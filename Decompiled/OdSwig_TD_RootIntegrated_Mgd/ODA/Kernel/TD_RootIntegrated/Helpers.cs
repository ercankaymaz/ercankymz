using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading;

namespace ODA.Kernel.TD_RootIntegrated;

public class Helpers
{
	private delegate OdRxObject OdRxObjectDynamicCreatorDelegate(IntPtr nativePtr, bool own);

	private delegate object DefaultObjectDynamicCreatorDelegate(IntPtr nativePtr, bool own);

	private class OdAssembliesContoller
	{
		private ConcurrentDictionary<string, Type> m_className2TypeCache = new ConcurrentDictionary<string, Type>();

		private HashSet<Assembly> m_processed = new HashSet<Assembly>();

		private string[] m_assemblyNames = Array.Empty<string>();

		private ReaderWriterLockSlim init_rwLocker = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

		private string m_originalCompanyName;

		public OdAssembliesContoller()
		{
			m_originalCompanyName = GetOriginalCompanyName();
			InitListOfLoadedAssemblies(null, null);
			AppDomain.CurrentDomain.AssemblyLoad += InitListOfLoadedAssemblies;
		}

		private string GetOriginalCompanyName()
		{
			return GetCompanyName(GetType().Assembly);
		}

		private bool AssemblyFromODA(Assembly assembly)
		{
			string companyName = GetCompanyName(assembly);
			if (companyName != null && companyName == m_originalCompanyName)
			{
				return true;
			}
			return false;
		}

		private string GetCompanyName(Assembly assembly)
		{
			object[] customAttributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), inherit: true);
			if (customAttributes.Length != 0)
			{
				return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
			}
			return null;
		}

		private void InitListOfLoadedAssemblies(object sender, AssemblyLoadEventArgs args)
		{
			init_rwLocker.EnterWriteLock();
			try
			{
				new List<string>();
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					if (!AssemblyFromODA(assembly) || m_processed.Contains(assembly))
					{
						continue;
					}
					m_processed.Add(assembly);
					_ = assembly.GetName().Name;
					try
					{
						Type[] types = assembly.GetTypes();
						foreach (Type type in types)
						{
							AddTypeToCache(type.Name, type);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			finally
			{
				init_rwLocker.ExitWriteLock();
			}
		}

		private Type GetTypeFromCache(string typeName)
		{
			Type value = null;
			m_className2TypeCache.TryGetValue(typeName, out value);
			return value;
		}

		private void AddTypeToCache(string typeName, Type type)
		{
			m_className2TypeCache.TryAdd(typeName, type);
		}

		public Type GetTypeFromCppType(string typeName)
		{
			return GetTypeFromCache(typeName);
		}
	}

	[Flags]
	private enum VertexDataFields
	{
		HasVertexData = 1,
		HasFaceData = 2,
		HasEdgeData = 4,
		HasEdgeColors = 8,
		HasEdgeTrueColors = 0x10,
		HasEdgeLayerIds = 0x20,
		HasEdgeLinetypeIds = 0x40,
		HasEdgeSelectionMarkers = 0x80,
		HasEdgeVisibilities = 0x100,
		HasFaceColors = 0x200,
		HasFaceTrueColors = 0x400,
		HasFaceLayerIds = 0x800,
		HasFaceSelectionMarkers = 0x1000,
		HasFaceVisibilities = 0x2000,
		HasFaceNormals = 0x4000,
		HasFaceMaterialIds = 0x8000,
		HasFaceMappers = 0x10000,
		HasFaceTransparency = 0x20000,
		HasVertexNormals = 0x40000,
		HasVertexTrueColors = 0x80000
	}

	public class VariantPointerHolder
	{
		private static VariantPointerHolder m_holder = new VariantPointerHolder();

		private List<IntPtr> m_collection;

		private VariantPointerHolder()
		{
			m_collection = new List<IntPtr>();
		}

		~VariantPointerHolder()
		{
			Clear();
		}

		public static void Add(IntPtr ptr)
		{
			if (ptr != IntPtr.Zero)
			{
				m_holder.m_collection.Add(ptr);
			}
		}

		public static void Clear()
		{
			foreach (IntPtr item in m_holder.m_collection)
			{
				FreeVariant(item);
			}
			m_holder.m_collection.Clear();
		}
	}

	private static ConcurrentDictionary<Type, DefaultObjectDynamicCreatorDelegate> default_types_constructorMap;

	private static ConcurrentDictionary<IntPtr, OdRxObjectDynamicCreatorDelegate> rx_objects_constructorMap;

	private static ConcurrentDictionary<Type, HashSet<Type>> m_IncompatibleCast;

	private static readonly ConcurrentDictionary<Type, FieldInfo> cache_swigCMemOwnField;

	private static readonly ConcurrentDictionary<Type, Func<IntPtr, bool, object>> ConstructorCache;

	private static OdAssembliesContoller m_assembliesInfo;

	private static readonly ConcurrentDictionary<Type, MethodInfo> methodCache;

	private static readonly ConcurrentDictionary<string, Type> classNameToTypeCache;

	public static void odUninit()
	{
		rx_objects_constructorMap.Clear();
		default_types_constructorMap.Clear();
		DelegateHolder.Clear();
		PointerHolder.Clear();
		cache_swigCMemOwnField.Clear();
	}

	public static OdRxObject odrxCreateObjectInternal(IntPtr p, bool own)
	{
		if (p == IntPtr.Zero)
		{
			return null;
		}
		OdRxObjectDynamicCreatorDelegate odRxObjectDynamicCreatorDelegate = odrxFindCreatorDelegate(TD_RootIntegrated_GlobalsPINVOKE.OdRxObject_isA(new HandleRef(null, p)), p);
		if (odRxObjectDynamicCreatorDelegate == null)
		{
			return new OdRxObject(p, own);
		}
		return odRxObjectDynamicCreatorDelegate(p, own);
	}

	private static bool CheckCast(Type targetType, object value)
	{
		bool result = true;
		try
		{
			if (m_IncompatibleCast.ContainsKey(targetType) && m_IncompatibleCast[targetType].Contains(value.GetType()))
			{
				return false;
			}
			if (value?.CastToExpr(targetType) == null)
			{
				result = false;
			}
		}
		catch (Exception)
		{
			if (!m_IncompatibleCast.ContainsKey(targetType))
			{
				m_IncompatibleCast.TryAdd(targetType, new HashSet<Type> { value.GetType() });
			}
			else if (!m_IncompatibleCast[targetType].Contains(value.GetType()))
			{
				m_IncompatibleCast[targetType].Add(value.GetType());
			}
			result = false;
		}
		return result;
	}

	internal static void ChangeSwigMemoryOwn(object obj, bool newOwnValue)
	{
		Type type = obj.GetType();
		FieldInfo field = type.GetField("swigCMemOwn", BindingFlags.Instance | BindingFlags.NonPublic);
		if (field != null)
		{
			field.SetValue(obj, newOwnValue);
		}
		FieldInfo field2 = type.GetField("swigCMemOwnBase", BindingFlags.Instance | BindingFlags.NonPublic);
		if (field2 != null)
		{
			field2.SetValue(obj, newOwnValue);
		}
	}

	internal static IntPtr GetSwigCPtr(object obj)
	{
		if (obj == null)
		{
			throw new ArgumentNullException("obj");
		}
		Type type = obj.GetType();
		FieldInfo orAdd = cache_swigCMemOwnField.GetOrAdd(type, delegate(Type currentType)
		{
			FieldInfo fieldInfo = null;
			do
			{
				fieldInfo = currentType.GetField("swigCPtr", BindingFlags.Instance | BindingFlags.NonPublic);
				if (fieldInfo != null)
				{
					return fieldInfo;
				}
				currentType = currentType.BaseType;
			}
			while (currentType != null);
			return (FieldInfo)null;
		});
		if (orAdd != null)
		{
			return ((HandleRef)orAdd.GetValue(obj)).Handle;
		}
		return IntPtr.Zero;
	}

	public static object CopyObjectWithoutOwn(object original)
	{
		if (original == null)
		{
			return null;
		}
		Type type = original.GetType();
		ConstructorInfo constructor = type.GetConstructor(new Type[2]
		{
			typeof(IntPtr),
			typeof(bool)
		});
		if (constructor == null)
		{
			throw new InvalidOperationException("No suitable constructor found for type " + type.FullName);
		}
		IntPtr swigCPtr = GetSwigCPtr(original);
		if (swigCPtr == IntPtr.Zero)
		{
			throw new InvalidOperationException("Invalid IntPtr, unable to create a new instance of type " + type.FullName);
		}
		return constructor.Invoke(new object[2] { swigCPtr, false });
	}

	public static TType GetRXObject<TType>(IntPtr ptr, bool bOwn, bool bTryAddToTransaction) where TType : OdRxObject
	{
		if (ptr == IntPtr.Zero)
		{
			return null;
		}
		TType val = (TType)odrxCreateObjectInternalUniversal(typeof(TType), ptr, bOwn);
		if (!bOwn)
		{
			return val;
		}
		if (bTryAddToTransaction)
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			bool num = currentTransaction != null;
			if (num)
			{
				currentTransaction.AddObject(val);
			}
			return num ? ((TType)CopyObjectWithoutOwn(val)) : val;
		}
		return val;
	}

	public static TType GetObject<TType>(IntPtr ptr, bool bOwn, bool bTryAddToTransaction) where TType : class, IDisposable
	{
		if (ptr == IntPtr.Zero)
		{
			return null;
		}
		Tuple<TType, TType> tuple = odCreateObjectInternal<TType>(typeof(TType), ptr, bOwn, bTryAddToTransaction);
		TType item = tuple.Item1;
		TType item2 = tuple.Item2;
		if (!bOwn)
		{
			return item;
		}
		if (bTryAddToTransaction)
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			if (currentTransaction != null)
			{
				currentTransaction.AddObject(item);
				return item2;
			}
			return item;
		}
		return item;
	}

	public static OdRxObject odrxCreateObjectInternalUniversal(Type targetType, IntPtr targetNativeObj, bool own)
	{
		if (targetNativeObj == IntPtr.Zero)
		{
			return null;
		}
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxObject_isA(new HandleRef(null, targetNativeObj));
		if (intPtr == IntPtr.Zero)
		{
			return odCreateObjectInternal<OdRxObject>(targetType, targetNativeObj, own);
		}
		OdRxObjectDynamicCreatorDelegate odRxObjectDynamicCreatorDelegate = odrxFindCreatorDelegate(intPtr, targetNativeObj);
		OdRxObject odRxObject = null;
		if (odRxObjectDynamicCreatorDelegate != null)
		{
			if (targetType != typeof(OdRxObject) && odRxObjectDynamicCreatorDelegate.Method.Name != "CreateObject_OdRxObject")
			{
				odRxObject = odRxObjectDynamicCreatorDelegate(targetNativeObj, own: false);
			}
			else if (targetType == typeof(OdRxObject) && odRxObjectDynamicCreatorDelegate.Method.Name != "CreateObject_OdRxObject")
			{
				odRxObject = odRxObjectDynamicCreatorDelegate(targetNativeObj, own: false);
			}
			else if (targetType == typeof(OdRxObject))
			{
				odRxObject = new OdRxObject(targetNativeObj, cMemoryOwn: false);
			}
		}
		if (!CheckCast(targetType, odRxObject))
		{
			DefaultObjectDynamicCreatorDelegate defaultObjectDynamicCreatorDelegate = odFindCreatorDelegate(targetType, targetNativeObj);
			if (defaultObjectDynamicCreatorDelegate != null)
			{
				odRxObject = defaultObjectDynamicCreatorDelegate(targetNativeObj, own: false) as OdRxObject;
			}
			else
			{
				ConstructorInfo constructor = targetType.GetConstructor(new Type[2]
				{
					typeof(IntPtr),
					typeof(bool)
				});
				odRxObject = ((!(constructor == null)) ? (constructor.Invoke(new object[2] { targetNativeObj, false }) as OdRxObject) : new OdRxObject(targetNativeObj, cMemoryOwn: false));
			}
		}
		if (own)
		{
			ChangeSwigMemoryOwn(odRxObject, own);
		}
		return odRxObject;
	}

	public static T odCreateObjectInternal<T>(Type basetype, IntPtr targetNativeObj, bool bIsWrapperOwnNativeObject) where T : class
	{
		if (targetNativeObj == IntPtr.Zero || basetype == null)
		{
			return null;
		}
		DefaultObjectDynamicCreatorDelegate defaultObjectDynamicCreatorDelegate = odFindCreatorDelegate(basetype, targetNativeObj);
		T val = null;
		if (defaultObjectDynamicCreatorDelegate != null)
		{
			return defaultObjectDynamicCreatorDelegate(targetNativeObj, bIsWrapperOwnNativeObject) as T;
		}
		ConstructorInfo constructor = basetype.GetConstructor(new Type[2]
		{
			typeof(IntPtr),
			typeof(bool)
		});
		if (constructor == null)
		{
			return null;
		}
		return constructor.Invoke(new object[2] { targetNativeObj, bIsWrapperOwnNativeObject }) as T;
	}

	private static Func<IntPtr, bool, object> GetConstructorDelegate(Type type)
	{
		if (ConstructorCache.TryGetValue(type, out var value))
		{
			return value;
		}
		ConstructorInfo constructor = type.GetConstructor(new Type[2]
		{
			typeof(IntPtr),
			typeof(bool)
		});
		if (constructor == null)
		{
			throw new InvalidOperationException($"Type {type} has no constructor with signature (IntPtr, bool)");
		}
		ParameterExpression parameterExpression = Expression.Parameter(typeof(IntPtr), "ptr");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(bool), "own");
		Func<IntPtr, bool, object> func = Expression.Lambda<Func<IntPtr, bool, object>>(Expression.New(constructor, parameterExpression, parameterExpression2), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
		ConstructorCache[type] = func;
		return func;
	}

	public static T CreateWrapperInstance<T>(IntPtr targetNativeObj, bool bIsWrapperOwnNativeObject) where T : class
	{
		return (T)GetConstructorDelegate(typeof(T))(targetNativeObj, bIsWrapperOwnNativeObject);
	}

	public static Tuple<T, T> odCreateObjectInternal<T>(Type basetype, IntPtr targetNativeObj, bool bIsWrapperOwnNativeObject, bool bCreateCloneWithOwnMemFalse) where T : class
	{
		if (targetNativeObj == IntPtr.Zero || basetype == null)
		{
			return new Tuple<T, T>(null, null);
		}
		DefaultObjectDynamicCreatorDelegate defaultObjectDynamicCreatorDelegate = odFindCreatorDelegate(basetype, targetNativeObj);
		T val = null;
		T item = null;
		if (defaultObjectDynamicCreatorDelegate != null)
		{
			val = defaultObjectDynamicCreatorDelegate(targetNativeObj, bIsWrapperOwnNativeObject) as T;
			if (bCreateCloneWithOwnMemFalse)
			{
				item = defaultObjectDynamicCreatorDelegate(targetNativeObj, own: false) as T;
			}
		}
		else
		{
			try
			{
				val = CreateWrapperInstance<T>(targetNativeObj, bIsWrapperOwnNativeObject);
				if (bCreateCloneWithOwnMemFalse)
				{
					item = CreateWrapperInstance<T>(targetNativeObj, bIsWrapperOwnNativeObject: false);
				}
			}
			catch (Exception)
			{
				return new Tuple<T, T>(null, null);
			}
		}
		return new Tuple<T, T>(val, item);
	}

	private static bool ValidationClassName(string className)
	{
		bool result = true;
		if (className.Contains(" "))
		{
			result = false;
		}
		else if (className.Contains("<"))
		{
			result = false;
		}
		return result;
	}

	static Helpers()
	{
		default_types_constructorMap = new ConcurrentDictionary<Type, DefaultObjectDynamicCreatorDelegate>();
		rx_objects_constructorMap = new ConcurrentDictionary<IntPtr, OdRxObjectDynamicCreatorDelegate>();
		m_IncompatibleCast = new ConcurrentDictionary<Type, HashSet<Type>>();
		cache_swigCMemOwnField = new ConcurrentDictionary<Type, FieldInfo>();
		ConstructorCache = new ConcurrentDictionary<Type, Func<IntPtr, bool, object>>();
		m_assembliesInfo = null;
		methodCache = new ConcurrentDictionary<Type, MethodInfo>();
		classNameToTypeCache = new ConcurrentDictionary<string, Type>();
		m_assembliesInfo = new OdAssembliesContoller();
		AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
		AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
	}

	private static void OnProcessExit(object sender, EventArgs e)
	{
		odUninit();
		TD_RootIntegrated_GlobalsPINVOKE.Free_OdSmartPtrMemoryManagment();
	}

	private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		odUninit();
		TD_RootIntegrated_GlobalsPINVOKE.Free_OdSmartPtrMemoryManagment();
	}

	private static Type FindTypeFromOdaAssemblies(string className)
	{
		if (!ValidationClassName(className))
		{
			return null;
		}
		className = className.Replace("::", "_");
		try
		{
			Type type = null;
			if (className.StartsWith("SwigDirector_"))
			{
				type = m_assembliesInfo.GetTypeFromCppType(className.Substring(13));
			}
			if (type == null)
			{
				type = m_assembliesInfo.GetTypeFromCppType($"{className}_Internal");
			}
			if (type == null)
			{
				type = m_assembliesInfo.GetTypeFromCppType(className);
			}
			if (type == null)
			{
				string text = null;
				if (className.StartsWith("Aecc"))
				{
					text = "AECC" + className.Substring(4);
					type = m_assembliesInfo.GetTypeFromCppType(text);
				}
				if (type == null && className.StartsWith("Aec"))
				{
					text = "AEC" + className.Substring(3);
					type = m_assembliesInfo.GetTypeFromCppType(text);
				}
				if (type == null && className.StartsWith("Ac"))
				{
					text = "Od" + className.Substring(2);
					type = m_assembliesInfo.GetTypeFromCppType(text);
				}
			}
			return type;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static TDelegate GenerateDynamicCreatorDelegate<TDelegate, TCastReturnClassType>(Type type, string className) where TDelegate : class
	{
		try
		{
			ConstructorInfo constructor = type.GetConstructor(new Type[2]
			{
				typeof(IntPtr),
				typeof(bool)
			});
			DynamicMethod dynamicMethod = new DynamicMethod("CreateObject_" + className, typeof(TCastReturnClassType), new Type[2]
			{
				typeof(IntPtr),
				typeof(bool)
			});
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldarg_1);
			iLGenerator.Emit(OpCodes.Newobj, constructor);
			iLGenerator.Emit(OpCodes.Castclass, typeof(TCastReturnClassType));
			iLGenerator.Emit(OpCodes.Ret);
			return dynamicMethod.CreateDelegate(typeof(TDelegate)) as TDelegate;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static OdRxObjectDynamicCreatorDelegate odrxFindCreatorDelegate(IntPtr isa, IntPtr p)
	{
		if (rx_objects_constructorMap.TryGetValue(isa, out var value))
		{
			return value;
		}
		lock (rx_objects_constructorMap)
		{
			if (rx_objects_constructorMap.TryGetValue(isa, out value))
			{
				return value;
			}
			string className = TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_name(new HandleRef(null, isa));
			Type type = FindTypeFromOdaAssemblies(className);
			if (type == null)
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_myParent(new HandleRef(null, isa));
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return odrxFindCreatorDelegate(intPtr, IntPtr.Zero);
			}
			OdRxObjectDynamicCreatorDelegate odRxObjectDynamicCreatorDelegate = GenerateDynamicCreatorDelegate<OdRxObjectDynamicCreatorDelegate, OdRxObject>(type, className);
			rx_objects_constructorMap.TryAdd(isa, odRxObjectDynamicCreatorDelegate);
			return odRxObjectDynamicCreatorDelegate;
		}
	}

	private static string PrepareClassNameFromRTTI(string from)
	{
		string[] array = from.Split(' ');
		if (array.Length == 2)
		{
			return array[1];
		}
		return from;
	}

	private static DefaultObjectDynamicCreatorDelegate odFindCreatorDelegate(Type basetype, IntPtr targetNativeObj)
	{
		if (basetype == null || targetNativeObj == IntPtr.Zero)
		{
			return null;
		}
		MethodInfo orAdd = methodCache.GetOrAdd(basetype, (Type type) => type.GetMethod("getRealClassName", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy));
		if (orAdd == null)
		{
			return null;
		}
		string text = PrepareClassNameFromRTTI(orAdd.Invoke(null, new object[1] { targetNativeObj }) as string);
		Type orAdd2 = classNameToTypeCache.GetOrAdd(text, FindTypeFromOdaAssemblies);
		if (orAdd2 == null)
		{
			return null;
		}
		if (default_types_constructorMap.TryGetValue(orAdd2, out var value))
		{
			return value;
		}
		lock (default_types_constructorMap)
		{
			if (default_types_constructorMap.TryGetValue(orAdd2, out value))
			{
				return value;
			}
			DefaultObjectDynamicCreatorDelegate defaultObjectDynamicCreatorDelegate = GenerateDynamicCreatorDelegate<DefaultObjectDynamicCreatorDelegate, object>(orAdd2, text);
			default_types_constructorMap.TryAdd(orAdd2, defaultObjectDynamicCreatorDelegate);
			return defaultObjectDynamicCreatorDelegate;
		}
	}

	public static IntPtr MarshalDCClipRegion(OdGsDCPointArray[] contours)
	{
		int num = 4 + 4 * contours.Length;
		OdGsDCPointArray[] array = contours;
		foreach (OdGsDCPointArray odGsDCPointArray in array)
		{
			num += odGsDCPointArray.Count * 2 * 4;
		}
		IntPtr intPtr = Marshal.AllocCoTaskMem(num);
		Marshal.WriteInt32(intPtr, contours.Length);
		int num2 = 4;
		array = contours;
		foreach (OdGsDCPointArray odGsDCPointArray2 in array)
		{
			Marshal.WriteInt32(intPtr, num2, odGsDCPointArray2.Count);
			num2 += 4;
		}
		for (int j = 0; j < contours.Length; j++)
		{
			for (int k = 0; k < contours[j].Count; k++)
			{
				num2 = copyBytes(intPtr, num2, BitConverter.GetBytes(contours[j][k].x));
				num2 = copyBytes(intPtr, num2, BitConverter.GetBytes(contours[j][k].y));
			}
		}
		return intPtr;
	}

	public static OdGsDCPointArray[] UnMarshalDCClipRegion(IntPtr pts)
	{
		byte[] array = new byte[4];
		Marshal.Copy(pts, array, 0, 4);
		int num = BitConverter.ToInt32(array, 0);
		byte[] array2 = new byte[num * 4];
		Marshal.Copy(pts, array2, 4, 4 * num);
		int[] array3 = new int[num];
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < num; i++)
		{
			array3[i] = BitConverter.ToInt32(array2, num2);
			num2 += 4;
			num3 += array3[i];
		}
		byte[] array4 = new byte[8 * num3];
		Marshal.Copy(pts, array4, 4 + 4 * num, 8 * num3);
		OdGsDCPointArray[] array5 = new OdGsDCPointArray[num];
		for (int j = 0; j < num; j++)
		{
			array5[j] = new OdGsDCPointArray();
		}
		num2 = 0;
		for (int k = 0; k < num; k++)
		{
			for (int l = 0; l < array3[k]; l++)
			{
				int xx = BitConverter.ToInt32(array4, num2);
				num2 += 4;
				int yy = BitConverter.ToInt32(array4, num2);
				num2 += 4;
				array5[k].Add(new OdGsDCPoint(xx, yy));
			}
		}
		return array5;
	}

	public static IntPtr MarshalClipRegion(OdGePoint2dArray[] contours)
	{
		int num = 4 + 4 * contours.Length;
		OdGePoint2dArray[] array = contours;
		foreach (OdGePoint2dArray odGePoint2dArray in array)
		{
			num += odGePoint2dArray.Count * 2 * 8;
		}
		IntPtr intPtr = Marshal.AllocCoTaskMem(num);
		Marshal.WriteInt32(intPtr, contours.Length);
		int num2 = 4;
		array = contours;
		foreach (OdGePoint2dArray odGePoint2dArray2 in array)
		{
			Marshal.WriteInt32(intPtr, num2, odGePoint2dArray2.Count);
			num2 += 4;
		}
		for (int j = 0; j < contours.Length; j++)
		{
			for (int k = 0; k < contours[j].Count; k++)
			{
				num2 = copyBytes(intPtr, num2, BitConverter.GetBytes(contours[j][k].x));
				num2 = copyBytes(intPtr, num2, BitConverter.GetBytes(contours[j][k].y));
			}
		}
		return intPtr;
	}

	public static OdGePoint2dArray[] UnMarshalClipRegion(IntPtr pts)
	{
		byte[] array = new byte[4];
		Marshal.Copy(pts, array, 0, 4);
		int num = BitConverter.ToInt32(array, 0);
		byte[] array2 = new byte[num * 4];
		Marshal.Copy(pts, array2, 4, 4 * num);
		int[] array3 = new int[num];
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < num; i++)
		{
			array3[i] = BitConverter.ToInt32(array2, num2);
			num2 += 4;
			num3 += array3[i];
		}
		byte[] array4 = new byte[16 * num3];
		Marshal.Copy(pts, array4, 4 + 4 * num, 16 * num3);
		OdGePoint2dArray[] array5 = new OdGePoint2dArray[num];
		for (int j = 0; j < num; j++)
		{
			array5[j] = new OdGePoint2dArray();
		}
		num2 = 0;
		for (int k = 0; k < num; k++)
		{
			for (int l = 0; l < array3[k]; l++)
			{
				double xx = BitConverter.ToDouble(array4, num2);
				num2 += 8;
				double yy = BitConverter.ToDouble(array4, num2);
				num2 += 8;
				array5[k].Add(new OdGePoint2d(xx, yy));
			}
		}
		return array5;
	}

	private static int copyBytes(IntPtr data, int N, byte[] bb)
	{
		if (bb != null)
		{
			foreach (byte val in bb)
			{
				Marshal.WriteByte(data, N++, val);
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, bool[] arr)
	{
		if (arr != null)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				N = copyBytes(data, N, BitConverter.GetBytes(arr[i]));
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, OdGsDCPoint[] pts)
	{
		if (pts != null)
		{
			for (int i = 0; i < pts.Length; i++)
			{
				N = copyBytes(data, N, BitConverter.GetBytes(pts[i].x));
				N = copyBytes(data, N, BitConverter.GetBytes(pts[i].y));
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, OdGePoint3d[] pts)
	{
		if (pts != null)
		{
			for (int i = 0; i < pts.Length; i++)
			{
				N = copyBytes(data, N, BitConverter.GetBytes(pts[i].x));
				N = copyBytes(data, N, BitConverter.GetBytes(pts[i].y));
				N = copyBytes(data, N, BitConverter.GetBytes(pts[i].z));
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, OdGePoint2d[] pts)
	{
		if (pts != null)
		{
			for (int i = 0; i < pts.Length; i++)
			{
				N = copyBytes(data, N, BitConverter.GetBytes(pts[i].x));
				N = copyBytes(data, N, BitConverter.GetBytes(pts[i].y));
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, OdGeVector3d[] pts)
	{
		if (pts != null)
		{
			for (int i = 0; i < pts.Length; i++)
			{
				N = copyBytes(data, N, BitConverter.GetBytes(pts[i].x));
				N = copyBytes(data, N, BitConverter.GetBytes(pts[i].y));
				N = copyBytes(data, N, BitConverter.GetBytes(pts[i].z));
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, OdCmEntityColor[] cc)
	{
		if (cc != null)
		{
			for (int i = 0; i < cc.Length; i++)
			{
				Marshal.WriteInt32(data, N, (int)cc[i].color());
				N += 4;
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, int[] cc)
	{
		if (cc != null)
		{
			for (int i = 0; i < cc.Length; i++)
			{
				Marshal.WriteInt32(data, N, cc[i]);
				N += 4;
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, ushort[] cc)
	{
		if (cc != null)
		{
			for (int i = 0; i < cc.Length; i++)
			{
				Marshal.WriteInt16(data, N, (short)cc[i]);
				N += 2;
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, OdDbStub[] cc)
	{
		if (cc != null)
		{
			for (int i = 0; i < cc.Length; i++)
			{
				IntPtr handle = OdDbStub.getCPtr(cc[i]).Handle;
				Marshal.WriteIntPtr(data, N, handle);
				N += Marshal.SizeOf(handle);
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, OdGiMapper[] cc)
	{
		if (cc != null)
		{
			for (int i = 0; i < cc.Length; i++)
			{
				IntPtr handle = OdGiMapper.getCPtr(cc[i]).Handle;
				Marshal.WriteIntPtr(data, N, handle);
				N += Marshal.SizeOf(handle);
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, OdCmTransparency[] cc)
	{
		if (cc != null)
		{
			for (int i = 0; i < cc.Length; i++)
			{
				IntPtr handle = OdCmTransparency.getCPtr(cc[i]).Handle;
				Marshal.WriteIntPtr(data, N, handle);
				N += Marshal.SizeOf(handle);
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, IntPtr[] cc)
	{
		if (cc != null)
		{
			for (int i = 0; i < cc.Length; i++)
			{
				Marshal.WriteIntPtr(data, N, cc[i]);
				N += Marshal.SizeOf(cc[i]);
			}
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, VertexData vd)
	{
		if (vd != null)
		{
			Marshal.WriteInt32(data, N, (int)vd.OrientationFlag);
			N += 4;
			N = copyBytes(data, N, vd.Normals);
			N = copyBytes(data, N, vd.TrueColors);
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, EdgeData ed)
	{
		if (ed != null)
		{
			N = copyBytes(data, N, ed.Colors);
			N = copyBytes(data, N, ed.LayerIds);
			N = copyBytes(data, N, ed.LinetypeIds);
			N = copyBytes(data, N, ed.SelectionMarkers);
			N = copyBytes(data, N, ed.TrueColors);
			N = copyBytes(data, N, ed.Visibilities);
		}
		return N;
	}

	private static int copyBytes(IntPtr data, int N, FaceData fd)
	{
		if (fd != null)
		{
			N = copyBytes(data, N, fd.Colors);
			N = copyBytes(data, N, fd.LayerIds);
			N = copyBytes(data, N, fd.Mappers);
			N = copyBytes(data, N, fd.MaterialIds);
			N = copyBytes(data, N, fd.Normals);
			N = copyBytes(data, N, fd.SelectionMarkers);
			N = copyBytes(data, N, fd.Transparency);
			N = copyBytes(data, N, fd.TrueColors);
			N = copyBytes(data, N, fd.Visibilities);
		}
		return N;
	}

	public static IntPtr MarshalPointPair(OdGePoint3d[] pts)
	{
		return MarshalPointFixedArray(pts, 2);
	}

	public static OdGePoint3d[] UnMarshalPointPair(IntPtr pts)
	{
		return UnMarshalPointFixedArray(pts, 2);
	}

	public static IntPtr MarshalPoint2dPair(OdGePoint2d[] pts)
	{
		return MarshalPoint2dFixedArray(pts, 2);
	}

	public static OdGePoint2d[] UnMarshalPoint2dPair(IntPtr pts)
	{
		return UnMarshalPoint2dFixedArray(pts, 2);
	}

	public static IntPtr MarshalOdGsDCPointArray(OdGsDCPoint[] pts)
	{
		IntPtr intPtr = Marshal.AllocCoTaskMem(4 + pts.Length * 2 * 4);
		Marshal.WriteInt32(intPtr, pts.Length);
		copyBytes(intPtr, 4, pts);
		return intPtr;
	}

	public static OdGsDCPoint[] UnMarshalOdGsDCPointArray(IntPtr pts)
	{
		int num = Marshal.ReadInt32(pts);
		int num2 = num * 2 * 4 + 4;
		byte[] array = new byte[num2];
		Marshal.Copy(pts, array, 0, num2);
		OdGsDCPoint[] array2 = new OdGsDCPoint[num];
		int num3 = 4;
		for (int i = 0; i < num; i++)
		{
			int xx = BitConverter.ToInt32(array, num3);
			num3 += 4;
			int yy = BitConverter.ToInt32(array, num3);
			num3 += 4;
			array2[i] = new OdGsDCPoint(xx, yy);
		}
		Marshal.FreeCoTaskMem(pts);
		return array2;
	}

	public static IntPtr MarshalPoint3dArray(OdGePoint3d[] pts)
	{
		IntPtr intPtr = Marshal.AllocCoTaskMem(4 + pts.Length * 3 * 8);
		Marshal.WriteInt32(intPtr, pts.Length);
		copyBytes(intPtr, 4, pts);
		return intPtr;
	}

	public static OdGePoint3d[] UnMarshalPoint3dArray(IntPtr pts)
	{
		int num = Marshal.ReadInt32(pts);
		int num2 = num * 3 * 8 + 4;
		byte[] array = new byte[num2];
		Marshal.Copy(pts, array, 0, num2);
		OdGePoint3d[] array2 = new OdGePoint3d[num];
		int num3 = 4;
		for (int i = 0; i < num; i++)
		{
			double xx = BitConverter.ToDouble(array, num3);
			num3 += 8;
			double yy = BitConverter.ToDouble(array, num3);
			num3 += 8;
			double zz = BitConverter.ToDouble(array, num3);
			num3 += 8;
			array2[i] = new OdGePoint3d(xx, yy, zz);
		}
		Marshal.FreeCoTaskMem(pts);
		return array2;
	}

	public static IntPtr MarshalPoint2dArray(OdGePoint2d[] pts)
	{
		IntPtr intPtr = Marshal.AllocCoTaskMem(4 + pts.Length * 2 * 8);
		Marshal.WriteInt32(intPtr, pts.Length);
		copyBytes(intPtr, 4, pts);
		return intPtr;
	}

	public static OdGePoint2d[] UnMarshalPoint2dArray(IntPtr pts)
	{
		int num = Marshal.ReadInt32(pts);
		int num2 = num * 2 * 8 + 4;
		byte[] array = new byte[num2];
		Marshal.Copy(pts, array, 0, num2);
		OdGePoint2d[] array2 = new OdGePoint2d[num];
		int num3 = 4;
		for (int i = 0; i < num; i++)
		{
			double xx = BitConverter.ToDouble(array, num3);
			num3 += 8;
			double yy = BitConverter.ToDouble(array, num3);
			num3 += 8;
			array2[i] = new OdGePoint2d(xx, yy);
		}
		Marshal.FreeCoTaskMem(pts);
		return array2;
	}

	private static void getVertextDataFlags(VertexData vd, int VertexCount, ref VertexDataFields dataAvailable, ref int Len)
	{
		if (vd != null)
		{
			dataAvailable |= VertexDataFields.HasVertexData;
			Len += 4;
			if (vd.Normals != null)
			{
				dataAvailable |= VertexDataFields.HasVertexNormals;
				Len += VertexCount * 3 * 8;
			}
			if (vd.TrueColors != null)
			{
				dataAvailable |= VertexDataFields.HasVertexTrueColors;
				Len += VertexCount * 4;
			}
		}
	}

	private static void getEdgeDataFlags(EdgeData ed, int EdgeCount, ref VertexDataFields dataAvailable, ref int Len)
	{
		if (ed != null)
		{
			dataAvailable |= VertexDataFields.HasEdgeData;
			if (ed.Colors != null)
			{
				dataAvailable |= VertexDataFields.HasEdgeColors;
				Len += EdgeCount * 2;
			}
			if (ed.LayerIds != null)
			{
				dataAvailable |= VertexDataFields.HasEdgeLayerIds;
				Len += EdgeCount * Marshal.SizeOf(IntPtr.Zero);
			}
			if (ed.LinetypeIds != null)
			{
				dataAvailable |= VertexDataFields.HasEdgeLinetypeIds;
				Len += EdgeCount * Marshal.SizeOf(IntPtr.Zero);
			}
			if (ed.SelectionMarkers != null)
			{
				dataAvailable |= VertexDataFields.HasEdgeSelectionMarkers;
				Len += EdgeCount * Marshal.SizeOf(IntPtr.Zero);
			}
			if (ed.TrueColors != null)
			{
				dataAvailable |= VertexDataFields.HasEdgeTrueColors;
				Len += EdgeCount * 4;
			}
			if (ed.Visibilities != null)
			{
				dataAvailable |= VertexDataFields.HasEdgeVisibilities;
				Len += EdgeCount;
			}
		}
	}

	private static void getFaceDataFlags(FaceData fd, int FaceCount, ref VertexDataFields dataAvailable, ref int Len)
	{
		if (fd != null)
		{
			dataAvailable |= VertexDataFields.HasFaceData;
			if (fd.Colors != null)
			{
				dataAvailable |= VertexDataFields.HasFaceColors;
				Len += FaceCount * 2;
			}
			if (fd.LayerIds != null)
			{
				dataAvailable |= VertexDataFields.HasFaceLayerIds;
				Len += FaceCount * Marshal.SizeOf(IntPtr.Zero);
			}
			if (fd.Mappers != null)
			{
				dataAvailable |= VertexDataFields.HasFaceMappers;
				Len += FaceCount * Marshal.SizeOf(IntPtr.Zero);
			}
			if (fd.MaterialIds != null)
			{
				dataAvailable |= VertexDataFields.HasFaceMaterialIds;
				Len += FaceCount * Marshal.SizeOf(IntPtr.Zero);
			}
			if (fd.Normals != null)
			{
				dataAvailable |= VertexDataFields.HasFaceNormals;
				Len += FaceCount * 3 * 8;
			}
			if (fd.SelectionMarkers != null)
			{
				dataAvailable |= VertexDataFields.HasFaceSelectionMarkers;
				Len += FaceCount * Marshal.SizeOf(IntPtr.Zero);
			}
			if (fd.Transparency != null)
			{
				dataAvailable |= VertexDataFields.HasFaceTransparency;
				Len += FaceCount * Marshal.SizeOf(IntPtr.Zero);
			}
			if (fd.TrueColors != null)
			{
				dataAvailable |= VertexDataFields.HasFaceTrueColors;
				Len += FaceCount * 4;
			}
			if (fd.Visibilities != null)
			{
				dataAvailable |= VertexDataFields.HasFaceVisibilities;
				Len += FaceCount;
			}
		}
	}

	public static IntPtr MarshalShellFacesData(ShellFacesData shellfaces)
	{
		int num = shellfaces.FaceList.Length;
		int edgeCount = num;
		int faceCount = num;
		int num2 = 8;
		num2 += 4 * num;
		VertexDataFields dataAvailable = (VertexDataFields)0;
		getEdgeDataFlags(shellfaces.EdgeData, edgeCount, ref dataAvailable, ref num2);
		getFaceDataFlags(shellfaces.FaceData, faceCount, ref dataAvailable, ref num2);
		IntPtr intPtr = Marshal.AllocCoTaskMem(num2);
		Marshal.WriteInt32(intPtr, num);
		int num3 = 4;
		Marshal.WriteInt32(intPtr, num3, (int)dataAvailable);
		num3 += 4;
		num3 = copyBytes(intPtr, num3, shellfaces.FaceList);
		num3 = copyBytes(intPtr, num3, shellfaces.EdgeData);
		num3 = copyBytes(intPtr, num3, shellfaces.FaceData);
		if (num3 != num2)
		{
			throw new InvalidOperationException($"Wrote {num3} bytes, allocated {num2}");
		}
		return intPtr;
	}

	public static IntPtr MarshalMeshData(MeshData mesh)
	{
		int num = mesh.NumColumns * mesh.NumRows;
		int edgeCount = (mesh.NumColumns - 1) * mesh.NumRows + mesh.NumColumns * (mesh.NumRows - 1);
		int faceCount = (mesh.NumColumns - 1) * (mesh.NumRows - 1);
		int Len = 12 + num * 3 * 8;
		VertexDataFields dataAvailable = (VertexDataFields)0;
		getVertextDataFlags(mesh.VertexData, num, ref dataAvailable, ref Len);
		getEdgeDataFlags(mesh.EdgeData, edgeCount, ref dataAvailable, ref Len);
		getFaceDataFlags(mesh.FaceData, faceCount, ref dataAvailable, ref Len);
		IntPtr intPtr = Marshal.AllocCoTaskMem(Len);
		Marshal.WriteInt32(intPtr, mesh.NumRows);
		int num2 = 4;
		Marshal.WriteInt32(intPtr, num2, mesh.NumColumns);
		num2 += 4;
		Marshal.WriteInt32(intPtr, num2, (int)dataAvailable);
		num2 += 4;
		num2 = copyBytes(intPtr, num2, mesh.VertexList);
		num2 = copyBytes(intPtr, num2, mesh.VertexData);
		num2 = copyBytes(intPtr, num2, mesh.EdgeData);
		num2 = copyBytes(intPtr, num2, mesh.FaceData);
		if (num2 != Len)
		{
			throw new InvalidOperationException($"Wrote {num2} bytes, allocated {Len}");
		}
		return intPtr;
	}

	public static IntPtr MarshalShellData(ShellData shell)
	{
		int num = shell.Points.Length;
		shell.getEdgesFacesCount(out var FaceCount, out var EdgeCount);
		int Len = 4 * (3 + shell.Faces.Length) + num * 3 * 8;
		VertexDataFields dataAvailable = (VertexDataFields)0;
		getVertextDataFlags(shell.VertexData, num, ref dataAvailable, ref Len);
		getEdgeDataFlags(shell.EdgeData, EdgeCount, ref dataAvailable, ref Len);
		getFaceDataFlags(shell.FaceData, FaceCount, ref dataAvailable, ref Len);
		IntPtr intPtr = Marshal.AllocCoTaskMem(Len);
		int num2 = 0;
		Marshal.WriteInt32(intPtr, num2, shell.Faces.Length);
		num2 += 4;
		Marshal.WriteInt32(intPtr, num2, num);
		num2 += 4;
		Marshal.WriteInt32(intPtr, num2, (int)dataAvailable);
		num2 += 4;
		num2 = copyBytes(intPtr, num2, shell.Faces);
		num2 = copyBytes(intPtr, num2, shell.Points);
		num2 = copyBytes(intPtr, num2, shell.VertexData);
		num2 = copyBytes(intPtr, num2, shell.EdgeData);
		num2 = copyBytes(intPtr, num2, shell.FaceData);
		if (num2 != Len)
		{
			throw new InvalidOperationException($"Wrote {num2} bytes, allocated {Len}");
		}
		return intPtr;
	}

	public static OdGePoint3d[] readPoints(IntPtr data, ref int N, int Len)
	{
		OdGePoint3d[] array = new OdGePoint3d[Len];
		byte[] array2 = new byte[24];
		for (int i = 0; i < Len; i++)
		{
			for (int j = 0; j < 24; j++)
			{
				array2[j] = Marshal.ReadByte(data, N++);
			}
			double xx = BitConverter.ToDouble(array2, 0);
			double yy = BitConverter.ToDouble(array2, 8);
			double zz = BitConverter.ToDouble(array2, 16);
			array[i] = new OdGePoint3d(xx, yy, zz);
		}
		return array;
	}

	public static OdGeVector3d[] readVectors(IntPtr data, ref int N, int Len)
	{
		OdGeVector3d[] array = new OdGeVector3d[Len];
		byte[] array2 = new byte[24];
		for (int i = 0; i < Len; i++)
		{
			for (int j = 0; j < 24; j++)
			{
				array2[j] = Marshal.ReadByte(data, N++);
			}
			double xx = BitConverter.ToDouble(array2, 0);
			double yy = BitConverter.ToDouble(array2, 8);
			double zz = BitConverter.ToDouble(array2, 16);
			array[i] = new OdGeVector3d(xx, yy, zz);
		}
		return array;
	}

	public static OdCmEntityColor[] readTrueColors(IntPtr data, ref int N, int Len)
	{
		OdCmEntityColor[] array = new OdCmEntityColor[Len];
		for (int i = 0; i < Len; i++)
		{
			array[i] = new OdCmEntityColor();
			array[i].setColor((uint)Marshal.ReadInt32(data, N));
			N += 4;
		}
		return array;
	}

	public static ushort[] readColors(IntPtr data, ref int N, int Len)
	{
		ushort[] array = new ushort[Len];
		for (int i = 0; i < Len; i++)
		{
			array[i] = (ushort)Marshal.ReadInt16(data, N);
			N += 2;
		}
		return array;
	}

	public static int[] readIntArray(IntPtr data, ref int N, int Len)
	{
		int[] array = new int[Len];
		for (int i = 0; i < Len; i++)
		{
			array[i] = Marshal.ReadInt32(data, N);
			N += 4;
		}
		return array;
	}

	public static OdDbStub[] readIds(IntPtr data, ref int N, int Len)
	{
		OdDbStub[] array = new OdDbStub[Len];
		for (int i = 0; i < Len; i++)
		{
			IntPtr intPtr = Marshal.ReadIntPtr(data, N);
			N += Marshal.SizeOf(intPtr);
			array[i] = new OdDbStub(intPtr, cMemoryOwn: false);
		}
		return array;
	}

	public static OdGiMapper[] readMappers(IntPtr data, ref int N, int Len)
	{
		OdGiMapper[] array = new OdGiMapper[Len];
		for (int i = 0; i < Len; i++)
		{
			IntPtr intPtr = Marshal.ReadIntPtr(data, N);
			N += Marshal.SizeOf(intPtr);
			array[i] = new OdGiMapper(intPtr, cMemoryOwn: false);
		}
		return array;
	}

	public static OdCmTransparency[] readTransparency(IntPtr data, ref int N, int Len)
	{
		OdCmTransparency[] array = new OdCmTransparency[Len];
		for (int i = 0; i < Len; i++)
		{
			IntPtr intPtr = Marshal.ReadIntPtr(data, N);
			N += Marshal.SizeOf(intPtr);
			array[i] = new OdCmTransparency(intPtr, cMemoryOwn: false);
		}
		return array;
	}

	public static IntPtr[] readIntPtrs(IntPtr data, ref int N, int Len)
	{
		IntPtr[] array = new IntPtr[Len];
		for (int i = 0; i < Len; i++)
		{
			array[i] = Marshal.ReadIntPtr(data, N);
			N += Marshal.SizeOf(array[i]);
		}
		return array;
	}

	public static byte[] readVisibilities(IntPtr data, ref int N, int Len)
	{
		byte[] array = new byte[Len];
		for (int i = 0; i < Len; i++)
		{
			array[i] = Marshal.ReadByte(data, N++);
		}
		return array;
	}

	private static VertexData readVertexData(VertexDataFields dataAvailable, int VertexCount, ref int N, IntPtr data)
	{
		VertexData vertexData = null;
		if ((dataAvailable & VertexDataFields.HasVertexData) != 0)
		{
			vertexData = new VertexData();
			vertexData.OrientationFlag = (OdGiOrientationType)Marshal.ReadInt32(data, N);
			N += 4;
			if ((dataAvailable & VertexDataFields.HasVertexNormals) != 0)
			{
				vertexData.Normals = readVectors(data, ref N, VertexCount);
			}
			if ((dataAvailable & VertexDataFields.HasVertexTrueColors) != 0)
			{
				vertexData.TrueColors = readTrueColors(data, ref N, VertexCount);
			}
		}
		return vertexData;
	}

	private static EdgeData readEdgeData(VertexDataFields dataAvailable, int EdgeCount, ref int N, IntPtr data)
	{
		EdgeData edgeData = null;
		if ((dataAvailable & VertexDataFields.HasEdgeData) != 0)
		{
			edgeData = new EdgeData();
			if ((dataAvailable & VertexDataFields.HasEdgeColors) != 0)
			{
				edgeData.Colors = readColors(data, ref N, EdgeCount);
			}
			if ((dataAvailable & VertexDataFields.HasEdgeLayerIds) != 0)
			{
				edgeData.LayerIds = readIds(data, ref N, EdgeCount);
			}
			if ((dataAvailable & VertexDataFields.HasEdgeLinetypeIds) != 0)
			{
				edgeData.LinetypeIds = readIds(data, ref N, EdgeCount);
			}
			if ((dataAvailable & VertexDataFields.HasEdgeSelectionMarkers) != 0)
			{
				edgeData.SelectionMarkers = readIntPtrs(data, ref N, EdgeCount);
			}
			if ((dataAvailable & VertexDataFields.HasEdgeTrueColors) != 0)
			{
				edgeData.TrueColors = readTrueColors(data, ref N, EdgeCount);
			}
			if ((dataAvailable & VertexDataFields.HasEdgeVisibilities) != 0)
			{
				edgeData.Visibilities = readVisibilities(data, ref N, EdgeCount);
			}
		}
		return edgeData;
	}

	private static FaceData readFaceData(VertexDataFields dataAvailable, int FaceCount, ref int N, IntPtr data)
	{
		FaceData faceData = null;
		if ((dataAvailable & VertexDataFields.HasFaceData) != 0)
		{
			faceData = new FaceData();
			if ((dataAvailable & VertexDataFields.HasFaceColors) != 0)
			{
				faceData.Colors = readColors(data, ref N, FaceCount);
			}
			if ((dataAvailable & VertexDataFields.HasFaceLayerIds) != 0)
			{
				faceData.LayerIds = readIds(data, ref N, FaceCount);
			}
			if ((dataAvailable & VertexDataFields.HasFaceMappers) != 0)
			{
				faceData.Mappers = readMappers(data, ref N, FaceCount);
			}
			if ((dataAvailable & VertexDataFields.HasFaceMaterialIds) != 0)
			{
				faceData.MaterialIds = readIds(data, ref N, FaceCount);
			}
			if ((dataAvailable & VertexDataFields.HasFaceNormals) != 0)
			{
				faceData.Normals = readVectors(data, ref N, FaceCount);
			}
			if ((dataAvailable & VertexDataFields.HasFaceSelectionMarkers) != 0)
			{
				faceData.SelectionMarkers = readIntPtrs(data, ref N, FaceCount);
			}
			if ((dataAvailable & VertexDataFields.HasFaceTransparency) != 0)
			{
				faceData.Transparency = readTransparency(data, ref N, FaceCount);
			}
			if ((dataAvailable & VertexDataFields.HasFaceTrueColors) != 0)
			{
				faceData.TrueColors = readTrueColors(data, ref N, FaceCount);
			}
			if ((dataAvailable & VertexDataFields.HasFaceVisibilities) != 0)
			{
				faceData.Visibilities = readVisibilities(data, ref N, FaceCount);
			}
		}
		return faceData;
	}

	public static ShellFacesData UnMarshalShellFacesData(IntPtr data)
	{
		if (data == IntPtr.Zero)
		{
			return null;
		}
		ShellFacesData shellFacesData = new ShellFacesData();
		int num = Marshal.ReadInt32(data);
		int num2 = 4;
		VertexDataFields dataAvailable = (VertexDataFields)Marshal.ReadInt32(data, num2);
		num2 += 4;
		shellFacesData.FaceList = readIntArray(data, ref num2, num);
		shellFacesData.EdgeData = readEdgeData(dataAvailable, num, ref num2, data);
		shellFacesData.FaceData = readFaceData(dataAvailable, num, ref num2, data);
		return shellFacesData;
	}

	public static MeshData UnMarshalFaceData(IntPtr data)
	{
		if (data == IntPtr.Zero)
		{
			return null;
		}
		MeshData meshData = new MeshData();
		meshData.NumRows = Marshal.ReadInt32(data);
		int num = 4;
		meshData.NumColumns = Marshal.ReadInt32(data, num);
		num += 4;
		VertexDataFields dataAvailable = (VertexDataFields)Marshal.ReadInt32(data, num);
		num += 4;
		_ = meshData.NumColumns;
		_ = meshData.NumRows;
		int faceCount = (meshData.NumColumns - 1) * (meshData.NumRows - 1);
		meshData.FaceData = readFaceData(dataAvailable, faceCount, ref num, data);
		return meshData;
	}

	public static IntPtr MarshalFaceData(MeshData mesh)
	{
		_ = mesh.NumColumns;
		_ = mesh.NumRows;
		_ = mesh.NumColumns;
		_ = mesh.NumRows;
		_ = mesh.NumColumns;
		_ = mesh.NumRows;
		int faceCount = (mesh.NumColumns - 1) * (mesh.NumRows - 1);
		int Len = 12;
		VertexDataFields dataAvailable = (VertexDataFields)0;
		getFaceDataFlags(mesh.FaceData, faceCount, ref dataAvailable, ref Len);
		IntPtr intPtr = Marshal.AllocCoTaskMem(Len);
		Marshal.WriteInt32(intPtr, mesh.NumRows);
		int num = 4;
		Marshal.WriteInt32(intPtr, num, mesh.NumColumns);
		num += 4;
		Marshal.WriteInt32(intPtr, num, (int)dataAvailable);
		num += 4;
		num = copyBytes(intPtr, num, mesh.FaceData);
		if (num != Len)
		{
			throw new InvalidOperationException($"Wrote {num} bytes, allocated {Len}");
		}
		return intPtr;
	}

	public static MeshData UnMarshalMeshData(IntPtr data)
	{
		if (data == IntPtr.Zero)
		{
			return null;
		}
		MeshData meshData = new MeshData();
		meshData.NumRows = Marshal.ReadInt32(data);
		int num = 4;
		meshData.NumColumns = Marshal.ReadInt32(data, num);
		num += 4;
		VertexDataFields dataAvailable = (VertexDataFields)Marshal.ReadInt32(data, num);
		num += 4;
		int num2 = meshData.NumColumns * meshData.NumRows;
		int edgeCount = (meshData.NumColumns - 1) * meshData.NumRows + meshData.NumColumns * (meshData.NumRows - 1);
		int faceCount = (meshData.NumColumns - 1) * (meshData.NumRows - 1);
		meshData.VertexList = readPoints(data, ref num, num2);
		meshData.VertexData = readVertexData(dataAvailable, num2, ref num, data);
		meshData.EdgeData = readEdgeData(dataAvailable, edgeCount, ref num, data);
		meshData.FaceData = readFaceData(dataAvailable, faceCount, ref num, data);
		return meshData;
	}

	public static ShellData UnMarshalShellData(IntPtr data)
	{
		if (data == IntPtr.Zero)
		{
			return null;
		}
		ShellData shellData = new ShellData();
		int len = Marshal.ReadInt32(data);
		int num = 4;
		int num2 = Marshal.ReadInt32(data, num);
		num += 4;
		VertexDataFields dataAvailable = (VertexDataFields)Marshal.ReadInt32(data, num);
		num += 4;
		shellData.Faces = readIntArray(data, ref num, len);
		shellData.Points = readPoints(data, ref num, num2);
		shellData.getEdgesFacesCount(out var FaceCount, out var EdgeCount);
		shellData.VertexData = readVertexData(dataAvailable, num2, ref num, data);
		shellData.EdgeData = readEdgeData(dataAvailable, EdgeCount, ref num, data);
		shellData.FaceData = readFaceData(dataAvailable, FaceCount, ref num, data);
		return shellData;
	}

	public static IntPtr MarshalPoint2dFixedArray(OdGePoint2d[] pts, int size)
	{
		if (pts == null)
		{
			return IntPtr.Zero;
		}
		if (pts.Length != size)
		{
			throw new Exception("MarshalPointFixedArray: wrong array length");
		}
		IntPtr intPtr = Marshal.AllocCoTaskMem(size * 2 * 8);
		copyBytes(intPtr, 0, pts);
		return intPtr;
	}

	public static OdGePoint2d[] UnMarshalPoint2dFixedArray(IntPtr pts, int size)
	{
		if (pts == IntPtr.Zero)
		{
			return null;
		}
		int num = size * 2 * 8;
		byte[] array = new byte[num];
		Marshal.Copy(pts, array, 0, num);
		OdGePoint2d[] array2 = new OdGePoint2d[size];
		int num2 = 0;
		for (int i = 0; i < size; i++)
		{
			double xx = BitConverter.ToDouble(array, num2);
			num2 += 8;
			double yy = BitConverter.ToDouble(array, num2);
			num2 += 8;
			array2[i] = new OdGePoint2d(xx, yy);
		}
		Marshal.FreeCoTaskMem(pts);
		return array2;
	}

	public static IntPtr MarshalboolFixedArray(bool[] arr)
	{
		if (arr == null)
		{
			return IntPtr.Zero;
		}
		return MarshalBoolFixedArray(arr, arr.Length);
	}

	public static IntPtr MarshalBoolFixedArray(bool[] arr, int size)
	{
		if (arr == null)
		{
			return IntPtr.Zero;
		}
		if (arr.Length != size)
		{
			throw new Exception("MarshalBoolFixedArray: wrong array length");
		}
		IntPtr intPtr = Marshal.AllocCoTaskMem(4 + size);
		Marshal.WriteInt32(intPtr, size);
		copyBytes(intPtr, 4, arr);
		return intPtr;
	}

	public static bool[] UnMarshalboolFixedArray(IntPtr arr)
	{
		if (arr == IntPtr.Zero)
		{
			return null;
		}
		int size = Marshal.ReadInt32(arr);
		return UnMarshalBoolFixedArray(arr, size);
	}

	public static bool[] UnMarshalBoolFixedArray(IntPtr arr, int size)
	{
		if (arr == IntPtr.Zero)
		{
			return null;
		}
		byte[] array = new byte[size];
		Marshal.Copy(arr, array, 4, size);
		bool[] array2 = new bool[size];
		int num = 0;
		for (int i = 0; i < size; i++)
		{
			array2[i] = BitConverter.ToBoolean(array, num);
			num++;
		}
		Marshal.FreeCoTaskMem(arr);
		return array2;
	}

	public static IntPtr MarshalPointFixedArray(OdGePoint3d[] pts, int size)
	{
		if (pts == null)
		{
			return IntPtr.Zero;
		}
		if (pts.Length != size)
		{
			throw new Exception("MarshalPointFixedArray: wrong array length");
		}
		IntPtr intPtr = Marshal.AllocCoTaskMem(size * 3 * 8);
		copyBytes(intPtr, 0, pts);
		return intPtr;
	}

	public static OdGePoint3d[] UnMarshalPointFixedArray(IntPtr pts, int size, bool bOwnPts = true)
	{
		if (pts == IntPtr.Zero)
		{
			return null;
		}
		int num = size * 3 * 8;
		byte[] array = new byte[num];
		Marshal.Copy(pts, array, 0, num);
		OdGePoint3d[] array2 = new OdGePoint3d[size];
		int num2 = 0;
		for (int i = 0; i < size; i++)
		{
			double xx = BitConverter.ToDouble(array, num2);
			num2 += 8;
			double yy = BitConverter.ToDouble(array, num2);
			num2 += 8;
			double zz = BitConverter.ToDouble(array, num2);
			num2 += 8;
			array2[i] = new OdGePoint3d(xx, yy, zz);
		}
		if (bOwnPts)
		{
			Marshal.FreeCoTaskMem(pts);
		}
		return array2;
	}

	public static IntPtr MarshaldoubleFixedArray(double[] pts)
	{
		if (pts == null)
		{
			return IntPtr.Zero;
		}
		int size = pts.Length;
		return MarshalDoubleFixedArray(pts, size);
	}

	public static IntPtr MarshalDoubleFixedArray(double[] pts, int size)
	{
		if (pts == null)
		{
			return IntPtr.Zero;
		}
		if (pts.Length != size)
		{
			throw new Exception("MarshalPointFixedArray: wrong array length");
		}
		IntPtr intPtr = Marshal.AllocCoTaskMem(size * 8);
		int n = 0;
		for (int i = 0; i < size; i++)
		{
			n = copyBytes(intPtr, n, BitConverter.GetBytes(pts[i]));
		}
		return intPtr;
	}

	public static double[] UnMarshaldoubleFixedArray(IntPtr pts)
	{
		if (IntPtr.Zero == pts)
		{
			return null;
		}
		int size = Marshal.ReadInt32(pts);
		return UnMarshalDoubleFixedArray(pts, size);
	}

	public static double[] UnMarshalDoubleFixedArray(IntPtr pts, int size)
	{
		if (pts == IntPtr.Zero)
		{
			return null;
		}
		int num = size * 8;
		byte[] array = new byte[num];
		Marshal.Copy(pts, array, 0, num);
		double[] array2 = new double[size];
		int num2 = 0;
		for (int i = 0; i < size; i++)
		{
			array2[i] = BitConverter.ToDouble(array, num2);
			num2 += 8;
		}
		return array2;
	}

	public static IntPtr MarshalIntPtrFixedArray(IntPtr[] ptrs)
	{
		if (ptrs == null)
		{
			return IntPtr.Zero;
		}
		int num = ptrs.Length;
		IntPtr intPtr = Marshal.AllocCoTaskMem(4 + num * IntPtr.Size);
		Marshal.WriteInt32(intPtr, num);
		copyBytes(intPtr, 4, ptrs);
		return intPtr;
	}

	public static IntPtr[] UnMarshalIntPtrFixedArray(IntPtr arr)
	{
		if (arr == IntPtr.Zero)
		{
			return null;
		}
		int num = Marshal.ReadInt32(arr);
		IntPtr[] array = new IntPtr[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = Marshal.ReadIntPtr(arr, 4 + i * IntPtr.Size);
		}
		return array;
	}

	public static IntPtr GetPtr<T>(T[] pts)
	{
		if (pts == null)
		{
			return IntPtr.Zero;
		}
		return Marshal.AllocCoTaskMem(4 + pts.Length * Marshal.SizeOf(typeof(T)));
	}

	public static byte[] GetData<T>(IntPtr pts)
	{
		if (pts == IntPtr.Zero)
		{
			return null;
		}
		int num = Marshal.ReadInt32(pts) * Marshal.SizeOf(typeof(T)) + 4;
		byte[] array = new byte[num];
		Marshal.Copy(pts, array, 0, num);
		return array;
	}

	public static IntPtr MarshalUInt32FixedArray(uint[] pts)
	{
		IntPtr ptr = GetPtr(pts);
		Marshal.WriteInt32(ptr, pts.Length);
		int n = 4;
		for (int i = 0; i < pts.Length; i++)
		{
			n = copyBytes(ptr, n, BitConverter.GetBytes(pts[i]));
		}
		return ptr;
	}

	public static uint[] UnMarshalUInt32FixedArray(IntPtr pts)
	{
		if (pts == IntPtr.Zero)
		{
			return null;
		}
		byte[] data = GetData<uint>(pts);
		int num = Marshal.ReadInt32(pts);
		uint[] array = new uint[num];
		int num2 = 4;
		for (int i = 0; i < num; i++)
		{
			array[i] = BitConverter.ToUInt32(data, num2);
			num2 += 4;
		}
		return array;
	}

	public static IntPtr MarshalUInt16FixedArray(ushort[] pts)
	{
		IntPtr ptr = GetPtr(pts);
		Marshal.WriteInt32(ptr, pts.Length);
		int n = 4;
		for (int i = 0; i < pts.Length; i++)
		{
			n = copyBytes(ptr, n, BitConverter.GetBytes(pts[i]));
		}
		return ptr;
	}

	public static ushort[] UnMarshalUInt16FixedArray(IntPtr pts)
	{
		if (pts == IntPtr.Zero)
		{
			return null;
		}
		byte[] data = GetData<ushort>(pts);
		int num = Marshal.ReadInt32(pts);
		ushort[] array = new ushort[num];
		int num2 = 4;
		for (int i = 0; i < num; i++)
		{
			array[i] = BitConverter.ToUInt16(data, num2);
			num2 += 2;
		}
		return array;
	}

	public static IntPtr MarshalUInt64FixedArray(ulong[] pts)
	{
		IntPtr ptr = GetPtr(pts);
		Marshal.WriteInt32(ptr, pts.Length);
		int n = 4;
		for (int i = 0; i < pts.Length; i++)
		{
			n = copyBytes(ptr, n, BitConverter.GetBytes(pts[i]));
		}
		return ptr;
	}

	public static ulong[] UnMarshalUInt64FixedArray(IntPtr pts)
	{
		byte[] data = GetData<ulong>(pts);
		int num = Marshal.ReadInt32(pts);
		ulong[] array = new ulong[num];
		int num2 = 4;
		for (int i = 0; i < num; i++)
		{
			array[i] = BitConverter.ToUInt64(data, num2);
			num2 += 8;
		}
		return array;
	}

	public static IntPtr MarshalbyteFixedArray(byte[] pts)
	{
		IntPtr ptr = GetPtr(pts);
		byte[] bytes = BitConverter.GetBytes(pts.Length);
		byte[] array = new byte[pts.Length + bytes.Length];
		Array.Copy(bytes, array, bytes.Length);
		Array.Copy(pts, 0, array, bytes.Length, pts.Length);
		Marshal.Copy(array, 0, ptr, array.Length);
		return ptr;
	}

	public static byte[] UnMarshalbyteFixedArray(IntPtr pts)
	{
		byte[] data = GetData<byte>(pts);
		int num = Marshal.ReadInt32(pts);
		byte[] array = new byte[num];
		int sourceIndex = 4;
		Array.Copy(data, sourceIndex, array, 0, num);
		return array;
	}

	public static IntPtr MarshalInt32FixedArray(int[] pts)
	{
		IntPtr ptr = GetPtr(pts);
		Marshal.WriteInt32(ptr, pts.Length);
		int n = 4;
		for (int i = 0; i < pts.Length; i++)
		{
			n = copyBytes(ptr, n, BitConverter.GetBytes(pts[i]));
		}
		return ptr;
	}

	public static int[] UnMarshalInt32FixedArray(IntPtr pts)
	{
		byte[] data = GetData<int>(pts);
		int num = Marshal.ReadInt32(pts);
		int[] array = new int[num];
		int num2 = 4;
		for (int i = 0; i < num; i++)
		{
			array[i] = BitConverter.ToInt32(data, num2);
			num2 += 4;
		}
		return array;
	}

	public static IntPtr MarshalInt16FixedArray(short[] pts)
	{
		IntPtr ptr = GetPtr(pts);
		Marshal.WriteInt32(ptr, pts.Length);
		int n = 4;
		for (int i = 0; i < pts.Length; i++)
		{
			n = copyBytes(ptr, n, BitConverter.GetBytes(pts[i]));
		}
		return ptr;
	}

	public static short[] UnMarshalInt16FixedArray(IntPtr pts)
	{
		byte[] data = GetData<short>(pts);
		int num = Marshal.ReadInt32(pts);
		short[] array = new short[num];
		int num2 = 4;
		for (int i = 0; i < num; i++)
		{
			array[i] = BitConverter.ToInt16(data, num2);
			num2 += 2;
		}
		return array;
	}

	public static IntPtr MarshalInt64FixedArray(long[] pts)
	{
		IntPtr ptr = GetPtr(pts);
		Marshal.WriteInt32(ptr, pts.Length);
		int n = 4;
		for (int i = 0; i < pts.Length; i++)
		{
			n = copyBytes(ptr, n, BitConverter.GetBytes(pts[i]));
		}
		return ptr;
	}

	public static long[] UnMarshalInt64FixedArray(IntPtr pts)
	{
		byte[] data = GetData<long>(pts);
		int num = Marshal.ReadInt32(pts);
		long[] array = new long[num];
		int num2 = 4;
		for (int i = 0; i < num; i++)
		{
			array[i] = BitConverter.ToInt64(data, num2);
			num2 += 8;
		}
		return array;
	}

	public static IntPtr MarshalVariant(object val)
	{
		return val.GetType().ToString() switch
		{
			"System.Boolean" => TD_RootIntegrated_GlobalsPINVOKE.createVariantFromBool((bool)val), 
			"System.Byte" => TD_RootIntegrated_GlobalsPINVOKE.createVariantFromByte((byte)val), 
			"System.Int16" => TD_RootIntegrated_GlobalsPINVOKE.createVariantFromInt16((short)val), 
			"System.UInt16" => TD_RootIntegrated_GlobalsPINVOKE.createVariantFromInt16((short)(ushort)val), 
			"System.Int32" => TD_RootIntegrated_GlobalsPINVOKE.createVariantFromInt32((int)val), 
			"System.UInt32" => TD_RootIntegrated_GlobalsPINVOKE.createVariantFromInt32((int)(uint)val), 
			"System.Int64" => TD_RootIntegrated_GlobalsPINVOKE.createVariantFromInt64((long)val), 
			"System.UInt64" => TD_RootIntegrated_GlobalsPINVOKE.createVariantFromInt64((long)(ulong)val), 
			"System.Double" => TD_RootIntegrated_GlobalsPINVOKE.createVariantFromDouble((double)val), 
			"System.String" => TD_RootIntegrated_GlobalsPINVOKE.createVariantFromString((string)val), 
			"System.IntPtr" => TD_RootIntegrated_GlobalsPINVOKE.createVariantFromIntPtr((IntPtr)val), 
			_ => IntPtr.Zero, 
		};
	}

	public static void FreeVariant(IntPtr val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.deleteVariant(val);
	}

	public static void FreeVariantAfterExit(IntPtr val)
	{
		VariantPointerHolder.Add(val);
	}

	public static object UnMarshalVariant(IntPtr p)
	{
		return TD_RootIntegrated_GlobalsPINVOKE.getVariantType(p) switch
		{
			1 => TD_RootIntegrated_GlobalsPINVOKE.getStringFromVariant(p), 
			2 => TD_RootIntegrated_GlobalsPINVOKE.getBoolFromVariant(p), 
			3 => TD_RootIntegrated_GlobalsPINVOKE.getByteFromVariant(p), 
			4 => TD_RootIntegrated_GlobalsPINVOKE.getInt16FromVariant(p), 
			5 => TD_RootIntegrated_GlobalsPINVOKE.getInt32FromVariant(p), 
			6 => TD_RootIntegrated_GlobalsPINVOKE.getInt64FromVariant(p), 
			7 => TD_RootIntegrated_GlobalsPINVOKE.getDoubleFromVariant(p), 
			8 => TD_RootIntegrated_GlobalsPINVOKE.getAnsiStringFromVariant(p), 
			_ => null, 
		};
	}

	public static uint[] UnMarshalPalette(IntPtr p)
	{
		if (p == IntPtr.Zero)
		{
			return null;
		}
		int num = Marshal.ReadInt32(p);
		uint[] array = new uint[num];
		for (int i = 1; i < num + 1; i++)
		{
			array[i - 1] = (uint)Marshal.ReadInt32(p, i * 4);
		}
		return array;
	}

	public static IntPtr MarshalPalette(uint[] p)
	{
		if (p == null)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocCoTaskMem(4 + p.Length * 4);
		Marshal.WriteInt32(intPtr, p.Length);
		for (int i = 1; i < p.Length + 1; i++)
		{
			Marshal.WriteInt32(intPtr, i * 4, (int)p[i - 1]);
		}
		return intPtr;
	}
}

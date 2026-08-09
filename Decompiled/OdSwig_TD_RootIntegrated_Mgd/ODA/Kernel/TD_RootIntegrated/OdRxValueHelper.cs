using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ODA.Kernel.TD_RootIntegrated;

public static class OdRxValueHelper
{
	private static string m_RxValueCast_PreffixName;

	private static string m_RxValueCreate_PreffixName;

	private static string m_GetNativeTypeName_PreffixName;

	private static string m_OdRxValueHelpers_ClassPreffixName;

	private static Dictionary<Assembly, Assembly> m_processedAssemblies;

	private static Dictionary<string, string> m_seqIdxToNativeType;

	private static Dictionary<string, string> m_nativeTypeToSeqIdx;

	private static Dictionary<string, MethodInfo> m_CastMethodMap;

	private static Dictionary<string, MethodInfo> m_CreateMethodMap;

	private static Dictionary<Type, List<string>> m_CsToNativeTypeMap;

	static OdRxValueHelper()
	{
		m_RxValueCast_PreffixName = "rxvalue_cast";
		m_RxValueCreate_PreffixName = "rxvalue_create";
		m_GetNativeTypeName_PreffixName = "getNativeTypeName";
		m_OdRxValueHelpers_ClassPreffixName = "OdRxValueHelpers";
		m_processedAssemblies = new Dictionary<Assembly, Assembly>();
		m_seqIdxToNativeType = new Dictionary<string, string>();
		m_nativeTypeToSeqIdx = new Dictionary<string, string>();
		m_CastMethodMap = new Dictionary<string, MethodInfo>();
		m_CreateMethodMap = new Dictionary<string, MethodInfo>();
		m_CsToNativeTypeMap = new Dictionary<Type, List<string>>();
		InitializeRxValueCastMethods();
		AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
	}

	private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
	{
		InitializeRxValueCastMethods();
	}

	public static List<KeyValuePair<Type, string[]>> AvailableTypeMap()
	{
		List<KeyValuePair<Type, string[]>> list = new List<KeyValuePair<Type, string[]>>();
		foreach (KeyValuePair<Type, List<string>> item in m_CsToNativeTypeMap)
		{
			list.Add(new KeyValuePair<Type, string[]>(item.Key, item.Value.ToArray()));
		}
		return list;
	}

	public static bool IsAvailable(Type type)
	{
		return m_CsToNativeTypeMap.ContainsKey(type);
	}

	public static OdRxValue rxvalue_create_AsOdString(string value)
	{
		return rxvalue_create(value, "OdString");
	}

	public static OdRxValue rxvalue_create_AsOdAnsiString(string value)
	{
		return rxvalue_create(value, "OdAnsiString");
	}

	public static OdRxValue rxvalue_create_const_char_p(string value)
	{
		return rxvalue_create(value, "const char*");
	}

	public static OdRxValue rxvalue_create(object value)
	{
		bool throwsIfMoreOne = false;
		return rxvalue_create(value, throwsIfMoreOne);
	}

	public static OdRxValue rxvalue_create()
	{
		return OdRxValue.create();
	}

	public static OdRxValue rxvalue_create(object value, bool throwsIfMoreOne)
	{
		string nativeFromCsType = GetNativeFromCsType(value.GetType(), throwsIfMoreOne);
		return rxvalue_create(value, nativeFromCsType);
	}

	public static OdRxValue rxvalue_create(object value, string nativeType)
	{
		if (nativeType == null)
		{
			return null;
		}
		if (value == null)
		{
			return null;
		}
		Type type = value.GetType();
		if (!m_CsToNativeTypeMap.ContainsKey(type))
		{
			throw new OdError("For input csharp value not available native types");
		}
		MethodInfo createMethodByNativeType = GetCreateMethodByNativeType(nativeType);
		if (createMethodByNativeType == null)
		{
			return null;
		}
		return createMethodByNativeType.Invoke(null, new object[1] { value }) as OdRxValue;
	}

	public static T rxvalue_cast<T>(OdRxValue value)
	{
		object obj = rxvalue_cast(value);
		try
		{
			if (obj == null)
			{
				return default(T);
			}
			return (T)obj;
		}
		catch (InvalidCastException)
		{
			return default(T);
		}
	}

	public static T rxvalue_cast<T>(OdRxValue value, string rxValueType)
	{
		object obj = rxvalue_cast(value, rxValueType);
		try
		{
			if (obj == null)
			{
				return default(T);
			}
			return (T)obj;
		}
		catch (InvalidCastException)
		{
			return default(T);
		}
	}

	public static object rxvalue_cast(OdRxValue value)
	{
		string rxValueType = value.type().name();
		return rxvalue_cast(value, rxValueType);
	}

	public static object rxvalue_cast(OdRxValue value, string rxValueType)
	{
		MethodInfo castMethodByRxValueType = GetCastMethodByRxValueType(rxValueType);
		if (castMethodByRxValueType == null)
		{
			return null;
		}
		return castMethodByRxValueType.Invoke(null, new object[1] { value });
	}

	private static void InitializeRxValueCastMethods()
	{
		Type[] odRxValueHelperTypes = GetOdRxValueHelperTypes();
		if (odRxValueHelperTypes.Length != 0)
		{
			GetMethods(odRxValueHelperTypes, out var _castMethods, out var _createMethods, out var _getNativeTypeNameMethods);
			InitSeqIdxToNativeTypeMap(_getNativeTypeNameMethods);
			InitNativeTypeToSeqIdxMap(_getNativeTypeNameMethods);
			InitMethodsCastMap(_castMethods);
			InitMethodsCreateMap(_createMethods);
			InitCsToNativeTypeMap();
		}
	}

	private static void IgnoreAssert(string s1, string s2, int i)
	{
	}

	private static void InitSeqIdxToNativeTypeMap(MethodInfo[] getNativeTypeNameMethods)
	{
		new Dictionary<string, string>();
		foreach (MethodInfo method in getNativeTypeNameMethods)
		{
			string methodIdx = GetMethodIdx(method, m_GetNativeTypeName_PreffixName);
			m_seqIdxToNativeType.Add(methodIdx, InvokeGetNativeTypeName(method));
		}
	}

	private static void InitNativeTypeToSeqIdxMap(MethodInfo[] getNativeTypeNameMethods)
	{
		foreach (MethodInfo method in getNativeTypeNameMethods)
		{
			string key = InvokeGetNativeTypeName(method);
			if (!m_nativeTypeToSeqIdx.ContainsKey(key))
			{
				m_nativeTypeToSeqIdx.Add(key, GetMethodIdx(method, m_GetNativeTypeName_PreffixName));
			}
		}
	}

	private static void InitMethodsCastMap(MethodInfo[] methods)
	{
		foreach (MethodInfo methodInfo in methods)
		{
			m_CastMethodMap.Add(GetMethodIdx(methodInfo, m_RxValueCast_PreffixName), methodInfo);
		}
	}

	private static void InitMethodsCreateMap(MethodInfo[] methods)
	{
		foreach (MethodInfo methodInfo in methods)
		{
			m_CreateMethodMap.Add(GetMethodIdx(methodInfo, m_RxValueCreate_PreffixName), methodInfo);
		}
	}

	private static void InitCsToNativeTypeMap()
	{
		foreach (KeyValuePair<string, MethodInfo> item in m_CreateMethodMap)
		{
			string key = item.Key;
			Type parameterType = item.Value.GetParameters()[0].ParameterType;
			string value = null;
			if (m_seqIdxToNativeType.TryGetValue(key, out value) && (!(parameterType == typeof(int)) || !(value == "long")))
			{
				if (m_CsToNativeTypeMap.ContainsKey(parameterType))
				{
					m_CsToNativeTypeMap[parameterType].Add(value);
					continue;
				}
				m_CsToNativeTypeMap.Add(parameterType, new List<string> { value });
			}
		}
	}

	private static string InvokeGetNativeTypeName(MethodInfo method)
	{
		return method.Invoke(null, new object[0]) as string;
	}

	private static string GetMethodIdx(MethodInfo method, string prefiix)
	{
		return method.Name.Replace(prefiix, "");
	}

	private static Type[] GetOdRxValueHelperTypes()
	{
		List<Type> list = new List<Type>();
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			if (m_processedAssemblies.ContainsKey(assembly))
			{
				continue;
			}
			m_processedAssemblies.Add(assembly, assembly);
			Type[] types = assembly.GetTypes();
			for (int j = 0; j < types.Length; j++)
			{
				if (types[j].Name.StartsWith(m_OdRxValueHelpers_ClassPreffixName))
				{
					list.Add(types[j]);
				}
			}
		}
		return list.ToArray();
	}

	private static void GetMethods(Type[] fromTypes, out MethodInfo[] _castMethods, out MethodInfo[] _createMethods, out MethodInfo[] _getNativeTypeNameMethods)
	{
		List<MethodInfo> list = new List<MethodInfo>();
		List<MethodInfo> list2 = new List<MethodInfo>();
		List<MethodInfo> list3 = new List<MethodInfo>();
		for (int i = 0; i < fromTypes.Length; i++)
		{
			GetMethods(fromTypes[i], out var _castMethods2, out var _createMethods2, out var _getNativeTypeNameMethods2);
			list.AddRange(_castMethods2);
			list2.AddRange(_createMethods2);
			list3.AddRange(_getNativeTypeNameMethods2);
		}
		_castMethods = list.ToArray();
		_createMethods = list2.ToArray();
		_getNativeTypeNameMethods = list3.ToArray();
	}

	private static void GetMethods(Type fromType, out MethodInfo[] _castMethods, out MethodInfo[] _createMethods, out MethodInfo[] _getNativeTypeNameMethods)
	{
		MethodInfo[] methods = fromType.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
		List<MethodInfo> list = new List<MethodInfo>();
		List<MethodInfo> list2 = new List<MethodInfo>();
		List<MethodInfo> list3 = new List<MethodInfo>();
		MethodInfo[] array = methods;
		foreach (MethodInfo methodInfo in array)
		{
			if (MethodIsCast(methodInfo))
			{
				list.Add(methodInfo);
			}
			else if (MethodIsCreate(methodInfo))
			{
				list2.Add(methodInfo);
			}
			else if (MethodIsGetNativeTypeName(methodInfo))
			{
				list3.Add(methodInfo);
			}
		}
		_castMethods = list.ToArray();
		_createMethods = list2.ToArray();
		_getNativeTypeNameMethods = list3.ToArray();
	}

	private static bool MethodIsCast(MethodInfo methodInfo)
	{
		if (!methodInfo.Name.StartsWith(m_RxValueCast_PreffixName))
		{
			return false;
		}
		ParameterInfo[] parameters = methodInfo.GetParameters();
		if (parameters.Length != 1)
		{
			return false;
		}
		return parameters[0].ParameterType == typeof(OdRxValue);
	}

	private static bool MethodIsCreate(MethodInfo methodInfo)
	{
		if (!methodInfo.Name.StartsWith(m_RxValueCreate_PreffixName))
		{
			return false;
		}
		bool flag = methodInfo.GetParameters().Length == 1;
		if (!flag)
		{
			return false;
		}
		return flag;
	}

	private static bool MethodIsGetNativeTypeName(MethodInfo methodInfo)
	{
		if (!methodInfo.Name.StartsWith(m_GetNativeTypeName_PreffixName))
		{
			return false;
		}
		bool flag = methodInfo.GetParameters().Length == 0;
		if (!flag)
		{
			return false;
		}
		return flag;
	}

	private static MethodInfo GetCastMethodByRxValueType(string valueType)
	{
		if (string.IsNullOrEmpty(valueType))
		{
			return null;
		}
		string value = null;
		if (!m_nativeTypeToSeqIdx.TryGetValue(valueType, out value))
		{
			return null;
		}
		return m_CastMethodMap[value];
	}

	private static string GetNativeFromCsType(Type csType, bool throwsIfMoreOne)
	{
		List<string> nativeFromCsType = GetNativeFromCsType(csType);
		if (throwsIfMoreOne && nativeFromCsType.Count > 1)
		{
			throw new OdError("For input csharp value available more one native types");
		}
		if (nativeFromCsType.Count > 1)
		{
			string[] array = nativeFromCsType.Select(delegate(string xNativeType)
			{
				string text = m_nativeTypeToSeqIdx[xNativeType];
				string text2 = text.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries).ToArray()[0];
				string text3 = text.Replace("_" + text2 + "_", "");
				return "OdRxValueTypeDesc_" + text2 + ".value_Desc_" + text3 + "().name()";
			}).ToArray();
			throw new OdError("Cannot resolve C++ native type for " + csType.FullName + "\nFounded C++ types: " + string.Join(",", nativeFromCsType) + ";\nFor resolve type you need choose method for resolving type:\n" + string.Join("\n", array) + "\n\nFor example: OdRxValueHelper.rxvalue_create(<your_instance>," + array[0] + ");\nOr\nFor example: OdRxValueHelper.rxvalue_create(<your_instance>,\"" + nativeFromCsType[0] + "\");");
		}
		if (nativeFromCsType.Count == 0)
		{
			throw new OdError("For input csharp value not available native types");
		}
		return nativeFromCsType[0];
	}

	private static List<string> GetNativeFromCsType(Type csType)
	{
		List<string> value = null;
		if (!m_CsToNativeTypeMap.TryGetValue(csType, out value))
		{
			return new List<string>();
		}
		return value;
	}

	private static MethodInfo GetCreateMethodByNativeType(string valueType)
	{
		if (string.IsNullOrEmpty(valueType))
		{
			return null;
		}
		string value = null;
		if (!m_nativeTypeToSeqIdx.TryGetValue(valueType, out value))
		{
			return null;
		}
		return m_CreateMethodMap[value];
	}
}

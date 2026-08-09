using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.Internal;

namespace System.ComponentModel.Composition;

internal static class MetadataViewGenerator
{
	public delegate object MetadataViewFactory(IDictionary<string, object?> metadata);

	public const string MetadataViewType = "MetadataViewType";

	public const string MetadataItemKey = "MetadataItemKey";

	public const string MetadataItemTargetType = "MetadataItemTargetType";

	public const string MetadataItemSourceType = "MetadataItemSourceType";

	public const string MetadataItemValue = "MetadataItemValue";

	public const string MetadataViewFactoryName = "Create";

	private static readonly Lock _lock = new Lock();

	private static readonly Dictionary<Type, MetadataViewFactory> _metadataViewFactories = new Dictionary<Type, MetadataViewFactory>();

	private static readonly AssemblyName ProxyAssemblyName = new AssemblyName($"MetadataViewProxies_{Guid.NewGuid()}");

	private static ModuleBuilder transparentProxyModuleBuilder;

	private static readonly Type[] CtorArgumentTypes = new Type[1] { typeof(IDictionary<string, object>) };

	private static readonly MethodInfo _mdvDictionaryTryGet = CtorArgumentTypes[0].GetMethod("TryGetValue");

	private static readonly MethodInfo ObjectGetType = typeof(object).GetMethod("GetType", Type.EmptyTypes);

	private static readonly ConstructorInfo ObjectCtor = typeof(object).GetConstructor(Type.EmptyTypes);

	private static ModuleBuilder GetProxyModuleBuilder()
	{
		if (transparentProxyModuleBuilder == null)
		{
			AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(ProxyAssemblyName, AssemblyBuilderAccess.Run);
			transparentProxyModuleBuilder = assemblyBuilder.DefineDynamicModule("MetadataViewProxiesModule");
		}
		return transparentProxyModuleBuilder;
	}

	public static MetadataViewFactory GetMetadataViewFactory(Type viewType)
	{
		ArgumentNullException.ThrowIfNull(viewType, "viewType");
		if (!viewType.IsInterface)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		bool flag;
		MetadataViewFactory value;
		using (new ReadLock(_lock))
		{
			flag = _metadataViewFactories.TryGetValue(viewType, out value);
		}
		if (!flag)
		{
			Type type = GenerateInterfaceViewProxyType(viewType);
			if (type == null)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			MetadataViewFactory metadataViewFactory = (MetadataViewFactory)Delegate.CreateDelegate(typeof(MetadataViewFactory), type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public));
			if (metadataViewFactory == null)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			using (new WriteLock(_lock))
			{
				if (!_metadataViewFactories.TryGetValue(viewType, out value))
				{
					value = metadataViewFactory;
					_metadataViewFactories.Add(viewType, value);
				}
			}
		}
		return value;
	}

	public static TMetadataView CreateMetadataView<TMetadataView>(MetadataViewFactory metadataViewFactory, IDictionary<string, object?> metadata)
	{
		ArgumentNullException.ThrowIfNull(metadataViewFactory, "metadataViewFactory");
		try
		{
			return (TMetadataView)metadataViewFactory(metadata);
		}
		catch (Exception inner)
		{
			throw new TargetInvocationException(inner);
		}
	}

	private static void GenerateLocalAssignmentFromDefaultAttribute(this ILGenerator IL, DefaultValueAttribute[] attrs, LocalBuilder local)
	{
		if (attrs.Length != 0)
		{
			DefaultValueAttribute defaultValueAttribute = attrs[0];
			IL.LoadValue(defaultValueAttribute.Value);
			if (defaultValueAttribute.Value != null && defaultValueAttribute.Value.GetType().IsValueType)
			{
				IL.Emit(OpCodes.Box, defaultValueAttribute.Value.GetType());
			}
			IL.Emit(OpCodes.Stloc, local);
		}
	}

	private static void GenerateFieldAssignmentFromLocalValue(this ILGenerator IL, LocalBuilder local, FieldBuilder field)
	{
		IL.Emit(OpCodes.Ldarg_0);
		IL.Emit(OpCodes.Ldloc, local);
		IL.Emit(field.FieldType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, field.FieldType);
		IL.Emit(OpCodes.Stfld, field);
	}

	private static void GenerateLocalAssignmentFromFlag(this ILGenerator IL, LocalBuilder local, bool flag)
	{
		IL.Emit(flag ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
		IL.Emit(OpCodes.Stloc, local);
	}

	private static Type GenerateInterfaceViewProxyType(Type viewType)
	{
		Type[] interfaces = new Type[1] { viewType };
		ModuleBuilder proxyModuleBuilder = GetProxyModuleBuilder();
		TypeBuilder typeBuilder = proxyModuleBuilder.DefineType($"_proxy_{viewType.FullName}_{Guid.NewGuid()}", TypeAttributes.Public, typeof(object), interfaces);
		ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, CtorArgumentTypes);
		ILGenerator iLGenerator = constructorBuilder.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Call, ObjectCtor);
		LocalBuilder localBuilder = iLGenerator.DeclareLocal(typeof(Exception));
		LocalBuilder localBuilder2 = iLGenerator.DeclareLocal(typeof(IDictionary));
		LocalBuilder localBuilder3 = iLGenerator.DeclareLocal(typeof(Type));
		LocalBuilder localBuilder4 = iLGenerator.DeclareLocal(typeof(object));
		LocalBuilder local = iLGenerator.DeclareLocal(typeof(bool));
		Label label = iLGenerator.BeginExceptionBlock();
		foreach (PropertyInfo allProperty in viewType.GetAllProperties())
		{
			string fieldName = $"_{allProperty.Name}_{Guid.NewGuid()}";
			string name = allProperty.Name;
			Type[] parameterTypes = new Type[1] { allProperty.PropertyType };
			Type[] array = null;
			Type[] array2 = null;
			array = allProperty.GetOptionalCustomModifiers();
			array2 = allProperty.GetRequiredCustomModifiers();
			Array.Reverse(array);
			Array.Reverse(array2);
			FieldBuilder field = typeBuilder.DefineField(fieldName, allProperty.PropertyType, FieldAttributes.Private);
			PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(name, PropertyAttributes.None, allProperty.PropertyType, parameterTypes);
			Label label2 = iLGenerator.BeginExceptionBlock();
			DefaultValueAttribute[] attributes = allProperty.GetAttributes<DefaultValueAttribute>(inherit: false);
			if (attributes.Length != 0)
			{
				Label label3 = iLGenerator.BeginExceptionBlock();
			}
			Label label4 = iLGenerator.DefineLabel();
			iLGenerator.GenerateLocalAssignmentFromFlag(local, flag: true);
			iLGenerator.Emit(OpCodes.Ldarg_1);
			iLGenerator.Emit(OpCodes.Ldstr, allProperty.Name);
			iLGenerator.Emit(OpCodes.Ldloca, localBuilder4);
			iLGenerator.Emit(OpCodes.Callvirt, _mdvDictionaryTryGet);
			iLGenerator.Emit(OpCodes.Brtrue, label4);
			iLGenerator.GenerateLocalAssignmentFromFlag(local, flag: false);
			iLGenerator.GenerateLocalAssignmentFromDefaultAttribute(attributes, localBuilder4);
			iLGenerator.MarkLabel(label4);
			iLGenerator.GenerateFieldAssignmentFromLocalValue(localBuilder4, field);
			iLGenerator.Emit(OpCodes.Leave, label2);
			if (attributes.Length != 0)
			{
				iLGenerator.BeginCatchBlock(typeof(InvalidCastException));
				Label label5 = iLGenerator.DefineLabel();
				iLGenerator.Emit(OpCodes.Ldloc, local);
				iLGenerator.Emit(OpCodes.Brtrue, label5);
				iLGenerator.Emit(OpCodes.Rethrow);
				iLGenerator.MarkLabel(label5);
				iLGenerator.GenerateLocalAssignmentFromDefaultAttribute(attributes, localBuilder4);
				iLGenerator.GenerateFieldAssignmentFromLocalValue(localBuilder4, field);
				iLGenerator.EndExceptionBlock();
			}
			iLGenerator.BeginCatchBlock(typeof(NullReferenceException));
			iLGenerator.Emit(OpCodes.Stloc, localBuilder);
			iLGenerator.GetExceptionDataAndStoreInLocal(localBuilder, localBuilder2);
			iLGenerator.AddItemToLocalDictionary(localBuilder2, "MetadataItemKey", name);
			iLGenerator.AddItemToLocalDictionary(localBuilder2, "MetadataItemTargetType", allProperty.PropertyType);
			iLGenerator.Emit(OpCodes.Rethrow);
			iLGenerator.BeginCatchBlock(typeof(InvalidCastException));
			iLGenerator.Emit(OpCodes.Stloc, localBuilder);
			iLGenerator.GetExceptionDataAndStoreInLocal(localBuilder, localBuilder2);
			iLGenerator.AddItemToLocalDictionary(localBuilder2, "MetadataItemKey", name);
			iLGenerator.AddItemToLocalDictionary(localBuilder2, "MetadataItemTargetType", allProperty.PropertyType);
			iLGenerator.Emit(OpCodes.Rethrow);
			iLGenerator.EndExceptionBlock();
			if (allProperty.CanWrite)
			{
				throw new NotSupportedException(System.SR.Format(System.SR.InvalidSetterOnMetadataField, viewType, name));
			}
			if (allProperty.CanRead)
			{
				MethodBuilder methodBuilder = typeBuilder.DefineMethod("get_" + name, MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask | MethodAttributes.SpecialName, CallingConventions.HasThis, allProperty.PropertyType, array2, array, Type.EmptyTypes, null, null);
				typeBuilder.DefineMethodOverride(methodBuilder, allProperty.GetGetMethod());
				ILGenerator iLGenerator2 = methodBuilder.GetILGenerator();
				iLGenerator2.Emit(OpCodes.Ldarg_0);
				iLGenerator2.Emit(OpCodes.Ldfld, field);
				iLGenerator2.Emit(OpCodes.Ret);
				propertyBuilder.SetGetMethod(methodBuilder);
			}
		}
		iLGenerator.Emit(OpCodes.Leave, label);
		iLGenerator.BeginCatchBlock(typeof(NullReferenceException));
		iLGenerator.Emit(OpCodes.Stloc, localBuilder);
		iLGenerator.GetExceptionDataAndStoreInLocal(localBuilder, localBuilder2);
		iLGenerator.AddItemToLocalDictionary(localBuilder2, "MetadataViewType", viewType);
		iLGenerator.Emit(OpCodes.Rethrow);
		iLGenerator.BeginCatchBlock(typeof(InvalidCastException));
		iLGenerator.Emit(OpCodes.Stloc, localBuilder);
		iLGenerator.GetExceptionDataAndStoreInLocal(localBuilder, localBuilder2);
		iLGenerator.Emit(OpCodes.Ldloc, localBuilder4);
		iLGenerator.Emit(OpCodes.Call, ObjectGetType);
		iLGenerator.Emit(OpCodes.Stloc, localBuilder3);
		iLGenerator.AddItemToLocalDictionary(localBuilder2, "MetadataViewType", viewType);
		iLGenerator.AddLocalToLocalDictionary(localBuilder2, "MetadataItemSourceType", localBuilder3);
		iLGenerator.AddLocalToLocalDictionary(localBuilder2, "MetadataItemValue", localBuilder4);
		iLGenerator.Emit(OpCodes.Rethrow);
		iLGenerator.EndExceptionBlock();
		iLGenerator.Emit(OpCodes.Ret);
		MethodBuilder methodBuilder2 = typeBuilder.DefineMethod("Create", MethodAttributes.Public | MethodAttributes.Static, typeof(object), CtorArgumentTypes);
		ILGenerator iLGenerator3 = methodBuilder2.GetILGenerator();
		iLGenerator3.Emit(OpCodes.Ldarg_0);
		iLGenerator3.Emit(OpCodes.Newobj, constructorBuilder);
		iLGenerator3.Emit(OpCodes.Ret);
		return typeBuilder.CreateTypeInfo();
	}
}

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Description;

internal static class ServiceReflector
{
	internal const string BeginMethodNamePrefix = "Begin";

	internal const string EndMethodNamePrefix = "End";

	internal static readonly Type VoidType = typeof(void);

	internal const string AsyncMethodNameSuffix = "Async";

	internal static readonly Type taskType = typeof(Task);

	internal static readonly Type taskTResultType = typeof(Task<>);

	internal static readonly Type CancellationTokenType = typeof(CancellationToken);

	internal static readonly Type IProgressType = typeof(IProgress<>);

	private static readonly Type s_asyncCallbackType = typeof(AsyncCallback);

	private static readonly Type s_asyncResultType = typeof(IAsyncResult);

	private static readonly Type s_objectType = typeof(object);

	private static readonly Type s_OperationContractAttributeType = typeof(OperationContractAttribute);

	internal static Type GetOperationContractProviderType(MethodInfo method)
	{
		if (GetSingleAttribute<OperationContractAttribute>(method) != null)
		{
			return s_OperationContractAttributeType;
		}
		return GetFirstAttribute<IOperationContractAttributeProvider>(method)?.GetType();
	}

	internal static List<Type> GetInterfaces(Type service)
	{
		List<Type> list = new List<Type>();
		bool flag = false;
		if (service.IsDefined(typeof(ServiceContractAttribute), inherit: false))
		{
			flag = true;
			list.Add(service);
		}
		if (!flag)
		{
			Type ancestorImplicitContractClass = GetAncestorImplicitContractClass(service);
			if (ancestorImplicitContractClass != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxContractInheritanceRequiresInterfaces2, service, ancestorImplicitContractClass)));
			}
			foreach (MethodInfo item in GetMethodsInternal(service))
			{
				Type operationContractProviderType = GetOperationContractProviderType(item);
				if (operationContractProviderType == s_OperationContractAttributeType)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ServicesWithoutAServiceContractAttributeCan2, operationContractProviderType.Name, item.Name, service.FullName)));
				}
			}
		}
		Type[] interfaces = service.GetInterfaces();
		foreach (Type type in interfaces)
		{
			if (type.IsDefined(typeof(ServiceContractAttribute), inherit: false))
			{
				if (flag)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxContractInheritanceRequiresInterfaces, service, type)));
				}
				list.Add(type);
			}
		}
		return list;
	}

	private static Type GetAncestorImplicitContractClass(Type service)
	{
		service = service.BaseType();
		while (service != null)
		{
			if (GetSingleAttribute<ServiceContractAttribute>(service) != null)
			{
				return service;
			}
			service = service.BaseType();
		}
		return null;
	}

	internal static List<Type> GetInheritedContractTypes(Type service)
	{
		List<Type> list = new List<Type>();
		Type[] interfaces = service.GetInterfaces();
		foreach (Type type in interfaces)
		{
			if (GetSingleAttribute<ServiceContractAttribute>(type) != null)
			{
				list.Add(type);
			}
		}
		service = service.BaseType();
		while (service != null)
		{
			if (GetSingleAttribute<ServiceContractAttribute>(service) != null)
			{
				list.Add(service);
			}
			service = service.BaseType();
		}
		return list;
	}

	internal static object[] GetCustomAttributes(ICustomAttributeProvider attrProvider, Type attrType)
	{
		return GetCustomAttributes(attrProvider, attrType, inherit: false);
	}

	internal static object[] GetCustomAttributes(ICustomAttributeProvider attrProvider, Type attrType, bool inherit)
	{
		try
		{
			if (typeof(Attribute).IsAssignableFrom(attrType))
			{
				return attrProvider.GetCustomAttributes(attrType, inherit);
			}
			List<object> list = new List<object>();
			object[] customAttributes = attrProvider.GetCustomAttributes(inherit);
			object[] array = customAttributes;
			foreach (object obj in array)
			{
				if (attrType.IsAssignableFrom(obj.GetType()))
				{
					list.Add(obj);
				}
			}
			return list.ToArray();
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			Type type = attrProvider as Type;
			MethodInfo methodInfo = attrProvider as MethodInfo;
			ParameterInfo parameterInfo = attrProvider as ParameterInfo;
			if (type != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxErrorReflectingOnType2, attrType.Name, type.Name), ex));
			}
			if (methodInfo != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxErrorReflectingOnMethod3, attrType.Name, methodInfo.Name, methodInfo.DeclaringType.Name), ex));
			}
			if (parameterInfo != null)
			{
				methodInfo = parameterInfo.Member as MethodInfo;
				if (methodInfo != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxErrorReflectingOnParameter4, attrType.Name, parameterInfo.Name, methodInfo.Name, methodInfo.DeclaringType.Name), ex));
				}
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxErrorReflectionOnUnknown1, attrType.Name), ex));
		}
	}

	internal static T GetFirstAttribute<T>(ICustomAttributeProvider attrProvider) where T : class
	{
		Type typeFromHandle = typeof(T);
		object[] customAttributes = GetCustomAttributes(attrProvider, typeFromHandle);
		if (customAttributes.Length == 0)
		{
			return null;
		}
		return customAttributes[0] as T;
	}

	internal static T GetSingleAttribute<T>(ICustomAttributeProvider attrProvider) where T : class
	{
		Type typeFromHandle = typeof(T);
		object[] customAttributes = GetCustomAttributes(attrProvider, typeFromHandle);
		if (customAttributes == null || customAttributes.Length == 0)
		{
			return null;
		}
		if (customAttributes.Length > 1)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.tooManyAttributesOfTypeOn2, typeFromHandle, attrProvider.ToString())));
		}
		return customAttributes[0] as T;
	}

	internal static T GetRequiredSingleAttribute<T>(ICustomAttributeProvider attrProvider) where T : class
	{
		T singleAttribute = GetSingleAttribute<T>(attrProvider);
		if (singleAttribute == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.couldnTFindRequiredAttributeOfTypeOn2, typeof(T), attrProvider.ToString())));
		}
		return singleAttribute;
	}

	internal static T GetSingleAttribute<T>(ICustomAttributeProvider attrProvider, Type[] attrTypeGroup) where T : class
	{
		T singleAttribute = GetSingleAttribute<T>(attrProvider);
		if (singleAttribute != null)
		{
			Type typeFromHandle = typeof(T);
			foreach (Type type in attrTypeGroup)
			{
				if (!(type == typeFromHandle))
				{
					object[] customAttributes = GetCustomAttributes(attrProvider, type);
					if (customAttributes != null && customAttributes.Length != 0)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxDisallowedAttributeCombination, attrProvider, typeFromHandle.FullName, type.FullName)));
					}
				}
			}
		}
		return singleAttribute;
	}

	internal static T GetRequiredSingleAttribute<T>(ICustomAttributeProvider attrProvider, Type[] attrTypeGroup) where T : class
	{
		T singleAttribute = GetSingleAttribute<T>(attrProvider, attrTypeGroup);
		if (singleAttribute == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.couldnTFindRequiredAttributeOfTypeOn2, typeof(T), attrProvider.ToString())));
		}
		return singleAttribute;
	}

	internal static Type GetContractType(Type interfaceType)
	{
		ServiceContractAttribute contractAttribute;
		return GetContractTypeAndAttribute(interfaceType, out contractAttribute);
	}

	internal static Type GetContractTypeAndAttribute(Type interfaceType, out ServiceContractAttribute contractAttribute)
	{
		contractAttribute = GetSingleAttribute<ServiceContractAttribute>(interfaceType);
		if (contractAttribute != null)
		{
			return interfaceType;
		}
		List<Type> list = new List<Type>(GetInheritedContractTypes(interfaceType));
		if (list.Count == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.AttemptedToGetContractTypeForButThatTypeIs1, interfaceType.Name)));
		}
		foreach (Type item in list)
		{
			bool flag = true;
			foreach (Type item2 in list)
			{
				if (!item2.IsAssignableFrom(item))
				{
					flag = false;
				}
			}
			if (flag)
			{
				contractAttribute = GetSingleAttribute<ServiceContractAttribute>(item);
				return item;
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxNoMostDerivedContract, interfaceType.Name)));
	}

	private static List<MethodInfo> GetMethodsInternal(Type interfaceType)
	{
		List<MethodInfo> list = new List<MethodInfo>();
		foreach (MethodInfo item in from m in interfaceType.GetRuntimeMethods()
			where !m.IsStatic
			select m)
		{
			if (GetSingleAttribute<OperationContractAttribute>(item) != null)
			{
				list.Add(item);
			}
			else if (GetFirstAttribute<IOperationContractAttributeProvider>(item) != null)
			{
				list.Add(item);
			}
		}
		return list;
	}

	internal static void ValidateParameterMetadata(MethodInfo methodInfo)
	{
		ParameterInfo[] parameters = methodInfo.GetParameters();
		ParameterInfo[] array = parameters;
		foreach (ParameterInfo parameterInfo in array)
		{
			if (!parameterInfo.ParameterType.IsByRef)
			{
				if (parameterInfo.IsOut)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxBadByValueParameterMetadata, methodInfo.Name, methodInfo.DeclaringType.Name)));
				}
			}
			else if (parameterInfo.IsIn && !parameterInfo.IsOut)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxBadByReferenceParameterMetadata, methodInfo.Name, methodInfo.DeclaringType.Name)));
			}
		}
	}

	internal static bool FlowsIn(ParameterInfo paramInfo)
	{
		if (paramInfo.IsOut)
		{
			return paramInfo.IsIn;
		}
		return true;
	}

	internal static bool FlowsOut(ParameterInfo paramInfo)
	{
		return paramInfo.ParameterType.IsByRef;
	}

	internal static ParameterInfo[] GetInputParameters(MethodInfo method, bool asyncPattern)
	{
		int num = 0;
		ParameterInfo[] parameters = method.GetParameters();
		int num2 = parameters.Length;
		if (asyncPattern)
		{
			num2 -= 2;
		}
		for (int i = 0; i < num2; i++)
		{
			if (FlowsIn(parameters[i]))
			{
				num++;
			}
		}
		ParameterInfo[] array = new ParameterInfo[num];
		int num3 = 0;
		for (int j = 0; j < num2; j++)
		{
			ParameterInfo parameterInfo = parameters[j];
			if (FlowsIn(parameterInfo))
			{
				array[num3++] = parameterInfo;
			}
		}
		return array;
	}

	internal static ParameterInfo[] GetOutputParameters(MethodInfo method, bool asyncPattern)
	{
		int num = 0;
		ParameterInfo[] parameters = method.GetParameters();
		int num2 = parameters.Length;
		if (asyncPattern)
		{
			num2--;
		}
		for (int i = 0; i < num2; i++)
		{
			if (FlowsOut(parameters[i]))
			{
				num++;
			}
		}
		ParameterInfo[] array = new ParameterInfo[num];
		int num3 = 0;
		for (int j = 0; j < num2; j++)
		{
			ParameterInfo parameterInfo = parameters[j];
			if (FlowsOut(parameterInfo))
			{
				array[num3++] = parameterInfo;
			}
		}
		return array;
	}

	internal static bool HasOutputParameters(MethodInfo method, bool asyncPattern)
	{
		ParameterInfo[] parameters = method.GetParameters();
		int num = parameters.Length;
		if (asyncPattern)
		{
			num--;
		}
		for (int i = 0; i < num; i++)
		{
			if (FlowsOut(parameters[i]))
			{
				return true;
			}
		}
		return false;
	}

	private static MethodInfo GetEndMethodInternal(MethodInfo beginMethod)
	{
		string logicalName = GetLogicalName(beginMethod);
		string text = "End" + logicalName;
		MethodInfo[] array = beginMethod.DeclaringType.GetTypeInfo().GetDeclaredMethods(text).ToArray();
		if (array.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.NoEndMethodFoundForAsyncBeginMethod3, beginMethod.Name, beginMethod.DeclaringType.FullName, text)));
		}
		if (array.Length > 1)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.MoreThanOneEndMethodFoundForAsyncBeginMethod3, beginMethod.Name, beginMethod.DeclaringType.FullName, text)));
		}
		return array[0];
	}

	internal static MethodInfo GetEndMethod(MethodInfo beginMethod)
	{
		MethodInfo endMethodInternal = GetEndMethodInternal(beginMethod);
		if (!HasEndMethodShape(endMethodInternal))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InvalidAsyncEndMethodSignatureForMethod2, endMethodInternal.Name, endMethodInternal.DeclaringType.FullName)));
		}
		return endMethodInternal;
	}

	internal static XmlName GetOperationName(MethodInfo method)
	{
		OperationContractAttribute operationContractAttribute = GetOperationContractAttribute(method);
		return NamingHelper.GetOperationName(GetLogicalName(method), operationContractAttribute.Name);
	}

	internal static bool HasBeginMethodShape(MethodInfo method)
	{
		ParameterInfo[] parameters = method.GetParameters();
		if (!method.Name.StartsWith("Begin", StringComparison.Ordinal) || parameters.Length < 2 || parameters[^2].ParameterType != s_asyncCallbackType || parameters[^1].ParameterType != s_objectType || method.ReturnType != s_asyncResultType)
		{
			return false;
		}
		return true;
	}

	internal static bool IsBegin(OperationContractAttribute opSettings, MethodInfo method)
	{
		if (opSettings.AsyncPattern)
		{
			if (!HasBeginMethodShape(method))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InvalidAsyncBeginMethodSignatureForMethod2, method.Name, method.DeclaringType.FullName)));
			}
			return true;
		}
		return false;
	}

	internal static bool IsTask(MethodInfo method)
	{
		if (method.ReturnType == taskType)
		{
			return true;
		}
		if (method.ReturnType.IsGenericType() && method.ReturnType.GetGenericTypeDefinition() == taskTResultType)
		{
			return true;
		}
		return false;
	}

	internal static bool IsTask(MethodInfo method, out Type taskTResult)
	{
		taskTResult = null;
		Type returnType = method.ReturnType;
		if (returnType == taskType)
		{
			taskTResult = VoidType;
			return true;
		}
		if (returnType.IsGenericType() && returnType.GetGenericTypeDefinition() == taskTResultType)
		{
			taskTResult = returnType.GetGenericArguments()[0];
			return true;
		}
		return false;
	}

	internal static bool HasEndMethodShape(MethodInfo method)
	{
		ParameterInfo[] parameters = method.GetParameters();
		if (!method.Name.StartsWith("End", StringComparison.Ordinal) || parameters.Length < 1 || parameters[^1].ParameterType != s_asyncResultType)
		{
			return false;
		}
		return true;
	}

	internal static OperationContractAttribute GetOperationContractAttribute(MethodInfo method)
	{
		OperationContractAttribute singleAttribute = GetSingleAttribute<OperationContractAttribute>(method);
		if (singleAttribute != null)
		{
			return singleAttribute;
		}
		return GetFirstAttribute<IOperationContractAttributeProvider>(method)?.GetOperationContractAttribute();
	}

	internal static bool IsBegin(MethodInfo method)
	{
		OperationContractAttribute operationContractAttribute = GetOperationContractAttribute(method);
		if (operationContractAttribute == null)
		{
			return false;
		}
		return IsBegin(operationContractAttribute, method);
	}

	internal static string GetLogicalName(MethodInfo method)
	{
		bool flag = IsBegin(method);
		bool isTask = !flag && IsTask(method);
		return GetLogicalName(method, flag, isTask);
	}

	internal static string GetLogicalName(MethodInfo method, bool isAsync, bool isTask)
	{
		if (isAsync)
		{
			return method.Name.Substring("Begin".Length);
		}
		if (isTask && method.Name.EndsWith("Async", StringComparison.Ordinal))
		{
			return method.Name.Substring(0, method.Name.Length - "Async".Length);
		}
		return method.Name;
	}

	internal static bool HasNoDisposableParameters(MethodInfo methodInfo)
	{
		ParameterInfo[] parameters = methodInfo.GetParameters();
		foreach (ParameterInfo parameterInfo in parameters)
		{
			if (IsParameterDisposable(parameterInfo.ParameterType))
			{
				return false;
			}
		}
		if (methodInfo.ReturnParameter != null)
		{
			return !IsParameterDisposable(methodInfo.ReturnParameter.ParameterType);
		}
		return true;
	}

	internal static bool IsParameterDisposable(Type type)
	{
		if (type.IsSealed())
		{
			return typeof(IDisposable).IsAssignableFrom(type);
		}
		return true;
	}
}

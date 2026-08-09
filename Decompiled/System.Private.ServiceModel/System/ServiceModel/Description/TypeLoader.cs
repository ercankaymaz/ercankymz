using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace System.ServiceModel.Description;

internal class TypeLoader
{
	private abstract class OperationConsistencyVerifier
	{
		public virtual void VerifyParameterLength()
		{
		}

		public virtual void VerifyParameterType()
		{
		}

		public virtual void VerifyOutParameterType()
		{
		}

		public virtual void VerifyReturnType()
		{
		}

		public virtual void VerifyFaultContractAttribute()
		{
		}

		public virtual void VerifyKnownTypeAttribute()
		{
		}

		public virtual void VerifyIsOneWayStatus()
		{
		}

		public virtual void VerifyActionAndReplyAction()
		{
		}
	}

	private class SyncAsyncOperationConsistencyVerifier : OperationConsistencyVerifier
	{
		private OperationDescription _syncOperation;

		private OperationDescription _asyncOperation;

		private ParameterInfo[] _syncInputs;

		private ParameterInfo[] _asyncInputs;

		private ParameterInfo[] _syncOutputs;

		private ParameterInfo[] _asyncOutputs;

		public SyncAsyncOperationConsistencyVerifier(OperationDescription syncOperation, OperationDescription asyncOperation)
		{
			_syncOperation = syncOperation;
			_asyncOperation = asyncOperation;
			_syncInputs = ServiceReflector.GetInputParameters(_syncOperation.SyncMethod, asyncPattern: false);
			_asyncInputs = ServiceReflector.GetInputParameters(_asyncOperation.BeginMethod, asyncPattern: true);
			_syncOutputs = ServiceReflector.GetOutputParameters(_syncOperation.SyncMethod, asyncPattern: false);
			_asyncOutputs = ServiceReflector.GetOutputParameters(_asyncOperation.EndMethod, asyncPattern: true);
		}

		public override void VerifyParameterLength()
		{
			if (_syncInputs.Length != _asyncInputs.Length || _syncOutputs.Length != _asyncOutputs.Length)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncAsyncMatchConsistency_Parameters5, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _syncOperation.Name)));
			}
		}

		public override void VerifyParameterType()
		{
			for (int i = 0; i < _syncInputs.Length; i++)
			{
				if (_syncInputs[i].ParameterType != _asyncInputs[i].ParameterType)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncAsyncMatchConsistency_Parameters5, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _syncOperation.Name)));
				}
			}
		}

		public override void VerifyOutParameterType()
		{
			for (int i = 0; i < _syncOutputs.Length; i++)
			{
				if (_syncOutputs[i].ParameterType != _asyncOutputs[i].ParameterType)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncAsyncMatchConsistency_Parameters5, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _syncOperation.Name)));
				}
			}
		}

		public override void VerifyReturnType()
		{
			if (_syncOperation.SyncMethod.ReturnType != _syncOperation.EndMethod.ReturnType)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncAsyncMatchConsistency_ReturnType5, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _syncOperation.Name)));
			}
		}

		public override void VerifyFaultContractAttribute()
		{
			if (_asyncOperation.Faults.Count != 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncAsyncMatchConsistency_Attributes6, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _syncOperation.Name, typeof(FaultContractAttribute).Name)));
			}
		}

		public override void VerifyKnownTypeAttribute()
		{
			if (_asyncOperation.KnownTypes.Count != 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncAsyncMatchConsistency_Attributes6, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _syncOperation.Name, typeof(ServiceKnownTypeAttribute).Name)));
			}
		}

		public override void VerifyIsOneWayStatus()
		{
			if (_syncOperation.Messages.Count != _asyncOperation.Messages.Count)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncAsyncMatchConsistency_Property6, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _syncOperation.Name, "IsOneWay")));
			}
		}

		public override void VerifyActionAndReplyAction()
		{
			for (int i = 0; i < _syncOperation.Messages.Count; i++)
			{
				if (_syncOperation.Messages[i].Action != _asyncOperation.Messages[i].Action)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncAsyncMatchConsistency_Property6, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _syncOperation.Name, (i == 0) ? "Action" : "ReplyAction")));
				}
			}
		}
	}

	private class SyncTaskOperationConsistencyVerifier : OperationConsistencyVerifier
	{
		private OperationDescription _syncOperation;

		private OperationDescription _taskOperation;

		private ParameterInfo[] _syncInputs;

		private ParameterInfo[] _taskInputs;

		public SyncTaskOperationConsistencyVerifier(OperationDescription syncOperation, OperationDescription taskOperation)
		{
			_syncOperation = syncOperation;
			_taskOperation = taskOperation;
			_syncInputs = ServiceReflector.GetInputParameters(_syncOperation.SyncMethod, asyncPattern: false);
			_taskInputs = ServiceReflector.GetInputParameters(_taskOperation.TaskMethod, asyncPattern: false);
		}

		public override void VerifyParameterLength()
		{
			if (_syncInputs.Length != _taskInputs.Length)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncTaskMatchConsistency_Parameters5, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _taskOperation.TaskMethod.Name, _syncOperation.Name)));
			}
		}

		public override void VerifyParameterType()
		{
			for (int i = 0; i < _syncInputs.Length; i++)
			{
				if (_syncInputs[i].ParameterType != _taskInputs[i].ParameterType)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncTaskMatchConsistency_Parameters5, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _taskOperation.TaskMethod.Name, _syncOperation.Name)));
				}
			}
		}

		public override void VerifyReturnType()
		{
			if (_syncOperation.SyncMethod.ReturnType != _syncOperation.TaskTResult)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncTaskMatchConsistency_ReturnType5, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _taskOperation.TaskMethod.Name, _syncOperation.Name)));
			}
		}

		public override void VerifyFaultContractAttribute()
		{
			if (_taskOperation.Faults.Count != 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncTaskMatchConsistency_Attributes6, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _taskOperation.TaskMethod.Name, _syncOperation.Name, typeof(FaultContractAttribute).Name)));
			}
		}

		public override void VerifyKnownTypeAttribute()
		{
			if (_taskOperation.KnownTypes.Count != 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncTaskMatchConsistency_Attributes6, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _taskOperation.TaskMethod.Name, _syncOperation.Name, typeof(ServiceKnownTypeAttribute).Name)));
			}
		}

		public override void VerifyIsOneWayStatus()
		{
			if (_syncOperation.Messages.Count != _taskOperation.Messages.Count)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncTaskMatchConsistency_Property6, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _taskOperation.TaskMethod.Name, _syncOperation.Name, "IsOneWay")));
			}
		}

		public override void VerifyActionAndReplyAction()
		{
			for (int i = 0; i < _syncOperation.Messages.Count; i++)
			{
				if (_syncOperation.Messages[i].Action != _taskOperation.Messages[i].Action)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncTaskMatchConsistency_Property6, _syncOperation.SyncMethod.Name, _syncOperation.SyncMethod.DeclaringType, _taskOperation.TaskMethod.Name, _syncOperation.Name, (i == 0) ? "Action" : "ReplyAction")));
				}
			}
		}
	}

	private class TaskAsyncOperationConsistencyVerifier : OperationConsistencyVerifier
	{
		private OperationDescription _taskOperation;

		private OperationDescription _asyncOperation;

		private ParameterInfo[] _taskInputs;

		private ParameterInfo[] _asyncInputs;

		public TaskAsyncOperationConsistencyVerifier(OperationDescription taskOperation, OperationDescription asyncOperation)
		{
			_taskOperation = taskOperation;
			_asyncOperation = asyncOperation;
			_taskInputs = ServiceReflector.GetInputParameters(_taskOperation.TaskMethod, asyncPattern: false);
			_asyncInputs = ServiceReflector.GetInputParameters(_asyncOperation.BeginMethod, asyncPattern: true);
		}

		public override void VerifyParameterLength()
		{
			if (_taskInputs.Length != _asyncInputs.Length)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TaskAsyncMatchConsistency_Parameters5, _taskOperation.TaskMethod.Name, _taskOperation.TaskMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _taskOperation.Name)));
			}
		}

		public override void VerifyParameterType()
		{
			for (int i = 0; i < _taskInputs.Length; i++)
			{
				if (_taskInputs[i].ParameterType != _asyncInputs[i].ParameterType)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TaskAsyncMatchConsistency_Parameters5, _taskOperation.TaskMethod.Name, _taskOperation.TaskMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _taskOperation.Name)));
				}
			}
		}

		public override void VerifyReturnType()
		{
			if (_taskOperation.TaskTResult != _asyncOperation.EndMethod.ReturnType)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TaskAsyncMatchConsistency_ReturnType5, _taskOperation.TaskMethod.Name, _taskOperation.TaskMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _taskOperation.Name)));
			}
		}

		public override void VerifyFaultContractAttribute()
		{
			if (_asyncOperation.Faults.Count != 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TaskAsyncMatchConsistency_Attributes6, _taskOperation.TaskMethod.Name, _taskOperation.TaskMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _taskOperation.Name, typeof(FaultContractAttribute).Name)));
			}
		}

		public override void VerifyKnownTypeAttribute()
		{
			if (_asyncOperation.KnownTypes.Count != 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TaskAsyncMatchConsistency_Attributes6, _taskOperation.TaskMethod.Name, _taskOperation.TaskMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _taskOperation.Name, typeof(ServiceKnownTypeAttribute).Name)));
			}
		}

		public override void VerifyIsOneWayStatus()
		{
			if (_taskOperation.Messages.Count != _asyncOperation.Messages.Count)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TaskAsyncMatchConsistency_Property6, _taskOperation.TaskMethod.Name, _taskOperation.TaskMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _taskOperation.Name, "IsOneWay")));
			}
		}

		public override void VerifyActionAndReplyAction()
		{
			for (int i = 0; i < _taskOperation.Messages.Count; i++)
			{
				if (_taskOperation.Messages[i].Action != _asyncOperation.Messages[i].Action)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TaskAsyncMatchConsistency_Property6, _taskOperation.TaskMethod.Name, _taskOperation.TaskMethod.DeclaringType, _asyncOperation.BeginMethod.Name, _asyncOperation.EndMethod.Name, _taskOperation.Name, (i == 0) ? "Action" : "ReplyAction")));
				}
			}
		}
	}

	private class ContractReflectionInfo
	{
		internal Type iface;

		internal Type callbackiface;
	}

	public delegate void ServiceInheritanceCallback<IBehavior, TBehaviorCollection>(Type currentType, KeyedByTypeCollection<IBehavior> behaviors);

	private static Type[] s_messageContractMemberAttributes = new Type[3]
	{
		typeof(MessageHeaderAttribute),
		typeof(MessageBodyMemberAttribute),
		typeof(MessagePropertyAttribute)
	};

	private static Type[] s_formatterAttributes = new Type[2]
	{
		typeof(XmlSerializerFormatAttribute),
		typeof(DataContractFormatAttribute)
	};

	private static Type[] s_knownTypesMethodParamType = new Type[1] { typeof(ICustomAttributeProvider) };

	internal static DataContractFormatAttribute DefaultDataContractFormatAttribute = new DataContractFormatAttribute();

	internal static XmlSerializerFormatAttribute DefaultXmlSerializerFormatAttribute = new XmlSerializerFormatAttribute();

	private static readonly Type s_OperationContractAttributeType = typeof(OperationContractAttribute);

	internal const string ReturnSuffix = "Result";

	internal const string ResponseSuffix = "Response";

	internal const string FaultSuffix = "Fault";

	internal const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	private readonly object _thisLock;

	private readonly Dictionary<Type, ContractDescription> _contracts;

	private readonly Dictionary<Type, MessageDescriptionItems> _messages;

	public TypeLoader()
	{
		_thisLock = new object();
		_contracts = new Dictionary<Type, ContractDescription>();
		_messages = new Dictionary<Type, MessageDescriptionItems>();
	}

	private ContractDescription LoadContractDescriptionHelper(Type contractType, Type serviceType, object serviceImplementation)
	{
		ContractDescription value;
		if (contractType == typeof(IOutputChannel))
		{
			value = LoadOutputChannelContractDescription();
		}
		else if (contractType == typeof(IRequestChannel))
		{
			value = LoadRequestChannelContractDescription();
		}
		else
		{
			ServiceContractAttribute contractAttribute;
			Type contractTypeAndAttribute = ServiceReflector.GetContractTypeAndAttribute(contractType, out contractAttribute);
			lock (_thisLock)
			{
				if (!_contracts.TryGetValue(contractTypeAndAttribute, out value))
				{
					EnsureNoInheritanceWithContractClasses(contractTypeAndAttribute);
					EnsureNoOperationContractsOnNonServiceContractTypes(contractTypeAndAttribute);
					value = CreateContractDescription(contractAttribute, contractTypeAndAttribute, serviceType, out var reflectionInfo, serviceImplementation);
					if (serviceImplementation != null && serviceImplementation is IContractBehavior)
					{
						value.Behaviors.Add((IContractBehavior)serviceImplementation);
					}
					if (serviceType != null)
					{
						UpdateContractDescriptionWithAttributesFromServiceType(value, serviceType);
						foreach (ContractDescription inheritedContract in value.GetInheritedContracts())
						{
							UpdateContractDescriptionWithAttributesFromServiceType(inheritedContract, serviceType);
						}
					}
					UpdateOperationsWithInterfaceAttributes(value, reflectionInfo);
					AddBehaviors(value, serviceType, implIsCallback: false, reflectionInfo);
					_contracts.Add(contractTypeAndAttribute, value);
				}
			}
		}
		return value;
	}

	private void EnsureNoInheritanceWithContractClasses(Type actualContractType)
	{
		if (!actualContractType.IsClass())
		{
			return;
		}
		Type type = actualContractType.BaseType();
		while (type != null)
		{
			if (ServiceReflector.GetSingleAttribute<ServiceContractAttribute>(type) != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxContractInheritanceRequiresInterfaces, actualContractType, type)));
			}
			type = type.BaseType();
		}
	}

	private void EnsureNoOperationContractsOnNonServiceContractTypes(Type actualContractType)
	{
		Type[] interfaces = actualContractType.GetInterfaces();
		foreach (Type aParentType in interfaces)
		{
			EnsureNoOperationContractsOnNonServiceContractTypes_Helper(aParentType);
		}
		Type type = actualContractType.BaseType();
		while (type != null)
		{
			EnsureNoOperationContractsOnNonServiceContractTypes_Helper(type);
			type = type.BaseType();
		}
	}

	private void EnsureNoOperationContractsOnNonServiceContractTypes_Helper(Type aParentType)
	{
		if (ServiceReflector.GetSingleAttribute<ServiceContractAttribute>(aParentType) != null)
		{
			return;
		}
		foreach (MethodInfo item in from m in aParentType.GetRuntimeMethods()
			where !m.IsStatic
			select m)
		{
			Type operationContractProviderType = ServiceReflector.GetOperationContractProviderType(item);
			if (operationContractProviderType != null)
			{
				if (operationContractProviderType == s_OperationContractAttributeType)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxOperationContractOnNonServiceContract, item.Name, aParentType.Name)));
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxOperationContractProviderOnNonServiceContract, operationContractProviderType.Name, item.Name, aParentType.Name)));
			}
		}
	}

	public ContractDescription LoadContractDescription(Type contractType)
	{
		return LoadContractDescriptionHelper(contractType, null, null);
	}

	public ContractDescription LoadContractDescription(Type contractType, Type serviceType)
	{
		return LoadContractDescriptionHelper(contractType, serviceType, null);
	}

	public ContractDescription LoadContractDescription(Type contractType, Type serviceType, object serviceImplementation)
	{
		return LoadContractDescriptionHelper(contractType, serviceType, serviceImplementation);
	}

	private ContractDescription LoadOutputChannelContractDescription()
	{
		Type typeFromHandle = typeof(IOutputChannel);
		XmlQualifiedName contractName = NamingHelper.GetContractName(typeFromHandle, null, "http://schemas.microsoft.com/2005/07/ServiceModel");
		ContractDescription contractDescription = new ContractDescription(contractName.Name, contractName.Namespace);
		contractDescription.ContractType = typeFromHandle;
		contractDescription.ConfigurationName = typeFromHandle.FullName;
		contractDescription.SessionMode = SessionMode.NotAllowed;
		OperationDescription operationDescription = new OperationDescription("Send", contractDescription);
		MessageDescription item = new MessageDescription("*", MessageDirection.Input);
		operationDescription.Messages.Add(item);
		contractDescription.Operations.Add(operationDescription);
		return contractDescription;
	}

	private ContractDescription LoadRequestChannelContractDescription()
	{
		Type typeFromHandle = typeof(IRequestChannel);
		XmlQualifiedName contractName = NamingHelper.GetContractName(typeFromHandle, null, "http://schemas.microsoft.com/2005/07/ServiceModel");
		ContractDescription contractDescription = new ContractDescription(contractName.Name, contractName.Namespace);
		contractDescription.ContractType = typeFromHandle;
		contractDescription.ConfigurationName = typeFromHandle.FullName;
		contractDescription.SessionMode = SessionMode.NotAllowed;
		OperationDescription operationDescription = new OperationDescription("Request", contractDescription);
		MessageDescription item = new MessageDescription("*", MessageDirection.Input);
		MessageDescription item2 = new MessageDescription("*", MessageDirection.Output);
		operationDescription.Messages.Add(item);
		operationDescription.Messages.Add(item2);
		contractDescription.Operations.Add(operationDescription);
		return contractDescription;
	}

	private void AddBehaviors(ContractDescription contractDesc, Type implType, bool implIsCallback, ContractReflectionInfo reflectionInfo)
	{
		ServiceContractAttribute requiredSingleAttribute = ServiceReflector.GetRequiredSingleAttribute<ServiceContractAttribute>(reflectionInfo.iface);
		for (int i = 0; i < contractDesc.Operations.Count; i++)
		{
			OperationDescription operationDescription = contractDesc.Operations[i];
			if (operationDescription.DeclaringContract == contractDesc)
			{
				operationDescription.Behaviors.Add(new OperationInvokerBehavior());
			}
		}
		contractDesc.Behaviors.Add(new OperationSelectorBehavior());
		for (int j = 0; j < contractDesc.Operations.Count; j++)
		{
			OperationDescription opDesc = contractDesc.Operations[j];
			bool flag = opDesc.DeclaringContract != contractDesc;
			Type targetIface = (implIsCallback ? opDesc.DeclaringContract.CallbackContractType : opDesc.DeclaringContract.ContractType);
			if (implType == null && !flag)
			{
				KeyedByTypeCollection<IOperationBehavior> iOperationBehaviorAttributesFromType = GetIOperationBehaviorAttributesFromType(opDesc, targetIface, null);
				for (int k = 0; k < iOperationBehaviorAttributesFromType.Count; k++)
				{
					opDesc.Behaviors.Add(iOperationBehaviorAttributesFromType[k]);
				}
				continue;
			}
			ApplyServiceInheritance(implType, opDesc.Behaviors, delegate(Type currentType, KeyedByTypeCollection<IOperationBehavior> behaviors)
			{
				KeyedByTypeCollection<IOperationBehavior> iOperationBehaviorAttributesFromType2 = GetIOperationBehaviorAttributesFromType(opDesc, targetIface, currentType);
				for (int l = 0; l < iOperationBehaviorAttributesFromType2.Count; l++)
				{
					behaviors.Add(iOperationBehaviorAttributesFromType2[l]);
				}
			});
			if (flag)
			{
				continue;
			}
			AddBehaviorsAtOneScope(targetIface, opDesc.Behaviors, delegate(Type currentType, KeyedByTypeCollection<IOperationBehavior> behaviors)
			{
				KeyedByTypeCollection<IOperationBehavior> iOperationBehaviorAttributesFromType2 = GetIOperationBehaviorAttributesFromType(opDesc, targetIface, null);
				for (int l = 0; l < iOperationBehaviorAttributesFromType2.Count; l++)
				{
					behaviors.Add(iOperationBehaviorAttributesFromType2[l]);
				}
			});
		}
		Type type = (implIsCallback ? reflectionInfo.callbackiface : reflectionInfo.iface);
		AddBehaviorsAtOneScope<IContractBehavior, KeyedByTypeCollection<IContractBehavior>>(type, contractDesc.Behaviors, GetIContractBehaviorsFromInterfaceType);
		bool flag2 = false;
		for (int num = 0; num < contractDesc.Operations.Count; num++)
		{
			OperationDescription operationDescription2 = contractDesc.Operations[num];
			bool flag3 = operationDescription2.DeclaringContract != contractDesc;
			MethodInfo operationMethod = operationDescription2.OperationMethod;
			Attribute formattingAttribute = GetFormattingAttribute(operationMethod, GetFormattingAttribute(operationDescription2.DeclaringContract.ContractType, DefaultDataContractFormatAttribute));
			if (formattingAttribute is DataContractFormatAttribute dataContractFormatAttribute)
			{
				if (!flag3)
				{
					operationDescription2.Behaviors.Add(new DataContractSerializerOperationBehavior(operationDescription2, dataContractFormatAttribute, builtInOperationBehavior: true));
				}
			}
			else if (formattingAttribute != null && formattingAttribute is XmlSerializerFormatAttribute)
			{
				flag2 = true;
			}
		}
		if (flag2)
		{
			XmlSerializerOperationBehavior.AddBuiltInBehaviors(contractDesc);
		}
	}

	private void GetIContractBehaviorsFromInterfaceType(Type interfaceType, KeyedByTypeCollection<IContractBehavior> behaviors)
	{
		object[] customAttributes = ServiceReflector.GetCustomAttributes(interfaceType, typeof(IContractBehavior), inherit: false);
		for (int i = 0; i < customAttributes.Length; i++)
		{
			IContractBehavior item = (IContractBehavior)customAttributes[i];
			behaviors.Add(item);
		}
	}

	private static void UpdateContractDescriptionWithAttributesFromServiceType(ContractDescription description, Type serviceType)
	{
		ApplyServiceInheritance(serviceType, description.Behaviors, delegate(Type currentType, KeyedByTypeCollection<IContractBehavior> behaviors)
		{
			object[] customAttributes = ServiceReflector.GetCustomAttributes(currentType, typeof(IContractBehavior), inherit: false);
			int num = 0;
			if (num < customAttributes.Length)
			{
				IContractBehavior contractBehavior = (IContractBehavior)customAttributes[num];
				throw ExceptionHelper.PlatformNotSupported();
			}
		});
	}

	private void UpdateOperationsWithInterfaceAttributes(ContractDescription contractDesc, ContractReflectionInfo reflectionInfo)
	{
		object[] customAttributes = ServiceReflector.GetCustomAttributes(reflectionInfo.iface, typeof(ServiceKnownTypeAttribute), inherit: false);
		IEnumerable<Type> knownTypes = GetKnownTypes(customAttributes, reflectionInfo.iface);
		foreach (Type item in knownTypes)
		{
			foreach (OperationDescription operation in contractDesc.Operations)
			{
				if (!operation.IsServerInitiated())
				{
					operation.KnownTypes.Add(item);
				}
			}
		}
		if (!(reflectionInfo.callbackiface != null))
		{
			return;
		}
		customAttributes = ServiceReflector.GetCustomAttributes(reflectionInfo.callbackiface, typeof(ServiceKnownTypeAttribute), inherit: false);
		knownTypes = GetKnownTypes(customAttributes, reflectionInfo.callbackiface);
		foreach (Type item2 in knownTypes)
		{
			foreach (OperationDescription operation2 in contractDesc.Operations)
			{
				if (operation2.IsServerInitiated())
				{
					operation2.KnownTypes.Add(item2);
				}
			}
		}
	}

	private IEnumerable<Type> GetKnownTypes(object[] knownTypeAttributes, ICustomAttributeProvider provider)
	{
		if (knownTypeAttributes.Length == 1)
		{
			ServiceKnownTypeAttribute serviceKnownTypeAttribute = (ServiceKnownTypeAttribute)knownTypeAttributes[0];
			if (!string.IsNullOrEmpty(serviceKnownTypeAttribute.MethodName))
			{
				Type type = serviceKnownTypeAttribute.DeclaringType;
				if (type == null)
				{
					type = provider as Type;
					if (type == null && provider is MethodInfo methodInfo)
					{
						type = methodInfo.DeclaringType;
					}
				}
				MethodInfo runtimeMethod = type.GetRuntimeMethod(serviceKnownTypeAttribute.MethodName, s_knownTypesMethodParamType);
				if (runtimeMethod == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxKnownTypeAttributeUnknownMethod3, provider, serviceKnownTypeAttribute.MethodName, type.FullName)));
				}
				if (!typeof(IEnumerable<Type>).IsAssignableFrom(runtimeMethod.ReturnType))
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxKnownTypeAttributeReturnType3, provider, serviceKnownTypeAttribute.MethodName, type.FullName)));
				}
				return (IEnumerable<Type>)runtimeMethod.Invoke(null, new object[1] { provider });
			}
		}
		List<Type> list = new List<Type>();
		for (int i = 0; i < knownTypeAttributes.Length; i++)
		{
			ServiceKnownTypeAttribute serviceKnownTypeAttribute2 = (ServiceKnownTypeAttribute)knownTypeAttributes[i];
			if (serviceKnownTypeAttribute2.Type == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxKnownTypeAttributeInvalid1, provider.ToString())));
			}
			list.Add(serviceKnownTypeAttribute2.Type);
		}
		return list;
	}

	private KeyedByTypeCollection<IOperationBehavior> GetIOperationBehaviorAttributesFromType(OperationDescription opDesc, Type targetIface, Type implType)
	{
		KeyedByTypeCollection<IOperationBehavior> result = new KeyedByTypeCollection<IOperationBehavior>();
		bool useImplAttrs = false;
		if (implType != null)
		{
			if (!targetIface.IsAssignableFrom(implType) || !targetIface.IsInterface())
			{
				return result;
			}
			useImplAttrs = true;
		}
		MethodInfo operationMethod = opDesc.OperationMethod;
		ProcessOpMethod(operationMethod, canHaveBehaviors: true, opDesc, result, targetIface, implType, useImplAttrs);
		if (opDesc.SyncMethod != null && opDesc.BeginMethod != null)
		{
			ProcessOpMethod(opDesc.BeginMethod, canHaveBehaviors: false, opDesc, result, targetIface, implType, useImplAttrs);
		}
		else if (opDesc.SyncMethod != null && opDesc.TaskMethod != null)
		{
			ProcessOpMethod(opDesc.TaskMethod, canHaveBehaviors: false, opDesc, result, targetIface, implType, useImplAttrs);
		}
		else if (opDesc.TaskMethod != null && opDesc.BeginMethod != null)
		{
			ProcessOpMethod(opDesc.BeginMethod, canHaveBehaviors: false, opDesc, result, targetIface, implType, useImplAttrs);
		}
		return result;
	}

	private void ProcessOpMethod(MethodInfo opMethod, bool canHaveBehaviors, OperationDescription opDesc, KeyedByTypeCollection<IOperationBehavior> result, Type ifaceType, Type implType, bool useImplAttrs)
	{
		MethodInfo methodInfo = null;
		if (useImplAttrs)
		{
			MethodInfo correspondingMethodFromType = GetCorrespondingMethodFromType(ifaceType, opMethod);
			if (correspondingMethodFromType != null)
			{
				MethodInfo correspondingMethodFromType2 = GetCorrespondingMethodFromType(implType, opMethod);
				if (correspondingMethodFromType2 != null)
				{
					methodInfo = correspondingMethodFromType2;
				}
			}
			if (methodInfo == null)
			{
				return;
			}
		}
		else
		{
			methodInfo = opMethod;
		}
		object[] customAttributes = ServiceReflector.GetCustomAttributes(methodInfo, typeof(IOperationBehavior), inherit: false);
		for (int i = 0; i < customAttributes.Length; i++)
		{
			IOperationBehavior operationBehavior = (IOperationBehavior)customAttributes[i];
			if (canHaveBehaviors)
			{
				result.Add(operationBehavior);
				continue;
			}
			if (opDesc.SyncMethod != null && opDesc.BeginMethod != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncAsyncMatchConsistency_Attributes6, opDesc.SyncMethod.Name, opDesc.SyncMethod.DeclaringType, opDesc.BeginMethod.Name, opDesc.EndMethod.Name, opDesc.Name, operationBehavior.GetType().FullName)));
			}
			if (opDesc.SyncMethod != null && opDesc.TaskMethod != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SyncTaskMatchConsistency_Attributes6, opDesc.SyncMethod.Name, opDesc.SyncMethod.DeclaringType, opDesc.TaskMethod.Name, opDesc.Name, operationBehavior.GetType().FullName)));
			}
			if (opDesc.TaskMethod != null && opDesc.BeginMethod != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TaskAsyncMatchConsistency_Attributes6, opDesc.TaskMethod.Name, opDesc.TaskMethod.DeclaringType, opDesc.BeginMethod.Name, opDesc.EndMethod.Name, opDesc.Name, operationBehavior.GetType().FullName)));
			}
		}
	}

	private static MethodInfo GetCorrespondingMethodFromType(Type type, MethodInfo methodInfo)
	{
		if (methodInfo.DeclaringType == type)
		{
			return methodInfo;
		}
		return type.GetTypeInfo().DeclaredMethods.SingleOrDefault((MethodInfo m) => MethodsMatch(m, methodInfo));
	}

	private static bool MethodsMatch(MethodInfo method1, MethodInfo method2)
	{
		if (method1.Equals(method2))
		{
			return true;
		}
		if (method1.ReturnType != method2.ReturnType || !string.Equals(method1.Name, method2.Name, StringComparison.Ordinal) || !ParameterInfosMatch(method1.ReturnParameter, method2.ReturnParameter))
		{
			return false;
		}
		ParameterInfo[] parameters = method1.GetParameters();
		ParameterInfo[] parameters2 = method2.GetParameters();
		if (parameters.Length != parameters2.Length)
		{
			return false;
		}
		for (int i = 0; i < parameters.Length; i++)
		{
			if (!ParameterInfosMatch(parameters[i], parameters2[i]))
			{
				return false;
			}
		}
		return true;
	}

	private static bool ParameterInfosMatch(ParameterInfo parameterInfo1, ParameterInfo parameterInfo2)
	{
		if (parameterInfo1 == null && parameterInfo2 == null)
		{
			return true;
		}
		if (parameterInfo1 == null || parameterInfo2 == null)
		{
			return false;
		}
		if (parameterInfo1.Equals(parameterInfo2))
		{
			return true;
		}
		if (parameterInfo1.ParameterType == parameterInfo2.ParameterType && parameterInfo1.IsIn == parameterInfo2.IsIn && parameterInfo1.IsOut == parameterInfo2.IsOut && parameterInfo1.IsRetval == parameterInfo2.IsRetval)
		{
			return parameterInfo1.Position == parameterInfo2.Position;
		}
		return false;
	}

	internal void AddBehaviorsSFx(ServiceEndpoint serviceEndpoint, Type contractType)
	{
		if (serviceEndpoint.Contract.IsDuplex())
		{
			CallbackBehaviorAttribute callbackBehaviorAttribute = serviceEndpoint.Behaviors.Find<CallbackBehaviorAttribute>();
			if (callbackBehaviorAttribute == null)
			{
				serviceEndpoint.Behaviors.Insert(0, new CallbackBehaviorAttribute());
			}
		}
	}

	internal void AddBehaviorsFromImplementationType(ServiceEndpoint serviceEndpoint, Type implementationType)
	{
		object[] customAttributes = ServiceReflector.GetCustomAttributes(implementationType, typeof(IEndpointBehavior), inherit: false);
		for (int i = 0; i < customAttributes.Length; i++)
		{
			IEndpointBehavior endpointBehavior = (IEndpointBehavior)customAttributes[i];
			if (endpointBehavior is CallbackBehaviorAttribute)
			{
				serviceEndpoint.Behaviors.Insert(0, endpointBehavior);
			}
			else
			{
				serviceEndpoint.Behaviors.Add(endpointBehavior);
			}
		}
		object[] customAttributes2 = ServiceReflector.GetCustomAttributes(implementationType, typeof(IContractBehavior), inherit: false);
		for (int j = 0; j < customAttributes2.Length; j++)
		{
			IContractBehavior item = (IContractBehavior)customAttributes2[j];
			serviceEndpoint.Contract.Behaviors.Add(item);
		}
		Type targetIface = serviceEndpoint.Contract.CallbackContractType;
		for (int k = 0; k < serviceEndpoint.Contract.Operations.Count; k++)
		{
			OperationDescription opDesc = serviceEndpoint.Contract.Operations[k];
			KeyedByTypeCollection<IOperationBehavior> keyedByTypeCollection = new KeyedByTypeCollection<IOperationBehavior>();
			ApplyServiceInheritance(implementationType, keyedByTypeCollection, delegate(Type currentType, KeyedByTypeCollection<IOperationBehavior> behaviors)
			{
				KeyedByTypeCollection<IOperationBehavior> iOperationBehaviorAttributesFromType = GetIOperationBehaviorAttributesFromType(opDesc, targetIface, currentType);
				for (int l = 0; l < iOperationBehaviorAttributesFromType.Count; l++)
				{
					behaviors.Add(iOperationBehaviorAttributesFromType[l]);
				}
			});
			for (int num = 0; num < keyedByTypeCollection.Count; num++)
			{
				IOperationBehavior operationBehavior = keyedByTypeCollection[num];
				Type type = operationBehavior.GetType();
				if (opDesc.Behaviors.Contains(type))
				{
					opDesc.Behaviors.Remove(type);
				}
				opDesc.Behaviors.Add(operationBehavior);
			}
		}
	}

	internal static int CompareMessagePartDescriptions(MessagePartDescription a, MessagePartDescription b)
	{
		int num = a.SerializationPosition - b.SerializationPosition;
		if (num != 0)
		{
			return num;
		}
		int num2 = string.Compare(a.Namespace, b.Namespace, StringComparison.Ordinal);
		if (num2 != 0)
		{
			return num2;
		}
		return string.Compare(a.Name, b.Name, StringComparison.Ordinal);
	}

	internal static XmlName GetBodyWrapperResponseName(string operationName)
	{
		return new XmlName(operationName + "Response");
	}

	internal static XmlName GetBodyWrapperResponseName(XmlName operationName)
	{
		return new XmlName(operationName.EncodedName + "Response", isEncoded: true);
	}

	private void CreateOperationDescriptions(ContractDescription contractDescription, ContractReflectionInfo reflectionInfo, Type contractToGetMethodsFrom, ContractDescription declaringContract, MessageDirection direction)
	{
		MessageDirection messageDirection = MessageDirectionHelper.Opposite(direction);
		if (!declaringContract.ContractType.IsAssignableFrom(contractDescription.ContractType))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Bad contract inheritence. Contract {0} does not implement {1}", declaringContract.ContractType.Name, contractDescription.ContractType.Name)));
		}
		foreach (MethodInfo item in from m in contractToGetMethodsFrom.GetRuntimeMethods()
			where !m.IsStatic
			select m)
		{
			ServiceReflector.ValidateParameterMetadata(item);
			OperationDescription operationDescription = CreateOperationDescription(contractDescription, item, direction, reflectionInfo, declaringContract);
			if (operationDescription != null)
			{
				contractDescription.Operations.Add(operationDescription);
			}
		}
	}

	internal static void EnsureCallbackType(Type callbackType)
	{
		if (callbackType != null && !callbackType.IsInterface() && !callbackType.IsMarshalByRef())
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.SFxInvalidCallbackContractType, callbackType.Name)));
		}
	}

	internal static void EnsureSubcontract(ServiceContractAttribute svcContractAttr, Type contractType)
	{
		Type callbackContract = svcContractAttr.CallbackContract;
		List<Type> inheritedContractTypes = ServiceReflector.GetInheritedContractTypes(contractType);
		for (int i = 0; i < inheritedContractTypes.Count; i++)
		{
			Type type = inheritedContractTypes[i];
			ServiceContractAttribute requiredSingleAttribute = ServiceReflector.GetRequiredSingleAttribute<ServiceContractAttribute>(type);
			if (requiredSingleAttribute.CallbackContract != null)
			{
				if (callbackContract == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InAContractInheritanceHierarchyIfParentHasCallbackChildMustToo, type.Name, requiredSingleAttribute.CallbackContract.Name, contractType.Name)));
				}
				if (!requiredSingleAttribute.CallbackContract.IsAssignableFrom(callbackContract))
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InAContractInheritanceHierarchyTheServiceContract3_2, type.Name, contractType.Name)));
				}
			}
		}
	}

	private ContractDescription CreateContractDescription(ServiceContractAttribute contractAttr, Type contractType, Type serviceType, out ContractReflectionInfo reflectionInfo, object serviceImplementation)
	{
		reflectionInfo = new ContractReflectionInfo();
		XmlQualifiedName contractName = NamingHelper.GetContractName(contractType, contractAttr.Name, contractAttr.Namespace);
		ContractDescription contractDescription = new ContractDescription(contractName.Name, contractName.Namespace);
		contractDescription.ContractType = contractType;
		if (contractAttr.HasProtectionLevel)
		{
			contractDescription.ProtectionLevel = contractAttr.ProtectionLevel;
		}
		Type callbackContract = contractAttr.CallbackContract;
		EnsureCallbackType(callbackContract);
		EnsureSubcontract(contractAttr, contractType);
		reflectionInfo.iface = contractType;
		reflectionInfo.callbackiface = callbackContract;
		contractDescription.SessionMode = contractAttr.SessionMode;
		contractDescription.CallbackContractType = callbackContract;
		contractDescription.ConfigurationName = contractAttr.ConfigurationName ?? contractType.FullName;
		List<Type> inheritedContractTypes = ServiceReflector.GetInheritedContractTypes(contractType);
		List<Type> list = new List<Type>();
		for (int i = 0; i < inheritedContractTypes.Count; i++)
		{
			Type type = inheritedContractTypes[i];
			ServiceContractAttribute requiredSingleAttribute = ServiceReflector.GetRequiredSingleAttribute<ServiceContractAttribute>(type);
			ContractDescription contractDescription2 = LoadContractDescriptionHelper(type, serviceType, serviceImplementation);
			foreach (OperationDescription operation in contractDescription2.Operations)
			{
				if (contractDescription.Operations.Contains(operation))
				{
					continue;
				}
				Collection<OperationDescription> collection = contractDescription.Operations.FindAll(operation.Name);
				foreach (OperationDescription item in collection)
				{
					if (item.Messages[0].Direction == operation.Messages[0].Direction)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.CannotInheritTwoOperationsWithTheSameName3, operation.Name, contractDescription2.Name, item.DeclaringContract.Name)));
					}
				}
				contractDescription.Operations.Add(operation);
			}
			if (contractDescription2.CallbackContractType != null)
			{
				list.Add(contractDescription2.CallbackContractType);
			}
		}
		CreateOperationDescriptions(contractDescription, reflectionInfo, contractType, contractDescription, MessageDirection.Input);
		if (callbackContract != null && !list.Contains(callbackContract))
		{
			CreateOperationDescriptions(contractDescription, reflectionInfo, callbackContract, contractDescription, MessageDirection.Output);
		}
		return contractDescription;
	}

	internal static Attribute GetFormattingAttribute(ICustomAttributeProvider attrProvider, Attribute defaultFormatAttribute)
	{
		if (attrProvider != null)
		{
			if (attrProvider.IsDefined(typeof(XmlSerializerFormatAttribute), inherit: false))
			{
				return ServiceReflector.GetSingleAttribute<XmlSerializerFormatAttribute>(attrProvider, s_formatterAttributes);
			}
			if (attrProvider.IsDefined(typeof(DataContractFormatAttribute), inherit: false))
			{
				return ServiceReflector.GetSingleAttribute<DataContractFormatAttribute>(attrProvider, s_formatterAttributes);
			}
		}
		return defaultFormatAttribute;
	}

	private void VerifyConsistency(OperationConsistencyVerifier verifier)
	{
		verifier.VerifyParameterLength();
		verifier.VerifyParameterType();
		verifier.VerifyOutParameterType();
		verifier.VerifyReturnType();
		verifier.VerifyFaultContractAttribute();
		verifier.VerifyKnownTypeAttribute();
		verifier.VerifyIsOneWayStatus();
		verifier.VerifyActionAndReplyAction();
	}

	private OperationDescription CreateOperationDescription(ContractDescription contractDescription, MethodInfo methodInfo, MessageDirection direction, ContractReflectionInfo reflectionInfo, ContractDescription declaringContract)
	{
		OperationContractAttribute operationContractAttribute = ServiceReflector.GetOperationContractAttribute(methodInfo);
		if (operationContractAttribute == null)
		{
			return null;
		}
		if (ServiceReflector.HasEndMethodShape(methodInfo))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EndMethodsCannotBeDecoratedWithOperationContractAttribute, methodInfo.Name, reflectionInfo.iface)));
		}
		Type taskTResult;
		bool flag = ServiceReflector.IsTask(methodInfo, out taskTResult);
		bool flag2 = !flag && ServiceReflector.IsBegin(operationContractAttribute, methodInfo);
		XmlName operationName = NamingHelper.GetOperationName(ServiceReflector.GetLogicalName(methodInfo, flag2, flag), operationContractAttribute.Name);
		operationContractAttribute.EnsureInvariants(methodInfo, operationName.EncodedName);
		Collection<OperationDescription> collection = contractDescription.Operations.FindAll(operationName.EncodedName);
		for (int i = 0; i < collection.Count; i++)
		{
			OperationDescription operationDescription = collection[i];
			if (operationDescription.Messages[0].Direction != direction)
			{
				continue;
			}
			if (operationDescription.TaskMethod != null && flag)
			{
				string name = operationDescription.OperationMethod.Name;
				string name2 = methodInfo.Name;
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.CannotHaveTwoOperationsWithTheSameName3, name, name2, reflectionInfo.iface)));
			}
			if (flag2 && operationDescription.BeginMethod != null)
			{
				string name3 = operationDescription.BeginMethod.Name;
				string name4 = methodInfo.Name;
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.CannotHaveTwoOperationsWithTheSameName3, name3, name4, reflectionInfo.iface)));
			}
			if (!flag2 && !flag && operationDescription.SyncMethod != null)
			{
				string name5 = operationDescription.SyncMethod.Name;
				string name6 = methodInfo.Name;
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.CannotHaveTwoOperationsWithTheSameName3, name5, name6, reflectionInfo.iface)));
			}
			contractDescription.Operations.Remove(operationDescription);
			OperationDescription operationDescription2 = CreateOperationDescription(contractDescription, methodInfo, direction, reflectionInfo, declaringContract);
			operationDescription2.HasNoDisposableParameters = ServiceReflector.HasNoDisposableParameters(methodInfo);
			if (flag)
			{
				operationDescription.TaskMethod = operationDescription2.TaskMethod;
				operationDescription.TaskTResult = operationDescription2.TaskTResult;
				if (operationDescription.SyncMethod != null)
				{
					VerifyConsistency(new SyncTaskOperationConsistencyVerifier(operationDescription, operationDescription2));
				}
				else
				{
					VerifyConsistency(new TaskAsyncOperationConsistencyVerifier(operationDescription2, operationDescription));
				}
				return operationDescription;
			}
			if (flag2)
			{
				operationDescription.BeginMethod = operationDescription2.BeginMethod;
				operationDescription.EndMethod = operationDescription2.EndMethod;
				if (operationDescription.SyncMethod != null)
				{
					VerifyConsistency(new SyncAsyncOperationConsistencyVerifier(operationDescription, operationDescription2));
				}
				else
				{
					VerifyConsistency(new TaskAsyncOperationConsistencyVerifier(operationDescription, operationDescription2));
				}
				return operationDescription;
			}
			operationDescription2.BeginMethod = operationDescription.BeginMethod;
			operationDescription2.EndMethod = operationDescription.EndMethod;
			operationDescription2.TaskMethod = operationDescription.TaskMethod;
			operationDescription2.TaskTResult = operationDescription.TaskTResult;
			if (operationDescription.TaskMethod != null)
			{
				VerifyConsistency(new SyncTaskOperationConsistencyVerifier(operationDescription2, operationDescription));
			}
			else
			{
				VerifyConsistency(new SyncAsyncOperationConsistencyVerifier(operationDescription2, operationDescription));
			}
			return operationDescription2;
		}
		OperationDescription operationDescription3 = new OperationDescription(operationName.EncodedName, declaringContract);
		operationDescription3.IsInitiating = operationContractAttribute.IsInitiating;
		operationDescription3.IsTerminating = operationContractAttribute.IsTerminating;
		operationDescription3.IsSessionOpenNotificationEnabled = operationContractAttribute.IsSessionOpenNotificationEnabled;
		operationDescription3.HasNoDisposableParameters = ServiceReflector.HasNoDisposableParameters(methodInfo);
		if (operationContractAttribute.HasProtectionLevel)
		{
			throw ExceptionHelper.PlatformNotSupported("security: protectionLevel");
		}
		XmlQualifiedName contractName = new XmlQualifiedName(declaringContract.Name, declaringContract.Namespace);
		object[] customAttributes = ServiceReflector.GetCustomAttributes(methodInfo, typeof(FaultContractAttribute), inherit: false);
		if (operationContractAttribute.IsOneWay && customAttributes.Length != 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.OneWayAndFaultsIncompatible2, methodInfo.DeclaringType.FullName, operationName.EncodedName)));
		}
		for (int j = 0; j < customAttributes.Length; j++)
		{
			FaultContractAttribute attr = (FaultContractAttribute)customAttributes[j];
			FaultDescription faultDescription = CreateFaultDescription(attr, contractName, declaringContract.Namespace, operationDescription3.XmlName);
			CheckDuplicateFaultContract(operationDescription3.Faults, faultDescription, operationName.EncodedName);
			operationDescription3.Faults.Add(faultDescription);
		}
		customAttributes = ServiceReflector.GetCustomAttributes(methodInfo, typeof(ServiceKnownTypeAttribute), inherit: false);
		IEnumerable<Type> knownTypes = GetKnownTypes(customAttributes, methodInfo);
		foreach (Type item in knownTypes)
		{
			operationDescription3.KnownTypes.Add(item);
		}
		MessageDirection direction2 = MessageDirectionHelper.Opposite(direction);
		string messageAction = NamingHelper.GetMessageAction(contractName, operationDescription3.CodeName, operationContractAttribute.Action, isResponse: false);
		string messageAction2 = NamingHelper.GetMessageAction(contractName, operationDescription3.CodeName, operationContractAttribute.ReplyAction, isResponse: true);
		XmlName wrapperName = operationName;
		XmlName bodyWrapperResponseName = GetBodyWrapperResponseName(operationName);
		string wrapperNamespace = declaringContract.Namespace;
		MessageDescription messageDescription = CreateMessageDescription(methodInfo, flag2, flag, null, null, contractDescription.Namespace, messageAction, wrapperName, wrapperNamespace, direction);
		MessageDescription messageDescription2 = null;
		operationDescription3.Messages.Add(messageDescription);
		MethodInfo methodInfo2 = methodInfo;
		if (flag)
		{
			operationDescription3.TaskMethod = methodInfo;
			operationDescription3.TaskTResult = taskTResult;
		}
		else if (!flag2)
		{
			operationDescription3.SyncMethod = methodInfo;
		}
		else
		{
			methodInfo2 = (operationDescription3.EndMethod = ServiceReflector.GetEndMethod(methodInfo));
			operationDescription3.BeginMethod = methodInfo;
		}
		if (!operationContractAttribute.IsOneWay)
		{
			XmlName returnValueName = GetReturnValueName(operationName);
			messageDescription2 = CreateMessageDescription(methodInfo2, flag2, flag, taskTResult, returnValueName, contractDescription.Namespace, messageAction2, bodyWrapperResponseName, wrapperNamespace, direction2);
			operationDescription3.Messages.Add(messageDescription2);
		}
		else
		{
			if ((!flag && methodInfo2.ReturnType != ServiceReflector.VoidType) || (flag && taskTResult != ServiceReflector.VoidType) || ServiceReflector.HasOutputParameters(methodInfo2, flag2))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ServiceOperationsMarkedWithIsOneWayTrueMust0));
			}
			if (operationContractAttribute.ReplyAction != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.OneWayOperationShouldNotSpecifyAReplyAction1, operationName)));
			}
		}
		if (!operationContractAttribute.IsOneWay)
		{
			if (messageDescription2.IsVoid && (messageDescription.IsUntypedMessage || messageDescription.IsTypedMessage))
			{
				MessageBodyDescription body = messageDescription2.Body;
				string wrapperName2 = (messageDescription2.Body.WrapperNamespace = null);
				body.WrapperName = wrapperName2;
			}
			else if (messageDescription.IsVoid && (messageDescription2.IsUntypedMessage || messageDescription2.IsTypedMessage))
			{
				MessageBodyDescription body2 = messageDescription.Body;
				string wrapperName2 = (messageDescription.Body.WrapperNamespace = null);
				body2.WrapperName = wrapperName2;
			}
		}
		return operationDescription3;
	}

	private void CheckDuplicateFaultContract(FaultDescriptionCollection faultDescriptionCollection, FaultDescription fault, string operationName)
	{
		foreach (FaultDescription item in faultDescriptionCollection)
		{
			if (XmlName.IsNullOrEmpty(item.ElementName) && XmlName.IsNullOrEmpty(fault.ElementName) && item.DetailType == fault.DetailType)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxFaultContractDuplicateDetailType, operationName, fault.DetailType)));
			}
			if (!XmlName.IsNullOrEmpty(item.ElementName) && !XmlName.IsNullOrEmpty(fault.ElementName) && item.ElementName == fault.ElementName && item.Namespace == fault.Namespace)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxFaultContractDuplicateElement, operationName, fault.ElementName, fault.Namespace)));
			}
		}
	}

	private FaultDescription CreateFaultDescription(FaultContractAttribute attr, XmlQualifiedName contractName, string contractNamespace, XmlName operationName)
	{
		XmlName xmlName = new XmlName(attr.Name ?? (NamingHelper.TypeName(attr.DetailType) + "Fault"));
		FaultDescription faultDescription = new FaultDescription(NamingHelper.GetMessageAction(contractName, operationName.DecodedName + xmlName.DecodedName, attr.Action, isResponse: false));
		if (attr.Name != null)
		{
			faultDescription.SetNameAndElement(xmlName);
		}
		else
		{
			faultDescription.SetNameOnly(xmlName);
		}
		faultDescription.Namespace = attr.Namespace ?? contractNamespace;
		faultDescription.DetailType = attr.DetailType;
		if (attr.HasProtectionLevel)
		{
			faultDescription.ProtectionLevel = attr.ProtectionLevel;
		}
		return faultDescription;
	}

	private MessageDescription CreateMessageDescription(MethodInfo methodInfo, bool isAsync, bool isTask, Type taskTResult, XmlName returnValueName, string defaultNS, string action, XmlName wrapperName, string wrapperNamespace, MessageDirection direction)
	{
		string name = methodInfo.Name;
		MessageDescription messageDescription;
		if (returnValueName == null)
		{
			ParameterInfo[] inputParameters = ServiceReflector.GetInputParameters(methodInfo, isAsync);
			messageDescription = ((inputParameters.Length != 1 || !inputParameters[0].ParameterType.IsDefined(typeof(MessageContractAttribute), inherit: false)) ? CreateParameterMessageDescription(inputParameters, null, null, null, name, defaultNS, action, wrapperName, wrapperNamespace, direction) : CreateTypedMessageDescription(inputParameters[0].ParameterType, null, null, defaultNS, action, direction));
		}
		else
		{
			ParameterInfo[] outputParameters = ServiceReflector.GetOutputParameters(methodInfo, isAsync);
			Type type = (isTask ? taskTResult : methodInfo.ReturnType);
			messageDescription = ((!type.IsDefined(typeof(MessageContractAttribute), inherit: false) || outputParameters.Length != 0) ? CreateParameterMessageDescription(outputParameters, type, methodInfo.ReturnParameter, returnValueName, name, defaultNS, action, wrapperName, wrapperNamespace, direction) : CreateTypedMessageDescription(type, methodInfo.ReturnParameter, returnValueName, defaultNS, action, direction));
		}
		bool flag = false;
		for (int i = 0; i < messageDescription.Headers.Count; i++)
		{
			MessageHeaderDescription messageHeaderDescription = messageDescription.Headers[i];
			if (messageHeaderDescription.IsUnknownHeaderCollection)
			{
				if (flag)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxMultipleUnknownHeaders, methodInfo, methodInfo.DeclaringType)));
				}
				flag = true;
			}
		}
		return messageDescription;
	}

	private MessageDescription CreateParameterMessageDescription(ParameterInfo[] parameters, Type returnType, ICustomAttributeProvider returnAttrProvider, XmlName returnValueName, string methodName, string defaultNS, string action, XmlName wrapperName, string wrapperNamespace, MessageDirection direction)
	{
		foreach (ParameterInfo parameterInfo in parameters)
		{
			if (GetParameterType(parameterInfo).IsDefined(typeof(MessageContractAttribute), inherit: false))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidMessageContractSignature, methodName)));
			}
		}
		if (returnType != null && returnType.IsDefined(typeof(MessageContractAttribute), inherit: false))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidMessageContractSignature, methodName)));
		}
		MessageDescription messageDescription = new MessageDescription(action, direction);
		MessagePartDescriptionCollection parts = messageDescription.Body.Parts;
		for (int j = 0; j < parameters.Length; j++)
		{
			MessagePartDescription messagePartDescription = CreateParameterPartDescription(new XmlName(parameters[j].Name), defaultNS, j, parameters[j], GetParameterType(parameters[j]));
			if (parts.Contains(new XmlQualifiedName(messagePartDescription.Name, messagePartDescription.Namespace)))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidMessageContractException(System.SR.Format(System.SR.SFxDuplicateMessageParts, messagePartDescription.Name, messagePartDescription.Namespace)));
			}
			messageDescription.Body.Parts.Add(messagePartDescription);
		}
		if (returnType != null)
		{
			messageDescription.Body.ReturnValue = CreateParameterPartDescription(returnValueName, defaultNS, 0, returnAttrProvider, returnType);
		}
		if (messageDescription.IsUntypedMessage)
		{
			messageDescription.Body.WrapperName = null;
			messageDescription.Body.WrapperNamespace = null;
		}
		else
		{
			messageDescription.Body.WrapperName = wrapperName.EncodedName;
			messageDescription.Body.WrapperNamespace = wrapperNamespace;
		}
		return messageDescription;
	}

	private static MessagePartDescription CreateParameterPartDescription(XmlName defaultName, string defaultNS, int index, ICustomAttributeProvider attrProvider, Type type)
	{
		MessageParameterAttribute singleAttribute = ServiceReflector.GetSingleAttribute<MessageParameterAttribute>(attrProvider);
		XmlName xmlName = ((singleAttribute == null || !singleAttribute.IsNameSetExplicit) ? defaultName : new XmlName(singleAttribute.Name));
		MessagePartDescription messagePartDescription = new MessagePartDescription(xmlName.EncodedName, defaultNS);
		messagePartDescription.Type = type;
		messagePartDescription.Index = index;
		messagePartDescription.AdditionalAttributesProvider = attrProvider;
		return messagePartDescription;
	}

	internal MessageDescription CreateTypedMessageDescription(Type typedMessageType, ICustomAttributeProvider returnAttrProvider, XmlName returnValueName, string defaultNS, string action, MessageDirection direction)
	{
		bool flag = false;
		MessageContractAttribute singleAttribute = ServiceReflector.GetSingleAttribute<MessageContractAttribute>(typedMessageType);
		MessageDescription messageDescription;
		if (_messages.TryGetValue(typedMessageType, out var value))
		{
			messageDescription = new MessageDescription(action, direction, value);
			flag = true;
		}
		else
		{
			messageDescription = new MessageDescription(action, direction, null);
		}
		messageDescription.MessageType = typedMessageType;
		messageDescription.MessageName = new XmlName(NamingHelper.TypeName(typedMessageType));
		if (singleAttribute.IsWrapped)
		{
			messageDescription.Body.WrapperName = GetWrapperName(singleAttribute.WrapperName, messageDescription.MessageName).EncodedName;
			messageDescription.Body.WrapperNamespace = singleAttribute.WrapperNamespace ?? defaultNS;
		}
		List<MemberInfo> list = new List<MemberInfo>();
		Type type = typedMessageType;
		while (type != null && type != typeof(object) && type != typeof(ValueType))
		{
			if (!type.IsDefined(typeof(MessageContractAttribute), inherit: false))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxMessageContractBaseTypeNotValid, type, typedMessageType)));
			}
			if (!messageDescription.HasProtectionLevel)
			{
				MessageContractAttribute requiredSingleAttribute = ServiceReflector.GetRequiredSingleAttribute<MessageContractAttribute>(type);
				if (requiredSingleAttribute.HasProtectionLevel)
				{
					messageDescription.ProtectionLevel = requiredSingleAttribute.ProtectionLevel;
				}
			}
			if (!flag)
			{
				foreach (MemberInfo declaredMember in type.GetTypeInfo().DeclaredMembers)
				{
					if (!(declaredMember is FieldInfo) && !(declaredMember is PropertyInfo))
					{
						continue;
					}
					PropertyInfo propertyInfo = declaredMember as PropertyInfo;
					if (propertyInfo != null)
					{
						MethodInfo getMethod = propertyInfo.GetGetMethod(nonPublic: true);
						if (getMethod != null && (getMethod.IsStatic || IsMethodOverriding(getMethod)))
						{
							continue;
						}
						MethodInfo setMethod = propertyInfo.GetSetMethod(nonPublic: true);
						if (setMethod != null && (setMethod.IsStatic || IsMethodOverriding(setMethod)))
						{
							continue;
						}
					}
					else if (((FieldInfo)declaredMember).IsStatic)
					{
						continue;
					}
					if (declaredMember.IsDefined(typeof(MessageBodyMemberAttribute), inherit: false) || declaredMember.IsDefined(typeof(MessageHeaderAttribute), inherit: false) || declaredMember.IsDefined(typeof(MessageHeaderArrayAttribute), inherit: false) || declaredMember.IsDefined(typeof(MessagePropertyAttribute), inherit: false))
					{
						list.Add(declaredMember);
					}
				}
			}
			type = type.BaseType();
		}
		if (flag)
		{
			return messageDescription;
		}
		List<MessagePartDescription> list2 = new List<MessagePartDescription>();
		List<MessageHeaderDescription> list3 = new List<MessageHeaderDescription>();
		for (int i = 0; i < list.Count; i++)
		{
			MemberInfo memberInfo = list[i];
			Type type2 = ((!(memberInfo is PropertyInfo)) ? ((FieldInfo)memberInfo).FieldType : ((PropertyInfo)memberInfo).PropertyType);
			if (memberInfo.IsDefined(typeof(MessageHeaderArrayAttribute), inherit: false) || memberInfo.IsDefined(typeof(MessageHeaderAttribute), inherit: false))
			{
				list3.Add(CreateMessageHeaderDescription(type2, memberInfo, new XmlName(memberInfo.Name), defaultNS, i, -1));
			}
			else if (memberInfo.IsDefined(typeof(MessagePropertyAttribute), inherit: false))
			{
				messageDescription.Properties.Add(CreateMessagePropertyDescription(memberInfo, new XmlName(memberInfo.Name), i));
			}
			else
			{
				list2.Add(CreateMessagePartDescription(type2, memberInfo, new XmlName(memberInfo.Name), defaultNS, i, -1));
			}
		}
		if (returnAttrProvider != null)
		{
			messageDescription.Body.ReturnValue = CreateMessagePartDescription(typeof(void), returnAttrProvider, returnValueName, defaultNS, 0, 0);
		}
		AddSortedParts(list2, messageDescription.Body.Parts);
		AddSortedParts(list3, messageDescription.Headers);
		_messages.Add(typedMessageType, messageDescription.Items);
		return messageDescription;
	}

	private static bool IsMethodOverriding(MethodInfo method)
	{
		if (method.IsVirtual)
		{
			return (method.Attributes & MethodAttributes.VtableLayoutMask) == 0;
		}
		return false;
	}

	private MessagePartDescription CreateMessagePartDescription(Type bodyType, ICustomAttributeProvider attrProvider, XmlName defaultName, string defaultNS, int parameterIndex, int serializationIndex)
	{
		MessagePartDescription messagePartDescription = null;
		MessageBodyMemberAttribute singleAttribute = ServiceReflector.GetSingleAttribute<MessageBodyMemberAttribute>(attrProvider, s_messageContractMemberAttributes);
		if (singleAttribute == null)
		{
			messagePartDescription = new MessagePartDescription(defaultName.EncodedName, defaultNS);
			messagePartDescription.SerializationPosition = serializationIndex;
		}
		else
		{
			XmlName xmlName = (singleAttribute.IsNameSetExplicit ? new XmlName(singleAttribute.Name) : defaultName);
			string ns = (singleAttribute.IsNamespaceSetExplicit ? singleAttribute.Namespace : defaultNS);
			messagePartDescription = new MessagePartDescription(xmlName.EncodedName, ns);
			messagePartDescription.SerializationPosition = ((singleAttribute.Order < 0) ? serializationIndex : singleAttribute.Order);
			if (singleAttribute.HasProtectionLevel)
			{
				messagePartDescription.ProtectionLevel = singleAttribute.ProtectionLevel;
			}
		}
		if (attrProvider is MemberInfo memberInfo)
		{
			messagePartDescription.MemberInfo = memberInfo;
		}
		messagePartDescription.Type = bodyType;
		messagePartDescription.Index = parameterIndex;
		return messagePartDescription;
	}

	private MessageHeaderDescription CreateMessageHeaderDescription(Type headerParameterType, ICustomAttributeProvider attrProvider, XmlName defaultName, string defaultNS, int parameterIndex, int serializationPosition)
	{
		MessageHeaderDescription messageHeaderDescription = null;
		MessageHeaderAttribute requiredSingleAttribute = ServiceReflector.GetRequiredSingleAttribute<MessageHeaderAttribute>(attrProvider, s_messageContractMemberAttributes);
		XmlName xmlName = (requiredSingleAttribute.IsNameSetExplicit ? new XmlName(requiredSingleAttribute.Name) : defaultName);
		string ns = (requiredSingleAttribute.IsNamespaceSetExplicit ? requiredSingleAttribute.Namespace : defaultNS);
		messageHeaderDescription = new MessageHeaderDescription(xmlName.EncodedName, ns);
		messageHeaderDescription.UniquePartName = defaultName.EncodedName;
		if (requiredSingleAttribute is MessageHeaderArrayAttribute)
		{
			if (!headerParameterType.IsArray || headerParameterType.GetArrayRank() != 1)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidMessageHeaderArrayType, defaultName)));
			}
			messageHeaderDescription.Multiple = true;
			headerParameterType = headerParameterType.GetElementType();
		}
		messageHeaderDescription.Type = TypedHeaderManager.GetHeaderType(headerParameterType);
		messageHeaderDescription.TypedHeader = headerParameterType != messageHeaderDescription.Type;
		if (messageHeaderDescription.TypedHeader)
		{
			if (requiredSingleAttribute.IsMustUnderstandSet || requiredSingleAttribute.IsRelaySet || requiredSingleAttribute.Actor != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxStaticMessageHeaderPropertiesNotAllowed, defaultName)));
			}
		}
		else
		{
			messageHeaderDescription.Actor = requiredSingleAttribute.Actor;
			messageHeaderDescription.MustUnderstand = requiredSingleAttribute.MustUnderstand;
			messageHeaderDescription.Relay = requiredSingleAttribute.Relay;
		}
		messageHeaderDescription.SerializationPosition = serializationPosition;
		if (requiredSingleAttribute.HasProtectionLevel)
		{
			messageHeaderDescription.ProtectionLevel = requiredSingleAttribute.ProtectionLevel;
		}
		if (attrProvider is MemberInfo memberInfo)
		{
			messageHeaderDescription.MemberInfo = memberInfo;
		}
		messageHeaderDescription.Index = parameterIndex;
		return messageHeaderDescription;
	}

	private MessagePropertyDescription CreateMessagePropertyDescription(ICustomAttributeProvider attrProvider, XmlName defaultName, int parameterIndex)
	{
		MessagePropertyAttribute singleAttribute = ServiceReflector.GetSingleAttribute<MessagePropertyAttribute>(attrProvider);
		XmlName xmlName = (singleAttribute.IsNameSetExplicit ? new XmlName(singleAttribute.Name) : defaultName);
		MessagePropertyDescription messagePropertyDescription = new MessagePropertyDescription(xmlName.EncodedName);
		messagePropertyDescription.Index = parameterIndex;
		if (attrProvider is MemberInfo memberInfo)
		{
			messagePropertyDescription.MemberInfo = memberInfo;
		}
		return messagePropertyDescription;
	}

	internal static XmlName GetReturnValueName(XmlName methodName)
	{
		return new XmlName(methodName.EncodedName + "Result", isEncoded: true);
	}

	internal static XmlName GetReturnValueName(string methodName)
	{
		return new XmlName(methodName + "Result");
	}

	internal static Type GetParameterType(ParameterInfo parameterInfo)
	{
		Type parameterType = parameterInfo.ParameterType;
		if (parameterType.IsByRef)
		{
			return parameterType.GetElementType();
		}
		return parameterType;
	}

	internal static XmlName GetWrapperName(string wrapperName, XmlName defaultName)
	{
		if (string.IsNullOrEmpty(wrapperName))
		{
			return defaultName;
		}
		return new XmlName(wrapperName);
	}

	private void AddSortedParts<T>(List<T> partDescriptionList, KeyedCollection<XmlQualifiedName, T> partDescriptionCollection) where T : MessagePartDescription
	{
		MessagePartDescription[] array = partDescriptionList.ToArray();
		MessagePartDescription[] array2 = array;
		if (array2.Length > 1)
		{
			Array.Sort(array2, CompareMessagePartDescriptions);
		}
		MessagePartDescription[] array3 = array2;
		for (int i = 0; i < array3.Length; i++)
		{
			T val = (T)array3[i];
			if (partDescriptionCollection.Contains(new XmlQualifiedName(val.Name, val.Namespace)))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidMessageContractException(System.SR.Format(System.SR.SFxDuplicateMessageParts, val.Name, val.Namespace)));
			}
			partDescriptionCollection.Add(val);
		}
	}

	public static void ApplyServiceInheritance<IBehavior, TBehaviorCollection>(Type serviceType, TBehaviorCollection descriptionBehaviors, ServiceInheritanceCallback<IBehavior, TBehaviorCollection> callback) where IBehavior : class where TBehaviorCollection : KeyedByTypeCollection<IBehavior>
	{
		Type type = serviceType;
		while (type != null)
		{
			AddBehaviorsAtOneScope(type, descriptionBehaviors, callback);
			type = type.BaseType();
		}
	}

	private static void AddBehaviorsAtOneScope<IBehavior, TBehaviorCollection>(Type type, TBehaviorCollection descriptionBehaviors, ServiceInheritanceCallback<IBehavior, TBehaviorCollection> callback) where IBehavior : class where TBehaviorCollection : KeyedByTypeCollection<IBehavior>
	{
		KeyedByTypeCollection<IBehavior> keyedByTypeCollection = new KeyedByTypeCollection<IBehavior>();
		callback(type, keyedByTypeCollection);
		for (int i = 0; i < keyedByTypeCollection.Count; i++)
		{
			IBehavior val = keyedByTypeCollection[i];
			if (!descriptionBehaviors.Contains(val.GetType()))
			{
				if (!(val is IOperationBehavior) && !(val is IContractBehavior))
				{
					throw ExceptionHelper.PlatformNotSupported();
				}
				descriptionBehaviors.Add(val);
			}
		}
	}
}

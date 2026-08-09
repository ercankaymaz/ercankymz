using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;

namespace System.ServiceModel.Description;

internal class DispatcherBuilder
{
	internal class ListenUriInfo
	{
		private ListenUriMode _listenUriMode;

		public Uri ListenUri { get; }

		public ListenUriMode ListenUriMode => _listenUriMode;

		public ListenUriInfo(Uri listenUri, ListenUriMode listenUriMode)
		{
			ListenUri = listenUri;
			_listenUriMode = listenUriMode;
		}

		public override bool Equals(object other)
		{
			return Equals(other as ListenUriInfo);
		}

		public bool Equals(ListenUriInfo other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (_listenUriMode == other._listenUriMode)
			{
				return EndpointAddress.UriEquals(ListenUri, other.ListenUri, ignoreCase: true, includeHostInComparison: true);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return EndpointAddress.UriGetHashCode(ListenUri, includeHostInComparison: true);
		}
	}

	internal class BindingInformationEndpointBehavior : IEndpointBehavior
	{
		private static BindingInformationEndpointBehavior s_instance;

		public static BindingInformationEndpointBehavior Instance
		{
			get
			{
				if (s_instance == null)
				{
					s_instance = new BindingInformationEndpointBehavior();
				}
				return s_instance;
			}
		}

		public void Validate(ServiceEndpoint serviceEndpoint)
		{
		}

		public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection parameters)
		{
		}

		public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime behavior)
		{
			behavior.ManualAddressing = IsManualAddressing(serviceEndpoint.Binding);
			behavior.EnableFaults = !IsMulticast(serviceEndpoint.Binding);
			if (serviceEndpoint.Contract.IsDuplex())
			{
				behavior.CallbackDispatchRuntime.ChannelDispatcher.MessageVersion = serviceEndpoint.Binding.MessageVersion;
			}
		}

		public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
		{
			if (serviceEndpoint.Binding is IBindingRuntimePreferences bindingRuntimePreferences)
			{
				endpointDispatcher.ChannelDispatcher.ReceiveSynchronously = bindingRuntimePreferences.ReceiveSynchronously;
			}
			endpointDispatcher.ChannelDispatcher.ManualAddressing = IsManualAddressing(serviceEndpoint.Binding);
			endpointDispatcher.ChannelDispatcher.EnableFaults = !IsMulticast(serviceEndpoint.Binding);
			endpointDispatcher.ChannelDispatcher.MessageVersion = serviceEndpoint.Binding.MessageVersion;
		}

		private bool IsManualAddressing(Binding binding)
		{
			TransportBindingElement transportBindingElement = binding.CreateBindingElements().Find<TransportBindingElement>();
			if (transportBindingElement == null)
			{
				string message = System.SR.Format(System.SR.SFxBindingMustContainTransport2, binding.Name, binding.Namespace);
				Exception exception = new InvalidOperationException(message);
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
			}
			return transportBindingElement.ManualAddressing;
		}

		private bool IsMulticast(Binding binding)
		{
			return binding.GetProperty<IBindingMulticastCapabilities>(new BindingParameterCollection())?.IsMulticast ?? false;
		}
	}

	internal class SecurityContractInformationEndpointBehavior : IEndpointBehavior
	{
		private bool _isForClient;

		private static SecurityContractInformationEndpointBehavior s_serverInstance;

		private static SecurityContractInformationEndpointBehavior s_clientInstance;

		public static SecurityContractInformationEndpointBehavior ServerInstance
		{
			get
			{
				if (s_serverInstance == null)
				{
					s_serverInstance = new SecurityContractInformationEndpointBehavior(isForClient: false);
				}
				return s_serverInstance;
			}
		}

		public static SecurityContractInformationEndpointBehavior ClientInstance
		{
			get
			{
				if (s_clientInstance == null)
				{
					s_clientInstance = new SecurityContractInformationEndpointBehavior(isForClient: true);
				}
				return s_clientInstance;
			}
		}

		private SecurityContractInformationEndpointBehavior(bool isForClient)
		{
			_isForClient = isForClient;
		}

		public void Validate(ServiceEndpoint serviceEndpoint)
		{
		}

		public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
		{
		}

		public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime behavior)
		{
		}

		public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection parameters)
		{
			ISecurityCapabilities securityCapabilities = null;
			BindingElementCollection bindingElementCollection = endpoint.Binding.CreateBindingElements();
			if (securityCapabilities != null)
			{
				ChannelProtectionRequirements channelProtectionRequirements = parameters.Find<ChannelProtectionRequirements>();
				if (channelProtectionRequirements == null)
				{
					channelProtectionRequirements = new ChannelProtectionRequirements();
					parameters.Add(channelProtectionRequirements);
				}
				MessageEncodingBindingElement messageEncodingBindingElement = bindingElementCollection.Find<MessageEncodingBindingElement>();
				if (messageEncodingBindingElement != null && messageEncodingBindingElement.MessageVersion.Addressing == AddressingVersion.None)
				{
					channelProtectionRequirements.Add(ChannelProtectionRequirements.CreateFromContractAndUnionResponseProtectionRequirements(endpoint.Contract, securityCapabilities, _isForClient));
				}
				else
				{
					channelProtectionRequirements.Add(ChannelProtectionRequirements.CreateFromContract(endpoint.Contract, securityCapabilities, _isForClient));
				}
			}
		}
	}

	internal static ClientRuntime BuildProxyBehavior(ServiceEndpoint serviceEndpoint, out BindingParameterCollection parameters)
	{
		parameters = new BindingParameterCollection();
		SecurityContractInformationEndpointBehavior.ClientInstance.AddBindingParameters(serviceEndpoint, parameters);
		AddBindingParameters(serviceEndpoint, parameters);
		ContractDescription contract = serviceEndpoint.Contract;
		ClientRuntime clientRuntime = new ClientRuntime(contract.Name, contract.Namespace);
		clientRuntime.ContractClientType = contract.ContractType;
		IdentityVerifier property = serviceEndpoint.Binding.GetProperty<IdentityVerifier>(parameters);
		if (property != null)
		{
			clientRuntime.IdentityVerifier = property;
		}
		for (int i = 0; i < contract.Operations.Count; i++)
		{
			OperationDescription operationDescription = contract.Operations[i];
			if (!operationDescription.IsServerInitiated())
			{
				BuildProxyOperation(operationDescription, clientRuntime);
			}
			else
			{
				BuildDispatchOperation(operationDescription, clientRuntime.CallbackDispatchRuntime);
			}
		}
		ApplyClientBehavior(serviceEndpoint, clientRuntime);
		return clientRuntime;
	}

	private static void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection parameters)
	{
		foreach (IContractBehavior behavior in endpoint.Contract.Behaviors)
		{
			behavior.AddBindingParameters(endpoint.Contract, endpoint, parameters);
		}
		foreach (IEndpointBehavior behavior2 in endpoint.Behaviors)
		{
			behavior2.AddBindingParameters(endpoint, parameters);
		}
		foreach (OperationDescription operation in endpoint.Contract.Operations)
		{
			foreach (IOperationBehavior behavior3 in operation.Behaviors)
			{
				behavior3.AddBindingParameters(operation, parameters);
			}
		}
	}

	private static void BuildProxyOperation(OperationDescription operation, ClientRuntime parent)
	{
		ClientOperation clientOperation = ((operation.Messages.Count != 1) ? new ClientOperation(parent, operation.Name, operation.Messages[0].Action, operation.Messages[1].Action) : new ClientOperation(parent, operation.Name, operation.Messages[0].Action));
		clientOperation.TaskMethod = operation.TaskMethod;
		clientOperation.TaskTResult = operation.TaskTResult;
		clientOperation.SyncMethod = operation.SyncMethod;
		clientOperation.BeginMethod = operation.BeginMethod;
		clientOperation.EndMethod = operation.EndMethod;
		clientOperation.IsOneWay = operation.IsOneWay;
		clientOperation.IsInitiating = operation.IsInitiating;
		clientOperation.IsTerminating = operation.IsTerminating;
		clientOperation.IsSessionOpenNotificationEnabled = operation.IsSessionOpenNotificationEnabled;
		for (int i = 0; i < operation.Faults.Count; i++)
		{
			FaultDescription faultDescription = operation.Faults[i];
			clientOperation.FaultContractInfos.Add(new FaultContractInfo(faultDescription.Action, faultDescription.DetailType, faultDescription.ElementName, faultDescription.Namespace, operation.KnownTypes));
		}
		parent.Operations.Add(clientOperation);
	}

	private static void BuildDispatchOperation(OperationDescription operation, DispatchRuntime parent)
	{
		string action = operation.Messages[0].Action;
		DispatchOperation dispatchOperation = null;
		if (operation.IsOneWay)
		{
			dispatchOperation = new DispatchOperation(parent, operation.Name, action);
		}
		else
		{
			string action2 = operation.Messages[1].Action;
			dispatchOperation = new DispatchOperation(parent, operation.Name, action, action2);
		}
		dispatchOperation.HasNoDisposableParameters = operation.HasNoDisposableParameters;
		dispatchOperation.IsTerminating = operation.IsTerminating;
		dispatchOperation.IsSessionOpenNotificationEnabled = operation.IsSessionOpenNotificationEnabled;
		for (int i = 0; i < operation.Faults.Count; i++)
		{
			FaultDescription faultDescription = operation.Faults[i];
			dispatchOperation.FaultContractInfos.Add(new FaultContractInfo(faultDescription.Action, faultDescription.DetailType, faultDescription.ElementName, faultDescription.Namespace, operation.KnownTypes));
		}
		if (action != "*")
		{
			parent.Operations.Add(dispatchOperation);
			return;
		}
		if (parent.HasMatchAllOperation)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxMultipleContractStarOperations0));
		}
		parent.UnhandledDispatchOperation = dispatchOperation;
	}

	private static void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime clientRuntime)
	{
		ContractDescription contract = serviceEndpoint.Contract;
		for (int i = 0; i < contract.Behaviors.Count; i++)
		{
			IContractBehavior contractBehavior = contract.Behaviors[i];
			contractBehavior.ApplyClientBehavior(contract, serviceEndpoint, clientRuntime);
		}
		BindingInformationEndpointBehavior.Instance.ApplyClientBehavior(serviceEndpoint, clientRuntime);
		for (int j = 0; j < serviceEndpoint.Behaviors.Count; j++)
		{
			IEndpointBehavior endpointBehavior = serviceEndpoint.Behaviors[j];
			endpointBehavior.ApplyClientBehavior(serviceEndpoint, clientRuntime);
		}
		BindOperations(contract, clientRuntime, null);
	}

	private static void BindOperations(ContractDescription contract, ClientRuntime proxy, DispatchRuntime dispatch)
	{
		if (proxy == null == (dispatch == null))
		{
			throw Fx.AssertAndThrowFatal("DispatcherBuilder.BindOperations: ((proxy == null) != (dispatch == null))");
		}
		MessageDirection messageDirection = ((proxy != null) ? MessageDirection.Output : MessageDirection.Input);
		for (int i = 0; i < contract.Operations.Count; i++)
		{
			OperationDescription operationDescription = contract.Operations[i];
			MessageDescription messageDescription = operationDescription.Messages[0];
			if (messageDescription.Direction != messageDirection)
			{
				if (proxy == null)
				{
					proxy = dispatch.CallbackClientRuntime;
				}
				ClientOperation clientOperation = proxy.Operations[operationDescription.Name];
				for (int j = 0; j < operationDescription.Behaviors.Count; j++)
				{
					IOperationBehavior operationBehavior = operationDescription.Behaviors[j];
					operationBehavior.ApplyClientBehavior(operationDescription, clientOperation);
				}
				continue;
			}
			if (dispatch == null)
			{
				dispatch = proxy.CallbackDispatchRuntime;
			}
			DispatchOperation dispatchOperation = null;
			if (dispatch.Operations.Contains(operationDescription.Name))
			{
				dispatchOperation = dispatch.Operations[operationDescription.Name];
			}
			if (dispatchOperation == null && dispatch.UnhandledDispatchOperation != null && dispatch.UnhandledDispatchOperation.Name == operationDescription.Name)
			{
				dispatchOperation = dispatch.UnhandledDispatchOperation;
			}
			if (dispatchOperation != null)
			{
				for (int k = 0; k < operationDescription.Behaviors.Count; k++)
				{
					IOperationBehavior operationBehavior2 = operationDescription.Behaviors[k];
					operationBehavior2.ApplyDispatchBehavior(operationDescription, dispatchOperation);
				}
			}
		}
	}
}

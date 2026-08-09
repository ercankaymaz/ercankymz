using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace System.ServiceModel.Dispatcher;

internal class OperationSelectorBehavior : IContractBehavior
{
	internal class MethodInfoOperationSelector : IClientOperationSelector
	{
		private Dictionary<IntPtr, string> _operationMap;

		public bool AreParametersRequiredForSelection => false;

		internal MethodInfoOperationSelector(ContractDescription description, MessageDirection directionThatRequiresClientOpSelection)
		{
			_operationMap = new Dictionary<IntPtr, string>();
			for (int i = 0; i < description.Operations.Count; i++)
			{
				OperationDescription operationDescription = description.Operations[i];
				if (operationDescription.Messages[0].Direction == directionThatRequiresClientOpSelection)
				{
					if (operationDescription.SyncMethod != null && !_operationMap.ContainsKey(operationDescription.SyncMethod.MethodHandle.Value))
					{
						_operationMap.Add(operationDescription.SyncMethod.MethodHandle.Value, operationDescription.Name);
					}
					if (operationDescription.BeginMethod != null && !_operationMap.ContainsKey(operationDescription.BeginMethod.MethodHandle.Value))
					{
						_operationMap.Add(operationDescription.BeginMethod.MethodHandle.Value, operationDescription.Name);
						_operationMap.Add(operationDescription.EndMethod.MethodHandle.Value, operationDescription.Name);
					}
					if (operationDescription.TaskMethod != null && !_operationMap.ContainsKey(operationDescription.TaskMethod.MethodHandle.Value))
					{
						_operationMap.Add(operationDescription.TaskMethod.MethodHandle.Value, operationDescription.Name);
					}
				}
			}
		}

		public string SelectOperation(MethodBase method, object[] parameters)
		{
			if (_operationMap.ContainsKey(method.MethodHandle.Value))
			{
				return _operationMap[method.MethodHandle.Value];
			}
			return null;
		}
	}

	void IContractBehavior.Validate(ContractDescription description, ServiceEndpoint endpoint)
	{
	}

	void IContractBehavior.AddBindingParameters(ContractDescription description, ServiceEndpoint endpoint, BindingParameterCollection parameters)
	{
	}

	void IContractBehavior.ApplyDispatchBehavior(ContractDescription description, ServiceEndpoint endpoint, DispatchRuntime dispatch)
	{
		if (dispatch.ClientRuntime != null)
		{
			dispatch.ClientRuntime.OperationSelector = new MethodInfoOperationSelector(description, MessageDirection.Output);
		}
	}

	void IContractBehavior.ApplyClientBehavior(ContractDescription description, ServiceEndpoint endpoint, ClientRuntime proxy)
	{
		proxy.OperationSelector = new MethodInfoOperationSelector(description, MessageDirection.Input);
	}
}

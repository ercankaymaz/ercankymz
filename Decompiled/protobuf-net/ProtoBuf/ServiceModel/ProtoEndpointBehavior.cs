using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace ProtoBuf.ServiceModel;

public class ProtoEndpointBehavior : IEndpointBehavior
{
	void IEndpointBehavior.AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
	{
	}

	void IEndpointBehavior.ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
	{
		ReplaceDataContractSerializerOperationBehavior(endpoint);
	}

	void IEndpointBehavior.ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
	{
		ReplaceDataContractSerializerOperationBehavior(endpoint);
	}

	void IEndpointBehavior.Validate(ServiceEndpoint endpoint)
	{
	}

	private static void ReplaceDataContractSerializerOperationBehavior(ServiceEndpoint serviceEndpoint)
	{
		foreach (OperationDescription item in (Collection<OperationDescription>)(object)serviceEndpoint.Contract.Operations)
		{
			ReplaceDataContractSerializerOperationBehavior(item);
		}
	}

	private static void ReplaceDataContractSerializerOperationBehavior(OperationDescription description)
	{
		DataContractSerializerOperationBehavior val = description.Behaviors.Find<DataContractSerializerOperationBehavior>();
		if (val != null)
		{
			((Collection<IOperationBehavior>)(object)description.Behaviors).Remove((IOperationBehavior)(object)val);
			ProtoOperationBehavior protoOperationBehavior = new ProtoOperationBehavior(description);
			((DataContractSerializerOperationBehavior)protoOperationBehavior).MaxItemsInObjectGraph = val.MaxItemsInObjectGraph;
			((Collection<IOperationBehavior>)(object)description.Behaviors).Add((IOperationBehavior)(object)protoOperationBehavior);
		}
	}
}

using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace System.ServiceModel.Description;

public interface IEndpointBehavior
{
	void Validate(ServiceEndpoint endpoint);

	void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters);

	void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher);

	void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime);
}

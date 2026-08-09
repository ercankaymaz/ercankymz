using System.ServiceModel.Description;

namespace System.ServiceModel;

internal sealed class ServiceEndpointTrait<TChannel> : EndpointTrait<TChannel> where TChannel : class
{
	private InstanceContext _callbackInstance;

	private ServiceEndpoint _serviceEndpoint;

	public ServiceEndpointTrait(ServiceEndpoint endpoint, InstanceContext callbackInstance)
	{
		_serviceEndpoint = endpoint;
		_callbackInstance = callbackInstance;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ServiceEndpointTrait<TChannel> serviceEndpointTrait))
		{
			return false;
		}
		if (_callbackInstance != serviceEndpointTrait._callbackInstance)
		{
			return false;
		}
		if (_serviceEndpoint != serviceEndpointTrait._serviceEndpoint)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		int num = 0;
		if (_callbackInstance != null)
		{
			num ^= _callbackInstance.GetHashCode();
		}
		return num ^ _serviceEndpoint.GetHashCode();
	}

	public override ChannelFactory<TChannel> CreateChannelFactory()
	{
		if (_callbackInstance != null)
		{
			return CreateDuplexFactory();
		}
		return CreateSimplexFactory();
	}

	private DuplexChannelFactory<TChannel> CreateDuplexFactory()
	{
		return new DuplexChannelFactory<TChannel>(_callbackInstance, _serviceEndpoint);
	}

	private ChannelFactory<TChannel> CreateSimplexFactory()
	{
		return new ChannelFactory<TChannel>(_serviceEndpoint);
	}
}

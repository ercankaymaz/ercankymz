using System.ServiceModel.Channels;

namespace System.ServiceModel;

internal sealed class ProgrammaticEndpointTrait<TChannel> : EndpointTrait<TChannel> where TChannel : class
{
	private EndpointAddress _remoteAddress;

	private Binding _binding;

	private InstanceContext _callbackInstance;

	public ProgrammaticEndpointTrait(Binding binding, EndpointAddress remoteAddress, InstanceContext callbackInstance)
	{
		_binding = binding;
		_remoteAddress = remoteAddress;
		_callbackInstance = callbackInstance;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ProgrammaticEndpointTrait<TChannel> programmaticEndpointTrait))
		{
			return false;
		}
		if (_callbackInstance != programmaticEndpointTrait._callbackInstance)
		{
			return false;
		}
		if (_remoteAddress != programmaticEndpointTrait._remoteAddress)
		{
			return false;
		}
		if (_binding != programmaticEndpointTrait._binding)
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
		num ^= _remoteAddress.GetHashCode();
		return num ^ _binding.GetHashCode();
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
		return new DuplexChannelFactory<TChannel>(_callbackInstance, _binding, _remoteAddress);
	}

	private ChannelFactory<TChannel> CreateSimplexFactory()
	{
		return new ChannelFactory<TChannel>(_binding, _remoteAddress);
	}
}

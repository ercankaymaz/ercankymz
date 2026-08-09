namespace System.ServiceModel;

internal abstract class EndpointTrait<TChannel> where TChannel : class
{
	public abstract ChannelFactory<TChannel> CreateChannelFactory();
}

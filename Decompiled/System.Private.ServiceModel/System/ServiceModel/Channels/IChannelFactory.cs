namespace System.ServiceModel.Channels;

public interface IChannelFactory : ICommunicationObject
{
	T GetProperty<T>() where T : class;
}
public interface IChannelFactory<TChannel> : IChannelFactory, ICommunicationObject
{
	TChannel CreateChannel(EndpointAddress to);

	TChannel CreateChannel(EndpointAddress to, Uri via);
}

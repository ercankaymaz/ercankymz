namespace System.ServiceModel.Dispatcher;

internal class ListenerChannel
{
	public IChannelBinder Binder { get; }

	public ListenerChannel(IChannelBinder binder)
	{
		Binder = binder;
	}
}

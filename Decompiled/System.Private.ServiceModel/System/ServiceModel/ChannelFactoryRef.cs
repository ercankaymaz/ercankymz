namespace System.ServiceModel;

internal sealed class ChannelFactoryRef<TChannel> where TChannel : class
{
	private ChannelFactory<TChannel> _channelFactory;

	private int _refCount = 1;

	public ChannelFactory<TChannel> ChannelFactory => _channelFactory;

	public ChannelFactoryRef(ChannelFactory<TChannel> channelFactory)
	{
		_channelFactory = channelFactory;
	}

	public void AddRef()
	{
		_refCount++;
	}

	public bool Release()
	{
		_refCount--;
		if (_refCount == 0)
		{
			return true;
		}
		return false;
	}

	public void Close(TimeSpan timeout)
	{
		_channelFactory.Close(timeout);
	}

	public void Abort()
	{
		_channelFactory.Abort();
	}
}

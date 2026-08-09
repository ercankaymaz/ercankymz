namespace System.ServiceModel.Channels;

public abstract class ConnectionPool : IdlingCommunicationPool<string, IConnection>
{
	private int _connectionBufferSize;

	private TimeSpan _maxOutputDelay;

	public string Name { get; }

	protected ConnectionPool(IConnectionOrientedTransportChannelFactorySettings settings, TimeSpan leaseTimeout)
		: base(settings.MaxOutboundConnectionsPerEndpoint, settings.IdleTimeout, leaseTimeout)
	{
		_connectionBufferSize = settings.ConnectionBufferSize;
		_maxOutputDelay = settings.MaxOutputDelay;
		Name = settings.ConnectionPoolGroupName;
	}

	protected override void AbortItem(IConnection item)
	{
		item.Abort();
	}

	protected override void CloseItem(IConnection item, TimeSpan timeout)
	{
		item.Close(timeout, asyncAndLinger: false);
	}

	protected override void CloseItemAsync(IConnection item, TimeSpan timeout)
	{
		item.Close(timeout, asyncAndLinger: true);
	}

	public virtual bool IsCompatible(IConnectionOrientedTransportChannelFactorySettings settings)
	{
		if (Name == settings.ConnectionPoolGroupName && _connectionBufferSize == settings.ConnectionBufferSize && base.MaxIdleConnectionPoolCount == settings.MaxOutboundConnectionsPerEndpoint && base.IdleTimeout == settings.IdleTimeout)
		{
			return _maxOutputDelay == settings.MaxOutputDelay;
		}
		return false;
	}
}

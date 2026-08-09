namespace System.ServiceModel.Channels;

public abstract class StreamUpgradeProvider : CommunicationObject, IAsyncCommunicationObject, ICommunicationObject
{
	private TimeSpan _closeTimeout;

	private TimeSpan _openTimeout;

	protected override TimeSpan DefaultCloseTimeout => _closeTimeout;

	protected override TimeSpan DefaultOpenTimeout => _closeTimeout;

	protected StreamUpgradeProvider()
		: this(null)
	{
	}

	protected StreamUpgradeProvider(IDefaultCommunicationTimeouts timeouts)
	{
		if (timeouts != null)
		{
			_closeTimeout = timeouts.CloseTimeout;
			_openTimeout = timeouts.OpenTimeout;
		}
		else
		{
			_closeTimeout = ServiceDefaults.CloseTimeout;
			_openTimeout = ServiceDefaults.OpenTimeout;
		}
	}

	public virtual T GetProperty<T>() where T : class
	{
		return null;
	}

	public abstract StreamUpgradeInitiator CreateUpgradeInitiator(EndpointAddress remoteAddress, Uri via);
}

namespace System.ServiceModel.Channels;

public abstract class StreamSecurityUpgradeProvider : StreamUpgradeProvider
{
	public abstract EndpointIdentity Identity { get; }

	protected StreamSecurityUpgradeProvider()
	{
	}

	protected StreamSecurityUpgradeProvider(IDefaultCommunicationTimeouts timeouts)
		: base(timeouts)
	{
	}
}

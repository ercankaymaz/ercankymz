namespace System.ServiceModel.Security;

internal class TransportSecurityProtocolFactory : SecurityProtocolFactory
{
	public override bool SupportsDuplex => true;

	public override bool SupportsReplayDetection => false;

	public TransportSecurityProtocolFactory()
	{
	}

	internal TransportSecurityProtocolFactory(TransportSecurityProtocolFactory factory)
		: base(factory)
	{
	}

	protected override SecurityProtocol OnCreateSecurityProtocol(EndpointAddress target, Uri via, object listenerSecurityState, TimeSpan timeout)
	{
		return new TransportSecurityProtocol(this, target, via);
	}
}

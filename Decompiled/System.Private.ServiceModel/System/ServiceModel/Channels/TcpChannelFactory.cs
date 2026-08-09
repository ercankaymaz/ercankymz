namespace System.ServiceModel.Channels;

internal class TcpChannelFactory<TChannel> : ConnectionOrientedTransportChannelFactory<TChannel>, ITcpChannelFactorySettings, IConnectionOrientedTransportChannelFactorySettings, IConnectionOrientedTransportFactorySettings, ITransportFactorySettings, IDefaultCommunicationTimeouts, IConnectionOrientedConnectionSettings
{
	private static TcpConnectionPoolRegistry s_connectionPoolRegistry = new TcpConnectionPoolRegistry();

	public TimeSpan LeaseTimeout { get; }

	public override string Scheme => "net.tcp";

	public TcpChannelFactory(TcpTransportBindingElement bindingElement, BindingContext context)
		: base((ConnectionOrientedTransportBindingElement)bindingElement, context, bindingElement.ConnectionPoolSettings.GroupName, bindingElement.ConnectionPoolSettings.IdleTimeout, bindingElement.ConnectionPoolSettings.MaxOutboundConnectionsPerEndpoint, true)
	{
		LeaseTimeout = bindingElement.ConnectionPoolSettings.LeaseTimeout;
	}

	internal override IConnectionInitiator GetConnectionInitiator()
	{
		IConnectionInitiator connectionInitiator = new SocketConnectionInitiator(base.ConnectionBufferSize);
		return new BufferedConnectionInitiator(connectionInitiator, base.MaxOutputDelay, base.ConnectionBufferSize);
	}

	internal override ConnectionPool GetConnectionPool()
	{
		return s_connectionPoolRegistry.Lookup(this);
	}

	internal override void ReleaseConnectionPool(ConnectionPool pool, TimeSpan timeout)
	{
		s_connectionPoolRegistry.Release(pool, timeout);
	}
}

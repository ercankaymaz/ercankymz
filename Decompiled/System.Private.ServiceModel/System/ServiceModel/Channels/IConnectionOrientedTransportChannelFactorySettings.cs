namespace System.ServiceModel.Channels;

public interface IConnectionOrientedTransportChannelFactorySettings : IConnectionOrientedTransportFactorySettings, ITransportFactorySettings, IDefaultCommunicationTimeouts, IConnectionOrientedConnectionSettings
{
	string ConnectionPoolGroupName { get; }

	int MaxOutboundConnectionsPerEndpoint { get; }
}

namespace System.ServiceModel.Channels;

public interface ITcpChannelFactorySettings : IConnectionOrientedTransportChannelFactorySettings, IConnectionOrientedTransportFactorySettings, ITransportFactorySettings, IDefaultCommunicationTimeouts, IConnectionOrientedConnectionSettings
{
	TimeSpan LeaseTimeout { get; }
}

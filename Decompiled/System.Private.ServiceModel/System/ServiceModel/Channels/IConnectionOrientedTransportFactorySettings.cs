namespace System.ServiceModel.Channels;

public interface IConnectionOrientedTransportFactorySettings : ITransportFactorySettings, IDefaultCommunicationTimeouts, IConnectionOrientedConnectionSettings
{
	int MaxBufferSize { get; }

	StreamUpgradeProvider Upgrade { get; }

	TransferMode TransferMode { get; }
}

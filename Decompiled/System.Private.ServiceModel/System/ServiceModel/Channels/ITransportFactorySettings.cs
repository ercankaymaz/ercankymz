namespace System.ServiceModel.Channels;

public interface ITransportFactorySettings : IDefaultCommunicationTimeouts
{
	bool ManualAddressing { get; }

	BufferManager BufferManager { get; }

	long MaxReceivedMessageSize { get; }

	MessageEncoderFactory MessageEncoderFactory { get; }

	MessageVersion MessageVersion { get; }
}

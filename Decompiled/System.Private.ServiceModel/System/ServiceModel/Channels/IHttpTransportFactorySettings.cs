namespace System.ServiceModel.Channels;

internal interface IHttpTransportFactorySettings : ITransportFactorySettings, IDefaultCommunicationTimeouts
{
	int MaxBufferSize { get; }

	TransferMode TransferMode { get; }
}

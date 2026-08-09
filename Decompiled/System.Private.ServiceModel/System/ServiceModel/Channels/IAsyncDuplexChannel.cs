namespace System.ServiceModel.Channels;

internal interface IAsyncDuplexChannel : IDuplexChannel, IInputChannel, IChannel, ICommunicationObject, IOutputChannel, IAsyncInputChannel, IAsyncCommunicationObject, IAsyncOutputChannel
{
}

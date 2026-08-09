namespace System.ServiceModel.Channels;

internal interface IAsyncDuplexSessionChannel : IDuplexSessionChannel, IDuplexChannel, IInputChannel, IChannel, ICommunicationObject, IOutputChannel, ISessionChannel<IDuplexSession>, IAsyncDuplexChannel, IAsyncInputChannel, IAsyncCommunicationObject, IAsyncOutputChannel, ISessionChannel<IAsyncDuplexSession>
{
}

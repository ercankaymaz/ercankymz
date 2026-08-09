namespace System.ServiceModel.Channels;

public interface IAsyncOutputSessionChannel : IOutputSessionChannel, IOutputChannel, IChannel, ICommunicationObject, ISessionChannel<IOutputSession>, IAsyncOutputChannel, IAsyncCommunicationObject
{
}

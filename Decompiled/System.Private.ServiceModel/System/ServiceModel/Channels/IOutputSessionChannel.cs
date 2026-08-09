namespace System.ServiceModel.Channels;

public interface IOutputSessionChannel : IOutputChannel, IChannel, ICommunicationObject, ISessionChannel<IOutputSession>
{
}

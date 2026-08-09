namespace System.ServiceModel.Channels;

public interface IRequestSessionChannel : IRequestChannel, IChannel, ICommunicationObject, ISessionChannel<IOutputSession>
{
}

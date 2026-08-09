namespace System.ServiceModel.Channels;

public interface IReplySessionChannel : IReplyChannel, IChannel, ICommunicationObject, ISessionChannel<IInputSession>
{
}

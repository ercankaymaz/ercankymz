namespace System.ServiceModel.Channels;

public interface IInputSessionChannel : IInputChannel, IChannel, ICommunicationObject, ISessionChannel<IInputSession>
{
}

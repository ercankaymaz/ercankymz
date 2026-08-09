namespace System.ServiceModel.Channels;

public interface IDuplexSessionChannel : IDuplexChannel, IInputChannel, IChannel, ICommunicationObject, IOutputChannel, ISessionChannel<IDuplexSession>
{
}

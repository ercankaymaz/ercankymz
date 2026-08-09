namespace System.ServiceModel.Channels;

public interface IOutputChannel : IChannel, ICommunicationObject
{
	EndpointAddress RemoteAddress { get; }

	Uri Via { get; }

	void Send(Message message);

	void Send(Message message, TimeSpan timeout);

	IAsyncResult BeginSend(Message message, AsyncCallback callback, object state);

	IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state);

	void EndSend(IAsyncResult result);
}

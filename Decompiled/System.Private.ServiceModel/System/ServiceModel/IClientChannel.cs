using System.ServiceModel.Channels;

namespace System.ServiceModel;

public interface IClientChannel : IContextChannel, IChannel, ICommunicationObject, IExtensibleObject<IContextChannel>, IDisposable
{
	bool AllowInitializationUI { get; set; }

	bool DidInteractiveInitialization { get; }

	Uri Via { get; }

	event EventHandler<UnknownMessageReceivedEventArgs> UnknownMessageReceived;

	void DisplayInitializationUI();

	IAsyncResult BeginDisplayInitializationUI(AsyncCallback callback, object state);

	void EndDisplayInitializationUI(IAsyncResult result);
}

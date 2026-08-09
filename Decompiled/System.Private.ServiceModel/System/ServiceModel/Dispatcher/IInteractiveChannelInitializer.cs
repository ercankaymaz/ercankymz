namespace System.ServiceModel.Dispatcher;

public interface IInteractiveChannelInitializer
{
	IAsyncResult BeginDisplayInitializationUI(IClientChannel channel, AsyncCallback callback, object state);

	void EndDisplayInitializationUI(IAsyncResult result);
}

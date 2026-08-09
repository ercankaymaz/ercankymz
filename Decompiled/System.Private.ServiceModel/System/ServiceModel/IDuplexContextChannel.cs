using System.ServiceModel.Channels;

namespace System.ServiceModel;

public interface IDuplexContextChannel : IContextChannel, IChannel, ICommunicationObject, IExtensibleObject<IContextChannel>
{
	bool AutomaticInputSessionShutdown { get; set; }

	InstanceContext CallbackInstance { get; set; }

	IAsyncResult BeginCloseOutputSession(TimeSpan timeout, AsyncCallback callback, object state);

	void EndCloseOutputSession(IAsyncResult result);

	void CloseOutputSession(TimeSpan timeout);
}

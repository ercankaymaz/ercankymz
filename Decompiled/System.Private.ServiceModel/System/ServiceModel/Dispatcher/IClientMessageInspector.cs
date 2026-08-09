using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

public interface IClientMessageInspector
{
	object BeforeSendRequest(ref Message request, IClientChannel channel);

	void AfterReceiveReply(ref Message reply, object correlationState);
}

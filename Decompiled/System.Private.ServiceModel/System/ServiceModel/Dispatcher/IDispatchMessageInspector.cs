using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

public interface IDispatchMessageInspector
{
	object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext);

	void BeforeSendReply(ref Message reply, object correlationState);
}

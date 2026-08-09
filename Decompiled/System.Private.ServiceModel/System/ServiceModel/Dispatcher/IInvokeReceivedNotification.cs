using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

internal interface IInvokeReceivedNotification
{
	void NotifyInvokeReceived();

	void NotifyInvokeReceived(RequestContext request);
}

using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel.Dispatcher;

internal class MessageRpcInvokeNotification : IInvokeReceivedNotification
{
	private ServiceModelActivity _activity;

	private ChannelHandler _handler;

	public bool DidInvokerEnsurePump { get; set; }

	public MessageRpcInvokeNotification(ServiceModelActivity activity, ChannelHandler handler)
	{
		_activity = activity;
		_handler = handler;
	}

	public void NotifyInvokeReceived()
	{
		using (ServiceModelActivity.BoundOperation(_activity))
		{
			ChannelHandler.Register(_handler);
		}
		DidInvokerEnsurePump = true;
	}

	public void NotifyInvokeReceived(RequestContext request)
	{
		using (ServiceModelActivity.BoundOperation(_activity))
		{
			ChannelHandler.Register(_handler, request);
		}
		DidInvokerEnsurePump = true;
	}
}

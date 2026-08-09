using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal sealed class RequestReliableRequestor : ReliableRequestor
{
	private bool replied;

	private WsrmMessageInfo replyInfo;

	private object thisLock = new object();

	private IClientReliableChannelBinder ClientBinder => (IClientReliableChannelBinder)base.Binder;

	private object ThisLock => thisLock;

	public override WsrmMessageInfo GetInfo()
	{
		return replyInfo;
	}

	private Message GetReply(Message reply, bool last)
	{
		lock (ThisLock)
		{
			if (reply != null && replyInfo != null)
			{
				replyInfo = null;
			}
			else if (reply == null && replyInfo != null)
			{
				reply = replyInfo.Message;
			}
			if (reply != null || last)
			{
				replied = true;
			}
		}
		return reply;
	}

	protected override async Task<Message> OnRequestAsync(Message request, TimeSpan timeout, bool last)
	{
		return GetReply(await ClientBinder.RequestAsync(request, timeout, MaskingMode.None), last);
	}

	public override void SetInfo(WsrmMessageInfo info)
	{
		lock (ThisLock)
		{
			if (!replied && replyInfo == null)
			{
				replyInfo = info;
			}
		}
	}
}

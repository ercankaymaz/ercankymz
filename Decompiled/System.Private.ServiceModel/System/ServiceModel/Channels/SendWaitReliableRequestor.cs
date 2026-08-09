using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal sealed class SendWaitReliableRequestor : ReliableRequestor
{
	private bool replied;

	private InterruptibleWaitObject replyHandle = new InterruptibleWaitObject(signaled: false, throwTimeoutByDefault: true);

	private WsrmMessageInfo replyInfo;

	private object thisLock = new object();

	private object ThisLock => thisLock;

	public override void Fault(CommunicationObject communicationObject)
	{
		replied = true;
		replyHandle.Fault(communicationObject);
		base.Fault(communicationObject);
	}

	public override WsrmMessageInfo GetInfo()
	{
		return replyInfo;
	}

	private Message GetReply(bool last)
	{
		lock (ThisLock)
		{
			if (replyInfo != null)
			{
				replied = true;
				return replyInfo.Message;
			}
			if (last)
			{
				replied = true;
			}
		}
		return null;
	}

	private TimeSpan GetWaitTimeout(TimeSpan timeoutRemaining)
	{
		if (timeoutRemaining < ReliableMessagingConstants.RequestorReceiveTime)
		{
			return timeoutRemaining;
		}
		return ReliableMessagingConstants.RequestorReceiveTime;
	}

	protected override async Task<Message> OnRequestAsync(Message request, TimeSpan timeout, bool last)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await base.Binder.SendAsync(request, timeoutHelper.RemainingTime(), MaskingMode.None);
		TimeSpan waitTimeout = GetWaitTimeout(timeoutHelper.RemainingTime());
		await replyHandle.WaitAsync(waitTimeout);
		return GetReply(last);
	}

	public override void SetInfo(WsrmMessageInfo info)
	{
		lock (ThisLock)
		{
			if (replied || replyInfo != null)
			{
				return;
			}
			replyInfo = info;
		}
		replyHandle.Set();
	}
}

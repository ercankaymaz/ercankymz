using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal sealed class SendReceiveReliableRequestor : ReliableRequestor
{
	private bool timeoutIsSafe;

	public bool TimeoutIsSafe
	{
		set
		{
			timeoutIsSafe = value;
		}
	}

	public override WsrmMessageInfo GetInfo()
	{
		throw Fx.AssertAndThrow("Not Supported.");
	}

	private TimeSpan GetReceiveTimeout(TimeSpan timeoutRemaining)
	{
		if (timeoutRemaining < ReliableMessagingConstants.RequestorReceiveTime || !timeoutIsSafe)
		{
			return timeoutRemaining;
		}
		return ReliableMessagingConstants.RequestorReceiveTime;
	}

	protected override async Task<Message> OnRequestAsync(Message request, TimeSpan timeout, bool last)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await base.Binder.SendAsync(request, timeoutHelper.RemainingTime(), MaskingMode.None);
		TimeSpan receiveTimeout = GetReceiveTimeout(timeoutHelper.RemainingTime());
		return (await base.Binder.TryReceiveAsync(receiveTimeout, MaskingMode.None)).Item2?.RequestMessage;
	}

	public override void SetInfo(WsrmMessageInfo info)
	{
		throw Fx.AssertAndThrow("Not Supported.");
	}
}

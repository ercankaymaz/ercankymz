using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class SendFaultHelper : TypedFaultHelper<Message>
{
	public SendFaultHelper(TimeSpan defaultSendTimeout, TimeSpan defaultCloseTimeout)
		: base(defaultSendTimeout, defaultCloseTimeout)
	{
	}

	protected override void AbortState(Message message, bool isOnAbortThread)
	{
		if (!isOnAbortThread)
		{
			message.Close();
		}
	}

	protected override async Task SendFaultAsync(IReliableChannelBinder binder, Message message, TimeSpan timeout)
	{
		await binder.SendAsync(message, timeout);
		message.Close();
	}

	protected override Message GetState(RequestContext requestContext, Message faultMessage)
	{
		return faultMessage;
	}
}

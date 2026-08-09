using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class ReplyFaultHelper : TypedFaultHelper<FaultState>
{
	public ReplyFaultHelper(TimeSpan defaultSendTimeout, TimeSpan defaultCloseTimeout)
		: base(defaultSendTimeout, defaultCloseTimeout)
	{
	}

	protected override void AbortState(FaultState faultState, bool isOnAbortThread)
	{
		if (!isOnAbortThread)
		{
			faultState.FaultMessage.Close();
		}
		faultState.RequestContext.Abort();
	}

	protected override async Task SendFaultAsync(IReliableChannelBinder binder, FaultState faultState, TimeSpan timeout)
	{
		RequestContext requestContext = faultState.RequestContext;
		await Task.Factory.FromAsync(requestContext.BeginReply, requestContext.EndReply, faultState.FaultMessage, timeout, null);
		faultState.FaultMessage.Close();
	}

	protected override FaultState GetState(RequestContext requestContext, Message faultMessage)
	{
		return new FaultState(requestContext, faultMessage);
	}
}

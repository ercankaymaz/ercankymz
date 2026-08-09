using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal sealed class ReliableOutputSessionChannelOverRequest : ReliableOutputSessionChannel
{
	private IClientReliableChannelBinder binder;

	protected override bool RequestAcks => false;

	public ReliableOutputSessionChannelOverRequest(ChannelManagerBase factory, IReliableFactorySettings settings, IClientReliableChannelBinder binder, FaultHelper faultHelper, LateBoundChannelParameterCollection channelParameters)
		: base(factory, settings, binder, faultHelper, channelParameters)
	{
		this.binder = binder;
	}

	protected override ReliableRequestor CreateRequestor()
	{
		return new RequestReliableRequestor();
	}

	protected override async Task OnConnectionSendAsync(Message message, TimeSpan timeout, bool saveHandledException, bool maskUnhandledException)
	{
		MaskingMode maskingMode = (maskUnhandledException ? MaskingMode.Unhandled : MaskingMode.None);
		if (saveHandledException)
		{
			try
			{
				await binder.RequestAsync(message, timeout, maskingMode);
				return;
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (base.Binder.IsHandleable(ex))
				{
					base.MaxRetryCountException = ex;
					return;
				}
				throw;
			}
		}
		maskingMode |= MaskingMode.Handled;
		Message message2 = await binder.RequestAsync(message, timeout, maskingMode);
		if (message2 != null)
		{
			await ProcessMessageAsync(message2);
		}
	}

	protected override async Task OnConnectionSendMessageAsync(Message message, TimeSpan timeout, MaskingMode maskingMode)
	{
		Message message2 = await binder.RequestAsync(message, timeout, maskingMode);
		if (message2 != null)
		{
			await ProcessMessageAsync(message2);
		}
	}

	protected override WsrmFault ProcessRequestorResponse(ReliableRequestor requestor, string requestName, WsrmMessageInfo info)
	{
		string faultReason = System.SR.Format(System.SR.ReceivedResponseBeforeRequestFaultString, requestName);
		string exceptionMessage = System.SR.Format(System.SR.ReceivedResponseBeforeRequestExceptionString, requestName);
		return SequenceTerminatedFault.CreateProtocolFault(base.ReliableSession.OutputID, faultReason, exceptionMessage);
	}
}

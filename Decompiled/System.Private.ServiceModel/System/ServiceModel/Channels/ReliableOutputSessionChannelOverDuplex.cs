using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal sealed class ReliableOutputSessionChannelOverDuplex : ReliableOutputSessionChannel
{
	protected override bool RequestAcks => true;

	public ReliableOutputSessionChannelOverDuplex(ChannelManagerBase factory, IReliableFactorySettings settings, IClientReliableChannelBinder binder, FaultHelper faultHelper, LateBoundChannelParameterCollection channelParameters)
		: base(factory, settings, binder, faultHelper, channelParameters)
	{
	}

	protected override ReliableRequestor CreateRequestor()
	{
		return new SendWaitReliableRequestor();
	}

	protected override async Task OnConnectionSendAsync(Message message, TimeSpan timeout, bool saveHandledException, bool maskUnhandledException)
	{
		MaskingMode maskingMode = (maskUnhandledException ? MaskingMode.Unhandled : MaskingMode.None);
		if (saveHandledException)
		{
			try
			{
				await base.Binder.SendAsync(message, timeout, maskingMode);
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
		await base.Binder.SendAsync(message, timeout, maskingMode);
	}

	protected override Task OnConnectionSendMessageAsync(Message message, TimeSpan timeout, MaskingMode maskingMode)
	{
		return base.Binder.SendAsync(message, timeout, maskingMode);
	}

	protected override void OnOpened()
	{
		base.OnOpened();
		if (Thread.CurrentThread.IsThreadPoolThread)
		{
			try
			{
				StartReceivingAsync();
				return;
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				base.ReliableSession.OnUnknownException(ex);
				return;
			}
		}
		ActionItem.Schedule((Func<object, Task>)StartReceivingAsync, (object)this);
	}

	protected override WsrmFault ProcessRequestorResponse(ReliableRequestor requestor, string requestName, WsrmMessageInfo info)
	{
		if (requestor != null)
		{
			requestor.SetInfo(info);
			return null;
		}
		string faultReason = System.SR.Format(System.SR.ReceivedResponseBeforeRequestFaultString, requestName);
		string exceptionMessage = System.SR.Format(System.SR.ReceivedResponseBeforeRequestExceptionString, requestName);
		return SequenceTerminatedFault.CreateProtocolFault(base.ReliableSession.OutputID, faultReason, exceptionMessage);
	}

	private async Task StartReceivingAsync()
	{
		_ = 1;
		try
		{
			while (true)
			{
				var (flag, context) = await base.Binder.TryReceiveAsync(TimeSpan.MaxValue);
				if (flag)
				{
					if (context == null)
					{
						break;
					}
					using (context)
					{
						Message requestMessage = context.RequestMessage;
						await ProcessMessageAsync(requestMessage);
						context.Close(DefaultCloseTimeout);
					}
				}
			}
			if (!base.Connection.Closed && base.Binder.State == CommunicationState.Opened)
			{
				Exception e = new CommunicationException(System.SR.EarlySecurityClose);
				base.ReliableSession.OnLocalFault(e, (Message)null, (RequestContext)null);
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			base.ReliableSession.OnUnknownException(ex);
		}
	}

	private static Task StartReceivingAsync(object state)
	{
		ReliableOutputSessionChannelOverDuplex reliableOutputSessionChannelOverDuplex = (ReliableOutputSessionChannelOverDuplex)state;
		return reliableOutputSessionChannelOverDuplex.StartReceivingAsync();
	}
}

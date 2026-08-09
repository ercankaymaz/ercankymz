using System.Runtime;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class ClientReliableDuplexSessionChannel : ReliableDuplexSessionChannel
{
	private class DuplexClientReliableSession : ClientReliableSession, IDuplexSession, IInputSession, ISession, IOutputSession
	{
		private ClientReliableDuplexSessionChannel channel;

		public DuplexClientReliableSession(ClientReliableDuplexSessionChannel channel, IReliableFactorySettings settings, FaultHelper helper, UniqueId inputID)
			: base(channel, settings, (IClientReliableChannelBinder)channel.Binder, helper, inputID)
		{
			this.channel = channel;
		}

		public IAsyncResult BeginCloseOutputSession(AsyncCallback callback, object state)
		{
			return BeginCloseOutputSession(channel.DefaultCloseTimeout, callback, state);
		}

		public IAsyncResult BeginCloseOutputSession(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return channel.OnCloseOutputSessionAsync(timeout).ToApm(callback, state);
		}

		public void EndCloseOutputSession(IAsyncResult result)
		{
			result.ToApmEnd();
		}

		public void CloseOutputSession()
		{
			CloseOutputSession(channel.DefaultCloseTimeout);
		}

		public void CloseOutputSession(TimeSpan timeout)
		{
			channel.OnCloseOutputSessionAsync(timeout).WaitForCompletionNoSpin();
		}
	}

	private ChannelParameterCollection _channelParameters;

	private DuplexClientReliableSession _clientSession;

	private TimeoutHelper _closeTimeoutHelper;

	private bool _closing;

	private static Func<object, Task> s_onReconnectTimerElapsed = OnReconnectTimerElapsed;

	public ClientReliableDuplexSessionChannel(ChannelManagerBase factory, IReliableFactorySettings settings, IReliableChannelBinder binder, FaultHelper faultHelper, LateBoundChannelParameterCollection channelParameters, UniqueId inputID)
		: base(factory, settings, binder)
	{
		_clientSession = new DuplexClientReliableSession(this, settings, faultHelper, inputID);
		_clientSession.PollingCallback = PollingAsyncCallback;
		SetSession(_clientSession);
		_channelParameters = channelParameters;
		channelParameters.SetChannel(this);
		((IClientReliableChannelBinder)binder).ConnectionLost += OnConnectionLost;
	}

	public override T GetProperty<T>()
	{
		if (typeof(T) == typeof(ChannelParameterCollection))
		{
			return (T)(object)_channelParameters;
		}
		return base.GetProperty<T>();
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnOpenAsync(timeout).ToApm(callback, state);
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		_closeTimeoutHelper = new TimeoutHelper(timeout);
		_closing = true;
		return base.OnCloseAsync(timeout);
	}

	protected override void OnClose(TimeSpan timeout)
	{
		OnCloseAsync(timeout).WaitForCompletion();
	}

	private async void OnConnectionLost(object sender, EventArgs args)
	{
		await using (await base.ThisAsyncLock.TakeLockAsync())
		{
			if ((base.State == CommunicationState.Opened || base.State == CommunicationState.Closing) && !base.Binder.Connected && _clientSession.StopPolling())
			{
				if (WcfEventSource.Instance.ClientReliableSessionReconnectIsEnabled())
				{
					WcfEventSource.Instance.ClientReliableSessionReconnect(_clientSession.Id);
				}
				await ReconnectAsync();
			}
		}
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected internal override async Task OnOpenAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		bool throwing = true;
		try
		{
			await base.Binder.OpenAsync(timeoutHelper.RemainingTime());
			await base.ReliableSession.OpenAsync(timeoutHelper.RemainingTime());
			throwing = false;
		}
		finally
		{
			if (throwing)
			{
				await base.Binder.CloseAsync(timeoutHelper.RemainingTime());
			}
		}
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		OnOpenAsync(timeout).WaitForCompletion();
	}

	protected override void OnOpened()
	{
		base.OnOpened();
		SetConnections();
		ActionItem.Schedule(ReliableDuplexSessionChannel.s_startReceivingAsyncStatic, this);
	}

	private static async Task OnReconnectTimerElapsed(object state)
	{
		ClientReliableDuplexSessionChannel channel = (ClientReliableDuplexSessionChannel)state;
		await using (await channel.ThisAsyncLock.TakeLockAsync())
		{
			if ((channel.State == CommunicationState.Opened || channel.State == CommunicationState.Closing) && !channel.Binder.Connected)
			{
				await channel.ReconnectAsync();
			}
			else
			{
				channel._clientSession.ResumePolling(channel.OutputConnection.Strategy.QuotaRemaining == 0);
			}
		}
	}

	protected override void OnRemoteActivity()
	{
		base.ReliableSession.OnRemoteActivity(base.OutputConnection.Strategy.QuotaRemaining == 0);
	}

	private async Task PollingAsyncCallback()
	{
		using Message message = WsrmUtilities.CreateAckRequestedMessage(base.Settings.MessageVersion, base.Settings.ReliableMessagingVersion, base.ReliableSession.OutputID);
		await base.Binder.SendAsync(message, base.DefaultSendTimeout);
	}

	protected override Task ProcessMessageAsync(WsrmMessageInfo info)
	{
		if (!base.ReliableSession.ProcessInfo(info, null))
		{
			return Task.CompletedTask;
		}
		if (!base.ReliableSession.VerifyDuplexProtocolElements(info, null))
		{
			return Task.CompletedTask;
		}
		return ProcessDuplexMessageAsync(info);
	}

	private async Task ReconnectAsync()
	{
		bool handleException = true;
		try
		{
			Message message = WsrmUtilities.CreateAckRequestedMessage(base.Settings.MessageVersion, base.Settings.ReliableMessagingVersion, base.ReliableSession.OutputID);
			TimeSpan timeout = (_closing ? _closeTimeoutHelper.RemainingTime() : DefaultCloseTimeout);
			await base.Binder.SendAsync(message, timeout);
			handleException = false;
			using (base.ThisAsyncLock.TakeLock())
			{
				if (base.Binder.Connected)
				{
					_clientSession.ResumePolling(base.OutputConnection.Strategy.QuotaRemaining == 0);
				}
				else
				{
					WaitForReconnect();
				}
			}
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
			if (handleException)
			{
				WaitForReconnect();
				return;
			}
			throw;
		}
	}

	private void WaitForReconnect()
	{
		TimeSpan timeFromNow = ((!_closing) ? TimeoutHelper.Divide(base.DefaultSendTimeout, 2) : TimeoutHelper.Divide(_closeTimeoutHelper.RemainingTime(), 2));
		IOThreadTimer iOThreadTimer = new IOThreadTimer(s_onReconnectTimerElapsed, this, isTypicallyCanceledShortlyAfterBeingSet: false);
		iOThreadTimer.Set(timeFromNow);
	}
}

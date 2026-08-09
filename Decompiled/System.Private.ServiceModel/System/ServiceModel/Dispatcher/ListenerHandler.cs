using System.Runtime;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace System.ServiceModel.Dispatcher;

internal class ListenerHandler : CommunicationObject
{
	internal class CloseChannelState
	{
		private IChannel _channel;

		internal ListenerHandler ListenerHandler { get; }

		internal IChannel Channel => _channel;

		internal CloseChannelState(ListenerHandler listenerHandler, IChannel channel)
		{
			ListenerHandler = listenerHandler;
			_channel = channel;
		}
	}

	private static Action<object> s_initiateChannelPump = InitiateChannelPump;

	private ServiceChannel.SessionIdleManager _idleManager;

	private bool _acceptedNull;

	private bool _doneAccepting;

	private readonly IListenerBinder _listenerBinder;

	private IDefaultCommunicationTimeouts _timeouts;

	internal ChannelDispatcher ChannelDispatcher { get; }

	internal ListenerChannel Channel { get; private set; }

	protected override TimeSpan DefaultCloseTimeout => ServiceDefaults.CloseTimeout;

	protected override TimeSpan DefaultOpenTimeout => ServiceDefaults.OpenTimeout;

	internal EndpointDispatcherTable Endpoints { get; set; }

	internal new object ThisLock => base.ThisLock;

	internal ListenerHandler(IListenerBinder listenerBinder, ChannelDispatcher channelDispatcher, IDefaultCommunicationTimeouts timeouts)
	{
		_listenerBinder = listenerBinder;
		if (_listenerBinder == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("listenerBinder");
		}
		ChannelDispatcher = channelDispatcher;
		if (ChannelDispatcher == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("channelDispatcher");
		}
		_timeouts = timeouts;
		Endpoints = channelDispatcher.EndpointDispatcherTable;
	}

	protected internal override async Task OnCloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		CancelPendingIdleManager();
		ChannelDispatcher.Channels.CloseInput();
		await CloseChannelsAsync(timeoutHelper.RemainingTime());
	}

	protected internal override Task OnOpenAsync(TimeSpan timeout)
	{
		OnOpen(timeout);
		return TaskHelpers.CompletedTask();
	}

	protected override void OnOpen(TimeSpan timeout)
	{
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return new CompletedAsyncResult(callback, state);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		CompletedAsyncResult.End(result);
	}

	protected override void OnOpened()
	{
		base.OnOpened();
		ChannelDispatcher.Channels.IncrementActivityCount();
		NewChannelPump();
	}

	internal void NewChannelPump()
	{
		ActionItem.Schedule(s_initiateChannelPump, this);
	}

	private static void InitiateChannelPump(object state)
	{
		ListenerHandler listenerHandler = state as ListenerHandler;
		listenerHandler.ChannelPump();
	}

	private void ChannelPump()
	{
		IChannelListener listener = _listenerBinder.Listener;
		while (!_acceptedNull && listener.State != CommunicationState.Faulted)
		{
			Dispatch();
		}
		DoneAccepting();
	}

	private void AbortChannels()
	{
		IChannel[] array = ChannelDispatcher.Channels.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Abort();
		}
	}

	private async Task CloseChannelAsync(IChannel channel, TimeSpan timeout)
	{
		_ = 1;
		try
		{
			if (channel.State != CommunicationState.Closing && channel.State != CommunicationState.Closed)
			{
				new CloseChannelState(this, channel);
				if (channel is ISessionChannel<IDuplexSession>)
				{
					IDuplexSession session = ((ISessionChannel<IDuplexSession>)channel).Session;
					await Task.Factory.FromAsync(session.BeginCloseOutputSession, session.EndCloseOutputSession, timeout, null);
				}
				else
				{
					await channel.CloseHelperAsync(timeout);
				}
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			HandleError(ex);
			if (channel is ISessionChannel<IDuplexSession>)
			{
				channel.Abort();
			}
		}
	}

	public void CloseInput(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		IChannel[] array = ChannelDispatcher.Channels.ToArray();
		foreach (IChannel channel in array)
		{
			if (IsSessionChannel(channel))
			{
				continue;
			}
			try
			{
				channel.Close(timeoutHelper.RemainingTime());
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				HandleError(ex);
			}
		}
	}

	private async Task CloseChannelsAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		IChannel[] array = ChannelDispatcher.Channels.ToArray();
		Task[] array2 = new Task[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = CloseChannelAsync(array[i], timeoutHelper.RemainingTime());
		}
		await Task.WhenAll(array2);
	}

	private void Dispatch()
	{
		ListenerChannel listenerChannel = Channel;
		ServiceChannel.SessionIdleManager sessionIdleManager = _idleManager;
		Channel = null;
		_idleManager = null;
		try
		{
			if (listenerChannel == null)
			{
				return;
			}
			ChannelHandler channelHandler = new ChannelHandler(_listenerBinder.MessageVersion, listenerChannel.Binder, this, sessionIdleManager);
			if (!listenerChannel.Binder.HasSession)
			{
				ChannelDispatcher.Channels.Add(listenerChannel.Binder.Channel);
			}
			if (listenerChannel.Binder is DuplexChannelBinder)
			{
				DuplexChannelBinder duplexChannelBinder = listenerChannel.Binder as DuplexChannelBinder;
				duplexChannelBinder.ChannelHandler = channelHandler;
				duplexChannelBinder.DefaultCloseTimeout = DefaultCloseTimeout;
				if (_timeouts == null)
				{
					duplexChannelBinder.DefaultSendTimeout = ServiceDefaults.SendTimeout;
				}
				else
				{
					duplexChannelBinder.DefaultSendTimeout = _timeouts.SendTimeout;
				}
			}
			ChannelHandler.Register(channelHandler);
			listenerChannel = null;
			sessionIdleManager = null;
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			HandleError(ex);
		}
		finally
		{
			if (listenerChannel != null)
			{
				listenerChannel.Binder.Channel.Abort();
				sessionIdleManager?.CancelTimer();
			}
		}
	}

	private void AcceptedNull()
	{
		_acceptedNull = true;
	}

	private void DoneAccepting()
	{
		lock (ThisLock)
		{
			if (!_doneAccepting)
			{
				_doneAccepting = true;
				ChannelDispatcher.Channels.DecrementActivityCount();
			}
		}
	}

	private bool IsSessionChannel(IChannel channel)
	{
		if (!(channel is ISessionChannel<IDuplexSession>) && !(channel is ISessionChannel<IInputSession>))
		{
			return channel is ISessionChannel<IOutputSession>;
		}
		return true;
	}

	private void CancelPendingIdleManager()
	{
		_idleManager?.CancelTimer();
	}

	protected override void OnAbort()
	{
		CancelPendingIdleManager();
		ChannelDispatcher.Channels.CloseInput();
		AbortChannels();
		ChannelDispatcher.Channels.Abort();
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	protected override void OnClose(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		CancelPendingIdleManager();
		ChannelDispatcher.Channels.CloseInput();
		CloseChannelsAsync(timeoutHelper.RemainingTime()).WaitForCompletion();
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	private bool HandleError(Exception e)
	{
		return ChannelDispatcher.HandleError(e);
	}
}

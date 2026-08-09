using System.Collections.Generic;
using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class ReliableChannelBinder<TChannel> : IReliableChannelBinder where TChannel : class, IChannel
{
	private abstract class BinderRequestContext : RequestContextBase
	{
		private MaskingMode _maskingMode;

		protected ReliableChannelBinder<TChannel> Binder { get; }

		protected MaskingMode MaskingMode => _maskingMode;

		public BinderRequestContext(ReliableChannelBinder<TChannel> binder, Message message)
			: base(message, binder._defaultCloseTimeout, binder.DefaultSendTimeout)
		{
			Binder = binder;
			_maskingMode = binder.DefaultMaskingMode;
		}

		public void SetMaskingMode(MaskingMode maskingMode)
		{
			if (Binder.DefaultMaskingMode != MaskingMode.All)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
			}
			_maskingMode = maskingMode;
		}
	}

	protected class ChannelSynchronizer
	{
		private enum State
		{
			Created,
			NoChannel,
			ChannelOpening,
			ChannelOpened,
			ChannelClosing,
			Faulted,
			Closed
		}

		public interface IWaiter
		{
			bool CanGetChannel { get; }

			void Close();

			void Fault();

			void GetChannel(bool onUserThread);

			void Set(TChannel channel);
		}

		private sealed class TaskWaiter : IWaiter
		{
			private TChannel _channel;

			private ChannelParameterCollection _channelParameters;

			private bool _getChannel;

			private MaskingMode _maskingMode;

			private ChannelSynchronizer _synchronizer;

			private TimeoutHelper _timeoutHelper;

			private TaskCompletionSource<object> _tcs;

			public bool CanGetChannel { get; }

			public TaskWaiter(ChannelSynchronizer synchronizer, bool canGetChannel, TChannel channel, TimeSpan timeout, MaskingMode maskingMode, ChannelParameterCollection channelParameters)
			{
				if (!canGetChannel && channel != null)
				{
					throw Fx.AssertAndThrow("This waiter must wait for a channel thus argument channel must be null.");
				}
				_synchronizer = synchronizer;
				CanGetChannel = canGetChannel;
				_channel = channel;
				_timeoutHelper = new TimeoutHelper(timeout);
				_maskingMode = maskingMode;
				_channelParameters = channelParameters;
				_tcs = new TaskCompletionSource<object>();
			}

			public void Close()
			{
				Exception closedException = _synchronizer._binder.GetClosedException(_maskingMode);
				if (closedException == null)
				{
					_tcs.TrySetResult(null);
				}
				else
				{
					_tcs.TrySetException(DiagnosticUtility.ExceptionUtility.ThrowHelperError(closedException));
				}
			}

			public void Fault()
			{
				Exception faultedException = _synchronizer._binder.GetFaultedException(_maskingMode);
				_tcs.TrySetException(DiagnosticUtility.ExceptionUtility.ThrowHelperError(faultedException));
			}

			public void GetChannel(bool onUserThread)
			{
				if (!CanGetChannel)
				{
					throw Fx.AssertAndThrow("This waiter must wait for a channel thus the caller cannot attempt to get a channel.");
				}
				_getChannel = true;
				_tcs.TrySetResult(null);
			}

			public void Set(TChannel channel)
			{
				_channel = channel ?? throw Fx.AssertAndThrow("Argument channel cannot be null. Caller must call Fault or Close instead.");
				_tcs.TrySetResult(null);
			}

			private async Task<bool> TryGetChannelAsync()
			{
				TChannel channel;
				if (_channel != null)
				{
					channel = _channel;
				}
				else
				{
					if (!(await _synchronizer._binder.TryGetChannelAsync(_timeoutHelper.RemainingTime())))
					{
						_synchronizer.OnGetChannelFailed();
						return false;
					}
					if (!_synchronizer.CompleteSetChannel(this, out channel))
					{
						return true;
					}
				}
				if (_synchronizer._binder.MustOpenChannel)
				{
					bool throwing = true;
					if (_channelParameters != null)
					{
						_channelParameters.PropagateChannelParameters(channel);
					}
					try
					{
						await channel.OpenHelperAsync(_timeoutHelper.RemainingTime());
						throwing = false;
					}
					finally
					{
						if (throwing)
						{
							channel.Abort();
							_synchronizer.OnGetChannelFailed();
						}
					}
				}
				if (_synchronizer.OnChannelOpened(this))
				{
					Set(channel);
				}
				return true;
			}

			public async Task<(bool success, TChannel channel)> TryWaitAsync()
			{
				if (!(await WaitAsync()))
				{
					return (success: false, channel: null);
				}
				bool getChannel = _getChannel;
				bool flag = getChannel;
				if (flag)
				{
					flag = !(await TryGetChannelAsync());
				}
				if (flag)
				{
					return (success: false, channel: null);
				}
				if (_tcs.Task.IsFaulted)
				{
					if (_channel != null)
					{
						throw Fx.AssertAndThrow("User of IWaiter called both Set and Fault or Close.");
					}
					await _tcs.Task;
				}
				return (success: true, channel: _channel);
			}

			private async Task<bool> WaitAsync()
			{
				if (!(await _tcs.Task.AwaitWithTimeout(_timeoutHelper.RemainingTime())))
				{
					if (_synchronizer.RemoveWaiter(this))
					{
						return false;
					}
					await _tcs.Task;
				}
				return true;
			}
		}

		private ReliableChannelBinder<TChannel> _binder;

		private int _count;

		private InterruptibleWaitObject _drainEvent;

		private TolerateFaultsMode _faultMode;

		private Queue<IWaiter> _getChannelQueue;

		private bool _innerChannelFaulted;

		private EventHandler _onChannelFaulted;

		private State _state;

		private Queue<IWaiter> _waitQueue;

		public bool Aborting { get; private set; }

		public bool Connected
		{
			get
			{
				if (_state != State.ChannelOpened)
				{
					return _state == State.ChannelOpening;
				}
				return true;
			}
		}

		public TChannel CurrentChannel { get; private set; }

		private AsyncLock ThisLock { get; } = new AsyncLock();

		public bool TolerateFaults { get; private set; } = true;

		public ChannelSynchronizer(ReliableChannelBinder<TChannel> binder, TChannel channel, TolerateFaultsMode faultMode)
		{
			_binder = binder;
			CurrentChannel = channel;
			_faultMode = faultMode;
		}

		public TChannel AbortCurentChannel()
		{
			using (ThisLock.TakeLock())
			{
				if (!TolerateFaults)
				{
					throw Fx.AssertAndThrow("It is only valid to abort the current channel when masking faults");
				}
				if (_state == State.ChannelOpening)
				{
					Aborting = true;
				}
				else
				{
					if (_state != State.ChannelOpened)
					{
						return null;
					}
					if (_count == 0)
					{
						_state = State.NoChannel;
					}
					else
					{
						Aborting = true;
						_state = State.ChannelClosing;
					}
				}
				return CurrentChannel;
			}
		}

		private bool CompleteSetChannel(IWaiter waiter, out TChannel channel)
		{
			if (waiter == null)
			{
				throw Fx.AssertAndThrow("Argument waiter cannot be null.");
			}
			bool flag = false;
			using (ThisLock.TakeLock())
			{
				if (ValidateOpened())
				{
					channel = CurrentChannel;
					return true;
				}
				channel = null;
				flag = _state == State.Closed;
			}
			if (flag)
			{
				waiter.Close();
			}
			else
			{
				waiter.Fault();
			}
			return false;
		}

		public async Task<bool> EnsureChannelAsync()
		{
			bool fault = false;
			bool result;
			await using (await ThisLock.TakeLockAsync())
			{
				if (ValidateOpened())
				{
					if (_state == State.ChannelOpened)
					{
						result = true;
						goto IL_0251;
					}
					if (_state != State.NoChannel)
					{
						throw Fx.AssertAndThrow("The caller may only invoke this EnsureChannel during the CreateSequence negotiation. ChannelOpening and ChannelClosing are invalid states during this phase of the negotiation.");
					}
					if (!TolerateFaults)
					{
						fault = true;
					}
					else
					{
						if (GetCurrentChannelIfCreated() != null)
						{
							result = true;
							goto IL_0251;
						}
						if (await _binder.TryGetChannelAsync(TimeSpan.Zero))
						{
							result = CurrentChannel != null;
							goto IL_0251;
						}
					}
				}
			}
			if (fault)
			{
				_binder.Fault(null);
			}
			return false;
			IL_0251:
			return result;
		}

		private IWaiter GetChannelWaiter()
		{
			if (_getChannelQueue == null || _getChannelQueue.Count == 0)
			{
				return null;
			}
			return _getChannelQueue.Dequeue();
		}

		private TChannel GetCurrentChannelIfCreated()
		{
			if (_state != State.NoChannel)
			{
				throw Fx.AssertAndThrow("This method may only be called in the NoChannel state.");
			}
			if (CurrentChannel != null && CurrentChannel.State == CommunicationState.Created)
			{
				return CurrentChannel;
			}
			return null;
		}

		private Queue<IWaiter> GetQueue(bool canGetChannel)
		{
			if (canGetChannel)
			{
				if (_getChannelQueue == null)
				{
					_getChannelQueue = new Queue<IWaiter>();
				}
				return _getChannelQueue;
			}
			if (_waitQueue == null)
			{
				_waitQueue = new Queue<IWaiter>();
			}
			return _waitQueue;
		}

		private void OnChannelFaulted(object sender, EventArgs e)
		{
			TChannel val = (TChannel)sender;
			bool flag = false;
			bool flag2 = false;
			using (ThisLock.TakeLock())
			{
				if (CurrentChannel != val || !ValidateOpened())
				{
					return;
				}
				if (_state == State.ChannelOpened)
				{
					if (_count == 0)
					{
						val.Faulted -= _onChannelFaulted;
					}
					flag = !TolerateFaults;
					_state = State.ChannelClosing;
					_innerChannelFaulted = true;
					if (!flag && _count == 0)
					{
						_state = State.NoChannel;
						Aborting = false;
						flag2 = true;
						_innerChannelFaulted = false;
					}
				}
			}
			if (flag)
			{
				_binder.Fault(null);
			}
			val.Abort();
			if (flag2)
			{
				_binder.OnInnerChannelFaulted();
			}
		}

		private bool OnChannelOpened(IWaiter waiter)
		{
			if (waiter == null)
			{
				throw Fx.AssertAndThrow("Argument waiter cannot be null.");
			}
			bool flag = false;
			bool flag2 = false;
			Queue<IWaiter> waiters = null;
			Queue<IWaiter> waiters2 = null;
			TChannel channel = null;
			using (ThisLock.TakeLock())
			{
				if (CurrentChannel == null)
				{
					throw Fx.AssertAndThrow("Caller must ensure that field currentChannel is set before opening the channel.");
				}
				if (ValidateOpened())
				{
					if (_state != State.ChannelOpening)
					{
						throw Fx.AssertAndThrow("This method may only be called in the ChannelOpening state.");
					}
					_state = State.ChannelOpened;
					SetTolerateFaults();
					_count++;
					_count += ((_getChannelQueue != null) ? _getChannelQueue.Count : 0);
					_count += ((_waitQueue != null) ? _waitQueue.Count : 0);
					waiters = _getChannelQueue;
					waiters2 = _waitQueue;
					channel = CurrentChannel;
					_getChannelQueue = null;
					_waitQueue = null;
				}
				else
				{
					flag = _state == State.Closed;
					flag2 = _state == State.Faulted;
				}
			}
			if (flag)
			{
				waiter.Close();
				return false;
			}
			if (flag2)
			{
				waiter.Fault();
				return false;
			}
			SetWaiters(waiters, channel);
			SetWaiters(waiters2, channel);
			return true;
		}

		private void OnGetChannelFailed()
		{
			IWaiter waiter = null;
			using (ThisLock.TakeLock())
			{
				if (!ValidateOpened())
				{
					return;
				}
				if (_state != State.ChannelOpening)
				{
					throw Fx.AssertAndThrow("The state must be set to ChannelOpening before the caller attempts to open the channel.");
				}
				waiter = GetChannelWaiter();
				if (waiter == null)
				{
					_state = State.NoChannel;
					return;
				}
			}
			waiter.GetChannel(onUserThread: false);
		}

		public void OnReadEof()
		{
			using (ThisLock.TakeLock())
			{
				if (_count <= 0)
				{
					throw Fx.AssertAndThrow("Caller must ensure that OnReadEof is called before ReturnChannel.");
				}
				if (ValidateOpened())
				{
					if (_state != State.ChannelOpened && _state != State.ChannelClosing)
					{
						throw Fx.AssertAndThrow("Since count is positive, the only valid states are ChannelOpened and ChannelClosing.");
					}
					if (CurrentChannel.State != CommunicationState.Faulted)
					{
						_state = State.ChannelClosing;
					}
				}
			}
		}

		private bool RemoveWaiter(IWaiter waiter)
		{
			Queue<IWaiter> queue = (waiter.CanGetChannel ? _getChannelQueue : _waitQueue);
			if (queue == null)
			{
				return false;
			}
			bool result = false;
			using (ThisLock.TakeLock())
			{
				if (!ValidateOpened())
				{
					return false;
				}
				for (int num = queue.Count; num > 0; num--)
				{
					IWaiter waiter2 = queue.Dequeue();
					if (waiter == waiter2)
					{
						result = true;
					}
					else
					{
						queue.Enqueue(waiter2);
					}
				}
				return result;
			}
		}

		public void ReturnChannel()
		{
			TChannel val = null;
			IWaiter waiter = null;
			bool flag = false;
			bool flag2 = false;
			bool flag3;
			using (ThisLock.TakeLock())
			{
				if (_count <= 0)
				{
					throw Fx.AssertAndThrow("Method ReturnChannel() can only be called after TryGetChannel or EndTryGetChannel returns a channel.");
				}
				_count--;
				flag3 = _count == 0 && _drainEvent != null;
				if (ValidateOpened())
				{
					if (_state != State.ChannelOpened && _state != State.ChannelClosing)
					{
						throw Fx.AssertAndThrow("ChannelOpened and ChannelClosing are the only 2 valid states when count is positive.");
					}
					if (CurrentChannel.State == CommunicationState.Faulted)
					{
						flag = !TolerateFaults;
						_innerChannelFaulted = true;
						_state = State.ChannelClosing;
					}
					if (!flag && _state == State.ChannelClosing && _count == 0)
					{
						val = CurrentChannel;
						flag2 = _innerChannelFaulted;
						_innerChannelFaulted = false;
						_state = State.NoChannel;
						Aborting = false;
						waiter = GetChannelWaiter();
						if (waiter != null)
						{
							_state = State.ChannelOpening;
						}
					}
				}
			}
			if (flag)
			{
				_binder.Fault(null);
			}
			if (flag3)
			{
				_drainEvent.Set();
			}
			if (val != null)
			{
				val.Faulted -= _onChannelFaulted;
				if (val.State == CommunicationState.Opened)
				{
					_binder.CloseChannel(val);
				}
				else
				{
					val.Abort();
				}
				waiter?.GetChannel(onUserThread: false);
			}
			if (flag2)
			{
				_binder.OnInnerChannelFaulted();
			}
		}

		public bool SetChannel(TChannel channel)
		{
			using (ThisLock.TakeLock())
			{
				if (_state != State.ChannelOpening && _state != State.NoChannel)
				{
					throw Fx.AssertAndThrow("SetChannel is only valid in the NoChannel and ChannelOpening states");
				}
				if (!TolerateFaults)
				{
					throw Fx.AssertAndThrow("SetChannel is only valid when masking faults");
				}
				if (ValidateOpened())
				{
					CurrentChannel = channel;
					return true;
				}
				return false;
			}
		}

		private void SetTolerateFaults()
		{
			if (_faultMode == TolerateFaultsMode.Never)
			{
				TolerateFaults = false;
			}
			else if (_faultMode == TolerateFaultsMode.IfNotSecuritySession)
			{
				TolerateFaults = !_binder.HasSecuritySession(CurrentChannel);
			}
			if (_onChannelFaulted == null)
			{
				_onChannelFaulted = OnChannelFaulted;
			}
			CurrentChannel.Faulted += _onChannelFaulted;
		}

		private void SetWaiters(Queue<IWaiter> waiters, TChannel channel)
		{
			if (waiters == null || waiters.Count <= 0)
			{
				return;
			}
			foreach (IWaiter waiter in waiters)
			{
				waiter.Set(channel);
			}
		}

		public async Task StartSynchronizingAsync()
		{
			await using (await ThisLock.TakeLockAsync())
			{
				if (_state == State.Created)
				{
					_state = State.NoChannel;
					if ((CurrentChannel != null || await _binder.TryGetChannelAsync(TimeSpan.Zero)) && CurrentChannel != null)
					{
						if (!_binder.MustOpenChannel)
						{
							_state = State.ChannelOpened;
							SetTolerateFaults();
						}
						return;
					}
					return;
				}
				if (_state != State.Closed)
				{
					throw Fx.AssertAndThrow("Abort is the only operation that can race with Open.");
				}
			}
		}

		public TChannel StopSynchronizing(bool close)
		{
			using (ThisLock.TakeLock())
			{
				if (_state != State.Faulted && _state != State.Closed)
				{
					_state = (close ? State.Closed : State.Faulted);
					if (CurrentChannel != null && _onChannelFaulted != null)
					{
						CurrentChannel.Faulted -= _onChannelFaulted;
					}
				}
				return CurrentChannel;
			}
		}

		private bool ThrowIfNecessary(MaskingMode maskingMode)
		{
			if (ValidateOpened())
			{
				return true;
			}
			Exception ex = ((_state != State.Closed) ? _binder.GetFaultedException(maskingMode) : _binder.GetClosedException(maskingMode));
			if (ex != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex);
			}
			return false;
		}

		public Task<(bool success, TChannel channel)> TryGetChannelForInputAsync(bool canGetChannel, TimeSpan timeout)
		{
			return TryGetChannelAsync(canGetChannel, canCauseFault: false, timeout, MaskingMode.All);
		}

		public Task<(bool success, TChannel channel)> TryGetChannelForOutputAsync(TimeSpan timeout, MaskingMode maskingMode)
		{
			return TryGetChannelAsync(canGetChannel: true, canCauseFault: true, timeout, maskingMode);
		}

		private async Task<(bool success, TChannel channel)> TryGetChannelAsync(bool canGetChannel, bool canCauseFault, TimeSpan timeout, MaskingMode maskingMode)
		{
			TaskWaiter waiter = null;
			bool faulted = false;
			bool getChannel = false;
			(bool success, TChannel channel) result;
			await using (await ThisLock.TakeLockAsync())
			{
				if (!ThrowIfNecessary(maskingMode))
				{
					result = (success: true, channel: null);
					goto IL_02cb;
				}
				if (_state == State.ChannelOpened)
				{
					if (CurrentChannel == null)
					{
						throw Fx.AssertAndThrow("Field currentChannel cannot be null in the ChannelOpened state.");
					}
					_count++;
					result = (success: true, channel: CurrentChannel);
					goto IL_02cb;
				}
				if (!TolerateFaults && (_state == State.ChannelClosing || _state == State.NoChannel))
				{
					if (!canCauseFault)
					{
						result = (success: true, channel: null);
						goto IL_02cb;
					}
					faulted = true;
				}
				else if (!canGetChannel || _state == State.ChannelOpening || _state == State.ChannelClosing)
				{
					waiter = new TaskWaiter(this, canGetChannel, null, timeout, maskingMode, _binder.ChannelParameters);
					GetQueue(canGetChannel).Enqueue(waiter);
				}
				else
				{
					if (_state != State.NoChannel)
					{
						throw Fx.AssertAndThrow("The state must be NoChannel.");
					}
					waiter = new TaskWaiter(this, canGetChannel, GetCurrentChannelIfCreated(), timeout, maskingMode, _binder.ChannelParameters);
					_state = State.ChannelOpening;
					getChannel = true;
				}
			}
			if (faulted)
			{
				_binder.Fault(null);
				return (success: true, channel: null);
			}
			if (getChannel)
			{
				waiter.GetChannel(onUserThread: true);
			}
			return await waiter.TryWaitAsync();
			IL_02cb:
			return result;
		}

		public void UnblockWaiters()
		{
			Queue<IWaiter> getChannelQueue;
			Queue<IWaiter> waitQueue;
			using (ThisLock.TakeLock())
			{
				getChannelQueue = _getChannelQueue;
				waitQueue = _waitQueue;
				_getChannelQueue = null;
				_waitQueue = null;
			}
			bool close = _state == State.Closed;
			UnblockWaiters(getChannelQueue, close);
			UnblockWaiters(waitQueue, close);
		}

		private void UnblockWaiters(Queue<IWaiter> waiters, bool close)
		{
			if (waiters == null || waiters.Count <= 0)
			{
				return;
			}
			foreach (IWaiter waiter in waiters)
			{
				if (close)
				{
					waiter.Close();
				}
				else
				{
					waiter.Fault();
				}
			}
		}

		private bool ValidateOpened()
		{
			if (_state == State.Created)
			{
				throw Fx.AssertAndThrow("This operation expects that the synchronizer has been opened.");
			}
			if (_state != State.Closed)
			{
				return _state != State.Faulted;
			}
			return false;
		}

		public async Task WaitForPendingOperationsAsync(TimeSpan timeout)
		{
			await using (await ThisLock.TakeLockAsync())
			{
				if (_drainEvent != null)
				{
					throw Fx.AssertAndThrow("The WaitForPendingOperations operation may only be invoked once.");
				}
				if (_count > 0)
				{
					_drainEvent = new InterruptibleWaitObject(signaled: false, throwTimeoutByDefault: false);
				}
			}
			if (_drainEvent != null)
			{
				await _drainEvent.WaitAsync(timeout);
			}
		}
	}

	private sealed class MessageRequestContext : BinderRequestContext
	{
		public MessageRequestContext(ReliableChannelBinder<TChannel> binder, Message message)
			: base(binder, message)
		{
		}

		protected override void OnAbort()
		{
		}

		protected override void OnClose(TimeSpan timeout)
		{
		}

		protected override IAsyncResult OnBeginReply(Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			if (message != null)
			{
				return base.Binder.SendAsync(message, timeout, base.MaskingMode).ToApm(callback, state);
			}
			return Task.CompletedTask.ToApm(callback, state);
		}

		protected override void OnEndReply(IAsyncResult result)
		{
			result.ToApmEnd();
		}

		protected override void OnReply(Message message, TimeSpan timeout)
		{
			if (message != null)
			{
				base.Binder.SendAsync(message, timeout, base.MaskingMode).GetAwaiter().GetResult();
			}
		}
	}

	private sealed class RequestRequestContext : BinderRequestContext
	{
		private RequestContext _innerContext;

		public RequestRequestContext(ReliableChannelBinder<TChannel> binder, RequestContext innerContext, Message message)
			: base(binder, message)
		{
			if (binder.DefaultMaskingMode != MaskingMode.All && !binder.TolerateFaults)
			{
				throw Fx.AssertAndThrow("This request context is designed to catch exceptions. Thus it cannot be used if the caller expects no exception handling.");
			}
			_innerContext = innerContext ?? throw Fx.AssertAndThrow("Argument innerContext cannot be null.");
		}

		protected override void OnAbort()
		{
			_innerContext.Abort();
		}

		protected override IAsyncResult OnBeginReply(Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			return OnReplyAsync(message, timeout).ToApm(callback, state);
		}

		protected override void OnClose(TimeSpan timeout)
		{
			try
			{
				_innerContext.Close(timeout);
			}
			catch (ObjectDisposedException)
			{
			}
			catch (Exception ex2)
			{
				if (Fx.IsFatal(ex2))
				{
					throw;
				}
				if (!base.Binder.HandleException(ex2, base.MaskingMode))
				{
					throw;
				}
				_innerContext.Abort();
			}
		}

		protected override void OnEndReply(IAsyncResult result)
		{
			result.ToApmEnd();
		}

		private async Task OnReplyAsync(Message message, TimeSpan timeout)
		{
			try
			{
				if (message != null)
				{
					base.Binder.AddOutputHeaders(message);
				}
				await Task.Factory.FromAsync(_innerContext.BeginReply, _innerContext.EndReply, message, timeout, null);
			}
			catch (ObjectDisposedException)
			{
			}
			catch (Exception ex2)
			{
				if (Fx.IsFatal(ex2))
				{
					throw;
				}
				if (!base.Binder.HandleException(ex2, base.MaskingMode))
				{
					throw;
				}
				_innerContext.Abort();
			}
		}

		protected override void OnReply(Message message, TimeSpan timeout)
		{
			OnReplyAsync(message, timeout).GetAwaiter().GetResult();
		}
	}

	private bool _aborted;

	private TimeSpan _defaultCloseTimeout;

	private AsyncCallback _onCloseChannelComplete;

	private object _thisLock = new object();

	protected abstract bool CanGetChannelForReceive { get; }

	public abstract bool CanSendAsynchronously { get; }

	public virtual ChannelParameterCollection ChannelParameters => null;

	public IChannel Channel => Synchronizer.CurrentChannel;

	public bool Connected => Synchronizer.Connected;

	public MaskingMode DefaultMaskingMode { get; }

	public TimeSpan DefaultSendTimeout { get; }

	public abstract bool HasSession { get; }

	public abstract EndpointAddress LocalAddress { get; }

	protected abstract bool MustCloseChannel { get; }

	protected abstract bool MustOpenChannel { get; }

	public abstract EndpointAddress RemoteAddress { get; }

	public CommunicationState State { get; private set; }

	protected ChannelSynchronizer Synchronizer { get; }

	protected object ThisLock => _thisLock;

	private bool TolerateFaults => Synchronizer.TolerateFaults;

	public event EventHandler ConnectionLost;

	public event BinderExceptionHandler Faulted;

	public event BinderExceptionHandler OnException;

	protected ReliableChannelBinder(TChannel channel, MaskingMode maskingMode, TolerateFaultsMode faultMode, TimeSpan defaultCloseTimeout, TimeSpan defaultSendTimeout)
	{
		if (maskingMode != MaskingMode.None && maskingMode != MaskingMode.All)
		{
			throw Fx.AssertAndThrow("ReliableChannelBinder was implemented with only 2 default masking modes, None and All.");
		}
		DefaultMaskingMode = maskingMode;
		_defaultCloseTimeout = defaultCloseTimeout;
		DefaultSendTimeout = defaultSendTimeout;
		Synchronizer = new ChannelSynchronizer(this, channel, faultMode);
	}

	public void Abort()
	{
		TChannel val;
		lock (ThisLock)
		{
			_aborted = true;
			if (State == CommunicationState.Closed)
			{
				return;
			}
			State = CommunicationState.Closing;
			val = Synchronizer.StopSynchronizing(close: true);
			if (!MustCloseChannel)
			{
				val = null;
			}
		}
		Synchronizer.UnblockWaiters();
		OnShutdown();
		OnAbort();
		val?.Abort();
		TransitionToClosed();
	}

	protected virtual void AddOutputHeaders(Message message)
	{
	}

	private bool CloseCore(out TChannel channel)
	{
		channel = null;
		bool flag = true;
		bool flag2 = false;
		lock (ThisLock)
		{
			if (State == CommunicationState.Closing || State == CommunicationState.Closed)
			{
				return true;
			}
			if (State == CommunicationState.Opened)
			{
				State = CommunicationState.Closing;
				channel = Synchronizer.StopSynchronizing(close: true);
				flag = false;
				if (!MustCloseChannel)
				{
					channel = null;
				}
				if (channel != null)
				{
					switch (channel.State)
					{
					case CommunicationState.Created:
					case CommunicationState.Opening:
					case CommunicationState.Faulted:
						flag2 = true;
						break;
					case CommunicationState.Closing:
					case CommunicationState.Closed:
						channel = null;
						break;
					}
				}
			}
		}
		Synchronizer.UnblockWaiters();
		if (flag)
		{
			Abort();
			return true;
		}
		if (flag2)
		{
			channel.Abort();
			channel = null;
		}
		return false;
	}

	public Task CloseAsync(TimeSpan timeout)
	{
		return CloseAsync(timeout, DefaultMaskingMode);
	}

	public async Task CloseAsync(TimeSpan timeout, MaskingMode maskingMode)
	{
		ThrowIfTimeoutNegative(timeout);
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (CloseCore(out var channel))
		{
			return;
		}
		try
		{
			OnShutdown();
			await OnCloseAsync(timeoutHelper.RemainingTime());
			if (channel != null)
			{
				await CloseChannelAsync(channel, timeoutHelper.RemainingTime());
			}
			TransitionToClosed();
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			Abort();
			if (!HandleException(ex, maskingMode))
			{
				throw;
			}
		}
	}

	private void CloseChannel(TChannel channel)
	{
		if (!MustCloseChannel)
		{
			throw Fx.AssertAndThrow("MustCloseChannel is false when there is no receive loop and this method is called when there is a receive loop.");
		}
		if (_onCloseChannelComplete == null)
		{
			_onCloseChannelComplete = Fx.ThunkCallback(OnCloseChannelComplete);
		}
		try
		{
			IAsyncResult asyncResult = channel.BeginClose(_onCloseChannelComplete, channel);
			if (asyncResult.CompletedSynchronously)
			{
				channel.EndClose(asyncResult);
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			HandleException(ex, MaskingMode.All);
		}
	}

	protected virtual Task CloseChannelAsync(TChannel channel, TimeSpan timeout)
	{
		return channel.CloseHelperAsync(timeout);
	}

	protected void Fault(Exception e)
	{
		lock (ThisLock)
		{
			if (State == CommunicationState.Created)
			{
				throw Fx.AssertAndThrow("The binder should not detect the inner channel's faults until after the binder is opened.");
			}
			if (State == CommunicationState.Faulted || State == CommunicationState.Closed)
			{
				return;
			}
			State = CommunicationState.Faulted;
			Synchronizer.StopSynchronizing(close: false);
		}
		Synchronizer.UnblockWaiters();
		this.Faulted?.Invoke(this, e);
	}

	private Exception GetClosedException(MaskingMode maskingMode)
	{
		if (ReliableChannelBinderHelper.MaskHandled(maskingMode))
		{
			return null;
		}
		if (_aborted)
		{
			return new CommunicationObjectAbortedException(System.SR.Format(System.SR.CommunicationObjectAborted1, GetType().ToString()));
		}
		return new ObjectDisposedException(GetType().ToString());
	}

	private Exception GetClosedOrFaultedException(MaskingMode maskingMode)
	{
		if (State == CommunicationState.Faulted)
		{
			return GetFaultedException(maskingMode);
		}
		if (State == CommunicationState.Closing || State == CommunicationState.Closed)
		{
			return GetClosedException(maskingMode);
		}
		throw Fx.AssertAndThrow("Caller is attempting to get a terminal exception in a non-terminal state.");
	}

	private Exception GetFaultedException(MaskingMode maskingMode)
	{
		if (ReliableChannelBinderHelper.MaskHandled(maskingMode))
		{
			return null;
		}
		return new CommunicationObjectFaultedException(System.SR.Format(System.SR.CommunicationObjectFaulted1, GetType().ToString()));
	}

	public abstract ISession GetInnerSession();

	public void HandleException(Exception e)
	{
		HandleException(e, MaskingMode.All);
	}

	protected bool HandleException(Exception e, MaskingMode maskingMode)
	{
		if (TolerateFaults && e is CommunicationObjectFaultedException)
		{
			return true;
		}
		if (IsHandleable(e))
		{
			return ReliableChannelBinderHelper.MaskHandled(maskingMode);
		}
		bool flag = ReliableChannelBinderHelper.MaskUnhandled(maskingMode);
		if (flag)
		{
			RaiseOnException(e);
		}
		return flag;
	}

	protected bool HandleException(Exception e, MaskingMode maskingMode, bool autoAborted)
	{
		if (TolerateFaults && autoAborted && e is CommunicationObjectAbortedException)
		{
			return true;
		}
		return HandleException(e, maskingMode);
	}

	protected abstract bool HasSecuritySession(TChannel channel);

	public bool IsHandleable(Exception e)
	{
		if (e is ProtocolException)
		{
			return false;
		}
		if (!(e is CommunicationException))
		{
			return e is TimeoutException;
		}
		return true;
	}

	protected abstract void OnAbort();

	protected abstract Task OnCloseAsync(TimeSpan timeout);

	private void OnCloseChannelComplete(IAsyncResult result)
	{
		if (result.CompletedSynchronously)
		{
			return;
		}
		TChannel val = (TChannel)result.AsyncState;
		try
		{
			val.EndClose(result);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			HandleException(ex, MaskingMode.All);
		}
	}

	private void OnInnerChannelFaulted()
	{
		if (TolerateFaults)
		{
			this.ConnectionLost?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract Task OnOpenAsync(TimeSpan timeout);

	private void OnOpened()
	{
		lock (ThisLock)
		{
			if (State == CommunicationState.Opening)
			{
				State = CommunicationState.Opened;
			}
		}
	}

	private bool OnOpening(MaskingMode maskingMode)
	{
		lock (ThisLock)
		{
			if (State != CommunicationState.Created)
			{
				Exception ex = null;
				if (State == CommunicationState.Opening || State == CommunicationState.Opened)
				{
					if (!ReliableChannelBinderHelper.MaskUnhandled(maskingMode))
					{
						ex = new InvalidOperationException(System.SR.Format(System.SR.CommunicationObjectCannotBeModifiedInState, GetType().ToString(), State.ToString()));
					}
				}
				else
				{
					ex = GetClosedOrFaultedException(maskingMode);
				}
				if (ex != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex);
				}
				return false;
			}
			State = CommunicationState.Opening;
			return true;
		}
	}

	protected virtual void OnShutdown()
	{
	}

	protected virtual Task OnSendAsync(TChannel channel, Message message, TimeSpan timeout)
	{
		throw Fx.AssertAndThrow("The derived class does not support the Send operation.");
	}

	protected virtual Task<(bool success, RequestContext requestContext)> OnTryReceiveAsync(TChannel channel, TimeSpan timeout)
	{
		throw Fx.AssertAndThrow("The derived class does not support the TryReceive operation.");
	}

	public async Task OpenAsync(TimeSpan timeout)
	{
		ThrowIfTimeoutNegative(timeout);
		if (!OnOpening(DefaultMaskingMode))
		{
			return;
		}
		try
		{
			await OnOpenAsync(timeout);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			Fault(null);
			if (DefaultMaskingMode == MaskingMode.None)
			{
				throw;
			}
			RaiseOnException(ex);
			return;
		}
		await Synchronizer.StartSynchronizingAsync();
		OnOpened();
	}

	private void RaiseOnException(Exception e)
	{
		this.OnException?.Invoke(this, e);
	}

	public Task SendAsync(Message message, TimeSpan timeout)
	{
		return SendAsync(message, timeout, DefaultMaskingMode);
	}

	public async Task SendAsync(Message message, TimeSpan timeout, MaskingMode maskingMode)
	{
		if (!ValidateOutputOperation(message, timeout, maskingMode))
		{
			return;
		}
		bool autoAborted = false;
		try
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			var (flag, val) = await Synchronizer.TryGetChannelForOutputAsync(timeoutHelper.RemainingTime(), maskingMode);
			if (!flag)
			{
				if (!ReliableChannelBinderHelper.MaskHandled(maskingMode))
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.TimeoutOnSend, timeout)));
				}
			}
			else if (val != null)
			{
				AddOutputHeaders(message);
				try
				{
					await OnSendAsync(val, message, timeoutHelper.RemainingTime());
				}
				finally
				{
					autoAborted = Synchronizer.Aborting;
					Synchronizer.ReturnChannel();
				}
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (!HandleException(ex, maskingMode, autoAborted))
			{
				throw;
			}
		}
	}

	public void SetMaskingMode(RequestContext context, MaskingMode maskingMode)
	{
		BinderRequestContext binderRequestContext = (BinderRequestContext)context;
		binderRequestContext.SetMaskingMode(maskingMode);
	}

	private bool ThrowIfNotOpenedAndNotMasking(MaskingMode maskingMode, bool throwDisposed)
	{
		lock (ThisLock)
		{
			if (State == CommunicationState.Created)
			{
				throw Fx.AssertAndThrow("Messaging operations cannot be called when the binder is in the Created state.");
			}
			if (State == CommunicationState.Opening)
			{
				throw Fx.AssertAndThrow("Messaging operations cannot be called when the binder is in the Opening state.");
			}
			if (State == CommunicationState.Opened)
			{
				return true;
			}
			if (throwDisposed)
			{
				Exception closedOrFaultedException = GetClosedOrFaultedException(maskingMode);
				if (closedOrFaultedException != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(closedOrFaultedException);
				}
			}
			return false;
		}
	}

	private void ThrowIfTimeoutNegative(TimeSpan timeout)
	{
		if (timeout < TimeSpan.Zero)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("timeout", timeout, System.SR.SFxTimeoutOutOfRange0));
		}
	}

	private void TransitionToClosed()
	{
		lock (ThisLock)
		{
			if (State != CommunicationState.Closing && State != CommunicationState.Closed && State != CommunicationState.Faulted)
			{
				throw Fx.AssertAndThrow("Caller cannot transition to the Closed state from a non-terminal state.");
			}
			State = CommunicationState.Closed;
		}
	}

	protected abstract Task<bool> TryGetChannelAsync(TimeSpan timeout);

	public virtual Task<(bool, RequestContext)> TryReceiveAsync(TimeSpan timeout)
	{
		return TryReceiveAsync(timeout, DefaultMaskingMode);
	}

	public virtual async Task<(bool, RequestContext)> TryReceiveAsync(TimeSpan timeout, MaskingMode maskingMode)
	{
		if (!ValidateInputOperation(timeout))
		{
			return (true, null);
		}
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		while (true)
		{
			bool autoAborted = false;
			try
			{
				(bool, TChannel) tuple = await Synchronizer.TryGetChannelForInputAsync(CanGetChannelForReceive, timeoutHelper.RemainingTime());
				bool item = tuple.Item1;
				TChannel item2 = tuple.Item2;
				item = !item;
				if (item2 == null)
				{
					return (item, null);
				}
				try
				{
					RequestContext requestContext;
					(item, requestContext) = await OnTryReceiveAsync(item2, timeoutHelper.RemainingTime());
					if (!item || requestContext != null)
					{
						return (item, requestContext);
					}
					Synchronizer.OnReadEof();
				}
				finally
				{
					autoAborted = Synchronizer.Aborting;
					Synchronizer.ReturnChannel();
				}
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (!HandleException(ex, maskingMode, autoAborted))
				{
					throw;
				}
			}
		}
	}

	protected bool ValidateInputOperation(TimeSpan timeout)
	{
		if (timeout < TimeSpan.Zero)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("timeout", timeout, System.SR.SFxTimeoutOutOfRange0));
		}
		return ThrowIfNotOpenedAndNotMasking(MaskingMode.All, throwDisposed: false);
	}

	protected bool ValidateOutputOperation(Message message, TimeSpan timeout, MaskingMode maskingMode)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		if (timeout < TimeSpan.Zero)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("timeout", timeout, System.SR.SFxTimeoutOutOfRange0));
		}
		return ThrowIfNotOpenedAndNotMasking(maskingMode, throwDisposed: true);
	}

	internal Task WaitForPendingOperationsAsync(TimeSpan timeout)
	{
		return Synchronizer.WaitForPendingOperationsAsync(timeout);
	}

	protected RequestContext WrapMessage(Message message)
	{
		if (message == null)
		{
			return null;
		}
		return new MessageRequestContext(this, message);
	}

	public RequestContext WrapRequestContext(RequestContext context)
	{
		if (context == null)
		{
			return null;
		}
		if (!TolerateFaults && DefaultMaskingMode == MaskingMode.None)
		{
			return context;
		}
		return new RequestRequestContext(this, context, context.RequestMessage);
	}
}

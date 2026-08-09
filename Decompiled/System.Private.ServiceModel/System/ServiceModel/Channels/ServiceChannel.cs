using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal sealed class ServiceChannel : CommunicationObject, IChannel, ICommunicationObject, IClientChannel, IContextChannel, IExtensibleObject<IContextChannel>, IDisposable, IDuplexContextChannel, IOutputChannel, IRequestChannel, IServiceChannel, IAsyncDisposable
{
	internal class SendAsyncResult : TraceAsyncResult
	{
		private readonly bool _isOneWay;

		private readonly ProxyOperationRuntime _operation;

		internal ProxyRpc Rpc;

		private OperationContext _operationContext;

		private static AsyncCallback s_ensureInteractiveInitCallback = Fx.ThunkCallback(EnsureInteractiveInitCallback);

		private static AsyncCallback s_ensureOpenCallback = Fx.ThunkCallback(EnsureOpenCallback);

		private static AsyncCallback s_sendCallback = Fx.ThunkCallback(SendCallback);

		internal SendAsyncResult(ServiceChannel channel, ProxyOperationRuntime operation, string action, object[] inputParameters, bool isOneWay, TimeSpan timeout, AsyncCallback userCallback, object userState)
			: base(userCallback, userState)
		{
			Rpc = new ProxyRpc(channel, operation, action, inputParameters, timeout);
			_isOneWay = isOneWay;
			_operation = operation;
			_operationContext = OperationContext.Current;
		}

		internal void Begin()
		{
			Rpc.Channel.PrepareCall(_operation, _isOneWay, ref Rpc);
			if (Rpc.Channel._explicitlyOpened)
			{
				Rpc.Channel.ThrowIfOpening();
				Rpc.Channel.ThrowIfDisposedOrNotOpen();
				StartSend(completedSynchronously: true);
			}
			else
			{
				StartEnsureInteractiveInit();
			}
		}

		private void StartEnsureInteractiveInit()
		{
			IAsyncResult asyncResult = Rpc.Channel.BeginEnsureDisplayUI(s_ensureInteractiveInitCallback, this);
			if (asyncResult.CompletedSynchronously)
			{
				FinishEnsureInteractiveInit(asyncResult, completedSynchronously: true);
			}
		}

		private static void EnsureInteractiveInitCallback(IAsyncResult result)
		{
			if (!result.CompletedSynchronously)
			{
				((SendAsyncResult)result.AsyncState).FinishEnsureInteractiveInit(result, completedSynchronously: false);
			}
		}

		private void FinishEnsureInteractiveInit(IAsyncResult result, bool completedSynchronously)
		{
			Exception ex = null;
			try
			{
				Rpc.Channel.EndEnsureDisplayUI(result);
			}
			catch (Exception ex2)
			{
				if (Fx.IsFatal(ex2) || completedSynchronously)
				{
					throw;
				}
				ex = ex2;
			}
			if (ex != null)
			{
				CallComplete(completedSynchronously, ex);
			}
			else
			{
				StartEnsureOpen(completedSynchronously);
			}
		}

		private void StartEnsureOpen(bool completedSynchronously)
		{
			TimeSpan timeout = Rpc.TimeoutHelper.RemainingTime();
			IAsyncResult asyncResult = null;
			Exception ex = null;
			try
			{
				asyncResult = Rpc.Channel.BeginEnsureOpened(timeout, s_ensureOpenCallback, this);
			}
			catch (Exception ex2)
			{
				if (Fx.IsFatal(ex2) || completedSynchronously)
				{
					throw;
				}
				ex = ex2;
			}
			if (ex != null)
			{
				CallComplete(completedSynchronously, ex);
			}
			else if (asyncResult.CompletedSynchronously)
			{
				FinishEnsureOpen(asyncResult, completedSynchronously);
			}
		}

		private static void EnsureOpenCallback(IAsyncResult result)
		{
			if (!result.CompletedSynchronously)
			{
				((SendAsyncResult)result.AsyncState).FinishEnsureOpen(result, completedSynchronously: false);
			}
		}

		private void FinishEnsureOpen(IAsyncResult result, bool completedSynchronously)
		{
			Exception ex = null;
			using (ServiceModelActivity.BoundOperation(Rpc.Activity))
			{
				try
				{
					Rpc.Channel.EndEnsureOpened(result);
				}
				catch (Exception ex2)
				{
					if (Fx.IsFatal(ex2) || completedSynchronously)
					{
						throw;
					}
					ex = ex2;
				}
				if (ex != null)
				{
					CallComplete(completedSynchronously, ex);
				}
				else
				{
					StartSend(completedSynchronously);
				}
			}
		}

		private void StartSend(bool completedSynchronously)
		{
			TimeSpan timeout = Rpc.TimeoutHelper.RemainingTime();
			IAsyncResult asyncResult = null;
			Exception ex = null;
			try
			{
				ConcurrencyBehavior.UnlockInstanceBeforeCallout(_operationContext);
				asyncResult = ((!_isOneWay) ? Rpc.Channel.Binder.BeginRequest(Rpc.Request, timeout, s_sendCallback, this) : Rpc.Channel.Binder.BeginSend(Rpc.Request, timeout, s_sendCallback, this));
			}
			catch (Exception ex2)
			{
				if (Fx.IsFatal(ex2))
				{
					throw;
				}
				if (completedSynchronously)
				{
					ConcurrencyBehavior.LockInstanceAfterCallout(_operationContext);
					throw;
				}
				ex = ex2;
			}
			finally
			{
				CallOnceManager.SignalNextIfNonNull(Rpc.Channel._autoOpenManager);
			}
			if (ex != null)
			{
				CallComplete(completedSynchronously, ex);
			}
			else if (asyncResult.CompletedSynchronously)
			{
				FinishSend(asyncResult, completedSynchronously);
			}
		}

		private static void SendCallback(IAsyncResult result)
		{
			if (!result.CompletedSynchronously)
			{
				((SendAsyncResult)result.AsyncState).FinishSend(result, completedSynchronously: false);
			}
		}

		private void FinishSend(IAsyncResult result, bool completedSynchronously)
		{
			Exception exception = null;
			try
			{
				if (_isOneWay)
				{
					Rpc.Channel.Binder.EndSend(result);
				}
				else
				{
					Rpc.Reply = Rpc.Channel.Binder.EndRequest(result);
					if (Rpc.Reply == null)
					{
						Rpc.Channel.ThrowIfFaulted();
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.SFxServerDidNotReply));
					}
				}
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (completedSynchronously)
				{
					ConcurrencyBehavior.LockInstanceAfterCallout(_operationContext);
					throw;
				}
				exception = ex;
			}
			CallComplete(completedSynchronously, exception);
		}

		private void CallComplete(bool completedSynchronously, Exception exception)
		{
			Rpc.Channel.CompletedIOOperation();
			Complete(completedSynchronously, exception);
		}

		public static void End(SendAsyncResult result)
		{
			try
			{
				AsyncResult.End<SendAsyncResult>(result);
			}
			finally
			{
				ConcurrencyBehavior.LockInstanceAfterCallout(result._operationContext);
			}
		}
	}

	internal interface ICallOnce
	{
		void Call(ServiceChannel channel, TimeSpan timeout);

		IAsyncResult BeginCall(ServiceChannel channel, TimeSpan timeout, AsyncCallback callback, object state);

		void EndCall(ServiceChannel channel, IAsyncResult result);
	}

	internal class CallDisplayUIOnce : ICallOnce
	{
		private static CallDisplayUIOnce s_instance;

		internal static CallDisplayUIOnce Instance
		{
			get
			{
				if (s_instance == null)
				{
					s_instance = new CallDisplayUIOnce();
				}
				return s_instance;
			}
		}

		[Conditional("DEBUG")]
		private void ValidateTimeoutIsMaxValue(TimeSpan timeout)
		{
			_ = timeout != TimeSpan.MaxValue;
		}

		void ICallOnce.Call(ServiceChannel channel, TimeSpan timeout)
		{
			channel.DisplayInitializationUI();
		}

		IAsyncResult ICallOnce.BeginCall(ServiceChannel channel, TimeSpan timeout, AsyncCallback callback, object state)
		{
			return channel.BeginDisplayInitializationUI(callback, state);
		}

		void ICallOnce.EndCall(ServiceChannel channel, IAsyncResult result)
		{
			channel.EndDisplayInitializationUI(result);
		}
	}

	internal class CallOpenOnce : ICallOnce
	{
		private static CallOpenOnce s_instance;

		internal static CallOpenOnce Instance
		{
			get
			{
				if (s_instance == null)
				{
					s_instance = new CallOpenOnce();
				}
				return s_instance;
			}
		}

		void ICallOnce.Call(ServiceChannel channel, TimeSpan timeout)
		{
			channel.Open(timeout);
		}

		IAsyncResult ICallOnce.BeginCall(ServiceChannel channel, TimeSpan timeout, AsyncCallback callback, object state)
		{
			return channel.BeginOpen(timeout, callback, state);
		}

		void ICallOnce.EndCall(ServiceChannel channel, IAsyncResult result)
		{
			channel.EndOpen(result);
		}
	}

	internal class CallOnceManager
	{
		private interface IWaiter
		{
			void Signal();
		}

		internal class SyncWaiter : IWaiter
		{
			private ManualResetEvent _wait = new ManualResetEvent(initialState: false);

			private CallOnceManager _manager;

			private bool _isTimedOut;

			private bool _isSignaled;

			private int _waitCount;

			private bool ShouldSignalNext
			{
				get
				{
					if (_isTimedOut || !_manager.ChannelIsAvailable)
					{
						return _isSignaled;
					}
					return false;
				}
			}

			internal SyncWaiter(CallOnceManager manager)
			{
				_manager = manager;
			}

			void IWaiter.Signal()
			{
				_wait.Set();
				CloseWaitHandle();
				bool shouldSignalNext;
				lock (_manager.ThisLock)
				{
					_isSignaled = true;
					shouldSignalNext = ShouldSignalNext;
				}
				if (shouldSignalNext)
				{
					_manager.SignalNext();
				}
			}

			internal bool Wait(TimeSpan timeout)
			{
				try
				{
					bool flag = !TimeoutHelper.WaitOne(_wait, timeout);
					if (flag || !_manager.ChannelIsAvailable)
					{
						bool shouldSignalNext;
						lock (_manager.ThisLock)
						{
							_isTimedOut = flag;
							shouldSignalNext = ShouldSignalNext;
						}
						if (shouldSignalNext)
						{
							_manager.SignalNext();
						}
					}
				}
				finally
				{
					CloseWaitHandle();
				}
				return !_isTimedOut;
			}

			private void CloseWaitHandle()
			{
				if (Interlocked.Increment(ref _waitCount) == 2)
				{
					_wait.Dispose();
				}
			}
		}

		internal class AsyncWaiter : AsyncResult, IWaiter
		{
			private static TimerCallback s_timeoutCallback = Fx.ThunkCallback<object>(TimeoutCallback).Invoke;

			private CallOnceManager _manager;

			private TimeSpan _timeout;

			private Timer _timer;

			internal AsyncWaiter(CallOnceManager manager, TimeSpan timeout, AsyncCallback callback, object state)
				: base(callback, state)
			{
				_manager = manager;
				_timeout = timeout;
				if (timeout != TimeSpan.MaxValue)
				{
					_timer = new Timer(s_timeoutCallback, this, timeout, TimeSpan.FromMilliseconds(-1.0));
				}
			}

			internal static void End(IAsyncResult result)
			{
				AsyncResult.End<AsyncWaiter>(result);
			}

			void IWaiter.Signal()
			{
				if (_timer == null || _timer.Change(TimeSpan.FromMilliseconds(-1.0), TimeSpan.FromMilliseconds(-1.0)))
				{
					Complete(completedSynchronously: false);
					_manager._channel.Closed -= OnClosed;
				}
				else
				{
					_manager.SignalNext();
				}
			}

			private void OnClosed(object sender, EventArgs e)
			{
				if (_timer == null || _timer.Change(TimeSpan.FromMilliseconds(-1.0), TimeSpan.FromMilliseconds(-1.0)))
				{
					Complete(completedSynchronously: false, _manager._channel.CreateClosedException());
				}
			}

			private static void TimeoutCallback(object state)
			{
				AsyncWaiter asyncWaiter = (AsyncWaiter)state;
				asyncWaiter.Complete(completedSynchronously: false, asyncWaiter._manager._channel.GetOpenTimeoutException(asyncWaiter._timeout));
			}
		}

		private readonly ICallOnce _callOnce;

		private readonly ServiceChannel _channel;

		private bool _isFirst = true;

		private Queue<IWaiter> _queue;

		private static Action<object> s_signalWaiter = SignalWaiter;

		private object ThisLock => this;

		internal bool ChannelIsAvailable { get; private set; }

		internal CallOnceManager(ServiceChannel channel, ICallOnce callOnce)
		{
			_callOnce = callOnce;
			_channel = channel;
			_queue = new Queue<IWaiter>();
			ChannelIsAvailable = true;
			_channel.Closing += delegate
			{
				SetChannelUnavailable();
			};
			_channel.Faulted += delegate
			{
				SetChannelUnavailable();
			};
		}

		private void SetChannelUnavailable()
		{
			ChannelIsAvailable = false;
			SignalNext();
		}

		internal void CallOnce(TimeSpan timeout, CallOnceManager cascade)
		{
			SyncWaiter syncWaiter = null;
			bool flag = false;
			if (_queue != null)
			{
				lock (ThisLock)
				{
					if (_queue != null)
					{
						if (_isFirst)
						{
							flag = true;
							_isFirst = false;
						}
						else
						{
							syncWaiter = new SyncWaiter(this);
							_queue.Enqueue(syncWaiter);
						}
					}
				}
			}
			SignalNextIfNonNull(cascade);
			if (flag)
			{
				bool flag2 = true;
				try
				{
					_callOnce.Call(_channel, timeout);
					flag2 = false;
					return;
				}
				finally
				{
					if (flag2)
					{
						SignalNext();
					}
				}
			}
			syncWaiter?.Wait(timeout);
		}

		internal IAsyncResult BeginCallOnce(TimeSpan timeout, CallOnceManager cascade, AsyncCallback callback, object state)
		{
			AsyncWaiter asyncWaiter = null;
			bool flag = false;
			if (_queue != null)
			{
				lock (ThisLock)
				{
					if (_queue != null)
					{
						if (_isFirst)
						{
							flag = true;
							_isFirst = false;
						}
						else
						{
							asyncWaiter = new AsyncWaiter(this, timeout, callback, state);
							_queue.Enqueue(asyncWaiter);
						}
					}
				}
			}
			SignalNextIfNonNull(cascade);
			if (flag)
			{
				bool flag2 = true;
				try
				{
					IAsyncResult result = _callOnce.BeginCall(_channel, timeout, callback, state);
					flag2 = false;
					return result;
				}
				finally
				{
					if (flag2)
					{
						SignalNext();
					}
				}
			}
			if (asyncWaiter != null)
			{
				return asyncWaiter;
			}
			return new CallOnceCompletedAsyncResult(callback, state);
		}

		internal void EndCallOnce(IAsyncResult result)
		{
			if (result is CallOnceCompletedAsyncResult)
			{
				CallOnceCompletedAsyncResult.End(result);
				return;
			}
			if (result is AsyncWaiter)
			{
				AsyncWaiter.End(result);
				return;
			}
			bool flag = true;
			try
			{
				_callOnce.EndCall(_channel, result);
				flag = false;
			}
			finally
			{
				if (flag)
				{
					SignalNext();
				}
			}
		}

		internal static void SignalNextIfNonNull(CallOnceManager manager)
		{
			manager?.SignalNext();
		}

		internal void SignalNext()
		{
			if (_queue == null)
			{
				return;
			}
			IWaiter waiter = null;
			lock (ThisLock)
			{
				if (_queue != null)
				{
					if (_queue.Count > 0)
					{
						waiter = _queue.Dequeue();
					}
					else
					{
						_queue = null;
					}
				}
			}
			if (waiter != null)
			{
				ActionItem.Schedule(s_signalWaiter, waiter);
			}
		}

		private static void SignalWaiter(object state)
		{
			((IWaiter)state).Signal();
		}
	}

	private class CallOnceCompletedAsyncResult : AsyncResult
	{
		internal CallOnceCompletedAsyncResult(AsyncCallback callback, object state)
			: base(callback, state)
		{
			Complete(completedSynchronously: true);
		}

		internal static void End(IAsyncResult result)
		{
			AsyncResult.End<CallOnceCompletedAsyncResult>(result);
		}
	}

	internal class SessionIdleManager
	{
		private readonly IChannelBinder _binder;

		private ServiceChannel _channel;

		private readonly long _idleTicks;

		private long _lastActivity;

		private readonly Timer _timer;

		private static Action<object> s_timerCallback;

		private bool _didIdleAbort;

		private bool _isTimerCancelled;

		private object _thisLock;

		internal bool DidIdleAbort
		{
			get
			{
				lock (_thisLock)
				{
					return _didIdleAbort;
				}
			}
		}

		private SessionIdleManager(IChannelBinder binder, TimeSpan idle)
		{
			_binder = binder;
			_timer = new Timer(GetTimerCallback().Invoke, this, idle, TimeSpan.FromMilliseconds(-1.0));
			_idleTicks = Ticks.FromTimeSpan(idle);
			_thisLock = new object();
		}

		internal static SessionIdleManager CreateIfNeeded(IChannelBinder binder, TimeSpan idle)
		{
			if (binder.HasSession && idle != TimeSpan.MaxValue)
			{
				return new SessionIdleManager(binder, idle);
			}
			return null;
		}

		internal void CancelTimer()
		{
			lock (_thisLock)
			{
				_isTimerCancelled = true;
				_timer.Change(TimeSpan.FromMilliseconds(-1.0), TimeSpan.FromMilliseconds(-1.0));
			}
		}

		internal void CompletedActivity()
		{
			Interlocked.Exchange(ref _lastActivity, Ticks.Now);
		}

		internal void RegisterChannel(ServiceChannel channel, out bool didIdleAbort)
		{
			lock (_thisLock)
			{
				_channel = channel;
				didIdleAbort = _didIdleAbort;
			}
		}

		private static Action<object> GetTimerCallback()
		{
			if (s_timerCallback == null)
			{
				s_timerCallback = TimerCallback;
			}
			return s_timerCallback;
		}

		private static void TimerCallback(object state)
		{
			((SessionIdleManager)state).TimerCallback();
		}

		private void TimerCallback()
		{
			long num = Interlocked.CompareExchange(ref _lastActivity, 0L, 0L);
			long num2 = num + _idleTicks;
			lock (_thisLock)
			{
				long now = Ticks.Now;
				if (now > num2)
				{
					if (WcfEventSource.Instance.SessionIdleTimeoutIsEnabled())
					{
						string remoteAddress = string.Empty;
						if (_binder.ListenUri != null)
						{
							remoteAddress = _binder.ListenUri.AbsoluteUri;
						}
						WcfEventSource.Instance.SessionIdleTimeout(remoteAddress);
					}
					_didIdleAbort = true;
					if (_channel != null)
					{
						_channel.Abort();
					}
					else
					{
						_binder.Abort();
					}
				}
				else if (!_isTimerCancelled && _binder.Channel.State != CommunicationState.Faulted && _binder.Channel.State != CommunicationState.Closed)
				{
					_timer.Change(Ticks.ToTimeSpan(num2 - now), TimeSpan.FromMilliseconds(-1.0));
				}
			}
		}
	}

	private int _activityCount;

	private bool _allowInitializationUI = true;

	private bool _allowOutputBatching;

	private bool _autoClose = true;

	private CallOnceManager _autoDisplayUIManager;

	private CallOnceManager _autoOpenManager;

	private readonly ChannelDispatcher _channelDispatcher;

	private readonly bool _closeBinder = true;

	private bool _didInteractiveInitialization;

	private bool _doneReceiving;

	private EndpointDispatcher _endpointDispatcher;

	private bool _explicitlyOpened;

	private ExtensionCollection<IContextChannel> _extensions;

	private readonly SessionIdleManager _idleManager;

	private EndpointAddress _localAddress;

	private readonly bool _openBinder;

	private TimeSpan _operationTimeout;

	private object _proxy;

	private string _terminatingOperationName;

	private bool _hasChannelStartedAutoClosing;

	private bool _hasCleanedUpChannelCollections;

	private EventTraceActivity _eventActivity;

	private EventHandler<UnknownMessageReceivedEventArgs> _unknownMessageReceived;

	private CallOnceManager AutoOpenManager
	{
		get
		{
			if (!_explicitlyOpened && _autoOpenManager == null)
			{
				EnsureAutoOpenManagers();
			}
			return _autoOpenManager;
		}
	}

	private CallOnceManager AutoDisplayUIManager
	{
		get
		{
			if (!_explicitlyOpened && _autoDisplayUIManager == null)
			{
				EnsureAutoOpenManagers();
			}
			return _autoDisplayUIManager;
		}
	}

	internal EventTraceActivity EventActivity
	{
		get
		{
			if (_eventActivity == null)
			{
				_eventActivity = EventTraceActivity.GetFromThreadOrCreate();
			}
			return _eventActivity;
		}
	}

	internal bool CloseFactory { get; set; }

	protected override TimeSpan DefaultCloseTimeout => CloseTimeout;

	protected override TimeSpan DefaultOpenTimeout => OpenTimeout;

	internal DispatchRuntime DispatchRuntime
	{
		get
		{
			if (_endpointDispatcher != null)
			{
				return _endpointDispatcher.DispatchRuntime;
			}
			if (ClientRuntime != null)
			{
				return ClientRuntime.DispatchRuntime;
			}
			return null;
		}
	}

	internal MessageVersion MessageVersion { get; }

	internal IChannelBinder Binder { get; }

	internal TimeSpan CloseTimeout
	{
		get
		{
			if (IsClient)
			{
				return Factory.InternalCloseTimeout;
			}
			return ChannelDispatcher.InternalCloseTimeout;
		}
	}

	internal ChannelDispatcher ChannelDispatcher => _channelDispatcher;

	internal EndpointDispatcher EndpointDispatcher
	{
		get
		{
			return _endpointDispatcher;
		}
		set
		{
			lock (base.ThisLock)
			{
				_endpointDispatcher = value;
				ClientRuntime = value.DispatchRuntime.CallbackClientRuntime;
			}
		}
	}

	internal ServiceChannelFactory Factory { get; }

	internal IChannel InnerChannel => Binder.Channel;

	internal bool IsPending { get; set; }

	internal bool HasSession { get; }

	internal bool IsClient => Factory != null;

	internal bool IsReplyChannel { get; }

	public Uri ListenUri => Binder.ListenUri;

	public EndpointAddress LocalAddress
	{
		get
		{
			if (_localAddress == null)
			{
				if (_endpointDispatcher != null)
				{
					_localAddress = _endpointDispatcher.EndpointAddress;
				}
				else
				{
					_localAddress = Binder.LocalAddress;
				}
			}
			return _localAddress;
		}
	}

	internal TimeSpan OpenTimeout
	{
		get
		{
			if (IsClient)
			{
				return Factory.InternalOpenTimeout;
			}
			return ChannelDispatcher.InternalOpenTimeout;
		}
	}

	public TimeSpan OperationTimeout
	{
		get
		{
			return _operationTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				string sFxTimeoutOutOfRange = System.SR.SFxTimeoutOutOfRange0;
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, sFxTimeoutOutOfRange));
			}
			if (TimeoutHelper.IsTooLarge(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRangeTooBig));
			}
			_operationTimeout = value;
		}
	}

	internal object Proxy
	{
		get
		{
			object proxy = _proxy;
			if (proxy != null)
			{
				return proxy;
			}
			return this;
		}
		set
		{
			_proxy = value;
			base.EventSender = value;
		}
	}

	internal ClientRuntime ClientRuntime { get; private set; }

	public EndpointAddress RemoteAddress
	{
		get
		{
			if (InnerChannel is IOutputChannel outputChannel)
			{
				return outputChannel.RemoteAddress;
			}
			if (InnerChannel is IRequestChannel requestChannel)
			{
				return requestChannel.RemoteAddress;
			}
			return null;
		}
	}

	private ProxyOperationRuntime UnhandledProxyOperation => ClientRuntime.GetRuntime().UnhandledProxyOperation;

	public Uri Via
	{
		get
		{
			if (InnerChannel is IOutputChannel outputChannel)
			{
				return outputChannel.Via;
			}
			if (InnerChannel is IRequestChannel requestChannel)
			{
				return requestChannel.Via;
			}
			return null;
		}
	}

	internal InstanceContext InstanceContext { get; set; }

	bool IDuplexContextChannel.AutomaticInputSessionShutdown
	{
		get
		{
			return _autoClose;
		}
		set
		{
			_autoClose = value;
		}
	}

	bool IClientChannel.AllowInitializationUI
	{
		get
		{
			return _allowInitializationUI;
		}
		set
		{
			ThrowIfDisposedOrImmutable();
			_allowInitializationUI = value;
		}
	}

	bool IContextChannel.AllowOutputBatching
	{
		get
		{
			return _allowOutputBatching;
		}
		set
		{
			_allowOutputBatching = value;
		}
	}

	bool IClientChannel.DidInteractiveInitialization => _didInteractiveInitialization;

	IExtensionCollection<IContextChannel> IExtensibleObject<IContextChannel>.Extensions
	{
		get
		{
			lock (base.ThisLock)
			{
				if (_extensions == null)
				{
					_extensions = new ExtensionCollection<IContextChannel>((IContextChannel)Proxy, base.ThisLock);
				}
				return _extensions;
			}
		}
	}

	InstanceContext IDuplexContextChannel.CallbackInstance
	{
		get
		{
			return InstanceContext;
		}
		set
		{
			lock (base.ThisLock)
			{
				if (InstanceContext != null)
				{
					InstanceContext.OutgoingChannels.Remove((IChannel)_proxy);
				}
				InstanceContext = value;
				if (InstanceContext != null)
				{
					InstanceContext.OutgoingChannels.Add((IChannel)_proxy);
				}
			}
		}
	}

	IInputSession IContextChannel.InputSession
	{
		get
		{
			if (InnerChannel != null)
			{
				if (InnerChannel is ISessionChannel<IInputSession> sessionChannel)
				{
					return sessionChannel.Session;
				}
				if (InnerChannel is ISessionChannel<IDuplexSession> sessionChannel2)
				{
					return sessionChannel2.Session;
				}
			}
			return null;
		}
	}

	IOutputSession IContextChannel.OutputSession
	{
		get
		{
			if (InnerChannel != null)
			{
				if (InnerChannel is ISessionChannel<IOutputSession> sessionChannel)
				{
					return sessionChannel.Session;
				}
				if (InnerChannel is ISessionChannel<IDuplexSession> sessionChannel2)
				{
					return sessionChannel2.Session;
				}
			}
			return null;
		}
	}

	string IContextChannel.SessionId
	{
		get
		{
			if (InnerChannel != null)
			{
				if (InnerChannel is ISessionChannel<IInputSession> sessionChannel)
				{
					return sessionChannel.Session.Id;
				}
				if (InnerChannel is ISessionChannel<IOutputSession> sessionChannel2)
				{
					return sessionChannel2.Session.Id;
				}
				if (InnerChannel is ISessionChannel<IDuplexSession> sessionChannel3)
				{
					return sessionChannel3.Session.Id;
				}
			}
			return null;
		}
	}

	event EventHandler<UnknownMessageReceivedEventArgs> IClientChannel.UnknownMessageReceived
	{
		add
		{
			lock (base.ThisLock)
			{
				_unknownMessageReceived = (EventHandler<UnknownMessageReceivedEventArgs>)Delegate.Combine(_unknownMessageReceived, value);
			}
		}
		remove
		{
			lock (base.ThisLock)
			{
				_unknownMessageReceived = (EventHandler<UnknownMessageReceivedEventArgs>)Delegate.Remove(_unknownMessageReceived, value);
			}
		}
	}

	private ServiceChannel(IChannelBinder binder, MessageVersion messageVersion, IDefaultCommunicationTimeouts timeouts)
	{
		MessageVersion = messageVersion;
		Binder = binder ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("binder");
		IsReplyChannel = Binder.Channel is IReplyChannel;
		IChannel channel = binder.Channel;
		HasSession = channel is ISessionChannel<IDuplexSession> || channel is ISessionChannel<IInputSession> || channel is ISessionChannel<IOutputSession>;
		IncrementActivity();
		_openBinder = binder.Channel.State == CommunicationState.Created;
		_operationTimeout = timeouts.SendTimeout;
	}

	internal ServiceChannel(ServiceChannelFactory factory, IChannelBinder binder)
		: this(binder, factory.MessageVersion, factory)
	{
		Factory = factory;
		ClientRuntime = factory.ClientRuntime;
		SetupInnerChannelFaultHandler();
		DispatchRuntime dispatchRuntime = factory.ClientRuntime.DispatchRuntime;
		if (dispatchRuntime != null)
		{
			_autoClose = dispatchRuntime.AutomaticInputSessionShutdown;
		}
		factory.ChannelCreated(this);
	}

	internal ServiceChannel(IChannelBinder binder, EndpointDispatcher endpointDispatcher, ChannelDispatcher channelDispatcher, SessionIdleManager idleManager)
		: this(binder, channelDispatcher.MessageVersion, channelDispatcher.DefaultCommunicationTimeouts)
	{
		_channelDispatcher = channelDispatcher;
		_endpointDispatcher = endpointDispatcher ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("endpointDispatcher");
		ClientRuntime = endpointDispatcher.DispatchRuntime.CallbackClientRuntime;
		SetupInnerChannelFaultHandler();
		_autoClose = endpointDispatcher.DispatchRuntime.AutomaticInputSessionShutdown;
		IsPending = true;
		IDefaultCommunicationTimeouts defaultCommunicationTimeouts = channelDispatcher.DefaultCommunicationTimeouts;
		_idleManager = idleManager;
		if (!binder.HasSession)
		{
			_closeBinder = false;
		}
		if (_idleManager != null)
		{
			_idleManager.RegisterChannel(this, out var didIdleAbort);
			if (didIdleAbort)
			{
				Abort();
			}
		}
	}

	private void SetupInnerChannelFaultHandler()
	{
		Binder.Channel.Faulted += OnInnerChannelFaulted;
	}

	private void BindDuplexCallbacks()
	{
		if (InnerChannel is IDuplexChannel && Factory != null && InstanceContext != null && Binder is DuplexChannelBinder)
		{
			((DuplexChannelBinder)Binder).EnsurePumping();
		}
	}

	internal bool CanCastTo(Type t)
	{
		if (t.IsAssignableFrom(typeof(IClientChannel)))
		{
			return true;
		}
		if (t.IsAssignableFrom(typeof(IDuplexContextChannel)))
		{
			return InnerChannel is IDuplexChannel;
		}
		if (t.IsAssignableFrom(typeof(IServiceChannel)))
		{
			return true;
		}
		return false;
	}

	internal void CompletedIOOperation()
	{
		if (_idleManager != null)
		{
			_idleManager.CompletedActivity();
		}
	}

	private void EnsureAutoOpenManagers()
	{
		lock (base.ThisLock)
		{
			if (!_explicitlyOpened)
			{
				if (_autoOpenManager == null)
				{
					_autoOpenManager = new CallOnceManager(this, CallOpenOnce.Instance);
				}
				if (_autoDisplayUIManager == null)
				{
					_autoDisplayUIManager = new CallOnceManager(this, CallDisplayUIOnce.Instance);
				}
			}
		}
	}

	private void EnsureDisplayUI()
	{
		AutoDisplayUIManager?.CallOnce(TimeSpan.MaxValue, null);
		ThrowIfInitializationUINotCalled();
	}

	private IAsyncResult BeginEnsureDisplayUI(AsyncCallback callback, object state)
	{
		CallOnceManager autoDisplayUIManager = AutoDisplayUIManager;
		if (autoDisplayUIManager != null)
		{
			return autoDisplayUIManager.BeginCallOnce(TimeSpan.MaxValue, null, callback, state);
		}
		return new CallOnceCompletedAsyncResult(callback, state);
	}

	private void EndEnsureDisplayUI(IAsyncResult result)
	{
		CallOnceManager autoDisplayUIManager = AutoDisplayUIManager;
		if (autoDisplayUIManager != null)
		{
			autoDisplayUIManager.EndCallOnce(result);
		}
		else
		{
			CallOnceCompletedAsyncResult.End(result);
		}
		ThrowIfInitializationUINotCalled();
	}

	private void EnsureOpened(TimeSpan timeout)
	{
		AutoOpenManager?.CallOnce(timeout, _autoDisplayUIManager);
		ThrowIfOpening();
		ThrowIfDisposedOrNotOpen();
	}

	private IAsyncResult BeginEnsureOpened(TimeSpan timeout, AsyncCallback callback, object state)
	{
		CallOnceManager autoOpenManager = AutoOpenManager;
		if (autoOpenManager != null)
		{
			return autoOpenManager.BeginCallOnce(timeout, _autoDisplayUIManager, callback, state);
		}
		ThrowIfOpening();
		ThrowIfDisposedOrNotOpen();
		return new CallOnceCompletedAsyncResult(callback, state);
	}

	private void EndEnsureOpened(IAsyncResult result)
	{
		CallOnceManager autoOpenManager = AutoOpenManager;
		if (autoOpenManager != null)
		{
			autoOpenManager.EndCallOnce(result);
		}
		else
		{
			CallOnceCompletedAsyncResult.End(result);
		}
	}

	public T GetProperty<T>() where T : class
	{
		IChannel innerChannel = InnerChannel;
		if (innerChannel != null)
		{
			return innerChannel.GetProperty<T>();
		}
		return null;
	}

	private void PrepareCall(ProxyOperationRuntime operation, bool oneway, ref ProxyRpc rpc)
	{
		OperationContext current = OperationContext.Current;
		if (!oneway)
		{
			DispatchRuntime dispatchRuntime = ClientRuntime.DispatchRuntime;
			if (dispatchRuntime != null && dispatchRuntime.ConcurrencyMode == ConcurrencyMode.Single && current != null && !current.IsUserContext && current.InternalServiceChannel == this)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxCallbackRequestReplyInOrder1, typeof(CallbackBehaviorAttribute).Name)));
			}
		}
		if (base.State == CommunicationState.Created && !operation.IsInitiating)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxNonInitiatingOperation1, operation.Name)));
		}
		if (_terminatingOperationName != null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxTerminatingOperationAlreadyCalled1, _terminatingOperationName)));
		}
		if (_hasChannelStartedAutoClosing)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.SFxClientOutputSessionAutoClosed));
		}
		operation.BeforeRequest(ref rpc);
		AddMessageProperties(rpc.Request, current);
		if (!oneway && !ClientRuntime.ManualAddressing && rpc.Request.Version.Addressing != AddressingVersion.None)
		{
			RequestReplyCorrelator.PrepareRequest(rpc.Request);
			MessageHeaders headers = rpc.Request.Headers;
			EndpointAddress localAddress = LocalAddress;
			EndpointAddress replyTo = headers.ReplyTo;
			if (replyTo == null)
			{
				headers.ReplyTo = localAddress ?? EndpointAddress.AnonymousAddress;
			}
			if (IsClient && localAddress != null && !localAddress.IsAnonymous)
			{
				Uri uri = localAddress.Uri;
				if (replyTo != null && !replyTo.IsAnonymous && uri != replyTo.Uri)
				{
					string message = System.SR.Format(System.SR.SFxRequestHasInvalidReplyToOnClient, replyTo.Uri, uri);
					Exception exception = new InvalidOperationException(message);
					throw TraceUtility.ThrowHelperError(exception, rpc.Request);
				}
				EndpointAddress faultTo = headers.FaultTo;
				if (faultTo != null && !faultTo.IsAnonymous && uri != faultTo.Uri)
				{
					string message2 = System.SR.Format(System.SR.SFxRequestHasInvalidFaultToOnClient, faultTo.Uri, uri);
					Exception exception2 = new InvalidOperationException(message2);
					throw TraceUtility.ThrowHelperError(exception2, rpc.Request);
				}
				if (MessageVersion.Addressing == AddressingVersion.WSAddressingAugust2004)
				{
					EndpointAddress endpointAddress = headers.From;
					if (endpointAddress != null && !endpointAddress.IsAnonymous && uri != endpointAddress.Uri)
					{
						string message3 = System.SR.Format(System.SR.SFxRequestHasInvalidFromOnClient, endpointAddress.Uri, uri);
						Exception exception3 = new InvalidOperationException(message3);
						throw TraceUtility.ThrowHelperError(exception3, rpc.Request);
					}
				}
			}
		}
		_ = TraceUtility.MessageFlowTracingOnly;
		if (rpc.Activity != null)
		{
			TraceUtility.SetActivity(rpc.Request, rpc.Activity);
			if (TraceUtility.ShouldPropagateActivity)
			{
				TraceUtility.AddActivityHeader(rpc.Request);
			}
		}
		else if (TraceUtility.PropagateUserActivity || TraceUtility.ShouldPropagateActivity)
		{
			TraceUtility.AddAmbientActivityToMessage(rpc.Request);
		}
		operation.Parent.BeforeSendRequest(ref rpc);
		if (FxTrace.Trace.IsEnd2EndActivityTracingEnabled)
		{
			TraceClientOperationPrepared(ref rpc);
		}
		TraceUtility.MessageFlowAtMessageSent(rpc.Request, rpc.EventTraceActivity);
		if (MessageLogger.LogMessagesAtServiceLevel)
		{
			MessageLogger.LogMessage(ref rpc.Request, (MessageLoggingSource)((oneway ? 32 : 128) | 0x800));
		}
	}

	private void TraceClientOperationPrepared(ref ProxyRpc rpc)
	{
		Guid relatedActivityId = ((rpc.EventTraceActivity != null) ? rpc.EventTraceActivity.ActivityId : Guid.Empty);
		EventTraceActivity eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(rpc.Request);
		if (eventTraceActivity == null)
		{
			eventTraceActivity = EventTraceActivity.GetFromThreadOrCreate();
			EventTraceActivityHelper.TryAttachActivity(rpc.Request, eventTraceActivity);
		}
		rpc.EventTraceActivity = eventTraceActivity;
		if (WcfEventSource.Instance.ClientOperationPreparedIsEnabled())
		{
			string destination = string.Empty;
			if (RemoteAddress != null && RemoteAddress.Uri != null)
			{
				destination = RemoteAddress.Uri.AbsoluteUri;
			}
			WcfEventSource.Instance.ClientOperationPrepared(rpc.EventTraceActivity, rpc.Action, ClientRuntime.ContractName, destination, relatedActivityId);
		}
	}

	internal static IAsyncResult BeginCall(ServiceChannel channel, ProxyOperationRuntime operation, object[] ins, AsyncCallback callback, object asyncState)
	{
		return channel.BeginCall(operation.Action, operation.IsOneWay, operation, ins, channel._operationTimeout, callback, asyncState);
	}

	internal IAsyncResult BeginCall(string action, bool oneway, ProxyOperationRuntime operation, object[] ins, AsyncCallback callback, object asyncState)
	{
		return BeginCall(action, oneway, operation, ins, _operationTimeout, callback, asyncState);
	}

	internal IAsyncResult BeginCall(string action, bool oneway, ProxyOperationRuntime operation, object[] ins, TimeSpan timeout, AsyncCallback callback, object asyncState)
	{
		ThrowIfDisallowedInitializationUI();
		ThrowIfIdleAborted(operation);
		ThrowIfIsConnectionOpened(operation);
		ServiceModelActivity activity = null;
		if (DiagnosticUtility.ShouldUseActivity)
		{
			activity = ServiceModelActivity.CreateActivity(autoStop: true);
			callback = TraceUtility.WrapExecuteUserCodeAsyncCallback(callback);
		}
		using (ServiceModelActivity.BoundOperation(activity, addTransfer: true))
		{
			if (DiagnosticUtility.ShouldUseActivity)
			{
				ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityProcessAction, action), ActivityType.ProcessAction);
			}
			SendAsyncResult sendAsyncResult = new SendAsyncResult(this, operation, action, ins, oneway, timeout, callback, asyncState);
			if (DiagnosticUtility.ShouldUseActivity)
			{
				sendAsyncResult.Rpc.Activity = activity;
			}
			TraceServiceChannelCallStart(sendAsyncResult.Rpc.EventTraceActivity, isSynchronous: false);
			sendAsyncResult.Begin();
			return sendAsyncResult;
		}
	}

	internal object Call(string action, bool oneway, ProxyOperationRuntime operation, object[] ins, object[] outs)
	{
		return Call(action, oneway, operation, ins, outs, _operationTimeout);
	}

	internal object Call(string action, bool oneway, ProxyOperationRuntime operation, object[] ins, object[] outs, TimeSpan timeout)
	{
		ThrowIfDisallowedInitializationUI();
		ThrowIfIdleAborted(operation);
		ThrowIfIsConnectionOpened(operation);
		ProxyRpc rpc = new ProxyRpc(this, operation, action, ins, timeout);
		TraceServiceChannelCallStart(rpc.EventTraceActivity, isSynchronous: true);
		using (rpc.Activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null))
		{
			if (DiagnosticUtility.ShouldUseActivity)
			{
				ServiceModelActivity.Start(rpc.Activity, System.SR.Format(System.SR.ActivityProcessAction, action), ActivityType.ProcessAction);
			}
			PrepareCall(operation, oneway, ref rpc);
			if (!_explicitlyOpened)
			{
				EnsureDisplayUI();
				EnsureOpened(rpc.TimeoutHelper.RemainingTime());
			}
			else
			{
				ThrowIfOpening();
				ThrowIfDisposedOrNotOpen();
			}
			try
			{
				ConcurrencyBehavior.UnlockInstanceBeforeCallout(OperationContext.Current);
				if (oneway)
				{
					Binder.Send(rpc.Request, rpc.TimeoutHelper.RemainingTime());
				}
				else
				{
					rpc.Reply = Binder.Request(rpc.Request, rpc.TimeoutHelper.RemainingTime());
					if (rpc.Reply == null)
					{
						ThrowIfFaulted();
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.SFxServerDidNotReply));
					}
				}
			}
			finally
			{
				CompletedIOOperation();
				CallOnceManager.SignalNextIfNonNull(_autoOpenManager);
				ConcurrencyBehavior.LockInstanceAfterCallout(OperationContext.Current);
			}
			rpc.OutputParameters = outs;
			HandleReply(operation, ref rpc);
		}
		return rpc.ReturnValue;
	}

	internal object EndCall(string action, object[] outs, IAsyncResult result)
	{
		if (!(result is SendAsyncResult sendAsyncResult))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.SFxInvalidCallbackIAsyncResult));
		}
		using ServiceModelActivity activity = sendAsyncResult.Rpc.Activity;
		using (ServiceModelActivity.BoundOperation(activity, addTransfer: true))
		{
			if (sendAsyncResult.Rpc.Activity != null && DiagnosticUtility.ShouldUseActivity)
			{
				sendAsyncResult.Rpc.Activity.Resume();
			}
			if (sendAsyncResult.Rpc.Channel != this)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("result", System.SR.AsyncEndCalledOnWrongChannel);
			}
			if (action != "*" && action != sendAsyncResult.Rpc.Action)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("result", System.SR.AsyncEndCalledWithAnIAsyncResult);
			}
			SendAsyncResult.End(sendAsyncResult);
			sendAsyncResult.Rpc.OutputParameters = outs;
			HandleReply(sendAsyncResult.Rpc.Operation, ref sendAsyncResult.Rpc);
			if (sendAsyncResult.Rpc.Activity != null)
			{
				sendAsyncResult.Rpc.Activity = null;
			}
			return sendAsyncResult.Rpc.ReturnValue;
		}
	}

	internal void DecrementActivity()
	{
		int num = Interlocked.Decrement(ref _activityCount);
		if (num < 0)
		{
			throw Fx.AssertAndThrowFatal("ServiceChannel.DecrementActivity: (updatedActivityCount >= 0)");
		}
		if (num != 0 || !_autoClose)
		{
			return;
		}
		try
		{
			if (base.State != CommunicationState.Opened)
			{
				return;
			}
			if (IsClient)
			{
				if (InnerChannel is ISessionChannel<IDuplexSession> sessionChannel)
				{
					_hasChannelStartedAutoClosing = true;
					sessionChannel.Session.CloseOutputSession(CloseTimeout);
				}
			}
			else
			{
				Close(CloseTimeout);
			}
		}
		catch (CommunicationException)
		{
		}
		catch (TimeoutException ex2)
		{
			if (WcfEventSource.Instance.CloseTimeoutIsEnabled())
			{
				WcfEventSource.Instance.CloseTimeout(ex2.Message);
			}
		}
		catch (ObjectDisposedException)
		{
		}
		catch (InvalidOperationException)
		{
		}
	}

	internal void FireUnknownMessageReceived(Message message)
	{
		_unknownMessageReceived?.Invoke(_proxy, new UnknownMessageReceivedEventArgs(message));
	}

	private TimeoutException GetOpenTimeoutException(TimeSpan timeout)
	{
		EndpointAddress endpointAddress = RemoteAddress ?? LocalAddress;
		if (endpointAddress != null)
		{
			return new TimeoutException(System.SR.Format(System.SR.TimeoutServiceChannelConcurrentOpen2, endpointAddress, timeout));
		}
		return new TimeoutException(System.SR.Format(System.SR.TimeoutServiceChannelConcurrentOpen1, timeout));
	}

	internal void HandleReceiveComplete(RequestContext context)
	{
		if (context == null && HasSession)
		{
			bool flag;
			lock (base.ThisLock)
			{
				flag = !_doneReceiving;
				_doneReceiving = true;
			}
			if (flag)
			{
				DispatchRuntime dispatchRuntime = ClientRuntime.DispatchRuntime;
				DecrementActivity();
			}
		}
	}

	private void HandleReply(ProxyOperationRuntime operation, ref ProxyRpc rpc)
	{
		try
		{
			if (TraceUtility.MessageFlowTracingOnly && rpc.ActivityId != Guid.Empty)
			{
				DiagnosticTraceBase.ActivityId = rpc.ActivityId;
			}
			if (rpc.Reply != null)
			{
				TraceUtility.MessageFlowAtMessageReceived(rpc.Reply, null, rpc.EventTraceActivity, createNewActivityId: false);
				if (MessageLogger.LogMessagesAtServiceLevel)
				{
					MessageLogger.LogMessage(ref rpc.Reply, MessageLoggingSource.ServiceLevelReceiveReply | MessageLoggingSource.LastChance);
				}
				operation.Parent.AfterReceiveReply(ref rpc);
				if (operation.ReplyAction != "*" && !rpc.Reply.IsFault && rpc.Reply.Headers.Action != null && string.CompareOrdinal(operation.ReplyAction, rpc.Reply.Headers.Action) != 0)
				{
					Exception exception = new ProtocolException(System.SR.Format(System.SR.SFxReplyActionMismatch3, operation.Name, rpc.Reply.Headers.Action, operation.ReplyAction));
					TerminateIfNecessary(ref rpc);
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
				}
				if (operation.DeserializeReply && ClientRuntime.IsFault(ref rpc.Reply))
				{
					MessageFault messageFault = MessageFault.CreateFault(rpc.Reply, ClientRuntime.MaxFaultSize);
					string text = rpc.Reply.Headers.Action;
					if (text == rpc.Reply.Version.Addressing.DefaultFaultAction)
					{
						text = null;
					}
					ThrowIfFaultUnderstood(rpc.Reply, messageFault, text, rpc.Reply.Version, rpc.Channel.GetProperty<FaultConverter>());
					FaultException exception2 = rpc.Operation.FaultFormatter.Deserialize(messageFault, text);
					TerminateIfNecessary(ref rpc);
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(exception2);
				}
				operation.AfterReply(ref rpc);
			}
		}
		finally
		{
			if (operation.SerializeRequest)
			{
				rpc.Request.Close();
			}
			OperationContext current = OperationContext.Current;
			bool flag = rpc.Reply != null && rpc.Reply.State != MessageState.Created;
			if (current != null && current.IsUserContext)
			{
				current.SetClientReply(rpc.Reply, flag);
			}
			else if (flag)
			{
				rpc.Reply.Close();
			}
			if (TraceUtility.MessageFlowTracingOnly && rpc.ActivityId != Guid.Empty)
			{
				DiagnosticTraceBase.ActivityId = Guid.Empty;
				rpc.ActivityId = Guid.Empty;
			}
		}
		TerminateIfNecessary(ref rpc);
		if (WcfEventSource.Instance.ServiceChannelCallStopIsEnabled())
		{
			string destination = string.Empty;
			if (RemoteAddress != null && RemoteAddress.Uri != null)
			{
				destination = RemoteAddress.Uri.AbsoluteUri;
			}
			WcfEventSource.Instance.ServiceChannelCallStop(rpc.EventTraceActivity, rpc.Action, ClientRuntime.ContractName, destination);
		}
	}

	private void TerminateIfNecessary(ref ProxyRpc rpc)
	{
		if (rpc.Operation.IsTerminating)
		{
			_terminatingOperationName = rpc.Operation.Name;
			TerminatingOperationBehavior.AfterReply(ref rpc);
		}
	}

	private void ThrowIfFaultUnderstood(Message reply, MessageFault fault, string action, MessageVersion version, FaultConverter faultConverter)
	{
		if (faultConverter != null && faultConverter.TryCreateException(reply, fault, out var exception))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(exception);
		}
		bool flag;
		bool flag2;
		FaultCode faultCode;
		if (version.Envelope == EnvelopeVersion.Soap11)
		{
			flag = true;
			flag2 = true;
			faultCode = fault.Code;
		}
		else
		{
			flag = fault.Code.IsSenderFault;
			flag2 = fault.Code.IsReceiverFault;
			faultCode = fault.Code.SubCode;
		}
		if (faultCode == null || faultCode.Namespace == null)
		{
			return;
		}
		if (flag)
		{
			if (string.Compare(faultCode.Namespace, "http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher", StringComparison.Ordinal) == 0 && string.Compare(faultCode.Name, "SessionTerminated", StringComparison.Ordinal) == 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new ChannelTerminatedException(fault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text));
			}
			if (string.Compare(faultCode.Namespace, SecurityVersion.Default.HeaderNamespace.Value, StringComparison.Ordinal) == 0 && string.Compare(faultCode.Name, SecurityVersion.Default.FailedAuthenticationFaultCode.Value, StringComparison.Ordinal) == 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new SecurityAccessDeniedException(fault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text));
			}
		}
		if (!flag2 || string.Compare(faultCode.Namespace, "http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher", StringComparison.Ordinal) != 0)
		{
			return;
		}
		if (string.Compare(faultCode.Name, "InternalServiceFault", StringComparison.Ordinal) == 0)
		{
			if (HasSession)
			{
				Fault();
			}
			if (fault.HasDetail)
			{
				ExceptionDetail detail = fault.GetDetail<ExceptionDetail>();
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new FaultException<ExceptionDetail>(detail, fault.Reason, fault.Code, action));
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new FaultException(fault, action));
		}
		if (string.Compare(faultCode.Name, "DeserializationFailed", StringComparison.Ordinal) != 0)
		{
			return;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new ProtocolException(fault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text));
	}

	private void ThrowIfIdleAborted(ProxyOperationRuntime operation)
	{
		if (_idleManager != null && _idleManager.DidIdleAbort)
		{
			string message = System.SR.Format(System.SR.SFxServiceChannelIdleAborted, operation.Name);
			Exception exception = new CommunicationObjectAbortedException(message);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
		}
	}

	private void ThrowIfIsConnectionOpened(ProxyOperationRuntime operation)
	{
		if (operation.IsSessionOpenNotificationEnabled)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxServiceChannelCannotBeCalledBecauseIsSessionOpenNotificationEnabled, operation.Name, "Action", "http://schemas.microsoft.com/2011/02/session/onopen", "Open")));
		}
	}

	private void ThrowIfInitializationUINotCalled()
	{
		if (!_didInteractiveInitialization && ClientRuntime.InteractiveChannelInitializers.Count > 0)
		{
			IInteractiveChannelInitializer interactiveChannelInitializer = ClientRuntime.InteractiveChannelInitializers[0];
			string message = System.SR.Format(System.SR.SFxInitializationUINotCalled, interactiveChannelInitializer.GetType().ToString());
			Exception exception = new InvalidOperationException(message);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
		}
	}

	private void ThrowIfDisallowedInitializationUI()
	{
		if (!_allowInitializationUI)
		{
			ThrowIfDisallowedInitializationUICore();
		}
	}

	private void ThrowIfDisallowedInitializationUICore()
	{
		if (ClientRuntime.InteractiveChannelInitializers.Count > 0)
		{
			IInteractiveChannelInitializer interactiveChannelInitializer = ClientRuntime.InteractiveChannelInitializers[0];
			string message = System.SR.Format(System.SR.SFxInitializationUIDisallowed, interactiveChannelInitializer.GetType().ToString());
			Exception exception = new InvalidOperationException(message);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
		}
	}

	private void ThrowIfOpening()
	{
		if (base.State == CommunicationState.Opening)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxCannotCallAutoOpenWhenExplicitOpenCalled));
		}
	}

	internal void IncrementActivity()
	{
		Interlocked.Increment(ref _activityCount);
	}

	private void OnInnerChannelFaulted(object sender, EventArgs e)
	{
		Fault();
		if (HasSession)
		{
			DispatchRuntime dispatchRuntime = ClientRuntime.DispatchRuntime;
		}
		if (_autoClose && !IsClient)
		{
			Abort();
		}
	}

	private void AddMessageProperties(Message message, OperationContext context)
	{
		if (_allowOutputBatching)
		{
			message.Properties.AllowOutputBatching = true;
		}
		if (context != null && context.InternalServiceChannel == this)
		{
			if (!context.OutgoingMessageVersion.IsMatch(message.Headers.MessageVersion))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxVersionMismatchInOperationContextAndMessage2, context.OutgoingMessageVersion, message.Headers.MessageVersion)));
			}
			if (context.HasOutgoingMessageHeaders)
			{
				message.Headers.CopyHeadersFrom(context.OutgoingMessageHeaders);
			}
			if (context.HasOutgoingMessageProperties)
			{
				message.Properties.CopyProperties(context.OutgoingMessageProperties);
			}
		}
	}

	public void Send(Message message)
	{
		Send(message, OperationTimeout);
	}

	public void Send(Message message, TimeSpan timeout)
	{
		ProxyOperationRuntime unhandledProxyOperation = UnhandledProxyOperation;
		Call(message.Headers.Action, oneway: true, unhandledProxyOperation, new object[1] { message }, Array.Empty<object>(), timeout);
	}

	public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
	{
		return BeginSend(message, OperationTimeout, callback, state);
	}

	public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		ProxyOperationRuntime unhandledProxyOperation = UnhandledProxyOperation;
		return BeginCall(message.Headers.Action, oneway: true, unhandledProxyOperation, new object[1] { message }, timeout, callback, state);
	}

	public void EndSend(IAsyncResult result)
	{
		EndCall("*", Array.Empty<object>(), result);
	}

	public Message Request(Message message)
	{
		return Request(message, OperationTimeout);
	}

	public Message Request(Message message, TimeSpan timeout)
	{
		ProxyOperationRuntime unhandledProxyOperation = UnhandledProxyOperation;
		return (Message)Call(message.Headers.Action, oneway: false, unhandledProxyOperation, new object[1] { message }, Array.Empty<object>(), timeout);
	}

	public IAsyncResult BeginRequest(Message message, AsyncCallback callback, object state)
	{
		return BeginRequest(message, OperationTimeout, callback, state);
	}

	public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		ProxyOperationRuntime unhandledProxyOperation = UnhandledProxyOperation;
		return BeginCall(message.Headers.Action, oneway: false, unhandledProxyOperation, new object[1] { message }, timeout, callback, state);
	}

	public Message EndRequest(IAsyncResult result)
	{
		return (Message)EndCall("*", Array.Empty<object>(), result);
	}

	protected override void OnAbort()
	{
		if (_idleManager != null)
		{
			_idleManager.CancelTimer();
		}
		Binder.Abort();
		if (Factory != null)
		{
			Factory.ChannelDisposed(this);
		}
		if (CloseFactory && Factory != null)
		{
			Factory.Abort();
		}
		CleanupChannelCollections();
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return CommunicationObjectInternal.OnBeginClose(this, timeout, callback, state);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		CommunicationObjectInternal.OnEnd(result);
	}

	protected override void OnClose(TimeSpan timeout)
	{
		CommunicationObjectInternal.OnClose(this, timeout);
	}

	protected internal override async Task OnCloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (_idleManager != null)
		{
			_idleManager.CancelTimer();
		}
		if (Factory != null)
		{
			Factory.ChannelDisposed(this);
		}
		if (_closeBinder)
		{
			await CloseOtherAsync(InnerChannel, timeoutHelper.RemainingTime());
		}
		if (CloseFactory)
		{
			await CloseOtherAsync(Factory, timeoutHelper.RemainingTime());
		}
		CleanupChannelCollections();
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return CommunicationObjectInternal.OnBeginOpen(this, timeout, callback, state);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		CommunicationObjectInternal.OnEnd(result);
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		CommunicationObjectInternal.OnOpen(this, timeout);
	}

	protected internal override async Task OnOpenAsync(TimeSpan timeout)
	{
		ThrowIfDisallowedInitializationUI();
		ThrowIfInitializationUINotCalled();
		if (_autoOpenManager == null)
		{
			_explicitlyOpened = true;
		}
		TraceChannelOpenStarted();
		if (_openBinder)
		{
			await OpenOtherAsync(InnerChannel, timeout);
		}
		BindDuplexCallbacks();
		CompletedIOOperation();
		TraceChannelOpenCompleted();
	}

	private void CleanupChannelCollections()
	{
		if (_hasCleanedUpChannelCollections)
		{
			return;
		}
		lock (base.ThisLock)
		{
			if (!_hasCleanedUpChannelCollections)
			{
				if (InstanceContext != null)
				{
					InstanceContext.OutgoingChannels.Remove((IChannel)_proxy);
				}
				_hasCleanedUpChannelCollections = true;
			}
		}
	}

	IAsyncResult IDuplexContextChannel.BeginCloseOutputSession(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return GetDuplexSessionOrThrow().BeginCloseOutputSession(timeout, callback, state);
	}

	void IDuplexContextChannel.EndCloseOutputSession(IAsyncResult result)
	{
		GetDuplexSessionOrThrow().EndCloseOutputSession(result);
	}

	void IDuplexContextChannel.CloseOutputSession(TimeSpan timeout)
	{
		GetDuplexSessionOrThrow().CloseOutputSession(timeout);
	}

	private IDuplexSession GetDuplexSessionOrThrow()
	{
		if (InnerChannel == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.channelIsNotAvailable0));
		}
		if (!(InnerChannel is ISessionChannel<IDuplexSession> sessionChannel))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.channelDoesNotHaveADuplexSession0));
		}
		return sessionChannel.Session;
	}

	public void DisplayInitializationUI()
	{
		ThrowIfDisallowedInitializationUI();
		if (_autoDisplayUIManager == null)
		{
			_explicitlyOpened = true;
		}
		ClientRuntime.GetRuntime().DisplayInitializationUI(this);
		_didInteractiveInitialization = true;
	}

	public IAsyncResult BeginDisplayInitializationUI(AsyncCallback callback, object state)
	{
		ThrowIfDisallowedInitializationUI();
		if (_autoDisplayUIManager == null)
		{
			_explicitlyOpened = true;
		}
		return ClientRuntime.GetRuntime().BeginDisplayInitializationUI(this, callback, state);
	}

	public void EndDisplayInitializationUI(IAsyncResult result)
	{
		ClientRuntime.GetRuntime().EndDisplayInitializationUI(result);
		_didInteractiveInitialization = true;
	}

	void IDisposable.Dispose()
	{
		Close();
	}

	async ValueTask IAsyncDisposable.DisposeAsync()
	{
		try
		{
			if (base.State == CommunicationState.Opened)
			{
				await ((IAsyncCommunicationObject)this).CloseAsync(DefaultCloseTimeout);
			}
			if (base.State != CommunicationState.Closed)
			{
				Abort();
			}
		}
		catch (CommunicationException)
		{
			Abort();
		}
		catch (TimeoutException)
		{
			Abort();
		}
	}

	private void TraceChannelOpenStarted()
	{
		if (WcfEventSource.Instance.ClientChannelOpenStartIsEnabled() && _endpointDispatcher == null)
		{
			WcfEventSource.Instance.ClientChannelOpenStart(EventActivity);
		}
		else if (WcfEventSource.Instance.ServiceChannelOpenStartIsEnabled())
		{
			WcfEventSource.Instance.ServiceChannelOpenStart(EventActivity);
		}
	}

	private void TraceChannelOpenCompleted()
	{
		if (_endpointDispatcher == null && WcfEventSource.Instance.ClientChannelOpenStopIsEnabled())
		{
			WcfEventSource.Instance.ClientChannelOpenStop(EventActivity);
		}
		else if (WcfEventSource.Instance.ServiceChannelOpenStopIsEnabled())
		{
			WcfEventSource.Instance.ServiceChannelOpenStop(EventActivity);
		}
	}

	private static void TraceServiceChannelCallStart(EventTraceActivity eventTraceActivity, bool isSynchronous)
	{
		if (WcfEventSource.Instance.ServiceChannelCallStartIsEnabled())
		{
			if (isSynchronous)
			{
				WcfEventSource.Instance.ServiceChannelCallStart(eventTraceActivity);
			}
			else
			{
				WcfEventSource.Instance.ServiceChannelBeginCallStart(eventTraceActivity);
			}
		}
	}
}

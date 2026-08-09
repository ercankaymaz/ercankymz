using System.Collections.Generic;
using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Dispatcher;

internal class DuplexChannelBinder : IChannelBinder
{
	internal class DuplexRequestContext : RequestContextBase
	{
		internal class ReplyAsyncResult : AsyncResult
		{
			private static AsyncCallback s_onSend;

			private DuplexRequestContext _context;

			public ReplyAsyncResult(DuplexRequestContext context, Message message, TimeSpan timeout, AsyncCallback callback, object state)
				: base(callback, state)
			{
				if (message != null)
				{
					if (s_onSend == null)
					{
						s_onSend = Fx.ThunkCallback(OnSend);
					}
					_context = context;
					IAsyncResult asyncResult = context._channel.BeginSend(message, timeout, s_onSend, this);
					if (!asyncResult.CompletedSynchronously)
					{
						return;
					}
					context._channel.EndSend(asyncResult);
				}
				Complete(completedSynchronously: true);
			}

			public static void End(IAsyncResult result)
			{
				AsyncResult.End<ReplyAsyncResult>(result);
			}

			private static void OnSend(IAsyncResult result)
			{
				if (result.CompletedSynchronously)
				{
					return;
				}
				Exception exception = null;
				ReplyAsyncResult replyAsyncResult = (ReplyAsyncResult)result.AsyncState;
				try
				{
					replyAsyncResult._context._channel.EndSend(result);
				}
				catch (Exception ex)
				{
					if (Fx.IsFatal(ex))
					{
						throw;
					}
					exception = ex;
				}
				replyAsyncResult.Complete(completedSynchronously: false, exception);
			}
		}

		private DuplexChannelBinder _binder;

		private IDuplexChannel _channel;

		internal DuplexRequestContext(IDuplexChannel channel, Message request, DuplexChannelBinder binder)
			: base(request, binder.DefaultCloseTimeout, binder.DefaultSendTimeout)
		{
			_channel = channel;
			_binder = binder;
		}

		protected override void OnAbort()
		{
		}

		protected override void OnClose(TimeSpan timeout)
		{
		}

		protected override void OnReply(Message message, TimeSpan timeout)
		{
			if (message != null)
			{
				_channel.Send(message, timeout);
			}
		}

		protected override IAsyncResult OnBeginReply(Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			return new ReplyAsyncResult(this, message, timeout, callback, state);
		}

		protected override void OnEndReply(IAsyncResult result)
		{
			ReplyAsyncResult.End(result);
		}
	}

	private interface IDuplexRequest
	{
		void Abort();

		void GotReply(Message reply);
	}

	internal class SyncDuplexRequest : IDuplexRequest, ICorrelatorKey
	{
		private Message _reply;

		private DuplexChannelBinder _parent;

		private ManualResetEvent _wait = new ManualResetEvent(initialState: false);

		private int _waitCount;

		private RequestReplyCorrelator.Key _requestCorrelatorKey;

		RequestReplyCorrelator.Key ICorrelatorKey.RequestCorrelatorKey
		{
			get
			{
				return _requestCorrelatorKey;
			}
			set
			{
				_requestCorrelatorKey = value;
			}
		}

		internal SyncDuplexRequest(DuplexChannelBinder parent)
		{
			_parent = parent;
		}

		public void Abort()
		{
			_wait.Set();
		}

		internal Message WaitForReply(TimeSpan timeout)
		{
			try
			{
				if (!TimeoutHelper.WaitOne(_wait, timeout))
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(_parent.GetReceiveTimeoutException(timeout));
				}
			}
			finally
			{
				CloseWaitHandle();
			}
			return _reply;
		}

		public void GotReply(Message reply)
		{
			lock (_parent.ThisLock)
			{
				_parent.RequestCompleting(this);
			}
			_reply = reply;
			_wait.Set();
			CloseWaitHandle();
		}

		private void CloseWaitHandle()
		{
			if (Interlocked.Increment(ref _waitCount) == 2)
			{
				_wait.Dispose();
			}
		}
	}

	internal class AsyncDuplexRequest : AsyncResult, IDuplexRequest, ICorrelatorKey
	{
		private static Action<object> s_timerCallback = TimerCallback;

		private bool _aborted;

		private bool _enableComplete;

		private bool _gotReply;

		private Exception _sendException;

		private IAsyncResult _sendResult;

		private DuplexChannelBinder _parent;

		private Message _reply;

		private bool _timedOut;

		private TimeSpan _timeout;

		private Timer _timer;

		private ServiceModelActivity _activity;

		private RequestReplyCorrelator.Key _requestCorrelatorKey;

		private bool IsDone
		{
			get
			{
				if (!_enableComplete)
				{
					return false;
				}
				if ((_sendResult == null || !_gotReply) && _sendException == null && !_timedOut)
				{
					return _aborted;
				}
				return true;
			}
		}

		RequestReplyCorrelator.Key ICorrelatorKey.RequestCorrelatorKey
		{
			get
			{
				return _requestCorrelatorKey;
			}
			set
			{
				_requestCorrelatorKey = value;
			}
		}

		internal AsyncDuplexRequest(Message message, DuplexChannelBinder parent, TimeSpan timeout, AsyncCallback callback, object state)
			: base(callback, state)
		{
			_parent = parent;
			_timeout = timeout;
			if (timeout != TimeSpan.MaxValue)
			{
				_timer = new Timer(s_timerCallback.Invoke, this, timeout, TimeSpan.FromMilliseconds(-1.0));
			}
			if (DiagnosticUtility.ShouldUseActivity)
			{
				_activity = TraceUtility.ExtractActivity(message);
			}
		}

		public void Abort()
		{
			bool flag;
			lock (_parent.ThisLock)
			{
				bool isDone = IsDone;
				_aborted = true;
				flag = !isDone && IsDone;
			}
			if (flag)
			{
				Done(completedSynchronously: false);
			}
		}

		private void Done(bool completedSynchronously)
		{
			ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? TraceUtility.ExtractActivity(_reply) : null);
			using (ServiceModelActivity.BoundOperation(activity))
			{
				if (_timer != null)
				{
					_timer.Dispose();
					_timer = null;
				}
				lock (_parent.ThisLock)
				{
					if (_timedOut)
					{
						_parent.AddToTimedOutRequestList(this);
					}
					_parent.RequestCompleting(this);
				}
				if (_sendException != null)
				{
					Complete(completedSynchronously, _sendException);
				}
				else if (_timedOut)
				{
					Complete(completedSynchronously, _parent.GetReceiveTimeoutException(_timeout));
				}
				else
				{
					Complete(completedSynchronously);
				}
			}
		}

		public void EnableCompletion()
		{
			bool flag;
			lock (_parent.ThisLock)
			{
				bool isDone = IsDone;
				_enableComplete = true;
				flag = !isDone && IsDone;
			}
			if (flag)
			{
				Done(completedSynchronously: true);
			}
		}

		public void FinishedSend(IAsyncResult sendResult, bool completedSynchronously)
		{
			Exception sendException = null;
			try
			{
				_parent._channel.EndSend(sendResult);
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				sendException = ex;
			}
			bool flag;
			lock (_parent.ThisLock)
			{
				bool isDone = IsDone;
				_sendResult = sendResult;
				_sendException = sendException;
				flag = !isDone && IsDone;
			}
			if (flag)
			{
				Done(completedSynchronously);
			}
		}

		internal Message End()
		{
			AsyncResult.End<AsyncDuplexRequest>(this);
			return _reply;
		}

		public void GotReply(Message reply)
		{
			ServiceModelActivity serviceModelActivity = (DiagnosticUtility.ShouldUseActivity ? TraceUtility.ExtractActivity(reply) : null);
			bool flag;
			using (ServiceModelActivity.BoundOperation(serviceModelActivity))
			{
				lock (_parent.ThisLock)
				{
					bool isDone = IsDone;
					_reply = reply;
					_gotReply = true;
					flag = !isDone && IsDone;
					if (isDone && _timedOut)
					{
						_parent.RemoveFromTimedOutRequestList(this);
					}
				}
				if (serviceModelActivity != null && DiagnosticUtility.ShouldUseActivity)
				{
					TraceUtility.SetActivity(reply, _activity);
					if (DiagnosticUtility.ShouldUseActivity && _activity != null && FxTrace.Trace != null)
					{
						FxTrace.Trace.TraceTransfer(_activity.Id);
					}
				}
			}
			if (DiagnosticUtility.ShouldUseActivity)
			{
				serviceModelActivity?.Stop();
			}
			if (flag)
			{
				Done(completedSynchronously: false);
			}
		}

		private void TimedOut()
		{
			bool flag;
			lock (_parent.ThisLock)
			{
				bool isDone = IsDone;
				_timedOut = true;
				flag = !isDone && IsDone;
			}
			if (flag)
			{
				Done(completedSynchronously: false);
			}
		}

		private static void TimerCallback(object state)
		{
			((AsyncDuplexRequest)state).TimedOut();
		}
	}

	private class ChannelFaultedAsyncResult : CompletedAsyncResult
	{
		public ChannelFaultedAsyncResult(AsyncCallback callback, object state)
			: base(callback, state)
		{
		}
	}

	internal class AutoCloseDuplexSessionChannel : IDuplexSessionChannel, IDuplexChannel, IInputChannel, IChannel, ICommunicationObject, IOutputChannel, ISessionChannel<IDuplexSession>
	{
		internal class CloseState
		{
			private bool _userClose;

			private InputQueue<object> _backgroundCloseData;

			public bool TryBackgroundClose()
			{
				if (!_userClose)
				{
					_backgroundCloseData = new InputQueue<object>();
					return true;
				}
				return false;
			}

			public void FinishBackgroundClose()
			{
				_backgroundCloseData.Close();
			}

			public bool TryUserClose()
			{
				if (_backgroundCloseData == null)
				{
					_userClose = true;
					return true;
				}
				return false;
			}

			public void WaitForBackgroundClose(TimeSpan timeout)
			{
				object obj = _backgroundCloseData.Dequeue(timeout);
			}

			public IAsyncResult BeginWaitForBackgroundClose(TimeSpan timeout, AsyncCallback callback, object state)
			{
				return _backgroundCloseData.BeginDequeue(timeout, callback, state);
			}

			public void EndWaitForBackgroundClose(IAsyncResult result)
			{
				object obj = _backgroundCloseData.EndDequeue(result);
			}

			public void CaptureBackgroundException(Exception exception)
			{
				_backgroundCloseData.EnqueueAndDispatch(exception, null, canDispatchOnThisThread: true);
			}
		}

		private static AsyncCallback s_receiveAsyncCallback;

		private static Action<object> s_receiveThreadSchedulerCallback;

		private static AsyncCallback s_closeInnerChannelCallback;

		private IDuplexSessionChannel _innerChannel;

		private InputQueue<Message> _pendingMessages;

		private Action _messageDequeuedCallback;

		private CloseState _closeState;

		private object ThisLock => this;

		public EndpointAddress LocalAddress => _innerChannel.LocalAddress;

		public EndpointAddress RemoteAddress => _innerChannel.RemoteAddress;

		public Uri Via => _innerChannel.Via;

		public IDuplexSession Session => _innerChannel.Session;

		public CommunicationState State => _innerChannel.State;

		private TimeSpan DefaultCloseTimeout
		{
			get
			{
				if (_innerChannel is IDefaultCommunicationTimeouts defaultCommunicationTimeouts)
				{
					return defaultCommunicationTimeouts.CloseTimeout;
				}
				return ServiceDefaults.CloseTimeout;
			}
		}

		private TimeSpan DefaultReceiveTimeout
		{
			get
			{
				if (_innerChannel is IDefaultCommunicationTimeouts defaultCommunicationTimeouts)
				{
					return defaultCommunicationTimeouts.ReceiveTimeout;
				}
				return ServiceDefaults.ReceiveTimeout;
			}
		}

		public event EventHandler Closing
		{
			add
			{
				_innerChannel.Closing += value;
			}
			remove
			{
				_innerChannel.Closing -= value;
			}
		}

		public event EventHandler Closed
		{
			add
			{
				_innerChannel.Closed += value;
			}
			remove
			{
				_innerChannel.Closed -= value;
			}
		}

		public event EventHandler Faulted
		{
			add
			{
				_innerChannel.Faulted += value;
			}
			remove
			{
				_innerChannel.Faulted -= value;
			}
		}

		public event EventHandler Opened
		{
			add
			{
				_innerChannel.Opened += value;
			}
			remove
			{
				_innerChannel.Opened -= value;
			}
		}

		public event EventHandler Opening
		{
			add
			{
				_innerChannel.Opening += value;
			}
			remove
			{
				_innerChannel.Opening -= value;
			}
		}

		public AutoCloseDuplexSessionChannel(IDuplexSessionChannel innerChannel)
		{
			_innerChannel = innerChannel;
			_pendingMessages = new InputQueue<Message>();
			_messageDequeuedCallback = StartBackgroundReceive;
			_closeState = new CloseState();
		}

		private void StartBackgroundReceive()
		{
			if (s_receiveAsyncCallback == null)
			{
				s_receiveAsyncCallback = Fx.ThunkCallback(ReceiveAsyncCallback);
			}
			IAsyncResult asyncResult = null;
			Exception ex = null;
			try
			{
				asyncResult = _innerChannel.BeginReceive(TimeSpan.MaxValue, s_receiveAsyncCallback, this);
			}
			catch (Exception ex2)
			{
				if (Fx.IsFatal(ex2))
				{
					throw;
				}
				ex = ex2;
			}
			if (ex != null)
			{
				_pendingMessages.EnqueueAndDispatch(ex, _messageDequeuedCallback, canDispatchOnThisThread: false);
			}
			else if (asyncResult.CompletedSynchronously)
			{
				if (s_receiveThreadSchedulerCallback == null)
				{
					s_receiveThreadSchedulerCallback = ReceiveThreadSchedulerCallback;
				}
				Task.Factory.StartNew(s_receiveThreadSchedulerCallback, asyncResult, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
			}
		}

		private static void ReceiveThreadSchedulerCallback(object state)
		{
			IAsyncResult asyncResult = (IAsyncResult)state;
			AutoCloseDuplexSessionChannel autoCloseDuplexSessionChannel = (AutoCloseDuplexSessionChannel)asyncResult.AsyncState;
			autoCloseDuplexSessionChannel.OnReceive(asyncResult);
		}

		private static void ReceiveAsyncCallback(IAsyncResult result)
		{
			if (!result.CompletedSynchronously)
			{
				AutoCloseDuplexSessionChannel autoCloseDuplexSessionChannel = (AutoCloseDuplexSessionChannel)result.AsyncState;
				autoCloseDuplexSessionChannel.OnReceive(result);
			}
		}

		private void OnReceive(IAsyncResult result)
		{
			Message message = null;
			Exception ex = null;
			try
			{
				message = _innerChannel.EndReceive(result);
			}
			catch (Exception ex2)
			{
				if (Fx.IsFatal(ex2))
				{
					throw;
				}
				ex = ex2;
			}
			if (ex != null)
			{
				_pendingMessages.EnqueueAndDispatch(ex, _messageDequeuedCallback, canDispatchOnThisThread: true);
			}
			else if (message == null)
			{
				_pendingMessages.Shutdown();
				CloseInnerChannel();
			}
			else
			{
				_pendingMessages.EnqueueAndDispatch(message, _messageDequeuedCallback, canDispatchOnThisThread: true);
			}
		}

		private void CloseInnerChannel()
		{
			lock (ThisLock)
			{
				if (!_closeState.TryBackgroundClose() || State != CommunicationState.Opened)
				{
					return;
				}
			}
			IAsyncResult asyncResult = null;
			Exception ex = null;
			try
			{
				if (s_closeInnerChannelCallback == null)
				{
					s_closeInnerChannelCallback = Fx.ThunkCallback(CloseInnerChannelCallback);
				}
				asyncResult = _innerChannel.BeginClose(s_closeInnerChannelCallback, this);
			}
			catch (Exception ex2)
			{
				if (Fx.IsFatal(ex2))
				{
					throw;
				}
				_innerChannel.Abort();
				ex = ex2;
			}
			if (ex != null)
			{
				_closeState.CaptureBackgroundException(ex);
			}
			else if (asyncResult.CompletedSynchronously)
			{
				OnCloseInnerChannel(asyncResult);
			}
		}

		private static void CloseInnerChannelCallback(IAsyncResult result)
		{
			if (!result.CompletedSynchronously)
			{
				((AutoCloseDuplexSessionChannel)result.AsyncState).OnCloseInnerChannel(result);
			}
		}

		private void OnCloseInnerChannel(IAsyncResult result)
		{
			Exception ex = null;
			try
			{
				_innerChannel.EndClose(result);
			}
			catch (Exception ex2)
			{
				if (Fx.IsFatal(ex2))
				{
					throw;
				}
				_innerChannel.Abort();
				ex = ex2;
			}
			if (ex != null)
			{
				_closeState.CaptureBackgroundException(ex);
			}
			else
			{
				_closeState.FinishBackgroundClose();
			}
		}

		public Message Receive()
		{
			return Receive(DefaultReceiveTimeout);
		}

		public Message Receive(TimeSpan timeout)
		{
			return _pendingMessages.Dequeue(timeout);
		}

		public IAsyncResult BeginReceive(AsyncCallback callback, object state)
		{
			return BeginReceive(DefaultReceiveTimeout, callback, state);
		}

		public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return _pendingMessages.BeginDequeue(timeout, callback, state);
		}

		public Message EndReceive(IAsyncResult result)
		{
			throw System.NotImplemented.ByDesign;
		}

		public bool TryReceive(TimeSpan timeout, out Message message)
		{
			return _pendingMessages.Dequeue(timeout, out message);
		}

		public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return _pendingMessages.BeginDequeue(timeout, callback, state);
		}

		public bool EndTryReceive(IAsyncResult result, out Message message)
		{
			return _pendingMessages.EndDequeue(result, out message);
		}

		public bool WaitForMessage(TimeSpan timeout)
		{
			return _pendingMessages.WaitForItem(timeout);
		}

		public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return _pendingMessages.BeginWaitForItem(timeout, callback, state);
		}

		public bool EndWaitForMessage(IAsyncResult result)
		{
			return _pendingMessages.EndWaitForItem(result);
		}

		public T GetProperty<T>() where T : class
		{
			return _innerChannel.GetProperty<T>();
		}

		public void Abort()
		{
			_innerChannel.Abort();
			Cleanup();
		}

		public void Close()
		{
			Close(DefaultCloseTimeout);
		}

		public void Close(TimeSpan timeout)
		{
			bool flag;
			lock (ThisLock)
			{
				flag = _closeState.TryUserClose();
			}
			if (flag)
			{
				_innerChannel.Close(timeout);
			}
			else
			{
				_closeState.WaitForBackgroundClose(timeout);
			}
			Cleanup();
		}

		public IAsyncResult BeginClose(AsyncCallback callback, object state)
		{
			return BeginClose(DefaultCloseTimeout, callback, state);
		}

		public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
		{
			bool flag;
			lock (ThisLock)
			{
				flag = _closeState.TryUserClose();
			}
			if (flag)
			{
				return _innerChannel.BeginClose(timeout, callback, state);
			}
			return _closeState.BeginWaitForBackgroundClose(timeout, callback, state);
		}

		public void EndClose(IAsyncResult result)
		{
			if (_closeState.TryUserClose())
			{
				_innerChannel.EndClose(result);
			}
			else
			{
				_closeState.EndWaitForBackgroundClose(result);
			}
			Cleanup();
		}

		private void Cleanup()
		{
			_pendingMessages.Dispose();
		}

		public void Open()
		{
			_innerChannel.Open();
			StartBackgroundReceive();
		}

		public void Open(TimeSpan timeout)
		{
			_innerChannel.Open(timeout);
			StartBackgroundReceive();
		}

		public IAsyncResult BeginOpen(AsyncCallback callback, object state)
		{
			return _innerChannel.BeginOpen(callback, state);
		}

		public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return _innerChannel.BeginOpen(timeout, callback, state);
		}

		public void EndOpen(IAsyncResult result)
		{
			_innerChannel.EndOpen(result);
			StartBackgroundReceive();
		}

		public void Send(Message message)
		{
			Send(message);
		}

		public void Send(Message message, TimeSpan timeout)
		{
			Send(message, timeout);
		}

		public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
		{
			return _innerChannel.BeginSend(message, callback, state);
		}

		public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			return _innerChannel.BeginSend(message, timeout, callback, state);
		}

		public void EndSend(IAsyncResult result)
		{
			_innerChannel.EndSend(result);
		}
	}

	private IDuplexChannel _channel;

	private IRequestReplyCorrelator _correlator;

	private TimeSpan _defaultSendTimeout;

	private IdentityVerifier _identityVerifier;

	private int _pending;

	private bool _syncPumpEnabled;

	private List<IDuplexRequest> _requests;

	private List<ICorrelatorKey> _timedOutRequests;

	private ChannelHandler _channelHandler;

	private volatile bool _requestAborted;

	public IChannel Channel => _channel;

	public TimeSpan DefaultCloseTimeout { get; set; }

	internal ChannelHandler ChannelHandler
	{
		get
		{
			_ = _channelHandler;
			return _channelHandler;
		}
		set
		{
			_ = _channelHandler;
			_channelHandler = value;
		}
	}

	public TimeSpan DefaultSendTimeout
	{
		get
		{
			return _defaultSendTimeout;
		}
		set
		{
			_defaultSendTimeout = value;
		}
	}

	public bool HasSession { get; }

	internal IdentityVerifier IdentityVerifier
	{
		get
		{
			if (_identityVerifier == null)
			{
				_identityVerifier = IdentityVerifier.CreateDefault();
			}
			return _identityVerifier;
		}
		set
		{
			_identityVerifier = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	public Uri ListenUri { get; }

	public EndpointAddress LocalAddress => _channel.LocalAddress;

	private bool Pumping
	{
		get
		{
			if (_syncPumpEnabled)
			{
				return true;
			}
			if (ChannelHandler != null && ChannelHandler.HasRegisterBeenCalled)
			{
				return true;
			}
			return false;
		}
	}

	public EndpointAddress RemoteAddress => _channel.RemoteAddress;

	private List<IDuplexRequest> Requests
	{
		get
		{
			lock (ThisLock)
			{
				if (_requests == null)
				{
					_requests = new List<IDuplexRequest>();
				}
				return _requests;
			}
		}
	}

	private List<ICorrelatorKey> TimedOutRequests
	{
		get
		{
			lock (ThisLock)
			{
				if (_timedOutRequests == null)
				{
					_timedOutRequests = new List<ICorrelatorKey>();
				}
				return _timedOutRequests;
			}
		}
	}

	private object ThisLock => this;

	internal DuplexChannelBinder(IDuplexChannel channel, IRequestReplyCorrelator correlator)
	{
		_channel = channel;
		_correlator = correlator;
		_channel.Faulted += OnFaulted;
	}

	internal DuplexChannelBinder(IDuplexChannel channel, IRequestReplyCorrelator correlator, Uri listenUri)
		: this(channel, correlator)
	{
		ListenUri = listenUri;
	}

	internal DuplexChannelBinder(IDuplexSessionChannel channel, IRequestReplyCorrelator correlator, Uri listenUri)
		: this((IDuplexChannel)channel, correlator, listenUri)
	{
		HasSession = true;
	}

	internal DuplexChannelBinder(IDuplexSessionChannel channel, IRequestReplyCorrelator correlator, bool useActiveAutoClose)
		: this(useActiveAutoClose ? new AutoCloseDuplexSessionChannel(channel) : channel, correlator, null)
	{
	}

	private void OnFaulted(object sender, EventArgs e)
	{
		AbortRequests();
	}

	public void Abort()
	{
		_channel.Abort();
		AbortRequests();
	}

	public void CloseAfterFault(TimeSpan timeout)
	{
		_channel.Close(timeout);
		AbortRequests();
	}

	private void AbortRequests()
	{
		IDuplexRequest[] array = null;
		lock (ThisLock)
		{
			if (_requests != null)
			{
				array = _requests.ToArray();
				IDuplexRequest[] array2 = array;
				foreach (IDuplexRequest duplexRequest in array2)
				{
					duplexRequest.Abort();
				}
			}
			_requests = null;
			_requestAborted = true;
		}
		if (array != null && array.Length != 0 && _correlator is RequestReplyCorrelator requestReplyCorrelator)
		{
			IDuplexRequest[] array3 = array;
			foreach (IDuplexRequest duplexRequest2 in array3)
			{
				if (duplexRequest2 is ICorrelatorKey request)
				{
					requestReplyCorrelator.RemoveRequest(request);
				}
			}
		}
		DeleteTimedoutRequestsFromCorrelator();
	}

	private TimeoutException GetReceiveTimeoutException(TimeSpan timeout)
	{
		EndpointAddress endpointAddress = _channel.RemoteAddress ?? _channel.LocalAddress;
		if (endpointAddress != null)
		{
			return new TimeoutException(System.SR.Format(System.SR.SFxRequestTimedOut2, endpointAddress, timeout));
		}
		return new TimeoutException(System.SR.Format(System.SR.SFxRequestTimedOut1, timeout));
	}

	internal bool HandleRequestAsReply(Message message)
	{
		UniqueId uniqueId = null;
		try
		{
			uniqueId = message.Headers.RelatesTo;
		}
		catch (MessageHeaderException)
		{
		}
		if (uniqueId == null)
		{
			return false;
		}
		return HandleRequestAsReplyCore(message);
	}

	private bool HandleRequestAsReplyCore(Message message)
	{
		IDuplexRequest duplexRequest = _correlator.Find<IDuplexRequest>(message, remove: true);
		if (duplexRequest != null)
		{
			duplexRequest.GotReply(message);
			return true;
		}
		return false;
	}

	public void EnsurePumping()
	{
		lock (ThisLock)
		{
			if (!_syncPumpEnabled && !ChannelHandler.HasRegisterBeenCalled)
			{
				ChannelHandler.Register(ChannelHandler);
			}
		}
	}

	public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
	{
		if (_channel.State == CommunicationState.Faulted)
		{
			return new ChannelFaultedAsyncResult(callback, state);
		}
		return _channel.BeginTryReceive(timeout, callback, state);
	}

	public bool EndTryReceive(IAsyncResult result, out RequestContext requestContext)
	{
		if (result is ChannelFaultedAsyncResult)
		{
			AbortRequests();
			requestContext = null;
			return true;
		}
		if (_channel.EndTryReceive(result, out var message))
		{
			if (message != null)
			{
				requestContext = new DuplexRequestContext(_channel, message, this);
			}
			else
			{
				AbortRequests();
				requestContext = null;
			}
			return true;
		}
		requestContext = null;
		return false;
	}

	public RequestContext CreateRequestContext(Message message)
	{
		return new DuplexRequestContext(_channel, message, this);
	}

	public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _channel.BeginSend(message, timeout, callback, state);
	}

	public void EndSend(IAsyncResult result)
	{
		_channel.EndSend(result);
	}

	public void Send(Message message, TimeSpan timeout)
	{
		_channel.Send(message, timeout);
	}

	public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		bool flag = false;
		AsyncDuplexRequest asyncDuplexRequest = null;
		try
		{
			RequestReplyCorrelator.PrepareRequest(message);
			asyncDuplexRequest = new AsyncDuplexRequest(message, this, timeout, callback, state);
			lock (ThisLock)
			{
				RequestStarting(message, asyncDuplexRequest);
			}
			IAsyncResult asyncResult = _channel.BeginSend(message, timeout, Fx.ThunkCallback(SendCallback), asyncDuplexRequest);
			if (asyncResult.CompletedSynchronously)
			{
				asyncDuplexRequest.FinishedSend(asyncResult, completedSynchronously: true);
			}
			EnsurePumping();
			flag = true;
			return asyncDuplexRequest;
		}
		finally
		{
			lock (ThisLock)
			{
				if (flag)
				{
					asyncDuplexRequest.EnableCompletion();
				}
				else
				{
					RequestCompleting(asyncDuplexRequest);
				}
			}
		}
	}

	public Message EndRequest(IAsyncResult result)
	{
		if (!(result is AsyncDuplexRequest asyncDuplexRequest))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.SPS_InvalidAsyncResult));
		}
		return asyncDuplexRequest.End();
	}

	public bool TryReceive(TimeSpan timeout, out RequestContext requestContext)
	{
		if (_channel.State == CommunicationState.Faulted)
		{
			AbortRequests();
			requestContext = null;
			return true;
		}
		if (_channel.TryReceive(timeout, out var message))
		{
			if (message != null)
			{
				requestContext = new DuplexRequestContext(_channel, message, this);
			}
			else
			{
				AbortRequests();
				requestContext = null;
			}
			return true;
		}
		requestContext = null;
		return false;
	}

	public Message Request(Message message, TimeSpan timeout)
	{
		SyncDuplexRequest syncDuplexRequest = null;
		bool flag = false;
		RequestReplyCorrelator.PrepareRequest(message);
		lock (ThisLock)
		{
			if (!Pumping)
			{
				flag = true;
				_syncPumpEnabled = true;
			}
			if (!flag)
			{
				syncDuplexRequest = new SyncDuplexRequest(this);
			}
			RequestStarting(message, syncDuplexRequest);
		}
		if (flag)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			UniqueId messageId = message.Headers.MessageId;
			try
			{
				_channel.Send(message, timeoutHelper.RemainingTime());
				if (DiagnosticUtility.ShouldUseActivity && ServiceModelActivity.Current != null && ServiceModelActivity.Current.ActivityType == ActivityType.ProcessAction)
				{
					ServiceModelActivity.Current.Suspend();
				}
				Message message2;
				while (true)
				{
					TimeSpan timeout2 = timeoutHelper.RemainingTime();
					if (!_channel.TryReceive(timeout2, out message2))
					{
						throw TraceUtility.ThrowHelperError(GetReceiveTimeoutException(timeout), message);
					}
					if (message2 == null)
					{
						AbortRequests();
						return null;
					}
					if (message2.Headers.RelatesTo == messageId)
					{
						break;
					}
					if (!HandleRequestAsReply(message2))
					{
						message2.Close();
					}
				}
				return message2;
			}
			finally
			{
				lock (ThisLock)
				{
					RequestCompleting(null);
					_syncPumpEnabled = false;
					if (_pending > 0)
					{
						EnsurePumping();
					}
				}
			}
		}
		TimeoutHelper timeoutHelper2 = new TimeoutHelper(timeout);
		_channel.Send(message, timeoutHelper2.RemainingTime());
		EnsurePumping();
		return syncDuplexRequest.WaitForReply(timeoutHelper2.RemainingTime());
	}

	private void RequestStarting(Message message, IDuplexRequest request)
	{
		if (request != null)
		{
			Requests.Add(request);
			if (!_requestAborted)
			{
				_correlator.Add(message, request);
			}
		}
		_pending++;
	}

	private void RequestCompleting(IDuplexRequest request)
	{
		_pending--;
		if (_pending == 0)
		{
			_requests = null;
		}
		else if (request != null && _requests != null)
		{
			_requests.Remove(request);
		}
	}

	private void AddToTimedOutRequestList(ICorrelatorKey request)
	{
		TimedOutRequests.Add(request);
	}

	private void RemoveFromTimedOutRequestList(ICorrelatorKey request)
	{
		if (_timedOutRequests != null)
		{
			_timedOutRequests.Remove(request);
		}
	}

	private void DeleteTimedoutRequestsFromCorrelator()
	{
		ICorrelatorKey[] array = null;
		if (_timedOutRequests != null && _timedOutRequests.Count > 0)
		{
			lock (ThisLock)
			{
				if (_timedOutRequests != null && _timedOutRequests.Count > 0)
				{
					array = _timedOutRequests.ToArray();
					_timedOutRequests = null;
				}
			}
		}
		if (array != null && array.Length != 0 && _correlator is RequestReplyCorrelator requestReplyCorrelator)
		{
			ICorrelatorKey[] array2 = array;
			foreach (ICorrelatorKey request in array2)
			{
				requestReplyCorrelator.RemoveRequest(request);
			}
		}
	}

	private void SendCallback(IAsyncResult result)
	{
		AsyncDuplexRequest asyncDuplexRequest = result.AsyncState as AsyncDuplexRequest;
		if (!result.CompletedSynchronously)
		{
			asyncDuplexRequest.FinishedSend(result, completedSynchronously: false);
		}
	}

	public bool WaitForMessage(TimeSpan timeout)
	{
		return _channel.WaitForMessage(timeout);
	}

	public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _channel.BeginWaitForMessage(timeout, callback, state);
	}

	public bool EndWaitForMessage(IAsyncResult result)
	{
		return _channel.EndWaitForMessage(result);
	}
}

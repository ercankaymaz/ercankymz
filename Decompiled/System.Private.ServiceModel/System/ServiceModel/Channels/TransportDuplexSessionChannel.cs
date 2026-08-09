using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Security;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public abstract class TransportDuplexSessionChannel : TransportOutputChannel, IDuplexSessionChannel, IDuplexChannel, IInputChannel, IChannel, ICommunicationObject, IOutputChannel, ISessionChannel<IDuplexSession>, IAsyncDuplexSessionChannel, IAsyncDuplexChannel, IAsyncInputChannel, IAsyncCommunicationObject, IAsyncOutputChannel, ISessionChannel<IAsyncDuplexSession>
{
	public class ConnectionDuplexSession : IDuplexSession, IInputSession, ISession, IOutputSession, IAsyncDuplexSession
	{
		private static UriGenerator s_uriGenerator;

		private string _id;

		public string Id
		{
			get
			{
				if (_id == null)
				{
					lock (Channel)
					{
						if (_id == null)
						{
							_id = UriGenerator.Next();
						}
					}
				}
				return _id;
			}
		}

		public TransportDuplexSessionChannel Channel { get; }

		private static UriGenerator UriGenerator
		{
			get
			{
				if (s_uriGenerator == null)
				{
					s_uriGenerator = new UriGenerator();
				}
				return s_uriGenerator;
			}
		}

		public ConnectionDuplexSession(TransportDuplexSessionChannel channel)
		{
			Channel = channel;
		}

		public IAsyncResult BeginCloseOutputSession(AsyncCallback callback, object state)
		{
			return BeginCloseOutputSession(Channel.DefaultCloseTimeout, callback, state);
		}

		public IAsyncResult BeginCloseOutputSession(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return Channel.CloseOutputSessionAsync(timeout).ToApm(callback, state);
		}

		public void EndCloseOutputSession(IAsyncResult result)
		{
			result.ToApmEnd();
		}

		public void CloseOutputSession()
		{
			CloseOutputSession(Channel.DefaultCloseTimeout);
		}

		public void CloseOutputSession(TimeSpan timeout)
		{
			Channel.CloseOutputSession(timeout);
		}

		public Task CloseOutputSessionAsync()
		{
			return CloseOutputSessionAsync(Channel.DefaultCloseTimeout);
		}

		public Task CloseOutputSessionAsync(TimeSpan timeout)
		{
			return Channel.CloseOutputSessionAsync(timeout);
		}
	}

	private bool _isInputSessionClosed;

	private bool _isOutputSessionClosed;

	private Uri _localVia;

	private static Action<object> s_onWriteComplete = OnWriteComplete;

	public EndpointAddress LocalAddress { get; }

	public SecurityMessageProperty RemoteSecurity { get; protected set; }

	public IDuplexSession Session { get; protected set; }

	protected SemaphoreSlim SendLock { get; }

	protected BufferManager BufferManager { get; }

	protected MessageEncoder MessageEncoder { get; set; }

	internal SynchronizedMessageSource MessageSource { get; private set; }

	protected abstract bool IsStreamedOutput { get; }

	IAsyncDuplexSession ISessionChannel<IAsyncDuplexSession>.Session => Session as IAsyncDuplexSession;

	protected TransportDuplexSessionChannel(ChannelManagerBase manager, ITransportFactorySettings settings, EndpointAddress localAddress, Uri localVia, EndpointAddress remoteAddress, Uri via)
		: base(manager, remoteAddress, via, settings.ManualAddressing, settings.MessageVersion)
	{
		LocalAddress = localAddress;
		_localVia = localVia;
		BufferManager = settings.BufferManager;
		SendLock = new SemaphoreSlim(1);
		MessageEncoder = settings.MessageEncoderFactory.CreateSessionEncoder();
		Session = new ConnectionDuplexSession(this);
	}

	public Message Receive()
	{
		return Receive(base.DefaultReceiveTimeout);
	}

	public Message Receive(TimeSpan timeout)
	{
		Message message = null;
		if (DoneReceivingInCurrentState())
		{
			return null;
		}
		bool flag = true;
		try
		{
			message = MessageSource.Receive(timeout);
			OnReceiveMessage(message);
			flag = false;
			return message;
		}
		finally
		{
			if (flag)
			{
				if (message != null)
				{
					message.Close();
					message = null;
				}
				Fault();
			}
		}
	}

	public Task<Message> ReceiveAsync()
	{
		return ReceiveAsync(base.DefaultReceiveTimeout);
	}

	public async Task<Message> ReceiveAsync(TimeSpan timeout)
	{
		Message message = null;
		if (DoneReceivingInCurrentState())
		{
			return null;
		}
		bool shouldFault = true;
		try
		{
			message = await MessageSource.ReceiveAsync(timeout);
			OnReceiveMessage(message);
			shouldFault = false;
			return message;
		}
		finally
		{
			if (shouldFault)
			{
				message?.Close();
				Fault();
			}
		}
	}

	public IAsyncResult BeginReceive(AsyncCallback callback, object state)
	{
		return BeginReceive(base.DefaultReceiveTimeout, callback, state);
	}

	public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return ReceiveAsync(timeout).ToApm(callback, state);
	}

	public Message EndReceive(IAsyncResult result)
	{
		return result.ToApmEnd<Message>();
	}

	public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return ReceiveAsync(timeout).ToApm(callback, state);
	}

	public bool EndTryReceive(IAsyncResult result, out Message message)
	{
		try
		{
			message = result.ToApmEnd<Message>();
			return true;
		}
		catch (TimeoutException ex)
		{
			if (WcfEventSource.Instance.ReceiveTimeoutIsEnabled())
			{
				WcfEventSource.Instance.ReceiveTimeout(ex.Message);
			}
			message = null;
			return false;
		}
	}

	public async Task<(bool, Message)> TryReceiveAsync(TimeSpan timeout)
	{
		try
		{
			return (true, await ReceiveAsync(timeout));
		}
		catch (TimeoutException ex)
		{
			if (WcfEventSource.Instance.ReceiveTimeoutIsEnabled())
			{
				WcfEventSource.Instance.ReceiveTimeout(ex.Message);
			}
			return (false, null);
		}
	}

	public bool TryReceive(TimeSpan timeout, out Message message)
	{
		try
		{
			message = Receive(timeout);
			return true;
		}
		catch (TimeoutException ex)
		{
			if (WcfEventSource.Instance.ReceiveTimeoutIsEnabled())
			{
				WcfEventSource.Instance.ReceiveTimeout(ex.Message);
			}
			message = null;
			return false;
		}
	}

	public async Task<bool> WaitForMessageAsync(TimeSpan timeout)
	{
		if (DoneReceivingInCurrentState())
		{
			return true;
		}
		bool shouldFault = true;
		try
		{
			bool flag = await MessageSource.WaitForMessageAsync(timeout);
			shouldFault = !flag;
			return flag;
		}
		finally
		{
			if (shouldFault)
			{
				Fault();
			}
		}
	}

	public bool WaitForMessage(TimeSpan timeout)
	{
		if (DoneReceivingInCurrentState())
		{
			return true;
		}
		bool flag = true;
		try
		{
			bool flag2 = MessageSource.WaitForMessage(timeout);
			flag = !flag2;
			return flag2;
		}
		finally
		{
			if (flag)
			{
				Fault();
			}
		}
	}

	public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return WaitForMessageAsync(timeout).ToApm(callback, state);
	}

	public bool EndWaitForMessage(IAsyncResult result)
	{
		return result.ToApmEnd<bool>();
	}

	protected void SetMessageSource(IMessageSource messageSource)
	{
		MessageSource = new SynchronizedMessageSource(messageSource);
	}

	protected abstract Task CloseOutputSessionCoreAsync(TimeSpan timeout);

	protected abstract void CloseOutputSessionCore(TimeSpan timeout);

	protected async Task CloseOutputSessionAsync(TimeSpan timeout)
	{
		ThrowIfNotOpened();
		ThrowIfFaulted();
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (!(await SendLock.WaitAsync(TimeoutHelper.ToMilliseconds(timeout))))
		{
			if (WcfEventSource.Instance.CloseTimeoutIsEnabled())
			{
				WcfEventSource.Instance.CloseTimeout(System.SR.Format(System.SR.CloseTimedOut, timeout));
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.CloseTimedOut, timeout), TimeoutHelper.CreateEnterTimedOutException(timeout)));
		}
		try
		{
			ThrowIfFaulted();
			if (_isOutputSessionClosed)
			{
				return;
			}
			_isOutputSessionClosed = true;
			bool shouldFault = true;
			try
			{
				await CloseOutputSessionCoreAsync(timeout);
				OnOutputSessionClosed(ref timeoutHelper);
				shouldFault = false;
			}
			finally
			{
				if (shouldFault)
				{
					Fault();
				}
			}
		}
		finally
		{
			SendLock.Release();
		}
	}

	protected void CloseOutputSession(TimeSpan timeout)
	{
		ThrowIfNotOpened();
		ThrowIfFaulted();
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (!SendLock.Wait(TimeoutHelper.ToMilliseconds(timeout)))
		{
			if (WcfEventSource.Instance.CloseTimeoutIsEnabled())
			{
				WcfEventSource.Instance.CloseTimeout(System.SR.Format(System.SR.CloseTimedOut, timeout));
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.CloseTimedOut, timeout), TimeoutHelper.CreateEnterTimedOutException(timeout)));
		}
		try
		{
			ThrowIfFaulted();
			if (_isOutputSessionClosed)
			{
				return;
			}
			_isOutputSessionClosed = true;
			bool flag = true;
			try
			{
				CloseOutputSessionCore(timeout);
				OnOutputSessionClosed(ref timeoutHelper);
				flag = false;
			}
			finally
			{
				if (flag)
				{
					Fault();
				}
			}
		}
		finally
		{
			SendLock.Release();
		}
	}

	protected abstract void ReturnConnectionIfNecessary(bool abort, TimeSpan timeout);

	protected override void OnAbort()
	{
		ReturnConnectionIfNecessary(abort: true, TimeSpan.Zero);
	}

	protected override void OnFaulted()
	{
		base.OnFaulted();
		ReturnConnectionIfNecessary(abort: true, TimeSpan.Zero);
	}

	protected internal override async Task OnCloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await CloseOutputSessionAsync(timeoutHelper.RemainingTime());
		if (!_isInputSessionClosed)
		{
			await EnsureInputClosedAsync(timeoutHelper.RemainingTime());
			OnInputSessionClosed();
		}
		CompleteClose(timeoutHelper.RemainingTime());
	}

	protected override void OnClose(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		CloseOutputSession(timeoutHelper.RemainingTime());
		if (!_isInputSessionClosed)
		{
			EnsureInputClosed(timeoutHelper.RemainingTime());
			OnInputSessionClosed();
		}
		CompleteClose(timeoutHelper.RemainingTime());
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected override void OnClosed()
	{
		base.OnClosed();
	}

	protected virtual void OnReceiveMessage(Message message)
	{
		if (message == null)
		{
			OnInputSessionClosed();
		}
		else
		{
			PrepareMessage(message);
		}
	}

	protected void ApplyChannelBinding(Message message)
	{
	}

	protected virtual void PrepareMessage(Message message)
	{
		message.Properties.Via = _localVia;
		ApplyChannelBinding(message);
		if (FxTrace.Trace.IsEnd2EndActivityTracingEnabled)
		{
			EventTraceActivity eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(message);
			Guid activityIdFromThread = EventTraceActivity.GetActivityIdFromThread();
			if (eventTraceActivity == null)
			{
				eventTraceActivity = EventTraceActivity.GetFromThreadOrCreate();
				EventTraceActivityHelper.TryAttachActivity(message, eventTraceActivity);
			}
			if (WcfEventSource.Instance.MessageReceivedByTransportIsEnabled())
			{
				WcfEventSource.Instance.MessageReceivedByTransport(eventTraceActivity, (LocalAddress != null && LocalAddress.Uri != null) ? LocalAddress.Uri.AbsoluteUri : string.Empty, activityIdFromThread);
			}
		}
	}

	protected abstract AsyncCompletionResult StartWritingBufferedMessage(Message message, ArraySegment<byte> messageData, bool allowOutputBatching, TimeSpan timeout, Action<object> callback, object state);

	protected abstract AsyncCompletionResult BeginCloseOutput(TimeSpan timeout, Action<object> callback, object state);

	protected virtual void FinishWritingMessage()
	{
	}

	protected abstract ArraySegment<byte> EncodeMessage(Message message);

	protected abstract void OnSendCore(Message message, TimeSpan timeout);

	protected abstract AsyncCompletionResult StartWritingStreamedMessage(Message message, TimeSpan timeout, Action<object> callback, object state);

	protected override async Task OnSendAsync(Message message, TimeSpan timeout)
	{
		ThrowIfDisposedOrNotOpen();
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (!(await SendLock.WaitAsync(TimeoutHelper.ToMilliseconds(timeout))))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.SendToViaTimedOut, Via, timeout), TimeoutHelper.CreateEnterTimedOutException(timeout)));
		}
		byte[] buffer = null;
		try
		{
			ThrowIfDisposedOrNotOpen();
			ThrowIfOutputSessionClosed();
			bool success = false;
			try
			{
				ApplyChannelBinding(message);
				TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>(this);
				AsyncCompletionResult asyncCompletionResult;
				if (IsStreamedOutput)
				{
					asyncCompletionResult = StartWritingStreamedMessage(message, timeoutHelper.RemainingTime(), s_onWriteComplete, taskCompletionSource);
				}
				else
				{
					bool allowOutputBatching = message.Properties.AllowOutputBatching;
					ArraySegment<byte> messageData = EncodeMessage(message);
					buffer = messageData.Array;
					asyncCompletionResult = StartWritingBufferedMessage(message, messageData, allowOutputBatching, timeoutHelper.RemainingTime(), s_onWriteComplete, taskCompletionSource);
				}
				if (asyncCompletionResult == AsyncCompletionResult.Completed)
				{
					taskCompletionSource.TrySetResult(result: true);
				}
				await taskCompletionSource.Task;
				FinishWritingMessage();
				success = true;
				if (WcfEventSource.Instance.MessageSentByTransportIsEnabled())
				{
					EventTraceActivity eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(message);
					WcfEventSource.Instance.MessageSentByTransport(eventTraceActivity, RemoteAddress.Uri.AbsoluteUri);
				}
			}
			finally
			{
				if (!success)
				{
					Fault();
				}
			}
		}
		finally
		{
			SendLock.Release();
		}
		if (buffer != null)
		{
			BufferManager.ReturnBuffer(buffer);
		}
	}

	private static void OnWriteComplete(object state)
	{
		if (state == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("state");
		}
		if (!(state is TaskCompletionSource<bool> taskCompletionSource))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("state", System.SR.SPS_InvalidAsyncResult);
		}
		taskCompletionSource.TrySetResult(result: true);
	}

	protected override void OnSend(Message message, TimeSpan timeout)
	{
		ThrowIfDisposedOrNotOpen();
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (!SendLock.Wait(TimeoutHelper.ToMilliseconds(timeout)))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.SendToViaTimedOut, Via, timeout), TimeoutHelper.CreateEnterTimedOutException(timeout)));
		}
		try
		{
			ThrowIfDisposedOrNotOpen();
			ThrowIfOutputSessionClosed();
			bool flag = false;
			try
			{
				ApplyChannelBinding(message);
				OnSendCore(message, timeoutHelper.RemainingTime());
				flag = true;
				if (WcfEventSource.Instance.MessageSentByTransportIsEnabled())
				{
					EventTraceActivity eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(message);
					WcfEventSource.Instance.MessageSentByTransport(eventTraceActivity, RemoteAddress.Uri.AbsoluteUri);
				}
			}
			finally
			{
				if (!flag)
				{
					Fault();
				}
			}
		}
		finally
		{
			SendLock.Release();
		}
	}

	protected abstract void CompleteClose(TimeSpan timeout);

	private void ThrowIfOutputSessionClosed()
	{
		if (_isOutputSessionClosed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SendCannotBeCalledAfterCloseOutputSession));
		}
	}

	private async Task EnsureInputClosedAsync(TimeSpan timeout)
	{
		Message message = await MessageSource.ReceiveAsync(timeout);
		if (message != null)
		{
			using (message)
			{
				ProtocolException exception = ProtocolException.ReceiveShutdownReturnedNonNull(message);
				throw TraceUtility.ThrowHelperError(exception, message);
			}
		}
	}

	private void EnsureInputClosed(TimeSpan timeout)
	{
		Message message = MessageSource.Receive(timeout);
		if (message != null)
		{
			using (message)
			{
				ProtocolException exception = ProtocolException.ReceiveShutdownReturnedNonNull(message);
				throw TraceUtility.ThrowHelperError(exception, message);
			}
		}
	}

	private void OnInputSessionClosed()
	{
		lock (base.ThisLock)
		{
			if (!_isInputSessionClosed)
			{
				_isInputSessionClosed = true;
			}
		}
	}

	private void OnOutputSessionClosed(ref TimeoutHelper timeoutHelper)
	{
		bool flag = false;
		lock (base.ThisLock)
		{
			if (_isInputSessionClosed)
			{
				flag = true;
			}
		}
		if (flag)
		{
			ReturnConnectionIfNecessary(abort: false, timeoutHelper.RemainingTime());
		}
	}
}

using System.Runtime;

namespace System.ServiceModel.Channels;

internal abstract class RequestContextBase : RequestContext
{
	private TimeSpan _defaultCloseTimeout;

	private CommunicationState _state = CommunicationState.Opened;

	private Message _requestMessage;

	private Exception _requestMessageException;

	private bool _replySent;

	private bool _aborted;

	public override Message RequestMessage
	{
		get
		{
			if (_requestMessageException != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(_requestMessageException);
			}
			return _requestMessage;
		}
	}

	protected bool ReplyInitiated { get; private set; }

	protected object ThisLock { get; } = new object();

	public bool Aborted => _aborted;

	public TimeSpan DefaultCloseTimeout => _defaultCloseTimeout;

	public TimeSpan DefaultSendTimeout { get; }

	protected RequestContextBase(Message requestMessage, TimeSpan defaultCloseTimeout, TimeSpan defaultSendTimeout)
	{
		DefaultSendTimeout = defaultSendTimeout;
		_defaultCloseTimeout = defaultCloseTimeout;
		_requestMessage = requestMessage;
	}

	public void ReInitialize(Message requestMessage)
	{
		_state = CommunicationState.Opened;
		_requestMessageException = null;
		_replySent = false;
		ReplyInitiated = false;
		_aborted = false;
		_requestMessage = requestMessage;
	}

	protected void SetRequestMessage(Message requestMessage)
	{
		_requestMessage = requestMessage;
	}

	protected void SetRequestMessage(Exception requestMessageException)
	{
		_requestMessageException = requestMessageException;
	}

	public override void Abort()
	{
		lock (ThisLock)
		{
			if (_state == CommunicationState.Closed)
			{
				return;
			}
			_state = CommunicationState.Closing;
			_aborted = true;
		}
		try
		{
			OnAbort();
		}
		finally
		{
			_state = CommunicationState.Closed;
		}
	}

	public override void Close()
	{
		Close(_defaultCloseTimeout);
	}

	public override void Close(TimeSpan timeout)
	{
		if (timeout < TimeSpan.Zero)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("timeout", timeout, System.SR.ValueMustBeNonNegative));
		}
		bool flag = false;
		lock (ThisLock)
		{
			if (_state != CommunicationState.Opened)
			{
				return;
			}
			if (TryInitiateReply())
			{
				flag = true;
			}
			_state = CommunicationState.Closing;
		}
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		bool flag2 = true;
		try
		{
			if (flag)
			{
				OnReply(null, timeoutHelper.RemainingTime());
			}
			OnClose(timeoutHelper.RemainingTime());
			_state = CommunicationState.Closed;
			flag2 = false;
		}
		finally
		{
			if (flag2)
			{
				Abort();
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing)
		{
			if (_replySent)
			{
				Close();
			}
			else
			{
				Abort();
			}
		}
	}

	protected abstract void OnAbort();

	protected abstract void OnClose(TimeSpan timeout);

	protected abstract void OnReply(Message message, TimeSpan timeout);

	protected abstract IAsyncResult OnBeginReply(Message message, TimeSpan timeout, AsyncCallback callback, object state);

	protected abstract void OnEndReply(IAsyncResult result);

	protected void ThrowIfInvalidReply()
	{
		if (_state == CommunicationState.Closed || _state == CommunicationState.Closing)
		{
			if (_aborted)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationObjectAbortedException(System.SR.RequestContextAborted));
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().FullName));
		}
		if (ReplyInitiated)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ReplyAlreadySent));
		}
	}

	protected bool TryInitiateReply()
	{
		lock (ThisLock)
		{
			if (_state != CommunicationState.Opened || ReplyInitiated)
			{
				return false;
			}
			ReplyInitiated = true;
			return true;
		}
	}

	public override IAsyncResult BeginReply(Message message, AsyncCallback callback, object state)
	{
		return BeginReply(message, DefaultSendTimeout, callback, state);
	}

	public override IAsyncResult BeginReply(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		lock (ThisLock)
		{
			ThrowIfInvalidReply();
			ReplyInitiated = true;
		}
		return OnBeginReply(message, timeout, callback, state);
	}

	public override void EndReply(IAsyncResult result)
	{
		OnEndReply(result);
		_replySent = true;
	}

	public override void Reply(Message message)
	{
		Reply(message, DefaultSendTimeout);
	}

	public override void Reply(Message message, TimeSpan timeout)
	{
		lock (ThisLock)
		{
			ThrowIfInvalidReply();
			ReplyInitiated = true;
		}
		OnReply(message, timeout);
		_replySent = true;
	}

	protected void SetReplySent()
	{
		lock (ThisLock)
		{
			ThrowIfInvalidReply();
			ReplyInitiated = true;
		}
		_replySent = true;
	}
}

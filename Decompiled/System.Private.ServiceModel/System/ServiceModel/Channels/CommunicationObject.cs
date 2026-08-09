using System.Collections.Generic;
using System.Runtime;
using System.ServiceModel.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public abstract class CommunicationObject : ICommunicationObject, IAsyncCommunicationObject
{
	private class ExceptionQueue
	{
		private Queue<Exception> _exceptions = new Queue<Exception>();

		private object _thisLock { get; }

		internal ExceptionQueue(object thisLock)
		{
			_thisLock = thisLock;
		}

		public void AddException(Exception exception)
		{
			if (exception == null)
			{
				return;
			}
			lock (_thisLock)
			{
				_exceptions.Enqueue(exception);
			}
		}

		public Exception GetException()
		{
			lock (_thisLock)
			{
				if (_exceptions.Count > 0)
				{
					return _exceptions.Dequeue();
				}
			}
			return null;
		}
	}

	private bool _closeCalled;

	private ExceptionQueue _exceptionQueue;

	private bool _onClosingCalled;

	private bool _onClosedCalled;

	private bool _onOpeningCalled;

	private bool _onOpenedCalled;

	private bool _raisedClosed;

	private bool _raisedClosing;

	private bool _raisedFaulted;

	private bool _traceOpenAndClose;

	private CommunicationState _state;

	internal bool _isSynchronousOpen;

	internal bool _isSynchronousClose;

	private bool _supportsAsyncOpenClose;

	private bool _supportsAsyncOpenCloseSet;

	private AsyncLock _asyncLock;

	private object _thisLock;

	internal bool SupportsAsyncOpenClose
	{
		get
		{
			if (!_supportsAsyncOpenCloseSet)
			{
				try
				{
					_supportsAsyncOpenClose = GetType().Namespace?.StartsWith("System.ServiceModel") ?? false;
				}
				catch
				{
					_supportsAsyncOpenClose = true;
				}
				_supportsAsyncOpenCloseSet = true;
			}
			return _supportsAsyncOpenClose;
		}
		set
		{
			_supportsAsyncOpenClose = value;
			_supportsAsyncOpenCloseSet = true;
		}
	}

	internal bool Aborted { get; private set; }

	internal object EventSender { get; set; }

	protected bool IsDisposed => _state == CommunicationState.Closed;

	public CommunicationState State => _state;

	protected object ThisLock => _thisLock;

	internal AsyncLock ThisAsyncLock
	{
		get
		{
			if (_asyncLock != null)
			{
				return _asyncLock;
			}
			Interlocked.CompareExchange(ref _asyncLock, new AsyncLock(), null);
			return _asyncLock;
		}
	}

	protected abstract TimeSpan DefaultCloseTimeout { get; }

	protected abstract TimeSpan DefaultOpenTimeout { get; }

	internal TimeSpan InternalCloseTimeout => DefaultCloseTimeout;

	internal TimeSpan InternalOpenTimeout => DefaultOpenTimeout;

	internal bool TraceOpenAndClose
	{
		get
		{
			return _traceOpenAndClose;
		}
		set
		{
			_traceOpenAndClose = value && DiagnosticUtility.ShouldUseActivity;
		}
	}

	public event EventHandler Closed;

	public event EventHandler Closing;

	public event EventHandler Faulted;

	public event EventHandler Opened;

	public event EventHandler Opening;

	protected CommunicationObject()
		: this(new object())
	{
	}

	protected CommunicationObject(object mutex)
	{
		_thisLock = mutex;
		EventSender = this;
		_state = CommunicationState.Created;
	}

	public void Abort()
	{
		lock (_thisLock)
		{
			if (Aborted || _state == CommunicationState.Closed)
			{
				return;
			}
			Aborted = true;
			_state = CommunicationState.Closing;
		}
		OnClosing();
		if (!_onClosingCalled)
		{
			throw TraceUtility.ThrowHelperError(CreateBaseClassMethodNotCalledException("OnClosing"), Guid.Empty, this);
		}
		OnAbort();
		OnClosed();
		if (!_onClosedCalled)
		{
			throw TraceUtility.ThrowHelperError(CreateBaseClassMethodNotCalledException("OnClosed"), Guid.Empty, this);
		}
	}

	public IAsyncResult BeginClose(AsyncCallback callback, object state)
	{
		return BeginClose(DefaultCloseTimeout, callback, state);
	}

	public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return CloseAsyncInternal(timeout).ToApm(callback, state);
	}

	public IAsyncResult BeginOpen(AsyncCallback callback, object state)
	{
		return BeginOpen(DefaultOpenTimeout, callback, state);
	}

	public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OpenAsyncInternal(timeout).ToApm(callback, state);
	}

	public void Close()
	{
		Close(DefaultCloseTimeout);
	}

	public void Close(TimeSpan timeout)
	{
		_isSynchronousClose = true;
		CloseAsyncInternal(timeout).WaitForCompletion();
	}

	private async Task CloseAsyncInternal(TimeSpan timeout)
	{
		await TaskHelpers.EnsureDefaultTaskScheduler();
		await ((IAsyncCommunicationObject)this).CloseAsync(timeout);
	}

	async Task IAsyncCommunicationObject.CloseAsync(TimeSpan timeout)
	{
		if (timeout < TimeSpan.Zero)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("timeout", System.SR.SFxTimeoutOutOfRange0));
		}
		CommunicationState state;
		lock (_thisLock)
		{
			state = _state;
			if (state != CommunicationState.Closed)
			{
				_state = CommunicationState.Closing;
			}
			_closeCalled = true;
		}
		switch (state)
		{
		case CommunicationState.Created:
		case CommunicationState.Opening:
		case CommunicationState.Faulted:
			Abort();
			if (state == CommunicationState.Faulted)
			{
				throw TraceUtility.ThrowHelperError(CreateFaultedException(), Guid.Empty, this);
			}
			break;
		case CommunicationState.Opened:
		{
			bool throwing = true;
			try
			{
				TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
				OnClosing();
				if (!_onClosingCalled)
				{
					throw TraceUtility.ThrowHelperError(CreateBaseClassMethodNotCalledException("OnClosing"), Guid.Empty, this);
				}
				await OnCloseAsyncInternal(timeoutHelper.RemainingTime());
				OnClosed();
				if (!_onClosedCalled)
				{
					throw TraceUtility.ThrowHelperError(CreateBaseClassMethodNotCalledException("OnClosed"), Guid.Empty, this);
				}
				throwing = false;
				break;
			}
			finally
			{
				if (throwing)
				{
					Abort();
				}
			}
		}
		default:
			throw Fx.AssertAndThrow("CommunicationObject.BeginClose: Unknown CommunicationState");
		case CommunicationState.Closing:
		case CommunicationState.Closed:
			break;
		}
	}

	private async Task OnCloseAsyncInternal(TimeSpan timeout)
	{
		if (SupportsAsyncOpenClose)
		{
			await OnCloseAsync(timeout);
		}
		else if (_isSynchronousClose)
		{
			await TaskHelpers.CallActionAsync(OnClose, timeout);
		}
		else
		{
			await Task.Factory.FromAsync(OnBeginClose, OnEndClose, timeout, TaskCreationOptions.RunContinuationsAsynchronously);
		}
	}

	private Exception CreateNotOpenException()
	{
		return new InvalidOperationException(System.SR.Format(System.SR.CommunicationObjectCannotBeUsed, GetCommunicationObjectType().ToString(), _state.ToString()));
	}

	private Exception CreateImmutableException()
	{
		return new InvalidOperationException(System.SR.Format(System.SR.CommunicationObjectCannotBeModifiedInState, GetCommunicationObjectType().ToString(), _state.ToString()));
	}

	private Exception CreateBaseClassMethodNotCalledException(string method)
	{
		return new InvalidOperationException(System.SR.Format(System.SR.CommunicationObjectBaseClassMethodNotCalled, GetCommunicationObjectType().ToString(), method));
	}

	internal Exception CreateClosedException()
	{
		if (!_closeCalled)
		{
			return CreateAbortedException();
		}
		return new ObjectDisposedException(GetCommunicationObjectType().ToString());
	}

	internal Exception CreateFaultedException()
	{
		string message = System.SR.Format(System.SR.CommunicationObjectFaulted1, GetCommunicationObjectType().ToString());
		return new CommunicationObjectFaultedException(message);
	}

	internal Exception CreateAbortedException()
	{
		return new CommunicationObjectAbortedException(System.SR.Format(System.SR.CommunicationObjectAborted1, GetCommunicationObjectType().ToString()));
	}

	internal bool DoneReceivingInCurrentState()
	{
		ThrowPending();
		return _state switch
		{
			CommunicationState.Created => throw TraceUtility.ThrowHelperError(CreateNotOpenException(), Guid.Empty, this), 
			CommunicationState.Opening => throw TraceUtility.ThrowHelperError(CreateNotOpenException(), Guid.Empty, this), 
			CommunicationState.Opened => false, 
			CommunicationState.Closing => true, 
			CommunicationState.Closed => true, 
			CommunicationState.Faulted => true, 
			_ => throw Fx.AssertAndThrow("DoneReceivingInCurrentState: Unknown CommunicationObject.state"), 
		};
	}

	public void EndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	public void EndOpen(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected void Fault()
	{
		lock (_thisLock)
		{
			if (_state == CommunicationState.Closed || _state == CommunicationState.Closing || _state == CommunicationState.Faulted)
			{
				return;
			}
			_state = CommunicationState.Faulted;
		}
		OnFaulted();
	}

	internal void Fault(Exception exception)
	{
		AddPendingException(exception);
		Fault();
	}

	internal void AddPendingException(Exception exception)
	{
		lock (_thisLock)
		{
			if (_exceptionQueue == null)
			{
				_exceptionQueue = new ExceptionQueue(_thisLock);
			}
		}
		_exceptionQueue.AddException(exception);
	}

	internal Exception GetPendingException()
	{
		CommunicationState state = _state;
		return _exceptionQueue?.GetException();
	}

	internal Exception GetTerminalException()
	{
		Exception pendingException = GetPendingException();
		if (pendingException != null)
		{
			return pendingException;
		}
		switch (_state)
		{
		case CommunicationState.Closing:
		case CommunicationState.Closed:
			return new CommunicationException(System.SR.Format(System.SR.CommunicationObjectCloseInterrupted1, GetCommunicationObjectType().ToString()));
		case CommunicationState.Faulted:
			return CreateFaultedException();
		default:
			throw Fx.AssertAndThrow("GetTerminalException: Invalid CommunicationObject.state");
		}
	}

	public void Open()
	{
		Open(DefaultOpenTimeout);
	}

	public void Open(TimeSpan timeout)
	{
		_isSynchronousOpen = true;
		OpenAsyncInternal(timeout).WaitForCompletion();
	}

	private async Task OpenAsyncInternal(TimeSpan timeout)
	{
		await TaskHelpers.EnsureDefaultTaskScheduler();
		await ((IAsyncCommunicationObject)this).OpenAsync(timeout);
	}

	async Task IAsyncCommunicationObject.OpenAsync(TimeSpan timeout)
	{
		if (timeout < TimeSpan.Zero)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("timeout", System.SR.SFxTimeoutOutOfRange0));
		}
		lock (_thisLock)
		{
			ThrowIfDisposedOrImmutable();
			_state = CommunicationState.Opening;
		}
		bool throwing = true;
		try
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			OnOpening();
			if (!_onOpeningCalled)
			{
				throw TraceUtility.ThrowHelperError(CreateBaseClassMethodNotCalledException("OnOpening"), Guid.Empty, this);
			}
			await OnOpenAsyncInternal(timeoutHelper.RemainingTime());
			OnOpened();
			if (!_onOpenedCalled)
			{
				throw TraceUtility.ThrowHelperError(CreateBaseClassMethodNotCalledException("OnOpened"), Guid.Empty, this);
			}
			throwing = false;
		}
		finally
		{
			if (throwing)
			{
				Fault();
			}
		}
	}

	private async Task OnOpenAsyncInternal(TimeSpan timeout)
	{
		if (SupportsAsyncOpenClose)
		{
			await OnOpenAsync(timeout);
		}
		else if (_isSynchronousOpen)
		{
			await TaskHelpers.CallActionAsync(OnOpen, timeout);
		}
		else
		{
			await Task.Factory.FromAsync(OnBeginOpen, OnEndOpen, timeout, TaskCreationOptions.RunContinuationsAsynchronously);
		}
	}

	protected virtual void OnClosed()
	{
		_onClosedCalled = true;
		lock (_thisLock)
		{
			if (_raisedClosed)
			{
				return;
			}
			_raisedClosed = true;
			_state = CommunicationState.Closed;
		}
		EventHandler eventHandler = this.Closed;
		if (eventHandler == null)
		{
			return;
		}
		try
		{
			eventHandler(EventSender, EventArgs.Empty);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	protected virtual void OnClosing()
	{
		_onClosingCalled = true;
		lock (_thisLock)
		{
			if (_raisedClosing)
			{
				return;
			}
			_raisedClosing = true;
		}
		EventHandler eventHandler = this.Closing;
		if (eventHandler == null)
		{
			return;
		}
		try
		{
			eventHandler(EventSender, EventArgs.Empty);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	protected virtual void OnFaulted()
	{
		lock (_thisLock)
		{
			if (_raisedFaulted)
			{
				return;
			}
			_raisedFaulted = true;
		}
		EventHandler eventHandler = this.Faulted;
		if (eventHandler == null)
		{
			return;
		}
		try
		{
			eventHandler(EventSender, EventArgs.Empty);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	protected virtual void OnOpened()
	{
		_onOpenedCalled = true;
		lock (_thisLock)
		{
			if (Aborted || _state != CommunicationState.Opening)
			{
				return;
			}
			_state = CommunicationState.Opened;
		}
		EventHandler eventHandler = this.Opened;
		if (eventHandler == null)
		{
			return;
		}
		try
		{
			eventHandler(EventSender, EventArgs.Empty);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	protected virtual void OnOpening()
	{
		_onOpeningCalled = true;
		EventHandler eventHandler = this.Opening;
		if (eventHandler == null)
		{
			return;
		}
		try
		{
			eventHandler(EventSender, EventArgs.Empty);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	internal void ThrowIfFaulted()
	{
		ThrowPending();
		switch (_state)
		{
		case CommunicationState.Faulted:
			throw TraceUtility.ThrowHelperError(CreateFaultedException(), Guid.Empty, this);
		default:
			throw Fx.AssertAndThrow("ThrowIfFaulted: Unknown CommunicationObject.state");
		case CommunicationState.Created:
		case CommunicationState.Opening:
		case CommunicationState.Opened:
		case CommunicationState.Closing:
		case CommunicationState.Closed:
			break;
		}
	}

	internal void ThrowIfAborted()
	{
		if (Aborted && !_closeCalled)
		{
			throw TraceUtility.ThrowHelperError(CreateAbortedException(), Guid.Empty, this);
		}
	}

	internal void ThrowIfClosed()
	{
		ThrowPending();
		switch (_state)
		{
		case CommunicationState.Closed:
			throw TraceUtility.ThrowHelperError(CreateClosedException(), Guid.Empty, this);
		case CommunicationState.Faulted:
			throw TraceUtility.ThrowHelperError(CreateFaultedException(), Guid.Empty, this);
		default:
			throw Fx.AssertAndThrow("ThrowIfClosed: Unknown CommunicationObject.state");
		case CommunicationState.Created:
		case CommunicationState.Opening:
		case CommunicationState.Opened:
		case CommunicationState.Closing:
			break;
		}
	}

	protected virtual Type GetCommunicationObjectType()
	{
		return GetType();
	}

	protected internal void ThrowIfDisposed()
	{
		ThrowPending();
		switch (_state)
		{
		case CommunicationState.Closing:
			throw TraceUtility.ThrowHelperError(CreateClosedException(), Guid.Empty, this);
		case CommunicationState.Closed:
			throw TraceUtility.ThrowHelperError(CreateClosedException(), Guid.Empty, this);
		case CommunicationState.Faulted:
			throw TraceUtility.ThrowHelperError(CreateFaultedException(), Guid.Empty, this);
		default:
			throw Fx.AssertAndThrow("ThrowIfDisposed: Unknown CommunicationObject.state");
		case CommunicationState.Created:
		case CommunicationState.Opening:
		case CommunicationState.Opened:
			break;
		}
	}

	internal void ThrowIfClosedOrOpened()
	{
		ThrowPending();
		switch (_state)
		{
		case CommunicationState.Opened:
			throw TraceUtility.ThrowHelperError(CreateImmutableException(), Guid.Empty, this);
		case CommunicationState.Closing:
			throw TraceUtility.ThrowHelperError(CreateImmutableException(), Guid.Empty, this);
		case CommunicationState.Closed:
			throw TraceUtility.ThrowHelperError(CreateClosedException(), Guid.Empty, this);
		case CommunicationState.Faulted:
			throw TraceUtility.ThrowHelperError(CreateFaultedException(), Guid.Empty, this);
		default:
			throw Fx.AssertAndThrow("ThrowIfClosedOrOpened: Unknown CommunicationObject.state");
		case CommunicationState.Created:
		case CommunicationState.Opening:
			break;
		}
	}

	protected internal void ThrowIfDisposedOrImmutable()
	{
		ThrowPending();
		switch (_state)
		{
		case CommunicationState.Opening:
			throw TraceUtility.ThrowHelperError(CreateImmutableException(), Guid.Empty, this);
		case CommunicationState.Opened:
			throw TraceUtility.ThrowHelperError(CreateImmutableException(), Guid.Empty, this);
		case CommunicationState.Closing:
			throw TraceUtility.ThrowHelperError(CreateClosedException(), Guid.Empty, this);
		case CommunicationState.Closed:
			throw TraceUtility.ThrowHelperError(CreateClosedException(), Guid.Empty, this);
		case CommunicationState.Faulted:
			throw TraceUtility.ThrowHelperError(CreateFaultedException(), Guid.Empty, this);
		default:
			throw Fx.AssertAndThrow("ThrowIfDisposedOrImmutable: Unknown CommunicationObject.state");
		case CommunicationState.Created:
			break;
		}
	}

	protected internal void ThrowIfDisposedOrNotOpen()
	{
		ThrowPending();
		switch (_state)
		{
		case CommunicationState.Created:
			throw TraceUtility.ThrowHelperError(CreateNotOpenException(), Guid.Empty, this);
		case CommunicationState.Opening:
			throw TraceUtility.ThrowHelperError(CreateNotOpenException(), Guid.Empty, this);
		case CommunicationState.Closing:
			throw TraceUtility.ThrowHelperError(CreateClosedException(), Guid.Empty, this);
		case CommunicationState.Closed:
			throw TraceUtility.ThrowHelperError(CreateClosedException(), Guid.Empty, this);
		case CommunicationState.Faulted:
			throw TraceUtility.ThrowHelperError(CreateFaultedException(), Guid.Empty, this);
		default:
			throw Fx.AssertAndThrow("ThrowIfDisposedOrNotOpen: Unknown CommunicationObject.state");
		case CommunicationState.Opened:
			break;
		}
	}

	internal void ThrowIfNotOpened()
	{
		if (_state == CommunicationState.Created || _state == CommunicationState.Opening)
		{
			throw TraceUtility.ThrowHelperError(CreateNotOpenException(), Guid.Empty, this);
		}
	}

	internal void ThrowIfClosedOrNotOpen()
	{
		ThrowPending();
		switch (_state)
		{
		case CommunicationState.Created:
			throw TraceUtility.ThrowHelperError(CreateNotOpenException(), Guid.Empty, this);
		case CommunicationState.Opening:
			throw TraceUtility.ThrowHelperError(CreateNotOpenException(), Guid.Empty, this);
		case CommunicationState.Closed:
			throw TraceUtility.ThrowHelperError(CreateClosedException(), Guid.Empty, this);
		case CommunicationState.Faulted:
			throw TraceUtility.ThrowHelperError(CreateFaultedException(), Guid.Empty, this);
		default:
			throw Fx.AssertAndThrow("ThrowIfClosedOrNotOpen: Unknown CommunicationObject.state");
		case CommunicationState.Opened:
		case CommunicationState.Closing:
			break;
		}
	}

	internal void ThrowPending()
	{
	}

	protected abstract void OnAbort();

	protected abstract void OnClose(TimeSpan timeout);

	protected abstract IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state);

	protected abstract void OnEndClose(IAsyncResult result);

	protected abstract void OnOpen(TimeSpan timeout);

	protected abstract IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state);

	protected abstract void OnEndOpen(IAsyncResult result);

	protected internal virtual Task OnCloseAsync(TimeSpan timeout)
	{
		return TaskHelpers.CompletedTask();
	}

	protected internal virtual Task OnOpenAsync(TimeSpan timeout)
	{
		return TaskHelpers.CompletedTask();
	}

	internal Task OpenOtherAsync(ICommunicationObject other, TimeSpan timeout)
	{
		if (other is CommunicationObject { SupportsAsyncOpenClose: not false } communicationObject)
		{
			communicationObject._isSynchronousOpen = _isSynchronousOpen;
			return ((IAsyncCommunicationObject)communicationObject).OpenAsync(timeout);
		}
		if (_isSynchronousOpen)
		{
			return TaskHelpers.CallActionAsync(other.Open, timeout);
		}
		return Task.Factory.FromAsync(other.BeginOpen, other.EndOpen, timeout, null);
	}

	internal Task CloseOtherAsync(ICommunicationObject other, TimeSpan timeout)
	{
		if (other is CommunicationObject { SupportsAsyncOpenClose: not false } communicationObject)
		{
			communicationObject._isSynchronousClose = _isSynchronousClose;
			return ((IAsyncCommunicationObject)communicationObject).CloseAsync(timeout);
		}
		if (_isSynchronousClose)
		{
			return TaskHelpers.CallActionAsync(other.Close, timeout);
		}
		return Task.Factory.FromAsync(other.BeginClose, other.EndClose, timeout, null);
	}
}

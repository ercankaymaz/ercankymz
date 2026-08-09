using System.Threading;

namespace System.Runtime;

internal abstract class AsyncResult : IAsyncResult
{
	protected delegate bool AsyncCompletion(IAsyncResult result);

	private static AsyncCallback s_asyncCompletionWrapperCallback;

	private AsyncCallback _callback;

	private bool _endCalled;

	private Exception _exception;

	private AsyncCompletion _nextAsyncCompletion;

	private Action _beforePrepareAsyncCompletionAction;

	private Func<IAsyncResult, bool> _checkSyncValidationFunc;

	private ManualResetEvent _manualResetEvent;

	private object _thisLock;

	public object AsyncState { get; }

	public WaitHandle AsyncWaitHandle
	{
		get
		{
			if (_manualResetEvent != null)
			{
				return _manualResetEvent;
			}
			lock (ThisLock)
			{
				if (_manualResetEvent == null)
				{
					_manualResetEvent = new ManualResetEvent(IsCompleted);
				}
			}
			return _manualResetEvent;
		}
	}

	public bool CompletedSynchronously { get; private set; }

	public bool HasCallback => _callback != null;

	public bool IsCompleted { get; private set; }

	protected Action<AsyncResult, Exception> OnCompleting { get; set; }

	private object ThisLock => _thisLock;

	protected Action<AsyncCallback, IAsyncResult> VirtualCallback { get; set; }

	protected AsyncResult(AsyncCallback callback, object state)
	{
		_callback = callback;
		AsyncState = state;
		_thisLock = new object();
	}

	protected void Complete(bool completedSynchronously)
	{
		if (IsCompleted)
		{
			throw Fx.Exception.AsError(new InvalidOperationException(InternalSR.AsyncResultCompletedTwice(GetType())));
		}
		CompletedSynchronously = completedSynchronously;
		if (OnCompleting != null)
		{
			try
			{
				OnCompleting(this, _exception);
			}
			catch (Exception exception)
			{
				if (Fx.IsFatal(exception))
				{
					throw;
				}
				_exception = exception;
			}
		}
		if (completedSynchronously)
		{
			IsCompleted = true;
		}
		else
		{
			lock (ThisLock)
			{
				IsCompleted = true;
				if (_manualResetEvent != null)
				{
					_manualResetEvent.Set();
				}
			}
		}
		if (_callback == null)
		{
			return;
		}
		try
		{
			if (VirtualCallback != null)
			{
				VirtualCallback(_callback, this);
			}
			else
			{
				_callback(this);
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw Fx.Exception.AsError(new CallbackException(InternalSR.AsyncCallbackThrewException, ex));
		}
	}

	protected void Complete(bool completedSynchronously, Exception exception)
	{
		_exception = exception;
		Complete(completedSynchronously);
	}

	private static void AsyncCompletionWrapperCallback(IAsyncResult result)
	{
		if (result == null)
		{
			throw Fx.Exception.AsError(new InvalidOperationException(InternalSR.InvalidNullAsyncResult));
		}
		if (result.CompletedSynchronously)
		{
			return;
		}
		AsyncResult asyncResult = (AsyncResult)result.AsyncState;
		if (!asyncResult.OnContinueAsyncCompletion(result))
		{
			return;
		}
		AsyncCompletion nextCompletion = asyncResult.GetNextCompletion();
		if (nextCompletion == null)
		{
			ThrowInvalidAsyncResult(result);
		}
		bool flag = false;
		Exception exception = null;
		try
		{
			flag = nextCompletion(result);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			flag = true;
			exception = ex;
		}
		if (flag)
		{
			asyncResult.Complete(completedSynchronously: false, exception);
		}
	}

	protected virtual bool OnContinueAsyncCompletion(IAsyncResult result)
	{
		return true;
	}

	protected void SetBeforePrepareAsyncCompletionAction(Action beforePrepareAsyncCompletionAction)
	{
		_beforePrepareAsyncCompletionAction = beforePrepareAsyncCompletionAction;
	}

	protected void SetCheckSyncValidationFunc(Func<IAsyncResult, bool> checkSyncValidationFunc)
	{
		_checkSyncValidationFunc = checkSyncValidationFunc;
	}

	protected AsyncCallback PrepareAsyncCompletion(AsyncCompletion callback)
	{
		if (_beforePrepareAsyncCompletionAction != null)
		{
			_beforePrepareAsyncCompletionAction();
		}
		_nextAsyncCompletion = callback;
		if (s_asyncCompletionWrapperCallback == null)
		{
			s_asyncCompletionWrapperCallback = Fx.ThunkCallback(AsyncCompletionWrapperCallback);
		}
		return s_asyncCompletionWrapperCallback;
	}

	protected bool CheckSyncContinue(IAsyncResult result)
	{
		AsyncCompletion callback;
		return TryContinueHelper(result, out callback);
	}

	protected bool SyncContinue(IAsyncResult result)
	{
		if (TryContinueHelper(result, out var callback))
		{
			return callback(result);
		}
		return false;
	}

	private bool TryContinueHelper(IAsyncResult result, out AsyncCompletion callback)
	{
		if (result == null)
		{
			throw Fx.Exception.AsError(new InvalidOperationException(InternalSR.InvalidNullAsyncResult));
		}
		callback = null;
		if (_checkSyncValidationFunc != null)
		{
			if (!_checkSyncValidationFunc(result))
			{
				return false;
			}
		}
		else if (!result.CompletedSynchronously)
		{
			return false;
		}
		callback = GetNextCompletion();
		if (callback == null)
		{
			ThrowInvalidAsyncResult("Only call Check/SyncContinue once per async operation (once per PrepareAsyncCompletion).");
		}
		return true;
	}

	private AsyncCompletion GetNextCompletion()
	{
		AsyncCompletion nextAsyncCompletion = _nextAsyncCompletion;
		_nextAsyncCompletion = null;
		return nextAsyncCompletion;
	}

	protected static void ThrowInvalidAsyncResult(IAsyncResult result)
	{
		throw Fx.Exception.AsError(new InvalidOperationException(InternalSR.InvalidAsyncResultImplementation(result.GetType())));
	}

	protected static void ThrowInvalidAsyncResult(string debugText)
	{
		string invalidAsyncResultImplementationGeneric = InternalSR.InvalidAsyncResultImplementationGeneric;
		throw Fx.Exception.AsError(new InvalidOperationException(invalidAsyncResultImplementationGeneric));
	}

	protected static TAsyncResult End<TAsyncResult>(IAsyncResult result) where TAsyncResult : AsyncResult
	{
		if (result == null)
		{
			throw Fx.Exception.ArgumentNull("result");
		}
		if (!(result is TAsyncResult val))
		{
			throw Fx.Exception.Argument("result", InternalSR.InvalidAsyncResult);
		}
		if (val._endCalled)
		{
			throw Fx.Exception.AsError(new InvalidOperationException(InternalSR.AsyncResultAlreadyEnded));
		}
		val._endCalled = true;
		if (!val.IsCompleted)
		{
			val.AsyncWaitHandle.WaitOne();
		}
		if (val._manualResetEvent != null)
		{
			val._manualResetEvent.Dispose();
		}
		if (val._exception != null)
		{
			throw Fx.Exception.AsError(val._exception);
		}
		return val;
	}
}

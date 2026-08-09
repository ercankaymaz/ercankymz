using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class InterruptibleWaitObject
{
	private bool _aborted;

	private CommunicationObject _communicationObject;

	private bool _set;

	private int _syncWaiters;

	private object _thisLock = new object();

	private bool _throwTimeoutByDefault = true;

	private TaskCompletionSource<object> _tcs;

	public InterruptibleWaitObject(bool signaled)
		: this(signaled, throwTimeoutByDefault: true)
	{
	}

	public InterruptibleWaitObject(bool signaled, bool throwTimeoutByDefault)
	{
		_set = signaled;
		_throwTimeoutByDefault = throwTimeoutByDefault;
	}

	public void Abort(CommunicationObject communicationObject)
	{
		if (communicationObject == null)
		{
			throw Fx.AssertAndThrow("Argument communicationObject cannot be null.");
		}
		lock (_thisLock)
		{
			if (!_aborted)
			{
				_communicationObject = communicationObject;
				_aborted = true;
				InternalSet();
			}
		}
	}

	public void Fault(CommunicationObject communicationObject)
	{
		if (communicationObject == null)
		{
			throw Fx.AssertAndThrow("Argument communicationObject cannot be null.");
		}
		lock (_thisLock)
		{
			if (!_aborted)
			{
				_communicationObject = communicationObject;
				_aborted = false;
				InternalSet();
			}
		}
	}

	private Exception GetException()
	{
		_ = _communicationObject;
		if (!_aborted)
		{
			return _communicationObject.GetTerminalException();
		}
		return _communicationObject.CreateAbortedException();
	}

	private void InternalSet()
	{
		lock (_thisLock)
		{
			_set = true;
			if (_tcs != null)
			{
				_tcs.TrySetResult(null);
			}
		}
	}

	public void Reset()
	{
		lock (_thisLock)
		{
			_communicationObject = null;
			_aborted = false;
			_set = false;
			if (_tcs != null && _tcs.Task.IsCompleted)
			{
				_tcs = new TaskCompletionSource<object>();
			}
		}
	}

	public void Set()
	{
		InternalSet();
	}

	public Task<bool> WaitAsync(TimeSpan timeout)
	{
		return WaitAsync(timeout, _throwTimeoutByDefault);
	}

	public async Task<bool> WaitAsync(TimeSpan timeout, bool throwTimeoutException)
	{
		lock (_thisLock)
		{
			if (_set)
			{
				if (_communicationObject != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(GetException());
				}
				return true;
			}
			if (_tcs == null)
			{
				_tcs = new TaskCompletionSource<object>();
			}
			_syncWaiters++;
		}
		try
		{
			if (!(await _tcs.Task.AwaitWithTimeout(timeout)))
			{
				if (throwTimeoutException)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.TimeoutOnOperation, timeout)));
				}
				return false;
			}
		}
		finally
		{
			lock (_thisLock)
			{
				_syncWaiters--;
				if (_syncWaiters == 0 && _tcs.Task.IsCompleted)
				{
					_tcs = null;
				}
			}
		}
		if (_communicationObject != null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(GetException());
		}
		return true;
	}
}

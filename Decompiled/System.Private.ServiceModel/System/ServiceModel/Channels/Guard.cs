using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal sealed class Guard
{
	private TaskCompletionSource<object> _tcs;

	private int _currentCount;

	private int _maxCount;

	private bool _closed;

	private object _thisLock = new object();

	public Guard()
		: this(1)
	{
	}

	public Guard(int maxCount)
	{
		_maxCount = maxCount;
	}

	public void Abort()
	{
		_closed = true;
	}

	public async Task CloseAsync(TimeSpan timeout)
	{
		lock (_thisLock)
		{
			if (_closed)
			{
				return;
			}
			_closed = true;
			if (_currentCount > 0)
			{
				_tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
			}
		}
		if (_tcs == null)
		{
			return;
		}
		try
		{
			if (!(await _tcs.Task.AwaitWithTimeout(timeout)))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.TimeoutOnOperation, timeout)));
			}
		}
		finally
		{
			lock (_thisLock)
			{
				_tcs.TrySetResult(null);
				_tcs = null;
			}
		}
	}

	public bool Enter()
	{
		lock (_thisLock)
		{
			if (_closed)
			{
				return false;
			}
			if (_currentCount == _maxCount)
			{
				return false;
			}
			_currentCount++;
			return true;
		}
	}

	public void Exit()
	{
		lock (_thisLock)
		{
			_currentCount--;
			if (_currentCount < 0)
			{
				throw Fx.AssertAndThrow("Exit can only be called after Enter.");
			}
			if (_currentCount == 0 && _tcs != null)
			{
				Fx.AssertAndThrow(!_tcs.Task.IsCompleted, "TCS should not have already been completed");
				_tcs.TrySetResult(null);
			}
		}
	}
}

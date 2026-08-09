using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class AsyncCommunicationWaiter : ICommunicationWaiter, IDisposable
{
	private bool _closed;

	private CommunicationWaitResult _result;

	private TaskCompletionSource<bool> _tcs;

	private object ThisLock { get; }

	internal AsyncCommunicationWaiter(object mutex)
	{
		ThisLock = mutex;
		_tcs = new TaskCompletionSource<bool>();
	}

	public void Dispose()
	{
		lock (ThisLock)
		{
			if (!_closed)
			{
				_closed = true;
				_tcs?.TrySetResult(result: false);
			}
		}
	}

	public void Signal()
	{
		lock (ThisLock)
		{
			if (!_closed)
			{
				_tcs.TrySetResult(result: true);
			}
		}
	}

	public async Task<CommunicationWaitResult> WaitAsync(TimeSpan timeout, bool aborting)
	{
		if (_closed)
		{
			return CommunicationWaitResult.Aborted;
		}
		if (timeout < TimeSpan.Zero)
		{
			return CommunicationWaitResult.Expired;
		}
		if (aborting)
		{
			_result = CommunicationWaitResult.Aborted;
		}
		bool flag = !(await _tcs.Task.AwaitWithTimeout(timeout));
		lock (ThisLock)
		{
			if (_result == CommunicationWaitResult.Waiting)
			{
				_result = ((!flag) ? CommunicationWaitResult.Succeeded : CommunicationWaitResult.Expired);
			}
		}
		lock (ThisLock)
		{
			if (!_closed)
			{
				_tcs.TrySetResult(!flag);
			}
		}
		return _result;
	}

	public CommunicationWaitResult Wait(TimeSpan timeout, bool aborting)
	{
		if (_closed)
		{
			return CommunicationWaitResult.Aborted;
		}
		if (timeout < TimeSpan.Zero)
		{
			return CommunicationWaitResult.Expired;
		}
		if (aborting)
		{
			_result = CommunicationWaitResult.Aborted;
		}
		bool flag = !_tcs.Task.WaitForCompletionNoSpin(timeout);
		lock (ThisLock)
		{
			if (_result == CommunicationWaitResult.Waiting)
			{
				_result = ((!flag) ? CommunicationWaitResult.Succeeded : CommunicationWaitResult.Expired);
			}
		}
		lock (ThisLock)
		{
			if (!_closed)
			{
				_tcs.TrySetResult(result: false);
			}
		}
		return _result;
	}
}

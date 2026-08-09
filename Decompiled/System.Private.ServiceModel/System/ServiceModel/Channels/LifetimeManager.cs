using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class LifetimeManager
{
	private bool _aborted;

	private ICommunicationWaiter _busyWaiter;

	private int _busyWaiterCount;

	private LifetimeState _state;

	public int BusyCount { get; private set; }

	protected LifetimeState State => _state;

	protected object ThisLock { get; }

	public LifetimeManager(object mutex)
	{
		ThisLock = mutex;
		_state = LifetimeState.Opened;
	}

	public void Abort()
	{
		lock (ThisLock)
		{
			if (State == LifetimeState.Closed || _aborted)
			{
				return;
			}
			_aborted = true;
			_state = LifetimeState.Closing;
		}
		OnAbort();
		_state = LifetimeState.Closed;
	}

	private void ThrowIfNotOpened()
	{
		if (!_aborted && _state != LifetimeState.Opened)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().ToString()));
		}
	}

	public async Task CloseAsync(TimeSpan timeout)
	{
		lock (ThisLock)
		{
			ThrowIfNotOpened();
			_state = LifetimeState.Closing;
		}
		await OnCloseAsync(timeout);
		_state = LifetimeState.Closed;
	}

	public void Close(TimeSpan timeout)
	{
		lock (ThisLock)
		{
			ThrowIfNotOpened();
			_state = LifetimeState.Closing;
		}
		OnClose(timeout);
		_state = LifetimeState.Closed;
	}

	private async Task<CommunicationWaitResult> CloseCoreAsync(TimeSpan timeout, bool aborting)
	{
		ICommunicationWaiter busyWaiter = null;
		CommunicationWaitResult result = CommunicationWaitResult.Succeeded;
		lock (ThisLock)
		{
			if (BusyCount > 0)
			{
				if (_busyWaiter == null)
				{
					busyWaiter = (_busyWaiter = new AsyncCommunicationWaiter(ThisLock));
				}
				else
				{
					if (!aborting && _aborted)
					{
						return CommunicationWaitResult.Aborted;
					}
					busyWaiter = _busyWaiter;
				}
				Interlocked.Increment(ref _busyWaiterCount);
			}
		}
		if (busyWaiter != null)
		{
			result = await busyWaiter.WaitAsync(timeout, aborting);
			if (Interlocked.Decrement(ref _busyWaiterCount) == 0)
			{
				busyWaiter.Dispose();
				_busyWaiter = null;
			}
		}
		return result;
	}

	private CommunicationWaitResult CloseCore(TimeSpan timeout, bool aborting)
	{
		ICommunicationWaiter communicationWaiter = null;
		CommunicationWaitResult result = CommunicationWaitResult.Succeeded;
		lock (ThisLock)
		{
			if (BusyCount > 0)
			{
				if (_busyWaiter == null)
				{
					communicationWaiter = (_busyWaiter = new AsyncCommunicationWaiter(ThisLock));
				}
				else
				{
					if (!aborting && _aborted)
					{
						return CommunicationWaitResult.Aborted;
					}
					communicationWaiter = _busyWaiter;
				}
				Interlocked.Increment(ref _busyWaiterCount);
			}
		}
		if (communicationWaiter != null)
		{
			result = communicationWaiter.Wait(timeout, aborting);
			if (Interlocked.Decrement(ref _busyWaiterCount) == 0)
			{
				communicationWaiter.Dispose();
				_busyWaiter = null;
			}
		}
		return result;
	}

	protected void DecrementBusyCount()
	{
		ICommunicationWaiter communicationWaiter = null;
		bool flag = false;
		lock (ThisLock)
		{
			if (BusyCount <= 0)
			{
				throw Fx.AssertAndThrow("LifetimeManager.DecrementBusyCount: (this.busyCount > 0)");
			}
			if (--BusyCount == 0)
			{
				if (_busyWaiter != null)
				{
					communicationWaiter = _busyWaiter;
					Interlocked.Increment(ref _busyWaiterCount);
				}
				flag = true;
			}
		}
		if (communicationWaiter != null)
		{
			communicationWaiter.Signal();
			if (Interlocked.Decrement(ref _busyWaiterCount) == 0)
			{
				communicationWaiter.Dispose();
				_busyWaiter = null;
			}
		}
		if (flag && State == LifetimeState.Opened)
		{
			OnEmpty();
		}
	}

	protected virtual void IncrementBusyCount()
	{
		lock (ThisLock)
		{
			BusyCount++;
		}
	}

	protected virtual void IncrementBusyCountWithoutLock()
	{
		BusyCount++;
	}

	protected virtual void OnAbort()
	{
		CloseCore(TimeSpan.FromSeconds(1.0), aborting: true);
	}

	protected virtual IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	protected virtual void OnClose(TimeSpan timeout)
	{
		switch (CloseCore(timeout, aborting: false))
		{
		case CommunicationWaitResult.Expired:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.SFxCloseTimedOut1, timeout)));
		case CommunicationWaitResult.Aborted:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().ToString()));
		}
	}

	protected virtual async Task OnCloseAsync(TimeSpan timeout)
	{
		switch (await CloseCoreAsync(timeout, aborting: false))
		{
		case CommunicationWaitResult.Expired:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.SFxCloseTimedOut1, timeout)));
		case CommunicationWaitResult.Aborted:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().ToString()));
		}
	}

	protected virtual void OnEmpty()
	{
	}

	protected virtual void OnEndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}
}

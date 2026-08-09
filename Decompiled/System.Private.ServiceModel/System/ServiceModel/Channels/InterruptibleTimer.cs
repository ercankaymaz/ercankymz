using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class InterruptibleTimer
{
	public delegate Task AsyncWaitCallback(object state);

	private WaitCallback _callback;

	private AsyncWaitCallback _asyncCallback;

	private bool _aborted;

	private TimeSpan _defaultInterval;

	private static Action<object> s_onTimerElapsed = OnTimerElapsed;

	private static Func<object, Task> s_onTimerElapsedAsync = OnTimerElapsedAsync;

	private bool _set;

	private object _state;

	private IOThreadTimer _timer;

	private bool _isAsync;

	private object ThisLock { get; } = new object();

	public InterruptibleTimer(TimeSpan defaultInterval, WaitCallback callback, object state)
		: this(defaultInterval, callback, null, state)
	{
		if (callback == null)
		{
			throw Fx.AssertAndThrow("Argument callback cannot be null.");
		}
		_isAsync = false;
	}

	public InterruptibleTimer(TimeSpan defaultInterval, AsyncWaitCallback callback, object state)
		: this(defaultInterval, null, callback, state)
	{
		if (callback == null)
		{
			throw Fx.AssertAndThrow("Argument callback cannot be null.");
		}
		_isAsync = true;
	}

	private InterruptibleTimer(TimeSpan defaultInterval, WaitCallback callback, AsyncWaitCallback asyncCallback, object state)
	{
		_defaultInterval = defaultInterval;
		_callback = callback;
		_asyncCallback = asyncCallback;
		_state = state;
	}

	public void Abort()
	{
		lock (ThisLock)
		{
			_aborted = true;
			if (_set)
			{
				_timer.Cancel();
				_set = false;
			}
		}
	}

	public bool Cancel()
	{
		lock (ThisLock)
		{
			if (_aborted)
			{
				return false;
			}
			if (_set)
			{
				_timer.Cancel();
				_set = false;
				return true;
			}
			return false;
		}
	}

	private void OnTimerElapsed()
	{
		lock (ThisLock)
		{
			if (_aborted)
			{
				return;
			}
			_set = false;
		}
		_callback(_state);
	}

	private Task OnTimerElapsedAsync()
	{
		lock (ThisLock)
		{
			if (_aborted)
			{
				return Task.CompletedTask;
			}
			_set = false;
		}
		return _asyncCallback(_state);
	}

	private static void OnTimerElapsed(object state)
	{
		InterruptibleTimer interruptibleTimer = (InterruptibleTimer)state;
		interruptibleTimer.OnTimerElapsed();
	}

	private static Task OnTimerElapsedAsync(object state)
	{
		InterruptibleTimer interruptibleTimer = (InterruptibleTimer)state;
		return interruptibleTimer.OnTimerElapsedAsync();
	}

	public void Set()
	{
		Set(_defaultInterval);
	}

	public void Set(TimeSpan interval)
	{
		InternalSet(interval, ifNotSet: false);
	}

	public void SetIfNotSet()
	{
		InternalSet(_defaultInterval, ifNotSet: true);
	}

	private void InternalSet(TimeSpan interval, bool ifNotSet)
	{
		lock (ThisLock)
		{
			if (_aborted || (ifNotSet && _set))
			{
				return;
			}
			if (_timer == null)
			{
				if (_isAsync)
				{
					_timer = new IOThreadTimer(s_onTimerElapsedAsync, this, isTypicallyCanceledShortlyAfterBeingSet: true);
				}
				else
				{
					_timer = new IOThreadTimer(s_onTimerElapsed, this, isTypicallyCanceledShortlyAfterBeingSet: true);
				}
			}
			_timer.Set(interval);
			_set = true;
		}
	}
}

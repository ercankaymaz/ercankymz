using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime;

public struct TimeoutHelper(TimeSpan timeout)
{
	public static readonly TimeSpan MaxWait = TimeSpan.FromMilliseconds(2147483647.0);

	private static readonly CancellationToken s_precancelledToken = new CancellationToken(canceled: true);

	private bool _cancellationTokenInitialized = false;

	private bool _deadlineSet = timeout == TimeSpan.MaxValue;

	private CancellationToken _cancellationToken;

	private DateTime _deadline = DateTime.MaxValue;

	public TimeSpan OriginalTimeout { get; } = timeout;

	public CancellationToken GetCancellationToken()
	{
		return GetCancellationTokenAsync().Result;
	}

	public async Task<CancellationToken> GetCancellationTokenAsync()
	{
		if (!_cancellationTokenInitialized)
		{
			TimeSpan timeSpan = RemainingTime();
			if (timeSpan >= MaxWait || timeSpan == Timeout.InfiniteTimeSpan)
			{
				_cancellationToken = CancellationToken.None;
			}
			else if (timeSpan > TimeSpan.Zero)
			{
				_cancellationToken = await TimeoutTokenSource.FromTimeoutAsync((int)timeSpan.TotalMilliseconds);
			}
			else
			{
				_cancellationToken = s_precancelledToken;
			}
			_cancellationTokenInitialized = true;
		}
		return _cancellationToken;
	}

	public static bool IsTooLarge(TimeSpan timeout)
	{
		if (timeout > MaxWait)
		{
			return timeout != TimeSpan.MaxValue;
		}
		return false;
	}

	public static TimeSpan FromMilliseconds(int milliseconds)
	{
		if (milliseconds == -1)
		{
			return TimeSpan.MaxValue;
		}
		return TimeSpan.FromMilliseconds(milliseconds);
	}

	public static int ToMilliseconds(TimeSpan timeout)
	{
		if (timeout == TimeSpan.MaxValue)
		{
			return -1;
		}
		long num = Ticks.FromTimeSpan(timeout);
		if (num / 10000 > int.MaxValue)
		{
			return int.MaxValue;
		}
		return Ticks.ToMilliseconds(num);
	}

	public static TimeSpan Min(TimeSpan val1, TimeSpan val2)
	{
		if (val1 > val2)
		{
			return val2;
		}
		return val1;
	}

	public static TimeSpan Add(TimeSpan timeout1, TimeSpan timeout2)
	{
		return Ticks.ToTimeSpan(Ticks.Add(Ticks.FromTimeSpan(timeout1), Ticks.FromTimeSpan(timeout2)));
	}

	public static DateTime Add(DateTime time, TimeSpan timeout)
	{
		if (timeout >= TimeSpan.Zero && DateTime.MaxValue - time <= timeout)
		{
			return DateTime.MaxValue;
		}
		if (timeout <= TimeSpan.Zero && DateTime.MinValue - time >= timeout)
		{
			return DateTime.MinValue;
		}
		return time + timeout;
	}

	public static DateTime Subtract(DateTime time, TimeSpan timeout)
	{
		return Add(time, TimeSpan.Zero - timeout);
	}

	public static TimeSpan Divide(TimeSpan timeout, int factor)
	{
		if (timeout == TimeSpan.MaxValue)
		{
			return TimeSpan.MaxValue;
		}
		return Ticks.ToTimeSpan(Ticks.FromTimeSpan(timeout) / factor + 1);
	}

	public TimeSpan RemainingTime()
	{
		if (!_deadlineSet)
		{
			SetDeadline();
			return OriginalTimeout;
		}
		if (_deadline == DateTime.MaxValue)
		{
			return TimeSpan.MaxValue;
		}
		TimeSpan timeSpan = _deadline - DateTime.UtcNow;
		if (timeSpan <= TimeSpan.Zero)
		{
			return TimeSpan.Zero;
		}
		return timeSpan;
	}

	public TimeSpan ElapsedTime()
	{
		return OriginalTimeout - RemainingTime();
	}

	private void SetDeadline()
	{
		_deadline = DateTime.UtcNow + OriginalTimeout;
		_deadlineSet = true;
	}

	public static void ThrowIfNegativeArgument(TimeSpan timeout)
	{
		ThrowIfNegativeArgument(timeout, "timeout");
	}

	public static void ThrowIfNegativeArgument(TimeSpan timeout, string argumentName)
	{
		if (timeout < TimeSpan.Zero)
		{
			throw Fx.Exception.ArgumentOutOfRange(argumentName, timeout, InternalSR.TimeoutMustBeNonNegative(argumentName, timeout));
		}
	}

	public static void ThrowIfNonPositiveArgument(TimeSpan timeout)
	{
		ThrowIfNonPositiveArgument(timeout, "timeout");
	}

	public static void ThrowIfNonPositiveArgument(TimeSpan timeout, string argumentName)
	{
		if (timeout <= TimeSpan.Zero)
		{
			throw Fx.Exception.ArgumentOutOfRange(argumentName, timeout, InternalSR.TimeoutMustBePositive(argumentName, timeout));
		}
	}

	public static bool WaitOne(WaitHandle waitHandle, TimeSpan timeout)
	{
		ThrowIfNegativeArgument(timeout);
		if (timeout == TimeSpan.MaxValue)
		{
			waitHandle.WaitOne();
			return true;
		}
		return waitHandle.WaitOne(timeout);
	}

	internal static TimeoutException CreateEnterTimedOutException(TimeSpan timeout)
	{
		return new TimeoutException(System.SR.Format(System.SR.LockTimeoutExceptionMessage, timeout));
	}
}

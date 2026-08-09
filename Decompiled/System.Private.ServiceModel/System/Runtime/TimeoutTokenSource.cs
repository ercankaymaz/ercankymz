using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime;

internal static class TimeoutTokenSource
{
	private const int CoalescingFactor = 15;

	private const int GranularityFactor = 2000;

	private const int SegmentationFactor = 30000;

	private static readonly ConcurrentDictionary<long, Task<CancellationToken>> s_tokenCache = new ConcurrentDictionary<long, Task<CancellationToken>>();

	private static readonly Action<object> s_deregisterToken = delegate(object state)
	{
		Tuple<long, CancellationTokenSource> tuple = (Tuple<long, CancellationTokenSource>)state;
		try
		{
			s_tokenCache.TryRemove(tuple.Item1, out var _);
		}
		finally
		{
			tuple.Item2.Dispose();
		}
	};

	public static CancellationToken FromTimeout(int millisecondsTimeout)
	{
		return FromTimeoutAsync(millisecondsTimeout).Result;
	}

	public static Task<CancellationToken> FromTimeoutAsync(int millisecondsTimeout)
	{
		if (millisecondsTimeout < -1)
		{
			throw new ArgumentOutOfRangeException("Invalid millisecondsTimeout value " + millisecondsTimeout);
		}
		uint tickCount = (uint)Environment.TickCount;
		long num = millisecondsTimeout + tickCount;
		int num2 = millisecondsTimeout / 30000;
		int num3 = 15;
		while (num2 > 0)
		{
			num2 >>= 1;
			num3 <<= 1;
		}
		num = (num + (num3 - 1)) / num3 * num3;
		if (!s_tokenCache.TryGetValue(num, out var value))
		{
			TaskCompletionSource<CancellationToken> taskCompletionSource = new TaskCompletionSource<CancellationToken>(TaskCreationOptions.RunContinuationsAsynchronously);
			if (s_tokenCache.TryAdd(num, taskCompletionSource.Task))
			{
				CancellationTokenSource cancellationTokenSource = new CancellationTokenSource((int)(num - tickCount));
				CancellationToken token = cancellationTokenSource.Token;
				token.Register(s_deregisterToken, Tuple.Create(num, cancellationTokenSource));
				taskCompletionSource.TrySetResult(token);
				return taskCompletionSource.Task;
			}
			if (!s_tokenCache.TryGetValue(num, out value))
			{
				return Task.FromResult(new CancellationTokenSource(millisecondsTimeout).Token);
			}
		}
		return value;
	}
}

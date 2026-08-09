using System.Diagnostics.Tracing;
using System.Runtime.Versioning;
using System.Threading;

namespace System.Runtime.Caching;

[UnsupportedOSPlatform("browser")]
internal sealed class Counters : EventSource
{
	private const string EVENT_SOURCE_NAME_ROOT = "System.Runtime.Caching.";

	private const int NUM_COUNTERS = 7;

	private DiagnosticCounter[] _counters;

	private long[] _counterValues;

	internal Counters(string cacheName)
		: base("System.Runtime.Caching." + (cacheName ?? throw new ArgumentNullException("cacheName")))
	{
		InitDisposableMembers();
	}

	private void InitDisposableMembers()
	{
		bool flag = true;
		try
		{
			_counters = new DiagnosticCounter[7];
			_counterValues = new long[7];
			_counters[0] = CreatePollingCounter("entries", "Cache Entries", 0);
			_counters[1] = CreatePollingCounter("hits", "Cache Hits", 1);
			_counters[4] = CreatePollingCounter("misses", "Cache Misses", 4);
			_counters[5] = CreatePollingCounter("trims", "Cache Trims", 5);
			_counters[6] = new IncrementingPollingCounter("turnover", this, () => _counterValues[6])
			{
				DisplayName = "Cache Turnover Rate"
			};
			_counters[2] = new PollingCounter("hit-ratio", this, () => (double)_counterValues[2] / (double)_counterValues[3] * 100.0)
			{
				DisplayName = "Cache Hit Ratio"
			};
			flag = false;
		}
		finally
		{
			if (flag)
			{
				Dispose();
			}
		}
	}

	private PollingCounter CreatePollingCounter(string name, string displayName, int counterIndex)
	{
		return new PollingCounter(name, this, () => _counterValues[counterIndex])
		{
			DisplayName = displayName
		};
	}

	public new void Dispose()
	{
		DiagnosticCounter[] counters = _counters;
		if (counters != null && Interlocked.CompareExchange(ref _counters, null, counters) == counters)
		{
			for (int i = 0; i < 7; i++)
			{
				counters[i]?.Dispose();
			}
		}
	}

	internal void Increment(CounterName name)
	{
		Interlocked.Increment(ref _counterValues[(int)name]);
	}

	internal void IncrementBy(CounterName name, long value)
	{
		Interlocked.Add(ref _counterValues[(int)name], value);
	}

	internal void Decrement(CounterName name)
	{
		Interlocked.Decrement(ref _counterValues[(int)name]);
	}
}

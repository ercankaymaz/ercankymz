using System.Threading;

namespace System.Runtime.Caching;

internal sealed class CacheUsage
{
	internal static readonly TimeSpan NEWADD_INTERVAL = new TimeSpan(0, 0, 10);

	internal static readonly TimeSpan CORRELATED_REQUEST_TIMEOUT = new TimeSpan(0, 0, 1);

	internal static readonly TimeSpan MIN_LIFETIME_FOR_USAGE = NEWADD_INTERVAL;

	private const byte NUMBUCKETS = 1;

	private readonly MemoryCacheStore _cacheStore;

	internal readonly UsageBucket[] _buckets;

	private int _inFlush;

	internal MemoryCacheStore MemoryCacheStore => _cacheStore;

	internal CacheUsage(MemoryCacheStore cacheStore)
	{
		_cacheStore = cacheStore;
		_buckets = new UsageBucket[1];
		for (byte b = 0; b < _buckets.Length; b++)
		{
			_buckets[b] = new UsageBucket(this, b);
		}
	}

	internal void Add(MemoryCacheEntry cacheEntry)
	{
		byte usageBucket = cacheEntry.UsageBucket;
		_buckets[usageBucket].AddCacheEntry(cacheEntry);
	}

	internal void Remove(MemoryCacheEntry cacheEntry)
	{
		byte usageBucket = cacheEntry.UsageBucket;
		if (usageBucket != byte.MaxValue)
		{
			_buckets[usageBucket].RemoveCacheEntry(cacheEntry);
		}
	}

	internal void Update(MemoryCacheEntry cacheEntry)
	{
		byte usageBucket = cacheEntry.UsageBucket;
		if (usageBucket != byte.MaxValue)
		{
			_buckets[usageBucket].UpdateCacheEntry(cacheEntry);
		}
	}

	internal int FlushUnderUsedItems(int toFlush)
	{
		int num = 0;
		if (Interlocked.Exchange(ref _inFlush, 1) == 0)
		{
			try
			{
				UsageBucket[] buckets = _buckets;
				foreach (UsageBucket usageBucket in buckets)
				{
					int num2 = usageBucket.FlushUnderUsedItems(toFlush - num, force: false);
					num += num2;
					if (num >= toFlush)
					{
						break;
					}
				}
				if (num < toFlush)
				{
					UsageBucket[] buckets2 = _buckets;
					foreach (UsageBucket usageBucket2 in buckets2)
					{
						int num3 = usageBucket2.FlushUnderUsedItems(toFlush - num, force: true);
						num += num3;
						if (num >= toFlush)
						{
							break;
						}
					}
				}
			}
			finally
			{
				Interlocked.Exchange(ref _inFlush, 0);
			}
		}
		return num;
	}
}

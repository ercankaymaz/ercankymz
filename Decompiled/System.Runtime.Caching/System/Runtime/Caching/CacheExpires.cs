using System.Threading;

namespace System.Runtime.Caching;

internal sealed class CacheExpires
{
	internal static readonly TimeSpan MIN_UPDATE_DELTA = new TimeSpan(0, 0, 1);

	internal static readonly TimeSpan MIN_FLUSH_INTERVAL = new TimeSpan(0, 0, 1);

	internal static readonly TimeSpan _tsPerBucket = new TimeSpan(0, 0, 20);

	private const int NUMBUCKETS = 30;

	private static readonly TimeSpan s_tsPerCycle = new TimeSpan(30 * _tsPerBucket.Ticks);

	private readonly MemoryCacheStore _cacheStore;

	private readonly ExpiresBucket[] _buckets;

	private GCHandleRef<Timer> _timerHandleRef;

	private DateTime _utcLastFlush;

	private int _inFlush;

	internal MemoryCacheStore MemoryCacheStore => _cacheStore;

	internal CacheExpires(MemoryCacheStore cacheStore)
	{
		DateTime utcNow = DateTime.UtcNow;
		_cacheStore = cacheStore;
		_buckets = new ExpiresBucket[30];
		for (byte b = 0; b < _buckets.Length; b++)
		{
			_buckets[b] = new ExpiresBucket(this, b, utcNow);
		}
	}

	private static int UtcCalcExpiresBucket(DateTime utcDate)
	{
		long num = utcDate.Ticks % s_tsPerCycle.Ticks;
		return (int)((num / _tsPerBucket.Ticks + 1) % 30);
	}

	private int FlushExpiredItems(bool checkDelta, bool useInsertBlock)
	{
		int num = 0;
		if (Interlocked.Exchange(ref _inFlush, 1) == 0)
		{
			try
			{
				if (_timerHandleRef == null)
				{
					return 0;
				}
				DateTime utcNow = DateTime.UtcNow;
				if (!checkDelta || utcNow - _utcLastFlush >= MIN_FLUSH_INTERVAL || utcNow < _utcLastFlush)
				{
					_utcLastFlush = utcNow;
					ExpiresBucket[] buckets = _buckets;
					foreach (ExpiresBucket expiresBucket in buckets)
					{
						num += expiresBucket.FlushExpiredItems(utcNow, useInsertBlock);
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

	internal int FlushExpiredItems(bool useInsertBlock)
	{
		return FlushExpiredItems(checkDelta: true, useInsertBlock);
	}

	private void TimerCallback(object state)
	{
		FlushExpiredItems(checkDelta: false, useInsertBlock: false);
	}

	internal void EnableExpirationTimer(bool enable)
	{
		if (enable)
		{
			if (_timerHandleRef != null)
			{
				return;
			}
			DateTime utcNow = DateTime.UtcNow;
			TimeSpan timeSpan = _tsPerBucket - new TimeSpan(utcNow.Ticks % _tsPerBucket.Ticks);
			bool flag = false;
			Timer t;
			try
			{
				if (!ExecutionContext.IsFlowSuppressed())
				{
					ExecutionContext.SuppressFlow();
					flag = true;
				}
				t = new Timer(TimerCallback, null, timeSpan.Ticks / 10000, _tsPerBucket.Ticks / 10000);
			}
			finally
			{
				if (flag)
				{
					ExecutionContext.RestoreFlow();
				}
			}
			_timerHandleRef = new GCHandleRef<Timer>(t);
			return;
		}
		GCHandleRef<Timer> timerHandleRef = _timerHandleRef;
		if (timerHandleRef != null && Interlocked.CompareExchange(ref _timerHandleRef, null, timerHandleRef) == timerHandleRef)
		{
			timerHandleRef.Dispose();
			while (_inFlush != 0)
			{
				Thread.Sleep(100);
			}
		}
	}

	internal void Add(MemoryCacheEntry cacheEntry)
	{
		DateTime utcNow = DateTime.UtcNow;
		if (utcNow > cacheEntry.UtcAbsExp)
		{
			cacheEntry.UtcAbsExp = utcNow;
		}
		int num = UtcCalcExpiresBucket(cacheEntry.UtcAbsExp);
		_buckets[num].AddCacheEntry(cacheEntry);
	}

	internal void Remove(MemoryCacheEntry cacheEntry)
	{
		byte expiresBucket = cacheEntry.ExpiresBucket;
		if (expiresBucket != byte.MaxValue)
		{
			_buckets[expiresBucket].RemoveCacheEntry(cacheEntry);
		}
	}

	internal void UtcUpdate(MemoryCacheEntry cacheEntry, DateTime utcNewExpires)
	{
		int expiresBucket = cacheEntry.ExpiresBucket;
		int num = UtcCalcExpiresBucket(utcNewExpires);
		if (expiresBucket != num)
		{
			if (expiresBucket != 255)
			{
				_buckets[expiresBucket].RemoveCacheEntry(cacheEntry);
				cacheEntry.UtcAbsExp = utcNewExpires;
				_buckets[num].AddCacheEntry(cacheEntry);
			}
		}
		else if (expiresBucket != 255)
		{
			_buckets[expiresBucket].UtcUpdateCacheEntry(cacheEntry, utcNewExpires);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace System.ServiceModel.Security;

internal class TimeBoundedCache
{
	internal interface IExpirableItem
	{
		DateTime ExpirationTime { get; }
	}

	internal class ExpirableItemComparer : IComparer<IExpirableItem>
	{
		private static ExpirableItemComparer s_instance;

		public static ExpirableItemComparer Default
		{
			get
			{
				if (s_instance == null)
				{
					s_instance = new ExpirableItemComparer();
				}
				return s_instance;
			}
		}

		public int Compare(IExpirableItem item1, IExpirableItem item2)
		{
			if (item1 == item2)
			{
				return 0;
			}
			if (item1.ExpirationTime < item2.ExpirationTime)
			{
				return 1;
			}
			if (item1.ExpirationTime > item2.ExpirationTime)
			{
				return -1;
			}
			return 0;
		}
	}

	internal sealed class ExpirableItem : IExpirableItem
	{
		private object _item;

		public DateTime ExpirationTime { get; }

		public object Item => _item;

		public ExpirableItem(object item, DateTime expirationTime)
		{
			_item = item;
			ExpirationTime = expirationTime;
		}
	}

	private static Action<object> s_purgeCallback;

	private Hashtable _entries;

	private int _lowWaterMark;

	private DateTime _nextPurgeTimeUtc;

	private TimeSpan _purgeInterval;

	private PurgingMode _purgingMode;

	private Timer _purgingTimer;

	private bool _doRemoveNotification;

	public int Count => _entries.Count;

	private static Action<object> PurgeCallback
	{
		get
		{
			if (s_purgeCallback == null)
			{
				s_purgeCallback = PurgeCallbackStatic;
			}
			return s_purgeCallback;
		}
	}

	protected int Capacity { get; }

	protected Hashtable Entries => _entries;

	protected ReaderWriterLockSlim CacheLock { get; }

	protected TimeBoundedCache(int lowWaterMark, int maxCacheItems, IEqualityComparer keyComparer, PurgingMode purgingMode, TimeSpan purgeInterval, bool doRemoveNotification)
	{
		_entries = new Hashtable(keyComparer);
		CacheLock = new ReaderWriterLockSlim();
		_lowWaterMark = lowWaterMark;
		Capacity = maxCacheItems;
		_purgingMode = purgingMode;
		_purgeInterval = purgeInterval;
		_doRemoveNotification = doRemoveNotification;
		_nextPurgeTimeUtc = DateTime.UtcNow.Add(_purgeInterval);
	}

	protected bool TryAddItem(object key, object item, DateTime expirationTime, bool replaceExistingEntry)
	{
		return TryAddItem(key, new ExpirableItem(item, expirationTime), replaceExistingEntry);
	}

	private void CancelTimerIfNeeded()
	{
		if (Count == 0 && _purgingTimer != null)
		{
			_purgingTimer.Change(TimeSpan.FromMilliseconds(-1.0), TimeSpan.FromMilliseconds(-1.0));
			_purgingTimer.Dispose();
			_purgingTimer = null;
		}
	}

	private void StartTimerIfNeeded()
	{
		if (_purgingMode == PurgingMode.TimerBasedPurge && _purgingTimer == null)
		{
			_purgingTimer = new Timer(PurgeCallback.Invoke, this, _purgeInterval, TimeSpan.FromMilliseconds(-1.0));
		}
	}

	protected bool TryAddItem(object key, IExpirableItem item, bool replaceExistingEntry)
	{
		bool flag = false;
		try
		{
			try
			{
			}
			finally
			{
				CacheLock.EnterWriteLock();
				flag = true;
			}
			PurgeIfNeeded();
			EnforceQuota();
			IExpirableItem expirableItem = _entries[key] as IExpirableItem;
			if (expirableItem == null || IsExpired(expirableItem))
			{
				_entries[key] = item;
			}
			else
			{
				if (!replaceExistingEntry)
				{
					return false;
				}
				_entries[key] = item;
			}
			if (expirableItem != null && _doRemoveNotification)
			{
				OnRemove(ExtractItem(expirableItem));
			}
			StartTimerIfNeeded();
			return true;
		}
		finally
		{
			if (flag)
			{
				CacheLock.ExitWriteLock();
			}
		}
	}

	protected bool TryReplaceItem(object key, object item, DateTime expirationTime)
	{
		bool flag = false;
		try
		{
			try
			{
			}
			finally
			{
				CacheLock.EnterWriteLock();
				flag = true;
			}
			PurgeIfNeeded();
			EnforceQuota();
			if (!(_entries[key] is IExpirableItem expirableItem) || IsExpired(expirableItem))
			{
				return false;
			}
			_entries[key] = new ExpirableItem(item, expirationTime);
			if (expirableItem != null && _doRemoveNotification)
			{
				OnRemove(ExtractItem(expirableItem));
			}
			StartTimerIfNeeded();
			return true;
		}
		finally
		{
			if (flag)
			{
				CacheLock.ExitWriteLock();
			}
		}
	}

	protected void ClearItems()
	{
		bool flag = false;
		try
		{
			try
			{
			}
			finally
			{
				CacheLock.EnterWriteLock();
				flag = true;
			}
			int count = _entries.Count;
			if (_doRemoveNotification)
			{
				foreach (IExpirableItem value in _entries.Values)
				{
					OnRemove(ExtractItem(value));
				}
			}
			_entries.Clear();
			CancelTimerIfNeeded();
		}
		finally
		{
			if (flag)
			{
				CacheLock.ExitWriteLock();
			}
		}
	}

	protected object GetItem(object key)
	{
		bool flag = false;
		try
		{
			try
			{
			}
			finally
			{
				CacheLock.EnterReadLock();
				flag = true;
			}
			if (!(_entries[key] is IExpirableItem expirableItem))
			{
				return null;
			}
			if (IsExpired(expirableItem))
			{
				return null;
			}
			return ExtractItem(expirableItem);
		}
		finally
		{
			if (flag)
			{
				CacheLock.ExitReadLock();
			}
		}
	}

	protected virtual ArrayList OnQuotaReached(Hashtable cacheTable)
	{
		ThrowQuotaReachedException();
		return null;
	}

	protected virtual void OnRemove(object item)
	{
	}

	protected bool TryRemoveItem(object key)
	{
		bool flag = false;
		try
		{
			try
			{
			}
			finally
			{
				CacheLock.EnterWriteLock();
				flag = true;
			}
			PurgeIfNeeded();
			IExpirableItem expirableItem = _entries[key] as IExpirableItem;
			bool result = expirableItem != null && !IsExpired(expirableItem);
			if (expirableItem != null)
			{
				_entries.Remove(key);
				if (_doRemoveNotification)
				{
					OnRemove(ExtractItem(expirableItem));
				}
				CancelTimerIfNeeded();
			}
			return result;
		}
		finally
		{
			if (flag)
			{
				CacheLock.ExitWriteLock();
			}
		}
	}

	private void EnforceQuota()
	{
		if (!CacheLock.IsWriteLockHeld)
		{
			Environment.FailFast("Cache write lock is not held.");
		}
		if (Count < Capacity)
		{
			return;
		}
		ArrayList arrayList = OnQuotaReached(_entries);
		if (arrayList != null)
		{
			for (int i = 0; i < arrayList.Count; i++)
			{
				_entries.Remove(arrayList[i]);
			}
		}
		CancelTimerIfNeeded();
		if (Count >= Capacity)
		{
			ThrowQuotaReachedException();
		}
	}

	protected object ExtractItem(IExpirableItem val)
	{
		if (val is ExpirableItem expirableItem)
		{
			return expirableItem.Item;
		}
		return val;
	}

	private bool IsExpired(IExpirableItem item)
	{
		return item.ExpirationTime <= DateTime.UtcNow;
	}

	private bool ShouldPurge()
	{
		if (Count >= Capacity)
		{
			return true;
		}
		if (_purgingMode == PurgingMode.AccessBasedPurge && DateTime.UtcNow > _nextPurgeTimeUtc && Count > _lowWaterMark)
		{
			return true;
		}
		return false;
	}

	private void PurgeIfNeeded()
	{
		if (!CacheLock.IsWriteLockHeld)
		{
			Environment.FailFast("Cache write lock is not held.");
		}
		if (ShouldPurge())
		{
			PurgeStaleItems();
		}
	}

	private void PurgeStaleItems()
	{
		if (!CacheLock.IsWriteLockHeld)
		{
			Environment.FailFast("Cache write lock is not held.");
		}
		ArrayList arrayList = new ArrayList();
		foreach (object key in _entries.Keys)
		{
			IExpirableItem expirableItem = _entries[key] as IExpirableItem;
			if (IsExpired(expirableItem))
			{
				OnRemove(ExtractItem(expirableItem));
				arrayList.Add(key);
			}
		}
		for (int i = 0; i < arrayList.Count; i++)
		{
			_entries.Remove(arrayList[i]);
		}
		CancelTimerIfNeeded();
		_nextPurgeTimeUtc = DateTime.UtcNow.Add(_purgeInterval);
	}

	private void ThrowQuotaReachedException()
	{
		string message = System.SR.Format(System.SR.CacheQuotaReached, Capacity);
		Exception innerException = new QuotaExceededException(message);
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(message, innerException));
	}

	private static void PurgeCallbackStatic(object state)
	{
		TimeBoundedCache timeBoundedCache = (TimeBoundedCache)state;
		bool flag = false;
		try
		{
			try
			{
			}
			finally
			{
				timeBoundedCache.CacheLock.EnterWriteLock();
				flag = true;
			}
			if (timeBoundedCache._purgingTimer != null)
			{
				timeBoundedCache.PurgeStaleItems();
				if (timeBoundedCache.Count > 0 && timeBoundedCache._purgingTimer != null)
				{
					timeBoundedCache._purgingTimer.Change(timeBoundedCache._purgeInterval, TimeSpan.FromMilliseconds(-1.0));
				}
			}
		}
		finally
		{
			if (flag)
			{
				timeBoundedCache.CacheLock.ExitWriteLock();
			}
		}
	}
}

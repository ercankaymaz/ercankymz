using System.Collections.Generic;
using System.Security;

namespace System.Runtime;

internal class SynchronizedPool<T> where T : class
{
	private struct Entry
	{
		public int threadID;

		public T value;
	}

	private struct PendingEntry
	{
		public int returnCount;

		public int threadID;
	}

	internal static class SynchronizedPoolHelper
	{
		public static readonly int ProcessorCount = GetProcessorCount();

		[SecuritySafeCritical]
		private static int GetProcessorCount()
		{
			return Environment.ProcessorCount;
		}
	}

	internal class GlobalPool
	{
		private Stack<T> _items;

		private int _maxCount;

		public int MaxCount
		{
			get
			{
				return _maxCount;
			}
			set
			{
				lock (ThisLock)
				{
					while (_items.Count > value)
					{
						_items.Pop();
					}
					_maxCount = value;
				}
			}
		}

		private object ThisLock => this;

		public GlobalPool(int maxCount)
		{
			_items = new Stack<T>();
			_maxCount = maxCount;
		}

		public void DecrementMaxCount()
		{
			lock (ThisLock)
			{
				if (_items.Count == _maxCount)
				{
					_items.Pop();
				}
				_maxCount--;
			}
		}

		public T Take()
		{
			if (_items.Count > 0)
			{
				lock (ThisLock)
				{
					if (_items.Count > 0)
					{
						return _items.Pop();
					}
				}
			}
			return null;
		}

		public bool Return(T value)
		{
			if (_items.Count < MaxCount)
			{
				lock (ThisLock)
				{
					if (_items.Count < MaxCount)
					{
						_items.Push(value);
						return true;
					}
				}
			}
			return false;
		}

		public void Clear()
		{
			lock (ThisLock)
			{
				_items.Clear();
			}
		}
	}

	private const int maxPendingEntries = 128;

	private const int maxPromotionFailures = 64;

	private const int maxReturnsBeforePromotion = 64;

	private const int maxThreadItemsPerProcessor = 16;

	private Entry[] _entries;

	private GlobalPool _globalPool;

	private int _maxCount;

	private PendingEntry[] _pending;

	private int _promotionFailures;

	private object ThisLock => this;

	public SynchronizedPool(int maxCount)
	{
		int num = maxCount;
		int num2 = 16 + SynchronizedPoolHelper.ProcessorCount;
		if (num > num2)
		{
			num = num2;
		}
		_maxCount = maxCount;
		_entries = new Entry[num];
		_pending = new PendingEntry[4];
		_globalPool = new GlobalPool(maxCount);
	}

	public void Clear()
	{
		Entry[] entries = _entries;
		for (int i = 0; i < entries.Length; i++)
		{
			entries[i].value = null;
		}
		_globalPool.Clear();
	}

	private void HandlePromotionFailure(int thisThreadID)
	{
		int num = _promotionFailures + 1;
		if (num >= 64)
		{
			lock (ThisLock)
			{
				_entries = new Entry[_entries.Length];
				_globalPool.MaxCount = _maxCount;
			}
			PromoteThread(thisThreadID);
		}
		else
		{
			_promotionFailures = num;
		}
	}

	private bool PromoteThread(int thisThreadID)
	{
		lock (ThisLock)
		{
			for (int i = 0; i < _entries.Length; i++)
			{
				int threadID = _entries[i].threadID;
				if (threadID == thisThreadID)
				{
					return true;
				}
				if (threadID == 0)
				{
					_globalPool.DecrementMaxCount();
					_entries[i].threadID = thisThreadID;
					return true;
				}
			}
		}
		return false;
	}

	private void RecordReturnToGlobalPool(int thisThreadID)
	{
		PendingEntry[] pending = _pending;
		for (int i = 0; i < pending.Length; i++)
		{
			int threadID = pending[i].threadID;
			if (threadID == thisThreadID)
			{
				int num = pending[i].returnCount + 1;
				if (num >= 64)
				{
					pending[i].returnCount = 0;
					if (!PromoteThread(thisThreadID))
					{
						HandlePromotionFailure(thisThreadID);
					}
				}
				else
				{
					pending[i].returnCount = num;
				}
				break;
			}
			if (threadID == 0)
			{
				break;
			}
		}
	}

	private void RecordTakeFromGlobalPool(int thisThreadID)
	{
		PendingEntry[] pending = _pending;
		for (int i = 0; i < pending.Length; i++)
		{
			int threadID = pending[i].threadID;
			if (threadID == thisThreadID)
			{
				return;
			}
			if (threadID != 0)
			{
				continue;
			}
			lock (pending)
			{
				if (pending[i].threadID == 0)
				{
					pending[i].threadID = thisThreadID;
					return;
				}
			}
		}
		if (pending.Length >= 128)
		{
			_pending = new PendingEntry[pending.Length];
			return;
		}
		PendingEntry[] array = new PendingEntry[pending.Length * 2];
		Array.Copy(pending, array, pending.Length);
		_pending = array;
	}

	public bool Return(T value)
	{
		int currentManagedThreadId = Environment.CurrentManagedThreadId;
		if (currentManagedThreadId == 0)
		{
			return false;
		}
		if (ReturnToPerThreadPool(currentManagedThreadId, value))
		{
			return true;
		}
		return ReturnToGlobalPool(currentManagedThreadId, value);
	}

	private bool ReturnToPerThreadPool(int thisThreadID, T value)
	{
		Entry[] entries = _entries;
		for (int i = 0; i < entries.Length; i++)
		{
			int threadID = entries[i].threadID;
			if (threadID == thisThreadID)
			{
				if (entries[i].value == null)
				{
					entries[i].value = value;
					return true;
				}
				return false;
			}
			if (threadID == 0)
			{
				break;
			}
		}
		return false;
	}

	private bool ReturnToGlobalPool(int thisThreadID, T value)
	{
		RecordReturnToGlobalPool(thisThreadID);
		return _globalPool.Return(value);
	}

	public T Take()
	{
		int currentManagedThreadId = Environment.CurrentManagedThreadId;
		if (currentManagedThreadId == 0)
		{
			return null;
		}
		T val = TakeFromPerThreadPool(currentManagedThreadId);
		if (val != null)
		{
			return val;
		}
		return TakeFromGlobalPool(currentManagedThreadId);
	}

	private T TakeFromPerThreadPool(int thisThreadID)
	{
		Entry[] entries = _entries;
		for (int i = 0; i < entries.Length; i++)
		{
			int threadID = entries[i].threadID;
			if (threadID == thisThreadID)
			{
				T value = entries[i].value;
				if (value != null)
				{
					entries[i].value = null;
					return value;
				}
				return null;
			}
			if (threadID == 0)
			{
				break;
			}
		}
		return null;
	}

	private T TakeFromGlobalPool(int thisThreadID)
	{
		RecordTakeFromGlobalPool(thisThreadID);
		return _globalPool.Take();
	}
}

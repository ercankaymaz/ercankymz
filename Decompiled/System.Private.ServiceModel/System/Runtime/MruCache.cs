using System.Collections.Generic;
using System.ServiceModel;

namespace System.Runtime;

internal class MruCache<TKey, TValue> : IDisposable where TKey : class where TValue : class
{
	private struct CacheEntry
	{
		internal TValue value;

		internal LinkedListNode<TKey> node;
	}

	private LinkedList<TKey> _mruList;

	private Dictionary<TKey, CacheEntry> _items;

	private readonly int _lowWatermark;

	private readonly int _highWatermark;

	private CacheEntry _mruEntry;

	private int _refCount = 1;

	private object _mutex = new object();

	public int Count
	{
		get
		{
			ThrowIfDisposed();
			return _items.Count;
		}
	}

	public bool IsDisposed { get; private set; }

	public MruCache(int watermark)
		: this(watermark * 4 / 5, watermark)
	{
	}

	public bool AddRef()
	{
		lock (_mutex)
		{
			if (_refCount == 0)
			{
				return false;
			}
			_refCount++;
			return true;
		}
	}

	public MruCache(int lowWatermark, int highWatermark)
		: this(lowWatermark, highWatermark, (IEqualityComparer<TKey>)null)
	{
	}

	public MruCache(int lowWatermark, int highWatermark, IEqualityComparer<TKey> comparer)
	{
		_lowWatermark = lowWatermark;
		_highWatermark = highWatermark;
		_mruList = new LinkedList<TKey>();
		if (comparer == null)
		{
			_items = new Dictionary<TKey, CacheEntry>();
		}
		else
		{
			_items = new Dictionary<TKey, CacheEntry>(comparer);
		}
	}

	public void Add(TKey key, TValue value)
	{
		ThrowIfDisposed();
		bool flag = false;
		try
		{
			if (_items.Count == _highWatermark)
			{
				int num = _highWatermark - _lowWatermark;
				for (int i = 0; i < num; i++)
				{
					TKey value2 = _mruList.Last.Value;
					_mruList.RemoveLast();
					TValue value3 = _items[value2].value;
					_items.Remove(value2);
					OnSingleItemRemoved(value3);
					OnItemAgedOutOfCache(value3);
				}
			}
			CacheEntry cacheEntry = default(CacheEntry);
			cacheEntry.node = _mruList.AddFirst(key);
			cacheEntry.value = value;
			_items.Add(key, cacheEntry);
			_mruEntry = cacheEntry;
			flag = true;
		}
		finally
		{
			if (!flag)
			{
				Clear();
			}
		}
	}

	public void Clear()
	{
		ThrowIfDisposed();
		Clear(dispose: false);
	}

	private void Clear(bool dispose)
	{
		_mruList.Clear();
		if (dispose)
		{
			foreach (CacheEntry value in _items.Values)
			{
				if (!(value.value is IDisposable disposable))
				{
					continue;
				}
				try
				{
					disposable.Dispose();
				}
				catch (Exception exception)
				{
					if (Fx.IsFatal(exception))
					{
						throw;
					}
				}
			}
		}
		_items.Clear();
		_mruEntry.value = null;
		_mruEntry.node = null;
	}

	public bool Remove(TKey key)
	{
		ThrowIfDisposed();
		if (_items.TryGetValue(key, out var value))
		{
			_items.Remove(key);
			OnSingleItemRemoved(value.value);
			_mruList.Remove(value.node);
			if (_mruEntry.node == value.node)
			{
				_mruEntry.value = null;
				_mruEntry.node = null;
			}
			return true;
		}
		return false;
	}

	protected virtual void OnSingleItemRemoved(TValue item)
	{
		ThrowIfDisposed();
	}

	protected virtual void OnItemAgedOutOfCache(TValue item)
	{
		ThrowIfDisposed();
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		if (_mruEntry.node != null && key != null && key.Equals(_mruEntry.node.Value))
		{
			value = _mruEntry.value;
			return true;
		}
		CacheEntry value2;
		bool flag = _items.TryGetValue(key, out value2);
		value = value2.value;
		if (flag && _mruList.Count > 1 && _mruList.First != value2.node)
		{
			_mruList.Remove(value2.node);
			_mruList.AddFirst(value2.node);
			_mruEntry = value2;
		}
		return flag;
	}

	public void Dispose()
	{
		int num;
		lock (_mutex)
		{
			num = --_refCount;
		}
		if (num == 0)
		{
			Dispose(disposing: true);
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposing)
		{
			return;
		}
		lock (_mutex)
		{
			if (!IsDisposed)
			{
				IsDisposed = true;
				Clear(dispose: true);
			}
		}
	}

	private void ThrowIfDisposed()
	{
		if (IsDisposed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().FullName));
		}
	}
}

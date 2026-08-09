using System.Collections.Generic;

namespace System.ServiceModel.Channels;

internal abstract class QueuedObjectPool<T>
{
	private Queue<T> _objectQueue;

	private bool _isClosed;

	private int _batchAllocCount;

	private int _maxFreeCount;

	private object ThisLock => _objectQueue;

	protected void Initialize(int batchAllocCount, int maxFreeCount)
	{
		if (batchAllocCount <= 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("batchAllocCount"));
		}
		_batchAllocCount = batchAllocCount;
		_maxFreeCount = maxFreeCount;
		_objectQueue = new Queue<T>(batchAllocCount);
	}

	public virtual bool Return(T value)
	{
		lock (ThisLock)
		{
			if (_objectQueue.Count < _maxFreeCount && !_isClosed)
			{
				_objectQueue.Enqueue(value);
				return true;
			}
			return false;
		}
	}

	public T Take()
	{
		lock (ThisLock)
		{
			if (_objectQueue.Count == 0)
			{
				AllocObjects();
			}
			return _objectQueue.Dequeue();
		}
	}

	public void Close()
	{
		lock (ThisLock)
		{
			foreach (T item in _objectQueue)
			{
				if (item != null)
				{
					CleanupItem(item);
				}
			}
			_objectQueue.Clear();
			_isClosed = true;
		}
	}

	protected virtual void CleanupItem(T item)
	{
	}

	protected abstract T Create();

	private void AllocObjects()
	{
		for (int i = 0; i < _batchAllocCount; i++)
		{
			_objectQueue.Enqueue(Create());
		}
	}
}

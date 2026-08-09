using System;
using System.Threading;

namespace Microsoft.Extensions.ObjectPool;

internal sealed class DisposableObjectPool<T> : DefaultObjectPool<T>, IDisposable where T : class
{
	private volatile bool _isDisposed;

	public DisposableObjectPool(IPooledObjectPolicy<T> policy)
		: base(policy)
	{
	}

	public DisposableObjectPool(IPooledObjectPolicy<T> policy, int maximumRetained)
		: base(policy, maximumRetained)
	{
	}

	public override T Get()
	{
		if (_isDisposed)
		{
			ThrowObjectDisposedException();
		}
		return base.Get();
		void ThrowObjectDisposedException()
		{
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public override void Return(T obj)
	{
		if (_isDisposed || !ReturnCore(obj))
		{
			DisposeItem(obj);
		}
	}

	private bool ReturnCore(T obj)
	{
		bool result = false;
		if (_isDefaultPolicy || (_fastPolicy?.Return(obj) ?? _policy.Return(obj)))
		{
			if (_firstItem == null && Interlocked.CompareExchange(ref _firstItem, obj, null) == null)
			{
				result = true;
			}
			else
			{
				DefaultObjectPool<T>.ObjectWrapper[] items = _items;
				for (int i = 0; i < items.Length; i++)
				{
					if (result = Interlocked.CompareExchange(ref items[i].Element, obj, null) == null)
					{
						break;
					}
				}
			}
		}
		return result;
	}

	public void Dispose()
	{
		_isDisposed = true;
		DisposeItem(_firstItem);
		_firstItem = null;
		DefaultObjectPool<T>.ObjectWrapper[] items = _items;
		for (int i = 0; i < items.Length; i++)
		{
			DisposeItem(items[i].Element);
			items[i].Element = null;
		}
	}

	private void DisposeItem(T? item)
	{
		if (item is IDisposable disposable)
		{
			disposable.Dispose();
		}
	}
}

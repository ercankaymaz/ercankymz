using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.ObjectPool;

namespace System.Runtime;

internal class AsyncLock : IAsyncDisposable
{
	private struct SafeSemaphoreRelease(SemaphoreSlim currentSemaphore, SemaphoreSlim nextSemaphore, AsyncLock asyncLock) : IAsyncDisposable, IDisposable
	{
		private SemaphoreSlim _currentSemaphore = currentSemaphore;

		private SemaphoreSlim _nextSemaphore = nextSemaphore;

		private AsyncLock _asyncLock = asyncLock;

		public ValueTask DisposeAsync()
		{
			if (_currentSemaphore == _asyncLock._topLevelSemaphore)
			{
				_asyncLock._currentSemaphore.Value = null;
			}
			else
			{
				_asyncLock._currentSemaphore.Value = _currentSemaphore;
			}
			return DisposeCoreAsync();
		}

		private async ValueTask DisposeCoreAsync()
		{
			await _nextSemaphore.WaitAsync();
			_currentSemaphore.Release();
			_nextSemaphore.Release();
			s_semaphorePool.Return(_nextSemaphore);
		}

		public void Dispose()
		{
			if (_currentSemaphore == _asyncLock._topLevelSemaphore)
			{
				_asyncLock._currentSemaphore.Value = null;
			}
			else
			{
				_asyncLock._currentSemaphore.Value = _currentSemaphore;
			}
			_nextSemaphore.Wait();
			_currentSemaphore.Release();
			_nextSemaphore.Release();
			s_semaphorePool.Return(_nextSemaphore);
		}
	}

	private class SemaphoreSlimPooledObjectPolicy : PooledObjectPolicy<SemaphoreSlim>
	{
		public override SemaphoreSlim Create()
		{
			return new SemaphoreSlim(1);
		}

		public override bool Return(SemaphoreSlim obj)
		{
			if (obj.CurrentCount != 1)
			{
				return false;
			}
			return true;
		}
	}

	private static readonly ObjectPool<SemaphoreSlim> s_semaphorePool = new DefaultObjectPoolProvider
	{
		MaximumRetained = 100
	}.Create(new SemaphoreSlimPooledObjectPolicy());

	private AsyncLocal<SemaphoreSlim> _currentSemaphore;

	private SemaphoreSlim _topLevelSemaphore;

	private bool _isDisposed;

	public AsyncLock()
	{
		_topLevelSemaphore = s_semaphorePool.Get();
		_currentSemaphore = new AsyncLocal<SemaphoreSlim>();
	}

	public Task<IAsyncDisposable> TakeLockAsync()
	{
		if (_isDisposed)
		{
			throw new ObjectDisposedException("AsyncLock");
		}
		AsyncLocal<SemaphoreSlim> currentSemaphore = _currentSemaphore;
		if (currentSemaphore.Value == null)
		{
			SemaphoreSlim semaphoreSlim = (currentSemaphore.Value = _topLevelSemaphore);
		}
		SemaphoreSlim value = _currentSemaphore.Value;
		SemaphoreSlim semaphoreSlim2 = s_semaphorePool.Get();
		_currentSemaphore.Value = semaphoreSlim2;
		SafeSemaphoreRelease safeSemaphoreRelease = new SafeSemaphoreRelease(value, semaphoreSlim2, this);
		return TakeLockCoreAsync(value, safeSemaphoreRelease);
	}

	private async Task<IAsyncDisposable> TakeLockCoreAsync(SemaphoreSlim currentSemaphore, SafeSemaphoreRelease safeSemaphoreRelease)
	{
		await currentSemaphore.WaitAsync();
		return safeSemaphoreRelease;
	}

	public IDisposable TakeLock()
	{
		if (_isDisposed)
		{
			throw new ObjectDisposedException("AsyncLock");
		}
		AsyncLocal<SemaphoreSlim> currentSemaphore = _currentSemaphore;
		if (currentSemaphore.Value == null)
		{
			SemaphoreSlim semaphoreSlim = (currentSemaphore.Value = _topLevelSemaphore);
		}
		SemaphoreSlim value = _currentSemaphore.Value;
		value.Wait();
		SemaphoreSlim semaphoreSlim2 = s_semaphorePool.Get();
		_currentSemaphore.Value = semaphoreSlim2;
		return new SafeSemaphoreRelease(value, semaphoreSlim2, this);
	}

	public async ValueTask DisposeAsync()
	{
		if (!_isDisposed)
		{
			_isDisposed = true;
			await _topLevelSemaphore.WaitAsync();
			_topLevelSemaphore.Release();
			s_semaphorePool.Return(_topLevelSemaphore);
			_topLevelSemaphore = null;
		}
	}
}

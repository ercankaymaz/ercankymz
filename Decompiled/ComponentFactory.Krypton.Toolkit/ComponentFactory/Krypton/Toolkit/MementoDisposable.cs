using System;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoDisposable : IDisposable
{
	private bool _disposed;

	~MementoDisposable()
	{
		if (!_disposed)
		{
			Dispose(disposing: false);
		}
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			Dispose(disposing: true);
		}
	}

	public virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			GC.SuppressFinalize(this);
		}
		_disposed = true;
	}
}

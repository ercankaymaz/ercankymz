using System;

namespace Microsoft.Isam.Esent.Interop;

public abstract class EsentResource : IDisposable
{
	private bool hasResource;

	private bool isDisposed;

	protected bool HasResource => hasResource;

	~EsentResource()
	{
		Dispose(isDisposing: false);
	}

	public void Dispose()
	{
		Dispose(isDisposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool isDisposing)
	{
		if (isDisposing)
		{
			if (hasResource)
			{
				ReleaseResource();
			}
			isDisposed = true;
		}
		else
		{
			_ = hasResource;
		}
	}

	protected void CheckObjectIsNotDisposed()
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("EsentResource");
		}
	}

	protected void ResourceWasAllocated()
	{
		CheckObjectIsNotDisposed();
		hasResource = true;
	}

	protected void ResourceWasReleased()
	{
		CheckObjectIsNotDisposed();
		hasResource = false;
	}

	protected abstract void ReleaseResource();
}

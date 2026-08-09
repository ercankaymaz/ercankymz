using System.Runtime.InteropServices;

namespace System.Runtime.Caching;

internal sealed class GCHandleRef<T> : IDisposable where T : class, IDisposable
{
	private GCHandle _handle;

	private T _t;

	public T Target
	{
		get
		{
			try
			{
				T val = (T)_handle.Target;
				if (val != null)
				{
					return val;
				}
			}
			catch (InvalidOperationException)
			{
			}
			return _t;
		}
	}

	public GCHandleRef(T t)
	{
		_handle = GCHandle.Alloc(t);
	}

	public void Dispose()
	{
		Target.Dispose();
		if (_handle.IsAllocated)
		{
			_t = (T)_handle.Target;
			_handle.Free();
		}
	}
}

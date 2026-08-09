using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Basler.Pylon;

internal class ScopedLock : IDisposable
{
	private object m_state;

	public ScopedLock(object lockObject)
	{
		m_state = lockObject;
		base._002Ector();
		object state = m_state;
		if (state != null)
		{
			Monitor.Enter(state);
		}
	}

	private void _007EScopedLock()
	{
		_0021ScopedLock();
	}

	private void _0021ScopedLock()
	{
		object state = m_state;
		if (state != null)
		{
			Monitor.Exit(state);
			m_state = null;
		}
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021ScopedLock();
			return;
		}
		try
		{
			_0021ScopedLock();
		}
		finally
		{
			base.Finalize();
		}
	}

	public virtual sealed void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
	}

	~ScopedLock()
	{
		Dispose(A_0: false);
	}
}

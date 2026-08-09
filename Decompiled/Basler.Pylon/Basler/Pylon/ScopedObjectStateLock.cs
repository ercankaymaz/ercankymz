using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Basler.Pylon;

internal class ScopedObjectStateLock : IDisposable
{
	private ObjectState m_state;

	public ScopedObjectStateLock(ObjectState state)
	{
		m_state = state;
		base._002Ector();
		Monitor.Enter(m_state);
		m_state.m_entryCount++;
	}

	private void _007EScopedObjectStateLock()
	{
		_0021ScopedObjectStateLock();
	}

	private void _0021ScopedObjectStateLock()
	{
		ObjectState state = m_state;
		if (state != null)
		{
			state.m_entryCount--;
			Monitor.Exit(m_state);
			m_state = null;
		}
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021ScopedObjectStateLock();
			return;
		}
		try
		{
			_0021ScopedObjectStateLock();
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

	~ScopedObjectStateLock()
	{
		Dispose(A_0: false);
	}
}

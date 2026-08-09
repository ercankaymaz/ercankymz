using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Basler.Pylon.Internal;

internal unsafe class PylonFinalizer(CPylonLibraryNative* pLibNat) : CriticalFinalizerObject, IDisposable
{
	private unsafe CPylonLibraryNative* m_pLibNat = pLibNat;

	private void _007EPylonFinalizer()
	{
		_0021PylonFinalizer();
	}

	private unsafe void _0021PylonFinalizer()
	{
		CPylonLibraryNative* pLibNat = m_pLibNat;
		CPylonLibraryNative* ptr = pLibNat;
		if (pLibNat != null)
		{
			m_pLibNat = null;
			global::_003CModule_003E.CPylonLibraryNative_002EShutdown(ptr);
		}
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_007EPylonFinalizer();
			return;
		}
		try
		{
			_0021PylonFinalizer();
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

	~PylonFinalizer()
	{
		Dispose(A_0: false);
	}
}

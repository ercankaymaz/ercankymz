using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

internal class AutoInitRelease : IDisposable
{
	private bool m_hasBeenReleased = false;

	public unsafe AutoInitRelease()
	{
		global::_003CModule_003E.CPylonLibraryNative_002EInit(global::_003CModule_003E.CPylonLibraryNative_002EgetInstance());
	}

	private void _007EAutoInitRelease()
	{
		_0021AutoInitRelease();
	}

	private unsafe void _0021AutoInitRelease()
	{
		if (!m_hasBeenReleased)
		{
			global::_003CModule_003E.CPylonLibraryNative_002ERelease(global::_003CModule_003E.CPylonLibraryNative_002EgetInstance());
			m_hasBeenReleased = true;
		}
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021AutoInitRelease();
			return;
		}
		try
		{
			_0021AutoInitRelease();
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

	~AutoInitRelease()
	{
		Dispose(A_0: false);
	}
}

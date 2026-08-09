using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using std;

namespace ModuleWorks.PPInterface;

internal class SharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E : IDisposable
{
	private unsafe shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* m_native_ptr;

	public unsafe SharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E(shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* native_ptr)
	{
		shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* ptr = (shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* native_ptr2;
		if (ptr != null)
		{
			*(int*)ptr = 0;
			((int*)ptr)[1] = 0;
			uint num = ((uint*)native_ptr)[1];
			if (num != 0)
			{
				Interlocked.Increment(ref *(int*)(num + 4));
			}
			*(int*)ptr = *(int*)native_ptr;
			((int*)ptr)[1] = ((int*)native_ptr)[1];
			native_ptr2 = ptr;
		}
		else
		{
			native_ptr2 = null;
		}
		m_native_ptr = native_ptr2;
		base._002Ector();
		GC.KeepAlive(this);
	}

	private void _007ESharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E()
	{
		_0021SharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E();
	}

	private unsafe void _0021SharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E()
	{
		shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* ptr = native_ptr;
			uint num = ((uint*)ptr)[1];
			if (num != 0)
			{
				global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)num);
			}
			global::_003CModule_003E.delete(ptr, 8u);
			m_native_ptr = null;
		}
		GC.KeepAlive(this);
	}

	public unsafe shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E();
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

	~SharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E()
	{
		Dispose(A_0: false);
	}
}

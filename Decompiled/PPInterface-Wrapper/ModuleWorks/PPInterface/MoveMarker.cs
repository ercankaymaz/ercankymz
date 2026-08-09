using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using std;

namespace ModuleWorks.PPInterface;

public abstract class MoveMarker : IDisposable
{
	private protected readonly SharedPointer_003Cppinterface_003A_003AMoveMarker_003E m_native;

	internal unsafe MoveMarker(shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* ptr)
	{
		SharedPointer_003Cppinterface_003A_003AMoveMarker_003E native = new SharedPointer_003Cppinterface_003A_003AMoveMarker_003E(ptr);
		try
		{
			m_native = native;
			base._002Ector();
			return;
		}
		catch
		{
			//try-fault
			((IDisposable)m_native).Dispose();
			throw;
		}
	}

	internal unsafe shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* GetNativePtr(shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* P_0)
	{
		uint num = 0u;
		shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* ptr = m_native.GetPtr();
		*(int*)P_0 = 0;
		shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* ptr2 = (shared_ptr_003Cppinterface_003A_003AMoveMarker_003E*)((byte*)P_0 + 4);
		*(int*)ptr2 = 0;
		uint num2 = ((uint*)ptr)[1];
		if (num2 != 0)
		{
			Interlocked.Increment(ref *(int*)(num2 + 4));
		}
		*(int*)P_0 = *(int*)ptr;
		*(int*)ptr2 = ((int*)ptr)[1];
		try
		{
			num = 1u;
			return P_0;
		}
		catch
		{
			//try-fault
			if ((num & 1) != 0)
			{
				num &= 0xFFFFFFFEu;
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AMoveMarker_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AMoveMarker_003E_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}

	public void _007EMoveMarker()
	{
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				return;
			}
			finally
			{
				((IDisposable)m_native).Dispose();
			}
		}
		base.Finalize();
	}

	public virtual sealed void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
	}
}

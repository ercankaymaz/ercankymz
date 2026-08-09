using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using std;

namespace ModuleWorks.PPInterface;

internal class SharedPointer_003Cppinterface_003A_003AVectord_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AVectord_003E* m_native_ptr;

	private void _007ESharedPointer_003Cppinterface_003A_003AVectord_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AVectord_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AVectord_003E()
	{
		shared_ptr_003Cppinterface_003A_003AVectord_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AVectord_003E* ptr = native_ptr;
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

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AVectord_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AVectord_003E();
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

	~SharedPointer_003Cppinterface_003A_003AVectord_003E()
	{
		Dispose(A_0: false);
	}

	public unsafe SharedPointer_003Cppinterface_003A_003AVectord_003E(shared_ptr_003Cppinterface_003A_003AVectord_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AVectord_003E* ptr = (shared_ptr_003Cppinterface_003A_003AVectord_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AVectord_003E* native_ptr2;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AVectord_003E* GetPtr()
	{
		return m_native_ptr;
	}
}
internal class SharedPointer_003Cppinterface_003A_003AAxis_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AAxis_003E* m_native_ptr;

	private void _007ESharedPointer_003Cppinterface_003A_003AAxis_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AAxis_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AAxis_003E()
	{
		shared_ptr_003Cppinterface_003A_003AAxis_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AAxis_003E* ptr = native_ptr;
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

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AAxis_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AAxis_003E();
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

	~SharedPointer_003Cppinterface_003A_003AAxis_003E()
	{
		Dispose(A_0: false);
	}

	public unsafe SharedPointer_003Cppinterface_003A_003AAxis_003E(shared_ptr_003Cppinterface_003A_003AAxis_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AAxis_003E* ptr = (shared_ptr_003Cppinterface_003A_003AAxis_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AAxis_003E* native_ptr2;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AAxis_003E* GetPtr()
	{
		return m_native_ptr;
	}
}
internal class SharedPointer_003Cppinterface_003A_003ACancelHandler_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003ACancelHandler_003E* m_native_ptr;

	private void _007ESharedPointer_003Cppinterface_003A_003ACancelHandler_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003ACancelHandler_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003ACancelHandler_003E()
	{
		shared_ptr_003Cppinterface_003A_003ACancelHandler_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003ACancelHandler_003E* ptr = native_ptr;
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

	public unsafe shared_ptr_003Cppinterface_003A_003ACancelHandler_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003ACancelHandler_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003ACancelHandler_003E();
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

	~SharedPointer_003Cppinterface_003A_003ACancelHandler_003E()
	{
		Dispose(A_0: false);
	}

	public unsafe SharedPointer_003Cppinterface_003A_003ACancelHandler_003E(shared_ptr_003Cppinterface_003A_003ACancelHandler_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003ACancelHandler_003E* ptr = (shared_ptr_003Cppinterface_003A_003ACancelHandler_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003ACancelHandler_003E* native_ptr2;
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
}
internal class SharedPointer_003Cppinterface_003A_003AOperationNode_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AOperationNode_003E* m_native_ptr;

	private void _007ESharedPointer_003Cppinterface_003A_003AOperationNode_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AOperationNode_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AOperationNode_003E()
	{
		shared_ptr_003Cppinterface_003A_003AOperationNode_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AOperationNode_003E* ptr = native_ptr;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AOperationNode_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AOperationNode_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AOperationNode_003E();
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

	~SharedPointer_003Cppinterface_003A_003AOperationNode_003E()
	{
		Dispose(A_0: false);
	}

	public unsafe SharedPointer_003Cppinterface_003A_003AOperationNode_003E(shared_ptr_003Cppinterface_003A_003AOperationNode_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AOperationNode_003E* ptr = (shared_ptr_003Cppinterface_003A_003AOperationNode_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AOperationNode_003E* native_ptr2;
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
}
internal class SharedPointer_003Cppinterface_003A_003AMachine_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AMachine_003E* m_native_ptr;

	public unsafe SharedPointer_003Cppinterface_003A_003AMachine_003E(shared_ptr_003Cppinterface_003A_003AMachine_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AMachine_003E* ptr = (shared_ptr_003Cppinterface_003A_003AMachine_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AMachine_003E* native_ptr2;
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

	private void _007ESharedPointer_003Cppinterface_003A_003AMachine_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AMachine_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AMachine_003E()
	{
		shared_ptr_003Cppinterface_003A_003AMachine_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AMachine_003E* ptr = native_ptr;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AMachine_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AMachine_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AMachine_003E();
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

	~SharedPointer_003Cppinterface_003A_003AMachine_003E()
	{
		Dispose(A_0: false);
	}
}
internal class SharedPointer_003Cppinterface_003A_003AMachineSettings_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AMachineSettings_003E* m_native_ptr;

	public unsafe SharedPointer_003Cppinterface_003A_003AMachineSettings_003E(shared_ptr_003Cppinterface_003A_003AMachineSettings_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AMachineSettings_003E* ptr = (shared_ptr_003Cppinterface_003A_003AMachineSettings_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AMachineSettings_003E* native_ptr2;
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

	private void _007ESharedPointer_003Cppinterface_003A_003AMachineSettings_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AMachineSettings_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AMachineSettings_003E()
	{
		shared_ptr_003Cppinterface_003A_003AMachineSettings_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AMachineSettings_003E* ptr = native_ptr;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AMachineSettings_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AMachineSettings_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AMachineSettings_003E();
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

	~SharedPointer_003Cppinterface_003A_003AMachineSettings_003E()
	{
		Dispose(A_0: false);
	}
}
internal class SharedPointer_003Cppinterface_003A_003AMoveMarker_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* m_native_ptr;

	public unsafe SharedPointer_003Cppinterface_003A_003AMoveMarker_003E(shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* ptr = (shared_ptr_003Cppinterface_003A_003AMoveMarker_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* native_ptr2;
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

	private void _007ESharedPointer_003Cppinterface_003A_003AMoveMarker_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AMoveMarker_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AMoveMarker_003E()
	{
		shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* ptr = native_ptr;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AMoveMarker_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AMoveMarker_003E();
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

	~SharedPointer_003Cppinterface_003A_003AMoveMarker_003E()
	{
		Dispose(A_0: false);
	}
}
internal class SharedPointer_003Cppinterface_003A_003AMove_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AMove_003E* m_native_ptr;

	private void _007ESharedPointer_003Cppinterface_003A_003AMove_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AMove_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AMove_003E()
	{
		shared_ptr_003Cppinterface_003A_003AMove_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AMove_003E* ptr = native_ptr;
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

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AMove_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AMove_003E();
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

	~SharedPointer_003Cppinterface_003A_003AMove_003E()
	{
		Dispose(A_0: false);
	}

	public unsafe SharedPointer_003Cppinterface_003A_003AMove_003E(shared_ptr_003Cppinterface_003A_003AMove_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AMove_003E* ptr = (shared_ptr_003Cppinterface_003A_003AMove_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AMove_003E* native_ptr2;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AMove_003E* GetPtr()
	{
		return m_native_ptr;
	}
}
internal class SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* m_native_ptr;

	private void _007ESharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E()
	{
		shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* ptr = native_ptr;
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

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E();
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

	~SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E()
	{
		Dispose(A_0: false);
	}

	public unsafe SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E(shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* ptr = (shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* native_ptr2;
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

	public unsafe shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* GetPtr()
	{
		return m_native_ptr;
	}
}
internal class SharedPointer_003Cppinterface_003A_003ASpindleSettings_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E* m_native_ptr;

	private void _007ESharedPointer_003Cppinterface_003A_003ASpindleSettings_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003ASpindleSettings_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003ASpindleSettings_003E()
	{
		shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E* ptr = native_ptr;
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

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003ASpindleSettings_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003ASpindleSettings_003E();
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

	~SharedPointer_003Cppinterface_003A_003ASpindleSettings_003E()
	{
		Dispose(A_0: false);
	}

	public unsafe SharedPointer_003Cppinterface_003A_003ASpindleSettings_003E(shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E* ptr = (shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E* native_ptr2;
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

	public unsafe shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E* GetPtr()
	{
		return m_native_ptr;
	}
}
internal class SharedPointer_003Cppinterface_003A_003AToolDescription_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AToolDescription_003E* m_native_ptr;

	private void _007ESharedPointer_003Cppinterface_003A_003AToolDescription_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AToolDescription_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AToolDescription_003E()
	{
		shared_ptr_003Cppinterface_003A_003AToolDescription_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AToolDescription_003E* ptr = native_ptr;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AToolDescription_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AToolDescription_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AToolDescription_003E();
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

	~SharedPointer_003Cppinterface_003A_003AToolDescription_003E()
	{
		Dispose(A_0: false);
	}

	public unsafe SharedPointer_003Cppinterface_003A_003AToolDescription_003E(shared_ptr_003Cppinterface_003A_003AToolDescription_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AToolDescription_003E* ptr = (shared_ptr_003Cppinterface_003A_003AToolDescription_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AToolDescription_003E* native_ptr2;
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
}
internal class SharedPointer_003Cppinterface_003A_003AAdditionalData_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* m_native_ptr;

	public unsafe SharedPointer_003Cppinterface_003A_003AAdditionalData_003E(shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* ptr = (shared_ptr_003Cppinterface_003A_003AAdditionalData_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* native_ptr2;
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

	private void _007ESharedPointer_003Cppinterface_003A_003AAdditionalData_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AAdditionalData_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AAdditionalData_003E()
	{
		shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* ptr = native_ptr;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AAdditionalData_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AAdditionalData_003E();
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

	~SharedPointer_003Cppinterface_003A_003AAdditionalData_003E()
	{
		Dispose(A_0: false);
	}
}
internal class SharedPointer_003Cppinterface_003A_003AArbor_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AArbor_003E* m_native_ptr;

	public unsafe SharedPointer_003Cppinterface_003A_003AArbor_003E(shared_ptr_003Cppinterface_003A_003AArbor_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AArbor_003E* ptr = (shared_ptr_003Cppinterface_003A_003AArbor_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AArbor_003E* native_ptr2;
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

	private void _007ESharedPointer_003Cppinterface_003A_003AArbor_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AArbor_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AArbor_003E()
	{
		shared_ptr_003Cppinterface_003A_003AArbor_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AArbor_003E* ptr = native_ptr;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AArbor_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AArbor_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AArbor_003E();
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

	~SharedPointer_003Cppinterface_003A_003AArbor_003E()
	{
		Dispose(A_0: false);
	}
}
internal class SharedPointer_003Cppinterface_003A_003ACutter_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003ACutter_003E* m_native_ptr;

	public unsafe SharedPointer_003Cppinterface_003A_003ACutter_003E(shared_ptr_003Cppinterface_003A_003ACutter_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003ACutter_003E* ptr = (shared_ptr_003Cppinterface_003A_003ACutter_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003ACutter_003E* native_ptr2;
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

	private void _007ESharedPointer_003Cppinterface_003A_003ACutter_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003ACutter_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003ACutter_003E()
	{
		shared_ptr_003Cppinterface_003A_003ACutter_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003ACutter_003E* ptr = native_ptr;
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

	public unsafe shared_ptr_003Cppinterface_003A_003ACutter_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003ACutter_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003ACutter_003E();
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

	~SharedPointer_003Cppinterface_003A_003ACutter_003E()
	{
		Dispose(A_0: false);
	}
}
internal class SharedPointer_003Cppinterface_003A_003ACAMInformation_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003ACAMInformation_003E* m_native_ptr;

	public unsafe SharedPointer_003Cppinterface_003A_003ACAMInformation_003E(shared_ptr_003Cppinterface_003A_003ACAMInformation_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003ACAMInformation_003E* ptr = (shared_ptr_003Cppinterface_003A_003ACAMInformation_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003ACAMInformation_003E* native_ptr2;
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

	private void _007ESharedPointer_003Cppinterface_003A_003ACAMInformation_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003ACAMInformation_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003ACAMInformation_003E()
	{
		shared_ptr_003Cppinterface_003A_003ACAMInformation_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003ACAMInformation_003E* ptr = native_ptr;
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

	public unsafe shared_ptr_003Cppinterface_003A_003ACAMInformation_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003ACAMInformation_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003ACAMInformation_003E();
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

	~SharedPointer_003Cppinterface_003A_003ACAMInformation_003E()
	{
		Dispose(A_0: false);
	}
}
internal class SharedPointer_003Cppinterface_003A_003AHolder_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AHolder_003E* m_native_ptr;

	public unsafe SharedPointer_003Cppinterface_003A_003AHolder_003E(shared_ptr_003Cppinterface_003A_003AHolder_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AHolder_003E* ptr = (shared_ptr_003Cppinterface_003A_003AHolder_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AHolder_003E* native_ptr2;
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

	private void _007ESharedPointer_003Cppinterface_003A_003AHolder_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AHolder_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AHolder_003E()
	{
		shared_ptr_003Cppinterface_003A_003AHolder_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AHolder_003E* ptr = native_ptr;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AHolder_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AHolder_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AHolder_003E();
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

	~SharedPointer_003Cppinterface_003A_003AHolder_003E()
	{
		Dispose(A_0: false);
	}
}
internal class SharedPointer_003Cppinterface_003A_003AOpticParameters_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AOpticParameters_003E* m_native_ptr;

	private void _007ESharedPointer_003Cppinterface_003A_003AOpticParameters_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AOpticParameters_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AOpticParameters_003E()
	{
		shared_ptr_003Cppinterface_003A_003AOpticParameters_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AOpticParameters_003E* ptr = native_ptr;
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

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AOpticParameters_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AOpticParameters_003E();
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

	~SharedPointer_003Cppinterface_003A_003AOpticParameters_003E()
	{
		Dispose(A_0: false);
	}

	public unsafe SharedPointer_003Cppinterface_003A_003AOpticParameters_003E(shared_ptr_003Cppinterface_003A_003AOpticParameters_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AOpticParameters_003E* ptr = (shared_ptr_003Cppinterface_003A_003AOpticParameters_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AOpticParameters_003E* native_ptr2;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AOpticParameters_003E* GetPtr()
	{
		return m_native_ptr;
	}
}
internal class SharedPointer_003Cppinterface_003A_003AToolPathParameters_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003AToolPathParameters_003E* m_native_ptr;

	private void _007ESharedPointer_003Cppinterface_003A_003AToolPathParameters_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003AToolPathParameters_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003AToolPathParameters_003E()
	{
		shared_ptr_003Cppinterface_003A_003AToolPathParameters_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003AToolPathParameters_003E* ptr = native_ptr;
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

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003AToolPathParameters_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003AToolPathParameters_003E();
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

	~SharedPointer_003Cppinterface_003A_003AToolPathParameters_003E()
	{
		Dispose(A_0: false);
	}

	public unsafe SharedPointer_003Cppinterface_003A_003AToolPathParameters_003E(shared_ptr_003Cppinterface_003A_003AToolPathParameters_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003AToolPathParameters_003E* ptr = (shared_ptr_003Cppinterface_003A_003AToolPathParameters_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003AToolPathParameters_003E* native_ptr2;
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

	public unsafe shared_ptr_003Cppinterface_003A_003AToolPathParameters_003E* GetPtr()
	{
		return m_native_ptr;
	}
}
internal class SharedPointer_003Cppinterface_003A_003APostSettings_003E : IDisposable
{
	private unsafe shared_ptr_003Cppinterface_003A_003APostSettings_003E* m_native_ptr;

	public unsafe SharedPointer_003Cppinterface_003A_003APostSettings_003E(shared_ptr_003Cppinterface_003A_003APostSettings_003E* native_ptr)
	{
		shared_ptr_003Cppinterface_003A_003APostSettings_003E* ptr = (shared_ptr_003Cppinterface_003A_003APostSettings_003E*)global::_003CModule_003E.@new(8u);
		shared_ptr_003Cppinterface_003A_003APostSettings_003E* native_ptr2;
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

	private void _007ESharedPointer_003Cppinterface_003A_003APostSettings_003E()
	{
		_0021SharedPointer_003Cppinterface_003A_003APostSettings_003E();
	}

	private unsafe void _0021SharedPointer_003Cppinterface_003A_003APostSettings_003E()
	{
		shared_ptr_003Cppinterface_003A_003APostSettings_003E* native_ptr = m_native_ptr;
		if (native_ptr != null)
		{
			shared_ptr_003Cppinterface_003A_003APostSettings_003E* ptr = native_ptr;
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

	public unsafe shared_ptr_003Cppinterface_003A_003APostSettings_003E* GetPtr()
	{
		return m_native_ptr;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021SharedPointer_003Cppinterface_003A_003APostSettings_003E();
			return;
		}
		try
		{
			_0021SharedPointer_003Cppinterface_003A_003APostSettings_003E();
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

	~SharedPointer_003Cppinterface_003A_003APostSettings_003E()
	{
		Dispose(A_0: false);
	}
}

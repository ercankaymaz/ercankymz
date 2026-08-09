using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class std_pair_const_OdGsBaseModule__p_OdUInt32 : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdGsBaseModule first
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.std_pair_const_OdGsBaseModule__p_OdUInt32_first_get(swigCPtr);
			OdGsBaseModule result = ((intPtr == IntPtr.Zero) ? null : new OdGsBaseModule(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.std_pair_const_OdGsBaseModule__p_OdUInt32_first_set(swigCPtr, OdGsBaseModule.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint second
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.std_pair_const_OdGsBaseModule__p_OdUInt32_second_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.std_pair_const_OdGsBaseModule__p_OdUInt32_second_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public std_pair_const_OdGsBaseModule__p_OdUInt32(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(std_pair_const_OdGsBaseModule__p_OdUInt32 obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~std_pair_const_OdGsBaseModule__p_OdUInt32()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_std_pair_const_OdGsBaseModule__p_OdUInt32(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public std_pair_const_OdGsBaseModule__p_OdUInt32()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_std_pair_const_OdGsBaseModule__p_OdUInt32__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public std_pair_const_OdGsBaseModule__p_OdUInt32(OdGsBaseModule first, uint second)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_std_pair_const_OdGsBaseModule__p_OdUInt32__SWIG_1(OdGsBaseModule.getCPtr(first), second), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public std_pair_const_OdGsBaseModule__p_OdUInt32(std_pair_const_OdGsBaseModule__p_OdUInt32 other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_std_pair_const_OdGsBaseModule__p_OdUInt32__SWIG_2(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class std_pair_const_OdGeCurve2d__p_bool : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdGeCurve2d first
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.std_pair_const_OdGeCurve2d__p_bool_first_get(swigCPtr);
			OdGeCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeCurve2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.std_pair_const_OdGeCurve2d__p_bool_first_set(swigCPtr, OdGeCurve2d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool second
	{
		get
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.std_pair_const_OdGeCurve2d__p_bool_second_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.std_pair_const_OdGeCurve2d__p_bool_second_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public std_pair_const_OdGeCurve2d__p_bool(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(std_pair_const_OdGeCurve2d__p_bool obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~std_pair_const_OdGeCurve2d__p_bool()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_std_pair_const_OdGeCurve2d__p_bool(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public std_pair_const_OdGeCurve2d__p_bool()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_std_pair_const_OdGeCurve2d__p_bool__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public std_pair_const_OdGeCurve2d__p_bool(OdGeCurve2d first, bool second)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_std_pair_const_OdGeCurve2d__p_bool__SWIG_1(OdGeCurve2d.getCPtr(first), second), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public std_pair_const_OdGeCurve2d__p_bool(std_pair_const_OdGeCurve2d__p_bool other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_std_pair_const_OdGeCurve2d__p_bool__SWIG_2(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

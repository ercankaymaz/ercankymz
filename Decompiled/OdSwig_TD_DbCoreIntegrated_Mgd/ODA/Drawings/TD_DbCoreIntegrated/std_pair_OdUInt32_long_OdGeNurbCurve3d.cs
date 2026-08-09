using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class std_pair_OdUInt32_long_OdGeNurbCurve3d : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public ulong first
	{
		get
		{
			ulong result = TD_DbCoreIntegrated_GlobalsPINVOKE.std_pair_OdUInt32_long_OdGeNurbCurve3d_first_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.std_pair_OdUInt32_long_OdGeNurbCurve3d_first_set(swigCPtr, value);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGeNurbCurve3d second
	{
		get
		{
			IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.std_pair_OdUInt32_long_OdGeNurbCurve3d_second_get(swigCPtr);
			OdGeNurbCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve3d(intPtr, cMemoryOwn: false));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.std_pair_OdUInt32_long_OdGeNurbCurve3d_second_set(swigCPtr, OdGeNurbCurve3d.getCPtr(value));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public std_pair_OdUInt32_long_OdGeNurbCurve3d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(std_pair_OdUInt32_long_OdGeNurbCurve3d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~std_pair_OdUInt32_long_OdGeNurbCurve3d()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_std_pair_OdUInt32_long_OdGeNurbCurve3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public std_pair_OdUInt32_long_OdGeNurbCurve3d()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_std_pair_OdUInt32_long_OdGeNurbCurve3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public std_pair_OdUInt32_long_OdGeNurbCurve3d(ulong first, OdGeNurbCurve3d second)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_std_pair_OdUInt32_long_OdGeNurbCurve3d__SWIG_1(first, OdGeNurbCurve3d.getCPtr(second)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public std_pair_OdUInt32_long_OdGeNurbCurve3d(std_pair_OdUInt32_long_OdGeNurbCurve3d other)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_std_pair_OdUInt32_long_OdGeNurbCurve3d__SWIG_2(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

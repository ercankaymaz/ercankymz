using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class BrepBuilderInitialVertex : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdGePoint3d point
	{
		get
		{
			IntPtr intPtr = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialVertex_point_get(swigCPtr);
			OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialVertex_point_set(swigCPtr, OdGePoint3d.getCPtr(value));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public std_pair_bool_long marker
	{
		get
		{
			IntPtr intPtr = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialVertex_marker_get(swigCPtr);
			std_pair_bool_long result = ((intPtr == IntPtr.Zero) ? null : new std_pair_bool_long(intPtr, cMemoryOwn: false));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialVertex_marker_set(swigCPtr, std_pair_bool_long.getCPtr(value));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public BrepBuilderInitialVertex(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(BrepBuilderInitialVertex obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~BrepBuilderInitialVertex()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_BrepBuilderInitialVertex(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public BrepBuilderInitialVertex()
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialVertex(), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

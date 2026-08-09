using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeLoopCtx : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeLoopCtx(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeLoopCtx obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeLoopCtx()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeLoopCtx(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGeLoopCtx(OdGeSurface pSurface, OdArray_std_pair_const_OdGeCurve2d__p_bool_OdObjectsAllocator arrCoedges, OdArray_const_OdGeCurve3d__p_OdObjectsAllocator arrEdges, bool bFaceReversed)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLoopCtx(OdGeSurface.getCPtr(pSurface), OdArray_std_pair_const_OdGeCurve2d__p_bool_OdObjectsAllocator.getCPtr(arrCoedges), OdArray_const_OdGeCurve3d__p_OdObjectsAllocator.getCPtr(arrEdges), bFaceReversed), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLoopCtx_LoopType getLoopType(double dTol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLoopCtx_getLoopType(swigCPtr, dTol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGeLoopCtx_LoopType)result;
	}
}

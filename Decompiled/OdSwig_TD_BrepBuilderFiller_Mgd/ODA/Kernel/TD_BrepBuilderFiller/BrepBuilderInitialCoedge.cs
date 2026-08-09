using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class BrepBuilderInitialCoedge : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdBrepBuilder_EntityDirection direction
	{
		get
		{
			int result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedge_direction_get(swigCPtr);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdBrepBuilder_EntityDirection)result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedge_direction_set(swigCPtr, (int)value);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public BrepBuilderInitialCoedge(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(BrepBuilderInitialCoedge obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~BrepBuilderInitialCoedge()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_BrepBuilderInitialCoedge(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public BrepBuilderInitialCoedge()
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialCoedge__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialCoedge(OdGeCurve2d curve, OdBrepBuilder_EntityDirection direction, uint edgeIndex)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialCoedge__SWIG_1(OdGeCurve2d.getCPtr(curve), (int)direction, edgeIndex), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve2d GetCurve()
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedge_GetCurve(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void SetCurve(OdGeCurve2d curve)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedge_SetCurve(swigCPtr, OdGeCurve2d.getCPtr(curve));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint GetEdgeIndex()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedge_GetEdgeIndex(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void SetEdgeIndex(uint index)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedge_SetEdgeIndex(swigCPtr, index);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

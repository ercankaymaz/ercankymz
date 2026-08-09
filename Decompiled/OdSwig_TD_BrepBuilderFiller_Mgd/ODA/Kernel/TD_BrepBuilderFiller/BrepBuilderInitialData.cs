using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class BrepBuilderInitialData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public BrepBuilderInitialVertexArray vertices
	{
		get
		{
			IntPtr intPtr = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialData_vertices_get(swigCPtr);
			BrepBuilderInitialVertexArray result = ((intPtr == IntPtr.Zero) ? null : new BrepBuilderInitialVertexArray(intPtr, cMemoryOwn: false));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialData_vertices_set(swigCPtr, BrepBuilderInitialVertexArray.getCPtr(value));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public BrepBuilderInitialEdgeArray edges
	{
		get
		{
			IntPtr intPtr = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialData_edges_get(swigCPtr);
			BrepBuilderInitialEdgeArray result = ((intPtr == IntPtr.Zero) ? null : new BrepBuilderInitialEdgeArray(intPtr, cMemoryOwn: false));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialData_edges_set(swigCPtr, BrepBuilderInitialEdgeArray.getCPtr(value));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public BrepBuilderComplexArray complexes
	{
		get
		{
			IntPtr intPtr = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialData_complexes_get(swigCPtr);
			BrepBuilderComplexArray result = ((intPtr == IntPtr.Zero) ? null : new BrepBuilderComplexArray(intPtr, cMemoryOwn: false));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialData_complexes_set(swigCPtr, BrepBuilderComplexArray.getCPtr(value));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public BrepBuilderInitialData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(BrepBuilderInitialData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~BrepBuilderInitialData()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_BrepBuilderInitialData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGeMatrix3d get_transformation()
	{
		OdGeMatrix3d result = Helpers.GetObject<OdGeMatrix3d>(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialData_get_transformation(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set_transformation(OdGeMatrix3d mxPtr)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialData_set_transformation(swigCPtr, OdGeMatrix3d.getCPtr(mxPtr));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialData()
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialData(), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

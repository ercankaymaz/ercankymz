using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class BrepBuilderInitialEdge : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public std_pair_bool_long marker
	{
		get
		{
			IntPtr intPtr = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_marker_get(swigCPtr);
			std_pair_bool_long result = ((intPtr == IntPtr.Zero) ? null : new std_pair_bool_long(intPtr, cMemoryOwn: false));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_marker_set(swigCPtr, std_pair_bool_long.getCPtr(value));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool hasColor
	{
		get
		{
			bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_hasColor_get(swigCPtr);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_hasColor_set(swigCPtr, value);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdCmEntityColor color
	{
		get
		{
			IntPtr intPtr = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_color_get(swigCPtr);
			OdCmEntityColor result = ((intPtr == IntPtr.Zero) ? null : new OdCmEntityColor(intPtr, cMemoryOwn: false));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_color_set(swigCPtr, OdCmEntityColor.getCPtr(value));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public BrepBuilderInitialEdge(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(BrepBuilderInitialEdge obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~BrepBuilderInitialEdge()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_BrepBuilderInitialEdge(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public BrepBuilderInitialEdge(OdGeCurve3d edgeCurve, uint vertex1Index, uint vertex2Index)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialEdge__SWIG_0(OdGeCurve3d.getCPtr(edgeCurve), vertex1Index, vertex2Index), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialEdge(OdGeCurve3d edgeCurve, uint vertex1Index)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialEdge__SWIG_1(OdGeCurve3d.getCPtr(edgeCurve), vertex1Index), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialEdge(OdGeCurve3d edgeCurve)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialEdge__SWIG_2(OdGeCurve3d.getCPtr(edgeCurve)), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialEdge()
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialEdge__SWIG_3(), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetApproxLength()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_resetApproxLength(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint Get_kInvalidIndex()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_Get_kInvalidIndex(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve3d GetCurve()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_GetCurve(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void SetCurve(OdGeCurve3d curve)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_SetCurve(swigCPtr, OdGeCurve3d.getCPtr(curve));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint getVertexIndex1()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_getVertexIndex1(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVertexIndex1(uint value)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_setVertexIndex1(swigCPtr, value);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint getVertexIndex2()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_getVertexIndex2(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVertexIndex2(uint value)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdge_setVertexIndex2(swigCPtr, value);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

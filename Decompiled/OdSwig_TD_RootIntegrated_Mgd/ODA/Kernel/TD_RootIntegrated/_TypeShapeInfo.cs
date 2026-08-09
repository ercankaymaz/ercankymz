using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class _TypeShapeInfo : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public bool bboxValid
	{
		get
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_bboxValid_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_bboxValid_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGePoint2d advance
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_advance_get(swigCPtr);
			OdGePoint2d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_advance_set(swigCPtr, OdGePoint2d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGePoint2d m_MinPoint
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_m_MinPoint_get(swigCPtr);
			OdGePoint2d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_m_MinPoint_set(swigCPtr, OdGePoint2d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGePoint2d m_MaxPoint
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_m_MaxPoint_get(swigCPtr);
			OdGePoint2d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_m_MaxPoint_set(swigCPtr, OdGePoint2d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdPolyPolygon3d m_Ppg
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_m_Ppg_get(swigCPtr);
			OdPolyPolygon3d result = ((intPtr == IntPtr.Zero) ? null : new OdPolyPolygon3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_m_Ppg_set(swigCPtr, OdPolyPolygon3d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdArray_FontArc_OdObjectsAllocator m_CircArc
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_m_CircArc_get(swigCPtr);
			OdArray_FontArc_OdObjectsAllocator result = ((intPtr == IntPtr.Zero) ? null : new OdArray_FontArc_OdObjectsAllocator(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_m_CircArc_set(swigCPtr, OdArray_FontArc_OdObjectsAllocator.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdArray_FontCircle_OdObjectsAllocator m_Circles
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_m_Circles_get(swigCPtr);
			OdArray_FontCircle_OdObjectsAllocator result = ((intPtr == IntPtr.Zero) ? null : new OdArray_FontCircle_OdObjectsAllocator(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_m_Circles_set(swigCPtr, OdArray_FontCircle_OdObjectsAllocator.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public _TypeShapeInfo(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(_TypeShapeInfo obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~_TypeShapeInfo()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete__TypeShapeInfo(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public _TypeShapeInfo()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new__TypeShapeInfo__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public _TypeShapeInfo(_TypeShapeInfo o)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new__TypeShapeInfo__SWIG_1(getCPtr(o)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void reset()
	{
		TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_reset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void copyFrom(_TypeShapeInfo o)
	{
		TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_copyFrom(swigCPtr, getCPtr(o));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE._TypeShapeInfo_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

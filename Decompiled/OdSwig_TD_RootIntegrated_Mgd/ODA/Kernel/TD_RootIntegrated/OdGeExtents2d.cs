using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeExtents2d : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static OdGeExtents2d kInvalid
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_kInvalid_get();
			OdGeExtents2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeExtents2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeExtents2d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeExtents2d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeExtents2d()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeExtents2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGeExtents2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExtents2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExtents2d(OdGePoint2d min, OdGePoint2d max)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExtents2d__SWIG_1(OdGePoint2d.getCPtr(min), OdGePoint2d.getCPtr(max)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint2d minPoint()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_minPoint(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d maxPoint()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_maxPoint(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d diagonal()
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_diagonal(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set(OdGePoint2d min, OdGePoint2d max)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_set(swigCPtr, OdGePoint2d.getCPtr(min), OdGePoint2d.getCPtr(max));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void comparingSet(OdGePoint2d pt1, OdGePoint2d pt2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_comparingSet(swigCPtr, OdGePoint2d.getCPtr(pt1), OdGePoint2d.getCPtr(pt2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExtents2d addPoint(OdGePoint2d point)
	{
		OdGeExtents2d result = new OdGeExtents2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_addPoint(swigCPtr, OdGePoint2d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents2d addPoints(OdGePoint2dArray points)
	{
		OdGeExtents2d result = new OdGeExtents2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_addPoints(swigCPtr, OdGePoint2dArray.getCPtr(points).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents2d addExt(OdGeExtents2d extents)
	{
		OdGeExtents2d result = new OdGeExtents2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_addExt(swigCPtr, getCPtr(extents)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValidExtents()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_isValidExtents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void expandBy(OdGeVector2d vect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_expandBy(swigCPtr, OdGeVector2d.getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void transformBy(OdGeMatrix2d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void translate(OdGeVector2d iShift)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_translate(swigCPtr, OdGeVector2d.getCPtr(iShift).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool contains(OdGePoint2d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_contains__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool contains(OdGeExtents2d extents, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_contains__SWIG_1(swigCPtr, getCPtr(extents), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDisjoint(OdGeExtents2d extents, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_isDisjoint__SWIG_0(swigCPtr, getCPtr(extents), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDisjoint(OdGeExtents2d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_isDisjoint__SWIG_1(swigCPtr, getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents2d_IntersectionStatus intersectWith(OdGeExtents2d extents, OdGeExtents2d pResult)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_intersectWith__SWIG_0(swigCPtr, getCPtr(extents), getCPtr(pResult));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGeExtents2d_IntersectionStatus)result;
	}

	public OdGeExtents2d_IntersectionStatus intersectWith(OdGeExtents2d extents)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_intersectWith__SWIG_1(swigCPtr, getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGeExtents2d_IntersectionStatus)result;
	}

	public OdGePoint2d center()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_center(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeExtents2d extents, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_isEqualTo__SWIG_0(swigCPtr, getCPtr(extents), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeExtents2d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_isEqualTo__SWIG_1(swigCPtr, getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGeExtents2d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_IsEqual(swigCPtr, getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGeExtents2d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents2d_IsNotEqual(swigCPtr, getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

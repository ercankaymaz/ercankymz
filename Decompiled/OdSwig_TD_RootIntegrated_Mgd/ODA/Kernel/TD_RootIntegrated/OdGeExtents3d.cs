using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeExtents3d : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static OdGeExtents3d kInvalid
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_kInvalid_get();
			OdGeExtents3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeExtents3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeExtents3d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeExtents3d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeExtents3d()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeExtents3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGeExtents3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExtents3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExtents3d(OdGePoint3d min, OdGePoint3d max)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExtents3d__SWIG_1(OdGePoint3d.getCPtr(min), OdGePoint3d.getCPtr(max)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d GetItem(int iIndex)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_GetItem__SWIG_0(swigCPtr, iIndex), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set(OdGePoint3d min, OdGePoint3d max)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_set(swigCPtr, OdGePoint3d.getCPtr(min), OdGePoint3d.getCPtr(max));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void comparingSet(OdGePoint3d pt1, OdGePoint3d pt2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_comparingSet(swigCPtr, OdGePoint3d.getCPtr(pt1), OdGePoint3d.getCPtr(pt2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExtents3d addPoint(OdGePoint3d point)
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_addPoint(swigCPtr, OdGePoint3d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d addPoints(OdGePoint3dArray points)
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_addPoints(swigCPtr, OdGePoint3dArray.getCPtr(points)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d addExt(OdGeExtents3d extents)
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_addExt(swigCPtr, getCPtr(extents)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValidExtents()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_isValidExtents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void expandBy(OdGeVector3d vect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_expandBy(swigCPtr, OdGeVector3d.getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void transformBy(OdGeMatrix3d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool contains(OdGePoint3d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_contains__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool contains(OdGeExtents3d extents, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_contains__SWIG_1(swigCPtr, getCPtr(extents), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDisjoint(OdGeExtents3d extents, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_isDisjoint__SWIG_0(swigCPtr, getCPtr(extents), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDisjoint(OdGeExtents3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_isDisjoint__SWIG_1(swigCPtr, getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDisjointEuclidean(OdGeExtents3d extents, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_isDisjointEuclidean__SWIG_0(swigCPtr, getCPtr(extents), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDisjointEuclidean(OdGeExtents3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_isDisjointEuclidean__SWIG_1(swigCPtr, getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGePoint3d iPoint)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_distanceTo__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(iPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGeExtents3d iExtents)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_distanceTo__SWIG_1(swigCPtr, getCPtr(iExtents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d_IntersectionStatus intersectWith(OdGeExtents3d extents, OdGeExtents3d pResult)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_intersectWith__SWIG_0(swigCPtr, getCPtr(extents), getCPtr(pResult));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGeExtents3d_IntersectionStatus)result;
	}

	public OdGeExtents3d_IntersectionStatus intersectWith(OdGeExtents3d extents)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_intersectWith__SWIG_1(swigCPtr, getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGeExtents3d_IntersectionStatus)result;
	}

	public bool isWithinRange(OdGePoint3d pt, double radius)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_isWithinRange(swigCPtr, OdGePoint3d.getCPtr(pt), radius);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d center()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_center(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d diagonal()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_diagonal(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void convert2d(OdGeExtents2d extents, OdGeExtents3d_Convert2dPlane plane)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_convert2d__SWIG_0(swigCPtr, OdGeExtents2d.getCPtr(extents), (int)plane);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void convert2d(OdGeExtents2d extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_convert2d__SWIG_1(swigCPtr, OdGeExtents2d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFrom2d(OdGeExtents2d extents, OdGeExtents3d_Convert2dPlane plane)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_setFrom2d__SWIG_0(swigCPtr, OdGeExtents2d.getCPtr(extents), (int)plane);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFrom2d(OdGeExtents2d extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_setFrom2d__SWIG_1(swigCPtr, OdGeExtents2d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isEqualTo(OdGeExtents3d extents, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_isEqualTo__SWIG_0(swigCPtr, getCPtr(extents), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeExtents3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_isEqualTo__SWIG_1(swigCPtr, getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGeExtents3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_IsEqual(swigCPtr, getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGeExtents3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_IsNotEqual(swigCPtr, getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d minPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_minPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d maxPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExtents3d_maxPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

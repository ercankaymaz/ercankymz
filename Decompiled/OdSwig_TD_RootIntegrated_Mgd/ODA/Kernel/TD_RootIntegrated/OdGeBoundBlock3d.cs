using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeBoundBlock3d : OdGeEntity3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeBoundBlock3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeBoundBlock3d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeBoundBlock3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeBoundBlock3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_copy(swigCPtr);
		OdGeBoundBlock3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeBoundBlock3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock3d translateBy(OdGeVector3d translateVec)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock3d mirror(OdGePlane plane)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock3d scaleBy(double scaleFactor)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundBlock3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundBlock3d(OdGePoint3d base_, OdGeVector3d side1, OdGeVector3d side2, OdGeVector3d side3)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundBlock3d__SWIG_1(OdGePoint3d.getCPtr(base_), OdGeVector3d.getCPtr(side1), OdGeVector3d.getCPtr(side2), OdGeVector3d.getCPtr(side3)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundBlock3d(OdGePoint3d point1, OdGePoint3d point2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundBlock3d__SWIG_2(OdGePoint3d.getCPtr(point1), OdGePoint3d.getCPtr(point2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundBlock3d(OdGeBoundBlock3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundBlock3d__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundBlock3d(OdGeMatrix3d lcs, OdGeExtents3d localBox)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundBlock3d__SWIG_4(OdGeMatrix3d.getCPtr(lcs), OdGeExtents3d.getCPtr(localBox)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getMinMaxPoints(OdGePoint3d p1, OdGePoint3d p2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_getMinMaxPoints(swigCPtr, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void get(OdGePoint3d base_, OdGeVector3d side1, OdGeVector3d side2, OdGeVector3d side3)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_get(swigCPtr, OdGePoint3d.getCPtr(base_), OdGeVector3d.getCPtr(side1), OdGeVector3d.getCPtr(side2), OdGeVector3d.getCPtr(side3));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundBlock3d set(OdGePoint3d p1, OdGePoint3d p2)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_set__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock3d set(OdGePoint3d base_, OdGeVector3d side1, OdGeVector3d side2, OdGeVector3d side3)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_set__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(base_), OdGeVector3d.getCPtr(side1), OdGeVector3d.getCPtr(side2), OdGeVector3d.getCPtr(side3)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock3d extend(OdGePoint3d point)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_extend(swigCPtr, OdGePoint3d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock3d swell(double distance)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_swell(swigCPtr, distance), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool contains(OdGePoint3d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_contains(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDisjoint(OdGeBoundBlock3d block, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_isDisjoint__SWIG_0(swigCPtr, getCPtr(block), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDisjoint(OdGeBoundBlock3d block)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_isDisjoint__SWIG_1(swigCPtr, getCPtr(block));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBox()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_isBox(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock3d setToBox(bool toBox)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_setToBox(swigCPtr, toBox), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock3d Assign(OdGeBoundBlock3d block)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_Assign(swigCPtr, getCPtr(block)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d minPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_minPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d maxPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_maxPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d center()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_center(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setToBoxOrtho(OdGeVector3d dir1, OdGeVector3d dir2, OdGeVector3d dir3)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_setToBoxOrtho__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(dir1), OdGeVector3d.getCPtr(dir2), OdGeVector3d.getCPtr(dir3));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setToBoxOrtho()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock3d_setToBoxOrtho__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

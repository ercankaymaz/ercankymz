using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGePlanarEnt : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGePlanarEnt(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGePlanarEnt obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGePlanarEnt(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGePlanarEnt copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_copy(swigCPtr);
		OdGePlanarEnt result = ((intPtr == IntPtr.Zero) ? null : new OdGePlanarEnt(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlanarEnt transformBy(OdGeMatrix3d xfm)
	{
		OdGePlanarEnt result = new OdGePlanarEnt(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlanarEnt translateBy(OdGeVector3d translateVec)
	{
		OdGePlanarEnt result = new OdGePlanarEnt(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlanarEnt rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGePlanarEnt result = new OdGePlanarEnt(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlanarEnt rotateBy(double angle, OdGeVector3d vect)
	{
		OdGePlanarEnt result = new OdGePlanarEnt(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlanarEnt mirror(OdGePlane plane)
	{
		OdGePlanarEnt result = new OdGePlanarEnt(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlanarEnt scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGePlanarEnt result = new OdGePlanarEnt(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlanarEnt scaleBy(double scaleFactor)
	{
		OdGePlanarEnt result = new OdGePlanarEnt(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOnPlane(OdGePoint3d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_isOnPlane__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOnPlane(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_isOnPlane__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d line, OdGePoint3d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_intersectWith__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(line), OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d line, OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_intersectWith__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(line), OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointToLinearEnt(OdGeLinearEnt3d line, OdGePoint3d pointOnLine, OdGeTol tol)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_closestPointToLinearEnt__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(line), OdGePoint3d.getCPtr(pointOnLine), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointToLinearEnt(OdGeLinearEnt3d line, OdGePoint3d pointOnLine)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_closestPointToLinearEnt__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(line), OdGePoint3d.getCPtr(pointOnLine)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointToPlanarEnt(OdGePlanarEnt plane, OdGePoint3d pointOnOtherPlane, OdGeTol tol)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_closestPointToPlanarEnt__SWIG_0(swigCPtr, getCPtr(plane), OdGePoint3d.getCPtr(pointOnOtherPlane), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointToPlanarEnt(OdGePlanarEnt plane, OdGePoint3d pointOnOtherPlane)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_closestPointToPlanarEnt__SWIG_1(swigCPtr, getCPtr(plane), OdGePoint3d.getCPtr(pointOnOtherPlane)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGeLinearEnt3d line, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_isParallelTo__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(line), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGeLinearEnt3d line)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_isParallelTo__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGePlanarEnt plane, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_isParallelTo__SWIG_2(swigCPtr, getCPtr(plane), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGePlanarEnt plane)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_isParallelTo__SWIG_3(swigCPtr, getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGeLinearEnt3d line, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_isPerpendicularTo__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(line), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGeLinearEnt3d line)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_isPerpendicularTo__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGePlanarEnt plane, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_isPerpendicularTo__SWIG_2(swigCPtr, getCPtr(plane), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGePlanarEnt plane)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_isPerpendicularTo__SWIG_3(swigCPtr, getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCoplanarTo(OdGePlanarEnt plane, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_isCoplanarTo__SWIG_0(swigCPtr, getCPtr(plane), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCoplanarTo(OdGePlanarEnt plane)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_isCoplanarTo__SWIG_1(swigCPtr, getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void get(OdGePoint3d origin, OdGeVector3d uAxis, OdGeVector3d vAxis)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_get__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uAxis), OdGeVector3d.getCPtr(vAxis));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void get(OdGePoint3d uPnt, OdGePoint3d origin, OdGePoint3d vPnt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_get__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(uPnt), OdGePoint3d.getCPtr(origin), OdGePoint3d.getCPtr(vPnt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d pointOnPlane()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_pointOnPlane(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d normal()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_normal(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getCoefficients(out double a, out double b, out double c, out double d)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_getCoefficients(swigCPtr, out a, out b, out c, out d);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCoordSystem(OdGePoint3d origin, OdGeVector3d axis1, OdGeVector3d axis2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_getCoordSystem(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(axis1), OdGeVector3d.getCPtr(axis2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePlanarEnt Assign(OdGePlanarEnt plane)
	{
		OdGePlanarEnt result = new OdGePlanarEnt(TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_Assign(swigCPtr, getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool project(OdGePoint3d p, OdGeVector3d unitDir, OdGePoint3d projP, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_project__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(p), OdGeVector3d.getCPtr(unitDir), OdGePoint3d.getCPtr(projP), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool project(OdGePoint3d p, OdGeVector3d unitDir, OdGePoint3d projP)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlanarEnt_project__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(p), OdGeVector3d.getCPtr(unitDir), OdGePoint3d.getCPtr(projP));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

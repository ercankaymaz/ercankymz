using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCircArc3d : OdGeCurve3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCircArc3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCircArc3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCircArc3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeExtents3d getGeomExtents(OdGeInterval range, OdGeMatrix3d coordSystem)
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_getGeomExtents__SWIG_0_0(swigCPtr, OdGeInterval.getCPtr(range), OdGeMatrix3d.getCPtr(coordSystem)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExtents3d getGeomExtents(OdGeInterval range)
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_getGeomExtents__SWIG_0_1(swigCPtr, OdGeInterval.getCPtr(range)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExtents3d getGeomExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_getGeomExtents__SWIG_0_2(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_copy(swigCPtr);
		OdGeCircArc3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeCircArc3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc3d translateBy(OdGeVector3d translateVec)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc3d mirror(OdGePlane plane)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc3d scaleBy(double scaleFactor)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc3d(OdGeCircArc3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc3d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc3d(OdGePoint3d center, OdGeVector3d normal, double radius)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc3d__SWIG_2(OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(normal), radius), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc3d(OdGePoint3d center, OdGeVector3d normal, OdGeVector3d refVec, double radius, double startAng, double endAng)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc3d__SWIG_3(OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(refVec), radius, startAng, endAng), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc3d(OdGePoint3d center, OdGeVector3d normal, OdGeVector3d refVec, double radius, double startAng)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc3d__SWIG_4(OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(refVec), radius, startAng), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc3d(OdGePoint3d center, OdGeVector3d normal, OdGeVector3d refVec, double radius)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc3d__SWIG_5(OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(refVec), radius), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc3d(OdGePoint3d startPoint, OdGePoint3d secondPoint, OdGePoint3d endPoint)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc3d__SWIG_6(OdGePoint3d.getCPtr(startPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(endPoint)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d closestPointToPlane(OdGePlanarEnt plane, OdGePoint3d pointOnPlane, OdGeTol tol)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_closestPointToPlane__SWIG_0(swigCPtr, OdGePlanarEnt.getCPtr(plane), OdGePoint3d.getCPtr(pointOnPlane), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointToPlane(OdGePlanarEnt plane, OdGePoint3d pointOnPlane)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_closestPointToPlane__SWIG_1(swigCPtr, OdGePlanarEnt.getCPtr(plane), OdGePoint3d.getCPtr(pointOnPlane)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d line, out int numInt, OdGePoint3d p1, OdGePoint3d p2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_intersectWith__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(line), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d line, out int numInt, OdGePoint3d p1, OdGePoint3d p2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_intersectWith__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(line), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeCircArc3d arc, out int numInt, OdGePoint3d p1, OdGePoint3d p2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_intersectWith__SWIG_2(swigCPtr, getCPtr(arc), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeCircArc3d arc, out int numInt, OdGePoint3d p1, OdGePoint3d p2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_intersectWith__SWIG_3(swigCPtr, getCPtr(arc), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGePlanarEnt plane, out int numInt, OdGePoint3d p1, OdGePoint3d p2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_intersectWith__SWIG_4(swigCPtr, OdGePlanarEnt.getCPtr(plane), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGePlanarEnt plane, out int numInt, OdGePoint3d p1, OdGePoint3d p2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_intersectWith__SWIG_5(swigCPtr, OdGePlanarEnt.getCPtr(plane), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool projIntersectWith(OdGeLinearEnt3d line, OdGeVector3d projDir, out int numInt, OdGePoint3d pntOnArc1, OdGePoint3d pntOnArc2, OdGePoint3d pntOnLine1, OdGePoint3d pntOnLine2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_projIntersectWith__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(line), OdGeVector3d.getCPtr(projDir), out numInt, OdGePoint3d.getCPtr(pntOnArc1), OdGePoint3d.getCPtr(pntOnArc2), OdGePoint3d.getCPtr(pntOnLine1), OdGePoint3d.getCPtr(pntOnLine2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool projIntersectWith(OdGeLinearEnt3d line, OdGeVector3d projDir, out int numInt, OdGePoint3d pntOnArc1, OdGePoint3d pntOnArc2, OdGePoint3d pntOnLine1, OdGePoint3d pntOnLine2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_projIntersectWith__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(line), OdGeVector3d.getCPtr(projDir), out numInt, OdGePoint3d.getCPtr(pntOnArc1), OdGePoint3d.getCPtr(pntOnArc2), OdGePoint3d.getCPtr(pntOnLine1), OdGePoint3d.getCPtr(pntOnLine2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool tangent(OdGePoint3d point, OdGeLine3d line, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_tangent__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeLine3d.getCPtr(line), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool tangent(OdGePoint3d point, OdGeLine3d line)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_tangent__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), OdGeLine3d.getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool tangent(OdGePoint3d point, OdGeLine3d line, OdGeTol tol, out OdGe_ErrorCondition status)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_tangent__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(point), OdGeLine3d.getCPtr(line), OdGeTol.getCPtr(tol), out status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getPlane(OdGePlane plane)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_getPlane(swigCPtr, OdGePlane.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isInside(OdGePoint3d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_isInside__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isInside(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_isInside__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d center()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_center(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d normal()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_normal(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d refVec()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_refVec(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double radius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_radius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double startAng()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_startAng(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double endAng()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_endAng(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d startPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_startPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d endPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_endPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d setCenter(OdGePoint3d center)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_setCenter(swigCPtr, OdGePoint3d.getCPtr(center)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d setAxes(OdGeVector3d normal, OdGeVector3d refVec)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_setAxes(swigCPtr, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(refVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d setRadius(double radius)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_setRadius(swigCPtr, radius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d setAngles(double startAng, double endAng)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_setAngles(swigCPtr, startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d set(OdGePoint3d center, OdGeVector3d normal, double radius)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_set__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(normal), radius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d set(OdGePoint3d center, OdGeVector3d normal, OdGeVector3d refVec, double radius, double startAng, double endAng)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_set__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(refVec), radius, startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d set(OdGePoint3d startPoint, OdGePoint3d secondPoint, OdGePoint3d endPoint)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_set__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(startPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(endPoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d set(OdGePoint3d startPoint, OdGePoint3d secondPoint, OdGePoint3d endPoint, out OdGe_ErrorCondition status)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_set__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(startPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(endPoint), out status), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d set(OdGeCurve3d curve1, OdGeCurve3d curve2, double radius, out double param1, out double param2, out bool success)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_set__SWIG_4(swigCPtr, OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), radius, out param1, out param2, out success), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d set(OdGeCurve3d curve1, OdGeCurve3d curve2, OdGeCurve3d curve3, out double param1, out double param2, out double param3, out bool success)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_set__SWIG_5(swigCPtr, OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), OdGeCurve3d.getCPtr(curve3), out param1, out param2, out param3, out success), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d Assign(OdGeCircArc3d arc)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_Assign(swigCPtr, getCPtr(arc)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getGeomExtents(OdGeExtents3d extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_getGeomExtents__SWIG_1(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc3d joinWith(OdGeCircArc3d curve, OdGeTol iTolerance)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_joinWith__SWIG_0(swigCPtr, getCPtr(curve), OdGeTol.getCPtr(iTolerance)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc3d joinWith(OdGeCircArc3d curve)
	{
		OdGeCircArc3d result = new OdGeCircArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc3d_joinWith__SWIG_1(swigCPtr, getCPtr(curve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

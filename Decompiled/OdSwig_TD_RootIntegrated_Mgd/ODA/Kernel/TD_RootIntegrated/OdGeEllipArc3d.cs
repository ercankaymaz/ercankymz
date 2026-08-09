using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeEllipArc3d : OdGeCurve3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeEllipArc3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeEllipArc3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeEllipArc3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeEllipArc3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_copy(swigCPtr);
		OdGeEllipArc3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeEllipArc3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc3d translateBy(OdGeVector3d translateVec)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc3d mirror(OdGePlane plane)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc3d scaleBy(double scaleFactor)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipArc3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipArc3d(OdGeEllipArc3d ell)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipArc3d__SWIG_1(getCPtr(ell)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipArc3d(OdGeCircArc3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipArc3d__SWIG_2(OdGeCircArc3d.getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipArc3d(OdGePoint3d center, OdGeVector3d majorAxis, OdGeVector3d minorAxis, double majorRadius, double minorRadius)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipArc3d__SWIG_3(OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(majorAxis), OdGeVector3d.getCPtr(minorAxis), majorRadius, minorRadius), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipArc3d(OdGePoint3d center, OdGeVector3d majorAxis, OdGeVector3d minorAxis, double majorRadius, double minorRadius, double startAng, double endAng)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipArc3d__SWIG_4(OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(majorAxis), OdGeVector3d.getCPtr(minorAxis), majorRadius, minorRadius, startAng, endAng), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d closestPointToPlane(OdGePlanarEnt plane, OdGePoint3d pointOnPlane, OdGeTol tol)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_closestPointToPlane__SWIG_0(swigCPtr, OdGePlanarEnt.getCPtr(plane), OdGePoint3d.getCPtr(pointOnPlane), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointToPlane(OdGePlanarEnt plane, OdGePoint3d pointOnPlane)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_closestPointToPlane__SWIG_1(swigCPtr, OdGePlanarEnt.getCPtr(plane), OdGePoint3d.getCPtr(pointOnPlane)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d line, out int numInt, OdGePoint3d p1, OdGePoint3d p2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_intersectWith__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(line), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d line, out int numInt, OdGePoint3d p1, OdGePoint3d p2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_intersectWith__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(line), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGePlanarEnt plane, out int numInt, OdGePoint3d p1, OdGePoint3d p2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_intersectWith__SWIG_2(swigCPtr, OdGePlanarEnt.getCPtr(plane), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGePlanarEnt plane, out int numInt, OdGePoint3d p1, OdGePoint3d p2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_intersectWith__SWIG_3(swigCPtr, OdGePlanarEnt.getCPtr(plane), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool projIntersectWith(OdGeLinearEnt3d line, OdGeVector3d projDir, out int numInt, OdGePoint3d pntOnEllipse1, OdGePoint3d pntOnEllipse2, OdGePoint3d pntOnLine1, OdGePoint3d pntOnLine2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_projIntersectWith__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(line), OdGeVector3d.getCPtr(projDir), out numInt, OdGePoint3d.getCPtr(pntOnEllipse1), OdGePoint3d.getCPtr(pntOnEllipse2), OdGePoint3d.getCPtr(pntOnLine1), OdGePoint3d.getCPtr(pntOnLine2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool projIntersectWith(OdGeLinearEnt3d line, OdGeVector3d projDir, out int numInt, OdGePoint3d pntOnEllipse1, OdGePoint3d pntOnEllipse2, OdGePoint3d pntOnLine1, OdGePoint3d pntOnLine2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_projIntersectWith__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(line), OdGeVector3d.getCPtr(projDir), out numInt, OdGePoint3d.getCPtr(pntOnEllipse1), OdGePoint3d.getCPtr(pntOnEllipse2), OdGePoint3d.getCPtr(pntOnLine1), OdGePoint3d.getCPtr(pntOnLine2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getPlane(OdGePlane plane)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_getPlane(swigCPtr, OdGePlane.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isCircular(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_isCircular__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCircular()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_isCircular__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isInside(OdGePoint3d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_isInside__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isInside(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_isInside__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d center()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_center(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double minorRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_minorRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double majorRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_majorRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d minorAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_minorAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d majorAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_majorAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d normal()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_normal(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double startAng()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_startAng(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double endAng()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_endAng(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d startPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_startPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d endPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_endPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc3d setCenter(OdGePoint3d center)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_setCenter(swigCPtr, OdGePoint3d.getCPtr(center)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc3d setMinorRadius(double rad)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_setMinorRadius(swigCPtr, rad), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc3d setMajorRadius(double rad)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_setMajorRadius(swigCPtr, rad), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc3d setAxes(OdGeVector3d majorAxis, OdGeVector3d minorAxis)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_setAxes(swigCPtr, OdGeVector3d.getCPtr(majorAxis), OdGeVector3d.getCPtr(minorAxis)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc3d setAngles(double startAng, double endAng)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_setAngles(swigCPtr, startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc3d set(OdGePoint3d center, OdGeVector3d majorAxis, OdGeVector3d minorAxis, double majorRadius, double minorRadius)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_set__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(majorAxis), OdGeVector3d.getCPtr(minorAxis), majorRadius, minorRadius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc3d set(OdGePoint3d center, OdGeVector3d majorAxis, OdGeVector3d minorAxis, double majorRadius, double minorRadius, double startAng, double endAng)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_set__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(majorAxis), OdGeVector3d.getCPtr(minorAxis), majorRadius, minorRadius, startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc3d set(OdGeCircArc3d arc)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_set__SWIG_2(swigCPtr, OdGeCircArc3d.getCPtr(arc)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc3d Assign(OdGeEllipArc3d ell)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_Assign(swigCPtr, getCPtr(ell)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void orthogonalizeAxes(OdGeTol tol, out OdGe_ErrorCondition flag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_orthogonalizeAxes__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol), out flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void orthogonalizeAxes(OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_orthogonalizeAxes__SWIG_1(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void orthogonalizeAxes()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_orthogonalizeAxes__SWIG_2(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d tangentAt(double param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_tangentAt(swigCPtr, param), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getGeomExtents(OdGeExtents3d extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_getGeomExtents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult inverseTangent(OdGeVector3d tan, OdDoubleArray params_)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_inverseTangent(swigCPtr, OdGeVector3d.getCPtr(tan), OdDoubleArray.getCPtr(params_).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult inverseTangentPlane(OdGePlane refPlane, OdDoubleArray params_)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_inverseTangentPlane(swigCPtr, OdGePlane.getCPtr(refPlane), OdDoubleArray.getCPtr(params_).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdGeEllipArc3d joinWith(OdGeEllipArc3d curve, OdGeTol iTolerance)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_joinWith__SWIG_0(swigCPtr, getCPtr(curve), OdGeTol.getCPtr(iTolerance)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc3d joinWith(OdGeEllipArc3d curve)
	{
		OdGeEllipArc3d result = new OdGeEllipArc3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc3d_joinWith__SWIG_1(swigCPtr, getCPtr(curve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

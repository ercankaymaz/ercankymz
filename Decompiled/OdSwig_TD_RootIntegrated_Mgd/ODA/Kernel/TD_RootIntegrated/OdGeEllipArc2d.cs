using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeEllipArc2d : OdGeCurve2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeEllipArc2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeEllipArc2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeEllipArc2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeEllipArc2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_copy(swigCPtr);
		OdGeEllipArc2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeEllipArc2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc2d translateBy(OdGeVector2d translateVec)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc2d rotateBy(double angle)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc2d mirror(OdGeLine2d line)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipArc2d scaleBy(double scaleFactor)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipArc2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipArc2d(OdGeEllipArc2d ell)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipArc2d__SWIG_1(getCPtr(ell)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipArc2d(OdGeCircArc2d arc)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipArc2d__SWIG_2(OdGeCircArc2d.getCPtr(arc)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipArc2d(OdGePoint2d center, OdGeVector2d majorAxis, OdGeVector2d minorAxis, double majorRadius, double minorRadius)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipArc2d__SWIG_3(OdGePoint2d.getCPtr(center), OdGeVector2d.getCPtr(majorAxis).Handle, OdGeVector2d.getCPtr(minorAxis).Handle, majorRadius, minorRadius), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipArc2d(OdGePoint2d center, OdGeVector2d majorAxis, OdGeVector2d minorAxis, double majorRadius, double minorRadius, double startAng, double endAng)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipArc2d__SWIG_4(OdGePoint2d.getCPtr(center), OdGeVector2d.getCPtr(majorAxis).Handle, OdGeVector2d.getCPtr(minorAxis).Handle, majorRadius, minorRadius, startAng, endAng), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool intersectWith(OdGeLinearEnt2d line, out int numInt, OdGePoint2d p1, OdGePoint2d p2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_intersectWith__SWIG_0(swigCPtr, OdGeLinearEnt2d.getCPtr(line), out numInt, OdGePoint2d.getCPtr(p1), OdGePoint2d.getCPtr(p2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt2d line, out int numInt, OdGePoint2d p1, OdGePoint2d p2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_intersectWith__SWIG_1(swigCPtr, OdGeLinearEnt2d.getCPtr(line), out numInt, OdGePoint2d.getCPtr(p1), OdGePoint2d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCircular(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_isCircular__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCircular()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_isCircular__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isInside(OdGePoint2d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_isInside__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isInside(OdGePoint2d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_isInside__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d center()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_center(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double minorRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_minorRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double majorRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_majorRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d minorAxis()
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_minorAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d majorAxis()
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_majorAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double startAng()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_startAng(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double endAng()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_endAng(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d startPoint()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_startPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d endPoint()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_endPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClockWise()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_isClockWise(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc2d setCenter(OdGePoint2d center)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_setCenter(swigCPtr, OdGePoint2d.getCPtr(center)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc2d setMinorRadius(double rad)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_setMinorRadius(swigCPtr, rad), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc2d setMajorRadius(double rad)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_setMajorRadius(swigCPtr, rad), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc2d setAxes(OdGeVector2d majorAxis, OdGeVector2d minorAxis)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_setAxes(swigCPtr, OdGeVector2d.getCPtr(majorAxis).Handle, OdGeVector2d.getCPtr(minorAxis).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc2d setAngles(double startAng, double endAng)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_setAngles(swigCPtr, startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc2d set(OdGePoint2d center, OdGeVector2d majorAxis, OdGeVector2d minorAxis, double majorRadius, double minorRadius)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_set__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(center), OdGeVector2d.getCPtr(majorAxis).Handle, OdGeVector2d.getCPtr(minorAxis).Handle, majorRadius, minorRadius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc2d set(OdGePoint2d center, OdGeVector2d majorAxis, OdGeVector2d minorAxis, double majorRadius, double minorRadius, double startAng, double endAng)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_set__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(center), OdGeVector2d.getCPtr(majorAxis).Handle, OdGeVector2d.getCPtr(minorAxis).Handle, majorRadius, minorRadius, startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc2d set(OdGeCircArc2d arc)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_set__SWIG_2(swigCPtr, OdGeCircArc2d.getCPtr(arc)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipArc2d Assign(OdGeEllipArc2d ell)
	{
		OdGeEllipArc2d result = new OdGeEllipArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_Assign(swigCPtr, getCPtr(ell)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getGeomExtents(OdGeExtents2d extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_getGeomExtents(swigCPtr, OdGeExtents2d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void inverseTangent(OdGeVector2d tan, OdDoubleArray params_)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc2d_inverseTangent(swigCPtr, OdGeVector2d.getCPtr(tan).Handle, OdDoubleArray.getCPtr(params_).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

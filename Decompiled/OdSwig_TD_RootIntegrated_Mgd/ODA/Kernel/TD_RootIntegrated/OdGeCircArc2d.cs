using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCircArc2d : OdGeCurve2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCircArc2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCircArc2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCircArc2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeCircArc2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_copy(swigCPtr);
		OdGeCircArc2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeCircArc2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc2d translateBy(OdGeVector2d translateVec)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc2d rotateBy(double angle)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc2d mirror(OdGeLine2d line)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCircArc2d scaleBy(double scaleFactor)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc2d(OdGeCircArc2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc2d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc2d(OdGePoint2d center, double radius)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc2d__SWIG_2(OdGePoint2d.getCPtr(center), radius), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc2d(OdGePoint2d center, double radius, double startAng, double endAng, OdGeVector2d refVec, bool isClockWise)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc2d__SWIG_3(OdGePoint2d.getCPtr(center), radius, startAng, endAng, OdGeVector2d.getCPtr(refVec).Handle, isClockWise), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc2d(OdGePoint2d center, double radius, double startAng, double endAng, OdGeVector2d refVec)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc2d__SWIG_4(OdGePoint2d.getCPtr(center), radius, startAng, endAng, OdGeVector2d.getCPtr(refVec).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc2d(OdGePoint2d center, double radius, double startAng, double endAng)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc2d__SWIG_5(OdGePoint2d.getCPtr(center), radius, startAng, endAng), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc2d(OdGePoint2d startPoint, OdGePoint2d secondPoint, OdGePoint2d endPoint)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc2d__SWIG_6(OdGePoint2d.getCPtr(startPoint), OdGePoint2d.getCPtr(secondPoint), OdGePoint2d.getCPtr(endPoint)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc2d(OdGePoint2d startPoint, OdGePoint2d endPoint, double bulge, bool bulgeFlag)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc2d__SWIG_7(OdGePoint2d.getCPtr(startPoint), OdGePoint2d.getCPtr(endPoint), bulge, bulgeFlag), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCircArc2d(OdGePoint2d startPoint, OdGePoint2d endPoint, double bulge)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCircArc2d__SWIG_8(OdGePoint2d.getCPtr(startPoint), OdGePoint2d.getCPtr(endPoint), bulge), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool intersectWith(OdGeLinearEnt2d line, out int numInt, OdGePoint2d p1, OdGePoint2d p2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_intersectWith__SWIG_0(swigCPtr, OdGeLinearEnt2d.getCPtr(line), out numInt, OdGePoint2d.getCPtr(p1), OdGePoint2d.getCPtr(p2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt2d line, out int numInt, OdGePoint2d p1, OdGePoint2d p2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_intersectWith__SWIG_1(swigCPtr, OdGeLinearEnt2d.getCPtr(line), out numInt, OdGePoint2d.getCPtr(p1), OdGePoint2d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeCircArc2d circarc, out int numInt, OdGePoint2d p1, OdGePoint2d p2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_intersectWith__SWIG_2(swigCPtr, getCPtr(circarc), out numInt, OdGePoint2d.getCPtr(p1), OdGePoint2d.getCPtr(p2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeCircArc2d circarc, out int numInt, OdGePoint2d p1, OdGePoint2d p2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_intersectWith__SWIG_3(swigCPtr, getCPtr(circarc), out numInt, OdGePoint2d.getCPtr(p1), OdGePoint2d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool tangent(OdGePoint2d point, OdGeLine2d line, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_tangent__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGeLine2d.getCPtr(line), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool tangent(OdGePoint2d point, OdGeLine2d line)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_tangent__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point), OdGeLine2d.getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool tangent(OdGePoint2d point, OdGeLine2d line, OdGeTol tol, out OdGe_ErrorCondition status)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_tangent__SWIG_2(swigCPtr, OdGePoint2d.getCPtr(point), OdGeLine2d.getCPtr(line), OdGeTol.getCPtr(tol), out status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isInside(OdGePoint2d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_isInside__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isInside(OdGePoint2d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_isInside__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d center()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_center(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double radius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_radius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double startAng()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_startAng(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double endAng()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_endAng(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClockWise()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_isClockWise(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d refVec()
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_refVec(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d startPoint()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_startPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d endPoint()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_endPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d setCenter(OdGePoint2d center)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_setCenter(swigCPtr, OdGePoint2d.getCPtr(center)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d setRadius(double radius)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_setRadius(swigCPtr, radius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d setAngles(double startAng, double endAng)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_setAngles(swigCPtr, startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d setToComplement()
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_setToComplement(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d setRefVec(OdGeVector2d vect)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_setRefVec(swigCPtr, OdGeVector2d.getCPtr(vect).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d set(OdGePoint2d center, double radius)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_set__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(center), radius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d set(OdGePoint2d center, double radius, double startAng, double endAng, OdGeVector2d refVec, bool isClockWise)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_set__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(center), radius, startAng, endAng, OdGeVector2d.getCPtr(refVec).Handle, isClockWise), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d set(OdGePoint2d center, double radius, double startAng, double endAng, OdGeVector2d refVec)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_set__SWIG_2(swigCPtr, OdGePoint2d.getCPtr(center), radius, startAng, endAng, OdGeVector2d.getCPtr(refVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d set(OdGePoint2d center, double radius, double startAng, double endAng)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_set__SWIG_3(swigCPtr, OdGePoint2d.getCPtr(center), radius, startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d set(OdGePoint2d startPoint, OdGePoint2d secondPoint, OdGePoint2d endPoint)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_set__SWIG_4(swigCPtr, OdGePoint2d.getCPtr(startPoint), OdGePoint2d.getCPtr(secondPoint), OdGePoint2d.getCPtr(endPoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d set(OdGePoint2d startPoint, OdGePoint2d secondPoint, OdGePoint2d endPoint, out OdGe_ErrorCondition status)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_set__SWIG_5(swigCPtr, OdGePoint2d.getCPtr(startPoint), OdGePoint2d.getCPtr(secondPoint), OdGePoint2d.getCPtr(endPoint), out status), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d set(OdGePoint2d startPoint, OdGePoint2d endPoint, double bulge, bool bulgeFlag)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_set__SWIG_6(swigCPtr, OdGePoint2d.getCPtr(startPoint), OdGePoint2d.getCPtr(endPoint), bulge, bulgeFlag), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d set(OdGePoint2d startPoint, OdGePoint2d endPoint, double bulge)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_set__SWIG_7(swigCPtr, OdGePoint2d.getCPtr(startPoint), OdGePoint2d.getCPtr(endPoint), bulge), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d set(OdGeCurve2d curve1, OdGeCurve2d curve2, double radius, out double param1, out double param2, out bool success)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_set__SWIG_8(swigCPtr, OdGeCurve2d.getCPtr(curve1), OdGeCurve2d.getCPtr(curve2), radius, out param1, out param2, out success), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d set(OdGeCurve2d curve1, OdGeCurve2d curve2, OdGeCurve2d curve3, out double param1, out double param2, out double param3, out bool success)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_set__SWIG_9(swigCPtr, OdGeCurve2d.getCPtr(curve1), OdGeCurve2d.getCPtr(curve2), OdGeCurve2d.getCPtr(curve3), out param1, out param2, out param3, out success), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCircArc2d Assign(OdGeCircArc2d arc)
	{
		OdGeCircArc2d result = new OdGeCircArc2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_Assign(swigCPtr, getCPtr(arc)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getGeomExtents(OdGeExtents2d extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_getGeomExtents(swigCPtr, OdGeExtents2d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double startAngFromXAxis()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_startAngFromXAxis(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double endAngFromXAxis()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCircArc2d_endAngFromXAxis(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

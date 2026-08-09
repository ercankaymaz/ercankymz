using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeSplineEnt2d : OdGeCurve2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeSplineEnt2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeSplineEnt2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeSplineEnt2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeSplineEnt2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_copy(swigCPtr);
		OdGeSplineEnt2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeSplineEnt2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeSplineEnt2d result = new OdGeSplineEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt2d translateBy(OdGeVector2d translateVec)
	{
		OdGeSplineEnt2d result = new OdGeSplineEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeSplineEnt2d result = new OdGeSplineEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt2d rotateBy(double angle)
	{
		OdGeSplineEnt2d result = new OdGeSplineEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt2d mirror(OdGeLine2d line)
	{
		OdGeSplineEnt2d result = new OdGeSplineEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeSplineEnt2d result = new OdGeSplineEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt2d scaleBy(double scaleFactor)
	{
		OdGeSplineEnt2d result = new OdGeSplineEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRational()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_isRational(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int degree()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_degree(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int order()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_order(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numKnots()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_numKnots(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector knots()
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_knots(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numControlPoints()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_numControlPoints(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int continuityAtKnot(int knotIndex, OdGeTol tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_continuityAtKnot__SWIG_0(swigCPtr, knotIndex, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int continuityAtKnot(int knotIndex)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_continuityAtKnot__SWIG_1(swigCPtr, knotIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double startParam()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_startParam(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double endParam()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_endParam(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d startPoint()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_startPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d endPoint()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_endPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasFitData()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_hasFitData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double knotAt(int knotIndex)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_knotAt(swigCPtr, knotIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSplineEnt2d setKnotAt(int knotIndex, double val)
	{
		OdGeSplineEnt2d result = new OdGeSplineEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_setKnotAt(swigCPtr, knotIndex, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d controlPointAt(int controlPointIndex)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_controlPointAt(swigCPtr, controlPointIndex), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSplineEnt2d setControlPointAt(int controlPointIndex, OdGePoint2d point)
	{
		OdGeSplineEnt2d result = new OdGeSplineEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_setControlPointAt(swigCPtr, controlPointIndex, OdGePoint2d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSplineEnt2d Assign(OdGeSplineEnt2d spline)
	{
		OdGeSplineEnt2d result = new OdGeSplineEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt2d_Assign(swigCPtr, getCPtr(spline)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

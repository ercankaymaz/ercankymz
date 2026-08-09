using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCubicSplineCurve2d : OdGeSplineEnt2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCubicSplineCurve2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCubicSplineCurve2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCubicSplineCurve2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeCubicSplineCurve2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_copy(swigCPtr);
		OdGeCubicSplineCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeCubicSplineCurve2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeCubicSplineCurve2d result = new OdGeCubicSplineCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve2d translateBy(OdGeVector2d translateVec)
	{
		OdGeCubicSplineCurve2d result = new OdGeCubicSplineCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeCubicSplineCurve2d result = new OdGeCubicSplineCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve2d rotateBy(double angle)
	{
		OdGeCubicSplineCurve2d result = new OdGeCubicSplineCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve2d mirror(OdGeLine2d line)
	{
		OdGeCubicSplineCurve2d result = new OdGeCubicSplineCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeCubicSplineCurve2d result = new OdGeCubicSplineCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve2d scaleBy(double scaleFactor)
	{
		OdGeCubicSplineCurve2d result = new OdGeCubicSplineCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCubicSplineCurve2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve2d(OdGeCubicSplineCurve2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve2d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve2d(OdGePoint2dArray fitPnts, OdGeTol tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve2d__SWIG_2(OdGePoint2dArray.getCPtr(fitPnts).Handle, OdGeTol.getCPtr(tol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve2d(OdGePoint2dArray fitPnts)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve2d__SWIG_3(OdGePoint2dArray.getCPtr(fitPnts).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve2d(OdGePoint2dArray fitPnts, OdGeVector2d startDeriv, OdGeVector2d endDeriv, OdGeTol tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve2d__SWIG_4(OdGePoint2dArray.getCPtr(fitPnts).Handle, OdGeVector2d.getCPtr(startDeriv).Handle, OdGeVector2d.getCPtr(endDeriv).Handle, OdGeTol.getCPtr(tol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve2d(OdGePoint2dArray fitPnts, OdGeVector2d startDeriv, OdGeVector2d endDeriv)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve2d__SWIG_5(OdGePoint2dArray.getCPtr(fitPnts).Handle, OdGeVector2d.getCPtr(startDeriv).Handle, OdGeVector2d.getCPtr(endDeriv).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve2d(OdGeCurve2d curve, double tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve2d__SWIG_6(OdGeCurve2d.getCPtr(curve), tol), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve2d(OdGeKnotVector knots, OdGePoint2dArray fitPnts, OdGeVector2dArray firstDerivs, bool isPeriodic)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve2d__SWIG_7(OdGeKnotVector.getCPtr(knots), OdGePoint2dArray.getCPtr(fitPnts).Handle, OdGeVector2dArray.getCPtr(firstDerivs), isPeriodic), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve2d(OdGeKnotVector knots, OdGePoint2dArray fitPnts, OdGeVector2dArray firstDerivs)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve2d__SWIG_8(OdGeKnotVector.getCPtr(knots), OdGePoint2dArray.getCPtr(fitPnts).Handle, OdGeVector2dArray.getCPtr(firstDerivs)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numFitPoints()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_numFitPoints(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d fitPointAt(int fitPointIndex)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_fitPointAt(swigCPtr, fitPointIndex), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCubicSplineCurve2d setFitPointAt(int fitPointIndex, OdGePoint2d point)
	{
		OdGeCubicSplineCurve2d result = new OdGeCubicSplineCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_setFitPointAt(swigCPtr, fitPointIndex, OdGePoint2d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d firstDerivAt(int fitPointIndex)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_firstDerivAt(swigCPtr, fitPointIndex), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCubicSplineCurve2d setFirstDerivAt(int fitPointIndex, OdGeVector2d deriv)
	{
		OdGeCubicSplineCurve2d result = new OdGeCubicSplineCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_setFirstDerivAt(swigCPtr, fitPointIndex, OdGeVector2d.getCPtr(deriv).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCubicSplineCurve2d Assign(OdGeCubicSplineCurve2d spline)
	{
		OdGeCubicSplineCurve2d result = new OdGeCubicSplineCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve2d_Assign(swigCPtr, getCPtr(spline)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

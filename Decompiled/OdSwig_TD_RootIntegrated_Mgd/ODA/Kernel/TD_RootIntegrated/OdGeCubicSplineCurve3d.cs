using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCubicSplineCurve3d : OdGeSplineEnt3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCubicSplineCurve3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCubicSplineCurve3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCubicSplineCurve3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeCubicSplineCurve3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_copy(swigCPtr);
		OdGeCubicSplineCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeCubicSplineCurve3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeCubicSplineCurve3d result = new OdGeCubicSplineCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve3d translateBy(OdGeVector3d translateVec)
	{
		OdGeCubicSplineCurve3d result = new OdGeCubicSplineCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeCubicSplineCurve3d result = new OdGeCubicSplineCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeCubicSplineCurve3d result = new OdGeCubicSplineCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve3d mirror(OdGePlane plane)
	{
		OdGeCubicSplineCurve3d result = new OdGeCubicSplineCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeCubicSplineCurve3d result = new OdGeCubicSplineCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCubicSplineCurve3d scaleBy(double scaleFactor)
	{
		OdGeCubicSplineCurve3d result = new OdGeCubicSplineCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCubicSplineCurve3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve3d(OdGeCubicSplineCurve3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve3d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve3d(OdGePoint3dArray fitPnts, OdGeTol tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve3d__SWIG_2(OdGePoint3dArray.getCPtr(fitPnts), OdGeTol.getCPtr(tol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve3d(OdGePoint3dArray fitPnts)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve3d__SWIG_3(OdGePoint3dArray.getCPtr(fitPnts)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve3d(OdGePoint3dArray fitPnts, OdGeVector3d startDeriv, OdGeVector3d endDeriv, OdGeTol tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve3d__SWIG_4(OdGePoint3dArray.getCPtr(fitPnts), OdGeVector3d.getCPtr(startDeriv), OdGeVector3d.getCPtr(endDeriv), OdGeTol.getCPtr(tol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve3d(OdGePoint3dArray fitPnts, OdGeVector3d startDeriv, OdGeVector3d endDeriv)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve3d__SWIG_5(OdGePoint3dArray.getCPtr(fitPnts), OdGeVector3d.getCPtr(startDeriv), OdGeVector3d.getCPtr(endDeriv)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve3d(OdGeCurve3d curve, double epsilon)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve3d__SWIG_6(OdGeCurve3d.getCPtr(curve), epsilon), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve3d(OdGeKnotVector knots, OdGePoint3dArray fitPnts, OdGeVector3dArray firstDerivs, bool isPeriodic)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve3d__SWIG_7(OdGeKnotVector.getCPtr(knots), OdGePoint3dArray.getCPtr(fitPnts), OdGeVector3dArray.getCPtr(firstDerivs), isPeriodic), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCubicSplineCurve3d(OdGeKnotVector knots, OdGePoint3dArray fitPnts, OdGeVector3dArray firstDerivs)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCubicSplineCurve3d__SWIG_8(OdGeKnotVector.getCPtr(knots), OdGePoint3dArray.getCPtr(fitPnts), OdGeVector3dArray.getCPtr(firstDerivs)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numFitPoints()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_numFitPoints(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d fitPointAt(int fitPointIndex)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_fitPointAt(swigCPtr, fitPointIndex), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCubicSplineCurve3d setFitPointAt(int fitPointIndex, OdGePoint3d point)
	{
		OdGeCubicSplineCurve3d result = new OdGeCubicSplineCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_setFitPointAt(swigCPtr, fitPointIndex, OdGePoint3d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d firstDerivAt(int fitPointIndex)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_firstDerivAt(swigCPtr, fitPointIndex), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCubicSplineCurve3d setFirstDerivAt(int fitPointIndex, OdGeVector3d deriv)
	{
		OdGeCubicSplineCurve3d result = new OdGeCubicSplineCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_setFirstDerivAt(swigCPtr, fitPointIndex, OdGeVector3d.getCPtr(deriv)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCubicSplineCurve3d Assign(OdGeCubicSplineCurve3d spline)
	{
		OdGeCubicSplineCurve3d result = new OdGeCubicSplineCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCubicSplineCurve3d_Assign(swigCPtr, getCPtr(spline)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

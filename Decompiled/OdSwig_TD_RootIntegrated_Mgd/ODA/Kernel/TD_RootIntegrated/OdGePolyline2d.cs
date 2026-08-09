using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGePolyline2d : OdGeSplineEnt2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGePolyline2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGePolyline2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGePolyline2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGePolyline2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_copy(swigCPtr);
		OdGePolyline2d result = ((intPtr == IntPtr.Zero) ? null : new OdGePolyline2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline2d transformBy(OdGeMatrix2d xfm)
	{
		OdGePolyline2d result = new OdGePolyline2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline2d translateBy(OdGeVector2d translateVec)
	{
		OdGePolyline2d result = new OdGePolyline2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGePolyline2d result = new OdGePolyline2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline2d rotateBy(double angle)
	{
		OdGePolyline2d result = new OdGePolyline2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline2d mirror(OdGeLine2d line)
	{
		OdGePolyline2d result = new OdGePolyline2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGePolyline2d result = new OdGePolyline2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline2d scaleBy(double scaleFactor)
	{
		OdGePolyline2d result = new OdGePolyline2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePolyline2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePolyline2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePolyline2d(OdGePolyline2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePolyline2d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePolyline2d(OdGePoint2dArray fitpoints)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePolyline2d__SWIG_2(OdGePoint2dArray.getCPtr(fitpoints).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePolyline2d(OdGeKnotVector knots, OdGePoint2dArray points)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePolyline2d__SWIG_3(OdGeKnotVector.getCPtr(knots), OdGePoint2dArray.getCPtr(points).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePolyline2d(OdGeCurve2d crv, double approxEps)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePolyline2d__SWIG_4(OdGeCurve2d.getCPtr(crv), approxEps), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numFitPoints()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_numFitPoints(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d fitPointAt(int fitPointIndex)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_fitPointAt(swigCPtr, fitPointIndex), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSplineEnt2d setFitPointAt(int fitPointIndex, OdGePoint2d point)
	{
		OdGeSplineEnt2d result = new OdGeSplineEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_setFitPointAt(swigCPtr, fitPointIndex, OdGePoint2d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePolyline2d Assign(OdGePolyline2d polyline)
	{
		OdGePolyline2d result = new OdGePolyline2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline2d_Assign(swigCPtr, getCPtr(polyline)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

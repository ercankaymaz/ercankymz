using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGePolyline3d : OdGeSplineEnt3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGePolyline3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGePolyline3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGePolyline3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGePolyline3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_copy(swigCPtr);
		OdGePolyline3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePolyline3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline3d transformBy(OdGeMatrix3d xfm)
	{
		OdGePolyline3d result = new OdGePolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline3d translateBy(OdGeVector3d translateVec)
	{
		OdGePolyline3d result = new OdGePolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGePolyline3d result = new OdGePolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGePolyline3d result = new OdGePolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline3d mirror(OdGePlane plane)
	{
		OdGePolyline3d result = new OdGePolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGePolyline3d result = new OdGePolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePolyline3d scaleBy(double scaleFactor)
	{
		OdGePolyline3d result = new OdGePolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePolyline3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePolyline3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePolyline3d(OdGePolyline3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePolyline3d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePolyline3d(OdGePoint3dArray points)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePolyline3d__SWIG_2(OdGePoint3dArray.getCPtr(points)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePolyline3d(OdGeKnotVector knots, OdGePoint3dArray controlPoints)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePolyline3d__SWIG_3(OdGeKnotVector.getCPtr(knots), OdGePoint3dArray.getCPtr(controlPoints)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePolyline3d(OdGeCurve3d crv, double approxEps)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePolyline3d__SWIG_4(OdGeCurve3d.getCPtr(crv), approxEps), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePolyline3d(int numPoints, OdGePoint3d pPoints)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePolyline3d__SWIG_5(numPoints, OdGePoint3d.getCPtr(pPoints)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numFitPoints()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_numFitPoints(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d fitPointAt(int fitPointIndex)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_fitPointAt(swigCPtr, fitPointIndex), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSplineEnt3d setFitPointAt(int index, OdGePoint3d point)
	{
		OdGeSplineEnt3d result = new OdGeSplineEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_setFitPointAt(swigCPtr, index, OdGePoint3d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePolyline3d Assign(OdGePolyline3d polyline)
	{
		OdGePolyline3d result = new OdGePolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_Assign(swigCPtr, getCPtr(polyline)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d evalPointSeg(double param, out int numSeg)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePolyline3d_evalPointSeg(swigCPtr, param, out numSeg), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

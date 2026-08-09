using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeSplineEnt3d : OdGeCurve3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeSplineEnt3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeSplineEnt3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeSplineEnt3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeSplineEnt3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_copy(swigCPtr);
		OdGeSplineEnt3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeSplineEnt3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeSplineEnt3d result = new OdGeSplineEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt3d translateBy(OdGeVector3d translateVec)
	{
		OdGeSplineEnt3d result = new OdGeSplineEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeSplineEnt3d result = new OdGeSplineEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeSplineEnt3d result = new OdGeSplineEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt3d mirror(OdGePlane plane)
	{
		OdGeSplineEnt3d result = new OdGeSplineEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeSplineEnt3d result = new OdGeSplineEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSplineEnt3d scaleBy(double scaleFactor)
	{
		OdGeSplineEnt3d result = new OdGeSplineEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRational()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_isRational(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int degree()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_degree(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int order()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_order(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numKnots()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_numKnots(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector knots()
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_knots(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numControlPoints()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_numControlPoints(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int continuityAtKnot(int index, OdGeTol tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_continuityAtKnot__SWIG_0(swigCPtr, index, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int continuityAtKnot(int index)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_continuityAtKnot__SWIG_1(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double startParam()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_startParam(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double endParam()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_endParam(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d startPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_startPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d endPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_endPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasFitData()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_hasFitData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double knotAt(int knotIndex)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_knotAt(swigCPtr, knotIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSplineEnt3d setKnotAt(int knotIndex, double val)
	{
		OdGeSplineEnt3d result = new OdGeSplineEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_setKnotAt(swigCPtr, knotIndex, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d controlPointAt(int controlPointIndex)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_controlPointAt(swigCPtr, controlPointIndex), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSplineEnt3d setControlPointAt(int controlPointIndex, OdGePoint3d point)
	{
		OdGeSplineEnt3d result = new OdGeSplineEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_setControlPointAt(swigCPtr, controlPointIndex, OdGePoint3d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSplineEnt3d Assign(OdGeSplineEnt3d spline)
	{
		OdGeSplineEnt3d result = new OdGeSplineEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSplineEnt3d_Assign(swigCPtr, getCPtr(spline)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

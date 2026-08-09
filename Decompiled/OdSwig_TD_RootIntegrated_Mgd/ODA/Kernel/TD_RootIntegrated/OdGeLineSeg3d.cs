using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeLineSeg3d : OdGeLinearEnt3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeLineSeg3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeLineSeg3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeLineSeg3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeLineSeg3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_copy(swigCPtr);
		OdGeLineSeg3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeLineSeg3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg3d translateBy(OdGeVector3d translateVec)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg3d mirror(OdGePlane plane)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg3d scaleBy(double scaleFactor)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLineSeg3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLineSeg3d(OdGeLineSeg3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLineSeg3d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLineSeg3d(OdGePoint3d point, OdGeVector3d vect)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLineSeg3d__SWIG_2(OdGePoint3d.getCPtr(point), OdGeVector3d.getCPtr(vect)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLineSeg3d(OdGePoint3d point1, OdGePoint3d point2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLineSeg3d__SWIG_3(OdGePoint3d.getCPtr(point1), OdGePoint3d.getCPtr(point2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBisector(OdGePlane plane)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_getBisector(swigCPtr, OdGePlane.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d baryComb(double blendCoeff)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_baryComb(swigCPtr, blendCoeff), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d startPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_startPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d endPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_endPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg3d set(OdGePoint3d point, OdGeVector3d vect)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_set__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg3d set(OdGePoint3d point1, OdGePoint3d point2)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_set__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point1), OdGePoint3d.getCPtr(point2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg3d set(OdGeCurve3d curve1, OdGeCurve3d curve2, out double param1, out double param2, out bool success)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_set__SWIG_2(swigCPtr, OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), out param1, out param2, out success), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg3d set(OdGeCurve3d curve, OdGePoint3d point, out double param, out bool success)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_set__SWIG_3(swigCPtr, OdGeCurve3d.getCPtr(curve), OdGePoint3d.getCPtr(point), out param, out success), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg3d Assign(OdGeLineSeg3d line)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_Assign(swigCPtr, getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getDistanceToVector(OdGePoint3d point, OdGeTol tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_getDistanceToVector__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getDistanceToVector(OdGePoint3d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_getDistanceToVector__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg3d joinWith(OdGeLineSeg3d curve, OdGeTol iTolerance)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_joinWith__SWIG_0(swigCPtr, getCPtr(curve), OdGeTol.getCPtr(iTolerance)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg3d joinWith(OdGeLineSeg3d curve)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg3d_joinWith__SWIG_1(swigCPtr, getCPtr(curve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

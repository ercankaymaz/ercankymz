using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGePointOnCurve3d : OdGePointEnt3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGePointOnCurve3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGePointOnCurve3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGePointOnCurve3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGePointOnCurve3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_copy(swigCPtr);
		OdGePointOnCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePointOnCurve3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve3d transformBy(OdGeMatrix3d xfm)
	{
		OdGePointOnCurve3d result = new OdGePointOnCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve3d translateBy(OdGeVector3d translateVec)
	{
		OdGePointOnCurve3d result = new OdGePointOnCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGePointOnCurve3d result = new OdGePointOnCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGePointOnCurve3d result = new OdGePointOnCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve3d mirror(OdGePlane plane)
	{
		OdGePointOnCurve3d result = new OdGePointOnCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGePointOnCurve3d result = new OdGePointOnCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve3d scaleBy(double scaleFactor)
	{
		OdGePointOnCurve3d result = new OdGePointOnCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePointOnCurve3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePointOnCurve3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePointOnCurve3d(OdGeCurve3d curve3d)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePointOnCurve3d__SWIG_1(OdGeCurve3d.getCPtr(curve3d)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePointOnCurve3d(OdGeCurve3d curve3d, double param)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePointOnCurve3d__SWIG_2(OdGeCurve3d.getCPtr(curve3d), param), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePointOnCurve3d(OdGePointOnCurve3d src)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePointOnCurve3d__SWIG_3(getCPtr(src)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePointOnCurve3d Assign(OdGePointOnCurve3d src)
	{
		OdGePointOnCurve3d result = new OdGePointOnCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_Assign(swigCPtr, getCPtr(src)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve3d curve()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_curve(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double parameter()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_parameter(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d point()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_point__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d point(double param)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_point__SWIG_1(swigCPtr, param), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d point(OdGeCurve3d curve3d, double param)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_point__SWIG_2(swigCPtr, OdGeCurve3d.getCPtr(curve3d), param), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d deriv(int order)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_deriv__SWIG_0(swigCPtr, order), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d deriv(int order, double param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_deriv__SWIG_1(swigCPtr, order, param), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d deriv(int order, OdGeCurve3d curve3d, double param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_deriv__SWIG_2(swigCPtr, order, OdGeCurve3d.getCPtr(curve3d), param), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSingular(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_isSingular__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSingular()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_isSingular__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool curvature(out double res)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_curvature__SWIG_0(swigCPtr, out res);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool curvature(double param, out double res)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_curvature__SWIG_1(swigCPtr, param, out res);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePointOnCurve3d setCurve(OdGeCurve3d curve3d)
	{
		OdGePointOnCurve3d result = new OdGePointOnCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_setCurve(swigCPtr, OdGeCurve3d.getCPtr(curve3d)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePointOnCurve3d setParameter(double param)
	{
		OdGePointOnCurve3d result = new OdGePointOnCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve3d_setParameter(swigCPtr, param), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

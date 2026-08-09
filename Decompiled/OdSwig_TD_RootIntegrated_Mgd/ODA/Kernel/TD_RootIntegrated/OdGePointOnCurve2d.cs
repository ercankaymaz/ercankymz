using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGePointOnCurve2d : OdGePointEnt2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGePointOnCurve2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGePointOnCurve2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGePointOnCurve2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGePointOnCurve2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_copy(swigCPtr);
		OdGePointOnCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGePointOnCurve2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve2d transformBy(OdGeMatrix2d xfm)
	{
		OdGePointOnCurve2d result = new OdGePointOnCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve2d translateBy(OdGeVector2d translateVec)
	{
		OdGePointOnCurve2d result = new OdGePointOnCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGePointOnCurve2d result = new OdGePointOnCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve2d rotateBy(double angle)
	{
		OdGePointOnCurve2d result = new OdGePointOnCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve2d mirror(OdGeLine2d line)
	{
		OdGePointOnCurve2d result = new OdGePointOnCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGePointOnCurve2d result = new OdGePointOnCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnCurve2d scaleBy(double scaleFactor)
	{
		OdGePointOnCurve2d result = new OdGePointOnCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePointOnCurve2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePointOnCurve2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePointOnCurve2d(OdGeCurve2d curve2d, double param)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePointOnCurve2d__SWIG_1(OdGeCurve2d.getCPtr(curve2d), param), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePointOnCurve2d(OdGeCurve2d curve2d)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePointOnCurve2d__SWIG_2(OdGeCurve2d.getCPtr(curve2d)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePointOnCurve2d(OdGePointOnCurve2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePointOnCurve2d__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePointOnCurve2d Assign(OdGePointOnCurve2d pntOnCurve)
	{
		OdGePointOnCurve2d result = new OdGePointOnCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_Assign(swigCPtr, getCPtr(pntOnCurve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve2d curve()
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_curve(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double parameter()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_parameter(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d point()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_point__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d point(double param)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_point__SWIG_1(swigCPtr, param), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d point(OdGeCurve2d curve2d, double param)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_point__SWIG_2(swigCPtr, OdGeCurve2d.getCPtr(curve2d), param), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d deriv(int order)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_deriv__SWIG_0(swigCPtr, order), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d deriv(int order, double param)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_deriv__SWIG_1(swigCPtr, order, param), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d deriv(int order, OdGeCurve2d curve2d, double param)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_deriv__SWIG_2(swigCPtr, order, OdGeCurve2d.getCPtr(curve2d), param), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSingular(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_isSingular__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSingular()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_isSingular__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool curvature(out double res)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_curvature__SWIG_0(swigCPtr, out res);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool curvature(double param, out double res)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_curvature__SWIG_1(swigCPtr, param, out res);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePointOnCurve2d setCurve(OdGeCurve2d curve2d)
	{
		OdGePointOnCurve2d result = new OdGePointOnCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_setCurve(swigCPtr, OdGeCurve2d.getCPtr(curve2d)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePointOnCurve2d setParameter(double param)
	{
		OdGePointOnCurve2d result = new OdGePointOnCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnCurve2d_setParameter(swigCPtr, param), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

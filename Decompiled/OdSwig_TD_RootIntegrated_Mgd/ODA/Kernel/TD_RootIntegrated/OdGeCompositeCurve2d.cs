using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCompositeCurve2d : OdGeCurve2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCompositeCurve2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCompositeCurve2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCompositeCurve2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeCompositeCurve2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_copy(swigCPtr);
		OdGeCompositeCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeCompositeCurve2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeCompositeCurve2d result = new OdGeCompositeCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve2d translateBy(OdGeVector2d translateVec)
	{
		OdGeCompositeCurve2d result = new OdGeCompositeCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeCompositeCurve2d result = new OdGeCompositeCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve2d rotateBy(double angle)
	{
		OdGeCompositeCurve2d result = new OdGeCompositeCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve2d mirror(OdGeLine2d line)
	{
		OdGeCompositeCurve2d result = new OdGeCompositeCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeCompositeCurve2d result = new OdGeCompositeCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve2d scaleBy(double scaleFactor)
	{
		OdGeCompositeCurve2d result = new OdGeCompositeCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCompositeCurve2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCompositeCurve2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCompositeCurve2d(OdGeCompositeCurve2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCompositeCurve2d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCompositeCurve2d(OdGeCurve2dPtrArray curveList)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCompositeCurve2d__SWIG_2(OdGeCurve2dPtrArray.getCPtr(curveList)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCurveList(OdGeCurve2dPtrArray curveList)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_getCurveList__SWIG_0(swigCPtr, OdGeCurve2dPtrArray.getCPtr(curveList));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve2dPtrArray getCurveList()
	{
		OdGeCurve2dPtrArray result = new OdGeCurve2dPtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_getCurveList__SWIG_1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCompositeCurve2d setCurveList(OdGeCurve2dPtrArray curveList)
	{
		OdGeCompositeCurve2d result = new OdGeCompositeCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_setCurveList(swigCPtr, OdGeCurve2dPtrArray.getCPtr(curveList)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double globalToLocalParam(double param, out int crvNum)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_globalToLocalParam(swigCPtr, param, out crvNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double localToGlobalParam(double param, int crvNum)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_localToGlobalParam(swigCPtr, param, crvNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCompositeCurve2d Assign(OdGeCompositeCurve2d compCurve)
	{
		OdGeCompositeCurve2d result = new OdGeCompositeCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve2d_Assign(swigCPtr, getCPtr(compCurve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

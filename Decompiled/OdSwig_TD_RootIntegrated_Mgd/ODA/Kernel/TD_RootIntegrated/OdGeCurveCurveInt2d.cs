using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCurveCurveInt2d : OdGeEntity2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCurveCurveInt2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCurveCurveInt2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCurveCurveInt2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeCurveCurveInt2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_copy(swigCPtr);
		OdGeCurveCurveInt2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeCurveCurveInt2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt2d translateBy(OdGeVector2d translateVec)
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt2d rotateBy(double angle)
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt2d mirror(OdGeLine2d line)
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt2d scaleBy(double scaleFactor)
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt2d(OdGeCurve2d curve1, OdGeCurve2d curve2, OdGeTol tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt2d__SWIG_1(OdGeCurve2d.getCPtr(curve1), OdGeCurve2d.getCPtr(curve2), OdGeTol.getCPtr(tol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt2d(OdGeCurve2d curve1, OdGeCurve2d curve2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt2d__SWIG_2(OdGeCurve2d.getCPtr(curve1), OdGeCurve2d.getCPtr(curve2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt2d(OdGeCurve2d curve1, OdGeCurve2d curve2, OdGeInterval range1, OdGeInterval range2, OdGeTol tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt2d__SWIG_3(OdGeCurve2d.getCPtr(curve1), OdGeCurve2d.getCPtr(curve2), OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2), OdGeTol.getCPtr(tol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt2d(OdGeCurve2d curve1, OdGeCurve2d curve2, OdGeInterval range1, OdGeInterval range2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt2d__SWIG_4(OdGeCurve2d.getCPtr(curve1), OdGeCurve2d.getCPtr(curve2), OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt2d(OdGeCurveCurveInt2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt2d__SWIG_5(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve2d curve1()
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_curve1(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve2d curve2()
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_curve2(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getIntRanges(OdGeInterval range1, OdGeInterval range2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_getIntRanges(swigCPtr, OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeTol tolerance()
	{
		OdGeTol result = new OdGeTol(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_tolerance(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numIntPoints()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_numIntPoints(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d intPoint(int intNum)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_intPoint(swigCPtr, intNum), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getIntParams(int intNum, out double param1, out double param2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_getIntParams(swigCPtr, intNum, out param1, out param2);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPointOnCurve1(int intNum, OdGePointOnCurve2d intPnt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_getPointOnCurve1(swigCPtr, intNum, OdGePointOnCurve2d.getCPtr(intPnt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPointOnCurve2(int intNum, OdGePointOnCurve2d intPnt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_getPointOnCurve2(swigCPtr, intNum, OdGePointOnCurve2d.getCPtr(intPnt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getIntConfigs(int intNum, ref OdGe_OdGeXConfig config1wrt2, ref OdGe_OdGeXConfig config2wrt1)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_getIntConfigs(swigCPtr, intNum, ref config1wrt2, ref config2wrt1);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isTangential(int intNum)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_isTangential(swigCPtr, intNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTransversal(int intNum)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_isTransversal(swigCPtr, intNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double intPointTol(int intNum)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_intPointTol(swigCPtr, intNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int overlapCount()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_overlapCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool overlapDirection(int overlapNum)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_overlapDirection(swigCPtr, overlapNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getOverlapRanges(int overlapNum, OdGeInterval range1, OdGeInterval range2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_getOverlapRanges(swigCPtr, overlapNum, OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void changeCurveOrder()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_changeCurveOrder(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt2d orderWrt1()
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_orderWrt1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt2d orderWrt2()
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_orderWrt2(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt2d set(OdGeCurve2d curve1, OdGeCurve2d curve2, OdGeTol tol)
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_set__SWIG_0(swigCPtr, OdGeCurve2d.getCPtr(curve1), OdGeCurve2d.getCPtr(curve2), OdGeTol.getCPtr(tol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt2d set(OdGeCurve2d curve1, OdGeCurve2d curve2)
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_set__SWIG_1(swigCPtr, OdGeCurve2d.getCPtr(curve1), OdGeCurve2d.getCPtr(curve2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt2d set(OdGeCurve2d curve1, OdGeCurve2d curve2, OdGeInterval range1, OdGeInterval range2, OdGeTol tol)
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_set__SWIG_2(swigCPtr, OdGeCurve2d.getCPtr(curve1), OdGeCurve2d.getCPtr(curve2), OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2), OdGeTol.getCPtr(tol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt2d set(OdGeCurve2d curve1, OdGeCurve2d curve2, OdGeInterval range1, OdGeInterval range2)
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_set__SWIG_3(swigCPtr, OdGeCurve2d.getCPtr(curve1), OdGeCurve2d.getCPtr(curve2), OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt2d Assign(OdGeCurveCurveInt2d crvCrvInt)
	{
		OdGeCurveCurveInt2d result = new OdGeCurveCurveInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt2d_Assign(swigCPtr, getCPtr(crvCrvInt)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

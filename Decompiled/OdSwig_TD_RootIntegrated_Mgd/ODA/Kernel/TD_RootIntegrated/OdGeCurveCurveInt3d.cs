using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCurveCurveInt3d : OdGeEntity3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCurveCurveInt3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCurveCurveInt3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCurveCurveInt3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeCurveCurveInt3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_copy(swigCPtr);
		OdGeCurveCurveInt3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeCurveCurveInt3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt3d translateBy(OdGeVector3d translateVec)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt3d mirror(OdGePlane plane)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveCurveInt3d scaleBy(double scaleFactor)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt3d(OdGeCurve3d curve1, OdGeCurve3d curve2, OdGeVector3d planeNormal, OdGeTol tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt3d__SWIG_1(OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), OdGeVector3d.getCPtr(planeNormal), OdGeTol.getCPtr(tol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt3d(OdGeCurve3d curve1, OdGeCurve3d curve2, OdGeVector3d planeNormal)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt3d__SWIG_2(OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), OdGeVector3d.getCPtr(planeNormal)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt3d(OdGeCurve3d curve1, OdGeCurve3d curve2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt3d__SWIG_3(OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt3d(OdGeCurve3d curve1, OdGeCurve3d curve2, OdGeInterval range1, OdGeInterval range2, OdGeVector3d planeNormal, OdGeTol tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt3d__SWIG_4(OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2), OdGeVector3d.getCPtr(planeNormal), OdGeTol.getCPtr(tol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt3d(OdGeCurve3d curve1, OdGeCurve3d curve2, OdGeInterval range1, OdGeInterval range2, OdGeVector3d planeNormal)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt3d__SWIG_5(OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2), OdGeVector3d.getCPtr(planeNormal)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt3d(OdGeCurve3d curve1, OdGeCurve3d curve2, OdGeInterval range1, OdGeInterval range2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt3d__SWIG_6(OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt3d(OdGeCurveCurveInt3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveCurveInt3d__SWIG_7(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve3d curve1()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_curve1(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve3d curve2()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_curve2(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getIntRanges(OdGeInterval range1, OdGeInterval range2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_getIntRanges(swigCPtr, OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d planeNormal()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_planeNormal(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTol tolerance()
	{
		OdGeTol result = new OdGeTol(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_tolerance(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numIntPoints()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_numIntPoints(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d intPoint(int intNum)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_intPoint(swigCPtr, intNum), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getIntParams(int intNum, out double param1, out double param2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_getIntParams(swigCPtr, intNum, out param1, out param2);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPointOnCurve1(int intNum, OdGePointOnCurve3d intPnt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_getPointOnCurve1(swigCPtr, intNum, OdGePointOnCurve3d.getCPtr(intPnt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPointOnCurve2(int intNum, OdGePointOnCurve3d intPnt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_getPointOnCurve2(swigCPtr, intNum, OdGePointOnCurve3d.getCPtr(intPnt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getIntConfigs(int intNum, ref OdGe_OdGeXConfig config1wrt2, ref OdGe_OdGeXConfig config2wrt1)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_getIntConfigs(swigCPtr, intNum, ref config1wrt2, ref config2wrt1);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isTangential(int intNum)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_isTangential(swigCPtr, intNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTransversal(int intNum)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_isTransversal(swigCPtr, intNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double intPointTol(int intNum)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_intPointTol(swigCPtr, intNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int overlapCount()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_overlapCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool overlapDirection(int overlapNum)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_overlapDirection(swigCPtr, overlapNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getOverlapRanges(int overlapNum, OdGeInterval range1, OdGeInterval range2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_getOverlapRanges(swigCPtr, overlapNum, OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void changeCurveOrder()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_changeCurveOrder(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveCurveInt3d orderWrt1()
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_orderWrt1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt3d orderWrt2()
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_orderWrt2(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt3d set(OdGeCurve3d curve1, OdGeCurve3d curve2, OdGeVector3d planeNormal, OdGeTol tol)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_set__SWIG_0(swigCPtr, OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), OdGeVector3d.getCPtr(planeNormal), OdGeTol.getCPtr(tol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt3d set(OdGeCurve3d curve1, OdGeCurve3d curve2, OdGeVector3d planeNormal)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_set__SWIG_1(swigCPtr, OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), OdGeVector3d.getCPtr(planeNormal)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt3d set(OdGeCurve3d curve1, OdGeCurve3d curve2)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_set__SWIG_2(swigCPtr, OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt3d set(OdGeCurve3d curve1, OdGeCurve3d curve2, OdGeInterval range1, OdGeInterval range2, OdGeVector3d planeNormal, OdGeTol tol)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_set__SWIG_3(swigCPtr, OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2), OdGeVector3d.getCPtr(planeNormal), OdGeTol.getCPtr(tol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt3d set(OdGeCurve3d curve1, OdGeCurve3d curve2, OdGeInterval range1, OdGeInterval range2, OdGeVector3d planeNormal)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_set__SWIG_4(swigCPtr, OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2), OdGeVector3d.getCPtr(planeNormal)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt3d set(OdGeCurve3d curve1, OdGeCurve3d curve2, OdGeInterval range1, OdGeInterval range2)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_set__SWIG_5(swigCPtr, OdGeCurve3d.getCPtr(curve1), OdGeCurve3d.getCPtr(curve2), OdGeInterval.getCPtr(range1), OdGeInterval.getCPtr(range2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveCurveInt3d Assign(OdGeCurveCurveInt3d crvCrvInt)
	{
		OdGeCurveCurveInt3d result = new OdGeCurveCurveInt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveCurveInt3d_Assign(swigCPtr, getCPtr(crvCrvInt)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

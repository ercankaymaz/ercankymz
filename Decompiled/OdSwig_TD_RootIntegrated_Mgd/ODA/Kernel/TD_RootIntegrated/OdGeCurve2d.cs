using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCurve2d : OdGeEntity2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCurve2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCurve2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCurve2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeCurve2d copy()
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_copy(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve2d translateBy(OdGeVector2d translateVec)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve2d rotateBy(double angle)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_rotateBy__SWIG_1(swigCPtr, angle), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve2d mirror(OdGeLine2d line)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve2d scaleBy(double scaleFactor)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve3d convertTo3d()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_convertTo3d__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void convertTo3d(ref OdGeCurve3d curve3d)
	{
		IntPtr jarg = ((curve3d == null) ? IntPtr.Zero : OdGeCurve3d.getCPtr(curve3d).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_convertTo3d__SWIG_1(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				curve3d = null;
			}
			if (jarg != intPtr)
			{
				curve3d = Helpers.GetObject<OdGeCurve3d>(jarg, bOwn: true, bTryAddToTransaction: false);
			}
		}
	}

	public void getInterval(OdGeInterval interval)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getInterval__SWIG_0(swigCPtr, OdGeInterval.getCPtr(interval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getInterval(OdGeInterval interval, OdGePoint2d start, OdGePoint2d end)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getInterval__SWIG_1(swigCPtr, OdGeInterval.getCPtr(interval), OdGePoint2d.getCPtr(start), OdGePoint2d.getCPtr(end));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve2d reverseParam()
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_reverseParam(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve2d setInterval()
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_setInterval__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setInterval(OdGeInterval interval)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_setInterval__SWIG_1(swigCPtr, OdGeInterval.getCPtr(interval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGePoint2d point, OdGeTol tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_distanceTo__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGePoint2d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_distanceTo__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGeCurve2d otherCur, OdGeTol tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_distanceTo__SWIG_2(swigCPtr, getCPtr(otherCur), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGeCurve2d otherCur)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_distanceTo__SWIG_3(swigCPtr, getCPtr(otherCur));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d closestPointTo(OdGePoint2d point, OdGeTol tol)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_closestPointTo__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d closestPointTo(OdGePoint2d point)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_closestPointTo__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d closestPointTo(OdGePoint2d point, out double param, OdGeInterval range, OdGeTol tol)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_closestPointTo__SWIG_2(swigCPtr, OdGePoint2d.getCPtr(point), out param, OdGeInterval.getCPtr(range), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d closestPointTo(OdGePoint2d point, out double param, OdGeInterval range)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_closestPointTo__SWIG_3(swigCPtr, OdGePoint2d.getCPtr(point), out param, OdGeInterval.getCPtr(range)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d closestPointTo(OdGeCurve2d curve2d, OdGePoint2d pntOnOtherCrv, OdGeTol tol)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_closestPointTo__SWIG_4(swigCPtr, getCPtr(curve2d), OdGePoint2d.getCPtr(pntOnOtherCrv), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d closestPointTo(OdGeCurve2d curve2d, OdGePoint2d pntOnOtherCrv)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_closestPointTo__SWIG_5(swigCPtr, getCPtr(curve2d), OdGePoint2d.getCPtr(pntOnOtherCrv)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getClosestPointTo(OdGePoint2d point, OdGePointOnCurve2d pntOnCrv, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getClosestPointTo__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGePointOnCurve2d.getCPtr(pntOnCrv), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getClosestPointTo(OdGePoint2d point, OdGePointOnCurve2d pntOnCrv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getClosestPointTo__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point), OdGePointOnCurve2d.getCPtr(pntOnCrv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getClosestPointTo(OdGeCurve2d curve2d, OdGePointOnCurve2d pntOnThisCrv, OdGePointOnCurve2d pntOnOtherCrv, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getClosestPointTo__SWIG_2(swigCPtr, getCPtr(curve2d), OdGePointOnCurve2d.getCPtr(pntOnThisCrv), OdGePointOnCurve2d.getCPtr(pntOnOtherCrv), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getClosestPointTo(OdGeCurve2d curve2d, OdGePointOnCurve2d pntOnThisCrv, OdGePointOnCurve2d pntOnOtherCrv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getClosestPointTo__SWIG_3(swigCPtr, getCPtr(curve2d), OdGePointOnCurve2d.getCPtr(pntOnThisCrv), OdGePointOnCurve2d.getCPtr(pntOnOtherCrv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getNormalPoint(OdGePoint2d point, OdGePointOnCurve2d pntOnCrv, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getNormalPoint__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGePointOnCurve2d.getCPtr(pntOnCrv), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getNormalPoint(OdGePoint2d point, OdGePointOnCurve2d pntOnCrv)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getNormalPoint__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point), OdGePointOnCurve2d.getCPtr(pntOnCrv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(OdGePoint2d point, out double param, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_isOn__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), out param, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(OdGePoint2d point, out double param)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_isOn__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point), out param);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(double param, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_isOn__SWIG_2(swigCPtr, param, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(double param)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_isOn__SWIG_3(swigCPtr, param);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double paramOf(OdGePoint2d point, OdGeTol tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_paramOf__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double paramOf(OdGePoint2d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_paramOf__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double paramOf(OdGePoint2d point, OdGeInterval range, OdGeTol tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_paramOf__SWIG_2(swigCPtr, OdGePoint2d.getCPtr(point), OdGeInterval.getCPtr(range), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult getTrimmedOffset(double distance, OdGeCurve2dPtrArray offsetCurveList, OdGe_OffsetCrvExtType extensionType, OdGeTol tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getTrimmedOffset__SWIG_0(swigCPtr, distance, OdGeCurve2dPtrArray.getCPtr(offsetCurveList), (int)extensionType, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getTrimmedOffset(double distance, OdGeCurve2dPtrArray offsetCurveList, OdGe_OffsetCrvExtType extensionType)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getTrimmedOffset__SWIG_1(swigCPtr, distance, OdGeCurve2dPtrArray.getCPtr(offsetCurveList), (int)extensionType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getTrimmedOffset(double distance, OdGeCurve2dPtrArray offsetCurveList)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getTrimmedOffset__SWIG_2(swigCPtr, distance, OdGeCurve2dPtrArray.getCPtr(offsetCurveList));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public bool isClosed(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_isClosed__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_isClosed__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPeriodic(out double period)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_isPeriodic(swigCPtr, out period);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLinear(OdGeLine2d line, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_isLinear__SWIG_0(swigCPtr, OdGeLine2d.getCPtr(line), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLinear(OdGeLine2d line)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_isLinear__SWIG_1(swigCPtr, OdGeLine2d.getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double length(double fromParam, double toParam, double tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_length__SWIG_0(swigCPtr, fromParam, toParam, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double length(double tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_length__SWIG_1(swigCPtr, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double paramAtLength(double datumParam, double length, bool posParamDir, double tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_paramAtLength(swigCPtr, datumParam, length, posParamDir, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool area(double startParam, double endParam, out double value, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_area__SWIG_0(swigCPtr, startParam, endParam, out value, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool area(double startParam, double endParam, out double value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_area__SWIG_1(swigCPtr, startParam, endParam, out value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getSplitCurves(double param, out OdGeCurve2d piece1, out OdGeCurve2d piece2)
	{
		IntPtr jarg = IntPtr.Zero;
		IntPtr jarg2 = IntPtr.Zero;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getSplitCurves(swigCPtr, param, out jarg, out jarg2);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeCurve2d>(typeof(OdGeCurve2d), jarg, bIsWrapperOwnNativeObject: true));
			piece1 = Helpers.odCreateObjectInternal<OdGeCurve2d>(typeof(OdGeCurve2d), jarg, currentTransaction == null);
			MemoryTransaction currentTransaction2 = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction2?.AddObject(Helpers.odCreateObjectInternal<OdGeCurve2d>(typeof(OdGeCurve2d), jarg2, bIsWrapperOwnNativeObject: true));
			piece2 = Helpers.odCreateObjectInternal<OdGeCurve2d>(typeof(OdGeCurve2d), jarg2, currentTransaction2 == null);
		}
	}

	public bool explode(OdGeCurve2dPtrArray explodedCurves, OdIntArray newExplodedCurve, OdGeInterval interval)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_explode__SWIG_0(swigCPtr, OdGeCurve2dPtrArray.getCPtr(explodedCurves), OdIntArray.getCPtr(newExplodedCurve).Handle, OdGeInterval.getCPtr(interval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool explode(OdGeCurve2dPtrArray explodedCurves, OdIntArray newExplodedCurve)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_explode__SWIG_1(swigCPtr, OdGeCurve2dPtrArray.getCPtr(explodedCurves), OdIntArray.getCPtr(newExplodedCurve).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getLocalClosestPoints(OdGePoint2d point, OdGePointOnCurve2d approxPnt, OdGeInterval nbhd, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getLocalClosestPoints__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGePointOnCurve2d.getCPtr(approxPnt), OdGeInterval.getCPtr(nbhd), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalClosestPoints(OdGePoint2d point, OdGePointOnCurve2d approxPnt, OdGeInterval nbhd)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getLocalClosestPoints__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point), OdGePointOnCurve2d.getCPtr(approxPnt), OdGeInterval.getCPtr(nbhd));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalClosestPoints(OdGePoint2d point, OdGePointOnCurve2d approxPnt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getLocalClosestPoints__SWIG_2(swigCPtr, OdGePoint2d.getCPtr(point), OdGePointOnCurve2d.getCPtr(approxPnt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalClosestPoints(OdGeCurve2d otherCurve, OdGePointOnCurve2d approxPntOnThisCrv, OdGePointOnCurve2d approxPntOnOtherCrv, OdGeInterval nbhd1, OdGeInterval nbhd2, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getLocalClosestPoints__SWIG_3(swigCPtr, getCPtr(otherCurve), OdGePointOnCurve2d.getCPtr(approxPntOnThisCrv), OdGePointOnCurve2d.getCPtr(approxPntOnOtherCrv), OdGeInterval.getCPtr(nbhd1), OdGeInterval.getCPtr(nbhd2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalClosestPoints(OdGeCurve2d otherCurve, OdGePointOnCurve2d approxPntOnThisCrv, OdGePointOnCurve2d approxPntOnOtherCrv, OdGeInterval nbhd1, OdGeInterval nbhd2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getLocalClosestPoints__SWIG_4(swigCPtr, getCPtr(otherCurve), OdGePointOnCurve2d.getCPtr(approxPntOnThisCrv), OdGePointOnCurve2d.getCPtr(approxPntOnOtherCrv), OdGeInterval.getCPtr(nbhd1), OdGeInterval.getCPtr(nbhd2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalClosestPoints(OdGeCurve2d otherCurve, OdGePointOnCurve2d approxPntOnThisCrv, OdGePointOnCurve2d approxPntOnOtherCrv, OdGeInterval nbhd1)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getLocalClosestPoints__SWIG_5(swigCPtr, getCPtr(otherCurve), OdGePointOnCurve2d.getCPtr(approxPntOnThisCrv), OdGePointOnCurve2d.getCPtr(approxPntOnOtherCrv), OdGeInterval.getCPtr(nbhd1));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalClosestPoints(OdGeCurve2d otherCurve, OdGePointOnCurve2d approxPntOnThisCrv, OdGePointOnCurve2d approxPntOnOtherCrv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getLocalClosestPoints__SWIG_6(swigCPtr, getCPtr(otherCurve), OdGePointOnCurve2d.getCPtr(approxPntOnThisCrv), OdGePointOnCurve2d.getCPtr(approxPntOnOtherCrv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundBlock2d boundBlock()
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_boundBlock__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock2d boundBlock(OdGeInterval range)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_boundBlock__SWIG_1(swigCPtr, OdGeInterval.getCPtr(range)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock2d orthoBoundBlock()
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_orthoBoundBlock__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock2d orthoBoundBlock(OdGeInterval range)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_orthoBoundBlock__SWIG_1(swigCPtr, OdGeInterval.getCPtr(range)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents2d getGeomExtents(OdGeInterval range, OdGeMatrix2d coordSystem)
	{
		OdGeExtents2d result = new OdGeExtents2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getGeomExtents__SWIG_0(swigCPtr, OdGeInterval.getCPtr(range), OdGeMatrix2d.getCPtr(coordSystem)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents2d getGeomExtents(OdGeInterval range)
	{
		OdGeExtents2d result = new OdGeExtents2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getGeomExtents__SWIG_1(swigCPtr, OdGeInterval.getCPtr(range)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents2d getGeomExtents()
	{
		OdGeExtents2d result = new OdGeExtents2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getGeomExtents__SWIG_2(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasStartPoint(OdGePoint2d startPoint)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_hasStartPoint(swigCPtr, OdGePoint2d.getCPtr(startPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasEndPoint(OdGePoint2d endPoint)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_hasEndPoint(swigCPtr, OdGePoint2d.getCPtr(endPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasMidPoint(OdGePoint2d point, double coef)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_hasMidPoint__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), coef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasMidPoint(OdGePoint2d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_hasMidPoint__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d midPoint(double coef)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_midPoint__SWIG_0(swigCPtr, coef), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d midPoint()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_midPoint__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d evalPoint(double param)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_evalPoint__SWIG_0(swigCPtr, param), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d evalPoint(double param, int numDeriv, OdGeVector2dArray derivatives)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_evalPoint__SWIG_1(swigCPtr, param, numDeriv, OdGeVector2dArray.getCPtr(derivatives)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getSamplePoints(double fromParam, double toParam, double approxEps, OdGePoint2dArray pointArray, OdDoubleArray paramArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getSamplePoints__SWIG_0(swigCPtr, fromParam, toParam, approxEps, OdGePoint2dArray.getCPtr(pointArray).Handle, OdDoubleArray.getCPtr(paramArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSamplePoints(int numSample, OdGePoint2dArray pointArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getSamplePoints__SWIG_1(swigCPtr, numSample, OdGePoint2dArray.getCPtr(pointArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve2d Assign(OdGeCurve2d curve)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_Assign(swigCPtr, getCPtr(curve)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getSamplePoints(double fromParam, double toParam, double approxEps, OdGePoint2dArray pointArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getSamplePoints__SWIG_3(swigCPtr, fromParam, toParam, approxEps, OdGePoint2dArray.getCPtr(pointArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void appendSamplePoints(double fromParam, double toParam, double approxEps, OdGePoint2dArray pointArray, OdDoubleArray pParamArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_appendSamplePoints__SWIG_0(swigCPtr, fromParam, toParam, approxEps, OdGePoint2dArray.getCPtr(pointArray).Handle, OdDoubleArray.getCPtr(pParamArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void appendSamplePoints(double fromParam, double toParam, double approxEps, OdGePoint2dArray pointArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_appendSamplePoints__SWIG_1(swigCPtr, fromParam, toParam, approxEps, OdGePoint2dArray.getCPtr(pointArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void appendSamplePoints(int numSample, OdGePoint2dArray pointArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_appendSamplePoints__SWIG_2(swigCPtr, numSample, OdGePoint2dArray.getCPtr(pointArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGeCurve2d restoreUvCurve(OdGeCurve3d curve, OdGeSurface surface, OdGeTol tol)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_restoreUvCurve__SWIG_0(OdGeCurve3d.getCPtr(curve), OdGeSurface.getCPtr(surface), OdGeTol.getCPtr(tol)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeCurve2d restoreUvCurve(OdGeCurve3d curve, OdGeSurface surface)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_restoreUvCurve__SWIG_1(OdGeCurve3d.getCPtr(curve), OdGeSurface.getCPtr(surface)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve2d_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

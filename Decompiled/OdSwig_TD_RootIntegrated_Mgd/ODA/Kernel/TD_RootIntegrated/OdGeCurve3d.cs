using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCurve3d : OdGeEntity3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCurve3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCurve3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCurve3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeCurve3d copy()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_copy(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve3d translateBy(OdGeVector3d translateVec)
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve3d mirror(OdGePlane plane)
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurve3d scaleBy(double scaleFactor)
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getInterval(OdGeInterval interval)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getInterval__SWIG_0(swigCPtr, OdGeInterval.getCPtr(interval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getInterval(OdGeInterval interval, OdGePoint3d start, OdGePoint3d end)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getInterval__SWIG_1(swigCPtr, OdGeInterval.getCPtr(interval), OdGePoint3d.getCPtr(start), OdGePoint3d.getCPtr(end));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve3d reverseParam()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_reverseParam(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve3d setInterval()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_setInterval__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setInterval(OdGeInterval interval)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_setInterval__SWIG_1(swigCPtr, OdGeInterval.getCPtr(interval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGePoint3d point, OdGeTol tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_distanceTo__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGePoint3d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_distanceTo__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGeCurve3d curve, OdGeTol tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_distanceTo__SWIG_2(swigCPtr, getCPtr(curve), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGeCurve3d curve)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_distanceTo__SWIG_3(swigCPtr, getCPtr(curve));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointTo(OdGePoint3d point, OdGeTol tol)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_closestPointTo__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointTo(OdGePoint3d point)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_closestPointTo__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointTo(OdGeCurve3d curve, OdGePoint3d pntOnOtherCrv, OdGeTol tol)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_closestPointTo__SWIG_2(swigCPtr, getCPtr(curve), OdGePoint3d.getCPtr(pntOnOtherCrv), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointTo(OdGeCurve3d curve, OdGePoint3d pntOnOtherCrv)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_closestPointTo__SWIG_3(swigCPtr, getCPtr(curve), OdGePoint3d.getCPtr(pntOnOtherCrv)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointTo(OdGePoint3d point, out double param, OdGeInterval range, OdGeTol tol)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_closestPointTo__SWIG_4(swigCPtr, OdGePoint3d.getCPtr(point), out param, OdGeInterval.getCPtr(range), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointTo(OdGePoint3d point, out double param, OdGeInterval range)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_closestPointTo__SWIG_5(swigCPtr, OdGePoint3d.getCPtr(point), out param, OdGeInterval.getCPtr(range)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getClosestPointTo(OdGePoint3d point, OdGePointOnCurve3d pntOnCrv, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getClosestPointTo__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGePointOnCurve3d.getCPtr(pntOnCrv), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getClosestPointTo(OdGePoint3d point, OdGePointOnCurve3d pntOnCrv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getClosestPointTo__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), OdGePointOnCurve3d.getCPtr(pntOnCrv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getClosestPointTo(OdGeCurve3d curve, OdGePointOnCurve3d pntOnThisCrv, OdGePointOnCurve3d pntOnOtherCrv, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getClosestPointTo__SWIG_2(swigCPtr, getCPtr(curve), OdGePointOnCurve3d.getCPtr(pntOnThisCrv), OdGePointOnCurve3d.getCPtr(pntOnOtherCrv), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getClosestPointTo(OdGeCurve3d curve, OdGePointOnCurve3d pntOnThisCrv, OdGePointOnCurve3d pntOnOtherCrv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getClosestPointTo__SWIG_3(swigCPtr, getCPtr(curve), OdGePointOnCurve3d.getCPtr(pntOnThisCrv), OdGePointOnCurve3d.getCPtr(pntOnOtherCrv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d projClosestPointTo(OdGePoint3d point, OdGeVector3d projectDirection, OdGeTol tol)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_projClosestPointTo__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeVector3d.getCPtr(projectDirection), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d projClosestPointTo(OdGePoint3d point, OdGeVector3d projectDirection)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_projClosestPointTo__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), OdGeVector3d.getCPtr(projectDirection)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d projClosestPointTo(OdGeCurve3d curve, OdGeVector3d projectDirection, OdGePoint3d pntOnOtherCrv, OdGeTol tol)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_projClosestPointTo__SWIG_2(swigCPtr, getCPtr(curve), OdGeVector3d.getCPtr(projectDirection), OdGePoint3d.getCPtr(pntOnOtherCrv), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d projClosestPointTo(OdGeCurve3d curve, OdGeVector3d projectDirection, OdGePoint3d pntOnOtherCrv)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_projClosestPointTo__SWIG_3(swigCPtr, getCPtr(curve), OdGeVector3d.getCPtr(projectDirection), OdGePoint3d.getCPtr(pntOnOtherCrv)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getProjClosestPointTo(OdGePoint3d point, OdGeVector3d projectDirection, OdGePointOnCurve3d pntOnCrv, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getProjClosestPointTo__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeVector3d.getCPtr(projectDirection), OdGePointOnCurve3d.getCPtr(pntOnCrv), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getProjClosestPointTo(OdGePoint3d point, OdGeVector3d projectDirection, OdGePointOnCurve3d pntOnCrv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getProjClosestPointTo__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), OdGeVector3d.getCPtr(projectDirection), OdGePointOnCurve3d.getCPtr(pntOnCrv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getProjClosestPointTo(OdGeCurve3d curve, OdGeVector3d projectDirection, OdGePointOnCurve3d pntOnThisCrv, OdGePointOnCurve3d pntOnOtherCrv, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getProjClosestPointTo__SWIG_2(swigCPtr, getCPtr(curve), OdGeVector3d.getCPtr(projectDirection), OdGePointOnCurve3d.getCPtr(pntOnThisCrv), OdGePointOnCurve3d.getCPtr(pntOnOtherCrv), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getProjClosestPointTo(OdGeCurve3d curve, OdGeVector3d projectDirection, OdGePointOnCurve3d pntOnThisCrv, OdGePointOnCurve3d pntOnOtherCrv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getProjClosestPointTo__SWIG_3(swigCPtr, getCPtr(curve), OdGeVector3d.getCPtr(projectDirection), OdGePointOnCurve3d.getCPtr(pntOnThisCrv), OdGePointOnCurve3d.getCPtr(pntOnOtherCrv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getNormalPoint(OdGePoint3d point, OdGePointOnCurve3d pntOnCrv, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getNormalPoint__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGePointOnCurve3d.getCPtr(pntOnCrv), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getNormalPoint(OdGePoint3d point, OdGePointOnCurve3d pntOnCrv)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getNormalPoint__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), OdGePointOnCurve3d.getCPtr(pntOnCrv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock3d boundBlock()
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_boundBlock__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock3d boundBlock(OdGeInterval range)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_boundBlock__SWIG_1(swigCPtr, OdGeInterval.getCPtr(range)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock3d orthoBoundBlock()
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_orthoBoundBlock__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock3d orthoBoundBlock(OdGeInterval range)
	{
		OdGeBoundBlock3d result = new OdGeBoundBlock3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_orthoBoundBlock__SWIG_1(swigCPtr, OdGeInterval.getCPtr(range)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d getGeomExtents(OdGeInterval range, OdGeMatrix3d coordSystem)
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getGeomExtents__SWIG_0(swigCPtr, OdGeInterval.getCPtr(range), OdGeMatrix3d.getCPtr(coordSystem)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d getGeomExtents(OdGeInterval range)
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getGeomExtents__SWIG_1(swigCPtr, OdGeInterval.getCPtr(range)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d getGeomExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getGeomExtents__SWIG_2(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEntity3d project(OdGePlane projectionPlane, OdGeVector3d projectDirection, OdGeTol tol)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_project__SWIG_0(swigCPtr, OdGePlane.getCPtr(projectionPlane), OdGeVector3d.getCPtr(projectDirection), OdGeTol.getCPtr(tol));
		OdGeEntity3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeEntity3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEntity3d project(OdGePlane projectionPlane, OdGeVector3d projectDirection)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_project__SWIG_1(swigCPtr, OdGePlane.getCPtr(projectionPlane), OdGeVector3d.getCPtr(projectDirection));
		OdGeEntity3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeEntity3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEntity3d orthoProject(OdGePlane projectionPlane, OdGeTol tol)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_orthoProject__SWIG_0(swigCPtr, OdGePlane.getCPtr(projectionPlane), OdGeTol.getCPtr(tol));
		OdGeEntity3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeEntity3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEntity3d orthoProject(OdGePlane projectionPlane)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_orthoProject__SWIG_1(swigCPtr, OdGePlane.getCPtr(projectionPlane));
		OdGeEntity3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeEntity3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(OdGePoint3d point, out double param, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isOn__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), out param, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(OdGePoint3d point, out double param)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isOn__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), out param);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(double param, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isOn__SWIG_2(swigCPtr, param, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(double param)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isOn__SWIG_3(swigCPtr, param);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double paramOf(OdGePoint3d point, OdGeTol tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_paramOf__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double paramOf(OdGePoint3d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_paramOf__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double paramOf(OdGePoint3d point, OdGeInterval range, OdGeTol tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_paramOf__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(point), OdGeInterval.getCPtr(range), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double paramOf(OdGePoint3d point, OdGeInterval range)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_paramOf__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(point), OdGeInterval.getCPtr(range));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult getTrimmedOffset(double distance, OdGeVector3d planeNormal, OdGeCurve3dPtrArray offsetCurveList, OdGe_OffsetCrvExtType extensionType, OdGeTol tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getTrimmedOffset__SWIG_0(swigCPtr, distance, OdGeVector3d.getCPtr(planeNormal), OdGeCurve3dPtrArray.getCPtr(offsetCurveList), (int)extensionType, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getTrimmedOffset(double distance, OdGeVector3d planeNormal, OdGeCurve3dPtrArray offsetCurveList, OdGe_OffsetCrvExtType extensionType)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getTrimmedOffset__SWIG_1(swigCPtr, distance, OdGeVector3d.getCPtr(planeNormal), OdGeCurve3dPtrArray.getCPtr(offsetCurveList), (int)extensionType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getTrimmedOffset(double distance, OdGeVector3d planeNormal, OdGeCurve3dPtrArray offsetCurveList)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getTrimmedOffset__SWIG_2(swigCPtr, distance, OdGeVector3d.getCPtr(planeNormal), OdGeCurve3dPtrArray.getCPtr(offsetCurveList));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public bool isClosed(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isClosed__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isClosed__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPlanar(OdGePlane plane, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isPlanar__SWIG_0(swigCPtr, OdGePlane.getCPtr(plane), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPlanar(OdGePlane plane)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isPlanar__SWIG_1(swigCPtr, OdGePlane.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLinear(OdGeLine3d line, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isLinear__SWIG_0(swigCPtr, OdGeLine3d.getCPtr(line), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLinear(OdGeLine3d line)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isLinear__SWIG_1(swigCPtr, OdGeLine3d.getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCoplanarWith(OdGeCurve3d curve, OdGePlane plane, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isCoplanarWith__SWIG_0(swigCPtr, getCPtr(curve), OdGePlane.getCPtr(plane), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCoplanarWith(OdGeCurve3d curve, OdGePlane plane)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isCoplanarWith__SWIG_1(swigCPtr, getCPtr(curve), OdGePlane.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPeriodic(out double period)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_isPeriodic(swigCPtr, out period);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double length(double fromParam, double toParam, double tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_length__SWIG_0(swigCPtr, fromParam, toParam, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double length(double tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_length__SWIG_1(swigCPtr, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double paramAtLength(double datumParam, double length, bool posParamDir, double tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_paramAtLength(swigCPtr, datumParam, length, posParamDir, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool area(double startParam, double endParam, out double value, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_area__SWIG_0(swigCPtr, startParam, endParam, out value, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool area(double startParam, double endParam, out double value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_area__SWIG_1(swigCPtr, startParam, endParam, out value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getSplitCurves(double param, out OdGeCurve3d piece1, out OdGeCurve3d piece2)
	{
		IntPtr jarg = IntPtr.Zero;
		IntPtr jarg2 = IntPtr.Zero;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getSplitCurves(swigCPtr, param, out jarg, out jarg2);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, bIsWrapperOwnNativeObject: true));
			piece1 = Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, currentTransaction == null);
			MemoryTransaction currentTransaction2 = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction2?.AddObject(Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg2, bIsWrapperOwnNativeObject: true));
			piece2 = Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg2, currentTransaction2 == null);
		}
	}

	public bool explode(OdGeCurve3dPtrArray explodedCurves, OdIntArray newExplodedCurves, OdGeInterval pInterval)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_explode__SWIG_0(swigCPtr, OdGeCurve3dPtrArray.getCPtr(explodedCurves), OdIntArray.getCPtr(newExplodedCurves).Handle, OdGeInterval.getCPtr(pInterval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool explode(OdGeCurve3dPtrArray explodedCurves, OdIntArray newExplodedCurves)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_explode__SWIG_1(swigCPtr, OdGeCurve3dPtrArray.getCPtr(explodedCurves), OdIntArray.getCPtr(newExplodedCurves).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getLocalClosestPoints(OdGePoint3d point, OdGePointOnCurve3d approxPntOnThisCrv, OdGeInterval pInterval1, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getLocalClosestPoints__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGePointOnCurve3d.getCPtr(approxPntOnThisCrv), OdGeInterval.getCPtr(pInterval1), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalClosestPoints(OdGePoint3d point, OdGePointOnCurve3d approxPntOnThisCrv, OdGeInterval pInterval1)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getLocalClosestPoints__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), OdGePointOnCurve3d.getCPtr(approxPntOnThisCrv), OdGeInterval.getCPtr(pInterval1));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalClosestPoints(OdGePoint3d point, OdGePointOnCurve3d approxPntOnThisCrv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getLocalClosestPoints__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(point), OdGePointOnCurve3d.getCPtr(approxPntOnThisCrv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalClosestPoints(OdGeCurve3d curve, OdGePointOnCurve3d approxPntOnThisCrv, OdGePointOnCurve3d approxPntOnOtherCrv, OdGeInterval pInterval1, OdGeInterval pInterval2, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getLocalClosestPoints__SWIG_3(swigCPtr, getCPtr(curve), OdGePointOnCurve3d.getCPtr(approxPntOnThisCrv), OdGePointOnCurve3d.getCPtr(approxPntOnOtherCrv), OdGeInterval.getCPtr(pInterval1), OdGeInterval.getCPtr(pInterval2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalClosestPoints(OdGeCurve3d curve, OdGePointOnCurve3d approxPntOnThisCrv, OdGePointOnCurve3d approxPntOnOtherCrv, OdGeInterval pInterval1, OdGeInterval pInterval2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getLocalClosestPoints__SWIG_4(swigCPtr, getCPtr(curve), OdGePointOnCurve3d.getCPtr(approxPntOnThisCrv), OdGePointOnCurve3d.getCPtr(approxPntOnOtherCrv), OdGeInterval.getCPtr(pInterval1), OdGeInterval.getCPtr(pInterval2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalClosestPoints(OdGeCurve3d curve, OdGePointOnCurve3d approxPntOnThisCrv, OdGePointOnCurve3d approxPntOnOtherCrv, OdGeInterval pInterval1)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getLocalClosestPoints__SWIG_5(swigCPtr, getCPtr(curve), OdGePointOnCurve3d.getCPtr(approxPntOnThisCrv), OdGePointOnCurve3d.getCPtr(approxPntOnOtherCrv), OdGeInterval.getCPtr(pInterval1));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalClosestPoints(OdGeCurve3d curve, OdGePointOnCurve3d approxPntOnThisCrv, OdGePointOnCurve3d approxPntOnOtherCrv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getLocalClosestPoints__SWIG_6(swigCPtr, getCPtr(curve), OdGePointOnCurve3d.getCPtr(approxPntOnThisCrv), OdGePointOnCurve3d.getCPtr(approxPntOnOtherCrv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasStartPoint(OdGePoint3d startPoint)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_hasStartPoint(swigCPtr, OdGePoint3d.getCPtr(startPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasEndPoint(OdGePoint3d endPoint)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_hasEndPoint(swigCPtr, OdGePoint3d.getCPtr(endPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasMidPoint(OdGePoint3d point, double coef)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_hasMidPoint__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), coef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasMidPoint(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_hasMidPoint__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d midPoint(double coef)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_midPoint__SWIG_0(swigCPtr, coef), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d midPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_midPoint__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d evalPoint(double param)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_evalPoint__SWIG_0(swigCPtr, param), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d evalPoint(double param, int numDeriv, OdGeVector3dArray derivatives)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_evalPoint__SWIG_1(swigCPtr, param, numDeriv, OdGeVector3dArray.getCPtr(derivatives)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getSamplePoints(double fromParam, double toParam, double approxEps, OdGePoint3dArray pointArray, OdDoubleArray paramArray, bool forceResampling)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getSamplePoints__SWIG_0(swigCPtr, fromParam, toParam, approxEps, OdGePoint3dArray.getCPtr(pointArray), OdDoubleArray.getCPtr(paramArray).Handle, forceResampling);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSamplePoints(double fromParam, double toParam, double approxEps, OdGePoint3dArray pointArray, OdDoubleArray paramArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getSamplePoints__SWIG_1(swigCPtr, fromParam, toParam, approxEps, OdGePoint3dArray.getCPtr(pointArray), OdDoubleArray.getCPtr(paramArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSamplePoints(int numSample, OdGePoint3dArray pointArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getSamplePoints__SWIG_2(swigCPtr, numSample, OdGePoint3dArray.getCPtr(pointArray));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSamplePoints(int numSample, OdGePoint3dArray pointArray, OdDoubleArray paramArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getSamplePoints__SWIG_3(swigCPtr, numSample, OdGePoint3dArray.getCPtr(pointArray), OdDoubleArray.getCPtr(paramArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve3d Assign(OdGeCurve3d curve)
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_Assign(swigCPtr, getCPtr(curve)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getSamplePoints(double fromParam, double toParam, double approxEps, OdGePoint3dArray pointArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getSamplePoints__SWIG_5(swigCPtr, fromParam, toParam, approxEps, OdGePoint3dArray.getCPtr(pointArray));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSamplePoints(OdGeInterval paramInterval, double approxEps, OdGePoint3dArray pointArray, OdDoubleArray pParamArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getSamplePoints__SWIG_6(swigCPtr, OdGeInterval.getCPtr(paramInterval), approxEps, OdGePoint3dArray.getCPtr(pointArray), OdDoubleArray.getCPtr(pParamArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSamplePoints(OdGeInterval paramInterval, double approxEps, OdGePoint3dArray pointArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getSamplePoints__SWIG_7(swigCPtr, OdGeInterval.getCPtr(paramInterval), approxEps, OdGePoint3dArray.getCPtr(pointArray));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void appendSamplePoints(double fromParam, double toParam, double approxEps, OdGePoint3dArray pointArray, OdDoubleArray pParamArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_appendSamplePoints__SWIG_0(swigCPtr, fromParam, toParam, approxEps, OdGePoint3dArray.getCPtr(pointArray), OdDoubleArray.getCPtr(pParamArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void appendSamplePoints(double fromParam, double toParam, double approxEps, OdGePoint3dArray pointArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_appendSamplePoints__SWIG_1(swigCPtr, fromParam, toParam, approxEps, OdGePoint3dArray.getCPtr(pointArray));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void appendSamplePoints(int numSample, OdGePoint3dArray pointArray, OdDoubleArray pParamArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_appendSamplePoints__SWIG_2(swigCPtr, numSample, OdGePoint3dArray.getCPtr(pointArray), OdDoubleArray.getCPtr(pParamArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void appendSamplePoints(int numSample, OdGePoint3dArray pointArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_appendSamplePoints__SWIG_3(swigCPtr, numSample, OdGePoint3dArray.getCPtr(pointArray));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void appendSamplePoints(OdGeInterval paramInterval, double approxEps, OdGePoint3dArray pointArray, OdDoubleArray pParamArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_appendSamplePoints__SWIG_4(swigCPtr, OdGeInterval.getCPtr(paramInterval), approxEps, OdGePoint3dArray.getCPtr(pointArray), OdDoubleArray.getCPtr(pParamArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void appendSamplePoints(OdGeInterval paramInterval, double approxEps, OdGePoint3dArray pointArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_appendSamplePoints__SWIG_5(swigCPtr, OdGeInterval.getCPtr(paramInterval), approxEps, OdGePoint3dArray.getCPtr(pointArray));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve2d convertTo2d(OdGeTol tol, bool sameParametrization)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_convertTo2d__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol), sameParametrization), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve2d convertTo2d(OdGeTol tol)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_convertTo2d__SWIG_1(swigCPtr, OdGeTol.getCPtr(tol)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve2d convertTo2d()
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_convertTo2d__SWIG_2(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurve3d_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

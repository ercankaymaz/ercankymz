using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCurveSurfInt : OdGeEntity3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCurveSurfInt(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCurveSurfInt obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCurveSurfInt(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeCurveSurfInt copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_copy(swigCPtr);
		OdGeCurveSurfInt result = ((intPtr == IntPtr.Zero) ? null : new OdGeCurveSurfInt(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveSurfInt transformBy(OdGeMatrix3d xfm)
	{
		OdGeCurveSurfInt result = new OdGeCurveSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveSurfInt translateBy(OdGeVector3d translateVec)
	{
		OdGeCurveSurfInt result = new OdGeCurveSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveSurfInt rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeCurveSurfInt result = new OdGeCurveSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveSurfInt rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeCurveSurfInt result = new OdGeCurveSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveSurfInt mirror(OdGePlane plane)
	{
		OdGeCurveSurfInt result = new OdGeCurveSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveSurfInt scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeCurveSurfInt result = new OdGeCurveSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCurveSurfInt scaleBy(double scaleFactor)
	{
		OdGeCurveSurfInt result = new OdGeCurveSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveSurfInt()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveSurfInt__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveSurfInt(OdGeCurve3d curve, OdGeSurface surf, OdGeTol tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveSurfInt__SWIG_1(OdGeCurve3d.getCPtr(curve), OdGeSurface.getCPtr(surf), OdGeTol.getCPtr(tol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveSurfInt(OdGeCurve3d curve, OdGeSurface surf)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveSurfInt__SWIG_2(OdGeCurve3d.getCPtr(curve), OdGeSurface.getCPtr(surf)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveSurfInt(OdGeCurveSurfInt source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveSurfInt__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve3d curve()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_curve(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSurface surface()
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_surface(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTol tolerance()
	{
		OdGeTol result = new OdGeTol(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_tolerance(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numResults(ref OdGe_OdGeIntersectError status)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_numResults(swigCPtr, ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getDimension(int intNum, ref OdGe_OdGeIntersectError status)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_getDimension(swigCPtr, intNum, ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numIntPoints(ref OdGe_OdGeIntersectError status)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_numIntPoints(swigCPtr, ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d intPoint(int intNum, ref OdGe_OdGeIntersectError status)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_intPoint(swigCPtr, intNum, ref status), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getIntParams(int intNum, out double param1, OdGePoint2d param2, ref OdGe_OdGeIntersectError status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_getIntParams(swigCPtr, intNum, out param1, OdGePoint2d.getCPtr(param2), ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPointOnCurve(int intNum, OdGePointOnCurve3d intPnt, ref OdGe_OdGeIntersectError status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_getPointOnCurve(swigCPtr, intNum, OdGePointOnCurve3d.getCPtr(intPnt), ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPointOnSurface(int intNum, OdGePointOnSurface intPnt, ref OdGe_OdGeIntersectError status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_getPointOnSurface(swigCPtr, intNum, OdGePointOnSurface.getCPtr(intPnt), ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getIntConfigs(int intNum, ref OdGe_csiConfig lower, ref OdGe_csiConfig higher, out bool smallAngle, ref OdGe_OdGeIntersectError status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_getIntConfigs(swigCPtr, intNum, ref lower, ref higher, out smallAngle, ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int overlapCount(ref OdGe_OdGeIntersectError status)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_overlapCount(swigCPtr, ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getOverlapRange(int intNum, OdGeInterval range, ref OdGe_OdGeIntersectError status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_getOverlapRange(swigCPtr, intNum, OdGeInterval.getCPtr(range), ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve2d intParamCurve(int intNum, bool isExternal, ref OdGe_OdGeIntersectError status)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_intParamCurve(swigCPtr, intNum, isExternal, ref status), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveSurfInt set(OdGeCurve3d crv, OdGeSurface surface, OdGeTol tol)
	{
		OdGeCurveSurfInt result = new OdGeCurveSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_set__SWIG_0(swigCPtr, OdGeCurve3d.getCPtr(crv), OdGeSurface.getCPtr(surface), OdGeTol.getCPtr(tol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveSurfInt set(OdGeCurve3d crv, OdGeSurface surface)
	{
		OdGeCurveSurfInt result = new OdGeCurveSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_set__SWIG_1(swigCPtr, OdGeCurve3d.getCPtr(crv), OdGeSurface.getCPtr(surface)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveSurfInt Assign(OdGeCurveSurfInt crvSurfInt)
	{
		OdGeCurveSurfInt result = new OdGeCurveSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveSurfInt_Assign(swigCPtr, getCPtr(crvSurfInt)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

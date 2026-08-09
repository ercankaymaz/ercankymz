using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeSurface : OdGeEntity3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeSurface(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeSurface obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeSurface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeSurface copy()
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_copy(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurface transformBy(OdGeMatrix3d xfm)
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurface translateBy(OdGeVector3d translateVec)
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurface rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurface rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurface mirror(OdGePlane plane)
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_mirror(swigCPtr, OdGePlane.getCPtr(plane)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurface scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurface scaleBy(double scaleFactor)
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_scaleBy__SWIG_1(swigCPtr, scaleFactor), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d paramOf(OdGePoint3d point, OdGeTol tol)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_paramOf__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d paramOf(OdGePoint3d point)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_paramOf__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d paramOf(OdGePoint3d point, OdGeUvBox uvBox, OdGeTol tol)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_paramOf__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(point), OdGeUvBox.getCPtr(uvBox), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d paramOf(OdGePoint3d point, OdGeUvBox uvBox)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_paramOf__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(point), OdGeUvBox.getCPtr(uvBox)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(OdGePoint3d point, OdGePoint2d paramPoint, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_isOn__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGePoint2d.getCPtr(paramPoint), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(OdGePoint3d point, OdGePoint2d paramPoint)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_isOn__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), OdGePoint2d.getCPtr(paramPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointTo(OdGePoint3d point, OdGeTol tol)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_closestPointTo__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointTo(OdGePoint3d point)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_closestPointTo__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointTo(OdGePoint3d point, OdGePoint2d param, OdGeUvBox uvBox, OdGeTol tol)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_closestPointTo__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(point), OdGePoint2d.getCPtr(param), OdGeUvBox.getCPtr(uvBox), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d closestPointTo(OdGePoint3d point, OdGePoint2d param, OdGeUvBox uvBox)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_closestPointTo__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(point), OdGePoint2d.getCPtr(param), OdGeUvBox.getCPtr(uvBox)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getClosestPointTo(OdGePoint3d point, OdGePointOnSurface pntOnSurface, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_getClosestPointTo__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGePointOnSurface.getCPtr(pntOnSurface), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getClosestPointTo(OdGePoint3d point, OdGePointOnSurface pntOnSurface)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_getClosestPointTo__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), OdGePointOnSurface.getCPtr(pntOnSurface));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double distanceTo(OdGePoint3d point, OdGeTol tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_distanceTo__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGePoint3d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_distanceTo__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isNormalReversed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_isNormalReversed(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLeftHanded()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_isLeftHanded(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSurface reverseNormal()
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_reverseNormal(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getEnvelope(OdGeInterval intrvlU, OdGeInterval intrvlV)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_getEnvelope__SWIG_0(swigCPtr, OdGeInterval.getCPtr(intrvlU), OdGeInterval.getCPtr(intrvlV));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getEnvelope(OdGeUvBox uvbox)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_getEnvelope__SWIG_1(swigCPtr, OdGeUvBox.getCPtr(uvbox));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isClosedInU(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_isClosedInU__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosedInU()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_isClosedInU__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosedInV(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_isClosedInV__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosedInV()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_isClosedInV__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d evalPoint(OdGePoint2d param)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_evalPoint__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d evalPoint(OdGePoint2d param, int numDeriv, OdGeVector3dArray derivatives)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_evalPoint__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(param), numDeriv, OdGeVector3dArray.getCPtr(derivatives)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d evalPoint(OdGePoint2d param, int numDeriv, OdGeVector3dArray derivatives, OdGeVector3d normal)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_evalPoint__SWIG_2(swigCPtr, OdGePoint2d.getCPtr(param), numDeriv, OdGeVector3dArray.getCPtr(derivatives), OdGeVector3d.getCPtr(normal)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSurface Assign(OdGeSurface surf)
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_Assign(swigCPtr, getCPtr(surf)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d getGeomExtents(OdGeUvBox range, OdGeMatrix3d coordSystem)
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_getGeomExtents__SWIG_0(swigCPtr, OdGeUvBox.getCPtr(range), OdGeMatrix3d.getCPtr(coordSystem)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d getGeomExtents(OdGeUvBox range)
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_getGeomExtents__SWIG_1(swigCPtr, OdGeUvBox.getCPtr(range)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d getGeomExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_getGeomExtents__SWIG_2(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool project(OdGePoint3d p, OdGePoint3d projP, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_project__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(p), OdGePoint3d.getCPtr(projP), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool project(OdGePoint3d p, OdGePoint3d projP)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_project__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(p), OdGePoint3d.getCPtr(projP));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setEnvelope(OdGeInterval realIntrvlU, OdGeInterval realIntrvlV)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_setEnvelope(swigCPtr, OdGeInterval.getCPtr(realIntrvlU), OdGeInterval.getCPtr(realIntrvlV));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve3d makeIsoparamCurve(bool byU, double param)
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_makeIsoparamCurve__SWIG_0(swigCPtr, byU, param), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve3d makeIsoparamCurve(bool byU, double param, OdGeInterval interval)
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_makeIsoparamCurve__SWIG_1(swigCPtr, byU, param, OdGeInterval.getCPtr(interval)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getPoles(OdDoubleArray uParams, OdDoubleArray vParams, OdGePoint3dArray uPoints, OdGePoint3dArray vPoints, double tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_getPoles__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(uParams).Handle, OdDoubleArray.getCPtr(vParams).Handle, OdGePoint3dArray.getCPtr(uPoints), OdGePoint3dArray.getCPtr(vPoints), tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getPoles(OdDoubleArray uParams, OdDoubleArray vParams, OdGePoint3dArray uPoints, OdGePoint3dArray vPoints)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_getPoles__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(uParams).Handle, OdDoubleArray.getCPtr(vParams).Handle, OdGePoint3dArray.getCPtr(uPoints), OdGePoint3dArray.getCPtr(vPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurface_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

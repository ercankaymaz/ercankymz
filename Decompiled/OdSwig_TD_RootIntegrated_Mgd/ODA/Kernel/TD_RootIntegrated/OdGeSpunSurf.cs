using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeSpunSurf : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeSpunSurf(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeSpunSurf obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeSpunSurf(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeSpunSurf copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_copy(swigCPtr);
		OdGeSpunSurf result = ((intPtr == IntPtr.Zero) ? null : new OdGeSpunSurf(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSpunSurf transformBy(OdGeMatrix3d xfm)
	{
		OdGeSpunSurf result = new OdGeSpunSurf(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSpunSurf translateBy(OdGeVector3d translateVec)
	{
		OdGeSpunSurf result = new OdGeSpunSurf(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSpunSurf rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeSpunSurf result = new OdGeSpunSurf(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSpunSurf rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeSpunSurf result = new OdGeSpunSurf(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSpunSurf mirror(OdGePlane plane)
	{
		OdGeSpunSurf result = new OdGeSpunSurf(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSpunSurf scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeSpunSurf result = new OdGeSpunSurf(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSpunSurf scaleBy(double scaleFactor)
	{
		OdGeSpunSurf result = new OdGeSpunSurf(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSpunSurf()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSpunSurf__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSpunSurf(OdGeCurve3d pProfile, OdGePoint3d pBase, OdGeVector3d pAxis)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSpunSurf__SWIG_1(OdGeCurve3d.getCPtr(pProfile), OdGePoint3d.getCPtr(pBase), OdGeVector3d.getCPtr(pAxis)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSpunSurf(OdGeSpunSurf spunSurf)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSpunSurf__SWIG_2(getCPtr(spunSurf)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSpunSurf Assign(OdGeSpunSurf spunSurface)
	{
		OdGeSpunSurf result = new OdGeSpunSurf(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_Assign(swigCPtr, getCPtr(spunSurface)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve3d getProfile()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_getProfile(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d getBasePoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_getBasePoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d getAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_getAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d getRef()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_getRef(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSpunSurf setAngles(double startAngle, double endAngle)
	{
		OdGeSpunSurf result = new OdGeSpunSurf(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_setAngles(swigCPtr, startAngle, endAngle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSpunSurf setRef(OdGeVector3d pRef)
	{
		OdGeSpunSurf result = new OdGeSpunSurf(TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_setRef(swigCPtr, OdGeVector3d.getCPtr(pRef)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set(OdGeCurve3d pProfile, OdGePoint3d pBase, OdGeVector3d pAxis)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeSpunSurf_set(swigCPtr, OdGeCurve3d.getCPtr(pProfile), OdGePoint3d.getCPtr(pBase), OdGeVector3d.getCPtr(pAxis));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

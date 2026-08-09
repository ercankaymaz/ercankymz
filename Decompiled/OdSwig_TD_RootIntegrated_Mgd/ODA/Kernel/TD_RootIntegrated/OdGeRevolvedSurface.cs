using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeRevolvedSurface : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeRevolvedSurface(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeRevolvedSurface obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeRevolvedSurface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeRevolvedSurface copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_copy(swigCPtr);
		OdGeRevolvedSurface result = ((intPtr == IntPtr.Zero) ? null : new OdGeRevolvedSurface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRevolvedSurface transformBy(OdGeMatrix3d xfm)
	{
		OdGeRevolvedSurface result = new OdGeRevolvedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRevolvedSurface translateBy(OdGeVector3d translateVec)
	{
		OdGeRevolvedSurface result = new OdGeRevolvedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRevolvedSurface rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeRevolvedSurface result = new OdGeRevolvedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRevolvedSurface rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeRevolvedSurface result = new OdGeRevolvedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRevolvedSurface mirror(OdGePlane plane)
	{
		OdGeRevolvedSurface result = new OdGeRevolvedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRevolvedSurface scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeRevolvedSurface result = new OdGeRevolvedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRevolvedSurface scaleBy(double scaleFactor)
	{
		OdGeRevolvedSurface result = new OdGeRevolvedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeRevolvedSurface()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRevolvedSurface__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRevolvedSurface(OdGeCurve3d pProfile, OdGePoint3d pBase, OdGeVector3d pAxis, OdGeVector3d pRef, double startAngle, double endAngle)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRevolvedSurface__SWIG_1(OdGeCurve3d.getCPtr(pProfile), OdGePoint3d.getCPtr(pBase), OdGeVector3d.getCPtr(pAxis), OdGeVector3d.getCPtr(pRef), startAngle, endAngle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRevolvedSurface(OdGeCurve3d pProfile, OdGePoint3d pBase, OdGeVector3d pAxis, OdGeVector3d pRef, double startAngle)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRevolvedSurface__SWIG_2(OdGeCurve3d.getCPtr(pProfile), OdGePoint3d.getCPtr(pBase), OdGeVector3d.getCPtr(pAxis), OdGeVector3d.getCPtr(pRef), startAngle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRevolvedSurface(OdGeCurve3d pProfile, OdGePoint3d pBase, OdGeVector3d pAxis, OdGeVector3d pRef)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRevolvedSurface__SWIG_3(OdGeCurve3d.getCPtr(pProfile), OdGePoint3d.getCPtr(pBase), OdGeVector3d.getCPtr(pAxis), OdGeVector3d.getCPtr(pRef)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRevolvedSurface(OdGeRevolvedSurface revolvedSurf)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRevolvedSurface__SWIG_4(getCPtr(revolvedSurf)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRevolvedSurface Assign(OdGeRevolvedSurface revolvedSurf)
	{
		OdGeRevolvedSurface result = new OdGeRevolvedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_Assign(swigCPtr, getCPtr(revolvedSurf)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve3d getProfile()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_getProfile(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d getBasePoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_getBasePoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d getAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_getAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d getRef()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_getRef(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getAngles(out double startAngle, out double endAngle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_getAngles(swigCPtr, out startAngle, out endAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRevolvedSurface setAngles(double startAngle, double endAngle)
	{
		OdGeRevolvedSurface result = new OdGeRevolvedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_setAngles(swigCPtr, startAngle, endAngle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeRevolvedSurface setRef(OdGeVector3d pRef)
	{
		OdGeRevolvedSurface result = new OdGeRevolvedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_setRef(swigCPtr, OdGeVector3d.getCPtr(pRef)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set(OdGeCurve3d pProfile, OdGePoint3d pBase, OdGeVector3d pAxis, OdGeVector3d pRef)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeRevolvedSurface_set(swigCPtr, OdGeCurve3d.getCPtr(pProfile), OdGePoint3d.getCPtr(pBase), OdGeVector3d.getCPtr(pAxis), OdGeVector3d.getCPtr(pRef));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

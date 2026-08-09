using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeSurfaceCurve2dTo3d : OdGeCurve3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeSurfaceCurve2dTo3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeSurfaceCurve2dTo3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeSurfaceCurve2dTo3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeSurfaceCurve2dTo3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_copy(swigCPtr);
		OdGeSurfaceCurve2dTo3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeSurfaceCurve2dTo3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfaceCurve2dTo3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeSurfaceCurve2dTo3d result = new OdGeSurfaceCurve2dTo3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfaceCurve2dTo3d translateBy(OdGeVector3d translateVec)
	{
		OdGeSurfaceCurve2dTo3d result = new OdGeSurfaceCurve2dTo3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfaceCurve2dTo3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeSurfaceCurve2dTo3d result = new OdGeSurfaceCurve2dTo3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfaceCurve2dTo3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeSurfaceCurve2dTo3d result = new OdGeSurfaceCurve2dTo3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfaceCurve2dTo3d mirror(OdGePlane plane)
	{
		OdGeSurfaceCurve2dTo3d result = new OdGeSurfaceCurve2dTo3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfaceCurve2dTo3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeSurfaceCurve2dTo3d result = new OdGeSurfaceCurve2dTo3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfaceCurve2dTo3d scaleBy(double scaleFactor)
	{
		OdGeSurfaceCurve2dTo3d result = new OdGeSurfaceCurve2dTo3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSurfaceCurve2dTo3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSurfaceCurve2dTo3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSurfaceCurve2dTo3d(OdGeSurfaceCurve2dTo3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSurfaceCurve2dTo3d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSurfaceCurve2dTo3d(OdGeCurve2d uvc, OdGeSurface surf)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSurfaceCurve2dTo3d__SWIG_2(OdGeCurve2d.getCPtr(uvc), OdGeSurface.getCPtr(surf)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSurfaceCurve2dTo3d(OdGeCurve2d pUvCurve, OdGeSurface pSurface, OdGeSurfaceCurve2dTo3d_OwnershipFlag ownership)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSurfaceCurve2dTo3d__SWIG_3(OdGeCurve2d.getCPtr(pUvCurve), OdGeSurface.getCPtr(pSurface), (int)ownership), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSurfaceCurve2dTo3d Assign(OdGeSurfaceCurve2dTo3d src)
	{
		OdGeSurfaceCurve2dTo3d result = new OdGeSurfaceCurve2dTo3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_Assign(swigCPtr, getCPtr(src)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve2d curve()
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_curve(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSurface surface()
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_surface(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getGeomExtents(OdGeExtents3d extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfaceCurve2dTo3d_getGeomExtents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

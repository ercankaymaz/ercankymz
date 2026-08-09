using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeExternalBoundedSurface : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeExternalBoundedSurface(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeExternalBoundedSurface obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeExternalBoundedSurface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public void getContours(out int numContours, out OdGeCurveBoundary[] contours)
	{
		IntPtr jarg = default(IntPtr);
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_getContours(swigCPtr, out numContours, out jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		if (numContours == 0)
		{
			contours = null;
			return;
		}
		contours = new OdGeCurveBoundary[numContours];
		for (int i = 0; i < numContours; i++)
		{
			contours[i] = new OdGeCurveBoundary(Marshal.ReadIntPtr(jarg, i * Marshal.SizeOf(Marshal.SizeOf(typeof(IntPtr)))), cMemoryOwn: false);
		}
	}

	public new OdGeExternalBoundedSurface copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_copy(swigCPtr);
		OdGeExternalBoundedSurface result = ((intPtr == IntPtr.Zero) ? null : new OdGeExternalBoundedSurface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalBoundedSurface transformBy(OdGeMatrix3d xfm)
	{
		OdGeExternalBoundedSurface result = new OdGeExternalBoundedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalBoundedSurface translateBy(OdGeVector3d translateVec)
	{
		OdGeExternalBoundedSurface result = new OdGeExternalBoundedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalBoundedSurface rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeExternalBoundedSurface result = new OdGeExternalBoundedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalBoundedSurface rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeExternalBoundedSurface result = new OdGeExternalBoundedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalBoundedSurface mirror(OdGePlane plane)
	{
		OdGeExternalBoundedSurface result = new OdGeExternalBoundedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalBoundedSurface scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeExternalBoundedSurface result = new OdGeExternalBoundedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalBoundedSurface scaleBy(double scaleFactor)
	{
		OdGeExternalBoundedSurface result = new OdGeExternalBoundedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalBoundedSurface()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalBoundedSurface__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExternalBoundedSurface(IntPtr pSurfaceDef, OdGe_ExternalEntityKind surfaceKind, bool makeCopy)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalBoundedSurface__SWIG_1(pSurfaceDef, (int)surfaceKind, makeCopy), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExternalBoundedSurface(IntPtr pSurfaceDef, OdGe_ExternalEntityKind surfaceKind)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalBoundedSurface__SWIG_2(pSurfaceDef, (int)surfaceKind), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExternalBoundedSurface(OdGeExternalBoundedSurface source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalBoundedSurface__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGe_ExternalEntityKind externalSurfaceKind()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_externalSurfaceKind(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ExternalEntityKind)result;
	}

	public bool isDefined()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_isDefined(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getExternalSurface(out IntPtr pSurfaceDef)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_getExternalSurface(swigCPtr, out pSurfaceDef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isPlane()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_isPlane(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSphere()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_isSphere(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCylinder()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_isCylinder(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCone()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_isCone(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEllipCylinder()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_isEllipCylinder(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEllipCone()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_isEllipCone(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTorus()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_isTorus(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isNurbs()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_isNurbs(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isExternalSurface()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_isExternalSurface(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numContours()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_numContours(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalBoundedSurface set(IntPtr pSurfaceDef, OdGe_ExternalEntityKind surfaceKind, bool makeCopy)
	{
		OdGeExternalBoundedSurface result = new OdGeExternalBoundedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_set__SWIG_0(swigCPtr, pSurfaceDef, (int)surfaceKind, makeCopy), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalBoundedSurface set(IntPtr pSurfaceDef, OdGe_ExternalEntityKind surfaceKind)
	{
		OdGeExternalBoundedSurface result = new OdGeExternalBoundedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_set__SWIG_1(swigCPtr, pSurfaceDef, (int)surfaceKind), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOwnerOfSurface()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_isOwnerOfSurface(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalBoundedSurface setToOwnSurface()
	{
		OdGeExternalBoundedSurface result = new OdGeExternalBoundedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_setToOwnSurface(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalBoundedSurface Assign(OdGeExternalBoundedSurface extBoundSurf)
	{
		OdGeExternalBoundedSurface result = new OdGeExternalBoundedSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_Assign(swigCPtr, getCPtr(extBoundSurf)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSurface getBaseSurfaceEx()
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalBoundedSurface_getBaseSurfaceEx(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

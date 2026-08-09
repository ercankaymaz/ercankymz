using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeExternalSurface : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeExternalSurface(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeExternalSurface obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeExternalSurface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeExternalSurface copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_copy(swigCPtr);
		OdGeExternalSurface result = ((intPtr == IntPtr.Zero) ? null : new OdGeExternalSurface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalSurface transformBy(OdGeMatrix3d xfm)
	{
		OdGeExternalSurface result = new OdGeExternalSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalSurface translateBy(OdGeVector3d translateVec)
	{
		OdGeExternalSurface result = new OdGeExternalSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalSurface rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeExternalSurface result = new OdGeExternalSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalSurface rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeExternalSurface result = new OdGeExternalSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalSurface mirror(OdGePlane plane)
	{
		OdGeExternalSurface result = new OdGeExternalSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalSurface scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeExternalSurface result = new OdGeExternalSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalSurface scaleBy(double scaleFactor)
	{
		OdGeExternalSurface result = new OdGeExternalSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalSurface()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalSurface__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExternalSurface(IntPtr pSurfaceDef, OdGe_ExternalEntityKind surfaceKind, bool makeCopy)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalSurface__SWIG_1(pSurfaceDef, (int)surfaceKind, makeCopy), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExternalSurface(IntPtr pSurfaceDef, OdGe_ExternalEntityKind surfaceKind)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalSurface__SWIG_2(pSurfaceDef, (int)surfaceKind), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExternalSurface(OdGeExternalSurface source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalSurface__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getExternalSurface(out IntPtr pSurfaceDef)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_getExternalSurface(swigCPtr, out pSurfaceDef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGe_ExternalEntityKind externalSurfaceKind()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_externalSurfaceKind(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ExternalEntityKind)result;
	}

	public bool isPlane()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_isPlane(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSphere()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_isSphere(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCylinder()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_isCylinder(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCone()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_isCone(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEllipCylinder()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_isEllipCylinder(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEllipCone()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_isEllipCone(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTorus()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_isTorus(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isNurbSurface()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_isNurbSurface(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDefined()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_isDefined(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isNativeSurface(out OdGeSurface nativeSurface)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_isNativeSurface(swigCPtr, out jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeSurface>(typeof(OdGeSurface), jarg, bIsWrapperOwnNativeObject: true));
			nativeSurface = Helpers.odCreateObjectInternal<OdGeSurface>(typeof(OdGeSurface), jarg, currentTransaction == null);
		}
	}

	public OdGeExternalSurface Assign(OdGeExternalSurface extSurf)
	{
		OdGeExternalSurface result = new OdGeExternalSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_Assign(swigCPtr, getCPtr(extSurf)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalSurface set(IntPtr pSurfaceDef, OdGe_ExternalEntityKind surfaceKind, bool makeCopy)
	{
		OdGeExternalSurface result = new OdGeExternalSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_set__SWIG_0(swigCPtr, pSurfaceDef, (int)surfaceKind, makeCopy), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalSurface set(IntPtr pSurfaceDef, OdGe_ExternalEntityKind surfaceKind)
	{
		OdGeExternalSurface result = new OdGeExternalSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_set__SWIG_1(swigCPtr, pSurfaceDef, (int)surfaceKind), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOwnerOfSurface()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_isOwnerOfSurface(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalSurface setToOwnSurface()
	{
		OdGeExternalSurface result = new OdGeExternalSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalSurface_setToOwnSurface(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

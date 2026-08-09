using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGePointOnSurface : OdGePointEnt3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGePointOnSurface(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGePointOnSurface obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGePointOnSurface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGePointOnSurface copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_copy(swigCPtr);
		OdGePointOnSurface result = ((intPtr == IntPtr.Zero) ? null : new OdGePointOnSurface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnSurface transformBy(OdGeMatrix3d xfm)
	{
		OdGePointOnSurface result = new OdGePointOnSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnSurface translateBy(OdGeVector3d translateVec)
	{
		OdGePointOnSurface result = new OdGePointOnSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnSurface rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGePointOnSurface result = new OdGePointOnSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnSurface rotateBy(double angle, OdGeVector3d vect)
	{
		OdGePointOnSurface result = new OdGePointOnSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnSurface mirror(OdGePlane plane)
	{
		OdGePointOnSurface result = new OdGePointOnSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnSurface scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGePointOnSurface result = new OdGePointOnSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointOnSurface scaleBy(double scaleFactor)
	{
		OdGePointOnSurface result = new OdGePointOnSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePointOnSurface()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePointOnSurface__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePointOnSurface(OdGePointOnSurface source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePointOnSurface__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePointOnSurface(OdGeSurface surface)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePointOnSurface__SWIG_2(OdGeSurface.getCPtr(surface)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePointOnSurface(OdGeSurface surface, OdGePoint2d param)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePointOnSurface__SWIG_3(OdGeSurface.getCPtr(surface), OdGePoint2d.getCPtr(param)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePointOnSurface Assign(OdGePointOnSurface pntOnSurface)
	{
		OdGePointOnSurface result = new OdGePointOnSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_Assign(swigCPtr, getCPtr(pntOnSurface)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSurface surface()
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_surface(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d parameter()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_parameter(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d point()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_point__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d point(OdGePoint2d param)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_point__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d point(OdGeSurface surface, OdGePoint2d param)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_point__SWIG_2(swigCPtr, OdGeSurface.getCPtr(surface), OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d normal()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_normal__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d normal(OdGePoint2d param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_normal__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d normal(OdGeSurface surface, OdGePoint2d param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_normal__SWIG_2(swigCPtr, OdGeSurface.getCPtr(surface), OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d uDeriv(int order)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_uDeriv__SWIG_0(swigCPtr, order), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d uDeriv(int order, OdGePoint2d param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_uDeriv__SWIG_1(swigCPtr, order, OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d uDeriv(int order, OdGeSurface surface, OdGePoint2d param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_uDeriv__SWIG_2(swigCPtr, order, OdGeSurface.getCPtr(surface), OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d vDeriv(int order)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_vDeriv__SWIG_0(swigCPtr, order), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d vDeriv(int order, OdGePoint2d param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_vDeriv__SWIG_1(swigCPtr, order, OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d vDeriv(int order, OdGeSurface surface, OdGePoint2d param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_vDeriv__SWIG_2(swigCPtr, order, OdGeSurface.getCPtr(surface), OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d mixedPartial()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_mixedPartial__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d mixedPartial(OdGePoint2d param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_mixedPartial__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d mixedPartial(OdGeSurface surface, OdGePoint2d param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_mixedPartial__SWIG_2(swigCPtr, OdGeSurface.getCPtr(surface), OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d tangentVector(OdGeVector2d vect)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_tangentVector__SWIG_0(swigCPtr, OdGeVector2d.getCPtr(vect).Handle), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d tangentVector(OdGeVector2d vect, OdGePoint2d param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_tangentVector__SWIG_1(swigCPtr, OdGeVector2d.getCPtr(vect).Handle, OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d tangentVector(OdGeVector2d vect, OdGeSurface surface, OdGePoint2d param)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_tangentVector__SWIG_2(swigCPtr, OdGeVector2d.getCPtr(vect).Handle, OdGeSurface.getCPtr(surface), OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d inverseTangentVector(OdGeVector3d vect)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_inverseTangentVector__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(vect)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d inverseTangentVector(OdGeVector3d vect, OdGePoint2d param)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_inverseTangentVector__SWIG_1(swigCPtr, OdGeVector3d.getCPtr(vect), OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d inverseTangentVector(OdGeVector3d vect, OdGeSurface surface, OdGePoint2d param)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_inverseTangentVector__SWIG_2(swigCPtr, OdGeVector3d.getCPtr(vect), OdGeSurface.getCPtr(surface), OdGePoint2d.getCPtr(param)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePointOnSurface setSurface(OdGeSurface surface)
	{
		OdGePointOnSurface result = new OdGePointOnSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_setSurface(swigCPtr, OdGeSurface.getCPtr(surface)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePointOnSurface setParameter(OdGePoint2d param)
	{
		OdGePointOnSurface result = new OdGePointOnSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGePointOnSurface_setParameter(swigCPtr, OdGePoint2d.getCPtr(param)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

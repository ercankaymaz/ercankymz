using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGePointEnt3d : OdGeEntity3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGePointEnt3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGePointEnt3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGePointEnt3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGePointEnt3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGePointEnt3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePointEnt3d_copy(swigCPtr);
		OdGePointEnt3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePointEnt3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointEnt3d transformBy(OdGeMatrix3d xfm)
	{
		OdGePointEnt3d result = new OdGePointEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointEnt3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointEnt3d translateBy(OdGeVector3d translateVec)
	{
		OdGePointEnt3d result = new OdGePointEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointEnt3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointEnt3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGePointEnt3d result = new OdGePointEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointEnt3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointEnt3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGePointEnt3d result = new OdGePointEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointEnt3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointEnt3d mirror(OdGePlane plane)
	{
		OdGePointEnt3d result = new OdGePointEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointEnt3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointEnt3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGePointEnt3d result = new OdGePointEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointEnt3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePointEnt3d scaleBy(double scaleFactor)
	{
		OdGePointEnt3d result = new OdGePointEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointEnt3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d point3d()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointEnt3d_point3d(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePointEnt3d Assign(OdGePointEnt3d ent)
	{
		OdGePointEnt3d result = new OdGePointEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePointEnt3d_Assign(swigCPtr, getCPtr(ent)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGePosition3d : OdGePointEnt3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGePosition3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGePosition3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGePosition3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGePosition3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePosition3d_copy(swigCPtr);
		OdGePosition3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePosition3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition3d transformBy(OdGeMatrix3d xfm)
	{
		OdGePosition3d result = new OdGePosition3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition3d translateBy(OdGeVector3d translateVec)
	{
		OdGePosition3d result = new OdGePosition3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGePosition3d result = new OdGePosition3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGePosition3d result = new OdGePosition3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition3d mirror(OdGePlane plane)
	{
		OdGePosition3d result = new OdGePosition3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGePosition3d result = new OdGePosition3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition3d scaleBy(double scaleFactor)
	{
		OdGePosition3d result = new OdGePosition3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePosition3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePosition3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePosition3d(OdGePoint3d point)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePosition3d__SWIG_1(OdGePoint3d.getCPtr(point)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePosition3d(double x, double y, double z)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePosition3d__SWIG_2(x, y, z), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePosition3d(OdGePosition3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePosition3d__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePosition3d set(OdGePoint3d point)
	{
		OdGePosition3d result = new OdGePosition3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition3d_set__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePosition3d set(double x, double y, double z)
	{
		OdGePosition3d result = new OdGePosition3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition3d_set__SWIG_1(swigCPtr, x, y, z), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePosition3d Assign(OdGePosition3d pos)
	{
		OdGePosition3d result = new OdGePosition3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition3d_Assign(swigCPtr, getCPtr(pos)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

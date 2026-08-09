using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeRay3d : OdGeLinearEnt3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeRay3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeRay3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeRay3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeRay3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeRay3d_copy(swigCPtr);
		OdGeRay3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeRay3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeRay3d result = new OdGeRay3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay3d translateBy(OdGeVector3d translateVec)
	{
		OdGeRay3d result = new OdGeRay3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeRay3d result = new OdGeRay3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeRay3d result = new OdGeRay3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay3d mirror(OdGePlane plane)
	{
		OdGeRay3d result = new OdGeRay3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeRay3d result = new OdGeRay3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay3d scaleBy(double scaleFactor)
	{
		OdGeRay3d result = new OdGeRay3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeRay3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRay3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRay3d(OdGeRay3d line)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRay3d__SWIG_1(getCPtr(line)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRay3d(OdGePoint3d point, OdGeVector3d vect)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRay3d__SWIG_2(OdGePoint3d.getCPtr(point), OdGeVector3d.getCPtr(vect)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRay3d(OdGePoint3d point1, OdGePoint3d point2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRay3d__SWIG_3(OdGePoint3d.getCPtr(point1), OdGePoint3d.getCPtr(point2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRay3d set(OdGePoint3d point, OdGeVector3d vect)
	{
		OdGeRay3d result = new OdGeRay3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay3d_set__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeRay3d set(OdGePoint3d point1, OdGePoint3d point2)
	{
		OdGeRay3d result = new OdGeRay3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay3d_set__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point1), OdGePoint3d.getCPtr(point2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeRay3d Assign(OdGeRay3d line)
	{
		OdGeRay3d result = new OdGeRay3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay3d_Assign(swigCPtr, getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeRay2d : OdGeLinearEnt2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeRay2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeRay2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeRay2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeRay2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeRay2d_copy(swigCPtr);
		OdGeRay2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeRay2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeRay2d result = new OdGeRay2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay2d translateBy(OdGeVector2d translateVec)
	{
		OdGeRay2d result = new OdGeRay2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeRay2d result = new OdGeRay2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay2d rotateBy(double angle)
	{
		OdGeRay2d result = new OdGeRay2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay2d mirror(OdGeLine2d line)
	{
		OdGeRay2d result = new OdGeRay2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeRay2d result = new OdGeRay2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRay2d scaleBy(double scaleFactor)
	{
		OdGeRay2d result = new OdGeRay2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeRay2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRay2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRay2d(OdGeRay2d ray)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRay2d__SWIG_1(getCPtr(ray)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRay2d(OdGePoint2d point, OdGeVector2d vect)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRay2d__SWIG_2(OdGePoint2d.getCPtr(point), OdGeVector2d.getCPtr(vect).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRay2d(OdGePoint2d point1, OdGePoint2d point2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRay2d__SWIG_3(OdGePoint2d.getCPtr(point1), OdGePoint2d.getCPtr(point2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRay2d set(OdGePoint2d point, OdGeVector2d vect)
	{
		OdGeRay2d result = new OdGeRay2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay2d_set__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGeVector2d.getCPtr(vect).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeRay2d set(OdGePoint2d point1, OdGePoint2d point2)
	{
		OdGeRay2d result = new OdGeRay2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay2d_set__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point1), OdGePoint2d.getCPtr(point2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeRay2d Assign(OdGeRay2d ray)
	{
		OdGeRay2d result = new OdGeRay2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeRay2d_Assign(swigCPtr, getCPtr(ray)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

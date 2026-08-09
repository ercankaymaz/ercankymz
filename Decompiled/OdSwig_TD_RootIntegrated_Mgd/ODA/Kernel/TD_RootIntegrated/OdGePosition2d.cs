using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGePosition2d : OdGePointEnt2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGePosition2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGePosition2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGePosition2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGePosition2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePosition2d_copy(swigCPtr);
		OdGePosition2d result = ((intPtr == IntPtr.Zero) ? null : new OdGePosition2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition2d transformBy(OdGeMatrix2d xfm)
	{
		OdGePosition2d result = new OdGePosition2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition2d translateBy(OdGeVector2d translateVec)
	{
		OdGePosition2d result = new OdGePosition2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGePosition2d result = new OdGePosition2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition2d rotateBy(double angle)
	{
		OdGePosition2d result = new OdGePosition2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition2d mirror(OdGeLine2d line)
	{
		OdGePosition2d result = new OdGePosition2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGePosition2d result = new OdGePosition2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePosition2d scaleBy(double scaleFactor)
	{
		OdGePosition2d result = new OdGePosition2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePosition2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePosition2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePosition2d(OdGePoint2d point)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePosition2d__SWIG_1(OdGePoint2d.getCPtr(point)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePosition2d(double x, double y)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePosition2d__SWIG_2(x, y), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePosition2d(OdGePosition2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePosition2d__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePosition2d set(OdGePoint2d point)
	{
		OdGePosition2d result = new OdGePosition2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition2d_set__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePosition2d set(double x, double y)
	{
		OdGePosition2d result = new OdGePosition2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition2d_set__SWIG_1(swigCPtr, x, y), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePosition2d Assign(OdGePosition2d pos)
	{
		OdGePosition2d result = new OdGePosition2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePosition2d_Assign(swigCPtr, getCPtr(pos)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

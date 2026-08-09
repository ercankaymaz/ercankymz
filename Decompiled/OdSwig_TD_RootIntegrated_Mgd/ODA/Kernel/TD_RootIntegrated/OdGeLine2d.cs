using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeLine2d : OdGeLinearEnt2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	public static OdGeLine2d kXAxis
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_kXAxis_get();
			OdGeLine2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeLine2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdGeLine2d kYAxis
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_kYAxis_get();
			OdGeLine2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeLine2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeLine2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeLine2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeLine2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeLine2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_copy(swigCPtr);
		OdGeLine2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeLine2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeLine2d result = new OdGeLine2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine2d translateBy(OdGeVector2d translateVec)
	{
		OdGeLine2d result = new OdGeLine2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeLine2d result = new OdGeLine2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine2d rotateBy(double angle)
	{
		OdGeLine2d result = new OdGeLine2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine2d mirror(OdGeLine2d line)
	{
		OdGeLine2d result = new OdGeLine2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_mirror(swigCPtr, getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeLine2d result = new OdGeLine2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine2d scaleBy(double scaleFactor)
	{
		OdGeLine2d result = new OdGeLine2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLine2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLine2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLine2d(OdGeLine2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLine2d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLine2d(OdGePoint2d point, OdGeVector2d vect)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLine2d__SWIG_2(OdGePoint2d.getCPtr(point), OdGeVector2d.getCPtr(vect).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLine2d(OdGePoint2d point1, OdGePoint2d point2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLine2d__SWIG_3(OdGePoint2d.getCPtr(point1), OdGePoint2d.getCPtr(point2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLine2d set(OdGePoint2d point, OdGeVector2d vect)
	{
		OdGeLine2d result = new OdGeLine2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_set__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGeVector2d.getCPtr(vect).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLine2d set(OdGePoint2d point1, OdGePoint2d point2)
	{
		OdGeLine2d result = new OdGeLine2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_set__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point1), OdGePoint2d.getCPtr(point2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLine2d Assign(OdGeLine2d line)
	{
		OdGeLine2d result = new OdGeLine2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine2d_Assign(swigCPtr, getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

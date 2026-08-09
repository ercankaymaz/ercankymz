using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeLine3d : OdGeLinearEnt3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	public static OdGeLine3d kXAxis
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_kXAxis_get();
			OdGeLine3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeLine3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdGeLine3d kYAxis
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_kYAxis_get();
			OdGeLine3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeLine3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdGeLine3d kZAxis
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_kZAxis_get();
			OdGeLine3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeLine3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeLine3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeLine3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeLine3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeLine3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_copy(swigCPtr);
		OdGeLine3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeLine3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeLine3d result = new OdGeLine3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine3d translateBy(OdGeVector3d translateVec)
	{
		OdGeLine3d result = new OdGeLine3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeLine3d result = new OdGeLine3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeLine3d result = new OdGeLine3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine3d mirror(OdGePlane plane)
	{
		OdGeLine3d result = new OdGeLine3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeLine3d result = new OdGeLine3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLine3d scaleBy(double scaleFactor)
	{
		OdGeLine3d result = new OdGeLine3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLine3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLine3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLine3d(OdGeLine3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLine3d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLine3d(OdGePoint3d point, OdGeVector3d vect)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLine3d__SWIG_2(OdGePoint3d.getCPtr(point), OdGeVector3d.getCPtr(vect)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLine3d(OdGePoint3d point1, OdGePoint3d point2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLine3d__SWIG_3(OdGePoint3d.getCPtr(point1), OdGePoint3d.getCPtr(point2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLine3d set(OdGePoint3d point, OdGeVector3d vect)
	{
		OdGeLine3d result = new OdGeLine3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_set__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLine3d set(OdGePoint3d point1, OdGePoint3d point2)
	{
		OdGeLine3d result = new OdGeLine3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_set__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point1), OdGePoint3d.getCPtr(point2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLine3d Assign(OdGeLine3d line)
	{
		OdGeLine3d result = new OdGeLine3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLine3d_Assign(swigCPtr, getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

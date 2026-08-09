using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGePlane : OdGePlanarEnt
{
	private object locker = new object();

	private HandleRef swigCPtr;

	public static OdGePlane kXYPlane
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_kXYPlane_get();
			OdGePlane result = ((intPtr == IntPtr.Zero) ? null : new OdGePlane(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdGePlane kYZPlane
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_kYZPlane_get();
			OdGePlane result = ((intPtr == IntPtr.Zero) ? null : new OdGePlane(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdGePlane kZXPlane
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_kZXPlane_get();
			OdGePlane result = ((intPtr == IntPtr.Zero) ? null : new OdGePlane(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGePlane(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGePlane obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGePlane(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGePlane copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_copy(swigCPtr);
		OdGePlane result = ((intPtr == IntPtr.Zero) ? null : new OdGePlane(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlane transformBy(OdGeMatrix3d xfm)
	{
		OdGePlane result = new OdGePlane(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlane translateBy(OdGeVector3d translateVec)
	{
		OdGePlane result = new OdGePlane(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlane rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGePlane result = new OdGePlane(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlane rotateBy(double angle, OdGeVector3d vect)
	{
		OdGePlane result = new OdGePlane(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlane mirror(OdGePlane plane)
	{
		OdGePlane result = new OdGePlane(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_mirror(swigCPtr, getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlane scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGePlane result = new OdGePlane(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGePlane scaleBy(double scaleFactor)
	{
		OdGePlane result = new OdGePlane(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePlane()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePlane__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePlane(OdGePlane plane)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePlane__SWIG_1(getCPtr(plane)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePlane(OdGePoint3d origin, OdGeVector3d normal)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePlane__SWIG_2(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(normal)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePlane(OdGePoint3d uPnt, OdGePoint3d origin, OdGePoint3d vPnt)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePlane__SWIG_3(OdGePoint3d.getCPtr(uPnt), OdGePoint3d.getCPtr(origin), OdGePoint3d.getCPtr(vPnt)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePlane(OdGePoint3d origin, OdGeVector3d uAxis, OdGeVector3d vAxis)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePlane__SWIG_4(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uAxis), OdGeVector3d.getCPtr(vAxis)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePlane(double a, double b, double c, double d)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePlane__SWIG_5(a, b, c, d), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool intersectWith(OdGePlane plane, OdGeLine3d intLine, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_intersectWith__SWIG_0(swigCPtr, getCPtr(plane), OdGeLine3d.getCPtr(intLine), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGePlane plane, OdGeLine3d intLine)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_intersectWith__SWIG_1(swigCPtr, getCPtr(plane), OdGeLine3d.getCPtr(intLine));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeBoundedPlane plane, OdGeLineSeg3d intLine, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_intersectWith__SWIG_2(swigCPtr, OdGeBoundedPlane.getCPtr(plane), OdGeLineSeg3d.getCPtr(intLine), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeBoundedPlane plane, OdGeLineSeg3d intLine)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_intersectWith__SWIG_3(swigCPtr, OdGeBoundedPlane.getCPtr(plane), OdGeLineSeg3d.getCPtr(intLine));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double signedDistanceTo(OdGePoint3d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_signedDistanceTo(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePlane set(OdGePoint3d point, OdGeVector3d normal)
	{
		OdGePlane result = new OdGePlane(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_set__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeVector3d.getCPtr(normal)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePlane set(OdGePoint3d uPnt, OdGePoint3d origin, OdGePoint3d vPnt)
	{
		OdGePlane result = new OdGePlane(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_set__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(uPnt), OdGePoint3d.getCPtr(origin), OdGePoint3d.getCPtr(vPnt)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePlane set(double a, double b, double c, double d)
	{
		OdGePlane result = new OdGePlane(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_set__SWIG_2(swigCPtr, a, b, c, d), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePlane set(OdGePoint3d origin, OdGeVector3d uAxis, OdGeVector3d vAxis)
	{
		OdGePlane result = new OdGePlane(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_set__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uAxis), OdGeVector3d.getCPtr(vAxis)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePlane Assign(OdGePlane plane)
	{
		OdGePlane result = new OdGePlane(TD_RootIntegrated_GlobalsPINVOKE.OdGePlane_Assign(swigCPtr, getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

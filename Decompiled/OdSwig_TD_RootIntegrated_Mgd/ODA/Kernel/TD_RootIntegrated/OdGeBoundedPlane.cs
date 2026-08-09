using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeBoundedPlane : OdGePlanarEnt
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeBoundedPlane(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeBoundedPlane obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeBoundedPlane(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeBoundedPlane copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_copy(swigCPtr);
		OdGeBoundedPlane result = ((intPtr == IntPtr.Zero) ? null : new OdGeBoundedPlane(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundedPlane transformBy(OdGeMatrix3d xfm)
	{
		OdGeBoundedPlane result = new OdGeBoundedPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundedPlane translateBy(OdGeVector3d translateVec)
	{
		OdGeBoundedPlane result = new OdGeBoundedPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundedPlane rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeBoundedPlane result = new OdGeBoundedPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundedPlane rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeBoundedPlane result = new OdGeBoundedPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundedPlane mirror(OdGePlane plane)
	{
		OdGeBoundedPlane result = new OdGeBoundedPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundedPlane scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeBoundedPlane result = new OdGeBoundedPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundedPlane scaleBy(double scaleFactor)
	{
		OdGeBoundedPlane result = new OdGeBoundedPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundedPlane()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundedPlane__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundedPlane(OdGeBoundedPlane plane)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundedPlane__SWIG_1(getCPtr(plane)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundedPlane(OdGePoint3d origin, OdGeVector3d uAxis, OdGeVector3d vAxis)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundedPlane__SWIG_2(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uAxis), OdGeVector3d.getCPtr(vAxis)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundedPlane(OdGePoint3d uPnt, OdGePoint3d origin, OdGePoint3d vPnt)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundedPlane__SWIG_3(OdGePoint3d.getCPtr(uPnt), OdGePoint3d.getCPtr(origin), OdGePoint3d.getCPtr(vPnt)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool intersectWith(OdGePlane plane, OdGeLineSeg3d intLine, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_intersectWith__SWIG_0(swigCPtr, OdGePlane.getCPtr(plane), OdGeLineSeg3d.getCPtr(intLine), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGePlane plane, OdGeLineSeg3d intLine)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_intersectWith__SWIG_1(swigCPtr, OdGePlane.getCPtr(plane), OdGeLineSeg3d.getCPtr(intLine));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeBoundedPlane plane, OdGeLineSeg3d intLine, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_intersectWith__SWIG_2(swigCPtr, getCPtr(plane), OdGeLineSeg3d.getCPtr(intLine), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeBoundedPlane plane, OdGeLineSeg3d intLine)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_intersectWith__SWIG_3(swigCPtr, getCPtr(plane), OdGeLineSeg3d.getCPtr(intLine));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundedPlane set(OdGePoint3d origin, OdGeVector3d uAxis, OdGeVector3d vAxis)
	{
		OdGeBoundedPlane result = new OdGeBoundedPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_set__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uAxis), OdGeVector3d.getCPtr(vAxis)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundedPlane set(OdGePoint3d uPnt, OdGePoint3d origin, OdGePoint3d vPnt)
	{
		OdGeBoundedPlane result = new OdGeBoundedPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_set__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(uPnt), OdGePoint3d.getCPtr(origin), OdGePoint3d.getCPtr(vPnt)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundedPlane Assign(OdGeBoundedPlane plane)
	{
		OdGeBoundedPlane result = new OdGeBoundedPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundedPlane_Assign(swigCPtr, getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

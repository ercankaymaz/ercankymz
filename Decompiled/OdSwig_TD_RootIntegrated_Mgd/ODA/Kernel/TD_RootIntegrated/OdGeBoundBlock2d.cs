using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeBoundBlock2d : OdGeEntity2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeBoundBlock2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeBoundBlock2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeBoundBlock2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeBoundBlock2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_copy(swigCPtr);
		OdGeBoundBlock2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeBoundBlock2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock2d translateBy(OdGeVector2d translateVec)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock2d rotateBy(double angle)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock2d mirror(OdGeLine2d line)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeBoundBlock2d scaleBy(double scaleFactor)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundBlock2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundBlock2d(OdGePoint2d point1, OdGePoint2d point2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundBlock2d__SWIG_1(OdGePoint2d.getCPtr(point1), OdGePoint2d.getCPtr(point2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundBlock2d(OdGePoint2d base_, OdGeVector2d dir1, OdGeVector2d dir2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundBlock2d__SWIG_2(OdGePoint2d.getCPtr(base_), OdGeVector2d.getCPtr(dir1).Handle, OdGeVector2d.getCPtr(dir2).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundBlock2d(OdGeBoundBlock2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeBoundBlock2d__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getMinMaxPoints(OdGePoint2d p1, OdGePoint2d p2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_getMinMaxPoints(swigCPtr, OdGePoint2d.getCPtr(p1), OdGePoint2d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void get(OdGePoint2d base_, OdGeVector2d side1, OdGeVector2d side2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_get(swigCPtr, OdGePoint2d.getCPtr(base_), OdGeVector2d.getCPtr(side1).Handle, OdGeVector2d.getCPtr(side2).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeBoundBlock2d set(OdGePoint2d p1, OdGePoint2d p2)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_set__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(p1), OdGePoint2d.getCPtr(p2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock2d set(OdGePoint2d base_, OdGeVector2d side1, OdGeVector2d side2)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_set__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(base_), OdGeVector2d.getCPtr(side1).Handle, OdGeVector2d.getCPtr(side2).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock2d extend(OdGePoint2d point)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_extend(swigCPtr, OdGePoint2d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock2d swell(double distance)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_swell(swigCPtr, distance), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool contains(OdGePoint2d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_contains(swigCPtr, OdGePoint2d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDisjoint(OdGeBoundBlock2d block, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_isDisjoint__SWIG_0(swigCPtr, getCPtr(block), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDisjoint(OdGeBoundBlock2d block)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_isDisjoint__SWIG_1(swigCPtr, getCPtr(block));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock2d Assign(OdGeBoundBlock2d block)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_Assign(swigCPtr, getCPtr(block)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBox()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_isBox(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeBoundBlock2d setToBox(bool toBox)
	{
		OdGeBoundBlock2d result = new OdGeBoundBlock2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeBoundBlock2d_setToBox(swigCPtr, toBox), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

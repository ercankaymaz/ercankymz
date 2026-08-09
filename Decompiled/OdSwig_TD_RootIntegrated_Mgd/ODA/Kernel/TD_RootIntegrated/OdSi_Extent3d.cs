using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSi_Extent3d : OdGeExtents3d, OdSiShape
{
	private object locker = new object();

	private HandleRef swigCPtr;

	public static OdSiShape kOverallSpace
	{
		get
		{
			OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_kOverallSpace_get(), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdSiShape kNoSpace
	{
		get
		{
			OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_kNoSpace_get(), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSi_Extent3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSi_Extent3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSi_Extent3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdSiShape.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_OdSiShape_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public virtual bool contains(OdGeExtents3d extents, bool planar, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_contains(swigCPtr, OdGeExtents3d.getCPtr(extents), planar, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool intersects(OdGeExtents3d extents, bool planar, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_intersects(swigCPtr, OdGeExtents3d.getCPtr(extents), planar, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void makeHalf(int dimension, bool moveRight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_makeHalf(swigCPtr, dimension, moveRight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void makeDouble(int dimension, bool moveRight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_makeDouble(swigCPtr, dimension, moveRight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void makeCube(bool planar)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_makeCube(swigCPtr, planar);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdSi_Extent3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Extent3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdSi_Extent3d(OdGePoint3d min, OdGePoint3d max)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Extent3d__SWIG_1(OdGePoint3d.getCPtr(min), OdGePoint3d.getCPtr(max)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdSi_Extent3d(OdGeExtents3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Extent3d__SWIG_2(OdGeExtents3d.getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdSi_Extent3d(OdGeExtents2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Extent3d__SWIG_3(OdGeExtents2d.getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdSiShape clone()
	{
		OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_clone(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void transform(OdGeMatrix3d arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_transform(swigCPtr, OdGeMatrix3d.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool isOverallSpace(OdSiShape ptr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_isOverallSpace(ptr.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isNoSpace(OdSiShape ptr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSi_Extent3d_isNoSpace(ptr.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

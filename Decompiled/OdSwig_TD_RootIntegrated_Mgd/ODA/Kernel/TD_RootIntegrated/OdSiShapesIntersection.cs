using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSiShapesIntersection : OdSiShape, IDisposable
{
	public delegate bool SwigDelegateOdSiShapesIntersection_0(IntPtr extents, bool planar, IntPtr tol);

	public delegate bool SwigDelegateOdSiShapesIntersection_1(IntPtr extents, bool planar, IntPtr tol);

	public delegate IntPtr SwigDelegateOdSiShapesIntersection_2();

	public delegate void SwigDelegateOdSiShapesIntersection_3(IntPtr tf);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdSiShapesIntersection_0 swigDelegate0;

	private SwigDelegateOdSiShapesIntersection_1 swigDelegate1;

	private SwigDelegateOdSiShapesIntersection_2 swigDelegate2;

	private SwigDelegateOdSiShapesIntersection_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[3]
	{
		typeof(OdGeExtents3d),
		typeof(bool),
		typeof(OdGeTol)
	};

	private static Type[] swigMethodTypes1 = new Type[3]
	{
		typeof(OdGeExtents3d),
		typeof(bool),
		typeof(OdGeTol)
	};

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGeMatrix3d) };

	public static OdSiShape kOverallSpace
	{
		get
		{
			OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_kOverallSpace_get(), cMemoryOwn: false);
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
			OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_kNoSpace_get(), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSiShapesIntersection(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSiShapesIntersection obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdSiShapesIntersection()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSiShapesIntersection(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdSiShape.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_OdSiShape_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public OdSiShapesIntersection()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiShapesIntersection__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSiShapesIntersection) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSiShapesIntersection(OdSiShapeConstPtrArray shapes)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiShapesIntersection__SWIG_1(OdSiShapeConstPtrArray.getCPtr(shapes)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSiShapesIntersection) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSiShapePtrArray shapes()
	{
		OdSiShapePtrArray result = new OdSiShapePtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_shapes(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void reset(OdSiShapeConstPtrArray shapes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_reset(swigCPtr, OdSiShapeConstPtrArray.getCPtr(shapes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool contains(OdGeExtents3d extents, bool planar, OdGeTol tol)
	{
		bool result = (SwigDerivedClassHasMethod("contains", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_containsSwigExplicitOdSiShapesIntersection(swigCPtr, OdGeExtents3d.getCPtr(extents), planar, OdGeTol.getCPtr(tol)) : TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_contains(swigCPtr, OdGeExtents3d.getCPtr(extents), planar, OdGeTol.getCPtr(tol)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool intersects(OdGeExtents3d extents, bool planar, OdGeTol tol)
	{
		bool result = (SwigDerivedClassHasMethod("intersects", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_intersectsSwigExplicitOdSiShapesIntersection(swigCPtr, OdGeExtents3d.getCPtr(extents), planar, OdGeTol.getCPtr(tol)) : TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_intersects(swigCPtr, OdGeExtents3d.getCPtr(extents), planar, OdGeTol.getCPtr(tol)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdSiShape clone()
	{
		OdSiShapeImpl result = new OdSiShapeImpl(SwigDerivedClassHasMethod("clone", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_cloneSwigExplicitOdSiShapesIntersection(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_clone(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void transform(OdGeMatrix3d tf)
	{
		if (SwigDerivedClassHasMethod("transform", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_transformSwigExplicitOdSiShapesIntersection(swigCPtr, OdGeMatrix3d.getCPtr(tf));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_transform(swigCPtr, OdGeMatrix3d.getCPtr(tf));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool isOverallSpace(OdSiShape ptr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_isOverallSpace(ptr.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isNoSpace(OdSiShape ptr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_isNoSpace(ptr.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("contains", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodcontains;
		}
		if (SwigDerivedClassHasMethod("intersects", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodintersects;
		}
		if (SwigDerivedClassHasMethod("clone", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodclone;
		}
		if (SwigDerivedClassHasMethod("transform", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodtransform;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdSiShapesIntersection_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSiShapesIntersection));
	}

	private bool SwigDirectorMethodcontains(IntPtr extents, bool planar, IntPtr tol)
	{
		return contains(new OdGeExtents3d(extents, cMemoryOwn: false), planar, new OdGeTol(tol, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodintersects(IntPtr extents, bool planar, IntPtr tol)
	{
		return intersects(new OdGeExtents3d(extents, cMemoryOwn: false), planar, new OdGeTol(tol, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodclone()
	{
		return clone().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodtransform(IntPtr tf)
	{
		try
		{
			transform(new OdGeMatrix3d(tf, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}

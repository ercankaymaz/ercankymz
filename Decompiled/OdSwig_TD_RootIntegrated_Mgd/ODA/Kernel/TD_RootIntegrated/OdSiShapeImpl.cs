using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSiShapeImpl : OdSiShape, IDisposable
{
	public delegate bool SwigDelegateOdSiShapeImpl_0(IntPtr extents, bool planar, IntPtr tol);

	public delegate bool SwigDelegateOdSiShapeImpl_1(IntPtr extents, bool planar, IntPtr tol);

	public delegate IntPtr SwigDelegateOdSiShapeImpl_2();

	public delegate void SwigDelegateOdSiShapeImpl_3(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdSiShapeImpl_0 swigDelegate0;

	private SwigDelegateOdSiShapeImpl_1 swigDelegate1;

	private SwigDelegateOdSiShapeImpl_2 swigDelegate2;

	private SwigDelegateOdSiShapeImpl_3 swigDelegate3;

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
			OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdSiShapeImpl_kOverallSpace_get(), cMemoryOwn: false);
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
			OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdSiShapeImpl_kNoSpace_get(), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSiShapeImpl(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSiShapeImpl obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdSiShapeImpl()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSiShapeImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdSiShape.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdSiShapeImpl_OdSiShape_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public virtual bool contains(OdGeExtents3d extents, bool planar, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiShapeImpl_contains(swigCPtr, OdGeExtents3d.getCPtr(extents), planar, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool intersects(OdGeExtents3d extents, bool planar, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiShapeImpl_intersects(swigCPtr, OdGeExtents3d.getCPtr(extents), planar, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdSiShape clone()
	{
		OdSiShapeImpl result = new OdSiShapeImpl(SwigDerivedClassHasMethod("clone", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdSiShapeImpl_cloneSwigExplicitOdSiShapeImpl(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdSiShapeImpl_clone(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void transform(OdGeMatrix3d arg0)
	{
		if (SwigDerivedClassHasMethod("transform", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdSiShapeImpl_transformSwigExplicitOdSiShapeImpl(swigCPtr, OdGeMatrix3d.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdSiShapeImpl_transform(swigCPtr, OdGeMatrix3d.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool isOverallSpace(OdSiShape ptr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiShapeImpl_isOverallSpace(ptr.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isNoSpace(OdSiShape ptr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiShapeImpl_isNoSpace(ptr.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdSiShapeImpl()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiShapeImpl(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSiShapeImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		TD_RootIntegrated_GlobalsPINVOKE.OdSiShapeImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSiShapeImpl));
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

	private void SwigDirectorMethodtransform(IntPtr arg0)
	{
		try
		{
			transform(new OdGeMatrix3d(arg0, cMemoryOwn: false));
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

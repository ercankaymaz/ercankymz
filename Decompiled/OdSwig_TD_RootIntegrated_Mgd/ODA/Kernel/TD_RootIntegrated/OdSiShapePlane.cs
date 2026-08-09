using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSiShapePlane : OdSiShape, IDisposable
{
	public delegate bool SwigDelegateOdSiShapePlane_0(IntPtr arg0, bool arg1, IntPtr arg2);

	public delegate bool SwigDelegateOdSiShapePlane_1(IntPtr extents, bool arg1, IntPtr tol);

	public delegate IntPtr SwigDelegateOdSiShapePlane_2();

	public delegate void SwigDelegateOdSiShapePlane_3(IntPtr tf);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdSiShapePlane_0 swigDelegate0;

	private SwigDelegateOdSiShapePlane_1 swigDelegate1;

	private SwigDelegateOdSiShapePlane_2 swigDelegate2;

	private SwigDelegateOdSiShapePlane_3 swigDelegate3;

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

	public OdGePoint3d m_pointOnPlane
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_m_pointOnPlane_get(swigCPtr);
			OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_m_pointOnPlane_set(swigCPtr, OdGePoint3d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGeVector3d m_planeNormal
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_m_planeNormal_get(swigCPtr);
			OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_m_planeNormal_set(swigCPtr, OdGeVector3d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public static OdSiShape kOverallSpace
	{
		get
		{
			OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_kOverallSpace_get(), cMemoryOwn: false);
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
			OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_kNoSpace_get(), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSiShapePlane(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSiShapePlane obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdSiShapePlane()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSiShapePlane(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdSiShape.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_OdSiShape_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public OdSiShapePlane(OdGePoint3d pointOnPlane, OdGeVector3d planeNormal)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiShapePlane__SWIG_0(OdGePoint3d.getCPtr(pointOnPlane), OdGeVector3d.getCPtr(planeNormal)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSiShapePlane) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSiShapePlane(OdGePlane plane)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiShapePlane__SWIG_1(OdGePlane.getCPtr(plane)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSiShapePlane) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public double signedDistanceTo(OdGePoint3d pt)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_signedDistanceTo(swigCPtr, OdGePoint3d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool contains(OdGeExtents3d arg0, bool arg1, OdGeTol arg2)
	{
		bool result = (SwigDerivedClassHasMethod("contains", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_containsSwigExplicitOdSiShapePlane(swigCPtr, OdGeExtents3d.getCPtr(arg0), arg1, OdGeTol.getCPtr(arg2)) : TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_contains(swigCPtr, OdGeExtents3d.getCPtr(arg0), arg1, OdGeTol.getCPtr(arg2)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool intersects(OdGeExtents3d extents, bool arg1, OdGeTol tol)
	{
		bool result = (SwigDerivedClassHasMethod("intersects", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_intersectsSwigExplicitOdSiShapePlane(swigCPtr, OdGeExtents3d.getCPtr(extents), arg1, OdGeTol.getCPtr(tol)) : TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_intersects(swigCPtr, OdGeExtents3d.getCPtr(extents), arg1, OdGeTol.getCPtr(tol)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdSiShape clone()
	{
		OdSiShapeImpl result = new OdSiShapeImpl(SwigDerivedClassHasMethod("clone", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_cloneSwigExplicitOdSiShapePlane(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_clone(swigCPtr), cMemoryOwn: false);
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
			TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_transformSwigExplicitOdSiShapePlane(swigCPtr, OdGeMatrix3d.getCPtr(tf));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_transform(swigCPtr, OdGeMatrix3d.getCPtr(tf));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool isOverallSpace(OdSiShape ptr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_isOverallSpace(ptr.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isNoSpace(OdSiShape ptr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_isNoSpace(ptr.GetInterfaceCPtr());
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
		TD_RootIntegrated_GlobalsPINVOKE.OdSiShapePlane_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSiShapePlane));
	}

	private bool SwigDirectorMethodcontains(IntPtr arg0, bool arg1, IntPtr arg2)
	{
		return contains(new OdGeExtents3d(arg0, cMemoryOwn: false), arg1, new OdGeTol(arg2, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodintersects(IntPtr extents, bool arg1, IntPtr tol)
	{
		return intersects(new OdGeExtents3d(extents, cMemoryOwn: false), arg1, new OdGeTol(tol, cMemoryOwn: false));
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

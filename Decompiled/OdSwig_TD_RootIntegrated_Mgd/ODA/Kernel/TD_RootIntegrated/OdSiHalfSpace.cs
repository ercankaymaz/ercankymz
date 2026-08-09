using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSiHalfSpace : OdSiShapePlane
{
	public delegate bool SwigDelegateOdSiHalfSpace_0(IntPtr extents, bool arg1, IntPtr tol);

	public delegate bool SwigDelegateOdSiHalfSpace_1(IntPtr extents, bool arg1, IntPtr tol);

	public delegate IntPtr SwigDelegateOdSiHalfSpace_2();

	public delegate void SwigDelegateOdSiHalfSpace_3(IntPtr tf);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdSiHalfSpace_0 swigDelegate0;

	private SwigDelegateOdSiHalfSpace_1 swigDelegate1;

	private SwigDelegateOdSiHalfSpace_2 swigDelegate2;

	private SwigDelegateOdSiHalfSpace_3 swigDelegate3;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSiHalfSpace(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdSiHalfSpace_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSiHalfSpace obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSiHalfSpace(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdSiHalfSpace(OdGePoint3d pointOnPlane, OdGeVector3d planeNormal)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiHalfSpace__SWIG_0(OdGePoint3d.getCPtr(pointOnPlane), OdGeVector3d.getCPtr(planeNormal)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSiHalfSpace) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSiHalfSpace(OdGePlane plane)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiHalfSpace__SWIG_1(OdGePlane.getCPtr(plane)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSiHalfSpace) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public void copyFrom(OdSiHalfSpace o)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiHalfSpace_copyFrom(swigCPtr, getCPtr(o));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool contains(OdGeExtents3d extents, bool arg1, OdGeTol tol)
	{
		bool result = (SwigDerivedClassHasMethod("contains", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdSiHalfSpace_containsSwigExplicitOdSiHalfSpace(swigCPtr, OdGeExtents3d.getCPtr(extents), arg1, OdGeTol.getCPtr(tol)) : TD_RootIntegrated_GlobalsPINVOKE.OdSiHalfSpace_contains(swigCPtr, OdGeExtents3d.getCPtr(extents), arg1, OdGeTol.getCPtr(tol)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool intersects(OdGeExtents3d extents, bool arg1, OdGeTol tol)
	{
		bool result = (SwigDerivedClassHasMethod("intersects", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdSiHalfSpace_intersectsSwigExplicitOdSiHalfSpace__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(extents), arg1, OdGeTol.getCPtr(tol)) : TD_RootIntegrated_GlobalsPINVOKE.OdSiHalfSpace_intersects__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(extents), arg1, OdGeTol.getCPtr(tol)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdSiShape clone()
	{
		OdSiShapeImpl result = new OdSiShapeImpl(SwigDerivedClassHasMethod("clone", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdSiHalfSpace_cloneSwigExplicitOdSiHalfSpace(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdSiHalfSpace_clone(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersects(OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis, OdGeVector3d zAxis, OdGeTol tol, out bool bContains)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiHalfSpace_intersects__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(zAxis), OdGeTol.getCPtr(tol), out bContains);
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
			swigDelegate1 = SwigDirectorMethodintersects__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("clone", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodclone;
		}
		if (SwigDerivedClassHasMethod("transform", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodtransform;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdSiHalfSpace_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSiHalfSpace));
	}

	private bool SwigDirectorMethodcontains(IntPtr extents, bool arg1, IntPtr tol)
	{
		return contains(new OdGeExtents3d(extents, cMemoryOwn: false), arg1, new OdGeTol(tol, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodintersects__SWIG_0(IntPtr extents, bool arg1, IntPtr tol)
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

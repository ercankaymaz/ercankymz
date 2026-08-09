using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSi_Volume : OdSiShape, IDisposable
{
	public delegate bool SwigDelegateOdSi_Volume_0(IntPtr extents, bool planar, IntPtr tol);

	public delegate bool SwigDelegateOdSi_Volume_1(IntPtr extents, bool planar, IntPtr tol);

	public delegate void SwigDelegateOdSi_Volume_2(IntPtr mtx);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdSi_Volume_0 swigDelegate0;

	private SwigDelegateOdSi_Volume_1 swigDelegate1;

	private SwigDelegateOdSi_Volume_2 swigDelegate2;

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

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdGeMatrix3d) };

	public static OdSiShape kOverallSpace
	{
		get
		{
			OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_kOverallSpace_get(), cMemoryOwn: false);
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
			OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_kNoSpace_get(), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSi_Volume(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSi_Volume obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdSi_Volume()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSi_Volume(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdSiShape.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_OdSiShape_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public virtual OdSiShape clone()
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		IntPtr cPtr = TD_RootIntegrated_GlobalsPINVOKE.Volume_clone(swigCPtr);
		OdSiShapeImpl odSiShapeImpl = null;
		if (currentTransaction != null)
		{
			currentTransaction.AddObject(new OdSiShapeImpl(cPtr, cMemoryOwn: true));
			odSiShapeImpl = new OdSiShapeImpl(cPtr, cMemoryOwn: false);
		}
		else
		{
			odSiShapeImpl = new OdSiShapeImpl(cPtr, cMemoryOwn: true);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odSiShapeImpl;
	}

	public OdSi_Volume()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Volume__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSi_Volume) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSi_Volume(OdSi_Volume source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Volume__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSi_Volume) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSi_Volume(OdGePoint3d origin, OdGeVector3d zAxis, OdGeVector3d yAxis, OdGeVector3d xAxis, double xFov, double yFov, bool xFovAsAspect, bool yFovAsAspect, bool bNearPlane, double fNearPlane, bool bFarPlane, double fFarPlane)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Volume__SWIG_2(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(zAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(xAxis), xFov, yFov, xFovAsAspect, yFovAsAspect, bNearPlane, fNearPlane, bFarPlane, fFarPlane), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSi_Volume) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSi_Volume(OdGePoint3d origin, OdGeVector3d zAxis, OdGeVector3d yAxis, OdGeVector3d xAxis, double xFov, double yFov, bool xFovAsAspect, bool yFovAsAspect, bool bNearPlane, double fNearPlane, bool bFarPlane)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Volume__SWIG_3(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(zAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(xAxis), xFov, yFov, xFovAsAspect, yFovAsAspect, bNearPlane, fNearPlane, bFarPlane), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSi_Volume) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSi_Volume(OdGePoint3d origin, OdGeVector3d zAxis, OdGeVector3d yAxis, OdGeVector3d xAxis, double xFov, double yFov, bool xFovAsAspect, bool yFovAsAspect, bool bNearPlane, double fNearPlane)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Volume__SWIG_4(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(zAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(xAxis), xFov, yFov, xFovAsAspect, yFovAsAspect, bNearPlane, fNearPlane), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSi_Volume) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSi_Volume(OdGePoint3d origin, OdGeVector3d zAxis, OdGeVector3d yAxis, OdGeVector3d xAxis, double xFov, double yFov, bool xFovAsAspect, bool yFovAsAspect, bool bNearPlane)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Volume__SWIG_5(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(zAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(xAxis), xFov, yFov, xFovAsAspect, yFovAsAspect, bNearPlane), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSi_Volume) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSi_Volume(OdGePoint3d origin, OdGeVector3d zAxis, OdGeVector3d yAxis, OdGeVector3d xAxis, double xFov, double yFov, bool xFovAsAspect, bool yFovAsAspect)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Volume__SWIG_6(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(zAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(xAxis), xFov, yFov, xFovAsAspect, yFovAsAspect), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSi_Volume) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSi_Volume(OdGePoint3d origin, OdGeVector3d zAxis, OdGeVector3d yAxis, OdGeVector3d xAxis, double xFov, double yFov, bool xFovAsAspect)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Volume__SWIG_7(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(zAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(xAxis), xFov, yFov, xFovAsAspect), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSi_Volume) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSi_Volume(OdGePoint3d origin, OdGeVector3d zAxis, OdGeVector3d yAxis, OdGeVector3d xAxis, double xFov, double yFov)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSi_Volume__SWIG_8(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(zAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(xAxis), xFov, yFov), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSi_Volume) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual bool contains(OdGeExtents3d extents, bool planar, OdGeTol tol)
	{
		bool result = (SwigDerivedClassHasMethod("contains", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_containsSwigExplicitOdSi_Volume(swigCPtr, OdGeExtents3d.getCPtr(extents), planar, OdGeTol.getCPtr(tol)) : TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_contains(swigCPtr, OdGeExtents3d.getCPtr(extents), planar, OdGeTol.getCPtr(tol)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool intersects(OdGeExtents3d extents, bool planar, OdGeTol tol)
	{
		bool result = (SwigDerivedClassHasMethod("intersects", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_intersectsSwigExplicitOdSi_Volume(swigCPtr, OdGeExtents3d.getCPtr(extents), planar, OdGeTol.getCPtr(tol)) : TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_intersects(swigCPtr, OdGeExtents3d.getCPtr(extents), planar, OdGeTol.getCPtr(tol)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void transform(OdGeMatrix3d mtx)
	{
		if (SwigDerivedClassHasMethod("transform", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_transformSwigExplicitOdSi_Volume(swigCPtr, OdGeMatrix3d.getCPtr(mtx));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_transform(swigCPtr, OdGeMatrix3d.getCPtr(mtx));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static double fovToPlane(double fov, double len)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_fovToPlane(fov, len);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double fovFromPlane(double plane, double len)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_fovFromPlane(plane, len);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdSi_Volume buildPyramidInEyeCS(OdGeExtents2d baseProjecton, double viewDistance, bool bNearPnane, double dNearPlane, bool bFarPlane, double dFarPlane)
	{
		OdSi_Volume result = new OdSi_Volume(TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_buildPyramidInEyeCS__SWIG_0(OdGeExtents2d.getCPtr(baseProjecton), viewDistance, bNearPnane, dNearPlane, bFarPlane, dFarPlane), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdSi_Volume buildPyramidInEyeCS(OdGeExtents2d baseProjecton, double viewDistance, bool bNearPnane, double dNearPlane, bool bFarPlane)
	{
		OdSi_Volume result = new OdSi_Volume(TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_buildPyramidInEyeCS__SWIG_1(OdGeExtents2d.getCPtr(baseProjecton), viewDistance, bNearPnane, dNearPlane, bFarPlane), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdSi_Volume buildPyramidInEyeCS(OdGeExtents2d baseProjecton, double viewDistance, bool bNearPnane, double dNearPlane)
	{
		OdSi_Volume result = new OdSi_Volume(TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_buildPyramidInEyeCS__SWIG_2(OdGeExtents2d.getCPtr(baseProjecton), viewDistance, bNearPnane, dNearPlane), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdSi_Volume buildPyramidInEyeCS(OdGeExtents2d baseProjecton, double viewDistance, bool bNearPnane)
	{
		OdSi_Volume result = new OdSi_Volume(TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_buildPyramidInEyeCS__SWIG_3(OdGeExtents2d.getCPtr(baseProjecton), viewDistance, bNearPnane), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdSi_Volume buildPyramidInEyeCS(OdGeExtents2d baseProjecton, double viewDistance)
	{
		OdSi_Volume result = new OdSi_Volume(TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_buildPyramidInEyeCS__SWIG_4(OdGeExtents2d.getCPtr(baseProjecton), viewDistance), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isOverallSpace(OdSiShape ptr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_isOverallSpace(ptr.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isNoSpace(OdSiShape ptr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_isNoSpace(ptr.GetInterfaceCPtr());
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
		if (SwigDerivedClassHasMethod("transform", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodtransform;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdSi_Volume_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSi_Volume));
	}

	private bool SwigDirectorMethodcontains(IntPtr extents, bool planar, IntPtr tol)
	{
		return contains(new OdGeExtents3d(extents, cMemoryOwn: false), planar, new OdGeTol(tol, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodintersects(IntPtr extents, bool planar, IntPtr tol)
	{
		return intersects(new OdGeExtents3d(extents, cMemoryOwn: false), planar, new OdGeTol(tol, cMemoryOwn: false));
	}

	private void SwigDirectorMethodtransform(IntPtr mtx)
	{
		try
		{
			transform(new OdGeMatrix3d(mtx, cMemoryOwn: false));
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

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsFrustumCullingVolume : OdGsCullingVolume
{
	public delegate IntPtr SwigDelegateOdGsFrustumCullingVolume_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsFrustumCullingVolume_1();

	public delegate void SwigDelegateOdGsFrustumCullingVolume_2(IntPtr pSource);

	public delegate int SwigDelegateOdGsFrustumCullingVolume_3();

	public delegate bool SwigDelegateOdGsFrustumCullingVolume_4(IntPtr prim);

	public delegate int SwigDelegateOdGsFrustumCullingVolume_5(IntPtr prim);

	public delegate void SwigDelegateOdGsFrustumCullingVolume_6(IntPtr xfm);

	public delegate void SwigDelegateOdGsFrustumCullingVolume_7(IntPtr position, IntPtr direction, IntPtr upVector, double fovY, double aspect, uint nPlanes, double nearZ, double farZ);

	public delegate void SwigDelegateOdGsFrustumCullingVolume_8(IntPtr position, IntPtr direction, IntPtr upVector, double fovY, double aspect, uint nPlanes, double nearZ);

	public delegate void SwigDelegateOdGsFrustumCullingVolume_9(IntPtr position, IntPtr direction, IntPtr upVector, double fovY, double aspect, uint nPlanes);

	public delegate void SwigDelegateOdGsFrustumCullingVolume_10(IntPtr position, IntPtr direction, IntPtr upVector, double fovY, double aspect);

	public delegate void SwigDelegateOdGsFrustumCullingVolume_11(IntPtr position, IntPtr direction, IntPtr upVector, double fovX, bool aspect, double fovY, uint nPlanes, double nearZ, double farZ);

	public delegate void SwigDelegateOdGsFrustumCullingVolume_12(IntPtr position, IntPtr direction, IntPtr upVector, double fovX, bool aspect, double fovY, uint nPlanes, double nearZ);

	public delegate void SwigDelegateOdGsFrustumCullingVolume_13(IntPtr position, IntPtr direction, IntPtr upVector, double fovX, bool aspect, double fovY, uint nPlanes);

	public delegate void SwigDelegateOdGsFrustumCullingVolume_14(IntPtr position, IntPtr direction, IntPtr upVector, double fovX, bool aspect, double fovY);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsFrustumCullingVolume_0 swigDelegate0;

	private SwigDelegateOdGsFrustumCullingVolume_1 swigDelegate1;

	private SwigDelegateOdGsFrustumCullingVolume_2 swigDelegate2;

	private SwigDelegateOdGsFrustumCullingVolume_3 swigDelegate3;

	private SwigDelegateOdGsFrustumCullingVolume_4 swigDelegate4;

	private SwigDelegateOdGsFrustumCullingVolume_5 swigDelegate5;

	private SwigDelegateOdGsFrustumCullingVolume_6 swigDelegate6;

	private SwigDelegateOdGsFrustumCullingVolume_7 swigDelegate7;

	private SwigDelegateOdGsFrustumCullingVolume_8 swigDelegate8;

	private SwigDelegateOdGsFrustumCullingVolume_9 swigDelegate9;

	private SwigDelegateOdGsFrustumCullingVolume_10 swigDelegate10;

	private SwigDelegateOdGsFrustumCullingVolume_11 swigDelegate11;

	private SwigDelegateOdGsFrustumCullingVolume_12 swigDelegate12;

	private SwigDelegateOdGsFrustumCullingVolume_13 swigDelegate13;

	private SwigDelegateOdGsFrustumCullingVolume_14 swigDelegate14;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGsCullingPrimitive) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGsCullingPrimitive) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes7 = new Type[8]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double),
		typeof(uint),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes8 = new Type[7]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double),
		typeof(uint),
		typeof(double)
	};

	private static Type[] swigMethodTypes9 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double),
		typeof(uint)
	};

	private static Type[] swigMethodTypes10 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes11 = new Type[9]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(bool),
		typeof(double),
		typeof(uint),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes12 = new Type[8]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(bool),
		typeof(double),
		typeof(uint),
		typeof(double)
	};

	private static Type[] swigMethodTypes13 = new Type[7]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(bool),
		typeof(double),
		typeof(uint)
	};

	private static Type[] swigMethodTypes14 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(bool),
		typeof(double)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsFrustumCullingVolume(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsFrustumCullingVolume obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFrustumCullingVolume(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsFrustumCullingVolume cast(OdRxObject pObj)
	{
		OdGsFrustumCullingVolume rXObject = Helpers.GetRXObject<OdGsFrustumCullingVolume>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_isASwigExplicitOdGsFrustumCullingVolume(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_queryXSwigExplicitOdGsFrustumCullingVolume(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsFrustumCullingVolume createObject()
	{
		OdGsFrustumCullingVolume rXObject = Helpers.GetRXObject<OdGsFrustumCullingVolume>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void init(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, double fovY, double aspect, uint nPlanes, double nearZ, double farZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_init__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fovY, aspect, nPlanes, nearZ, farZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void init(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, double fovY, double aspect, uint nPlanes, double nearZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_init__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fovY, aspect, nPlanes, nearZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void init(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, double fovY, double aspect, uint nPlanes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_init__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fovY, aspect, nPlanes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void init(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, double fovY, double aspect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_init__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fovY, aspect);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void init(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, double fovX, bool aspect, double fovY, uint nPlanes, double nearZ, double farZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_init__SWIG_4(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fovX, aspect, fovY, nPlanes, nearZ, farZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void init(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, double fovX, bool aspect, double fovY, uint nPlanes, double nearZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_init__SWIG_5(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fovX, aspect, fovY, nPlanes, nearZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void init(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, double fovX, bool aspect, double fovY, uint nPlanes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_init__SWIG_6(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fovX, aspect, fovY, nPlanes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void init(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, double fovX, bool aspect, double fovY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_init__SWIG_7(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fovX, aspect, fovY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsFrustumCullingVolume()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFrustumCullingVolume(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsFrustumCullingVolume) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("projectionType", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodprojectionType;
		}
		if (SwigDerivedClassHasMethod("intersectWithOpt", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodintersectWithOpt;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodintersectWith;
		}
		if (SwigDerivedClassHasMethod("transformBy", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodtransformBy;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodinit__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodinit__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodinit__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodinit__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodinit__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodinit__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodinit__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodinit__SWIG_7;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFrustumCullingVolume_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsFrustumCullingVolume));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodprojectionType()
	{
		return (int)projectionType();
	}

	private bool SwigDirectorMethodintersectWithOpt(IntPtr prim)
	{
		return intersectWithOpt(new OdGsCullingPrimitive(prim, cMemoryOwn: false));
	}

	private int SwigDirectorMethodintersectWith(IntPtr prim)
	{
		return (int)intersectWith(new OdGsCullingPrimitive(prim, cMemoryOwn: false));
	}

	private void SwigDirectorMethodtransformBy(IntPtr xfm)
	{
		try
		{
			transformBy(new OdGeMatrix3d(xfm, cMemoryOwn: false));
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

	private void SwigDirectorMethodinit__SWIG_0(IntPtr position, IntPtr direction, IntPtr upVector, double fovY, double aspect, uint nPlanes, double nearZ, double farZ)
	{
		try
		{
			init(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fovY, aspect, nPlanes, nearZ, farZ);
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

	private void SwigDirectorMethodinit__SWIG_1(IntPtr position, IntPtr direction, IntPtr upVector, double fovY, double aspect, uint nPlanes, double nearZ)
	{
		try
		{
			init(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fovY, aspect, nPlanes, nearZ);
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

	private void SwigDirectorMethodinit__SWIG_2(IntPtr position, IntPtr direction, IntPtr upVector, double fovY, double aspect, uint nPlanes)
	{
		try
		{
			init(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fovY, aspect, nPlanes);
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

	private void SwigDirectorMethodinit__SWIG_3(IntPtr position, IntPtr direction, IntPtr upVector, double fovY, double aspect)
	{
		try
		{
			init(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fovY, aspect);
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

	private void SwigDirectorMethodinit__SWIG_4(IntPtr position, IntPtr direction, IntPtr upVector, double fovX, bool aspect, double fovY, uint nPlanes, double nearZ, double farZ)
	{
		try
		{
			init(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fovX, aspect, fovY, nPlanes, nearZ, farZ);
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

	private void SwigDirectorMethodinit__SWIG_5(IntPtr position, IntPtr direction, IntPtr upVector, double fovX, bool aspect, double fovY, uint nPlanes, double nearZ)
	{
		try
		{
			init(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fovX, aspect, fovY, nPlanes, nearZ);
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

	private void SwigDirectorMethodinit__SWIG_6(IntPtr position, IntPtr direction, IntPtr upVector, double fovX, bool aspect, double fovY, uint nPlanes)
	{
		try
		{
			init(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fovX, aspect, fovY, nPlanes);
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

	private void SwigDirectorMethodinit__SWIG_7(IntPtr position, IntPtr direction, IntPtr upVector, double fovX, bool aspect, double fovY)
	{
		try
		{
			init(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fovX, aspect, fovY);
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

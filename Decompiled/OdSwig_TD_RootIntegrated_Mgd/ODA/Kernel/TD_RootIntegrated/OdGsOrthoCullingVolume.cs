using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsOrthoCullingVolume : OdGsCullingVolume
{
	public delegate IntPtr SwigDelegateOdGsOrthoCullingVolume_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsOrthoCullingVolume_1();

	public delegate void SwigDelegateOdGsOrthoCullingVolume_2(IntPtr pSource);

	public delegate int SwigDelegateOdGsOrthoCullingVolume_3();

	public delegate bool SwigDelegateOdGsOrthoCullingVolume_4(IntPtr prim);

	public delegate int SwigDelegateOdGsOrthoCullingVolume_5(IntPtr prim);

	public delegate void SwigDelegateOdGsOrthoCullingVolume_6(IntPtr xfm);

	public delegate void SwigDelegateOdGsOrthoCullingVolume_7(IntPtr position, IntPtr direction, IntPtr upVector, double volumeWidth, double volumeHeight);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsOrthoCullingVolume_0 swigDelegate0;

	private SwigDelegateOdGsOrthoCullingVolume_1 swigDelegate1;

	private SwigDelegateOdGsOrthoCullingVolume_2 swigDelegate2;

	private SwigDelegateOdGsOrthoCullingVolume_3 swigDelegate3;

	private SwigDelegateOdGsOrthoCullingVolume_4 swigDelegate4;

	private SwigDelegateOdGsOrthoCullingVolume_5 swigDelegate5;

	private SwigDelegateOdGsOrthoCullingVolume_6 swigDelegate6;

	private SwigDelegateOdGsOrthoCullingVolume_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGsCullingPrimitive) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGsCullingPrimitive) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes7 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsOrthoCullingVolume(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsOrthoCullingVolume_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsOrthoCullingVolume obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsOrthoCullingVolume(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsOrthoCullingVolume cast(OdRxObject pObj)
	{
		OdGsOrthoCullingVolume rXObject = Helpers.GetRXObject<OdGsOrthoCullingVolume>(TD_RootIntegrated_GlobalsPINVOKE.OdGsOrthoCullingVolume_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsOrthoCullingVolume_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsOrthoCullingVolume_isASwigExplicitOdGsOrthoCullingVolume(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsOrthoCullingVolume_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsOrthoCullingVolume_queryXSwigExplicitOdGsOrthoCullingVolume(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsOrthoCullingVolume_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsOrthoCullingVolume createObject()
	{
		OdGsOrthoCullingVolume rXObject = Helpers.GetRXObject<OdGsOrthoCullingVolume>(TD_RootIntegrated_GlobalsPINVOKE.OdGsOrthoCullingVolume_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void init(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, double volumeWidth, double volumeHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsOrthoCullingVolume_init(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), volumeWidth, volumeHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsOrthoCullingVolume_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsOrthoCullingVolume()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsOrthoCullingVolume(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsOrthoCullingVolume) != GetType();
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
			swigDelegate7 = SwigDirectorMethodinit;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsOrthoCullingVolume_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsOrthoCullingVolume));
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

	private void SwigDirectorMethodinit(IntPtr position, IntPtr direction, IntPtr upVector, double volumeWidth, double volumeHeight)
	{
		try
		{
			init(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), volumeWidth, volumeHeight);
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

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPointCloudExtentsReceiver : OdGiPointCloudReceiver
{
	public delegate IntPtr SwigDelegateOdGiPointCloudExtentsReceiver_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiPointCloudExtentsReceiver_1();

	public delegate void SwigDelegateOdGiPointCloudExtentsReceiver_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiPointCloudExtentsReceiver_3(IntPtr pArrays, uint nArrays, uint compFlags, ulong arg3, IntPtr pExtents);

	public delegate bool SwigDelegateOdGiPointCloudExtentsReceiver_4(uint arg0, ulong arg1);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiPointCloudExtentsReceiver_0 swigDelegate0;

	private SwigDelegateOdGiPointCloudExtentsReceiver_1 swigDelegate1;

	private SwigDelegateOdGiPointCloudExtentsReceiver_2 swigDelegate2;

	private SwigDelegateOdGiPointCloudExtentsReceiver_3 swigDelegate3;

	private SwigDelegateOdGiPointCloudExtentsReceiver_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[5]
	{
		typeof(OdGiPointCloud.ComponentsRaw),
		typeof(uint),
		typeof(uint),
		typeof(ulong),
		typeof(OdGeBoundBlock3d)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(uint),
		typeof(ulong)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPointCloudExtentsReceiver(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPointCloudExtentsReceiver obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPointCloudExtentsReceiver(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiPointCloudExtentsReceiver cast(OdRxObject pObj)
	{
		OdGiPointCloudExtentsReceiver rXObject = Helpers.GetRXObject<OdGiPointCloudExtentsReceiver>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_isASwigExplicitOdGiPointCloudExtentsReceiver(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_queryXSwigExplicitOdGiPointCloudExtentsReceiver(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected override bool addPointsImpl(OdGiPointCloud.ComponentsRaw pArrays, uint nArrays, uint compFlags, ulong arg3, OdGeBoundBlock3d pExtents)
	{
		bool result = (SwigDerivedClassHasMethod("addPointsImpl", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_addPointsImplSwigExplicitOdGiPointCloudExtentsReceiver(swigCPtr, OdGiPointCloud.ComponentsRaw.getCPtr(pArrays), nArrays, compFlags, arg3, OdGeBoundBlock3d.getCPtr(pExtents)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_addPointsImpl(swigCPtr, OdGiPointCloud.ComponentsRaw.getCPtr(pArrays), nArrays, compFlags, arg3, OdGeBoundBlock3d.getCPtr(pExtents)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiPointCloudReceiver createObject(OdGiPointCloudFilter pFilter)
	{
		OdGiPointCloudReceiver rXObject = Helpers.GetRXObject<OdGiPointCloudReceiver>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_createObject__SWIG_0(OdGiPointCloudFilter.getCPtr(pFilter)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGeExtents3d getExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_getExtents(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void resetExtents()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_resetExtents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiPointCloudExtentsReceiver createObject()
	{
		OdGiPointCloudExtentsReceiver rXObject = Helpers.GetRXObject<OdGiPointCloudExtentsReceiver>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_createObject__SWIG_1(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("addPointsImpl", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodaddPointsImpl;
		}
		if (SwigDerivedClassHasMethod("removePointsImpl", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodremovePointsImpl;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudExtentsReceiver_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPointCloudExtentsReceiver));
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

	private bool SwigDirectorMethodaddPointsImpl(IntPtr pArrays, uint nArrays, uint compFlags, ulong arg3, IntPtr pExtents)
	{
		return addPointsImpl((pArrays == IntPtr.Zero) ? null : new OdGiPointCloud.ComponentsRaw(pArrays, cMemoryOwn: false), nArrays, compFlags, arg3, (pExtents == IntPtr.Zero) ? null : new OdGeBoundBlock3d(pExtents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodremovePointsImpl(uint arg0, ulong arg1)
	{
		return removePointsImpl(arg0, arg1);
	}
}

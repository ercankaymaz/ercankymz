using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPointCloudReceiver : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiPointCloudReceiver_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiPointCloudReceiver_1();

	public delegate void SwigDelegateOdGiPointCloudReceiver_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiPointCloudReceiver_3(IntPtr pArrays, uint nArrays, uint compFlags, ulong nCellId, IntPtr pExtents);

	public delegate bool SwigDelegateOdGiPointCloudReceiver_4(uint arg0, ulong arg1);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiPointCloudReceiver_0 swigDelegate0;

	private SwigDelegateOdGiPointCloudReceiver_1 swigDelegate1;

	private SwigDelegateOdGiPointCloudReceiver_2 swigDelegate2;

	private SwigDelegateOdGiPointCloudReceiver_3 swigDelegate3;

	private SwigDelegateOdGiPointCloudReceiver_4 swigDelegate4;

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
	public OdGiPointCloudReceiver(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPointCloudReceiver obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPointCloudReceiver(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiPointCloudReceiver cast(OdRxObject pObj)
	{
		OdGiPointCloudReceiver rXObject = Helpers.GetRXObject<OdGiPointCloudReceiver>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_isASwigExplicitOdGiPointCloudReceiver(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_queryXSwigExplicitOdGiPointCloudReceiver(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiPointCloudReceiver createObject()
	{
		OdGiPointCloudReceiver rXObject = Helpers.GetRXObject<OdGiPointCloudReceiver>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected virtual bool addPointsImpl(OdGiPointCloud.ComponentsRaw pArrays, uint nArrays, uint compFlags, ulong nCellId, OdGeBoundBlock3d pExtents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_addPointsImpl(swigCPtr, OdGiPointCloud.ComponentsRaw.getCPtr(pArrays), nArrays, compFlags, nCellId, OdGeBoundBlock3d.getCPtr(pExtents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual bool removePointsImpl(uint arg0, ulong arg1)
	{
		bool result = (SwigDerivedClassHasMethod("removePointsImpl", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_removePointsImplSwigExplicitOdGiPointCloudReceiver(swigCPtr, arg0, arg1) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_removePointsImpl(swigCPtr, arg0, arg1));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool addPoints(OdGiPointCloud.ComponentsRaw pArrays, uint nArrays, uint compFlags, ulong nCellId, OdGeBoundBlock3d pExtents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_addPoints__SWIG_0(swigCPtr, OdGiPointCloud.ComponentsRaw.getCPtr(pArrays), nArrays, compFlags, nCellId, OdGeBoundBlock3d.getCPtr(pExtents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool addPoints(OdGiPointCloud.ComponentsRaw pArrays, uint nArrays, uint compFlags, ulong nCellId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_addPoints__SWIG_1(swigCPtr, OdGiPointCloud.ComponentsRaw.getCPtr(pArrays), nArrays, compFlags, nCellId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool addPoints(OdGiPointCloud.ComponentsRaw pArrays, uint nArrays, uint compFlags)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_addPoints__SWIG_2(swigCPtr, OdGiPointCloud.ComponentsRaw.getCPtr(pArrays), nArrays, compFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool removePoints(uint nPoints, ulong nCellId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_removePoints__SWIG_0(swigCPtr, nPoints, nCellId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool removePoints(uint nPoints)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_removePoints__SWIG_1(swigCPtr, nPoints);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudReceiver_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPointCloudReceiver));
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

	private bool SwigDirectorMethodaddPointsImpl(IntPtr pArrays, uint nArrays, uint compFlags, ulong nCellId, IntPtr pExtents)
	{
		return addPointsImpl((pArrays == IntPtr.Zero) ? null : new OdGiPointCloud.ComponentsRaw(pArrays, cMemoryOwn: false), nArrays, compFlags, nCellId, (pExtents == IntPtr.Zero) ? null : new OdGeBoundBlock3d(pExtents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodremovePointsImpl(uint arg0, ulong arg1)
	{
		return removePointsImpl(arg0, arg1);
	}
}

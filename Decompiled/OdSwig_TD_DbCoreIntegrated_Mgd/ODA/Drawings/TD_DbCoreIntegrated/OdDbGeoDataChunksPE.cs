using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeoDataChunksPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeoDataChunksPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeoDataChunksPE_1();

	public delegate void SwigDelegateOdDbGeoDataChunksPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGeoDataChunksPE_3(IntPtr pVd);

	public delegate int SwigDelegateOdDbGeoDataChunksPE_4(IntPtr pVd);

	public delegate void SwigDelegateOdDbGeoDataChunksPE_5(bool bEnable);

	public delegate bool SwigDelegateOdDbGeoDataChunksPE_6();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeoDataChunksPE_0 swigDelegate0;

	private SwigDelegateOdDbGeoDataChunksPE_1 swigDelegate1;

	private SwigDelegateOdDbGeoDataChunksPE_2 swigDelegate2;

	private SwigDelegateOdDbGeoDataChunksPE_3 swigDelegate3;

	private SwigDelegateOdDbGeoDataChunksPE_4 swigDelegate4;

	private SwigDelegateOdDbGeoDataChunksPE_5 swigDelegate5;

	private SwigDelegateOdDbGeoDataChunksPE_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiViewportDraw) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGiViewportDraw) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes6 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeoDataChunksPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeoDataChunksPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeoDataChunksPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeoDataChunksPE cast(OdRxObject pObj)
	{
		OdDbGeoDataChunksPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoDataChunksPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_isASwigExplicitOdDbGeoDataChunksPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_queryXSwigExplicitOdDbGeoDataChunksPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbGeoDataChunksPE createObject()
	{
		OdDbGeoDataChunksPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoDataChunksPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult drawGeoDataChunks(OdGiViewportDraw pVd)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_drawGeoDataChunks(swigCPtr, OdGiViewportDraw.getCPtr(pVd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult drawGeoDataProvidersString(OdGiViewportDraw pVd)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_drawGeoDataProvidersString(swigCPtr, OdGiViewportDraw.getCPtr(pVd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void setMode(bool bEnable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_setMode(swigCPtr, bEnable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getMode()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_getMode(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbGeoDataChunksPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGeoDataChunksPE(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbGeoDataChunksPE) != GetType();
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
		if (SwigDerivedClassHasMethod("drawGeoDataChunks", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddrawGeoDataChunks;
		}
		if (SwigDerivedClassHasMethod("drawGeoDataProvidersString", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddrawGeoDataProvidersString;
		}
		if (SwigDerivedClassHasMethod("setMode", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetMode;
		}
		if (SwigDerivedClassHasMethod("getMode", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetMode;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataChunksPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeoDataChunksPE));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethoddrawGeoDataChunks(IntPtr pVd)
	{
		return (int)drawGeoDataChunks(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiViewportDraw>(pVd, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethoddrawGeoDataProvidersString(IntPtr pVd)
	{
		return (int)drawGeoDataProvidersString(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiViewportDraw>(pVd, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetMode(bool bEnable)
	{
		try
		{
			setMode(bEnable);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodgetMode()
	{
		return getMode();
	}
}

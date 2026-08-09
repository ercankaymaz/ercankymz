using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxDLinkerReactor : OdRxObject
{
	public delegate IntPtr SwigDelegateOdRxDLinkerReactor_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxDLinkerReactor_1();

	public delegate void SwigDelegateOdRxDLinkerReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdRxDLinkerReactor_3([MarshalAs(UnmanagedType.LPWStr)] string moduleName);

	public delegate void SwigDelegateOdRxDLinkerReactor_4(IntPtr pModule);

	public delegate void SwigDelegateOdRxDLinkerReactor_5([MarshalAs(UnmanagedType.LPWStr)] string moduleName);

	public delegate void SwigDelegateOdRxDLinkerReactor_6(IntPtr pModule);

	public delegate void SwigDelegateOdRxDLinkerReactor_7([MarshalAs(UnmanagedType.LPWStr)] string moduleName);

	public delegate void SwigDelegateOdRxDLinkerReactor_8(IntPtr pModule);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxDLinkerReactor_0 swigDelegate0;

	private SwigDelegateOdRxDLinkerReactor_1 swigDelegate1;

	private SwigDelegateOdRxDLinkerReactor_2 swigDelegate2;

	private SwigDelegateOdRxDLinkerReactor_3 swigDelegate3;

	private SwigDelegateOdRxDLinkerReactor_4 swigDelegate4;

	private SwigDelegateOdRxDLinkerReactor_5 swigDelegate5;

	private SwigDelegateOdRxDLinkerReactor_6 swigDelegate6;

	private SwigDelegateOdRxDLinkerReactor_7 swigDelegate7;

	private SwigDelegateOdRxDLinkerReactor_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxModule) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdRxModule) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdRxModule) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxDLinkerReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxDLinkerReactor obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxDLinkerReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdRxDLinkerReactor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxDLinkerReactor(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdRxDLinkerReactor cast(OdRxObject pObj)
	{
		OdRxDLinkerReactor rXObject = Helpers.GetRXObject<OdRxDLinkerReactor>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_isASwigExplicitOdRxDLinkerReactor(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_queryXSwigExplicitOdRxDLinkerReactor(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void rxAppWillBeLoaded(string moduleName)
	{
		if (SwigDerivedClassHasMethod("rxAppWillBeLoaded", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_rxAppWillBeLoadedSwigExplicitOdRxDLinkerReactor(swigCPtr, moduleName);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_rxAppWillBeLoaded(swigCPtr, moduleName);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rxAppLoaded(OdRxModule pModule)
	{
		if (SwigDerivedClassHasMethod("rxAppLoaded", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_rxAppLoadedSwigExplicitOdRxDLinkerReactor(swigCPtr, OdRxModule.getCPtr(pModule));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_rxAppLoaded(swigCPtr, OdRxModule.getCPtr(pModule));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rxAppLoadAborted(string moduleName)
	{
		if (SwigDerivedClassHasMethod("rxAppLoadAborted", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_rxAppLoadAbortedSwigExplicitOdRxDLinkerReactor(swigCPtr, moduleName);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_rxAppLoadAborted(swigCPtr, moduleName);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rxAppWillBeUnloaded(OdRxModule pModule)
	{
		if (SwigDerivedClassHasMethod("rxAppWillBeUnloaded", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_rxAppWillBeUnloadedSwigExplicitOdRxDLinkerReactor(swigCPtr, OdRxModule.getCPtr(pModule));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_rxAppWillBeUnloaded(swigCPtr, OdRxModule.getCPtr(pModule));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rxAppUnloaded(string moduleName)
	{
		if (SwigDerivedClassHasMethod("rxAppUnloaded", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_rxAppUnloadedSwigExplicitOdRxDLinkerReactor(swigCPtr, moduleName);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_rxAppUnloaded(swigCPtr, moduleName);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rxAppUnloadAborted(OdRxModule pModule)
	{
		if (SwigDerivedClassHasMethod("rxAppUnloadAborted", swigMethodTypes8))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_rxAppUnloadAbortedSwigExplicitOdRxDLinkerReactor(swigCPtr, OdRxModule.getCPtr(pModule));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_rxAppUnloadAborted(swigCPtr, OdRxModule.getCPtr(pModule));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxDLinkerReactor createObject()
	{
		OdRxDLinkerReactor rXObject = Helpers.GetRXObject<OdRxDLinkerReactor>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("rxAppWillBeLoaded", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodrxAppWillBeLoaded;
		}
		if (SwigDerivedClassHasMethod("rxAppLoaded", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodrxAppLoaded;
		}
		if (SwigDerivedClassHasMethod("rxAppLoadAborted", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodrxAppLoadAborted;
		}
		if (SwigDerivedClassHasMethod("rxAppWillBeUnloaded", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodrxAppWillBeUnloaded;
		}
		if (SwigDerivedClassHasMethod("rxAppUnloaded", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodrxAppUnloaded;
		}
		if (SwigDerivedClassHasMethod("rxAppUnloadAborted", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodrxAppUnloadAborted;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxDLinkerReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxDLinkerReactor));
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

	private void SwigDirectorMethodrxAppWillBeLoaded([MarshalAs(UnmanagedType.LPWStr)] string moduleName)
	{
		try
		{
			rxAppWillBeLoaded(moduleName);
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

	private void SwigDirectorMethodrxAppLoaded(IntPtr pModule)
	{
		try
		{
			rxAppLoaded(Helpers.GetRXObject<OdRxModule>(pModule, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodrxAppLoadAborted([MarshalAs(UnmanagedType.LPWStr)] string moduleName)
	{
		try
		{
			rxAppLoadAborted(moduleName);
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

	private void SwigDirectorMethodrxAppWillBeUnloaded(IntPtr pModule)
	{
		try
		{
			rxAppWillBeUnloaded(Helpers.GetRXObject<OdRxModule>(pModule, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodrxAppUnloaded([MarshalAs(UnmanagedType.LPWStr)] string moduleName)
	{
		try
		{
			rxAppUnloaded(moduleName);
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

	private void SwigDirectorMethodrxAppUnloadAborted(IntPtr pModule)
	{
		try
		{
			rxAppUnloadAborted(Helpers.GetRXObject<OdRxModule>(pModule, bOwn: false, bTryAddToTransaction: false));
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

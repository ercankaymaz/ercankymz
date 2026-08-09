using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBackgroundModule : OdRxModule
{
	public delegate IntPtr SwigDelegateOdGsBackgroundModule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsBackgroundModule_1();

	public delegate void SwigDelegateOdGsBackgroundModule_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGsBackgroundModule_3();

	public delegate void SwigDelegateOdGsBackgroundModule_4();

	public delegate void SwigDelegateOdGsBackgroundModule_5();

	public delegate void SwigDelegateOdGsBackgroundModule_6();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGsBackgroundModule_7();

	public delegate IntPtr SwigDelegateOdGsBackgroundModule_8(int type);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsBackgroundModule_0 swigDelegate0;

	private SwigDelegateOdGsBackgroundModule_1 swigDelegate1;

	private SwigDelegateOdGsBackgroundModule_2 swigDelegate2;

	private SwigDelegateOdGsBackgroundModule_3 swigDelegate3;

	private SwigDelegateOdGsBackgroundModule_4 swigDelegate4;

	private SwigDelegateOdGsBackgroundModule_5 swigDelegate5;

	private SwigDelegateOdGsBackgroundModule_6 swigDelegate6;

	private SwigDelegateOdGsBackgroundModule_7 swigDelegate7;

	private SwigDelegateOdGsBackgroundModule_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGsBackground_BackgroundType) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBackgroundModule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundModule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBackgroundModule obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBackgroundModule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsBackgroundModule cast(OdRxObject pObj)
	{
		OdGsBackgroundModule rXObject = Helpers.GetRXObject<OdGsBackgroundModule>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundModule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundModule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundModule_isASwigExplicitOdGsBackgroundModule(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundModule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundModule_queryXSwigExplicitOdGsBackgroundModule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundModule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsBackgroundModule createObject()
	{
		OdGsBackgroundModule rXObject = Helpers.GetRXObject<OdGsBackgroundModule>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundModule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsBackground createBackground(OdGsBackground_BackgroundType type)
	{
		OdGsBackground rXObject = Helpers.GetRXObject<OdGsBackground>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundModule_createBackground(swigCPtr, (int)type), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundModule_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("sysData", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsysData;
		}
		if (SwigDerivedClassHasMethod("deleteModule", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddeleteModule;
		}
		if (SwigDerivedClassHasMethod("initApp", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodinitApp;
		}
		if (SwigDerivedClassHasMethod("uninitApp", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoduninitApp;
		}
		if (SwigDerivedClassHasMethod("moduleName", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodmoduleName;
		}
		if (SwigDerivedClassHasMethod("createBackground", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcreateBackground;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundModule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsBackgroundModule));
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

	private IntPtr SwigDirectorMethodsysData()
	{
		return sysData();
	}

	private void SwigDirectorMethoddeleteModule()
	{
		try
		{
			deleteModule();
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

	private void SwigDirectorMethodinitApp()
	{
		try
		{
			initApp();
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

	private void SwigDirectorMethoduninitApp()
	{
		try
		{
			uninitApp();
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodmoduleName()
	{
		return moduleName();
	}

	private IntPtr SwigDirectorMethodcreateBackground(int type)
	{
		return OdGsBackground.getCPtr(createBackground((OdGsBackground_BackgroundType)type)).Handle;
	}
}

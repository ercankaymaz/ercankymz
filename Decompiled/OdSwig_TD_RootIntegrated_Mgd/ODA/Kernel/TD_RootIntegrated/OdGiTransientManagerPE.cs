using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiTransientManagerPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiTransientManagerPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiTransientManagerPE_1();

	public delegate void SwigDelegateOdGiTransientManagerPE_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiTransientManagerPE_3(IntPtr pThis);

	public delegate void SwigDelegateOdGiTransientManagerPE_4(IntPtr pThis, IntPtr pManager);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiTransientManagerPE_0 swigDelegate0;

	private SwigDelegateOdGiTransientManagerPE_1 swigDelegate1;

	private SwigDelegateOdGiTransientManagerPE_2 swigDelegate2;

	private SwigDelegateOdGiTransientManagerPE_3 swigDelegate3;

	private SwigDelegateOdGiTransientManagerPE_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGiTransientManager)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiTransientManagerPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManagerPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiTransientManagerPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiTransientManagerPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiTransientManagerPE cast(OdRxObject pObj)
	{
		OdGiTransientManagerPE rXObject = Helpers.GetRXObject<OdGiTransientManagerPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManagerPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManagerPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManagerPE_isASwigExplicitOdGiTransientManagerPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManagerPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManagerPE_queryXSwigExplicitOdGiTransientManagerPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManagerPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiTransientManagerPE createObject()
	{
		OdGiTransientManagerPE rXObject = Helpers.GetRXObject<OdGiTransientManagerPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManagerPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiTransientManager transientManager(OdRxObject pThis)
	{
		OdGiTransientManager rXObject = Helpers.GetRXObject<OdGiTransientManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManagerPE_transientManager(swigCPtr, OdRxObject.getCPtr(pThis)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setTransientManager(OdRxObject pThis, OdGiTransientManager pManager)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManagerPE_setTransientManager(swigCPtr, OdRxObject.getCPtr(pThis), OdGiTransientManager.getCPtr(pManager));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManagerPE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiTransientManagerPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiTransientManagerPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiTransientManagerPE) != GetType();
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
		if (SwigDerivedClassHasMethod("transientManager", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodtransientManager;
		}
		if (SwigDerivedClassHasMethod("setTransientManager", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetTransientManager;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManagerPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiTransientManagerPE));
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

	private IntPtr SwigDirectorMethodtransientManager(IntPtr pThis)
	{
		return OdGiTransientManager.getCPtr(transientManager(Helpers.GetRXObject<OdRxObject>(pThis, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private void SwigDirectorMethodsetTransientManager(IntPtr pThis, IntPtr pManager)
	{
		try
		{
			setTransientManager(Helpers.GetRXObject<OdRxObject>(pThis, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiTransientManager>(pManager, bOwn: false, bTryAddToTransaction: false));
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

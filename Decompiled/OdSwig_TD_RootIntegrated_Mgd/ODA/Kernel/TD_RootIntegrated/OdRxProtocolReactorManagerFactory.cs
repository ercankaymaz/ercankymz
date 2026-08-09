using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxProtocolReactorManagerFactory : OdRxObject
{
	public delegate IntPtr SwigDelegateOdRxProtocolReactorManagerFactory_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxProtocolReactorManagerFactory_1();

	public delegate void SwigDelegateOdRxProtocolReactorManagerFactory_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdRxProtocolReactorManagerFactory_3(IntPtr pRxClass);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxProtocolReactorManagerFactory_0 swigDelegate0;

	private SwigDelegateOdRxProtocolReactorManagerFactory_1 swigDelegate1;

	private SwigDelegateOdRxProtocolReactorManagerFactory_2 swigDelegate2;

	private SwigDelegateOdRxProtocolReactorManagerFactory_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxClass) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxProtocolReactorManagerFactory(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorManagerFactory_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxProtocolReactorManagerFactory obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxProtocolReactorManagerFactory(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxProtocolReactorManagerFactory cast(OdRxObject pObj)
	{
		OdRxProtocolReactorManagerFactory rXObject = Helpers.GetRXObject<OdRxProtocolReactorManagerFactory>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorManagerFactory_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorManagerFactory_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorManagerFactory_isASwigExplicitOdRxProtocolReactorManagerFactory(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorManagerFactory_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorManagerFactory_queryXSwigExplicitOdRxProtocolReactorManagerFactory(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorManagerFactory_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxProtocolReactorManagerFactory createObject()
	{
		OdRxProtocolReactorManagerFactory rXObject = Helpers.GetRXObject<OdRxProtocolReactorManagerFactory>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorManagerFactory_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxProtocolReactorManager createReactorManager(OdRxClass pRxClass)
	{
		OdRxProtocolReactorManager rXObject = Helpers.GetRXObject<OdRxProtocolReactorManager>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorManagerFactory_createReactorManager(swigCPtr, OdRxClass.getCPtr(pRxClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorManagerFactory_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxProtocolReactorManagerFactory()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxProtocolReactorManagerFactory(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxProtocolReactorManagerFactory) != GetType();
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
		if (SwigDerivedClassHasMethod("createReactorManager", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcreateReactorManager;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorManagerFactory_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxProtocolReactorManagerFactory));
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

	private IntPtr SwigDirectorMethodcreateReactorManager(IntPtr pRxClass)
	{
		return OdRxProtocolReactorManager.getCPtr(createReactorManager(Helpers.GetRXObject<OdRxClass>(pRxClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}
}

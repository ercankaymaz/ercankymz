using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbProxyExt : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbProxyExt_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbProxyExt_1();

	public delegate void SwigDelegateOdDbProxyExt_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbProxyExt_3(IntPtr pProxy);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbProxyExt_4(IntPtr pProxy);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbProxyExt_5(IntPtr pProxy);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbProxyExt_6(IntPtr pProxy);

	public delegate void SwigDelegateOdDbProxyExt_7(IntPtr pProxy, IntPtr ids);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbProxyExt_0 swigDelegate0;

	private SwigDelegateOdDbProxyExt_1 swigDelegate1;

	private SwigDelegateOdDbProxyExt_2 swigDelegate2;

	private SwigDelegateOdDbProxyExt_3 swigDelegate3;

	private SwigDelegateOdDbProxyExt_4 swigDelegate4;

	private SwigDelegateOdDbProxyExt_5 swigDelegate5;

	private SwigDelegateOdDbProxyExt_6 swigDelegate6;

	private SwigDelegateOdDbProxyExt_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdTypedIdsArray)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbProxyExt(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbProxyExt obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbProxyExt(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdDbProxyExt()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbProxyExt(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbProxyExt) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdDbProxyExt cast(OdRxObject pObj)
	{
		OdDbProxyExt rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbProxyExt>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_isASwigExplicitOdDbProxyExt(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_queryXSwigExplicitOdDbProxyExt(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbProxyExt createObject()
	{
		OdDbProxyExt rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbProxyExt>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual int proxyFlags(OdDbObject pProxy)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_proxyFlags(swigCPtr, OdDbObject.getCPtr(pProxy));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string originalClassName(OdDbObject pProxy)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_originalClassName(swigCPtr, OdDbObject.getCPtr(pProxy));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string originalDxfName(OdDbObject pProxy)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_originalDxfName(swigCPtr, OdDbObject.getCPtr(pProxy));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string applicationDescription(OdDbObject pProxy)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_applicationDescription(swigCPtr, OdDbObject.getCPtr(pProxy));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getReferences(OdDbObject pProxy, OdTypedIdsArray ids)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_getReferences(swigCPtr, OdDbObject.getCPtr(pProxy), OdTypedIdsArray.getCPtr(ids));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("proxyFlags", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodproxyFlags;
		}
		if (SwigDerivedClassHasMethod("originalClassName", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodoriginalClassName;
		}
		if (SwigDerivedClassHasMethod("originalDxfName", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodoriginalDxfName;
		}
		if (SwigDerivedClassHasMethod("applicationDescription", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodapplicationDescription;
		}
		if (SwigDerivedClassHasMethod("getReferences", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetReferences;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyExt_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbProxyExt));
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

	private int SwigDirectorMethodproxyFlags(IntPtr pProxy)
	{
		return proxyFlags(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pProxy, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodoriginalClassName(IntPtr pProxy)
	{
		return originalClassName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pProxy, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodoriginalDxfName(IntPtr pProxy)
	{
		return originalDxfName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pProxy, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodapplicationDescription(IntPtr pProxy)
	{
		return applicationDescription(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pProxy, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodgetReferences(IntPtr pProxy, IntPtr ids)
	{
		try
		{
			getReferences(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pProxy, bOwn: false, bTryAddToTransaction: false), new OdTypedIdsArray(ids, cMemoryOwn: false));
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
}

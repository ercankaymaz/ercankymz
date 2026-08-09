using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbObjectContextDefaultPE : OdDbObjectContextInterface
{
	public delegate IntPtr SwigDelegateOdDbObjectContextDefaultPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbObjectContextDefaultPE_1();

	public delegate void SwigDelegateOdDbObjectContextDefaultPE_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbObjectContextDefaultPE_3(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1);

	public delegate bool SwigDelegateOdDbObjectContextDefaultPE_4(IntPtr arg0, IntPtr arg1);

	public delegate int SwigDelegateOdDbObjectContextDefaultPE_5(IntPtr arg0, IntPtr arg1);

	public delegate int SwigDelegateOdDbObjectContextDefaultPE_6(IntPtr arg0, IntPtr arg1);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbObjectContextDefaultPE_0 swigDelegate0;

	private SwigDelegateOdDbObjectContextDefaultPE_1 swigDelegate1;

	private SwigDelegateOdDbObjectContextDefaultPE_2 swigDelegate2;

	private SwigDelegateOdDbObjectContextDefaultPE_3 swigDelegate3;

	private SwigDelegateOdDbObjectContextDefaultPE_4 swigDelegate4;

	private SwigDelegateOdDbObjectContextDefaultPE_5 swigDelegate5;

	private SwigDelegateOdDbObjectContextDefaultPE_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObjectContext)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObjectContext)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObjectContext)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbObjectContextDefaultPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbObjectContextDefaultPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbObjectContextDefaultPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbObjectContextDefaultPE cast(OdRxObject pObj)
	{
		OdDbObjectContextDefaultPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextDefaultPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_isASwigExplicitOdDbObjectContextDefaultPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_queryXSwigExplicitOdDbObjectContextDefaultPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdResult addContext(OdDbObject arg0, OdDbObjectContext arg1)
	{
		int result = (SwigDerivedClassHasMethod("addContext", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_addContextSwigExplicitOdDbObjectContextDefaultPE(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContext.getCPtr(arg1)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_addContext(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContext.getCPtr(arg1)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override bool hasContext(OdDbObject arg0, OdDbObjectContext arg1)
	{
		bool result = (SwigDerivedClassHasMethod("hasContext", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_hasContextSwigExplicitOdDbObjectContextDefaultPE(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContext.getCPtr(arg1)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_hasContext(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContext.getCPtr(arg1)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult removeContext(OdDbObject arg0, OdDbObjectContext arg1)
	{
		int result = (SwigDerivedClassHasMethod("removeContext", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_removeContextSwigExplicitOdDbObjectContextDefaultPE(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContext.getCPtr(arg1)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_removeContext(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContext.getCPtr(arg1)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override bool supportsCollection(OdDbObject arg0, string arg1)
	{
		bool result = (SwigDerivedClassHasMethod("supportsCollection", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_supportsCollectionSwigExplicitOdDbObjectContextDefaultPE(swigCPtr, OdDbObject.getCPtr(arg0), arg1) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_supportsCollection(swigCPtr, OdDbObject.getCPtr(arg0), arg1));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbObjectContextDefaultPE createObject()
	{
		OdDbObjectContextDefaultPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextDefaultPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("supportsCollection", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsupportsCollection;
		}
		if (SwigDerivedClassHasMethod("hasContext", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodhasContext;
		}
		if (SwigDerivedClassHasMethod("addContext", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodaddContext;
		}
		if (SwigDerivedClassHasMethod("removeContext", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodremoveContext;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDefaultPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbObjectContextDefaultPE));
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

	private bool SwigDirectorMethodsupportsCollection(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1)
	{
		return supportsCollection(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), arg1);
	}

	private bool SwigDirectorMethodhasContext(IntPtr arg0, IntPtr arg1)
	{
		return hasContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(arg1, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodaddContext(IntPtr arg0, IntPtr arg1)
	{
		return (int)addContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(arg1, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodremoveContext(IntPtr arg0, IntPtr arg1)
	{
		return (int)removeContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(arg1, bOwn: false, bTryAddToTransaction: false));
	}
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbObjectContextDimPE : OdDbObjectContextPE
{
	public delegate IntPtr SwigDelegateOdDbObjectContextDimPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbObjectContextDimPE_1();

	public delegate void SwigDelegateOdDbObjectContextDimPE_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbObjectContextDimPE_3(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1);

	public delegate bool SwigDelegateOdDbObjectContextDimPE_4(IntPtr arg0, IntPtr arg1);

	public delegate int SwigDelegateOdDbObjectContextDimPE_5(IntPtr pObject, IntPtr ctx);

	public delegate int SwigDelegateOdDbObjectContextDimPE_6(IntPtr arg0, IntPtr arg1);

	public delegate int SwigDelegateOdDbObjectContextDimPE_7(IntPtr arg0, IntPtr arg1);

	public delegate IntPtr SwigDelegateOdDbObjectContextDimPE_8(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1);

	public delegate IntPtr SwigDelegateOdDbObjectContextDimPE_9(IntPtr pObj, IntPtr ctx, IntPtr def);

	public delegate IntPtr SwigDelegateOdDbObjectContextDimPE_10(IntPtr arg0, IntPtr arg1);

	public delegate void SwigDelegateOdDbObjectContextDimPE_11(IntPtr pObj);

	public delegate void SwigDelegateOdDbObjectContextDimPE_12(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1);

	public delegate bool SwigDelegateOdDbObjectContextDimPE_13(IntPtr arg0, IntPtr arg1);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbObjectContextDimPE_0 swigDelegate0;

	private SwigDelegateOdDbObjectContextDimPE_1 swigDelegate1;

	private SwigDelegateOdDbObjectContextDimPE_2 swigDelegate2;

	private SwigDelegateOdDbObjectContextDimPE_3 swigDelegate3;

	private SwigDelegateOdDbObjectContextDimPE_4 swigDelegate4;

	private SwigDelegateOdDbObjectContextDimPE_5 swigDelegate5;

	private SwigDelegateOdDbObjectContextDimPE_6 swigDelegate6;

	private SwigDelegateOdDbObjectContextDimPE_7 swigDelegate7;

	private SwigDelegateOdDbObjectContextDimPE_8 swigDelegate8;

	private SwigDelegateOdDbObjectContextDimPE_9 swigDelegate9;

	private SwigDelegateOdDbObjectContextDimPE_10 swigDelegate10;

	private SwigDelegateOdDbObjectContextDimPE_11 swigDelegate11;

	private SwigDelegateOdDbObjectContextDimPE_12 swigDelegate12;

	private SwigDelegateOdDbObjectContextDimPE_13 swigDelegate13;

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

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObjectContext)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes9 = new Type[3]
	{
		typeof(OdDbObject),
		typeof(OdDbObjectContext),
		typeof(OdDbObjectContext)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObjectContext)
	};

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObjectContextData)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbObjectContextDimPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbObjectContextDimPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbObjectContextDimPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbObjectContextDimPE cast(OdRxObject pObj)
	{
		OdDbObjectContextDimPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextDimPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_isASwigExplicitOdDbObjectContextDimPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_queryXSwigExplicitOdDbObjectContextDimPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbObjectContextDimPE createObject()
	{
		OdDbObjectContextDimPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextDimPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdResult addContext(OdDbObject pObject, OdDbObjectContext ctx)
	{
		int result = (SwigDerivedClassHasMethod("addContext", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_addContextSwigExplicitOdDbObjectContextDimPE(swigCPtr, OdDbObject.getCPtr(pObject), OdDbObjectContext.getCPtr(ctx)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_addContext(swigCPtr, OdDbObject.getCPtr(pObject), OdDbObjectContext.getCPtr(ctx)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override bool isValidContextData(OdDbObject arg0, OdDbObjectContextData arg1)
	{
		bool result = (SwigDerivedClassHasMethod("isValidContextData", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_isValidContextDataSwigExplicitOdDbObjectContextDimPE(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContextData.getCPtr(arg1)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_isValidContextData(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContextData.getCPtr(arg1)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("setDefaultContext", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetDefaultContext;
		}
		if (SwigDerivedClassHasMethod("getDefaultContextData", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetDefaultContextData;
		}
		if (SwigDerivedClassHasMethod("createContextData", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcreateContextData;
		}
		if (SwigDerivedClassHasMethod("getContextData", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetContextData;
		}
		if (SwigDerivedClassHasMethod("compose", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcompose;
		}
		if (SwigDerivedClassHasMethod("removeAllContexts", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodremoveAllContexts;
		}
		if (SwigDerivedClassHasMethod("isValidContextData", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodisValidContextData;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDimPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbObjectContextDimPE));
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

	private int SwigDirectorMethodaddContext(IntPtr pObject, IntPtr ctx)
	{
		return (int)addContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(ctx, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodremoveContext(IntPtr arg0, IntPtr arg1)
	{
		return (int)removeContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(arg1, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodsetDefaultContext(IntPtr arg0, IntPtr arg1)
	{
		return (int)setDefaultContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(arg1, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodgetDefaultContextData(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1)
	{
		return OdDbObjectContextData.getCPtr(getDefaultContextData(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), arg1)).Handle;
	}

	private IntPtr SwigDirectorMethodcreateContextData(IntPtr pObj, IntPtr ctx, IntPtr def)
	{
		return OdDbObjectContextData.getCPtr(createContextData(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObj, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(ctx, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(def, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetContextData(IntPtr arg0, IntPtr arg1)
	{
		return OdDbObjectContextData.getCPtr(getContextData(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(arg1, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private void SwigDirectorMethodcompose(IntPtr pObj)
	{
		try
		{
			compose(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObj, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodremoveAllContexts(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1)
	{
		try
		{
			removeAllContexts(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), arg1);
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

	private bool SwigDirectorMethodisValidContextData(IntPtr arg0, IntPtr arg1)
	{
		return isValidContextData(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextData>(arg1, bOwn: false, bTryAddToTransaction: false));
	}
}

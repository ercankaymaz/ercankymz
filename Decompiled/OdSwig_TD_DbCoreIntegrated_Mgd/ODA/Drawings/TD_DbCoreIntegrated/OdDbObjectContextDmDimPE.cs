using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbObjectContextDmDimPE : OdDbObjectContextDimPE
{
	public delegate IntPtr SwigDelegateOdDbObjectContextDmDimPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbObjectContextDmDimPE_1();

	public delegate void SwigDelegateOdDbObjectContextDmDimPE_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbObjectContextDmDimPE_3(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1);

	public delegate bool SwigDelegateOdDbObjectContextDmDimPE_4(IntPtr arg0, IntPtr arg1);

	public delegate int SwigDelegateOdDbObjectContextDmDimPE_5(IntPtr pObject, IntPtr ctx);

	public delegate int SwigDelegateOdDbObjectContextDmDimPE_6(IntPtr arg0, IntPtr arg1);

	public delegate int SwigDelegateOdDbObjectContextDmDimPE_7(IntPtr arg0, IntPtr arg1);

	public delegate IntPtr SwigDelegateOdDbObjectContextDmDimPE_8(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1);

	public delegate IntPtr SwigDelegateOdDbObjectContextDmDimPE_9(IntPtr arg0, IntPtr arg1, IntPtr def);

	public delegate IntPtr SwigDelegateOdDbObjectContextDmDimPE_10(IntPtr arg0, IntPtr arg1);

	public delegate void SwigDelegateOdDbObjectContextDmDimPE_11(IntPtr pObj);

	public delegate void SwigDelegateOdDbObjectContextDmDimPE_12(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1);

	public delegate bool SwigDelegateOdDbObjectContextDmDimPE_13(IntPtr arg0, IntPtr arg1);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbObjectContextDmDimPE_0 swigDelegate0;

	private SwigDelegateOdDbObjectContextDmDimPE_1 swigDelegate1;

	private SwigDelegateOdDbObjectContextDmDimPE_2 swigDelegate2;

	private SwigDelegateOdDbObjectContextDmDimPE_3 swigDelegate3;

	private SwigDelegateOdDbObjectContextDmDimPE_4 swigDelegate4;

	private SwigDelegateOdDbObjectContextDmDimPE_5 swigDelegate5;

	private SwigDelegateOdDbObjectContextDmDimPE_6 swigDelegate6;

	private SwigDelegateOdDbObjectContextDmDimPE_7 swigDelegate7;

	private SwigDelegateOdDbObjectContextDmDimPE_8 swigDelegate8;

	private SwigDelegateOdDbObjectContextDmDimPE_9 swigDelegate9;

	private SwigDelegateOdDbObjectContextDmDimPE_10 swigDelegate10;

	private SwigDelegateOdDbObjectContextDmDimPE_11 swigDelegate11;

	private SwigDelegateOdDbObjectContextDmDimPE_12 swigDelegate12;

	private SwigDelegateOdDbObjectContextDmDimPE_13 swigDelegate13;

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
	public OdDbObjectContextDmDimPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbObjectContextDmDimPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbObjectContextDmDimPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbObjectContextDmDimPE cast(OdRxObject pObj)
	{
		OdDbObjectContextDmDimPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextDmDimPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_isASwigExplicitOdDbObjectContextDmDimPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_queryXSwigExplicitOdDbObjectContextDmDimPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdDbObjectContextData createContextData(OdDbObject arg0, OdDbObjectContext arg1, OdDbObjectContext def)
	{
		OdDbObjectContextData rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextData>(SwigDerivedClassHasMethod("createContextData", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_createContextDataSwigExplicitOdDbObjectContextDmDimPE(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContext.getCPtr(arg1), OdDbObjectContext.getCPtr(def)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_createContextData(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContext.getCPtr(arg1), OdDbObjectContext.getCPtr(def)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override bool isValidContextData(OdDbObject arg0, OdDbObjectContextData arg1)
	{
		bool result = (SwigDerivedClassHasMethod("isValidContextData", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_isValidContextDataSwigExplicitOdDbObjectContextDmDimPE(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContextData.getCPtr(arg1)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_isValidContextData(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContextData.getCPtr(arg1)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbObjectContextDmDimPE createObject()
	{
		OdDbObjectContextDmDimPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextDmDimPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextDmDimPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbObjectContextDmDimPE));
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

	private IntPtr SwigDirectorMethodcreateContextData(IntPtr arg0, IntPtr arg1, IntPtr def)
	{
		return OdDbObjectContextData.getCPtr(createContextData(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(arg1, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(def, bOwn: false, bTryAddToTransaction: false))).Handle;
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

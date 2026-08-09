using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbObjectContextMTextPE : OdDbObjectContextPE
{
	public delegate IntPtr SwigDelegateOdDbObjectContextMTextPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbObjectContextMTextPE_1();

	public delegate void SwigDelegateOdDbObjectContextMTextPE_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbObjectContextMTextPE_3(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1);

	public delegate bool SwigDelegateOdDbObjectContextMTextPE_4(IntPtr arg0, IntPtr arg1);

	public delegate int SwigDelegateOdDbObjectContextMTextPE_5(IntPtr arg0, IntPtr arg1);

	public delegate int SwigDelegateOdDbObjectContextMTextPE_6(IntPtr arg0, IntPtr arg1);

	public delegate int SwigDelegateOdDbObjectContextMTextPE_7(IntPtr arg0, IntPtr arg1);

	public delegate IntPtr SwigDelegateOdDbObjectContextMTextPE_8(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1);

	public delegate IntPtr SwigDelegateOdDbObjectContextMTextPE_9(IntPtr arg0, IntPtr arg1, IntPtr def);

	public delegate IntPtr SwigDelegateOdDbObjectContextMTextPE_10(IntPtr arg0, IntPtr arg1);

	public delegate void SwigDelegateOdDbObjectContextMTextPE_11(IntPtr pObj);

	public delegate void SwigDelegateOdDbObjectContextMTextPE_12(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1);

	public delegate bool SwigDelegateOdDbObjectContextMTextPE_13(IntPtr arg0, IntPtr arg1);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbObjectContextMTextPE_0 swigDelegate0;

	private SwigDelegateOdDbObjectContextMTextPE_1 swigDelegate1;

	private SwigDelegateOdDbObjectContextMTextPE_2 swigDelegate2;

	private SwigDelegateOdDbObjectContextMTextPE_3 swigDelegate3;

	private SwigDelegateOdDbObjectContextMTextPE_4 swigDelegate4;

	private SwigDelegateOdDbObjectContextMTextPE_5 swigDelegate5;

	private SwigDelegateOdDbObjectContextMTextPE_6 swigDelegate6;

	private SwigDelegateOdDbObjectContextMTextPE_7 swigDelegate7;

	private SwigDelegateOdDbObjectContextMTextPE_8 swigDelegate8;

	private SwigDelegateOdDbObjectContextMTextPE_9 swigDelegate9;

	private SwigDelegateOdDbObjectContextMTextPE_10 swigDelegate10;

	private SwigDelegateOdDbObjectContextMTextPE_11 swigDelegate11;

	private SwigDelegateOdDbObjectContextMTextPE_12 swigDelegate12;

	private SwigDelegateOdDbObjectContextMTextPE_13 swigDelegate13;

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
	public OdDbObjectContextMTextPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbObjectContextMTextPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbObjectContextMTextPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbObjectContextMTextPE cast(OdRxObject pObj)
	{
		OdDbObjectContextMTextPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextMTextPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_isASwigExplicitOdDbObjectContextMTextPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_queryXSwigExplicitOdDbObjectContextMTextPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdDbObjectContextData createContextData(OdDbObject arg0, OdDbObjectContext arg1, OdDbObjectContext def)
	{
		OdDbObjectContextData rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextData>(SwigDerivedClassHasMethod("createContextData", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_createContextDataSwigExplicitOdDbObjectContextMTextPE(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContext.getCPtr(arg1), OdDbObjectContext.getCPtr(def)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_createContextData(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContext.getCPtr(arg1), OdDbObjectContext.getCPtr(def)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override bool isValidContextData(OdDbObject arg0, OdDbObjectContextData arg1)
	{
		bool result = (SwigDerivedClassHasMethod("isValidContextData", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_isValidContextDataSwigExplicitOdDbObjectContextMTextPE(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContextData.getCPtr(arg1)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_isValidContextData(swigCPtr, OdDbObject.getCPtr(arg0), OdDbObjectContextData.getCPtr(arg1)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbObjectContextMTextPE createObject()
	{
		OdDbObjectContextMTextPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextMTextPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextMTextPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbObjectContextMTextPE));
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

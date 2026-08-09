using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbCommandContext : OdEdCommandContext
{
	public delegate IntPtr SwigDelegateOdDbCommandContext_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbCommandContext_1();

	public delegate void SwigDelegateOdDbCommandContext_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdDbCommandContext_3();

	public delegate IntPtr SwigDelegateOdDbCommandContext_4();

	public delegate IntPtr SwigDelegateOdDbCommandContext_5();

	public delegate void SwigDelegateOdDbCommandContext_6([MarshalAs(UnmanagedType.LPWStr)] string szPathName, IntPtr pDataObj);

	public delegate IntPtr SwigDelegateOdDbCommandContext_7([MarshalAs(UnmanagedType.LPWStr)] string szPathName);

	public delegate void SwigDelegateOdDbCommandContext_8(IntPtr arg0, IntPtr arg1);

	public delegate IntPtr SwigDelegateOdDbCommandContext_9();

	public delegate IntPtr SwigDelegateOdDbCommandContext_10(IntPtr arg0, IntPtr arg1);

	public delegate IntPtr SwigDelegateOdDbCommandContext_11(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdDbCommandContext_12();

	public delegate IntPtr SwigDelegateOdDbCommandContext_13();

	public delegate IntPtr SwigDelegateOdDbCommandContext_14();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbCommandContext_0 swigDelegate0;

	private SwigDelegateOdDbCommandContext_1 swigDelegate1;

	private SwigDelegateOdDbCommandContext_2 swigDelegate2;

	private SwigDelegateOdDbCommandContext_3 swigDelegate3;

	private SwigDelegateOdDbCommandContext_4 swigDelegate4;

	private SwigDelegateOdDbCommandContext_5 swigDelegate5;

	private SwigDelegateOdDbCommandContext_6 swigDelegate6;

	private SwigDelegateOdDbCommandContext_7 swigDelegate7;

	private SwigDelegateOdDbCommandContext_8 swigDelegate8;

	private SwigDelegateOdDbCommandContext_9 swigDelegate9;

	private SwigDelegateOdDbCommandContext_10 swigDelegate10;

	private SwigDelegateOdDbCommandContext_11 swigDelegate11;

	private SwigDelegateOdDbCommandContext_12 swigDelegate12;

	private SwigDelegateOdDbCommandContext_13 swigDelegate13;

	private SwigDelegateOdDbCommandContext_14 swigDelegate14;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(string),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdEdBaseIO),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdEdBaseIO),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdEdBaseIO) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbCommandContext(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbCommandContext obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbCommandContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbCommandContext cast(OdRxObject pObj)
	{
		OdDbCommandContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCommandContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_isASwigExplicitOdDbCommandContext(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_queryXSwigExplicitOdDbCommandContext(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbCommandContext createObject()
	{
		OdDbCommandContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCommandContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase database()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("database", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_databaseSwigExplicitOdDbCommandContext(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbUserIO dbUserIO()
	{
		OdDbUserIO rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUserIO>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_dbUserIO(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResult registerCommandContext(OdDbDatabase db, OdDbCommandContext dbctx)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_registerCommandContext(OdDbDatabase.getCPtr(db), getCPtr(dbctx));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdDbCommandContext registredCommandContext(OdDbDatabase db)
	{
		OdDbCommandContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCommandContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_registredCommandContext(OdDbDatabase.getCPtr(db)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbHostAppServices appServices()
	{
		OdDbHostAppServices rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbHostAppServices>(SwigDerivedClassHasMethod("appServices", swigMethodTypes14) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_appServicesSwigExplicitOdDbCommandContext(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_appServices(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbCommandContext()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbCommandContext(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbCommandContext) != GetType();
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
		if (SwigDerivedClassHasMethod("userIO", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoduserIO;
		}
		if (SwigDerivedClassHasMethod("funcIO", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodfuncIO;
		}
		if (SwigDerivedClassHasMethod("baseDatabase", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodbaseDatabase;
		}
		if (SwigDerivedClassHasMethod("setArbitraryData", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetArbitraryData;
		}
		if (SwigDerivedClassHasMethod("arbitraryData", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodarbitraryData;
		}
		if (SwigDerivedClassHasMethod("reset", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodreset;
		}
		if (SwigDerivedClassHasMethod("baseIO", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodbaseIO;
		}
		if (SwigDerivedClassHasMethod("cloneObject", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcloneObject__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("cloneObject", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcloneObject__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("cloneObject", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodcloneObject__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("database", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethoddatabase;
		}
		if (SwigDerivedClassHasMethod("appServices", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodappServices;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCommandContext_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbCommandContext));
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

	private IntPtr SwigDirectorMethoduserIO()
	{
		return OdEdUserIO.getCPtr(userIO()).Handle;
	}

	private IntPtr SwigDirectorMethodfuncIO()
	{
		return OdEdFunctionIO.getCPtr(funcIO()).Handle;
	}

	private IntPtr SwigDirectorMethodbaseDatabase()
	{
		return OdRxObject.getCPtr(baseDatabase()).Handle;
	}

	private void SwigDirectorMethodsetArbitraryData([MarshalAs(UnmanagedType.LPWStr)] string szPathName, IntPtr pDataObj)
	{
		try
		{
			setArbitraryData(szPathName, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDataObj, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodarbitraryData([MarshalAs(UnmanagedType.LPWStr)] string szPathName)
	{
		return OdRxObject.getCPtr(arbitraryData(szPathName)).Handle;
	}

	private void SwigDirectorMethodreset(IntPtr arg0, IntPtr arg1)
	{
		try
		{
			reset(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdBaseIO>(arg0, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(arg1, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodbaseIO()
	{
		return OdEdBaseIO.getCPtr(baseIO()).Handle;
	}

	private IntPtr SwigDirectorMethodcloneObject__SWIG_0(IntPtr arg0, IntPtr arg1)
	{
		return OdEdCommandContext.getCPtr(cloneObject(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdBaseIO>(arg0, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(arg1, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcloneObject__SWIG_1(IntPtr arg0)
	{
		return OdEdCommandContext.getCPtr(cloneObject(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdBaseIO>(arg0, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcloneObject__SWIG_2()
	{
		return OdEdCommandContext.getCPtr(cloneObject()).Handle;
	}

	private IntPtr SwigDirectorMethoddatabase()
	{
		return OdDbDatabase.getCPtr(database()).Handle;
	}

	private IntPtr SwigDirectorMethodappServices()
	{
		return OdDbHostAppServices.getCPtr(appServices()).Handle;
	}
}

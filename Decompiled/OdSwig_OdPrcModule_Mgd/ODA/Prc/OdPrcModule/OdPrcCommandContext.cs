using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcCommandContext : OdEdCommandContext
{
	public delegate IntPtr SwigDelegateOdPrcCommandContext_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcCommandContext_1();

	public delegate void SwigDelegateOdPrcCommandContext_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdPrcCommandContext_3();

	public delegate IntPtr SwigDelegateOdPrcCommandContext_4();

	public delegate IntPtr SwigDelegateOdPrcCommandContext_5();

	public delegate void SwigDelegateOdPrcCommandContext_6([MarshalAs(UnmanagedType.LPWStr)] string szPathName, IntPtr pDataObj);

	public delegate IntPtr SwigDelegateOdPrcCommandContext_7([MarshalAs(UnmanagedType.LPWStr)] string szPathName);

	public delegate void SwigDelegateOdPrcCommandContext_8(IntPtr arg0, IntPtr arg1);

	public delegate IntPtr SwigDelegateOdPrcCommandContext_9();

	public delegate IntPtr SwigDelegateOdPrcCommandContext_10(IntPtr arg0, IntPtr arg1);

	public delegate IntPtr SwigDelegateOdPrcCommandContext_11(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdPrcCommandContext_12();

	public delegate IntPtr SwigDelegateOdPrcCommandContext_13();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcCommandContext_0 swigDelegate0;

	private SwigDelegateOdPrcCommandContext_1 swigDelegate1;

	private SwigDelegateOdPrcCommandContext_2 swigDelegate2;

	private SwigDelegateOdPrcCommandContext_3 swigDelegate3;

	private SwigDelegateOdPrcCommandContext_4 swigDelegate4;

	private SwigDelegateOdPrcCommandContext_5 swigDelegate5;

	private SwigDelegateOdPrcCommandContext_6 swigDelegate6;

	private SwigDelegateOdPrcCommandContext_7 swigDelegate7;

	private SwigDelegateOdPrcCommandContext_8 swigDelegate8;

	private SwigDelegateOdPrcCommandContext_9 swigDelegate9;

	private SwigDelegateOdPrcCommandContext_10 swigDelegate10;

	private SwigDelegateOdPrcCommandContext_11 swigDelegate11;

	private SwigDelegateOdPrcCommandContext_12 swigDelegate12;

	private SwigDelegateOdPrcCommandContext_13 swigDelegate13;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcCommandContext(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcCommandContext obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcCommandContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPrcCommandContext cast(OdRxObject pObj)
	{
		OdPrcCommandContext rXObject = Helpers.GetRXObject<OdPrcCommandContext>(OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_isASwigExplicitOdPrcCommandContext(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_queryXSwigExplicitOdPrcCommandContext(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcCommandContext createObject()
	{
		OdPrcCommandContext rXObject = Helpers.GetRXObject<OdPrcCommandContext>(OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdPrcFile database()
	{
		OdPrcFile rXObject = Helpers.GetRXObject<OdPrcFile>(SwigDerivedClassHasMethod("database", swigMethodTypes13) ? OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_databaseSwigExplicitOdPrcCommandContext(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdEdBaseUserIO dbUserIO()
	{
		OdEdBaseUserIO rXObject = Helpers.GetRXObject<OdEdBaseUserIO>(OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_dbUserIO(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcCommandContext()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcCommandContext(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcCommandContext) != GetType();
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
		OdPrcModule_GlobalsPINVOKE.OdPrcCommandContext_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcCommandContext));
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			setArbitraryData(szPathName, Helpers.GetRXObject<OdRxObject>(pDataObj, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			reset(Helpers.GetRXObject<OdEdBaseIO>(arg0, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(arg1, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodbaseIO()
	{
		return OdEdBaseIO.getCPtr(baseIO()).Handle;
	}

	private IntPtr SwigDirectorMethodcloneObject__SWIG_0(IntPtr arg0, IntPtr arg1)
	{
		return OdEdCommandContext.getCPtr(cloneObject(Helpers.GetRXObject<OdEdBaseIO>(arg0, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(arg1, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcloneObject__SWIG_1(IntPtr arg0)
	{
		return OdEdCommandContext.getCPtr(cloneObject(Helpers.GetRXObject<OdEdBaseIO>(arg0, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcloneObject__SWIG_2()
	{
		return OdEdCommandContext.getCPtr(cloneObject()).Handle;
	}

	private IntPtr SwigDirectorMethoddatabase()
	{
		return OdPrcFile.getCPtr(database()).Handle;
	}
}

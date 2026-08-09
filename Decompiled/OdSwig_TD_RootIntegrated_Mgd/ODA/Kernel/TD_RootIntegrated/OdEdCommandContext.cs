using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdEdCommandContext : OdRxObject
{
	public delegate IntPtr SwigDelegateOdEdCommandContext_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdEdCommandContext_1();

	public delegate void SwigDelegateOdEdCommandContext_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdEdCommandContext_3();

	public delegate IntPtr SwigDelegateOdEdCommandContext_4();

	public delegate IntPtr SwigDelegateOdEdCommandContext_5();

	public delegate void SwigDelegateOdEdCommandContext_6([MarshalAs(UnmanagedType.LPWStr)] string szPathName, IntPtr pDataObj);

	public delegate IntPtr SwigDelegateOdEdCommandContext_7([MarshalAs(UnmanagedType.LPWStr)] string szPathName);

	public delegate void SwigDelegateOdEdCommandContext_8(IntPtr arg0, IntPtr arg1);

	public delegate IntPtr SwigDelegateOdEdCommandContext_9();

	public delegate IntPtr SwigDelegateOdEdCommandContext_10(IntPtr arg0, IntPtr arg1);

	public delegate IntPtr SwigDelegateOdEdCommandContext_11(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdEdCommandContext_12();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdEdCommandContext_0 swigDelegate0;

	private SwigDelegateOdEdCommandContext_1 swigDelegate1;

	private SwigDelegateOdEdCommandContext_2 swigDelegate2;

	private SwigDelegateOdEdCommandContext_3 swigDelegate3;

	private SwigDelegateOdEdCommandContext_4 swigDelegate4;

	private SwigDelegateOdEdCommandContext_5 swigDelegate5;

	private SwigDelegateOdEdCommandContext_6 swigDelegate6;

	private SwigDelegateOdEdCommandContext_7 swigDelegate7;

	private SwigDelegateOdEdCommandContext_8 swigDelegate8;

	private SwigDelegateOdEdCommandContext_9 swigDelegate9;

	private SwigDelegateOdEdCommandContext_10 swigDelegate10;

	private SwigDelegateOdEdCommandContext_11 swigDelegate11;

	private SwigDelegateOdEdCommandContext_12 swigDelegate12;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdEdCommandContext(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdEdCommandContext obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdEdCommandContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdEdCommandContext cast(OdRxObject pObj)
	{
		OdEdCommandContext rXObject = Helpers.GetRXObject<OdEdCommandContext>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_isASwigExplicitOdEdCommandContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_queryXSwigExplicitOdEdCommandContext(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdEdCommandContext createObject()
	{
		OdEdCommandContext rXObject = Helpers.GetRXObject<OdEdCommandContext>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdUserIO userIO()
	{
		OdEdUserIO rXObject = Helpers.GetRXObject<OdEdUserIO>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_userIO(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdFunctionIO funcIO()
	{
		OdEdFunctionIO rXObject = Helpers.GetRXObject<OdEdFunctionIO>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_funcIO(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject baseDatabase()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_baseDatabase(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setArbitraryData(string szPathName, OdRxObject pDataObj)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_setArbitraryData(swigCPtr, szPathName, OdRxObject.getCPtr(pDataObj));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject arbitraryData(string szPathName)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_arbitraryData(swigCPtr, szPathName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void reset(OdEdBaseIO arg0, OdRxObject arg1)
	{
		if (SwigDerivedClassHasMethod("reset", swigMethodTypes8))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_resetSwigExplicitOdEdCommandContext(swigCPtr, OdEdBaseIO.getCPtr(arg0), OdRxObject.getCPtr(arg1));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_reset(swigCPtr, OdEdBaseIO.getCPtr(arg0), OdRxObject.getCPtr(arg1));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdEdBaseIO baseIO()
	{
		OdEdBaseIO rXObject = Helpers.GetRXObject<OdEdBaseIO>(SwigDerivedClassHasMethod("baseIO", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_baseIOSwigExplicitOdEdCommandContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_baseIO(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdCommandContext cloneObject(OdEdBaseIO arg0, OdRxObject arg1)
	{
		OdEdCommandContext rXObject = Helpers.GetRXObject<OdEdCommandContext>(SwigDerivedClassHasMethod("cloneObject", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_cloneObjectSwigExplicitOdEdCommandContext__SWIG_0(swigCPtr, OdEdBaseIO.getCPtr(arg0), OdRxObject.getCPtr(arg1)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_cloneObject__SWIG_0(swigCPtr, OdEdBaseIO.getCPtr(arg0), OdRxObject.getCPtr(arg1)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdCommandContext cloneObject(OdEdBaseIO arg0)
	{
		OdEdCommandContext rXObject = Helpers.GetRXObject<OdEdCommandContext>(SwigDerivedClassHasMethod("cloneObject", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_cloneObjectSwigExplicitOdEdCommandContext__SWIG_1(swigCPtr, OdEdBaseIO.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_cloneObject__SWIG_1(swigCPtr, OdEdBaseIO.getCPtr(arg0)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdCommandContext cloneObject()
	{
		OdEdCommandContext rXObject = Helpers.GetRXObject<OdEdCommandContext>(SwigDerivedClassHasMethod("cloneObject", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_cloneObjectSwigExplicitOdEdCommandContext__SWIG_2(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_cloneObject__SWIG_2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdEdCommandContext()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdEdCommandContext(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdEdCommandContext) != GetType();
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
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandContext_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdEdCommandContext));
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

	private IntPtr SwigDirectorMethodbaseIO()
	{
		return OdEdBaseIO.getCPtr(baseIO()).Handle;
	}

	private IntPtr SwigDirectorMethodcloneObject__SWIG_0(IntPtr arg0, IntPtr arg1)
	{
		return getCPtr(cloneObject(Helpers.GetRXObject<OdEdBaseIO>(arg0, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(arg1, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcloneObject__SWIG_1(IntPtr arg0)
	{
		return getCPtr(cloneObject(Helpers.GetRXObject<OdEdBaseIO>(arg0, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcloneObject__SWIG_2()
	{
		return getCPtr(cloneObject()).Handle;
	}
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class TxErrorContext : OdErrorContext
{
	public delegate IntPtr SwigDelegateTxErrorContext_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateTxErrorContext_1();

	public delegate void SwigDelegateTxErrorContext_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateTxErrorContext_3();

	public delegate int SwigDelegateTxErrorContext_4();

	public delegate int SwigDelegateTxErrorContext_5();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateTxErrorContext_6();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateTxErrorContext_0 swigDelegate0;

	private SwigDelegateTxErrorContext_1 swigDelegate1;

	private SwigDelegateTxErrorContext_2 swigDelegate2;

	private SwigDelegateTxErrorContext_3 swigDelegate3;

	private SwigDelegateTxErrorContext_4 swigDelegate4;

	private SwigDelegateTxErrorContext_5 swigDelegate5;

	private SwigDelegateTxErrorContext_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TxErrorContext(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TxErrorContext obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_TxErrorContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public TxErrorContext()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_TxErrorContext(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(TxErrorContext) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdErrorContext init(string name, int nCode, string desc)
	{
		OdErrorContext rXObject = Helpers.GetRXObject<OdErrorContext>(TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_init__SWIG_0(swigCPtr, name, nCode, desc), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdErrorContext init(string name, int nCode)
	{
		OdErrorContext rXObject = Helpers.GetRXObject<OdErrorContext>(TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_init__SWIG_1(swigCPtr, name, nCode), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override string description()
	{
		string result = (SwigDerivedClassHasMethod("description", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_descriptionSwigExplicitTxErrorContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_description(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult code()
	{
		int result = (SwigDerivedClassHasMethod("code", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_codeSwigExplicitTxErrorContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_code(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual int txAppCode()
	{
		int result = (SwigDerivedClassHasMethod("txAppCode", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_txAppCodeSwigExplicitTxErrorContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_txAppCode(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string txAppName()
	{
		string result = (SwigDerivedClassHasMethod("txAppName", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_txAppNameSwigExplicitTxErrorContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_txAppName(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TxErrorContext createObject()
	{
		TxErrorContext rXObject = Helpers.GetRXObject<TxErrorContext>(TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("description", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddescription;
		}
		if (SwigDerivedClassHasMethod("code", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcode;
		}
		if (SwigDerivedClassHasMethod("txAppCode", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodtxAppCode;
		}
		if (SwigDerivedClassHasMethod("txAppName", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodtxAppName;
		}
		TD_RootIntegrated_GlobalsPINVOKE.TxErrorContext_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(TxErrorContext));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethoddescription()
	{
		return description();
	}

	private int SwigDirectorMethodcode()
	{
		return (int)code();
	}

	private int SwigDirectorMethodtxAppCode()
	{
		return txAppCode();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodtxAppName()
	{
		return txAppName();
	}
}

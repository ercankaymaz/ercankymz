using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdTfObjectPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdTfObjectPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdTfObjectPE_1();

	public delegate void SwigDelegateOdTfObjectPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdTfObjectPE_3(IntPtr arg0);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdTfObjectPE_4(IntPtr arg0);

	public delegate bool SwigDelegateOdTfObjectPE_5(IntPtr arg0, IntPtr arg1);

	public delegate void SwigDelegateOdTfObjectPE_6(IntPtr arg0, IntPtr arg1);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdTfObjectPE_0 swigDelegate0;

	private SwigDelegateOdTfObjectPE_1 swigDelegate1;

	private SwigDelegateOdTfObjectPE_2 swigDelegate2;

	private SwigDelegateOdTfObjectPE_3 swigDelegate3;

	private SwigDelegateOdTfObjectPE_4 swigDelegate4;

	private SwigDelegateOdTfObjectPE_5 swigDelegate5;

	private SwigDelegateOdTfObjectPE_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdTfFiler)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdTfFiler)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdTfObjectPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdTfObjectPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdTfObjectPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdTfObjectPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdTfObjectPE_isASwigExplicitOdTfObjectPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdTfObjectPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdTfObjectPE_queryXSwigExplicitOdTfObjectPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdTfObjectPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual int schemaVersion(OdRxObject arg0)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdTfObjectPE_schemaVersion(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string schema(OdRxObject arg0)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdTfObjectPE_schema(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool in_(OdRxObject arg0, OdTfFiler arg1)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTfObjectPE_in_(swigCPtr, OdRxObject.getCPtr(arg0), OdTfFiler.getCPtr(arg1));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void out_(OdRxObject arg0, OdTfFiler arg1)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTfObjectPE_out_(swigCPtr, OdRxObject.getCPtr(arg0), OdTfFiler.getCPtr(arg1));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdTfObjectPE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdTfObjectPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdTfObjectPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdTfObjectPE) != GetType();
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
		if (SwigDerivedClassHasMethod("schemaVersion", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodschemaVersion;
		}
		if (SwigDerivedClassHasMethod("schema", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodschema;
		}
		if (SwigDerivedClassHasMethod("in_", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodin_;
		}
		if (SwigDerivedClassHasMethod("out_", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodout_;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdTfObjectPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdTfObjectPE));
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

	private int SwigDirectorMethodschemaVersion(IntPtr arg0)
	{
		return schemaVersion(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodschema(IntPtr arg0)
	{
		return schema(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodin_(IntPtr arg0, IntPtr arg1)
	{
		return in_(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), (arg1 == IntPtr.Zero) ? null : new OdTfFiler(arg1, cMemoryOwn: false));
	}

	private void SwigDirectorMethodout_(IntPtr arg0, IntPtr arg1)
	{
		try
		{
			out_(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), (arg1 == IntPtr.Zero) ? null : new OdTfFiler(arg1, cMemoryOwn: false));
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
}

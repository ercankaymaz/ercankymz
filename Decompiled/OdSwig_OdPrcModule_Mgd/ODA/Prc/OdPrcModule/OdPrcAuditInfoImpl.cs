using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcAuditInfoImpl : OdPrcAuditInfo
{
	public delegate IntPtr SwigDelegateOdPrcAuditInfoImpl_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcAuditInfoImpl_1();

	public delegate void SwigDelegateOdPrcAuditInfoImpl_2(IntPtr pSource);

	public delegate void SwigDelegateOdPrcAuditInfoImpl_3([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation, [MarshalAs(UnmanagedType.LPWStr)] string defaultValue);

	public delegate void SwigDelegateOdPrcAuditInfoImpl_4([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation);

	public delegate void SwigDelegateOdPrcAuditInfoImpl_5([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate void SwigDelegateOdPrcAuditInfoImpl_6([MarshalAs(UnmanagedType.LPWStr)] string logInfo);

	public delegate bool SwigDelegateOdPrcAuditInfoImpl_7();

	public delegate void SwigDelegateOdPrcAuditInfoImpl_8();

	public delegate IntPtr SwigDelegateOdPrcAuditInfoImpl_9();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcAuditInfoImpl_0 swigDelegate0;

	private SwigDelegateOdPrcAuditInfoImpl_1 swigDelegate1;

	private SwigDelegateOdPrcAuditInfoImpl_2 swigDelegate2;

	private SwigDelegateOdPrcAuditInfoImpl_3 swigDelegate3;

	private SwigDelegateOdPrcAuditInfoImpl_4 swigDelegate4;

	private SwigDelegateOdPrcAuditInfoImpl_5 swigDelegate5;

	private SwigDelegateOdPrcAuditInfoImpl_6 swigDelegate6;

	private SwigDelegateOdPrcAuditInfoImpl_7 swigDelegate7;

	private SwigDelegateOdPrcAuditInfoImpl_8 swigDelegate8;

	private SwigDelegateOdPrcAuditInfoImpl_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcAuditInfoImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcAuditInfoImpl obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcAuditInfoImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcAuditInfoImpl()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcAuditInfoImpl(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcAuditInfoImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPrcAuditInfoImpl cast(OdRxObject pObj)
	{
		OdPrcAuditInfoImpl rXObject = Helpers.GetRXObject<OdPrcAuditInfoImpl>(OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_isASwigExplicitOdPrcAuditInfoImpl(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_queryXSwigExplicitOdPrcAuditInfoImpl(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcAuditInfoImpl createObject()
	{
		OdPrcAuditInfoImpl rXObject = Helpers.GetRXObject<OdPrcAuditInfoImpl>(OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void printError(string name, string value, string validation, string defaultValue)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes3))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_printErrorSwigExplicitOdPrcAuditInfoImpl__SWIG_0(swigCPtr, name, value, validation, defaultValue);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_printError__SWIG_0(swigCPtr, name, value, validation, defaultValue);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void printError(string name, string value, string validation)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes4))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_printErrorSwigExplicitOdPrcAuditInfoImpl__SWIG_1(swigCPtr, name, value, validation);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_printError__SWIG_1(swigCPtr, name, value, validation);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void printError(string name, string value)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes5))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_printErrorSwigExplicitOdPrcAuditInfoImpl__SWIG_2(swigCPtr, name, value);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_printError__SWIG_2(swigCPtr, name, value);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void printInfo(string logInfo)
	{
		if (SwigDerivedClassHasMethod("printInfo", swigMethodTypes6))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_printInfoSwigExplicitOdPrcAuditInfoImpl(swigCPtr, logInfo);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_printInfo(swigCPtr, logInfo);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool errorsFound()
	{
		bool result = (SwigDerivedClassHasMethod("errorsFound", swigMethodTypes7) ? OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_errorsFoundSwigExplicitOdPrcAuditInfoImpl(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_errorsFound(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clearErrors()
	{
		if (SwigDerivedClassHasMethod("clearErrors", swigMethodTypes8))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_clearErrorsSwigExplicitOdPrcAuditInfoImpl(swigCPtr);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_clearErrors(swigCPtr);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdStringArray errorInfo()
	{
		OdStringArray result = new OdStringArray(SwigDerivedClassHasMethod("errorInfo", swigMethodTypes9) ? OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_errorInfoSwigExplicitOdPrcAuditInfoImpl(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_errorInfo(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodprintError__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodprintError__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodprintError__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("printInfo", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodprintInfo;
		}
		if (SwigDerivedClassHasMethod("errorsFound", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoderrorsFound;
		}
		if (SwigDerivedClassHasMethod("clearErrors", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodclearErrors;
		}
		if (SwigDerivedClassHasMethod("errorInfo", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethoderrorInfo;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfoImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcAuditInfoImpl));
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

	private void SwigDirectorMethodprintError__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation, [MarshalAs(UnmanagedType.LPWStr)] string defaultValue)
	{
		try
		{
			printError(name, value, validation, defaultValue);
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

	private void SwigDirectorMethodprintError__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation)
	{
		try
		{
			printError(name, value, validation);
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

	private void SwigDirectorMethodprintError__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value)
	{
		try
		{
			printError(name, value);
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

	private void SwigDirectorMethodprintInfo([MarshalAs(UnmanagedType.LPWStr)] string logInfo)
	{
		try
		{
			printInfo(logInfo);
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

	private bool SwigDirectorMethoderrorsFound()
	{
		return errorsFound();
	}

	private void SwigDirectorMethodclearErrors()
	{
		try
		{
			clearErrors();
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

	private IntPtr SwigDirectorMethoderrorInfo()
	{
		return OdStringArray.getCPtr(errorInfo()).Handle;
	}
}

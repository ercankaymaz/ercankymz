using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcAuditInfo : OdRxObject
{
	public delegate IntPtr SwigDelegateOdPrcAuditInfo_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcAuditInfo_1();

	public delegate void SwigDelegateOdPrcAuditInfo_2(IntPtr pSource);

	public delegate void SwigDelegateOdPrcAuditInfo_3([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation, [MarshalAs(UnmanagedType.LPWStr)] string defaultValue);

	public delegate void SwigDelegateOdPrcAuditInfo_4([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation);

	public delegate void SwigDelegateOdPrcAuditInfo_5([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate void SwigDelegateOdPrcAuditInfo_6([MarshalAs(UnmanagedType.LPWStr)] string logInfo);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcAuditInfo_0 swigDelegate0;

	private SwigDelegateOdPrcAuditInfo_1 swigDelegate1;

	private SwigDelegateOdPrcAuditInfo_2 swigDelegate2;

	private SwigDelegateOdPrcAuditInfo_3 swigDelegate3;

	private SwigDelegateOdPrcAuditInfo_4 swigDelegate4;

	private SwigDelegateOdPrcAuditInfo_5 swigDelegate5;

	private SwigDelegateOdPrcAuditInfo_6 swigDelegate6;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcAuditInfo(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcAuditInfo obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcAuditInfo(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcAuditInfo()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcAuditInfo(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcAuditInfo) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPrcAuditInfo cast(OdRxObject pObj)
	{
		OdPrcAuditInfo rXObject = Helpers.GetRXObject<OdPrcAuditInfo>(OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_isASwigExplicitOdPrcAuditInfo(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_queryXSwigExplicitOdPrcAuditInfo(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPrcAuditInfo createObject()
	{
		OdPrcAuditInfo rXObject = Helpers.GetRXObject<OdPrcAuditInfo>(OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool fixErrors()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_fixErrors(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFixErrors(bool bFix)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_setFixErrors(swigCPtr, bFix);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void printError(string name, string value, string validation, string defaultValue)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes3))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_printErrorSwigExplicitOdPrcAuditInfo__SWIG_0(swigCPtr, name, value, validation, defaultValue);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_printError__SWIG_0(swigCPtr, name, value, validation, defaultValue);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void printError(string name, string value, string validation)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes4))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_printErrorSwigExplicitOdPrcAuditInfo__SWIG_1(swigCPtr, name, value, validation);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_printError__SWIG_1(swigCPtr, name, value, validation);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void printError(string name, string value)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes5))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_printErrorSwigExplicitOdPrcAuditInfo__SWIG_2(swigCPtr, name, value);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_printError__SWIG_2(swigCPtr, name, value);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void printInfo(string logInfo)
	{
		if (SwigDerivedClassHasMethod("printInfo", swigMethodTypes6))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_printInfoSwigExplicitOdPrcAuditInfo(swigCPtr, logInfo);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_printInfo(swigCPtr, logInfo);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_getRealClassName(ptr);
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
		OdPrcModule_GlobalsPINVOKE.OdPrcAuditInfo_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcAuditInfo));
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
}

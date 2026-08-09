using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbAuditInfo : OdAuditInfo
{
	public delegate void SwigDelegateOdDbAuditInfo_0([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation, [MarshalAs(UnmanagedType.LPWStr)] string defaultValue);

	public delegate void SwigDelegateOdDbAuditInfo_1([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation);

	public delegate void SwigDelegateOdDbAuditInfo_2([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate void SwigDelegateOdDbAuditInfo_3(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation, [MarshalAs(UnmanagedType.LPWStr)] string defaultValue);

	public delegate void SwigDelegateOdDbAuditInfo_4(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation);

	public delegate void SwigDelegateOdDbAuditInfo_5(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate void SwigDelegateOdDbAuditInfo_6([MarshalAs(UnmanagedType.LPWStr)] string logInfo);

	public delegate IntPtr SwigDelegateOdDbAuditInfo_7();

	public delegate void SwigDelegateOdDbAuditInfo_8(IntPtr lastInfo);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbAuditInfo_0 swigDelegate0;

	private SwigDelegateOdDbAuditInfo_1 swigDelegate1;

	private SwigDelegateOdDbAuditInfo_2 swigDelegate2;

	private SwigDelegateOdDbAuditInfo_3 swigDelegate3;

	private SwigDelegateOdDbAuditInfo_4 swigDelegate4;

	private SwigDelegateOdDbAuditInfo_5 swigDelegate5;

	private SwigDelegateOdDbAuditInfo_6 swigDelegate6;

	private SwigDelegateOdDbAuditInfo_7 swigDelegate7;

	private SwigDelegateOdDbAuditInfo_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[4]
	{
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes1 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes2 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(OdRxObject),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(MsgInfo) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbAuditInfo(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbAuditInfo obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbAuditInfo(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override void printError(string name, string value, string validation, string defaultValue)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes0))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_printErrorSwigExplicitOdDbAuditInfo__SWIG_0(swigCPtr, name, value, validation, defaultValue);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_printError__SWIG_0(swigCPtr, name, value, validation, defaultValue);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void printError(string name, string value, string validation)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes1))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_printErrorSwigExplicitOdDbAuditInfo__SWIG_1(swigCPtr, name, value, validation);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_printError__SWIG_1(swigCPtr, name, value, validation);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void printError(string name, string value)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes2))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_printErrorSwigExplicitOdDbAuditInfo__SWIG_2(swigCPtr, name, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_printError__SWIG_2(swigCPtr, name, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void printError(OdRxObject pObject, string value, string validation, string defaultValue)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_printErrorSwigExplicitOdDbAuditInfo__SWIG_3(swigCPtr, OdRxObject.getCPtr(pObject), value, validation, defaultValue);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_printError__SWIG_3(swigCPtr, OdRxObject.getCPtr(pObject), value, validation, defaultValue);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void printError(OdRxObject pObject, string value, string validation)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_printErrorSwigExplicitOdDbAuditInfo__SWIG_4(swigCPtr, OdRxObject.getCPtr(pObject), value, validation);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_printError__SWIG_4(swigCPtr, OdRxObject.getCPtr(pObject), value, validation);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void printError(OdRxObject pObject, string value)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_printErrorSwigExplicitOdDbAuditInfo__SWIG_5(swigCPtr, OdRxObject.getCPtr(pObject), value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_printError__SWIG_5(swigCPtr, OdRxObject.getCPtr(pObject), value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbAuditInfo()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbAuditInfo(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbAuditInfo) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodprintError__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodprintError__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodprintError__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodprintError__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodprintError__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodprintError__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("printInfo", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodprintInfo;
		}
		if (SwigDerivedClassHasMethod("getLastInfo", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetLastInfo;
		}
		if (SwigDerivedClassHasMethod("setLastInfo", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetLastInfo;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAuditInfo_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbAuditInfo));
	}

	private void SwigDirectorMethodprintError__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation, [MarshalAs(UnmanagedType.LPWStr)] string defaultValue)
	{
		try
		{
			printError(name, value, validation, defaultValue);
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

	private void SwigDirectorMethodprintError__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation)
	{
		try
		{
			printError(name, value, validation);
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

	private void SwigDirectorMethodprintError__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value)
	{
		try
		{
			printError(name, value);
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

	private void SwigDirectorMethodprintError__SWIG_3(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation, [MarshalAs(UnmanagedType.LPWStr)] string defaultValue)
	{
		try
		{
			printError(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), value, validation, defaultValue);
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

	private void SwigDirectorMethodprintError__SWIG_4(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation)
	{
		try
		{
			printError(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), value, validation);
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

	private void SwigDirectorMethodprintError__SWIG_5(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string value)
	{
		try
		{
			printError(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), value);
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

	private void SwigDirectorMethodprintInfo([MarshalAs(UnmanagedType.LPWStr)] string logInfo)
	{
		try
		{
			printInfo(logInfo);
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

	private IntPtr SwigDirectorMethodgetLastInfo()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return MsgInfo.getCPtr(getLastInfo()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetLastInfo(IntPtr lastInfo)
	{
		try
		{
			setLastInfo(new MsgInfo(lastInfo, cMemoryOwn: false));
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
}

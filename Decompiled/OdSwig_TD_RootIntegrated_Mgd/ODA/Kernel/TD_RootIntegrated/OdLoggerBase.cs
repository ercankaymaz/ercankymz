using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdLoggerBase : IDisposable
{
	public delegate void SwigDelegateOdLoggerBase_0([MarshalAs(UnmanagedType.LPWStr)] string msg);

	public delegate void SwigDelegateOdLoggerBase_1([MarshalAs(UnmanagedType.LPWStr)] string wrn);

	public delegate void SwigDelegateOdLoggerBase_2([MarshalAs(UnmanagedType.LPWStr)] string err);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdLoggerBase_0 swigDelegate0;

	private SwigDelegateOdLoggerBase_1 swigDelegate1;

	private SwigDelegateOdLoggerBase_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(string) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdLoggerBase(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdLoggerBase obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdLoggerBase()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdLoggerBase(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void logMessage(string msg)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdLoggerBase_logMessage(swigCPtr, msg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void logWarning(string wrn)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdLoggerBase_logWarning(swigCPtr, wrn);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void logError(string err)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdLoggerBase_logError(swigCPtr, err);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdLoggerBase()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdLoggerBase(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdLoggerBase) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("logMessage", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodlogMessage;
		}
		if (SwigDerivedClassHasMethod("logWarning", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodlogWarning;
		}
		if (SwigDerivedClassHasMethod("logError", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodlogError;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdLoggerBase_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdLoggerBase));
	}

	private void SwigDirectorMethodlogMessage([MarshalAs(UnmanagedType.LPWStr)] string msg)
	{
		try
		{
			logMessage(msg);
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

	private void SwigDirectorMethodlogWarning([MarshalAs(UnmanagedType.LPWStr)] string wrn)
	{
		try
		{
			logWarning(wrn);
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

	private void SwigDirectorMethodlogError([MarshalAs(UnmanagedType.LPWStr)] string err)
	{
		try
		{
			logError(err);
		}
		catch (OdEdEmptyInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdEdOtherInput err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (OdError err4)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err4);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}

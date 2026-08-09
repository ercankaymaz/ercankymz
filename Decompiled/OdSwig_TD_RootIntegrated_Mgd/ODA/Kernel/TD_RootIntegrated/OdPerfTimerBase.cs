using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdPerfTimerBase : IDisposable
{
	public delegate void SwigDelegateOdPerfTimerBase_0();

	public delegate void SwigDelegateOdPerfTimerBase_1();

	public delegate void SwigDelegateOdPerfTimerBase_2();

	public delegate void SwigDelegateOdPerfTimerBase_3();

	public delegate void SwigDelegateOdPerfTimerBase_4();

	public delegate double SwigDelegateOdPerfTimerBase_5();

	public delegate uint SwigDelegateOdPerfTimerBase_6();

	public delegate double SwigDelegateOdPerfTimerBase_7();

	public delegate uint SwigDelegateOdPerfTimerBase_8();

	public delegate bool SwigDelegateOdPerfTimerBase_9();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdPerfTimerBase_0 swigDelegate0;

	private SwigDelegateOdPerfTimerBase_1 swigDelegate1;

	private SwigDelegateOdPerfTimerBase_2 swigDelegate2;

	private SwigDelegateOdPerfTimerBase_3 swigDelegate3;

	private SwigDelegateOdPerfTimerBase_4 swigDelegate4;

	private SwigDelegateOdPerfTimerBase_5 swigDelegate5;

	private SwigDelegateOdPerfTimerBase_6 swigDelegate6;

	private SwigDelegateOdPerfTimerBase_7 swigDelegate7;

	private SwigDelegateOdPerfTimerBase_8 swigDelegate8;

	private SwigDelegateOdPerfTimerBase_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPerfTimerBase(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPerfTimerBase obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPerfTimerBase()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdPerfTimerBase(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPerfTimerBase()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdPerfTimerBase(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPerfTimerBase) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual void initialize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_initialize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void destroy()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_destroy(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void start()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_start(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void stop()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_stop(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double countedSec()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_countedSec(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint countedMSec()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_countedMSec(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double permanentSec()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_permanentSec(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint permanentMSec()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_permanentMSec(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isStarted()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_isStarted(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdPerfTimerBase createTiming()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_createTiming();
		OdPerfTimerBase result = ((intPtr == IntPtr.Zero) ? null : new OdPerfTimerBase(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void destroyTiming(OdPerfTimerBase ptr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_destroyTiming(getCPtr(ptr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("initialize", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodinitialize;
		}
		if (SwigDerivedClassHasMethod("destroy", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethoddestroy;
		}
		if (SwigDerivedClassHasMethod("clear", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodclear;
		}
		if (SwigDerivedClassHasMethod("start", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodstart;
		}
		if (SwigDerivedClassHasMethod("stop", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodstop;
		}
		if (SwigDerivedClassHasMethod("countedSec", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcountedSec;
		}
		if (SwigDerivedClassHasMethod("countedMSec", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcountedMSec;
		}
		if (SwigDerivedClassHasMethod("permanentSec", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodpermanentSec;
		}
		if (SwigDerivedClassHasMethod("permanentMSec", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodpermanentMSec;
		}
		if (SwigDerivedClassHasMethod("isStarted", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodisStarted;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdPerfTimerBase_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPerfTimerBase));
	}

	private void SwigDirectorMethodinitialize()
	{
		try
		{
			initialize();
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

	private void SwigDirectorMethoddestroy()
	{
		try
		{
			destroy();
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

	private void SwigDirectorMethodclear()
	{
		try
		{
			clear();
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

	private void SwigDirectorMethodstart()
	{
		try
		{
			start();
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

	private void SwigDirectorMethodstop()
	{
		try
		{
			stop();
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

	private double SwigDirectorMethodcountedSec()
	{
		return countedSec();
	}

	private uint SwigDirectorMethodcountedMSec()
	{
		return countedMSec();
	}

	private double SwigDirectorMethodpermanentSec()
	{
		return permanentSec();
	}

	private uint SwigDirectorMethodpermanentMSec()
	{
		return permanentMSec();
	}

	private bool SwigDirectorMethodisStarted()
	{
		return isStarted();
	}
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPointCloudTimerBasedScheduler : OdGiPointCloudScheduler
{
	public delegate void SwigDelegateOdGiPointCloudTimerBasedScheduler_0();

	public delegate void SwigDelegateOdGiPointCloudTimerBasedScheduler_1();

	public delegate int SwigDelegateOdGiPointCloudTimerBasedScheduler_2(bool bFinal);

	public delegate int SwigDelegateOdGiPointCloudTimerBasedScheduler_3();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiPointCloudTimerBasedScheduler_0 swigDelegate0;

	private SwigDelegateOdGiPointCloudTimerBasedScheduler_1 swigDelegate1;

	private SwigDelegateOdGiPointCloudTimerBasedScheduler_2 swigDelegate2;

	private SwigDelegateOdGiPointCloudTimerBasedScheduler_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes3 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPointCloudTimerBasedScheduler(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudTimerBasedScheduler_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPointCloudTimerBasedScheduler obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPointCloudTimerBasedScheduler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiPointCloudTimerBasedScheduler()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPointCloudTimerBasedScheduler(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiPointCloudTimerBasedScheduler) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override void startScheduling()
	{
		if (SwigDerivedClassHasMethod("startScheduling", swigMethodTypes0))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudTimerBasedScheduler_startSchedulingSwigExplicitOdGiPointCloudTimerBasedScheduler(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudTimerBasedScheduler_startScheduling(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void stopScheduling()
	{
		if (SwigDerivedClassHasMethod("stopScheduling", swigMethodTypes1))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudTimerBasedScheduler_stopSchedulingSwigExplicitOdGiPointCloudTimerBasedScheduler(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudTimerBasedScheduler_stopScheduling(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTimerPeriod(uint msec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudTimerBasedScheduler_setTimerPeriod(swigCPtr, msec);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint timerPeriod()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudTimerBasedScheduler_timerPeriod(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiPointCloudScheduler_SchedulerState checkSchedulerState(bool bFinal)
	{
		int result = (SwigDerivedClassHasMethod("checkSchedulerState", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudTimerBasedScheduler_checkSchedulerStateSwigExplicitOdGiPointCloudTimerBasedScheduler__SWIG_0(swigCPtr, bFinal) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudTimerBasedScheduler_checkSchedulerState__SWIG_0(swigCPtr, bFinal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiPointCloudScheduler_SchedulerState)result;
	}

	public override OdGiPointCloudScheduler_SchedulerState checkSchedulerState()
	{
		int result = (SwigDerivedClassHasMethod("checkSchedulerState", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudTimerBasedScheduler_checkSchedulerStateSwigExplicitOdGiPointCloudTimerBasedScheduler__SWIG_1(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudTimerBasedScheduler_checkSchedulerState__SWIG_1(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiPointCloudScheduler_SchedulerState)result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("startScheduling", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodstartScheduling;
		}
		if (SwigDerivedClassHasMethod("stopScheduling", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodstopScheduling;
		}
		if (SwigDerivedClassHasMethod("checkSchedulerState", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcheckSchedulerState__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("checkSchedulerState", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcheckSchedulerState__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudTimerBasedScheduler_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPointCloudTimerBasedScheduler));
	}

	private void SwigDirectorMethodstartScheduling()
	{
		try
		{
			startScheduling();
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

	private void SwigDirectorMethodstopScheduling()
	{
		try
		{
			stopScheduling();
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

	private int SwigDirectorMethodcheckSchedulerState__SWIG_0(bool bFinal)
	{
		return (int)checkSchedulerState(bFinal);
	}

	private int SwigDirectorMethodcheckSchedulerState__SWIG_1()
	{
		return (int)checkSchedulerState();
	}
}

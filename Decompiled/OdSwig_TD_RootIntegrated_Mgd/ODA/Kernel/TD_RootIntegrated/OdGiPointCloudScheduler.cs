using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPointCloudScheduler : IDisposable
{
	public delegate void SwigDelegateOdGiPointCloudScheduler_0();

	public delegate void SwigDelegateOdGiPointCloudScheduler_1();

	public delegate int SwigDelegateOdGiPointCloudScheduler_2(bool bFinal);

	public delegate int SwigDelegateOdGiPointCloudScheduler_3();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiPointCloudScheduler_0 swigDelegate0;

	private SwigDelegateOdGiPointCloudScheduler_1 swigDelegate1;

	private SwigDelegateOdGiPointCloudScheduler_2 swigDelegate2;

	private SwigDelegateOdGiPointCloudScheduler_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes3 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPointCloudScheduler(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPointCloudScheduler obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiPointCloudScheduler()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPointCloudScheduler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiPointCloudScheduler()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPointCloudScheduler(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiPointCloudScheduler) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual void startScheduling()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudScheduler_startScheduling(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void stopScheduling()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudScheduler_stopScheduling(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiPointCloudScheduler_SchedulerState checkSchedulerState(bool bFinal)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudScheduler_checkSchedulerState__SWIG_0(swigCPtr, bFinal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiPointCloudScheduler_SchedulerState)result;
	}

	public virtual OdGiPointCloudScheduler_SchedulerState checkSchedulerState()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudScheduler_checkSchedulerState__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiPointCloudScheduler_SchedulerState)result;
	}

	public bool onTaskAdded()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudScheduler_onTaskAdded(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool onTaskCompleted()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudScheduler_onTaskCompleted(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numTasks()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudScheduler_numTasks(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudScheduler_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPointCloudScheduler));
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

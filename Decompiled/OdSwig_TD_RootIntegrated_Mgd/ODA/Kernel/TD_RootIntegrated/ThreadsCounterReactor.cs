using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class ThreadsCounterReactor : IDisposable
{
	public delegate void SwigDelegateThreadsCounterReactor_0(uint arg0, IntPtr arg1, uint arg2);

	public delegate void SwigDelegateThreadsCounterReactor_1(uint arg0, IntPtr arg1, uint arg2);

	public delegate void SwigDelegateThreadsCounterReactor_2(uint arg0, uint arg1);

	public delegate void SwigDelegateThreadsCounterReactor_3(uint arg0, uint arg1);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateThreadsCounterReactor_0 swigDelegate0;

	private SwigDelegateThreadsCounterReactor_1 swigDelegate1;

	private SwigDelegateThreadsCounterReactor_2 swigDelegate2;

	private SwigDelegateThreadsCounterReactor_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[3]
	{
		typeof(uint),
		typeof(uint[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes1 = new Type[3]
	{
		typeof(uint),
		typeof(uint[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes2 = new Type[2]
	{
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(uint),
		typeof(uint)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public ThreadsCounterReactor(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(ThreadsCounterReactor obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~ThreadsCounterReactor()
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
	}

	public virtual void increase(uint arg0, uint[] arg1, uint arg2)
	{
		if (SwigDerivedClassHasMethod("increase", swigMethodTypes0))
		{
			TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounterReactor_increaseSwigExplicitThreadsCounterReactor(swigCPtr, arg0, Helpers.MarshalUInt32FixedArray(arg1), arg2);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounterReactor_increase(swigCPtr, arg0, Helpers.MarshalUInt32FixedArray(arg1), arg2);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void decrease(uint arg0, uint[] arg1, uint arg2)
	{
		if (SwigDerivedClassHasMethod("decrease", swigMethodTypes1))
		{
			TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounterReactor_decreaseSwigExplicitThreadsCounterReactor(swigCPtr, arg0, Helpers.MarshalUInt32FixedArray(arg1), arg2);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounterReactor_decrease(swigCPtr, arg0, Helpers.MarshalUInt32FixedArray(arg1), arg2);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void startThread(uint arg0, uint arg1)
	{
		if (SwigDerivedClassHasMethod("startThread", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounterReactor_startThreadSwigExplicitThreadsCounterReactor(swigCPtr, arg0, arg1);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounterReactor_startThread(swigCPtr, arg0, arg1);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void stopThread(uint arg0, uint arg1)
	{
		if (SwigDerivedClassHasMethod("stopThread", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounterReactor_stopThreadSwigExplicitThreadsCounterReactor(swigCPtr, arg0, arg1);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounterReactor_stopThread(swigCPtr, arg0, arg1);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("increase", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodincrease;
		}
		if (SwigDerivedClassHasMethod("decrease", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethoddecrease;
		}
		if (SwigDerivedClassHasMethod("startThread", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodstartThread;
		}
		if (SwigDerivedClassHasMethod("stopThread", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodstopThread;
		}
		TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounterReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(ThreadsCounterReactor));
	}

	private void SwigDirectorMethodincrease(uint arg0, IntPtr arg1, uint arg2)
	{
		try
		{
			increase(arg0, Helpers.UnMarshalUInt32FixedArray(arg1), arg2);
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

	private void SwigDirectorMethoddecrease(uint arg0, IntPtr arg1, uint arg2)
	{
		try
		{
			decrease(arg0, Helpers.UnMarshalUInt32FixedArray(arg1), arg2);
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

	private void SwigDirectorMethodstartThread(uint arg0, uint arg1)
	{
		try
		{
			startThread(arg0, arg1);
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

	private void SwigDirectorMethodstopThread(uint arg0, uint arg1)
	{
		try
		{
			stopThread(arg0, arg1);
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

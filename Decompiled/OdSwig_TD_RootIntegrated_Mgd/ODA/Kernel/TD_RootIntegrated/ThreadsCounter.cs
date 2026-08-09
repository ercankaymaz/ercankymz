using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class ThreadsCounter : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public ThreadsCounter(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(ThreadsCounter obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~ThreadsCounter()
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

	public bool addReactor(ThreadsCounterReactor pReactor)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_addReactor(swigCPtr, ThreadsCounterReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool removeReactor(ThreadsCounterReactor pReactor)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_removeReactor(swigCPtr, ThreadsCounterReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasReactor(ThreadsCounterReactor pReactor)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_hasReactor(swigCPtr, ThreadsCounterReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int nReactors()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_nReactors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setThreadPoolService(OdRxThreadPoolService pService)
	{
		TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_setThreadPoolService(swigCPtr, OdRxThreadPoolService.getCPtr(pService));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxThreadPoolService getThreadPoolService()
	{
		OdRxThreadPoolService rXObject = Helpers.GetRXObject<OdRxThreadPoolService>(TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_getThreadPoolService(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void increase(uint nThreads, uint[] aThreads, uint nThreadAttributes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_increase__SWIG_0(swigCPtr, nThreads, Helpers.MarshalUInt32FixedArray(aThreads), nThreadAttributes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void increase(uint nThreads, uint[] aThreads)
	{
		TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_increase__SWIG_1(swigCPtr, nThreads, Helpers.MarshalUInt32FixedArray(aThreads));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void decrease(uint nThreads, uint[] aThreads)
	{
		TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_decrease(swigCPtr, nThreads, Helpers.MarshalUInt32FixedArray(aThreads));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void startThread()
	{
		TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_startThread(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void stopThread()
	{
		TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_stopThread(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasThread(uint nThreadId, uint[] pThreadAttributes)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_hasThread(swigCPtr, nThreadId, Helpers.MarshalUInt32FixedArray(pThreadAttributes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMainThreadFunc(TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegate func)
	{
		TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegateNative executeMainThreadFuncDelegateNative = null;
		if (func != null)
		{
			executeMainThreadFuncDelegateNative = delegate(TD_RootIntegrated_Globals.MainThreadFuncDelegateNative _func, IntPtr _arg)
			{
				TD_RootIntegrated_Globals.MainThreadFuncDelegate func2 = null;
				if (_func != null)
				{
					func2 = delegate(IntPtr __arg)
					{
						_func(__arg);
					};
				}
				func(func2, _arg);
			};
		}
		IntPtr jarg = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(executeMainThreadFuncDelegateNative));
		DelegateHolder.Add(executeMainThreadFuncDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_setMainThreadFunc(swigCPtr, jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegate getMainThreadFunc()
	{
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.ThreadsCounter_getMainThreadFunc(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = delegate(TD_RootIntegrated_Globals.MainThreadFuncDelegate _func, IntPtr _arg)
			{
				TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegateNative obj = Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegateNative)) as TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegateNative;
				TD_RootIntegrated_Globals.MainThreadFuncDelegate func_csharpTemp = _func;
				TD_RootIntegrated_Globals.MainThreadFuncDelegateNative func = null;
				if (func_csharpTemp != null)
				{
					func = delegate(IntPtr __arg)
					{
						func_csharpTemp(__arg);
					};
				}
				obj(func, _arg);
			};
		}
		return result;
	}
}

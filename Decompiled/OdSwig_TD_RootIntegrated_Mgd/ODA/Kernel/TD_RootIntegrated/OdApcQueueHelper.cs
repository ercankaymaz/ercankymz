using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdApcQueueHelper : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdApcQueueHelper(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdApcQueueHelper obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdApcQueueHelper()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdApcQueueHelper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdApcQueueHelper()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdApcQueueHelper__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdApcQueueHelper(OdApcQueue pObject, OdRxObjMod m)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdApcQueueHelper__SWIG_1(OdApcQueue.getCPtr(pObject), (int)m), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdApcQueueHelper(OdApcQueue pObject)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdApcQueueHelper__SWIG_2(OdApcQueue.getCPtr(pObject)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdApcQueueHelper(OdRxObject pObject, OdRxObjMod m)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdApcQueueHelper__SWIG_3(OdRxObject.getCPtr(pObject), (int)m), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdApcQueueHelper(OdBaseObjectPtr pObject)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdApcQueueHelper__SWIG_4(OdBaseObjectPtr.getCPtr(pObject)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void initST(OdRxThreadPoolService pThreadPool)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueueHelper_initST(swigCPtr, OdRxThreadPoolService.getCPtr(pThreadPool));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void initMT(OdRxThreadPoolService pThreadPool)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueueHelper_initMT(swigCPtr, OdRxThreadPoolService.getCPtr(pThreadPool));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void call(OdApcAtom pAction, OdRxObject pParam)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueueHelper_call__SWIG_0(swigCPtr, OdApcAtom.getCPtr(pAction), OdRxObject.getCPtr(pParam));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void call(OdApcAtom pAction)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueueHelper_call__SWIG_1(swigCPtr, OdApcAtom.getCPtr(pAction));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void call(OdApcAtom pAction, IntPtr param)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueueHelper_call__SWIG_2(swigCPtr, OdApcAtom.getCPtr(pAction), param);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAtomPoolRef(OdApcObjectPool pAtomPool)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueueHelper_setAtomPoolRef(swigCPtr, OdApcObjectPool.getCPtr(pAtomPool));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wait()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueueHelper_wait(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

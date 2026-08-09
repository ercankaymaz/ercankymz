using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdApcQueue : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdApcQueue(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdApcQueue_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdApcQueue obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdApcQueue(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual OdRxThreadPoolService framework()
	{
		OdRxThreadPoolService rXObject = Helpers.GetRXObject<OdRxThreadPoolService>(TD_RootIntegrated_GlobalsPINVOKE.OdApcQueue_framework(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setAtomPoolRef(OdApcObjectPool pAtomPool)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueue_setAtomPoolRef(swigCPtr, OdApcObjectPool.getCPtr(pAtomPool));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addEntryPoint(OdApcAtom pRecipient, OdRxObject pMessage)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueue_addEntryPoint__SWIG_0(swigCPtr, OdApcAtom.getCPtr(pRecipient), OdRxObject.getCPtr(pMessage));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addEntryPoint(OdApcAtom pRecipient)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueue_addEntryPoint__SWIG_1(swigCPtr, OdApcAtom.getCPtr(pRecipient));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addEntryPoint(OdApcAtom pRecipient, IntPtr pMessage)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueue_addEntryPoint__SWIG_2(swigCPtr, OdApcAtom.getCPtr(pRecipient), pMessage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wait()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueue_wait(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void executeMainThreadAction(TD_RootIntegrated_Globals.MainThreadFuncDelegate mtFunc, IntPtr pArg)
	{
		TD_RootIntegrated_Globals.MainThreadFuncDelegateNative mainThreadFuncDelegateNative = null;
		if (mtFunc != null)
		{
			mainThreadFuncDelegateNative = delegate(IntPtr arg1)
			{
				mtFunc(arg1);
			};
		}
		IntPtr jarg = ((mtFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(mainThreadFuncDelegateNative));
		DelegateHolder.Add(mainThreadFuncDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdApcQueue_executeMainThreadAction(swigCPtr, jarg, pArg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int numThreads()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdApcQueue_numThreads(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdApcQueue_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

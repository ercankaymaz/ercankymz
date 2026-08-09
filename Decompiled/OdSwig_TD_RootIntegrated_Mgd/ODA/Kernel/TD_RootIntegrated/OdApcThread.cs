using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdApcThread : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdApcThread(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdApcThread_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdApcThread obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdApcThread(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual void asyncProcCall(TD_RootIntegrated_Globals.OdApcEntryPointVoidParamDelegate ep, IntPtr parameter)
	{
		TD_RootIntegrated_Globals.OdApcEntryPointVoidParamDelegateNative odApcEntryPointVoidParamDelegateNative = null;
		if (ep != null)
		{
			odApcEntryPointVoidParamDelegateNative = delegate(IntPtr _parameter)
			{
				ep(_parameter);
			};
		}
		IntPtr jarg = ((ep == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(odApcEntryPointVoidParamDelegateNative));
		DelegateHolder.Add(odApcEntryPointVoidParamDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdApcThread_asyncProcCall__SWIG_0(swigCPtr, jarg, parameter);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void asyncProcCall(TD_RootIntegrated_Globals.OdApcEntryPointRxObjParamDelegate ep, OdRxObject parameter)
	{
		TD_RootIntegrated_Globals.OdApcEntryPointRxObjParamDelegateNative odApcEntryPointRxObjParamDelegateNative = null;
		if (ep != null)
		{
			odApcEntryPointRxObjParamDelegateNative = delegate(IntPtr parameter_)
			{
				ep(OdMarshalHelper.PtrToObject<OdRxObject>(parameter_));
			};
		}
		IntPtr jarg = ((ep == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(odApcEntryPointRxObjParamDelegateNative));
		DelegateHolder.Add(odApcEntryPointRxObjParamDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdApcThread_asyncProcCall__SWIG_1(swigCPtr, jarg, OdRxObject.getCPtr(parameter));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wait(bool bNoThrow)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcThread_wait__SWIG_0(swigCPtr, bNoThrow);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wait()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcThread_wait__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getId()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdApcThread_getId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasException()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdApcThread_hasException(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void processException(bool bReThrow, bool bClear)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcThread_processException__SWIG_0(swigCPtr, bReThrow, bClear);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void processException(bool bReThrow)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcThread_processException__SWIG_1(swigCPtr, bReThrow);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void processException()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdApcThread_processException__SWIG_2(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdApcThread_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

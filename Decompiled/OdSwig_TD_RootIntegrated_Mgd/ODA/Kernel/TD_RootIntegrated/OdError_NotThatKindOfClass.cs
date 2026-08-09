using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdError_NotThatKindOfClass : OdError
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdError_NotThatKindOfClass(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdError_NotThatKindOfClass_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdError_NotThatKindOfClass obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdError_NotThatKindOfClass(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdError_NotThatKindOfClass(OdRxClass fromClass, OdRxClass toClass)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdError_NotThatKindOfClass__SWIG_0(OdRxClass.getCPtr(fromClass), OdRxClass.getCPtr(toClass)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdError_NotThatKindOfClass(string fromClass, string toClass)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdError_NotThatKindOfClass__SWIG_1(fromClass, toClass), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdError_NotThatKindOfClass(OdError_NotThatKindOfClass arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdError_NotThatKindOfClass__SWIG_2(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string fromClassName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdError_NotThatKindOfClass_fromClassName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string toClassName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdError_NotThatKindOfClass_toClassName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

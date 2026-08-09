using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdColorConverterCallbackCaching : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdColorConverterCallbackCaching(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdColorConverterCallbackCaching obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdColorConverterCallbackCaching()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdColorConverterCallbackCaching(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdColorConverterCallbackCaching(OdColorConverterCallback pCallback)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdColorConverterCallbackCaching__SWIG_0(OdColorConverterCallback.getCPtr(pCallback)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdColorConverterCallbackCaching()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdColorConverterCallbackCaching__SWIG_1(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void refresh()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdColorConverterCallbackCaching_refresh(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColorConverterCallback(OdColorConverterCallback pCallback)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdColorConverterCallbackCaching_setColorConverterCallback(swigCPtr, OdColorConverterCallback.getCPtr(pCallback));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdColorConverterCallback colorConverterCallback()
	{
		OdColorConverterCallback rXObject = Helpers.GetRXObject<OdColorConverterCallback>(TD_RootIntegrated_GlobalsPINVOKE.OdColorConverterCallbackCaching_colorConverterCallback(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public uint convert(uint originalColor)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdColorConverterCallbackCaching_convert(swigCPtr, originalColor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

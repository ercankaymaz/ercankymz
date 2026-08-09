using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsOverlayMapping : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsOverlayMapping(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsOverlayMapping obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsOverlayMapping()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsOverlayMapping(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static uint overlayFlags(OdGsOverlayId id)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsOverlayMapping_overlayFlags((int)id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint overlayIndexToRenderingOrder(OdGsOverlayId id)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsOverlayMapping_overlayIndexToRenderingOrder((int)id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGsOverlayId overlayRenderingOrderToIndex(uint renderOrder)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsOverlayMapping_overlayRenderingOrderToIndex(renderOrder);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsOverlayId)result;
	}

	public static bool validateDefinitions(uint gsModelDef)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsOverlayMapping_validateDefinitions(gsModelDef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool validateOverlayIndex(OdGsOverlayId id)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsOverlayMapping_validateOverlayIndex((int)id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool validateRenderingOrder(uint renderOrder)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsOverlayMapping_validateRenderingOrder(renderOrder);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsOverlayMapping()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsOverlayMapping(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

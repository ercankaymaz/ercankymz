using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsAwareFlagsArray : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsAwareFlagsArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsAwareFlagsArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsAwareFlagsArray()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsAwareFlagsArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsAwareFlagsArray()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsAwareFlagsArray(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setChildrenUpToDate(bool childrenUpToDate, uint nVpID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsAwareFlagsArray_setChildrenUpToDate__SWIG_0(swigCPtr, childrenUpToDate, nVpID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setChildrenUpToDate(bool childrenUpToDate)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsAwareFlagsArray_setChildrenUpToDate__SWIG_1(swigCPtr, childrenUpToDate);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool childrenUpToDate(uint nVpID)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsAwareFlagsArray_childrenUpToDate(swigCPtr, nVpID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool childrenRegenDraw(uint nVpID)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsAwareFlagsArray_childrenRegenDraw(swigCPtr, nVpID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint get(uint nVpID)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsAwareFlagsArray_get(swigCPtr, nVpID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set(uint nVpID, uint flags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsAwareFlagsArray_set(swigCPtr, nVpID, flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsAwareFlagsArray_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsAwareFlagsArray_isEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint numAwareFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsAwareFlagsArray_numAwareFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool areInvalid(uint nVpID)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsAwareFlagsArray_areInvalid(swigCPtr, nVpID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setInvalid(uint nVpID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsAwareFlagsArray_setInvalid(swigCPtr, nVpID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

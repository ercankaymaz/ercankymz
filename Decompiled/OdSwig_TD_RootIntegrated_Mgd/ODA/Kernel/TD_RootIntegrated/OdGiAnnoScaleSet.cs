using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiAnnoScaleSet : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiAnnoScaleSet(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiAnnoScaleSet obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiAnnoScaleSet()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiAnnoScaleSet(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiAnnoScaleSet()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiAnnoScaleSet__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiAnnoScaleSet(OdDbStubPtrArray aSortedId, OdDbStub defaultId)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiAnnoScaleSet__SWIG_1(OdDbStubPtrArray.getCPtr(aSortedId), OdDbStub.getCPtr(defaultId)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiAnnoScaleSet(OdGiAnnoScaleSet v)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiAnnoScaleSet__SWIG_2(getCPtr(v)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdDbStubPtrArray aSortedId, OdDbStub defaultId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiAnnoScaleSet_set(swigCPtr, OdDbStubPtrArray.getCPtr(aSortedId), OdDbStub.getCPtr(defaultId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiAnnoScaleSet_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbStubPtrArray annoScaleIds()
	{
		OdDbStubPtrArray result = new OdDbStubPtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiAnnoScaleSet_annoScaleIds(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub defaultId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiAnnoScaleSet_defaultId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

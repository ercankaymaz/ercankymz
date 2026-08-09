using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsLightsAccumulationContainter : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager m_accumulatedLightsData
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsLightsAccumulationContainter_m_accumulatedLightsData_get(swigCPtr);
			OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager result = ((intPtr == IntPtr.Zero) ? null : new OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsLightsAccumulationContainter_m_accumulatedLightsData_set(swigCPtr, OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdMutexPtr m_lightsAccumMutex
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsLightsAccumulationContainter_m_lightsAccumMutex_get(swigCPtr);
			OdMutexPtr result = ((intPtr == IntPtr.Zero) ? null : new OdMutexPtr(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsLightsAccumulationContainter_m_lightsAccumMutex_set(swigCPtr, OdMutexPtr.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsLightsAccumulationContainter(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsLightsAccumulationContainter obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsLightsAccumulationContainter()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsLightsAccumulationContainter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsLightsAccumulationContainter()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsLightsAccumulationContainter(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool has()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLightsAccumulationContainter_has(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void append(bool bMtSync, OdGiLightTraitsData pLightData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsLightsAccumulationContainter_append__SWIG_0(swigCPtr, bMtSync, OdGiLightTraitsData.getCPtr(pLightData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void append(bool bMtSync, OdGsLightsAccumulationContainter lightsAccum)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsLightsAccumulationContainter_append__SWIG_1(swigCPtr, bMtSync, getCPtr(lightsAccum));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsLightsAccumulationContainter_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

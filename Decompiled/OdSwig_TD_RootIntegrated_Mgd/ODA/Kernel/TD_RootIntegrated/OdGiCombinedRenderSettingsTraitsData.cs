using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiCombinedRenderSettingsTraitsData : OdGiMentalRayRenderSettingsTraitsData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiCombinedRenderSettingsTraitsData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiCombinedRenderSettingsTraitsData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiCombinedRenderSettingsTraitsData obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiCombinedRenderSettingsTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiCombinedRenderSettingsTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiCombinedRenderSettingsTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setKindOfRenderSettings(uint nFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCombinedRenderSettingsTraitsData_setKindOfRenderSettings(swigCPtr, nFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint kindOfRenderSettings()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCombinedRenderSettingsTraitsData_kindOfRenderSettings(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void modifyKindOfRenderSettings(uint nFlags, bool bOp)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCombinedRenderSettingsTraitsData_modifyKindOfRenderSettings__SWIG_0(swigCPtr, nFlags, bOp);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void modifyKindOfRenderSettings(uint nFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCombinedRenderSettingsTraitsData_modifyKindOfRenderSettings__SWIG_1(swigCPtr, nFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasMentalRayRenderSettings()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCombinedRenderSettingsTraitsData_hasMentalRayRenderSettings(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasRapidRTRenderSettings()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCombinedRenderSettingsTraitsData_hasRapidRTRenderSettings(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasVisualizeRTRenderSettings()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCombinedRenderSettingsTraitsData_hasVisualizeRTRenderSettings(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiCombinedRenderSettingsTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCombinedRenderSettingsTraitsData_IsNotEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGiCombinedRenderSettingsTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCombinedRenderSettingsTraitsData_IsEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRapidRTRenderSettingsTraitsData : OdGiRenderSettingsTraitsData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiRapidRTRenderSettingsTraitsData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRapidRTRenderSettingsTraitsData obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRapidRTRenderSettingsTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiRapidRTRenderSettingsTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRapidRTRenderSettingsTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiRapidRTRenderSettingsTraitsData) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public void setQuitCondition(OdGiQuitCondition_ condition)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_setQuitCondition(swigCPtr, (int)condition);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiQuitCondition_ quitCondition()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_quitCondition(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiQuitCondition_)result;
	}

	public void setDesiredRenderLevel(int level)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_setDesiredRenderLevel(swigCPtr, level);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int desiredRenderLevel()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_desiredRenderLevel(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDesiredRenderTime(int time)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_setDesiredRenderTime(swigCPtr, time);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int desiredRenderTime()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_desiredRenderTime(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLightingMode(OdGiLightingMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_setLightingMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiLightingMode_ lightingMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_lightingMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiLightingMode_)result;
	}

	public void setFilterType(OdGiFilterType_ type)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_setFilterType(swigCPtr, (int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiFilterType_ filterType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_filterType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFilterType_)result;
	}

	public void setFilterWidth(float width)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_setFilterWidth(swigCPtr, width);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public float filterWidth()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_filterWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFilterHeight(float height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_setFilterHeight(swigCPtr, height);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public float filterHeight()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_filterHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiRapidRTRenderSettingsTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_IsNotEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGiRapidRTRenderSettingsTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_IsEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraitsData_director_connect(swigCPtr);
	}
}

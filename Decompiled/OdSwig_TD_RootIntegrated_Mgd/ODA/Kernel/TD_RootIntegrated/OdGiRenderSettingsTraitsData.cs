using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRenderSettingsTraitsData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiRenderSettingsTraitsData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRenderSettingsTraitsData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiRenderSettingsTraitsData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRenderSettingsTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiRenderSettingsTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRenderSettingsTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiRenderSettingsTraitsData) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public void setMaterialEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_setMaterialEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool materialEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_materialEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTextureSampling(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_setTextureSampling(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool textureSampling()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_textureSampling(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBackFacesEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_setBackFacesEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool backFacesEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_backFacesEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setShadowsEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_setShadowsEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool shadowsEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_shadowsEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDiagnosticBackgroundEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_setDiagnosticBackgroundEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool diagnosticBackgroundEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_diagnosticBackgroundEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setModelScaleFactor(double scaleFactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_setModelScaleFactor(swigCPtr, scaleFactor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double modelScaleFactor()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_modelScaleFactor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGiRenderSettingsTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_IsEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiRenderSettingsTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_IsNotEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraitsData_director_connect(swigCPtr);
	}
}

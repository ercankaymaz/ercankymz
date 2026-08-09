using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMentalRayRenderSettingsTraitsData : OdGiRenderSettingsTraitsData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMentalRayRenderSettingsTraitsData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMentalRayRenderSettingsTraitsData obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMentalRayRenderSettingsTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiMentalRayRenderSettingsTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMentalRayRenderSettingsTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMentalRayRenderSettingsTraitsData) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public void setSampling(int min, int max)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setSampling(swigCPtr, min, max);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void sampling(out int min, out int max)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_sampling(swigCPtr, out min, out max);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSamplingFilter(OdGiMrFilter_ filter, double width, double height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setSamplingFilter(swigCPtr, (int)filter, width, height);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void samplingFilter(out OdGiMrFilter_ filter, out double width, out double height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_samplingFilter(swigCPtr, out filter, out width, out height);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSamplingContrastColor(float r, float g, float b, float a)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setSamplingContrastColor(swigCPtr, r, g, b, a);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void samplingContrastColor(out float r, out float g, out float b, out float a)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_samplingContrastColor(swigCPtr, out r, out g, out b, out a);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setShadowMode(OdGiMrShadowMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setShadowMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMrShadowMode_ shadowMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_shadowMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrShadowMode_)result;
	}

	public void setShadowMapEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setShadowMapEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool shadowMapEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_shadowMapEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRayTraceEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setRayTraceEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool rayTraceEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_rayTraceEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRayTraceDepth(int reflection, int refraction, int sum)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setRayTraceDepth(swigCPtr, reflection, refraction, sum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void rayTraceDepth(out int reflection, out int refraction, out int sum)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_rayTraceDepth(swigCPtr, out reflection, out refraction, out sum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGlobalIlluminationEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setGlobalIlluminationEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool globalIlluminationEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_globalIlluminationEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGISampleCount(int num)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setGISampleCount(swigCPtr, num);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int giSampleCount()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_giSampleCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGISampleRadiusEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setGISampleRadiusEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool giSampleRadiusEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_giSampleRadiusEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGISampleRadius(double radius)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setGISampleRadius(swigCPtr, radius);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double giSampleRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_giSampleRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGIPhotonsPerLight(int num)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setGIPhotonsPerLight(swigCPtr, num);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int giPhotonsPerLight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_giPhotonsPerLight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPhotonTraceDepth(int reflection, int refraction, int sum)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setPhotonTraceDepth(swigCPtr, reflection, refraction, sum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void photonTraceDepth(out int reflection, out int refraction, out int sum)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_photonTraceDepth(swigCPtr, out reflection, out refraction, out sum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFinalGatheringEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setFinalGatheringEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool finalGatheringEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_finalGatheringEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFGRayCount(int num)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setFGRayCount(swigCPtr, num);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int fgRayCount()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_fgRayCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFGRadiusState(bool bMin, bool bMax, bool bPixels)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setFGRadiusState(swigCPtr, bMin, bMax, bPixels);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fgSampleRadiusState(out bool bMin, out bool bMax, out bool bPixels)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_fgSampleRadiusState(swigCPtr, out bMin, out bMax, out bPixels);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFGSampleRadius(double min, double max)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setFGSampleRadius(swigCPtr, min, max);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fgSampleRadius(out double min, out double max)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_fgSampleRadius(swigCPtr, out min, out max);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLightLuminanceScale(double luminance)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setLightLuminanceScale(swigCPtr, luminance);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double lightLuminanceScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_lightLuminanceScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDiagnosticMode(OdGiMrDiagnosticMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setDiagnosticMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMrDiagnosticMode_ diagnosticMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_diagnosticMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrDiagnosticMode_)result;
	}

	public void setDiagnosticGridMode(OdGiMrDiagnosticGridMode_ mode, float fSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setDiagnosticGridMode(swigCPtr, (int)mode, fSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void diagnosticGridMode(out OdGiMrDiagnosticGridMode_ mode, out float fSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_diagnosticGridMode(swigCPtr, out mode, out fSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDiagnosticPhotonMode(OdGiMrDiagnosticPhotonMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setDiagnosticPhotonMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMrDiagnosticPhotonMode_ diagnosticPhotonMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_diagnosticPhotonMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrDiagnosticPhotonMode_)result;
	}

	public void setDiagnosticBSPMode(OdGiMrDiagnosticBSPMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setDiagnosticBSPMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMrDiagnosticBSPMode_ diagnosticBSPMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_diagnosticBSPMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrDiagnosticBSPMode_)result;
	}

	public void setExportMIEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setExportMIEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool exportMIEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_exportMIEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExportMIFileName(string miName)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setExportMIFileName(swigCPtr, miName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string exportMIFileName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_exportMIFileName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTileSize(int size)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setTileSize(swigCPtr, size);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int tileSize()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_tileSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTileOrder(OdGiMrTileOrder_ order)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setTileOrder(swigCPtr, (int)order);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMrTileOrder_ tileOrder()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_tileOrder(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrTileOrder_)result;
	}

	public void setMemoryLimit(int limit)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setMemoryLimit(swigCPtr, limit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int memoryLimit()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_memoryLimit(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEnergyMultiplier(float fScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setEnergyMultiplier(swigCPtr, fScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public float energyMultiplier()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_energyMultiplier(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setProgressMonitor(IntPtr pMonitor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setProgressMonitor(swigCPtr, pMonitor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public IntPtr progressMonitor()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_progressMonitor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExposureType(OdGiMrExposureType_ type)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setExposureType(swigCPtr, (int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMrExposureType_ exposureType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_exposureType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrExposureType_)result;
	}

	public void setFinalGatheringMode(OdGiMrFinalGatheringMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setFinalGatheringMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMrFinalGatheringMode_ finalGatheringMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_finalGatheringMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrFinalGatheringMode_)result;
	}

	public void setShadowSamplingMultiplier(double multiplier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setShadowSamplingMultiplier(swigCPtr, multiplier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double shadowSamplingMultiplier()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_shadowSamplingMultiplier(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExportMIMode(OdGiMrExportMIMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_setExportMIMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMrExportMIMode_ exportMIMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_exportMIMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrExportMIMode_)result;
	}

	public bool IsNotEqual(OdGiMentalRayRenderSettingsTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_IsNotEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGiMentalRayRenderSettingsTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_IsEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraitsData_director_connect(swigCPtr);
	}
}

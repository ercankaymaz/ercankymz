using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRenderEnvironmentTraitsData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiRenderEnvironmentTraitsData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRenderEnvironmentTraitsData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiRenderEnvironmentTraitsData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRenderEnvironmentTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiRenderEnvironmentTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRenderEnvironmentTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setEnable(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_setEnable(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool enable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_enable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIsBackground(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_setIsBackground(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isBackground()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_isBackground(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFogColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_setFogColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor fogColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_fogColor(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNearDistance(double nearDist)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_setNearDistance(swigCPtr, nearDist);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double nearDistance()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_nearDistance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFarDistance(double farDist)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_setFarDistance(swigCPtr, farDist);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double farDistance()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_farDistance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNearPercentage(double nearPct)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_setNearPercentage(swigCPtr, nearPct);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double nearPercentage()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_nearPercentage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFarPercentage(double farPct)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_setFarPercentage(swigCPtr, farPct);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double farPercentage()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_farPercentage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEnvironmentMap(OdGiMaterialTexture map)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_setEnvironmentMap(swigCPtr, OdGiMaterialTexture.getCPtr(map));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMaterialTexture environmentMap()
	{
		OdGiMaterialTexture rXObject = Helpers.GetRXObject<OdGiMaterialTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_environmentMap(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool IsEqual(OdGiRenderEnvironmentTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_IsEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiRenderEnvironmentTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraitsData_IsNotEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

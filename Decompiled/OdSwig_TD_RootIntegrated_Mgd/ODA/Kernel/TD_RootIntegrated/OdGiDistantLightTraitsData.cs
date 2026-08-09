using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDistantLightTraitsData : OdGiLightTraitsData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDistantLightTraitsData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDistantLightTraitsData obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDistantLightTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiDistantLightTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDistantLightTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d direction()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_direction(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDirection(OdGeVector3d dir)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_setDirection(swigCPtr, OdGeVector3d.getCPtr(dir));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isSunlight()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_isSunlight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSunlight(bool val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_setSunlight(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double physicalIntensity()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_physicalIntensity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPhysicalIntensity(double intensity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_setPhysicalIntensity(swigCPtr, intensity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiColorRGB lampColor()
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_lampColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLampColor(OdGiColorRGB color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_setLampColor(swigCPtr, OdGiColorRGB.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void skyParameters(OdGiSkyParameters arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_skyParameters(swigCPtr, OdGiSkyParameters.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSkyParameters(OdGiSkyParameters arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_setSkyParameters(swigCPtr, OdGiSkyParameters.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new void save(OdGsFiler pFiler)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_save(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new void load(OdGsFiler pFiler)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraitsData_load(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

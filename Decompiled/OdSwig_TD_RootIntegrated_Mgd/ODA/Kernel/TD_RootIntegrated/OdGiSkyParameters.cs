using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSkyParameters : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSkyParameters(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSkyParameters obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiSkyParameters()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSkyParameters(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiSkyParameters()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSkyParameters(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdGiSkyParameters params_)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_IsEqual(swigCPtr, getCPtr(params_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIllumination(bool enable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setIllumination(swigCPtr, enable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool illumination()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_illumination(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIntensityFactor(double intensity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setIntensityFactor(swigCPtr, intensity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double intensityFactor()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_intensityFactor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHaze(double haze)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setHaze(swigCPtr, haze);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double haze()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_haze(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHorizonHeight(double height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setHorizonHeight(swigCPtr, height);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double horizonHeight()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_horizonHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHorizonBlur(double blur)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setHorizonBlur(swigCPtr, blur);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double horizonBlur()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_horizonBlur(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGroundColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setGroundColor__SWIG_0(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGroundColor(OdCmColorBase color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setGroundColor__SWIG_1(swigCPtr, OdCmColorBase.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor groundColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_groundColor__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void groundColor(ref OdCmColorBase color)
	{
		IntPtr jarg = ((color == null) ? IntPtr.Zero : OdCmColorBase.getCPtr(color).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_groundColor__SWIG_1(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				color = null;
			}
			if (jarg != intPtr)
			{
				color = Helpers.GetObject<OdCmColorBase>(jarg, bOwn: true, bTryAddToTransaction: false);
			}
		}
	}

	public void setNightColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setNightColor__SWIG_0(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setNightColor(OdCmColorBase color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setNightColor__SWIG_1(swigCPtr, OdCmColorBase.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor nightColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_nightColor__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void nightColor(ref OdCmColorBase color)
	{
		IntPtr jarg = ((color == null) ? IntPtr.Zero : OdCmColorBase.getCPtr(color).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_nightColor__SWIG_1(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				color = null;
			}
			if (jarg != intPtr)
			{
				color = Helpers.GetObject<OdCmColorBase>(jarg, bOwn: true, bTryAddToTransaction: false);
			}
		}
	}

	public void setAerialPerspective(bool apply)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setAerialPerspective(swigCPtr, apply);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool aerialPerspective()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_aerialPerspective(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVisibilityDistance(double distance)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setVisibilityDistance(swigCPtr, distance);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double visibilityDistance()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_visibilityDistance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDiskScale(double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setDiskScale(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double diskScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_diskScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGlowIntensity(double intensity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setGlowIntensity(swigCPtr, intensity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double glowIntensity()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_glowIntensity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDiskIntensity(double intensity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setDiskIntensity(swigCPtr, intensity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double diskIntensity()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_diskIntensity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSolarDiskSamples(ushort samples)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setSolarDiskSamples(swigCPtr, samples);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort solarDiskSamples()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_solarDiskSamples(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSunDirection(OdGeVector3d sundir)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setSunDirection(swigCPtr, OdGeVector3d.getCPtr(sundir));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d sunDirection()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_sunDirection(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRedBlueShift(double redBlueShift)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setRedBlueShift(swigCPtr, redBlueShift);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double redBlueShift()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_redBlueShift(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSaturation(double saturation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_setSaturation(swigCPtr, saturation);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double saturation()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSkyParameters_saturation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

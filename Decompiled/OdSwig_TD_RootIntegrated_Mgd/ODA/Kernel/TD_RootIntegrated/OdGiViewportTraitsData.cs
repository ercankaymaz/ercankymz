using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiViewportTraitsData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiViewportTraitsData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiViewportTraitsData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiViewportTraitsData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiViewportTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiViewportTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiViewportTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDrawable_DrawableType type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiDrawable_DrawableType)result;
	}

	public void setBackground(OdDbStub backgroundId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setBackground(swigCPtr, OdDbStub.getCPtr(backgroundId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbStub background()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_background(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDefaultLightingOn(bool on)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setDefaultLightingOn(swigCPtr, on);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDefaultLightingOn()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_isDefaultLightingOn(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDefaultLightingType(OdGiViewportTraits_DefaultLightingType typ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setDefaultLightingType(swigCPtr, (int)typ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiViewportTraits_DefaultLightingType defaultLightingType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_defaultLightingType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiViewportTraits_DefaultLightingType)result;
	}

	public OdGeVector3d userDefinedLightDirection()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_userDefinedLightDirection(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUserDefinedLightDirection(OdGeVector3d lightDirection)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setUserDefinedLightDirection(swigCPtr, OdGeVector3d.getCPtr(lightDirection));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double defaultLightingIntensity()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_defaultLightingIntensity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDefaultLightingIntensity(double dIntensity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setDefaultLightingIntensity(swigCPtr, dIntensity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor defaultLightingColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_defaultLightingColor(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDefaultLightingColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setDefaultLightingColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiShadowParameters defaultLightingShadowParameters()
	{
		OdGiShadowParameters result = new OdGiShadowParameters(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_defaultLightingShadowParameters(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDefaultLightingShadowParameters(OdGiShadowParameters params_)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setDefaultLightingShadowParameters(swigCPtr, OdGiShadowParameters.getCPtr(params_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAmbientLightColor(OdCmEntityColor clr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setAmbientLightColor(swigCPtr, OdCmEntityColor.getCPtr(clr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor ambientLightColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_ambientLightColor(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBrightness(double brightness)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setBrightness(swigCPtr, brightness);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double brightness()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_brightness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setContrast(double contrast)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setContrast(swigCPtr, contrast);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double contrast()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_contrast(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRenderEnvironment(OdDbStub renderEnvId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setRenderEnvironment(swigCPtr, OdDbStub.getCPtr(renderEnvId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbStub renderEnvironment()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_renderEnvironment(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRenderSettings(OdDbStub renderSettingsId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setRenderSettings(swigCPtr, OdDbStub.getCPtr(renderSettingsId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbStub renderSettings()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_renderSettings(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVisualStyle(OdDbStub visualStyleId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setVisualStyle(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbStub visualStyle()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_visualStyle(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setToneOperatorParameters(OdGiToneOperatorParameters params_)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_setToneOperatorParameters(swigCPtr, OdGiToneOperatorParameters.getCPtr(params_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void toneOperatorParameters(ref OdGiToneOperatorParameters params_)
	{
		IntPtr jarg = ((params_ == null) ? IntPtr.Zero : OdGiToneOperatorParameters.getCPtr(params_).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_toneOperatorParameters__SWIG_0(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				params_ = null;
			}
			if (jarg != intPtr)
			{
				params_ = Helpers.GetRXObject<OdGiToneOperatorParameters>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdGiToneOperatorParameters toneOperatorParameters()
	{
		OdGiToneOperatorParameters rXObject = Helpers.GetRXObject<OdGiToneOperatorParameters>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_toneOperatorParameters__SWIG_1(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static bool compareToneOps(OdGiToneOperatorParameters op1, OdGiToneOperatorParameters op2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_compareToneOps(OdGiToneOperatorParameters.getCPtr(op1), OdGiToneOperatorParameters.getCPtr(op2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGiViewportTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_IsEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiViewportTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraitsData_IsNotEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

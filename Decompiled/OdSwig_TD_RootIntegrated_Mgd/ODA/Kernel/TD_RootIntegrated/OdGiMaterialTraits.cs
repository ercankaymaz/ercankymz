using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMaterialTraits : OdGiDrawableTraits
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMaterialTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMaterialTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMaterialTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMaterialTraits cast(OdRxObject pObj)
	{
		OdGiMaterialTraits rXObject = Helpers.GetRXObject<OdGiMaterialTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiMaterialTraits createObject()
	{
		OdGiMaterialTraits rXObject = Helpers.GetRXObject<OdGiMaterialTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void ambient(OdGiMaterialColor ambientColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_ambient(swigCPtr, OdGiMaterialColor.getCPtr(ambientColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void diffuse(OdGiMaterialColor diffuseColor, OdGiMaterialMap diffuseMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_diffuse(swigCPtr, OdGiMaterialColor.getCPtr(diffuseColor), OdGiMaterialMap.getCPtr(diffuseMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void specular(OdGiMaterialColor specularColor, OdGiMaterialMap specularMap, out double glossFactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_specular(swigCPtr, OdGiMaterialColor.getCPtr(specularColor), OdGiMaterialMap.getCPtr(specularMap), out glossFactor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void reflection(OdGiMaterialMap reflectionMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_reflection(swigCPtr, OdGiMaterialMap.getCPtr(reflectionMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void opacity(out double opacityPercentage, OdGiMaterialMap opacityMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_opacity(swigCPtr, out opacityPercentage, OdGiMaterialMap.getCPtr(opacityMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void bump(OdGiMaterialMap bumpMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_bump(swigCPtr, OdGiMaterialMap.getCPtr(bumpMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void refraction(out double refractionIndex, OdGiMaterialMap refractionMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_refraction(swigCPtr, out refractionIndex, OdGiMaterialMap.getCPtr(refractionMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double translucence()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_translucence(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double selfIllumination()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_selfIllumination(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double reflectivity()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_reflectivity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTraits_IlluminationModel illuminationModel()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_illuminationModel(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_IlluminationModel)result;
	}

	public virtual OdGiMaterialTraits_ChannelFlags channelFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_channelFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_ChannelFlags)result;
	}

	public virtual OdGiMaterialTraits_Mode mode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_mode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_Mode)result;
	}

	public virtual void setAmbient(OdGiMaterialColor ambientColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setAmbient(swigCPtr, OdGiMaterialColor.getCPtr(ambientColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDiffuse(OdGiMaterialColor diffuseColor, OdGiMaterialMap diffuseMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setDiffuse(swigCPtr, OdGiMaterialColor.getCPtr(diffuseColor), OdGiMaterialMap.getCPtr(diffuseMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSpecular(OdGiMaterialColor specularColor, OdGiMaterialMap specularMap, double glossFactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setSpecular(swigCPtr, OdGiMaterialColor.getCPtr(specularColor), OdGiMaterialMap.getCPtr(specularMap), glossFactor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setReflection(OdGiMaterialMap reflectionMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setReflection(swigCPtr, OdGiMaterialMap.getCPtr(reflectionMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setOpacity(double opacityPercentage, OdGiMaterialMap opacityMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setOpacity(swigCPtr, opacityPercentage, OdGiMaterialMap.getCPtr(opacityMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBump(OdGiMaterialMap bumpMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setBump(swigCPtr, OdGiMaterialMap.getCPtr(bumpMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRefraction(double refractionIndex, OdGiMaterialMap refractionMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setRefraction(swigCPtr, refractionIndex, OdGiMaterialMap.getCPtr(refractionMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTranslucence(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setTranslucence(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSelfIllumination(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setSelfIllumination(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setReflectivity(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setReflectivity(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setIlluminationModel(OdGiMaterialTraits_IlluminationModel model)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setIlluminationModel(swigCPtr, (int)model);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setChannelFlags(OdGiMaterialTraits_ChannelFlags flags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setChannelFlags(swigCPtr, (int)flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMode(OdGiMaterialTraits_Mode value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setMode(swigCPtr, (int)value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setColorBleedScale(double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setColorBleedScale(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double colorBleedScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_colorBleedScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setIndirectBumpScale(double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setIndirectBumpScale(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double indirectBumpScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_indirectBumpScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setReflectanceScale(double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setReflectanceScale(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double reflectanceScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_reflectanceScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTransmittanceScale(double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setTransmittanceScale(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double transmittanceScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_transmittanceScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTwoSided(bool flag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setTwoSided(swigCPtr, flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool twoSided()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_twoSided(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLuminanceMode(OdGiMaterialTraits_LuminanceMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setLuminanceMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTraits_LuminanceMode luminanceMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_luminanceMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_LuminanceMode)result;
	}

	public virtual void setLuminance(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setLuminance(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double luminance()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_luminance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setNormalMap(OdGiMaterialMap normalMap, OdGiMaterialTraits_NormalMapMethod method, double strength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setNormalMap(swigCPtr, OdGiMaterialMap.getCPtr(normalMap), (int)method, strength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void normalMap(OdGiMaterialMap normalMap, out OdGiMaterialTraits_NormalMapMethod method, out double strength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_normalMap(swigCPtr, OdGiMaterialMap.getCPtr(normalMap), out method, out strength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGlobalIllumination(OdGiMaterialTraits_GlobalIlluminationMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setGlobalIllumination(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTraits_GlobalIlluminationMode globalIllumination()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_globalIllumination(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_GlobalIlluminationMode)result;
	}

	public virtual void setFinalGather(OdGiMaterialTraits_FinalGatherMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setFinalGather(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTraits_FinalGatherMode finalGather()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_finalGather(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_FinalGatherMode)result;
	}

	public virtual void setEmission(OdGiMaterialColor emissionColor, OdGiMaterialMap emissionMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setEmission(swigCPtr, OdGiMaterialColor.getCPtr(emissionColor), OdGiMaterialMap.getCPtr(emissionMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void emission(OdGiMaterialColor emissionColor, OdGiMaterialMap emissionMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_emission(swigCPtr, OdGiMaterialColor.getCPtr(emissionColor), OdGiMaterialMap.getCPtr(emissionMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTint(OdGiMaterialColor tintColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setTint(swigCPtr, OdGiMaterialColor.getCPtr(tintColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void tint(OdGiMaterialColor tintColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_tint(swigCPtr, OdGiMaterialColor.getCPtr(tintColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setShadingAmbient(OdGiMaterialColor ambientColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setShadingAmbient(swigCPtr, OdGiMaterialColor.getCPtr(ambientColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void shadingAmbient(OdGiMaterialColor ambientColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_shadingAmbient(swigCPtr, OdGiMaterialColor.getCPtr(ambientColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setShadingDiffuse(OdGiMaterialColor diffuseColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setShadingDiffuse(swigCPtr, OdGiMaterialColor.getCPtr(diffuseColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void shadingDiffuse(OdGiMaterialColor diffuseColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_shadingDiffuse(swigCPtr, OdGiMaterialColor.getCPtr(diffuseColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setShadingSpecular(OdGiMaterialColor specularColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setShadingSpecular(swigCPtr, OdGiMaterialColor.getCPtr(specularColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void shadingSpecular(OdGiMaterialColor specularColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_shadingSpecular(swigCPtr, OdGiMaterialColor.getCPtr(specularColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setShadingOpacity(double opacityPercentage)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setShadingOpacity(swigCPtr, opacityPercentage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void shadingOpacity(out double opacityPercentage)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_shadingOpacity(swigCPtr, out opacityPercentage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDiffuseColorMode(OdGiMaterialTraits_DiffuseColorMode diffuseColorMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setDiffuseColorMode(swigCPtr, (int)diffuseColorMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTraits_DiffuseColorMode diffuseColorMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_diffuseColorMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_DiffuseColorMode)result;
	}

	public virtual void setShadowsOpacityEffect(double effectPercentage, double nonShadowLightsMergeEffect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setShadowsOpacityEffect__SWIG_0(swigCPtr, effectPercentage, nonShadowLightsMergeEffect);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setShadowsOpacityEffect(double effectPercentage)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setShadowsOpacityEffect__SWIG_1(swigCPtr, effectPercentage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double shadowsOpacityEffect(out double nonShadowLightsMergeEffect)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_shadowsOpacityEffect(swigCPtr, out nonShadowLightsMergeEffect);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSpecularHighlightingOverride(double overrideVal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setSpecularHighlightingOverride(swigCPtr, overrideVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double specularHighlightingOverride()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_specularHighlightingOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRoughness(OdGiMaterialMap roughnessMap, double strength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setRoughness(swigCPtr, OdGiMaterialMap.getCPtr(roughnessMap), strength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void roughness(OdGiMaterialMap roughnessMap, out double strength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_roughness(swigCPtr, OdGiMaterialMap.getCPtr(roughnessMap), out strength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCutouts(OdGiMaterialMap cutoutsMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setCutouts(swigCPtr, OdGiMaterialMap.getCPtr(cutoutsMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void cutouts(OdGiMaterialMap cutoutsMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_cutouts(swigCPtr, OdGiMaterialMap.getCPtr(cutoutsMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setReflectionMethod(OdGiMaterialTraits_ReflectionMethod method)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_setReflectionMethod(swigCPtr, (int)method);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTraits_ReflectionMethod reflectionMethod()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_reflectionMethod(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_ReflectionMethod)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

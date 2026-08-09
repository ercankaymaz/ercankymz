using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMaterialTraitsData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMaterialTraitsData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMaterialTraitsData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiMaterialTraitsData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMaterialTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiMaterialTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMaterialTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Assign(OdGiMaterialTraitsData other)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_Assign(swigCPtr, getCPtr(other));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdGiMaterialTraitsData other)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_IsEqual(swigCPtr, getCPtr(other));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiMaterialTraitsData other)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_IsNotEqual(swigCPtr, getCPtr(other));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void ambient(OdGiMaterialColor ambientColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_ambient(swigCPtr, OdGiMaterialColor.getCPtr(ambientColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void diffuse(OdGiMaterialColor diffuseColor, OdGiMaterialMap diffuseMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_diffuse(swigCPtr, OdGiMaterialColor.getCPtr(diffuseColor), OdGiMaterialMap.getCPtr(diffuseMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void specular(OdGiMaterialColor specularColor, OdGiMaterialMap specularMap, out double glossFactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_specular(swigCPtr, OdGiMaterialColor.getCPtr(specularColor), OdGiMaterialMap.getCPtr(specularMap), out glossFactor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void reflection(OdGiMaterialMap reflectionMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_reflection(swigCPtr, OdGiMaterialMap.getCPtr(reflectionMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void opacity(out double opacity, OdGiMaterialMap opacityMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_opacity(swigCPtr, out opacity, OdGiMaterialMap.getCPtr(opacityMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void bump(OdGiMaterialMap bumpMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_bump(swigCPtr, OdGiMaterialMap.getCPtr(bumpMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void refraction(out double refractionIndex, OdGiMaterialMap refractionMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_refraction(swigCPtr, out refractionIndex, OdGiMaterialMap.getCPtr(refractionMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double translucence()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_translucence(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double selfIllumination()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_selfIllumination(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double reflectivity()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_reflectivity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMaterialTraits_IlluminationModel illuminationModel()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_illuminationModel(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_IlluminationModel)result;
	}

	public OdGiMaterialTraits_ChannelFlags channelFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_channelFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_ChannelFlags)result;
	}

	public OdGiMaterialTraits_Mode mode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_mode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_Mode)result;
	}

	public void setAmbient(OdGiMaterialColor ambientColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setAmbient(swigCPtr, OdGiMaterialColor.getCPtr(ambientColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDiffuse(OdGiMaterialColor diffuseColor, OdGiMaterialMap diffuseMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setDiffuse(swigCPtr, OdGiMaterialColor.getCPtr(diffuseColor), OdGiMaterialMap.getCPtr(diffuseMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSpecular(OdGiMaterialColor specularColor, OdGiMaterialMap specularMap, double glossFactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setSpecular(swigCPtr, OdGiMaterialColor.getCPtr(specularColor), OdGiMaterialMap.getCPtr(specularMap), glossFactor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setReflection(OdGiMaterialMap reflectionMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setReflection(swigCPtr, OdGiMaterialMap.getCPtr(reflectionMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOpacity(double opacity, OdGiMaterialMap opacityMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setOpacity(swigCPtr, opacity, OdGiMaterialMap.getCPtr(opacityMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBump(OdGiMaterialMap bumpMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setBump(swigCPtr, OdGiMaterialMap.getCPtr(bumpMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRefraction(double refractionIndex, OdGiMaterialMap refractionMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setRefraction(swigCPtr, refractionIndex, OdGiMaterialMap.getCPtr(refractionMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTranslucence(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setTranslucence(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSelfIllumination(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setSelfIllumination(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setReflectivity(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setReflectivity(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setIlluminationModel(OdGiMaterialTraits_IlluminationModel model)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setIlluminationModel(swigCPtr, (int)model);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setChannelFlags(OdGiMaterialTraits_ChannelFlags flags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setChannelFlags(swigCPtr, (int)flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMode(OdGiMaterialTraits_Mode value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setMode(swigCPtr, (int)value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColorBleedScale(double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setColorBleedScale(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double colorBleedScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_colorBleedScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIndirectBumpScale(double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setIndirectBumpScale(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double indirectBumpScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_indirectBumpScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setReflectanceScale(double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setReflectanceScale(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double reflectanceScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_reflectanceScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTransmittanceScale(double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setTransmittanceScale(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double transmittanceScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_transmittanceScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTwoSided(bool flag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setTwoSided(swigCPtr, flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool twoSided()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_twoSided(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLuminanceMode(OdGiMaterialTraits_LuminanceMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setLuminanceMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMaterialTraits_LuminanceMode luminanceMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_luminanceMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_LuminanceMode)result;
	}

	public void setLuminance(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setLuminance(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double luminance()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_luminance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNormalMap(OdGiMaterialMap normalMap, OdGiMaterialTraits_NormalMapMethod method, double strength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setNormalMap(swigCPtr, OdGiMaterialMap.getCPtr(normalMap), (int)method, strength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void normalMap(OdGiMaterialMap normalMap, out OdGiMaterialTraits_NormalMapMethod method, out double strength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_normalMap(swigCPtr, OdGiMaterialMap.getCPtr(normalMap), out method, out strength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGlobalIllumination(OdGiMaterialTraits_GlobalIlluminationMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setGlobalIllumination(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMaterialTraits_GlobalIlluminationMode globalIllumination()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_globalIllumination(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_GlobalIlluminationMode)result;
	}

	public void setFinalGather(OdGiMaterialTraits_FinalGatherMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setFinalGather(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMaterialTraits_FinalGatherMode finalGather()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_finalGather(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_FinalGatherMode)result;
	}

	public void setEmission(OdGiMaterialColor emissionColor, OdGiMaterialMap emissionMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setEmission(swigCPtr, OdGiMaterialColor.getCPtr(emissionColor), OdGiMaterialMap.getCPtr(emissionMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void emission(OdGiMaterialColor emissionColor, OdGiMaterialMap emissionMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_emission(swigCPtr, OdGiMaterialColor.getCPtr(emissionColor), OdGiMaterialMap.getCPtr(emissionMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTint(OdGiMaterialColor tintColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setTint(swigCPtr, OdGiMaterialColor.getCPtr(tintColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void tint(OdGiMaterialColor tintColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_tint(swigCPtr, OdGiMaterialColor.getCPtr(tintColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setShadingAmbient(OdGiMaterialColor ambientColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setShadingAmbient(swigCPtr, OdGiMaterialColor.getCPtr(ambientColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void shadingAmbient(OdGiMaterialColor ambientColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_shadingAmbient(swigCPtr, OdGiMaterialColor.getCPtr(ambientColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setShadingDiffuse(OdGiMaterialColor diffuseColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setShadingDiffuse(swigCPtr, OdGiMaterialColor.getCPtr(diffuseColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void shadingDiffuse(OdGiMaterialColor diffuseColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_shadingDiffuse(swigCPtr, OdGiMaterialColor.getCPtr(diffuseColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setShadingSpecular(OdGiMaterialColor specularColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setShadingSpecular(swigCPtr, OdGiMaterialColor.getCPtr(specularColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void shadingSpecular(OdGiMaterialColor specularColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_shadingSpecular(swigCPtr, OdGiMaterialColor.getCPtr(specularColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setShadingOpacity(double opacityPercentage)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setShadingOpacity(swigCPtr, opacityPercentage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void shadingOpacity(out double opacityPercentage)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_shadingOpacity(swigCPtr, out opacityPercentage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDiffuseColorMode(OdGiMaterialTraits_DiffuseColorMode diffuseColorMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setDiffuseColorMode(swigCPtr, (int)diffuseColorMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMaterialTraits_DiffuseColorMode diffuseColorMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_diffuseColorMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_DiffuseColorMode)result;
	}

	public void setShadowsOpacityEffect(double shadowsOpacity, double nonShadowLightsMergeEffect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setShadowsOpacityEffect(swigCPtr, shadowsOpacity, nonShadowLightsMergeEffect);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double shadowsOpacityEffect(out double nonShadowLightsMergeEffect)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_shadowsOpacityEffect(swigCPtr, out nonShadowLightsMergeEffect);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSpecularHighlightingOverride(double overrideVal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setSpecularHighlightingOverride(swigCPtr, overrideVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double specularHighlightingOverride()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_specularHighlightingOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRoughness(OdGiMaterialMap roughnessMap, double strength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setRoughness(swigCPtr, OdGiMaterialMap.getCPtr(roughnessMap), strength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void roughness(OdGiMaterialMap roughnessMap, out double strength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_roughness(swigCPtr, OdGiMaterialMap.getCPtr(roughnessMap), out strength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCutouts(OdGiMaterialMap cutoutsMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setCutouts(swigCPtr, OdGiMaterialMap.getCPtr(cutoutsMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void cutouts(OdGiMaterialMap cutoutsMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_cutouts(swigCPtr, OdGiMaterialMap.getCPtr(cutoutsMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setReflectionMethod(OdGiMaterialTraits_ReflectionMethod method)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_setReflectionMethod(swigCPtr, (int)method);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMaterialTraits_ReflectionMethod reflectionMethod()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTraitsData_reflectionMethod(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_ReflectionMethod)result;
	}
}

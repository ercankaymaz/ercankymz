using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiVisualizeRTRenderSettingsTraitsData : OdGiRenderSettingsTraitsData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiVisualizeRTRenderSettingsTraitsData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiVisualizeRTRenderSettingsTraitsData obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiVisualizeRTRenderSettingsTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiVisualizeRTRenderSettingsTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiVisualizeRTRenderSettingsTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiVisualizeRTRenderSettingsTraitsData) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public void setRendererType(OdGiVisualizeRTRenderSettingsTraits_RendererType renderType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setRendererType(swigCPtr, (int)renderType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiVisualizeRTRenderSettingsTraits_RendererType rendererType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_rendererType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualizeRTRenderSettingsTraits_RendererType)result;
	}

	public void setRenderQuality(OdGiVisualizeRTRenderSettingsTraits_QualityLevel renderQual)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setRenderQuality(swigCPtr, (int)renderQual);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiVisualizeRTRenderSettingsTraits_QualityLevel renderQuality()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_renderQuality(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualizeRTRenderSettingsTraits_QualityLevel)result;
	}

	public void setDefaultShader(OdGiVisualizeRTRenderSettingsTraits_DefaultShader shader)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setDefaultShader(swigCPtr, (int)shader);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiVisualizeRTRenderSettingsTraits_DefaultShader defaultShader()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_defaultShader(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualizeRTRenderSettingsTraits_DefaultShader)result;
	}

	public void setTextureQuality(OdGiVisualizeRTRenderSettingsTraits_TextureQuality texQlty)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setTextureQuality(swigCPtr, (int)texQlty);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiVisualizeRTRenderSettingsTraits_TextureQuality textureQuality()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_textureQuality(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualizeRTRenderSettingsTraits_TextureQuality)result;
	}

	public void setPixelSamples(int nX, int nY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setPixelSamples(swigCPtr, nX, nY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void pixelSamples(out int nX, out int nY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_pixelSamples(swigCPtr, out nX, out nY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMaxBounces(uint nBounces)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setMaxBounces(swigCPtr, nBounces);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint maxBounces()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_maxBounces(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMaxSelfReflections(uint nRels)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setMaxSelfReflections(swigCPtr, nRels);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint maxSelfReflections()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_maxSelfReflections(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMaxSelfRefractions(uint nRefs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setMaxSelfRefractions(swigCPtr, nRefs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint maxSelfRefractions()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_maxSelfRefractions(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGeometryAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, uint nMaxLeafPrims, uint nNodeDepth, bool bSort)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setGeometryAccelerator(swigCPtr, (int)treeType, (int)splitMode, nMaxLeafPrims, nNodeDepth, bSort);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void geometryAccelerator(out OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, out OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, out uint nMaxLeafPrims, out uint nNodeDepth, out bool bSort)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_geometryAccelerator(swigCPtr, out treeType, out splitMode, out nMaxLeafPrims, out nNodeDepth, out bSort);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPrimitiveAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, uint nMaxLeafPrims, uint nNodeDepth, bool bSort)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setPrimitiveAccelerator(swigCPtr, (int)treeType, (int)splitMode, nMaxLeafPrims, nNodeDepth, bSort);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void primitiveAccelerator(out OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, out OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, out uint nMaxLeafPrims, out uint nNodeDepth, out bool bSort)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_primitiveAccelerator(swigCPtr, out treeType, out splitMode, out nMaxLeafPrims, out nNodeDepth, out bSort);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setToleranceOverride(bool bOverride, float fTol, double dTol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setToleranceOverride(swigCPtr, bOverride, fTol, dTol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool toleranceOverride(out float fTol, out double dTol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_toleranceOverride(swigCPtr, out fTol, out dTol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMinEnergy(float fEnergy)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setMinEnergy(swigCPtr, fEnergy);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public float minEnergy()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_minEnergy(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLinePrimitivesEnabled(bool bEnable, float fWidth)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setLinePrimitivesEnabled(swigCPtr, bEnable, fWidth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool linePrimitivesEnabled(out float fWidth)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_linePrimitivesEnabled(swigCPtr, out fWidth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMaxCPUThreads(uint nThreads)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setMaxCPUThreads(swigCPtr, nThreads);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint maxCPUThreads()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_maxCPUThreads(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTileSize(uint nWidth, uint nHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setTileSize(swigCPtr, nWidth, nHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void tileSize(out uint nWidth, out uint nHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_tileSize(swigCPtr, out nWidth, out nHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTileOrder(OdGiMrTileOrder_ order)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setTileOrder(swigCPtr, (int)order);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMrTileOrder_ tileOrder()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_tileOrder(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrTileOrder_)result;
	}

	public void setMaxGPUBufferSubdivisions(uint nSubdivs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setMaxGPUBufferSubdivisions(swigCPtr, nSubdivs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint maxGPUBufferSubdivisions()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_maxGPUBufferSubdivisions(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMinGPUBufferSubdivisionSize(uint nWidth, uint nHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setMinGPUBufferSubdivisionSize(swigCPtr, nWidth, nHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void minGPUBufferSubdivisionSize(out uint nWidth, out uint nHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_minGPUBufferSubdivisionSize(swigCPtr, out nWidth, out nHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGPUBufferScalePercents(uint nPercs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setGPUBufferScalePercents(swigCPtr, nPercs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint gpuBufferScalePercents()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_gpuBufferScalePercents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGPUWorkGroupSize(uint nThreads)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setGPUWorkGroupSize(swigCPtr, nThreads);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint gpuWorkGroupSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_gpuWorkGroupSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGPUTiledRendering(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setGPUTiledRendering(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool gpuTiledRendering()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_gpuTiledRendering(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGPUForceShadowMapsInsideReflections(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setGPUForceShadowMapsInsideReflections(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool gpuForceShadowMapsInsideReflections()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_gpuForceShadowMapsInsideReflections(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPartialRenderComponents(uint nComponents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setPartialRenderComponents(swigCPtr, nComponents);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint partialRenderComponents()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_partialRenderComponents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMinimalReflectionCutoff(float refCutoff)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setMinimalReflectionCutoff(swigCPtr, refCutoff);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public float minimalReflectionCutoff()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_minimalReflectionCutoff(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMinimalRefractionCutoff(float refCutoff)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setMinimalRefractionCutoff(swigCPtr, refCutoff);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public float minimalRefractionCutoff()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_minimalRefractionCutoff(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMinimalLightingCutoff(float lightCutoff)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setMinimalLightingCutoff(swigCPtr, lightCutoff);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public float minimalLightingCutoff()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_minimalLightingCutoff(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setShadowTypeOverride(OdGiVisualizeRTRenderSettingsTraits_ShadowTypeOverride shadowType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setShadowTypeOverride(swigCPtr, (int)shadowType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiVisualizeRTRenderSettingsTraits_ShadowTypeOverride shadowTypeOverride()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_shadowTypeOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualizeRTRenderSettingsTraits_ShadowTypeOverride)result;
	}

	public void setGlobalIlluminationEnabled(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setGlobalIlluminationEnabled(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool globalIlluminationEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_globalIlluminationEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGlobalIlluminationSamples(int nX, int nY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setGlobalIlluminationSamples(swigCPtr, nX, nY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void globalIlluminationSamples(out int nX, out int nY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_globalIlluminationSamples(swigCPtr, out nX, out nY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGlobalIlluminationRadius(float fRad)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setGlobalIlluminationRadius(swigCPtr, fRad);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public float globalIlluminationRadius()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_globalIlluminationRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGlobalIlluminationAutoRadiusEnabled(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setGlobalIlluminationAutoRadiusEnabled(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool globalIlluminationAutoRadiusEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_globalIlluminationAutoRadiusEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGlobalIlluminationAutoRadiusPercents(float fPerc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setGlobalIlluminationAutoRadiusPercents(swigCPtr, fPerc);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public float globalIlluminationAutoRadiusPercents()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_globalIlluminationAutoRadiusPercents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGlobalIlluminationOcclusionCoefficient(float fCoef)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setGlobalIlluminationOcclusionCoefficient(swigCPtr, fCoef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public float globalIlluminationOcclusionCoefficient()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_globalIlluminationOcclusionCoefficient(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRoughnessSamples(int nX, int nY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_setRoughnessSamples(swigCPtr, nX, nY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void roughnessSamples(out int nX, out int nY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_roughnessSamples(swigCPtr, out nX, out nY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsNotEqual(OdGiVisualizeRTRenderSettingsTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_IsNotEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGiVisualizeRTRenderSettingsTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_IsEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraitsData_director_connect(swigCPtr);
	}
}

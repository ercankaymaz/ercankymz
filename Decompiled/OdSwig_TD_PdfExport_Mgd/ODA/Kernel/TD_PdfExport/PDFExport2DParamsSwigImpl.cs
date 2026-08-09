using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class PDFExport2DParamsSwigImpl : PDFExport2DParams, PDFExportBaseParams, IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public PDFExport2DParamsSwigImpl(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(PDFExport2DParamsSwigImpl obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~PDFExport2DParamsSwigImpl()
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
					TD_PdfExport_GlobalsPINVOKE.delete_PDFExport2DParamsSwigImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef PDFExport2DParams.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_PDFExport2DParams_GetInterfaceCPtr(swigCPtr.Handle));
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef PDFExportBaseParams.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_PDFExportBaseParams_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public PDFExport2DParamsSwigImpl()
		: this(TD_PdfExport_GlobalsPINVOKE.new_PDFExport2DParamsSwigImpl__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(PDFExport2DParamsSwigImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public void setExportFlags(TD_PDF_2D_EXPORT_PDFExport2DParams_PDFExportFlags flags)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setExportFlags(swigCPtr, (int)flags);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_PDFExportFlags exportFlags()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_exportFlags(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_PDFExportFlags)result;
	}

	public void setSearchableTextType(TD_PDF_2D_EXPORT_PDFExport2DParams_SearchableTextType type)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setSearchableTextType(swigCPtr, (int)type);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_SearchableTextType searchableTextType()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_searchableTextType(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_SearchableTextType)result;
	}

	public void setColorPolicy(TD_PDF_2D_EXPORT_PDFExport2DParams_ColorPolicy policy)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setColorPolicy(swigCPtr, (int)policy);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_ColorPolicy colorPolicy()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_colorPolicy(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_ColorPolicy)result;
	}

	public void setBackground(uint background)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setBackground(swigCPtr, background);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint background()
	{
		uint result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_background(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPalette(uint[] pPalette)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setPalette(swigCPtr, pPalette);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint[] palette()
	{
		IntPtr intPtr = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_palette(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int num = 257;
		int[] array = new int[num];
		Marshal.Copy(intPtr, array, 0, num);
		return Array.ConvertAll(array, (int in_value) => (uint)in_value);
	}

	public void setGeomDPI(ushort dpi)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setGeomDPI(swigCPtr, dpi);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort getGeomDPI()
	{
		ushort result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_getGeomDPI(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHatchDPI(ushort dpi)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setHatchDPI(swigCPtr, dpi);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort hatchDPI()
	{
		ushort result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_hatchDPI(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColorImagesDPI(ushort dpi)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setColorImagesDPI(swigCPtr, dpi);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort colorImagesDPI()
	{
		ushort result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_colorImagesDPI(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBWImagesDPI(ushort dpi)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setBWImagesDPI(swigCPtr, dpi);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort bwImagesDPI()
	{
		ushort result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_bwImagesDPI(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSolidHatchesExportType(TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType type)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setSolidHatchesExportType(swigCPtr, (int)type);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType solidHatchesExportType()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_solidHatchesExportType(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType)result;
	}

	public void setGradientHatchesExportType(TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType type)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setGradientHatchesExportType(swigCPtr, (int)type);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType gradientHatchesExportType()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_gradientHatchesExportType(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType)result;
	}

	public void setOtherHatchesExportType(TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType arg0)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setOtherHatchesExportType(swigCPtr, (int)arg0);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType otherHatchesExportType()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_otherHatchesExportType(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType)result;
	}

	public bool imageCropping()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_imageCropping(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setImageCropping(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setImageCropping(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort dctQuality()
	{
		ushort result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_dctQuality(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDCTQuality(ushort quality)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setDCTQuality(swigCPtr, quality);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool monoImagesAsMask()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_monoImagesAsMask(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMonoImagesAsMask(bool bAsMask)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setMonoImagesAsMask(swigCPtr, bAsMask);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool get720DPIMode()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_get720DPIMode(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set720DPIMode(bool bMode)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_set720DPIMode(swigCPtr, bMode);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool useViewExtents()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_useViewExtents(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUseViewExtents(bool bViewExtents)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setUseViewExtents(swigCPtr, bViewExtents);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool dctCompression()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_dctCompression(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDCTCompression(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setDCTCompression(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool dctCompressionShadedViewports()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_dctCompressionShadedViewports(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDCTCompressionShadedViewports(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setDCTCompressionShadedViewports(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool upscaleImages()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_upscaleImages(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUpscaleImages(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setUpscaleImages(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTransparentShadedVpBg(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setTransparentShadedVpBg(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool transparentShadedVpBg()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_transparentShadedVpBg(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setForceDisableGsDevice(bool bDisable)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setForceDisableGsDevice(swigCPtr, bDisable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool forceDisableGsDevice()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_forceDisableGsDevice(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setShadedVpExportMode(TD_PDF_2D_EXPORT_PDFExport2DParams_PDFShadedViewportExportMode mode)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setShadedVpExportMode(swigCPtr, (int)mode);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_PDFShadedViewportExportMode shadedVpExportMode()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_shadedVpExportMode(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_PDFShadedViewportExportMode)result;
	}

	public bool export2XObject()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_export2XObject(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool useGsCache()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_useGsCache(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUseGsCache(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setUseGsCache(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isParallelVectorization()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_isParallelVectorization(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setParallelVectorization(bool bOn)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setParallelVectorization(swigCPtr, bOn);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUsePdfBlocks(bool bOn)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setUsePdfBlocks(swigCPtr, bOn);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isUsePdfBlocks()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_isUsePdfBlocks(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setXrefsAsPdfBlocks(bool bOn)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setXrefsAsPdfBlocks(swigCPtr, bOn);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isXrefsAsPdfBlocks()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_isXrefsAsPdfBlocks(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool searchableTextAsHiddenText()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_searchableTextAsHiddenText(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool searchableTextInRenderedViews()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_searchableTextInRenderedViews(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSearchableTextAsHiddenText(bool bOn)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setSearchableTextAsHiddenText(swigCPtr, bOn);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSearchableTextInRenderedViews(bool bOn)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setSearchableTextInRenderedViews(swigCPtr, bOn);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isTTFTextAsGeometry()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_isTTFTextAsGeometry(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSHXTextAsGeometry()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_isSHXTextAsGeometry(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableBookmarks(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_enableBookmarks(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool bookmarksEnabled()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_bookmarksEnabled(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdStringArray layoutNames()
	{
		OdStringArray result = new OdStringArray(TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_layoutNames(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLayoutNames(OdStringArray layoutNames)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setLayoutNames(swigCPtr, OdStringArray.getCPtr(layoutNames).Handle);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMeasuringType(TD_PDF_2D_EXPORT_PDFExport2DParams_PDFMeasuringType type)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setMeasuringType(swigCPtr, (int)type);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_PDFMeasuringType measuringType()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_measuringType(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_PDFMeasuringType)result;
	}

	protected PDFExport2DParamsSwigImpl(PDFExport2DParams other)
		: this(TD_PdfExport_GlobalsPINVOKE.new_PDFExport2DParamsSwigImpl__SWIG_1(other.GetInterfaceCPtr()), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(PDFExport2DParamsSwigImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public void setDatabase(OdRxObject pDb)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setDatabase(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxObject database()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setSelectionSetsArray(OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator pSSets)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setSelectionSetsArray(swigCPtr, OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator.getCPtr(pSSets));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator getSelectionSetsArray()
	{
		OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator result = new OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_getSelectionSetsArray(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLayouts(OdStringArray layouts, OdRxObjectPtrArray pDbArray)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setLayouts__SWIG_0(swigCPtr, OdStringArray.getCPtr(layouts).Handle, OdRxObjectPtrArray.getCPtr(pDbArray).Handle);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLayouts(OdStringArray layouts)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_setLayouts__SWIG_1(swigCPtr, OdStringArray.getCPtr(layouts).Handle);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addLayout(string s)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_addLayout(swigCPtr, s);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdStringArray layouts()
	{
		OdStringArray result = new OdStringArray(TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_layouts(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObjectPtrArray databases()
	{
		OdRxObjectPtrArray result = Helpers.GetObject<OdRxObjectPtrArray>(TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_databases(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearMultipleDbSettings()
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_clearMultipleDbSettings(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private void SwigDirectorConnect()
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport2DParamsSwigImpl_director_connect(swigCPtr);
	}
}

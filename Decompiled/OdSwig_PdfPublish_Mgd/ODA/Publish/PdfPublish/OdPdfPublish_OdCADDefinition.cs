using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdCADDefinition : OdPdfPublish_OdObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdCADDefinition(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdCADDefinition obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdCADDefinition(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPdfPublish_OdCADDefinition cast(OdRxObject pObj)
	{
		OdPdfPublish_OdCADDefinition rXObject = Helpers.GetRXObject<OdPdfPublish_OdCADDefinition>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdCADDefinition createObject()
	{
		OdPdfPublish_OdCADDefinition rXObject = Helpers.GetRXObject<OdPdfPublish_OdCADDefinition>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setDatabase(OdRxObject database)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setDatabase(swigCPtr, OdRxObject.getCPtr(database));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDatabaseWrapper(SWIGTYPE_p_OdPDF__OdDatabaseToPdfWrapperInterface database_wrapper)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setDatabaseWrapper(swigCPtr, SWIGTYPE_p_OdPDF__OdDatabaseToPdfWrapperInterface.getCPtr(database_wrapper));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLayoutName(string name)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setLayoutName(swigCPtr, name);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMediaSize(OdPdfPublish_Page_PaperUnits units, double width, double height)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setMediaSize(swigCPtr, (int)units, width, height);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setEmbededTrueTypeFonts(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setEmbededTrueTypeFonts(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTrueTypeFontAsGeometry(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setTrueTypeFontAsGeometry(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSHXTextAsGeometry(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setSHXTextAsGeometry(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextSearchable(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setTextSearchable(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSearchableTextAsHiddenText(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setSearchableTextAsHiddenText(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSearchableTextInRenderedViews(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setSearchableTextInRenderedViews(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setExportHyperlinks(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setExportHyperlinks(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGeomDPI(uint dpi)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setGeomDPI(swigCPtr, dpi);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBWImagesDPI(uint dpi)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setBWImagesDPI(swigCPtr, dpi);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColorImagesDPI(uint dpi)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setColorImagesDPI(swigCPtr, dpi);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMeasuring(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setMeasuring(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColorPolicy(OdPdfPublish_CAD_ColorPolicy policy)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setColorPolicy(swigCPtr, (int)policy);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUseSimpleGeomOptimization(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setUseSimpleGeomOptimization(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUseHLR(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setUseHLR(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUseFlateCompression(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setUseFlateCompression(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUseDctCompression(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setUseDctCompression(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDctCompressionQuality(ushort quality)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setDctCompressionQuality(swigCPtr, quality);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUseASCIIHexEncoding(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setUseASCIIHexEncoding(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUseGsCache(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setUseGsCache(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUseParallelVectorization(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setUseParallelVectorization(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setEnableLayers(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setEnableLayers(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setIncludeOffLayers(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setIncludeOffLayers(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSelectionSet(OdSelectionSet selection)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_setSelectionSet(swigCPtr, OdSelectionSet.getCPtr(selection));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxObject getDatabase()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getDatabase(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public SWIGTYPE_p_OdPDF__OdDatabaseToPdfWrapperInterface getDatabaseWrapper()
	{
		IntPtr intPtr = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getDatabaseWrapper(swigCPtr);
		SWIGTYPE_p_OdPDF__OdDatabaseToPdfWrapperInterface result = ((intPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_OdPDF__OdDatabaseToPdfWrapperInterface(intPtr, futureUse: false));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getLayoutName(ref string name)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(name);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getLayoutName(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				name = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getMediaSize(out OdPdfPublish_Page_PaperUnits units, out double width, out double height)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getMediaSize(swigCPtr, out units, out width, out height);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getEmbededTrueTypeFonts(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getEmbededTrueTypeFonts(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTrueTypeFontAsGeometry(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getTrueTypeFontAsGeometry(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSHXTextAsGeometry(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getSHXTextAsGeometry(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTextSearchable(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getTextSearchable(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSearchableTextAsHiddenText(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getSearchableTextAsHiddenText(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSearchableTextInRenderedViews(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getSearchableTextInRenderedViews(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getExportHyperlinks(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getExportHyperlinks(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getGeomDPI(out uint dpi)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getGeomDPI(swigCPtr, out dpi);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBWImagesDPI(out uint dpi)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getBWImagesDPI(swigCPtr, out dpi);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getColorImagesDPI(out uint dpi)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getColorImagesDPI(swigCPtr, out dpi);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getMeasuring(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getMeasuring(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getColorPolicy(out OdPdfPublish_CAD_ColorPolicy policy)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getColorPolicy(swigCPtr, out policy);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getUseSimpleGeomOptimization(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getUseSimpleGeomOptimization(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getUseHLR(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getUseHLR(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getUseFlateCompression(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getUseFlateCompression(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getUseDctCompression(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getUseDctCompression(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDctCompressionQuality(out ushort quality)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getDctCompressionQuality(swigCPtr, out quality);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getUseASCIIHexEncoding(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getUseASCIIHexEncoding(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getUseGsCache(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getUseGsCache(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getUseParallelVectorization(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getUseParallelVectorization(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getEnableLayers(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getEnableLayers(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getIncludeOffLayers(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getIncludeOffLayers(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSelectionSet(ref OdSelectionSet selection)
	{
		IntPtr jarg = ((selection == null) ? IntPtr.Zero : OdSelectionSet.getCPtr(selection).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getSelectionSet(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				selection = null;
			}
			else if (jarg != intPtr)
			{
				selection = Helpers.GetRXObject<OdSelectionSet>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADDefinition_getRealClassName(ptr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

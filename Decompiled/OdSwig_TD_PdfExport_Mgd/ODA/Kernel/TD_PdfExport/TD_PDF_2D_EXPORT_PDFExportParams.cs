using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_PDFToolkit;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class TD_PDF_2D_EXPORT_PDFExportParams : PDFExportDocumentParams, PDFExport2DParams, PDFExportBaseParams, PDFExport3DParams, PRCExportParams, IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public uint[] Palette
	{
		get
		{
			return UnMarshalPalette(TD_PdfExport_GlobalsPINVOKE.PDFExportParams_getPalette(swigCPtr));
		}
		set
		{
			IntPtr intPtr = MarshalPalette(value);
			TD_PdfExport_GlobalsPINVOKE.PDFExportParams_setPalette(swigCPtr, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public uint[] Palette_vb
	{
		get
		{
			return Palette;
		}
		set
		{
			Palette = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_2D_EXPORT_PDFExportParams(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_2D_EXPORT_PDFExportParams obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_2D_EXPORT_PDFExportParams()
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
					TD_PdfExport_GlobalsPINVOKE.delete_TD_PDF_2D_EXPORT_PDFExportParams(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef PDFExportDocumentParams.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_PDFExportDocumentParams_GetInterfaceCPtr(swigCPtr.Handle));
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef PDFExport2DParams.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_PDFExport2DParams_GetInterfaceCPtr(swigCPtr.Handle));
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef PDFExport3DParams.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_PDFExport3DParams_GetInterfaceCPtr(swigCPtr.Handle));
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef PRCExportParams.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_PRCExportParams_GetInterfaceCPtr(swigCPtr.Handle));
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef PDFExportBaseParams.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_PDFExportBaseParams_GetInterfaceCPtr(swigCPtr.Handle));
	}

	private static uint[] UnMarshalPalette(IntPtr p)
	{
		if (p == IntPtr.Zero)
		{
			return null;
		}
		uint[] array = new uint[256];
		for (int i = 0; i < 256; i++)
		{
			array[i] = (uint)Marshal.ReadInt32(p, i * 4);
		}
		return array;
	}

	private static IntPtr MarshalPalette(uint[] p)
	{
		if (p == null)
		{
			return IntPtr.Zero;
		}
		if (p.Length != 256)
		{
			throw new Exception("MarshalPalette: palette size must be 256");
		}
		IntPtr intPtr = Marshal.AllocCoTaskMem(1024);
		for (int i = 0; i < 256; i++)
		{
			Marshal.WriteInt32(intPtr, i * 4, (int)p[i]);
		}
		return intPtr;
	}

	public TD_PDF_2D_EXPORT_PDFExportParams()
		: this(TD_PdfExport_GlobalsPINVOKE.new_TD_PDF_2D_EXPORT_PDFExportParams(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOutput(OdStreamBuf output)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setOutput(swigCPtr, OdStreamBuf.getCPtr(output));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdStreamBuf output()
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_output(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public TD_PDF_2D_EXPORT_PdfExportReactor exportReactor()
	{
		IntPtr intPtr = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_exportReactor(swigCPtr);
		TD_PDF_2D_EXPORT_PdfExportReactor result = ((intPtr == IntPtr.Zero) ? null : new TD_PDF_2D_EXPORT_PdfExportReactor(intPtr, cMemoryOwn: false));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExportReactor(TD_PDF_2D_EXPORT_PdfExportReactor reactor)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setExportReactor(swigCPtr, TD_PDF_2D_EXPORT_PdfExportReactor.getCPtr(reactor));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPRCMode(TD_PDF_2D_EXPORT_PRCExportParams_PRCSupport flags)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setPRCMode(swigCPtr, (int)flags);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setStopOnError(bool bFlag)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setStopOnError(swigCPtr, bFlag);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool stopOnError()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_stopOnError(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVersion(OdPDF_PDFFormatVersions version)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setVersion(swigCPtr, (int)version);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPDF_PDFFormatVersions version()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_version(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdPDF_PDFFormatVersions)result;
	}

	public void setArchived(TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDF_A_mode mode)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setArchived(swigCPtr, (int)mode);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDF_A_mode archived()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_archived(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDF_A_mode)result;
	}

	public void setPageParams(OdArray_OdGsPageParams_OdObjectsAllocator pageParams)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setPageParams(swigCPtr, OdArray_OdGsPageParams_OdObjectsAllocator.getCPtr(pageParams));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdGsPageParams_OdObjectsAllocator pageParams()
	{
		OdArray_OdGsPageParams_OdObjectsAllocator result = new OdArray_OdGsPageParams_OdObjectsAllocator(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_pageParams(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTitle(string sTitle)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setTitle(swigCPtr, sTitle);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string title()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_title(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAuthor(string sAuthor)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setAuthor(swigCPtr, sAuthor);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string author()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_author(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSubject(string sSubject)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setSubject(swigCPtr, sSubject);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string subject()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_subject(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setKeywords(string sKeywords)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setKeywords(swigCPtr, sKeywords);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string keywords()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_keywords(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCreator(string sCreator)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setCreator(swigCPtr, sCreator);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string creator()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_creator(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setProducer(string sProducer)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setProducer(swigCPtr, sProducer);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string producer()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_producer(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUserPassword(string sUserPassword)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setUserPassword(swigCPtr, sUserPassword);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string userPassword()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_userPassword(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setOwnerPassword(string sOwnerPassword)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setOwnerPassword(swigCPtr, sOwnerPassword);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string ownerPassword()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_ownerPassword(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAccessPermissionFlags(TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDFAccessPermissionsFlags flags)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setAccessPermissionFlags(swigCPtr, (int)flags);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDFAccessPermissionsFlags accessPermissionFlags()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_accessPermissionFlags(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDFAccessPermissionsFlags)result;
	}

	public void addWatermark(TD_PDF_2D_EXPORT_Watermark wm)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_addWatermark(swigCPtr, TD_PDF_2D_EXPORT_Watermark.getCPtr(wm));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator watermarks()
	{
		OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator result = new OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_watermarks(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearWatermarks()
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_clearWatermarks(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setExportFlags(TD_PDF_2D_EXPORT_PDFExport2DParams_PDFExportFlags flags)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setExportFlags(swigCPtr, (int)flags);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_PDFExportFlags exportFlags()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_exportFlags(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_PDFExportFlags)result;
	}

	public void setSearchableTextType(TD_PDF_2D_EXPORT_PDFExport2DParams_SearchableTextType type)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setSearchableTextType(swigCPtr, (int)type);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_SearchableTextType searchableTextType()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_searchableTextType(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_SearchableTextType)result;
	}

	public void setColorPolicy(TD_PDF_2D_EXPORT_PDFExport2DParams_ColorPolicy policy)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setColorPolicy(swigCPtr, (int)policy);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_ColorPolicy colorPolicy()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_colorPolicy(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_ColorPolicy)result;
	}

	public void setBackground(uint background)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setBackground(swigCPtr, background);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint background()
	{
		uint result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_background(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPalette(uint[] pPalette)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setPalette(swigCPtr, pPalette);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint[] palette()
	{
		IntPtr intPtr = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_palette(swigCPtr);
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
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setGeomDPI(swigCPtr, dpi);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort getGeomDPI()
	{
		ushort result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_getGeomDPI(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHatchDPI(ushort dpi)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setHatchDPI(swigCPtr, dpi);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort hatchDPI()
	{
		ushort result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_hatchDPI(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColorImagesDPI(ushort dpi)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setColorImagesDPI(swigCPtr, dpi);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort colorImagesDPI()
	{
		ushort result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_colorImagesDPI(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBWImagesDPI(ushort dpi)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setBWImagesDPI(swigCPtr, dpi);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort bwImagesDPI()
	{
		ushort result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_bwImagesDPI(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSolidHatchesExportType(TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType type)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setSolidHatchesExportType(swigCPtr, (int)type);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType solidHatchesExportType()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_solidHatchesExportType(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType)result;
	}

	public void setGradientHatchesExportType(TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType type)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setGradientHatchesExportType(swigCPtr, (int)type);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType gradientHatchesExportType()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_gradientHatchesExportType(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType)result;
	}

	public void setOtherHatchesExportType(TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType arg0)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setOtherHatchesExportType(swigCPtr, (int)arg0);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType otherHatchesExportType()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_otherHatchesExportType(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType)result;
	}

	public bool imageCropping()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_imageCropping(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setImageCropping(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setImageCropping(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort dctQuality()
	{
		ushort result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_dctQuality(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDCTQuality(ushort quality)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setDCTQuality(swigCPtr, quality);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool monoImagesAsMask()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_monoImagesAsMask(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMonoImagesAsMask(bool bAsMask)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setMonoImagesAsMask(swigCPtr, bAsMask);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool get720DPIMode()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_get720DPIMode(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set720DPIMode(bool bMode)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_set720DPIMode(swigCPtr, bMode);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool useViewExtents()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_useViewExtents(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUseViewExtents(bool bViewExtents)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setUseViewExtents(swigCPtr, bViewExtents);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool dctCompression()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_dctCompression(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDCTCompression(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setDCTCompression(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool dctCompressionShadedViewports()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_dctCompressionShadedViewports(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDCTCompressionShadedViewports(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setDCTCompressionShadedViewports(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool upscaleImages()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_upscaleImages(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUpscaleImages(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setUpscaleImages(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTransparentShadedVpBg(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setTransparentShadedVpBg(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool transparentShadedVpBg()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_transparentShadedVpBg(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setForceDisableGsDevice(bool bDisable)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setForceDisableGsDevice(swigCPtr, bDisable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool forceDisableGsDevice()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_forceDisableGsDevice(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setShadedVpExportMode(TD_PDF_2D_EXPORT_PDFExport2DParams_PDFShadedViewportExportMode mode)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setShadedVpExportMode(swigCPtr, (int)mode);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_PDFShadedViewportExportMode shadedVpExportMode()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_shadedVpExportMode(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_PDFShadedViewportExportMode)result;
	}

	public bool export2XObject()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_export2XObject(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool useGsCache()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_useGsCache(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUseGsCache(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setUseGsCache(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isParallelVectorization()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_isParallelVectorization(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setParallelVectorization(bool bOn)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setParallelVectorization(swigCPtr, bOn);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUsePdfBlocks(bool bOn)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setUsePdfBlocks(swigCPtr, bOn);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isUsePdfBlocks()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_isUsePdfBlocks(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setXrefsAsPdfBlocks(bool bOn)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setXrefsAsPdfBlocks(swigCPtr, bOn);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isXrefsAsPdfBlocks()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_isXrefsAsPdfBlocks(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool searchableTextAsHiddenText()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_searchableTextAsHiddenText(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool searchableTextInRenderedViews()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_searchableTextInRenderedViews(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSearchableTextAsHiddenText(bool bOn)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setSearchableTextAsHiddenText(swigCPtr, bOn);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSearchableTextInRenderedViews(bool bOn)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setSearchableTextInRenderedViews(swigCPtr, bOn);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isTTFTextAsGeometry()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_isTTFTextAsGeometry(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSHXTextAsGeometry()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_isSHXTextAsGeometry(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableBookmarks(bool bEnable)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_enableBookmarks(swigCPtr, bEnable);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool bookmarksEnabled()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_bookmarksEnabled(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdStringArray layoutNames()
	{
		OdStringArray result = new OdStringArray(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_layoutNames(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLayoutNames(OdStringArray layoutNames)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setLayoutNames(swigCPtr, OdStringArray.getCPtr(layoutNames).Handle);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMeasuringType(TD_PDF_2D_EXPORT_PDFExport2DParams_PDFMeasuringType type)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setMeasuringType(swigCPtr, (int)type);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExport2DParams_PDFMeasuringType measuringType()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_measuringType(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExport2DParams_PDFMeasuringType)result;
	}

	public bool hasPrcBackground()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_hasPrcBackground(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint getPrcBackground()
	{
		uint result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_getPrcBackground(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPrcBackground(uint bacgr)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setPrcBackground(swigCPtr, bacgr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearPrcBackground()
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_clearPrcBackground(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public PDF3D_ENUMS_PRCRenderingMode getPrcRenderingMode()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_getPrcRenderingMode(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PDF3D_ENUMS_PRCRenderingMode)result;
	}

	public void setPrcRenderingMode(PDF3D_ENUMS_PRCRenderingMode renderMode)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setPrcRenderingMode(swigCPtr, (int)renderMode);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PRCExportParams_PRCSupport getPRCMode()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_getPRCMode(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PRCExportParams_PRCSupport)result;
	}

	public OdPrcContextForPdfExport getPRCContext()
	{
		OdPrcContextForPdfExport rXObject = Helpers.GetRXObject<OdPrcContextForPdfExport>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_getPRCContext(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setPRCContext(OdRxObject pContext)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setPRCContext(swigCPtr, OdRxObject.getCPtr(pContext));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasPrcBrepCompression(out PDF3D_ENUMS_PRCCompressionLevel compressionLev)
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_hasPrcBrepCompression(swigCPtr, out compressionLev);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasPrcTessellationCompression()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_hasPrcTessellationCompression(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPRCCompression(PDF3D_ENUMS_PRCCompressionLevel compressionLevel, bool bCompressBrep, bool bCompressTessellation)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setPRCCompression(swigCPtr, (int)compressionLevel, bCompressBrep, bCompressTessellation);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public PDF3D_ENUMS_PrcExportColorComponentBehavior getPrcExportAmbientColorBehavior()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_getPrcExportAmbientColorBehavior(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PDF3D_ENUMS_PrcExportColorComponentBehavior)result;
	}

	public void setPrcExportAmbientColorBehavior(PDF3D_ENUMS_PrcExportColorComponentBehavior value)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setPrcExportAmbientColorBehavior(swigCPtr, (int)value);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDatabase(OdRxObject pDb)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setDatabase(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxObject database()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setSelectionSetsArray(OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator pSSets)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setSelectionSetsArray(swigCPtr, OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator.getCPtr(pSSets));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator getSelectionSetsArray()
	{
		OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator result = new OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_getSelectionSetsArray(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLayouts(OdStringArray layouts, OdRxObjectPtrArray pDbArray)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setLayouts__SWIG_0(swigCPtr, OdStringArray.getCPtr(layouts).Handle, OdRxObjectPtrArray.getCPtr(pDbArray).Handle);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLayouts(OdStringArray layouts)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_setLayouts__SWIG_1(swigCPtr, OdStringArray.getCPtr(layouts).Handle);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addLayout(string s)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_addLayout(swigCPtr, s);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdStringArray layouts()
	{
		OdStringArray result = new OdStringArray(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_layouts(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObjectPtrArray databases()
	{
		OdRxObjectPtrArray result = Helpers.GetObject<OdRxObjectPtrArray>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_databases(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearMultipleDbSettings()
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PDFExportParams_clearMultipleDbSettings(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

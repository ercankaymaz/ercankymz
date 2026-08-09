using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class PDFExportDocumentParamsSwigImpl : PDFExportDocumentParams, IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public PDFExportDocumentParamsSwigImpl(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(PDFExportDocumentParamsSwigImpl obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~PDFExportDocumentParamsSwigImpl()
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
					TD_PdfExport_GlobalsPINVOKE.delete_PDFExportDocumentParamsSwigImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef PDFExportDocumentParams.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_PDFExportDocumentParams_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public void setVersion(OdPDF_PDFFormatVersions version)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_setVersion(swigCPtr, (int)version);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPDF_PDFFormatVersions version()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_version(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdPDF_PDFFormatVersions)result;
	}

	public void setArchived(TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDF_A_mode mode)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_setArchived(swigCPtr, (int)mode);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDF_A_mode archived()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_archived(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDF_A_mode)result;
	}

	public void setPageParams(OdArray_OdGsPageParams_OdObjectsAllocator pageParams)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_setPageParams(swigCPtr, OdArray_OdGsPageParams_OdObjectsAllocator.getCPtr(pageParams));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdGsPageParams_OdObjectsAllocator pageParams()
	{
		OdArray_OdGsPageParams_OdObjectsAllocator result = new OdArray_OdGsPageParams_OdObjectsAllocator(TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_pageParams(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTitle(string sTitle)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_setTitle(swigCPtr, sTitle);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string title()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_title(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAuthor(string sAuthor)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_setAuthor(swigCPtr, sAuthor);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string author()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_author(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSubject(string sSubject)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_setSubject(swigCPtr, sSubject);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string subject()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_subject(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setKeywords(string sKeywords)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_setKeywords(swigCPtr, sKeywords);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string keywords()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_keywords(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCreator(string sCreator)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_setCreator(swigCPtr, sCreator);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string creator()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_creator(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setProducer(string sProducer)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_setProducer(swigCPtr, sProducer);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string producer()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_producer(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUserPassword(string sUserPassword)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_setUserPassword(swigCPtr, sUserPassword);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string userPassword()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_userPassword(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setOwnerPassword(string sOwnerPassword)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_setOwnerPassword(swigCPtr, sOwnerPassword);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string ownerPassword()
	{
		string result = TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_ownerPassword(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAccessPermissionFlags(TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDFAccessPermissionsFlags flags)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_setAccessPermissionFlags(swigCPtr, (int)flags);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDFAccessPermissionsFlags accessPermissionFlags()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_accessPermissionFlags(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDFAccessPermissionsFlags)result;
	}

	public void addWatermark(TD_PDF_2D_EXPORT_Watermark wm)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_addWatermark(swigCPtr, TD_PDF_2D_EXPORT_Watermark.getCPtr(wm));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator watermarks()
	{
		OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator result = new OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator(TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_watermarks(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearWatermarks()
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_clearWatermarks(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected PDFExportDocumentParamsSwigImpl()
		: this(TD_PdfExport_GlobalsPINVOKE.new_PDFExportDocumentParamsSwigImpl(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(PDFExportDocumentParamsSwigImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportDocumentParamsSwigImpl_director_connect(swigCPtr);
	}
}

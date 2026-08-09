using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_PDFToolkit;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class TD_PDF_2D_EXPORT_PdfExportParamsForXObject : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public TD_PDF_PDFPageDictionary m_pCurrentPage
	{
		get
		{
			TD_PDF_PDFPageDictionary result = Helpers.GetObject<TD_PDF_PDFPageDictionary>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_pCurrentPage_get(swigCPtr), bOwn: true, bTryAddToTransaction: false);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			IntPtr jarg = ((value == null) ? IntPtr.Zero : TD_PDF_PDFPageDictionary.getCPtr(value).Handle);
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_pCurrentPage_set(swigCPtr, ref jarg);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public TD_PDF_PDFXObjectForm m_pXobjectForm
	{
		get
		{
			TD_PDF_PDFXObjectForm result = Helpers.GetObject<TD_PDF_PDFXObjectForm>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_pXobjectForm_get(swigCPtr), bOwn: true, bTryAddToTransaction: false);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			IntPtr jarg = ((value == null) ? IntPtr.Zero : TD_PDF_PDFXObjectForm.getCPtr(value).Handle);
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_pXobjectForm_set(swigCPtr, ref jarg);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public TD_PDF_PDFFontOptimizer m_FontOptimizer
	{
		get
		{
			TD_PDF_PDFFontOptimizer result = new TD_PDF_PDFFontOptimizer(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_FontOptimizer_get(swigCPtr), cMemoryOwn: false);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_FontOptimizer_set(swigCPtr, TD_PDF_PDFFontOptimizer.getCPtr(value));
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdStringArray m_BookmarkNames
	{
		get
		{
			OdStringArray result = new OdStringArray(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_BookmarkNames_get(swigCPtr), cMemoryOwn: false);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_BookmarkNames_set(swigCPtr, OdStringArray.getCPtr(value).Handle);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGePoint3dArray m_BookmarkPoints
	{
		get
		{
			OdGePoint3dArray result = new OdGePoint3dArray(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_BookmarkPoints_get(swigCPtr), cMemoryOwn: false);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_BookmarkPoints_set(swigCPtr, OdGePoint3dArray.getCPtr(value).Handle);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_2D_EXPORT_PdfExportParamsForXObject(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_2D_EXPORT_PdfExportParamsForXObject obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_2D_EXPORT_PdfExportParamsForXObject()
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
					TD_PdfExport_GlobalsPINVOKE.delete_TD_PDF_2D_EXPORT_PdfExportParamsForXObject(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public TD_PDF_2D_EXPORT_PdfExportParamsForXObject(TD_PDF_PDFFontOptimizer optimizer)
		: this(TD_PdfExport_GlobalsPINVOKE.new_TD_PDF_2D_EXPORT_PdfExportParamsForXObject(TD_PDF_PDFFontOptimizer.getCPtr(optimizer)), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

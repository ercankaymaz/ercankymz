using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class TD_PDF_2D_EXPORT_PdfExportReactor : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_2D_EXPORT_PdfExportReactor(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_2D_EXPORT_PdfExportReactor obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_2D_EXPORT_PdfExportReactor()
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
					TD_PdfExport_GlobalsPINVOKE.delete_TD_PDF_2D_EXPORT_PdfExportReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void beginViewVectorization(OdGsBaseVectorizer vect)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PdfExportReactor_beginViewVectorization(swigCPtr, OdGsBaseVectorizer.getCPtr(vect));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endViewVectorization(OdGsBaseVectorizer vect)
	{
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_PdfExportReactor_endViewVectorization(swigCPtr, OdGsBaseVectorizer.getCPtr(vect));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFVersion : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFVersion(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFVersion obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_PDFVersion()
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFVersion(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public TD_PDF_PDFVersion()
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_TD_PDF_PDFVersion__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_PDFVersion(SWIGTYPE_p_OdPDF__PDFFormatVersions PdfVer)
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_TD_PDF_PDFVersion__SWIG_1(SWIGTYPE_p_OdPDF__PDFFormatVersions.getCPtr(PdfVer)), cMemoryOwn: true)
	{
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public SWIGTYPE_p_OdPDF__PDFFormatVersions Version()
	{
		SWIGTYPE_p_OdPDF__PDFFormatVersions result = new SWIGTYPE_p_OdPDF__PDFFormatVersions(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFVersion_Version(swigCPtr), futureUse: true);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string asString()
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFVersion_asString(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public SWIGTYPE_p_OdPDF__PDFFormatVersions FromString(string str)
	{
		SWIGTYPE_p_OdPDF__PDFFormatVersions result = new SWIGTYPE_p_OdPDF__PDFFormatVersions(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFVersion_FromString(swigCPtr, str), futureUse: true);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public TD_PDF_PDFVersion Assign(SWIGTYPE_p_OdPDF__PDFFormatVersions ver)
	{
		TD_PDF_PDFVersion result = new TD_PDF_PDFVersion(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFVersion_Assign(swigCPtr, SWIGTYPE_p_OdPDF__PDFFormatVersions.getCPtr(ver)), cMemoryOwn: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(TD_PDF_PDFVersion ver)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFVersion_IsEqual__SWIG_0(swigCPtr, getCPtr(ver));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(SWIGTYPE_p_OdPDF__PDFFormatVersions ver)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFVersion_IsEqual__SWIG_1(swigCPtr, SWIGTYPE_p_OdPDF__PDFFormatVersions.getCPtr(ver));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

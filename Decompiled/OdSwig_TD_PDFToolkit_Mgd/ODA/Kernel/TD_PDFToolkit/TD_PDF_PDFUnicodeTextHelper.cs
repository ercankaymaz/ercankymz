using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFUnicodeTextHelper : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFUnicodeTextHelper(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFUnicodeTextHelper obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_PDFUnicodeTextHelper()
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFUnicodeTextHelper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public TD_PDF_PDFUnicodeTextHelper()
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_TD_PDF_PDFUnicodeTextHelper(), cMemoryOwn: true)
	{
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void enableFixParenthesis(bool b)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFUnicodeTextHelper_enableFixParenthesis__SWIG_0(swigCPtr, b);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void enableFixParenthesis()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFUnicodeTextHelper_enableFixParenthesis__SWIG_1(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool exportUnicodeMarker()
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFUnicodeTextHelper_exportUnicodeMarker(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExportUnicodeMarker(bool b)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFUnicodeTextHelper_setExportUnicodeMarker(swigCPtr, b);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

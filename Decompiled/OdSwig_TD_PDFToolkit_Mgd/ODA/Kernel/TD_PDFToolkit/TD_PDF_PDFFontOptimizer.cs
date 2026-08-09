using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFFontOptimizer : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFFontOptimizer(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFFontOptimizer obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_PDFFontOptimizer()
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFFontOptimizer(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public TD_PDF_PDFFontOptimizer()
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_TD_PDF_PDFFontOptimizer(), cMemoryOwn: true)
	{
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clear(bool bOptimizedEmbeddedMode, bool bEmbeddedMode, bool bPDFA)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFontOptimizer_clear(swigCPtr, bOptimizedEmbeddedMode, bEmbeddedMode, bPDFA);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addText(TD_PDF_PDFFont pFont, string pStr)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFontOptimizer_addText(swigCPtr, TD_PDF_PDFFont.getCPtr(pFont), pStr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addUnicodeText(TD_PDF_PDFFont pFont, OdUInt16ValuesArray pUnicode)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFontOptimizer_addUnicodeText(swigCPtr, TD_PDF_PDFFont.getCPtr(pFont), OdUInt16ValuesArray.getCPtr(pUnicode));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Optimize()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFontOptimizer_Optimize(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

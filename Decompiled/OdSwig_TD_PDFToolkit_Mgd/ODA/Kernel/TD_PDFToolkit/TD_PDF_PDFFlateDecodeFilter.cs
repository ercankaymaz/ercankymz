using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFFlateDecodeFilter : TD_PDF_PDFStreamFilter
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFFlateDecodeFilter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFlateDecodeFilter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFFlateDecodeFilter obj)
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFFlateDecodeFilter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override bool isKindOf(TD_PDF_PDFTypeId objType)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFlateDecodeFilter_isKindOf(swigCPtr, (int)objType);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override TD_PDF_PDFTypeId type()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFlateDecodeFilter_type(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_PDFTypeId)result;
	}

	public static TD_PDF_PDFFlateDecodeFilter createObject()
	{
		TD_PDF_PDFFlateDecodeFilter result = Helpers.GetObject<TD_PDF_PDFFlateDecodeFilter>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFlateDecodeFilter_createObject(), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTmpStream(OdStreamBuf pTmpStream)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFlateDecodeFilter_setTmpStream(swigCPtr, OdStreamBuf.getCPtr(pTmpStream));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override string getName()
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFlateDecodeFilter_getName(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool DecodeStream(TD_PDF_PDFIStream pStream, TD_PDF_PDFDecodeParametersDictionary pParameters)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFlateDecodeFilter_DecodeStream(swigCPtr, TD_PDF_PDFIStream.getCPtr(pStream), TD_PDF_PDFDecodeParametersDictionary.getCPtr(pParameters));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool EncodeStream(TD_PDF_PDFIStream pStream, TD_PDF_PDFDecodeParametersDictionary pParameters)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFlateDecodeFilter_EncodeStream(swigCPtr, TD_PDF_PDFIStream.getCPtr(pStream), TD_PDF_PDFDecodeParametersDictionary.getCPtr(pParameters));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFlateDecodeFilter_getRealClassName(ptr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

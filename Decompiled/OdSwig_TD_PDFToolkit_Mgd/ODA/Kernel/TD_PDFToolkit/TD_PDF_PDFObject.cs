using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFObject : TD_PDF_PDFBaseObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFObject(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFObject_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFObject obj)
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFObject(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new virtual bool isKindOf(TD_PDF_PDFTypeId objType)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFObject_isKindOf(swigCPtr, (int)objType);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual TD_PDF_PDFTypeId type()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFObject_type(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_PDFTypeId)result;
	}

	public virtual void IndirectObjectID(PDFObjectID arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFObject_IndirectObjectID(swigCPtr, PDFObjectID.getCPtr(arg0));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool Export(TD_PDF_PDFIStream pStream, TD_PDF_PDFVersion ver)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFObject_Export(swigCPtr, TD_PDF_PDFIStream.getCPtr(pStream), TD_PDF_PDFVersion.getCPtr(ver));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool ExportLikeRef(TD_PDF_PDFIStream arg0, TD_PDF_PDFVersion arg1)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFObject_ExportLikeRef(swigCPtr, TD_PDF_PDFIStream.getCPtr(arg0), TD_PDF_PDFVersion.getCPtr(arg1));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool ExportLikeRefObj(TD_PDF_PDFIStream arg0, TD_PDF_PDFVersion arg1)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFObject_ExportLikeRefObj(swigCPtr, TD_PDF_PDFIStream.getCPtr(arg0), TD_PDF_PDFVersion.getCPtr(arg1));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isIndirect()
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFObject_isIndirect(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual TD_PDF_PDFDocument document()
	{
		IntPtr intPtr = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFObject_document(swigCPtr);
		TD_PDF_PDFDocument result = ((intPtr == IntPtr.Zero) ? null : new TD_PDF_PDFDocument(intPtr, cMemoryOwn: false));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDocument(TD_PDF_PDFDocument pDoc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFObject_setDocument(swigCPtr, TD_PDF_PDFDocument.getCPtr(pDoc));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void clearDictionaries()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFObject_clearDictionaries(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFObject_getRealClassName(ptr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

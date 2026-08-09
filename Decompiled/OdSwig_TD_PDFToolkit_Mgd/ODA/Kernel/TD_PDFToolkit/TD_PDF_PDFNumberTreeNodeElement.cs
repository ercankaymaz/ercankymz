using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFNumberTreeNodeElement : TD_PDF_PDFObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFNumberTreeNodeElement(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFNumberTreeNodeElement_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFNumberTreeNodeElement obj)
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFNumberTreeNodeElement(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override bool isKindOf(TD_PDF_PDFTypeId objType)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFNumberTreeNodeElement_isKindOf(swigCPtr, (int)objType);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual TD_PDF_PDFTypeId type()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFNumberTreeNodeElement_type(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_PDFTypeId)result;
	}

	public static TD_PDF_PDFNumberTreeNodeElement createObject(TD_PDF_PDFDocument pDoc, bool isIndirect)
	{
		TD_PDF_PDFNumberTreeNodeElement result = Helpers.GetObject<TD_PDF_PDFNumberTreeNodeElement>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFNumberTreeNodeElement_createObject__SWIG_0(TD_PDF_PDFDocument.getCPtr(pDoc), isIndirect), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFNumberTreeNodeElement createObject(TD_PDF_PDFDocument pDoc)
	{
		TD_PDF_PDFNumberTreeNodeElement result = Helpers.GetObject<TD_PDF_PDFNumberTreeNodeElement>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFNumberTreeNodeElement_createObject__SWIG_1(TD_PDF_PDFDocument.getCPtr(pDoc)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getIndex()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFNumberTreeNodeElement_getIndex(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIndex(int index)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFNumberTreeNodeElement_setIndex(swigCPtr, index);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_PDFObject getObject()
	{
		TD_PDF_PDFObject result = Helpers.GetObject<TD_PDF_PDFObject>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFNumberTreeNodeElement_getObject(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool Export(TD_PDF_PDFIStream pStream, TD_PDF_PDFVersion ver)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFNumberTreeNodeElement_Export(swigCPtr, TD_PDF_PDFIStream.getCPtr(pStream), TD_PDF_PDFVersion.getCPtr(ver));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFNumberTreeNodeElement createObject(TD_PDF_PDFDocument pDoc, uint index, TD_PDF_PDFObject pObject, bool isIndirect)
	{
		TD_PDF_PDFNumberTreeNodeElement result = Helpers.GetObject<TD_PDF_PDFNumberTreeNodeElement>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFNumberTreeNodeElement_createObject__SWIG_2(TD_PDF_PDFDocument.getCPtr(pDoc), index, TD_PDF_PDFObject.getCPtr(pObject), isIndirect), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFNumberTreeNodeElement createObject(TD_PDF_PDFDocument pDoc, uint index, TD_PDF_PDFObject pObject)
	{
		TD_PDF_PDFNumberTreeNodeElement result = Helpers.GetObject<TD_PDF_PDFNumberTreeNodeElement>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFNumberTreeNodeElement_createObject__SWIG_3(TD_PDF_PDFDocument.getCPtr(pDoc), index, TD_PDF_PDFObject.getCPtr(pObject)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFNumberTreeNodeElement_getRealClassName(ptr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

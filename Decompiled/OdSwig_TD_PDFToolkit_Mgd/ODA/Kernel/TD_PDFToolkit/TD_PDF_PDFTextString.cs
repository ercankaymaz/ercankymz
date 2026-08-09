using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFTextString : TD_PDF_PDFObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFTextString(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFTextString obj)
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFTextString(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override bool isKindOf(TD_PDF_PDFTypeId objType)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_isKindOf(swigCPtr, (int)objType);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual TD_PDF_PDFTypeId type()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_type(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_PDFTypeId)result;
	}

	public static TD_PDF_PDFTextString createObject(TD_PDF_PDFDocument pDoc, bool isIndirect)
	{
		TD_PDF_PDFTextString result = Helpers.GetObject<TD_PDF_PDFTextString>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_createObject__SWIG_0(TD_PDF_PDFDocument.getCPtr(pDoc), isIndirect), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFTextString createObject(TD_PDF_PDFDocument pDoc)
	{
		TD_PDF_PDFTextString result = Helpers.GetObject<TD_PDF_PDFTextString>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_createObject__SWIG_1(TD_PDF_PDFDocument.getCPtr(pDoc)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFTextString createObject(TD_PDF_PDFDocument pDoc, string pStr, bool isIndirect)
	{
		TD_PDF_PDFTextString result = Helpers.GetObject<TD_PDF_PDFTextString>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_createObject__SWIG_2(TD_PDF_PDFDocument.getCPtr(pDoc), pStr, isIndirect), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFTextString createObject(TD_PDF_PDFDocument pDoc, string pStr)
	{
		TD_PDF_PDFTextString result = Helpers.GetObject<TD_PDF_PDFTextString>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_createObject__SWIG_3(TD_PDF_PDFDocument.getCPtr(pDoc), pStr), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFTextString createObject_as_OdAnsiString(TD_PDF_PDFDocument pDoc, string pStr, bool isIndirect)
	{
		TD_PDF_PDFTextString result = Helpers.GetObject<TD_PDF_PDFTextString>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_createObject_as_OdAnsiString__SWIG_0(TD_PDF_PDFDocument.getCPtr(pDoc), pStr, isIndirect), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFTextString createObject_as_OdAnsiString(TD_PDF_PDFDocument pDoc, string pStr)
	{
		TD_PDF_PDFTextString result = Helpers.GetObject<TD_PDF_PDFTextString>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_createObject_as_OdAnsiString__SWIG_1(TD_PDF_PDFDocument.getCPtr(pDoc), pStr), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(string str)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_isEqualTo(swigCPtr, str);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getAsUnicode()
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_getAsUnicode(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clear()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_clear(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isInUnicode()
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_isInUnicode(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public TD_PDF_PDFTextString set(string stringSrc)
	{
		TD_PDF_PDFTextString result = Helpers.GetObject<TD_PDF_PDFTextString>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_set(swigCPtr, stringSrc), bOwn: false, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public TD_PDF_PDFTextString set_as_OdAnsiString(string stringSrc)
	{
		TD_PDF_PDFTextString result = Helpers.GetObject<TD_PDF_PDFTextString>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_set_as_OdAnsiString(swigCPtr, stringSrc), bOwn: false, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool Export(TD_PDF_PDFIStream pStream, TD_PDF_PDFVersion ver)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_Export(swigCPtr, TD_PDF_PDFIStream.getCPtr(pStream), TD_PDF_PDFVersion.getCPtr(ver));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isAscii(string s)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_isAscii(swigCPtr, s);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRoundBrackets(bool bFlag)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_setRoundBrackets(swigCPtr, bFlag);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFTextString_getRealClassName(ptr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

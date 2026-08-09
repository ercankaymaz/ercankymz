using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFType1Font : TD_PDF_PDFFont
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFType1Font(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFType1Font obj)
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFType1Font(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override bool isKindOf(TD_PDF_PDFTypeId objType)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_isKindOf(swigCPtr, (int)objType);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual TD_PDF_PDFTypeId type()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_type(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_PDFTypeId)result;
	}

	public new static TD_PDF_PDFType1Font createObject(TD_PDF_PDFDocument pDoc, bool isIndirect)
	{
		TD_PDF_PDFType1Font result = Helpers.GetObject<TD_PDF_PDFType1Font>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_createObject__SWIG_0(TD_PDF_PDFDocument.getCPtr(pDoc), isIndirect), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static TD_PDF_PDFType1Font createObject(TD_PDF_PDFDocument pDoc)
	{
		TD_PDF_PDFType1Font result = Helpers.GetObject<TD_PDF_PDFType1Font>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_createObject__SWIG_1(TD_PDF_PDFDocument.getCPtr(pDoc)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setStandardType1Fonts(TD_PDF_PDFType1Font_StandardType1FontsEnum font_type)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_setStandardType1Fonts(swigCPtr, (int)font_type);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static string getStandardType1FontsName(TD_PDF_PDFType1Font_StandardType1FontsEnum font_type)
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_getStandardType1FontsName((int)font_type);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double getTextCapHeight(TD_PDF_PDFType1Font_StandardType1FontsEnum font_type)
	{
		double result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_getTextCapHeight((int)font_type);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double getTextAscender(TD_PDF_PDFType1Font_StandardType1FontsEnum font_type)
	{
		double result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_getTextAscender((int)font_type);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double getTextDescender(TD_PDF_PDFType1Font_StandardType1FontsEnum font_type)
	{
		double result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_getTextDescender((int)font_type);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static ODRECT_ getTextBBox(TD_PDF_PDFType1Font_StandardType1FontsEnum font_type)
	{
		ODRECT_ result = new ODRECT_(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_getTextBBox((int)font_type), cMemoryOwn: true);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double getTextBaseWidth(TD_PDF_PDFType1Font_StandardType1FontsEnum font_type, string text)
	{
		double result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_getTextBaseWidth((int)font_type, text);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFType1Font_getRealClassName(ptr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

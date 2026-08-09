using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFFont : TD_PDF_PDFDictionary
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFFont(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFFont obj)
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFFont(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override bool isKindOf(TD_PDF_PDFTypeId objType)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_isKindOf(swigCPtr, (int)objType);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual TD_PDF_PDFTypeId type()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_type(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_PDFTypeId)result;
	}

	public new static TD_PDF_PDFFont createObject(TD_PDF_PDFDocument pDoc, bool isIndirect)
	{
		TD_PDF_PDFFont result = Helpers.GetObject<TD_PDF_PDFFont>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_createObject__SWIG_0(TD_PDF_PDFDocument.getCPtr(pDoc), isIndirect), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static TD_PDF_PDFFont createObject(TD_PDF_PDFDocument pDoc)
	{
		TD_PDF_PDFFont result = Helpers.GetObject<TD_PDF_PDFFont>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_createObject__SWIG_1(TD_PDF_PDFDocument.getCPtr(pDoc)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool truncateFont(ushort nFirstChar, ushort nLastChar)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_truncateFont__SWIG_0(swigCPtr, nFirstChar, nLastChar);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool truncateFont(ushort nFirstChar, ushort nLastChar, OdUInt16Array fontUsedUnicodeChars, bool bEmbedded)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_truncateFont__SWIG_1(swigCPtr, nFirstChar, nLastChar, OdUInt16Array.getCPtr(fontUsedUnicodeChars).Handle, bEmbedded);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool truncateFont(ushort nFirstChar, ushort nLastChar, OdUInt16Array fontUsedUnicodeChars)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_truncateFont__SWIG_2(swigCPtr, nFirstChar, nLastChar, OdUInt16Array.getCPtr(fontUsedUnicodeChars).Handle);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPseudoBold(bool bBold)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_setPseudoBold(swigCPtr, bBold);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPseudoItalic(bool bItalic)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_setPseudoItalic(swigCPtr, bItalic);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isPseudoBold()
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_isPseudoBold(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isPseudoItalic()
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_isPseudoItalic(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setNonUnicodeTable(bool bFlag)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_setNonUnicodeTable(swigCPtr, bFlag);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isNonUnicodeTable()
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_isNonUnicodeTable(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFFont_getRealClassName(ptr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

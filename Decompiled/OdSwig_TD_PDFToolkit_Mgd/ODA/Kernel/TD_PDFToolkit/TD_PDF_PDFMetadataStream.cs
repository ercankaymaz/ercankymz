using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFMetadataStream : TD_PDF_PDFStream
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFMetadataStream(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFMetadataStream obj)
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFMetadataStream(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override bool isKindOf(TD_PDF_PDFTypeId objType)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_isKindOf(swigCPtr, (int)objType);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual TD_PDF_PDFTypeId type()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_type(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_PDFTypeId)result;
	}

	public static TD_PDF_PDFMetadataStream createObject(TD_PDF_PDFDocument pDoc, bool isIndirect)
	{
		TD_PDF_PDFMetadataStream result = Helpers.GetObject<TD_PDF_PDFMetadataStream>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_createObject__SWIG_0(TD_PDF_PDFDocument.getCPtr(pDoc), isIndirect), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFMetadataStream createObject(TD_PDF_PDFDocument pDoc)
	{
		TD_PDF_PDFMetadataStream result = Helpers.GetObject<TD_PDF_PDFMetadataStream>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_createObject__SWIG_1(TD_PDF_PDFDocument.getCPtr(pDoc)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public TD_PDF_PDFMetadataStreamDictionary getDictionary()
	{
		TD_PDF_PDFMetadataStreamDictionary result = Helpers.GetObject<TD_PDF_PDFMetadataStreamDictionary>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_getDictionary(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void putData(string pBuf, uint nSize)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_putData(swigCPtr, pBuf, nSize);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getData(string pBuf, uint nSize)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_getData(swigCPtr, pBuf, nSize);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTitle(string sTitle)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_setTitle(swigCPtr, sTitle);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAuthor(string sAuthor)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_setAuthor(swigCPtr, sAuthor);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSubject(string sSubject)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_setSubject(swigCPtr, sSubject);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setKeywords(string sKeywords)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_setKeywords(swigCPtr, sKeywords);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCreator(string sCreator)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_setCreator(swigCPtr, sCreator);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setProducer(string sProducer)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_setProducer(swigCPtr, sProducer);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCreationDate(OdTimeStamp creationDate)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_setCreationDate(swigCPtr, OdTimeStamp.getCPtr(creationDate));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPdfALevelConf(ushort lev, ushort conf)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_setPdfALevelConf(swigCPtr, lev, conf);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool Export(TD_PDF_PDFIStream pStream, TD_PDF_PDFVersion ver)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_Export(swigCPtr, TD_PDF_PDFIStream.getCPtr(pStream), TD_PDF_PDFVersion.getCPtr(ver));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFMetadataStream_getRealClassName(ptr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

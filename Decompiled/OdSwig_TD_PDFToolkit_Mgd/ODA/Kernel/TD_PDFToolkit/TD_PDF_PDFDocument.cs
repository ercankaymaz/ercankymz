using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFDocument : IDisposable
{
	public delegate bool SwigDelegateTD_PDF_PDFDocument_0(IntPtr pStream, IntPtr ver);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateTD_PDF_PDFDocument_0 swigDelegate0;

	private static Type[] swigMethodTypes0 = new Type[2]
	{
		typeof(TD_PDF_PDFIStream),
		typeof(TD_PDF_PDFVersion)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFDocument(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFDocument obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_PDFDocument()
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFDocument(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public TD_PDF_PDFDocument()
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_TD_PDF_PDFDocument(), cMemoryOwn: true)
	{
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(TD_PDF_PDFDocument) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public void clearDictionaries()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_clearDictionaries(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string getUniqueTempPath()
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_getUniqueTempPath(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getUniqueKey()
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_getUniqueKey(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTmpStream(OdStreamBuf pTmpStream)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_setTmpStream(swigCPtr, OdStreamBuf.getCPtr(pTmpStream));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool encodingEnabled()
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_encodingEnabled(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableEncoding(bool bEnable)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_enableEncoding(swigCPtr, bEnable);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool encodingASCIIHEXEnabled()
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_encodingASCIIHEXEnabled(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableEncodingASCIIHEX(bool bEnable)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_enableEncodingASCIIHEX(swigCPtr, bEnable);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool encodingDCTEnabled()
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_encodingDCTEnabled(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableEncodingDCT(bool bEnable)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_enableEncodingDCT(swigCPtr, bEnable);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isPdfA()
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_isPdfA(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPdfA(bool bEnable)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_setPdfA(swigCPtr, bEnable);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool useQPDF()
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_useQPDF(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUseQPDF(bool bEnable)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_setUseQPDF(swigCPtr, bEnable);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_PDFVersion getVersion()
	{
		TD_PDF_PDFVersion result = new TD_PDF_PDFVersion(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_getVersion(swigCPtr), cMemoryOwn: true);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool Export(TD_PDF_PDFIStream pStream, TD_PDF_PDFVersion ver)
	{
		bool result = (SwigDerivedClassHasMethod("Export", swigMethodTypes0) ? TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_ExportSwigExplicitTD_PDF_PDFDocument(swigCPtr, TD_PDF_PDFIStream.getCPtr(pStream), TD_PDF_PDFVersion.getCPtr(ver)) : TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_Export(swigCPtr, TD_PDF_PDFIStream.getCPtr(pStream), TD_PDF_PDFVersion.getCPtr(ver)));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool AddObject(TD_PDF_PDFObject pObj)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_AddObject(swigCPtr, TD_PDF_PDFObject.getCPtr(pObj));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void RemoveObject(TD_PDF_PDFObject pObj)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_RemoveObject(swigCPtr, TD_PDF_PDFObject.getCPtr(pObj));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool setRoot(TD_PDF_PDFCatalogDictionary pObj)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_setRoot(swigCPtr, TD_PDF_PDFCatalogDictionary.getCPtr(pObj));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public TD_PDF_PDFCatalogDictionary Root()
	{
		TD_PDF_PDFCatalogDictionary result = Helpers.GetObject<TD_PDF_PDFCatalogDictionary>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_Root(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setDocumentInformation(TD_PDF_PDFDocumentInformation pDI)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_setDocumentInformation(swigCPtr, TD_PDF_PDFDocumentInformation.getCPtr(pDI));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public TD_PDF_PDFDocumentInformation getDocumentInformation()
	{
		TD_PDF_PDFDocumentInformation result = Helpers.GetObject<TD_PDF_PDFDocumentInformation>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_getDocumentInformation(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public PDFObjectID getNextObjectID()
	{
		PDFObjectID result = new PDFObjectID(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_getNextObjectID(swigCPtr), cMemoryOwn: true);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public PDFObjectID getLastObjectID()
	{
		PDFObjectID result = new PDFObjectID(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_getLastObjectID(swigCPtr), cMemoryOwn: true);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool RegistryFilter(TD_PDF_PDFStreamFilter pFilter)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_RegistryFilter(swigCPtr, TD_PDF_PDFStreamFilter.getCPtr(pFilter));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool HasFilter(string FilterName)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_HasFilter(swigCPtr, FilterName);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public TD_PDF_PDFStreamFilter GetFilter(string FilterName)
	{
		TD_PDF_PDFStreamFilter result = Helpers.GetObject<TD_PDF_PDFStreamFilter>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_GetFilter(swigCPtr, FilterName), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("Export", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodExport;
		}
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDocument_director_connect(swigCPtr, swigDelegate0);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(TD_PDF_PDFDocument));
	}

	private bool SwigDirectorMethodExport(IntPtr pStream, IntPtr ver)
	{
		return Export(Helpers.GetObject<TD_PDF_PDFIStream>(pStream, bOwn: false, bTryAddToTransaction: false), new TD_PDF_PDFVersion(ver, cMemoryOwn: false));
	}
}

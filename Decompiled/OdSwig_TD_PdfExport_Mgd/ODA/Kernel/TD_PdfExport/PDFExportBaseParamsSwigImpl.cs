using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class PDFExportBaseParamsSwigImpl : PDFExportBaseParams, IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public PDFExportBaseParamsSwigImpl(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(PDFExportBaseParamsSwigImpl obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~PDFExportBaseParamsSwigImpl()
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
					TD_PdfExport_GlobalsPINVOKE.delete_PDFExportBaseParamsSwigImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef PDFExportBaseParams.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_PdfExport_GlobalsPINVOKE.PDFExportBaseParamsSwigImpl_PDFExportBaseParams_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public void setDatabase(OdRxObject pDb)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportBaseParamsSwigImpl_setDatabase(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxObject database()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_PdfExport_GlobalsPINVOKE.PDFExportBaseParamsSwigImpl_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setSelectionSetsArray(OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator pSSets)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportBaseParamsSwigImpl_setSelectionSetsArray(swigCPtr, OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator.getCPtr(pSSets));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator getSelectionSetsArray()
	{
		OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator result = new OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(TD_PdfExport_GlobalsPINVOKE.PDFExportBaseParamsSwigImpl_getSelectionSetsArray(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLayouts(OdStringArray layouts, OdRxObjectPtrArray pDbArray)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportBaseParamsSwigImpl_setLayouts__SWIG_0(swigCPtr, OdStringArray.getCPtr(layouts).Handle, OdRxObjectPtrArray.getCPtr(pDbArray).Handle);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLayouts(OdStringArray layouts)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportBaseParamsSwigImpl_setLayouts__SWIG_1(swigCPtr, OdStringArray.getCPtr(layouts).Handle);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addLayout(string s)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportBaseParamsSwigImpl_addLayout(swigCPtr, s);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdStringArray layouts()
	{
		OdStringArray result = new OdStringArray(TD_PdfExport_GlobalsPINVOKE.PDFExportBaseParamsSwigImpl_layouts(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObjectPtrArray databases()
	{
		OdRxObjectPtrArray result = Helpers.GetObject<OdRxObjectPtrArray>(TD_PdfExport_GlobalsPINVOKE.PDFExportBaseParamsSwigImpl_databases(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearMultipleDbSettings()
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportBaseParamsSwigImpl_clearMultipleDbSettings(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected PDFExportBaseParamsSwigImpl()
		: this(TD_PdfExport_GlobalsPINVOKE.new_PDFExportBaseParamsSwigImpl__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(PDFExportBaseParamsSwigImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected PDFExportBaseParamsSwigImpl(PDFExportBaseParams other)
		: this(TD_PdfExport_GlobalsPINVOKE.new_PDFExportBaseParamsSwigImpl__SWIG_1(other.GetInterfaceCPtr()), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(PDFExportBaseParamsSwigImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExportBaseParamsSwigImpl_director_connect(swigCPtr);
	}
}

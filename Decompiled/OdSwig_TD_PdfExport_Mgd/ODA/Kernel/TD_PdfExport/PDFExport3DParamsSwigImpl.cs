using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_PDFToolkit;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class PDFExport3DParamsSwigImpl : PDFExport3DParams, PRCExportParams, PDFExportBaseParams, IDisposable
{
	public delegate void SwigDelegatePDFExport3DParamsSwigImpl_0(int flags);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegatePDFExport3DParamsSwigImpl_0 swigDelegate0;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(TD_PDF_2D_EXPORT_PRCExportParams_PRCSupport) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public PDFExport3DParamsSwigImpl(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(PDFExport3DParamsSwigImpl obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~PDFExport3DParamsSwigImpl()
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
					TD_PdfExport_GlobalsPINVOKE.delete_PDFExport3DParamsSwigImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef PDFExport3DParams.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_PDFExport3DParams_GetInterfaceCPtr(swigCPtr.Handle));
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef PRCExportParams.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_PRCExportParams_GetInterfaceCPtr(swigCPtr.Handle));
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef PDFExportBaseParams.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_PDFExportBaseParams_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public bool hasPrcBackground()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_hasPrcBackground(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint getPrcBackground()
	{
		uint result = TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_getPrcBackground(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPrcBackground(uint bacgr)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_setPrcBackground(swigCPtr, bacgr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearPrcBackground()
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_clearPrcBackground(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public PDF3D_ENUMS_PRCRenderingMode getPrcRenderingMode()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_getPrcRenderingMode(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PDF3D_ENUMS_PRCRenderingMode)result;
	}

	public void setPrcRenderingMode(PDF3D_ENUMS_PRCRenderingMode renderMode)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_setPrcRenderingMode(swigCPtr, (int)renderMode);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected PDFExport3DParamsSwigImpl()
		: this(TD_PdfExport_GlobalsPINVOKE.new_PDFExport3DParamsSwigImpl__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(PDFExport3DParamsSwigImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected PDFExport3DParamsSwigImpl(PRCExportParams prc_export_params)
		: this(TD_PdfExport_GlobalsPINVOKE.new_PDFExport3DParamsSwigImpl__SWIG_1(prc_export_params.GetInterfaceCPtr()), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(PDFExport3DParamsSwigImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual void setPRCMode(TD_PDF_2D_EXPORT_PRCExportParams_PRCSupport flags)
	{
		if (SwigDerivedClassHasMethod("setPRCMode", swigMethodTypes0))
		{
			TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_setPRCModeSwigExplicitPDFExport3DParamsSwigImpl(swigCPtr, (int)flags);
		}
		else
		{
			TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_setPRCMode(swigCPtr, (int)flags);
		}
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_2D_EXPORT_PRCExportParams_PRCSupport getPRCMode()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_getPRCMode(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_2D_EXPORT_PRCExportParams_PRCSupport)result;
	}

	public OdPrcContextForPdfExport getPRCContext()
	{
		OdPrcContextForPdfExport rXObject = Helpers.GetRXObject<OdPrcContextForPdfExport>(TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_getPRCContext(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setPRCContext(OdRxObject pContext)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_setPRCContext(swigCPtr, OdRxObject.getCPtr(pContext));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasPrcBrepCompression(out PDF3D_ENUMS_PRCCompressionLevel compressionLev)
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_hasPrcBrepCompression(swigCPtr, out compressionLev);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasPrcTessellationCompression()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_hasPrcTessellationCompression(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPRCCompression(PDF3D_ENUMS_PRCCompressionLevel compressionLevel, bool bCompressBrep, bool bCompressTessellation)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_setPRCCompression(swigCPtr, (int)compressionLevel, bCompressBrep, bCompressTessellation);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public PDF3D_ENUMS_PrcExportColorComponentBehavior getPrcExportAmbientColorBehavior()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_getPrcExportAmbientColorBehavior(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PDF3D_ENUMS_PrcExportColorComponentBehavior)result;
	}

	public void setPrcExportAmbientColorBehavior(PDF3D_ENUMS_PrcExportColorComponentBehavior value)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_setPrcExportAmbientColorBehavior(swigCPtr, (int)value);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDatabase(OdRxObject pDb)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_setDatabase(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxObject database()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setSelectionSetsArray(OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator pSSets)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_setSelectionSetsArray(swigCPtr, OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator.getCPtr(pSSets));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator getSelectionSetsArray()
	{
		OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator result = new OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_getSelectionSetsArray(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLayouts(OdStringArray layouts, OdRxObjectPtrArray pDbArray)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_setLayouts__SWIG_0(swigCPtr, OdStringArray.getCPtr(layouts).Handle, OdRxObjectPtrArray.getCPtr(pDbArray).Handle);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLayouts(OdStringArray layouts)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_setLayouts__SWIG_1(swigCPtr, OdStringArray.getCPtr(layouts).Handle);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addLayout(string s)
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_addLayout(swigCPtr, s);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdStringArray layouts()
	{
		OdStringArray result = new OdStringArray(TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_layouts(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObjectPtrArray databases()
	{
		OdRxObjectPtrArray result = Helpers.GetObject<OdRxObjectPtrArray>(TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_databases(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearMultipleDbSettings()
	{
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_clearMultipleDbSettings(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("setPRCMode", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodsetPRCMode;
		}
		TD_PdfExport_GlobalsPINVOKE.PDFExport3DParamsSwigImpl_director_connect(swigCPtr, swigDelegate0);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(PDFExport3DParamsSwigImpl));
	}

	private void SwigDirectorMethodsetPRCMode(int flags)
	{
		try
		{
			setPRCMode((TD_PDF_2D_EXPORT_PRCExportParams_PRCSupport)flags);
		}
		catch (OdEdEmptyInput err)
		{
			TD_PdfExport_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_PdfExport_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_PdfExport_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_PdfExport_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class TD_PDF_2D_EXPORT_OdPdfExport : OdRxObject
{
	public delegate IntPtr SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_1();

	public delegate void SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_2(IntPtr pSource);

	public delegate uint SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_3(IntPtr pParams);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_4(uint errorCode);

	public delegate uint SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_5(IntPtr pParams, IntPtr outStreamsPRC);

	public delegate uint SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_6(IntPtr pParams, IntPtr pExportParams, double xobject_width, double xobject_height);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_0 swigDelegate0;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_1 swigDelegate1;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_2 swigDelegate2;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_3 swigDelegate3;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_4 swigDelegate4;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_5 swigDelegate5;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(TD_PDF_2D_EXPORT_PDFExportParams) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(PRCExportParams),
		typeof(PRCStreamsMap)
	};

	private static Type[] swigMethodTypes6 = new Type[4]
	{
		typeof(PDFExport2DParams),
		typeof(TD_PDF_2D_EXPORT_PdfExportParamsForXObject),
		typeof(double),
		typeof(double)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_2D_EXPORT_OdPdfExport(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_2D_EXPORT_OdPdfExport obj)
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
					TD_PdfExport_GlobalsPINVOKE.delete_TD_PDF_2D_EXPORT_OdPdfExport(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static TD_PDF_2D_EXPORT_OdPdfExport cast(OdRxObject pObj)
	{
		TD_PDF_2D_EXPORT_OdPdfExport rXObject = Helpers.GetRXObject<TD_PDF_2D_EXPORT_OdPdfExport>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_isASwigExplicitTD_PDF_2D_EXPORT_OdPdfExport(swigCPtr) : TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_queryXSwigExplicitTD_PDF_2D_EXPORT_OdPdfExport(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static TD_PDF_2D_EXPORT_OdPdfExport createObject()
	{
		TD_PDF_2D_EXPORT_OdPdfExport rXObject = Helpers.GetRXObject<TD_PDF_2D_EXPORT_OdPdfExport>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint exportPdf(TD_PDF_2D_EXPORT_PDFExportParams pParams)
	{
		uint result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_exportPdf(swigCPtr, TD_PDF_2D_EXPORT_PDFExportParams.getCPtr(pParams));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string exportPdfErrorCode(uint errorCode)
	{
		string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_exportPdfErrorCode(swigCPtr, errorCode);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint exportToPRCStreams(PRCExportParams pParams, PRCStreamsMap outStreamsPRC)
	{
		uint result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_exportToPRCStreams(swigCPtr, pParams.GetInterfaceCPtr(), PRCStreamsMap.getCPtr(outStreamsPRC));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint export2XObject(PDFExport2DParams pParams, TD_PDF_2D_EXPORT_PdfExportParamsForXObject pExportParams, double xobject_width, double xobject_height)
	{
		uint result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_export2XObject(swigCPtr, pParams.GetInterfaceCPtr(), TD_PDF_2D_EXPORT_PdfExportParamsForXObject.getCPtr(pExportParams), xobject_width, xobject_height);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_getRealClassName(ptr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public TD_PDF_2D_EXPORT_OdPdfExport()
		: this(TD_PdfExport_GlobalsPINVOKE.new_TD_PDF_2D_EXPORT_OdPdfExport(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(TD_PDF_2D_EXPORT_OdPdfExport) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("exportPdf", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodexportPdf;
		}
		if (SwigDerivedClassHasMethod("exportPdfErrorCode", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodexportPdfErrorCode;
		}
		if (SwigDerivedClassHasMethod("exportToPRCStreams", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodexportToPRCStreams;
		}
		if (SwigDerivedClassHasMethod("export2XObject", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodexport2XObject;
		}
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExport_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(TD_PDF_2D_EXPORT_OdPdfExport));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
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

	private uint SwigDirectorMethodexportPdf(IntPtr pParams)
	{
		return exportPdf(new TD_PDF_2D_EXPORT_PDFExportParams(pParams, cMemoryOwn: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodexportPdfErrorCode(uint errorCode)
	{
		return exportPdfErrorCode(errorCode);
	}

	private uint SwigDirectorMethodexportToPRCStreams(IntPtr pParams, IntPtr outStreamsPRC)
	{
		return exportToPRCStreams(new PRCExportParamsSwigImpl(pParams, cMemoryOwn: false), new PRCStreamsMap(outStreamsPRC, cMemoryOwn: false));
	}

	private uint SwigDirectorMethodexport2XObject(IntPtr pParams, IntPtr pExportParams, double xobject_width, double xobject_height)
	{
		return export2XObject(new PDFExport2DParamsSwigImpl(pParams, cMemoryOwn: false), (pExportParams == IntPtr.Zero) ? null : new TD_PDF_2D_EXPORT_PdfExportParamsForXObject(pExportParams, cMemoryOwn: false), xobject_width, xobject_height);
	}
}

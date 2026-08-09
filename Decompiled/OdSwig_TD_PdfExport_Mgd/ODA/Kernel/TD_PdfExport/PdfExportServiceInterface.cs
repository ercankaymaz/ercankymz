using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class PdfExportServiceInterface : OdRxObject
{
	public delegate IntPtr SwigDelegatePdfExportServiceInterface_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegatePdfExportServiceInterface_1();

	public delegate void SwigDelegatePdfExportServiceInterface_2(IntPtr pSource);

	public delegate IntPtr SwigDelegatePdfExportServiceInterface_3(IntPtr pDb);

	public delegate int SwigDelegatePdfExportServiceInterface_4(IntPtr pBuffer, IntPtr context, IntPtr params_);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegatePdfExportServiceInterface_0 swigDelegate0;

	private SwigDelegatePdfExportServiceInterface_1 swigDelegate1;

	private SwigDelegatePdfExportServiceInterface_2 swigDelegate2;

	private SwigDelegatePdfExportServiceInterface_3 swigDelegate3;

	private SwigDelegatePdfExportServiceInterface_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(OdRxObject),
		typeof(PDF2PRCExportParams)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public PdfExportServiceInterface(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(PdfExportServiceInterface obj)
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
					TD_PdfExport_GlobalsPINVOKE.delete_PdfExportServiceInterface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static PdfExportServiceInterface cast(OdRxObject pObj)
	{
		PdfExportServiceInterface rXObject = Helpers.GetRXObject<PdfExportServiceInterface>(TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_isASwigExplicitPdfExportServiceInterface(swigCPtr) : TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_queryXSwigExplicitPdfExportServiceInterface(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static PdfExportServiceInterface createObject()
	{
		PdfExportServiceInterface rXObject = Helpers.GetRXObject<PdfExportServiceInterface>(TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject createPrcExportContext(OdRxObject pDb)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_createPrcExportContext(swigCPtr, OdRxObject.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult serialize(OdStreamBuf pBuffer, OdRxObject context, PDF2PRCExportParams params_)
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_serialize(swigCPtr, OdStreamBuf.getCPtr(pBuffer), OdRxObject.getCPtr(context), PDF2PRCExportParams.getCPtr(params_));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_getRealClassName(ptr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult ExportPrc(OdRxObject context, OdGiDrawable pDrawable, PDF2PRCExportParams params_)
	{
		int result = TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_ExportPrc(swigCPtr, OdRxObject.getCPtr(context), OdGiDrawable.getCPtr(pDrawable), PDF2PRCExportParams.getCPtr(params_));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public PdfExportServiceInterface()
		: this(TD_PdfExport_GlobalsPINVOKE.new_PdfExportServiceInterface(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(PdfExportServiceInterface) != GetType();
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
		if (SwigDerivedClassHasMethod("createPrcExportContext", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcreatePrcExportContext;
		}
		if (SwigDerivedClassHasMethod("serialize", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodserialize;
		}
		TD_PdfExport_GlobalsPINVOKE.PdfExportServiceInterface_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(PdfExportServiceInterface));
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

	private IntPtr SwigDirectorMethodcreatePrcExportContext(IntPtr pDb)
	{
		return OdRxObject.getCPtr(createPrcExportContext(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private int SwigDirectorMethodserialize(IntPtr pBuffer, IntPtr context, IntPtr params_)
	{
		return (int)serialize(Helpers.GetRXObject<OdStreamBuf>(pBuffer, bOwn: true, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(context, bOwn: true, bTryAddToTransaction: false), (params_ == IntPtr.Zero) ? null : new PDF2PRCExportParams(params_, cMemoryOwn: false));
	}
}

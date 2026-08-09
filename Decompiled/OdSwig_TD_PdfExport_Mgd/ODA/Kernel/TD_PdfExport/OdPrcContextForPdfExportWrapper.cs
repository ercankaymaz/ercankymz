using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class OdPrcContextForPdfExportWrapper : OdPrcContextForPdfExport
{
	public delegate IntPtr SwigDelegateOdPrcContextForPdfExportWrapper_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcContextForPdfExportWrapper_1();

	public delegate void SwigDelegateOdPrcContextForPdfExportWrapper_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPrcContextForPdfExportWrapper_3(IntPtr pDrawable, IntPtr entity, IntPtr pView, uint viewportidx);

	public delegate void SwigDelegateOdPrcContextForPdfExportWrapper_4(IntPtr pDrawable, IntPtr viewportObjectId, IntPtr pGiContext, IntPtr cameraView, IntPtr modelToWorld, IntPtr extents);

	public delegate void SwigDelegateOdPrcContextForPdfExportWrapper_5(IntPtr userData);

	public delegate bool SwigDelegateOdPrcContextForPdfExportWrapper_6();

	public delegate void SwigDelegateOdPrcContextForPdfExportWrapper_7(bool flag);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcContextForPdfExportWrapper_0 swigDelegate0;

	private SwigDelegateOdPrcContextForPdfExportWrapper_1 swigDelegate1;

	private SwigDelegateOdPrcContextForPdfExportWrapper_2 swigDelegate2;

	private SwigDelegateOdPrcContextForPdfExportWrapper_3 swigDelegate3;

	private SwigDelegateOdPrcContextForPdfExportWrapper_4 swigDelegate4;

	private SwigDelegateOdPrcContextForPdfExportWrapper_5 swigDelegate5;

	private SwigDelegateOdPrcContextForPdfExportWrapper_6 swigDelegate6;

	private SwigDelegateOdPrcContextForPdfExportWrapper_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(OdGiDrawable),
		typeof(OdGiPathNode),
		typeof(OdGsClientViewInfo),
		typeof(uint).MakeByRefType()
	};

	private static Type[] swigMethodTypes4 = new Type[6]
	{
		typeof(OdGiDrawable),
		typeof(OdDbStub),
		typeof(OdGiContext),
		typeof(OdGeMatrix3d),
		typeof(OdGeMatrix3d),
		typeof(OdGeExtents3d)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(bool) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcContextForPdfExportWrapper(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcContextForPdfExportWrapper obj)
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
					TD_PdfExport_GlobalsPINVOKE.delete_OdPrcContextForPdfExportWrapper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPrcContextForPdfExportWrapper cast(OdRxObject pObj)
	{
		OdPrcContextForPdfExportWrapper rXObject = Helpers.GetRXObject<OdPrcContextForPdfExportWrapper>(TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_isASwigExplicitOdPrcContextForPdfExportWrapper(swigCPtr) : TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_queryXSwigExplicitOdPrcContextForPdfExportWrapper(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public PRCStreamsMap getOutputPRC()
	{
		PRCStreamsMap result = new PRCStreamsMap(TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_getOutputPRC(swigCPtr), cMemoryOwn: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setOutputPRC(PRCStreamsMap streamsPRC)
	{
		TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_setOutputPRC(swigCPtr, PRCStreamsMap.getCPtr(streamsPRC));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcContextForPdfExport getUserContext()
	{
		OdPrcContextForPdfExport rXObject = Helpers.GetRXObject<OdPrcContextForPdfExport>(TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_getUserContext(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setUserContext(OdPrcContextForPdfExport userContext)
	{
		TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_setUserContext(swigCPtr, OdPrcContextForPdfExport.getCPtr(userContext));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool shouldExportAsPRC(OdGiDrawable pDrawable, OdGiPathNode entity, OdGsClientViewInfo pView, out uint viewportidx)
	{
		bool result = (SwigDerivedClassHasMethod("shouldExportAsPRC", swigMethodTypes3) ? TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_shouldExportAsPRCSwigExplicitOdPrcContextForPdfExportWrapper(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGiPathNode.getCPtr(entity), OdGsClientViewInfo.getCPtr(pView), out viewportidx) : TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_shouldExportAsPRC(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGiPathNode.getCPtr(entity), OdGsClientViewInfo.getCPtr(pView), out viewportidx));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUserData(OdRxObject userData)
	{
		if (SwigDerivedClassHasMethod("setUserData", swigMethodTypes5))
		{
			TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_setUserDataSwigExplicitOdPrcContextForPdfExportWrapper(swigCPtr, OdRxObject.getCPtr(userData));
		}
		else
		{
			TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_setUserData(swigCPtr, OdRxObject.getCPtr(userData));
		}
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool getWritePdfFile()
	{
		bool result = (SwigDerivedClassHasMethod("getWritePdfFile", swigMethodTypes6) ? TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_getWritePdfFileSwigExplicitOdPrcContextForPdfExportWrapper(swigCPtr) : TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_getWritePdfFile(swigCPtr));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_getRealClassName(ptr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdRxObject UserData()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_UserData(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcContextForPdfExportWrapper createObject()
	{
		OdPrcContextForPdfExportWrapper rXObject = Helpers.GetRXObject<OdPrcContextForPdfExportWrapper>(TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcContextForPdfExportWrapper()
		: this(TD_PdfExport_GlobalsPINVOKE.new_OdPrcContextForPdfExportWrapper(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcContextForPdfExportWrapper) != GetType();
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
		if (SwigDerivedClassHasMethod("shouldExportAsPRC", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodshouldExportAsPRC;
		}
		if (SwigDerivedClassHasMethod("getExtents", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetExtents;
		}
		if (SwigDerivedClassHasMethod("setUserData", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetUserData;
		}
		if (SwigDerivedClassHasMethod("getWritePdfFile", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetWritePdfFile;
		}
		if (SwigDerivedClassHasMethod("setWritePdfFile", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetWritePdfFile;
		}
		TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExportWrapper_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcContextForPdfExportWrapper));
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

	private bool SwigDirectorMethodshouldExportAsPRC(IntPtr pDrawable, IntPtr entity, IntPtr pView, uint viewportidx)
	{
		return shouldExportAsPRC(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), (entity == IntPtr.Zero) ? null : new OdGiPathNode(entity, cMemoryOwn: false), (pView == IntPtr.Zero) ? null : new OdGsClientViewInfo(pView, cMemoryOwn: false), out viewportidx);
	}

	private void SwigDirectorMethodgetExtents(IntPtr pDrawable, IntPtr viewportObjectId, IntPtr pGiContext, IntPtr cameraView, IntPtr modelToWorld, IntPtr extents)
	{
		try
		{
			getExtents(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), (viewportObjectId == IntPtr.Zero) ? null : new OdDbStub(viewportObjectId, cMemoryOwn: false), Helpers.GetRXObject<OdGiContext>(pGiContext, bOwn: false, bTryAddToTransaction: false), new OdGeMatrix3d(cameraView, cMemoryOwn: false), new OdGeMatrix3d(modelToWorld, cMemoryOwn: false), new OdGeExtents3d(extents, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetUserData(IntPtr userData)
	{
		try
		{
			setUserData(Helpers.GetRXObject<OdRxObject>(userData, bOwn: true, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodgetWritePdfFile()
	{
		return getWritePdfFile();
	}

	private void SwigDirectorMethodsetWritePdfFile(bool flag)
	{
		try
		{
			setWritePdfFile(flag);
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

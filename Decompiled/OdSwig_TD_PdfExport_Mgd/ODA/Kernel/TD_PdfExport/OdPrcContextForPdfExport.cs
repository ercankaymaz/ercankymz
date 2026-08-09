using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class OdPrcContextForPdfExport : OdRxObject
{
	public delegate IntPtr SwigDelegateOdPrcContextForPdfExport_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcContextForPdfExport_1();

	public delegate void SwigDelegateOdPrcContextForPdfExport_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPrcContextForPdfExport_3(IntPtr arg0, IntPtr arg1, IntPtr arg2, uint arg3);

	public delegate void SwigDelegateOdPrcContextForPdfExport_4(IntPtr pDrawable, IntPtr viewportObjectId, IntPtr pGiContext, IntPtr cameraView, IntPtr modelToWorld, IntPtr extents);

	public delegate void SwigDelegateOdPrcContextForPdfExport_5(IntPtr userData);

	public delegate bool SwigDelegateOdPrcContextForPdfExport_6();

	public delegate void SwigDelegateOdPrcContextForPdfExport_7(bool flag);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcContextForPdfExport_0 swigDelegate0;

	private SwigDelegateOdPrcContextForPdfExport_1 swigDelegate1;

	private SwigDelegateOdPrcContextForPdfExport_2 swigDelegate2;

	private SwigDelegateOdPrcContextForPdfExport_3 swigDelegate3;

	private SwigDelegateOdPrcContextForPdfExport_4 swigDelegate4;

	private SwigDelegateOdPrcContextForPdfExport_5 swigDelegate5;

	private SwigDelegateOdPrcContextForPdfExport_6 swigDelegate6;

	private SwigDelegateOdPrcContextForPdfExport_7 swigDelegate7;

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
	public OdPrcContextForPdfExport(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcContextForPdfExport obj)
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
					TD_PdfExport_GlobalsPINVOKE.delete_OdPrcContextForPdfExport(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPrcContextForPdfExport cast(OdRxObject pObj)
	{
		OdPrcContextForPdfExport rXObject = Helpers.GetRXObject<OdPrcContextForPdfExport>(TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_isASwigExplicitOdPrcContextForPdfExport(swigCPtr) : TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_queryXSwigExplicitOdPrcContextForPdfExport(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcContextForPdfExport()
		: this(TD_PdfExport_GlobalsPINVOKE.new_OdPrcContextForPdfExport(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcContextForPdfExport) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual bool shouldExportAsPRC(OdGiDrawable arg0, OdGiPathNode arg1, OdGsClientViewInfo arg2, out uint arg3)
	{
		bool result = (SwigDerivedClassHasMethod("shouldExportAsPRC", swigMethodTypes3) ? TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_shouldExportAsPRCSwigExplicitOdPrcContextForPdfExport(swigCPtr, OdGiDrawable.getCPtr(arg0), OdGiPathNode.getCPtr(arg1), OdGsClientViewInfo.getCPtr(arg2), out arg3) : TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_shouldExportAsPRC(swigCPtr, OdGiDrawable.getCPtr(arg0), OdGiPathNode.getCPtr(arg1), OdGsClientViewInfo.getCPtr(arg2), out arg3));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getExtents(OdGiDrawable pDrawable, OdDbStub viewportObjectId, OdGiContext pGiContext, OdGeMatrix3d cameraView, OdGeMatrix3d modelToWorld, OdGeExtents3d extents)
	{
		if (SwigDerivedClassHasMethod("getExtents", swigMethodTypes4))
		{
			TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_getExtentsSwigExplicitOdPrcContextForPdfExport(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdDbStub.getCPtr(viewportObjectId), OdGiContext.getCPtr(pGiContext), OdGeMatrix3d.getCPtr(cameraView), OdGeMatrix3d.getCPtr(modelToWorld), OdGeExtents3d.getCPtr(extents));
		}
		else
		{
			TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_getExtents(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdDbStub.getCPtr(viewportObjectId), OdGiContext.getCPtr(pGiContext), OdGeMatrix3d.getCPtr(cameraView), OdGeMatrix3d.getCPtr(modelToWorld), OdGeExtents3d.getCPtr(extents));
		}
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUserData(OdRxObject userData)
	{
		if (SwigDerivedClassHasMethod("setUserData", swigMethodTypes5))
		{
			TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_setUserDataSwigExplicitOdPrcContextForPdfExport(swigCPtr, OdRxObject.getCPtr(userData));
		}
		else
		{
			TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_setUserData(swigCPtr, OdRxObject.getCPtr(userData));
		}
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getWritePdfFile()
	{
		bool result = (SwigDerivedClassHasMethod("getWritePdfFile", swigMethodTypes6) ? TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_getWritePdfFileSwigExplicitOdPrcContextForPdfExport(swigCPtr) : TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_getWritePdfFile(swigCPtr));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setWritePdfFile(bool flag)
	{
		if (SwigDerivedClassHasMethod("setWritePdfFile", swigMethodTypes7))
		{
			TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_setWritePdfFileSwigExplicitOdPrcContextForPdfExport(swigCPtr, flag);
		}
		else
		{
			TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_setWritePdfFile(swigCPtr, flag);
		}
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_getRealClassName(ptr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObject UserData()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_UserData(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPrcContextForPdfExport createObject()
	{
		OdPrcContextForPdfExport rXObject = Helpers.GetRXObject<OdPrcContextForPdfExport>(TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		TD_PdfExport_GlobalsPINVOKE.OdPrcContextForPdfExport_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcContextForPdfExport));
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

	private bool SwigDirectorMethodshouldExportAsPRC(IntPtr arg0, IntPtr arg1, IntPtr arg2, uint arg3)
	{
		return shouldExportAsPRC(Helpers.GetRXObject<OdGiDrawable>(arg0, bOwn: false, bTryAddToTransaction: false), (arg1 == IntPtr.Zero) ? null : new OdGiPathNode(arg1, cMemoryOwn: false), (arg2 == IntPtr.Zero) ? null : new OdGsClientViewInfo(arg2, cMemoryOwn: false), out arg3);
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

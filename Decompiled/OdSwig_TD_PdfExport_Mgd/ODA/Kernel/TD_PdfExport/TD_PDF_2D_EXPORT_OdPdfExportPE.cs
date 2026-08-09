using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class TD_PDF_2D_EXPORT_OdPdfExportPE : OdRxObject
{
	public delegate IntPtr SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_1();

	public delegate void SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_3(IntPtr pDb);

	public delegate void SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_4(IntPtr device, IntPtr aDrw);

	public delegate void SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_5(IntPtr device);

	public delegate bool SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_6(IntPtr pDb, IntPtr params_, uint pageIdx);

	public delegate void SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_7(IntPtr pDb, IntPtr params_, uint pageIdx);

	public delegate void SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_8(IntPtr aDrw, IntPtr pDevice, IntPtr pModel);

	public delegate void SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_9(IntPtr pDb);

	public delegate int SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_10(IntPtr arg0, IntPtr arg1, uint arg2, IntPtr arg3);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_0 swigDelegate0;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_1 swigDelegate1;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_2 swigDelegate2;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_3 swigDelegate3;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_4 swigDelegate4;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_5 swigDelegate5;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_6 swigDelegate6;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_7 swigDelegate7;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_8 swigDelegate8;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_9 swigDelegate9;

	private SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGsDevice).MakeByRefType(),
		typeof(OdGiDrawablePtrArray)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGsDevice).MakeByRefType() };

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(TD_PDF_2D_EXPORT_PDFExportParams),
		typeof(uint)
	};

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(TD_PDF_2D_EXPORT_PDFExportParams),
		typeof(uint)
	};

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(OdGiDrawablePtrArray),
		typeof(OdGsDevice),
		typeof(OdGsModel)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes10 = new Type[4]
	{
		typeof(OdRxObjectPtrArray),
		typeof(OdRxObject),
		typeof(uint),
		typeof(OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_2D_EXPORT_OdPdfExportPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_2D_EXPORT_OdPdfExportPE obj)
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
					TD_PdfExport_GlobalsPINVOKE.delete_TD_PDF_2D_EXPORT_OdPdfExportPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static TD_PDF_2D_EXPORT_OdPdfExportPE cast(OdRxObject pObj)
	{
		TD_PDF_2D_EXPORT_OdPdfExportPE rXObject = Helpers.GetRXObject<TD_PDF_2D_EXPORT_OdPdfExportPE>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_isASwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(swigCPtr) : TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_queryXSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static TD_PDF_2D_EXPORT_OdPdfExportPE createObject()
	{
		TD_PDF_2D_EXPORT_OdPdfExportPE rXObject = Helpers.GetRXObject<TD_PDF_2D_EXPORT_OdPdfExportPE>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiDefaultContext createGiContext(OdRxObject pDb)
	{
		OdGiDefaultContext rXObject = Helpers.GetRXObject<OdGiDefaultContext>(TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_createGiContext(swigCPtr, OdRxObject.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void createAuxDrawables(ref OdGsDevice device, OdGiDrawablePtrArray aDrw)
	{
		IntPtr jarg = ((device == null) ? IntPtr.Zero : OdGsDevice.getCPtr(device).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_createAuxDrawables(swigCPtr, ref jarg, OdGiDrawablePtrArray.getCPtr(aDrw).Handle);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				device = null;
			}
			if (jarg != intPtr)
			{
				device = Helpers.GetRXObject<OdGsDevice>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void filterDrawables(ref OdGsDevice device)
	{
		IntPtr jarg = ((device == null) ? IntPtr.Zero : OdGsDevice.getCPtr(device).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_filterDrawables(swigCPtr, ref jarg);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				device = null;
			}
			if (jarg != intPtr)
			{
				device = Helpers.GetRXObject<OdGsDevice>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual bool onBeginPage(OdRxObject pDb, TD_PDF_2D_EXPORT_PDFExportParams params_, uint pageIdx)
	{
		bool result = (SwigDerivedClassHasMethod("onBeginPage", swigMethodTypes6) ? TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_onBeginPageSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(swigCPtr, OdRxObject.getCPtr(pDb), TD_PDF_2D_EXPORT_PDFExportParams.getCPtr(params_), pageIdx) : TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_onBeginPage(swigCPtr, OdRxObject.getCPtr(pDb), TD_PDF_2D_EXPORT_PDFExportParams.getCPtr(params_), pageIdx));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void onEndPage(OdRxObject pDb, TD_PDF_2D_EXPORT_PDFExportParams params_, uint pageIdx)
	{
		if (SwigDerivedClassHasMethod("onEndPage", swigMethodTypes7))
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_onEndPageSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(swigCPtr, OdRxObject.getCPtr(pDb), TD_PDF_2D_EXPORT_PDFExportParams.getCPtr(params_), pageIdx);
		}
		else
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_onEndPage(swigCPtr, OdRxObject.getCPtr(pDb), TD_PDF_2D_EXPORT_PDFExportParams.getCPtr(params_), pageIdx);
		}
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addDrawables(OdGiDrawablePtrArray aDrw, OdGsDevice pDevice, OdGsModel pModel)
	{
		if (SwigDerivedClassHasMethod("addDrawables", swigMethodTypes8))
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_addDrawablesSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(swigCPtr, OdGiDrawablePtrArray.getCPtr(aDrw).Handle, OdGsDevice.getCPtr(pDevice), OdGsModel.getCPtr(pModel));
		}
		else
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_addDrawables(swigCPtr, OdGiDrawablePtrArray.getCPtr(aDrw).Handle, OdGsDevice.getCPtr(pDevice), OdGsModel.getCPtr(pModel));
		}
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void evaluateFields(OdRxObject pDb)
	{
		if (SwigDerivedClassHasMethod("evaluateFields", swigMethodTypes9))
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_evaluateFieldsSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(swigCPtr, OdRxObject.getCPtr(pDb));
		}
		else
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_evaluateFields(swigCPtr, OdRxObject.getCPtr(pDb));
		}
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult gsBitmapDevices(OdRxObjectPtrArray arg0, OdRxObject arg1, uint arg2, OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator arg3)
	{
		int result = (SwigDerivedClassHasMethod("gsBitmapDevices", swigMethodTypes10) ? TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_gsBitmapDevicesSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(swigCPtr, OdRxObjectPtrArray.getCPtr(arg0).Handle, OdRxObject.getCPtr(arg1), arg2, OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator.getCPtr(arg3)) : TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_gsBitmapDevices(swigCPtr, OdRxObjectPtrArray.getCPtr(arg0).Handle, OdRxObject.getCPtr(arg1), arg2, OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator.getCPtr(arg3)));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_getRealClassName(ptr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public TD_PDF_2D_EXPORT_OdPdfExportPE()
		: this(TD_PdfExport_GlobalsPINVOKE.new_TD_PDF_2D_EXPORT_OdPdfExportPE(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(TD_PDF_2D_EXPORT_OdPdfExportPE) != GetType();
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
		if (SwigDerivedClassHasMethod("createGiContext", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcreateGiContext;
		}
		if (SwigDerivedClassHasMethod("createAuxDrawables", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcreateAuxDrawables;
		}
		if (SwigDerivedClassHasMethod("filterDrawables", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodfilterDrawables;
		}
		if (SwigDerivedClassHasMethod("onBeginPage", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodonBeginPage;
		}
		if (SwigDerivedClassHasMethod("onEndPage", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodonEndPage;
		}
		if (SwigDerivedClassHasMethod("addDrawables", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodaddDrawables;
		}
		if (SwigDerivedClassHasMethod("evaluateFields", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodevaluateFields;
		}
		if (SwigDerivedClassHasMethod("gsBitmapDevices", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgsBitmapDevices;
		}
		TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_OdPdfExportPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(TD_PDF_2D_EXPORT_OdPdfExportPE));
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

	private IntPtr SwigDirectorMethodcreateGiContext(IntPtr pDb)
	{
		return OdGiDefaultContext.getCPtr(createGiContext(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private void SwigDirectorMethodcreateAuxDrawables(IntPtr device, IntPtr aDrw)
	{
		OdSwigDirectorHelper.director_UnpackData(device, out var pOriginalObject, out var pFunction);
		OdGsDevice device2 = Helpers.GetRXObject<OdGsDevice>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			createAuxDrawables(ref device2, new OdGiDrawablePtrArray(aDrw, cMemoryOwn: true));
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
		finally
		{
			IntPtr handle = OdGsDevice.getCPtr(device2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(device);
		}
	}

	private void SwigDirectorMethodfilterDrawables(IntPtr device)
	{
		OdSwigDirectorHelper.director_UnpackData(device, out var pOriginalObject, out var pFunction);
		OdGsDevice device2 = Helpers.GetRXObject<OdGsDevice>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			filterDrawables(ref device2);
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
		finally
		{
			IntPtr handle = OdGsDevice.getCPtr(device2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(device);
		}
	}

	private bool SwigDirectorMethodonBeginPage(IntPtr pDb, IntPtr params_, uint pageIdx)
	{
		return onBeginPage(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), new TD_PDF_2D_EXPORT_PDFExportParams(params_, cMemoryOwn: false), pageIdx);
	}

	private void SwigDirectorMethodonEndPage(IntPtr pDb, IntPtr params_, uint pageIdx)
	{
		try
		{
			onEndPage(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), new TD_PDF_2D_EXPORT_PDFExportParams(params_, cMemoryOwn: false), pageIdx);
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

	private void SwigDirectorMethodaddDrawables(IntPtr aDrw, IntPtr pDevice, IntPtr pModel)
	{
		try
		{
			addDrawables(new OdGiDrawablePtrArray(aDrw, cMemoryOwn: true), Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodevaluateFields(IntPtr pDb)
	{
		try
		{
			evaluateFields(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodgsBitmapDevices(IntPtr arg0, IntPtr arg1, uint arg2, IntPtr arg3)
	{
		return (int)gsBitmapDevices(new OdRxObjectPtrArray(arg0, cMemoryOwn: true), Helpers.GetRXObject<OdRxObject>(arg1, bOwn: false, bTryAddToTransaction: false), arg2, new OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator(arg3, cMemoryOwn: false));
	}
}

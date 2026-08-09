using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class PdfExportGiDrawablePE : OdRxObject
{
	public delegate IntPtr SwigDelegatePdfExportGiDrawablePE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegatePdfExportGiDrawablePE_1();

	public delegate void SwigDelegatePdfExportGiDrawablePE_2(IntPtr pSource);

	public delegate int SwigDelegatePdfExportGiDrawablePE_3(IntPtr pDrawable, IntPtr pPdfPrcParams, IntPtr context);

	public delegate int SwigDelegatePdfExportGiDrawablePE_4(IntPtr pDrawable, IntPtr pPdfPrcParams, IntPtr context, IntPtr pParent, IntPtr pPartDefinition, bool hasRefs);

	public delegate IntPtr SwigDelegatePdfExportGiDrawablePE_5(IntPtr pDrawable);

	public delegate IntPtr SwigDelegatePdfExportGiDrawablePE_6(IntPtr pDrawable);

	public delegate IntPtr SwigDelegatePdfExportGiDrawablePE_7(IntPtr pDrawable);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegatePdfExportGiDrawablePE_0 swigDelegate0;

	private SwigDelegatePdfExportGiDrawablePE_1 swigDelegate1;

	private SwigDelegatePdfExportGiDrawablePE_2 swigDelegate2;

	private SwigDelegatePdfExportGiDrawablePE_3 swigDelegate3;

	private SwigDelegatePdfExportGiDrawablePE_4 swigDelegate4;

	private SwigDelegatePdfExportGiDrawablePE_5 swigDelegate5;

	private SwigDelegatePdfExportGiDrawablePE_6 swigDelegate6;

	private SwigDelegatePdfExportGiDrawablePE_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdGiDrawable),
		typeof(PDF2PRCExportParams),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes4 = new Type[6]
	{
		typeof(OdGiDrawable),
		typeof(PDF2PRCExportParams),
		typeof(OdRxObject),
		typeof(OdRxObject),
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGiDrawable) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public PdfExportGiDrawablePE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(PdfExportGiDrawablePE obj)
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
					TD_PdfExport_GlobalsPINVOKE.delete_PdfExportGiDrawablePE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static PdfExportGiDrawablePE cast(OdRxObject pObj)
	{
		PdfExportGiDrawablePE rXObject = Helpers.GetRXObject<PdfExportGiDrawablePE>(TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_isASwigExplicitPdfExportGiDrawablePE(swigCPtr) : TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_queryXSwigExplicitPdfExportGiDrawablePE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult drawableToPRC(OdGiDrawable pDrawable, PDF2PRCExportParams pPdfPrcParams, OdRxObject context)
	{
		int result = (SwigDerivedClassHasMethod("drawableToPRC", swigMethodTypes3) ? TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_drawableToPRCSwigExplicitPdfExportGiDrawablePE__SWIG_0(swigCPtr, OdGiDrawable.getCPtr(pDrawable), PDF2PRCExportParams.getCPtr(pPdfPrcParams), OdRxObject.getCPtr(context)) : TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_drawableToPRC__SWIG_0(swigCPtr, OdGiDrawable.getCPtr(pDrawable), PDF2PRCExportParams.getCPtr(pPdfPrcParams), OdRxObject.getCPtr(context)));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult drawableToPRC(OdGiDrawable pDrawable, PDF2PRCExportParams pPdfPrcParams, OdRxObject context, OdRxObject pParent, OdRxObject pPartDefinition, bool hasRefs)
	{
		int result = (SwigDerivedClassHasMethod("drawableToPRC", swigMethodTypes4) ? TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_drawableToPRCSwigExplicitPdfExportGiDrawablePE__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pDrawable), PDF2PRCExportParams.getCPtr(pPdfPrcParams), OdRxObject.getCPtr(context), OdRxObject.getCPtr(pParent), OdRxObject.getCPtr(pPartDefinition), hasRefs) : TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_drawableToPRC__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pDrawable), PDF2PRCExportParams.getCPtr(pPdfPrcParams), OdRxObject.getCPtr(context), OdRxObject.getCPtr(pParent), OdRxObject.getCPtr(pPartDefinition), hasRefs));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdCmEntityColor getColor(OdGiDrawable pDrawable)
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("getColor", swigMethodTypes5) ? TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_getColorSwigExplicitPdfExportGiDrawablePE(swigCPtr, OdGiDrawable.getCPtr(pDrawable)) : TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_getColor(swigCPtr, OdGiDrawable.getCPtr(pDrawable)), cMemoryOwn: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub getMaterial(OdGiDrawable pDrawable)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("getMaterial", swigMethodTypes6) ? TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_getMaterialSwigExplicitPdfExportGiDrawablePE(swigCPtr, OdGiDrawable.getCPtr(pDrawable)) : TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_getMaterial(swigCPtr, OdGiDrawable.getCPtr(pDrawable)));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmTransparency getTransparency(OdGiDrawable pDrawable)
	{
		OdCmTransparency result = new OdCmTransparency(SwigDerivedClassHasMethod("getTransparency", swigMethodTypes7) ? TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_getTransparencySwigExplicitPdfExportGiDrawablePE(swigCPtr, OdGiDrawable.getCPtr(pDrawable)) : TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_getTransparency(swigCPtr, OdGiDrawable.getCPtr(pDrawable)), cMemoryOwn: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_getRealClassName(ptr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static PdfExportGiDrawablePE createObject()
	{
		PdfExportGiDrawablePE rXObject = Helpers.GetRXObject<PdfExportGiDrawablePE>(TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public PdfExportGiDrawablePE()
		: this(TD_PdfExport_GlobalsPINVOKE.new_PdfExportGiDrawablePE(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(PdfExportGiDrawablePE) != GetType();
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
		if (SwigDerivedClassHasMethod("drawableToPRC", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddrawableToPRC__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("drawableToPRC", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddrawableToPRC__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getColor", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetColor;
		}
		if (SwigDerivedClassHasMethod("getMaterial", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetMaterial;
		}
		if (SwigDerivedClassHasMethod("getTransparency", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetTransparency;
		}
		TD_PdfExport_GlobalsPINVOKE.PdfExportGiDrawablePE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(PdfExportGiDrawablePE));
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

	private int SwigDirectorMethoddrawableToPRC__SWIG_0(IntPtr pDrawable, IntPtr pPdfPrcParams, IntPtr context)
	{
		return (int)drawableToPRC(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), (pPdfPrcParams == IntPtr.Zero) ? null : new PDF2PRCExportParams(pPdfPrcParams, cMemoryOwn: false), Helpers.GetRXObject<OdRxObject>(context, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethoddrawableToPRC__SWIG_1(IntPtr pDrawable, IntPtr pPdfPrcParams, IntPtr context, IntPtr pParent, IntPtr pPartDefinition, bool hasRefs)
	{
		return (int)drawableToPRC(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), (pPdfPrcParams == IntPtr.Zero) ? null : new PDF2PRCExportParams(pPdfPrcParams, cMemoryOwn: false), Helpers.GetRXObject<OdRxObject>(context, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pParent, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pPartDefinition, bOwn: false, bTryAddToTransaction: false), hasRefs);
	}

	private IntPtr SwigDirectorMethodgetColor(IntPtr pDrawable)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(getColor(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_PdfExport_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_PdfExport_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_PdfExport_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_PdfExport_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodgetMaterial(IntPtr pDrawable)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getMaterial(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_PdfExport_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_PdfExport_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_PdfExport_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_PdfExport_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodgetTransparency(IntPtr pDrawable)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmTransparency.getCPtr(getTransparency(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_PdfExport_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_PdfExport_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_PdfExport_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_PdfExport_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}

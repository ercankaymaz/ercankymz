using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class PdfExportLayerPE : OdRxObject
{
	public delegate IntPtr SwigDelegatePdfExportLayerPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegatePdfExportLayerPE_1();

	public delegate void SwigDelegatePdfExportLayerPE_2(IntPtr pSource);

	public delegate IntPtr SwigDelegatePdfExportLayerPE_3(IntPtr pDrawable);

	public delegate IntPtr SwigDelegatePdfExportLayerPE_4(IntPtr pDrawable);

	public delegate IntPtr SwigDelegatePdfExportLayerPE_5(IntPtr pDrawable);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegatePdfExportLayerPE_0 swigDelegate0;

	private SwigDelegatePdfExportLayerPE_1 swigDelegate1;

	private SwigDelegatePdfExportLayerPE_2 swigDelegate2;

	private SwigDelegatePdfExportLayerPE_3 swigDelegate3;

	private SwigDelegatePdfExportLayerPE_4 swigDelegate4;

	private SwigDelegatePdfExportLayerPE_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public PdfExportLayerPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(PdfExportLayerPE obj)
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
					TD_PdfExport_GlobalsPINVOKE.delete_PdfExportLayerPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static PdfExportLayerPE cast(OdRxObject pObj)
	{
		PdfExportLayerPE rXObject = Helpers.GetRXObject<PdfExportLayerPE>(TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_isASwigExplicitPdfExportLayerPE(swigCPtr) : TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_queryXSwigExplicitPdfExportLayerPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdCmEntityColor getColor(OdRxObject pDrawable)
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("getColor", swigMethodTypes3) ? TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_getColorSwigExplicitPdfExportLayerPE(swigCPtr, OdRxObject.getCPtr(pDrawable)) : TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_getColor(swigCPtr, OdRxObject.getCPtr(pDrawable)), cMemoryOwn: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub getMaterial(OdRxObject pDrawable)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("getMaterial", swigMethodTypes4) ? TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_getMaterialSwigExplicitPdfExportLayerPE(swigCPtr, OdRxObject.getCPtr(pDrawable)) : TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_getMaterial(swigCPtr, OdRxObject.getCPtr(pDrawable)));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmTransparency getTransparency(OdRxObject pDrawable)
	{
		OdCmTransparency result = new OdCmTransparency(SwigDerivedClassHasMethod("getTransparency", swigMethodTypes5) ? TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_getTransparencySwigExplicitPdfExportLayerPE(swigCPtr, OdRxObject.getCPtr(pDrawable)) : TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_getTransparency(swigCPtr, OdRxObject.getCPtr(pDrawable)), cMemoryOwn: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_getRealClassName(ptr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static PdfExportLayerPE createObject()
	{
		PdfExportLayerPE rXObject = Helpers.GetRXObject<PdfExportLayerPE>(TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public PdfExportLayerPE()
		: this(TD_PdfExport_GlobalsPINVOKE.new_PdfExportLayerPE(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(PdfExportLayerPE) != GetType();
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
		if (SwigDerivedClassHasMethod("getColor", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetColor;
		}
		if (SwigDerivedClassHasMethod("getMaterial", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetMaterial;
		}
		if (SwigDerivedClassHasMethod("getTransparency", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetTransparency;
		}
		TD_PdfExport_GlobalsPINVOKE.PdfExportLayerPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(PdfExportLayerPE));
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

	private IntPtr SwigDirectorMethodgetColor(IntPtr pDrawable)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(getColor(Helpers.GetRXObject<OdRxObject>(pDrawable, bOwn: false, bTryAddToTransaction: false))).Handle;
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
				return OdDbStub.getCPtr(getMaterial(Helpers.GetRXObject<OdRxObject>(pDrawable, bOwn: false, bTryAddToTransaction: false))).Handle;
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
				return OdCmTransparency.getCPtr(getTransparency(Helpers.GetRXObject<OdRxObject>(pDrawable, bOwn: false, bTryAddToTransaction: false))).Handle;
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

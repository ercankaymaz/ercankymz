using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdMarkupAnnotation : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdMarkupAnnotation_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdMarkupAnnotation_1();

	public delegate void SwigDelegateOdPdfPublish_OdMarkupAnnotation_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdMarkupAnnotation_3();

	public delegate bool SwigDelegateOdPdfPublish_OdMarkupAnnotation_4();

	public delegate void SwigDelegateOdPdfPublish_OdMarkupAnnotation_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdMarkupAnnotation_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdMarkupAnnotation_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdMarkupAnnotation_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdMarkupAnnotation_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdMarkupAnnotation_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdMarkupAnnotation_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdMarkupAnnotation(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdMarkupAnnotation obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdMarkupAnnotation(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdMarkupAnnotation()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdMarkupAnnotation(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdMarkupAnnotation) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdMarkupAnnotation cast(OdRxObject pObj)
	{
		OdPdfPublish_OdMarkupAnnotation rXObject = Helpers.GetRXObject<OdPdfPublish_OdMarkupAnnotation>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_isASwigExplicitOdPdfPublish_OdMarkupAnnotation(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_queryXSwigExplicitOdPdfPublish_OdMarkupAnnotation(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdMarkupAnnotation createObject()
	{
		OdPdfPublish_OdMarkupAnnotation rXObject = Helpers.GetRXObject<OdPdfPublish_OdMarkupAnnotation>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setPopupLocation(OdGsDCRect popup_location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_setPopupLocation(swigCPtr, OdGsDCRect.getCPtr(popup_location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOpen(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_setOpen(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setContents(string value)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_setContents(swigCPtr, value);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTitle(string value)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_setTitle(swigCPtr, value);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDescription(string value)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_setDescription(swigCPtr, value);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCreationDate(OdTimeStamp value)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_setCreationDate(swigCPtr, OdTimeStamp.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOpacity(byte value)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_setOpacity(swigCPtr, value);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_setColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLock(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_setLock(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMarkedState(OdPdfPublish_MarkupAnnotations_MarkupAnnotationMarkedStates marked_state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_setMarkedState(swigCPtr, (int)marked_state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setReviewState(OdPdfPublish_MarkupAnnotations_MarkupAnnotationReviewStates review_state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_setReviewState(swigCPtr, (int)review_state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPopupLocation(OdGsDCRect popup_location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_getPopupLocation(swigCPtr, OdGsDCRect.getCPtr(popup_location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getOpen(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_getOpen(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getContents(ref string value)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(value);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_getContents(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				value = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getTitle(ref string value)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(value);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_getTitle(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				value = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getDescription(ref string value)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(value);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_getDescription(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				value = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public bool getCreationDate(OdTimeStamp value)
	{
		bool result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_getCreationDate(swigCPtr, OdTimeStamp.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getOpacity(out byte value)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_getOpacity(swigCPtr, out value);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_getColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLock(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_getLock(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getMarkedState(out OdPdfPublish_MarkupAnnotations_MarkupAnnotationMarkedStates marked_state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_getMarkedState(swigCPtr, out marked_state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getReviewState(out OdPdfPublish_MarkupAnnotations_MarkupAnnotationReviewStates review_state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_getReviewState(swigCPtr, out review_state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_getRealClassName(ptr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		if (SwigDerivedClassHasMethod("isEmpty", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisEmpty;
		}
		if (SwigDerivedClassHasMethod("isValid", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisValid;
		}
		if (SwigDerivedClassHasMethod("clear", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodclear;
		}
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdMarkupAnnotation_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdMarkupAnnotation));
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
			PdfPublish_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			PdfPublish_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			PdfPublish_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			PdfPublish_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisEmpty()
	{
		return isEmpty();
	}

	private bool SwigDirectorMethodisValid()
	{
		return isValid();
	}

	private void SwigDirectorMethodclear()
	{
		try
		{
			clear();
		}
		catch (OdEdEmptyInput err)
		{
			PdfPublish_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			PdfPublish_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			PdfPublish_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			PdfPublish_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}

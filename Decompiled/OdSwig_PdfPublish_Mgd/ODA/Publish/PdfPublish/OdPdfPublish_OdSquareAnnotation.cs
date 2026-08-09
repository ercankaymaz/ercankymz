using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdSquareAnnotation : OdPdfPublish_OdMarkupAnnotation
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdSquareAnnotation_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdSquareAnnotation_1();

	public delegate void SwigDelegateOdPdfPublish_OdSquareAnnotation_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdSquareAnnotation_3();

	public delegate bool SwigDelegateOdPdfPublish_OdSquareAnnotation_4();

	public delegate void SwigDelegateOdPdfPublish_OdSquareAnnotation_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdSquareAnnotation_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdSquareAnnotation_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdSquareAnnotation_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdSquareAnnotation_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdSquareAnnotation_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdSquareAnnotation_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdSquareAnnotation(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdSquareAnnotation obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdSquareAnnotation(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdSquareAnnotation()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdSquareAnnotation(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdSquareAnnotation) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdSquareAnnotation cast(OdRxObject pObj)
	{
		OdPdfPublish_OdSquareAnnotation rXObject = Helpers.GetRXObject<OdPdfPublish_OdSquareAnnotation>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_isASwigExplicitOdPdfPublish_OdSquareAnnotation(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_queryXSwigExplicitOdPdfPublish_OdSquareAnnotation(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdSquareAnnotation createObject()
	{
		OdPdfPublish_OdSquareAnnotation rXObject = Helpers.GetRXObject<OdPdfPublish_OdSquareAnnotation>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setLineStyle(OdPdfPublish_OdAnnotationBorderStyle style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_setLineStyle(swigCPtr, OdPdfPublish_OdAnnotationBorderStyle.getCPtr(style));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLineEffect(OdPdfPublish_OdAnnotationBorderEffect effect)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_setLineEffect(swigCPtr, OdPdfPublish_OdAnnotationBorderEffect.getCPtr(effect));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLineStyle(ref OdPdfPublish_OdAnnotationBorderStyle style)
	{
		IntPtr jarg = ((style == null) ? IntPtr.Zero : OdPdfPublish_OdAnnotationBorderStyle.getCPtr(style).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_getLineStyle(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				style = null;
			}
			else if (jarg != intPtr)
			{
				style = Helpers.GetRXObject<OdPdfPublish_OdAnnotationBorderStyle>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getLineEffect(ref OdPdfPublish_OdAnnotationBorderEffect effect)
	{
		IntPtr jarg = ((effect == null) ? IntPtr.Zero : OdPdfPublish_OdAnnotationBorderEffect.getCPtr(effect).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_getLineEffect(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				effect = null;
			}
			else if (jarg != intPtr)
			{
				effect = Helpers.GetRXObject<OdPdfPublish_OdAnnotationBorderEffect>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdSquareAnnotation_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdSquareAnnotation));
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

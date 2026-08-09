using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdLineAnnotation : OdPdfPublish_OdMarkupAnnotation
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdLineAnnotation_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdLineAnnotation_1();

	public delegate void SwigDelegateOdPdfPublish_OdLineAnnotation_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdLineAnnotation_3();

	public delegate bool SwigDelegateOdPdfPublish_OdLineAnnotation_4();

	public delegate void SwigDelegateOdPdfPublish_OdLineAnnotation_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdLineAnnotation_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdLineAnnotation_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdLineAnnotation_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdLineAnnotation_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdLineAnnotation_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdLineAnnotation_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdLineAnnotation(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdLineAnnotation obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdLineAnnotation(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdLineAnnotation()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdLineAnnotation(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdLineAnnotation) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdLineAnnotation cast(OdRxObject pObj)
	{
		OdPdfPublish_OdLineAnnotation rXObject = Helpers.GetRXObject<OdPdfPublish_OdLineAnnotation>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_isASwigExplicitOdPdfPublish_OdLineAnnotation(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_queryXSwigExplicitOdPdfPublish_OdLineAnnotation(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdLineAnnotation createObject()
	{
		OdPdfPublish_OdLineAnnotation rXObject = Helpers.GetRXObject<OdPdfPublish_OdLineAnnotation>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setPoints(OdGePoint2d start, OdGePoint2d end)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_setPoints(swigCPtr, OdGePoint2d.getCPtr(start), OdGePoint2d.getCPtr(end));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLineStyle(OdPdfPublish_OdAnnotationBorderStyle style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_setLineStyle(swigCPtr, OdPdfPublish_OdAnnotationBorderStyle.getCPtr(style));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setEndings(OdPdfPublish_LineEnding_Style start_le, OdPdfPublish_LineEnding_Style end_le)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_setEndings(swigCPtr, (int)start_le, (int)end_le);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLeaderLinesSize(int size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_setLeaderLinesSize(swigCPtr, size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLeaderLinesExtSize(uint size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_setLeaderLinesExtSize(swigCPtr, size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLeaderLinesOffsetSize(uint size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_setLeaderLinesOffsetSize(swigCPtr, size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLineIntent(OdPdfPublish_LineOptions_Intent size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_setLineIntent(swigCPtr, (int)size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCaptionPosition(OdPdfPublish_LineOptions_CaptionPosition position)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_setCaptionPosition(swigCPtr, (int)position);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCaptionOffset(OdGePoint2d offset)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_setCaptionOffset(swigCPtr, OdGePoint2d.getCPtr(offset));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCaption(string caption)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_setCaption(swigCPtr, caption);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPoints(OdGePoint2d start, OdGePoint2d end)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_getPoints(swigCPtr, OdGePoint2d.getCPtr(start), OdGePoint2d.getCPtr(end));
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
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_getLineStyle(swigCPtr, ref jarg);
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

	public void getEndings(out OdPdfPublish_LineEnding_Style start_le, out OdPdfPublish_LineEnding_Style end_le)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_getEndings(swigCPtr, out start_le, out end_le);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLeaderLinesSize(out int size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_getLeaderLinesSize(swigCPtr, out size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLeaderLinesExtSize(out uint size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_getLeaderLinesExtSize(swigCPtr, out size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLeaderLinesOffsetSize(out uint size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_getLeaderLinesOffsetSize(swigCPtr, out size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLineIntent(out OdPdfPublish_LineOptions_Intent size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_getLineIntent(swigCPtr, out size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCaptionPosition(out OdPdfPublish_LineOptions_CaptionPosition position)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_getCaptionPosition(swigCPtr, out position);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCaptionOffset(OdGePoint2d offset)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_getCaptionOffset(swigCPtr, OdGePoint2d.getCPtr(offset));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCaption(ref string caption)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(caption);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_getCaption(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				caption = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdLineAnnotation_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdLineAnnotation));
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

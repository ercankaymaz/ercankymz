using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdText : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdText_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdText_1();

	public delegate void SwigDelegateOdPdfPublish_OdText_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdText_3();

	public delegate bool SwigDelegateOdPdfPublish_OdText_4();

	public delegate void SwigDelegateOdPdfPublish_OdText_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdText_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdText_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdText_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdText_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdText_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdText_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdText(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdText obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdText(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdText()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdText(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdText) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdText cast(OdRxObject pObj)
	{
		OdPdfPublish_OdText rXObject = Helpers.GetRXObject<OdPdfPublish_OdText>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_isASwigExplicitOdPdfPublish_OdText(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_queryXSwigExplicitOdPdfPublish_OdText(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdText createObject()
	{
		OdPdfPublish_OdText rXObject = Helpers.GetRXObject<OdPdfPublish_OdText>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setText(string text)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_setText(swigCPtr, text);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(OdPdfPublish_Text_StandardFontsType fontType)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_setFont__SWIG_0(swigCPtr, (int)fontType);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle, OdPdfPublish_Text_Language language, bool embed)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_setFont__SWIG_1(swigCPtr, fontName, (int)fontStyle, (int)language, embed);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle, OdPdfPublish_Text_Language language)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_setFont__SWIG_2(swigCPtr, fontName, (int)fontStyle, (int)language);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_setFont__SWIG_3(swigCPtr, fontName, (int)fontStyle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_setFont__SWIG_4(swigCPtr, fontName);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSize(ushort size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_setSize(swigCPtr, size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_setColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addTextMarkupAnnotation(OdPdfPublish_OdTextMarkupAnnotation annot)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_addTextMarkupAnnotation(swigCPtr, OdPdfPublish_OdTextMarkupAnnotation.getCPtr(annot));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addCaretAnnotation(OdPdfPublish_OdCaretAnnotation annot, ushort position)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_addCaretAnnotation(swigCPtr, OdPdfPublish_OdCaretAnnotation.getCPtr(annot), position);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getText(ref string text)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(text);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_getText(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				text = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getFont(out OdPdfPublish_Text_StorageType storageType, out OdPdfPublish_Text_StandardFontsType fontType, ref string fontName, out OdPdfPublish_Text_FontStyle fontStyle, out OdPdfPublish_Text_Language language, out bool embed)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(fontName);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_getFont(swigCPtr, out storageType, out fontType, ref jarg, out fontStyle, out language, out embed);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				fontName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getSize(out ushort size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_getSize(swigCPtr, out size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_getColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLayer(OdPdfPublish_Od2dGeometryLayer layer)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_setLayer(swigCPtr, OdPdfPublish_Od2dGeometryLayer.getCPtr(layer));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLayer(ref OdPdfPublish_Od2dGeometryLayer layer)
	{
		IntPtr jarg = ((layer == null) ? IntPtr.Zero : OdPdfPublish_Od2dGeometryLayer.getCPtr(layer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_getLayer(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				layer = null;
			}
			else if (jarg != intPtr)
			{
				layer = Helpers.GetRXObject<OdPdfPublish_Od2dGeometryLayer>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getTextMarkupAnnotations(OdPdfPublish_OdTextMarkupAnnotationPtrArray annots)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_getTextMarkupAnnotations(swigCPtr, OdPdfPublish_OdTextMarkupAnnotationPtrArray.getCPtr(annots));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCaretAnnotations(OdPdfPublish_OdCaretAnnotationPtrArray annots, OdUInt16Array positions)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_getCaretAnnotations(swigCPtr, OdPdfPublish_OdCaretAnnotationPtrArray.getCPtr(annots), OdUInt16Array.getCPtr(positions).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdText_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdText));
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

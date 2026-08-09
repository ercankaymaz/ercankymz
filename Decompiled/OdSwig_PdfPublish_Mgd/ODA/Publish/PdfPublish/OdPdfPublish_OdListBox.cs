using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdListBox : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdListBox_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdListBox_1();

	public delegate void SwigDelegateOdPdfPublish_OdListBox_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdListBox_3();

	public delegate bool SwigDelegateOdPdfPublish_OdListBox_4();

	public delegate void SwigDelegateOdPdfPublish_OdListBox_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdListBox_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdListBox_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdListBox_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdListBox_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdListBox_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdListBox_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdListBox(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdListBox obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdListBox(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdListBox()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdListBox(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdListBox) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdListBox cast(OdRxObject pObj)
	{
		OdPdfPublish_OdListBox rXObject = Helpers.GetRXObject<OdPdfPublish_OdListBox>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_isASwigExplicitOdPdfPublish_OdListBox(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_queryXSwigExplicitOdPdfPublish_OdListBox(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdListBox createObject()
	{
		OdPdfPublish_OdListBox rXObject = Helpers.GetRXObject<OdPdfPublish_OdListBox>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setName(string name)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setName(swigCPtr, name);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle, OdPdfPublish_Text_Language language, bool embed)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setFont__SWIG_0(swigCPtr, fontName, (int)fontStyle, (int)language, embed);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle, OdPdfPublish_Text_Language language)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setFont__SWIG_1(swigCPtr, fontName, (int)fontStyle, (int)language);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setFont__SWIG_2(swigCPtr, fontName, (int)fontStyle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setFont__SWIG_3(swigCPtr, fontName);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(OdPdfPublish_Text_StandardFontsType fontType)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setFont__SWIG_4(swigCPtr, (int)fontType);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFontSize(ushort size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setFontSize(swigCPtr, size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setTextColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTooltip(string tooltip)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setTooltip(swigCPtr, tooltip);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setVisibility(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setVisibility(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPrintability(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setPrintability(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextRotation(OdPdfPublish_Text_Rotation rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setTextRotation(swigCPtr, (int)rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLock(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setLock(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorder(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setBorder(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setBorderColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderThickness(OdPdfPublish_Border_Thickness thickness)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setBorderThickness(swigCPtr, (int)thickness);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderStyle(OdPdfPublish_Border_Style style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setBorderStyle(swigCPtr, (int)style);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFillColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setFillColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMultipleSelection(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setMultipleSelection(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setContents(OdStringArray displayed_values, OdStringArray export_values)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_setContents(swigCPtr, OdStringArray.getCPtr(displayed_values).Handle, OdStringArray.getCPtr(export_values).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getName(ref string name)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(name);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getName(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				name = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getFont(out OdPdfPublish_Text_StorageType storageType, out OdPdfPublish_Text_StandardFontsType fontType, ref string fontName, out OdPdfPublish_Text_FontStyle fontStyle, out OdPdfPublish_Text_Language language, out bool embed)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(fontName);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getFont(swigCPtr, out storageType, out fontType, ref jarg, out fontStyle, out language, out embed);
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

	public void getFontSize(out ushort size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getFontSize(swigCPtr, out size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTextColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getTextColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTooltip(ref string tooltip)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(tooltip);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getTooltip(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				tooltip = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getVisibility(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getVisibility(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPrintability(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getPrintability(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTextRotation(out OdPdfPublish_Text_Rotation rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getTextRotation(swigCPtr, out rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLock(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getLock(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorder(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getBorder(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getBorderColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderThickness(out OdPdfPublish_Border_Thickness thickness)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getBorderThickness(swigCPtr, out thickness);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderStyle(out OdPdfPublish_Border_Style style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getBorderStyle(swigCPtr, out style);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getFillColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getFillColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getMultipleSelection(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getMultipleSelection(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getContents(OdStringArray displayed_values, OdStringArray export_values)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getContents(swigCPtr, OdStringArray.getCPtr(displayed_values).Handle, OdStringArray.getCPtr(export_values).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdListBox_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdListBox));
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

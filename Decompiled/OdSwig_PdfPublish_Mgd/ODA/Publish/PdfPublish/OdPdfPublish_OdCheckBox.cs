using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdCheckBox : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdCheckBox_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdCheckBox_1();

	public delegate void SwigDelegateOdPdfPublish_OdCheckBox_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdCheckBox_3();

	public delegate bool SwigDelegateOdPdfPublish_OdCheckBox_4();

	public delegate void SwigDelegateOdPdfPublish_OdCheckBox_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdCheckBox_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdCheckBox_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdCheckBox_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdCheckBox_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdCheckBox_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdCheckBox_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdCheckBox(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdCheckBox obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdCheckBox(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdCheckBox()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdCheckBox(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdCheckBox) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdCheckBox cast(OdRxObject pObj)
	{
		OdPdfPublish_OdCheckBox rXObject = Helpers.GetRXObject<OdPdfPublish_OdCheckBox>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_isASwigExplicitOdPdfPublish_OdCheckBox(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_queryXSwigExplicitOdPdfPublish_OdCheckBox(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdCheckBox createObject()
	{
		OdPdfPublish_OdCheckBox rXObject = Helpers.GetRXObject<OdPdfPublish_OdCheckBox>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setName(string name)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setName(swigCPtr, name);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(OdPdfPublish_Text_StandardFontsType fontType)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setFont__SWIG_0(swigCPtr, (int)fontType);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle, OdPdfPublish_Text_Language language, bool embed)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setFont__SWIG_1(swigCPtr, fontName, (int)fontStyle, (int)language, embed);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle, OdPdfPublish_Text_Language language)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setFont__SWIG_2(swigCPtr, fontName, (int)fontStyle, (int)language);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setFont__SWIG_3(swigCPtr, fontName, (int)fontStyle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setFont__SWIG_4(swigCPtr, fontName);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFontSize(ushort size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setFontSize(swigCPtr, size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setTextColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTooltip(string tooltip)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setTooltip(swigCPtr, tooltip);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setVisibility(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setVisibility(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPrintability(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setPrintability(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextRotation(OdPdfPublish_Text_Rotation rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setTextRotation(swigCPtr, (int)rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLock(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setLock(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorder(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setBorder(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setBorderColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderThickness(OdPdfPublish_Border_Thickness thickness)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setBorderThickness(swigCPtr, (int)thickness);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderStyle(OdPdfPublish_Border_Style style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setBorderStyle(swigCPtr, (int)style);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFillColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setFillColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setExportValue(string export_value)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setExportValue(swigCPtr, export_value);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDefaultState(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_setDefaultState(swigCPtr, state);
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
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getName(swigCPtr, ref jarg);
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
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getFont(swigCPtr, out storageType, out fontType, ref jarg, out fontStyle, out language, out embed);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getFontSize(swigCPtr, out size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTextColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getTextColor(swigCPtr, out color);
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
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getTooltip(swigCPtr, ref jarg);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getVisibility(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPrintability(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getPrintability(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTextRotation(out OdPdfPublish_Text_Rotation rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getTextRotation(swigCPtr, out rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLock(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getLock(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorder(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getBorder(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getBorderColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderThickness(out OdPdfPublish_Border_Thickness thickness)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getBorderThickness(swigCPtr, out thickness);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderStyle(out OdPdfPublish_Border_Style style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getBorderStyle(swigCPtr, out style);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getFillColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getFillColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getExportValue(ref string export_value)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(export_value);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getExportValue(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				export_value = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getDefaultState(out bool default_state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getDefaultState(swigCPtr, out default_state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCheckBox_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdCheckBox));
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

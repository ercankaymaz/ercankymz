using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdButton : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdButton_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdButton_1();

	public delegate void SwigDelegateOdPdfPublish_OdButton_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdButton_3();

	public delegate bool SwigDelegateOdPdfPublish_OdButton_4();

	public delegate void SwigDelegateOdPdfPublish_OdButton_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdButton_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdButton_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdButton_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdButton_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdButton_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdButton_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdButton(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdButton obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdButton(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdButton()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdButton(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdButton) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdButton cast(OdRxObject pObj)
	{
		OdPdfPublish_OdButton rXObject = Helpers.GetRXObject<OdPdfPublish_OdButton>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_isASwigExplicitOdPdfPublish_OdButton(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_queryXSwigExplicitOdPdfPublish_OdButton(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdButton createObject()
	{
		OdPdfPublish_OdButton rXObject = Helpers.GetRXObject<OdPdfPublish_OdButton>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setName(string name)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setName(swigCPtr, name);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLabel(string label)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setLabel(swigCPtr, label);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle, OdPdfPublish_Text_Language language, bool embed)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setFont__SWIG_0(swigCPtr, fontName, (int)fontStyle, (int)language, embed);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle, OdPdfPublish_Text_Language language)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setFont__SWIG_1(swigCPtr, fontName, (int)fontStyle, (int)language);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setFont__SWIG_2(swigCPtr, fontName, (int)fontStyle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(string fontName)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setFont__SWIG_3(swigCPtr, fontName);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(OdPdfPublish_Text_StandardFontsType fontType)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setFont__SWIG_4(swigCPtr, (int)fontType);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFontSize(ushort size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setFontSize(swigCPtr, size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setTextColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTooltip(string tooltip)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setTooltip(swigCPtr, tooltip);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setVisibility(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setVisibility(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPrintability(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setPrintability(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextRotation(OdPdfPublish_Text_Rotation rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setTextRotation(swigCPtr, (int)rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLock(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setLock(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorder(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setBorder(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setBorderColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderThickness(OdPdfPublish_Border_Thickness thickness)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setBorderThickness(swigCPtr, (int)thickness);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderStyle(OdPdfPublish_Border_Style style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setBorderStyle(swigCPtr, (int)style);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFillColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setFillColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLabelPosition(OdPdfPublish_Label_Position position)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setLabelPosition(swigCPtr, (int)position);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setHighlighting(OdPdfPublish_Highlighting_Mode mode)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setHighlighting(swigCPtr, (int)mode);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setIconImage(OdPdfPublish_OdImage image)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_setIconImage(swigCPtr, OdPdfPublish_OdImage.getCPtr(image));
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
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getName(swigCPtr, ref jarg);
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

	public void getLabel(ref string label)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(label);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getLabel(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				label = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getFont(out OdPdfPublish_Text_StorageType storageType, out OdPdfPublish_Text_StandardFontsType fontType, ref string fontName, out OdPdfPublish_Text_FontStyle fontStyle, out OdPdfPublish_Text_Language language, out bool embed)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(fontName);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getFont(swigCPtr, out storageType, out fontType, ref jarg, out fontStyle, out language, out embed);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getFontSize(swigCPtr, out size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTextColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getTextColor(swigCPtr, out color);
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
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getTooltip(swigCPtr, ref jarg);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getVisibility(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPrintability(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getPrintability(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTextRotation(out OdPdfPublish_Text_Rotation rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getTextRotation(swigCPtr, out rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLock(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getLock(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorder(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getBorder(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getBorderColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderThickness(out OdPdfPublish_Border_Thickness thickness)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getBorderThickness(swigCPtr, out thickness);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderStyle(out OdPdfPublish_Border_Style style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getBorderStyle(swigCPtr, out style);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getFillColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getFillColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLabelPosition(out OdPdfPublish_Label_Position position)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getLabelPosition(swigCPtr, out position);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getHighlighting(out OdPdfPublish_Highlighting_Mode mode)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getHighlighting(swigCPtr, out mode);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getIconImage(ref OdPdfPublish_OdImage image)
	{
		IntPtr jarg = ((image == null) ? IntPtr.Zero : OdPdfPublish_OdImage.getCPtr(image).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getIconImage(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				image = null;
			}
			else if (jarg != intPtr)
			{
				image = Helpers.GetRXObject<OdPdfPublish_OdImage>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdButton_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdButton));
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

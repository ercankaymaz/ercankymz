using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdAnnotation : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdAnnotation_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdAnnotation_1();

	public delegate void SwigDelegateOdPdfPublish_OdAnnotation_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdAnnotation_3();

	public delegate bool SwigDelegateOdPdfPublish_OdAnnotation_4();

	public delegate void SwigDelegateOdPdfPublish_OdAnnotation_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdAnnotation_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdAnnotation_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdAnnotation_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdAnnotation_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdAnnotation_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdAnnotation_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdAnnotation(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdAnnotation obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdAnnotation(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdAnnotation()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdAnnotation(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdAnnotation) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdAnnotation cast(OdRxObject pObj)
	{
		OdPdfPublish_OdAnnotation rXObject = Helpers.GetRXObject<OdPdfPublish_OdAnnotation>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_isASwigExplicitOdPdfPublish_OdAnnotation(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_queryXSwigExplicitOdPdfPublish_OdAnnotation(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdAnnotation createObject()
	{
		OdPdfPublish_OdAnnotation rXObject = Helpers.GetRXObject<OdPdfPublish_OdAnnotation>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setSource(OdPdfPublish_OdCADModel cad_model)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setSource(swigCPtr, OdPdfPublish_OdCADModel.getCPtr(cad_model));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setName(string name)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setName(swigCPtr, name);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setArtwork(OdPdfPublish_OdArtwork artwork)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setArtwork(swigCPtr, OdPdfPublish_OdArtwork.getCPtr(artwork));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setToolbarVisibility(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setToolbarVisibility(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setModelTreeVisibility(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setModelTreeVisibility(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setInteractivity(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setInteractivity(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderWidth(ushort width)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setBorderWidth(swigCPtr, width);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTransparentBackground(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setTransparentBackground(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPosterImage(OdPdfPublish_OdImage image)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setPosterImage(swigCPtr, OdPdfPublish_OdImage.getCPtr(image));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setActivation(OdPdfPublish_Activation_When when)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setActivation(swigCPtr, (int)when);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDeactivation(OdPdfPublish_Deactivation_When when)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setDeactivation(swigCPtr, (int)when);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCarouselButtons(OdStringArray button_names, string previous_button_name, string next_button_name, ushort scroll_size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setCarouselButtons(swigCPtr, OdStringArray.getCPtr(button_names).Handle, previous_button_name, next_button_name, scroll_size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCarouselViews(OdUInt32Array indices, OdPdfPublish_OdImagePtrArray images)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setCarouselViews(swigCPtr, OdUInt32Array.getCPtr(indices).Handle, OdPdfPublish_OdImagePtrArray.getCPtr(images));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCarouselScrollButtonsImages(OdPdfPublish_OdImage previous_button, OdPdfPublish_OdImage next_button)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setCarouselScrollButtonsImages(swigCPtr, OdPdfPublish_OdImage.getCPtr(previous_button), OdPdfPublish_OdImage.getCPtr(next_button));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCarouselButtonsFillColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setCarouselButtonsFillColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCarouselButtonsOffset(uint value)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setCarouselButtonsOffset(swigCPtr, value);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCarouselButtonsFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle, OdPdfPublish_Text_Language language, bool embed)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_0(swigCPtr, fontName, (int)fontStyle, (int)language, embed);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCarouselButtonsFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle, OdPdfPublish_Text_Language language)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_1(swigCPtr, fontName, (int)fontStyle, (int)language);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCarouselButtonsFont(string fontName, OdPdfPublish_Text_FontStyle fontStyle)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_2(swigCPtr, fontName, (int)fontStyle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCarouselButtonsFont(string fontName)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_3(swigCPtr, fontName);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCarouselButtonsFont(OdPdfPublish_Text_StandardFontsType fontType)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_4(swigCPtr, (int)fontType);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCarouselButtonsFontSize(ushort size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setCarouselButtonsFontSize(swigCPtr, size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCarouselButtonsAlignment(OdPdfPublish_CarouselButtons_Alignment alignment)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setCarouselButtonsAlignment(swigCPtr, (int)alignment);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setViewListByField(string field)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setViewListByField(swigCPtr, field);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setViewList(OdGsDCRect location, OdPdfPublish_OdListBox list)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setViewList(swigCPtr, OdGsDCRect.getCPtr(location), OdPdfPublish_OdListBox.getCPtr(list));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPartsList(OdStringArray node_names, OdGsDCRect location, OdStringArray headers, OdDoubleArray columns, OdPdfPublish_OdTextField text_style, OdPdfPublish_OdTextField header_style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setPartsList__SWIG_0(swigCPtr, OdStringArray.getCPtr(node_names), OdGsDCRect.getCPtr(location), OdStringArray.getCPtr(headers).Handle, OdDoubleArray.getCPtr(columns).Handle, OdPdfPublish_OdTextField.getCPtr(text_style), OdPdfPublish_OdTextField.getCPtr(header_style));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPartsList(OdStringArray node_names, OdGsDCRect location, OdStringArray headers, OdDoubleArray columns, OdPdfPublish_OdTextField text_style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setPartsList__SWIG_1(swigCPtr, OdStringArray.getCPtr(node_names), OdGsDCRect.getCPtr(location), OdStringArray.getCPtr(headers).Handle, OdDoubleArray.getCPtr(columns).Handle, OdPdfPublish_OdTextField.getCPtr(text_style));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPartsList(OdStringArray node_names, OdGsDCRect location, OdStringArray headers, OdDoubleArray columns)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setPartsList__SWIG_2(swigCPtr, OdStringArray.getCPtr(node_names), OdGsDCRect.getCPtr(location), OdStringArray.getCPtr(headers).Handle, OdDoubleArray.getCPtr(columns).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPropertyList(OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setPropertyList(swigCPtr, OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPropertyToTextField(string property_name, OdPdfPublish_OdTextField text_fields)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_setPropertyToTextField(swigCPtr, property_name, OdPdfPublish_OdTextField.getCPtr(text_fields));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSource(ref OdPdfPublish_OdCADModel cad_model)
	{
		IntPtr jarg = ((cad_model == null) ? IntPtr.Zero : OdPdfPublish_OdCADModel.getCPtr(cad_model).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getSource(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				cad_model = null;
			}
			else if (jarg != intPtr)
			{
				cad_model = Helpers.GetRXObject<OdPdfPublish_OdCADModel>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getName(ref string name)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(name);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getName(swigCPtr, ref jarg);
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

	public void getArtwork(ref OdPdfPublish_OdArtwork artwork)
	{
		IntPtr jarg = ((artwork == null) ? IntPtr.Zero : OdPdfPublish_OdArtwork.getCPtr(artwork).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getArtwork(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				artwork = null;
			}
			else if (jarg != intPtr)
			{
				artwork = Helpers.GetRXObject<OdPdfPublish_OdArtwork>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getToolbarVisibility(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getToolbarVisibility(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getModelTreeVisibility(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getModelTreeVisibility(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getInteractivity(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getInteractivity(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderWidth(out ushort width)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getBorderWidth(swigCPtr, out width);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTransparentBackground(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getTransparentBackground(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPosterImage(ref OdPdfPublish_OdImage image)
	{
		IntPtr jarg = ((image == null) ? IntPtr.Zero : OdPdfPublish_OdImage.getCPtr(image).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getPosterImage(swigCPtr, ref jarg);
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

	public void getActivation(out OdPdfPublish_Activation_When when)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getActivation(swigCPtr, out when);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDeactivation(out OdPdfPublish_Deactivation_When when)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getDeactivation(swigCPtr, out when);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCarouselButtons(OdStringArray button_names, ref string previous_button_name, ref string next_button_name, out ushort scroll_size)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(previous_button_name);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = Marshal.StringToCoTaskMemUni(next_button_name);
		IntPtr intPtr2 = jarg2;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getCarouselButtons(swigCPtr, OdStringArray.getCPtr(button_names).Handle, ref jarg, ref jarg2, out scroll_size);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				previous_button_name = Marshal.PtrToStringUni(jarg);
			}
			if (jarg2 != intPtr2)
			{
				next_button_name = Marshal.PtrToStringUni(jarg2);
			}
		}
	}

	public void getCarouselViews(OdUInt32Array indices, OdPdfPublish_OdImagePtrArray images)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getCarouselViews(swigCPtr, OdUInt32Array.getCPtr(indices).Handle, OdPdfPublish_OdImagePtrArray.getCPtr(images));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCarouselScrollButtonsImages(ref OdPdfPublish_OdImage previous_button, ref OdPdfPublish_OdImage next_button)
	{
		IntPtr jarg = ((previous_button == null) ? IntPtr.Zero : OdPdfPublish_OdImage.getCPtr(previous_button).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((next_button == null) ? IntPtr.Zero : OdPdfPublish_OdImage.getCPtr(next_button).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getCarouselScrollButtonsImages(swigCPtr, ref jarg, ref jarg2);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				previous_button = null;
			}
			else if (jarg != intPtr)
			{
				previous_button = Helpers.GetRXObject<OdPdfPublish_OdImage>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				next_button = null;
			}
			else if (jarg2 != intPtr2)
			{
				next_button = Helpers.GetRXObject<OdPdfPublish_OdImage>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getCarouselButtonsFillColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getCarouselButtonsFillColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCarouselButtonsOffset(out uint value)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getCarouselButtonsOffset(swigCPtr, out value);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCarouselButtonsFont(out OdPdfPublish_Text_StorageType storageType, out OdPdfPublish_Text_StandardFontsType fontType, ref string fontName, out OdPdfPublish_Text_FontStyle fontStyle, out OdPdfPublish_Text_Language language, out bool embed)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(fontName);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getCarouselButtonsFont(swigCPtr, out storageType, out fontType, ref jarg, out fontStyle, out language, out embed);
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

	public void getCarouselButtonsFontSize(out ushort size)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getCarouselButtonsFontSize(swigCPtr, out size);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCarouselButtonsAlignment(out OdPdfPublish_CarouselButtons_Alignment alignment)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getCarouselButtonsAlignment(swigCPtr, out alignment);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getViewListField(ref string field)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(field);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getViewListField(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				field = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getViewList(OdGsDCRect location, ref OdPdfPublish_OdListBox list)
	{
		IntPtr jarg = ((list == null) ? IntPtr.Zero : OdPdfPublish_OdListBox.getCPtr(list).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getViewList(swigCPtr, OdGsDCRect.getCPtr(location), ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				list = null;
			}
			else if (jarg != intPtr)
			{
				list = Helpers.GetRXObject<OdPdfPublish_OdListBox>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getPartsList(OdStringArray node_names, OdGsDCRect location, OdStringArray headers, OdDoubleArray columns, ref OdPdfPublish_OdTextField text_style, ref OdPdfPublish_OdTextField header_style)
	{
		IntPtr jarg = ((text_style == null) ? IntPtr.Zero : OdPdfPublish_OdTextField.getCPtr(text_style).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((header_style == null) ? IntPtr.Zero : OdPdfPublish_OdTextField.getCPtr(header_style).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getPartsList(swigCPtr, OdStringArray.getCPtr(node_names).Handle, OdGsDCRect.getCPtr(location), OdStringArray.getCPtr(headers).Handle, OdDoubleArray.getCPtr(columns).Handle, ref jarg, ref jarg2);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				text_style = null;
			}
			else if (jarg != intPtr)
			{
				text_style = Helpers.GetRXObject<OdPdfPublish_OdTextField>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				header_style = null;
			}
			else if (jarg2 != intPtr2)
			{
				header_style = Helpers.GetRXObject<OdPdfPublish_OdTextField>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getPropertyList(OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getPropertyList(swigCPtr, OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPropertyToTextField(string property_name, OdPdfPublish_OdTextFieldPtrArray text_field)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getPropertyToTextField(swigCPtr, property_name, OdPdfPublish_OdTextFieldPtrArray.getCPtr(text_field));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnnotation_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdAnnotation));
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

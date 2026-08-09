using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdArtwork : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdArtwork_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdArtwork_1();

	public delegate void SwigDelegateOdPdfPublish_OdArtwork_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdArtwork_3();

	public delegate bool SwigDelegateOdPdfPublish_OdArtwork_4();

	public delegate void SwigDelegateOdPdfPublish_OdArtwork_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdArtwork_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdArtwork_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdArtwork_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdArtwork_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdArtwork_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdArtwork_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdArtwork(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdArtwork obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdArtwork(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdArtwork()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdArtwork(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdArtwork) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdArtwork cast(OdRxObject pObj)
	{
		OdPdfPublish_OdArtwork rXObject = Helpers.GetRXObject<OdPdfPublish_OdArtwork>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_isASwigExplicitOdPdfPublish_OdArtwork(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_queryXSwigExplicitOdPdfPublish_OdArtwork(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdArtwork createObject()
	{
		OdPdfPublish_OdArtwork rXObject = Helpers.GetRXObject<OdPdfPublish_OdArtwork>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setAnimationStyle(OdPdfPublish_Artwork_AnimationStyle style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_setAnimationStyle(swigCPtr, (int)style);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setJavaScript(string source, OdPdfPublish_Source_Type source_type)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_setJavaScript__SWIG_0(swigCPtr, source, (int)source_type);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setJavaScript(string source)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_setJavaScript__SWIG_1(swigCPtr, source);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPMICrossHighlighting(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_setPMICrossHighlighting(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPMISemanticInformation(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_setPMISemanticInformation(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDefaultViewPreference(OdPdfPublish_Artwork_ViewPreference preference)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_setDefaultViewPreference(swigCPtr, (int)preference);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDisplayPreference(OdPdfPublish_Artwork_DisplayPreference preference)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_setDisplayPreference(swigCPtr, (int)preference);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addView(OdPdfPublish_OdView view)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_addView(swigCPtr, OdPdfPublish_OdView.getCPtr(view));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPMIColor(uint pmi_color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_setPMIColor(swigCPtr, pmi_color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addAnimation(OdPdfPublish_OdAnimation animation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_addAnimation(swigCPtr, OdPdfPublish_OdAnimation.getCPtr(animation));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getAnimationStyle(out OdPdfPublish_Artwork_AnimationStyle style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_getAnimationStyle(swigCPtr, out style);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getJavaScript(ref string source, out OdPdfPublish_Source_Type source_type)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(source);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_getJavaScript(swigCPtr, ref jarg, out source_type);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				source = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getPMICrossHighlighting(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_getPMICrossHighlighting(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPMISemanticInformation(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_getPMISemanticInformation(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDefaultViewPreference(out OdPdfPublish_Artwork_ViewPreference preference)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_getDefaultViewPreference(swigCPtr, out preference);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDisplayPreference(out OdPdfPublish_Artwork_DisplayPreference preference)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_getDisplayPreference(swigCPtr, out preference);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getViews(OdPdfPublish_OdViewPtrArray views)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_getViews(swigCPtr, OdPdfPublish_OdViewPtrArray.getCPtr(views));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPMIColor(out uint pmi_color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_getPMIColor(swigCPtr, out pmi_color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getAnimations(OdPdfPublish_OdAnimationPtrArray animations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_getAnimations(swigCPtr, OdPdfPublish_OdAnimationPtrArray.getCPtr(animations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdArtwork_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdArtwork));
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

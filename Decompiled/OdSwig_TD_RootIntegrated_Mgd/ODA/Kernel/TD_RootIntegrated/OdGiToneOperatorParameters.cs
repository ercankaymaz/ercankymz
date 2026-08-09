using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiToneOperatorParameters : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiToneOperatorParameters_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiToneOperatorParameters_1();

	public delegate void SwigDelegateOdGiToneOperatorParameters_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiToneOperatorParameters_3(bool bActive);

	public delegate bool SwigDelegateOdGiToneOperatorParameters_4();

	public delegate void SwigDelegateOdGiToneOperatorParameters_5(bool bEnable);

	public delegate bool SwigDelegateOdGiToneOperatorParameters_6();

	public delegate void SwigDelegateOdGiToneOperatorParameters_7(bool bEnable);

	public delegate bool SwigDelegateOdGiToneOperatorParameters_8();

	public delegate void SwigDelegateOdGiToneOperatorParameters_9(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiToneOperatorParameters_10();

	public delegate void SwigDelegateOdGiToneOperatorParameters_11(bool bProcessBg);

	public delegate bool SwigDelegateOdGiToneOperatorParameters_12();

	public delegate bool SwigDelegateOdGiToneOperatorParameters_13(double fBrightness);

	public delegate double SwigDelegateOdGiToneOperatorParameters_14();

	public delegate bool SwigDelegateOdGiToneOperatorParameters_15(double fContrast);

	public delegate double SwigDelegateOdGiToneOperatorParameters_16();

	public delegate bool SwigDelegateOdGiToneOperatorParameters_17(double fMidTones);

	public delegate double SwigDelegateOdGiToneOperatorParameters_18();

	public delegate bool SwigDelegateOdGiToneOperatorParameters_19(int mode);

	public delegate int SwigDelegateOdGiToneOperatorParameters_20();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiToneOperatorParameters_0 swigDelegate0;

	private SwigDelegateOdGiToneOperatorParameters_1 swigDelegate1;

	private SwigDelegateOdGiToneOperatorParameters_2 swigDelegate2;

	private SwigDelegateOdGiToneOperatorParameters_3 swigDelegate3;

	private SwigDelegateOdGiToneOperatorParameters_4 swigDelegate4;

	private SwigDelegateOdGiToneOperatorParameters_5 swigDelegate5;

	private SwigDelegateOdGiToneOperatorParameters_6 swigDelegate6;

	private SwigDelegateOdGiToneOperatorParameters_7 swigDelegate7;

	private SwigDelegateOdGiToneOperatorParameters_8 swigDelegate8;

	private SwigDelegateOdGiToneOperatorParameters_9 swigDelegate9;

	private SwigDelegateOdGiToneOperatorParameters_10 swigDelegate10;

	private SwigDelegateOdGiToneOperatorParameters_11 swigDelegate11;

	private SwigDelegateOdGiToneOperatorParameters_12 swigDelegate12;

	private SwigDelegateOdGiToneOperatorParameters_13 swigDelegate13;

	private SwigDelegateOdGiToneOperatorParameters_14 swigDelegate14;

	private SwigDelegateOdGiToneOperatorParameters_15 swigDelegate15;

	private SwigDelegateOdGiToneOperatorParameters_16 swigDelegate16;

	private SwigDelegateOdGiToneOperatorParameters_17 swigDelegate17;

	private SwigDelegateOdGiToneOperatorParameters_18 swigDelegate18;

	private SwigDelegateOdGiToneOperatorParameters_19 swigDelegate19;

	private SwigDelegateOdGiToneOperatorParameters_20 swigDelegate20;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdGiToneOperatorParameters_ExteriorDaylightMode) };

	private static Type[] swigMethodTypes20 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiToneOperatorParameters(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiToneOperatorParameters obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiToneOperatorParameters(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiToneOperatorParameters cast(OdRxObject pObj)
	{
		OdGiToneOperatorParameters rXObject = Helpers.GetRXObject<OdGiToneOperatorParameters>(TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_isASwigExplicitOdGiToneOperatorParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_queryXSwigExplicitOdGiToneOperatorParameters(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiToneOperatorParameters()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiToneOperatorParameters__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiToneOperatorParameters) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdGiToneOperatorParameters(OdGiToneOperatorParameters params_)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiToneOperatorParameters__SWIG_1(getCPtr(params_)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiToneOperatorParameters) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public bool IsEqual(OdGiToneOperatorParameters params_)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_IsEqual(swigCPtr, getCPtr(params_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiToneOperatorParameters params_)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_IsNotEqual(swigCPtr, getCPtr(params_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiToneOperatorParameters Assign(OdGiToneOperatorParameters params_)
	{
		OdGiToneOperatorParameters rXObject = Helpers.GetRXObject<OdGiToneOperatorParameters>(TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_Assign(swigCPtr, getCPtr(params_)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setIsActive(bool bActive)
	{
		if (SwigDerivedClassHasMethod("setIsActive", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setIsActiveSwigExplicitOdGiToneOperatorParameters(swigCPtr, bActive);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setIsActive(swigCPtr, bActive);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isActive()
	{
		bool result = (SwigDerivedClassHasMethod("isActive", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_isActiveSwigExplicitOdGiToneOperatorParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_isActive(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setChromaticAdaptation(bool bEnable)
	{
		if (SwigDerivedClassHasMethod("setChromaticAdaptation", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setChromaticAdaptationSwigExplicitOdGiToneOperatorParameters(swigCPtr, bEnable);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setChromaticAdaptation(swigCPtr, bEnable);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool chromaticAdaptation()
	{
		bool result = (SwigDerivedClassHasMethod("chromaticAdaptation", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_chromaticAdaptationSwigExplicitOdGiToneOperatorParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_chromaticAdaptation(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColorDifferentiation(bool bEnable)
	{
		if (SwigDerivedClassHasMethod("setColorDifferentiation", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setColorDifferentiationSwigExplicitOdGiToneOperatorParameters(swigCPtr, bEnable);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setColorDifferentiation(swigCPtr, bEnable);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool colorDifferentiation()
	{
		bool result = (SwigDerivedClassHasMethod("colorDifferentiation", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_colorDifferentiationSwigExplicitOdGiToneOperatorParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_colorDifferentiation(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setWhiteColor(OdCmEntityColor color)
	{
		if (SwigDerivedClassHasMethod("setWhiteColor", swigMethodTypes9))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setWhiteColorSwigExplicitOdGiToneOperatorParameters(swigCPtr, OdCmEntityColor.getCPtr(color));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setWhiteColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor whiteColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("whiteColor", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_whiteColorSwigExplicitOdGiToneOperatorParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_whiteColor(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setProcessBackground(bool bProcessBg)
	{
		if (SwigDerivedClassHasMethod("setProcessBackground", swigMethodTypes11))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setProcessBackgroundSwigExplicitOdGiToneOperatorParameters(swigCPtr, bProcessBg);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setProcessBackground(swigCPtr, bProcessBg);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool processBackground()
	{
		bool result = (SwigDerivedClassHasMethod("processBackground", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_processBackgroundSwigExplicitOdGiToneOperatorParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_processBackground(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setBrightness(double fBrightness)
	{
		bool result = (SwigDerivedClassHasMethod("setBrightness", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setBrightnessSwigExplicitOdGiToneOperatorParameters(swigCPtr, fBrightness) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setBrightness(swigCPtr, fBrightness));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double brightness()
	{
		double result = (SwigDerivedClassHasMethod("brightness", swigMethodTypes14) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_brightnessSwigExplicitOdGiToneOperatorParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_brightness(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setContrast(double fContrast)
	{
		bool result = (SwigDerivedClassHasMethod("setContrast", swigMethodTypes15) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setContrastSwigExplicitOdGiToneOperatorParameters(swigCPtr, fContrast) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setContrast(swigCPtr, fContrast));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double contrast()
	{
		double result = (SwigDerivedClassHasMethod("contrast", swigMethodTypes16) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_contrastSwigExplicitOdGiToneOperatorParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_contrast(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setMidTones(double fMidTones)
	{
		bool result = (SwigDerivedClassHasMethod("setMidTones", swigMethodTypes17) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setMidTonesSwigExplicitOdGiToneOperatorParameters(swigCPtr, fMidTones) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setMidTones(swigCPtr, fMidTones));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double midTones()
	{
		double result = (SwigDerivedClassHasMethod("midTones", swigMethodTypes18) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_midTonesSwigExplicitOdGiToneOperatorParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_midTones(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setExteriorDaylight(OdGiToneOperatorParameters_ExteriorDaylightMode mode)
	{
		bool result = (SwigDerivedClassHasMethod("setExteriorDaylight", swigMethodTypes19) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setExteriorDaylightSwigExplicitOdGiToneOperatorParameters(swigCPtr, (int)mode) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_setExteriorDaylight(swigCPtr, (int)mode));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiToneOperatorParameters_ExteriorDaylightMode exteriorDaylight()
	{
		int result = (SwigDerivedClassHasMethod("exteriorDaylight", swigMethodTypes20) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_exteriorDaylightSwigExplicitOdGiToneOperatorParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_exteriorDaylight(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiToneOperatorParameters_ExteriorDaylightMode)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiToneOperatorParameters createObject()
	{
		OdGiToneOperatorParameters rXObject = Helpers.GetRXObject<OdGiToneOperatorParameters>(TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("setIsActive", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetIsActive;
		}
		if (SwigDerivedClassHasMethod("isActive", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisActive;
		}
		if (SwigDerivedClassHasMethod("setChromaticAdaptation", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetChromaticAdaptation;
		}
		if (SwigDerivedClassHasMethod("chromaticAdaptation", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodchromaticAdaptation;
		}
		if (SwigDerivedClassHasMethod("setColorDifferentiation", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetColorDifferentiation;
		}
		if (SwigDerivedClassHasMethod("colorDifferentiation", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcolorDifferentiation;
		}
		if (SwigDerivedClassHasMethod("setWhiteColor", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetWhiteColor;
		}
		if (SwigDerivedClassHasMethod("whiteColor", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodwhiteColor;
		}
		if (SwigDerivedClassHasMethod("setProcessBackground", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetProcessBackground;
		}
		if (SwigDerivedClassHasMethod("processBackground", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodprocessBackground;
		}
		if (SwigDerivedClassHasMethod("setBrightness", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetBrightness;
		}
		if (SwigDerivedClassHasMethod("brightness", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodbrightness;
		}
		if (SwigDerivedClassHasMethod("setContrast", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetContrast;
		}
		if (SwigDerivedClassHasMethod("contrast", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodcontrast;
		}
		if (SwigDerivedClassHasMethod("setMidTones", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetMidTones;
		}
		if (SwigDerivedClassHasMethod("midTones", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodmidTones;
		}
		if (SwigDerivedClassHasMethod("setExteriorDaylight", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetExteriorDaylight;
		}
		if (SwigDerivedClassHasMethod("exteriorDaylight", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodexteriorDaylight;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiToneOperatorParameters_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiToneOperatorParameters));
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
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetIsActive(bool bActive)
	{
		try
		{
			setIsActive(bActive);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisActive()
	{
		return isActive();
	}

	private void SwigDirectorMethodsetChromaticAdaptation(bool bEnable)
	{
		try
		{
			setChromaticAdaptation(bEnable);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodchromaticAdaptation()
	{
		return chromaticAdaptation();
	}

	private void SwigDirectorMethodsetColorDifferentiation(bool bEnable)
	{
		try
		{
			setColorDifferentiation(bEnable);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodcolorDifferentiation()
	{
		return colorDifferentiation();
	}

	private void SwigDirectorMethodsetWhiteColor(IntPtr color)
	{
		try
		{
			setWhiteColor(new OdCmEntityColor(color, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodwhiteColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(whiteColor()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetProcessBackground(bool bProcessBg)
	{
		try
		{
			setProcessBackground(bProcessBg);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodprocessBackground()
	{
		return processBackground();
	}

	private bool SwigDirectorMethodsetBrightness(double fBrightness)
	{
		return setBrightness(fBrightness);
	}

	private double SwigDirectorMethodbrightness()
	{
		return brightness();
	}

	private bool SwigDirectorMethodsetContrast(double fContrast)
	{
		return setContrast(fContrast);
	}

	private double SwigDirectorMethodcontrast()
	{
		return contrast();
	}

	private bool SwigDirectorMethodsetMidTones(double fMidTones)
	{
		return setMidTones(fMidTones);
	}

	private double SwigDirectorMethodmidTones()
	{
		return midTones();
	}

	private bool SwigDirectorMethodsetExteriorDaylight(int mode)
	{
		return setExteriorDaylight((OdGiToneOperatorParameters_ExteriorDaylightMode)mode);
	}

	private int SwigDirectorMethodexteriorDaylight()
	{
		return (int)exteriorDaylight();
	}
}

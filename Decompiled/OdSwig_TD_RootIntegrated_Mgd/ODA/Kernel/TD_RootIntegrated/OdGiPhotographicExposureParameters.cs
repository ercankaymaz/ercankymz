using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPhotographicExposureParameters : OdGiToneOperatorParameters
{
	public delegate IntPtr SwigDelegateOdGiPhotographicExposureParameters_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiPhotographicExposureParameters_1();

	public delegate void SwigDelegateOdGiPhotographicExposureParameters_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiPhotographicExposureParameters_3(bool bActive);

	public delegate bool SwigDelegateOdGiPhotographicExposureParameters_4();

	public delegate void SwigDelegateOdGiPhotographicExposureParameters_5(bool bEnable);

	public delegate bool SwigDelegateOdGiPhotographicExposureParameters_6();

	public delegate void SwigDelegateOdGiPhotographicExposureParameters_7(bool bEnable);

	public delegate bool SwigDelegateOdGiPhotographicExposureParameters_8();

	public delegate void SwigDelegateOdGiPhotographicExposureParameters_9(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiPhotographicExposureParameters_10();

	public delegate void SwigDelegateOdGiPhotographicExposureParameters_11(bool bProcessBg);

	public delegate bool SwigDelegateOdGiPhotographicExposureParameters_12();

	public delegate bool SwigDelegateOdGiPhotographicExposureParameters_13(double fBrightness);

	public delegate double SwigDelegateOdGiPhotographicExposureParameters_14();

	public delegate bool SwigDelegateOdGiPhotographicExposureParameters_15(double fContrast);

	public delegate double SwigDelegateOdGiPhotographicExposureParameters_16();

	public delegate bool SwigDelegateOdGiPhotographicExposureParameters_17(double fMidTones);

	public delegate double SwigDelegateOdGiPhotographicExposureParameters_18();

	public delegate bool SwigDelegateOdGiPhotographicExposureParameters_19(int mode);

	public delegate int SwigDelegateOdGiPhotographicExposureParameters_20();

	public delegate bool SwigDelegateOdGiPhotographicExposureParameters_21(double fExposure);

	public delegate double SwigDelegateOdGiPhotographicExposureParameters_22();

	public delegate bool SwigDelegateOdGiPhotographicExposureParameters_23(double fWhitePoint);

	public delegate double SwigDelegateOdGiPhotographicExposureParameters_24();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiPhotographicExposureParameters_0 swigDelegate0;

	private SwigDelegateOdGiPhotographicExposureParameters_1 swigDelegate1;

	private SwigDelegateOdGiPhotographicExposureParameters_2 swigDelegate2;

	private SwigDelegateOdGiPhotographicExposureParameters_3 swigDelegate3;

	private SwigDelegateOdGiPhotographicExposureParameters_4 swigDelegate4;

	private SwigDelegateOdGiPhotographicExposureParameters_5 swigDelegate5;

	private SwigDelegateOdGiPhotographicExposureParameters_6 swigDelegate6;

	private SwigDelegateOdGiPhotographicExposureParameters_7 swigDelegate7;

	private SwigDelegateOdGiPhotographicExposureParameters_8 swigDelegate8;

	private SwigDelegateOdGiPhotographicExposureParameters_9 swigDelegate9;

	private SwigDelegateOdGiPhotographicExposureParameters_10 swigDelegate10;

	private SwigDelegateOdGiPhotographicExposureParameters_11 swigDelegate11;

	private SwigDelegateOdGiPhotographicExposureParameters_12 swigDelegate12;

	private SwigDelegateOdGiPhotographicExposureParameters_13 swigDelegate13;

	private SwigDelegateOdGiPhotographicExposureParameters_14 swigDelegate14;

	private SwigDelegateOdGiPhotographicExposureParameters_15 swigDelegate15;

	private SwigDelegateOdGiPhotographicExposureParameters_16 swigDelegate16;

	private SwigDelegateOdGiPhotographicExposureParameters_17 swigDelegate17;

	private SwigDelegateOdGiPhotographicExposureParameters_18 swigDelegate18;

	private SwigDelegateOdGiPhotographicExposureParameters_19 swigDelegate19;

	private SwigDelegateOdGiPhotographicExposureParameters_20 swigDelegate20;

	private SwigDelegateOdGiPhotographicExposureParameters_21 swigDelegate21;

	private SwigDelegateOdGiPhotographicExposureParameters_22 swigDelegate22;

	private SwigDelegateOdGiPhotographicExposureParameters_23 swigDelegate23;

	private SwigDelegateOdGiPhotographicExposureParameters_24 swigDelegate24;

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

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes24 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPhotographicExposureParameters(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPhotographicExposureParameters obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPhotographicExposureParameters(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiPhotographicExposureParameters cast(OdRxObject pObj)
	{
		OdGiPhotographicExposureParameters rXObject = Helpers.GetRXObject<OdGiPhotographicExposureParameters>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_isASwigExplicitOdGiPhotographicExposureParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_queryXSwigExplicitOdGiPhotographicExposureParameters(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiPhotographicExposureParameters()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPhotographicExposureParameters__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiPhotographicExposureParameters) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdGiPhotographicExposureParameters(OdGiPhotographicExposureParameters params_)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPhotographicExposureParameters__SWIG_1(getCPtr(params_)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiPhotographicExposureParameters) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public bool IsEqual(OdGiPhotographicExposureParameters params_)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_IsEqual(swigCPtr, getCPtr(params_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiPhotographicExposureParameters params_)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_IsNotEqual(swigCPtr, getCPtr(params_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiPhotographicExposureParameters Assign(OdGiPhotographicExposureParameters params_)
	{
		OdGiPhotographicExposureParameters rXObject = Helpers.GetRXObject<OdGiPhotographicExposureParameters>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_Assign(swigCPtr, getCPtr(params_)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool setExposure(double fExposure)
	{
		bool result = (SwigDerivedClassHasMethod("setExposure", swigMethodTypes21) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_setExposureSwigExplicitOdGiPhotographicExposureParameters(swigCPtr, fExposure) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_setExposure(swigCPtr, fExposure));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double exposure()
	{
		double result = (SwigDerivedClassHasMethod("exposure", swigMethodTypes22) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_exposureSwigExplicitOdGiPhotographicExposureParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_exposure(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setWhitePoint(double fWhitePoint)
	{
		bool result = (SwigDerivedClassHasMethod("setWhitePoint", swigMethodTypes23) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_setWhitePointSwigExplicitOdGiPhotographicExposureParameters(swigCPtr, fWhitePoint) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_setWhitePoint(swigCPtr, fWhitePoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double whitePoint()
	{
		double result = (SwigDerivedClassHasMethod("whitePoint", swigMethodTypes24) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_whitePointSwigExplicitOdGiPhotographicExposureParameters(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_whitePoint(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool setBrightness(double fBrightness)
	{
		bool result = (SwigDerivedClassHasMethod("setBrightness", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_setBrightnessSwigExplicitOdGiPhotographicExposureParameters(swigCPtr, fBrightness) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_setBrightness(swigCPtr, fBrightness));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColor whitePointToColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_whitePointToColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double convertExposureToBrightness(double fExposure)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_convertExposureToBrightness(fExposure);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double convertBrightnessToExposure(double fBrightness)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_convertBrightnessToExposure(fBrightness);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiPhotographicExposureParameters createObject()
	{
		OdGiPhotographicExposureParameters rXObject = Helpers.GetRXObject<OdGiPhotographicExposureParameters>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("setExposure", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetExposure;
		}
		if (SwigDerivedClassHasMethod("exposure", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodexposure;
		}
		if (SwigDerivedClassHasMethod("setWhitePoint", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodsetWhitePoint;
		}
		if (SwigDerivedClassHasMethod("whitePoint", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodwhitePoint;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPhotographicExposureParameters_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPhotographicExposureParameters));
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

	private bool SwigDirectorMethodsetExposure(double fExposure)
	{
		return setExposure(fExposure);
	}

	private double SwigDirectorMethodexposure()
	{
		return exposure();
	}

	private bool SwigDirectorMethodsetWhitePoint(double fWhitePoint)
	{
		return setWhitePoint(fWhitePoint);
	}

	private double SwigDirectorMethodwhitePoint()
	{
		return whitePoint();
	}
}

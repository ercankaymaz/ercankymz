using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDistantLightTraits : OdGiStandardLightTraits
{
	public delegate IntPtr SwigDelegateOdGiDistantLightTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiDistantLightTraits_1();

	public delegate void SwigDelegateOdGiDistantLightTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiDistantLightTraits_3(bool on);

	public delegate bool SwigDelegateOdGiDistantLightTraits_4();

	public delegate void SwigDelegateOdGiDistantLightTraits_5(double inten);

	public delegate double SwigDelegateOdGiDistantLightTraits_6();

	public delegate void SwigDelegateOdGiDistantLightTraits_7(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiDistantLightTraits_8();

	public delegate void SwigDelegateOdGiDistantLightTraits_9(IntPtr params_);

	public delegate IntPtr SwigDelegateOdGiDistantLightTraits_10();

	public delegate void SwigDelegateOdGiDistantLightTraits_11(IntPtr vec);

	public delegate IntPtr SwigDelegateOdGiDistantLightTraits_12();

	public delegate void SwigDelegateOdGiDistantLightTraits_13(bool isSunlight);

	public delegate bool SwigDelegateOdGiDistantLightTraits_14();

	public delegate void SwigDelegateOdGiDistantLightTraits_15(double fIntensity);

	public delegate double SwigDelegateOdGiDistantLightTraits_16();

	public delegate void SwigDelegateOdGiDistantLightTraits_17(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiDistantLightTraits_18();

	public delegate void SwigDelegateOdGiDistantLightTraits_19(IntPtr params_);

	public delegate void SwigDelegateOdGiDistantLightTraits_20(IntPtr params_);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiDistantLightTraits_0 swigDelegate0;

	private SwigDelegateOdGiDistantLightTraits_1 swigDelegate1;

	private SwigDelegateOdGiDistantLightTraits_2 swigDelegate2;

	private SwigDelegateOdGiDistantLightTraits_3 swigDelegate3;

	private SwigDelegateOdGiDistantLightTraits_4 swigDelegate4;

	private SwigDelegateOdGiDistantLightTraits_5 swigDelegate5;

	private SwigDelegateOdGiDistantLightTraits_6 swigDelegate6;

	private SwigDelegateOdGiDistantLightTraits_7 swigDelegate7;

	private SwigDelegateOdGiDistantLightTraits_8 swigDelegate8;

	private SwigDelegateOdGiDistantLightTraits_9 swigDelegate9;

	private SwigDelegateOdGiDistantLightTraits_10 swigDelegate10;

	private SwigDelegateOdGiDistantLightTraits_11 swigDelegate11;

	private SwigDelegateOdGiDistantLightTraits_12 swigDelegate12;

	private SwigDelegateOdGiDistantLightTraits_13 swigDelegate13;

	private SwigDelegateOdGiDistantLightTraits_14 swigDelegate14;

	private SwigDelegateOdGiDistantLightTraits_15 swigDelegate15;

	private SwigDelegateOdGiDistantLightTraits_16 swigDelegate16;

	private SwigDelegateOdGiDistantLightTraits_17 swigDelegate17;

	private SwigDelegateOdGiDistantLightTraits_18 swigDelegate18;

	private SwigDelegateOdGiDistantLightTraits_19 swigDelegate19;

	private SwigDelegateOdGiDistantLightTraits_20 swigDelegate20;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGiShadowParameters) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGiColorRGB) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdGiSkyParameters) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdGiSkyParameters) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDistantLightTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDistantLightTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDistantLightTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiDistantLightTraits cast(OdRxObject pObj)
	{
		OdGiDistantLightTraits rXObject = Helpers.GetRXObject<OdGiDistantLightTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_isASwigExplicitOdGiDistantLightTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_queryXSwigExplicitOdGiDistantLightTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiDistantLightTraits createObject()
	{
		OdGiDistantLightTraits rXObject = Helpers.GetRXObject<OdGiDistantLightTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setLightDirection(OdGeVector3d vec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_setLightDirection(swigCPtr, OdGeVector3d.getCPtr(vec));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeVector3d lightDirection()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_lightDirection(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setIsSunlight(bool isSunlight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_setIsSunlight(swigCPtr, isSunlight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isSunlight()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_isSunlight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPhysicalIntensity(double fIntensity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_setPhysicalIntensity(swigCPtr, fIntensity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double physicalIntensity()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_physicalIntensity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLampColor(OdGiColorRGB color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_setLampColor(swigCPtr, OdGiColorRGB.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiColorRGB lampColor()
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_lampColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSkyParameters(OdGiSkyParameters params_)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_setSkyParameters(swigCPtr, OdGiSkyParameters.getCPtr(params_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void skyParameters(OdGiSkyParameters params_)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_skyParameters(swigCPtr, OdGiSkyParameters.getCPtr(params_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiDistantLightTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDistantLightTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiDistantLightTraits) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		if (SwigDerivedClassHasMethod("setOn", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetOn;
		}
		if (SwigDerivedClassHasMethod("isOn", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisOn;
		}
		if (SwigDerivedClassHasMethod("setIntensity", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetIntensity;
		}
		if (SwigDerivedClassHasMethod("intensity", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodintensity;
		}
		if (SwigDerivedClassHasMethod("setLightColor", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetLightColor;
		}
		if (SwigDerivedClassHasMethod("lightColor", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodlightColor;
		}
		if (SwigDerivedClassHasMethod("setShadowParameters", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetShadowParameters;
		}
		if (SwigDerivedClassHasMethod("shadowParameters", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodshadowParameters;
		}
		if (SwigDerivedClassHasMethod("setLightDirection", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetLightDirection;
		}
		if (SwigDerivedClassHasMethod("lightDirection", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodlightDirection;
		}
		if (SwigDerivedClassHasMethod("setIsSunlight", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetIsSunlight;
		}
		if (SwigDerivedClassHasMethod("isSunlight", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodisSunlight;
		}
		if (SwigDerivedClassHasMethod("setPhysicalIntensity", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetPhysicalIntensity;
		}
		if (SwigDerivedClassHasMethod("physicalIntensity", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodphysicalIntensity;
		}
		if (SwigDerivedClassHasMethod("setLampColor", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetLampColor;
		}
		if (SwigDerivedClassHasMethod("lampColor", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodlampColor;
		}
		if (SwigDerivedClassHasMethod("setSkyParameters", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetSkyParameters;
		}
		if (SwigDerivedClassHasMethod("skyParameters", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodskyParameters;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDistantLightTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiDistantLightTraits));
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

	private void SwigDirectorMethodsetOn(bool on)
	{
		try
		{
			setOn(on);
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

	private bool SwigDirectorMethodisOn()
	{
		return isOn();
	}

	private void SwigDirectorMethodsetIntensity(double inten)
	{
		try
		{
			setIntensity(inten);
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

	private double SwigDirectorMethodintensity()
	{
		return intensity();
	}

	private void SwigDirectorMethodsetLightColor(IntPtr color)
	{
		try
		{
			setLightColor(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodlightColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(lightColor()).Handle;
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

	private void SwigDirectorMethodsetShadowParameters(IntPtr params_)
	{
		try
		{
			setShadowParameters(new OdGiShadowParameters(params_, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodshadowParameters()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiShadowParameters.getCPtr(shadowParameters()).Handle;
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

	private void SwigDirectorMethodsetLightDirection(IntPtr vec)
	{
		try
		{
			setLightDirection(new OdGeVector3d(vec, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodlightDirection()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(lightDirection()).Handle;
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

	private void SwigDirectorMethodsetIsSunlight(bool isSunlight)
	{
		try
		{
			setIsSunlight(isSunlight);
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

	private bool SwigDirectorMethodisSunlight()
	{
		return isSunlight();
	}

	private void SwigDirectorMethodsetPhysicalIntensity(double fIntensity)
	{
		try
		{
			setPhysicalIntensity(fIntensity);
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

	private double SwigDirectorMethodphysicalIntensity()
	{
		return physicalIntensity();
	}

	private void SwigDirectorMethodsetLampColor(IntPtr color)
	{
		try
		{
			setLampColor(new OdGiColorRGB(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodlampColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiColorRGB.getCPtr(lampColor()).Handle;
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

	private void SwigDirectorMethodsetSkyParameters(IntPtr params_)
	{
		try
		{
			setSkyParameters(new OdGiSkyParameters(params_, cMemoryOwn: false));
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

	private void SwigDirectorMethodskyParameters(IntPtr params_)
	{
		try
		{
			skyParameters(new OdGiSkyParameters(params_, cMemoryOwn: false));
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
}

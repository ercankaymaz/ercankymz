using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSpotLightTraits : OdGiStandardLightTraits
{
	public delegate IntPtr SwigDelegateOdGiSpotLightTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiSpotLightTraits_1();

	public delegate void SwigDelegateOdGiSpotLightTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiSpotLightTraits_3(bool on);

	public delegate bool SwigDelegateOdGiSpotLightTraits_4();

	public delegate void SwigDelegateOdGiSpotLightTraits_5(double inten);

	public delegate double SwigDelegateOdGiSpotLightTraits_6();

	public delegate void SwigDelegateOdGiSpotLightTraits_7(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiSpotLightTraits_8();

	public delegate void SwigDelegateOdGiSpotLightTraits_9(IntPtr params_);

	public delegate IntPtr SwigDelegateOdGiSpotLightTraits_10();

	public delegate void SwigDelegateOdGiSpotLightTraits_11(IntPtr pos);

	public delegate IntPtr SwigDelegateOdGiSpotLightTraits_12();

	public delegate void SwigDelegateOdGiSpotLightTraits_13(IntPtr loc);

	public delegate IntPtr SwigDelegateOdGiSpotLightTraits_14();

	public delegate bool SwigDelegateOdGiSpotLightTraits_15(double hotspot, double falloff);

	public delegate double SwigDelegateOdGiSpotLightTraits_16();

	public delegate double SwigDelegateOdGiSpotLightTraits_17();

	public delegate IntPtr SwigDelegateOdGiSpotLightTraits_18();

	public delegate void SwigDelegateOdGiSpotLightTraits_19(IntPtr atten);

	public delegate void SwigDelegateOdGiSpotLightTraits_20(double fIntensity);

	public delegate double SwigDelegateOdGiSpotLightTraits_21();

	public delegate void SwigDelegateOdGiSpotLightTraits_22(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiSpotLightTraits_23();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiSpotLightTraits_0 swigDelegate0;

	private SwigDelegateOdGiSpotLightTraits_1 swigDelegate1;

	private SwigDelegateOdGiSpotLightTraits_2 swigDelegate2;

	private SwigDelegateOdGiSpotLightTraits_3 swigDelegate3;

	private SwigDelegateOdGiSpotLightTraits_4 swigDelegate4;

	private SwigDelegateOdGiSpotLightTraits_5 swigDelegate5;

	private SwigDelegateOdGiSpotLightTraits_6 swigDelegate6;

	private SwigDelegateOdGiSpotLightTraits_7 swigDelegate7;

	private SwigDelegateOdGiSpotLightTraits_8 swigDelegate8;

	private SwigDelegateOdGiSpotLightTraits_9 swigDelegate9;

	private SwigDelegateOdGiSpotLightTraits_10 swigDelegate10;

	private SwigDelegateOdGiSpotLightTraits_11 swigDelegate11;

	private SwigDelegateOdGiSpotLightTraits_12 swigDelegate12;

	private SwigDelegateOdGiSpotLightTraits_13 swigDelegate13;

	private SwigDelegateOdGiSpotLightTraits_14 swigDelegate14;

	private SwigDelegateOdGiSpotLightTraits_15 swigDelegate15;

	private SwigDelegateOdGiSpotLightTraits_16 swigDelegate16;

	private SwigDelegateOdGiSpotLightTraits_17 swigDelegate17;

	private SwigDelegateOdGiSpotLightTraits_18 swigDelegate18;

	private SwigDelegateOdGiSpotLightTraits_19 swigDelegate19;

	private SwigDelegateOdGiSpotLightTraits_20 swigDelegate20;

	private SwigDelegateOdGiSpotLightTraits_21 swigDelegate21;

	private SwigDelegateOdGiSpotLightTraits_22 swigDelegate22;

	private SwigDelegateOdGiSpotLightTraits_23 swigDelegate23;

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

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdGiLightAttenuation) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdGiColorRGB) };

	private static Type[] swigMethodTypes23 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSpotLightTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSpotLightTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSpotLightTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiSpotLightTraits cast(OdRxObject pObj)
	{
		OdGiSpotLightTraits rXObject = Helpers.GetRXObject<OdGiSpotLightTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_isASwigExplicitOdGiSpotLightTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_queryXSwigExplicitOdGiSpotLightTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiSpotLightTraits createObject()
	{
		OdGiSpotLightTraits rXObject = Helpers.GetRXObject<OdGiSpotLightTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setPosition(OdGePoint3d pos)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_setPosition(swigCPtr, OdGePoint3d.getCPtr(pos));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint3d position()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_position(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTargetLocation(OdGePoint3d loc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_setTargetLocation(swigCPtr, OdGePoint3d.getCPtr(loc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint3d targetLocation()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_targetLocation(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setHotspotAndFalloff(double hotspot, double falloff)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_setHotspotAndFalloff(swigCPtr, hotspot, falloff);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double hotspot()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_hotspot(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double falloff()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_falloff(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiLightAttenuation lightAttenuation()
	{
		OdGiLightAttenuation result = new OdGiLightAttenuation(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_lightAttenuation(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAttenuation(OdGiLightAttenuation atten)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_setAttenuation(swigCPtr, OdGiLightAttenuation.getCPtr(atten));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPhysicalIntensity(double fIntensity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_setPhysicalIntensity(swigCPtr, fIntensity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double physicalIntensity()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_physicalIntensity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLampColor(OdGiColorRGB color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_setLampColor(swigCPtr, OdGiColorRGB.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiColorRGB lampColor()
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_lampColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiSpotLightTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSpotLightTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiSpotLightTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setPosition", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetPosition;
		}
		if (SwigDerivedClassHasMethod("position", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodposition;
		}
		if (SwigDerivedClassHasMethod("setTargetLocation", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetTargetLocation;
		}
		if (SwigDerivedClassHasMethod("targetLocation", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodtargetLocation;
		}
		if (SwigDerivedClassHasMethod("setHotspotAndFalloff", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetHotspotAndFalloff;
		}
		if (SwigDerivedClassHasMethod("hotspot", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodhotspot;
		}
		if (SwigDerivedClassHasMethod("falloff", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodfalloff;
		}
		if (SwigDerivedClassHasMethod("lightAttenuation", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodlightAttenuation;
		}
		if (SwigDerivedClassHasMethod("setAttenuation", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetAttenuation;
		}
		if (SwigDerivedClassHasMethod("setPhysicalIntensity", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsetPhysicalIntensity;
		}
		if (SwigDerivedClassHasMethod("physicalIntensity", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodphysicalIntensity;
		}
		if (SwigDerivedClassHasMethod("setLampColor", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodsetLampColor;
		}
		if (SwigDerivedClassHasMethod("lampColor", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodlampColor;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpotLightTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiSpotLightTraits));
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

	private void SwigDirectorMethodsetPosition(IntPtr pos)
	{
		try
		{
			setPosition(new OdGePoint3d(pos, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodposition()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(position()).Handle;
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

	private void SwigDirectorMethodsetTargetLocation(IntPtr loc)
	{
		try
		{
			setTargetLocation(new OdGePoint3d(loc, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodtargetLocation()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(targetLocation()).Handle;
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

	private bool SwigDirectorMethodsetHotspotAndFalloff(double hotspot, double falloff)
	{
		return setHotspotAndFalloff(hotspot, falloff);
	}

	private double SwigDirectorMethodhotspot()
	{
		return hotspot();
	}

	private double SwigDirectorMethodfalloff()
	{
		return falloff();
	}

	private IntPtr SwigDirectorMethodlightAttenuation()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiLightAttenuation.getCPtr(lightAttenuation()).Handle;
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

	private void SwigDirectorMethodsetAttenuation(IntPtr atten)
	{
		try
		{
			setAttenuation(new OdGiLightAttenuation(atten, cMemoryOwn: false));
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
}

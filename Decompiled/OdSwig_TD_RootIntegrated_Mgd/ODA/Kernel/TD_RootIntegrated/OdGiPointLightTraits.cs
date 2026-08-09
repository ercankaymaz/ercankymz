using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPointLightTraits : OdGiStandardLightTraits
{
	public delegate IntPtr SwigDelegateOdGiPointLightTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiPointLightTraits_1();

	public delegate void SwigDelegateOdGiPointLightTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiPointLightTraits_3(bool on);

	public delegate bool SwigDelegateOdGiPointLightTraits_4();

	public delegate void SwigDelegateOdGiPointLightTraits_5(double inten);

	public delegate double SwigDelegateOdGiPointLightTraits_6();

	public delegate void SwigDelegateOdGiPointLightTraits_7(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiPointLightTraits_8();

	public delegate void SwigDelegateOdGiPointLightTraits_9(IntPtr params_);

	public delegate IntPtr SwigDelegateOdGiPointLightTraits_10();

	public delegate void SwigDelegateOdGiPointLightTraits_11(IntPtr pos);

	public delegate IntPtr SwigDelegateOdGiPointLightTraits_12();

	public delegate IntPtr SwigDelegateOdGiPointLightTraits_13();

	public delegate void SwigDelegateOdGiPointLightTraits_14(IntPtr atten);

	public delegate void SwigDelegateOdGiPointLightTraits_15(double fIntensity);

	public delegate double SwigDelegateOdGiPointLightTraits_16();

	public delegate void SwigDelegateOdGiPointLightTraits_17(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiPointLightTraits_18();

	public delegate void SwigDelegateOdGiPointLightTraits_19(bool bTarget);

	public delegate bool SwigDelegateOdGiPointLightTraits_20();

	public delegate void SwigDelegateOdGiPointLightTraits_21(IntPtr loc);

	public delegate IntPtr SwigDelegateOdGiPointLightTraits_22();

	public delegate void SwigDelegateOdGiPointLightTraits_23(bool bHemisphere);

	public delegate bool SwigDelegateOdGiPointLightTraits_24();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiPointLightTraits_0 swigDelegate0;

	private SwigDelegateOdGiPointLightTraits_1 swigDelegate1;

	private SwigDelegateOdGiPointLightTraits_2 swigDelegate2;

	private SwigDelegateOdGiPointLightTraits_3 swigDelegate3;

	private SwigDelegateOdGiPointLightTraits_4 swigDelegate4;

	private SwigDelegateOdGiPointLightTraits_5 swigDelegate5;

	private SwigDelegateOdGiPointLightTraits_6 swigDelegate6;

	private SwigDelegateOdGiPointLightTraits_7 swigDelegate7;

	private SwigDelegateOdGiPointLightTraits_8 swigDelegate8;

	private SwigDelegateOdGiPointLightTraits_9 swigDelegate9;

	private SwigDelegateOdGiPointLightTraits_10 swigDelegate10;

	private SwigDelegateOdGiPointLightTraits_11 swigDelegate11;

	private SwigDelegateOdGiPointLightTraits_12 swigDelegate12;

	private SwigDelegateOdGiPointLightTraits_13 swigDelegate13;

	private SwigDelegateOdGiPointLightTraits_14 swigDelegate14;

	private SwigDelegateOdGiPointLightTraits_15 swigDelegate15;

	private SwigDelegateOdGiPointLightTraits_16 swigDelegate16;

	private SwigDelegateOdGiPointLightTraits_17 swigDelegate17;

	private SwigDelegateOdGiPointLightTraits_18 swigDelegate18;

	private SwigDelegateOdGiPointLightTraits_19 swigDelegate19;

	private SwigDelegateOdGiPointLightTraits_20 swigDelegate20;

	private SwigDelegateOdGiPointLightTraits_21 swigDelegate21;

	private SwigDelegateOdGiPointLightTraits_22 swigDelegate22;

	private SwigDelegateOdGiPointLightTraits_23 swigDelegate23;

	private SwigDelegateOdGiPointLightTraits_24 swigDelegate24;

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

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGiLightAttenuation) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGiColorRGB) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes24 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPointLightTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPointLightTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPointLightTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiPointLightTraits cast(OdRxObject pObj)
	{
		OdGiPointLightTraits rXObject = Helpers.GetRXObject<OdGiPointLightTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_isASwigExplicitOdGiPointLightTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_queryXSwigExplicitOdGiPointLightTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiPointLightTraits createObject()
	{
		OdGiPointLightTraits rXObject = Helpers.GetRXObject<OdGiPointLightTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setPosition(OdGePoint3d pos)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_setPosition(swigCPtr, OdGePoint3d.getCPtr(pos));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint3d position()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_position(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiLightAttenuation lightAttenuation()
	{
		OdGiLightAttenuation result = new OdGiLightAttenuation(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_lightAttenuation(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAttenuation(OdGiLightAttenuation atten)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_setAttenuation(swigCPtr, OdGiLightAttenuation.getCPtr(atten));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPhysicalIntensity(double fIntensity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_setPhysicalIntensity(swigCPtr, fIntensity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double physicalIntensity()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_physicalIntensity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLampColor(OdGiColorRGB color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_setLampColor(swigCPtr, OdGiColorRGB.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiColorRGB lampColor()
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_lampColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHasTarget(bool bTarget)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_setHasTarget(swigCPtr, bTarget);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hasTarget()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_hasTarget(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTargetLocation(OdGePoint3d loc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_setTargetLocation(swigCPtr, OdGePoint3d.getCPtr(loc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint3d targetLocation()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_targetLocation(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHemisphericalDistribution(bool bHemisphere)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_setHemisphericalDistribution(swigCPtr, bHemisphere);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hemisphericalDistribution()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_hemisphericalDistribution(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiPointLightTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPointLightTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiPointLightTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("lightAttenuation", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodlightAttenuation;
		}
		if (SwigDerivedClassHasMethod("setAttenuation", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetAttenuation;
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
		if (SwigDerivedClassHasMethod("setHasTarget", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetHasTarget;
		}
		if (SwigDerivedClassHasMethod("hasTarget", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodhasTarget;
		}
		if (SwigDerivedClassHasMethod("setTargetLocation", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetTargetLocation;
		}
		if (SwigDerivedClassHasMethod("targetLocation", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodtargetLocation;
		}
		if (SwigDerivedClassHasMethod("setHemisphericalDistribution", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodsetHemisphericalDistribution;
		}
		if (SwigDerivedClassHasMethod("hemisphericalDistribution", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodhemisphericalDistribution;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointLightTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPointLightTraits));
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

	private void SwigDirectorMethodsetHasTarget(bool bTarget)
	{
		try
		{
			setHasTarget(bTarget);
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

	private bool SwigDirectorMethodhasTarget()
	{
		return hasTarget();
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

	private void SwigDirectorMethodsetHemisphericalDistribution(bool bHemisphere)
	{
		try
		{
			setHemisphericalDistribution(bHemisphere);
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

	private bool SwigDirectorMethodhemisphericalDistribution()
	{
		return hemisphericalDistribution();
	}
}

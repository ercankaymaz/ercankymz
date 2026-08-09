using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDisplayStyle : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiDisplayStyle_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiDisplayStyle_1();

	public delegate void SwigDelegateOdGiDisplayStyle_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiDisplayStyle_3(uint nSettings);

	public delegate void SwigDelegateOdGiDisplayStyle_4(int flag, bool bEnable);

	public delegate uint SwigDelegateOdGiDisplayStyle_5();

	public delegate bool SwigDelegateOdGiDisplayStyle_6(int flag);

	public delegate void SwigDelegateOdGiDisplayStyle_7(double value);

	public delegate double SwigDelegateOdGiDisplayStyle_8();

	public delegate void SwigDelegateOdGiDisplayStyle_9(int type);

	public delegate int SwigDelegateOdGiDisplayStyle_10();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiDisplayStyle_0 swigDelegate0;

	private SwigDelegateOdGiDisplayStyle_1 swigDelegate1;

	private SwigDelegateOdGiDisplayStyle_2 swigDelegate2;

	private SwigDelegateOdGiDisplayStyle_3 swigDelegate3;

	private SwigDelegateOdGiDisplayStyle_4 swigDelegate4;

	private SwigDelegateOdGiDisplayStyle_5 swigDelegate5;

	private SwigDelegateOdGiDisplayStyle_6 swigDelegate6;

	private SwigDelegateOdGiDisplayStyle_7 swigDelegate7;

	private SwigDelegateOdGiDisplayStyle_8 swigDelegate8;

	private SwigDelegateOdGiDisplayStyle_9 swigDelegate9;

	private SwigDelegateOdGiDisplayStyle_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGiDisplayStyle_DisplaySettings),
		typeof(bool)
	};

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGiDisplayStyle_DisplaySettings) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGiDisplayStyle_ShadowType) };

	private static Type[] swigMethodTypes10 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDisplayStyle(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDisplayStyle obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDisplayStyle(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiDisplayStyle cast(OdRxObject pObj)
	{
		OdGiDisplayStyle rXObject = Helpers.GetRXObject<OdGiDisplayStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_isASwigExplicitOdGiDisplayStyle(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_queryXSwigExplicitOdGiDisplayStyle(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiDisplayStyle createObject()
	{
		OdGiDisplayStyle rXObject = Helpers.GetRXObject<OdGiDisplayStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void set(OdGiDisplayStyle style)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_set(swigCPtr, getCPtr(style));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDisplayStyle Assign(OdGiDisplayStyle style)
	{
		OdGiDisplayStyle rXObject = Helpers.GetRXObject<OdGiDisplayStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_Assign(swigCPtr, getCPtr(style)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool IsEqual(OdGiDisplayStyle style)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_IsEqual(swigCPtr, getCPtr(style));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDisplaySettings(uint nSettings)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_setDisplaySettings(swigCPtr, nSettings);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDisplaySettingsFlag(OdGiDisplayStyle_DisplaySettings flag, bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_setDisplaySettingsFlag(swigCPtr, (int)flag, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint displaySettings()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_displaySettings(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isDisplaySettingsFlagSet(OdGiDisplayStyle_DisplaySettings flag)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_isDisplaySettingsFlagSet(swigCPtr, (int)flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBrightness(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_setBrightness(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double brightness()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_brightness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setShadowType(OdGiDisplayStyle_ShadowType type)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_setShadowType(swigCPtr, (int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiDisplayStyle_ShadowType shadowType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_shadowType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiDisplayStyle_ShadowType)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiDisplayStyle()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDisplayStyle(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiDisplayStyle) != GetType();
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
		if (SwigDerivedClassHasMethod("setDisplaySettings", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetDisplaySettings;
		}
		if (SwigDerivedClassHasMethod("setDisplaySettingsFlag", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetDisplaySettingsFlag;
		}
		if (SwigDerivedClassHasMethod("displaySettings", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoddisplaySettings;
		}
		if (SwigDerivedClassHasMethod("isDisplaySettingsFlagSet", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodisDisplaySettingsFlagSet;
		}
		if (SwigDerivedClassHasMethod("setBrightness", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetBrightness;
		}
		if (SwigDerivedClassHasMethod("brightness", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodbrightness;
		}
		if (SwigDerivedClassHasMethod("setShadowType", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetShadowType;
		}
		if (SwigDerivedClassHasMethod("shadowType", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodshadowType;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDisplayStyle_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiDisplayStyle));
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

	private void SwigDirectorMethodsetDisplaySettings(uint nSettings)
	{
		try
		{
			setDisplaySettings(nSettings);
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

	private void SwigDirectorMethodsetDisplaySettingsFlag(int flag, bool bEnable)
	{
		try
		{
			setDisplaySettingsFlag((OdGiDisplayStyle_DisplaySettings)flag, bEnable);
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

	private uint SwigDirectorMethoddisplaySettings()
	{
		return displaySettings();
	}

	private bool SwigDirectorMethodisDisplaySettingsFlagSet(int flag)
	{
		return isDisplaySettingsFlagSet((OdGiDisplayStyle_DisplaySettings)flag);
	}

	private void SwigDirectorMethodsetBrightness(double value)
	{
		try
		{
			setBrightness(value);
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

	private double SwigDirectorMethodbrightness()
	{
		return brightness();
	}

	private void SwigDirectorMethodsetShadowType(int type)
	{
		try
		{
			setShadowType((OdGiDisplayStyle_ShadowType)type);
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

	private int SwigDirectorMethodshadowType()
	{
		return (int)shadowType();
	}
}

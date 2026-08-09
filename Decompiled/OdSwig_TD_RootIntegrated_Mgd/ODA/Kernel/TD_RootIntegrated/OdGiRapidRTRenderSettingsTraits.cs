using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRapidRTRenderSettingsTraits : OdGiRenderSettingsTraits
{
	public delegate IntPtr SwigDelegateOdGiRapidRTRenderSettingsTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiRapidRTRenderSettingsTraits_1();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_3(bool enabled);

	public delegate bool SwigDelegateOdGiRapidRTRenderSettingsTraits_4();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_5(bool enabled);

	public delegate bool SwigDelegateOdGiRapidRTRenderSettingsTraits_6();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_7(bool enabled);

	public delegate bool SwigDelegateOdGiRapidRTRenderSettingsTraits_8();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_9(bool enabled);

	public delegate bool SwigDelegateOdGiRapidRTRenderSettingsTraits_10();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_11(bool enabled);

	public delegate bool SwigDelegateOdGiRapidRTRenderSettingsTraits_12();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_13(double scaleFactor);

	public delegate double SwigDelegateOdGiRapidRTRenderSettingsTraits_14();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_15(int condition);

	public delegate int SwigDelegateOdGiRapidRTRenderSettingsTraits_16();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_17(int level);

	public delegate int SwigDelegateOdGiRapidRTRenderSettingsTraits_18();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_19(int time);

	public delegate int SwigDelegateOdGiRapidRTRenderSettingsTraits_20();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_21(int mode);

	public delegate int SwigDelegateOdGiRapidRTRenderSettingsTraits_22();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_23(int type);

	public delegate int SwigDelegateOdGiRapidRTRenderSettingsTraits_24();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_25(float width);

	public delegate float SwigDelegateOdGiRapidRTRenderSettingsTraits_26();

	public delegate void SwigDelegateOdGiRapidRTRenderSettingsTraits_27(float height);

	public delegate float SwigDelegateOdGiRapidRTRenderSettingsTraits_28();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_0 swigDelegate0;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_1 swigDelegate1;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_2 swigDelegate2;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_3 swigDelegate3;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_4 swigDelegate4;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_5 swigDelegate5;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_6 swigDelegate6;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_7 swigDelegate7;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_8 swigDelegate8;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_9 swigDelegate9;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_10 swigDelegate10;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_11 swigDelegate11;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_12 swigDelegate12;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_13 swigDelegate13;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_14 swigDelegate14;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_15 swigDelegate15;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_16 swigDelegate16;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_17 swigDelegate17;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_18 swigDelegate18;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_19 swigDelegate19;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_20 swigDelegate20;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_21 swigDelegate21;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_22 swigDelegate22;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_23 swigDelegate23;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_24 swigDelegate24;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_25 swigDelegate25;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_26 swigDelegate26;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_27 swigDelegate27;

	private SwigDelegateOdGiRapidRTRenderSettingsTraits_28 swigDelegate28;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdGiQuitCondition_) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGiLightingMode_) };

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(OdGiFilterType_) };

	private static Type[] swigMethodTypes24 = new Type[0];

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(float) };

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(float) };

	private static Type[] swigMethodTypes28 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiRapidRTRenderSettingsTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRapidRTRenderSettingsTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRapidRTRenderSettingsTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiRapidRTRenderSettingsTraits cast(OdRxObject pObj)
	{
		OdGiRapidRTRenderSettingsTraits rXObject = Helpers.GetRXObject<OdGiRapidRTRenderSettingsTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_isASwigExplicitOdGiRapidRTRenderSettingsTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_queryXSwigExplicitOdGiRapidRTRenderSettingsTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiRapidRTRenderSettingsTraits createObject()
	{
		OdGiRapidRTRenderSettingsTraits rXObject = Helpers.GetRXObject<OdGiRapidRTRenderSettingsTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setQuitCondition(OdGiQuitCondition_ condition)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_setQuitCondition(swigCPtr, (int)condition);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiQuitCondition_ quitCondition()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_quitCondition(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiQuitCondition_)result;
	}

	public virtual void setDesiredRenderLevel(int level)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_setDesiredRenderLevel(swigCPtr, level);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int desiredRenderLevel()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_desiredRenderLevel(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDesiredRenderTime(int time)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_setDesiredRenderTime(swigCPtr, time);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int desiredRenderTime()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_desiredRenderTime(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLightingMode(OdGiLightingMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_setLightingMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiLightingMode_ lightingMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_lightingMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiLightingMode_)result;
	}

	public virtual void setFilterType(OdGiFilterType_ type)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_setFilterType(swigCPtr, (int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiFilterType_ filterType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_filterType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFilterType_)result;
	}

	public virtual void setFilterWidth(float width)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_setFilterWidth(swigCPtr, width);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual float filterWidth()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_filterWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFilterHeight(float height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_setFilterHeight(swigCPtr, height);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual float filterHeight()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_filterHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiRapidRTRenderSettingsTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRapidRTRenderSettingsTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiRapidRTRenderSettingsTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setMaterialEnabled", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetMaterialEnabled;
		}
		if (SwigDerivedClassHasMethod("materialEnabled", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodmaterialEnabled;
		}
		if (SwigDerivedClassHasMethod("setTextureSampling", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetTextureSampling;
		}
		if (SwigDerivedClassHasMethod("textureSampling", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodtextureSampling;
		}
		if (SwigDerivedClassHasMethod("setBackFacesEnabled", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetBackFacesEnabled;
		}
		if (SwigDerivedClassHasMethod("backFacesEnabled", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodbackFacesEnabled;
		}
		if (SwigDerivedClassHasMethod("setShadowsEnabled", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetShadowsEnabled;
		}
		if (SwigDerivedClassHasMethod("shadowsEnabled", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodshadowsEnabled;
		}
		if (SwigDerivedClassHasMethod("setDiagnosticBackgroundEnabled", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetDiagnosticBackgroundEnabled;
		}
		if (SwigDerivedClassHasMethod("diagnosticBackgroundEnabled", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethoddiagnosticBackgroundEnabled;
		}
		if (SwigDerivedClassHasMethod("setModelScaleFactor", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetModelScaleFactor;
		}
		if (SwigDerivedClassHasMethod("modelScaleFactor", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodmodelScaleFactor;
		}
		if (SwigDerivedClassHasMethod("setQuitCondition", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetQuitCondition;
		}
		if (SwigDerivedClassHasMethod("quitCondition", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodquitCondition;
		}
		if (SwigDerivedClassHasMethod("setDesiredRenderLevel", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetDesiredRenderLevel;
		}
		if (SwigDerivedClassHasMethod("desiredRenderLevel", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethoddesiredRenderLevel;
		}
		if (SwigDerivedClassHasMethod("setDesiredRenderTime", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetDesiredRenderTime;
		}
		if (SwigDerivedClassHasMethod("desiredRenderTime", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethoddesiredRenderTime;
		}
		if (SwigDerivedClassHasMethod("setLightingMode", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetLightingMode;
		}
		if (SwigDerivedClassHasMethod("lightingMode", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodlightingMode;
		}
		if (SwigDerivedClassHasMethod("setFilterType", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodsetFilterType;
		}
		if (SwigDerivedClassHasMethod("filterType", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodfilterType;
		}
		if (SwigDerivedClassHasMethod("setFilterWidth", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetFilterWidth;
		}
		if (SwigDerivedClassHasMethod("filterWidth", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodfilterWidth;
		}
		if (SwigDerivedClassHasMethod("setFilterHeight", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodsetFilterHeight;
		}
		if (SwigDerivedClassHasMethod("filterHeight", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodfilterHeight;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRapidRTRenderSettingsTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiRapidRTRenderSettingsTraits));
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

	private void SwigDirectorMethodsetMaterialEnabled(bool enabled)
	{
		try
		{
			setMaterialEnabled(enabled);
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

	private bool SwigDirectorMethodmaterialEnabled()
	{
		return materialEnabled();
	}

	private void SwigDirectorMethodsetTextureSampling(bool enabled)
	{
		try
		{
			setTextureSampling(enabled);
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

	private bool SwigDirectorMethodtextureSampling()
	{
		return textureSampling();
	}

	private void SwigDirectorMethodsetBackFacesEnabled(bool enabled)
	{
		try
		{
			setBackFacesEnabled(enabled);
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

	private bool SwigDirectorMethodbackFacesEnabled()
	{
		return backFacesEnabled();
	}

	private void SwigDirectorMethodsetShadowsEnabled(bool enabled)
	{
		try
		{
			setShadowsEnabled(enabled);
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

	private bool SwigDirectorMethodshadowsEnabled()
	{
		return shadowsEnabled();
	}

	private void SwigDirectorMethodsetDiagnosticBackgroundEnabled(bool enabled)
	{
		try
		{
			setDiagnosticBackgroundEnabled(enabled);
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

	private bool SwigDirectorMethoddiagnosticBackgroundEnabled()
	{
		return diagnosticBackgroundEnabled();
	}

	private void SwigDirectorMethodsetModelScaleFactor(double scaleFactor)
	{
		try
		{
			setModelScaleFactor(scaleFactor);
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

	private double SwigDirectorMethodmodelScaleFactor()
	{
		return modelScaleFactor();
	}

	private void SwigDirectorMethodsetQuitCondition(int condition)
	{
		try
		{
			setQuitCondition((OdGiQuitCondition_)condition);
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

	private int SwigDirectorMethodquitCondition()
	{
		return (int)quitCondition();
	}

	private void SwigDirectorMethodsetDesiredRenderLevel(int level)
	{
		try
		{
			setDesiredRenderLevel(level);
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

	private int SwigDirectorMethoddesiredRenderLevel()
	{
		return desiredRenderLevel();
	}

	private void SwigDirectorMethodsetDesiredRenderTime(int time)
	{
		try
		{
			setDesiredRenderTime(time);
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

	private int SwigDirectorMethoddesiredRenderTime()
	{
		return desiredRenderTime();
	}

	private void SwigDirectorMethodsetLightingMode(int mode)
	{
		try
		{
			setLightingMode((OdGiLightingMode_)mode);
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

	private int SwigDirectorMethodlightingMode()
	{
		return (int)lightingMode();
	}

	private void SwigDirectorMethodsetFilterType(int type)
	{
		try
		{
			setFilterType((OdGiFilterType_)type);
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

	private int SwigDirectorMethodfilterType()
	{
		return (int)filterType();
	}

	private void SwigDirectorMethodsetFilterWidth(float width)
	{
		try
		{
			setFilterWidth(width);
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

	private float SwigDirectorMethodfilterWidth()
	{
		return filterWidth();
	}

	private void SwigDirectorMethodsetFilterHeight(float height)
	{
		try
		{
			setFilterHeight(height);
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

	private float SwigDirectorMethodfilterHeight()
	{
		return filterHeight();
	}
}

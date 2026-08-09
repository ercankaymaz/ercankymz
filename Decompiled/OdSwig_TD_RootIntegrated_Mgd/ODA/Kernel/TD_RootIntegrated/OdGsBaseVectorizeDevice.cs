using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBaseVectorizeDevice : OdGsDevice
{
	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_1();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_3();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_4();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_5(IntPtr pUserGiContext);

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_6();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_7(IntPtr screenRect);

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_8();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_9(IntPtr pUpdatedRect);

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_10();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_11(IntPtr outputRect);

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_12(IntPtr outputRect);

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_13(IntPtr outputRect);

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_14(IntPtr outputRect);

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_15();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_16();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_17(int bitsPerPixel, int xPixels, int yPixels);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_18(IntPtr pViewInfo, bool enableLayerVisibilityPerView);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_19(IntPtr pViewInfo);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_20();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_21(IntPtr pView);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_22();

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_23(IntPtr pModel);

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_24(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_25(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_26();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_27(int viewIndex, IntPtr pView);

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_28(IntPtr pView);

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_29(int viewIndex);

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_30();

	public delegate int SwigDelegateOdGsBaseVectorizeDevice_31();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_32(int viewIndex);

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_33(uint backgroundColor);

	public delegate uint SwigDelegateOdGsBaseVectorizeDevice_34();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_35(IntPtr logicalPalette, int numColors);

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_36(IntPtr pImage, IntPtr region);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_37(bool createIfNotExist);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_38();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_39(IntPtr pManager);

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_40(int nOverlay);

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_41(int nOverlay);

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_42();

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_43();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_44(uint nOverlays);

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_45(uint nOverlays, IntPtr screenRect);

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_46();

	public delegate void SwigDelegateOdGsBaseVectorizeDevice_47();

	public delegate uint SwigDelegateOdGsBaseVectorizeDevice_48(int renderType);

	public delegate int SwigDelegateOdGsBaseVectorizeDevice_49(int renderType);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeDevice_50();

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_51();

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_52(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_53(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_54(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_55(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseVectorizeDevice_56();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsBaseVectorizeDevice_0 swigDelegate0;

	private SwigDelegateOdGsBaseVectorizeDevice_1 swigDelegate1;

	private SwigDelegateOdGsBaseVectorizeDevice_2 swigDelegate2;

	private SwigDelegateOdGsBaseVectorizeDevice_3 swigDelegate3;

	private SwigDelegateOdGsBaseVectorizeDevice_4 swigDelegate4;

	private SwigDelegateOdGsBaseVectorizeDevice_5 swigDelegate5;

	private SwigDelegateOdGsBaseVectorizeDevice_6 swigDelegate6;

	private SwigDelegateOdGsBaseVectorizeDevice_7 swigDelegate7;

	private SwigDelegateOdGsBaseVectorizeDevice_8 swigDelegate8;

	private SwigDelegateOdGsBaseVectorizeDevice_9 swigDelegate9;

	private SwigDelegateOdGsBaseVectorizeDevice_10 swigDelegate10;

	private SwigDelegateOdGsBaseVectorizeDevice_11 swigDelegate11;

	private SwigDelegateOdGsBaseVectorizeDevice_12 swigDelegate12;

	private SwigDelegateOdGsBaseVectorizeDevice_13 swigDelegate13;

	private SwigDelegateOdGsBaseVectorizeDevice_14 swigDelegate14;

	private SwigDelegateOdGsBaseVectorizeDevice_15 swigDelegate15;

	private SwigDelegateOdGsBaseVectorizeDevice_16 swigDelegate16;

	private SwigDelegateOdGsBaseVectorizeDevice_17 swigDelegate17;

	private SwigDelegateOdGsBaseVectorizeDevice_18 swigDelegate18;

	private SwigDelegateOdGsBaseVectorizeDevice_19 swigDelegate19;

	private SwigDelegateOdGsBaseVectorizeDevice_20 swigDelegate20;

	private SwigDelegateOdGsBaseVectorizeDevice_21 swigDelegate21;

	private SwigDelegateOdGsBaseVectorizeDevice_22 swigDelegate22;

	private SwigDelegateOdGsBaseVectorizeDevice_23 swigDelegate23;

	private SwigDelegateOdGsBaseVectorizeDevice_24 swigDelegate24;

	private SwigDelegateOdGsBaseVectorizeDevice_25 swigDelegate25;

	private SwigDelegateOdGsBaseVectorizeDevice_26 swigDelegate26;

	private SwigDelegateOdGsBaseVectorizeDevice_27 swigDelegate27;

	private SwigDelegateOdGsBaseVectorizeDevice_28 swigDelegate28;

	private SwigDelegateOdGsBaseVectorizeDevice_29 swigDelegate29;

	private SwigDelegateOdGsBaseVectorizeDevice_30 swigDelegate30;

	private SwigDelegateOdGsBaseVectorizeDevice_31 swigDelegate31;

	private SwigDelegateOdGsBaseVectorizeDevice_32 swigDelegate32;

	private SwigDelegateOdGsBaseVectorizeDevice_33 swigDelegate33;

	private SwigDelegateOdGsBaseVectorizeDevice_34 swigDelegate34;

	private SwigDelegateOdGsBaseVectorizeDevice_35 swigDelegate35;

	private SwigDelegateOdGsBaseVectorizeDevice_36 swigDelegate36;

	private SwigDelegateOdGsBaseVectorizeDevice_37 swigDelegate37;

	private SwigDelegateOdGsBaseVectorizeDevice_38 swigDelegate38;

	private SwigDelegateOdGsBaseVectorizeDevice_39 swigDelegate39;

	private SwigDelegateOdGsBaseVectorizeDevice_40 swigDelegate40;

	private SwigDelegateOdGsBaseVectorizeDevice_41 swigDelegate41;

	private SwigDelegateOdGsBaseVectorizeDevice_42 swigDelegate42;

	private SwigDelegateOdGsBaseVectorizeDevice_43 swigDelegate43;

	private SwigDelegateOdGsBaseVectorizeDevice_44 swigDelegate44;

	private SwigDelegateOdGsBaseVectorizeDevice_45 swigDelegate45;

	private SwigDelegateOdGsBaseVectorizeDevice_46 swigDelegate46;

	private SwigDelegateOdGsBaseVectorizeDevice_47 swigDelegate47;

	private SwigDelegateOdGsBaseVectorizeDevice_48 swigDelegate48;

	private SwigDelegateOdGsBaseVectorizeDevice_49 swigDelegate49;

	private SwigDelegateOdGsBaseVectorizeDevice_50 swigDelegate50;

	private SwigDelegateOdGsBaseVectorizeDevice_51 swigDelegate51;

	private SwigDelegateOdGsBaseVectorizeDevice_52 swigDelegate52;

	private SwigDelegateOdGsBaseVectorizeDevice_53 swigDelegate53;

	private SwigDelegateOdGsBaseVectorizeDevice_54 swigDelegate54;

	private SwigDelegateOdGsBaseVectorizeDevice_55 swigDelegate55;

	private SwigDelegateOdGsBaseVectorizeDevice_56 swigDelegate56;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGiContext) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdGsDCRectDouble) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGsDCRectDouble) };

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes18 = new Type[2]
	{
		typeof(OdGsClientViewInfo),
		typeof(bool)
	};

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdGsClientViewInfo) };

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(OdGsModel) };

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[2]
	{
		typeof(int),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes30 = new Type[0];

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[2]
	{
		typeof(uint[]),
		typeof(int)
	};

	private static Type[] swigMethodTypes36 = new Type[2]
	{
		typeof(OdGiRasterImage).MakeByRefType(),
		typeof(OdGsDCRect)
	};

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes38 = new Type[0];

	private static Type[] swigMethodTypes39 = new Type[1] { typeof(OdGsUpdateManager) };

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(OdGsOverlayId) };

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(OdGsOverlayId) };

	private static Type[] swigMethodTypes42 = new Type[0];

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes45 = new Type[2]
	{
		typeof(uint),
		typeof(OdGsDCRect)
	};

	private static Type[] swigMethodTypes46 = new Type[0];

	private static Type[] swigMethodTypes47 = new Type[0];

	private static Type[] swigMethodTypes48 = new Type[1] { typeof(OdGsModel_RenderType) };

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(OdGsModel_RenderType) };

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[0];

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes54 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes56 = new Type[0];

	public GsVectPerformanceData m_vectPerfData
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_m_vectPerfData_get(swigCPtr);
			GsVectPerformanceData result = ((intPtr == IntPtr.Zero) ? null : new GsVectPerformanceData(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_m_vectPerfData_set(swigCPtr, GsVectPerformanceData.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBaseVectorizeDevice(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBaseVectorizeDevice obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsBaseVectorizeDevice()
	{
		Dispose(disposing: false);
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected new virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseVectorizeDevice(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsBaseVectorizeDevice()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBaseVectorizeDevice(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	protected virtual void onOverlayActivated(OdGsOverlayId nOverlay)
	{
		if (SwigDerivedClassHasMethod("onOverlayActivated", swigMethodTypes40))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onOverlayActivatedSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, (int)nOverlay);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onOverlayActivated(swigCPtr, (int)nOverlay);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void onOverlayDeactivated(OdGsOverlayId nOverlay)
	{
		if (SwigDerivedClassHasMethod("onOverlayDeactivated", swigMethodTypes41))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onOverlayDeactivatedSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, (int)nOverlay);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onOverlayDeactivated(swigCPtr, (int)nOverlay);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool invalid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setInvalid(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setInvalid(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setValid(bool bFlag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setValid(swigCPtr, bFlag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool supportPartialUpdate()
	{
		bool result = (SwigDerivedClassHasMethod("supportPartialUpdate", swigMethodTypes42) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportPartialUpdateSwigExplicitOdGsBaseVectorizeDevice(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportPartialUpdate(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool supportPartialScreenUpdate()
	{
		bool result = (SwigDerivedClassHasMethod("supportPartialScreenUpdate", swigMethodTypes43) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportPartialScreenUpdateSwigExplicitOdGsBaseVectorizeDevice(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportPartialScreenUpdate(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void onViewAdded(OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onViewAdded(swigCPtr, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new static OdGsBaseVectorizeDevice cast(OdRxObject pObj)
	{
		OdGsBaseVectorizeDevice rXObject = Helpers.GetRXObject<OdGsBaseVectorizeDevice>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isASwigExplicitOdGsBaseVectorizeDevice(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_queryXSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGiContext userGiContext()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(SwigDerivedClassHasMethod("userGiContext", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_userGiContextSwigExplicitOdGsBaseVectorizeDevice(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_userGiContext(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void setUserGiContext(OdGiContext pUserGiContext)
	{
		if (SwigDerivedClassHasMethod("setUserGiContext", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setUserGiContextSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGiContext.getCPtr(pUserGiContext));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setUserGiContext(swigCPtr, OdGiContext.getCPtr(pUserGiContext));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdRxDictionary properties()
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(SwigDerivedClassHasMethod("properties", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_propertiesSwigExplicitOdGsBaseVectorizeDevice(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_properties(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public int height()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_height(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int width()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_width(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int hOffset()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_hOffset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int vOffset()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_vOffset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void invalidate()
	{
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidateSwigExplicitOdGsBaseVectorizeDevice__SWIG_0(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidate__SWIG_0(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void invalidate(OdGsDCRect screenRect)
	{
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidateSwigExplicitOdGsBaseVectorizeDevice__SWIG_1(swigCPtr, OdGsDCRect.getCPtr(screenRect));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidate__SWIG_1(swigCPtr, OdGsDCRect.getCPtr(screenRect));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidate(uint nOverlays)
	{
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes44))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidateSwigExplicitOdGsBaseVectorizeDevice__SWIG_2(swigCPtr, nOverlays);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidate__SWIG_2(swigCPtr, nOverlays);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidate(uint nOverlays, OdGsDCRect screenRect)
	{
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes45))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidateSwigExplicitOdGsBaseVectorizeDevice__SWIG_3(swigCPtr, nOverlays, OdGsDCRect.getCPtr(screenRect));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidate__SWIG_3(swigCPtr, nOverlays, OdGsDCRect.getCPtr(screenRect));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void invalidate(OdGsViewImpl pView, OdGsDCRect screenRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidate__SWIG_4(swigCPtr, OdGsViewImpl.getCPtr(pView), OdGsDCRect.getCPtr(screenRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void invalidate(OdGsModel pModel, OdGsDCRect screenRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidate__SWIG_5(swigCPtr, OdGsModel.getCPtr(pModel), OdGsDCRect.getCPtr(screenRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void invalidateRegion(OdGiPathNode path)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidateRegion(swigCPtr, OdGiPathNode.getCPtr(path));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCRectArray invalidRects()
	{
		OdGsDCRectArray result = new OdGsDCRectArray(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidRects__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsDCRectArray invalidRects(OdGsOverlayId overlayId)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_invalidRects__SWIG_1(swigCPtr, (int)overlayId);
		OdGsDCRectArray result = ((intPtr == IntPtr.Zero) ? null : new OdGsDCRectArray(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isValid()
	{
		bool result = (SwigDerivedClassHasMethod("isValid", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isValidSwigExplicitOdGsBaseVectorizeDevice(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isValid(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void update(OdGsDCRect pUpdatedRect)
	{
		if (SwigDerivedClassHasMethod("update", swigMethodTypes9))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_updateSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsDCRect.getCPtr(pUpdatedRect));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_update(swigCPtr, OdGsDCRect.getCPtr(pUpdatedRect));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void updateGeometry()
	{
		if (SwigDerivedClassHasMethod("updateGeometry", swigMethodTypes46))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_updateGeometrySwigExplicitOdGsBaseVectorizeDevice(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_updateGeometry(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void updateScreen()
	{
		if (SwigDerivedClassHasMethod("updateScreen", swigMethodTypes47))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_updateScreenSwigExplicitOdGsBaseVectorizeDevice(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_updateScreen(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void onSize(OdGsDCRect outputRect)
	{
		if (SwigDerivedClassHasMethod("onSize", swigMethodTypes11))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onSizeSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsDCRect.getCPtr(outputRect));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onSize(swigCPtr, OdGsDCRect.getCPtr(outputRect));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCRect outputRect()
	{
		OdGsDCRect result = new OdGsDCRect(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_outputRect(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void getSize(OdGsDCRect outputRect)
	{
		if (SwigDerivedClassHasMethod("getSize", swigMethodTypes13))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getSizeSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsDCRect.getCPtr(outputRect));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getSize(swigCPtr, OdGsDCRect.getCPtr(outputRect));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void onRealizeForegroundPalette()
	{
		if (SwigDerivedClassHasMethod("onRealizeForegroundPalette", swigMethodTypes15))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onRealizeForegroundPaletteSwigExplicitOdGsBaseVectorizeDevice(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onRealizeForegroundPalette(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void onRealizeBackgroundPalette()
	{
		if (SwigDerivedClassHasMethod("onRealizeBackgroundPalette", swigMethodTypes16))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onRealizeBackgroundPaletteSwigExplicitOdGsBaseVectorizeDevice(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onRealizeBackgroundPalette(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void onDisplayChange(int bitsPerPixel, int xPixels, int yPixels)
	{
		if (SwigDerivedClassHasMethod("onDisplayChange", swigMethodTypes17))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onDisplayChangeSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, bitsPerPixel, xPixels, yPixels);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_onDisplayChange(swigCPtr, bitsPerPixel, xPixels, yPixels);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsView createView(OdGsClientViewInfo pViewInfo, bool enableLayerVisibilityPerView)
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(SwigDerivedClassHasMethod("createView", swigMethodTypes18) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_createViewSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsClientViewInfo.getCPtr(pViewInfo), enableLayerVisibilityPerView) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_createView(swigCPtr, OdGsClientViewInfo.getCPtr(pViewInfo), enableLayerVisibilityPerView), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void addView(OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("addView", swigMethodTypes21))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_addViewSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_addView(swigCPtr, OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void insertView(int viewIndex, OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("insertView", swigMethodTypes27))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_insertViewSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, viewIndex, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_insertView(swigCPtr, viewIndex, OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool eraseView(OdGsView pView)
	{
		bool result = (SwigDerivedClassHasMethod("eraseView", swigMethodTypes28) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_eraseViewSwigExplicitOdGsBaseVectorizeDevice__SWIG_0(swigCPtr, OdGsView.getCPtr(pView)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_eraseView__SWIG_0(swigCPtr, OdGsView.getCPtr(pView)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override int numViews()
	{
		int result = (SwigDerivedClassHasMethod("numViews", swigMethodTypes31) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_numViewsSwigExplicitOdGsBaseVectorizeDevice(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_numViews(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGsView viewAt(int viewIndex)
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(SwigDerivedClassHasMethod("viewAt", swigMethodTypes32) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_viewAtSwigExplicitOdGsBaseVectorizeDevice__SWIG_0(swigCPtr, viewIndex) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_viewAt__SWIG_0(swigCPtr, viewIndex), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsViewImpl viewImplAt(int viewIndex)
	{
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_viewImplAt__SWIG_0(swigCPtr, viewIndex), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override bool eraseView(int viewIndex)
	{
		bool result = (SwigDerivedClassHasMethod("eraseView", swigMethodTypes29) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_eraseViewSwigExplicitOdGsBaseVectorizeDevice__SWIG_1(swigCPtr, viewIndex) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_eraseView__SWIG_1(swigCPtr, viewIndex));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void eraseAllViews()
	{
		if (SwigDerivedClassHasMethod("eraseAllViews", swigMethodTypes30))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_eraseAllViewsSwigExplicitOdGsBaseVectorizeDevice(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_eraseAllViews(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool setBackgroundColor(uint backgroundColor)
	{
		bool result = (SwigDerivedClassHasMethod("setBackgroundColor", swigMethodTypes33) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setBackgroundColorSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, backgroundColor) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setBackgroundColor(swigCPtr, backgroundColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint getBackgroundColor()
	{
		uint result = (SwigDerivedClassHasMethod("getBackgroundColor", swigMethodTypes34) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getBackgroundColorSwigExplicitOdGsBaseVectorizeDevice(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getBackgroundColor(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setLogicalPalette(uint[] logicalPalette, int numColors)
	{
		if (SwigDerivedClassHasMethod("setLogicalPalette", swigMethodTypes35))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setLogicalPaletteSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, logicalPalette, numColors);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setLogicalPalette(swigCPtr, logicalPalette, numColors);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void getSnapShot(ref OdGiRasterImage pImage, OdGsDCRect region)
	{
		IntPtr jarg = ((pImage == null) ? IntPtr.Zero : OdGiRasterImage.getCPtr(pImage).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("getSnapShot", swigMethodTypes36))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getSnapShotSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, ref jarg, OdGsDCRect.getCPtr(region));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getSnapShot(swigCPtr, ref jarg, OdGsDCRect.getCPtr(region));
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pImage = null;
			}
			else if (jarg != intPtr)
			{
				pImage = Helpers.GetRXObject<OdGiRasterImage>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public uint getColor(ushort colorIndex)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getColor(swigCPtr, colorIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint getPaletteBackground()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getPaletteBackground(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint[] getLogicalPalette(out int numColors)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getLogicalPalette(swigCPtr, out numColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int num = 257;
		int[] array = new int[num];
		Marshal.Copy(intPtr, array, 0, num);
		return Array.ConvertAll(array, (int in_value) => (uint)in_value);
	}

	public override OdGsModel createModel()
	{
		OdGsModel rXObject = Helpers.GetRXObject<OdGsModel>(SwigDerivedClassHasMethod("createModel", swigMethodTypes22) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_createModelSwigExplicitOdGsBaseVectorizeDevice(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_createModel(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override bool isModelCompatible(OdGsModel pModel)
	{
		bool result = (SwigDerivedClassHasMethod("isModelCompatible", swigMethodTypes23) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isModelCompatibleSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsModel.getCPtr(pModel)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isModelCompatible(swigCPtr, OdGsModel.getCPtr(pModel)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsView rootView()
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_rootView(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool sortRenderTypes()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_sortRenderTypes(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSortRenderTypes(bool flag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setSortRenderTypes(swigCPtr, flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint renderTypeWeight(OdGsModel_RenderType renderType)
	{
		uint result = (SwigDerivedClassHasMethod("renderTypeWeight", swigMethodTypes48) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_renderTypeWeightSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, (int)renderType) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_renderTypeWeight(swigCPtr, (int)renderType));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsModel_RenderType transientRenderType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_transientRenderType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsModel_RenderType)result;
	}

	public void setTransientRenderType(OdGsModel_RenderType renderType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setTransientRenderType(swigCPtr, (int)renderType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool supportOverlays()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportOverlays(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSupportOverlays(bool bFlag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setSupportOverlays(swigCPtr, bFlag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsOverlayId renderTypeOverlay(OdGsModel_RenderType renderType)
	{
		int result = (SwigDerivedClassHasMethod("renderTypeOverlay", swigMethodTypes49) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_renderTypeOverlaySwigExplicitOdGsBaseVectorizeDevice(swigCPtr, (int)renderType) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_renderTypeOverlay(swigCPtr, (int)renderType));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsOverlayId)result;
	}

	public OdGsOverlayId gsModelOverlay(OdGsModel pModel)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_gsModelOverlay(swigCPtr, OdGsModel.getCPtr(pModel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsOverlayId)result;
	}

	public int isOverlayRequireUpdate(OdGsOverlayId overlayId)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isOverlayRequireUpdate(swigCPtr, (int)overlayId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSpatialIndexDisabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isSpatialIndexDisabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void disableSpatialIndex(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_disableSpatialIndex(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isCullingVolumeEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isCullingVolumeEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableCullingVolume(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_enableCullingVolume(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool supportHighlightTwoPass()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportHighlightTwoPass(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSupportHighlightTwoPass(bool bOn)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setSupportHighlightTwoPass(swigCPtr, bOn);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isMtDisplay()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isMtDisplay(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool supportDynamicHighlight()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportDynamicHighlight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool supportDynamicSubhighlight()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportDynamicSubhighlight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool supportSelectionStyles()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportSelectionStyles(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool supportBlocks()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportBlocks(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool supportComposition()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportComposition(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool compositionEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_compositionEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableComposition(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_enableComposition(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDisplayOffLayersEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isDisplayOffLayersEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableDisplayOffLayers(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_enableDisplayOffLayers(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isValidViewportId(uint acgiId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isValidViewportId(swigCPtr, acgiId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool useVpLtypeScaleMult()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_useVpLtypeScaleMult(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool useVpFilterFunction()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_useVpFilterFunction(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiSectionGeometryManager getSectionGeometryManager()
	{
		OdGiSectionGeometryManager rXObject = Helpers.GetRXObject<OdGiSectionGeometryManager>(SwigDerivedClassHasMethod("getSectionGeometryManager", swigMethodTypes50) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getSectionGeometryManagerSwigExplicitOdGsBaseVectorizeDevice(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getSectionGeometryManager(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxObject getSectionGeometryMap()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getSectionGeometryMap(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void clearSectionGeometryMap()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_clearSectionGeometryMap(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxObject mtServices()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_mtServices(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiTransientManager transientManager()
	{
		OdGiTransientManager rXObject = Helpers.GetRXObject<OdGiTransientManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_transientManager(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setTransientManager(OdGiTransientManager pManager)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setTransientManager(swigCPtr, OdGiTransientManager.getCPtr(pManager));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isSupportDeviceStateSaving()
	{
		bool result = (SwigDerivedClassHasMethod("isSupportDeviceStateSaving", swigMethodTypes51) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isSupportDeviceStateSavingSwigExplicitOdGsBaseVectorizeDevice(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isSupportDeviceStateSaving(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool saveDeviceState(OdGsFilerGSS pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("saveDeviceState", swigMethodTypes24) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_saveDeviceStateSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_saveDeviceState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool loadDeviceState(OdGsFilerGSS pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("loadDeviceState", swigMethodTypes25) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_loadDeviceStateSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_loadDeviceState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool saveClientDeviceState(OdGsFilerGSS pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("saveClientDeviceState", swigMethodTypes52) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_saveClientDeviceStateSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_saveClientDeviceState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadClientDeviceState(OdGsFilerGSS pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("loadClientDeviceState", swigMethodTypes53) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_loadClientDeviceStateSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_loadClientDeviceState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool saveLinkedDeviceState(OdGsFilerGSS pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("saveLinkedDeviceState", swigMethodTypes54) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_saveLinkedDeviceStateSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_saveLinkedDeviceState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadLinkedDeviceState(OdGsFilerGSS pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("loadLinkedDeviceState", swigMethodTypes55) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_loadLinkedDeviceStateSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_loadLinkedDeviceState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool supportInteractiveViewMode()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportInteractiveViewMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSupportInteractiveViewMode(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setSupportInteractiveViewMode(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsUpdateManager getUpdateManager(bool createIfNotExist)
	{
		OdGsUpdateManager rXObject = Helpers.GetRXObject<OdGsUpdateManager>(SwigDerivedClassHasMethod("getUpdateManager", swigMethodTypes37) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getUpdateManagerSwigExplicitOdGsBaseVectorizeDevice__SWIG_0(swigCPtr, createIfNotExist) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getUpdateManager__SWIG_0(swigCPtr, createIfNotExist), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGsUpdateManager getUpdateManager()
	{
		OdGsUpdateManager rXObject = Helpers.GetRXObject<OdGsUpdateManager>(SwigDerivedClassHasMethod("getUpdateManager", swigMethodTypes38) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getUpdateManagerSwigExplicitOdGsBaseVectorizeDevice__SWIG_1(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getUpdateManager__SWIG_1(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void setUpdateManager(OdGsUpdateManager pManager)
	{
		if (SwigDerivedClassHasMethod("setUpdateManager", swigMethodTypes39))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setUpdateManagerSwigExplicitOdGsBaseVectorizeDevice(swigCPtr, OdGsUpdateManager.getCPtr(pManager));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_setUpdateManager(swigCPtr, OdGsUpdateManager.getCPtr(pManager));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsUpdateManager updateManager()
	{
		OdGsUpdateManager rXObject = Helpers.GetRXObject<OdGsUpdateManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_updateManager(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isSuppressHide()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_isSuppressHide(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObject deviceSelfReference()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_deviceSelfReference(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected virtual bool supportParallelDisplay()
	{
		bool result = (SwigDerivedClassHasMethod("supportParallelDisplay", swigMethodTypes56) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportParallelDisplaySwigExplicitOdGsBaseVectorizeDevice(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_supportParallelDisplay(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGsBaseVectorizeDevice createObject()
	{
		OdGsBaseVectorizeDevice rXObject = Helpers.GetRXObject<OdGsBaseVectorizeDevice>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("properties", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodproperties;
		}
		if (SwigDerivedClassHasMethod("userGiContext", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoduserGiContext;
		}
		if (SwigDerivedClassHasMethod("setUserGiContext", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetUserGiContext;
		}
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodinvalidate__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodinvalidate__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isValid", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodisValid;
		}
		if (SwigDerivedClassHasMethod("update", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodupdate;
		}
		if (SwigDerivedClassHasMethod("update", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodupdate__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("onSize", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodonSize;
		}
		if (SwigDerivedClassHasMethod("onSize", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodonSize__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getSize", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetSize;
		}
		if (SwigDerivedClassHasMethod("getSize", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetSize__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("onRealizeForegroundPalette", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodonRealizeForegroundPalette;
		}
		if (SwigDerivedClassHasMethod("onRealizeBackgroundPalette", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodonRealizeBackgroundPalette;
		}
		if (SwigDerivedClassHasMethod("onDisplayChange", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodonDisplayChange;
		}
		if (SwigDerivedClassHasMethod("createView", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodcreateView;
		}
		if (SwigDerivedClassHasMethod("createView", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodcreateView__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createView", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodcreateView__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("addView", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodaddView;
		}
		if (SwigDerivedClassHasMethod("createModel", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodcreateModel;
		}
		if (SwigDerivedClassHasMethod("isModelCompatible", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodisModelCompatible;
		}
		if (SwigDerivedClassHasMethod("saveDeviceState", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsaveDeviceState;
		}
		if (SwigDerivedClassHasMethod("loadDeviceState", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodloadDeviceState;
		}
		if (SwigDerivedClassHasMethod("gsFilerDeviceInterface", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodgsFilerDeviceInterface;
		}
		if (SwigDerivedClassHasMethod("insertView", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodinsertView;
		}
		if (SwigDerivedClassHasMethod("eraseView", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethoderaseView__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("eraseView", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethoderaseView__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("eraseAllViews", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethoderaseAllViews;
		}
		if (SwigDerivedClassHasMethod("numViews", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodnumViews;
		}
		if (SwigDerivedClassHasMethod("viewAt", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodviewAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setBackgroundColor", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodsetBackgroundColor;
		}
		if (SwigDerivedClassHasMethod("getBackgroundColor", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodgetBackgroundColor;
		}
		if (SwigDerivedClassHasMethod("setLogicalPalette", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodsetLogicalPalette;
		}
		if (SwigDerivedClassHasMethod("getSnapShot", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodgetSnapShot;
		}
		if (SwigDerivedClassHasMethod("getUpdateManager", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodgetUpdateManager__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getUpdateManager", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodgetUpdateManager__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setUpdateManager", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodsetUpdateManager;
		}
		if (SwigDerivedClassHasMethod("onOverlayActivated", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodonOverlayActivated;
		}
		if (SwigDerivedClassHasMethod("onOverlayDeactivated", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodonOverlayDeactivated;
		}
		if (SwigDerivedClassHasMethod("supportPartialUpdate", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodsupportPartialUpdate;
		}
		if (SwigDerivedClassHasMethod("supportPartialScreenUpdate", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodsupportPartialScreenUpdate;
		}
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodinvalidate__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodinvalidate__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("updateGeometry", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodupdateGeometry;
		}
		if (SwigDerivedClassHasMethod("updateScreen", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodupdateScreen;
		}
		if (SwigDerivedClassHasMethod("renderTypeWeight", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodrenderTypeWeight;
		}
		if (SwigDerivedClassHasMethod("renderTypeOverlay", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodrenderTypeOverlay;
		}
		if (SwigDerivedClassHasMethod("getSectionGeometryManager", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodgetSectionGeometryManager;
		}
		if (SwigDerivedClassHasMethod("isSupportDeviceStateSaving", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodisSupportDeviceStateSaving;
		}
		if (SwigDerivedClassHasMethod("saveClientDeviceState", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodsaveClientDeviceState;
		}
		if (SwigDerivedClassHasMethod("loadClientDeviceState", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodloadClientDeviceState;
		}
		if (SwigDerivedClassHasMethod("saveLinkedDeviceState", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodsaveLinkedDeviceState;
		}
		if (SwigDerivedClassHasMethod("loadLinkedDeviceState", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodloadLinkedDeviceState;
		}
		if (SwigDerivedClassHasMethod("supportParallelDisplay", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodsupportParallelDisplay;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeDevice_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsBaseVectorizeDevice));
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

	private IntPtr SwigDirectorMethodproperties()
	{
		return OdRxDictionary.getCPtr(properties()).Handle;
	}

	private IntPtr SwigDirectorMethoduserGiContext()
	{
		return OdGiContext.getCPtr(userGiContext()).Handle;
	}

	private void SwigDirectorMethodsetUserGiContext(IntPtr pUserGiContext)
	{
		try
		{
			setUserGiContext(Helpers.GetRXObject<OdGiContext>(pUserGiContext, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodinvalidate__SWIG_0()
	{
		try
		{
			invalidate();
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

	private void SwigDirectorMethodinvalidate__SWIG_1(IntPtr screenRect)
	{
		try
		{
			invalidate(new OdGsDCRect(screenRect, cMemoryOwn: false));
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

	private bool SwigDirectorMethodisValid()
	{
		return isValid();
	}

	private void SwigDirectorMethodupdate(IntPtr pUpdatedRect)
	{
		try
		{
			update((pUpdatedRect == IntPtr.Zero) ? null : new OdGsDCRect(pUpdatedRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodupdate__SWIG_1()
	{
		try
		{
			update();
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

	private void SwigDirectorMethodonSize(IntPtr outputRect)
	{
		try
		{
			onSize(new OdGsDCRect(outputRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodonSize__SWIG_1(IntPtr outputRect)
	{
		try
		{
			onSize(new OdGsDCRectDouble(outputRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetSize(IntPtr outputRect)
	{
		try
		{
			getSize(new OdGsDCRect(outputRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetSize__SWIG_1(IntPtr outputRect)
	{
		try
		{
			getSize(new OdGsDCRectDouble(outputRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodonRealizeForegroundPalette()
	{
		try
		{
			onRealizeForegroundPalette();
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

	private void SwigDirectorMethodonRealizeBackgroundPalette()
	{
		try
		{
			onRealizeBackgroundPalette();
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

	private void SwigDirectorMethodonDisplayChange(int bitsPerPixel, int xPixels, int yPixels)
	{
		try
		{
			onDisplayChange(bitsPerPixel, xPixels, yPixels);
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

	private IntPtr SwigDirectorMethodcreateView(IntPtr pViewInfo, bool enableLayerVisibilityPerView)
	{
		return OdGsView.getCPtr(createView((pViewInfo == IntPtr.Zero) ? null : new OdGsClientViewInfo(pViewInfo, cMemoryOwn: false), enableLayerVisibilityPerView)).Handle;
	}

	private IntPtr SwigDirectorMethodcreateView__SWIG_1(IntPtr pViewInfo)
	{
		return OdGsView.getCPtr(createView((pViewInfo == IntPtr.Zero) ? null : new OdGsClientViewInfo(pViewInfo, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcreateView__SWIG_2()
	{
		return OdGsView.getCPtr(createView()).Handle;
	}

	private void SwigDirectorMethodaddView(IntPtr pView)
	{
		try
		{
			addView(Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodcreateModel()
	{
		return OdGsModel.getCPtr(createModel()).Handle;
	}

	private bool SwigDirectorMethodisModelCompatible(IntPtr pModel)
	{
		return isModelCompatible(Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsaveDeviceState(IntPtr pFiler)
	{
		return saveDeviceState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodloadDeviceState(IntPtr pFiler)
	{
		return loadDeviceState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodgsFilerDeviceInterface()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGsFilerDeviceInterface.getCPtr(gsFilerDeviceInterface()).Handle;
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

	private void SwigDirectorMethodinsertView(int viewIndex, IntPtr pView)
	{
		try
		{
			insertView(viewIndex, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethoderaseView__SWIG_0(IntPtr pView)
	{
		return eraseView(Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethoderaseView__SWIG_1(int viewIndex)
	{
		return eraseView(viewIndex);
	}

	private void SwigDirectorMethoderaseAllViews()
	{
		try
		{
			eraseAllViews();
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

	private int SwigDirectorMethodnumViews()
	{
		return numViews();
	}

	private IntPtr SwigDirectorMethodviewAt__SWIG_0(int viewIndex)
	{
		return OdGsView.getCPtr(viewAt(viewIndex)).Handle;
	}

	private bool SwigDirectorMethodsetBackgroundColor(uint backgroundColor)
	{
		return setBackgroundColor(backgroundColor);
	}

	private uint SwigDirectorMethodgetBackgroundColor()
	{
		return getBackgroundColor();
	}

	private void SwigDirectorMethodsetLogicalPalette(IntPtr logicalPalette, int numColors)
	{
		Func<uint[]> func = delegate
		{
			IntPtr intPtr = logicalPalette;
			if (intPtr == IntPtr.Zero)
			{
				return (uint[])null;
			}
			int num = 257;
			int[] array = new int[num];
			Marshal.Copy(intPtr, array, 0, num);
			return Array.ConvertAll(array, (int in_value) => (uint)in_value);
		};
		try
		{
			setLogicalPalette(func(), numColors);
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

	private void SwigDirectorMethodgetSnapShot(IntPtr pImage, IntPtr region)
	{
		OdSwigDirectorHelper.director_UnpackData(pImage, out var pOriginalObject, out var pFunction);
		OdGiRasterImage pImage2 = Helpers.GetRXObject<OdGiRasterImage>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			getSnapShot(ref pImage2, new OdGsDCRect(region, cMemoryOwn: false));
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
		finally
		{
			IntPtr handle = OdGiRasterImage.getCPtr(pImage2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pImage);
		}
	}

	private IntPtr SwigDirectorMethodgetUpdateManager__SWIG_0(bool createIfNotExist)
	{
		return OdGsUpdateManager.getCPtr(getUpdateManager(createIfNotExist)).Handle;
	}

	private IntPtr SwigDirectorMethodgetUpdateManager__SWIG_1()
	{
		return OdGsUpdateManager.getCPtr(getUpdateManager()).Handle;
	}

	private void SwigDirectorMethodsetUpdateManager(IntPtr pManager)
	{
		try
		{
			setUpdateManager(Helpers.GetRXObject<OdGsUpdateManager>(pManager, bOwn: true, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodonOverlayActivated(int nOverlay)
	{
		try
		{
			onOverlayActivated((OdGsOverlayId)nOverlay);
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

	private void SwigDirectorMethodonOverlayDeactivated(int nOverlay)
	{
		try
		{
			onOverlayDeactivated((OdGsOverlayId)nOverlay);
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

	private bool SwigDirectorMethodsupportPartialUpdate()
	{
		return supportPartialUpdate();
	}

	private bool SwigDirectorMethodsupportPartialScreenUpdate()
	{
		return supportPartialScreenUpdate();
	}

	private void SwigDirectorMethodinvalidate__SWIG_2(uint nOverlays)
	{
		try
		{
			invalidate(nOverlays);
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

	private void SwigDirectorMethodinvalidate__SWIG_3(uint nOverlays, IntPtr screenRect)
	{
		try
		{
			invalidate(nOverlays, new OdGsDCRect(screenRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodupdateGeometry()
	{
		try
		{
			updateGeometry();
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

	private void SwigDirectorMethodupdateScreen()
	{
		try
		{
			updateScreen();
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

	private uint SwigDirectorMethodrenderTypeWeight(int renderType)
	{
		return renderTypeWeight((OdGsModel_RenderType)renderType);
	}

	private int SwigDirectorMethodrenderTypeOverlay(int renderType)
	{
		return (int)renderTypeOverlay((OdGsModel_RenderType)renderType);
	}

	private IntPtr SwigDirectorMethodgetSectionGeometryManager()
	{
		return OdGiSectionGeometryManager.getCPtr(getSectionGeometryManager()).Handle;
	}

	private bool SwigDirectorMethodisSupportDeviceStateSaving()
	{
		return isSupportDeviceStateSaving();
	}

	private bool SwigDirectorMethodsaveClientDeviceState(IntPtr pFiler)
	{
		return saveClientDeviceState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodloadClientDeviceState(IntPtr pFiler)
	{
		return loadClientDeviceState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsaveLinkedDeviceState(IntPtr pFiler)
	{
		return saveLinkedDeviceState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodloadLinkedDeviceState(IntPtr pFiler)
	{
		return loadLinkedDeviceState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsupportParallelDisplay()
	{
		return supportParallelDisplay();
	}
}

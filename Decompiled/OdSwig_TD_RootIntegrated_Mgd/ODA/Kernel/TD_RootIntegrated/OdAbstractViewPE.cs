using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdAbstractViewPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdAbstractViewPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_1();

	public delegate void SwigDelegateOdAbstractViewPE_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_3(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_4(IntPtr pViewport);

	public delegate void SwigDelegateOdAbstractViewPE_5(IntPtr pViewport, IntPtr lowerLeft, IntPtr upperRight);

	public delegate bool SwigDelegateOdAbstractViewPE_6(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_7(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_8(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_9(IntPtr pViewport);

	public delegate double SwigDelegateOdAbstractViewPE_10(IntPtr pViewport);

	public delegate double SwigDelegateOdAbstractViewPE_11(IntPtr pViewport);

	public delegate bool SwigDelegateOdAbstractViewPE_12(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_13(IntPtr pViewport);

	public delegate bool SwigDelegateOdAbstractViewPE_14(IntPtr pViewport);

	public delegate double SwigDelegateOdAbstractViewPE_15(IntPtr pViewport);

	public delegate void SwigDelegateOdAbstractViewPE_16(IntPtr pViewport, IntPtr target, IntPtr direction, IntPtr upVector, double fieldWidth, double fieldHeight, bool isPerspective, IntPtr viewOffset);

	public delegate void SwigDelegateOdAbstractViewPE_17(IntPtr pViewport, IntPtr target, IntPtr direction, IntPtr upVector, double fieldWidth, double fieldHeight, bool isPerspective);

	public delegate void SwigDelegateOdAbstractViewPE_18(IntPtr pViewport, double lensLength);

	public delegate double SwigDelegateOdAbstractViewPE_19(IntPtr pViewport);

	public delegate bool SwigDelegateOdAbstractViewPE_20(IntPtr pViewport);

	public delegate void SwigDelegateOdAbstractViewPE_21(IntPtr pViewport, bool frontClip);

	public delegate bool SwigDelegateOdAbstractViewPE_22(IntPtr pViewport);

	public delegate void SwigDelegateOdAbstractViewPE_23(IntPtr pViewport, bool backClip);

	public delegate bool SwigDelegateOdAbstractViewPE_24(IntPtr pViewport);

	public delegate void SwigDelegateOdAbstractViewPE_25(IntPtr pViewport, bool frontClipAtEye);

	public delegate double SwigDelegateOdAbstractViewPE_26(IntPtr pViewport);

	public delegate void SwigDelegateOdAbstractViewPE_27(IntPtr pViewport, double frontClipDistance);

	public delegate double SwigDelegateOdAbstractViewPE_28(IntPtr pViewport);

	public delegate void SwigDelegateOdAbstractViewPE_29(IntPtr pViewport, double backClipDistance);

	public delegate void SwigDelegateOdAbstractViewPE_30(IntPtr pViewport, int renderMode);

	public delegate int SwigDelegateOdAbstractViewPE_31(IntPtr pViewport);

	public delegate void SwigDelegateOdAbstractViewPE_32(IntPtr pViewport, IntPtr visualStyleId);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_33(IntPtr pViewport);

	public delegate void SwigDelegateOdAbstractViewPE_34(IntPtr pViewport, IntPtr backgroundId);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_35(IntPtr pViewport);

	public delegate bool SwigDelegateOdAbstractViewPE_36(IntPtr pViewport);

	public delegate void SwigDelegateOdAbstractViewPE_37(IntPtr pViewport, bool isOn);

	public delegate int SwigDelegateOdAbstractViewPE_38(IntPtr pViewport);

	public delegate void SwigDelegateOdAbstractViewPE_39(IntPtr pViewport, int lightingType);

	public delegate void SwigDelegateOdAbstractViewPE_40(IntPtr pViewport, IntPtr frozenLayers);

	public delegate void SwigDelegateOdAbstractViewPE_41(IntPtr pViewport, IntPtr frozenLayers);

	public delegate void SwigDelegateOdAbstractViewPE_42(IntPtr pDestinationView, IntPtr pSourceView);

	public delegate bool SwigDelegateOdAbstractViewPE_43(IntPtr pViewport);

	public delegate int SwigDelegateOdAbstractViewPE_44(IntPtr pViewport, IntPtr pDb);

	public delegate int SwigDelegateOdAbstractViewPE_45(IntPtr pViewport);

	public delegate bool SwigDelegateOdAbstractViewPE_46(IntPtr pViewport, int orthoUcs, IntPtr pDb);

	public delegate bool SwigDelegateOdAbstractViewPE_47(IntPtr pViewport, int orthoUcs);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_48(IntPtr pViewport);

	public delegate bool SwigDelegateOdAbstractViewPE_49(IntPtr pViewport, IntPtr ucsId);

	public delegate void SwigDelegateOdAbstractViewPE_50(IntPtr pViewport, IntPtr origin, IntPtr xAxis, IntPtr yAxis);

	public delegate void SwigDelegateOdAbstractViewPE_51(IntPtr pViewport, IntPtr origin, IntPtr xAxis, IntPtr yAxis);

	public delegate double SwigDelegateOdAbstractViewPE_52(IntPtr pViewport);

	public delegate void SwigDelegateOdAbstractViewPE_53(IntPtr pViewport, double elevation);

	public delegate void SwigDelegateOdAbstractViewPE_54(IntPtr pDestinationView, IntPtr pSourceView);

	public delegate bool SwigDelegateOdAbstractViewPE_55(IntPtr pViewport, IntPtr extents);

	public delegate bool SwigDelegateOdAbstractViewPE_56(IntPtr pViewport, IntPtr extents, bool bExtendOnly, bool bExtentsValid, IntPtr pWorldToEye);

	public delegate bool SwigDelegateOdAbstractViewPE_57(IntPtr pViewport, IntPtr extents, bool bExtendOnly, bool bExtentsValid);

	public delegate bool SwigDelegateOdAbstractViewPE_58(IntPtr pViewport, IntPtr extents, bool bExtendOnly);

	public delegate bool SwigDelegateOdAbstractViewPE_59(IntPtr pViewport, IntPtr extents);

	public delegate bool SwigDelegateOdAbstractViewPE_60(IntPtr pViewport, IntPtr pExtents, double extCoef);

	public delegate bool SwigDelegateOdAbstractViewPE_61(IntPtr pViewport, IntPtr pExtents);

	public delegate bool SwigDelegateOdAbstractViewPE_62(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_63(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_64(IntPtr pViewport);

	public delegate bool SwigDelegateOdAbstractViewPE_65(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_66(IntPtr pViewport, bool bOpenForWrite);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_67(IntPtr pViewport);

	public delegate bool SwigDelegateOdAbstractViewPE_68(IntPtr pDestinationView, IntPtr pSourceView);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_69(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdAbstractViewPE_70(IntPtr pViewport, IntPtr pCopyObject);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdAbstractViewPE_0 swigDelegate0;

	private SwigDelegateOdAbstractViewPE_1 swigDelegate1;

	private SwigDelegateOdAbstractViewPE_2 swigDelegate2;

	private SwigDelegateOdAbstractViewPE_3 swigDelegate3;

	private SwigDelegateOdAbstractViewPE_4 swigDelegate4;

	private SwigDelegateOdAbstractViewPE_5 swigDelegate5;

	private SwigDelegateOdAbstractViewPE_6 swigDelegate6;

	private SwigDelegateOdAbstractViewPE_7 swigDelegate7;

	private SwigDelegateOdAbstractViewPE_8 swigDelegate8;

	private SwigDelegateOdAbstractViewPE_9 swigDelegate9;

	private SwigDelegateOdAbstractViewPE_10 swigDelegate10;

	private SwigDelegateOdAbstractViewPE_11 swigDelegate11;

	private SwigDelegateOdAbstractViewPE_12 swigDelegate12;

	private SwigDelegateOdAbstractViewPE_13 swigDelegate13;

	private SwigDelegateOdAbstractViewPE_14 swigDelegate14;

	private SwigDelegateOdAbstractViewPE_15 swigDelegate15;

	private SwigDelegateOdAbstractViewPE_16 swigDelegate16;

	private SwigDelegateOdAbstractViewPE_17 swigDelegate17;

	private SwigDelegateOdAbstractViewPE_18 swigDelegate18;

	private SwigDelegateOdAbstractViewPE_19 swigDelegate19;

	private SwigDelegateOdAbstractViewPE_20 swigDelegate20;

	private SwigDelegateOdAbstractViewPE_21 swigDelegate21;

	private SwigDelegateOdAbstractViewPE_22 swigDelegate22;

	private SwigDelegateOdAbstractViewPE_23 swigDelegate23;

	private SwigDelegateOdAbstractViewPE_24 swigDelegate24;

	private SwigDelegateOdAbstractViewPE_25 swigDelegate25;

	private SwigDelegateOdAbstractViewPE_26 swigDelegate26;

	private SwigDelegateOdAbstractViewPE_27 swigDelegate27;

	private SwigDelegateOdAbstractViewPE_28 swigDelegate28;

	private SwigDelegateOdAbstractViewPE_29 swigDelegate29;

	private SwigDelegateOdAbstractViewPE_30 swigDelegate30;

	private SwigDelegateOdAbstractViewPE_31 swigDelegate31;

	private SwigDelegateOdAbstractViewPE_32 swigDelegate32;

	private SwigDelegateOdAbstractViewPE_33 swigDelegate33;

	private SwigDelegateOdAbstractViewPE_34 swigDelegate34;

	private SwigDelegateOdAbstractViewPE_35 swigDelegate35;

	private SwigDelegateOdAbstractViewPE_36 swigDelegate36;

	private SwigDelegateOdAbstractViewPE_37 swigDelegate37;

	private SwigDelegateOdAbstractViewPE_38 swigDelegate38;

	private SwigDelegateOdAbstractViewPE_39 swigDelegate39;

	private SwigDelegateOdAbstractViewPE_40 swigDelegate40;

	private SwigDelegateOdAbstractViewPE_41 swigDelegate41;

	private SwigDelegateOdAbstractViewPE_42 swigDelegate42;

	private SwigDelegateOdAbstractViewPE_43 swigDelegate43;

	private SwigDelegateOdAbstractViewPE_44 swigDelegate44;

	private SwigDelegateOdAbstractViewPE_45 swigDelegate45;

	private SwigDelegateOdAbstractViewPE_46 swigDelegate46;

	private SwigDelegateOdAbstractViewPE_47 swigDelegate47;

	private SwigDelegateOdAbstractViewPE_48 swigDelegate48;

	private SwigDelegateOdAbstractViewPE_49 swigDelegate49;

	private SwigDelegateOdAbstractViewPE_50 swigDelegate50;

	private SwigDelegateOdAbstractViewPE_51 swigDelegate51;

	private SwigDelegateOdAbstractViewPE_52 swigDelegate52;

	private SwigDelegateOdAbstractViewPE_53 swigDelegate53;

	private SwigDelegateOdAbstractViewPE_54 swigDelegate54;

	private SwigDelegateOdAbstractViewPE_55 swigDelegate55;

	private SwigDelegateOdAbstractViewPE_56 swigDelegate56;

	private SwigDelegateOdAbstractViewPE_57 swigDelegate57;

	private SwigDelegateOdAbstractViewPE_58 swigDelegate58;

	private SwigDelegateOdAbstractViewPE_59 swigDelegate59;

	private SwigDelegateOdAbstractViewPE_60 swigDelegate60;

	private SwigDelegateOdAbstractViewPE_61 swigDelegate61;

	private SwigDelegateOdAbstractViewPE_62 swigDelegate62;

	private SwigDelegateOdAbstractViewPE_63 swigDelegate63;

	private SwigDelegateOdAbstractViewPE_64 swigDelegate64;

	private SwigDelegateOdAbstractViewPE_65 swigDelegate65;

	private SwigDelegateOdAbstractViewPE_66 swigDelegate66;

	private SwigDelegateOdAbstractViewPE_67 swigDelegate67;

	private SwigDelegateOdAbstractViewPE_68 swigDelegate68;

	private SwigDelegateOdAbstractViewPE_69 swigDelegate69;

	private SwigDelegateOdAbstractViewPE_70 swigDelegate70;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdGePoint2d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes16 = new Type[8]
	{
		typeof(OdRxObject),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double),
		typeof(bool),
		typeof(OdGeVector2d)
	};

	private static Type[] swigMethodTypes17 = new Type[7]
	{
		typeof(OdRxObject),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double),
		typeof(bool)
	};

	private static Type[] swigMethodTypes18 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(double)
	};

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes21 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes23 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes25 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes27 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(double)
	};

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes29 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(double)
	};

	private static Type[] swigMethodTypes30 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDb_RenderMode)
	};

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes32 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes34 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes35 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes37 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes39 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGiViewportTraits_DefaultLightingType)
	};

	private static Type[] swigMethodTypes40 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbStubPtrArray)
	};

	private static Type[] swigMethodTypes41 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbStubPtrArray)
	};

	private static Type[] swigMethodTypes42 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes44 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes45 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes46 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdDb_OrthographicView),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes47 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDb_OrthographicView)
	};

	private static Type[] swigMethodTypes48 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes49 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes50 = new Type[4]
	{
		typeof(OdRxObject),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes51 = new Type[4]
	{
		typeof(OdRxObject),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes53 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(double)
	};

	private static Type[] swigMethodTypes54 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes55 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGeBoundBlock3d)
	};

	private static Type[] swigMethodTypes56 = new Type[5]
	{
		typeof(OdRxObject),
		typeof(OdGeBoundBlock3d),
		typeof(bool),
		typeof(bool),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes57 = new Type[4]
	{
		typeof(OdRxObject),
		typeof(OdGeBoundBlock3d),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes58 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdGeBoundBlock3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes59 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGeBoundBlock3d)
	};

	private static Type[] swigMethodTypes60 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdGeBoundBlock3d),
		typeof(double)
	};

	private static Type[] swigMethodTypes61 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGeBoundBlock3d)
	};

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes63 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes65 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes66 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes67 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes68 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes69 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes70 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbStub)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdAbstractViewPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdAbstractViewPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdAbstractViewPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdAbstractViewPE cast(OdRxObject pObj)
	{
		OdAbstractViewPE rXObject = Helpers.GetRXObject<OdAbstractViewPE>(TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_isASwigExplicitOdAbstractViewPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_queryXSwigExplicitOdAbstractViewPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdAbstractViewPE createObject()
	{
		OdAbstractViewPE rXObject = Helpers.GetRXObject<OdAbstractViewPE>(TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGePoint2d lowerLeftCorner(OdRxObject pViewport)
	{
		OdGePoint2d result = new OdGePoint2d(SwigDerivedClassHasMethod("lowerLeftCorner", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_lowerLeftCornerSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_lowerLeftCorner(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint2d upperRightCorner(OdRxObject pViewport)
	{
		OdGePoint2d result = new OdGePoint2d(SwigDerivedClassHasMethod("upperRightCorner", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_upperRightCornerSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_upperRightCorner(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setViewport(OdRxObject pViewport, OdGePoint2d lowerLeft, OdGePoint2d upperRight)
	{
		if (SwigDerivedClassHasMethod("setViewport", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setViewportSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint2d.getCPtr(lowerLeft), OdGePoint2d.getCPtr(upperRight));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setViewport(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint2d.getCPtr(lowerLeft), OdGePoint2d.getCPtr(upperRight));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hasViewport(OdRxObject pViewport)
	{
		bool result = (SwigDerivedClassHasMethod("hasViewport", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_hasViewportSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_hasViewport(swigCPtr, OdRxObject.getCPtr(pViewport)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d target(OdRxObject pViewport)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_target(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d direction(OdRxObject pViewport)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_direction(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d upVector(OdRxObject pViewport)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_upVector(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double fieldWidth(OdRxObject pViewport)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_fieldWidth(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double fieldHeight(OdRxObject pViewport)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_fieldHeight(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isPerspective(OdRxObject pViewport)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_isPerspective(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector2d viewOffset(OdRxObject pViewport)
	{
		OdGeVector2d result = new OdGeVector2d(SwigDerivedClassHasMethod("viewOffset", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_viewOffsetSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_viewOffset(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasViewOffset(OdRxObject pViewport)
	{
		bool result = (SwigDerivedClassHasMethod("hasViewOffset", swigMethodTypes14) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_hasViewOffsetSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_hasViewOffset(swigCPtr, OdRxObject.getCPtr(pViewport)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double viewTwist(OdRxObject pViewport)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_viewTwist(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setView(OdRxObject pViewport, OdGePoint3d target, OdGeVector3d direction, OdGeVector3d upVector, double fieldWidth, double fieldHeight, bool isPerspective, OdGeVector2d viewOffset)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setView__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(target), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fieldWidth, fieldHeight, isPerspective, OdGeVector2d.getCPtr(viewOffset).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setView(OdRxObject pViewport, OdGePoint3d target, OdGeVector3d direction, OdGeVector3d upVector, double fieldWidth, double fieldHeight, bool isPerspective)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setView__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(target), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fieldWidth, fieldHeight, isPerspective);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLensLength(OdRxObject pViewport, double lensLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setLensLength(swigCPtr, OdRxObject.getCPtr(pViewport), lensLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double lensLength(OdRxObject pViewport)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_lensLength(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isFrontClipOn(OdRxObject pViewport)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_isFrontClipOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFrontClipOn(OdRxObject pViewport, bool frontClip)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setFrontClipOn(swigCPtr, OdRxObject.getCPtr(pViewport), frontClip);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isBackClipOn(OdRxObject pViewport)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_isBackClipOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBackClipOn(OdRxObject pViewport, bool backClip)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setBackClipOn(swigCPtr, OdRxObject.getCPtr(pViewport), backClip);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isFrontClipAtEyeOn(OdRxObject pViewport)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_isFrontClipAtEyeOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFrontClipAtEyeOn(OdRxObject pViewport, bool frontClipAtEye)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setFrontClipAtEyeOn(swigCPtr, OdRxObject.getCPtr(pViewport), frontClipAtEye);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double frontClipDistance(OdRxObject pViewport)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_frontClipDistance(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFrontClipDistance(OdRxObject pViewport, double frontClipDistance)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setFrontClipDistance(swigCPtr, OdRxObject.getCPtr(pViewport), frontClipDistance);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double backClipDistance(OdRxObject pViewport)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_backClipDistance(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBackClipDistance(OdRxObject pViewport, double backClipDistance)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setBackClipDistance(swigCPtr, OdRxObject.getCPtr(pViewport), backClipDistance);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRenderMode(OdRxObject pViewport, OdDb_RenderMode renderMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setRenderMode(swigCPtr, OdRxObject.getCPtr(pViewport), (int)renderMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_RenderMode renderMode(OdRxObject pViewport)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_renderMode(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_RenderMode)result;
	}

	public virtual void setVisualStyle(OdRxObject pViewport, OdDbStub visualStyleId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setVisualStyle(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(visualStyleId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub visualStyle(OdRxObject pViewport)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_visualStyle(swigCPtr, OdRxObject.getCPtr(pViewport));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBackground(OdRxObject pViewport, OdDbStub backgroundId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setBackground(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(backgroundId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub background(OdRxObject pViewport)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_background(swigCPtr, OdRxObject.getCPtr(pViewport));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isDefaultLightingOn(OdRxObject pViewport)
	{
		bool result = (SwigDerivedClassHasMethod("isDefaultLightingOn", swigMethodTypes36) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_isDefaultLightingOnSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_isDefaultLightingOn(swigCPtr, OdRxObject.getCPtr(pViewport)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDefaultLightingOn(OdRxObject pViewport, bool isOn)
	{
		if (SwigDerivedClassHasMethod("setDefaultLightingOn", swigMethodTypes37))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setDefaultLightingOnSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport), isOn);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setDefaultLightingOn(swigCPtr, OdRxObject.getCPtr(pViewport), isOn);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiViewportTraits_DefaultLightingType defaultLightingType(OdRxObject pViewport)
	{
		int result = (SwigDerivedClassHasMethod("defaultLightingType", swigMethodTypes38) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_defaultLightingTypeSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_defaultLightingType(swigCPtr, OdRxObject.getCPtr(pViewport)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiViewportTraits_DefaultLightingType)result;
	}

	public virtual void setDefaultLightingType(OdRxObject pViewport, OdGiViewportTraits_DefaultLightingType lightingType)
	{
		if (SwigDerivedClassHasMethod("setDefaultLightingType", swigMethodTypes39))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setDefaultLightingTypeSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport), (int)lightingType);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setDefaultLightingType(swigCPtr, OdRxObject.getCPtr(pViewport), (int)lightingType);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void FrozenLayers(OdRxObject pViewport, OdDbStubPtrArray frozenLayers)
	{
		if (SwigDerivedClassHasMethod("FrozenLayers", swigMethodTypes40))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_FrozenLayersSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStubPtrArray.getCPtr(frozenLayers));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_FrozenLayers(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStubPtrArray.getCPtr(frozenLayers));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFrozenLayers(OdRxObject pViewport, OdDbStubPtrArray frozenLayers)
	{
		if (SwigDerivedClassHasMethod("setFrozenLayers", swigMethodTypes41))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setFrozenLayersSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStubPtrArray.getCPtr(frozenLayers));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setFrozenLayers(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStubPtrArray.getCPtr(frozenLayers));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setView(OdRxObject pDestinationView, OdRxObject pSourceView)
	{
		if (SwigDerivedClassHasMethod("setView", swigMethodTypes42))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setViewSwigExplicitOdAbstractViewPE__SWIG_2(swigCPtr, OdRxObject.getCPtr(pDestinationView), OdRxObject.getCPtr(pSourceView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setView__SWIG_2(swigCPtr, OdRxObject.getCPtr(pDestinationView), OdRxObject.getCPtr(pSourceView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hasUcs(OdRxObject pViewport)
	{
		bool result = (SwigDerivedClassHasMethod("hasUcs", swigMethodTypes43) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_hasUcsSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_hasUcs(swigCPtr, OdRxObject.getCPtr(pViewport)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDb_OrthographicView orthoUcs(OdRxObject pViewport, OdRxObject pDb)
	{
		int result = (SwigDerivedClassHasMethod("orthoUcs", swigMethodTypes44) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_orthoUcsSwigExplicitOdAbstractViewPE__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdRxObject.getCPtr(pDb)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_orthoUcs__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdRxObject.getCPtr(pDb)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_OrthographicView)result;
	}

	public virtual OdDb_OrthographicView orthoUcs(OdRxObject pViewport)
	{
		int result = (SwigDerivedClassHasMethod("orthoUcs", swigMethodTypes45) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_orthoUcsSwigExplicitOdAbstractViewPE__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_orthoUcs__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_OrthographicView)result;
	}

	public virtual bool setUcs(OdRxObject pViewport, OdDb_OrthographicView orthoUcs, OdRxObject pDb)
	{
		bool result = (SwigDerivedClassHasMethod("setUcs", swigMethodTypes46) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setUcsSwigExplicitOdAbstractViewPE__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), (int)orthoUcs, OdRxObject.getCPtr(pDb)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setUcs__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), (int)orthoUcs, OdRxObject.getCPtr(pDb)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setUcs(OdRxObject pViewport, OdDb_OrthographicView orthoUcs)
	{
		bool result = (SwigDerivedClassHasMethod("setUcs", swigMethodTypes47) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setUcsSwigExplicitOdAbstractViewPE__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport), (int)orthoUcs) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setUcs__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport), (int)orthoUcs));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub ucsName(OdRxObject pViewport)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("ucsName", swigMethodTypes48) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_ucsNameSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_ucsName(swigCPtr, OdRxObject.getCPtr(pViewport)));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setUcs(OdRxObject pViewport, OdDbStub ucsId)
	{
		bool result = (SwigDerivedClassHasMethod("setUcs", swigMethodTypes49) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setUcsSwigExplicitOdAbstractViewPE__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(ucsId)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setUcs__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(ucsId)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getUcs(OdRxObject pViewport, OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis)
	{
		if (SwigDerivedClassHasMethod("getUcs", swigMethodTypes50))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_getUcsSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_getUcs(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUcs(OdRxObject pViewport, OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis)
	{
		if (SwigDerivedClassHasMethod("setUcs", swigMethodTypes51))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setUcsSwigExplicitOdAbstractViewPE__SWIG_3(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setUcs__SWIG_3(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double elevation(OdRxObject pViewport)
	{
		double result = (SwigDerivedClassHasMethod("elevation", swigMethodTypes52) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_elevationSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_elevation(swigCPtr, OdRxObject.getCPtr(pViewport)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setElevation(OdRxObject pViewport, double elevation)
	{
		if (SwigDerivedClassHasMethod("setElevation", swigMethodTypes53))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setElevationSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport), elevation);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setElevation(swigCPtr, OdRxObject.getCPtr(pViewport), elevation);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUcs(OdRxObject pDestinationView, OdRxObject pSourceView)
	{
		if (SwigDerivedClassHasMethod("setUcs", swigMethodTypes54))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setUcsSwigExplicitOdAbstractViewPE__SWIG_4(swigCPtr, OdRxObject.getCPtr(pDestinationView), OdRxObject.getCPtr(pSourceView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_setUcs__SWIG_4(swigCPtr, OdRxObject.getCPtr(pDestinationView), OdRxObject.getCPtr(pSourceView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool viewExtents(OdRxObject pViewport, OdGeBoundBlock3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_viewExtents(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool plotExtents(OdRxObject pViewport, OdGeBoundBlock3d extents, bool bExtendOnly, bool bExtentsValid, OdGeMatrix3d pWorldToEye)
	{
		bool result = (SwigDerivedClassHasMethod("plotExtents", swigMethodTypes56) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_plotExtentsSwigExplicitOdAbstractViewPE__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents), bExtendOnly, bExtentsValid, OdGeMatrix3d.getCPtr(pWorldToEye)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_plotExtents__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents), bExtendOnly, bExtentsValid, OdGeMatrix3d.getCPtr(pWorldToEye)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool plotExtents(OdRxObject pViewport, OdGeBoundBlock3d extents, bool bExtendOnly, bool bExtentsValid)
	{
		bool result = (SwigDerivedClassHasMethod("plotExtents", swigMethodTypes57) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_plotExtentsSwigExplicitOdAbstractViewPE__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents), bExtendOnly, bExtentsValid) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_plotExtents__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents), bExtendOnly, bExtentsValid));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool plotExtents(OdRxObject pViewport, OdGeBoundBlock3d extents, bool bExtendOnly)
	{
		bool result = (SwigDerivedClassHasMethod("plotExtents", swigMethodTypes58) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_plotExtentsSwigExplicitOdAbstractViewPE__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents), bExtendOnly) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_plotExtents__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents), bExtendOnly));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool plotExtents(OdRxObject pViewport, OdGeBoundBlock3d extents)
	{
		bool result = (SwigDerivedClassHasMethod("plotExtents", swigMethodTypes59) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_plotExtentsSwigExplicitOdAbstractViewPE__SWIG_3(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_plotExtents__SWIG_3(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool zoomExtents(OdRxObject pViewport, OdGeBoundBlock3d pExtents, double extCoef)
	{
		bool result = (SwigDerivedClassHasMethod("zoomExtents", swigMethodTypes60) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_zoomExtentsSwigExplicitOdAbstractViewPE__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(pExtents), extCoef) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_zoomExtents__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(pExtents), extCoef));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool zoomExtents(OdRxObject pViewport, OdGeBoundBlock3d pExtents)
	{
		bool result = (SwigDerivedClassHasMethod("zoomExtents", swigMethodTypes61) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_zoomExtentsSwigExplicitOdAbstractViewPE__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(pExtents)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_zoomExtents__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(pExtents)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool zoomExtents(OdRxObject pViewport)
	{
		bool result = (SwigDerivedClassHasMethod("zoomExtents", swigMethodTypes62) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_zoomExtentsSwigExplicitOdAbstractViewPE__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_zoomExtents__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewport)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d worldToEye(OdRxObject pViewport)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("worldToEye", swigMethodTypes63) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_worldToEyeSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_worldToEye(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d eyeToWorld(OdRxObject pViewport)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("eyeToWorld", swigMethodTypes64) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_eyeToWorldSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_eyeToWorld(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isPlotting(OdRxObject pViewport)
	{
		bool result = (SwigDerivedClassHasMethod("isPlotting", swigMethodTypes65) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_isPlottingSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_isPlotting(swigCPtr, OdRxObject.getCPtr(pViewport)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxObject plotDataObject(OdRxObject pViewport, bool bOpenForWrite)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("plotDataObject", swigMethodTypes66) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_plotDataObjectSwigExplicitOdAbstractViewPE__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), bOpenForWrite) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_plotDataObject__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), bOpenForWrite), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject plotDataObject(OdRxObject pViewport)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("plotDataObject", swigMethodTypes67) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_plotDataObjectSwigExplicitOdAbstractViewPE__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_plotDataObject__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool applyPlotSettings(OdRxObject pDestinationView, OdRxObject pSourceView)
	{
		bool result = (SwigDerivedClassHasMethod("applyPlotSettings", swigMethodTypes68) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_applyPlotSettingsSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pDestinationView), OdRxObject.getCPtr(pSourceView)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_applyPlotSettings(swigCPtr, OdRxObject.getCPtr(pDestinationView), OdRxObject.getCPtr(pSourceView)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub annotationScale(OdRxObject pViewport)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("annotationScale", swigMethodTypes69) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_annotationScaleSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_annotationScale(swigCPtr, OdRxObject.getCPtr(pViewport)));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub compatibleCopyObject(OdRxObject pViewport, OdDbStub pCopyObject)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("compatibleCopyObject", swigMethodTypes70) ? TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_compatibleCopyObjectSwigExplicitOdAbstractViewPE(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(pCopyObject)) : TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_compatibleCopyObject(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(pCopyObject)));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdAbstractViewPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdAbstractViewPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdAbstractViewPE) != GetType();
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
		if (SwigDerivedClassHasMethod("lowerLeftCorner", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodlowerLeftCorner;
		}
		if (SwigDerivedClassHasMethod("upperRightCorner", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodupperRightCorner;
		}
		if (SwigDerivedClassHasMethod("setViewport", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetViewport;
		}
		if (SwigDerivedClassHasMethod("hasViewport", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodhasViewport;
		}
		if (SwigDerivedClassHasMethod("target", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodtarget;
		}
		if (SwigDerivedClassHasMethod("direction", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddirection;
		}
		if (SwigDerivedClassHasMethod("upVector", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodupVector;
		}
		if (SwigDerivedClassHasMethod("fieldWidth", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodfieldWidth;
		}
		if (SwigDerivedClassHasMethod("fieldHeight", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodfieldHeight;
		}
		if (SwigDerivedClassHasMethod("isPerspective", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodisPerspective;
		}
		if (SwigDerivedClassHasMethod("viewOffset", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodviewOffset;
		}
		if (SwigDerivedClassHasMethod("hasViewOffset", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodhasViewOffset;
		}
		if (SwigDerivedClassHasMethod("viewTwist", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodviewTwist;
		}
		if (SwigDerivedClassHasMethod("setView", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetView__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setView", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetView__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLensLength", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodsetLensLength;
		}
		if (SwigDerivedClassHasMethod("lensLength", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodlensLength;
		}
		if (SwigDerivedClassHasMethod("isFrontClipOn", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodisFrontClipOn;
		}
		if (SwigDerivedClassHasMethod("setFrontClipOn", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetFrontClipOn;
		}
		if (SwigDerivedClassHasMethod("isBackClipOn", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodisBackClipOn;
		}
		if (SwigDerivedClassHasMethod("setBackClipOn", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodsetBackClipOn;
		}
		if (SwigDerivedClassHasMethod("isFrontClipAtEyeOn", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodisFrontClipAtEyeOn;
		}
		if (SwigDerivedClassHasMethod("setFrontClipAtEyeOn", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetFrontClipAtEyeOn;
		}
		if (SwigDerivedClassHasMethod("frontClipDistance", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodfrontClipDistance;
		}
		if (SwigDerivedClassHasMethod("setFrontClipDistance", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodsetFrontClipDistance;
		}
		if (SwigDerivedClassHasMethod("backClipDistance", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodbackClipDistance;
		}
		if (SwigDerivedClassHasMethod("setBackClipDistance", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodsetBackClipDistance;
		}
		if (SwigDerivedClassHasMethod("setRenderMode", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodsetRenderMode;
		}
		if (SwigDerivedClassHasMethod("renderMode", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodrenderMode;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodsetVisualStyle;
		}
		if (SwigDerivedClassHasMethod("visualStyle", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodvisualStyle;
		}
		if (SwigDerivedClassHasMethod("setBackground", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodsetBackground;
		}
		if (SwigDerivedClassHasMethod("background", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodbackground;
		}
		if (SwigDerivedClassHasMethod("isDefaultLightingOn", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodisDefaultLightingOn;
		}
		if (SwigDerivedClassHasMethod("setDefaultLightingOn", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodsetDefaultLightingOn;
		}
		if (SwigDerivedClassHasMethod("defaultLightingType", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethoddefaultLightingType;
		}
		if (SwigDerivedClassHasMethod("setDefaultLightingType", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodsetDefaultLightingType;
		}
		if (SwigDerivedClassHasMethod("FrozenLayers", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodFrozenLayers;
		}
		if (SwigDerivedClassHasMethod("setFrozenLayers", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodsetFrozenLayers;
		}
		if (SwigDerivedClassHasMethod("setView", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodsetView__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("hasUcs", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodhasUcs;
		}
		if (SwigDerivedClassHasMethod("orthoUcs", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodorthoUcs__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("orthoUcs", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodorthoUcs__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setUcs", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodsetUcs__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setUcs", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodsetUcs__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("ucsName", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethoducsName;
		}
		if (SwigDerivedClassHasMethod("setUcs", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodsetUcs__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getUcs", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodgetUcs;
		}
		if (SwigDerivedClassHasMethod("setUcs", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodsetUcs__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("elevation", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodelevation;
		}
		if (SwigDerivedClassHasMethod("setElevation", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodsetElevation;
		}
		if (SwigDerivedClassHasMethod("setUcs", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodsetUcs__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("viewExtents", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodviewExtents;
		}
		if (SwigDerivedClassHasMethod("plotExtents", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodplotExtents__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("plotExtents", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodplotExtents__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("plotExtents", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodplotExtents__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("plotExtents", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodplotExtents__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("zoomExtents", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodzoomExtents__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("zoomExtents", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodzoomExtents__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("zoomExtents", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodzoomExtents__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("worldToEye", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodworldToEye;
		}
		if (SwigDerivedClassHasMethod("eyeToWorld", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodeyeToWorld;
		}
		if (SwigDerivedClassHasMethod("isPlotting", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodisPlotting;
		}
		if (SwigDerivedClassHasMethod("plotDataObject", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodplotDataObject__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("plotDataObject", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodplotDataObject__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("applyPlotSettings", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodapplyPlotSettings;
		}
		if (SwigDerivedClassHasMethod("annotationScale", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodannotationScale;
		}
		if (SwigDerivedClassHasMethod("compatibleCopyObject", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodcompatibleCopyObject;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdAbstractViewPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdAbstractViewPE));
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

	private IntPtr SwigDirectorMethodlowerLeftCorner(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint2d.getCPtr(lowerLeftCorner(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodupperRightCorner(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint2d.getCPtr(upperRightCorner(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private void SwigDirectorMethodsetViewport(IntPtr pViewport, IntPtr lowerLeft, IntPtr upperRight)
	{
		try
		{
			setViewport(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGePoint2d(lowerLeft, cMemoryOwn: false), new OdGePoint2d(upperRight, cMemoryOwn: false));
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

	private bool SwigDirectorMethodhasViewport(IntPtr pViewport)
	{
		return hasViewport(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodtarget(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(target(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethoddirection(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(direction(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodupVector(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(upVector(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private double SwigDirectorMethodfieldWidth(IntPtr pViewport)
	{
		return fieldWidth(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodfieldHeight(IntPtr pViewport)
	{
		return fieldHeight(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisPerspective(IntPtr pViewport)
	{
		return isPerspective(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodviewOffset(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector2d.getCPtr(viewOffset(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private bool SwigDirectorMethodhasViewOffset(IntPtr pViewport)
	{
		return hasViewOffset(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodviewTwist(IntPtr pViewport)
	{
		return viewTwist(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetView__SWIG_0(IntPtr pViewport, IntPtr target, IntPtr direction, IntPtr upVector, double fieldWidth, double fieldHeight, bool isPerspective, IntPtr viewOffset)
	{
		try
		{
			setView(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(target, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fieldWidth, fieldHeight, isPerspective, new OdGeVector2d(viewOffset, cMemoryOwn: true));
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

	private void SwigDirectorMethodsetView__SWIG_1(IntPtr pViewport, IntPtr target, IntPtr direction, IntPtr upVector, double fieldWidth, double fieldHeight, bool isPerspective)
	{
		try
		{
			setView(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(target, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fieldWidth, fieldHeight, isPerspective);
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

	private void SwigDirectorMethodsetLensLength(IntPtr pViewport, double lensLength)
	{
		try
		{
			setLensLength(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), lensLength);
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

	private double SwigDirectorMethodlensLength(IntPtr pViewport)
	{
		return lensLength(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisFrontClipOn(IntPtr pViewport)
	{
		return isFrontClipOn(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetFrontClipOn(IntPtr pViewport, bool frontClip)
	{
		try
		{
			setFrontClipOn(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), frontClip);
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

	private bool SwigDirectorMethodisBackClipOn(IntPtr pViewport)
	{
		return isBackClipOn(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetBackClipOn(IntPtr pViewport, bool backClip)
	{
		try
		{
			setBackClipOn(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), backClip);
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

	private bool SwigDirectorMethodisFrontClipAtEyeOn(IntPtr pViewport)
	{
		return isFrontClipAtEyeOn(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetFrontClipAtEyeOn(IntPtr pViewport, bool frontClipAtEye)
	{
		try
		{
			setFrontClipAtEyeOn(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), frontClipAtEye);
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

	private double SwigDirectorMethodfrontClipDistance(IntPtr pViewport)
	{
		return frontClipDistance(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetFrontClipDistance(IntPtr pViewport, double frontClipDistance)
	{
		try
		{
			setFrontClipDistance(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), frontClipDistance);
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

	private double SwigDirectorMethodbackClipDistance(IntPtr pViewport)
	{
		return backClipDistance(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetBackClipDistance(IntPtr pViewport, double backClipDistance)
	{
		try
		{
			setBackClipDistance(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), backClipDistance);
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

	private void SwigDirectorMethodsetRenderMode(IntPtr pViewport, int renderMode)
	{
		try
		{
			setRenderMode(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (OdDb_RenderMode)renderMode);
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

	private int SwigDirectorMethodrenderMode(IntPtr pViewport)
	{
		return (int)renderMode(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetVisualStyle(IntPtr pViewport, IntPtr visualStyleId)
	{
		try
		{
			setVisualStyle(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (visualStyleId == IntPtr.Zero) ? null : new OdDbStub(visualStyleId, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodvisualStyle(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(visualStyle(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private void SwigDirectorMethodsetBackground(IntPtr pViewport, IntPtr backgroundId)
	{
		try
		{
			setBackground(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (backgroundId == IntPtr.Zero) ? null : new OdDbStub(backgroundId, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodbackground(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(background(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private bool SwigDirectorMethodisDefaultLightingOn(IntPtr pViewport)
	{
		return isDefaultLightingOn(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetDefaultLightingOn(IntPtr pViewport, bool isOn)
	{
		try
		{
			setDefaultLightingOn(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), isOn);
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

	private int SwigDirectorMethoddefaultLightingType(IntPtr pViewport)
	{
		return (int)defaultLightingType(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetDefaultLightingType(IntPtr pViewport, int lightingType)
	{
		try
		{
			setDefaultLightingType(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (OdGiViewportTraits_DefaultLightingType)lightingType);
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

	private void SwigDirectorMethodFrozenLayers(IntPtr pViewport, IntPtr frozenLayers)
	{
		try
		{
			FrozenLayers(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdDbStubPtrArray(frozenLayers, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetFrozenLayers(IntPtr pViewport, IntPtr frozenLayers)
	{
		try
		{
			setFrozenLayers(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdDbStubPtrArray(frozenLayers, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetView__SWIG_2(IntPtr pDestinationView, IntPtr pSourceView)
	{
		try
		{
			setView(Helpers.GetRXObject<OdRxObject>(pDestinationView, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pSourceView, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodhasUcs(IntPtr pViewport)
	{
		return hasUcs(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodorthoUcs__SWIG_0(IntPtr pViewport, IntPtr pDb)
	{
		return (int)orthoUcs(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodorthoUcs__SWIG_1(IntPtr pViewport)
	{
		return (int)orthoUcs(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsetUcs__SWIG_0(IntPtr pViewport, int orthoUcs, IntPtr pDb)
	{
		return setUcs(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (OdDb_OrthographicView)orthoUcs, Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsetUcs__SWIG_1(IntPtr pViewport, int orthoUcs)
	{
		return setUcs(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (OdDb_OrthographicView)orthoUcs);
	}

	private IntPtr SwigDirectorMethoducsName(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(ucsName(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private bool SwigDirectorMethodsetUcs__SWIG_2(IntPtr pViewport, IntPtr ucsId)
	{
		return setUcs(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (ucsId == IntPtr.Zero) ? null : new OdDbStub(ucsId, cMemoryOwn: false));
	}

	private void SwigDirectorMethodgetUcs(IntPtr pViewport, IntPtr origin, IntPtr xAxis, IntPtr yAxis)
	{
		try
		{
			getUcs(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(xAxis, cMemoryOwn: false), new OdGeVector3d(yAxis, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetUcs__SWIG_3(IntPtr pViewport, IntPtr origin, IntPtr xAxis, IntPtr yAxis)
	{
		try
		{
			setUcs(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(xAxis, cMemoryOwn: false), new OdGeVector3d(yAxis, cMemoryOwn: false));
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

	private double SwigDirectorMethodelevation(IntPtr pViewport)
	{
		return elevation(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetElevation(IntPtr pViewport, double elevation)
	{
		try
		{
			setElevation(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), elevation);
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

	private void SwigDirectorMethodsetUcs__SWIG_4(IntPtr pDestinationView, IntPtr pSourceView)
	{
		try
		{
			setUcs(Helpers.GetRXObject<OdRxObject>(pDestinationView, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pSourceView, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodviewExtents(IntPtr pViewport, IntPtr extents)
	{
		return viewExtents(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(extents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodplotExtents__SWIG_0(IntPtr pViewport, IntPtr extents, bool bExtendOnly, bool bExtentsValid, IntPtr pWorldToEye)
	{
		return plotExtents(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(extents, cMemoryOwn: false), bExtendOnly, bExtentsValid, (pWorldToEye == IntPtr.Zero) ? null : new OdGeMatrix3d(pWorldToEye, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodplotExtents__SWIG_1(IntPtr pViewport, IntPtr extents, bool bExtendOnly, bool bExtentsValid)
	{
		return plotExtents(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(extents, cMemoryOwn: false), bExtendOnly, bExtentsValid);
	}

	private bool SwigDirectorMethodplotExtents__SWIG_2(IntPtr pViewport, IntPtr extents, bool bExtendOnly)
	{
		return plotExtents(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(extents, cMemoryOwn: false), bExtendOnly);
	}

	private bool SwigDirectorMethodplotExtents__SWIG_3(IntPtr pViewport, IntPtr extents)
	{
		return plotExtents(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(extents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodzoomExtents__SWIG_0(IntPtr pViewport, IntPtr pExtents, double extCoef)
	{
		return zoomExtents(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (pExtents == IntPtr.Zero) ? null : new OdGeBoundBlock3d(pExtents, cMemoryOwn: false), extCoef);
	}

	private bool SwigDirectorMethodzoomExtents__SWIG_1(IntPtr pViewport, IntPtr pExtents)
	{
		return zoomExtents(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (pExtents == IntPtr.Zero) ? null : new OdGeBoundBlock3d(pExtents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodzoomExtents__SWIG_2(IntPtr pViewport)
	{
		return zoomExtents(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodworldToEye(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(worldToEye(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodeyeToWorld(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(eyeToWorld(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private bool SwigDirectorMethodisPlotting(IntPtr pViewport)
	{
		return isPlotting(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodplotDataObject__SWIG_0(IntPtr pViewport, bool bOpenForWrite)
	{
		return OdRxObject.getCPtr(plotDataObject(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), bOpenForWrite)).Handle;
	}

	private IntPtr SwigDirectorMethodplotDataObject__SWIG_1(IntPtr pViewport)
	{
		return OdRxObject.getCPtr(plotDataObject(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private bool SwigDirectorMethodapplyPlotSettings(IntPtr pDestinationView, IntPtr pSourceView)
	{
		return applyPlotSettings(Helpers.GetRXObject<OdRxObject>(pDestinationView, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pSourceView, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodannotationScale(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(annotationScale(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodcompatibleCopyObject(IntPtr pViewport, IntPtr pCopyObject)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(compatibleCopyObject(Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (pCopyObject == IntPtr.Zero) ? null : new OdDbStub(pCopyObject, cMemoryOwn: false))).Handle;
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

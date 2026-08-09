using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiViewportTraits : OdGiSubEntityTraits
{
	public delegate IntPtr SwigDelegateOdGiViewportTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiViewportTraits_1();

	public delegate void SwigDelegateOdGiViewportTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiViewportTraits_3(ushort color);

	public delegate void SwigDelegateOdGiViewportTraits_4(IntPtr color);

	public delegate void SwigDelegateOdGiViewportTraits_5(IntPtr layerId);

	public delegate void SwigDelegateOdGiViewportTraits_6(IntPtr lineTypeId);

	public delegate void SwigDelegateOdGiViewportTraits_7(IntPtr selectionMarker);

	public delegate void SwigDelegateOdGiViewportTraits_8(int fillType);

	public delegate void SwigDelegateOdGiViewportTraits_9(IntPtr pNormal);

	public delegate void SwigDelegateOdGiViewportTraits_10();

	public delegate void SwigDelegateOdGiViewportTraits_11(int lineWeight);

	public delegate void SwigDelegateOdGiViewportTraits_12(double lineTypeScale);

	public delegate void SwigDelegateOdGiViewportTraits_13();

	public delegate void SwigDelegateOdGiViewportTraits_14(double thickness);

	public delegate void SwigDelegateOdGiViewportTraits_15(int plotStyleNameType, IntPtr plotStyleNameId);

	public delegate void SwigDelegateOdGiViewportTraits_16(int plotStyleNameType);

	public delegate void SwigDelegateOdGiViewportTraits_17(IntPtr materialId);

	public delegate void SwigDelegateOdGiViewportTraits_18(IntPtr pMapper);

	public delegate void SwigDelegateOdGiViewportTraits_19(IntPtr visualStyleId);

	public delegate void SwigDelegateOdGiViewportTraits_20(IntPtr transparency);

	public delegate void SwigDelegateOdGiViewportTraits_21(uint drawFlags);

	public delegate void SwigDelegateOdGiViewportTraits_22(uint lockFlags);

	public delegate void SwigDelegateOdGiViewportTraits_23(bool bSelectionFlag);

	public delegate void SwigDelegateOdGiViewportTraits_24(int shadowFlags);

	public delegate void SwigDelegateOdGiViewportTraits_25(bool bSectionableFlag);

	public delegate void SwigDelegateOdGiViewportTraits_26(int selectionFlags);

	public delegate ushort SwigDelegateOdGiViewportTraits_27();

	public delegate IntPtr SwigDelegateOdGiViewportTraits_28();

	public delegate IntPtr SwigDelegateOdGiViewportTraits_29();

	public delegate IntPtr SwigDelegateOdGiViewportTraits_30();

	public delegate int SwigDelegateOdGiViewportTraits_31();

	public delegate bool SwigDelegateOdGiViewportTraits_32(IntPtr normal);

	public delegate int SwigDelegateOdGiViewportTraits_33();

	public delegate double SwigDelegateOdGiViewportTraits_34();

	public delegate double SwigDelegateOdGiViewportTraits_35();

	public delegate int SwigDelegateOdGiViewportTraits_36();

	public delegate IntPtr SwigDelegateOdGiViewportTraits_37();

	public delegate IntPtr SwigDelegateOdGiViewportTraits_38();

	public delegate IntPtr SwigDelegateOdGiViewportTraits_39();

	public delegate IntPtr SwigDelegateOdGiViewportTraits_40();

	public delegate IntPtr SwigDelegateOdGiViewportTraits_41();

	public delegate uint SwigDelegateOdGiViewportTraits_42();

	public delegate uint SwigDelegateOdGiViewportTraits_43();

	public delegate bool SwigDelegateOdGiViewportTraits_44();

	public delegate int SwigDelegateOdGiViewportTraits_45();

	public delegate bool SwigDelegateOdGiViewportTraits_46();

	public delegate int SwigDelegateOdGiViewportTraits_47();

	public delegate void SwigDelegateOdGiViewportTraits_48(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiViewportTraits_49();

	public delegate void SwigDelegateOdGiViewportTraits_50(IntPtr pLSMod);

	public delegate IntPtr SwigDelegateOdGiViewportTraits_51();

	public delegate void SwigDelegateOdGiViewportTraits_52(IntPtr pFill);

	public delegate IntPtr SwigDelegateOdGiViewportTraits_53();

	public delegate void SwigDelegateOdGiViewportTraits_54(IntPtr pAuxData);

	public delegate IntPtr SwigDelegateOdGiViewportTraits_55();

	public delegate bool SwigDelegateOdGiViewportTraits_56(IntPtr pOverride);

	public delegate void SwigDelegateOdGiViewportTraits_57();

	public delegate bool SwigDelegateOdGiViewportTraits_58(IntPtr pOverride);

	public delegate void SwigDelegateOdGiViewportTraits_59();

	public delegate uint SwigDelegateOdGiViewportTraits_60();

	public delegate void SwigDelegateOdGiViewportTraits_61(IntPtr lightId);

	public delegate bool SwigDelegateOdGiViewportTraits_62();

	public delegate void SwigDelegateOdGiViewportTraits_63(bool b);

	public delegate int SwigDelegateOdGiViewportTraits_64();

	public delegate void SwigDelegateOdGiViewportTraits_65(int arg0);

	public delegate IntPtr SwigDelegateOdGiViewportTraits_66();

	public delegate void SwigDelegateOdGiViewportTraits_67(IntPtr lightDirection);

	public delegate double SwigDelegateOdGiViewportTraits_68();

	public delegate void SwigDelegateOdGiViewportTraits_69(double dIntensity);

	public delegate IntPtr SwigDelegateOdGiViewportTraits_70();

	public delegate void SwigDelegateOdGiViewportTraits_71(IntPtr color);

	public delegate void SwigDelegateOdGiViewportTraits_72(IntPtr params_);

	public delegate void SwigDelegateOdGiViewportTraits_73(IntPtr params_);

	public delegate void SwigDelegateOdGiViewportTraits_74(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiViewportTraits_75();

	public delegate void SwigDelegateOdGiViewportTraits_76(double contrast);

	public delegate double SwigDelegateOdGiViewportTraits_77();

	public delegate void SwigDelegateOdGiViewportTraits_78(double brightness);

	public delegate double SwigDelegateOdGiViewportTraits_79();

	public delegate void SwigDelegateOdGiViewportTraits_80(IntPtr bg);

	public delegate IntPtr SwigDelegateOdGiViewportTraits_81();

	public delegate void SwigDelegateOdGiViewportTraits_82(IntPtr re);

	public delegate IntPtr SwigDelegateOdGiViewportTraits_83();

	public delegate void SwigDelegateOdGiViewportTraits_84(IntPtr rs);

	public delegate IntPtr SwigDelegateOdGiViewportTraits_85();

	public delegate void SwigDelegateOdGiViewportTraits_86(IntPtr params_);

	public delegate void SwigDelegateOdGiViewportTraits_87(IntPtr params_);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiViewportTraits_0 swigDelegate0;

	private SwigDelegateOdGiViewportTraits_1 swigDelegate1;

	private SwigDelegateOdGiViewportTraits_2 swigDelegate2;

	private SwigDelegateOdGiViewportTraits_3 swigDelegate3;

	private SwigDelegateOdGiViewportTraits_4 swigDelegate4;

	private SwigDelegateOdGiViewportTraits_5 swigDelegate5;

	private SwigDelegateOdGiViewportTraits_6 swigDelegate6;

	private SwigDelegateOdGiViewportTraits_7 swigDelegate7;

	private SwigDelegateOdGiViewportTraits_8 swigDelegate8;

	private SwigDelegateOdGiViewportTraits_9 swigDelegate9;

	private SwigDelegateOdGiViewportTraits_10 swigDelegate10;

	private SwigDelegateOdGiViewportTraits_11 swigDelegate11;

	private SwigDelegateOdGiViewportTraits_12 swigDelegate12;

	private SwigDelegateOdGiViewportTraits_13 swigDelegate13;

	private SwigDelegateOdGiViewportTraits_14 swigDelegate14;

	private SwigDelegateOdGiViewportTraits_15 swigDelegate15;

	private SwigDelegateOdGiViewportTraits_16 swigDelegate16;

	private SwigDelegateOdGiViewportTraits_17 swigDelegate17;

	private SwigDelegateOdGiViewportTraits_18 swigDelegate18;

	private SwigDelegateOdGiViewportTraits_19 swigDelegate19;

	private SwigDelegateOdGiViewportTraits_20 swigDelegate20;

	private SwigDelegateOdGiViewportTraits_21 swigDelegate21;

	private SwigDelegateOdGiViewportTraits_22 swigDelegate22;

	private SwigDelegateOdGiViewportTraits_23 swigDelegate23;

	private SwigDelegateOdGiViewportTraits_24 swigDelegate24;

	private SwigDelegateOdGiViewportTraits_25 swigDelegate25;

	private SwigDelegateOdGiViewportTraits_26 swigDelegate26;

	private SwigDelegateOdGiViewportTraits_27 swigDelegate27;

	private SwigDelegateOdGiViewportTraits_28 swigDelegate28;

	private SwigDelegateOdGiViewportTraits_29 swigDelegate29;

	private SwigDelegateOdGiViewportTraits_30 swigDelegate30;

	private SwigDelegateOdGiViewportTraits_31 swigDelegate31;

	private SwigDelegateOdGiViewportTraits_32 swigDelegate32;

	private SwigDelegateOdGiViewportTraits_33 swigDelegate33;

	private SwigDelegateOdGiViewportTraits_34 swigDelegate34;

	private SwigDelegateOdGiViewportTraits_35 swigDelegate35;

	private SwigDelegateOdGiViewportTraits_36 swigDelegate36;

	private SwigDelegateOdGiViewportTraits_37 swigDelegate37;

	private SwigDelegateOdGiViewportTraits_38 swigDelegate38;

	private SwigDelegateOdGiViewportTraits_39 swigDelegate39;

	private SwigDelegateOdGiViewportTraits_40 swigDelegate40;

	private SwigDelegateOdGiViewportTraits_41 swigDelegate41;

	private SwigDelegateOdGiViewportTraits_42 swigDelegate42;

	private SwigDelegateOdGiViewportTraits_43 swigDelegate43;

	private SwigDelegateOdGiViewportTraits_44 swigDelegate44;

	private SwigDelegateOdGiViewportTraits_45 swigDelegate45;

	private SwigDelegateOdGiViewportTraits_46 swigDelegate46;

	private SwigDelegateOdGiViewportTraits_47 swigDelegate47;

	private SwigDelegateOdGiViewportTraits_48 swigDelegate48;

	private SwigDelegateOdGiViewportTraits_49 swigDelegate49;

	private SwigDelegateOdGiViewportTraits_50 swigDelegate50;

	private SwigDelegateOdGiViewportTraits_51 swigDelegate51;

	private SwigDelegateOdGiViewportTraits_52 swigDelegate52;

	private SwigDelegateOdGiViewportTraits_53 swigDelegate53;

	private SwigDelegateOdGiViewportTraits_54 swigDelegate54;

	private SwigDelegateOdGiViewportTraits_55 swigDelegate55;

	private SwigDelegateOdGiViewportTraits_56 swigDelegate56;

	private SwigDelegateOdGiViewportTraits_57 swigDelegate57;

	private SwigDelegateOdGiViewportTraits_58 swigDelegate58;

	private SwigDelegateOdGiViewportTraits_59 swigDelegate59;

	private SwigDelegateOdGiViewportTraits_60 swigDelegate60;

	private SwigDelegateOdGiViewportTraits_61 swigDelegate61;

	private SwigDelegateOdGiViewportTraits_62 swigDelegate62;

	private SwigDelegateOdGiViewportTraits_63 swigDelegate63;

	private SwigDelegateOdGiViewportTraits_64 swigDelegate64;

	private SwigDelegateOdGiViewportTraits_65 swigDelegate65;

	private SwigDelegateOdGiViewportTraits_66 swigDelegate66;

	private SwigDelegateOdGiViewportTraits_67 swigDelegate67;

	private SwigDelegateOdGiViewportTraits_68 swigDelegate68;

	private SwigDelegateOdGiViewportTraits_69 swigDelegate69;

	private SwigDelegateOdGiViewportTraits_70 swigDelegate70;

	private SwigDelegateOdGiViewportTraits_71 swigDelegate71;

	private SwigDelegateOdGiViewportTraits_72 swigDelegate72;

	private SwigDelegateOdGiViewportTraits_73 swigDelegate73;

	private SwigDelegateOdGiViewportTraits_74 swigDelegate74;

	private SwigDelegateOdGiViewportTraits_75 swigDelegate75;

	private SwigDelegateOdGiViewportTraits_76 swigDelegate76;

	private SwigDelegateOdGiViewportTraits_77 swigDelegate77;

	private SwigDelegateOdGiViewportTraits_78 swigDelegate78;

	private SwigDelegateOdGiViewportTraits_79 swigDelegate79;

	private SwigDelegateOdGiViewportTraits_80 swigDelegate80;

	private SwigDelegateOdGiViewportTraits_81 swigDelegate81;

	private SwigDelegateOdGiViewportTraits_82 swigDelegate82;

	private SwigDelegateOdGiViewportTraits_83 swigDelegate83;

	private SwigDelegateOdGiViewportTraits_84 swigDelegate84;

	private SwigDelegateOdGiViewportTraits_85 swigDelegate85;

	private SwigDelegateOdGiViewportTraits_86 swigDelegate86;

	private SwigDelegateOdGiViewportTraits_87 swigDelegate87;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(ushort) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGiFillType) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(LineWeight) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(PlotStyleNameType),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(PlotStyleNameType) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdGiMapper) };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdCmTransparency) };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdGiSubEntityTraits_ShadowFlags) };

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdGiSubEntityTraits_SelectionFlags) };

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[0];

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes33 = new Type[0];

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[0];

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[0];

	private static Type[] swigMethodTypes38 = new Type[0];

	private static Type[] swigMethodTypes39 = new Type[0];

	private static Type[] swigMethodTypes40 = new Type[0];

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[0];

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[0];

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[0];

	private static Type[] swigMethodTypes47 = new Type[0];

	private static Type[] swigMethodTypes48 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes49 = new Type[0];

	private static Type[] swigMethodTypes50 = new Type[1] { typeof(OdGiDgLinetypeModifiers) };

	private static Type[] swigMethodTypes51 = new Type[0];

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(OdGiFill) };

	private static Type[] swigMethodTypes53 = new Type[0];

	private static Type[] swigMethodTypes54 = new Type[1] { typeof(OdGiAuxiliaryData) };

	private static Type[] swigMethodTypes55 = new Type[0];

	private static Type[] swigMethodTypes56 = new Type[1] { typeof(OdGiLineweightOverride) };

	private static Type[] swigMethodTypes57 = new Type[0];

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(OdGiPalette) };

	private static Type[] swigMethodTypes59 = new Type[0];

	private static Type[] swigMethodTypes60 = new Type[0];

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes62 = new Type[0];

	private static Type[] swigMethodTypes63 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes64 = new Type[0];

	private static Type[] swigMethodTypes65 = new Type[1] { typeof(OdGiViewportTraits_DefaultLightingType) };

	private static Type[] swigMethodTypes66 = new Type[0];

	private static Type[] swigMethodTypes67 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes68 = new Type[0];

	private static Type[] swigMethodTypes69 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes70 = new Type[0];

	private static Type[] swigMethodTypes71 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes72 = new Type[1] { typeof(OdGiShadowParameters) };

	private static Type[] swigMethodTypes73 = new Type[1] { typeof(OdGiShadowParameters) };

	private static Type[] swigMethodTypes74 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes75 = new Type[0];

	private static Type[] swigMethodTypes76 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes77 = new Type[0];

	private static Type[] swigMethodTypes78 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes79 = new Type[0];

	private static Type[] swigMethodTypes80 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes81 = new Type[0];

	private static Type[] swigMethodTypes82 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes83 = new Type[0];

	private static Type[] swigMethodTypes84 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes85 = new Type[0];

	private static Type[] swigMethodTypes86 = new Type[1] { typeof(OdGiToneOperatorParameters) };

	private static Type[] swigMethodTypes87 = new Type[1] { typeof(OdGiToneOperatorParameters).MakeByRefType() };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiViewportTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiViewportTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiViewportTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiViewportTraits cast(OdRxObject pObj)
	{
		OdGiViewportTraits rXObject = Helpers.GetRXObject<OdGiViewportTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_isASwigExplicitOdGiViewportTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_queryXSwigExplicitOdGiViewportTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiViewportTraits createObject()
	{
		OdGiViewportTraits rXObject = Helpers.GetRXObject<OdGiViewportTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isDefaultLightingOn()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_isDefaultLightingOn(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDefaultLightingOn(bool b)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setDefaultLightingOn(swigCPtr, b);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiViewportTraits_DefaultLightingType defaultLightingType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_defaultLightingType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiViewportTraits_DefaultLightingType)result;
	}

	public virtual void setDefaultLightingType(OdGiViewportTraits_DefaultLightingType arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setDefaultLightingType(swigCPtr, (int)arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeVector3d userDefinedLightDirection()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_userDefinedLightDirection(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setUserDefinedLightDirection(OdGeVector3d lightDirection)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setUserDefinedLightDirection(swigCPtr, OdGeVector3d.getCPtr(lightDirection));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double defaultLightingIntensity()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_defaultLightingIntensity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDefaultLightingIntensity(double dIntensity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setDefaultLightingIntensity(swigCPtr, dIntensity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor defaultLightingColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_defaultLightingColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDefaultLightingColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setDefaultLightingColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void defaultLightingShadowParameters(OdGiShadowParameters params_)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_defaultLightingShadowParameters(swigCPtr, OdGiShadowParameters.getCPtr(params_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDefaultLightingShadowParameters(OdGiShadowParameters params_)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setDefaultLightingShadowParameters(swigCPtr, OdGiShadowParameters.getCPtr(params_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setAmbientLightColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setAmbientLightColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor ambientLightColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_ambientLightColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setContrast(double contrast)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setContrast(swigCPtr, contrast);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double contrast()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_contrast(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBrightness(double brightness)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setBrightness(swigCPtr, brightness);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double brightness()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_brightness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBackground(OdDbStub bg)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setBackground(swigCPtr, OdDbStub.getCPtr(bg));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub background()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_background(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRenderEnvironment(OdDbStub re)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setRenderEnvironment(swigCPtr, OdDbStub.getCPtr(re));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub renderEnvironment()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_renderEnvironment(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRenderSettings(OdDbStub rs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setRenderSettings(swigCPtr, OdDbStub.getCPtr(rs));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub renderSettings()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_renderSettings(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setToneOperatorParameters(OdGiToneOperatorParameters params_)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_setToneOperatorParameters(swigCPtr, OdGiToneOperatorParameters.getCPtr(params_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void toneOperatorParameters(ref OdGiToneOperatorParameters params_)
	{
		IntPtr jarg = ((params_ == null) ? IntPtr.Zero : OdGiToneOperatorParameters.getCPtr(params_).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_toneOperatorParameters(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				params_ = null;
			}
			if (jarg != intPtr)
			{
				params_ = Helpers.GetRXObject<OdGiToneOperatorParameters>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiViewportTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiViewportTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiViewportTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetColor;
		}
		if (SwigDerivedClassHasMethod("setTrueColor", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetTrueColor;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetLayer;
		}
		if (SwigDerivedClassHasMethod("setLineType", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetLineType;
		}
		if (SwigDerivedClassHasMethod("setSelectionMarker", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetSelectionMarker;
		}
		if (SwigDerivedClassHasMethod("setFillType", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetFillType;
		}
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetFillPlane__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetFillPlane__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLineWeight", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetLineWeight;
		}
		if (SwigDerivedClassHasMethod("setLineTypeScale", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetLineTypeScale__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setLineTypeScale", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetLineTypeScale__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setThickness", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetThickness;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetPlotStyleName__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetPlotStyleName__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetMaterial;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodsetMapper;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetVisualStyle;
		}
		if (SwigDerivedClassHasMethod("setTransparency", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsetTransparency;
		}
		if (SwigDerivedClassHasMethod("setDrawFlags", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetDrawFlags;
		}
		if (SwigDerivedClassHasMethod("setLockFlags", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodsetLockFlags;
		}
		if (SwigDerivedClassHasMethod("setSelectionGeom", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodsetSelectionGeom;
		}
		if (SwigDerivedClassHasMethod("setShadowFlags", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsetShadowFlags;
		}
		if (SwigDerivedClassHasMethod("setSectionable", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetSectionable;
		}
		if (SwigDerivedClassHasMethod("setSelectionFlags", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodsetSelectionFlags;
		}
		if (SwigDerivedClassHasMethod("color", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodcolor;
		}
		if (SwigDerivedClassHasMethod("trueColor", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodtrueColor;
		}
		if (SwigDerivedClassHasMethod("layer", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodlayer;
		}
		if (SwigDerivedClassHasMethod("lineType", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodlineType;
		}
		if (SwigDerivedClassHasMethod("fillType", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodfillType;
		}
		if (SwigDerivedClassHasMethod("fillPlane", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodfillPlane;
		}
		if (SwigDerivedClassHasMethod("lineWeight", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodlineWeight;
		}
		if (SwigDerivedClassHasMethod("lineTypeScale", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodlineTypeScale;
		}
		if (SwigDerivedClassHasMethod("thickness", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodthickness;
		}
		if (SwigDerivedClassHasMethod("plotStyleNameType", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodplotStyleNameType;
		}
		if (SwigDerivedClassHasMethod("plotStyleNameId", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodplotStyleNameId;
		}
		if (SwigDerivedClassHasMethod("material", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodmaterial;
		}
		if (SwigDerivedClassHasMethod("mapper", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodmapper;
		}
		if (SwigDerivedClassHasMethod("visualStyle", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodvisualStyle;
		}
		if (SwigDerivedClassHasMethod("transparency", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodtransparency;
		}
		if (SwigDerivedClassHasMethod("drawFlags", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethoddrawFlags;
		}
		if (SwigDerivedClassHasMethod("lockFlags", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodlockFlags;
		}
		if (SwigDerivedClassHasMethod("selectionGeom", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodselectionGeom;
		}
		if (SwigDerivedClassHasMethod("shadowFlags", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodshadowFlags;
		}
		if (SwigDerivedClassHasMethod("sectionable", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodsectionable;
		}
		if (SwigDerivedClassHasMethod("selectionFlags", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodselectionFlags;
		}
		if (SwigDerivedClassHasMethod("setSecondaryTrueColor", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodsetSecondaryTrueColor;
		}
		if (SwigDerivedClassHasMethod("secondaryTrueColor", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodsecondaryTrueColor;
		}
		if (SwigDerivedClassHasMethod("setLineStyleModifiers", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodsetLineStyleModifiers;
		}
		if (SwigDerivedClassHasMethod("lineStyleModifiers", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodlineStyleModifiers;
		}
		if (SwigDerivedClassHasMethod("setFill", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodsetFill;
		}
		if (SwigDerivedClassHasMethod("fill", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodfill;
		}
		if (SwigDerivedClassHasMethod("setAuxData", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodsetAuxData;
		}
		if (SwigDerivedClassHasMethod("auxData", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodauxData;
		}
		if (SwigDerivedClassHasMethod("pushLineweightOverride", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodpushLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("popLineweightOverride", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodpopLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("pushPaletteOverride", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodpushPaletteOverride;
		}
		if (SwigDerivedClassHasMethod("popPaletteOverride", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodpopPaletteOverride;
		}
		if (SwigDerivedClassHasMethod("setupForEntity", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodsetupForEntity;
		}
		if (SwigDerivedClassHasMethod("addLight", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodaddLight;
		}
		if (SwigDerivedClassHasMethod("isDefaultLightingOn", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodisDefaultLightingOn;
		}
		if (SwigDerivedClassHasMethod("setDefaultLightingOn", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodsetDefaultLightingOn;
		}
		if (SwigDerivedClassHasMethod("defaultLightingType", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethoddefaultLightingType;
		}
		if (SwigDerivedClassHasMethod("setDefaultLightingType", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodsetDefaultLightingType;
		}
		if (SwigDerivedClassHasMethod("userDefinedLightDirection", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethoduserDefinedLightDirection;
		}
		if (SwigDerivedClassHasMethod("setUserDefinedLightDirection", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodsetUserDefinedLightDirection;
		}
		if (SwigDerivedClassHasMethod("defaultLightingIntensity", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethoddefaultLightingIntensity;
		}
		if (SwigDerivedClassHasMethod("setDefaultLightingIntensity", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodsetDefaultLightingIntensity;
		}
		if (SwigDerivedClassHasMethod("defaultLightingColor", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethoddefaultLightingColor;
		}
		if (SwigDerivedClassHasMethod("setDefaultLightingColor", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodsetDefaultLightingColor;
		}
		if (SwigDerivedClassHasMethod("defaultLightingShadowParameters", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethoddefaultLightingShadowParameters;
		}
		if (SwigDerivedClassHasMethod("setDefaultLightingShadowParameters", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodsetDefaultLightingShadowParameters;
		}
		if (SwigDerivedClassHasMethod("setAmbientLightColor", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodsetAmbientLightColor;
		}
		if (SwigDerivedClassHasMethod("ambientLightColor", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodambientLightColor;
		}
		if (SwigDerivedClassHasMethod("setContrast", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodsetContrast;
		}
		if (SwigDerivedClassHasMethod("contrast", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodcontrast;
		}
		if (SwigDerivedClassHasMethod("setBrightness", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodsetBrightness;
		}
		if (SwigDerivedClassHasMethod("brightness", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodbrightness;
		}
		if (SwigDerivedClassHasMethod("setBackground", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodsetBackground;
		}
		if (SwigDerivedClassHasMethod("background", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodbackground;
		}
		if (SwigDerivedClassHasMethod("setRenderEnvironment", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodsetRenderEnvironment;
		}
		if (SwigDerivedClassHasMethod("renderEnvironment", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodrenderEnvironment;
		}
		if (SwigDerivedClassHasMethod("setRenderSettings", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodsetRenderSettings;
		}
		if (SwigDerivedClassHasMethod("renderSettings", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodrenderSettings;
		}
		if (SwigDerivedClassHasMethod("setToneOperatorParameters", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodsetToneOperatorParameters;
		}
		if (SwigDerivedClassHasMethod("toneOperatorParameters", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodtoneOperatorParameters;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiViewportTraits));
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

	private void SwigDirectorMethodsetColor(ushort color)
	{
		try
		{
			setColor(color);
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

	private void SwigDirectorMethodsetTrueColor(IntPtr color)
	{
		try
		{
			setTrueColor(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetLayer(IntPtr layerId)
	{
		try
		{
			setLayer((layerId == IntPtr.Zero) ? null : new OdDbStub(layerId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetLineType(IntPtr lineTypeId)
	{
		try
		{
			setLineType((lineTypeId == IntPtr.Zero) ? null : new OdDbStub(lineTypeId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetSelectionMarker(IntPtr selectionMarker)
	{
		try
		{
			setSelectionMarker(selectionMarker);
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

	private void SwigDirectorMethodsetFillType(int fillType)
	{
		try
		{
			setFillType((OdGiFillType)fillType);
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

	private void SwigDirectorMethodsetFillPlane__SWIG_0(IntPtr pNormal)
	{
		try
		{
			setFillPlane((pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetFillPlane__SWIG_1()
	{
		try
		{
			setFillPlane();
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

	private void SwigDirectorMethodsetLineWeight(int lineWeight)
	{
		try
		{
			setLineWeight((LineWeight)lineWeight);
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

	private void SwigDirectorMethodsetLineTypeScale__SWIG_0(double lineTypeScale)
	{
		try
		{
			setLineTypeScale(lineTypeScale);
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

	private void SwigDirectorMethodsetLineTypeScale__SWIG_1()
	{
		try
		{
			setLineTypeScale();
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

	private void SwigDirectorMethodsetThickness(double thickness)
	{
		try
		{
			setThickness(thickness);
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

	private void SwigDirectorMethodsetPlotStyleName__SWIG_0(int plotStyleNameType, IntPtr plotStyleNameId)
	{
		try
		{
			setPlotStyleName((PlotStyleNameType)plotStyleNameType, (plotStyleNameId == IntPtr.Zero) ? null : new OdDbStub(plotStyleNameId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetPlotStyleName__SWIG_1(int plotStyleNameType)
	{
		try
		{
			setPlotStyleName((PlotStyleNameType)plotStyleNameType);
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

	private void SwigDirectorMethodsetMaterial(IntPtr materialId)
	{
		try
		{
			setMaterial((materialId == IntPtr.Zero) ? null : new OdDbStub(materialId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper(IntPtr pMapper)
	{
		try
		{
			setMapper((pMapper == IntPtr.Zero) ? null : new OdGiMapper(pMapper, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetVisualStyle(IntPtr visualStyleId)
	{
		try
		{
			setVisualStyle((visualStyleId == IntPtr.Zero) ? null : new OdDbStub(visualStyleId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetTransparency(IntPtr transparency)
	{
		try
		{
			setTransparency(new OdCmTransparency(transparency, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDrawFlags(uint drawFlags)
	{
		try
		{
			setDrawFlags(drawFlags);
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

	private void SwigDirectorMethodsetLockFlags(uint lockFlags)
	{
		try
		{
			setLockFlags(lockFlags);
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

	private void SwigDirectorMethodsetSelectionGeom(bool bSelectionFlag)
	{
		try
		{
			setSelectionGeom(bSelectionFlag);
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

	private void SwigDirectorMethodsetShadowFlags(int shadowFlags)
	{
		try
		{
			setShadowFlags((OdGiSubEntityTraits_ShadowFlags)shadowFlags);
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

	private void SwigDirectorMethodsetSectionable(bool bSectionableFlag)
	{
		try
		{
			setSectionable(bSectionableFlag);
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

	private void SwigDirectorMethodsetSelectionFlags(int selectionFlags)
	{
		try
		{
			setSelectionFlags((OdGiSubEntityTraits_SelectionFlags)selectionFlags);
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

	private ushort SwigDirectorMethodcolor()
	{
		return color();
	}

	private IntPtr SwigDirectorMethodtrueColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(trueColor()).Handle;
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

	private IntPtr SwigDirectorMethodlayer()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(layer()).Handle;
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

	private IntPtr SwigDirectorMethodlineType()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(lineType()).Handle;
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

	private int SwigDirectorMethodfillType()
	{
		return (int)fillType();
	}

	private bool SwigDirectorMethodfillPlane(IntPtr normal)
	{
		return fillPlane(new OdGeVector3d(normal, cMemoryOwn: false));
	}

	private int SwigDirectorMethodlineWeight()
	{
		return (int)lineWeight();
	}

	private double SwigDirectorMethodlineTypeScale()
	{
		return lineTypeScale();
	}

	private double SwigDirectorMethodthickness()
	{
		return thickness();
	}

	private int SwigDirectorMethodplotStyleNameType()
	{
		return (int)plotStyleNameType();
	}

	private IntPtr SwigDirectorMethodplotStyleNameId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(plotStyleNameId()).Handle;
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

	private IntPtr SwigDirectorMethodmaterial()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(material()).Handle;
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

	private IntPtr SwigDirectorMethodmapper()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiMapper.getCPtr(mapper()).Handle;
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

	private IntPtr SwigDirectorMethodvisualStyle()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(visualStyle()).Handle;
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

	private IntPtr SwigDirectorMethodtransparency()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmTransparency.getCPtr(transparency()).Handle;
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

	private uint SwigDirectorMethoddrawFlags()
	{
		return drawFlags();
	}

	private uint SwigDirectorMethodlockFlags()
	{
		return lockFlags();
	}

	private bool SwigDirectorMethodselectionGeom()
	{
		return selectionGeom();
	}

	private int SwigDirectorMethodshadowFlags()
	{
		return (int)shadowFlags();
	}

	private bool SwigDirectorMethodsectionable()
	{
		return sectionable();
	}

	private int SwigDirectorMethodselectionFlags()
	{
		return (int)selectionFlags();
	}

	private void SwigDirectorMethodsetSecondaryTrueColor(IntPtr color)
	{
		try
		{
			setSecondaryTrueColor(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodsecondaryTrueColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(secondaryTrueColor()).Handle;
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

	private void SwigDirectorMethodsetLineStyleModifiers(IntPtr pLSMod)
	{
		try
		{
			setLineStyleModifiers((pLSMod == IntPtr.Zero) ? null : new OdGiDgLinetypeModifiers(pLSMod, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodlineStyleModifiers()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiDgLinetypeModifiers.getCPtr(lineStyleModifiers()).Handle;
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

	private void SwigDirectorMethodsetFill(IntPtr pFill)
	{
		try
		{
			setFill(Helpers.GetRXObject<OdGiFill>(pFill, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodfill()
	{
		return OdGiFill.getCPtr(fill()).Handle;
	}

	private void SwigDirectorMethodsetAuxData(IntPtr pAuxData)
	{
		try
		{
			setAuxData(Helpers.GetRXObject<OdGiAuxiliaryData>(pAuxData, bOwn: true, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodauxData()
	{
		return OdGiAuxiliaryData.getCPtr(auxData()).Handle;
	}

	private bool SwigDirectorMethodpushLineweightOverride(IntPtr pOverride)
	{
		return pushLineweightOverride((pOverride == IntPtr.Zero) ? null : new OdGiLineweightOverride(pOverride, cMemoryOwn: false));
	}

	private void SwigDirectorMethodpopLineweightOverride()
	{
		try
		{
			popLineweightOverride();
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

	private bool SwigDirectorMethodpushPaletteOverride(IntPtr pOverride)
	{
		return pushPaletteOverride(Helpers.GetRXObject<OdGiPalette>(pOverride, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodpopPaletteOverride()
	{
		try
		{
			popPaletteOverride();
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

	private uint SwigDirectorMethodsetupForEntity()
	{
		return setupForEntity();
	}

	private void SwigDirectorMethodaddLight(IntPtr lightId)
	{
		try
		{
			addLight((lightId == IntPtr.Zero) ? null : new OdDbStub(lightId, cMemoryOwn: false));
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

	private bool SwigDirectorMethodisDefaultLightingOn()
	{
		return isDefaultLightingOn();
	}

	private void SwigDirectorMethodsetDefaultLightingOn(bool b)
	{
		try
		{
			setDefaultLightingOn(b);
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

	private int SwigDirectorMethoddefaultLightingType()
	{
		return (int)defaultLightingType();
	}

	private void SwigDirectorMethodsetDefaultLightingType(int arg0)
	{
		try
		{
			setDefaultLightingType((OdGiViewportTraits_DefaultLightingType)arg0);
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

	private IntPtr SwigDirectorMethoduserDefinedLightDirection()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(userDefinedLightDirection()).Handle;
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

	private void SwigDirectorMethodsetUserDefinedLightDirection(IntPtr lightDirection)
	{
		try
		{
			setUserDefinedLightDirection(new OdGeVector3d(lightDirection, cMemoryOwn: false));
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

	private double SwigDirectorMethoddefaultLightingIntensity()
	{
		return defaultLightingIntensity();
	}

	private void SwigDirectorMethodsetDefaultLightingIntensity(double dIntensity)
	{
		try
		{
			setDefaultLightingIntensity(dIntensity);
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

	private IntPtr SwigDirectorMethoddefaultLightingColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(defaultLightingColor()).Handle;
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

	private void SwigDirectorMethodsetDefaultLightingColor(IntPtr color)
	{
		try
		{
			setDefaultLightingColor(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private void SwigDirectorMethoddefaultLightingShadowParameters(IntPtr params_)
	{
		try
		{
			defaultLightingShadowParameters(new OdGiShadowParameters(params_, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDefaultLightingShadowParameters(IntPtr params_)
	{
		try
		{
			setDefaultLightingShadowParameters(new OdGiShadowParameters(params_, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetAmbientLightColor(IntPtr color)
	{
		try
		{
			setAmbientLightColor(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodambientLightColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(ambientLightColor()).Handle;
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

	private void SwigDirectorMethodsetContrast(double contrast)
	{
		try
		{
			setContrast(contrast);
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

	private double SwigDirectorMethodcontrast()
	{
		return contrast();
	}

	private void SwigDirectorMethodsetBrightness(double brightness)
	{
		try
		{
			setBrightness(brightness);
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

	private void SwigDirectorMethodsetBackground(IntPtr bg)
	{
		try
		{
			setBackground((bg == IntPtr.Zero) ? null : new OdDbStub(bg, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodbackground()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(background()).Handle;
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

	private void SwigDirectorMethodsetRenderEnvironment(IntPtr re)
	{
		try
		{
			setRenderEnvironment((re == IntPtr.Zero) ? null : new OdDbStub(re, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodrenderEnvironment()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(renderEnvironment()).Handle;
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

	private void SwigDirectorMethodsetRenderSettings(IntPtr rs)
	{
		try
		{
			setRenderSettings((rs == IntPtr.Zero) ? null : new OdDbStub(rs, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodrenderSettings()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(renderSettings()).Handle;
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

	private void SwigDirectorMethodsetToneOperatorParameters(IntPtr params_)
	{
		try
		{
			setToneOperatorParameters(Helpers.GetRXObject<OdGiToneOperatorParameters>(params_, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodtoneOperatorParameters(IntPtr params_)
	{
		OdSwigDirectorHelper.director_UnpackData(params_, out var pOriginalObject, out var pFunction);
		OdGiToneOperatorParameters params_2 = Helpers.GetRXObject<OdGiToneOperatorParameters>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			toneOperatorParameters(ref params_2);
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
			IntPtr handle = OdGiToneOperatorParameters.getCPtr(params_2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(params_);
		}
	}
}

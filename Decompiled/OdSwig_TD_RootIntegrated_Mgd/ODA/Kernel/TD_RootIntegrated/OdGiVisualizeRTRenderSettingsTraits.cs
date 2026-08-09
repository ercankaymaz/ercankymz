using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiVisualizeRTRenderSettingsTraits : OdGiRenderSettingsTraits
{
	public delegate IntPtr SwigDelegateOdGiVisualizeRTRenderSettingsTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiVisualizeRTRenderSettingsTraits_1();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_3(bool enabled);

	public delegate bool SwigDelegateOdGiVisualizeRTRenderSettingsTraits_4();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_5(bool enabled);

	public delegate bool SwigDelegateOdGiVisualizeRTRenderSettingsTraits_6();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_7(bool enabled);

	public delegate bool SwigDelegateOdGiVisualizeRTRenderSettingsTraits_8();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_9(bool enabled);

	public delegate bool SwigDelegateOdGiVisualizeRTRenderSettingsTraits_10();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_11(bool enabled);

	public delegate bool SwigDelegateOdGiVisualizeRTRenderSettingsTraits_12();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_13(double scaleFactor);

	public delegate double SwigDelegateOdGiVisualizeRTRenderSettingsTraits_14();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_15(int renderType);

	public delegate int SwigDelegateOdGiVisualizeRTRenderSettingsTraits_16();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_17(int renderQual);

	public delegate int SwigDelegateOdGiVisualizeRTRenderSettingsTraits_18();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_19(int shader);

	public delegate int SwigDelegateOdGiVisualizeRTRenderSettingsTraits_20();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_21(int texQlty);

	public delegate int SwigDelegateOdGiVisualizeRTRenderSettingsTraits_22();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_23(int nX, int nY);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_24(int nX, int nY);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_25(uint nBounces);

	public delegate uint SwigDelegateOdGiVisualizeRTRenderSettingsTraits_26();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_27(uint nRels);

	public delegate uint SwigDelegateOdGiVisualizeRTRenderSettingsTraits_28();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_29(uint nRefs);

	public delegate uint SwigDelegateOdGiVisualizeRTRenderSettingsTraits_30();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_31(int treeType, int splitMode, uint nMaxLeafPrims, uint nNodeDepth, bool bSort);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_32(int treeType, int splitMode, uint nMaxLeafPrims, uint nNodeDepth);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_33(int treeType, int splitMode, uint nMaxLeafPrims);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_34(int treeType, int splitMode);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_35(int treeType);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_36(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, uint nMaxLeafPrims, uint nNodeDepth, bool bSort);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_37(int treeType, int splitMode, uint nMaxLeafPrims, uint nNodeDepth, bool bSort);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_38(int treeType, int splitMode, uint nMaxLeafPrims, uint nNodeDepth);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_39(int treeType, int splitMode, uint nMaxLeafPrims);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_40(int treeType, int splitMode);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_41(int treeType);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_42(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, uint nMaxLeafPrims, uint nNodeDepth, bool bSort);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_43(bool bOverride, float fTol, double dTol);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_44(bool bOverride, float fTol);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_45(bool bOverride);

	public delegate bool SwigDelegateOdGiVisualizeRTRenderSettingsTraits_46(float fTol, double dTol);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_47(float fEnergy);

	public delegate float SwigDelegateOdGiVisualizeRTRenderSettingsTraits_48();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_49(bool bEnable, float fWidth);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_50(bool bEnable);

	public delegate bool SwigDelegateOdGiVisualizeRTRenderSettingsTraits_51(float fWidth);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_52(uint nThreads);

	public delegate uint SwigDelegateOdGiVisualizeRTRenderSettingsTraits_53();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_54(uint nWidth, uint nHeight);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_55(uint nWidth, uint nHeight);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_56(int order);

	public delegate int SwigDelegateOdGiVisualizeRTRenderSettingsTraits_57();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_58(uint nSubdivs);

	public delegate uint SwigDelegateOdGiVisualizeRTRenderSettingsTraits_59();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_60(uint nWidth, uint nHeight);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_61(uint nWidth, uint nHeight);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_62(uint nPercs);

	public delegate uint SwigDelegateOdGiVisualizeRTRenderSettingsTraits_63();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_64(uint nThreads);

	public delegate uint SwigDelegateOdGiVisualizeRTRenderSettingsTraits_65();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_66(bool bEnable);

	public delegate bool SwigDelegateOdGiVisualizeRTRenderSettingsTraits_67();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_68(bool bEnable);

	public delegate bool SwigDelegateOdGiVisualizeRTRenderSettingsTraits_69();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_70(uint nComponents);

	public delegate uint SwigDelegateOdGiVisualizeRTRenderSettingsTraits_71();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_72(float refCutoff);

	public delegate float SwigDelegateOdGiVisualizeRTRenderSettingsTraits_73();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_74(float refCutoff);

	public delegate float SwigDelegateOdGiVisualizeRTRenderSettingsTraits_75();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_76(float lightCutoff);

	public delegate float SwigDelegateOdGiVisualizeRTRenderSettingsTraits_77();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_78(int shadowType);

	public delegate int SwigDelegateOdGiVisualizeRTRenderSettingsTraits_79();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_80(bool bSet);

	public delegate bool SwigDelegateOdGiVisualizeRTRenderSettingsTraits_81();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_82(int nX, int nY);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_83(int nX, int nY);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_84(float fRad);

	public delegate float SwigDelegateOdGiVisualizeRTRenderSettingsTraits_85();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_86(bool bSet);

	public delegate bool SwigDelegateOdGiVisualizeRTRenderSettingsTraits_87();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_88(float fPerc);

	public delegate float SwigDelegateOdGiVisualizeRTRenderSettingsTraits_89();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_90(float fCoef);

	public delegate float SwigDelegateOdGiVisualizeRTRenderSettingsTraits_91();

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_92(int nX, int nY);

	public delegate void SwigDelegateOdGiVisualizeRTRenderSettingsTraits_93(int nX, int nY);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_0 swigDelegate0;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_1 swigDelegate1;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_2 swigDelegate2;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_3 swigDelegate3;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_4 swigDelegate4;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_5 swigDelegate5;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_6 swigDelegate6;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_7 swigDelegate7;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_8 swigDelegate8;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_9 swigDelegate9;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_10 swigDelegate10;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_11 swigDelegate11;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_12 swigDelegate12;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_13 swigDelegate13;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_14 swigDelegate14;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_15 swigDelegate15;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_16 swigDelegate16;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_17 swigDelegate17;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_18 swigDelegate18;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_19 swigDelegate19;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_20 swigDelegate20;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_21 swigDelegate21;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_22 swigDelegate22;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_23 swigDelegate23;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_24 swigDelegate24;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_25 swigDelegate25;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_26 swigDelegate26;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_27 swigDelegate27;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_28 swigDelegate28;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_29 swigDelegate29;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_30 swigDelegate30;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_31 swigDelegate31;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_32 swigDelegate32;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_33 swigDelegate33;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_34 swigDelegate34;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_35 swigDelegate35;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_36 swigDelegate36;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_37 swigDelegate37;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_38 swigDelegate38;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_39 swigDelegate39;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_40 swigDelegate40;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_41 swigDelegate41;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_42 swigDelegate42;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_43 swigDelegate43;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_44 swigDelegate44;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_45 swigDelegate45;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_46 swigDelegate46;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_47 swigDelegate47;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_48 swigDelegate48;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_49 swigDelegate49;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_50 swigDelegate50;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_51 swigDelegate51;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_52 swigDelegate52;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_53 swigDelegate53;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_54 swigDelegate54;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_55 swigDelegate55;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_56 swigDelegate56;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_57 swigDelegate57;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_58 swigDelegate58;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_59 swigDelegate59;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_60 swigDelegate60;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_61 swigDelegate61;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_62 swigDelegate62;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_63 swigDelegate63;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_64 swigDelegate64;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_65 swigDelegate65;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_66 swigDelegate66;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_67 swigDelegate67;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_68 swigDelegate68;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_69 swigDelegate69;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_70 swigDelegate70;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_71 swigDelegate71;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_72 swigDelegate72;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_73 swigDelegate73;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_74 swigDelegate74;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_75 swigDelegate75;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_76 swigDelegate76;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_77 swigDelegate77;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_78 swigDelegate78;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_79 swigDelegate79;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_80 swigDelegate80;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_81 swigDelegate81;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_82 swigDelegate82;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_83 swigDelegate83;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_84 swigDelegate84;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_85 swigDelegate85;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_86 swigDelegate86;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_87 swigDelegate87;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_88 swigDelegate88;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_89 swigDelegate89;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_90 swigDelegate90;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_91 swigDelegate91;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_92 swigDelegate92;

	private SwigDelegateOdGiVisualizeRTRenderSettingsTraits_93 swigDelegate93;

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

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdGiVisualizeRTRenderSettingsTraits_RendererType) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGiVisualizeRTRenderSettingsTraits_QualityLevel) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdGiVisualizeRTRenderSettingsTraits_DefaultShader) };

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGiVisualizeRTRenderSettingsTraits_TextureQuality) };

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes24 = new Type[2]
	{
		typeof(int).MakeByRefType(),
		typeof(int).MakeByRefType()
	};

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes30 = new Type[0];

	private static Type[] swigMethodTypes31 = new Type[5]
	{
		typeof(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType),
		typeof(OdGiVisualizeRTRenderSettingsTraits_SplitMethod),
		typeof(uint),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes32 = new Type[4]
	{
		typeof(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType),
		typeof(OdGiVisualizeRTRenderSettingsTraits_SplitMethod),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes33 = new Type[3]
	{
		typeof(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType),
		typeof(OdGiVisualizeRTRenderSettingsTraits_SplitMethod),
		typeof(uint)
	};

	private static Type[] swigMethodTypes34 = new Type[2]
	{
		typeof(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType),
		typeof(OdGiVisualizeRTRenderSettingsTraits_SplitMethod)
	};

	private static Type[] swigMethodTypes35 = new Type[1] { typeof(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType) };

	private static Type[] swigMethodTypes36 = new Type[5]
	{
		typeof(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType).MakeByRefType(),
		typeof(OdGiVisualizeRTRenderSettingsTraits_SplitMethod).MakeByRefType(),
		typeof(uint).MakeByRefType(),
		typeof(uint).MakeByRefType(),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes37 = new Type[5]
	{
		typeof(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType),
		typeof(OdGiVisualizeRTRenderSettingsTraits_SplitMethod),
		typeof(uint),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes38 = new Type[4]
	{
		typeof(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType),
		typeof(OdGiVisualizeRTRenderSettingsTraits_SplitMethod),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes39 = new Type[3]
	{
		typeof(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType),
		typeof(OdGiVisualizeRTRenderSettingsTraits_SplitMethod),
		typeof(uint)
	};

	private static Type[] swigMethodTypes40 = new Type[2]
	{
		typeof(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType),
		typeof(OdGiVisualizeRTRenderSettingsTraits_SplitMethod)
	};

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType) };

	private static Type[] swigMethodTypes42 = new Type[5]
	{
		typeof(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType).MakeByRefType(),
		typeof(OdGiVisualizeRTRenderSettingsTraits_SplitMethod).MakeByRefType(),
		typeof(uint).MakeByRefType(),
		typeof(uint).MakeByRefType(),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes43 = new Type[3]
	{
		typeof(bool),
		typeof(float),
		typeof(double)
	};

	private static Type[] swigMethodTypes44 = new Type[2]
	{
		typeof(bool),
		typeof(float)
	};

	private static Type[] swigMethodTypes45 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes46 = new Type[2]
	{
		typeof(float).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(float) };

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[2]
	{
		typeof(bool),
		typeof(float)
	};

	private static Type[] swigMethodTypes50 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(float).MakeByRefType() };

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes53 = new Type[0];

	private static Type[] swigMethodTypes54 = new Type[2]
	{
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes55 = new Type[2]
	{
		typeof(uint).MakeByRefType(),
		typeof(uint).MakeByRefType()
	};

	private static Type[] swigMethodTypes56 = new Type[1] { typeof(OdGiMrTileOrder_) };

	private static Type[] swigMethodTypes57 = new Type[0];

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes59 = new Type[0];

	private static Type[] swigMethodTypes60 = new Type[2]
	{
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes61 = new Type[2]
	{
		typeof(uint).MakeByRefType(),
		typeof(uint).MakeByRefType()
	};

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes63 = new Type[0];

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes65 = new Type[0];

	private static Type[] swigMethodTypes66 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes67 = new Type[0];

	private static Type[] swigMethodTypes68 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes69 = new Type[0];

	private static Type[] swigMethodTypes70 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes71 = new Type[0];

	private static Type[] swigMethodTypes72 = new Type[1] { typeof(float) };

	private static Type[] swigMethodTypes73 = new Type[0];

	private static Type[] swigMethodTypes74 = new Type[1] { typeof(float) };

	private static Type[] swigMethodTypes75 = new Type[0];

	private static Type[] swigMethodTypes76 = new Type[1] { typeof(float) };

	private static Type[] swigMethodTypes77 = new Type[0];

	private static Type[] swigMethodTypes78 = new Type[1] { typeof(OdGiVisualizeRTRenderSettingsTraits_ShadowTypeOverride) };

	private static Type[] swigMethodTypes79 = new Type[0];

	private static Type[] swigMethodTypes80 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes81 = new Type[0];

	private static Type[] swigMethodTypes82 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes83 = new Type[2]
	{
		typeof(int).MakeByRefType(),
		typeof(int).MakeByRefType()
	};

	private static Type[] swigMethodTypes84 = new Type[1] { typeof(float) };

	private static Type[] swigMethodTypes85 = new Type[0];

	private static Type[] swigMethodTypes86 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes87 = new Type[0];

	private static Type[] swigMethodTypes88 = new Type[1] { typeof(float) };

	private static Type[] swigMethodTypes89 = new Type[0];

	private static Type[] swigMethodTypes90 = new Type[1] { typeof(float) };

	private static Type[] swigMethodTypes91 = new Type[0];

	private static Type[] swigMethodTypes92 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes93 = new Type[2]
	{
		typeof(int).MakeByRefType(),
		typeof(int).MakeByRefType()
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiVisualizeRTRenderSettingsTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiVisualizeRTRenderSettingsTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiVisualizeRTRenderSettingsTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiVisualizeRTRenderSettingsTraits cast(OdRxObject pObj)
	{
		OdGiVisualizeRTRenderSettingsTraits rXObject = Helpers.GetRXObject<OdGiVisualizeRTRenderSettingsTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_isASwigExplicitOdGiVisualizeRTRenderSettingsTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_queryXSwigExplicitOdGiVisualizeRTRenderSettingsTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiVisualizeRTRenderSettingsTraits createObject()
	{
		OdGiVisualizeRTRenderSettingsTraits rXObject = Helpers.GetRXObject<OdGiVisualizeRTRenderSettingsTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setRendererType(OdGiVisualizeRTRenderSettingsTraits_RendererType renderType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setRendererType(swigCPtr, (int)renderType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiVisualizeRTRenderSettingsTraits_RendererType rendererType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_rendererType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualizeRTRenderSettingsTraits_RendererType)result;
	}

	public virtual void setRenderQuality(OdGiVisualizeRTRenderSettingsTraits_QualityLevel renderQual)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setRenderQuality(swigCPtr, (int)renderQual);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiVisualizeRTRenderSettingsTraits_QualityLevel renderQuality()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_renderQuality(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualizeRTRenderSettingsTraits_QualityLevel)result;
	}

	public virtual void setDefaultShader(OdGiVisualizeRTRenderSettingsTraits_DefaultShader shader)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setDefaultShader(swigCPtr, (int)shader);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiVisualizeRTRenderSettingsTraits_DefaultShader defaultShader()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_defaultShader(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualizeRTRenderSettingsTraits_DefaultShader)result;
	}

	public virtual void setTextureQuality(OdGiVisualizeRTRenderSettingsTraits_TextureQuality texQlty)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setTextureQuality(swigCPtr, (int)texQlty);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiVisualizeRTRenderSettingsTraits_TextureQuality textureQuality()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_textureQuality(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualizeRTRenderSettingsTraits_TextureQuality)result;
	}

	public virtual void setPixelSamples(int nX, int nY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setPixelSamples(swigCPtr, nX, nY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pixelSamples(out int nX, out int nY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_pixelSamples(swigCPtr, out nX, out nY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMaxBounces(uint nBounces)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setMaxBounces(swigCPtr, nBounces);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint maxBounces()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_maxBounces(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMaxSelfReflections(uint nRels)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setMaxSelfReflections(swigCPtr, nRels);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint maxSelfReflections()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_maxSelfReflections(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMaxSelfRefractions(uint nRefs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setMaxSelfRefractions(swigCPtr, nRefs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint maxSelfRefractions()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_maxSelfRefractions(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGeometryAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, uint nMaxLeafPrims, uint nNodeDepth, bool bSort)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGeometryAccelerator__SWIG_0(swigCPtr, (int)treeType, (int)splitMode, nMaxLeafPrims, nNodeDepth, bSort);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGeometryAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, uint nMaxLeafPrims, uint nNodeDepth)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGeometryAccelerator__SWIG_1(swigCPtr, (int)treeType, (int)splitMode, nMaxLeafPrims, nNodeDepth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGeometryAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, uint nMaxLeafPrims)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGeometryAccelerator__SWIG_2(swigCPtr, (int)treeType, (int)splitMode, nMaxLeafPrims);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGeometryAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGeometryAccelerator__SWIG_3(swigCPtr, (int)treeType, (int)splitMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGeometryAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGeometryAccelerator__SWIG_4(swigCPtr, (int)treeType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void geometryAccelerator(out OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, out OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, out uint nMaxLeafPrims, out uint nNodeDepth, out bool bSort)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_geometryAccelerator(swigCPtr, out treeType, out splitMode, out nMaxLeafPrims, out nNodeDepth, out bSort);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPrimitiveAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, uint nMaxLeafPrims, uint nNodeDepth, bool bSort)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setPrimitiveAccelerator__SWIG_0(swigCPtr, (int)treeType, (int)splitMode, nMaxLeafPrims, nNodeDepth, bSort);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPrimitiveAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, uint nMaxLeafPrims, uint nNodeDepth)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setPrimitiveAccelerator__SWIG_1(swigCPtr, (int)treeType, (int)splitMode, nMaxLeafPrims, nNodeDepth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPrimitiveAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, uint nMaxLeafPrims)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setPrimitiveAccelerator__SWIG_2(swigCPtr, (int)treeType, (int)splitMode, nMaxLeafPrims);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPrimitiveAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setPrimitiveAccelerator__SWIG_3(swigCPtr, (int)treeType, (int)splitMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPrimitiveAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setPrimitiveAccelerator__SWIG_4(swigCPtr, (int)treeType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void primitiveAccelerator(out OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, out OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, out uint nMaxLeafPrims, out uint nNodeDepth, out bool bSort)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_primitiveAccelerator(swigCPtr, out treeType, out splitMode, out nMaxLeafPrims, out nNodeDepth, out bSort);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setToleranceOverride(bool bOverride, float fTol, double dTol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setToleranceOverride__SWIG_0(swigCPtr, bOverride, fTol, dTol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setToleranceOverride(bool bOverride, float fTol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setToleranceOverride__SWIG_1(swigCPtr, bOverride, fTol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setToleranceOverride(bool bOverride)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setToleranceOverride__SWIG_2(swigCPtr, bOverride);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool toleranceOverride(out float fTol, out double dTol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_toleranceOverride(swigCPtr, out fTol, out dTol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMinEnergy(float fEnergy)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setMinEnergy(swigCPtr, fEnergy);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual float minEnergy()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_minEnergy(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLinePrimitivesEnabled(bool bEnable, float fWidth)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setLinePrimitivesEnabled__SWIG_0(swigCPtr, bEnable, fWidth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLinePrimitivesEnabled(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setLinePrimitivesEnabled__SWIG_1(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool linePrimitivesEnabled(out float fWidth)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_linePrimitivesEnabled(swigCPtr, out fWidth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMaxCPUThreads(uint nThreads)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setMaxCPUThreads(swigCPtr, nThreads);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint maxCPUThreads()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_maxCPUThreads(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTileSize(uint nWidth, uint nHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setTileSize(swigCPtr, nWidth, nHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void tileSize(out uint nWidth, out uint nHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_tileSize(swigCPtr, out nWidth, out nHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTileOrder(OdGiMrTileOrder_ order)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setTileOrder(swigCPtr, (int)order);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMrTileOrder_ tileOrder()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_tileOrder(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrTileOrder_)result;
	}

	public virtual void setMaxGPUBufferSubdivisions(uint nSubdivs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setMaxGPUBufferSubdivisions(swigCPtr, nSubdivs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint maxGPUBufferSubdivisions()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_maxGPUBufferSubdivisions(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMinGPUBufferSubdivisionSize(uint nWidth, uint nHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setMinGPUBufferSubdivisionSize(swigCPtr, nWidth, nHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void minGPUBufferSubdivisionSize(out uint nWidth, out uint nHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_minGPUBufferSubdivisionSize(swigCPtr, out nWidth, out nHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGPUBufferScalePercents(uint nPercs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGPUBufferScalePercents(swigCPtr, nPercs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint gpuBufferScalePercents()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_gpuBufferScalePercents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGPUWorkGroupSize(uint nThreads)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGPUWorkGroupSize(swigCPtr, nThreads);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint gpuWorkGroupSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_gpuWorkGroupSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGPUTiledRendering(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGPUTiledRendering(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool gpuTiledRendering()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_gpuTiledRendering(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGPUForceShadowMapsInsideReflections(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGPUForceShadowMapsInsideReflections(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool gpuForceShadowMapsInsideReflections()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_gpuForceShadowMapsInsideReflections(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPartialRenderComponents(uint nComponents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setPartialRenderComponents(swigCPtr, nComponents);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint partialRenderComponents()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_partialRenderComponents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMinimalReflectionCutoff(float refCutoff)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setMinimalReflectionCutoff(swigCPtr, refCutoff);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual float minimalReflectionCutoff()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_minimalReflectionCutoff(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMinimalRefractionCutoff(float refCutoff)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setMinimalRefractionCutoff(swigCPtr, refCutoff);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual float minimalRefractionCutoff()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_minimalRefractionCutoff(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMinimalLightingCutoff(float lightCutoff)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setMinimalLightingCutoff(swigCPtr, lightCutoff);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual float minimalLightingCutoff()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_minimalLightingCutoff(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setShadowTypeOverride(OdGiVisualizeRTRenderSettingsTraits_ShadowTypeOverride shadowType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setShadowTypeOverride(swigCPtr, (int)shadowType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiVisualizeRTRenderSettingsTraits_ShadowTypeOverride shadowTypeOverride()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_shadowTypeOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualizeRTRenderSettingsTraits_ShadowTypeOverride)result;
	}

	public virtual void setGlobalIlluminationEnabled(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGlobalIlluminationEnabled(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool globalIlluminationEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_globalIlluminationEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGlobalIlluminationSamples(int nX, int nY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGlobalIlluminationSamples(swigCPtr, nX, nY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void globalIlluminationSamples(out int nX, out int nY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_globalIlluminationSamples(swigCPtr, out nX, out nY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGlobalIlluminationRadius(float fRad)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGlobalIlluminationRadius(swigCPtr, fRad);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual float globalIlluminationRadius()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_globalIlluminationRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGlobalIlluminationAutoRadiusEnabled(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGlobalIlluminationAutoRadiusEnabled(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool globalIlluminationAutoRadiusEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_globalIlluminationAutoRadiusEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGlobalIlluminationAutoRadiusPercents(float fPerc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGlobalIlluminationAutoRadiusPercents(swigCPtr, fPerc);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual float globalIlluminationAutoRadiusPercents()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_globalIlluminationAutoRadiusPercents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGlobalIlluminationOcclusionCoefficient(float fCoef)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setGlobalIlluminationOcclusionCoefficient(swigCPtr, fCoef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual float globalIlluminationOcclusionCoefficient()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_globalIlluminationOcclusionCoefficient(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRoughnessSamples(int nX, int nY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_setRoughnessSamples(swigCPtr, nX, nY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void roughnessSamples(out int nX, out int nY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_roughnessSamples(swigCPtr, out nX, out nY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiVisualizeRTRenderSettingsTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiVisualizeRTRenderSettingsTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiVisualizeRTRenderSettingsTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setRendererType", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetRendererType;
		}
		if (SwigDerivedClassHasMethod("rendererType", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodrendererType;
		}
		if (SwigDerivedClassHasMethod("setRenderQuality", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetRenderQuality;
		}
		if (SwigDerivedClassHasMethod("renderQuality", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodrenderQuality;
		}
		if (SwigDerivedClassHasMethod("setDefaultShader", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetDefaultShader;
		}
		if (SwigDerivedClassHasMethod("defaultShader", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethoddefaultShader;
		}
		if (SwigDerivedClassHasMethod("setTextureQuality", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetTextureQuality;
		}
		if (SwigDerivedClassHasMethod("textureQuality", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodtextureQuality;
		}
		if (SwigDerivedClassHasMethod("setPixelSamples", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodsetPixelSamples;
		}
		if (SwigDerivedClassHasMethod("pixelSamples", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodpixelSamples;
		}
		if (SwigDerivedClassHasMethod("setMaxBounces", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetMaxBounces;
		}
		if (SwigDerivedClassHasMethod("maxBounces", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodmaxBounces;
		}
		if (SwigDerivedClassHasMethod("setMaxSelfReflections", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodsetMaxSelfReflections;
		}
		if (SwigDerivedClassHasMethod("maxSelfReflections", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodmaxSelfReflections;
		}
		if (SwigDerivedClassHasMethod("setMaxSelfRefractions", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodsetMaxSelfRefractions;
		}
		if (SwigDerivedClassHasMethod("maxSelfRefractions", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodmaxSelfRefractions;
		}
		if (SwigDerivedClassHasMethod("setGeometryAccelerator", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodsetGeometryAccelerator__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setGeometryAccelerator", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodsetGeometryAccelerator__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setGeometryAccelerator", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodsetGeometryAccelerator__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setGeometryAccelerator", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodsetGeometryAccelerator__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setGeometryAccelerator", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodsetGeometryAccelerator__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("geometryAccelerator", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodgeometryAccelerator;
		}
		if (SwigDerivedClassHasMethod("setPrimitiveAccelerator", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodsetPrimitiveAccelerator__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setPrimitiveAccelerator", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodsetPrimitiveAccelerator__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setPrimitiveAccelerator", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodsetPrimitiveAccelerator__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setPrimitiveAccelerator", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodsetPrimitiveAccelerator__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setPrimitiveAccelerator", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodsetPrimitiveAccelerator__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("primitiveAccelerator", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodprimitiveAccelerator;
		}
		if (SwigDerivedClassHasMethod("setToleranceOverride", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodsetToleranceOverride__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setToleranceOverride", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodsetToleranceOverride__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setToleranceOverride", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodsetToleranceOverride__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("toleranceOverride", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodtoleranceOverride;
		}
		if (SwigDerivedClassHasMethod("setMinEnergy", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodsetMinEnergy;
		}
		if (SwigDerivedClassHasMethod("minEnergy", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodminEnergy;
		}
		if (SwigDerivedClassHasMethod("setLinePrimitivesEnabled", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodsetLinePrimitivesEnabled__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setLinePrimitivesEnabled", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodsetLinePrimitivesEnabled__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("linePrimitivesEnabled", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodlinePrimitivesEnabled;
		}
		if (SwigDerivedClassHasMethod("setMaxCPUThreads", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodsetMaxCPUThreads;
		}
		if (SwigDerivedClassHasMethod("maxCPUThreads", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodmaxCPUThreads;
		}
		if (SwigDerivedClassHasMethod("setTileSize", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodsetTileSize;
		}
		if (SwigDerivedClassHasMethod("tileSize", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodtileSize;
		}
		if (SwigDerivedClassHasMethod("setTileOrder", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodsetTileOrder;
		}
		if (SwigDerivedClassHasMethod("tileOrder", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodtileOrder;
		}
		if (SwigDerivedClassHasMethod("setMaxGPUBufferSubdivisions", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodsetMaxGPUBufferSubdivisions;
		}
		if (SwigDerivedClassHasMethod("maxGPUBufferSubdivisions", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodmaxGPUBufferSubdivisions;
		}
		if (SwigDerivedClassHasMethod("setMinGPUBufferSubdivisionSize", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodsetMinGPUBufferSubdivisionSize;
		}
		if (SwigDerivedClassHasMethod("minGPUBufferSubdivisionSize", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodminGPUBufferSubdivisionSize;
		}
		if (SwigDerivedClassHasMethod("setGPUBufferScalePercents", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodsetGPUBufferScalePercents;
		}
		if (SwigDerivedClassHasMethod("gpuBufferScalePercents", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodgpuBufferScalePercents;
		}
		if (SwigDerivedClassHasMethod("setGPUWorkGroupSize", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodsetGPUWorkGroupSize;
		}
		if (SwigDerivedClassHasMethod("gpuWorkGroupSize", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodgpuWorkGroupSize;
		}
		if (SwigDerivedClassHasMethod("setGPUTiledRendering", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodsetGPUTiledRendering;
		}
		if (SwigDerivedClassHasMethod("gpuTiledRendering", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodgpuTiledRendering;
		}
		if (SwigDerivedClassHasMethod("setGPUForceShadowMapsInsideReflections", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodsetGPUForceShadowMapsInsideReflections;
		}
		if (SwigDerivedClassHasMethod("gpuForceShadowMapsInsideReflections", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodgpuForceShadowMapsInsideReflections;
		}
		if (SwigDerivedClassHasMethod("setPartialRenderComponents", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodsetPartialRenderComponents;
		}
		if (SwigDerivedClassHasMethod("partialRenderComponents", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodpartialRenderComponents;
		}
		if (SwigDerivedClassHasMethod("setMinimalReflectionCutoff", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodsetMinimalReflectionCutoff;
		}
		if (SwigDerivedClassHasMethod("minimalReflectionCutoff", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodminimalReflectionCutoff;
		}
		if (SwigDerivedClassHasMethod("setMinimalRefractionCutoff", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodsetMinimalRefractionCutoff;
		}
		if (SwigDerivedClassHasMethod("minimalRefractionCutoff", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodminimalRefractionCutoff;
		}
		if (SwigDerivedClassHasMethod("setMinimalLightingCutoff", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodsetMinimalLightingCutoff;
		}
		if (SwigDerivedClassHasMethod("minimalLightingCutoff", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodminimalLightingCutoff;
		}
		if (SwigDerivedClassHasMethod("setShadowTypeOverride", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodsetShadowTypeOverride;
		}
		if (SwigDerivedClassHasMethod("shadowTypeOverride", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodshadowTypeOverride;
		}
		if (SwigDerivedClassHasMethod("setGlobalIlluminationEnabled", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodsetGlobalIlluminationEnabled;
		}
		if (SwigDerivedClassHasMethod("globalIlluminationEnabled", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodglobalIlluminationEnabled;
		}
		if (SwigDerivedClassHasMethod("setGlobalIlluminationSamples", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodsetGlobalIlluminationSamples;
		}
		if (SwigDerivedClassHasMethod("globalIlluminationSamples", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodglobalIlluminationSamples;
		}
		if (SwigDerivedClassHasMethod("setGlobalIlluminationRadius", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodsetGlobalIlluminationRadius;
		}
		if (SwigDerivedClassHasMethod("globalIlluminationRadius", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodglobalIlluminationRadius;
		}
		if (SwigDerivedClassHasMethod("setGlobalIlluminationAutoRadiusEnabled", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodsetGlobalIlluminationAutoRadiusEnabled;
		}
		if (SwigDerivedClassHasMethod("globalIlluminationAutoRadiusEnabled", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodglobalIlluminationAutoRadiusEnabled;
		}
		if (SwigDerivedClassHasMethod("setGlobalIlluminationAutoRadiusPercents", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodsetGlobalIlluminationAutoRadiusPercents;
		}
		if (SwigDerivedClassHasMethod("globalIlluminationAutoRadiusPercents", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodglobalIlluminationAutoRadiusPercents;
		}
		if (SwigDerivedClassHasMethod("setGlobalIlluminationOcclusionCoefficient", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodsetGlobalIlluminationOcclusionCoefficient;
		}
		if (SwigDerivedClassHasMethod("globalIlluminationOcclusionCoefficient", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodglobalIlluminationOcclusionCoefficient;
		}
		if (SwigDerivedClassHasMethod("setRoughnessSamples", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodsetRoughnessSamples;
		}
		if (SwigDerivedClassHasMethod("roughnessSamples", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodroughnessSamples;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualizeRTRenderSettingsTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiVisualizeRTRenderSettingsTraits));
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

	private void SwigDirectorMethodsetRendererType(int renderType)
	{
		try
		{
			setRendererType((OdGiVisualizeRTRenderSettingsTraits_RendererType)renderType);
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

	private int SwigDirectorMethodrendererType()
	{
		return (int)rendererType();
	}

	private void SwigDirectorMethodsetRenderQuality(int renderQual)
	{
		try
		{
			setRenderQuality((OdGiVisualizeRTRenderSettingsTraits_QualityLevel)renderQual);
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

	private int SwigDirectorMethodrenderQuality()
	{
		return (int)renderQuality();
	}

	private void SwigDirectorMethodsetDefaultShader(int shader)
	{
		try
		{
			setDefaultShader((OdGiVisualizeRTRenderSettingsTraits_DefaultShader)shader);
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

	private int SwigDirectorMethoddefaultShader()
	{
		return (int)defaultShader();
	}

	private void SwigDirectorMethodsetTextureQuality(int texQlty)
	{
		try
		{
			setTextureQuality((OdGiVisualizeRTRenderSettingsTraits_TextureQuality)texQlty);
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

	private int SwigDirectorMethodtextureQuality()
	{
		return (int)textureQuality();
	}

	private void SwigDirectorMethodsetPixelSamples(int nX, int nY)
	{
		try
		{
			setPixelSamples(nX, nY);
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

	private void SwigDirectorMethodpixelSamples(int nX, int nY)
	{
		try
		{
			pixelSamples(out nX, out nY);
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

	private void SwigDirectorMethodsetMaxBounces(uint nBounces)
	{
		try
		{
			setMaxBounces(nBounces);
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

	private uint SwigDirectorMethodmaxBounces()
	{
		return maxBounces();
	}

	private void SwigDirectorMethodsetMaxSelfReflections(uint nRels)
	{
		try
		{
			setMaxSelfReflections(nRels);
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

	private uint SwigDirectorMethodmaxSelfReflections()
	{
		return maxSelfReflections();
	}

	private void SwigDirectorMethodsetMaxSelfRefractions(uint nRefs)
	{
		try
		{
			setMaxSelfRefractions(nRefs);
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

	private uint SwigDirectorMethodmaxSelfRefractions()
	{
		return maxSelfRefractions();
	}

	private void SwigDirectorMethodsetGeometryAccelerator__SWIG_0(int treeType, int splitMode, uint nMaxLeafPrims, uint nNodeDepth, bool bSort)
	{
		try
		{
			setGeometryAccelerator((OdGiVisualizeRTRenderSettingsTraits_AcceleratorType)treeType, (OdGiVisualizeRTRenderSettingsTraits_SplitMethod)splitMode, nMaxLeafPrims, nNodeDepth, bSort);
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

	private void SwigDirectorMethodsetGeometryAccelerator__SWIG_1(int treeType, int splitMode, uint nMaxLeafPrims, uint nNodeDepth)
	{
		try
		{
			setGeometryAccelerator((OdGiVisualizeRTRenderSettingsTraits_AcceleratorType)treeType, (OdGiVisualizeRTRenderSettingsTraits_SplitMethod)splitMode, nMaxLeafPrims, nNodeDepth);
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

	private void SwigDirectorMethodsetGeometryAccelerator__SWIG_2(int treeType, int splitMode, uint nMaxLeafPrims)
	{
		try
		{
			setGeometryAccelerator((OdGiVisualizeRTRenderSettingsTraits_AcceleratorType)treeType, (OdGiVisualizeRTRenderSettingsTraits_SplitMethod)splitMode, nMaxLeafPrims);
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

	private void SwigDirectorMethodsetGeometryAccelerator__SWIG_3(int treeType, int splitMode)
	{
		try
		{
			setGeometryAccelerator((OdGiVisualizeRTRenderSettingsTraits_AcceleratorType)treeType, (OdGiVisualizeRTRenderSettingsTraits_SplitMethod)splitMode);
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

	private void SwigDirectorMethodsetGeometryAccelerator__SWIG_4(int treeType)
	{
		try
		{
			setGeometryAccelerator((OdGiVisualizeRTRenderSettingsTraits_AcceleratorType)treeType);
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

	private void SwigDirectorMethodgeometryAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, uint nMaxLeafPrims, uint nNodeDepth, bool bSort)
	{
		try
		{
			geometryAccelerator(out treeType, out splitMode, out nMaxLeafPrims, out nNodeDepth, out bSort);
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

	private void SwigDirectorMethodsetPrimitiveAccelerator__SWIG_0(int treeType, int splitMode, uint nMaxLeafPrims, uint nNodeDepth, bool bSort)
	{
		try
		{
			setPrimitiveAccelerator((OdGiVisualizeRTRenderSettingsTraits_AcceleratorType)treeType, (OdGiVisualizeRTRenderSettingsTraits_SplitMethod)splitMode, nMaxLeafPrims, nNodeDepth, bSort);
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

	private void SwigDirectorMethodsetPrimitiveAccelerator__SWIG_1(int treeType, int splitMode, uint nMaxLeafPrims, uint nNodeDepth)
	{
		try
		{
			setPrimitiveAccelerator((OdGiVisualizeRTRenderSettingsTraits_AcceleratorType)treeType, (OdGiVisualizeRTRenderSettingsTraits_SplitMethod)splitMode, nMaxLeafPrims, nNodeDepth);
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

	private void SwigDirectorMethodsetPrimitiveAccelerator__SWIG_2(int treeType, int splitMode, uint nMaxLeafPrims)
	{
		try
		{
			setPrimitiveAccelerator((OdGiVisualizeRTRenderSettingsTraits_AcceleratorType)treeType, (OdGiVisualizeRTRenderSettingsTraits_SplitMethod)splitMode, nMaxLeafPrims);
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

	private void SwigDirectorMethodsetPrimitiveAccelerator__SWIG_3(int treeType, int splitMode)
	{
		try
		{
			setPrimitiveAccelerator((OdGiVisualizeRTRenderSettingsTraits_AcceleratorType)treeType, (OdGiVisualizeRTRenderSettingsTraits_SplitMethod)splitMode);
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

	private void SwigDirectorMethodsetPrimitiveAccelerator__SWIG_4(int treeType)
	{
		try
		{
			setPrimitiveAccelerator((OdGiVisualizeRTRenderSettingsTraits_AcceleratorType)treeType);
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

	private void SwigDirectorMethodprimitiveAccelerator(OdGiVisualizeRTRenderSettingsTraits_AcceleratorType treeType, OdGiVisualizeRTRenderSettingsTraits_SplitMethod splitMode, uint nMaxLeafPrims, uint nNodeDepth, bool bSort)
	{
		try
		{
			primitiveAccelerator(out treeType, out splitMode, out nMaxLeafPrims, out nNodeDepth, out bSort);
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

	private void SwigDirectorMethodsetToleranceOverride__SWIG_0(bool bOverride, float fTol, double dTol)
	{
		try
		{
			setToleranceOverride(bOverride, fTol, dTol);
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

	private void SwigDirectorMethodsetToleranceOverride__SWIG_1(bool bOverride, float fTol)
	{
		try
		{
			setToleranceOverride(bOverride, fTol);
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

	private void SwigDirectorMethodsetToleranceOverride__SWIG_2(bool bOverride)
	{
		try
		{
			setToleranceOverride(bOverride);
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

	private bool SwigDirectorMethodtoleranceOverride(float fTol, double dTol)
	{
		return toleranceOverride(out fTol, out dTol);
	}

	private void SwigDirectorMethodsetMinEnergy(float fEnergy)
	{
		try
		{
			setMinEnergy(fEnergy);
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

	private float SwigDirectorMethodminEnergy()
	{
		return minEnergy();
	}

	private void SwigDirectorMethodsetLinePrimitivesEnabled__SWIG_0(bool bEnable, float fWidth)
	{
		try
		{
			setLinePrimitivesEnabled(bEnable, fWidth);
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

	private void SwigDirectorMethodsetLinePrimitivesEnabled__SWIG_1(bool bEnable)
	{
		try
		{
			setLinePrimitivesEnabled(bEnable);
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

	private bool SwigDirectorMethodlinePrimitivesEnabled(float fWidth)
	{
		return linePrimitivesEnabled(out fWidth);
	}

	private void SwigDirectorMethodsetMaxCPUThreads(uint nThreads)
	{
		try
		{
			setMaxCPUThreads(nThreads);
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

	private uint SwigDirectorMethodmaxCPUThreads()
	{
		return maxCPUThreads();
	}

	private void SwigDirectorMethodsetTileSize(uint nWidth, uint nHeight)
	{
		try
		{
			setTileSize(nWidth, nHeight);
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

	private void SwigDirectorMethodtileSize(uint nWidth, uint nHeight)
	{
		try
		{
			tileSize(out nWidth, out nHeight);
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

	private void SwigDirectorMethodsetTileOrder(int order)
	{
		try
		{
			setTileOrder((OdGiMrTileOrder_)order);
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

	private int SwigDirectorMethodtileOrder()
	{
		return (int)tileOrder();
	}

	private void SwigDirectorMethodsetMaxGPUBufferSubdivisions(uint nSubdivs)
	{
		try
		{
			setMaxGPUBufferSubdivisions(nSubdivs);
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

	private uint SwigDirectorMethodmaxGPUBufferSubdivisions()
	{
		return maxGPUBufferSubdivisions();
	}

	private void SwigDirectorMethodsetMinGPUBufferSubdivisionSize(uint nWidth, uint nHeight)
	{
		try
		{
			setMinGPUBufferSubdivisionSize(nWidth, nHeight);
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

	private void SwigDirectorMethodminGPUBufferSubdivisionSize(uint nWidth, uint nHeight)
	{
		try
		{
			minGPUBufferSubdivisionSize(out nWidth, out nHeight);
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

	private void SwigDirectorMethodsetGPUBufferScalePercents(uint nPercs)
	{
		try
		{
			setGPUBufferScalePercents(nPercs);
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

	private uint SwigDirectorMethodgpuBufferScalePercents()
	{
		return gpuBufferScalePercents();
	}

	private void SwigDirectorMethodsetGPUWorkGroupSize(uint nThreads)
	{
		try
		{
			setGPUWorkGroupSize(nThreads);
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

	private uint SwigDirectorMethodgpuWorkGroupSize()
	{
		return gpuWorkGroupSize();
	}

	private void SwigDirectorMethodsetGPUTiledRendering(bool bEnable)
	{
		try
		{
			setGPUTiledRendering(bEnable);
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

	private bool SwigDirectorMethodgpuTiledRendering()
	{
		return gpuTiledRendering();
	}

	private void SwigDirectorMethodsetGPUForceShadowMapsInsideReflections(bool bEnable)
	{
		try
		{
			setGPUForceShadowMapsInsideReflections(bEnable);
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

	private bool SwigDirectorMethodgpuForceShadowMapsInsideReflections()
	{
		return gpuForceShadowMapsInsideReflections();
	}

	private void SwigDirectorMethodsetPartialRenderComponents(uint nComponents)
	{
		try
		{
			setPartialRenderComponents(nComponents);
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

	private uint SwigDirectorMethodpartialRenderComponents()
	{
		return partialRenderComponents();
	}

	private void SwigDirectorMethodsetMinimalReflectionCutoff(float refCutoff)
	{
		try
		{
			setMinimalReflectionCutoff(refCutoff);
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

	private float SwigDirectorMethodminimalReflectionCutoff()
	{
		return minimalReflectionCutoff();
	}

	private void SwigDirectorMethodsetMinimalRefractionCutoff(float refCutoff)
	{
		try
		{
			setMinimalRefractionCutoff(refCutoff);
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

	private float SwigDirectorMethodminimalRefractionCutoff()
	{
		return minimalRefractionCutoff();
	}

	private void SwigDirectorMethodsetMinimalLightingCutoff(float lightCutoff)
	{
		try
		{
			setMinimalLightingCutoff(lightCutoff);
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

	private float SwigDirectorMethodminimalLightingCutoff()
	{
		return minimalLightingCutoff();
	}

	private void SwigDirectorMethodsetShadowTypeOverride(int shadowType)
	{
		try
		{
			setShadowTypeOverride((OdGiVisualizeRTRenderSettingsTraits_ShadowTypeOverride)shadowType);
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

	private int SwigDirectorMethodshadowTypeOverride()
	{
		return (int)shadowTypeOverride();
	}

	private void SwigDirectorMethodsetGlobalIlluminationEnabled(bool bSet)
	{
		try
		{
			setGlobalIlluminationEnabled(bSet);
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

	private bool SwigDirectorMethodglobalIlluminationEnabled()
	{
		return globalIlluminationEnabled();
	}

	private void SwigDirectorMethodsetGlobalIlluminationSamples(int nX, int nY)
	{
		try
		{
			setGlobalIlluminationSamples(nX, nY);
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

	private void SwigDirectorMethodglobalIlluminationSamples(int nX, int nY)
	{
		try
		{
			globalIlluminationSamples(out nX, out nY);
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

	private void SwigDirectorMethodsetGlobalIlluminationRadius(float fRad)
	{
		try
		{
			setGlobalIlluminationRadius(fRad);
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

	private float SwigDirectorMethodglobalIlluminationRadius()
	{
		return globalIlluminationRadius();
	}

	private void SwigDirectorMethodsetGlobalIlluminationAutoRadiusEnabled(bool bSet)
	{
		try
		{
			setGlobalIlluminationAutoRadiusEnabled(bSet);
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

	private bool SwigDirectorMethodglobalIlluminationAutoRadiusEnabled()
	{
		return globalIlluminationAutoRadiusEnabled();
	}

	private void SwigDirectorMethodsetGlobalIlluminationAutoRadiusPercents(float fPerc)
	{
		try
		{
			setGlobalIlluminationAutoRadiusPercents(fPerc);
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

	private float SwigDirectorMethodglobalIlluminationAutoRadiusPercents()
	{
		return globalIlluminationAutoRadiusPercents();
	}

	private void SwigDirectorMethodsetGlobalIlluminationOcclusionCoefficient(float fCoef)
	{
		try
		{
			setGlobalIlluminationOcclusionCoefficient(fCoef);
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

	private float SwigDirectorMethodglobalIlluminationOcclusionCoefficient()
	{
		return globalIlluminationOcclusionCoefficient();
	}

	private void SwigDirectorMethodsetRoughnessSamples(int nX, int nY)
	{
		try
		{
			setRoughnessSamples(nX, nY);
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

	private void SwigDirectorMethodroughnessSamples(int nX, int nY)
	{
		try
		{
			roughnessSamples(out nX, out nY);
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

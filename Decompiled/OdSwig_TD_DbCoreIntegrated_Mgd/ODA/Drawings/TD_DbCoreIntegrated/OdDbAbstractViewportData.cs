using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbAbstractViewportData : OdAbstractViewPE
{
	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_1();

	public delegate void SwigDelegateOdDbAbstractViewportData_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_3(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_4(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_5(IntPtr pViewport, IntPtr lowerLeft, IntPtr upperRight);

	public delegate bool SwigDelegateOdDbAbstractViewportData_6(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_7(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_8(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_9(IntPtr pViewport);

	public delegate double SwigDelegateOdDbAbstractViewportData_10(IntPtr pViewport);

	public delegate double SwigDelegateOdDbAbstractViewportData_11(IntPtr pViewport);

	public delegate bool SwigDelegateOdDbAbstractViewportData_12(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_13(IntPtr pViewport);

	public delegate bool SwigDelegateOdDbAbstractViewportData_14(IntPtr pViewport);

	public delegate double SwigDelegateOdDbAbstractViewportData_15(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_16(IntPtr pViewport, IntPtr target, IntPtr direction, IntPtr upVector, double fieldWidth, double fieldHeight, bool isPerspective, IntPtr viewOffset);

	public delegate void SwigDelegateOdDbAbstractViewportData_17(IntPtr pViewport, IntPtr target, IntPtr direction, IntPtr upVector, double fieldWidth, double fieldHeight, bool isPerspective);

	public delegate void SwigDelegateOdDbAbstractViewportData_18(IntPtr pViewport, double lensLength);

	public delegate double SwigDelegateOdDbAbstractViewportData_19(IntPtr pViewport);

	public delegate bool SwigDelegateOdDbAbstractViewportData_20(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_21(IntPtr pViewport, bool frontClip);

	public delegate bool SwigDelegateOdDbAbstractViewportData_22(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_23(IntPtr pViewport, bool backClip);

	public delegate bool SwigDelegateOdDbAbstractViewportData_24(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_25(IntPtr pViewport, bool frontClipAtEye);

	public delegate double SwigDelegateOdDbAbstractViewportData_26(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_27(IntPtr pViewport, double frontClipDistance);

	public delegate double SwigDelegateOdDbAbstractViewportData_28(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_29(IntPtr pViewport, double backClipDistance);

	public delegate void SwigDelegateOdDbAbstractViewportData_30(IntPtr pViewport, int renderMode);

	public delegate int SwigDelegateOdDbAbstractViewportData_31(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_32(IntPtr pViewport, IntPtr visualStyleId);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_33(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_34(IntPtr pViewport, IntPtr backgroundId);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_35(IntPtr pViewport);

	public delegate bool SwigDelegateOdDbAbstractViewportData_36(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_37(IntPtr pViewport, bool isOn);

	public delegate int SwigDelegateOdDbAbstractViewportData_38(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_39(IntPtr pViewport, int lightingType);

	public delegate void SwigDelegateOdDbAbstractViewportData_40(IntPtr pViewport, IntPtr frozenLayers);

	public delegate void SwigDelegateOdDbAbstractViewportData_41(IntPtr pViewport, IntPtr frozenLayers);

	public delegate void SwigDelegateOdDbAbstractViewportData_42(IntPtr pDestinationView, IntPtr pSourceView);

	public delegate bool SwigDelegateOdDbAbstractViewportData_43(IntPtr pViewport);

	public delegate int SwigDelegateOdDbAbstractViewportData_44(IntPtr pViewport, IntPtr pDb);

	public delegate int SwigDelegateOdDbAbstractViewportData_45(IntPtr pViewport);

	public delegate bool SwigDelegateOdDbAbstractViewportData_46(IntPtr pViewport, int orthoUcs, IntPtr pDb);

	public delegate bool SwigDelegateOdDbAbstractViewportData_47(IntPtr pViewport, int orthoUcs);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_48(IntPtr pViewport);

	public delegate bool SwigDelegateOdDbAbstractViewportData_49(IntPtr pViewport, IntPtr ucsId);

	public delegate void SwigDelegateOdDbAbstractViewportData_50(IntPtr pViewport, IntPtr origin, IntPtr xAxis, IntPtr yAxis);

	public delegate void SwigDelegateOdDbAbstractViewportData_51(IntPtr pViewport, IntPtr origin, IntPtr xAxis, IntPtr yAxis);

	public delegate double SwigDelegateOdDbAbstractViewportData_52(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_53(IntPtr pViewport, double elevation);

	public delegate void SwigDelegateOdDbAbstractViewportData_54(IntPtr pDestinationView, IntPtr pSourceView);

	public delegate bool SwigDelegateOdDbAbstractViewportData_55(IntPtr pViewport, IntPtr extents);

	public delegate bool SwigDelegateOdDbAbstractViewportData_56(IntPtr pViewport, IntPtr extents, bool bExtendOnly, bool bExtentsValid, IntPtr pWorldToEye);

	public delegate bool SwigDelegateOdDbAbstractViewportData_57(IntPtr pViewport, IntPtr extents, bool bExtendOnly, bool bExtentsValid);

	public delegate bool SwigDelegateOdDbAbstractViewportData_58(IntPtr pViewport, IntPtr extents, bool bExtendOnly);

	public delegate bool SwigDelegateOdDbAbstractViewportData_59(IntPtr pViewport, IntPtr extents);

	public delegate bool SwigDelegateOdDbAbstractViewportData_60(IntPtr pViewport, IntPtr pExtents, double extCoef);

	public delegate bool SwigDelegateOdDbAbstractViewportData_61(IntPtr pViewport, IntPtr pExtents);

	public delegate bool SwigDelegateOdDbAbstractViewportData_62(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_63(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_64(IntPtr pViewport);

	public delegate bool SwigDelegateOdDbAbstractViewportData_65(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_66(IntPtr pViewport, bool bOpenForWrite);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_67(IntPtr pViewport);

	public delegate bool SwigDelegateOdDbAbstractViewportData_68(IntPtr pDestinationView, IntPtr pSourceView);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_69(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_70(IntPtr pViewport, IntPtr pCopyObject);

	public delegate void SwigDelegateOdDbAbstractViewportData_71(IntPtr pViewport, IntPtr pSourceView);

	public delegate bool SwigDelegateOdDbAbstractViewportData_72(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_73(IntPtr pViewport, bool ucsPerViewport);

	public delegate bool SwigDelegateOdDbAbstractViewportData_74(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_75(IntPtr pViewport, bool ucsFollowMode);

	public delegate ushort SwigDelegateOdDbAbstractViewportData_76(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_77(IntPtr pViewport, ushort circleSides);

	public delegate bool SwigDelegateOdDbAbstractViewportData_78(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_79(IntPtr pViewport, bool gridOn);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_80(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_81(IntPtr pViewport, IntPtr gridIncrement);

	public delegate bool SwigDelegateOdDbAbstractViewportData_82(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_83(IntPtr pViewport, bool gridDispFlag);

	public delegate bool SwigDelegateOdDbAbstractViewportData_84(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_85(IntPtr pViewport, bool gridDispFlag);

	public delegate bool SwigDelegateOdDbAbstractViewportData_86(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_87(IntPtr pViewport, bool gridDispFlag);

	public delegate bool SwigDelegateOdDbAbstractViewportData_88(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_89(IntPtr pViewport, bool gridDispFlag);

	public delegate short SwigDelegateOdDbAbstractViewportData_90(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_91(IntPtr pViewport, short nMajor);

	public delegate bool SwigDelegateOdDbAbstractViewportData_92(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_93(IntPtr pViewport, bool iconVisible);

	public delegate bool SwigDelegateOdDbAbstractViewportData_94(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_95(IntPtr pViewport, bool atOrigin);

	public delegate bool SwigDelegateOdDbAbstractViewportData_96(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_97(IntPtr pViewport, bool snapOn);

	public delegate bool SwigDelegateOdDbAbstractViewportData_98(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_99(IntPtr pViewport, bool snapIsometric);

	public delegate double SwigDelegateOdDbAbstractViewportData_100(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_101(IntPtr pViewport, double snapAngle);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_102(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_103(IntPtr pViewport, IntPtr snapBase);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_104(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_105(IntPtr pViewport, IntPtr snapIncrement);

	public delegate ushort SwigDelegateOdDbAbstractViewportData_106(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_107(IntPtr pViewport, ushort snapIsoPair);

	public delegate double SwigDelegateOdDbAbstractViewportData_108(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_109(IntPtr pViewport, double brightness);

	public delegate double SwigDelegateOdDbAbstractViewportData_110(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_111(IntPtr pViewport, double contrast);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_112(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_113(IntPtr pViewport, IntPtr color);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_114(IntPtr pViewport);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_115(IntPtr pViewport, IntPtr pSun);

	public delegate void SwigDelegateOdDbAbstractViewportData_116(IntPtr pViewport, IntPtr params_);

	public delegate void SwigDelegateOdDbAbstractViewportData_117(IntPtr pViewport, IntPtr params_);

	public delegate IntPtr SwigDelegateOdDbAbstractViewportData_118(IntPtr pViewport);

	public delegate void SwigDelegateOdDbAbstractViewportData_119(IntPtr pViewport, IntPtr pGsView);

	public delegate int SwigDelegateOdDbAbstractViewportData_120(IntPtr pViewport);

	public delegate int SwigDelegateOdDbAbstractViewportData_121(IntPtr pViewport, int nVal);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbAbstractViewportData_0 swigDelegate0;

	private SwigDelegateOdDbAbstractViewportData_1 swigDelegate1;

	private SwigDelegateOdDbAbstractViewportData_2 swigDelegate2;

	private SwigDelegateOdDbAbstractViewportData_3 swigDelegate3;

	private SwigDelegateOdDbAbstractViewportData_4 swigDelegate4;

	private SwigDelegateOdDbAbstractViewportData_5 swigDelegate5;

	private SwigDelegateOdDbAbstractViewportData_6 swigDelegate6;

	private SwigDelegateOdDbAbstractViewportData_7 swigDelegate7;

	private SwigDelegateOdDbAbstractViewportData_8 swigDelegate8;

	private SwigDelegateOdDbAbstractViewportData_9 swigDelegate9;

	private SwigDelegateOdDbAbstractViewportData_10 swigDelegate10;

	private SwigDelegateOdDbAbstractViewportData_11 swigDelegate11;

	private SwigDelegateOdDbAbstractViewportData_12 swigDelegate12;

	private SwigDelegateOdDbAbstractViewportData_13 swigDelegate13;

	private SwigDelegateOdDbAbstractViewportData_14 swigDelegate14;

	private SwigDelegateOdDbAbstractViewportData_15 swigDelegate15;

	private SwigDelegateOdDbAbstractViewportData_16 swigDelegate16;

	private SwigDelegateOdDbAbstractViewportData_17 swigDelegate17;

	private SwigDelegateOdDbAbstractViewportData_18 swigDelegate18;

	private SwigDelegateOdDbAbstractViewportData_19 swigDelegate19;

	private SwigDelegateOdDbAbstractViewportData_20 swigDelegate20;

	private SwigDelegateOdDbAbstractViewportData_21 swigDelegate21;

	private SwigDelegateOdDbAbstractViewportData_22 swigDelegate22;

	private SwigDelegateOdDbAbstractViewportData_23 swigDelegate23;

	private SwigDelegateOdDbAbstractViewportData_24 swigDelegate24;

	private SwigDelegateOdDbAbstractViewportData_25 swigDelegate25;

	private SwigDelegateOdDbAbstractViewportData_26 swigDelegate26;

	private SwigDelegateOdDbAbstractViewportData_27 swigDelegate27;

	private SwigDelegateOdDbAbstractViewportData_28 swigDelegate28;

	private SwigDelegateOdDbAbstractViewportData_29 swigDelegate29;

	private SwigDelegateOdDbAbstractViewportData_30 swigDelegate30;

	private SwigDelegateOdDbAbstractViewportData_31 swigDelegate31;

	private SwigDelegateOdDbAbstractViewportData_32 swigDelegate32;

	private SwigDelegateOdDbAbstractViewportData_33 swigDelegate33;

	private SwigDelegateOdDbAbstractViewportData_34 swigDelegate34;

	private SwigDelegateOdDbAbstractViewportData_35 swigDelegate35;

	private SwigDelegateOdDbAbstractViewportData_36 swigDelegate36;

	private SwigDelegateOdDbAbstractViewportData_37 swigDelegate37;

	private SwigDelegateOdDbAbstractViewportData_38 swigDelegate38;

	private SwigDelegateOdDbAbstractViewportData_39 swigDelegate39;

	private SwigDelegateOdDbAbstractViewportData_40 swigDelegate40;

	private SwigDelegateOdDbAbstractViewportData_41 swigDelegate41;

	private SwigDelegateOdDbAbstractViewportData_42 swigDelegate42;

	private SwigDelegateOdDbAbstractViewportData_43 swigDelegate43;

	private SwigDelegateOdDbAbstractViewportData_44 swigDelegate44;

	private SwigDelegateOdDbAbstractViewportData_45 swigDelegate45;

	private SwigDelegateOdDbAbstractViewportData_46 swigDelegate46;

	private SwigDelegateOdDbAbstractViewportData_47 swigDelegate47;

	private SwigDelegateOdDbAbstractViewportData_48 swigDelegate48;

	private SwigDelegateOdDbAbstractViewportData_49 swigDelegate49;

	private SwigDelegateOdDbAbstractViewportData_50 swigDelegate50;

	private SwigDelegateOdDbAbstractViewportData_51 swigDelegate51;

	private SwigDelegateOdDbAbstractViewportData_52 swigDelegate52;

	private SwigDelegateOdDbAbstractViewportData_53 swigDelegate53;

	private SwigDelegateOdDbAbstractViewportData_54 swigDelegate54;

	private SwigDelegateOdDbAbstractViewportData_55 swigDelegate55;

	private SwigDelegateOdDbAbstractViewportData_56 swigDelegate56;

	private SwigDelegateOdDbAbstractViewportData_57 swigDelegate57;

	private SwigDelegateOdDbAbstractViewportData_58 swigDelegate58;

	private SwigDelegateOdDbAbstractViewportData_59 swigDelegate59;

	private SwigDelegateOdDbAbstractViewportData_60 swigDelegate60;

	private SwigDelegateOdDbAbstractViewportData_61 swigDelegate61;

	private SwigDelegateOdDbAbstractViewportData_62 swigDelegate62;

	private SwigDelegateOdDbAbstractViewportData_63 swigDelegate63;

	private SwigDelegateOdDbAbstractViewportData_64 swigDelegate64;

	private SwigDelegateOdDbAbstractViewportData_65 swigDelegate65;

	private SwigDelegateOdDbAbstractViewportData_66 swigDelegate66;

	private SwigDelegateOdDbAbstractViewportData_67 swigDelegate67;

	private SwigDelegateOdDbAbstractViewportData_68 swigDelegate68;

	private SwigDelegateOdDbAbstractViewportData_69 swigDelegate69;

	private SwigDelegateOdDbAbstractViewportData_70 swigDelegate70;

	private SwigDelegateOdDbAbstractViewportData_71 swigDelegate71;

	private SwigDelegateOdDbAbstractViewportData_72 swigDelegate72;

	private SwigDelegateOdDbAbstractViewportData_73 swigDelegate73;

	private SwigDelegateOdDbAbstractViewportData_74 swigDelegate74;

	private SwigDelegateOdDbAbstractViewportData_75 swigDelegate75;

	private SwigDelegateOdDbAbstractViewportData_76 swigDelegate76;

	private SwigDelegateOdDbAbstractViewportData_77 swigDelegate77;

	private SwigDelegateOdDbAbstractViewportData_78 swigDelegate78;

	private SwigDelegateOdDbAbstractViewportData_79 swigDelegate79;

	private SwigDelegateOdDbAbstractViewportData_80 swigDelegate80;

	private SwigDelegateOdDbAbstractViewportData_81 swigDelegate81;

	private SwigDelegateOdDbAbstractViewportData_82 swigDelegate82;

	private SwigDelegateOdDbAbstractViewportData_83 swigDelegate83;

	private SwigDelegateOdDbAbstractViewportData_84 swigDelegate84;

	private SwigDelegateOdDbAbstractViewportData_85 swigDelegate85;

	private SwigDelegateOdDbAbstractViewportData_86 swigDelegate86;

	private SwigDelegateOdDbAbstractViewportData_87 swigDelegate87;

	private SwigDelegateOdDbAbstractViewportData_88 swigDelegate88;

	private SwigDelegateOdDbAbstractViewportData_89 swigDelegate89;

	private SwigDelegateOdDbAbstractViewportData_90 swigDelegate90;

	private SwigDelegateOdDbAbstractViewportData_91 swigDelegate91;

	private SwigDelegateOdDbAbstractViewportData_92 swigDelegate92;

	private SwigDelegateOdDbAbstractViewportData_93 swigDelegate93;

	private SwigDelegateOdDbAbstractViewportData_94 swigDelegate94;

	private SwigDelegateOdDbAbstractViewportData_95 swigDelegate95;

	private SwigDelegateOdDbAbstractViewportData_96 swigDelegate96;

	private SwigDelegateOdDbAbstractViewportData_97 swigDelegate97;

	private SwigDelegateOdDbAbstractViewportData_98 swigDelegate98;

	private SwigDelegateOdDbAbstractViewportData_99 swigDelegate99;

	private SwigDelegateOdDbAbstractViewportData_100 swigDelegate100;

	private SwigDelegateOdDbAbstractViewportData_101 swigDelegate101;

	private SwigDelegateOdDbAbstractViewportData_102 swigDelegate102;

	private SwigDelegateOdDbAbstractViewportData_103 swigDelegate103;

	private SwigDelegateOdDbAbstractViewportData_104 swigDelegate104;

	private SwigDelegateOdDbAbstractViewportData_105 swigDelegate105;

	private SwigDelegateOdDbAbstractViewportData_106 swigDelegate106;

	private SwigDelegateOdDbAbstractViewportData_107 swigDelegate107;

	private SwigDelegateOdDbAbstractViewportData_108 swigDelegate108;

	private SwigDelegateOdDbAbstractViewportData_109 swigDelegate109;

	private SwigDelegateOdDbAbstractViewportData_110 swigDelegate110;

	private SwigDelegateOdDbAbstractViewportData_111 swigDelegate111;

	private SwigDelegateOdDbAbstractViewportData_112 swigDelegate112;

	private SwigDelegateOdDbAbstractViewportData_113 swigDelegate113;

	private SwigDelegateOdDbAbstractViewportData_114 swigDelegate114;

	private SwigDelegateOdDbAbstractViewportData_115 swigDelegate115;

	private SwigDelegateOdDbAbstractViewportData_116 swigDelegate116;

	private SwigDelegateOdDbAbstractViewportData_117 swigDelegate117;

	private SwigDelegateOdDbAbstractViewportData_118 swigDelegate118;

	private SwigDelegateOdDbAbstractViewportData_119 swigDelegate119;

	private SwigDelegateOdDbAbstractViewportData_120 swigDelegate120;

	private SwigDelegateOdDbAbstractViewportData_121 swigDelegate121;

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

	private static Type[] swigMethodTypes71 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes72 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes73 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes74 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes75 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes76 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes77 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(ushort)
	};

	private static Type[] swigMethodTypes78 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes79 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes80 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes81 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGeVector2d)
	};

	private static Type[] swigMethodTypes82 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes83 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes84 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes85 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes86 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes87 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes88 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes89 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes90 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes91 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(short)
	};

	private static Type[] swigMethodTypes92 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes93 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes94 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes95 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes96 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes97 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes98 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes99 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes100 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes101 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(double)
	};

	private static Type[] swigMethodTypes102 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes103 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes104 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes105 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGeVector2d)
	};

	private static Type[] swigMethodTypes106 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes107 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(ushort)
	};

	private static Type[] swigMethodTypes108 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes109 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(double)
	};

	private static Type[] swigMethodTypes110 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes111 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(double)
	};

	private static Type[] swigMethodTypes112 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes113 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdCmColor)
	};

	private static Type[] swigMethodTypes114 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes115 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes116 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGiToneOperatorParameters).MakeByRefType()
	};

	private static Type[] swigMethodTypes117 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGiToneOperatorParameters)
	};

	private static Type[] swigMethodTypes118 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes119 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes120 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes121 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(int)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbAbstractViewportData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbAbstractViewportData obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbAbstractViewportData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbAbstractViewportData cast(OdRxObject pObj)
	{
		OdDbAbstractViewportData rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAbstractViewportData>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isASwigExplicitOdDbAbstractViewportData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_queryXSwigExplicitOdDbAbstractViewportData(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbAbstractViewportData createObject()
	{
		OdDbAbstractViewportData rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAbstractViewportData>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setProps(OdRxObject pViewport, OdRxObject pSourceView)
	{
		if (SwigDerivedClassHasMethod("setProps", swigMethodTypes71))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setPropsSwigExplicitOdDbAbstractViewportData(swigCPtr, OdRxObject.getCPtr(pViewport), OdRxObject.getCPtr(pSourceView));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setProps(swigCPtr, OdRxObject.getCPtr(pViewport), OdRxObject.getCPtr(pSourceView));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setUcs(OdRxObject pDestinationView, OdRxObject pSourceView)
	{
		if (SwigDerivedClassHasMethod("setUcs", swigMethodTypes54))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setUcsSwigExplicitOdDbAbstractViewportData(swigCPtr, OdRxObject.getCPtr(pDestinationView), OdRxObject.getCPtr(pSourceView));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setUcs(swigCPtr, OdRxObject.getCPtr(pDestinationView), OdRxObject.getCPtr(pSourceView));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool hasViewOffset(OdRxObject pViewport)
	{
		bool result = (SwigDerivedClassHasMethod("hasViewOffset", swigMethodTypes14) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_hasViewOffsetSwigExplicitOdDbAbstractViewportData(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_hasViewOffset(swigCPtr, OdRxObject.getCPtr(pViewport)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool applyPlotSettings(OdRxObject pDestinationView, OdRxObject pSourceView)
	{
		bool result = (SwigDerivedClassHasMethod("applyPlotSettings", swigMethodTypes68) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_applyPlotSettingsSwigExplicitOdDbAbstractViewportData(swigCPtr, OdRxObject.getCPtr(pDestinationView), OdRxObject.getCPtr(pSourceView)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_applyPlotSettings(swigCPtr, OdRxObject.getCPtr(pDestinationView), OdRxObject.getCPtr(pSourceView)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbStub compatibleCopyObject(OdRxObject pViewport, OdDbStub pCopyObject)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("compatibleCopyObject", swigMethodTypes70) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_compatibleCopyObjectSwigExplicitOdDbAbstractViewportData(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(pCopyObject)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_compatibleCopyObject(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(pCopyObject)));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isUcsSavedWithViewport(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isUcsSavedWithViewport(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setUcsPerViewport(OdRxObject pViewport, bool ucsPerViewport)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setUcsPerViewport(swigCPtr, OdRxObject.getCPtr(pViewport), ucsPerViewport);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isUcsFollowModeOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isUcsFollowModeOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setUcsFollowModeOn(OdRxObject pViewport, bool ucsFollowMode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setUcsFollowModeOn(swigCPtr, OdRxObject.getCPtr(pViewport), ucsFollowMode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ushort circleSides(OdRxObject pViewport)
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_circleSides(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setCircleSides(OdRxObject pViewport, ushort circleSides)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setCircleSides(swigCPtr, OdRxObject.getCPtr(pViewport), circleSides);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isGridOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isGridOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGridOn(OdRxObject pViewport, bool gridOn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setGridOn(swigCPtr, OdRxObject.getCPtr(pViewport), gridOn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeVector2d gridIncrement(OdRxObject pViewport)
	{
		OdGeVector2d result = new OdGeVector2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_gridIncrement(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGridIncrement(OdRxObject pViewport, OdGeVector2d gridIncrement)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setGridIncrement(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeVector2d.getCPtr(gridIncrement).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isGridBoundToLimits(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isGridBoundToLimits(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGridBoundToLimits(OdRxObject pViewport, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setGridBoundToLimits(swigCPtr, OdRxObject.getCPtr(pViewport), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isGridAdaptive(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isGridAdaptive(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGridAdaptive(OdRxObject pViewport, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setGridAdaptive(swigCPtr, OdRxObject.getCPtr(pViewport), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isGridSubdivisionRestricted(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isGridSubdivisionRestricted(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGridSubdivisionRestricted(OdRxObject pViewport, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setGridSubdivisionRestricted(swigCPtr, OdRxObject.getCPtr(pViewport), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isGridFollow(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isGridFollow(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGridFollow(OdRxObject pViewport, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setGridFollow(swigCPtr, OdRxObject.getCPtr(pViewport), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short gridMajor(OdRxObject pViewport)
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_gridMajor(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGridMajor(OdRxObject pViewport, short nMajor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setGridMajor(swigCPtr, OdRxObject.getCPtr(pViewport), nMajor);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isUcsIconVisible(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isUcsIconVisible(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setUcsIconVisible(OdRxObject pViewport, bool iconVisible)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setUcsIconVisible(swigCPtr, OdRxObject.getCPtr(pViewport), iconVisible);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isUcsIconAtOrigin(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isUcsIconAtOrigin(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setUcsIconAtOrigin(OdRxObject pViewport, bool atOrigin)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setUcsIconAtOrigin(swigCPtr, OdRxObject.getCPtr(pViewport), atOrigin);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isSnapOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isSnapOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSnapOn(OdRxObject pViewport, bool snapOn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setSnapOn(swigCPtr, OdRxObject.getCPtr(pViewport), snapOn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isSnapIsometric(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_isSnapIsometric(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSnapIsometric(OdRxObject pViewport, bool snapIsometric)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setSnapIsometric(swigCPtr, OdRxObject.getCPtr(pViewport), snapIsometric);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double snapAngle(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_snapAngle(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSnapAngle(OdRxObject pViewport, double snapAngle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setSnapAngle(swigCPtr, OdRxObject.getCPtr(pViewport), snapAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint2d snapBase(OdRxObject pViewport)
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_snapBase(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSnapBase(OdRxObject pViewport, OdGePoint2d snapBase)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setSnapBase(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint2d.getCPtr(snapBase));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeVector2d snapIncrement(OdRxObject pViewport)
	{
		OdGeVector2d result = new OdGeVector2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_snapIncrement(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSnapIncrement(OdRxObject pViewport, OdGeVector2d snapIncrement)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setSnapIncrement(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeVector2d.getCPtr(snapIncrement).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ushort snapIsoPair(OdRxObject pViewport)
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_snapIsoPair(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSnapIsoPair(OdRxObject pViewport, ushort snapIsoPair)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setSnapIsoPair(swigCPtr, OdRxObject.getCPtr(pViewport), snapIsoPair);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double brightness(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_brightness(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBrightness(OdRxObject pViewport, double brightness)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setBrightness(swigCPtr, OdRxObject.getCPtr(pViewport), brightness);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double contrast(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_contrast(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setContrast(OdRxObject pViewport, double contrast)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setContrast(swigCPtr, OdRxObject.getCPtr(pViewport), contrast);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor ambientLightColor(OdRxObject pViewport)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_ambientLightColor(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAmbientLightColor(OdRxObject pViewport, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setAmbientLightColor(swigCPtr, OdRxObject.getCPtr(pViewport), OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub sunId(OdRxObject pViewport)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_sunId(swigCPtr, OdRxObject.getCPtr(pViewport));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub setSun(OdRxObject pViewport, OdRxObject pSun)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setSun(swigCPtr, OdRxObject.getCPtr(pViewport), OdRxObject.getCPtr(pSun));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void toneOperatorParameters(OdRxObject pViewport, ref OdGiToneOperatorParameters params_)
	{
		IntPtr jarg = ((params_ == null) ? IntPtr.Zero : OdGiToneOperatorParameters.getCPtr(params_).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_toneOperatorParameters(swigCPtr, OdRxObject.getCPtr(pViewport), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
				params_ = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiToneOperatorParameters>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void setToneOperatorParameters(OdRxObject pViewport, OdGiToneOperatorParameters params_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setToneOperatorParameters(swigCPtr, OdRxObject.getCPtr(pViewport), OdGiToneOperatorParameters.getCPtr(params_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsView gsView(OdRxObject pViewport)
	{
		OdGsView rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_gsView(swigCPtr, OdRxObject.getCPtr(pViewport)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setGsView(OdRxObject pViewport, OdGsView pGsView)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setGsView(swigCPtr, OdRxObject.getCPtr(pViewport), OdGsView.getCPtr(pGsView));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int navvcubedisplay(OdRxObject pViewport)
	{
		int result = (SwigDerivedClassHasMethod("navvcubedisplay", swigMethodTypes120) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_navvcubedisplaySwigExplicitOdDbAbstractViewportData(swigCPtr, OdRxObject.getCPtr(pViewport)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_navvcubedisplay(swigCPtr, OdRxObject.getCPtr(pViewport)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setNavvcubedisplay(OdRxObject pViewport, int nVal)
	{
		int result = (SwigDerivedClassHasMethod("setNavvcubedisplay", swigMethodTypes121) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setNavvcubedisplaySwigExplicitOdDbAbstractViewportData(swigCPtr, OdRxObject.getCPtr(pViewport), nVal) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setNavvcubedisplay(swigCPtr, OdRxObject.getCPtr(pViewport), nVal));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void setView(OdRxObject pDestinationView, OdRxObject pSourceView)
	{
		if (SwigDerivedClassHasMethod("setView", swigMethodTypes42))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setViewSwigExplicitOdDbAbstractViewportData(swigCPtr, OdRxObject.getCPtr(pDestinationView), OdRxObject.getCPtr(pSourceView));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_setView(swigCPtr, OdRxObject.getCPtr(pDestinationView), OdRxObject.getCPtr(pSourceView));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbAbstractViewportData()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbAbstractViewportData(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbAbstractViewportData) != GetType();
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
			swigDelegate42 = SwigDirectorMethodsetView;
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
			swigDelegate54 = SwigDirectorMethodsetUcs;
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
		if (SwigDerivedClassHasMethod("setProps", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodsetProps;
		}
		if (SwigDerivedClassHasMethod("isUcsSavedWithViewport", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodisUcsSavedWithViewport;
		}
		if (SwigDerivedClassHasMethod("setUcsPerViewport", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodsetUcsPerViewport;
		}
		if (SwigDerivedClassHasMethod("isUcsFollowModeOn", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodisUcsFollowModeOn;
		}
		if (SwigDerivedClassHasMethod("setUcsFollowModeOn", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodsetUcsFollowModeOn;
		}
		if (SwigDerivedClassHasMethod("circleSides", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodcircleSides;
		}
		if (SwigDerivedClassHasMethod("setCircleSides", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodsetCircleSides;
		}
		if (SwigDerivedClassHasMethod("isGridOn", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodisGridOn;
		}
		if (SwigDerivedClassHasMethod("setGridOn", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodsetGridOn;
		}
		if (SwigDerivedClassHasMethod("gridIncrement", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodgridIncrement;
		}
		if (SwigDerivedClassHasMethod("setGridIncrement", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodsetGridIncrement;
		}
		if (SwigDerivedClassHasMethod("isGridBoundToLimits", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodisGridBoundToLimits;
		}
		if (SwigDerivedClassHasMethod("setGridBoundToLimits", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodsetGridBoundToLimits;
		}
		if (SwigDerivedClassHasMethod("isGridAdaptive", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodisGridAdaptive;
		}
		if (SwigDerivedClassHasMethod("setGridAdaptive", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodsetGridAdaptive;
		}
		if (SwigDerivedClassHasMethod("isGridSubdivisionRestricted", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodisGridSubdivisionRestricted;
		}
		if (SwigDerivedClassHasMethod("setGridSubdivisionRestricted", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodsetGridSubdivisionRestricted;
		}
		if (SwigDerivedClassHasMethod("isGridFollow", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodisGridFollow;
		}
		if (SwigDerivedClassHasMethod("setGridFollow", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodsetGridFollow;
		}
		if (SwigDerivedClassHasMethod("gridMajor", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodgridMajor;
		}
		if (SwigDerivedClassHasMethod("setGridMajor", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodsetGridMajor;
		}
		if (SwigDerivedClassHasMethod("isUcsIconVisible", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodisUcsIconVisible;
		}
		if (SwigDerivedClassHasMethod("setUcsIconVisible", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodsetUcsIconVisible;
		}
		if (SwigDerivedClassHasMethod("isUcsIconAtOrigin", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodisUcsIconAtOrigin;
		}
		if (SwigDerivedClassHasMethod("setUcsIconAtOrigin", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodsetUcsIconAtOrigin;
		}
		if (SwigDerivedClassHasMethod("isSnapOn", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodisSnapOn;
		}
		if (SwigDerivedClassHasMethod("setSnapOn", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodsetSnapOn;
		}
		if (SwigDerivedClassHasMethod("isSnapIsometric", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodisSnapIsometric;
		}
		if (SwigDerivedClassHasMethod("setSnapIsometric", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethodsetSnapIsometric;
		}
		if (SwigDerivedClassHasMethod("snapAngle", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodsnapAngle;
		}
		if (SwigDerivedClassHasMethod("setSnapAngle", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodsetSnapAngle;
		}
		if (SwigDerivedClassHasMethod("snapBase", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethodsnapBase;
		}
		if (SwigDerivedClassHasMethod("setSnapBase", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethodsetSnapBase;
		}
		if (SwigDerivedClassHasMethod("snapIncrement", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethodsnapIncrement;
		}
		if (SwigDerivedClassHasMethod("setSnapIncrement", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodsetSnapIncrement;
		}
		if (SwigDerivedClassHasMethod("snapIsoPair", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethodsnapIsoPair;
		}
		if (SwigDerivedClassHasMethod("setSnapIsoPair", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodsetSnapIsoPair;
		}
		if (SwigDerivedClassHasMethod("brightness", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethodbrightness;
		}
		if (SwigDerivedClassHasMethod("setBrightness", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodsetBrightness;
		}
		if (SwigDerivedClassHasMethod("contrast", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodcontrast;
		}
		if (SwigDerivedClassHasMethod("setContrast", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodsetContrast;
		}
		if (SwigDerivedClassHasMethod("ambientLightColor", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodambientLightColor;
		}
		if (SwigDerivedClassHasMethod("setAmbientLightColor", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethodsetAmbientLightColor;
		}
		if (SwigDerivedClassHasMethod("sunId", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodsunId;
		}
		if (SwigDerivedClassHasMethod("setSun", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethodsetSun;
		}
		if (SwigDerivedClassHasMethod("toneOperatorParameters", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethodtoneOperatorParameters;
		}
		if (SwigDerivedClassHasMethod("setToneOperatorParameters", swigMethodTypes117))
		{
			swigDelegate117 = SwigDirectorMethodsetToneOperatorParameters;
		}
		if (SwigDerivedClassHasMethod("gsView", swigMethodTypes118))
		{
			swigDelegate118 = SwigDirectorMethodgsView;
		}
		if (SwigDerivedClassHasMethod("setGsView", swigMethodTypes119))
		{
			swigDelegate119 = SwigDirectorMethodsetGsView;
		}
		if (SwigDerivedClassHasMethod("navvcubedisplay", swigMethodTypes120))
		{
			swigDelegate120 = SwigDirectorMethodnavvcubedisplay;
		}
		if (SwigDerivedClassHasMethod("setNavvcubedisplay", swigMethodTypes121))
		{
			swigDelegate121 = SwigDirectorMethodsetNavvcubedisplay;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportData_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbAbstractViewportData));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodlowerLeftCorner(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint2d.getCPtr(lowerLeftCorner(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
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
				return OdGePoint2d.getCPtr(upperRightCorner(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetViewport(IntPtr pViewport, IntPtr lowerLeft, IntPtr upperRight)
	{
		try
		{
			setViewport(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGePoint2d(lowerLeft, cMemoryOwn: false), new OdGePoint2d(upperRight, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodhasViewport(IntPtr pViewport)
	{
		return hasViewport(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodtarget(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(target(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
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
				return OdGeVector3d.getCPtr(direction(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
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
				return OdGeVector3d.getCPtr(upVector(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private double SwigDirectorMethodfieldWidth(IntPtr pViewport)
	{
		return fieldWidth(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodfieldHeight(IntPtr pViewport)
	{
		return fieldHeight(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisPerspective(IntPtr pViewport)
	{
		return isPerspective(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodviewOffset(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector2d.getCPtr(viewOffset(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private bool SwigDirectorMethodhasViewOffset(IntPtr pViewport)
	{
		return hasViewOffset(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodviewTwist(IntPtr pViewport)
	{
		return viewTwist(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetView__SWIG_0(IntPtr pViewport, IntPtr target, IntPtr direction, IntPtr upVector, double fieldWidth, double fieldHeight, bool isPerspective, IntPtr viewOffset)
	{
		try
		{
			setView(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(target, cMemoryOwn: true), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fieldWidth, fieldHeight, isPerspective, new OdGeVector2d(viewOffset, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetView__SWIG_1(IntPtr pViewport, IntPtr target, IntPtr direction, IntPtr upVector, double fieldWidth, double fieldHeight, bool isPerspective)
	{
		try
		{
			setView(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(target, cMemoryOwn: true), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fieldWidth, fieldHeight, isPerspective);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetLensLength(IntPtr pViewport, double lensLength)
	{
		try
		{
			setLensLength(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), lensLength);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodlensLength(IntPtr pViewport)
	{
		return lensLength(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisFrontClipOn(IntPtr pViewport)
	{
		return isFrontClipOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetFrontClipOn(IntPtr pViewport, bool frontClip)
	{
		try
		{
			setFrontClipOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), frontClip);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisBackClipOn(IntPtr pViewport)
	{
		return isBackClipOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetBackClipOn(IntPtr pViewport, bool backClip)
	{
		try
		{
			setBackClipOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), backClip);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisFrontClipAtEyeOn(IntPtr pViewport)
	{
		return isFrontClipAtEyeOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetFrontClipAtEyeOn(IntPtr pViewport, bool frontClipAtEye)
	{
		try
		{
			setFrontClipAtEyeOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), frontClipAtEye);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodfrontClipDistance(IntPtr pViewport)
	{
		return frontClipDistance(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetFrontClipDistance(IntPtr pViewport, double frontClipDistance)
	{
		try
		{
			setFrontClipDistance(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), frontClipDistance);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodbackClipDistance(IntPtr pViewport)
	{
		return backClipDistance(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetBackClipDistance(IntPtr pViewport, double backClipDistance)
	{
		try
		{
			setBackClipDistance(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), backClipDistance);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetRenderMode(IntPtr pViewport, int renderMode)
	{
		try
		{
			setRenderMode(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (OdDb_RenderMode)renderMode);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodrenderMode(IntPtr pViewport)
	{
		return (int)renderMode(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetVisualStyle(IntPtr pViewport, IntPtr visualStyleId)
	{
		try
		{
			setVisualStyle(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (visualStyleId == IntPtr.Zero) ? null : new OdDbStub(visualStyleId, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodvisualStyle(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(visualStyle(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetBackground(IntPtr pViewport, IntPtr backgroundId)
	{
		try
		{
			setBackground(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (backgroundId == IntPtr.Zero) ? null : new OdDbStub(backgroundId, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodbackground(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(background(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private bool SwigDirectorMethodisDefaultLightingOn(IntPtr pViewport)
	{
		return isDefaultLightingOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetDefaultLightingOn(IntPtr pViewport, bool isOn)
	{
		try
		{
			setDefaultLightingOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), isOn);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethoddefaultLightingType(IntPtr pViewport)
	{
		return (int)defaultLightingType(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetDefaultLightingType(IntPtr pViewport, int lightingType)
	{
		try
		{
			setDefaultLightingType(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (OdGiViewportTraits_DefaultLightingType)lightingType);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodFrozenLayers(IntPtr pViewport, IntPtr frozenLayers)
	{
		try
		{
			FrozenLayers(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdDbStubPtrArray(frozenLayers, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetFrozenLayers(IntPtr pViewport, IntPtr frozenLayers)
	{
		try
		{
			setFrozenLayers(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdDbStubPtrArray(frozenLayers, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetView(IntPtr pDestinationView, IntPtr pSourceView)
	{
		try
		{
			setView(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDestinationView, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSourceView, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodhasUcs(IntPtr pViewport)
	{
		return hasUcs(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodorthoUcs__SWIG_0(IntPtr pViewport, IntPtr pDb)
	{
		return (int)orthoUcs(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodorthoUcs__SWIG_1(IntPtr pViewport)
	{
		return (int)orthoUcs(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsetUcs__SWIG_0(IntPtr pViewport, int orthoUcs, IntPtr pDb)
	{
		return setUcs(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (OdDb_OrthographicView)orthoUcs, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsetUcs__SWIG_1(IntPtr pViewport, int orthoUcs)
	{
		return setUcs(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (OdDb_OrthographicView)orthoUcs);
	}

	private IntPtr SwigDirectorMethoducsName(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(ucsName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private bool SwigDirectorMethodsetUcs__SWIG_2(IntPtr pViewport, IntPtr ucsId)
	{
		return setUcs(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (ucsId == IntPtr.Zero) ? null : new OdDbStub(ucsId, cMemoryOwn: false));
	}

	private void SwigDirectorMethodgetUcs(IntPtr pViewport, IntPtr origin, IntPtr xAxis, IntPtr yAxis)
	{
		try
		{
			getUcs(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(xAxis, cMemoryOwn: false), new OdGeVector3d(yAxis, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetUcs__SWIG_3(IntPtr pViewport, IntPtr origin, IntPtr xAxis, IntPtr yAxis)
	{
		try
		{
			setUcs(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(xAxis, cMemoryOwn: false), new OdGeVector3d(yAxis, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodelevation(IntPtr pViewport)
	{
		return elevation(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetElevation(IntPtr pViewport, double elevation)
	{
		try
		{
			setElevation(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), elevation);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetUcs(IntPtr pDestinationView, IntPtr pSourceView)
	{
		try
		{
			setUcs(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDestinationView, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSourceView, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodviewExtents(IntPtr pViewport, IntPtr extents)
	{
		return viewExtents(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(extents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodplotExtents__SWIG_0(IntPtr pViewport, IntPtr extents, bool bExtendOnly, bool bExtentsValid, IntPtr pWorldToEye)
	{
		return plotExtents(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(extents, cMemoryOwn: false), bExtendOnly, bExtentsValid, (pWorldToEye == IntPtr.Zero) ? null : new OdGeMatrix3d(pWorldToEye, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodplotExtents__SWIG_1(IntPtr pViewport, IntPtr extents, bool bExtendOnly, bool bExtentsValid)
	{
		return plotExtents(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(extents, cMemoryOwn: false), bExtendOnly, bExtentsValid);
	}

	private bool SwigDirectorMethodplotExtents__SWIG_2(IntPtr pViewport, IntPtr extents, bool bExtendOnly)
	{
		return plotExtents(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(extents, cMemoryOwn: false), bExtendOnly);
	}

	private bool SwigDirectorMethodplotExtents__SWIG_3(IntPtr pViewport, IntPtr extents)
	{
		return plotExtents(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(extents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodzoomExtents__SWIG_0(IntPtr pViewport, IntPtr pExtents, double extCoef)
	{
		return zoomExtents(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (pExtents == IntPtr.Zero) ? null : new OdGeBoundBlock3d(pExtents, cMemoryOwn: false), extCoef);
	}

	private bool SwigDirectorMethodzoomExtents__SWIG_1(IntPtr pViewport, IntPtr pExtents)
	{
		return zoomExtents(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (pExtents == IntPtr.Zero) ? null : new OdGeBoundBlock3d(pExtents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodzoomExtents__SWIG_2(IntPtr pViewport)
	{
		return zoomExtents(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodworldToEye(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(worldToEye(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
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
				return OdGeMatrix3d.getCPtr(eyeToWorld(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private bool SwigDirectorMethodisPlotting(IntPtr pViewport)
	{
		return isPlotting(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodplotDataObject__SWIG_0(IntPtr pViewport, bool bOpenForWrite)
	{
		return OdRxObject.getCPtr(plotDataObject(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), bOpenForWrite)).Handle;
	}

	private IntPtr SwigDirectorMethodplotDataObject__SWIG_1(IntPtr pViewport)
	{
		return OdRxObject.getCPtr(plotDataObject(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private bool SwigDirectorMethodapplyPlotSettings(IntPtr pDestinationView, IntPtr pSourceView)
	{
		return applyPlotSettings(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDestinationView, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSourceView, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodannotationScale(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(annotationScale(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
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
				return OdDbStub.getCPtr(compatibleCopyObject(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), (pCopyObject == IntPtr.Zero) ? null : new OdDbStub(pCopyObject, cMemoryOwn: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetProps(IntPtr pViewport, IntPtr pSourceView)
	{
		try
		{
			setProps(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSourceView, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisUcsSavedWithViewport(IntPtr pViewport)
	{
		return isUcsSavedWithViewport(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetUcsPerViewport(IntPtr pViewport, bool ucsPerViewport)
	{
		try
		{
			setUcsPerViewport(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), ucsPerViewport);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisUcsFollowModeOn(IntPtr pViewport)
	{
		return isUcsFollowModeOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetUcsFollowModeOn(IntPtr pViewport, bool ucsFollowMode)
	{
		try
		{
			setUcsFollowModeOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), ucsFollowMode);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private ushort SwigDirectorMethodcircleSides(IntPtr pViewport)
	{
		return circleSides(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetCircleSides(IntPtr pViewport, ushort circleSides)
	{
		try
		{
			setCircleSides(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), circleSides);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisGridOn(IntPtr pViewport)
	{
		return isGridOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetGridOn(IntPtr pViewport, bool gridOn)
	{
		try
		{
			setGridOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), gridOn);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgridIncrement(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector2d.getCPtr(gridIncrement(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetGridIncrement(IntPtr pViewport, IntPtr gridIncrement)
	{
		try
		{
			setGridIncrement(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGeVector2d(gridIncrement, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisGridBoundToLimits(IntPtr pViewport)
	{
		return isGridBoundToLimits(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetGridBoundToLimits(IntPtr pViewport, bool gridDispFlag)
	{
		try
		{
			setGridBoundToLimits(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), gridDispFlag);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisGridAdaptive(IntPtr pViewport)
	{
		return isGridAdaptive(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetGridAdaptive(IntPtr pViewport, bool gridDispFlag)
	{
		try
		{
			setGridAdaptive(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), gridDispFlag);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisGridSubdivisionRestricted(IntPtr pViewport)
	{
		return isGridSubdivisionRestricted(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetGridSubdivisionRestricted(IntPtr pViewport, bool gridDispFlag)
	{
		try
		{
			setGridSubdivisionRestricted(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), gridDispFlag);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisGridFollow(IntPtr pViewport)
	{
		return isGridFollow(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetGridFollow(IntPtr pViewport, bool gridDispFlag)
	{
		try
		{
			setGridFollow(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), gridDispFlag);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private short SwigDirectorMethodgridMajor(IntPtr pViewport)
	{
		return gridMajor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetGridMajor(IntPtr pViewport, short nMajor)
	{
		try
		{
			setGridMajor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), nMajor);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisUcsIconVisible(IntPtr pViewport)
	{
		return isUcsIconVisible(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetUcsIconVisible(IntPtr pViewport, bool iconVisible)
	{
		try
		{
			setUcsIconVisible(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), iconVisible);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisUcsIconAtOrigin(IntPtr pViewport)
	{
		return isUcsIconAtOrigin(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetUcsIconAtOrigin(IntPtr pViewport, bool atOrigin)
	{
		try
		{
			setUcsIconAtOrigin(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), atOrigin);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisSnapOn(IntPtr pViewport)
	{
		return isSnapOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetSnapOn(IntPtr pViewport, bool snapOn)
	{
		try
		{
			setSnapOn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), snapOn);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisSnapIsometric(IntPtr pViewport)
	{
		return isSnapIsometric(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetSnapIsometric(IntPtr pViewport, bool snapIsometric)
	{
		try
		{
			setSnapIsometric(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), snapIsometric);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodsnapAngle(IntPtr pViewport)
	{
		return snapAngle(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetSnapAngle(IntPtr pViewport, double snapAngle)
	{
		try
		{
			setSnapAngle(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), snapAngle);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodsnapBase(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint2d.getCPtr(snapBase(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetSnapBase(IntPtr pViewport, IntPtr snapBase)
	{
		try
		{
			setSnapBase(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGePoint2d(snapBase, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodsnapIncrement(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector2d.getCPtr(snapIncrement(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetSnapIncrement(IntPtr pViewport, IntPtr snapIncrement)
	{
		try
		{
			setSnapIncrement(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdGeVector2d(snapIncrement, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private ushort SwigDirectorMethodsnapIsoPair(IntPtr pViewport)
	{
		return snapIsoPair(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetSnapIsoPair(IntPtr pViewport, ushort snapIsoPair)
	{
		try
		{
			setSnapIsoPair(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), snapIsoPair);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodbrightness(IntPtr pViewport)
	{
		return brightness(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetBrightness(IntPtr pViewport, double brightness)
	{
		try
		{
			setBrightness(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), brightness);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodcontrast(IntPtr pViewport)
	{
		return contrast(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetContrast(IntPtr pViewport, double contrast)
	{
		try
		{
			setContrast(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), contrast);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodambientLightColor(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(ambientLightColor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetAmbientLightColor(IntPtr pViewport, IntPtr color)
	{
		try
		{
			setAmbientLightColor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), new OdCmColor(color, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodsunId(IntPtr pViewport)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(sunId(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodsetSun(IntPtr pViewport, IntPtr pSun)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(setSun(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSun, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodtoneOperatorParameters(IntPtr pViewport, IntPtr params_)
	{
		OdSwigDirectorHelper.director_UnpackData(params_, out var pOriginalObject, out var pFunction);
		OdGiToneOperatorParameters params_2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiToneOperatorParameters>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			toneOperatorParameters(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), ref params_2);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
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

	private void SwigDirectorMethodsetToneOperatorParameters(IntPtr pViewport, IntPtr params_)
	{
		try
		{
			setToneOperatorParameters(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiToneOperatorParameters>(params_, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgsView(IntPtr pViewport)
	{
		return OdGsView.getCPtr(gsView(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private void SwigDirectorMethodsetGsView(IntPtr pViewport, IntPtr pGsView)
	{
		try
		{
			setGsView(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(pGsView, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodnavvcubedisplay(IntPtr pViewport)
	{
		return navvcubedisplay(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodsetNavvcubedisplay(IntPtr pViewport, int nVal)
	{
		return (int)setNavvcubedisplay(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewport, bOwn: false, bTryAddToTransaction: false), nVal);
	}
}

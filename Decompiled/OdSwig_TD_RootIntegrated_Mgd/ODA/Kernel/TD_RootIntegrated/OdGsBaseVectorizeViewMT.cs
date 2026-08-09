using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBaseVectorizeViewMT : TempOdGsBaseVectorizeViewJoinMT
{
	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_1();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_2();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_3();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_4();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_5();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_6();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_7(IntPtr point);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_8(IntPtr point);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_9(IntPtr point, IntPtr pixelDensity, bool includePerspective);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_10(IntPtr point, IntPtr pixelDensity);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_11();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_12();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_13();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_14();

	public delegate uint SwigDelegateOdGsBaseVectorizeViewMT_15();

	public delegate short SwigDelegateOdGsBaseVectorizeViewMT_16();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_17(IntPtr lowerLeft, IntPtr upperRight);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_18(bool clipFront, bool clipBack, double front, double back);

	public delegate double SwigDelegateOdGsBaseVectorizeViewMT_19();

	public delegate double SwigDelegateOdGsBaseVectorizeViewMT_20();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_21(IntPtr layerId);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_22();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_23();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_24(IntPtr view);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_25();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_26();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_27();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_28();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_29(IntPtr normal);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_30(IntPtr xfm);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_31();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_32(IntPtr firstPoint, IntPtr secondPoint);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_33(IntPtr basePoint, IntPtr throughPoint);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_34(IntPtr numVertices);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_35(IntPtr numRows);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_36(IntPtr newExtents);

	public delegate double SwigDelegateOdGsBaseVectorizeViewMT_37(int deviationType, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdGsBaseVectorizeViewMT_38();

	public delegate uint SwigDelegateOdGsBaseVectorizeViewMT_39();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_40(uint viewportId);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_41();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_42(IntPtr pNormal);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_43();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_44(int fillType);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_45();

	public delegate uint SwigDelegateOdGsBaseVectorizeViewMT_46();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_47(IntPtr pOverride);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_48();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_49(IntPtr pOverride);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_50();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_51();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_52();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_53();

	public delegate double SwigDelegateOdGsBaseVectorizeViewMT_54();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_55();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_56();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_57();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_58();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_59();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_60(IntPtr pDrawable);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_61();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_62(IntPtr pMetafile);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_63(IntPtr pMetafile);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_64(IntPtr pMetafile);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_65(IntPtr pMetafile, IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_66(IntPtr pFiler);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_67();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_68();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_69();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_70();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_71();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_72(IntPtr materialId, IntPtr pNode);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_73(IntPtr pNode, IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_74(IntPtr pNode, IntPtr pFiler);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_75(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_76(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_77(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_78(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_79(IntPtr pBoundary);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_80(IntPtr pBoundary, IntPtr pClipInfo);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_81();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_82();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_83(int bit, bool value);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_84(int bit);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_85(IntPtr arg0, uint arg1);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_86(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_87(uint arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_88();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_89();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_90();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_91();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_92(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_93();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_94(IntPtr arg0, IntPtr error);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_95(IntPtr pXform);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_96();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_97();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_98(bool analytic);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_99();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_100(bool analytic);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_101();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_102(IntPtr pdro, uint incFlags);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_103(IntPtr pdro);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_104();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_105();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_106(uint drawableFlags, IntPtr pDrawable);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_107(IntPtr selectionMarker);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_108();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_109(IntPtr visualStyle);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_110();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_111(IntPtr pGeomPortion);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_112();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_113(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList, uint nObjectListSize);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_114(int overlayId);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_115(IntPtr node, IntPtr ctx);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_116(IntPtr node, IntPtr ctx, bool bHighlighted);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_117();

	public delegate uint SwigDelegateOdGsBaseVectorizeViewMT_118(IntPtr pDrawable);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewMT_119();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_120(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize, IntPtr pCtx);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_121(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_122(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_123(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_124(IntPtr pReactor, IntPtr pCtx);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_125(IntPtr pReactor);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_126();

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_127(IntPtr pDevice, IntPtr pViewInfo, bool enableLayerVisibilityPerView);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_128(IntPtr pDevice, IntPtr pViewInfo);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_129(IntPtr pDevice);

	public delegate uint SwigDelegateOdGsBaseVectorizeViewMT_130();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewMT_131(bool arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewMT_132(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsBaseVectorizeViewMT_0 swigDelegate0;

	private SwigDelegateOdGsBaseVectorizeViewMT_1 swigDelegate1;

	private SwigDelegateOdGsBaseVectorizeViewMT_2 swigDelegate2;

	private SwigDelegateOdGsBaseVectorizeViewMT_3 swigDelegate3;

	private SwigDelegateOdGsBaseVectorizeViewMT_4 swigDelegate4;

	private SwigDelegateOdGsBaseVectorizeViewMT_5 swigDelegate5;

	private SwigDelegateOdGsBaseVectorizeViewMT_6 swigDelegate6;

	private SwigDelegateOdGsBaseVectorizeViewMT_7 swigDelegate7;

	private SwigDelegateOdGsBaseVectorizeViewMT_8 swigDelegate8;

	private SwigDelegateOdGsBaseVectorizeViewMT_9 swigDelegate9;

	private SwigDelegateOdGsBaseVectorizeViewMT_10 swigDelegate10;

	private SwigDelegateOdGsBaseVectorizeViewMT_11 swigDelegate11;

	private SwigDelegateOdGsBaseVectorizeViewMT_12 swigDelegate12;

	private SwigDelegateOdGsBaseVectorizeViewMT_13 swigDelegate13;

	private SwigDelegateOdGsBaseVectorizeViewMT_14 swigDelegate14;

	private SwigDelegateOdGsBaseVectorizeViewMT_15 swigDelegate15;

	private SwigDelegateOdGsBaseVectorizeViewMT_16 swigDelegate16;

	private SwigDelegateOdGsBaseVectorizeViewMT_17 swigDelegate17;

	private SwigDelegateOdGsBaseVectorizeViewMT_18 swigDelegate18;

	private SwigDelegateOdGsBaseVectorizeViewMT_19 swigDelegate19;

	private SwigDelegateOdGsBaseVectorizeViewMT_20 swigDelegate20;

	private SwigDelegateOdGsBaseVectorizeViewMT_21 swigDelegate21;

	private SwigDelegateOdGsBaseVectorizeViewMT_22 swigDelegate22;

	private SwigDelegateOdGsBaseVectorizeViewMT_23 swigDelegate23;

	private SwigDelegateOdGsBaseVectorizeViewMT_24 swigDelegate24;

	private SwigDelegateOdGsBaseVectorizeViewMT_25 swigDelegate25;

	private SwigDelegateOdGsBaseVectorizeViewMT_26 swigDelegate26;

	private SwigDelegateOdGsBaseVectorizeViewMT_27 swigDelegate27;

	private SwigDelegateOdGsBaseVectorizeViewMT_28 swigDelegate28;

	private SwigDelegateOdGsBaseVectorizeViewMT_29 swigDelegate29;

	private SwigDelegateOdGsBaseVectorizeViewMT_30 swigDelegate30;

	private SwigDelegateOdGsBaseVectorizeViewMT_31 swigDelegate31;

	private SwigDelegateOdGsBaseVectorizeViewMT_32 swigDelegate32;

	private SwigDelegateOdGsBaseVectorizeViewMT_33 swigDelegate33;

	private SwigDelegateOdGsBaseVectorizeViewMT_34 swigDelegate34;

	private SwigDelegateOdGsBaseVectorizeViewMT_35 swigDelegate35;

	private SwigDelegateOdGsBaseVectorizeViewMT_36 swigDelegate36;

	private SwigDelegateOdGsBaseVectorizeViewMT_37 swigDelegate37;

	private SwigDelegateOdGsBaseVectorizeViewMT_38 swigDelegate38;

	private SwigDelegateOdGsBaseVectorizeViewMT_39 swigDelegate39;

	private SwigDelegateOdGsBaseVectorizeViewMT_40 swigDelegate40;

	private SwigDelegateOdGsBaseVectorizeViewMT_41 swigDelegate41;

	private SwigDelegateOdGsBaseVectorizeViewMT_42 swigDelegate42;

	private SwigDelegateOdGsBaseVectorizeViewMT_43 swigDelegate43;

	private SwigDelegateOdGsBaseVectorizeViewMT_44 swigDelegate44;

	private SwigDelegateOdGsBaseVectorizeViewMT_45 swigDelegate45;

	private SwigDelegateOdGsBaseVectorizeViewMT_46 swigDelegate46;

	private SwigDelegateOdGsBaseVectorizeViewMT_47 swigDelegate47;

	private SwigDelegateOdGsBaseVectorizeViewMT_48 swigDelegate48;

	private SwigDelegateOdGsBaseVectorizeViewMT_49 swigDelegate49;

	private SwigDelegateOdGsBaseVectorizeViewMT_50 swigDelegate50;

	private SwigDelegateOdGsBaseVectorizeViewMT_51 swigDelegate51;

	private SwigDelegateOdGsBaseVectorizeViewMT_52 swigDelegate52;

	private SwigDelegateOdGsBaseVectorizeViewMT_53 swigDelegate53;

	private SwigDelegateOdGsBaseVectorizeViewMT_54 swigDelegate54;

	private SwigDelegateOdGsBaseVectorizeViewMT_55 swigDelegate55;

	private SwigDelegateOdGsBaseVectorizeViewMT_56 swigDelegate56;

	private SwigDelegateOdGsBaseVectorizeViewMT_57 swigDelegate57;

	private SwigDelegateOdGsBaseVectorizeViewMT_58 swigDelegate58;

	private SwigDelegateOdGsBaseVectorizeViewMT_59 swigDelegate59;

	private SwigDelegateOdGsBaseVectorizeViewMT_60 swigDelegate60;

	private SwigDelegateOdGsBaseVectorizeViewMT_61 swigDelegate61;

	private SwigDelegateOdGsBaseVectorizeViewMT_62 swigDelegate62;

	private SwigDelegateOdGsBaseVectorizeViewMT_63 swigDelegate63;

	private SwigDelegateOdGsBaseVectorizeViewMT_64 swigDelegate64;

	private SwigDelegateOdGsBaseVectorizeViewMT_65 swigDelegate65;

	private SwigDelegateOdGsBaseVectorizeViewMT_66 swigDelegate66;

	private SwigDelegateOdGsBaseVectorizeViewMT_67 swigDelegate67;

	private SwigDelegateOdGsBaseVectorizeViewMT_68 swigDelegate68;

	private SwigDelegateOdGsBaseVectorizeViewMT_69 swigDelegate69;

	private SwigDelegateOdGsBaseVectorizeViewMT_70 swigDelegate70;

	private SwigDelegateOdGsBaseVectorizeViewMT_71 swigDelegate71;

	private SwigDelegateOdGsBaseVectorizeViewMT_72 swigDelegate72;

	private SwigDelegateOdGsBaseVectorizeViewMT_73 swigDelegate73;

	private SwigDelegateOdGsBaseVectorizeViewMT_74 swigDelegate74;

	private SwigDelegateOdGsBaseVectorizeViewMT_75 swigDelegate75;

	private SwigDelegateOdGsBaseVectorizeViewMT_76 swigDelegate76;

	private SwigDelegateOdGsBaseVectorizeViewMT_77 swigDelegate77;

	private SwigDelegateOdGsBaseVectorizeViewMT_78 swigDelegate78;

	private SwigDelegateOdGsBaseVectorizeViewMT_79 swigDelegate79;

	private SwigDelegateOdGsBaseVectorizeViewMT_80 swigDelegate80;

	private SwigDelegateOdGsBaseVectorizeViewMT_81 swigDelegate81;

	private SwigDelegateOdGsBaseVectorizeViewMT_82 swigDelegate82;

	private SwigDelegateOdGsBaseVectorizeViewMT_83 swigDelegate83;

	private SwigDelegateOdGsBaseVectorizeViewMT_84 swigDelegate84;

	private SwigDelegateOdGsBaseVectorizeViewMT_85 swigDelegate85;

	private SwigDelegateOdGsBaseVectorizeViewMT_86 swigDelegate86;

	private SwigDelegateOdGsBaseVectorizeViewMT_87 swigDelegate87;

	private SwigDelegateOdGsBaseVectorizeViewMT_88 swigDelegate88;

	private SwigDelegateOdGsBaseVectorizeViewMT_89 swigDelegate89;

	private SwigDelegateOdGsBaseVectorizeViewMT_90 swigDelegate90;

	private SwigDelegateOdGsBaseVectorizeViewMT_91 swigDelegate91;

	private SwigDelegateOdGsBaseVectorizeViewMT_92 swigDelegate92;

	private SwigDelegateOdGsBaseVectorizeViewMT_93 swigDelegate93;

	private SwigDelegateOdGsBaseVectorizeViewMT_94 swigDelegate94;

	private SwigDelegateOdGsBaseVectorizeViewMT_95 swigDelegate95;

	private SwigDelegateOdGsBaseVectorizeViewMT_96 swigDelegate96;

	private SwigDelegateOdGsBaseVectorizeViewMT_97 swigDelegate97;

	private SwigDelegateOdGsBaseVectorizeViewMT_98 swigDelegate98;

	private SwigDelegateOdGsBaseVectorizeViewMT_99 swigDelegate99;

	private SwigDelegateOdGsBaseVectorizeViewMT_100 swigDelegate100;

	private SwigDelegateOdGsBaseVectorizeViewMT_101 swigDelegate101;

	private SwigDelegateOdGsBaseVectorizeViewMT_102 swigDelegate102;

	private SwigDelegateOdGsBaseVectorizeViewMT_103 swigDelegate103;

	private SwigDelegateOdGsBaseVectorizeViewMT_104 swigDelegate104;

	private SwigDelegateOdGsBaseVectorizeViewMT_105 swigDelegate105;

	private SwigDelegateOdGsBaseVectorizeViewMT_106 swigDelegate106;

	private SwigDelegateOdGsBaseVectorizeViewMT_107 swigDelegate107;

	private SwigDelegateOdGsBaseVectorizeViewMT_108 swigDelegate108;

	private SwigDelegateOdGsBaseVectorizeViewMT_109 swigDelegate109;

	private SwigDelegateOdGsBaseVectorizeViewMT_110 swigDelegate110;

	private SwigDelegateOdGsBaseVectorizeViewMT_111 swigDelegate111;

	private SwigDelegateOdGsBaseVectorizeViewMT_112 swigDelegate112;

	private SwigDelegateOdGsBaseVectorizeViewMT_113 swigDelegate113;

	private SwigDelegateOdGsBaseVectorizeViewMT_114 swigDelegate114;

	private SwigDelegateOdGsBaseVectorizeViewMT_115 swigDelegate115;

	private SwigDelegateOdGsBaseVectorizeViewMT_116 swigDelegate116;

	private SwigDelegateOdGsBaseVectorizeViewMT_117 swigDelegate117;

	private SwigDelegateOdGsBaseVectorizeViewMT_118 swigDelegate118;

	private SwigDelegateOdGsBaseVectorizeViewMT_119 swigDelegate119;

	private SwigDelegateOdGsBaseVectorizeViewMT_120 swigDelegate120;

	private SwigDelegateOdGsBaseVectorizeViewMT_121 swigDelegate121;

	private SwigDelegateOdGsBaseVectorizeViewMT_122 swigDelegate122;

	private SwigDelegateOdGsBaseVectorizeViewMT_123 swigDelegate123;

	private SwigDelegateOdGsBaseVectorizeViewMT_124 swigDelegate124;

	private SwigDelegateOdGsBaseVectorizeViewMT_125 swigDelegate125;

	private SwigDelegateOdGsBaseVectorizeViewMT_126 swigDelegate126;

	private SwigDelegateOdGsBaseVectorizeViewMT_127 swigDelegate127;

	private SwigDelegateOdGsBaseVectorizeViewMT_128 swigDelegate128;

	private SwigDelegateOdGsBaseVectorizeViewMT_129 swigDelegate129;

	private SwigDelegateOdGsBaseVectorizeViewMT_130 swigDelegate130;

	private SwigDelegateOdGsBaseVectorizeViewMT_131 swigDelegate131;

	private SwigDelegateOdGsBaseVectorizeViewMT_132 swigDelegate132;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes9 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint2d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(OdGePoint2d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes18 = new Type[4]
	{
		typeof(bool).MakeByRefType(),
		typeof(bool).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdGsViewImpl).MakeByRefType() };

	private static Type[] swigMethodTypes25 = new Type[0];

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes33 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes34 = new Type[1] { typeof(ShellData) };

	private static Type[] swigMethodTypes35 = new Type[1] { typeof(MeshData) };

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes37 = new Type[2]
	{
		typeof(OdGiDeviationType),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes38 = new Type[0];

	private static Type[] swigMethodTypes39 = new Type[0];

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdGiFillType) };

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[0];

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(OdGiLineweightOverride) };

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(OdGiPalette) };

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[0];

	private static Type[] swigMethodTypes52 = new Type[0];

	private static Type[] swigMethodTypes53 = new Type[0];

	private static Type[] swigMethodTypes54 = new Type[0];

	private static Type[] swigMethodTypes55 = new Type[0];

	private static Type[] swigMethodTypes56 = new Type[0];

	private static Type[] swigMethodTypes57 = new Type[0];

	private static Type[] swigMethodTypes58 = new Type[0];

	private static Type[] swigMethodTypes59 = new Type[0];

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes61 = new Type[0];

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes63 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes65 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGsFiler)
	};

	private static Type[] swigMethodTypes66 = new Type[1] { typeof(OdGsFiler) };

	private static Type[] swigMethodTypes67 = new Type[0];

	private static Type[] swigMethodTypes68 = new Type[0];

	private static Type[] swigMethodTypes69 = new Type[0];

	private static Type[] swigMethodTypes70 = new Type[0];

	private static Type[] swigMethodTypes71 = new Type[0];

	private static Type[] swigMethodTypes72 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdGsMaterialNode)
	};

	private static Type[] swigMethodTypes73 = new Type[2]
	{
		typeof(OdGsMaterialNode),
		typeof(OdGsFiler)
	};

	private static Type[] swigMethodTypes74 = new Type[2]
	{
		typeof(OdGsMaterialNode),
		typeof(OdGsFiler)
	};

	private static Type[] swigMethodTypes75 = new Type[1] { typeof(OdGiPointLightTraitsData) };

	private static Type[] swigMethodTypes76 = new Type[1] { typeof(OdGiSpotLightTraitsData) };

	private static Type[] swigMethodTypes77 = new Type[1] { typeof(OdGiDistantLightTraitsData) };

	private static Type[] swigMethodTypes78 = new Type[1] { typeof(OdGiWebLightTraitsData) };

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(OdGiClipBoundary) };

	private static Type[] swigMethodTypes80 = new Type[2]
	{
		typeof(OdGiClipBoundary),
		typeof(OdGiAbstractClipBoundary)
	};

	private static Type[] swigMethodTypes81 = new Type[0];

	private static Type[] swigMethodTypes82 = new Type[0];

	private static Type[] swigMethodTypes83 = new Type[2]
	{
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes84 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes85 = new Type[2]
	{
		typeof(OdGeMatrix3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes86 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes87 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes88 = new Type[0];

	private static Type[] swigMethodTypes89 = new Type[0];

	private static Type[] swigMethodTypes90 = new Type[0];

	private static Type[] swigMethodTypes91 = new Type[0];

	private static Type[] swigMethodTypes92 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes93 = new Type[0];

	private static Type[] swigMethodTypes94 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdError)
	};

	private static Type[] swigMethodTypes95 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes96 = new Type[0];

	private static Type[] swigMethodTypes97 = new Type[0];

	private static Type[] swigMethodTypes98 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes99 = new Type[0];

	private static Type[] swigMethodTypes100 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes101 = new Type[0];

	private static Type[] swigMethodTypes102 = new Type[2]
	{
		typeof(OdGsPropertiesDirectRenderOutput),
		typeof(uint)
	};

	private static Type[] swigMethodTypes103 = new Type[1] { typeof(OdGsPropertiesDirectRenderOutput) };

	private static Type[] swigMethodTypes104 = new Type[0];

	private static Type[] swigMethodTypes105 = new Type[0];

	private static Type[] swigMethodTypes106 = new Type[2]
	{
		typeof(uint),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes107 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes108 = new Type[0];

	private static Type[] swigMethodTypes109 = new Type[1] { typeof(OdGiVisualStyle) };

	private static Type[] swigMethodTypes110 = new Type[0];

	private static Type[] swigMethodTypes111 = new Type[1] { typeof(OdGsGeomPortion) };

	private static Type[] swigMethodTypes112 = new Type[0];

	private static Type[] swigMethodTypes113 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGsRayTraceReactor),
		typeof(bool),
		typeof(OdGiPathNode[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes114 = new Type[1] { typeof(OdGsOverlayId) };

	private static Type[] swigMethodTypes115 = new Type[2]
	{
		typeof(OdGsNode).MakeByRefType(),
		typeof(OdGsDisplayContext)
	};

	private static Type[] swigMethodTypes116 = new Type[3]
	{
		typeof(OdGsEntityNode).MakeByRefType(),
		typeof(OdGsDisplayContext),
		typeof(bool)
	};

	private static Type[] swigMethodTypes117 = new Type[0];

	private static Type[] swigMethodTypes118 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes119 = new Type[0];

	private static Type[] swigMethodTypes120 = new Type[6]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionContext)
	};

	private static Type[] swigMethodTypes121 = new Type[5]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGiPathNode[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes122 = new Type[4]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGiPathNode[])
	};

	private static Type[] swigMethodTypes123 = new Type[3]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor)
	};

	private static Type[] swigMethodTypes124 = new Type[2]
	{
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGsCollisionDetectionContext)
	};

	private static Type[] swigMethodTypes125 = new Type[1] { typeof(OdGsCollisionDetectionReactor) };

	private static Type[] swigMethodTypes126 = new Type[0];

	private static Type[] swigMethodTypes127 = new Type[3]
	{
		typeof(OdGsBaseVectorizeDevice),
		typeof(OdGsClientViewInfo),
		typeof(bool)
	};

	private static Type[] swigMethodTypes128 = new Type[2]
	{
		typeof(OdGsBaseVectorizeDevice),
		typeof(OdGsClientViewInfo)
	};

	private static Type[] swigMethodTypes129 = new Type[1] { typeof(OdGsBaseVectorizeDevice) };

	private static Type[] swigMethodTypes130 = new Type[0];

	private static Type[] swigMethodTypes131 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes132 = new Type[1] { typeof(OdGsBaseVectorizer) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBaseVectorizeViewMT(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeViewMT_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBaseVectorizeViewMT obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseVectorizeViewMT(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGsBaseVectorizeViewMT()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBaseVectorizeViewMT(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsBaseVectorizeViewMT) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public bool isMTView()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeViewMT_isMTView(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		if (SwigDerivedClassHasMethod("getModelToEyeTransform", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetModelToEyeTransform;
		}
		if (SwigDerivedClassHasMethod("getEyeToModelTransform", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetEyeToModelTransform;
		}
		if (SwigDerivedClassHasMethod("getWorldToEyeTransform", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetWorldToEyeTransform;
		}
		if (SwigDerivedClassHasMethod("getEyeToWorldTransform", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetEyeToWorldTransform;
		}
		if (SwigDerivedClassHasMethod("isPerspective", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodisPerspective;
		}
		if (SwigDerivedClassHasMethod("doPerspective", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddoPerspective;
		}
		if (SwigDerivedClassHasMethod("doInversePerspective", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddoInversePerspective;
		}
		if (SwigDerivedClassHasMethod("getNumPixelsInUnitSquare", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getNumPixelsInUnitSquare", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getCameraLocation", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetCameraLocation;
		}
		if (SwigDerivedClassHasMethod("getCameraTarget", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetCameraTarget;
		}
		if (SwigDerivedClassHasMethod("getCameraUpVector", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetCameraUpVector;
		}
		if (SwigDerivedClassHasMethod("viewDir", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodviewDir;
		}
		if (SwigDerivedClassHasMethod("viewportId", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodviewportId;
		}
		if (SwigDerivedClassHasMethod("acadWindowId", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodacadWindowId;
		}
		if (SwigDerivedClassHasMethod("getViewportDcCorners", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetViewportDcCorners;
		}
		if (SwigDerivedClassHasMethod("getFrontAndBackClipValues", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetFrontAndBackClipValues;
		}
		if (SwigDerivedClassHasMethod("linetypeScaleMultiplier", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodlinetypeScaleMultiplier;
		}
		if (SwigDerivedClassHasMethod("linetypeGenerationCriteria", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodlinetypeGenerationCriteria;
		}
		if (SwigDerivedClassHasMethod("layerVisible", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodlayerVisible;
		}
		if (SwigDerivedClassHasMethod("contextualColors", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodcontextualColors;
		}
		if (SwigDerivedClassHasMethod("annotationScaleId", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodannotationScaleId;
		}
		if (SwigDerivedClassHasMethod("setUp", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsetUp;
		}
		if (SwigDerivedClassHasMethod("objectToDeviceMatrix", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodobjectToDeviceMatrix;
		}
		if (SwigDerivedClassHasMethod("currentLineweightOverride", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodcurrentLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("getWorldToModelTransform", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodgetWorldToModelTransform;
		}
		if (SwigDerivedClassHasMethod("getModelToWorldTransform", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodgetModelToWorldTransform;
		}
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodpushModelTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodpushModelTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("popModelTransform", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodpopModelTransform;
		}
		if (SwigDerivedClassHasMethod("xline", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodxline;
		}
		if (SwigDerivedClassHasMethod("ray", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodray;
		}
		if (SwigDerivedClassHasMethod("shell", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodshell;
		}
		if (SwigDerivedClassHasMethod("mesh", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodmesh;
		}
		if (SwigDerivedClassHasMethod("setExtents", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodsetExtents;
		}
		if (SwigDerivedClassHasMethod("deviation", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethoddeviation;
		}
		if (SwigDerivedClassHasMethod("regenType", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodregenType;
		}
		if (SwigDerivedClassHasMethod("sequenceNumber", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodsequenceNumber;
		}
		if (SwigDerivedClassHasMethod("isValidId", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodisValidId;
		}
		if (SwigDerivedClassHasMethod("viewportObjectId", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodviewportObjectId;
		}
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodsetFillPlane__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodsetFillPlane__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setFillType", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodsetFillType;
		}
		if (SwigDerivedClassHasMethod("visualStyle", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodvisualStyle;
		}
		if (SwigDerivedClassHasMethod("setupForEntity", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodsetupForEntity;
		}
		if (SwigDerivedClassHasMethod("pushLineweightOverride", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodpushLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("popLineweightOverride", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodpopLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("pushPaletteOverride", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodpushPaletteOverride;
		}
		if (SwigDerivedClassHasMethod("popPaletteOverride", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodpopPaletteOverride;
		}
		if (SwigDerivedClassHasMethod("hasPaletteOverrides", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodhasPaletteOverrides;
		}
		if (SwigDerivedClassHasMethod("giViewport", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodgiViewport;
		}
		if (SwigDerivedClassHasMethod("gsView", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodgsView;
		}
		if (SwigDerivedClassHasMethod("annotationScale", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodannotationScale;
		}
		if (SwigDerivedClassHasMethod("beginViewVectorization", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodbeginViewVectorization;
		}
		if (SwigDerivedClassHasMethod("endViewVectorization", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodendViewVectorization;
		}
		if (SwigDerivedClassHasMethod("onTraitsModified", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodonTraitsModified;
		}
		if (SwigDerivedClassHasMethod("effectiveTraits", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodeffectiveTraits;
		}
		if (SwigDerivedClassHasMethod("metafileTransform", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodmetafileTransform;
		}
		if (SwigDerivedClassHasMethod("draw", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethoddraw;
		}
		if (SwigDerivedClassHasMethod("newGsMetafile", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodnewGsMetafile;
		}
		if (SwigDerivedClassHasMethod("beginMetafile", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodbeginMetafile;
		}
		if (SwigDerivedClassHasMethod("endMetafile", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodendMetafile;
		}
		if (SwigDerivedClassHasMethod("playMetafile", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodplayMetafile;
		}
		if (SwigDerivedClassHasMethod("saveMetafile", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodsaveMetafile;
		}
		if (SwigDerivedClassHasMethod("loadMetafile", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodloadMetafile;
		}
		if (SwigDerivedClassHasMethod("loadViewport", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodloadViewport;
		}
		if (SwigDerivedClassHasMethod("forceMetafilesDependence", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodforceMetafilesDependence;
		}
		if (SwigDerivedClassHasMethod("isViewRegenerated", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodisViewRegenerated;
		}
		if (SwigDerivedClassHasMethod("drawViewportFrame", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethoddrawViewportFrame;
		}
		if (SwigDerivedClassHasMethod("updateViewport", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodupdateViewport;
		}
		if (SwigDerivedClassHasMethod("processMaterialNode", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodprocessMaterialNode;
		}
		if (SwigDerivedClassHasMethod("saveMaterialCache", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodsaveMaterialCache;
		}
		if (SwigDerivedClassHasMethod("loadMaterialCache", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodloadMaterialCache;
		}
		if (SwigDerivedClassHasMethod("addPointLight", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodaddPointLight;
		}
		if (SwigDerivedClassHasMethod("addSpotLight", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodaddSpotLight;
		}
		if (SwigDerivedClassHasMethod("addDistantLight", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodaddDistantLight;
		}
		if (SwigDerivedClassHasMethod("addWebLight", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodaddWebLight;
		}
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodpushClipBoundary__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodpushClipBoundary__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("popClipBoundary", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodpopClipBoundary;
		}
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("pushMetafileTransform", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodpushMetafileTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushMetafileTransform", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodpushMetafileTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("popMetafileTransform", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodpopMetafileTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("popMetafileTransform", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodpopMetafileTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("useSharedBlockReferences", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethoduseSharedBlockReferences;
		}
		if (SwigDerivedClassHasMethod("useMetafileAsGeometry", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethoduseMetafileAsGeometry;
		}
		if (SwigDerivedClassHasMethod("outputForMetafileGeometry", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodoutputForMetafileGeometry;
		}
		if (SwigDerivedClassHasMethod("setTransformForMetafileGeometry", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodsetTransformForMetafileGeometry;
		}
		if (SwigDerivedClassHasMethod("getTransformForMetafileGeometry", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodgetTransformForMetafileGeometry;
		}
		if (SwigDerivedClassHasMethod("reportUpdateError", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodreportUpdateError;
		}
		if (SwigDerivedClassHasMethod("applySubentityTransform", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodapplySubentityTransform;
		}
		if (SwigDerivedClassHasMethod("isDragging", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodisDragging;
		}
		if (SwigDerivedClassHasMethod("gsExtentsOutput", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodgsExtentsOutput;
		}
		if (SwigDerivedClassHasMethod("setAnalyticLinetypingCircles", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodsetAnalyticLinetypingCircles;
		}
		if (SwigDerivedClassHasMethod("isAnalyticLinetypingCircles", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethodisAnalyticLinetypingCircles;
		}
		if (SwigDerivedClassHasMethod("setAnalyticLinetypingComplexCurves", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodsetAnalyticLinetypingComplexCurves;
		}
		if (SwigDerivedClassHasMethod("isAnalyticLinetypingComplexCurves", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodisAnalyticLinetypingComplexCurves;
		}
		if (SwigDerivedClassHasMethod("displayViewportProperties", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethoddisplayViewportProperties__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("displayViewportProperties", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethoddisplayViewportProperties__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("displayViewportProperties", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethoddisplayViewportProperties__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("regenAbort", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodregenAbort;
		}
		if (SwigDerivedClassHasMethod("doDraw", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethoddoDraw;
		}
		if (SwigDerivedClassHasMethod("setSelectionMarker", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodsetSelectionMarker;
		}
		if (SwigDerivedClassHasMethod("output", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethodoutput;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodsetVisualStyle;
		}
		if (SwigDerivedClassHasMethod("isSpatialIndexDisabled", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodisSpatialIndexDisabled;
		}
		if (SwigDerivedClassHasMethod("beginMetafileRecording", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodbeginMetafileRecording;
		}
		if (SwigDerivedClassHasMethod("endMetafileRecording", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodendMetafileRecording;
		}
		if (SwigDerivedClassHasMethod("doRayTrace", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethoddoRayTrace;
		}
		if (SwigDerivedClassHasMethod("switchOverlay", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodswitchOverlay;
		}
		if (SwigDerivedClassHasMethod("displayNode", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethoddisplayNode;
		}
		if (SwigDerivedClassHasMethod("displaySubnode", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethoddisplaySubnode;
		}
		if (SwigDerivedClassHasMethod("updateExtentsOnly", swigMethodTypes117))
		{
			swigDelegate117 = SwigDirectorMethodupdateExtentsOnly;
		}
		if (SwigDerivedClassHasMethod("setAttributes", swigMethodTypes118))
		{
			swigDelegate118 = SwigDirectorMethodsetAttributes;
		}
		if (SwigDerivedClassHasMethod("renderAbort", swigMethodTypes119))
		{
			swigDelegate119 = SwigDirectorMethodrenderAbort;
		}
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes120))
		{
			swigDelegate120 = SwigDirectorMethoddoCollide__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes121))
		{
			swigDelegate121 = SwigDirectorMethoddoCollide__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes122))
		{
			swigDelegate122 = SwigDirectorMethoddoCollide__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes123))
		{
			swigDelegate123 = SwigDirectorMethoddoCollide__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("doCollideAll", swigMethodTypes124))
		{
			swigDelegate124 = SwigDirectorMethoddoCollideAll__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("doCollideAll", swigMethodTypes125))
		{
			swigDelegate125 = SwigDirectorMethoddoCollideAll__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("clearLinetypeCache", swigMethodTypes126))
		{
			swigDelegate126 = SwigDirectorMethodclearLinetypeCache;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes127))
		{
			swigDelegate127 = SwigDirectorMethodinit__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes128))
		{
			swigDelegate128 = SwigDirectorMethodinit__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes129))
		{
			swigDelegate129 = SwigDirectorMethodinit__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("numVectorizers", swigMethodTypes130))
		{
			swigDelegate130 = SwigDirectorMethodnumVectorizers;
		}
		if (SwigDerivedClassHasMethod("getVectorizer", swigMethodTypes131))
		{
			swigDelegate131 = SwigDirectorMethodgetVectorizer;
		}
		if (SwigDerivedClassHasMethod("releaseVectorizer", swigMethodTypes132))
		{
			swigDelegate132 = SwigDirectorMethodreleaseVectorizer;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeViewMT_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125, swigDelegate126, swigDelegate127, swigDelegate128, swigDelegate129, swigDelegate130, swigDelegate131, swigDelegate132);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsBaseVectorizeViewMT));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private IntPtr SwigDirectorMethodgetModelToEyeTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getModelToEyeTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetEyeToModelTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getEyeToModelTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetWorldToEyeTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getWorldToEyeTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetEyeToWorldTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getEyeToWorldTransform()).Handle;
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

	private bool SwigDirectorMethodisPerspective()
	{
		return isPerspective();
	}

	private bool SwigDirectorMethoddoPerspective(IntPtr point)
	{
		return doPerspective(new OdGePoint3d(point, cMemoryOwn: false));
	}

	private bool SwigDirectorMethoddoInversePerspective(IntPtr point)
	{
		return doInversePerspective(new OdGePoint3d(point, cMemoryOwn: false));
	}

	private void SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_0(IntPtr point, IntPtr pixelDensity, bool includePerspective)
	{
		try
		{
			getNumPixelsInUnitSquare(new OdGePoint3d(point, cMemoryOwn: false), new OdGePoint2d(pixelDensity, cMemoryOwn: false), includePerspective);
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

	private void SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_1(IntPtr point, IntPtr pixelDensity)
	{
		try
		{
			getNumPixelsInUnitSquare(new OdGePoint3d(point, cMemoryOwn: false), new OdGePoint2d(pixelDensity, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodgetCameraLocation()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getCameraLocation()).Handle;
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

	private IntPtr SwigDirectorMethodgetCameraTarget()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getCameraTarget()).Handle;
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

	private IntPtr SwigDirectorMethodgetCameraUpVector()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(getCameraUpVector()).Handle;
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

	private IntPtr SwigDirectorMethodviewDir()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(viewDir()).Handle;
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

	private uint SwigDirectorMethodviewportId()
	{
		return viewportId();
	}

	private short SwigDirectorMethodacadWindowId()
	{
		return acadWindowId();
	}

	private void SwigDirectorMethodgetViewportDcCorners(IntPtr lowerLeft, IntPtr upperRight)
	{
		try
		{
			getViewportDcCorners(new OdGePoint2d(lowerLeft, cMemoryOwn: false), new OdGePoint2d(upperRight, cMemoryOwn: false));
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

	private bool SwigDirectorMethodgetFrontAndBackClipValues(bool clipFront, bool clipBack, double front, double back)
	{
		return getFrontAndBackClipValues(out clipFront, out clipBack, out front, out back);
	}

	private double SwigDirectorMethodlinetypeScaleMultiplier()
	{
		return linetypeScaleMultiplier();
	}

	private double SwigDirectorMethodlinetypeGenerationCriteria()
	{
		return linetypeGenerationCriteria();
	}

	private bool SwigDirectorMethodlayerVisible(IntPtr layerId)
	{
		return layerVisible((layerId == IntPtr.Zero) ? null : new OdDbStub(layerId, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodcontextualColors()
	{
		return OdGiContextualColors.getCPtr(contextualColors()).Handle;
	}

	private IntPtr SwigDirectorMethodannotationScaleId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(annotationScaleId()).Handle;
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

	private void SwigDirectorMethodsetUp(IntPtr view)
	{
		OdSwigDirectorHelper.director_UnpackData(view, out var pOriginalObject, out var pFunction);
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			setUp(ref rXObject);
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
			IntPtr handle = OdGsViewImpl.getCPtr(rXObject).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(view);
		}
	}

	private IntPtr SwigDirectorMethodobjectToDeviceMatrix()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(objectToDeviceMatrix()).Handle;
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

	private IntPtr SwigDirectorMethodcurrentLineweightOverride()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiLineweightOverride.getCPtr(currentLineweightOverride()).Handle;
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

	private IntPtr SwigDirectorMethodgetWorldToModelTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getWorldToModelTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetModelToWorldTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getModelToWorldTransform()).Handle;
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

	private void SwigDirectorMethodpushModelTransform__SWIG_1(IntPtr normal)
	{
		try
		{
			pushModelTransform(new OdGeVector3d(normal, cMemoryOwn: false));
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

	private void SwigDirectorMethodpushModelTransform__SWIG_0(IntPtr xfm)
	{
		try
		{
			pushModelTransform(new OdGeMatrix3d(xfm, cMemoryOwn: false));
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

	private void SwigDirectorMethodpopModelTransform()
	{
		try
		{
			popModelTransform();
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

	private void SwigDirectorMethodxline(IntPtr firstPoint, IntPtr secondPoint)
	{
		try
		{
			xline(new OdGePoint3d(firstPoint, cMemoryOwn: false), new OdGePoint3d(secondPoint, cMemoryOwn: false));
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

	private void SwigDirectorMethodray(IntPtr basePoint, IntPtr throughPoint)
	{
		try
		{
			ray(new OdGePoint3d(basePoint, cMemoryOwn: false), new OdGePoint3d(throughPoint, cMemoryOwn: false));
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

	private void SwigDirectorMethodshell(IntPtr numVertices)
	{
		try
		{
			shell(Helpers.UnMarshalShellData(numVertices));
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

	private void SwigDirectorMethodmesh(IntPtr numRows)
	{
		try
		{
			mesh(Helpers.UnMarshalMeshData(numRows));
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

	private void SwigDirectorMethodsetExtents(IntPtr newExtents)
	{
		try
		{
			setExtents((newExtents == IntPtr.Zero) ? null : new OdGePoint3d(newExtents, cMemoryOwn: false));
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

	private double SwigDirectorMethoddeviation(int deviationType, IntPtr pointOnCurve)
	{
		return deviation((OdGiDeviationType)deviationType, new OdGePoint3d(pointOnCurve, cMemoryOwn: false));
	}

	private int SwigDirectorMethodregenType()
	{
		return (int)regenType();
	}

	private uint SwigDirectorMethodsequenceNumber()
	{
		return sequenceNumber();
	}

	private bool SwigDirectorMethodisValidId(uint viewportId)
	{
		return isValidId(viewportId);
	}

	private IntPtr SwigDirectorMethodviewportObjectId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(viewportObjectId()).Handle;
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

	private uint SwigDirectorMethodsetupForEntity()
	{
		return setupForEntity();
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

	private bool SwigDirectorMethodhasPaletteOverrides()
	{
		return hasPaletteOverrides();
	}

	private IntPtr SwigDirectorMethodgiViewport()
	{
		return OdGiViewport.getCPtr(giViewport()).Handle;
	}

	private IntPtr SwigDirectorMethodgsView()
	{
		return OdGsView.getCPtr(gsView()).Handle;
	}

	private double SwigDirectorMethodannotationScale()
	{
		return annotationScale();
	}

	private void SwigDirectorMethodbeginViewVectorization()
	{
		try
		{
			beginViewVectorization();
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

	private void SwigDirectorMethodendViewVectorization()
	{
		try
		{
			endViewVectorization();
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

	private void SwigDirectorMethodonTraitsModified()
	{
		try
		{
			onTraitsModified();
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

	private IntPtr SwigDirectorMethodeffectiveTraits()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiSubEntityTraitsData.getCPtr(effectiveTraits()).Handle;
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

	private IntPtr SwigDirectorMethodmetafileTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(metafileTransform()).Handle;
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

	private void SwigDirectorMethoddraw(IntPtr pDrawable)
	{
		try
		{
			draw(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodnewGsMetafile()
	{
		return OdRxObject.getCPtr(newGsMetafile()).Handle;
	}

	private void SwigDirectorMethodbeginMetafile(IntPtr pMetafile)
	{
		try
		{
			beginMetafile(Helpers.GetRXObject<OdRxObject>(pMetafile, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodendMetafile(IntPtr pMetafile)
	{
		try
		{
			endMetafile(Helpers.GetRXObject<OdRxObject>(pMetafile, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodplayMetafile(IntPtr pMetafile)
	{
		try
		{
			playMetafile(Helpers.GetRXObject<OdRxObject>(pMetafile, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodsaveMetafile(IntPtr pMetafile, IntPtr pFiler)
	{
		return saveMetafile(Helpers.GetRXObject<OdRxObject>(pMetafile, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodloadMetafile(IntPtr pFiler)
	{
		return OdRxObject.getCPtr(loadMetafile(Helpers.GetRXObject<OdGsFiler>(pFiler, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private void SwigDirectorMethodloadViewport()
	{
		try
		{
			loadViewport();
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

	private bool SwigDirectorMethodforceMetafilesDependence()
	{
		return forceMetafilesDependence();
	}

	private bool SwigDirectorMethodisViewRegenerated()
	{
		return isViewRegenerated();
	}

	private void SwigDirectorMethoddrawViewportFrame()
	{
		try
		{
			drawViewportFrame();
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

	private void SwigDirectorMethodupdateViewport()
	{
		try
		{
			updateViewport();
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

	private void SwigDirectorMethodprocessMaterialNode(IntPtr materialId, IntPtr pNode)
	{
		try
		{
			processMaterialNode((materialId == IntPtr.Zero) ? null : new OdDbStub(materialId, cMemoryOwn: false), Helpers.GetRXObject<OdGsMaterialNode>(pNode, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodsaveMaterialCache(IntPtr pNode, IntPtr pFiler)
	{
		return saveMaterialCache(Helpers.GetRXObject<OdGsMaterialNode>(pNode, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodloadMaterialCache(IntPtr pNode, IntPtr pFiler)
	{
		return loadMaterialCache(Helpers.GetRXObject<OdGsMaterialNode>(pNode, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodaddPointLight(IntPtr arg0)
	{
		try
		{
			addPointLight(new OdGiPointLightTraitsData(arg0, cMemoryOwn: false));
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

	private void SwigDirectorMethodaddSpotLight(IntPtr arg0)
	{
		try
		{
			addSpotLight(new OdGiSpotLightTraitsData(arg0, cMemoryOwn: false));
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

	private void SwigDirectorMethodaddDistantLight(IntPtr arg0)
	{
		try
		{
			addDistantLight(new OdGiDistantLightTraitsData(arg0, cMemoryOwn: false));
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

	private void SwigDirectorMethodaddWebLight(IntPtr arg0)
	{
		try
		{
			addWebLight(new OdGiWebLightTraitsData(arg0, cMemoryOwn: false));
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

	private void SwigDirectorMethodpushClipBoundary__SWIG_0(IntPtr pBoundary)
	{
		try
		{
			pushClipBoundary((pBoundary == IntPtr.Zero) ? null : new OdGiClipBoundary(pBoundary, cMemoryOwn: false));
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

	private void SwigDirectorMethodpushClipBoundary__SWIG_1(IntPtr pBoundary, IntPtr pClipInfo)
	{
		try
		{
			pushClipBoundary((pBoundary == IntPtr.Zero) ? null : new OdGiClipBoundary(pBoundary, cMemoryOwn: false), (pClipInfo == IntPtr.Zero) ? null : new OdGiAbstractClipBoundary(pClipInfo, cMemoryOwn: false));
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

	private void SwigDirectorMethodpopClipBoundary()
	{
		try
		{
			popClipBoundary();
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

	private void SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_0()
	{
		try
		{
			setEntityTraitsDataChanged();
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

	private void SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_1(int bit, bool value)
	{
		try
		{
			setEntityTraitsDataChanged(bit, value);
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

	private void SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_2(int bit)
	{
		try
		{
			setEntityTraitsDataChanged(bit);
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

	private void SwigDirectorMethodpushMetafileTransform__SWIG_0(IntPtr arg0, uint arg1)
	{
		try
		{
			pushMetafileTransform(new OdGeMatrix3d(arg0, cMemoryOwn: false), arg1);
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

	private void SwigDirectorMethodpushMetafileTransform__SWIG_1(IntPtr arg0)
	{
		try
		{
			pushMetafileTransform(new OdGeMatrix3d(arg0, cMemoryOwn: false));
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

	private void SwigDirectorMethodpopMetafileTransform__SWIG_0(uint arg0)
	{
		try
		{
			popMetafileTransform(arg0);
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

	private void SwigDirectorMethodpopMetafileTransform__SWIG_1()
	{
		try
		{
			popMetafileTransform();
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

	private bool SwigDirectorMethoduseSharedBlockReferences()
	{
		return useSharedBlockReferences();
	}

	private bool SwigDirectorMethoduseMetafileAsGeometry()
	{
		return useMetafileAsGeometry();
	}

	private IntPtr SwigDirectorMethodoutputForMetafileGeometry()
	{
		return outputForMetafileGeometry().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodsetTransformForMetafileGeometry(IntPtr arg0)
	{
		try
		{
			setTransformForMetafileGeometry(new OdGeMatrix3d(arg0, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodgetTransformForMetafileGeometry()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getTransformForMetafileGeometry()).Handle;
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

	private void SwigDirectorMethodreportUpdateError(IntPtr arg0, IntPtr error)
	{
		try
		{
			reportUpdateError((arg0 == IntPtr.Zero) ? null : new OdDbStub(arg0, cMemoryOwn: false), new OdError(error, cMemoryOwn: false));
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

	private void SwigDirectorMethodapplySubentityTransform(IntPtr pXform)
	{
		try
		{
			applySubentityTransform((pXform == IntPtr.Zero) ? null : new OdGeMatrix3d(pXform, cMemoryOwn: false));
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

	private bool SwigDirectorMethodisDragging()
	{
		return isDragging();
	}

	private IntPtr SwigDirectorMethodgsExtentsOutput()
	{
		return gsExtentsOutput().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodsetAnalyticLinetypingCircles(bool analytic)
	{
		try
		{
			setAnalyticLinetypingCircles(analytic);
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

	private bool SwigDirectorMethodisAnalyticLinetypingCircles()
	{
		return isAnalyticLinetypingCircles();
	}

	private void SwigDirectorMethodsetAnalyticLinetypingComplexCurves(bool analytic)
	{
		try
		{
			setAnalyticLinetypingComplexCurves(analytic);
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

	private bool SwigDirectorMethodisAnalyticLinetypingComplexCurves()
	{
		return isAnalyticLinetypingComplexCurves();
	}

	private bool SwigDirectorMethoddisplayViewportProperties__SWIG_0(IntPtr pdro, uint incFlags)
	{
		return displayViewportProperties((pdro == IntPtr.Zero) ? null : new OdGsPropertiesDirectRenderOutput(pdro, cMemoryOwn: false), incFlags);
	}

	private bool SwigDirectorMethoddisplayViewportProperties__SWIG_1(IntPtr pdro)
	{
		return displayViewportProperties((pdro == IntPtr.Zero) ? null : new OdGsPropertiesDirectRenderOutput(pdro, cMemoryOwn: false));
	}

	private bool SwigDirectorMethoddisplayViewportProperties__SWIG_2()
	{
		return displayViewportProperties();
	}

	private bool SwigDirectorMethodregenAbort()
	{
		return regenAbort();
	}

	private bool SwigDirectorMethoddoDraw(uint drawableFlags, IntPtr pDrawable)
	{
		return doDraw(drawableFlags, Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodoutput()
	{
		return output().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodsetVisualStyle(IntPtr visualStyle)
	{
		try
		{
			setVisualStyle(Helpers.GetRXObject<OdGiVisualStyle>(visualStyle, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodisSpatialIndexDisabled()
	{
		return isSpatialIndexDisabled();
	}

	private void SwigDirectorMethodbeginMetafileRecording(IntPtr pGeomPortion)
	{
		try
		{
			beginMetafileRecording((pGeomPortion == IntPtr.Zero) ? null : new OdGsGeomPortion(pGeomPortion, cMemoryOwn: false));
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

	private void SwigDirectorMethodendMetafileRecording()
	{
		try
		{
			endMetafileRecording();
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

	private void SwigDirectorMethoddoRayTrace(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList, uint nObjectListSize)
	{
		try
		{
			doRayTrace(new OdGePoint3d(rayOrigin, cMemoryOwn: false), new OdGeVector3d(rayDirection, cMemoryOwn: false), (pReactor == IntPtr.Zero) ? null : new OdGsRayTraceReactor(pReactor, cMemoryOwn: false), bSortedSelection, pObjectList, nObjectListSize);
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

	private void SwigDirectorMethodswitchOverlay(int overlayId)
	{
		try
		{
			switchOverlay((OdGsOverlayId)overlayId);
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

	private void SwigDirectorMethoddisplayNode(IntPtr node, IntPtr ctx)
	{
		OdSwigDirectorHelper.director_UnpackData(node, out var pOriginalObject, out var pFunction);
		OdGsNode node2 = Helpers.GetRXObject<OdGsNode>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		OdGsDisplayContext ctx2 = new OdGsDisplayContext(ctx, cMemoryOwn: true);
		try
		{
			displayNode(ref node2, ctx2);
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
			IntPtr handle = OdGsNode.getCPtr(node2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(node);
		}
	}

	private void SwigDirectorMethoddisplaySubnode(IntPtr node, IntPtr ctx, bool bHighlighted)
	{
		OdSwigDirectorHelper.director_UnpackData(node, out var pOriginalObject, out var pFunction);
		OdGsEntityNode node2 = Helpers.GetRXObject<OdGsEntityNode>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		OdGsDisplayContext ctx2 = new OdGsDisplayContext(ctx, cMemoryOwn: true);
		try
		{
			displaySubnode(ref node2, ctx2, bHighlighted);
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
			IntPtr handle = OdGsEntityNode.getCPtr(node2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(node);
		}
	}

	private bool SwigDirectorMethodupdateExtentsOnly()
	{
		return updateExtentsOnly();
	}

	private uint SwigDirectorMethodsetAttributes(IntPtr pDrawable)
	{
		return setAttributes(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodrenderAbort()
	{
		return renderAbort();
	}

	private void SwigDirectorMethoddoCollide__SWIG_0(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize, IntPtr pCtx)
	{
		try
		{
			doCollide(pInputList, nInputListSize, (pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false), pCollisionWithList, nCollisionWithListSize, (pCtx == IntPtr.Zero) ? null : new OdGsCollisionDetectionContext(pCtx, cMemoryOwn: false));
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

	private void SwigDirectorMethoddoCollide__SWIG_1(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize)
	{
		try
		{
			doCollide(pInputList, nInputListSize, (pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false), pCollisionWithList, nCollisionWithListSize);
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

	private void SwigDirectorMethoddoCollide__SWIG_2(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList)
	{
		try
		{
			doCollide(pInputList, nInputListSize, (pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false), pCollisionWithList);
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

	private void SwigDirectorMethoddoCollide__SWIG_3(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor)
	{
		try
		{
			doCollide(pInputList, nInputListSize, (pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false));
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

	private void SwigDirectorMethoddoCollideAll__SWIG_0(IntPtr pReactor, IntPtr pCtx)
	{
		try
		{
			doCollideAll((pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false), (pCtx == IntPtr.Zero) ? null : new OdGsCollisionDetectionContext(pCtx, cMemoryOwn: false));
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

	private void SwigDirectorMethoddoCollideAll__SWIG_1(IntPtr pReactor)
	{
		try
		{
			doCollideAll((pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false));
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

	private void SwigDirectorMethodclearLinetypeCache()
	{
		try
		{
			clearLinetypeCache();
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

	private void SwigDirectorMethodinit__SWIG_0(IntPtr pDevice, IntPtr pViewInfo, bool enableLayerVisibilityPerView)
	{
		try
		{
			init(Helpers.GetRXObject<OdGsBaseVectorizeDevice>(pDevice, bOwn: false, bTryAddToTransaction: false), (pViewInfo == IntPtr.Zero) ? null : new OdGsClientViewInfo(pViewInfo, cMemoryOwn: false), enableLayerVisibilityPerView);
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

	private void SwigDirectorMethodinit__SWIG_1(IntPtr pDevice, IntPtr pViewInfo)
	{
		try
		{
			init(Helpers.GetRXObject<OdGsBaseVectorizeDevice>(pDevice, bOwn: false, bTryAddToTransaction: false), (pViewInfo == IntPtr.Zero) ? null : new OdGsClientViewInfo(pViewInfo, cMemoryOwn: false));
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

	private void SwigDirectorMethodinit__SWIG_2(IntPtr pDevice)
	{
		try
		{
			init(Helpers.GetRXObject<OdGsBaseVectorizeDevice>(pDevice, bOwn: false, bTryAddToTransaction: false));
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

	private uint SwigDirectorMethodnumVectorizers()
	{
		return numVectorizers();
	}

	private IntPtr SwigDirectorMethodgetVectorizer(bool arg0)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGsBaseVectorizer.getCPtr(getVectorizer(arg0)).Handle;
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

	private void SwigDirectorMethodreleaseVectorizer(IntPtr arg0)
	{
		try
		{
			releaseVectorizer((arg0 == IntPtr.Zero) ? null : new OdGsBaseVectorizer(arg0, cMemoryOwn: false));
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

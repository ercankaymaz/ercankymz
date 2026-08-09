using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBaseVectorizeViewDef : TempOdGsBaseVectorizeViewJoin
{
	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_0();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_1();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_2();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_3();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_4(IntPtr point);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_5(IntPtr point);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_6();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_7();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_8();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_9();

	public delegate uint SwigDelegateOdGsBaseVectorizeViewDef_10();

	public delegate short SwigDelegateOdGsBaseVectorizeViewDef_11();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_12(IntPtr lowerLeft, IntPtr upperRight);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_13(bool clipFront, bool clipBack, double front, double back);

	public delegate double SwigDelegateOdGsBaseVectorizeViewDef_14();

	public delegate double SwigDelegateOdGsBaseVectorizeViewDef_15();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_16(IntPtr layerId);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_17();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_18();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_19(IntPtr view);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_20();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_21();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_22();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_23();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_24(IntPtr normal);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_25(IntPtr xfm);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_26();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_27(IntPtr firstPoint, IntPtr secondPoint);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_28(IntPtr basePoint, IntPtr throughPoint);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_29(IntPtr numVertices);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_30(IntPtr numRows);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_31(IntPtr newExtents);

	public delegate double SwigDelegateOdGsBaseVectorizeViewDef_32(int deviationType, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdGsBaseVectorizeViewDef_33();

	public delegate uint SwigDelegateOdGsBaseVectorizeViewDef_34();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_35(uint viewportId);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_36();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_37(IntPtr pNormal);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_38();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_39(int fillType);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_40();

	public delegate uint SwigDelegateOdGsBaseVectorizeViewDef_41();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_42(IntPtr pOverride);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_43();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_44(IntPtr pOverride);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_45();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_46();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_47();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_48();

	public delegate double SwigDelegateOdGsBaseVectorizeViewDef_49();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_50();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_51();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_52();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_53();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_54();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_55(IntPtr pDrawable);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_56();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_57(IntPtr pMetafile);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_58(IntPtr pMetafile);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_59(IntPtr pMetafile);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_60(IntPtr pMetafile, IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_61(IntPtr pFiler);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_62();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_63();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_64();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_65();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_66();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_67(IntPtr materialId, IntPtr pNode);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_68(IntPtr pNode, IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_69(IntPtr pNode, IntPtr pFiler);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_70(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_71(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_72(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_73(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_74(IntPtr pBoundary);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_75(IntPtr pBoundary, IntPtr pClipInfo);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_76();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_77();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_78(int bit, bool value);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_79(int bit);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_80(IntPtr arg0, uint arg1);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_81(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_82(uint arg0);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_83();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_84();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_85();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_86();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_87(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_88();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_89(IntPtr arg0, IntPtr error);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_90(IntPtr pXform);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_91();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_92();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_93(bool analytic);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_94();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_95(bool analytic);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_96();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_97(IntPtr pdro, uint incFlags);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_98(IntPtr pdro);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_99();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_100();

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_101(uint drawableFlags, IntPtr pDrawable);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_102(IntPtr selectionMarker);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeViewDef_103();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_104(IntPtr visualStyle);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_105();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_106(IntPtr pGeomPortion);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_107();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_108(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList, uint nObjectListSize);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_109(int overlayId);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_110(IntPtr node, IntPtr ctx);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_111(IntPtr node, IntPtr ctx, bool bHighlighted);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_112();

	public delegate uint SwigDelegateOdGsBaseVectorizeViewDef_113(IntPtr pDrawable);

	public delegate bool SwigDelegateOdGsBaseVectorizeViewDef_114();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_115(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize, IntPtr pCtx);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_116(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_117(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_118(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_119(IntPtr pReactor, IntPtr pCtx);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_120(IntPtr pReactor);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_121();

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_122(IntPtr pDevice, IntPtr pViewInfo, bool enableLayerVisibilityPerView);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_123(IntPtr pDevice, IntPtr pViewInfo);

	public delegate void SwigDelegateOdGsBaseVectorizeViewDef_124(IntPtr pDevice);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsBaseVectorizeViewDef_0 swigDelegate0;

	private SwigDelegateOdGsBaseVectorizeViewDef_1 swigDelegate1;

	private SwigDelegateOdGsBaseVectorizeViewDef_2 swigDelegate2;

	private SwigDelegateOdGsBaseVectorizeViewDef_3 swigDelegate3;

	private SwigDelegateOdGsBaseVectorizeViewDef_4 swigDelegate4;

	private SwigDelegateOdGsBaseVectorizeViewDef_5 swigDelegate5;

	private SwigDelegateOdGsBaseVectorizeViewDef_6 swigDelegate6;

	private SwigDelegateOdGsBaseVectorizeViewDef_7 swigDelegate7;

	private SwigDelegateOdGsBaseVectorizeViewDef_8 swigDelegate8;

	private SwigDelegateOdGsBaseVectorizeViewDef_9 swigDelegate9;

	private SwigDelegateOdGsBaseVectorizeViewDef_10 swigDelegate10;

	private SwigDelegateOdGsBaseVectorizeViewDef_11 swigDelegate11;

	private SwigDelegateOdGsBaseVectorizeViewDef_12 swigDelegate12;

	private SwigDelegateOdGsBaseVectorizeViewDef_13 swigDelegate13;

	private SwigDelegateOdGsBaseVectorizeViewDef_14 swigDelegate14;

	private SwigDelegateOdGsBaseVectorizeViewDef_15 swigDelegate15;

	private SwigDelegateOdGsBaseVectorizeViewDef_16 swigDelegate16;

	private SwigDelegateOdGsBaseVectorizeViewDef_17 swigDelegate17;

	private SwigDelegateOdGsBaseVectorizeViewDef_18 swigDelegate18;

	private SwigDelegateOdGsBaseVectorizeViewDef_19 swigDelegate19;

	private SwigDelegateOdGsBaseVectorizeViewDef_20 swigDelegate20;

	private SwigDelegateOdGsBaseVectorizeViewDef_21 swigDelegate21;

	private SwigDelegateOdGsBaseVectorizeViewDef_22 swigDelegate22;

	private SwigDelegateOdGsBaseVectorizeViewDef_23 swigDelegate23;

	private SwigDelegateOdGsBaseVectorizeViewDef_24 swigDelegate24;

	private SwigDelegateOdGsBaseVectorizeViewDef_25 swigDelegate25;

	private SwigDelegateOdGsBaseVectorizeViewDef_26 swigDelegate26;

	private SwigDelegateOdGsBaseVectorizeViewDef_27 swigDelegate27;

	private SwigDelegateOdGsBaseVectorizeViewDef_28 swigDelegate28;

	private SwigDelegateOdGsBaseVectorizeViewDef_29 swigDelegate29;

	private SwigDelegateOdGsBaseVectorizeViewDef_30 swigDelegate30;

	private SwigDelegateOdGsBaseVectorizeViewDef_31 swigDelegate31;

	private SwigDelegateOdGsBaseVectorizeViewDef_32 swigDelegate32;

	private SwigDelegateOdGsBaseVectorizeViewDef_33 swigDelegate33;

	private SwigDelegateOdGsBaseVectorizeViewDef_34 swigDelegate34;

	private SwigDelegateOdGsBaseVectorizeViewDef_35 swigDelegate35;

	private SwigDelegateOdGsBaseVectorizeViewDef_36 swigDelegate36;

	private SwigDelegateOdGsBaseVectorizeViewDef_37 swigDelegate37;

	private SwigDelegateOdGsBaseVectorizeViewDef_38 swigDelegate38;

	private SwigDelegateOdGsBaseVectorizeViewDef_39 swigDelegate39;

	private SwigDelegateOdGsBaseVectorizeViewDef_40 swigDelegate40;

	private SwigDelegateOdGsBaseVectorizeViewDef_41 swigDelegate41;

	private SwigDelegateOdGsBaseVectorizeViewDef_42 swigDelegate42;

	private SwigDelegateOdGsBaseVectorizeViewDef_43 swigDelegate43;

	private SwigDelegateOdGsBaseVectorizeViewDef_44 swigDelegate44;

	private SwigDelegateOdGsBaseVectorizeViewDef_45 swigDelegate45;

	private SwigDelegateOdGsBaseVectorizeViewDef_46 swigDelegate46;

	private SwigDelegateOdGsBaseVectorizeViewDef_47 swigDelegate47;

	private SwigDelegateOdGsBaseVectorizeViewDef_48 swigDelegate48;

	private SwigDelegateOdGsBaseVectorizeViewDef_49 swigDelegate49;

	private SwigDelegateOdGsBaseVectorizeViewDef_50 swigDelegate50;

	private SwigDelegateOdGsBaseVectorizeViewDef_51 swigDelegate51;

	private SwigDelegateOdGsBaseVectorizeViewDef_52 swigDelegate52;

	private SwigDelegateOdGsBaseVectorizeViewDef_53 swigDelegate53;

	private SwigDelegateOdGsBaseVectorizeViewDef_54 swigDelegate54;

	private SwigDelegateOdGsBaseVectorizeViewDef_55 swigDelegate55;

	private SwigDelegateOdGsBaseVectorizeViewDef_56 swigDelegate56;

	private SwigDelegateOdGsBaseVectorizeViewDef_57 swigDelegate57;

	private SwigDelegateOdGsBaseVectorizeViewDef_58 swigDelegate58;

	private SwigDelegateOdGsBaseVectorizeViewDef_59 swigDelegate59;

	private SwigDelegateOdGsBaseVectorizeViewDef_60 swigDelegate60;

	private SwigDelegateOdGsBaseVectorizeViewDef_61 swigDelegate61;

	private SwigDelegateOdGsBaseVectorizeViewDef_62 swigDelegate62;

	private SwigDelegateOdGsBaseVectorizeViewDef_63 swigDelegate63;

	private SwigDelegateOdGsBaseVectorizeViewDef_64 swigDelegate64;

	private SwigDelegateOdGsBaseVectorizeViewDef_65 swigDelegate65;

	private SwigDelegateOdGsBaseVectorizeViewDef_66 swigDelegate66;

	private SwigDelegateOdGsBaseVectorizeViewDef_67 swigDelegate67;

	private SwigDelegateOdGsBaseVectorizeViewDef_68 swigDelegate68;

	private SwigDelegateOdGsBaseVectorizeViewDef_69 swigDelegate69;

	private SwigDelegateOdGsBaseVectorizeViewDef_70 swigDelegate70;

	private SwigDelegateOdGsBaseVectorizeViewDef_71 swigDelegate71;

	private SwigDelegateOdGsBaseVectorizeViewDef_72 swigDelegate72;

	private SwigDelegateOdGsBaseVectorizeViewDef_73 swigDelegate73;

	private SwigDelegateOdGsBaseVectorizeViewDef_74 swigDelegate74;

	private SwigDelegateOdGsBaseVectorizeViewDef_75 swigDelegate75;

	private SwigDelegateOdGsBaseVectorizeViewDef_76 swigDelegate76;

	private SwigDelegateOdGsBaseVectorizeViewDef_77 swigDelegate77;

	private SwigDelegateOdGsBaseVectorizeViewDef_78 swigDelegate78;

	private SwigDelegateOdGsBaseVectorizeViewDef_79 swigDelegate79;

	private SwigDelegateOdGsBaseVectorizeViewDef_80 swigDelegate80;

	private SwigDelegateOdGsBaseVectorizeViewDef_81 swigDelegate81;

	private SwigDelegateOdGsBaseVectorizeViewDef_82 swigDelegate82;

	private SwigDelegateOdGsBaseVectorizeViewDef_83 swigDelegate83;

	private SwigDelegateOdGsBaseVectorizeViewDef_84 swigDelegate84;

	private SwigDelegateOdGsBaseVectorizeViewDef_85 swigDelegate85;

	private SwigDelegateOdGsBaseVectorizeViewDef_86 swigDelegate86;

	private SwigDelegateOdGsBaseVectorizeViewDef_87 swigDelegate87;

	private SwigDelegateOdGsBaseVectorizeViewDef_88 swigDelegate88;

	private SwigDelegateOdGsBaseVectorizeViewDef_89 swigDelegate89;

	private SwigDelegateOdGsBaseVectorizeViewDef_90 swigDelegate90;

	private SwigDelegateOdGsBaseVectorizeViewDef_91 swigDelegate91;

	private SwigDelegateOdGsBaseVectorizeViewDef_92 swigDelegate92;

	private SwigDelegateOdGsBaseVectorizeViewDef_93 swigDelegate93;

	private SwigDelegateOdGsBaseVectorizeViewDef_94 swigDelegate94;

	private SwigDelegateOdGsBaseVectorizeViewDef_95 swigDelegate95;

	private SwigDelegateOdGsBaseVectorizeViewDef_96 swigDelegate96;

	private SwigDelegateOdGsBaseVectorizeViewDef_97 swigDelegate97;

	private SwigDelegateOdGsBaseVectorizeViewDef_98 swigDelegate98;

	private SwigDelegateOdGsBaseVectorizeViewDef_99 swigDelegate99;

	private SwigDelegateOdGsBaseVectorizeViewDef_100 swigDelegate100;

	private SwigDelegateOdGsBaseVectorizeViewDef_101 swigDelegate101;

	private SwigDelegateOdGsBaseVectorizeViewDef_102 swigDelegate102;

	private SwigDelegateOdGsBaseVectorizeViewDef_103 swigDelegate103;

	private SwigDelegateOdGsBaseVectorizeViewDef_104 swigDelegate104;

	private SwigDelegateOdGsBaseVectorizeViewDef_105 swigDelegate105;

	private SwigDelegateOdGsBaseVectorizeViewDef_106 swigDelegate106;

	private SwigDelegateOdGsBaseVectorizeViewDef_107 swigDelegate107;

	private SwigDelegateOdGsBaseVectorizeViewDef_108 swigDelegate108;

	private SwigDelegateOdGsBaseVectorizeViewDef_109 swigDelegate109;

	private SwigDelegateOdGsBaseVectorizeViewDef_110 swigDelegate110;

	private SwigDelegateOdGsBaseVectorizeViewDef_111 swigDelegate111;

	private SwigDelegateOdGsBaseVectorizeViewDef_112 swigDelegate112;

	private SwigDelegateOdGsBaseVectorizeViewDef_113 swigDelegate113;

	private SwigDelegateOdGsBaseVectorizeViewDef_114 swigDelegate114;

	private SwigDelegateOdGsBaseVectorizeViewDef_115 swigDelegate115;

	private SwigDelegateOdGsBaseVectorizeViewDef_116 swigDelegate116;

	private SwigDelegateOdGsBaseVectorizeViewDef_117 swigDelegate117;

	private SwigDelegateOdGsBaseVectorizeViewDef_118 swigDelegate118;

	private SwigDelegateOdGsBaseVectorizeViewDef_119 swigDelegate119;

	private SwigDelegateOdGsBaseVectorizeViewDef_120 swigDelegate120;

	private SwigDelegateOdGsBaseVectorizeViewDef_121 swigDelegate121;

	private SwigDelegateOdGsBaseVectorizeViewDef_122 swigDelegate122;

	private SwigDelegateOdGsBaseVectorizeViewDef_123 swigDelegate123;

	private SwigDelegateOdGsBaseVectorizeViewDef_124 swigDelegate124;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdGePoint2d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes13 = new Type[4]
	{
		typeof(bool).MakeByRefType(),
		typeof(bool).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdGsViewImpl).MakeByRefType() };

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes28 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(ShellData) };

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(MeshData) };

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes32 = new Type[2]
	{
		typeof(OdGiDeviationType),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes33 = new Type[0];

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes38 = new Type[0];

	private static Type[] swigMethodTypes39 = new Type[1] { typeof(OdGiFillType) };

	private static Type[] swigMethodTypes40 = new Type[0];

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(OdGiLineweightOverride) };

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdGiPalette) };

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[0];

	private static Type[] swigMethodTypes47 = new Type[0];

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[0];

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[0];

	private static Type[] swigMethodTypes52 = new Type[0];

	private static Type[] swigMethodTypes53 = new Type[0];

	private static Type[] swigMethodTypes54 = new Type[0];

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes56 = new Type[0];

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes60 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGsFiler)
	};

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(OdGsFiler) };

	private static Type[] swigMethodTypes62 = new Type[0];

	private static Type[] swigMethodTypes63 = new Type[0];

	private static Type[] swigMethodTypes64 = new Type[0];

	private static Type[] swigMethodTypes65 = new Type[0];

	private static Type[] swigMethodTypes66 = new Type[0];

	private static Type[] swigMethodTypes67 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdGsMaterialNode)
	};

	private static Type[] swigMethodTypes68 = new Type[2]
	{
		typeof(OdGsMaterialNode),
		typeof(OdGsFiler)
	};

	private static Type[] swigMethodTypes69 = new Type[2]
	{
		typeof(OdGsMaterialNode),
		typeof(OdGsFiler)
	};

	private static Type[] swigMethodTypes70 = new Type[1] { typeof(OdGiPointLightTraitsData) };

	private static Type[] swigMethodTypes71 = new Type[1] { typeof(OdGiSpotLightTraitsData) };

	private static Type[] swigMethodTypes72 = new Type[1] { typeof(OdGiDistantLightTraitsData) };

	private static Type[] swigMethodTypes73 = new Type[1] { typeof(OdGiWebLightTraitsData) };

	private static Type[] swigMethodTypes74 = new Type[1] { typeof(OdGiClipBoundary) };

	private static Type[] swigMethodTypes75 = new Type[2]
	{
		typeof(OdGiClipBoundary),
		typeof(OdGiAbstractClipBoundary)
	};

	private static Type[] swigMethodTypes76 = new Type[0];

	private static Type[] swigMethodTypes77 = new Type[0];

	private static Type[] swigMethodTypes78 = new Type[2]
	{
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes80 = new Type[2]
	{
		typeof(OdGeMatrix3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes81 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes82 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes83 = new Type[0];

	private static Type[] swigMethodTypes84 = new Type[0];

	private static Type[] swigMethodTypes85 = new Type[0];

	private static Type[] swigMethodTypes86 = new Type[0];

	private static Type[] swigMethodTypes87 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes88 = new Type[0];

	private static Type[] swigMethodTypes89 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdError)
	};

	private static Type[] swigMethodTypes90 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes91 = new Type[0];

	private static Type[] swigMethodTypes92 = new Type[0];

	private static Type[] swigMethodTypes93 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes94 = new Type[0];

	private static Type[] swigMethodTypes95 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes96 = new Type[0];

	private static Type[] swigMethodTypes97 = new Type[2]
	{
		typeof(OdGsPropertiesDirectRenderOutput),
		typeof(uint)
	};

	private static Type[] swigMethodTypes98 = new Type[1] { typeof(OdGsPropertiesDirectRenderOutput) };

	private static Type[] swigMethodTypes99 = new Type[0];

	private static Type[] swigMethodTypes100 = new Type[0];

	private static Type[] swigMethodTypes101 = new Type[2]
	{
		typeof(uint),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes102 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes103 = new Type[0];

	private static Type[] swigMethodTypes104 = new Type[1] { typeof(OdGiVisualStyle) };

	private static Type[] swigMethodTypes105 = new Type[0];

	private static Type[] swigMethodTypes106 = new Type[1] { typeof(OdGsGeomPortion) };

	private static Type[] swigMethodTypes107 = new Type[0];

	private static Type[] swigMethodTypes108 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGsRayTraceReactor),
		typeof(bool),
		typeof(OdGiPathNode[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes109 = new Type[1] { typeof(OdGsOverlayId) };

	private static Type[] swigMethodTypes110 = new Type[2]
	{
		typeof(OdGsNode).MakeByRefType(),
		typeof(OdGsDisplayContext)
	};

	private static Type[] swigMethodTypes111 = new Type[3]
	{
		typeof(OdGsEntityNode).MakeByRefType(),
		typeof(OdGsDisplayContext),
		typeof(bool)
	};

	private static Type[] swigMethodTypes112 = new Type[0];

	private static Type[] swigMethodTypes113 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes114 = new Type[0];

	private static Type[] swigMethodTypes115 = new Type[6]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionContext)
	};

	private static Type[] swigMethodTypes116 = new Type[5]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGiPathNode[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes117 = new Type[4]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGiPathNode[])
	};

	private static Type[] swigMethodTypes118 = new Type[3]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor)
	};

	private static Type[] swigMethodTypes119 = new Type[2]
	{
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGsCollisionDetectionContext)
	};

	private static Type[] swigMethodTypes120 = new Type[1] { typeof(OdGsCollisionDetectionReactor) };

	private static Type[] swigMethodTypes121 = new Type[0];

	private static Type[] swigMethodTypes122 = new Type[3]
	{
		typeof(OdGsBaseVectorizeDevice),
		typeof(OdGsClientViewInfo),
		typeof(bool)
	};

	private static Type[] swigMethodTypes123 = new Type[2]
	{
		typeof(OdGsBaseVectorizeDevice),
		typeof(OdGsClientViewInfo)
	};

	private static Type[] swigMethodTypes124 = new Type[1] { typeof(OdGsBaseVectorizeDevice) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBaseVectorizeViewDef(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeViewDef_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBaseVectorizeViewDef obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseVectorizeViewDef(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGsBaseVectorizeViewDef()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBaseVectorizeViewDef(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsBaseVectorizeViewDef) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getModelToEyeTransform", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetModelToEyeTransform;
		}
		if (SwigDerivedClassHasMethod("getEyeToModelTransform", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetEyeToModelTransform;
		}
		if (SwigDerivedClassHasMethod("getWorldToEyeTransform", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetWorldToEyeTransform;
		}
		if (SwigDerivedClassHasMethod("getEyeToWorldTransform", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetEyeToWorldTransform;
		}
		if (SwigDerivedClassHasMethod("doPerspective", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddoPerspective;
		}
		if (SwigDerivedClassHasMethod("doInversePerspective", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoddoInversePerspective;
		}
		if (SwigDerivedClassHasMethod("getCameraLocation", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetCameraLocation;
		}
		if (SwigDerivedClassHasMethod("getCameraTarget", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetCameraTarget;
		}
		if (SwigDerivedClassHasMethod("getCameraUpVector", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetCameraUpVector;
		}
		if (SwigDerivedClassHasMethod("viewDir", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodviewDir;
		}
		if (SwigDerivedClassHasMethod("viewportId", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodviewportId;
		}
		if (SwigDerivedClassHasMethod("acadWindowId", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodacadWindowId;
		}
		if (SwigDerivedClassHasMethod("getViewportDcCorners", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetViewportDcCorners;
		}
		if (SwigDerivedClassHasMethod("getFrontAndBackClipValues", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetFrontAndBackClipValues;
		}
		if (SwigDerivedClassHasMethod("linetypeScaleMultiplier", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodlinetypeScaleMultiplier;
		}
		if (SwigDerivedClassHasMethod("linetypeGenerationCriteria", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodlinetypeGenerationCriteria;
		}
		if (SwigDerivedClassHasMethod("layerVisible", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodlayerVisible;
		}
		if (SwigDerivedClassHasMethod("contextualColors", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodcontextualColors;
		}
		if (SwigDerivedClassHasMethod("annotationScaleId", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodannotationScaleId;
		}
		if (SwigDerivedClassHasMethod("setUp", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetUp;
		}
		if (SwigDerivedClassHasMethod("objectToDeviceMatrix", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodobjectToDeviceMatrix;
		}
		if (SwigDerivedClassHasMethod("currentLineweightOverride", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodcurrentLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("getWorldToModelTransform", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodgetWorldToModelTransform;
		}
		if (SwigDerivedClassHasMethod("getModelToWorldTransform", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodgetModelToWorldTransform;
		}
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodpushModelTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodpushModelTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("popModelTransform", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodpopModelTransform;
		}
		if (SwigDerivedClassHasMethod("xline", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodxline;
		}
		if (SwigDerivedClassHasMethod("ray", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodray;
		}
		if (SwigDerivedClassHasMethod("shell", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodshell;
		}
		if (SwigDerivedClassHasMethod("mesh", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodmesh;
		}
		if (SwigDerivedClassHasMethod("setExtents", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodsetExtents;
		}
		if (SwigDerivedClassHasMethod("deviation", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethoddeviation;
		}
		if (SwigDerivedClassHasMethod("regenType", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodregenType;
		}
		if (SwigDerivedClassHasMethod("sequenceNumber", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodsequenceNumber;
		}
		if (SwigDerivedClassHasMethod("isValidId", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodisValidId;
		}
		if (SwigDerivedClassHasMethod("viewportObjectId", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodviewportObjectId;
		}
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodsetFillPlane__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodsetFillPlane__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setFillType", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodsetFillType;
		}
		if (SwigDerivedClassHasMethod("visualStyle", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodvisualStyle;
		}
		if (SwigDerivedClassHasMethod("setupForEntity", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodsetupForEntity;
		}
		if (SwigDerivedClassHasMethod("pushLineweightOverride", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodpushLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("popLineweightOverride", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodpopLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("pushPaletteOverride", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodpushPaletteOverride;
		}
		if (SwigDerivedClassHasMethod("popPaletteOverride", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodpopPaletteOverride;
		}
		if (SwigDerivedClassHasMethod("hasPaletteOverrides", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodhasPaletteOverrides;
		}
		if (SwigDerivedClassHasMethod("giViewport", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodgiViewport;
		}
		if (SwigDerivedClassHasMethod("gsView", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodgsView;
		}
		if (SwigDerivedClassHasMethod("annotationScale", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodannotationScale;
		}
		if (SwigDerivedClassHasMethod("beginViewVectorization", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodbeginViewVectorization;
		}
		if (SwigDerivedClassHasMethod("endViewVectorization", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodendViewVectorization;
		}
		if (SwigDerivedClassHasMethod("onTraitsModified", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodonTraitsModified;
		}
		if (SwigDerivedClassHasMethod("effectiveTraits", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodeffectiveTraits;
		}
		if (SwigDerivedClassHasMethod("metafileTransform", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodmetafileTransform;
		}
		if (SwigDerivedClassHasMethod("draw", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethoddraw;
		}
		if (SwigDerivedClassHasMethod("newGsMetafile", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodnewGsMetafile;
		}
		if (SwigDerivedClassHasMethod("beginMetafile", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodbeginMetafile;
		}
		if (SwigDerivedClassHasMethod("endMetafile", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodendMetafile;
		}
		if (SwigDerivedClassHasMethod("playMetafile", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodplayMetafile;
		}
		if (SwigDerivedClassHasMethod("saveMetafile", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodsaveMetafile;
		}
		if (SwigDerivedClassHasMethod("loadMetafile", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodloadMetafile;
		}
		if (SwigDerivedClassHasMethod("loadViewport", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodloadViewport;
		}
		if (SwigDerivedClassHasMethod("forceMetafilesDependence", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodforceMetafilesDependence;
		}
		if (SwigDerivedClassHasMethod("isViewRegenerated", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodisViewRegenerated;
		}
		if (SwigDerivedClassHasMethod("drawViewportFrame", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethoddrawViewportFrame;
		}
		if (SwigDerivedClassHasMethod("updateViewport", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodupdateViewport;
		}
		if (SwigDerivedClassHasMethod("processMaterialNode", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodprocessMaterialNode;
		}
		if (SwigDerivedClassHasMethod("saveMaterialCache", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodsaveMaterialCache;
		}
		if (SwigDerivedClassHasMethod("loadMaterialCache", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodloadMaterialCache;
		}
		if (SwigDerivedClassHasMethod("addPointLight", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodaddPointLight;
		}
		if (SwigDerivedClassHasMethod("addSpotLight", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodaddSpotLight;
		}
		if (SwigDerivedClassHasMethod("addDistantLight", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodaddDistantLight;
		}
		if (SwigDerivedClassHasMethod("addWebLight", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodaddWebLight;
		}
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodpushClipBoundary__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodpushClipBoundary__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("popClipBoundary", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodpopClipBoundary;
		}
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("pushMetafileTransform", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodpushMetafileTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushMetafileTransform", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodpushMetafileTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("popMetafileTransform", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodpopMetafileTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("popMetafileTransform", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodpopMetafileTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("useSharedBlockReferences", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethoduseSharedBlockReferences;
		}
		if (SwigDerivedClassHasMethod("useMetafileAsGeometry", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethoduseMetafileAsGeometry;
		}
		if (SwigDerivedClassHasMethod("outputForMetafileGeometry", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodoutputForMetafileGeometry;
		}
		if (SwigDerivedClassHasMethod("setTransformForMetafileGeometry", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodsetTransformForMetafileGeometry;
		}
		if (SwigDerivedClassHasMethod("getTransformForMetafileGeometry", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodgetTransformForMetafileGeometry;
		}
		if (SwigDerivedClassHasMethod("reportUpdateError", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodreportUpdateError;
		}
		if (SwigDerivedClassHasMethod("applySubentityTransform", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodapplySubentityTransform;
		}
		if (SwigDerivedClassHasMethod("isDragging", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodisDragging;
		}
		if (SwigDerivedClassHasMethod("gsExtentsOutput", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodgsExtentsOutput;
		}
		if (SwigDerivedClassHasMethod("setAnalyticLinetypingCircles", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodsetAnalyticLinetypingCircles;
		}
		if (SwigDerivedClassHasMethod("isAnalyticLinetypingCircles", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodisAnalyticLinetypingCircles;
		}
		if (SwigDerivedClassHasMethod("setAnalyticLinetypingComplexCurves", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodsetAnalyticLinetypingComplexCurves;
		}
		if (SwigDerivedClassHasMethod("isAnalyticLinetypingComplexCurves", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodisAnalyticLinetypingComplexCurves;
		}
		if (SwigDerivedClassHasMethod("displayViewportProperties", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethoddisplayViewportProperties__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("displayViewportProperties", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethoddisplayViewportProperties__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("displayViewportProperties", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethoddisplayViewportProperties__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("regenAbort", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodregenAbort;
		}
		if (SwigDerivedClassHasMethod("doDraw", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethoddoDraw;
		}
		if (SwigDerivedClassHasMethod("setSelectionMarker", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethodsetSelectionMarker;
		}
		if (SwigDerivedClassHasMethod("output", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethodoutput;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethodsetVisualStyle;
		}
		if (SwigDerivedClassHasMethod("isSpatialIndexDisabled", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodisSpatialIndexDisabled;
		}
		if (SwigDerivedClassHasMethod("beginMetafileRecording", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethodbeginMetafileRecording;
		}
		if (SwigDerivedClassHasMethod("endMetafileRecording", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodendMetafileRecording;
		}
		if (SwigDerivedClassHasMethod("doRayTrace", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethoddoRayTrace;
		}
		if (SwigDerivedClassHasMethod("switchOverlay", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodswitchOverlay;
		}
		if (SwigDerivedClassHasMethod("displayNode", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethoddisplayNode;
		}
		if (SwigDerivedClassHasMethod("displaySubnode", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethoddisplaySubnode;
		}
		if (SwigDerivedClassHasMethod("updateExtentsOnly", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodupdateExtentsOnly;
		}
		if (SwigDerivedClassHasMethod("setAttributes", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethodsetAttributes;
		}
		if (SwigDerivedClassHasMethod("renderAbort", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodrenderAbort;
		}
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethoddoCollide__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethoddoCollide__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes117))
		{
			swigDelegate117 = SwigDirectorMethoddoCollide__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes118))
		{
			swigDelegate118 = SwigDirectorMethoddoCollide__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("doCollideAll", swigMethodTypes119))
		{
			swigDelegate119 = SwigDirectorMethoddoCollideAll__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("doCollideAll", swigMethodTypes120))
		{
			swigDelegate120 = SwigDirectorMethoddoCollideAll__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("clearLinetypeCache", swigMethodTypes121))
		{
			swigDelegate121 = SwigDirectorMethodclearLinetypeCache;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes122))
		{
			swigDelegate122 = SwigDirectorMethodinit__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes123))
		{
			swigDelegate123 = SwigDirectorMethodinit__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes124))
		{
			swigDelegate124 = SwigDirectorMethodinit__SWIG_2;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeViewDef_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsBaseVectorizeViewDef));
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

	private bool SwigDirectorMethoddoPerspective(IntPtr point)
	{
		return doPerspective(new OdGePoint3d(point, cMemoryOwn: false));
	}

	private bool SwigDirectorMethoddoInversePerspective(IntPtr point)
	{
		return doInversePerspective(new OdGePoint3d(point, cMemoryOwn: false));
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
}

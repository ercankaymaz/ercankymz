using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbEntity : OdDbObject
{
	public delegate IntPtr SwigDelegateOdDbEntity_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbEntity_1();

	public delegate void SwigDelegateOdDbEntity_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbEntity_3();

	public delegate bool SwigDelegateOdDbEntity_4();

	public delegate IntPtr SwigDelegateOdDbEntity_5();

	public delegate void SwigDelegateOdDbEntity_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbEntity_7();

	public delegate void SwigDelegateOdDbEntity_8(IntPtr ownerId);

	public delegate int SwigDelegateOdDbEntity_9(int mode);

	public delegate void SwigDelegateOdDbEntity_10();

	public delegate int SwigDelegateOdDbEntity_11(bool erasing);

	public delegate void SwigDelegateOdDbEntity_12(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbEntity_13(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbEntity_14(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbEntity_15(IntPtr otherId);

	public delegate void SwigDelegateOdDbEntity_16(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbEntity_17(IntPtr pFiler);

	public delegate void SwigDelegateOdDbEntity_18(IntPtr pFiler);

	public delegate int SwigDelegateOdDbEntity_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbEntity_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbEntity_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbEntity_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbEntity_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbEntity_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbEntity_25();

	public delegate IntPtr SwigDelegateOdDbEntity_26([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbEntity_27(IntPtr pRb);

	public delegate void SwigDelegateOdDbEntity_28(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbEntity_29(IntPtr objId);

	public delegate void SwigDelegateOdDbEntity_30(IntPtr objId);

	public delegate void SwigDelegateOdDbEntity_31(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbEntity_32();

	public delegate void SwigDelegateOdDbEntity_33(IntPtr idPair, IntPtr pOwnerObject, IntPtr ownerIdMap);

	public delegate void SwigDelegateOdDbEntity_34(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbEntity_35(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbEntity_36(IntPtr pObject);

	public delegate void SwigDelegateOdDbEntity_37(IntPtr pObject);

	public delegate void SwigDelegateOdDbEntity_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbEntity_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbEntity_40(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbEntity_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbEntity_42(IntPtr pObject);

	public delegate void SwigDelegateOdDbEntity_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbEntity_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbEntity_45(IntPtr objectId);

	public delegate void SwigDelegateOdDbEntity_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbEntity_47(IntPtr pSource);

	public delegate int SwigDelegateOdDbEntity_48(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbEntity_49(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbEntity_50(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbEntity_51(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbEntity_52(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbEntity_53();

	public delegate IntPtr SwigDelegateOdDbEntity_54([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbEntity_55(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbEntity_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbEntity_57(IntPtr pClass);

	public delegate int SwigDelegateOdDbEntity_58(IntPtr color, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_59(IntPtr color);

	public delegate IntPtr SwigDelegateOdDbEntity_60();

	public delegate int SwigDelegateOdDbEntity_61(ushort colorIndex, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_62(ushort colorIndex);

	public delegate int SwigDelegateOdDbEntity_63(IntPtr colorId, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_64(IntPtr colorId);

	public delegate int SwigDelegateOdDbEntity_65(IntPtr transparency, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_66(IntPtr transparency);

	public delegate int SwigDelegateOdDbEntity_67([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_68([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName);

	public delegate int SwigDelegateOdDbEntity_69(int plotStyleNameType, IntPtr plotStyleNameId, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_70(int plotStyleNameType, IntPtr plotStyleNameId);

	public delegate int SwigDelegateOdDbEntity_71(int plotStyleNameType);

	public delegate int SwigDelegateOdDbEntity_72([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbEntity_73([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_74([MarshalAs(UnmanagedType.LPWStr)] string layerName);

	public delegate int SwigDelegateOdDbEntity_75(IntPtr layerId, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbEntity_76(IntPtr layerId, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_77(IntPtr layerId);

	public delegate int SwigDelegateOdDbEntity_78([MarshalAs(UnmanagedType.LPWStr)] string linetypeName, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_79([MarshalAs(UnmanagedType.LPWStr)] string linetypeName);

	public delegate int SwigDelegateOdDbEntity_80(IntPtr linetypeID, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_81(IntPtr linetypeID);

	public delegate int SwigDelegateOdDbEntity_82([MarshalAs(UnmanagedType.LPWStr)] string materialName, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_83([MarshalAs(UnmanagedType.LPWStr)] string materialName);

	public delegate int SwigDelegateOdDbEntity_84(IntPtr materialID, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_85(IntPtr materialID);

	public delegate int SwigDelegateOdDbEntity_86(IntPtr visualStyleId, int vstype, bool doSubents);

	public delegate IntPtr SwigDelegateOdDbEntity_87();

	public delegate void SwigDelegateOdDbEntity_88(IntPtr mapper, bool doSubents);

	public delegate void SwigDelegateOdDbEntity_89(IntPtr mapper);

	public delegate int SwigDelegateOdDbEntity_90(double linetypeScale, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_91(double linetypeScale);

	public delegate int SwigDelegateOdDbEntity_92(int lineWeight, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_93(int lineWeight);

	public delegate bool SwigDelegateOdDbEntity_94();

	public delegate void SwigDelegateOdDbEntity_95(bool castShadows);

	public delegate bool SwigDelegateOdDbEntity_96();

	public delegate void SwigDelegateOdDbEntity_97(bool receiveShadows);

	public delegate int SwigDelegateOdDbEntity_98();

	public delegate bool SwigDelegateOdDbEntity_99();

	public delegate int SwigDelegateOdDbEntity_100(IntPtr plane, OdDb_Planarity planarity);

	public delegate int SwigDelegateOdDbEntity_101(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbEntity_102(IntPtr pBlockRecord);

	public delegate int SwigDelegateOdDbEntity_103(IntPtr entitySet);

	public delegate int SwigDelegateOdDbEntity_104(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbEntity_105(IntPtr pBlockRecord);

	public delegate void SwigDelegateOdDbEntity_106(IntPtr pDb, bool doSubents);

	public delegate void SwigDelegateOdDbEntity_107();

	public delegate void SwigDelegateOdDbEntity_108(int status);

	public delegate void SwigDelegateOdDbEntity_109(IntPtr pWd, int ver);

	public delegate IntPtr SwigDelegateOdDbEntity_110();

	public delegate int SwigDelegateOdDbEntity_111(IntPtr xfm);

	public delegate int SwigDelegateOdDbEntity_112(IntPtr xfm, IntPtr pCopy);

	public delegate int SwigDelegateOdDbEntity_113(IntPtr entitySet);

	public delegate int SwigDelegateOdDbEntity_114(IntPtr xM);

	public delegate bool SwigDelegateOdDbEntity_115();

	public delegate bool SwigDelegateOdDbEntity_116();

	public delegate void SwigDelegateOdDbEntity_117(int status);

	public delegate int SwigDelegateOdDbEntity_118(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints);

	public delegate int SwigDelegateOdDbEntity_119(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insertionMat);

	public delegate bool SwigDelegateOdDbEntity_120();

	public delegate int SwigDelegateOdDbEntity_121(IntPtr gripPoints);

	public delegate int SwigDelegateOdDbEntity_122(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbEntity_123(IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags);

	public delegate int SwigDelegateOdDbEntity_124(IntPtr grips, IntPtr offset, int bitFlags);

	public delegate int SwigDelegateOdDbEntity_125(IntPtr stretchPoints);

	public delegate int SwigDelegateOdDbEntity_126(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbEntity_127(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbEntity_128(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbEntity_129(IntPtr pEnt, int intType, IntPtr points);

	public delegate int SwigDelegateOdDbEntity_130(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbEntity_131(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbEntity_132(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points);

	public delegate void SwigDelegateOdDbEntity_133(bool bDoIt, IntPtr pSubId, bool highlightAll);

	public delegate void SwigDelegateOdDbEntity_134(bool bDoIt, IntPtr pSubId);

	public delegate void SwigDelegateOdDbEntity_135(bool bDoIt);

	public delegate void SwigDelegateOdDbEntity_136();

	public delegate int SwigDelegateOdDbEntity_137();

	public delegate int SwigDelegateOdDbEntity_138(int visibility, bool doSubents);

	public delegate int SwigDelegateOdDbEntity_139(int visibility);

	public delegate int SwigDelegateOdDbEntity_140(IntPtr extents);

	public delegate int SwigDelegateOdDbEntity_141(IntPtr paths);

	public delegate int SwigDelegateOdDbEntity_142(IntPtr paths);

	public delegate int SwigDelegateOdDbEntity_143(IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags);

	public delegate int SwigDelegateOdDbEntity_144(IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags);

	public delegate int SwigDelegateOdDbEntity_145(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths, IntPtr pEntAndInsertStack);

	public delegate int SwigDelegateOdDbEntity_146(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths);

	public delegate int SwigDelegateOdDbEntity_147(IntPtr subPath, IntPtr gsMarkers);

	public delegate IntPtr SwigDelegateOdDbEntity_148(IntPtr path);

	public delegate int SwigDelegateOdDbEntity_149(IntPtr paths, IntPtr xform);

	public delegate int SwigDelegateOdDbEntity_150(IntPtr path, IntPtr clsId);

	public delegate int SwigDelegateOdDbEntity_151(IntPtr path, IntPtr extents);

	public delegate void SwigDelegateOdDbEntity_152(int status, IntPtr subentity);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbEntity_0 swigDelegate0;

	private SwigDelegateOdDbEntity_1 swigDelegate1;

	private SwigDelegateOdDbEntity_2 swigDelegate2;

	private SwigDelegateOdDbEntity_3 swigDelegate3;

	private SwigDelegateOdDbEntity_4 swigDelegate4;

	private SwigDelegateOdDbEntity_5 swigDelegate5;

	private SwigDelegateOdDbEntity_6 swigDelegate6;

	private SwigDelegateOdDbEntity_7 swigDelegate7;

	private SwigDelegateOdDbEntity_8 swigDelegate8;

	private SwigDelegateOdDbEntity_9 swigDelegate9;

	private SwigDelegateOdDbEntity_10 swigDelegate10;

	private SwigDelegateOdDbEntity_11 swigDelegate11;

	private SwigDelegateOdDbEntity_12 swigDelegate12;

	private SwigDelegateOdDbEntity_13 swigDelegate13;

	private SwigDelegateOdDbEntity_14 swigDelegate14;

	private SwigDelegateOdDbEntity_15 swigDelegate15;

	private SwigDelegateOdDbEntity_16 swigDelegate16;

	private SwigDelegateOdDbEntity_17 swigDelegate17;

	private SwigDelegateOdDbEntity_18 swigDelegate18;

	private SwigDelegateOdDbEntity_19 swigDelegate19;

	private SwigDelegateOdDbEntity_20 swigDelegate20;

	private SwigDelegateOdDbEntity_21 swigDelegate21;

	private SwigDelegateOdDbEntity_22 swigDelegate22;

	private SwigDelegateOdDbEntity_23 swigDelegate23;

	private SwigDelegateOdDbEntity_24 swigDelegate24;

	private SwigDelegateOdDbEntity_25 swigDelegate25;

	private SwigDelegateOdDbEntity_26 swigDelegate26;

	private SwigDelegateOdDbEntity_27 swigDelegate27;

	private SwigDelegateOdDbEntity_28 swigDelegate28;

	private SwigDelegateOdDbEntity_29 swigDelegate29;

	private SwigDelegateOdDbEntity_30 swigDelegate30;

	private SwigDelegateOdDbEntity_31 swigDelegate31;

	private SwigDelegateOdDbEntity_32 swigDelegate32;

	private SwigDelegateOdDbEntity_33 swigDelegate33;

	private SwigDelegateOdDbEntity_34 swigDelegate34;

	private SwigDelegateOdDbEntity_35 swigDelegate35;

	private SwigDelegateOdDbEntity_36 swigDelegate36;

	private SwigDelegateOdDbEntity_37 swigDelegate37;

	private SwigDelegateOdDbEntity_38 swigDelegate38;

	private SwigDelegateOdDbEntity_39 swigDelegate39;

	private SwigDelegateOdDbEntity_40 swigDelegate40;

	private SwigDelegateOdDbEntity_41 swigDelegate41;

	private SwigDelegateOdDbEntity_42 swigDelegate42;

	private SwigDelegateOdDbEntity_43 swigDelegate43;

	private SwigDelegateOdDbEntity_44 swigDelegate44;

	private SwigDelegateOdDbEntity_45 swigDelegate45;

	private SwigDelegateOdDbEntity_46 swigDelegate46;

	private SwigDelegateOdDbEntity_47 swigDelegate47;

	private SwigDelegateOdDbEntity_48 swigDelegate48;

	private SwigDelegateOdDbEntity_49 swigDelegate49;

	private SwigDelegateOdDbEntity_50 swigDelegate50;

	private SwigDelegateOdDbEntity_51 swigDelegate51;

	private SwigDelegateOdDbEntity_52 swigDelegate52;

	private SwigDelegateOdDbEntity_53 swigDelegate53;

	private SwigDelegateOdDbEntity_54 swigDelegate54;

	private SwigDelegateOdDbEntity_55 swigDelegate55;

	private SwigDelegateOdDbEntity_56 swigDelegate56;

	private SwigDelegateOdDbEntity_57 swigDelegate57;

	private SwigDelegateOdDbEntity_58 swigDelegate58;

	private SwigDelegateOdDbEntity_59 swigDelegate59;

	private SwigDelegateOdDbEntity_60 swigDelegate60;

	private SwigDelegateOdDbEntity_61 swigDelegate61;

	private SwigDelegateOdDbEntity_62 swigDelegate62;

	private SwigDelegateOdDbEntity_63 swigDelegate63;

	private SwigDelegateOdDbEntity_64 swigDelegate64;

	private SwigDelegateOdDbEntity_65 swigDelegate65;

	private SwigDelegateOdDbEntity_66 swigDelegate66;

	private SwigDelegateOdDbEntity_67 swigDelegate67;

	private SwigDelegateOdDbEntity_68 swigDelegate68;

	private SwigDelegateOdDbEntity_69 swigDelegate69;

	private SwigDelegateOdDbEntity_70 swigDelegate70;

	private SwigDelegateOdDbEntity_71 swigDelegate71;

	private SwigDelegateOdDbEntity_72 swigDelegate72;

	private SwigDelegateOdDbEntity_73 swigDelegate73;

	private SwigDelegateOdDbEntity_74 swigDelegate74;

	private SwigDelegateOdDbEntity_75 swigDelegate75;

	private SwigDelegateOdDbEntity_76 swigDelegate76;

	private SwigDelegateOdDbEntity_77 swigDelegate77;

	private SwigDelegateOdDbEntity_78 swigDelegate78;

	private SwigDelegateOdDbEntity_79 swigDelegate79;

	private SwigDelegateOdDbEntity_80 swigDelegate80;

	private SwigDelegateOdDbEntity_81 swigDelegate81;

	private SwigDelegateOdDbEntity_82 swigDelegate82;

	private SwigDelegateOdDbEntity_83 swigDelegate83;

	private SwigDelegateOdDbEntity_84 swigDelegate84;

	private SwigDelegateOdDbEntity_85 swigDelegate85;

	private SwigDelegateOdDbEntity_86 swigDelegate86;

	private SwigDelegateOdDbEntity_87 swigDelegate87;

	private SwigDelegateOdDbEntity_88 swigDelegate88;

	private SwigDelegateOdDbEntity_89 swigDelegate89;

	private SwigDelegateOdDbEntity_90 swigDelegate90;

	private SwigDelegateOdDbEntity_91 swigDelegate91;

	private SwigDelegateOdDbEntity_92 swigDelegate92;

	private SwigDelegateOdDbEntity_93 swigDelegate93;

	private SwigDelegateOdDbEntity_94 swigDelegate94;

	private SwigDelegateOdDbEntity_95 swigDelegate95;

	private SwigDelegateOdDbEntity_96 swigDelegate96;

	private SwigDelegateOdDbEntity_97 swigDelegate97;

	private SwigDelegateOdDbEntity_98 swigDelegate98;

	private SwigDelegateOdDbEntity_99 swigDelegate99;

	private SwigDelegateOdDbEntity_100 swigDelegate100;

	private SwigDelegateOdDbEntity_101 swigDelegate101;

	private SwigDelegateOdDbEntity_102 swigDelegate102;

	private SwigDelegateOdDbEntity_103 swigDelegate103;

	private SwigDelegateOdDbEntity_104 swigDelegate104;

	private SwigDelegateOdDbEntity_105 swigDelegate105;

	private SwigDelegateOdDbEntity_106 swigDelegate106;

	private SwigDelegateOdDbEntity_107 swigDelegate107;

	private SwigDelegateOdDbEntity_108 swigDelegate108;

	private SwigDelegateOdDbEntity_109 swigDelegate109;

	private SwigDelegateOdDbEntity_110 swigDelegate110;

	private SwigDelegateOdDbEntity_111 swigDelegate111;

	private SwigDelegateOdDbEntity_112 swigDelegate112;

	private SwigDelegateOdDbEntity_113 swigDelegate113;

	private SwigDelegateOdDbEntity_114 swigDelegate114;

	private SwigDelegateOdDbEntity_115 swigDelegate115;

	private SwigDelegateOdDbEntity_116 swigDelegate116;

	private SwigDelegateOdDbEntity_117 swigDelegate117;

	private SwigDelegateOdDbEntity_118 swigDelegate118;

	private SwigDelegateOdDbEntity_119 swigDelegate119;

	private SwigDelegateOdDbEntity_120 swigDelegate120;

	private SwigDelegateOdDbEntity_121 swigDelegate121;

	private SwigDelegateOdDbEntity_122 swigDelegate122;

	private SwigDelegateOdDbEntity_123 swigDelegate123;

	private SwigDelegateOdDbEntity_124 swigDelegate124;

	private SwigDelegateOdDbEntity_125 swigDelegate125;

	private SwigDelegateOdDbEntity_126 swigDelegate126;

	private SwigDelegateOdDbEntity_127 swigDelegate127;

	private SwigDelegateOdDbEntity_128 swigDelegate128;

	private SwigDelegateOdDbEntity_129 swigDelegate129;

	private SwigDelegateOdDbEntity_130 swigDelegate130;

	private SwigDelegateOdDbEntity_131 swigDelegate131;

	private SwigDelegateOdDbEntity_132 swigDelegate132;

	private SwigDelegateOdDbEntity_133 swigDelegate133;

	private SwigDelegateOdDbEntity_134 swigDelegate134;

	private SwigDelegateOdDbEntity_135 swigDelegate135;

	private SwigDelegateOdDbEntity_136 swigDelegate136;

	private SwigDelegateOdDbEntity_137 swigDelegate137;

	private SwigDelegateOdDbEntity_138 swigDelegate138;

	private SwigDelegateOdDbEntity_139 swigDelegate139;

	private SwigDelegateOdDbEntity_140 swigDelegate140;

	private SwigDelegateOdDbEntity_141 swigDelegate141;

	private SwigDelegateOdDbEntity_142 swigDelegate142;

	private SwigDelegateOdDbEntity_143 swigDelegate143;

	private SwigDelegateOdDbEntity_144 swigDelegate144;

	private SwigDelegateOdDbEntity_145 swigDelegate145;

	private SwigDelegateOdDbEntity_146 swigDelegate146;

	private SwigDelegateOdDbEntity_147 swigDelegate147;

	private SwigDelegateOdDbEntity_148 swigDelegate148;

	private SwigDelegateOdDbEntity_149 swigDelegate149;

	private SwigDelegateOdDbEntity_150 swigDelegate150;

	private SwigDelegateOdDbEntity_151 swigDelegate151;

	private SwigDelegateOdDbEntity_152 swigDelegate152;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGsCache) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdDb_OpenMode) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes13 = new Type[3]
	{
		typeof(OdDbObjectId),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbAuditInfo) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes25 = new Type[0];

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(OdResBuf) };

	private static Type[] swigMethodTypes28 = new Type[2]
	{
		typeof(OdDbDwgFiler),
		typeof(OdRxClass)
	};

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[3]
	{
		typeof(OdDbIdPair),
		typeof(OdDbObject),
		typeof(OdDbIdMapping).MakeByRefType()
	};

	private static Type[] swigMethodTypes34 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes35 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes39 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes40 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes45 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes46 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes48 = new Type[2]
	{
		typeof(OdDbFiler),
		typeof(MaintReleaseVer).MakeByRefType()
	};

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(OdDbFiler) };

	private static Type[] swigMethodTypes50 = new Type[3]
	{
		typeof(DwgVersion),
		typeof(OdDbObjectId),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes51 = new Type[4]
	{
		typeof(OdDb_SaveType),
		typeof(DwgVersion),
		typeof(OdDbObjectId),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes52 = new Type[3]
	{
		typeof(OdDb_SaveType),
		typeof(DwgVersion),
		typeof(OdDbAuditInfo)
	};

	private static Type[] swigMethodTypes53 = new Type[0];

	private static Type[] swigMethodTypes54 = new Type[2]
	{
		typeof(string),
		typeof(OdDbField)
	};

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes56 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes58 = new Type[2]
	{
		typeof(OdCmColor),
		typeof(bool)
	};

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(OdCmColor) };

	private static Type[] swigMethodTypes60 = new Type[0];

	private static Type[] swigMethodTypes61 = new Type[2]
	{
		typeof(ushort),
		typeof(bool)
	};

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(ushort) };

	private static Type[] swigMethodTypes63 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes65 = new Type[2]
	{
		typeof(OdCmTransparency),
		typeof(bool)
	};

	private static Type[] swigMethodTypes66 = new Type[1] { typeof(OdCmTransparency) };

	private static Type[] swigMethodTypes67 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes68 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes69 = new Type[3]
	{
		typeof(PlotStyleNameType),
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes70 = new Type[2]
	{
		typeof(PlotStyleNameType),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes71 = new Type[1] { typeof(PlotStyleNameType) };

	private static Type[] swigMethodTypes72 = new Type[3]
	{
		typeof(string),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes73 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes74 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes75 = new Type[3]
	{
		typeof(OdDbObjectId),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes76 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes77 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes78 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes80 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes81 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes82 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes83 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes84 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes85 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes86 = new Type[3]
	{
		typeof(OdDbObjectId),
		typeof(OdDbEntity_VisualStyleType),
		typeof(bool)
	};

	private static Type[] swigMethodTypes87 = new Type[0];

	private static Type[] swigMethodTypes88 = new Type[2]
	{
		typeof(OdGiMapper),
		typeof(bool)
	};

	private static Type[] swigMethodTypes89 = new Type[1] { typeof(OdGiMapper) };

	private static Type[] swigMethodTypes90 = new Type[2]
	{
		typeof(double),
		typeof(bool)
	};

	private static Type[] swigMethodTypes91 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes92 = new Type[2]
	{
		typeof(LineWeight),
		typeof(bool)
	};

	private static Type[] swigMethodTypes93 = new Type[1] { typeof(LineWeight) };

	private static Type[] swigMethodTypes94 = new Type[0];

	private static Type[] swigMethodTypes95 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes96 = new Type[0];

	private static Type[] swigMethodTypes97 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes98 = new Type[0];

	private static Type[] swigMethodTypes99 = new Type[0];

	private static Type[] swigMethodTypes100 = new Type[2]
	{
		typeof(OdGePlane),
		typeof(OdDb_Planarity).MakeByRefType()
	};

	private static Type[] swigMethodTypes101 = new Type[2]
	{
		typeof(OdDbBlockTableRecord),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes102 = new Type[1] { typeof(OdDbBlockTableRecord) };

	private static Type[] swigMethodTypes103 = new Type[1] { typeof(OdRxObjectPtrArray) };

	private static Type[] swigMethodTypes104 = new Type[2]
	{
		typeof(OdDbBlockTableRecord),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes105 = new Type[1] { typeof(OdDbBlockTableRecord) };

	private static Type[] swigMethodTypes106 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(bool)
	};

	private static Type[] swigMethodTypes107 = new Type[0];

	private static Type[] swigMethodTypes108 = new Type[1] { typeof(OdDb_DragStat) };

	private static Type[] swigMethodTypes109 = new Type[2]
	{
		typeof(OdGiWorldDraw),
		typeof(DwgVersion)
	};

	private static Type[] swigMethodTypes110 = new Type[0];

	private static Type[] swigMethodTypes111 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes112 = new Type[2]
	{
		typeof(OdGeMatrix3d),
		typeof(OdDbEntity).MakeByRefType()
	};

	private static Type[] swigMethodTypes113 = new Type[1] { typeof(OdRxObjectPtrArray) };

	private static Type[] swigMethodTypes114 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes115 = new Type[0];

	private static Type[] swigMethodTypes116 = new Type[0];

	private static Type[] swigMethodTypes117 = new Type[1] { typeof(OdDb_GripStat) };

	private static Type[] swigMethodTypes118 = new Type[6]
	{
		typeof(OsnapMode),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes119 = new Type[7]
	{
		typeof(OsnapMode),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3dArray),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes120 = new Type[0];

	private static Type[] swigMethodTypes121 = new Type[1] { typeof(OdGePoint3dArray) };

	private static Type[] swigMethodTypes122 = new Type[2]
	{
		typeof(OdIntArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes123 = new Type[5]
	{
		typeof(OdDbGripDataPtrArray),
		typeof(double),
		typeof(int),
		typeof(OdGeVector3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes124 = new Type[3]
	{
		typeof(OdDbVoidPtrArray),
		typeof(OdGeVector3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes125 = new Type[1] { typeof(OdGePoint3dArray) };

	private static Type[] swigMethodTypes126 = new Type[2]
	{
		typeof(OdIntArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes127 = new Type[5]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes128 = new Type[4]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes129 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes130 = new Type[6]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes131 = new Type[5]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes132 = new Type[4]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes133 = new Type[3]
	{
		typeof(bool),
		typeof(OdDbFullSubentPath),
		typeof(bool)
	};

	private static Type[] swigMethodTypes134 = new Type[2]
	{
		typeof(bool),
		typeof(OdDbFullSubentPath)
	};

	private static Type[] swigMethodTypes135 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes136 = new Type[0];

	private static Type[] swigMethodTypes137 = new Type[0];

	private static Type[] swigMethodTypes138 = new Type[2]
	{
		typeof(OdDb_Visibility),
		typeof(bool)
	};

	private static Type[] swigMethodTypes139 = new Type[1] { typeof(OdDb_Visibility) };

	private static Type[] swigMethodTypes140 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes141 = new Type[1] { typeof(OdDbFullSubentPathArray) };

	private static Type[] swigMethodTypes142 = new Type[1] { typeof(OdDbFullSubentPathArray) };

	private static Type[] swigMethodTypes143 = new Type[4]
	{
		typeof(OdDbFullSubentPathArray),
		typeof(OdDbVoidPtrArray),
		typeof(OdGeVector3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes144 = new Type[6]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdDbGripDataPtrArray),
		typeof(double),
		typeof(int),
		typeof(OdGeVector3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes145 = new Type[6]
	{
		typeof(OdDb_SubentType),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdDbFullSubentPathArray),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes146 = new Type[5]
	{
		typeof(OdDb_SubentType),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdDbFullSubentPathArray)
	};

	private static Type[] swigMethodTypes147 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdGsMarkerArray)
	};

	private static Type[] swigMethodTypes148 = new Type[1] { typeof(OdDbFullSubentPath) };

	private static Type[] swigMethodTypes149 = new Type[2]
	{
		typeof(OdDbFullSubentPathArray),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes150 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes151 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdGeExtents3d)
	};

	private static Type[] swigMethodTypes152 = new Type[2]
	{
		typeof(OdDb_GripStat),
		typeof(OdDbFullSubentPath)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbEntity(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbEntity obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbEntity(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbEntity()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbEntity(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbEntity cast(OdRxObject pObj)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_isASwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_queryXSwigExplicitOdDbEntity(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObjectId blockId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_blockId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmColor color()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_color(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setColor(OdCmColor color, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setColor", swigMethodTypes58) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setColorSwigExplicitOdDbEntity__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setColor__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setColor(OdCmColor color)
	{
		int result = (SwigDerivedClassHasMethod("setColor", swigMethodTypes59) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setColorSwigExplicitOdDbEntity__SWIG_1(swigCPtr, OdCmColor.getCPtr(color)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setColor__SWIG_1(swigCPtr, OdCmColor.getCPtr(color)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public ushort colorIndex()
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_colorIndex(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor entityColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("entityColor", swigMethodTypes60) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_entityColorSwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_entityColor(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setColorIndex(ushort colorIndex, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setColorIndex", swigMethodTypes61) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setColorIndexSwigExplicitOdDbEntity__SWIG_0(swigCPtr, colorIndex, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setColorIndex__SWIG_0(swigCPtr, colorIndex, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setColorIndex(ushort colorIndex)
	{
		int result = (SwigDerivedClassHasMethod("setColorIndex", swigMethodTypes62) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setColorIndexSwigExplicitOdDbEntity__SWIG_1(swigCPtr, colorIndex) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setColorIndex__SWIG_1(swigCPtr, colorIndex));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDbObjectId colorId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_colorId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setColorId(OdDbObjectId colorId, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setColorId", swigMethodTypes63) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setColorIdSwigExplicitOdDbEntity__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(colorId), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setColorId__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(colorId), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setColorId(OdDbObjectId colorId)
	{
		int result = (SwigDerivedClassHasMethod("setColorId", swigMethodTypes64) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setColorIdSwigExplicitOdDbEntity__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(colorId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setColorId__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(colorId)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdCmTransparency transparency()
	{
		OdCmTransparency result = new OdCmTransparency(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_transparency(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setTransparency(OdCmTransparency transparency, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setTransparency", swigMethodTypes65) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setTransparencySwigExplicitOdDbEntity__SWIG_0(swigCPtr, OdCmTransparency.getCPtr(transparency), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setTransparency__SWIG_0(swigCPtr, OdCmTransparency.getCPtr(transparency), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setTransparency(OdCmTransparency transparency)
	{
		int result = (SwigDerivedClassHasMethod("setTransparency", swigMethodTypes66) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setTransparencySwigExplicitOdDbEntity__SWIG_1(swigCPtr, OdCmTransparency.getCPtr(transparency)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setTransparency__SWIG_1(swigCPtr, OdCmTransparency.getCPtr(transparency)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public string plotStyleName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_plotStyleName(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public PlotStyleNameType getPlotStyleNameId(OdDbObjectId plotStyleNameId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getPlotStyleNameId(swigCPtr, OdDbObjectId.getCPtr(plotStyleNameId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PlotStyleNameType)result;
	}

	public virtual OdResult setPlotStyleName(string plotStyleName, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes67) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setPlotStyleNameSwigExplicitOdDbEntity__SWIG_0(swigCPtr, plotStyleName, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setPlotStyleName__SWIG_0(swigCPtr, plotStyleName, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotStyleName(string plotStyleName)
	{
		int result = (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes68) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setPlotStyleNameSwigExplicitOdDbEntity__SWIG_1(swigCPtr, plotStyleName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setPlotStyleName__SWIG_1(swigCPtr, plotStyleName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotStyleName(PlotStyleNameType plotStyleNameType, OdDbObjectId plotStyleNameId, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes69) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setPlotStyleNameSwigExplicitOdDbEntity__SWIG_2(swigCPtr, (int)plotStyleNameType, OdDbObjectId.getCPtr(plotStyleNameId), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setPlotStyleName__SWIG_2(swigCPtr, (int)plotStyleNameType, OdDbObjectId.getCPtr(plotStyleNameId), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotStyleName(PlotStyleNameType plotStyleNameType, OdDbObjectId plotStyleNameId)
	{
		int result = (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes70) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setPlotStyleNameSwigExplicitOdDbEntity__SWIG_3(swigCPtr, (int)plotStyleNameType, OdDbObjectId.getCPtr(plotStyleNameId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setPlotStyleName__SWIG_3(swigCPtr, (int)plotStyleNameType, OdDbObjectId.getCPtr(plotStyleNameId)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotStyleName(PlotStyleNameType plotStyleNameType)
	{
		int result = (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes71) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setPlotStyleNameSwigExplicitOdDbEntity__SWIG_4(swigCPtr, (int)plotStyleNameType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setPlotStyleName__SWIG_4(swigCPtr, (int)plotStyleNameType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public string layer()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_layer(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId layerId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_layerId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setLayer(string layerName, bool doSubents, bool allowHiddenLayer)
	{
		int result = (SwigDerivedClassHasMethod("setLayer", swigMethodTypes72) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLayerSwigExplicitOdDbEntity__SWIG_0(swigCPtr, layerName, doSubents, allowHiddenLayer) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLayer__SWIG_0(swigCPtr, layerName, doSubents, allowHiddenLayer));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setLayer(string layerName, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setLayer", swigMethodTypes73) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLayerSwigExplicitOdDbEntity__SWIG_1(swigCPtr, layerName, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLayer__SWIG_1(swigCPtr, layerName, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setLayer(string layerName)
	{
		int result = (SwigDerivedClassHasMethod("setLayer", swigMethodTypes74) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLayerSwigExplicitOdDbEntity__SWIG_2(swigCPtr, layerName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLayer__SWIG_2(swigCPtr, layerName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setLayer(OdDbObjectId layerId, bool doSubents, bool allowHiddenLayer)
	{
		int result = (SwigDerivedClassHasMethod("setLayer", swigMethodTypes75) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLayerSwigExplicitOdDbEntity__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(layerId), doSubents, allowHiddenLayer) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLayer__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(layerId), doSubents, allowHiddenLayer));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setLayer(OdDbObjectId layerId, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setLayer", swigMethodTypes76) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLayerSwigExplicitOdDbEntity__SWIG_4(swigCPtr, OdDbObjectId.getCPtr(layerId), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLayer__SWIG_4(swigCPtr, OdDbObjectId.getCPtr(layerId), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setLayer(OdDbObjectId layerId)
	{
		int result = (SwigDerivedClassHasMethod("setLayer", swigMethodTypes77) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLayerSwigExplicitOdDbEntity__SWIG_5(swigCPtr, OdDbObjectId.getCPtr(layerId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLayer__SWIG_5(swigCPtr, OdDbObjectId.getCPtr(layerId)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public string linetype()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_linetype(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId linetypeId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_linetypeId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setLinetype(string linetypeName, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes78) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLinetypeSwigExplicitOdDbEntity__SWIG_0(swigCPtr, linetypeName, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLinetype__SWIG_0(swigCPtr, linetypeName, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setLinetype(string linetypeName)
	{
		int result = (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes79) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLinetypeSwigExplicitOdDbEntity__SWIG_1(swigCPtr, linetypeName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLinetype__SWIG_1(swigCPtr, linetypeName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setLinetype(OdDbObjectId linetypeID, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes80) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLinetypeSwigExplicitOdDbEntity__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(linetypeID), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLinetype__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(linetypeID), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setLinetype(OdDbObjectId linetypeID)
	{
		int result = (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes81) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLinetypeSwigExplicitOdDbEntity__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(linetypeID)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLinetype__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(linetypeID)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public string material()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_material(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId materialId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_materialId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setMaterial(string materialName, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes82) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setMaterialSwigExplicitOdDbEntity__SWIG_0(swigCPtr, materialName, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setMaterial__SWIG_0(swigCPtr, materialName, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setMaterial(string materialName)
	{
		int result = (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes83) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setMaterialSwigExplicitOdDbEntity__SWIG_1(swigCPtr, materialName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setMaterial__SWIG_1(swigCPtr, materialName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setMaterial(OdDbObjectId materialID, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes84) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setMaterialSwigExplicitOdDbEntity__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(materialID), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setMaterial__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(materialID), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setMaterial(OdDbObjectId materialID)
	{
		int result = (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes85) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setMaterialSwigExplicitOdDbEntity__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(materialID)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setMaterial__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(materialID)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDbObjectId visualStyleId(OdDbEntity_VisualStyleType vstype)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_visualStyleId__SWIG_0(swigCPtr, (int)vstype), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId visualStyleId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_visualStyleId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setVisualStyle(OdDbObjectId visualStyleId, OdDbEntity_VisualStyleType vstype, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes86) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setVisualStyleSwigExplicitOdDbEntity(swigCPtr, OdDbObjectId.getCPtr(visualStyleId), (int)vstype, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setVisualStyle(swigCPtr, OdDbObjectId.getCPtr(visualStyleId), (int)vstype, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdGiMapper materialMapper()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("materialMapper", swigMethodTypes87) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_materialMapperSwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_materialMapper(swigCPtr));
		OdGiMapper result = ((intPtr == IntPtr.Zero) ? null : new OdGiMapper(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMaterialMapper(OdGiMapper mapper, bool doSubents)
	{
		if (SwigDerivedClassHasMethod("setMaterialMapper", swigMethodTypes88))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setMaterialMapperSwigExplicitOdDbEntity__SWIG_0(swigCPtr, OdGiMapper.getCPtr(mapper), doSubents);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setMaterialMapper__SWIG_0(swigCPtr, OdGiMapper.getCPtr(mapper), doSubents);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMaterialMapper(OdGiMapper mapper)
	{
		if (SwigDerivedClassHasMethod("setMaterialMapper", swigMethodTypes89))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setMaterialMapperSwigExplicitOdDbEntity__SWIG_1(swigCPtr, OdGiMapper.getCPtr(mapper));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setMaterialMapper__SWIG_1(swigCPtr, OdGiMapper.getCPtr(mapper));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double linetypeScale()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_linetypeScale(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setLinetypeScale(double linetypeScale, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setLinetypeScale", swigMethodTypes90) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLinetypeScaleSwigExplicitOdDbEntity__SWIG_0(swigCPtr, linetypeScale, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLinetypeScale__SWIG_0(swigCPtr, linetypeScale, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setLinetypeScale(double linetypeScale)
	{
		int result = (SwigDerivedClassHasMethod("setLinetypeScale", swigMethodTypes91) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLinetypeScaleSwigExplicitOdDbEntity__SWIG_1(swigCPtr, linetypeScale) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLinetypeScale__SWIG_1(swigCPtr, linetypeScale));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDb_Visibility visibility()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_visibility(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	public virtual OdResult setVisibility(OdDb_Visibility visibility, bool doSubents)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setVisibility__SWIG_0(swigCPtr, (int)visibility, doSubents);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setVisibility(OdDb_Visibility visibility)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setVisibility__SWIG_1(swigCPtr, (int)visibility);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDb_Visibility tempVisibility()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_tempVisibility(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	public void setTempVisibility(OdDb_Visibility visibility)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setTempVisibility(swigCPtr, (int)visibility);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public LineWeight lineWeight()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_lineWeight(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual OdResult setLineWeight(LineWeight lineWeight, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setLineWeight", swigMethodTypes92) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLineWeightSwigExplicitOdDbEntity__SWIG_0(swigCPtr, (int)lineWeight, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLineWeight__SWIG_0(swigCPtr, (int)lineWeight, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setLineWeight(LineWeight lineWeight)
	{
		int result = (SwigDerivedClassHasMethod("setLineWeight", swigMethodTypes93) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLineWeightSwigExplicitOdDbEntity__SWIG_1(swigCPtr, (int)lineWeight) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setLineWeight__SWIG_1(swigCPtr, (int)lineWeight));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool castShadows()
	{
		bool result = (SwigDerivedClassHasMethod("castShadows", swigMethodTypes94) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_castShadowsSwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_castShadows(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setCastShadows(bool castShadows)
	{
		if (SwigDerivedClassHasMethod("setCastShadows", swigMethodTypes95))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setCastShadowsSwigExplicitOdDbEntity(swigCPtr, castShadows);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setCastShadows(swigCPtr, castShadows);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool receiveShadows()
	{
		bool result = (SwigDerivedClassHasMethod("receiveShadows", swigMethodTypes96) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_receiveShadowsSwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_receiveShadows(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setReceiveShadows(bool receiveShadows)
	{
		if (SwigDerivedClassHasMethod("setReceiveShadows", swigMethodTypes97))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setReceiveShadowsSwigExplicitOdDbEntity(swigCPtr, receiveShadows);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setReceiveShadows(swigCPtr, receiveShadows);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_CollisionType collisionType()
	{
		int result = (SwigDerivedClassHasMethod("collisionType", swigMethodTypes98) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_collisionTypeSwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_collisionType(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CollisionType)result;
	}

	public void setPropertiesFrom(OdDbEntity pSource, bool doSubents)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setPropertiesFrom__SWIG_0(swigCPtr, getCPtr(pSource), doSubents);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPropertiesFrom(OdDbEntity pSource)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setPropertiesFrom__SWIG_1(swigCPtr, getCPtr(pSource));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isPlanar()
	{
		bool result = (SwigDerivedClassHasMethod("isPlanar", swigMethodTypes99) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_isPlanarSwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_isPlanar(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getPlane(OdGePlane plane, out OdDb_Planarity planarity)
	{
		int result = (SwigDerivedClassHasMethod("getPlane", swigMethodTypes100) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getPlaneSwigExplicitOdDbEntity(swigCPtr, OdGePlane.getCPtr(plane), out planarity) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getPlane(swigCPtr, OdGePlane.getCPtr(plane), out planarity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void subHandOverTo(OdDbObject pNewObject)
	{
		if (SwigDerivedClassHasMethod("subHandOverTo", swigMethodTypes12))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subHandOverToSwigExplicitOdDbEntity(swigCPtr, OdDbObject.getCPtr(pNewObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subHandOverTo(swigCPtr, OdDbObject.getCPtr(pNewObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult transformBy(OdGeMatrix3d xfm)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getTransformedCopy(OdGeMatrix3d xfm, ref OdDbEntity pCopy)
	{
		IntPtr jarg = ((pCopy == null) ? IntPtr.Zero : getCPtr(pCopy).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getTransformedCopy(swigCPtr, OdGeMatrix3d.getCPtr(xfm), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pCopy = null;
			}
			else if (jarg != intPtr)
			{
				pCopy = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult explode(OdRxObjectPtrArray entitySet)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_explode(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult explodeToBlock(OdDbBlockTableRecord pBlockRecord, OdDbObjectIdArray ids)
	{
		int result = (SwigDerivedClassHasMethod("explodeToBlock", swigMethodTypes101) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_explodeToBlockSwigExplicitOdDbEntity__SWIG_0(swigCPtr, OdDbBlockTableRecord.getCPtr(pBlockRecord), OdDbObjectIdArray.getCPtr(ids)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_explodeToBlock__SWIG_0(swigCPtr, OdDbBlockTableRecord.getCPtr(pBlockRecord), OdDbObjectIdArray.getCPtr(ids)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult explodeToBlock(OdDbBlockTableRecord pBlockRecord)
	{
		int result = (SwigDerivedClassHasMethod("explodeToBlock", swigMethodTypes102) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_explodeToBlockSwigExplicitOdDbEntity__SWIG_1(swigCPtr, OdDbBlockTableRecord.getCPtr(pBlockRecord)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_explodeToBlock__SWIG_1(swigCPtr, OdDbBlockTableRecord.getCPtr(pBlockRecord)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult explodeGeometry(OdRxObjectPtrArray entitySet)
	{
		int result = (SwigDerivedClassHasMethod("explodeGeometry", swigMethodTypes103) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_explodeGeometrySwigExplicitOdDbEntity(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_explodeGeometry(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult explodeGeometryToBlock(OdDbBlockTableRecord pBlockRecord, OdDbObjectIdArray ids)
	{
		int result = (SwigDerivedClassHasMethod("explodeGeometryToBlock", swigMethodTypes104) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_explodeGeometryToBlockSwigExplicitOdDbEntity__SWIG_0(swigCPtr, OdDbBlockTableRecord.getCPtr(pBlockRecord), OdDbObjectIdArray.getCPtr(ids)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_explodeGeometryToBlock__SWIG_0(swigCPtr, OdDbBlockTableRecord.getCPtr(pBlockRecord), OdDbObjectIdArray.getCPtr(ids)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult explodeGeometryToBlock(OdDbBlockTableRecord pBlockRecord)
	{
		int result = (SwigDerivedClassHasMethod("explodeGeometryToBlock", swigMethodTypes105) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_explodeGeometryToBlockSwigExplicitOdDbEntity__SWIG_1(swigCPtr, OdDbBlockTableRecord.getCPtr(pBlockRecord)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_explodeGeometryToBlock__SWIG_1(swigCPtr, OdDbBlockTableRecord.getCPtr(pBlockRecord)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void setDatabaseDefaults(OdDbDatabase pDb, bool doSubents)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setDatabaseDefaults__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pDb), doSubents);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDatabaseDefaults(OdDbDatabase pDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setDatabaseDefaults__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDatabaseDefaults()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_setDatabaseDefaults__SWIG_2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void subSetDatabaseDefaults(OdDbDatabase pDb, bool doSubents)
	{
		if (SwigDerivedClassHasMethod("subSetDatabaseDefaults", swigMethodTypes106))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSetDatabaseDefaultsSwigExplicitOdDbEntity(swigCPtr, OdDbDatabase.getCPtr(pDb), doSubents);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSetDatabaseDefaults(swigCPtr, OdDbDatabase.getCPtr(pDb), doSubents);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void applyPartialUndo(OdDbDwgFiler pUndoFiler, OdRxClass pClassObj)
	{
		if (SwigDerivedClassHasMethod("applyPartialUndo", swigMethodTypes28))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_applyPartialUndoSwigExplicitOdDbEntity(swigCPtr, OdDbDwgFiler.getCPtr(pUndoFiler), OdRxClass.getCPtr(pClassObj));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_applyPartialUndo(swigCPtr, OdDbDwgFiler.getCPtr(pUndoFiler), OdRxClass.getCPtr(pClassObj));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dwgInFieldsSwigExplicitOdDbEntity(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dwgOutFields(OdDbDwgFiler pFiler)
	{
		if (SwigDerivedClassHasMethod("dwgOutFields", swigMethodTypes20))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dwgOutFieldsSwigExplicitOdDbEntity(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void appendToOwner(OdDbIdPair idPair, OdDbObject pOwnerObject, ref OdDbIdMapping ownerIdMap)
	{
		IntPtr jarg = ((ownerIdMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(ownerIdMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("appendToOwner", swigMethodTypes33))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_appendToOwnerSwigExplicitOdDbEntity(swigCPtr, OdDbIdPair.getCPtr(idPair), OdDbObject.getCPtr(pOwnerObject), ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_appendToOwner(swigCPtr, OdDbIdPair.getCPtr(idPair), OdDbObject.getCPtr(pOwnerObject), ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				ownerIdMap = null;
			}
			if (jarg != intPtr)
			{
				ownerIdMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override OdResult dxfIn(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfIn", swigMethodTypes17) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dxfInSwigExplicitOdDbEntity(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dxfIn(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dxfOut(OdDbDxfFiler pFiler)
	{
		if (SwigDerivedClassHasMethod("dxfOut", swigMethodTypes18))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dxfOutSwigExplicitOdDbEntity(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dxfOut(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dxfInFieldsSwigExplicitOdDbEntity(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dxfOutFields(OdDbDxfFiler pFiler)
	{
		if (SwigDerivedClassHasMethod("dxfOutFields", swigMethodTypes22))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dxfOutFieldsSwigExplicitOdDbEntity(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields_R12(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields_R12", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dxfInFields_R12SwigExplicitOdDbEntity(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dxfInFields_R12(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dxfOutFields_R12(OdDbDxfFiler pFiler)
	{
		if (SwigDerivedClassHasMethod("dxfOutFields_R12", swigMethodTypes24))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dxfOutFields_R12SwigExplicitOdDbEntity(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dxfOutFields_R12(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGiDrawable drawable()
	{
		OdGiDrawable rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiDrawable>(SwigDerivedClassHasMethod("drawable", swigMethodTypes53) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_drawableSwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_drawable(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void subList()
	{
		if (SwigDerivedClassHasMethod("subList", swigMethodTypes107))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subListSwigExplicitOdDbEntity(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subList(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void subSwapIdWith(OdDbObjectId otherId, bool swapXdata, bool swapExtDict)
	{
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes13))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSwapIdWithSwigExplicitOdDbEntity__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(otherId), swapXdata, swapExtDict);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSwapIdWith__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(otherId), swapXdata, swapExtDict);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void subSwapIdWith(OdDbObjectId otherId, bool swapXdata)
	{
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes14))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSwapIdWithSwigExplicitOdDbEntity__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(otherId), swapXdata);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSwapIdWith__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(otherId), swapXdata);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void subSwapIdWith(OdDbObjectId otherId)
	{
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes15))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSwapIdWithSwigExplicitOdDbEntity__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(otherId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSwapIdWith__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(otherId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult subErase(bool erasing)
	{
		int result = (SwigDerivedClassHasMethod("subErase", swigMethodTypes11) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subEraseSwigExplicitOdDbEntity(swigCPtr, erasing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subErase(swigCPtr, erasing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult subOpen(OdDb_OpenMode mode)
	{
		int result = (SwigDerivedClassHasMethod("subOpen", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subOpenSwigExplicitOdDbEntity(swigCPtr, (int)mode) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subOpen(swigCPtr, (int)mode));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void recordGraphicsModified(bool graphicsModified)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_recordGraphicsModified__SWIG_0(swigCPtr, graphicsModified);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void recordGraphicsModified()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_recordGraphicsModified__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void copyFrom(OdRxObject pSource)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_copyFromSwigExplicitOdDbEntity(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void list()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_list(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult getGeomExtents(OdGeExtents3d extents)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getGeomExtents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void highlight(bool bDoIt, OdDbFullSubentPath pSubId, bool highlightAll)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_highlight__SWIG_0(swigCPtr, bDoIt, OdDbFullSubentPath.getCPtr(pSubId), highlightAll);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(bool bDoIt, OdDbFullSubentPath pSubId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_highlight__SWIG_1(swigCPtr, bDoIt, OdDbFullSubentPath.getCPtr(pSubId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(bool bDoIt)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_highlight__SWIG_2(swigCPtr, bDoIt);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_highlight__SWIG_3(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult getOsnapPoints(OsnapMode osnapMode, IntPtr gsSelectionMark, OdGePoint3d pickPoint, OdGePoint3d lastPoint, OdGeMatrix3d xWorldToEye, OdGePoint3dArray snapPoints)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getOsnapPoints__SWIG_0(swigCPtr, (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getOsnapPoints(OsnapMode osnapMode, IntPtr gsSelectionMark, OdGePoint3d pickPoint, OdGePoint3d lastPoint, OdGeMatrix3d xWorldToEye, OdGePoint3dArray snapPoints, OdGeMatrix3d insertionMat)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getOsnapPoints__SWIG_1(swigCPtr, (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle, OdGeMatrix3d.getCPtr(insertionMat));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool isContentSnappable()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_isContentSnappable(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getGripPoints(OdGePoint3dArray gripPoints)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getGripPoints__SWIG_0(swigCPtr, OdGePoint3dArray.getCPtr(gripPoints).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult moveGripPointsAt(OdIntArray indices, OdGeVector3d offset)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_moveGripPointsAt__SWIG_0(swigCPtr, OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getGripPoints(OdDbGripDataPtrArray grips, double curViewUnitSize, int gripSize, OdGeVector3d curViewDir, int bitFlags)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getGripPoints__SWIG_1(swigCPtr, OdDbGripDataPtrArray.getCPtr(grips).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitFlags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult moveGripPointsAt(OdDbVoidPtrArray grips, OdGeVector3d offset, int bitFlags)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_moveGripPointsAt__SWIG_1(swigCPtr, OdDbVoidPtrArray.getCPtr(grips), OdGeVector3d.getCPtr(offset), bitFlags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getStretchPoints(OdGePoint3dArray stretchPoints)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getStretchPoints(swigCPtr, OdGePoint3dArray.getCPtr(stretchPoints).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult moveStretchPointsAt(OdIntArray indices, OdGeVector3d offset)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_moveStretchPointsAt(swigCPtr, OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void dragStatus(OdDb_DragStat status)
	{
		if (SwigDerivedClassHasMethod("dragStatus", swigMethodTypes108))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dragStatusSwigExplicitOdDbEntity(swigCPtr, (int)status);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_dragStatus(swigCPtr, (int)status);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void gripStatus(OdDb_GripStat status)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_gripStatus(swigCPtr, (int)status);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool cloneMeForDragging()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_cloneMeForDragging(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hideMeForDragging()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_hideMeForDragging(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void saveAs(OdGiWorldDraw pWd, DwgVersion ver)
	{
		if (SwigDerivedClassHasMethod("saveAs", swigMethodTypes109))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_saveAsSwigExplicitOdDbEntity(swigCPtr, OdGiWorldDraw.getCPtr(pWd), (int)ver);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_saveAs(swigCPtr, OdGiWorldDraw.getCPtr(pWd), (int)ver);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult getCompoundObjectTransform(OdGeMatrix3d xM)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getCompoundObjectTransform(swigCPtr, OdGeMatrix3d.getCPtr(xM));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_intersectWith__SWIG_0(swigCPtr, getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points, IntPtr thisGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_intersectWith__SWIG_1(swigCPtr, getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_intersectWith__SWIG_2(swigCPtr, getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_intersectWith__SWIG_3(swigCPtr, getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points, IntPtr thisGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_intersectWith__SWIG_4(swigCPtr, getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_intersectWith__SWIG_5(swigCPtr, getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult boundingBoxIntersectWith(OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_boundingBoxIntersectWith__SWIG_0(swigCPtr, getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult boundingBoxIntersectWith(OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_boundingBoxIntersectWith__SWIG_1(swigCPtr, getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d xfm, OdDbFullSubentPathArray subentPaths, OdDbObjectIdArray pEntAndInsertStack)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getSubentPathsAtGsMarker__SWIG_0(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(xfm), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(pEntAndInsertStack));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d xfm, OdDbFullSubentPathArray subentPaths)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getSubentPathsAtGsMarker__SWIG_1(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(xfm), OdDbFullSubentPathArray.getCPtr(subentPaths));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getGsMarkersAtSubentPath(OdDbFullSubentPath subPath, OdGsMarkerArray gsMarkers)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getGsMarkersAtSubentPath(swigCPtr, OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getGripPointsAtSubentPath(OdDbFullSubentPath path, OdDbGripDataPtrArray grips, double curViewUnitSize, int gripSize, OdGeVector3d curViewDir, uint bitflags)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getGripPointsAtSubentPath(swigCPtr, OdDbFullSubentPath.getCPtr(path), OdDbGripDataPtrArray.getCPtr(grips).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitflags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult moveGripPointsAtSubentPaths(OdDbFullSubentPathArray paths, OdDbVoidPtrArray gripAppData, OdGeVector3d offset, uint bitflags)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_moveGripPointsAtSubentPaths(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths), OdDbVoidPtrArray.getCPtr(gripAppData), OdGeVector3d.getCPtr(offset), bitflags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult deleteSubentPaths(OdDbFullSubentPathArray paths)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_deleteSubentPaths(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult addSubentPaths(OdDbFullSubentPathArray paths)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_addSubentPaths(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbEntity subentPtr(OdDbFullSubentPath path)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subentPtr(swigCPtr, OdDbFullSubentPath.getCPtr(path)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult transformSubentPathsBy(OdDbFullSubentPathArray paths, OdGeMatrix3d xform)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_transformSubentPathsBy(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths), OdGeMatrix3d.getCPtr(xform));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentClassId(OdDbFullSubentPath path, IntPtr clsId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getSubentClassId(swigCPtr, OdDbFullSubentPath.getCPtr(path), clsId);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentPathGeomExtents(OdDbFullSubentPath path, OdGeExtents3d extents)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getSubentPathGeomExtents(swigCPtr, OdDbFullSubentPath.getCPtr(path), OdGeExtents3d.getCPtr(extents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void subentGripStatus(OdDb_GripStat status, OdDbFullSubentPath subentity)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subentGripStatus(swigCPtr, (int)status, OdDbFullSubentPath.getCPtr(subentity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d getEcs()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("getEcs", swigMethodTypes110) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getEcsSwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getEcs(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual OdResult subTransformBy(OdGeMatrix3d xfm)
	{
		int result = (SwigDerivedClassHasMethod("subTransformBy", swigMethodTypes111) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subTransformBySwigExplicitOdDbEntity(swigCPtr, OdGeMatrix3d.getCPtr(xfm)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subTransformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetTransformedCopy(OdGeMatrix3d xfm, ref OdDbEntity pCopy)
	{
		IntPtr jarg = ((pCopy == null) ? IntPtr.Zero : getCPtr(pCopy).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = (SwigDerivedClassHasMethod("subGetTransformedCopy", swigMethodTypes112) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetTransformedCopySwigExplicitOdDbEntity(swigCPtr, OdGeMatrix3d.getCPtr(xfm), ref jarg) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetTransformedCopy(swigCPtr, OdGeMatrix3d.getCPtr(xfm), ref jarg));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pCopy = null;
			}
			else if (jarg != intPtr)
			{
				pCopy = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected virtual OdResult subExplode(OdRxObjectPtrArray entitySet)
	{
		int result = (SwigDerivedClassHasMethod("subExplode", swigMethodTypes113) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subExplodeSwigExplicitOdDbEntity(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subExplode(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetCompoundObjectTransform(OdGeMatrix3d xM)
	{
		int result = (SwigDerivedClassHasMethod("subGetCompoundObjectTransform", swigMethodTypes114) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetCompoundObjectTransformSwigExplicitOdDbEntity(swigCPtr, OdGeMatrix3d.getCPtr(xM)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetCompoundObjectTransform(swigCPtr, OdGeMatrix3d.getCPtr(xM)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual bool subCloneMeForDragging()
	{
		bool result = (SwigDerivedClassHasMethod("subCloneMeForDragging", swigMethodTypes115) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subCloneMeForDraggingSwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subCloneMeForDragging(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual bool subHideMeForDragging()
	{
		bool result = (SwigDerivedClassHasMethod("subHideMeForDragging", swigMethodTypes116) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subHideMeForDraggingSwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subHideMeForDragging(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual void subGripStatus(OdDb_GripStat status)
	{
		if (SwigDerivedClassHasMethod("subGripStatus", swigMethodTypes117))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGripStatusSwigExplicitOdDbEntity(swigCPtr, (int)status);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGripStatus(swigCPtr, (int)status);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual OdResult subGetOsnapPoints(OsnapMode osnapMode, IntPtr gsSelectionMark, OdGePoint3d pickPoint, OdGePoint3d lastPoint, OdGeMatrix3d xWorldToEye, OdGePoint3dArray snapPoints)
	{
		int result = (SwigDerivedClassHasMethod("subGetOsnapPoints", swigMethodTypes118) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetOsnapPointsSwigExplicitOdDbEntity__SWIG_0(swigCPtr, (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetOsnapPoints__SWIG_0(swigCPtr, (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetOsnapPoints(OsnapMode osnapMode, IntPtr gsSelectionMark, OdGePoint3d pickPoint, OdGePoint3d lastPoint, OdGeMatrix3d xWorldToEye, OdGePoint3dArray snapPoints, OdGeMatrix3d insertionMat)
	{
		int result = (SwigDerivedClassHasMethod("subGetOsnapPoints", swigMethodTypes119) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetOsnapPointsSwigExplicitOdDbEntity__SWIG_1(swigCPtr, (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle, OdGeMatrix3d.getCPtr(insertionMat)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetOsnapPoints__SWIG_1(swigCPtr, (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle, OdGeMatrix3d.getCPtr(insertionMat)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual bool subIsContentSnappable()
	{
		bool result = (SwigDerivedClassHasMethod("subIsContentSnappable", swigMethodTypes120) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIsContentSnappableSwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIsContentSnappable(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual OdResult subGetGripPoints(OdGePoint3dArray gripPoints)
	{
		int result = (SwigDerivedClassHasMethod("subGetGripPoints", swigMethodTypes121) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetGripPointsSwigExplicitOdDbEntity__SWIG_0(swigCPtr, OdGePoint3dArray.getCPtr(gripPoints).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetGripPoints__SWIG_0(swigCPtr, OdGePoint3dArray.getCPtr(gripPoints).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subMoveGripPointsAt(OdIntArray indices, OdGeVector3d offset)
	{
		int result = (SwigDerivedClassHasMethod("subMoveGripPointsAt", swigMethodTypes122) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subMoveGripPointsAtSwigExplicitOdDbEntity__SWIG_0(swigCPtr, OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subMoveGripPointsAt__SWIG_0(swigCPtr, OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetGripPoints(OdDbGripDataPtrArray grips, double curViewUnitSize, int gripSize, OdGeVector3d curViewDir, int bitFlags)
	{
		int result = (SwigDerivedClassHasMethod("subGetGripPoints", swigMethodTypes123) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetGripPointsSwigExplicitOdDbEntity__SWIG_1(swigCPtr, OdDbGripDataPtrArray.getCPtr(grips).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitFlags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetGripPoints__SWIG_1(swigCPtr, OdDbGripDataPtrArray.getCPtr(grips).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitFlags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subMoveGripPointsAt(OdDbVoidPtrArray grips, OdGeVector3d offset, int bitFlags)
	{
		int result = (SwigDerivedClassHasMethod("subMoveGripPointsAt", swigMethodTypes124) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subMoveGripPointsAtSwigExplicitOdDbEntity__SWIG_1(swigCPtr, OdDbVoidPtrArray.getCPtr(grips), OdGeVector3d.getCPtr(offset), bitFlags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subMoveGripPointsAt__SWIG_1(swigCPtr, OdDbVoidPtrArray.getCPtr(grips), OdGeVector3d.getCPtr(offset), bitFlags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetStretchPoints(OdGePoint3dArray stretchPoints)
	{
		int result = (SwigDerivedClassHasMethod("subGetStretchPoints", swigMethodTypes125) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetStretchPointsSwigExplicitOdDbEntity(swigCPtr, OdGePoint3dArray.getCPtr(stretchPoints).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetStretchPoints(swigCPtr, OdGePoint3dArray.getCPtr(stretchPoints).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subMoveStretchPointsAt(OdIntArray indices, OdGeVector3d offset)
	{
		int result = (SwigDerivedClassHasMethod("subMoveStretchPointsAt", swigMethodTypes126) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subMoveStretchPointsAtSwigExplicitOdDbEntity(swigCPtr, OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subMoveStretchPointsAt(swigCPtr, OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subIntersectWith(OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes127) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIntersectWithSwigExplicitOdDbEntity__SWIG_0(swigCPtr, getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIntersectWith__SWIG_0(swigCPtr, getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subIntersectWith(OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points, IntPtr thisGsMarker)
	{
		int result = (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes128) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIntersectWithSwigExplicitOdDbEntity__SWIG_1(swigCPtr, getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIntersectWith__SWIG_1(swigCPtr, getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subIntersectWith(OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points)
	{
		int result = (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes129) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIntersectWithSwigExplicitOdDbEntity__SWIG_2(swigCPtr, getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIntersectWith__SWIG_2(swigCPtr, getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subIntersectWith(OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes130) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIntersectWithSwigExplicitOdDbEntity__SWIG_3(swigCPtr, getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIntersectWith__SWIG_3(swigCPtr, getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subIntersectWith(OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points, IntPtr thisGsMarker)
	{
		int result = (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes131) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIntersectWithSwigExplicitOdDbEntity__SWIG_4(swigCPtr, getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIntersectWith__SWIG_4(swigCPtr, getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subIntersectWith(OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points)
	{
		int result = (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes132) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIntersectWithSwigExplicitOdDbEntity__SWIG_5(swigCPtr, getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subIntersectWith__SWIG_5(swigCPtr, getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual void subHighlight(bool bDoIt, OdDbFullSubentPath pSubId, bool highlightAll)
	{
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes133))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subHighlightSwigExplicitOdDbEntity__SWIG_0(swigCPtr, bDoIt, OdDbFullSubentPath.getCPtr(pSubId), highlightAll);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subHighlight__SWIG_0(swigCPtr, bDoIt, OdDbFullSubentPath.getCPtr(pSubId), highlightAll);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void subHighlight(bool bDoIt, OdDbFullSubentPath pSubId)
	{
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes134))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subHighlightSwigExplicitOdDbEntity__SWIG_1(swigCPtr, bDoIt, OdDbFullSubentPath.getCPtr(pSubId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subHighlight__SWIG_1(swigCPtr, bDoIt, OdDbFullSubentPath.getCPtr(pSubId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void subHighlight(bool bDoIt)
	{
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes135))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subHighlightSwigExplicitOdDbEntity__SWIG_2(swigCPtr, bDoIt);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subHighlight__SWIG_2(swigCPtr, bDoIt);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void subHighlight()
	{
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes136))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subHighlightSwigExplicitOdDbEntity__SWIG_3(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subHighlight__SWIG_3(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual OdDb_Visibility subVisibility()
	{
		int result = (SwigDerivedClassHasMethod("subVisibility", swigMethodTypes137) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subVisibilitySwigExplicitOdDbEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subVisibility(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	protected virtual OdResult subSetVisibility(OdDb_Visibility visibility, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("subSetVisibility", swigMethodTypes138) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSetVisibilitySwigExplicitOdDbEntity__SWIG_0(swigCPtr, (int)visibility, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSetVisibility__SWIG_0(swigCPtr, (int)visibility, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subSetVisibility(OdDb_Visibility visibility)
	{
		int result = (SwigDerivedClassHasMethod("subSetVisibility", swigMethodTypes139) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSetVisibilitySwigExplicitOdDbEntity__SWIG_1(swigCPtr, (int)visibility) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSetVisibility__SWIG_1(swigCPtr, (int)visibility));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetGeomExtents(OdGeExtents3d extents)
	{
		int result = (SwigDerivedClassHasMethod("subGetGeomExtents", swigMethodTypes140) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetGeomExtentsSwigExplicitOdDbEntity(swigCPtr, OdGeExtents3d.getCPtr(extents)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetGeomExtents(swigCPtr, OdGeExtents3d.getCPtr(extents)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subDeleteSubentPaths(OdDbFullSubentPathArray paths)
	{
		int result = (SwigDerivedClassHasMethod("subDeleteSubentPaths", swigMethodTypes141) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subDeleteSubentPathsSwigExplicitOdDbEntity(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subDeleteSubentPaths(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subAddSubentPaths(OdDbFullSubentPathArray paths)
	{
		int result = (SwigDerivedClassHasMethod("subAddSubentPaths", swigMethodTypes142) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subAddSubentPathsSwigExplicitOdDbEntity(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subAddSubentPaths(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subMoveGripPointsAtSubentPaths(OdDbFullSubentPathArray paths, OdDbVoidPtrArray gripAppData, OdGeVector3d offset, uint bitflags)
	{
		int result = (SwigDerivedClassHasMethod("subMoveGripPointsAtSubentPaths", swigMethodTypes143) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subMoveGripPointsAtSubentPathsSwigExplicitOdDbEntity(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths), OdDbVoidPtrArray.getCPtr(gripAppData), OdGeVector3d.getCPtr(offset), bitflags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subMoveGripPointsAtSubentPaths(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths), OdDbVoidPtrArray.getCPtr(gripAppData), OdGeVector3d.getCPtr(offset), bitflags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetGripPointsAtSubentPath(OdDbFullSubentPath path, OdDbGripDataPtrArray grips, double curViewUnitSize, int gripSize, OdGeVector3d curViewDir, uint bitflags)
	{
		int result = (SwigDerivedClassHasMethod("subGetGripPointsAtSubentPath", swigMethodTypes144) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetGripPointsAtSubentPathSwigExplicitOdDbEntity(swigCPtr, OdDbFullSubentPath.getCPtr(path), OdDbGripDataPtrArray.getCPtr(grips).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitflags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetGripPointsAtSubentPath(swigCPtr, OdDbFullSubentPath.getCPtr(path), OdDbGripDataPtrArray.getCPtr(grips).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitflags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d xfm, OdDbFullSubentPathArray subentPaths, OdDbObjectIdArray pEntAndInsertStack)
	{
		int result = (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes145) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetSubentPathsAtGsMarkerSwigExplicitOdDbEntity__SWIG_0(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(xfm), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(pEntAndInsertStack)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetSubentPathsAtGsMarker__SWIG_0(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(xfm), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(pEntAndInsertStack)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d xfm, OdDbFullSubentPathArray subentPaths)
	{
		int result = (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes146) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetSubentPathsAtGsMarkerSwigExplicitOdDbEntity__SWIG_1(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(xfm), OdDbFullSubentPathArray.getCPtr(subentPaths)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetSubentPathsAtGsMarker__SWIG_1(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(xfm), OdDbFullSubentPathArray.getCPtr(subentPaths)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetGsMarkersAtSubentPath(OdDbFullSubentPath subPath, OdGsMarkerArray gsMarkers)
	{
		int result = (SwigDerivedClassHasMethod("subGetGsMarkersAtSubentPath", swigMethodTypes147) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetGsMarkersAtSubentPathSwigExplicitOdDbEntity(swigCPtr, OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetGsMarkersAtSubentPath(swigCPtr, OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdDbEntity subSubentPtr(OdDbFullSubentPath path)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(SwigDerivedClassHasMethod("subSubentPtr", swigMethodTypes148) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSubentPtrSwigExplicitOdDbEntity(swigCPtr, OdDbFullSubentPath.getCPtr(path)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSubentPtr(swigCPtr, OdDbFullSubentPath.getCPtr(path)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected virtual OdResult subTransformSubentPathsBy(OdDbFullSubentPathArray paths, OdGeMatrix3d xform)
	{
		int result = (SwigDerivedClassHasMethod("subTransformSubentPathsBy", swigMethodTypes149) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subTransformSubentPathsBySwigExplicitOdDbEntity(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths), OdGeMatrix3d.getCPtr(xform)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subTransformSubentPathsBy(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths), OdGeMatrix3d.getCPtr(xform)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetSubentClassId(OdDbFullSubentPath path, IntPtr clsId)
	{
		int result = (SwigDerivedClassHasMethod("subGetSubentClassId", swigMethodTypes150) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetSubentClassIdSwigExplicitOdDbEntity(swigCPtr, OdDbFullSubentPath.getCPtr(path), clsId) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetSubentClassId(swigCPtr, OdDbFullSubentPath.getCPtr(path), clsId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetSubentPathGeomExtents(OdDbFullSubentPath path, OdGeExtents3d extents)
	{
		int result = (SwigDerivedClassHasMethod("subGetSubentPathGeomExtents", swigMethodTypes151) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetSubentPathGeomExtentsSwigExplicitOdDbEntity(swigCPtr, OdDbFullSubentPath.getCPtr(path), OdGeExtents3d.getCPtr(extents)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subGetSubentPathGeomExtents(swigCPtr, OdDbFullSubentPath.getCPtr(path), OdGeExtents3d.getCPtr(extents)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual void subSubentGripStatus(OdDb_GripStat status, OdDbFullSubentPath subentity)
	{
		if (SwigDerivedClassHasMethod("subSubentGripStatus", swigMethodTypes152))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSubentGripStatusSwigExplicitOdDbEntity(swigCPtr, (int)status, OdDbFullSubentPath.getCPtr(subentity));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_subSubentGripStatus(swigCPtr, (int)status, OdDbFullSubentPath.getCPtr(subentity));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool SubWorldDraw(OdGiWorldDraw pWd)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_SubWorldDraw(swigCPtr, OdGiWorldDraw.getCPtr(pWd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void SubViewportDraw(OdGiViewportDraw pVd)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_SubViewportDraw(swigCPtr, OdGiViewportDraw.getCPtr(pVd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override uint SubSetAttributes(OdGiDrawableTraits pTraits)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_SubSetAttributes(swigCPtr, OdGiDrawableTraits.getCPtr(pTraits));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult SubGetClassID(IntPtr pClsid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_SubGetClassID(swigCPtr, pClsid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbEntity createObject()
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("drawableType", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddrawableType;
		}
		if (SwigDerivedClassHasMethod("isPersistent", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisPersistent;
		}
		if (SwigDerivedClassHasMethod("id", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodid;
		}
		if (SwigDerivedClassHasMethod("setGsNode", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetGsNode;
		}
		if (SwigDerivedClassHasMethod("gsNode", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgsNode;
		}
		if (SwigDerivedClassHasMethod("setOwnerId", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetOwnerId;
		}
		if (SwigDerivedClassHasMethod("subOpen", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsubOpen;
		}
		if (SwigDerivedClassHasMethod("subClose", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsubClose;
		}
		if (SwigDerivedClassHasMethod("subErase", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsubErase;
		}
		if (SwigDerivedClassHasMethod("subHandOverTo", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsubHandOverTo;
		}
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsubSwapIdWith__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsubSwapIdWith__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsubSwapIdWith__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("audit", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodaudit;
		}
		if (SwigDerivedClassHasMethod("dxfIn", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethoddxfIn;
		}
		if (SwigDerivedClassHasMethod("dxfOut", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethoddxfOut;
		}
		if (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethoddwgInFields;
		}
		if (SwigDerivedClassHasMethod("dwgOutFields", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethoddwgOutFields;
		}
		if (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethoddxfInFields;
		}
		if (SwigDerivedClassHasMethod("dxfOutFields", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethoddxfOutFields;
		}
		if (SwigDerivedClassHasMethod("dxfInFields_R12", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethoddxfInFields_R12;
		}
		if (SwigDerivedClassHasMethod("dxfOutFields_R12", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethoddxfOutFields_R12;
		}
		if (SwigDerivedClassHasMethod("mergeStyle", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodmergeStyle;
		}
		if (SwigDerivedClassHasMethod("xData", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodxData;
		}
		if (SwigDerivedClassHasMethod("setXData", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodsetXData;
		}
		if (SwigDerivedClassHasMethod("applyPartialUndo", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodapplyPartialUndo;
		}
		if (SwigDerivedClassHasMethod("addPersistentReactor", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodaddPersistentReactor;
		}
		if (SwigDerivedClassHasMethod("removePersistentReactor", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodremovePersistentReactor;
		}
		if (SwigDerivedClassHasMethod("recvPropagateModify", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodrecvPropagateModify;
		}
		if (SwigDerivedClassHasMethod("xmitPropagateModify", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodxmitPropagateModify;
		}
		if (SwigDerivedClassHasMethod("appendToOwner", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodappendToOwner;
		}
		if (SwigDerivedClassHasMethod("copied", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodcopied;
		}
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethoderased__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethoderased__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("goodbye", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodgoodbye;
		}
		if (SwigDerivedClassHasMethod("openedForModify", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodopenedForModify;
		}
		if (SwigDerivedClassHasMethod("modified", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodmodified;
		}
		if (SwigDerivedClassHasMethod("subObjModified", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodsubObjModified;
		}
		if (SwigDerivedClassHasMethod("modifyUndone", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodmodifyUndone;
		}
		if (SwigDerivedClassHasMethod("modifiedXData", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodmodifiedXData;
		}
		if (SwigDerivedClassHasMethod("unappended", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodunappended;
		}
		if (SwigDerivedClassHasMethod("reappended", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodreappended;
		}
		if (SwigDerivedClassHasMethod("objectClosed", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodobjectClosed;
		}
		if (SwigDerivedClassHasMethod("modifiedGraphics", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodmodifiedGraphics;
		}
		if (SwigDerivedClassHasMethod("copyMeFrom", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodcopyMeFrom;
		}
		if (SwigDerivedClassHasMethod("getObjectSaveVersion", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodgetObjectSaveVersion__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getObjectSaveVersion", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodgetObjectSaveVersion__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("decomposeForSave", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethoddecomposeForSave__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("decomposeForSave", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethoddecomposeForSave__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("composeForLoad", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodcomposeForLoad;
		}
		if (SwigDerivedClassHasMethod("drawable", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethoddrawable;
		}
		if (SwigDerivedClassHasMethod("setField", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodsetField;
		}
		if (SwigDerivedClassHasMethod("removeField", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodremoveField__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("removeField", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodremoveField__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("saveAsClass", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodsaveAsClass;
		}
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodsetColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodsetColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("entityColor", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodentityColor;
		}
		if (SwigDerivedClassHasMethod("setColorIndex", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodsetColorIndex__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setColorIndex", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodsetColorIndex__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setColorId", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodsetColorId__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setColorId", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodsetColorId__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setTransparency", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodsetTransparency__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setTransparency", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodsetTransparency__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodsetPlotStyleName__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodsetPlotStyleName__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodsetPlotStyleName__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodsetPlotStyleName__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodsetPlotStyleName__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodsetLayer__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodsetLayer__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodsetLayer__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodsetLayer__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodsetLayer__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodsetLayer__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodsetLinetype__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodsetLinetype__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodsetLinetype__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodsetLinetype__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodsetMaterial__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodsetMaterial__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodsetMaterial__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodsetMaterial__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodsetVisualStyle;
		}
		if (SwigDerivedClassHasMethod("materialMapper", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodmaterialMapper;
		}
		if (SwigDerivedClassHasMethod("setMaterialMapper", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodsetMaterialMapper__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setMaterialMapper", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodsetMaterialMapper__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLinetypeScale", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodsetLinetypeScale__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setLinetypeScale", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodsetLinetypeScale__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLineWeight", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodsetLineWeight__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setLineWeight", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodsetLineWeight__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("castShadows", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodcastShadows;
		}
		if (SwigDerivedClassHasMethod("setCastShadows", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodsetCastShadows;
		}
		if (SwigDerivedClassHasMethod("receiveShadows", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodreceiveShadows;
		}
		if (SwigDerivedClassHasMethod("setReceiveShadows", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodsetReceiveShadows;
		}
		if (SwigDerivedClassHasMethod("collisionType", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodcollisionType;
		}
		if (SwigDerivedClassHasMethod("isPlanar", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethodisPlanar;
		}
		if (SwigDerivedClassHasMethod("getPlane", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodgetPlane;
		}
		if (SwigDerivedClassHasMethod("explodeToBlock", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodexplodeToBlock__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("explodeToBlock", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethodexplodeToBlock__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("explodeGeometry", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethodexplodeGeometry;
		}
		if (SwigDerivedClassHasMethod("explodeGeometryToBlock", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethodexplodeGeometryToBlock__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("explodeGeometryToBlock", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodexplodeGeometryToBlock__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subSetDatabaseDefaults", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethodsubSetDatabaseDefaults;
		}
		if (SwigDerivedClassHasMethod("subList", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodsubList;
		}
		if (SwigDerivedClassHasMethod("dragStatus", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethoddragStatus;
		}
		if (SwigDerivedClassHasMethod("saveAs", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodsaveAs;
		}
		if (SwigDerivedClassHasMethod("getEcs", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodgetEcs;
		}
		if (SwigDerivedClassHasMethod("subTransformBy", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodsubTransformBy;
		}
		if (SwigDerivedClassHasMethod("subGetTransformedCopy", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodsubGetTransformedCopy;
		}
		if (SwigDerivedClassHasMethod("subExplode", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethodsubExplode;
		}
		if (SwigDerivedClassHasMethod("subGetCompoundObjectTransform", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodsubGetCompoundObjectTransform;
		}
		if (SwigDerivedClassHasMethod("subCloneMeForDragging", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethodsubCloneMeForDragging;
		}
		if (SwigDerivedClassHasMethod("subHideMeForDragging", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethodsubHideMeForDragging;
		}
		if (SwigDerivedClassHasMethod("subGripStatus", swigMethodTypes117))
		{
			swigDelegate117 = SwigDirectorMethodsubGripStatus;
		}
		if (SwigDerivedClassHasMethod("subGetOsnapPoints", swigMethodTypes118))
		{
			swigDelegate118 = SwigDirectorMethodsubGetOsnapPoints__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subGetOsnapPoints", swigMethodTypes119))
		{
			swigDelegate119 = SwigDirectorMethodsubGetOsnapPoints__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subIsContentSnappable", swigMethodTypes120))
		{
			swigDelegate120 = SwigDirectorMethodsubIsContentSnappable;
		}
		if (SwigDerivedClassHasMethod("subGetGripPoints", swigMethodTypes121))
		{
			swigDelegate121 = SwigDirectorMethodsubGetGripPoints__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subMoveGripPointsAt", swigMethodTypes122))
		{
			swigDelegate122 = SwigDirectorMethodsubMoveGripPointsAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subGetGripPoints", swigMethodTypes123))
		{
			swigDelegate123 = SwigDirectorMethodsubGetGripPoints__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subMoveGripPointsAt", swigMethodTypes124))
		{
			swigDelegate124 = SwigDirectorMethodsubMoveGripPointsAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subGetStretchPoints", swigMethodTypes125))
		{
			swigDelegate125 = SwigDirectorMethodsubGetStretchPoints;
		}
		if (SwigDerivedClassHasMethod("subMoveStretchPointsAt", swigMethodTypes126))
		{
			swigDelegate126 = SwigDirectorMethodsubMoveStretchPointsAt;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes127))
		{
			swigDelegate127 = SwigDirectorMethodsubIntersectWith__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes128))
		{
			swigDelegate128 = SwigDirectorMethodsubIntersectWith__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes129))
		{
			swigDelegate129 = SwigDirectorMethodsubIntersectWith__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes130))
		{
			swigDelegate130 = SwigDirectorMethodsubIntersectWith__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes131))
		{
			swigDelegate131 = SwigDirectorMethodsubIntersectWith__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes132))
		{
			swigDelegate132 = SwigDirectorMethodsubIntersectWith__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes133))
		{
			swigDelegate133 = SwigDirectorMethodsubHighlight__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes134))
		{
			swigDelegate134 = SwigDirectorMethodsubHighlight__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes135))
		{
			swigDelegate135 = SwigDirectorMethodsubHighlight__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes136))
		{
			swigDelegate136 = SwigDirectorMethodsubHighlight__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("subVisibility", swigMethodTypes137))
		{
			swigDelegate137 = SwigDirectorMethodsubVisibility;
		}
		if (SwigDerivedClassHasMethod("subSetVisibility", swigMethodTypes138))
		{
			swigDelegate138 = SwigDirectorMethodsubSetVisibility__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subSetVisibility", swigMethodTypes139))
		{
			swigDelegate139 = SwigDirectorMethodsubSetVisibility__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subGetGeomExtents", swigMethodTypes140))
		{
			swigDelegate140 = SwigDirectorMethodsubGetGeomExtents;
		}
		if (SwigDerivedClassHasMethod("subDeleteSubentPaths", swigMethodTypes141))
		{
			swigDelegate141 = SwigDirectorMethodsubDeleteSubentPaths;
		}
		if (SwigDerivedClassHasMethod("subAddSubentPaths", swigMethodTypes142))
		{
			swigDelegate142 = SwigDirectorMethodsubAddSubentPaths;
		}
		if (SwigDerivedClassHasMethod("subMoveGripPointsAtSubentPaths", swigMethodTypes143))
		{
			swigDelegate143 = SwigDirectorMethodsubMoveGripPointsAtSubentPaths;
		}
		if (SwigDerivedClassHasMethod("subGetGripPointsAtSubentPath", swigMethodTypes144))
		{
			swigDelegate144 = SwigDirectorMethodsubGetGripPointsAtSubentPath;
		}
		if (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes145))
		{
			swigDelegate145 = SwigDirectorMethodsubGetSubentPathsAtGsMarker__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes146))
		{
			swigDelegate146 = SwigDirectorMethodsubGetSubentPathsAtGsMarker__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subGetGsMarkersAtSubentPath", swigMethodTypes147))
		{
			swigDelegate147 = SwigDirectorMethodsubGetGsMarkersAtSubentPath;
		}
		if (SwigDerivedClassHasMethod("subSubentPtr", swigMethodTypes148))
		{
			swigDelegate148 = SwigDirectorMethodsubSubentPtr;
		}
		if (SwigDerivedClassHasMethod("subTransformSubentPathsBy", swigMethodTypes149))
		{
			swigDelegate149 = SwigDirectorMethodsubTransformSubentPathsBy;
		}
		if (SwigDerivedClassHasMethod("subGetSubentClassId", swigMethodTypes150))
		{
			swigDelegate150 = SwigDirectorMethodsubGetSubentClassId;
		}
		if (SwigDerivedClassHasMethod("subGetSubentPathGeomExtents", swigMethodTypes151))
		{
			swigDelegate151 = SwigDirectorMethodsubGetSubentPathGeomExtents;
		}
		if (SwigDerivedClassHasMethod("subSubentGripStatus", swigMethodTypes152))
		{
			swigDelegate152 = SwigDirectorMethodsubSubentGripStatus;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntity_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125, swigDelegate126, swigDelegate127, swigDelegate128, swigDelegate129, swigDelegate130, swigDelegate131, swigDelegate132, swigDelegate133, swigDelegate134, swigDelegate135, swigDelegate136, swigDelegate137, swigDelegate138, swigDelegate139, swigDelegate140, swigDelegate141, swigDelegate142, swigDelegate143, swigDelegate144, swigDelegate145, swigDelegate146, swigDelegate147, swigDelegate148, swigDelegate149, swigDelegate150, swigDelegate151, swigDelegate152);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbEntity));
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

	private int SwigDirectorMethoddrawableType()
	{
		return (int)drawableType();
	}

	private bool SwigDirectorMethodisPersistent()
	{
		return isPersistent();
	}

	private IntPtr SwigDirectorMethodid()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(id()).Handle;
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

	private void SwigDirectorMethodsetGsNode(IntPtr pNode)
	{
		try
		{
			setGsNode(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsCache>(pNode, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodgsNode()
	{
		return OdGsCache.getCPtr(gsNode()).Handle;
	}

	private void SwigDirectorMethodsetOwnerId(IntPtr ownerId)
	{
		try
		{
			setOwnerId(new OdDbObjectId(ownerId, cMemoryOwn: true));
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

	private int SwigDirectorMethodsubOpen(int mode)
	{
		return (int)subOpen((OdDb_OpenMode)mode);
	}

	private void SwigDirectorMethodsubClose()
	{
		try
		{
			subClose();
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

	private int SwigDirectorMethodsubErase(bool erasing)
	{
		return (int)subErase(erasing);
	}

	private void SwigDirectorMethodsubHandOverTo(IntPtr pNewObject)
	{
		try
		{
			subHandOverTo(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pNewObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodsubSwapIdWith__SWIG_0(IntPtr otherId, bool swapXdata, bool swapExtDict)
	{
		try
		{
			subSwapIdWith(new OdDbObjectId(otherId, cMemoryOwn: false), swapXdata, swapExtDict);
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

	private void SwigDirectorMethodsubSwapIdWith__SWIG_1(IntPtr otherId, bool swapXdata)
	{
		try
		{
			subSwapIdWith(new OdDbObjectId(otherId, cMemoryOwn: false), swapXdata);
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

	private void SwigDirectorMethodsubSwapIdWith__SWIG_2(IntPtr otherId)
	{
		try
		{
			subSwapIdWith(new OdDbObjectId(otherId, cMemoryOwn: false));
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

	private void SwigDirectorMethodaudit(IntPtr pAuditInfo)
	{
		try
		{
			audit((pAuditInfo == IntPtr.Zero) ? null : new OdDbAuditInfo(pAuditInfo, cMemoryOwn: false));
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

	private int SwigDirectorMethoddxfIn(IntPtr pFiler)
	{
		return (int)dxfIn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethoddxfOut(IntPtr pFiler)
	{
		try
		{
			dxfOut(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethoddwgInFields(IntPtr pFiler)
	{
		return (int)dwgInFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethoddwgOutFields(IntPtr pFiler)
	{
		try
		{
			dwgOutFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethoddxfInFields(IntPtr pFiler)
	{
		return (int)dxfInFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethoddxfOutFields(IntPtr pFiler)
	{
		try
		{
			dxfOutFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethoddxfInFields_R12(IntPtr pFiler)
	{
		return (int)dxfInFields_R12(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethoddxfOutFields_R12(IntPtr pFiler)
	{
		try
		{
			dxfOutFields_R12(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodmergeStyle()
	{
		return (int)mergeStyle();
	}

	private IntPtr SwigDirectorMethodxData([MarshalAs(UnmanagedType.LPWStr)] string regappName)
	{
		return OdResBuf.getCPtr(xData(regappName)).Handle;
	}

	private void SwigDirectorMethodsetXData(IntPtr pRb)
	{
		try
		{
			setXData(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(pRb, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodapplyPartialUndo(IntPtr pUndoFiler, IntPtr pClassObj)
	{
		try
		{
			applyPartialUndo(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(pUndoFiler, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(pClassObj, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodaddPersistentReactor(IntPtr objId)
	{
		try
		{
			addPersistentReactor(new OdDbObjectId(objId, cMemoryOwn: false));
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

	private void SwigDirectorMethodremovePersistentReactor(IntPtr objId)
	{
		try
		{
			removePersistentReactor(new OdDbObjectId(objId, cMemoryOwn: false));
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

	private void SwigDirectorMethodrecvPropagateModify(IntPtr pSubObj)
	{
		try
		{
			recvPropagateModify(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pSubObj, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodxmitPropagateModify()
	{
		try
		{
			xmitPropagateModify();
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

	private void SwigDirectorMethodappendToOwner(IntPtr idPair, IntPtr pOwnerObject, IntPtr ownerIdMap)
	{
		OdSwigDirectorHelper.director_UnpackData(ownerIdMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			appendToOwner(new OdDbIdPair(idPair, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOwnerObject, bOwn: false, bTryAddToTransaction: false), ref idMap);
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
			IntPtr intPtr = OdDbIdMapping.getCPtr(idMap).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(ownerIdMap);
		}
	}

	private void SwigDirectorMethodcopied(IntPtr pObject, IntPtr pNewObject)
	{
		try
		{
			copied(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pNewObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethoderased__SWIG_0(IntPtr pObject, bool erasing)
	{
		try
		{
			erased(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), erasing);
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

	private void SwigDirectorMethoderased__SWIG_1(IntPtr pObject)
	{
		try
		{
			erased(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodgoodbye(IntPtr pObject)
	{
		try
		{
			goodbye(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodopenedForModify(IntPtr pObject)
	{
		try
		{
			openedForModify(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodmodified(IntPtr pObject)
	{
		try
		{
			modified(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodsubObjModified(IntPtr pObject, IntPtr pSubObj)
	{
		try
		{
			subObjModified(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pSubObj, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodmodifyUndone(IntPtr pObject)
	{
		try
		{
			modifyUndone(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodmodifiedXData(IntPtr pObject)
	{
		try
		{
			modifiedXData(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodunappended(IntPtr pObject)
	{
		try
		{
			unappended(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodreappended(IntPtr pObject)
	{
		try
		{
			reappended(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodobjectClosed(IntPtr objectId)
	{
		try
		{
			objectClosed(new OdDbObjectId(objectId, cMemoryOwn: false));
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

	private void SwigDirectorMethodmodifiedGraphics(IntPtr pObject)
	{
		try
		{
			modifiedGraphics(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodcopyMeFrom(IntPtr pSource)
	{
		try
		{
			copyMeFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodgetObjectSaveVersion__SWIG_0(IntPtr pFiler, MaintReleaseVer pMaintVer)
	{
		return (int)getObjectSaveVersion(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbFiler>(pFiler, bOwn: false, bTryAddToTransaction: false), out pMaintVer);
	}

	private int SwigDirectorMethodgetObjectSaveVersion__SWIG_1(IntPtr pFiler)
	{
		return (int)getObjectSaveVersion(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethoddecomposeForSave__SWIG_0(int ver, IntPtr replaceId, bool exchangeXData)
	{
		return OdDbObject.getCPtr(decomposeForSave((DwgVersion)ver, new OdDbObjectId(replaceId, cMemoryOwn: false), out exchangeXData)).Handle;
	}

	private IntPtr SwigDirectorMethoddecomposeForSave__SWIG_1(int format, int ver, IntPtr replaceId, bool exchangeXData)
	{
		return OdDbObject.getCPtr(decomposeForSave((OdDb_SaveType)format, (DwgVersion)ver, new OdDbObjectId(replaceId, cMemoryOwn: false), out exchangeXData)).Handle;
	}

	private void SwigDirectorMethodcomposeForLoad(int format, int version, IntPtr pAuditInfo)
	{
		try
		{
			composeForLoad((OdDb_SaveType)format, (DwgVersion)version, (pAuditInfo == IntPtr.Zero) ? null : new OdDbAuditInfo(pAuditInfo, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethoddrawable()
	{
		return OdGiDrawable.getCPtr(drawable()).Handle;
	}

	private IntPtr SwigDirectorMethodsetField([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(setField(fieldName, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbField>(pField, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private int SwigDirectorMethodremoveField__SWIG_0(IntPtr fieldId)
	{
		return (int)removeField(new OdDbObjectId(fieldId, cMemoryOwn: true));
	}

	private IntPtr SwigDirectorMethodremoveField__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string fieldName)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(removeField(fieldName)).Handle;
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

	private IntPtr SwigDirectorMethodsaveAsClass(IntPtr pClass)
	{
		return OdRxClass.getCPtr(saveAsClass(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private int SwigDirectorMethodsetColor__SWIG_0(IntPtr color, bool doSubents)
	{
		return (int)setColor(new OdCmColor(color, cMemoryOwn: false), doSubents);
	}

	private int SwigDirectorMethodsetColor__SWIG_1(IntPtr color)
	{
		return (int)setColor(new OdCmColor(color, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodentityColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(entityColor()).Handle;
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

	private int SwigDirectorMethodsetColorIndex__SWIG_0(ushort colorIndex, bool doSubents)
	{
		return (int)setColorIndex(colorIndex, doSubents);
	}

	private int SwigDirectorMethodsetColorIndex__SWIG_1(ushort colorIndex)
	{
		return (int)setColorIndex(colorIndex);
	}

	private int SwigDirectorMethodsetColorId__SWIG_0(IntPtr colorId, bool doSubents)
	{
		return (int)setColorId(new OdDbObjectId(colorId, cMemoryOwn: true), doSubents);
	}

	private int SwigDirectorMethodsetColorId__SWIG_1(IntPtr colorId)
	{
		return (int)setColorId(new OdDbObjectId(colorId, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsetTransparency__SWIG_0(IntPtr transparency, bool doSubents)
	{
		return (int)setTransparency(new OdCmTransparency(transparency, cMemoryOwn: false), doSubents);
	}

	private int SwigDirectorMethodsetTransparency__SWIG_1(IntPtr transparency)
	{
		return (int)setTransparency(new OdCmTransparency(transparency, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsetPlotStyleName__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName, bool doSubents)
	{
		return (int)setPlotStyleName(plotStyleName, doSubents);
	}

	private int SwigDirectorMethodsetPlotStyleName__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName)
	{
		return (int)setPlotStyleName(plotStyleName);
	}

	private int SwigDirectorMethodsetPlotStyleName__SWIG_2(int plotStyleNameType, IntPtr plotStyleNameId, bool doSubents)
	{
		return (int)setPlotStyleName((PlotStyleNameType)plotStyleNameType, new OdDbObjectId(plotStyleNameId, cMemoryOwn: true), doSubents);
	}

	private int SwigDirectorMethodsetPlotStyleName__SWIG_3(int plotStyleNameType, IntPtr plotStyleNameId)
	{
		return (int)setPlotStyleName((PlotStyleNameType)plotStyleNameType, new OdDbObjectId(plotStyleNameId, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsetPlotStyleName__SWIG_4(int plotStyleNameType)
	{
		return (int)setPlotStyleName((PlotStyleNameType)plotStyleNameType);
	}

	private int SwigDirectorMethodsetLayer__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents, bool allowHiddenLayer)
	{
		return (int)setLayer(layerName, doSubents, allowHiddenLayer);
	}

	private int SwigDirectorMethodsetLayer__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents)
	{
		return (int)setLayer(layerName, doSubents);
	}

	private int SwigDirectorMethodsetLayer__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string layerName)
	{
		return (int)setLayer(layerName);
	}

	private int SwigDirectorMethodsetLayer__SWIG_3(IntPtr layerId, bool doSubents, bool allowHiddenLayer)
	{
		return (int)setLayer(new OdDbObjectId(layerId, cMemoryOwn: true), doSubents, allowHiddenLayer);
	}

	private int SwigDirectorMethodsetLayer__SWIG_4(IntPtr layerId, bool doSubents)
	{
		return (int)setLayer(new OdDbObjectId(layerId, cMemoryOwn: true), doSubents);
	}

	private int SwigDirectorMethodsetLayer__SWIG_5(IntPtr layerId)
	{
		return (int)setLayer(new OdDbObjectId(layerId, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsetLinetype__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string linetypeName, bool doSubents)
	{
		return (int)setLinetype(linetypeName, doSubents);
	}

	private int SwigDirectorMethodsetLinetype__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string linetypeName)
	{
		return (int)setLinetype(linetypeName);
	}

	private int SwigDirectorMethodsetLinetype__SWIG_2(IntPtr linetypeID, bool doSubents)
	{
		return (int)setLinetype(new OdDbObjectId(linetypeID, cMemoryOwn: true), doSubents);
	}

	private int SwigDirectorMethodsetLinetype__SWIG_3(IntPtr linetypeID)
	{
		return (int)setLinetype(new OdDbObjectId(linetypeID, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsetMaterial__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string materialName, bool doSubents)
	{
		return (int)setMaterial(materialName, doSubents);
	}

	private int SwigDirectorMethodsetMaterial__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string materialName)
	{
		return (int)setMaterial(materialName);
	}

	private int SwigDirectorMethodsetMaterial__SWIG_2(IntPtr materialID, bool doSubents)
	{
		return (int)setMaterial(new OdDbObjectId(materialID, cMemoryOwn: true), doSubents);
	}

	private int SwigDirectorMethodsetMaterial__SWIG_3(IntPtr materialID)
	{
		return (int)setMaterial(new OdDbObjectId(materialID, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsetVisualStyle(IntPtr visualStyleId, int vstype, bool doSubents)
	{
		return (int)setVisualStyle(new OdDbObjectId(visualStyleId, cMemoryOwn: true), (OdDbEntity_VisualStyleType)vstype, doSubents);
	}

	private IntPtr SwigDirectorMethodmaterialMapper()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiMapper.getCPtr(materialMapper()).Handle;
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

	private void SwigDirectorMethodsetMaterialMapper__SWIG_0(IntPtr mapper, bool doSubents)
	{
		try
		{
			setMaterialMapper((mapper == IntPtr.Zero) ? null : new OdGiMapper(mapper, cMemoryOwn: false), doSubents);
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

	private void SwigDirectorMethodsetMaterialMapper__SWIG_1(IntPtr mapper)
	{
		try
		{
			setMaterialMapper((mapper == IntPtr.Zero) ? null : new OdGiMapper(mapper, cMemoryOwn: false));
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

	private int SwigDirectorMethodsetLinetypeScale__SWIG_0(double linetypeScale, bool doSubents)
	{
		return (int)setLinetypeScale(linetypeScale, doSubents);
	}

	private int SwigDirectorMethodsetLinetypeScale__SWIG_1(double linetypeScale)
	{
		return (int)setLinetypeScale(linetypeScale);
	}

	private int SwigDirectorMethodsetLineWeight__SWIG_0(int lineWeight, bool doSubents)
	{
		return (int)setLineWeight((LineWeight)lineWeight, doSubents);
	}

	private int SwigDirectorMethodsetLineWeight__SWIG_1(int lineWeight)
	{
		return (int)setLineWeight((LineWeight)lineWeight);
	}

	private bool SwigDirectorMethodcastShadows()
	{
		return castShadows();
	}

	private void SwigDirectorMethodsetCastShadows(bool castShadows)
	{
		try
		{
			setCastShadows(castShadows);
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

	private bool SwigDirectorMethodreceiveShadows()
	{
		return receiveShadows();
	}

	private void SwigDirectorMethodsetReceiveShadows(bool receiveShadows)
	{
		try
		{
			setReceiveShadows(receiveShadows);
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

	private int SwigDirectorMethodcollisionType()
	{
		return (int)collisionType();
	}

	private bool SwigDirectorMethodisPlanar()
	{
		return isPlanar();
	}

	private int SwigDirectorMethodgetPlane(IntPtr plane, OdDb_Planarity planarity)
	{
		return (int)getPlane(new OdGePlane(plane, cMemoryOwn: false), out planarity);
	}

	private int SwigDirectorMethodexplodeToBlock__SWIG_0(IntPtr pBlockRecord, IntPtr ids)
	{
		return (int)explodeToBlock(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableRecord>(pBlockRecord, bOwn: false, bTryAddToTransaction: false), (ids == IntPtr.Zero) ? null : new OdDbObjectIdArray(ids, cMemoryOwn: false));
	}

	private int SwigDirectorMethodexplodeToBlock__SWIG_1(IntPtr pBlockRecord)
	{
		return (int)explodeToBlock(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableRecord>(pBlockRecord, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodexplodeGeometry(IntPtr entitySet)
	{
		return (int)explodeGeometry(new OdRxObjectPtrArray(entitySet, cMemoryOwn: true));
	}

	private int SwigDirectorMethodexplodeGeometryToBlock__SWIG_0(IntPtr pBlockRecord, IntPtr ids)
	{
		return (int)explodeGeometryToBlock(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableRecord>(pBlockRecord, bOwn: false, bTryAddToTransaction: false), (ids == IntPtr.Zero) ? null : new OdDbObjectIdArray(ids, cMemoryOwn: false));
	}

	private int SwigDirectorMethodexplodeGeometryToBlock__SWIG_1(IntPtr pBlockRecord)
	{
		return (int)explodeGeometryToBlock(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableRecord>(pBlockRecord, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsubSetDatabaseDefaults(IntPtr pDb, bool doSubents)
	{
		try
		{
			subSetDatabaseDefaults(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), doSubents);
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

	private void SwigDirectorMethodsubList()
	{
		try
		{
			subList();
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

	private void SwigDirectorMethoddragStatus(int status)
	{
		try
		{
			dragStatus((OdDb_DragStat)status);
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

	private void SwigDirectorMethodsaveAs(IntPtr pWd, int ver)
	{
		try
		{
			saveAs(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiWorldDraw>(pWd, bOwn: false, bTryAddToTransaction: false), (DwgVersion)ver);
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

	private IntPtr SwigDirectorMethodgetEcs()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getEcs()).Handle;
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

	private int SwigDirectorMethodsubTransformBy(IntPtr xfm)
	{
		return (int)subTransformBy(new OdGeMatrix3d(xfm, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubGetTransformedCopy(IntPtr xfm, IntPtr pCopy)
	{
		OdSwigDirectorHelper.director_UnpackData(pCopy, out var pOriginalObject, out var pFunction);
		OdDbEntity pCopy2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)subGetTransformedCopy(new OdGeMatrix3d(xfm, cMemoryOwn: false), ref pCopy2);
		}
		finally
		{
			IntPtr intPtr = getCPtr(pCopy2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pCopy);
		}
	}

	private int SwigDirectorMethodsubExplode(IntPtr entitySet)
	{
		return (int)subExplode(new OdRxObjectPtrArray(entitySet, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsubGetCompoundObjectTransform(IntPtr xM)
	{
		return (int)subGetCompoundObjectTransform(new OdGeMatrix3d(xM, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodsubCloneMeForDragging()
	{
		return subCloneMeForDragging();
	}

	private bool SwigDirectorMethodsubHideMeForDragging()
	{
		return subHideMeForDragging();
	}

	private void SwigDirectorMethodsubGripStatus(int status)
	{
		try
		{
			subGripStatus((OdDb_GripStat)status);
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

	private int SwigDirectorMethodsubGetOsnapPoints__SWIG_0(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints)
	{
		return (int)subGetOsnapPoints((OsnapMode)osnapMode, gsSelectionMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGePoint3d(lastPoint, cMemoryOwn: false), new OdGeMatrix3d(xWorldToEye, cMemoryOwn: false), new OdGePoint3dArray(snapPoints, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsubGetOsnapPoints__SWIG_1(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insertionMat)
	{
		return (int)subGetOsnapPoints((OsnapMode)osnapMode, gsSelectionMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGePoint3d(lastPoint, cMemoryOwn: false), new OdGeMatrix3d(xWorldToEye, cMemoryOwn: false), new OdGePoint3dArray(snapPoints, cMemoryOwn: true), new OdGeMatrix3d(insertionMat, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodsubIsContentSnappable()
	{
		return subIsContentSnappable();
	}

	private int SwigDirectorMethodsubGetGripPoints__SWIG_0(IntPtr gripPoints)
	{
		return (int)subGetGripPoints(new OdGePoint3dArray(gripPoints, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsubMoveGripPointsAt__SWIG_0(IntPtr indices, IntPtr offset)
	{
		return (int)subMoveGripPointsAt(new OdIntArray(indices, cMemoryOwn: true), new OdGeVector3d(offset, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubGetGripPoints__SWIG_1(IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags)
	{
		return (int)subGetGripPoints(new OdDbGripDataPtrArray(grips, cMemoryOwn: true), curViewUnitSize, gripSize, new OdGeVector3d(curViewDir, cMemoryOwn: false), bitFlags);
	}

	private int SwigDirectorMethodsubMoveGripPointsAt__SWIG_1(IntPtr grips, IntPtr offset, int bitFlags)
	{
		return (int)subMoveGripPointsAt(new OdDbVoidPtrArray(grips, cMemoryOwn: false), new OdGeVector3d(offset, cMemoryOwn: false), bitFlags);
	}

	private int SwigDirectorMethodsubGetStretchPoints(IntPtr stretchPoints)
	{
		return (int)subGetStretchPoints(new OdGePoint3dArray(stretchPoints, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsubMoveStretchPointsAt(IntPtr indices, IntPtr offset)
	{
		return (int)subMoveStretchPointsAt(new OdIntArray(indices, cMemoryOwn: true), new OdGeVector3d(offset, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubIntersectWith__SWIG_0(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		return (int)subIntersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePoint3dArray(points, cMemoryOwn: true), thisGsMarker, otherGsMarker);
	}

	private int SwigDirectorMethodsubIntersectWith__SWIG_1(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker)
	{
		return (int)subIntersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePoint3dArray(points, cMemoryOwn: true), thisGsMarker);
	}

	private int SwigDirectorMethodsubIntersectWith__SWIG_2(IntPtr pEnt, int intType, IntPtr points)
	{
		return (int)subIntersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePoint3dArray(points, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsubIntersectWith__SWIG_3(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		return (int)subIntersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePlane(projPlane, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: true), thisGsMarker, otherGsMarker);
	}

	private int SwigDirectorMethodsubIntersectWith__SWIG_4(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker)
	{
		return (int)subIntersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePlane(projPlane, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: true), thisGsMarker);
	}

	private int SwigDirectorMethodsubIntersectWith__SWIG_5(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points)
	{
		return (int)subIntersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePlane(projPlane, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: true));
	}

	private void SwigDirectorMethodsubHighlight__SWIG_0(bool bDoIt, IntPtr pSubId, bool highlightAll)
	{
		try
		{
			subHighlight(bDoIt, (pSubId == IntPtr.Zero) ? null : new OdDbFullSubentPath(pSubId, cMemoryOwn: false), highlightAll);
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

	private void SwigDirectorMethodsubHighlight__SWIG_1(bool bDoIt, IntPtr pSubId)
	{
		try
		{
			subHighlight(bDoIt, (pSubId == IntPtr.Zero) ? null : new OdDbFullSubentPath(pSubId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsubHighlight__SWIG_2(bool bDoIt)
	{
		try
		{
			subHighlight(bDoIt);
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

	private void SwigDirectorMethodsubHighlight__SWIG_3()
	{
		try
		{
			subHighlight();
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

	private int SwigDirectorMethodsubVisibility()
	{
		return (int)subVisibility();
	}

	private int SwigDirectorMethodsubSetVisibility__SWIG_0(int visibility, bool doSubents)
	{
		return (int)subSetVisibility((OdDb_Visibility)visibility, doSubents);
	}

	private int SwigDirectorMethodsubSetVisibility__SWIG_1(int visibility)
	{
		return (int)subSetVisibility((OdDb_Visibility)visibility);
	}

	private int SwigDirectorMethodsubGetGeomExtents(IntPtr extents)
	{
		return (int)subGetGeomExtents(new OdGeExtents3d(extents, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubDeleteSubentPaths(IntPtr paths)
	{
		return (int)subDeleteSubentPaths(new OdDbFullSubentPathArray(paths, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubAddSubentPaths(IntPtr paths)
	{
		return (int)subAddSubentPaths(new OdDbFullSubentPathArray(paths, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubMoveGripPointsAtSubentPaths(IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags)
	{
		return (int)subMoveGripPointsAtSubentPaths(new OdDbFullSubentPathArray(paths, cMemoryOwn: false), new OdDbVoidPtrArray(gripAppData, cMemoryOwn: false), new OdGeVector3d(offset, cMemoryOwn: false), bitflags);
	}

	private int SwigDirectorMethodsubGetGripPointsAtSubentPath(IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags)
	{
		return (int)subGetGripPointsAtSubentPath(new OdDbFullSubentPath(path, cMemoryOwn: false), new OdDbGripDataPtrArray(grips, cMemoryOwn: true), curViewUnitSize, gripSize, new OdGeVector3d(curViewDir, cMemoryOwn: false), bitflags);
	}

	private int SwigDirectorMethodsubGetSubentPathsAtGsMarker__SWIG_0(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths, IntPtr pEntAndInsertStack)
	{
		return (int)subGetSubentPathsAtGsMarker((OdDb_SubentType)type, gsMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGeMatrix3d(xfm, cMemoryOwn: false), new OdDbFullSubentPathArray(subentPaths, cMemoryOwn: false), (pEntAndInsertStack == IntPtr.Zero) ? null : new OdDbObjectIdArray(pEntAndInsertStack, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubGetSubentPathsAtGsMarker__SWIG_1(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths)
	{
		return (int)subGetSubentPathsAtGsMarker((OdDb_SubentType)type, gsMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGeMatrix3d(xfm, cMemoryOwn: false), new OdDbFullSubentPathArray(subentPaths, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubGetGsMarkersAtSubentPath(IntPtr subPath, IntPtr gsMarkers)
	{
		return (int)subGetGsMarkersAtSubentPath(new OdDbFullSubentPath(subPath, cMemoryOwn: false), new OdGsMarkerArray(gsMarkers, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodsubSubentPtr(IntPtr path)
	{
		return getCPtr(subSubentPtr(new OdDbFullSubentPath(path, cMemoryOwn: false))).Handle;
	}

	private int SwigDirectorMethodsubTransformSubentPathsBy(IntPtr paths, IntPtr xform)
	{
		return (int)subTransformSubentPathsBy(new OdDbFullSubentPathArray(paths, cMemoryOwn: false), new OdGeMatrix3d(xform, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubGetSubentClassId(IntPtr path, IntPtr clsId)
	{
		return (int)subGetSubentClassId(new OdDbFullSubentPath(path, cMemoryOwn: false), clsId);
	}

	private int SwigDirectorMethodsubGetSubentPathGeomExtents(IntPtr path, IntPtr extents)
	{
		return (int)subGetSubentPathGeomExtents(new OdDbFullSubentPath(path, cMemoryOwn: false), new OdGeExtents3d(extents, cMemoryOwn: false));
	}

	private void SwigDirectorMethodsubSubentGripStatus(int status, IntPtr subentity)
	{
		try
		{
			subSubentGripStatus((OdDb_GripStat)status, new OdDbFullSubentPath(subentity, cMemoryOwn: false));
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
}

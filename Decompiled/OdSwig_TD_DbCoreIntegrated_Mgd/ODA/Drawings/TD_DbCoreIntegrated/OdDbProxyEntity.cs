using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbProxyEntity : OdDbEntity
{
	public delegate IntPtr SwigDelegateOdDbProxyEntity_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbProxyEntity_1();

	public delegate void SwigDelegateOdDbProxyEntity_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbProxyEntity_3();

	public delegate bool SwigDelegateOdDbProxyEntity_4();

	public delegate IntPtr SwigDelegateOdDbProxyEntity_5();

	public delegate void SwigDelegateOdDbProxyEntity_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbProxyEntity_7();

	public delegate void SwigDelegateOdDbProxyEntity_8(IntPtr ownerId);

	public delegate int SwigDelegateOdDbProxyEntity_9(int mode);

	public delegate void SwigDelegateOdDbProxyEntity_10();

	public delegate int SwigDelegateOdDbProxyEntity_11(bool erasing);

	public delegate void SwigDelegateOdDbProxyEntity_12(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbProxyEntity_13(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbProxyEntity_14(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbProxyEntity_15(IntPtr otherId);

	public delegate void SwigDelegateOdDbProxyEntity_16(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbProxyEntity_17(IntPtr pFiler);

	public delegate void SwigDelegateOdDbProxyEntity_18(IntPtr pFiler);

	public delegate int SwigDelegateOdDbProxyEntity_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbProxyEntity_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbProxyEntity_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbProxyEntity_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbProxyEntity_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbProxyEntity_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbProxyEntity_25();

	public delegate IntPtr SwigDelegateOdDbProxyEntity_26([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbProxyEntity_27(IntPtr pRb);

	public delegate void SwigDelegateOdDbProxyEntity_28(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbProxyEntity_29(IntPtr objId);

	public delegate void SwigDelegateOdDbProxyEntity_30(IntPtr objId);

	public delegate void SwigDelegateOdDbProxyEntity_31(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbProxyEntity_32();

	public delegate void SwigDelegateOdDbProxyEntity_33(IntPtr idPair, IntPtr pOwnerObject, IntPtr ownerIdMap);

	public delegate void SwigDelegateOdDbProxyEntity_34(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbProxyEntity_35(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbProxyEntity_36(IntPtr pObject);

	public delegate void SwigDelegateOdDbProxyEntity_37(IntPtr pObject);

	public delegate void SwigDelegateOdDbProxyEntity_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbProxyEntity_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbProxyEntity_40(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbProxyEntity_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbProxyEntity_42(IntPtr pObject);

	public delegate void SwigDelegateOdDbProxyEntity_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbProxyEntity_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbProxyEntity_45(IntPtr objectId);

	public delegate void SwigDelegateOdDbProxyEntity_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbProxyEntity_47(IntPtr pSource);

	public delegate int SwigDelegateOdDbProxyEntity_48(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbProxyEntity_49(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbProxyEntity_50(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbProxyEntity_51(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbProxyEntity_52(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbProxyEntity_53();

	public delegate IntPtr SwigDelegateOdDbProxyEntity_54([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbProxyEntity_55(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbProxyEntity_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbProxyEntity_57(IntPtr pClass);

	public delegate int SwigDelegateOdDbProxyEntity_58(IntPtr color, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_59(IntPtr color);

	public delegate IntPtr SwigDelegateOdDbProxyEntity_60();

	public delegate int SwigDelegateOdDbProxyEntity_61(ushort colorIndex, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_62(ushort colorIndex);

	public delegate int SwigDelegateOdDbProxyEntity_63(IntPtr colorId, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_64(IntPtr colorId);

	public delegate int SwigDelegateOdDbProxyEntity_65(IntPtr transparency, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_66(IntPtr transparency);

	public delegate int SwigDelegateOdDbProxyEntity_67([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_68([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName);

	public delegate int SwigDelegateOdDbProxyEntity_69(int plotStyleNameType, IntPtr newId, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_70(int plotStyleNameType, IntPtr newId);

	public delegate int SwigDelegateOdDbProxyEntity_71(int plotStyleNameType);

	public delegate int SwigDelegateOdDbProxyEntity_72([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbProxyEntity_73([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_74([MarshalAs(UnmanagedType.LPWStr)] string layerName);

	public delegate int SwigDelegateOdDbProxyEntity_75(IntPtr layerId, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbProxyEntity_76(IntPtr layerId, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_77(IntPtr layerId);

	public delegate int SwigDelegateOdDbProxyEntity_78([MarshalAs(UnmanagedType.LPWStr)] string linetypeName, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_79([MarshalAs(UnmanagedType.LPWStr)] string linetypeName);

	public delegate int SwigDelegateOdDbProxyEntity_80(IntPtr linetypeID, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_81(IntPtr linetypeID);

	public delegate int SwigDelegateOdDbProxyEntity_82([MarshalAs(UnmanagedType.LPWStr)] string materialName, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_83([MarshalAs(UnmanagedType.LPWStr)] string materialName);

	public delegate int SwigDelegateOdDbProxyEntity_84(IntPtr materialID, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_85(IntPtr materialID);

	public delegate int SwigDelegateOdDbProxyEntity_86(IntPtr visualStyleId, int vstype, bool doSubents);

	public delegate IntPtr SwigDelegateOdDbProxyEntity_87();

	public delegate void SwigDelegateOdDbProxyEntity_88(IntPtr mapper, bool doSubents);

	public delegate void SwigDelegateOdDbProxyEntity_89(IntPtr mapper);

	public delegate int SwigDelegateOdDbProxyEntity_90(double linetypeScale, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_91(double linetypeScale);

	public delegate int SwigDelegateOdDbProxyEntity_92(int lineWeight, bool doSubents);

	public delegate int SwigDelegateOdDbProxyEntity_93(int lineWeight);

	public delegate bool SwigDelegateOdDbProxyEntity_94();

	public delegate void SwigDelegateOdDbProxyEntity_95(bool castShadows);

	public delegate bool SwigDelegateOdDbProxyEntity_96();

	public delegate void SwigDelegateOdDbProxyEntity_97(bool receiveShadows);

	public delegate int SwigDelegateOdDbProxyEntity_98();

	public delegate bool SwigDelegateOdDbProxyEntity_99();

	public delegate int SwigDelegateOdDbProxyEntity_100(IntPtr plane, OdDb_Planarity planarity);

	public delegate int SwigDelegateOdDbProxyEntity_101(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbProxyEntity_102(IntPtr pBlockRecord);

	public delegate int SwigDelegateOdDbProxyEntity_103(IntPtr entitySet);

	public delegate int SwigDelegateOdDbProxyEntity_104(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbProxyEntity_105(IntPtr pBlockRecord);

	public delegate void SwigDelegateOdDbProxyEntity_106(IntPtr pDb, bool doSubents);

	public delegate void SwigDelegateOdDbProxyEntity_107();

	public delegate void SwigDelegateOdDbProxyEntity_108(int status);

	public delegate void SwigDelegateOdDbProxyEntity_109(IntPtr pWd, int ver);

	public delegate IntPtr SwigDelegateOdDbProxyEntity_110();

	public delegate int SwigDelegateOdDbProxyEntity_111(IntPtr xfm, IntPtr pCopy);

	public delegate int SwigDelegateOdDbProxyEntity_112(IntPtr xM);

	public delegate bool SwigDelegateOdDbProxyEntity_113();

	public delegate bool SwigDelegateOdDbProxyEntity_114();

	public delegate void SwigDelegateOdDbProxyEntity_115(int status);

	public delegate int SwigDelegateOdDbProxyEntity_116(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints);

	public delegate int SwigDelegateOdDbProxyEntity_117(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insertionMat);

	public delegate bool SwigDelegateOdDbProxyEntity_118();

	public delegate int SwigDelegateOdDbProxyEntity_119(IntPtr gripPoints);

	public delegate int SwigDelegateOdDbProxyEntity_120(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbProxyEntity_121(IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags);

	public delegate int SwigDelegateOdDbProxyEntity_122(IntPtr grips, IntPtr offset, int bitFlags);

	public delegate int SwigDelegateOdDbProxyEntity_123(IntPtr stretchPoints);

	public delegate int SwigDelegateOdDbProxyEntity_124(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbProxyEntity_125(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbProxyEntity_126(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbProxyEntity_127(IntPtr pEnt, int intType, IntPtr points);

	public delegate int SwigDelegateOdDbProxyEntity_128(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbProxyEntity_129(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbProxyEntity_130(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points);

	public delegate void SwigDelegateOdDbProxyEntity_131(bool bDoIt, IntPtr pSubId, bool highlightAll);

	public delegate void SwigDelegateOdDbProxyEntity_132(bool bDoIt, IntPtr pSubId);

	public delegate void SwigDelegateOdDbProxyEntity_133(bool bDoIt);

	public delegate void SwigDelegateOdDbProxyEntity_134();

	public delegate int SwigDelegateOdDbProxyEntity_135();

	public delegate int SwigDelegateOdDbProxyEntity_136(int visibility);

	public delegate int SwigDelegateOdDbProxyEntity_137(IntPtr extents);

	public delegate int SwigDelegateOdDbProxyEntity_138(IntPtr paths);

	public delegate int SwigDelegateOdDbProxyEntity_139(IntPtr paths);

	public delegate int SwigDelegateOdDbProxyEntity_140(IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags);

	public delegate int SwigDelegateOdDbProxyEntity_141(IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags);

	public delegate int SwigDelegateOdDbProxyEntity_142(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths, IntPtr pEntAndInsertStack);

	public delegate int SwigDelegateOdDbProxyEntity_143(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths);

	public delegate int SwigDelegateOdDbProxyEntity_144(IntPtr subPath, IntPtr gsMarkers);

	public delegate IntPtr SwigDelegateOdDbProxyEntity_145(IntPtr path);

	public delegate int SwigDelegateOdDbProxyEntity_146(IntPtr paths, IntPtr xform);

	public delegate int SwigDelegateOdDbProxyEntity_147(IntPtr path, IntPtr clsId);

	public delegate int SwigDelegateOdDbProxyEntity_148(IntPtr path, IntPtr extents);

	public delegate void SwigDelegateOdDbProxyEntity_149(int status, IntPtr subentity);

	public delegate int SwigDelegateOdDbProxyEntity_150();

	public delegate int SwigDelegateOdDbProxyEntity_151();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbProxyEntity_152();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbProxyEntity_153();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbProxyEntity_154();

	public delegate void SwigDelegateOdDbProxyEntity_155(IntPtr objectIds);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbProxyEntity_0 swigDelegate0;

	private SwigDelegateOdDbProxyEntity_1 swigDelegate1;

	private SwigDelegateOdDbProxyEntity_2 swigDelegate2;

	private SwigDelegateOdDbProxyEntity_3 swigDelegate3;

	private SwigDelegateOdDbProxyEntity_4 swigDelegate4;

	private SwigDelegateOdDbProxyEntity_5 swigDelegate5;

	private SwigDelegateOdDbProxyEntity_6 swigDelegate6;

	private SwigDelegateOdDbProxyEntity_7 swigDelegate7;

	private SwigDelegateOdDbProxyEntity_8 swigDelegate8;

	private SwigDelegateOdDbProxyEntity_9 swigDelegate9;

	private SwigDelegateOdDbProxyEntity_10 swigDelegate10;

	private SwigDelegateOdDbProxyEntity_11 swigDelegate11;

	private SwigDelegateOdDbProxyEntity_12 swigDelegate12;

	private SwigDelegateOdDbProxyEntity_13 swigDelegate13;

	private SwigDelegateOdDbProxyEntity_14 swigDelegate14;

	private SwigDelegateOdDbProxyEntity_15 swigDelegate15;

	private SwigDelegateOdDbProxyEntity_16 swigDelegate16;

	private SwigDelegateOdDbProxyEntity_17 swigDelegate17;

	private SwigDelegateOdDbProxyEntity_18 swigDelegate18;

	private SwigDelegateOdDbProxyEntity_19 swigDelegate19;

	private SwigDelegateOdDbProxyEntity_20 swigDelegate20;

	private SwigDelegateOdDbProxyEntity_21 swigDelegate21;

	private SwigDelegateOdDbProxyEntity_22 swigDelegate22;

	private SwigDelegateOdDbProxyEntity_23 swigDelegate23;

	private SwigDelegateOdDbProxyEntity_24 swigDelegate24;

	private SwigDelegateOdDbProxyEntity_25 swigDelegate25;

	private SwigDelegateOdDbProxyEntity_26 swigDelegate26;

	private SwigDelegateOdDbProxyEntity_27 swigDelegate27;

	private SwigDelegateOdDbProxyEntity_28 swigDelegate28;

	private SwigDelegateOdDbProxyEntity_29 swigDelegate29;

	private SwigDelegateOdDbProxyEntity_30 swigDelegate30;

	private SwigDelegateOdDbProxyEntity_31 swigDelegate31;

	private SwigDelegateOdDbProxyEntity_32 swigDelegate32;

	private SwigDelegateOdDbProxyEntity_33 swigDelegate33;

	private SwigDelegateOdDbProxyEntity_34 swigDelegate34;

	private SwigDelegateOdDbProxyEntity_35 swigDelegate35;

	private SwigDelegateOdDbProxyEntity_36 swigDelegate36;

	private SwigDelegateOdDbProxyEntity_37 swigDelegate37;

	private SwigDelegateOdDbProxyEntity_38 swigDelegate38;

	private SwigDelegateOdDbProxyEntity_39 swigDelegate39;

	private SwigDelegateOdDbProxyEntity_40 swigDelegate40;

	private SwigDelegateOdDbProxyEntity_41 swigDelegate41;

	private SwigDelegateOdDbProxyEntity_42 swigDelegate42;

	private SwigDelegateOdDbProxyEntity_43 swigDelegate43;

	private SwigDelegateOdDbProxyEntity_44 swigDelegate44;

	private SwigDelegateOdDbProxyEntity_45 swigDelegate45;

	private SwigDelegateOdDbProxyEntity_46 swigDelegate46;

	private SwigDelegateOdDbProxyEntity_47 swigDelegate47;

	private SwigDelegateOdDbProxyEntity_48 swigDelegate48;

	private SwigDelegateOdDbProxyEntity_49 swigDelegate49;

	private SwigDelegateOdDbProxyEntity_50 swigDelegate50;

	private SwigDelegateOdDbProxyEntity_51 swigDelegate51;

	private SwigDelegateOdDbProxyEntity_52 swigDelegate52;

	private SwigDelegateOdDbProxyEntity_53 swigDelegate53;

	private SwigDelegateOdDbProxyEntity_54 swigDelegate54;

	private SwigDelegateOdDbProxyEntity_55 swigDelegate55;

	private SwigDelegateOdDbProxyEntity_56 swigDelegate56;

	private SwigDelegateOdDbProxyEntity_57 swigDelegate57;

	private SwigDelegateOdDbProxyEntity_58 swigDelegate58;

	private SwigDelegateOdDbProxyEntity_59 swigDelegate59;

	private SwigDelegateOdDbProxyEntity_60 swigDelegate60;

	private SwigDelegateOdDbProxyEntity_61 swigDelegate61;

	private SwigDelegateOdDbProxyEntity_62 swigDelegate62;

	private SwigDelegateOdDbProxyEntity_63 swigDelegate63;

	private SwigDelegateOdDbProxyEntity_64 swigDelegate64;

	private SwigDelegateOdDbProxyEntity_65 swigDelegate65;

	private SwigDelegateOdDbProxyEntity_66 swigDelegate66;

	private SwigDelegateOdDbProxyEntity_67 swigDelegate67;

	private SwigDelegateOdDbProxyEntity_68 swigDelegate68;

	private SwigDelegateOdDbProxyEntity_69 swigDelegate69;

	private SwigDelegateOdDbProxyEntity_70 swigDelegate70;

	private SwigDelegateOdDbProxyEntity_71 swigDelegate71;

	private SwigDelegateOdDbProxyEntity_72 swigDelegate72;

	private SwigDelegateOdDbProxyEntity_73 swigDelegate73;

	private SwigDelegateOdDbProxyEntity_74 swigDelegate74;

	private SwigDelegateOdDbProxyEntity_75 swigDelegate75;

	private SwigDelegateOdDbProxyEntity_76 swigDelegate76;

	private SwigDelegateOdDbProxyEntity_77 swigDelegate77;

	private SwigDelegateOdDbProxyEntity_78 swigDelegate78;

	private SwigDelegateOdDbProxyEntity_79 swigDelegate79;

	private SwigDelegateOdDbProxyEntity_80 swigDelegate80;

	private SwigDelegateOdDbProxyEntity_81 swigDelegate81;

	private SwigDelegateOdDbProxyEntity_82 swigDelegate82;

	private SwigDelegateOdDbProxyEntity_83 swigDelegate83;

	private SwigDelegateOdDbProxyEntity_84 swigDelegate84;

	private SwigDelegateOdDbProxyEntity_85 swigDelegate85;

	private SwigDelegateOdDbProxyEntity_86 swigDelegate86;

	private SwigDelegateOdDbProxyEntity_87 swigDelegate87;

	private SwigDelegateOdDbProxyEntity_88 swigDelegate88;

	private SwigDelegateOdDbProxyEntity_89 swigDelegate89;

	private SwigDelegateOdDbProxyEntity_90 swigDelegate90;

	private SwigDelegateOdDbProxyEntity_91 swigDelegate91;

	private SwigDelegateOdDbProxyEntity_92 swigDelegate92;

	private SwigDelegateOdDbProxyEntity_93 swigDelegate93;

	private SwigDelegateOdDbProxyEntity_94 swigDelegate94;

	private SwigDelegateOdDbProxyEntity_95 swigDelegate95;

	private SwigDelegateOdDbProxyEntity_96 swigDelegate96;

	private SwigDelegateOdDbProxyEntity_97 swigDelegate97;

	private SwigDelegateOdDbProxyEntity_98 swigDelegate98;

	private SwigDelegateOdDbProxyEntity_99 swigDelegate99;

	private SwigDelegateOdDbProxyEntity_100 swigDelegate100;

	private SwigDelegateOdDbProxyEntity_101 swigDelegate101;

	private SwigDelegateOdDbProxyEntity_102 swigDelegate102;

	private SwigDelegateOdDbProxyEntity_103 swigDelegate103;

	private SwigDelegateOdDbProxyEntity_104 swigDelegate104;

	private SwigDelegateOdDbProxyEntity_105 swigDelegate105;

	private SwigDelegateOdDbProxyEntity_106 swigDelegate106;

	private SwigDelegateOdDbProxyEntity_107 swigDelegate107;

	private SwigDelegateOdDbProxyEntity_108 swigDelegate108;

	private SwigDelegateOdDbProxyEntity_109 swigDelegate109;

	private SwigDelegateOdDbProxyEntity_110 swigDelegate110;

	private SwigDelegateOdDbProxyEntity_111 swigDelegate111;

	private SwigDelegateOdDbProxyEntity_112 swigDelegate112;

	private SwigDelegateOdDbProxyEntity_113 swigDelegate113;

	private SwigDelegateOdDbProxyEntity_114 swigDelegate114;

	private SwigDelegateOdDbProxyEntity_115 swigDelegate115;

	private SwigDelegateOdDbProxyEntity_116 swigDelegate116;

	private SwigDelegateOdDbProxyEntity_117 swigDelegate117;

	private SwigDelegateOdDbProxyEntity_118 swigDelegate118;

	private SwigDelegateOdDbProxyEntity_119 swigDelegate119;

	private SwigDelegateOdDbProxyEntity_120 swigDelegate120;

	private SwigDelegateOdDbProxyEntity_121 swigDelegate121;

	private SwigDelegateOdDbProxyEntity_122 swigDelegate122;

	private SwigDelegateOdDbProxyEntity_123 swigDelegate123;

	private SwigDelegateOdDbProxyEntity_124 swigDelegate124;

	private SwigDelegateOdDbProxyEntity_125 swigDelegate125;

	private SwigDelegateOdDbProxyEntity_126 swigDelegate126;

	private SwigDelegateOdDbProxyEntity_127 swigDelegate127;

	private SwigDelegateOdDbProxyEntity_128 swigDelegate128;

	private SwigDelegateOdDbProxyEntity_129 swigDelegate129;

	private SwigDelegateOdDbProxyEntity_130 swigDelegate130;

	private SwigDelegateOdDbProxyEntity_131 swigDelegate131;

	private SwigDelegateOdDbProxyEntity_132 swigDelegate132;

	private SwigDelegateOdDbProxyEntity_133 swigDelegate133;

	private SwigDelegateOdDbProxyEntity_134 swigDelegate134;

	private SwigDelegateOdDbProxyEntity_135 swigDelegate135;

	private SwigDelegateOdDbProxyEntity_136 swigDelegate136;

	private SwigDelegateOdDbProxyEntity_137 swigDelegate137;

	private SwigDelegateOdDbProxyEntity_138 swigDelegate138;

	private SwigDelegateOdDbProxyEntity_139 swigDelegate139;

	private SwigDelegateOdDbProxyEntity_140 swigDelegate140;

	private SwigDelegateOdDbProxyEntity_141 swigDelegate141;

	private SwigDelegateOdDbProxyEntity_142 swigDelegate142;

	private SwigDelegateOdDbProxyEntity_143 swigDelegate143;

	private SwigDelegateOdDbProxyEntity_144 swigDelegate144;

	private SwigDelegateOdDbProxyEntity_145 swigDelegate145;

	private SwigDelegateOdDbProxyEntity_146 swigDelegate146;

	private SwigDelegateOdDbProxyEntity_147 swigDelegate147;

	private SwigDelegateOdDbProxyEntity_148 swigDelegate148;

	private SwigDelegateOdDbProxyEntity_149 swigDelegate149;

	private SwigDelegateOdDbProxyEntity_150 swigDelegate150;

	private SwigDelegateOdDbProxyEntity_151 swigDelegate151;

	private SwigDelegateOdDbProxyEntity_152 swigDelegate152;

	private SwigDelegateOdDbProxyEntity_153 swigDelegate153;

	private SwigDelegateOdDbProxyEntity_154 swigDelegate154;

	private SwigDelegateOdDbProxyEntity_155 swigDelegate155;

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

	private static Type[] swigMethodTypes111 = new Type[2]
	{
		typeof(OdGeMatrix3d),
		typeof(OdDbEntity).MakeByRefType()
	};

	private static Type[] swigMethodTypes112 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes113 = new Type[0];

	private static Type[] swigMethodTypes114 = new Type[0];

	private static Type[] swigMethodTypes115 = new Type[1] { typeof(OdDb_GripStat) };

	private static Type[] swigMethodTypes116 = new Type[6]
	{
		typeof(OsnapMode),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes117 = new Type[7]
	{
		typeof(OsnapMode),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3dArray),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes118 = new Type[0];

	private static Type[] swigMethodTypes119 = new Type[1] { typeof(OdGePoint3dArray) };

	private static Type[] swigMethodTypes120 = new Type[2]
	{
		typeof(OdIntArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes121 = new Type[5]
	{
		typeof(OdDbGripDataPtrArray),
		typeof(double),
		typeof(int),
		typeof(OdGeVector3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes122 = new Type[3]
	{
		typeof(OdDbVoidPtrArray),
		typeof(OdGeVector3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes123 = new Type[1] { typeof(OdGePoint3dArray) };

	private static Type[] swigMethodTypes124 = new Type[2]
	{
		typeof(OdIntArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes125 = new Type[5]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes126 = new Type[4]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes127 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes128 = new Type[6]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes129 = new Type[5]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes130 = new Type[4]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes131 = new Type[3]
	{
		typeof(bool),
		typeof(OdDbFullSubentPath),
		typeof(bool)
	};

	private static Type[] swigMethodTypes132 = new Type[2]
	{
		typeof(bool),
		typeof(OdDbFullSubentPath)
	};

	private static Type[] swigMethodTypes133 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes134 = new Type[0];

	private static Type[] swigMethodTypes135 = new Type[0];

	private static Type[] swigMethodTypes136 = new Type[1] { typeof(OdDb_Visibility) };

	private static Type[] swigMethodTypes137 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes138 = new Type[1] { typeof(OdDbFullSubentPathArray) };

	private static Type[] swigMethodTypes139 = new Type[1] { typeof(OdDbFullSubentPathArray) };

	private static Type[] swigMethodTypes140 = new Type[4]
	{
		typeof(OdDbFullSubentPathArray),
		typeof(OdDbVoidPtrArray),
		typeof(OdGeVector3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes141 = new Type[6]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdDbGripDataPtrArray),
		typeof(double),
		typeof(int),
		typeof(OdGeVector3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes142 = new Type[6]
	{
		typeof(OdDb_SubentType),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdDbFullSubentPathArray),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes143 = new Type[5]
	{
		typeof(OdDb_SubentType),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdDbFullSubentPathArray)
	};

	private static Type[] swigMethodTypes144 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdGsMarkerArray)
	};

	private static Type[] swigMethodTypes145 = new Type[1] { typeof(OdDbFullSubentPath) };

	private static Type[] swigMethodTypes146 = new Type[2]
	{
		typeof(OdDbFullSubentPathArray),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes147 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes148 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdGeExtents3d)
	};

	private static Type[] swigMethodTypes149 = new Type[2]
	{
		typeof(OdDb_GripStat),
		typeof(OdDbFullSubentPath)
	};

	private static Type[] swigMethodTypes150 = new Type[0];

	private static Type[] swigMethodTypes151 = new Type[0];

	private static Type[] swigMethodTypes152 = new Type[0];

	private static Type[] swigMethodTypes153 = new Type[0];

	private static Type[] swigMethodTypes154 = new Type[0];

	private static Type[] swigMethodTypes155 = new Type[1] { typeof(OdTypedIdsArray) };

	public const int kNoOperation = 0;

	public const int kEraseAllowed = 1;

	public const int kTransformAllowed = 2;

	public const int kColorChangeAllowed = 4;

	public const int kLayerChangeAllowed = 8;

	public const int kLinetypeChangeAllowed = 16;

	public const int kLinetypeScaleChangeAllowed = 32;

	public const int kVisibilityChangeAllowed = 64;

	public const int kCloningAllowed = 128;

	public const int kLineWeightChangeAllowed = 256;

	public const int kPlotStyleNameChangeAllowed = 512;

	public const int kDisableProxyWarning = 1024;

	public const int kMaterialChangeAllowed = 2048;

	public const int kAllButCloningAllowed = 2943;

	public const int kAllAllowedBits = 3071;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbProxyEntity(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbProxyEntity obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbProxyEntity(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbProxyEntity cast(OdRxObject pObj)
	{
		OdDbProxyEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbProxyEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_isASwigExplicitOdDbProxyEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_queryXSwigExplicitOdDbProxyEntity(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbProxyEntity_GraphicsMetafileType graphicsMetafileType()
	{
		int result = (SwigDerivedClassHasMethod("graphicsMetafileType", swigMethodTypes150) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_graphicsMetafileTypeSwigExplicitOdDbProxyEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_graphicsMetafileType(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbProxyEntity_GraphicsMetafileType)result;
	}

	public virtual int proxyFlags()
	{
		int result = (SwigDerivedClassHasMethod("proxyFlags", swigMethodTypes151) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_proxyFlagsSwigExplicitOdDbProxyEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_proxyFlags(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool eraseAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_eraseAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool transformAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_transformAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool colorChangeAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_colorChangeAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool layerChangeAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_layerChangeAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool linetypeChangeAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_linetypeChangeAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool linetypeScaleChangeAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_linetypeScaleChangeAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool visibilityChangeAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_visibilityChangeAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool lineWeightChangeAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_lineWeightChangeAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool plotStyleNameChangeAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_plotStyleNameChangeAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool materialChangeAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_materialChangeAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool cloningAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_cloningAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool allButCloningAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_allButCloningAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool allOperationsAllowed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_allOperationsAllowed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isR13FormatProxy()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_isR13FormatProxy(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string originalClassName()
	{
		string result = (SwigDerivedClassHasMethod("originalClassName", swigMethodTypes152) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_originalClassNameSwigExplicitOdDbProxyEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_originalClassName(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string originalDxfName()
	{
		string result = (SwigDerivedClassHasMethod("originalDxfName", swigMethodTypes153) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_originalDxfNameSwigExplicitOdDbProxyEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_originalDxfName(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string applicationDescription()
	{
		string result = (SwigDerivedClassHasMethod("applicationDescription", swigMethodTypes154) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_applicationDescriptionSwigExplicitOdDbProxyEntity(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_applicationDescription(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getReferences(OdTypedIdsArray objectIds)
	{
		if (SwigDerivedClassHasMethod("getReferences", swigMethodTypes155))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_getReferencesSwigExplicitOdDbProxyEntity(swigCPtr, OdTypedIdsArray.getCPtr(objectIds));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_getReferences(swigCPtr, OdTypedIdsArray.getCPtr(objectIds));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_dwgInFieldsSwigExplicitOdDbProxyEntity(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_dwgOutFieldsSwigExplicitOdDbProxyEntity(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_dxfInFieldsSwigExplicitOdDbProxyEntity(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_dxfOutFieldsSwigExplicitOdDbProxyEntity(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfIn(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfIn", swigMethodTypes17) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_dxfInSwigExplicitOdDbProxyEntity(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_dxfIn(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setColor(OdCmColor color, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setColor", swigMethodTypes58) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setColorSwigExplicitOdDbProxyEntity__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setColor__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setColor(OdCmColor color)
	{
		int result = (SwigDerivedClassHasMethod("setColor", swigMethodTypes59) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setColorSwigExplicitOdDbProxyEntity__SWIG_1(swigCPtr, OdCmColor.getCPtr(color)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setColor__SWIG_1(swigCPtr, OdCmColor.getCPtr(color)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setColorIndex(ushort colorIndex, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setColorIndex", swigMethodTypes61) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setColorIndexSwigExplicitOdDbProxyEntity__SWIG_0(swigCPtr, colorIndex, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setColorIndex__SWIG_0(swigCPtr, colorIndex, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setColorIndex(ushort colorIndex)
	{
		int result = (SwigDerivedClassHasMethod("setColorIndex", swigMethodTypes62) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setColorIndexSwigExplicitOdDbProxyEntity__SWIG_1(swigCPtr, colorIndex) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setColorIndex__SWIG_1(swigCPtr, colorIndex));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setColorId(OdDbObjectId colorId, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setColorId", swigMethodTypes63) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setColorIdSwigExplicitOdDbProxyEntity__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(colorId), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setColorId__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(colorId), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setColorId(OdDbObjectId colorId)
	{
		int result = (SwigDerivedClassHasMethod("setColorId", swigMethodTypes64) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setColorIdSwigExplicitOdDbProxyEntity__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(colorId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setColorId__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(colorId)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setPlotStyleName(string plotStyleName, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes67) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setPlotStyleNameSwigExplicitOdDbProxyEntity__SWIG_0(swigCPtr, plotStyleName, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setPlotStyleName__SWIG_0(swigCPtr, plotStyleName, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setPlotStyleName(string plotStyleName)
	{
		int result = (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes68) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setPlotStyleNameSwigExplicitOdDbProxyEntity__SWIG_1(swigCPtr, plotStyleName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setPlotStyleName__SWIG_1(swigCPtr, plotStyleName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setPlotStyleName(PlotStyleNameType plotStyleNameType, OdDbObjectId newId, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes69) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setPlotStyleNameSwigExplicitOdDbProxyEntity__SWIG_2(swigCPtr, (int)plotStyleNameType, OdDbObjectId.getCPtr(newId), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setPlotStyleName__SWIG_2(swigCPtr, (int)plotStyleNameType, OdDbObjectId.getCPtr(newId), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setPlotStyleName(PlotStyleNameType plotStyleNameType, OdDbObjectId newId)
	{
		int result = (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes70) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setPlotStyleNameSwigExplicitOdDbProxyEntity__SWIG_3(swigCPtr, (int)plotStyleNameType, OdDbObjectId.getCPtr(newId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setPlotStyleName__SWIG_3(swigCPtr, (int)plotStyleNameType, OdDbObjectId.getCPtr(newId)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setPlotStyleName(PlotStyleNameType plotStyleNameType)
	{
		int result = (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes71) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setPlotStyleNameSwigExplicitOdDbProxyEntity__SWIG_4(swigCPtr, (int)plotStyleNameType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setPlotStyleName__SWIG_4(swigCPtr, (int)plotStyleNameType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLayer(string layerName, bool doSubents, bool allowHiddenLayer)
	{
		int result = (SwigDerivedClassHasMethod("setLayer", swigMethodTypes72) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLayerSwigExplicitOdDbProxyEntity__SWIG_0(swigCPtr, layerName, doSubents, allowHiddenLayer) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLayer__SWIG_0(swigCPtr, layerName, doSubents, allowHiddenLayer));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLayer(string layerName, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setLayer", swigMethodTypes73) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLayerSwigExplicitOdDbProxyEntity__SWIG_1(swigCPtr, layerName, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLayer__SWIG_1(swigCPtr, layerName, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLayer(string layerName)
	{
		int result = (SwigDerivedClassHasMethod("setLayer", swigMethodTypes74) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLayerSwigExplicitOdDbProxyEntity__SWIG_2(swigCPtr, layerName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLayer__SWIG_2(swigCPtr, layerName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLayer(OdDbObjectId layerId, bool doSubents, bool allowHiddenLayer)
	{
		int result = (SwigDerivedClassHasMethod("setLayer", swigMethodTypes75) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLayerSwigExplicitOdDbProxyEntity__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(layerId), doSubents, allowHiddenLayer) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLayer__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(layerId), doSubents, allowHiddenLayer));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLayer(OdDbObjectId layerId, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setLayer", swigMethodTypes76) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLayerSwigExplicitOdDbProxyEntity__SWIG_4(swigCPtr, OdDbObjectId.getCPtr(layerId), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLayer__SWIG_4(swigCPtr, OdDbObjectId.getCPtr(layerId), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLayer(OdDbObjectId layerId)
	{
		int result = (SwigDerivedClassHasMethod("setLayer", swigMethodTypes77) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLayerSwigExplicitOdDbProxyEntity__SWIG_5(swigCPtr, OdDbObjectId.getCPtr(layerId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLayer__SWIG_5(swigCPtr, OdDbObjectId.getCPtr(layerId)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLinetype(string linetypeName, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes78) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLinetypeSwigExplicitOdDbProxyEntity__SWIG_0(swigCPtr, linetypeName, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLinetype__SWIG_0(swigCPtr, linetypeName, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLinetype(string linetypeName)
	{
		int result = (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes79) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLinetypeSwigExplicitOdDbProxyEntity__SWIG_1(swigCPtr, linetypeName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLinetype__SWIG_1(swigCPtr, linetypeName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLinetype(OdDbObjectId linetypeID, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes80) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLinetypeSwigExplicitOdDbProxyEntity__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(linetypeID), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLinetype__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(linetypeID), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLinetype(OdDbObjectId linetypeID)
	{
		int result = (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes81) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLinetypeSwigExplicitOdDbProxyEntity__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(linetypeID)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLinetype__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(linetypeID)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLinetypeScale(double linetypeScale, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setLinetypeScale", swigMethodTypes90) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLinetypeScaleSwigExplicitOdDbProxyEntity__SWIG_0(swigCPtr, linetypeScale, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLinetypeScale__SWIG_0(swigCPtr, linetypeScale, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLinetypeScale(double linetypeScale)
	{
		int result = (SwigDerivedClassHasMethod("setLinetypeScale", swigMethodTypes91) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLinetypeScaleSwigExplicitOdDbProxyEntity__SWIG_1(swigCPtr, linetypeScale) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLinetypeScale__SWIG_1(swigCPtr, linetypeScale));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public new virtual OdResult subSetVisibility(OdDb_Visibility visibility)
	{
		int result = (SwigDerivedClassHasMethod("subSetVisibility", swigMethodTypes136) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_subSetVisibilitySwigExplicitOdDbProxyEntity(swigCPtr, (int)visibility) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_subSetVisibility(swigCPtr, (int)visibility));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLineWeight(LineWeight lineWeight, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setLineWeight", swigMethodTypes92) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLineWeightSwigExplicitOdDbProxyEntity__SWIG_0(swigCPtr, (int)lineWeight, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLineWeight__SWIG_0(swigCPtr, (int)lineWeight, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setLineWeight(LineWeight lineWeight)
	{
		int result = (SwigDerivedClassHasMethod("setLineWeight", swigMethodTypes93) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLineWeightSwigExplicitOdDbProxyEntity__SWIG_1(swigCPtr, (int)lineWeight) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setLineWeight__SWIG_1(swigCPtr, (int)lineWeight));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setMaterial(string materialName, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes82) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setMaterialSwigExplicitOdDbProxyEntity__SWIG_0(swigCPtr, materialName, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setMaterial__SWIG_0(swigCPtr, materialName, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setMaterial(string materialName)
	{
		int result = (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes83) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setMaterialSwigExplicitOdDbProxyEntity__SWIG_1(swigCPtr, materialName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setMaterial__SWIG_1(swigCPtr, materialName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setMaterial(OdDbObjectId materialID, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes84) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setMaterialSwigExplicitOdDbProxyEntity__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(materialID), doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setMaterial__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(materialID), doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setMaterial(OdDbObjectId materialID)
	{
		int result = (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes85) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setMaterialSwigExplicitOdDbProxyEntity__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(materialID)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_setMaterial__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(materialID)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult subErase(bool erasing)
	{
		int result = (SwigDerivedClassHasMethod("subErase", swigMethodTypes11) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_subEraseSwigExplicitOdDbProxyEntity(swigCPtr, erasing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_subErase(swigCPtr, erasing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbObject SubDeepClone(ref OdDbIdMapping ownerIdMap, OdDbObject arg0, bool bPrimary)
	{
		IntPtr jarg = ((ownerIdMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(ownerIdMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_SubDeepClone(swigCPtr, ref jarg, OdDbObject.getCPtr(arg0), bPrimary), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
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

	public virtual OdDbObject SubWblockClone(ref OdDbIdMapping ownerIdMap, OdDbObject arg0, bool bPrimary)
	{
		IntPtr jarg = ((ownerIdMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(ownerIdMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_SubWblockClone(swigCPtr, ref jarg, OdDbObject.getCPtr(arg0), bPrimary), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
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

	public virtual OdResult SubExplode(OdRxObjectPtrArray entitySet)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_SubExplode(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubTransformBy(OdGeMatrix3d xfm)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_SubTransformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubSetVisibility(OdDb_Visibility visibility, bool doSubents)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_SubSetVisibility(swigCPtr, (int)visibility, doSubents);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbProxyEntity createObject()
	{
		OdDbProxyEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbProxyEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("subGetTransformedCopy", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodsubGetTransformedCopy;
		}
		if (SwigDerivedClassHasMethod("subGetCompoundObjectTransform", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodsubGetCompoundObjectTransform;
		}
		if (SwigDerivedClassHasMethod("subCloneMeForDragging", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethodsubCloneMeForDragging;
		}
		if (SwigDerivedClassHasMethod("subHideMeForDragging", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodsubHideMeForDragging;
		}
		if (SwigDerivedClassHasMethod("subGripStatus", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethodsubGripStatus;
		}
		if (SwigDerivedClassHasMethod("subGetOsnapPoints", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethodsubGetOsnapPoints__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subGetOsnapPoints", swigMethodTypes117))
		{
			swigDelegate117 = SwigDirectorMethodsubGetOsnapPoints__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subIsContentSnappable", swigMethodTypes118))
		{
			swigDelegate118 = SwigDirectorMethodsubIsContentSnappable;
		}
		if (SwigDerivedClassHasMethod("subGetGripPoints", swigMethodTypes119))
		{
			swigDelegate119 = SwigDirectorMethodsubGetGripPoints__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subMoveGripPointsAt", swigMethodTypes120))
		{
			swigDelegate120 = SwigDirectorMethodsubMoveGripPointsAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subGetGripPoints", swigMethodTypes121))
		{
			swigDelegate121 = SwigDirectorMethodsubGetGripPoints__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subMoveGripPointsAt", swigMethodTypes122))
		{
			swigDelegate122 = SwigDirectorMethodsubMoveGripPointsAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subGetStretchPoints", swigMethodTypes123))
		{
			swigDelegate123 = SwigDirectorMethodsubGetStretchPoints;
		}
		if (SwigDerivedClassHasMethod("subMoveStretchPointsAt", swigMethodTypes124))
		{
			swigDelegate124 = SwigDirectorMethodsubMoveStretchPointsAt;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes125))
		{
			swigDelegate125 = SwigDirectorMethodsubIntersectWith__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes126))
		{
			swigDelegate126 = SwigDirectorMethodsubIntersectWith__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes127))
		{
			swigDelegate127 = SwigDirectorMethodsubIntersectWith__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes128))
		{
			swigDelegate128 = SwigDirectorMethodsubIntersectWith__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes129))
		{
			swigDelegate129 = SwigDirectorMethodsubIntersectWith__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes130))
		{
			swigDelegate130 = SwigDirectorMethodsubIntersectWith__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes131))
		{
			swigDelegate131 = SwigDirectorMethodsubHighlight__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes132))
		{
			swigDelegate132 = SwigDirectorMethodsubHighlight__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes133))
		{
			swigDelegate133 = SwigDirectorMethodsubHighlight__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes134))
		{
			swigDelegate134 = SwigDirectorMethodsubHighlight__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("subVisibility", swigMethodTypes135))
		{
			swigDelegate135 = SwigDirectorMethodsubVisibility;
		}
		if (SwigDerivedClassHasMethod("subSetVisibility", swigMethodTypes136))
		{
			swigDelegate136 = SwigDirectorMethodsubSetVisibility;
		}
		if (SwigDerivedClassHasMethod("subGetGeomExtents", swigMethodTypes137))
		{
			swigDelegate137 = SwigDirectorMethodsubGetGeomExtents;
		}
		if (SwigDerivedClassHasMethod("subDeleteSubentPaths", swigMethodTypes138))
		{
			swigDelegate138 = SwigDirectorMethodsubDeleteSubentPaths;
		}
		if (SwigDerivedClassHasMethod("subAddSubentPaths", swigMethodTypes139))
		{
			swigDelegate139 = SwigDirectorMethodsubAddSubentPaths;
		}
		if (SwigDerivedClassHasMethod("subMoveGripPointsAtSubentPaths", swigMethodTypes140))
		{
			swigDelegate140 = SwigDirectorMethodsubMoveGripPointsAtSubentPaths;
		}
		if (SwigDerivedClassHasMethod("subGetGripPointsAtSubentPath", swigMethodTypes141))
		{
			swigDelegate141 = SwigDirectorMethodsubGetGripPointsAtSubentPath;
		}
		if (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes142))
		{
			swigDelegate142 = SwigDirectorMethodsubGetSubentPathsAtGsMarker__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes143))
		{
			swigDelegate143 = SwigDirectorMethodsubGetSubentPathsAtGsMarker__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subGetGsMarkersAtSubentPath", swigMethodTypes144))
		{
			swigDelegate144 = SwigDirectorMethodsubGetGsMarkersAtSubentPath;
		}
		if (SwigDerivedClassHasMethod("subSubentPtr", swigMethodTypes145))
		{
			swigDelegate145 = SwigDirectorMethodsubSubentPtr;
		}
		if (SwigDerivedClassHasMethod("subTransformSubentPathsBy", swigMethodTypes146))
		{
			swigDelegate146 = SwigDirectorMethodsubTransformSubentPathsBy;
		}
		if (SwigDerivedClassHasMethod("subGetSubentClassId", swigMethodTypes147))
		{
			swigDelegate147 = SwigDirectorMethodsubGetSubentClassId;
		}
		if (SwigDerivedClassHasMethod("subGetSubentPathGeomExtents", swigMethodTypes148))
		{
			swigDelegate148 = SwigDirectorMethodsubGetSubentPathGeomExtents;
		}
		if (SwigDerivedClassHasMethod("subSubentGripStatus", swigMethodTypes149))
		{
			swigDelegate149 = SwigDirectorMethodsubSubentGripStatus;
		}
		if (SwigDerivedClassHasMethod("graphicsMetafileType", swigMethodTypes150))
		{
			swigDelegate150 = SwigDirectorMethodgraphicsMetafileType;
		}
		if (SwigDerivedClassHasMethod("proxyFlags", swigMethodTypes151))
		{
			swigDelegate151 = SwigDirectorMethodproxyFlags;
		}
		if (SwigDerivedClassHasMethod("originalClassName", swigMethodTypes152))
		{
			swigDelegate152 = SwigDirectorMethodoriginalClassName;
		}
		if (SwigDerivedClassHasMethod("originalDxfName", swigMethodTypes153))
		{
			swigDelegate153 = SwigDirectorMethodoriginalDxfName;
		}
		if (SwigDerivedClassHasMethod("applicationDescription", swigMethodTypes154))
		{
			swigDelegate154 = SwigDirectorMethodapplicationDescription;
		}
		if (SwigDerivedClassHasMethod("getReferences", swigMethodTypes155))
		{
			swigDelegate155 = SwigDirectorMethodgetReferences;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbProxyEntity_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125, swigDelegate126, swigDelegate127, swigDelegate128, swigDelegate129, swigDelegate130, swigDelegate131, swigDelegate132, swigDelegate133, swigDelegate134, swigDelegate135, swigDelegate136, swigDelegate137, swigDelegate138, swigDelegate139, swigDelegate140, swigDelegate141, swigDelegate142, swigDelegate143, swigDelegate144, swigDelegate145, swigDelegate146, swigDelegate147, swigDelegate148, swigDelegate149, swigDelegate150, swigDelegate151, swigDelegate152, swigDelegate153, swigDelegate154, swigDelegate155);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbProxyEntity));
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

	private int SwigDirectorMethodsetPlotStyleName__SWIG_2(int plotStyleNameType, IntPtr newId, bool doSubents)
	{
		return (int)setPlotStyleName((PlotStyleNameType)plotStyleNameType, new OdDbObjectId(newId, cMemoryOwn: true), doSubents);
	}

	private int SwigDirectorMethodsetPlotStyleName__SWIG_3(int plotStyleNameType, IntPtr newId)
	{
		return (int)setPlotStyleName((PlotStyleNameType)plotStyleNameType, new OdDbObjectId(newId, cMemoryOwn: true));
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
			IntPtr intPtr = OdDbEntity.getCPtr(pCopy2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pCopy);
		}
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

	private int SwigDirectorMethodsubSetVisibility(int visibility)
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
		return OdDbEntity.getCPtr(subSubentPtr(new OdDbFullSubentPath(path, cMemoryOwn: false))).Handle;
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

	private int SwigDirectorMethodgraphicsMetafileType()
	{
		return (int)graphicsMetafileType();
	}

	private int SwigDirectorMethodproxyFlags()
	{
		return proxyFlags();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodoriginalClassName()
	{
		return originalClassName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodoriginalDxfName()
	{
		return originalDxfName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodapplicationDescription()
	{
		return applicationDescription();
	}

	private void SwigDirectorMethodgetReferences(IntPtr objectIds)
	{
		try
		{
			getReferences(new OdTypedIdsArray(objectIds, cMemoryOwn: false));
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

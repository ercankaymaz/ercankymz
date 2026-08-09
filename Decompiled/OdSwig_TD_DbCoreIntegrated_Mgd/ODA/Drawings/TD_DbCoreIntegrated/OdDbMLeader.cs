using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbMLeader : OdDbEntity
{
	public delegate IntPtr SwigDelegateOdDbMLeader_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbMLeader_1();

	public delegate void SwigDelegateOdDbMLeader_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbMLeader_3();

	public delegate bool SwigDelegateOdDbMLeader_4();

	public delegate IntPtr SwigDelegateOdDbMLeader_5();

	public delegate void SwigDelegateOdDbMLeader_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbMLeader_7();

	public delegate void SwigDelegateOdDbMLeader_8(IntPtr ownerId);

	public delegate int SwigDelegateOdDbMLeader_9(int mode);

	public delegate int SwigDelegateOdDbMLeader_10(bool erasing);

	public delegate void SwigDelegateOdDbMLeader_11(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbMLeader_12(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbMLeader_13(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbMLeader_14(IntPtr otherId);

	public delegate void SwigDelegateOdDbMLeader_15(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbMLeader_16(IntPtr pFiler);

	public delegate void SwigDelegateOdDbMLeader_17(IntPtr pFiler);

	public delegate int SwigDelegateOdDbMLeader_18(IntPtr filer);

	public delegate void SwigDelegateOdDbMLeader_19(IntPtr filer);

	public delegate int SwigDelegateOdDbMLeader_20(IntPtr filer);

	public delegate void SwigDelegateOdDbMLeader_21(IntPtr filer);

	public delegate int SwigDelegateOdDbMLeader_22(IntPtr pFiler);

	public delegate void SwigDelegateOdDbMLeader_23(IntPtr pFiler);

	public delegate int SwigDelegateOdDbMLeader_24();

	public delegate IntPtr SwigDelegateOdDbMLeader_25([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbMLeader_26(IntPtr pRb);

	public delegate void SwigDelegateOdDbMLeader_27(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbMLeader_28(IntPtr objId);

	public delegate void SwigDelegateOdDbMLeader_29(IntPtr objId);

	public delegate void SwigDelegateOdDbMLeader_30(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbMLeader_31();

	public delegate void SwigDelegateOdDbMLeader_32(IntPtr idPair, IntPtr pOwnerObject, IntPtr ownerIdMap);

	public delegate void SwigDelegateOdDbMLeader_33(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbMLeader_34(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbMLeader_35(IntPtr pObject);

	public delegate void SwigDelegateOdDbMLeader_36(IntPtr pObject);

	public delegate void SwigDelegateOdDbMLeader_37(IntPtr pObject);

	public delegate void SwigDelegateOdDbMLeader_38(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbMLeader_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbMLeader_40(IntPtr pObject);

	public delegate void SwigDelegateOdDbMLeader_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbMLeader_42(IntPtr pObject);

	public delegate void SwigDelegateOdDbMLeader_43(IntPtr objectId);

	public delegate void SwigDelegateOdDbMLeader_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbMLeader_45(IntPtr pSource);

	public delegate int SwigDelegateOdDbMLeader_46(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbMLeader_47(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbMLeader_48(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbMLeader_49(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbMLeader_50(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbMLeader_51();

	public delegate IntPtr SwigDelegateOdDbMLeader_52([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbMLeader_53(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbMLeader_54([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbMLeader_55(IntPtr pClass);

	public delegate int SwigDelegateOdDbMLeader_56(IntPtr color, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_57(IntPtr color);

	public delegate IntPtr SwigDelegateOdDbMLeader_58();

	public delegate int SwigDelegateOdDbMLeader_59(ushort colorIndex, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_60(ushort colorIndex);

	public delegate int SwigDelegateOdDbMLeader_61(IntPtr colorId, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_62(IntPtr colorId);

	public delegate int SwigDelegateOdDbMLeader_63(IntPtr transparency, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_64(IntPtr transparency);

	public delegate int SwigDelegateOdDbMLeader_65([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_66([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName);

	public delegate int SwigDelegateOdDbMLeader_67(int plotStyleNameType, IntPtr plotStyleNameId, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_68(int plotStyleNameType, IntPtr plotStyleNameId);

	public delegate int SwigDelegateOdDbMLeader_69(int plotStyleNameType);

	public delegate int SwigDelegateOdDbMLeader_70([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbMLeader_71([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_72([MarshalAs(UnmanagedType.LPWStr)] string layerName);

	public delegate int SwigDelegateOdDbMLeader_73(IntPtr layerId, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbMLeader_74(IntPtr layerId, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_75(IntPtr layerId);

	public delegate int SwigDelegateOdDbMLeader_76([MarshalAs(UnmanagedType.LPWStr)] string linetypeName, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_77([MarshalAs(UnmanagedType.LPWStr)] string linetypeName);

	public delegate int SwigDelegateOdDbMLeader_78(IntPtr linetypeID, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_79(IntPtr linetypeID);

	public delegate int SwigDelegateOdDbMLeader_80([MarshalAs(UnmanagedType.LPWStr)] string materialName, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_81([MarshalAs(UnmanagedType.LPWStr)] string materialName);

	public delegate int SwigDelegateOdDbMLeader_82(IntPtr materialID, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_83(IntPtr materialID);

	public delegate int SwigDelegateOdDbMLeader_84(IntPtr visualStyleId, int vstype, bool doSubents);

	public delegate IntPtr SwigDelegateOdDbMLeader_85();

	public delegate void SwigDelegateOdDbMLeader_86(IntPtr mapper, bool doSubents);

	public delegate void SwigDelegateOdDbMLeader_87(IntPtr mapper);

	public delegate int SwigDelegateOdDbMLeader_88(double linetypeScale, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_89(double linetypeScale);

	public delegate int SwigDelegateOdDbMLeader_90(int lineWeight, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_91(int lineWeight);

	public delegate bool SwigDelegateOdDbMLeader_92();

	public delegate void SwigDelegateOdDbMLeader_93(bool castShadows);

	public delegate bool SwigDelegateOdDbMLeader_94();

	public delegate void SwigDelegateOdDbMLeader_95(bool receiveShadows);

	public delegate int SwigDelegateOdDbMLeader_96();

	public delegate bool SwigDelegateOdDbMLeader_97();

	public delegate int SwigDelegateOdDbMLeader_98(IntPtr plane, OdDb_Planarity planarity);

	public delegate int SwigDelegateOdDbMLeader_99(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbMLeader_100(IntPtr pBlockRecord);

	public delegate int SwigDelegateOdDbMLeader_101(IntPtr entitySet);

	public delegate int SwigDelegateOdDbMLeader_102(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbMLeader_103(IntPtr pBlockRecord);

	public delegate void SwigDelegateOdDbMLeader_104();

	public delegate void SwigDelegateOdDbMLeader_105(int status);

	public delegate void SwigDelegateOdDbMLeader_106(IntPtr pWd, int ver);

	public delegate IntPtr SwigDelegateOdDbMLeader_107();

	public delegate int SwigDelegateOdDbMLeader_108(IntPtr xform);

	public delegate int SwigDelegateOdDbMLeader_109(IntPtr xform, IntPtr pEnt);

	public delegate int SwigDelegateOdDbMLeader_110(IntPtr entitySet);

	public delegate int SwigDelegateOdDbMLeader_111(IntPtr xM);

	public delegate bool SwigDelegateOdDbMLeader_112();

	public delegate bool SwigDelegateOdDbMLeader_113();

	public delegate void SwigDelegateOdDbMLeader_114(int status);

	public delegate int SwigDelegateOdDbMLeader_115(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints);

	public delegate int SwigDelegateOdDbMLeader_116(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insertionMat);

	public delegate bool SwigDelegateOdDbMLeader_117();

	public delegate int SwigDelegateOdDbMLeader_118(IntPtr gripPoints);

	public delegate int SwigDelegateOdDbMLeader_119(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbMLeader_120(IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags);

	public delegate int SwigDelegateOdDbMLeader_121(IntPtr grips, IntPtr offset, int bitFlags);

	public delegate int SwigDelegateOdDbMLeader_122(IntPtr stretchPoints);

	public delegate int SwigDelegateOdDbMLeader_123(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbMLeader_124(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbMLeader_125(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbMLeader_126(IntPtr pEnt, int intType, IntPtr points);

	public delegate int SwigDelegateOdDbMLeader_127(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbMLeader_128(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbMLeader_129(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points);

	public delegate void SwigDelegateOdDbMLeader_130(bool bDoIt, IntPtr pSubId, bool highlightAll);

	public delegate void SwigDelegateOdDbMLeader_131(bool bDoIt, IntPtr pSubId);

	public delegate void SwigDelegateOdDbMLeader_132(bool bDoIt);

	public delegate void SwigDelegateOdDbMLeader_133();

	public delegate int SwigDelegateOdDbMLeader_134();

	public delegate int SwigDelegateOdDbMLeader_135(int visibility, bool doSubents);

	public delegate int SwigDelegateOdDbMLeader_136(int visibility);

	public delegate int SwigDelegateOdDbMLeader_137(IntPtr extents);

	public delegate int SwigDelegateOdDbMLeader_138(IntPtr paths);

	public delegate int SwigDelegateOdDbMLeader_139(IntPtr paths);

	public delegate int SwigDelegateOdDbMLeader_140(IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags);

	public delegate int SwigDelegateOdDbMLeader_141(IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags);

	public delegate int SwigDelegateOdDbMLeader_142(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths, IntPtr pEntAndInsertStack);

	public delegate int SwigDelegateOdDbMLeader_143(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths);

	public delegate int SwigDelegateOdDbMLeader_144(IntPtr subPath, IntPtr gsMarkers);

	public delegate IntPtr SwigDelegateOdDbMLeader_145(IntPtr path);

	public delegate int SwigDelegateOdDbMLeader_146(IntPtr paths, IntPtr xform);

	public delegate int SwigDelegateOdDbMLeader_147(IntPtr path, IntPtr clsId);

	public delegate int SwigDelegateOdDbMLeader_148(IntPtr path, IntPtr extents);

	public delegate void SwigDelegateOdDbMLeader_149(int status, IntPtr subentity);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbMLeader_0 swigDelegate0;

	private SwigDelegateOdDbMLeader_1 swigDelegate1;

	private SwigDelegateOdDbMLeader_2 swigDelegate2;

	private SwigDelegateOdDbMLeader_3 swigDelegate3;

	private SwigDelegateOdDbMLeader_4 swigDelegate4;

	private SwigDelegateOdDbMLeader_5 swigDelegate5;

	private SwigDelegateOdDbMLeader_6 swigDelegate6;

	private SwigDelegateOdDbMLeader_7 swigDelegate7;

	private SwigDelegateOdDbMLeader_8 swigDelegate8;

	private SwigDelegateOdDbMLeader_9 swigDelegate9;

	private SwigDelegateOdDbMLeader_10 swigDelegate10;

	private SwigDelegateOdDbMLeader_11 swigDelegate11;

	private SwigDelegateOdDbMLeader_12 swigDelegate12;

	private SwigDelegateOdDbMLeader_13 swigDelegate13;

	private SwigDelegateOdDbMLeader_14 swigDelegate14;

	private SwigDelegateOdDbMLeader_15 swigDelegate15;

	private SwigDelegateOdDbMLeader_16 swigDelegate16;

	private SwigDelegateOdDbMLeader_17 swigDelegate17;

	private SwigDelegateOdDbMLeader_18 swigDelegate18;

	private SwigDelegateOdDbMLeader_19 swigDelegate19;

	private SwigDelegateOdDbMLeader_20 swigDelegate20;

	private SwigDelegateOdDbMLeader_21 swigDelegate21;

	private SwigDelegateOdDbMLeader_22 swigDelegate22;

	private SwigDelegateOdDbMLeader_23 swigDelegate23;

	private SwigDelegateOdDbMLeader_24 swigDelegate24;

	private SwigDelegateOdDbMLeader_25 swigDelegate25;

	private SwigDelegateOdDbMLeader_26 swigDelegate26;

	private SwigDelegateOdDbMLeader_27 swigDelegate27;

	private SwigDelegateOdDbMLeader_28 swigDelegate28;

	private SwigDelegateOdDbMLeader_29 swigDelegate29;

	private SwigDelegateOdDbMLeader_30 swigDelegate30;

	private SwigDelegateOdDbMLeader_31 swigDelegate31;

	private SwigDelegateOdDbMLeader_32 swigDelegate32;

	private SwigDelegateOdDbMLeader_33 swigDelegate33;

	private SwigDelegateOdDbMLeader_34 swigDelegate34;

	private SwigDelegateOdDbMLeader_35 swigDelegate35;

	private SwigDelegateOdDbMLeader_36 swigDelegate36;

	private SwigDelegateOdDbMLeader_37 swigDelegate37;

	private SwigDelegateOdDbMLeader_38 swigDelegate38;

	private SwigDelegateOdDbMLeader_39 swigDelegate39;

	private SwigDelegateOdDbMLeader_40 swigDelegate40;

	private SwigDelegateOdDbMLeader_41 swigDelegate41;

	private SwigDelegateOdDbMLeader_42 swigDelegate42;

	private SwigDelegateOdDbMLeader_43 swigDelegate43;

	private SwigDelegateOdDbMLeader_44 swigDelegate44;

	private SwigDelegateOdDbMLeader_45 swigDelegate45;

	private SwigDelegateOdDbMLeader_46 swigDelegate46;

	private SwigDelegateOdDbMLeader_47 swigDelegate47;

	private SwigDelegateOdDbMLeader_48 swigDelegate48;

	private SwigDelegateOdDbMLeader_49 swigDelegate49;

	private SwigDelegateOdDbMLeader_50 swigDelegate50;

	private SwigDelegateOdDbMLeader_51 swigDelegate51;

	private SwigDelegateOdDbMLeader_52 swigDelegate52;

	private SwigDelegateOdDbMLeader_53 swigDelegate53;

	private SwigDelegateOdDbMLeader_54 swigDelegate54;

	private SwigDelegateOdDbMLeader_55 swigDelegate55;

	private SwigDelegateOdDbMLeader_56 swigDelegate56;

	private SwigDelegateOdDbMLeader_57 swigDelegate57;

	private SwigDelegateOdDbMLeader_58 swigDelegate58;

	private SwigDelegateOdDbMLeader_59 swigDelegate59;

	private SwigDelegateOdDbMLeader_60 swigDelegate60;

	private SwigDelegateOdDbMLeader_61 swigDelegate61;

	private SwigDelegateOdDbMLeader_62 swigDelegate62;

	private SwigDelegateOdDbMLeader_63 swigDelegate63;

	private SwigDelegateOdDbMLeader_64 swigDelegate64;

	private SwigDelegateOdDbMLeader_65 swigDelegate65;

	private SwigDelegateOdDbMLeader_66 swigDelegate66;

	private SwigDelegateOdDbMLeader_67 swigDelegate67;

	private SwigDelegateOdDbMLeader_68 swigDelegate68;

	private SwigDelegateOdDbMLeader_69 swigDelegate69;

	private SwigDelegateOdDbMLeader_70 swigDelegate70;

	private SwigDelegateOdDbMLeader_71 swigDelegate71;

	private SwigDelegateOdDbMLeader_72 swigDelegate72;

	private SwigDelegateOdDbMLeader_73 swigDelegate73;

	private SwigDelegateOdDbMLeader_74 swigDelegate74;

	private SwigDelegateOdDbMLeader_75 swigDelegate75;

	private SwigDelegateOdDbMLeader_76 swigDelegate76;

	private SwigDelegateOdDbMLeader_77 swigDelegate77;

	private SwigDelegateOdDbMLeader_78 swigDelegate78;

	private SwigDelegateOdDbMLeader_79 swigDelegate79;

	private SwigDelegateOdDbMLeader_80 swigDelegate80;

	private SwigDelegateOdDbMLeader_81 swigDelegate81;

	private SwigDelegateOdDbMLeader_82 swigDelegate82;

	private SwigDelegateOdDbMLeader_83 swigDelegate83;

	private SwigDelegateOdDbMLeader_84 swigDelegate84;

	private SwigDelegateOdDbMLeader_85 swigDelegate85;

	private SwigDelegateOdDbMLeader_86 swigDelegate86;

	private SwigDelegateOdDbMLeader_87 swigDelegate87;

	private SwigDelegateOdDbMLeader_88 swigDelegate88;

	private SwigDelegateOdDbMLeader_89 swigDelegate89;

	private SwigDelegateOdDbMLeader_90 swigDelegate90;

	private SwigDelegateOdDbMLeader_91 swigDelegate91;

	private SwigDelegateOdDbMLeader_92 swigDelegate92;

	private SwigDelegateOdDbMLeader_93 swigDelegate93;

	private SwigDelegateOdDbMLeader_94 swigDelegate94;

	private SwigDelegateOdDbMLeader_95 swigDelegate95;

	private SwigDelegateOdDbMLeader_96 swigDelegate96;

	private SwigDelegateOdDbMLeader_97 swigDelegate97;

	private SwigDelegateOdDbMLeader_98 swigDelegate98;

	private SwigDelegateOdDbMLeader_99 swigDelegate99;

	private SwigDelegateOdDbMLeader_100 swigDelegate100;

	private SwigDelegateOdDbMLeader_101 swigDelegate101;

	private SwigDelegateOdDbMLeader_102 swigDelegate102;

	private SwigDelegateOdDbMLeader_103 swigDelegate103;

	private SwigDelegateOdDbMLeader_104 swigDelegate104;

	private SwigDelegateOdDbMLeader_105 swigDelegate105;

	private SwigDelegateOdDbMLeader_106 swigDelegate106;

	private SwigDelegateOdDbMLeader_107 swigDelegate107;

	private SwigDelegateOdDbMLeader_108 swigDelegate108;

	private SwigDelegateOdDbMLeader_109 swigDelegate109;

	private SwigDelegateOdDbMLeader_110 swigDelegate110;

	private SwigDelegateOdDbMLeader_111 swigDelegate111;

	private SwigDelegateOdDbMLeader_112 swigDelegate112;

	private SwigDelegateOdDbMLeader_113 swigDelegate113;

	private SwigDelegateOdDbMLeader_114 swigDelegate114;

	private SwigDelegateOdDbMLeader_115 swigDelegate115;

	private SwigDelegateOdDbMLeader_116 swigDelegate116;

	private SwigDelegateOdDbMLeader_117 swigDelegate117;

	private SwigDelegateOdDbMLeader_118 swigDelegate118;

	private SwigDelegateOdDbMLeader_119 swigDelegate119;

	private SwigDelegateOdDbMLeader_120 swigDelegate120;

	private SwigDelegateOdDbMLeader_121 swigDelegate121;

	private SwigDelegateOdDbMLeader_122 swigDelegate122;

	private SwigDelegateOdDbMLeader_123 swigDelegate123;

	private SwigDelegateOdDbMLeader_124 swigDelegate124;

	private SwigDelegateOdDbMLeader_125 swigDelegate125;

	private SwigDelegateOdDbMLeader_126 swigDelegate126;

	private SwigDelegateOdDbMLeader_127 swigDelegate127;

	private SwigDelegateOdDbMLeader_128 swigDelegate128;

	private SwigDelegateOdDbMLeader_129 swigDelegate129;

	private SwigDelegateOdDbMLeader_130 swigDelegate130;

	private SwigDelegateOdDbMLeader_131 swigDelegate131;

	private SwigDelegateOdDbMLeader_132 swigDelegate132;

	private SwigDelegateOdDbMLeader_133 swigDelegate133;

	private SwigDelegateOdDbMLeader_134 swigDelegate134;

	private SwigDelegateOdDbMLeader_135 swigDelegate135;

	private SwigDelegateOdDbMLeader_136 swigDelegate136;

	private SwigDelegateOdDbMLeader_137 swigDelegate137;

	private SwigDelegateOdDbMLeader_138 swigDelegate138;

	private SwigDelegateOdDbMLeader_139 swigDelegate139;

	private SwigDelegateOdDbMLeader_140 swigDelegate140;

	private SwigDelegateOdDbMLeader_141 swigDelegate141;

	private SwigDelegateOdDbMLeader_142 swigDelegate142;

	private SwigDelegateOdDbMLeader_143 swigDelegate143;

	private SwigDelegateOdDbMLeader_144 swigDelegate144;

	private SwigDelegateOdDbMLeader_145 swigDelegate145;

	private SwigDelegateOdDbMLeader_146 swigDelegate146;

	private SwigDelegateOdDbMLeader_147 swigDelegate147;

	private SwigDelegateOdDbMLeader_148 swigDelegate148;

	private SwigDelegateOdDbMLeader_149 swigDelegate149;

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

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes12 = new Type[3]
	{
		typeof(OdDbObjectId),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdDbAuditInfo) };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes24 = new Type[0];

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdResBuf) };

	private static Type[] swigMethodTypes27 = new Type[2]
	{
		typeof(OdDbDwgFiler),
		typeof(OdRxClass)
	};

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[3]
	{
		typeof(OdDbIdPair),
		typeof(OdDbObject),
		typeof(OdDbIdMapping).MakeByRefType()
	};

	private static Type[] swigMethodTypes33 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes34 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes35 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes38 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes39 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes45 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes46 = new Type[2]
	{
		typeof(OdDbFiler),
		typeof(MaintReleaseVer).MakeByRefType()
	};

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(OdDbFiler) };

	private static Type[] swigMethodTypes48 = new Type[3]
	{
		typeof(DwgVersion),
		typeof(OdDbObjectId),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes49 = new Type[4]
	{
		typeof(OdDb_SaveType),
		typeof(DwgVersion),
		typeof(OdDbObjectId),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes50 = new Type[3]
	{
		typeof(OdDb_SaveType),
		typeof(DwgVersion),
		typeof(OdDbAuditInfo)
	};

	private static Type[] swigMethodTypes51 = new Type[0];

	private static Type[] swigMethodTypes52 = new Type[2]
	{
		typeof(string),
		typeof(OdDbField)
	};

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes54 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes56 = new Type[2]
	{
		typeof(OdCmColor),
		typeof(bool)
	};

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(OdCmColor) };

	private static Type[] swigMethodTypes58 = new Type[0];

	private static Type[] swigMethodTypes59 = new Type[2]
	{
		typeof(ushort),
		typeof(bool)
	};

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(ushort) };

	private static Type[] swigMethodTypes61 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes63 = new Type[2]
	{
		typeof(OdCmTransparency),
		typeof(bool)
	};

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(OdCmTransparency) };

	private static Type[] swigMethodTypes65 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes66 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes67 = new Type[3]
	{
		typeof(PlotStyleNameType),
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes68 = new Type[2]
	{
		typeof(PlotStyleNameType),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes69 = new Type[1] { typeof(PlotStyleNameType) };

	private static Type[] swigMethodTypes70 = new Type[3]
	{
		typeof(string),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes71 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes72 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes73 = new Type[3]
	{
		typeof(OdDbObjectId),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes74 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes75 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes76 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes77 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes78 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes80 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes81 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes82 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes83 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes84 = new Type[3]
	{
		typeof(OdDbObjectId),
		typeof(OdDbEntity_VisualStyleType),
		typeof(bool)
	};

	private static Type[] swigMethodTypes85 = new Type[0];

	private static Type[] swigMethodTypes86 = new Type[2]
	{
		typeof(OdGiMapper),
		typeof(bool)
	};

	private static Type[] swigMethodTypes87 = new Type[1] { typeof(OdGiMapper) };

	private static Type[] swigMethodTypes88 = new Type[2]
	{
		typeof(double),
		typeof(bool)
	};

	private static Type[] swigMethodTypes89 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes90 = new Type[2]
	{
		typeof(LineWeight),
		typeof(bool)
	};

	private static Type[] swigMethodTypes91 = new Type[1] { typeof(LineWeight) };

	private static Type[] swigMethodTypes92 = new Type[0];

	private static Type[] swigMethodTypes93 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes94 = new Type[0];

	private static Type[] swigMethodTypes95 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes96 = new Type[0];

	private static Type[] swigMethodTypes97 = new Type[0];

	private static Type[] swigMethodTypes98 = new Type[2]
	{
		typeof(OdGePlane),
		typeof(OdDb_Planarity).MakeByRefType()
	};

	private static Type[] swigMethodTypes99 = new Type[2]
	{
		typeof(OdDbBlockTableRecord),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes100 = new Type[1] { typeof(OdDbBlockTableRecord) };

	private static Type[] swigMethodTypes101 = new Type[1] { typeof(OdRxObjectPtrArray) };

	private static Type[] swigMethodTypes102 = new Type[2]
	{
		typeof(OdDbBlockTableRecord),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes103 = new Type[1] { typeof(OdDbBlockTableRecord) };

	private static Type[] swigMethodTypes104 = new Type[0];

	private static Type[] swigMethodTypes105 = new Type[1] { typeof(OdDb_DragStat) };

	private static Type[] swigMethodTypes106 = new Type[2]
	{
		typeof(OdGiWorldDraw),
		typeof(DwgVersion)
	};

	private static Type[] swigMethodTypes107 = new Type[0];

	private static Type[] swigMethodTypes108 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes109 = new Type[2]
	{
		typeof(OdGeMatrix3d),
		typeof(OdDbEntity).MakeByRefType()
	};

	private static Type[] swigMethodTypes110 = new Type[1] { typeof(OdRxObjectPtrArray) };

	private static Type[] swigMethodTypes111 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes112 = new Type[0];

	private static Type[] swigMethodTypes113 = new Type[0];

	private static Type[] swigMethodTypes114 = new Type[1] { typeof(OdDb_GripStat) };

	private static Type[] swigMethodTypes115 = new Type[6]
	{
		typeof(OsnapMode),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes116 = new Type[7]
	{
		typeof(OsnapMode),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3dArray),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes117 = new Type[0];

	private static Type[] swigMethodTypes118 = new Type[1] { typeof(OdGePoint3dArray) };

	private static Type[] swigMethodTypes119 = new Type[2]
	{
		typeof(OdIntArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes120 = new Type[5]
	{
		typeof(OdDbGripDataPtrArray),
		typeof(double),
		typeof(int),
		typeof(OdGeVector3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes121 = new Type[3]
	{
		typeof(OdDbVoidPtrArray),
		typeof(OdGeVector3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes122 = new Type[1] { typeof(OdGePoint3dArray) };

	private static Type[] swigMethodTypes123 = new Type[2]
	{
		typeof(OdIntArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes124 = new Type[5]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes125 = new Type[4]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes126 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes127 = new Type[6]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes128 = new Type[5]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes129 = new Type[4]
	{
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes130 = new Type[3]
	{
		typeof(bool),
		typeof(OdDbFullSubentPath),
		typeof(bool)
	};

	private static Type[] swigMethodTypes131 = new Type[2]
	{
		typeof(bool),
		typeof(OdDbFullSubentPath)
	};

	private static Type[] swigMethodTypes132 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes133 = new Type[0];

	private static Type[] swigMethodTypes134 = new Type[0];

	private static Type[] swigMethodTypes135 = new Type[2]
	{
		typeof(OdDb_Visibility),
		typeof(bool)
	};

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbMLeader(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbMLeader obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbMLeader(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbMLeader cast(OdRxObject pObj)
	{
		OdDbMLeader rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbMLeader>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_isASwigExplicitOdDbMLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_queryXSwigExplicitOdDbMLeader(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdResult dwgInFields(OdDbDwgFiler filer)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes18) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_dwgInFieldsSwigExplicitOdDbMLeader(swigCPtr, OdDbDwgFiler.getCPtr(filer)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(filer)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dwgOutFields(OdDbDwgFiler filer)
	{
		if (SwigDerivedClassHasMethod("dwgOutFields", swigMethodTypes19))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_dwgOutFieldsSwigExplicitOdDbMLeader(swigCPtr, OdDbDwgFiler.getCPtr(filer));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(filer));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler filer)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes20) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_dxfInFieldsSwigExplicitOdDbMLeader(swigCPtr, OdDbDxfFiler.getCPtr(filer)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(filer)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dxfOutFields(OdDbDxfFiler filer)
	{
		if (SwigDerivedClassHasMethod("dxfOutFields", swigMethodTypes21))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_dxfOutFieldsSwigExplicitOdDbMLeader(swigCPtr, OdDbDxfFiler.getCPtr(filer));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(filer));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected override OdResult subTransformBy(OdGeMatrix3d xform)
	{
		int result = (SwigDerivedClassHasMethod("subTransformBy", swigMethodTypes108) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subTransformBySwigExplicitOdDbMLeader(swigCPtr, OdGeMatrix3d.getCPtr(xform)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subTransformBy(swigCPtr, OdGeMatrix3d.getCPtr(xform)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected override OdResult subMoveGripPointsAt(OdIntArray indices, OdGeVector3d offset)
	{
		int result = (SwigDerivedClassHasMethod("subMoveGripPointsAt", swigMethodTypes119) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subMoveGripPointsAtSwigExplicitOdDbMLeader__SWIG_0(swigCPtr, OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subMoveGripPointsAt__SWIG_0(swigCPtr, OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected override OdResult subMoveGripPointsAt(OdDbVoidPtrArray grips, OdGeVector3d offset, int bitFlags)
	{
		int result = (SwigDerivedClassHasMethod("subMoveGripPointsAt", swigMethodTypes121) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subMoveGripPointsAtSwigExplicitOdDbMLeader__SWIG_1(swigCPtr, OdDbVoidPtrArray.getCPtr(grips), OdGeVector3d.getCPtr(offset), bitFlags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subMoveGripPointsAt__SWIG_1(swigCPtr, OdDbVoidPtrArray.getCPtr(grips), OdGeVector3d.getCPtr(offset), bitFlags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected override OdResult subGetSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d xfm, OdDbFullSubentPathArray subentPaths, OdDbObjectIdArray pEntAndInsertStack)
	{
		int result = (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes142) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subGetSubentPathsAtGsMarkerSwigExplicitOdDbMLeader__SWIG_0(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(xfm), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(pEntAndInsertStack)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subGetSubentPathsAtGsMarker__SWIG_0(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(xfm), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(pEntAndInsertStack)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected override OdResult subGetSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d xfm, OdDbFullSubentPathArray subentPaths)
	{
		int result = (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes143) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subGetSubentPathsAtGsMarkerSwigExplicitOdDbMLeader__SWIG_1(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(xfm), OdDbFullSubentPathArray.getCPtr(subentPaths)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subGetSubentPathsAtGsMarker__SWIG_1(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(xfm), OdDbFullSubentPathArray.getCPtr(subentPaths)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected override OdResult subGetGsMarkersAtSubentPath(OdDbFullSubentPath subPath, OdGsMarkerArray gsMarkers)
	{
		int result = (SwigDerivedClassHasMethod("subGetGsMarkersAtSubentPath", swigMethodTypes144) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subGetGsMarkersAtSubentPathSwigExplicitOdDbMLeader(swigCPtr, OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subGetGsMarkersAtSubentPath(swigCPtr, OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected override OdResult subDeleteSubentPaths(OdDbFullSubentPathArray paths)
	{
		int result = (SwigDerivedClassHasMethod("subDeleteSubentPaths", swigMethodTypes138) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subDeleteSubentPathsSwigExplicitOdDbMLeader(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subDeleteSubentPaths(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected override OdDbEntity subSubentPtr(OdDbFullSubentPath path)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(SwigDerivedClassHasMethod("subSubentPtr", swigMethodTypes145) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subSubentPtrSwigExplicitOdDbMLeader(swigCPtr, OdDbFullSubentPath.getCPtr(path)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subSubentPtr(swigCPtr, OdDbFullSubentPath.getCPtr(path)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected override OdResult subExplode(OdRxObjectPtrArray entitySet)
	{
		int result = (SwigDerivedClassHasMethod("subExplode", swigMethodTypes110) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subExplodeSwigExplicitOdDbMLeader(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subExplode(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected override OdResult subGetGeomExtents(OdGeExtents3d extents)
	{
		int result = (SwigDerivedClassHasMethod("subGetGeomExtents", swigMethodTypes137) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subGetGeomExtentsSwigExplicitOdDbMLeader(swigCPtr, OdGeExtents3d.getCPtr(extents)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subGetGeomExtents(swigCPtr, OdGeExtents3d.getCPtr(extents)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected override OdResult subGetTransformedCopy(OdGeMatrix3d xform, ref OdDbEntity pEnt)
	{
		IntPtr jarg = ((pEnt == null) ? IntPtr.Zero : OdDbEntity.getCPtr(pEnt).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = (SwigDerivedClassHasMethod("subGetTransformedCopy", swigMethodTypes109) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subGetTransformedCopySwigExplicitOdDbMLeader(swigCPtr, OdGeMatrix3d.getCPtr(xform), ref jarg) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_subGetTransformedCopy(swigCPtr, OdGeMatrix3d.getCPtr(xform), ref jarg));
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
				pEnt = null;
			}
			else if (jarg != intPtr)
			{
				pEnt = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void setOverride(OdDbMLeader_PropertyOverrideType propertyType, bool isOverride)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setOverride__SWIG_0(swigCPtr, (int)propertyType, isOverride);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOverride(OdDbMLeader_PropertyOverrideType propertyType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setOverride__SWIG_1(swigCPtr, (int)propertyType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isOverride(OdDbMLeader_PropertyOverrideType propertyType)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_isOverride__SWIG_0(swigCPtr, (int)propertyType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setScale(double scale)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setScale(swigCPtr, scale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public double scale()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_scale(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult getBlockAttributeValue(OdDbObjectId attdefId, ref OdDbAttribute pAtt)
	{
		IntPtr jarg = ((pAtt == null) ? IntPtr.Zero : OdDbAttribute.getCPtr(pAtt).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getBlockAttributeValue(swigCPtr, OdDbObjectId.getCPtr(attdefId), ref jarg);
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
				pAtt = null;
			}
			else if (jarg != intPtr)
			{
				pAtt = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAttribute>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdResult setBlockAttributeValue(OdDbObjectId attdefId, OdDbAttribute pAtt)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setBlockAttributeValue(swigCPtr, OdDbObjectId.getCPtr(attdefId), OdDbAttribute.getCPtr(pAtt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdGePlane plane()
	{
		OdGePlane result = new OdGePlane(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_plane(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPlane(OdGePlane plane)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setPlane(swigCPtr, OdGePlane.getCPtr(plane));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d normal()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_normal(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult moveMLeader(OdGeVector3d vector, OdDbMLeader_MoveType moveType, bool bAutoSwitchDogleg)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_moveMLeader__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(vector).Handle, (int)moveType, bAutoSwitchDogleg);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult moveMLeader(OdGeVector3d vector, OdDbMLeader_MoveType moveType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_moveMLeader__SWIG_1(swigCPtr, OdGeVector3d.getCPtr(vector).Handle, (int)moveType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getContentGeomExtents(OdGeExtents3d extents)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getContentGeomExtents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public int numLeaders()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_numLeaders(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getLeaderIndexes(OdIntArray leaderIndexes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getLeaderIndexes(swigCPtr, OdIntArray.getCPtr(leaderIndexes).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addLeader(out int leaderIndex)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_addLeader(swigCPtr, out leaderIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void removeLeader(int leaderIndex)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_removeLeader(swigCPtr, leaderIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numLeaderLines()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_numLeaderLines(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getLeaderLineIndexes(OdIntArray leaderLineIndexes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getLeaderLineIndexes__SWIG_0(swigCPtr, OdIntArray.getCPtr(leaderLineIndexes).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult addLeaderLine(int leaderIndex, out int leaderLineIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_addLeaderLine__SWIG_0(swigCPtr, leaderIndex, out leaderLineIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult addLeaderLine(OdGePoint3d point, out int leaderLineIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_addLeaderLine__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), out leaderLineIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void removeLeaderLine(int leaderLineIndex)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_removeLeaderLine(swigCPtr, leaderLineIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult addFirstVertex(int leaderLineIndex, OdGePoint3d point)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_addFirstVertex(swigCPtr, leaderLineIndex, OdGePoint3d.getCPtr(point));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult removeFirstVertex(int leaderLineIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_removeFirstVertex(swigCPtr, leaderLineIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getFirstVertex(int leaderLineIndex, OdGePoint3d point)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getFirstVertex(swigCPtr, leaderLineIndex, OdGePoint3d.getCPtr(point));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setFirstVertex(int leaderLineIndex, OdGePoint3d point)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setFirstVertex(swigCPtr, leaderLineIndex, OdGePoint3d.getCPtr(point));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult addLastVertex(int leaderLineIndex, OdGePoint3d point)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_addLastVertex(swigCPtr, leaderLineIndex, OdGePoint3d.getCPtr(point));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult removeLastVertex(int leaderLineIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_removeLastVertex(swigCPtr, leaderLineIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getLastVertex(int leaderLineIndex, OdGePoint3d point)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getLastVertex(swigCPtr, leaderLineIndex, OdGePoint3d.getCPtr(point));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setLastVertex(int leaderLineIndex, OdGePoint3d point)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setLastVertex(swigCPtr, leaderLineIndex, OdGePoint3d.getCPtr(point));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult numVertices(int leaderLineIndex, out int num)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_numVertices(swigCPtr, leaderLineIndex, out num);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setVertex(int leaderLineIndex, int index, OdGePoint3d point)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setVertex(swigCPtr, leaderLineIndex, index, OdGePoint3d.getCPtr(point));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void getVertex(int leaderLineIndex, int index, OdGePoint3d point)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getVertex(swigCPtr, leaderLineIndex, index, OdGePoint3d.getCPtr(point));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLeaderIndex(int leaderLineIndex, out int leaderIndex)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getLeaderIndex(swigCPtr, leaderLineIndex, out leaderIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLeaderLineIndexes(int leaderIndex, OdIntArray leaderLineIndexes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getLeaderLineIndexes__SWIG_1(swigCPtr, leaderIndex, OdIntArray.getCPtr(leaderLineIndexes).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDoglegDirection(int leaderIndex, OdGeVector3d vector)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setDoglegDirection(swigCPtr, leaderIndex, OdGeVector3d.getCPtr(vector).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDoglegDirection(int leaderIndex, OdGeVector3d vector)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getDoglegDirection(swigCPtr, leaderIndex, OdGeVector3d.getCPtr(vector).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLeaderLineType(OdDbMLeaderStyle_LeaderType leaderLineType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setLeaderLineType__SWIG_0(swigCPtr, (int)leaderLineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbMLeaderStyle_LeaderType leaderLineType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_leaderLineType__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_LeaderType)result;
	}

	public void setLeaderLineColor(OdCmColor leaderLineColor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setLeaderLineColor__SWIG_0(swigCPtr, OdCmColor.getCPtr(leaderLineColor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmColor leaderLineColor()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_leaderLineColor__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLeaderLineTypeId(OdDbObjectId leaderLineTypeId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setLeaderLineTypeId__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(leaderLineTypeId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId leaderLineTypeId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_leaderLineTypeId__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLeaderLineWeight(LineWeight leaderLineWeight)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setLeaderLineWeight__SWIG_0(swigCPtr, (int)leaderLineWeight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public LineWeight leaderLineWeight()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_leaderLineWeight__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public void setLandingGap(double landingGap)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setLandingGap(swigCPtr, landingGap);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double landingGap()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_landingGap(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEnableLanding(bool enableLanding)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setEnableLanding(swigCPtr, enableLanding);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool enableLanding()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_enableLanding(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEnableDogleg(bool enableDogleg)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setEnableDogleg(swigCPtr, enableDogleg);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool enableDogleg()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_enableDogleg(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDoglegLength(int leaderIndex, double dDoglegLength)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setDoglegLength__SWIG_0(swigCPtr, leaderIndex, dDoglegLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double doglegLength(int leaderIndex)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_doglegLength__SWIG_0(swigCPtr, leaderIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setDoglegLength(double doglegLength)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setDoglegLength__SWIG_1(swigCPtr, doglegLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public double doglegLength()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_doglegLength__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setArrowSymbolId(OdDbObjectId arrowSymbolId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setArrowSymbolId__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(arrowSymbolId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId arrowSymbolId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_arrowSymbolId__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setArrowSize(double arrowSize)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setArrowSize__SWIG_0(swigCPtr, arrowSize);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double arrowSize()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_arrowSize__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setContentType(OdDbMLeaderStyle_ContentType contentType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setContentType(swigCPtr, (int)contentType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbMLeaderStyle_ContentType contentType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_contentType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_ContentType)result;
	}

	public void setTextStyleId(OdDbObjectId textStyleId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setTextStyleId(swigCPtr, OdDbObjectId.getCPtr(textStyleId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId textStyleId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_textStyleId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTextAttachmentType(OdDbMLeaderStyle_TextAttachmentType textAttachmentType, OdDbMLeaderStyle_LeaderDirectionType leaderDirection)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setTextAttachmentType(swigCPtr, (int)textAttachmentType, (int)leaderDirection);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbMLeaderStyle_TextAttachmentType textAttachmentType(OdDbMLeaderStyle_LeaderDirectionType leaderDirection)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_textAttachmentType(swigCPtr, (int)leaderDirection);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_TextAttachmentType)result;
	}

	public void setTextAngleType(OdDbMLeaderStyle_TextAngleType textAngleType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setTextAngleType(swigCPtr, (int)textAngleType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbMLeaderStyle_TextAngleType textAngleType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_textAngleType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_TextAngleType)result;
	}

	public void setTextAlignmentType(OdDbMLeaderStyle_TextAlignmentType textAlignmentType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setTextAlignmentType(swigCPtr, (int)textAlignmentType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbMLeaderStyle_TextAlignmentType textAlignmentType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_textAlignmentType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_TextAlignmentType)result;
	}

	public void setTextColor(OdCmColor textColor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setTextColor(swigCPtr, OdCmColor.getCPtr(textColor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmColor textColor()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_textColor(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTextHeight(double textHeight)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setTextHeight(swigCPtr, textHeight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double textHeight()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_textHeight(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEnableFrameText(bool enableFrameText)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setEnableFrameText(swigCPtr, enableFrameText);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool enableFrameText()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_enableFrameText(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMText(OdDbMText pMText)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setMText(swigCPtr, OdDbMText.getCPtr(pMText));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbMText mtext()
	{
		OdDbMText rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbMText>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_mtext(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setBlockContentId(OdDbObjectId blockId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setBlockContentId(swigCPtr, OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId blockContentId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_blockContentId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBlockColor(OdCmColor blockColor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setBlockColor(swigCPtr, OdCmColor.getCPtr(blockColor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmColor blockColor()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_blockColor(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBlockScale(OdGeScale3d scale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setBlockScale(swigCPtr, OdGeScale3d.getCPtr(scale));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeScale3d blockScale()
	{
		OdGeScale3d result = new OdGeScale3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_blockScale(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBlockRotation(double rotation)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setBlockRotation(swigCPtr, rotation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double blockRotation()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_blockRotation(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBlockConnectionType(OdDbMLeaderStyle_BlockConnectionType blockConnectionType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setBlockConnectionType(swigCPtr, (int)blockConnectionType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbMLeaderStyle_BlockConnectionType blockConnectionType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_blockConnectionType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_BlockConnectionType)result;
	}

	public void setEnableAnnotationScale(bool enableAnnotationScale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setEnableAnnotationScale(swigCPtr, enableAnnotationScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool enableAnnotationScale()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_enableAnnotationScale(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMLeaderStyle(OdDbObjectId newStyleId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setMLeaderStyle(swigCPtr, OdDbObjectId.getCPtr(newStyleId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId MLeaderStyle()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_MLeaderStyle(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult getOverridedMLeaderStyle(ref OdDbMLeaderStyle mleaderStyle)
	{
		IntPtr jarg = ((mleaderStyle == null) ? IntPtr.Zero : OdDbMLeaderStyle.getCPtr(mleaderStyle).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getOverridedMLeaderStyle(swigCPtr, ref jarg);
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
				mleaderStyle = null;
			}
			if (jarg != intPtr)
			{
				mleaderStyle = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbMLeaderStyle>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdResult setContextDataManager(IntPtr pContextDataManager)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setContextDataManager(swigCPtr, pContextDataManager);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public IntPtr getContextDataManager()
	{
		IntPtr result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getContextDataManager(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBlockPosition(OdGePoint3d position)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setBlockPosition(swigCPtr, OdGePoint3d.getCPtr(position).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBlockPosition(OdGePoint3d position)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getBlockPosition(swigCPtr, OdGePoint3d.getCPtr(position).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextLocation(OdGePoint3d location)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setTextLocation(swigCPtr, OdGePoint3d.getCPtr(location));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTextLocation(OdGePoint3d location)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getTextLocation(swigCPtr, OdGePoint3d.getCPtr(location));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult setToleranceLocation(OdGePoint3d location)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setToleranceLocation(swigCPtr, OdGePoint3d.getCPtr(location));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getToleranceLocation(OdGePoint3d location)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getToleranceLocation(swigCPtr, OdGePoint3d.getCPtr(location));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void setArrowSymbolId(int leaderLineIndex, OdDbObjectId arrowSymbolId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setArrowSymbolId__SWIG_1(swigCPtr, leaderLineIndex, OdDbObjectId.getCPtr(arrowSymbolId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId arrowSymbolId(int leaderLineIndex)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_arrowSymbolId__SWIG_1(swigCPtr, leaderLineIndex), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasContent()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_hasContent(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult connectionPoint(OdGeVector3d vect, OdGePoint3d point)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_connectionPoint__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(point));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult connectionPoint(OdGeVector3d vect, OdGePoint3d point, OdDbMLeaderStyle_TextAttachmentDirection direction)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_connectionPoint__SWIG_1(swigCPtr, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(point), (int)direction);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult recomputeBreakPoints()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_recomputeBreakPoints(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult postMLeaderToDb(OdDbDatabase pDb)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_postMLeaderToDb(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult updateLeaderLinePosition()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_updateLeaderLinePosition(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult removeLeaderLineRefAssoc(int leaderLineIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_removeLeaderLineRefAssoc(swigCPtr, leaderLineIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult updateContentScale(OdDbMLeaderObjectContextData pContext)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_updateContentScale(swigCPtr, OdDbMLeaderObjectContextData.getCPtr(pContext));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override bool isPlanar()
	{
		bool result = (SwigDerivedClassHasMethod("isPlanar", swigMethodTypes97) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_isPlanarSwigExplicitOdDbMLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_isPlanar(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult getPlane(OdGePlane plane, out OdDb_Planarity planarity)
	{
		int result = (SwigDerivedClassHasMethod("getPlane", swigMethodTypes98) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getPlaneSwigExplicitOdDbMLeader(swigCPtr, OdGePlane.getCPtr(plane), out planarity) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getPlane(swigCPtr, OdGePlane.getCPtr(plane), out planarity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void setTextAttachmentDirection(OdDbMLeaderStyle_TextAttachmentDirection direction)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setTextAttachmentDirection(swigCPtr, (int)direction);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbMLeaderStyle_TextAttachmentDirection textAttachmentDirection()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_textAttachmentDirection(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_TextAttachmentDirection)result;
	}

	public bool isOverride(int leaderLineIndex, OdDbMLeader_LeaderLineOverrideType value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_isOverride__SWIG_1(swigCPtr, leaderLineIndex, (int)value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLeaderLineType(int leaderLineIndex, OdDbMLeaderStyle_LeaderType leaderLineType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setLeaderLineType__SWIG_1(swigCPtr, leaderLineIndex, (int)leaderLineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbMLeaderStyle_LeaderType leaderLineType(int leaderLineIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_leaderLineType__SWIG_1(swigCPtr, leaderLineIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_LeaderType)result;
	}

	public void setLeaderLineColor(int leaderLineIndex, OdCmColor leaderLineColor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setLeaderLineColor__SWIG_1(swigCPtr, leaderLineIndex, OdCmColor.getCPtr(leaderLineColor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmColor leaderLineColor(int leaderLineIndex)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_leaderLineColor__SWIG_1(swigCPtr, leaderLineIndex), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLeaderLineTypeId(int leaderLineIndex, OdDbObjectId leaderLineTypeId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setLeaderLineTypeId__SWIG_1(swigCPtr, leaderLineIndex, OdDbObjectId.getCPtr(leaderLineTypeId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId leaderLineTypeId(int leaderLineIndex)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_leaderLineTypeId__SWIG_1(swigCPtr, leaderLineIndex), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLeaderLineWeight(int leaderLineIndex, LineWeight leaderLineWeight)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setLeaderLineWeight__SWIG_1(swigCPtr, leaderLineIndex, (int)leaderLineWeight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public LineWeight leaderLineWeight(int leaderLineIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_leaderLineWeight__SWIG_1(swigCPtr, leaderLineIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public void setArrowSize(int leaderLineIndex, double arrowSize)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setArrowSize__SWIG_1(swigCPtr, leaderLineIndex, arrowSize);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double arrowSize(int leaderLineIndex)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_arrowSize__SWIG_1(swigCPtr, leaderLineIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExtendLeaderToText(bool bSet)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setExtendLeaderToText(swigCPtr, bSet);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool extendLeaderToText()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_extendLeaderToText(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void copyFrom(OdRxObject pSource)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_copyFromSwigExplicitOdDbMLeader(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbMLeader createObject()
	{
		OdDbMLeader rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbMLeader>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("subErase", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsubErase;
		}
		if (SwigDerivedClassHasMethod("subHandOverTo", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsubHandOverTo;
		}
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsubSwapIdWith__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsubSwapIdWith__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsubSwapIdWith__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("audit", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodaudit;
		}
		if (SwigDerivedClassHasMethod("dxfIn", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethoddxfIn;
		}
		if (SwigDerivedClassHasMethod("dxfOut", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethoddxfOut;
		}
		if (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethoddwgInFields;
		}
		if (SwigDerivedClassHasMethod("dwgOutFields", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethoddwgOutFields;
		}
		if (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethoddxfInFields;
		}
		if (SwigDerivedClassHasMethod("dxfOutFields", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethoddxfOutFields;
		}
		if (SwigDerivedClassHasMethod("dxfInFields_R12", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethoddxfInFields_R12;
		}
		if (SwigDerivedClassHasMethod("dxfOutFields_R12", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethoddxfOutFields_R12;
		}
		if (SwigDerivedClassHasMethod("mergeStyle", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodmergeStyle;
		}
		if (SwigDerivedClassHasMethod("xData", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodxData;
		}
		if (SwigDerivedClassHasMethod("setXData", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodsetXData;
		}
		if (SwigDerivedClassHasMethod("applyPartialUndo", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodapplyPartialUndo;
		}
		if (SwigDerivedClassHasMethod("addPersistentReactor", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodaddPersistentReactor;
		}
		if (SwigDerivedClassHasMethod("removePersistentReactor", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodremovePersistentReactor;
		}
		if (SwigDerivedClassHasMethod("recvPropagateModify", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodrecvPropagateModify;
		}
		if (SwigDerivedClassHasMethod("xmitPropagateModify", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodxmitPropagateModify;
		}
		if (SwigDerivedClassHasMethod("appendToOwner", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodappendToOwner;
		}
		if (SwigDerivedClassHasMethod("copied", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodcopied;
		}
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethoderased__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethoderased__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("goodbye", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodgoodbye;
		}
		if (SwigDerivedClassHasMethod("openedForModify", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodopenedForModify;
		}
		if (SwigDerivedClassHasMethod("subObjModified", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodsubObjModified;
		}
		if (SwigDerivedClassHasMethod("modifyUndone", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodmodifyUndone;
		}
		if (SwigDerivedClassHasMethod("modifiedXData", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodmodifiedXData;
		}
		if (SwigDerivedClassHasMethod("unappended", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodunappended;
		}
		if (SwigDerivedClassHasMethod("reappended", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodreappended;
		}
		if (SwigDerivedClassHasMethod("objectClosed", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodobjectClosed;
		}
		if (SwigDerivedClassHasMethod("modifiedGraphics", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodmodifiedGraphics;
		}
		if (SwigDerivedClassHasMethod("copyMeFrom", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodcopyMeFrom;
		}
		if (SwigDerivedClassHasMethod("getObjectSaveVersion", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodgetObjectSaveVersion__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getObjectSaveVersion", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodgetObjectSaveVersion__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("decomposeForSave", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethoddecomposeForSave__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("decomposeForSave", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethoddecomposeForSave__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("composeForLoad", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodcomposeForLoad;
		}
		if (SwigDerivedClassHasMethod("drawable", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethoddrawable;
		}
		if (SwigDerivedClassHasMethod("setField", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodsetField;
		}
		if (SwigDerivedClassHasMethod("removeField", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodremoveField__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("removeField", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodremoveField__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("saveAsClass", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodsaveAsClass;
		}
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodsetColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodsetColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("entityColor", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodentityColor;
		}
		if (SwigDerivedClassHasMethod("setColorIndex", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodsetColorIndex__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setColorIndex", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodsetColorIndex__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setColorId", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodsetColorId__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setColorId", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodsetColorId__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setTransparency", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodsetTransparency__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setTransparency", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodsetTransparency__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodsetPlotStyleName__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodsetPlotStyleName__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodsetPlotStyleName__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodsetPlotStyleName__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodsetPlotStyleName__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodsetLayer__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodsetLayer__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodsetLayer__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodsetLayer__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodsetLayer__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodsetLayer__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodsetLinetype__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodsetLinetype__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodsetLinetype__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodsetLinetype__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodsetMaterial__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodsetMaterial__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodsetMaterial__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodsetMaterial__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodsetVisualStyle;
		}
		if (SwigDerivedClassHasMethod("materialMapper", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodmaterialMapper;
		}
		if (SwigDerivedClassHasMethod("setMaterialMapper", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodsetMaterialMapper__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setMaterialMapper", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodsetMaterialMapper__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLinetypeScale", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodsetLinetypeScale__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setLinetypeScale", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodsetLinetypeScale__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLineWeight", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodsetLineWeight__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setLineWeight", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodsetLineWeight__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("castShadows", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodcastShadows;
		}
		if (SwigDerivedClassHasMethod("setCastShadows", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodsetCastShadows;
		}
		if (SwigDerivedClassHasMethod("receiveShadows", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodreceiveShadows;
		}
		if (SwigDerivedClassHasMethod("setReceiveShadows", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodsetReceiveShadows;
		}
		if (SwigDerivedClassHasMethod("collisionType", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodcollisionType;
		}
		if (SwigDerivedClassHasMethod("isPlanar", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodisPlanar;
		}
		if (SwigDerivedClassHasMethod("getPlane", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodgetPlane;
		}
		if (SwigDerivedClassHasMethod("explodeToBlock", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethodexplodeToBlock__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("explodeToBlock", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodexplodeToBlock__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("explodeGeometry", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodexplodeGeometry;
		}
		if (SwigDerivedClassHasMethod("explodeGeometryToBlock", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethodexplodeGeometryToBlock__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("explodeGeometryToBlock", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethodexplodeGeometryToBlock__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subList", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethodsubList;
		}
		if (SwigDerivedClassHasMethod("dragStatus", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethoddragStatus;
		}
		if (SwigDerivedClassHasMethod("saveAs", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethodsaveAs;
		}
		if (SwigDerivedClassHasMethod("getEcs", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodgetEcs;
		}
		if (SwigDerivedClassHasMethod("subTransformBy", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethodsubTransformBy;
		}
		if (SwigDerivedClassHasMethod("subGetTransformedCopy", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodsubGetTransformedCopy;
		}
		if (SwigDerivedClassHasMethod("subExplode", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodsubExplode;
		}
		if (SwigDerivedClassHasMethod("subGetCompoundObjectTransform", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodsubGetCompoundObjectTransform;
		}
		if (SwigDerivedClassHasMethod("subCloneMeForDragging", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodsubCloneMeForDragging;
		}
		if (SwigDerivedClassHasMethod("subHideMeForDragging", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethodsubHideMeForDragging;
		}
		if (SwigDerivedClassHasMethod("subGripStatus", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodsubGripStatus;
		}
		if (SwigDerivedClassHasMethod("subGetOsnapPoints", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethodsubGetOsnapPoints__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subGetOsnapPoints", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethodsubGetOsnapPoints__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subIsContentSnappable", swigMethodTypes117))
		{
			swigDelegate117 = SwigDirectorMethodsubIsContentSnappable;
		}
		if (SwigDerivedClassHasMethod("subGetGripPoints", swigMethodTypes118))
		{
			swigDelegate118 = SwigDirectorMethodsubGetGripPoints__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subMoveGripPointsAt", swigMethodTypes119))
		{
			swigDelegate119 = SwigDirectorMethodsubMoveGripPointsAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subGetGripPoints", swigMethodTypes120))
		{
			swigDelegate120 = SwigDirectorMethodsubGetGripPoints__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subMoveGripPointsAt", swigMethodTypes121))
		{
			swigDelegate121 = SwigDirectorMethodsubMoveGripPointsAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subGetStretchPoints", swigMethodTypes122))
		{
			swigDelegate122 = SwigDirectorMethodsubGetStretchPoints;
		}
		if (SwigDerivedClassHasMethod("subMoveStretchPointsAt", swigMethodTypes123))
		{
			swigDelegate123 = SwigDirectorMethodsubMoveStretchPointsAt;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes124))
		{
			swigDelegate124 = SwigDirectorMethodsubIntersectWith__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes125))
		{
			swigDelegate125 = SwigDirectorMethodsubIntersectWith__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes126))
		{
			swigDelegate126 = SwigDirectorMethodsubIntersectWith__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes127))
		{
			swigDelegate127 = SwigDirectorMethodsubIntersectWith__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes128))
		{
			swigDelegate128 = SwigDirectorMethodsubIntersectWith__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("subIntersectWith", swigMethodTypes129))
		{
			swigDelegate129 = SwigDirectorMethodsubIntersectWith__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes130))
		{
			swigDelegate130 = SwigDirectorMethodsubHighlight__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes131))
		{
			swigDelegate131 = SwigDirectorMethodsubHighlight__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes132))
		{
			swigDelegate132 = SwigDirectorMethodsubHighlight__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("subHighlight", swigMethodTypes133))
		{
			swigDelegate133 = SwigDirectorMethodsubHighlight__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("subVisibility", swigMethodTypes134))
		{
			swigDelegate134 = SwigDirectorMethodsubVisibility;
		}
		if (SwigDerivedClassHasMethod("subSetVisibility", swigMethodTypes135))
		{
			swigDelegate135 = SwigDirectorMethodsubSetVisibility__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subSetVisibility", swigMethodTypes136))
		{
			swigDelegate136 = SwigDirectorMethodsubSetVisibility__SWIG_1;
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125, swigDelegate126, swigDelegate127, swigDelegate128, swigDelegate129, swigDelegate130, swigDelegate131, swigDelegate132, swigDelegate133, swigDelegate134, swigDelegate135, swigDelegate136, swigDelegate137, swigDelegate138, swigDelegate139, swigDelegate140, swigDelegate141, swigDelegate142, swigDelegate143, swigDelegate144, swigDelegate145, swigDelegate146, swigDelegate147, swigDelegate148, swigDelegate149);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbMLeader));
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

	private int SwigDirectorMethoddwgInFields(IntPtr filer)
	{
		return (int)dwgInFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(filer, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethoddwgOutFields(IntPtr filer)
	{
		try
		{
			dwgOutFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(filer, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethoddxfInFields(IntPtr filer)
	{
		return (int)dxfInFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(filer, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethoddxfOutFields(IntPtr filer)
	{
		try
		{
			dxfOutFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(filer, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodsubTransformBy(IntPtr xform)
	{
		return (int)subTransformBy(new OdGeMatrix3d(xform, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubGetTransformedCopy(IntPtr xform, IntPtr pEnt)
	{
		OdSwigDirectorHelper.director_UnpackData(pEnt, out var pOriginalObject, out var pFunction);
		OdDbEntity pCopy = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)subGetTransformedCopy(new OdGeMatrix3d(xform, cMemoryOwn: false), ref pCopy);
		}
		finally
		{
			IntPtr intPtr = OdDbEntity.getCPtr(pCopy).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pEnt);
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
}

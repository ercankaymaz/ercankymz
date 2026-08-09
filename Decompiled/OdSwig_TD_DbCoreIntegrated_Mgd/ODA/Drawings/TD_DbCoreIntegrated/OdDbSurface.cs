using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbSurface : OdDbEntity
{
	public delegate IntPtr SwigDelegateOdDbSurface_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbSurface_1();

	public delegate void SwigDelegateOdDbSurface_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbSurface_3();

	public delegate bool SwigDelegateOdDbSurface_4();

	public delegate IntPtr SwigDelegateOdDbSurface_5();

	public delegate void SwigDelegateOdDbSurface_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbSurface_7();

	public delegate void SwigDelegateOdDbSurface_8(IntPtr ownerId);

	public delegate int SwigDelegateOdDbSurface_9(int mode);

	public delegate void SwigDelegateOdDbSurface_10();

	public delegate int SwigDelegateOdDbSurface_11(bool erasing);

	public delegate void SwigDelegateOdDbSurface_12(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbSurface_13(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbSurface_14(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbSurface_15(IntPtr otherId);

	public delegate void SwigDelegateOdDbSurface_16(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbSurface_17(IntPtr pFiler);

	public delegate void SwigDelegateOdDbSurface_18(IntPtr pFiler);

	public delegate int SwigDelegateOdDbSurface_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbSurface_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbSurface_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbSurface_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbSurface_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbSurface_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbSurface_25();

	public delegate IntPtr SwigDelegateOdDbSurface_26([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbSurface_27(IntPtr pRb);

	public delegate void SwigDelegateOdDbSurface_28(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbSurface_29(IntPtr objId);

	public delegate void SwigDelegateOdDbSurface_30(IntPtr objId);

	public delegate void SwigDelegateOdDbSurface_31(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbSurface_32();

	public delegate void SwigDelegateOdDbSurface_33(IntPtr idPair, IntPtr pOwnerObject, IntPtr ownerIdMap);

	public delegate void SwigDelegateOdDbSurface_34(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbSurface_35(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbSurface_36(IntPtr pObject);

	public delegate void SwigDelegateOdDbSurface_37(IntPtr pObject);

	public delegate void SwigDelegateOdDbSurface_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbSurface_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbSurface_40(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbSurface_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbSurface_42(IntPtr pObject);

	public delegate void SwigDelegateOdDbSurface_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbSurface_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbSurface_45(IntPtr objectId);

	public delegate void SwigDelegateOdDbSurface_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbSurface_47(IntPtr pSource);

	public delegate int SwigDelegateOdDbSurface_48(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbSurface_49(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbSurface_50(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbSurface_51(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbSurface_52(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbSurface_53();

	public delegate IntPtr SwigDelegateOdDbSurface_54([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbSurface_55(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbSurface_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbSurface_57(IntPtr pClass);

	public delegate int SwigDelegateOdDbSurface_58(IntPtr color, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_59(IntPtr color);

	public delegate IntPtr SwigDelegateOdDbSurface_60();

	public delegate int SwigDelegateOdDbSurface_61(ushort colorIndex, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_62(ushort colorIndex);

	public delegate int SwigDelegateOdDbSurface_63(IntPtr colorId, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_64(IntPtr colorId);

	public delegate int SwigDelegateOdDbSurface_65(IntPtr transparency, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_66(IntPtr transparency);

	public delegate int SwigDelegateOdDbSurface_67([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_68([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName);

	public delegate int SwigDelegateOdDbSurface_69(int plotStyleNameType, IntPtr plotStyleNameId, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_70(int plotStyleNameType, IntPtr plotStyleNameId);

	public delegate int SwigDelegateOdDbSurface_71(int plotStyleNameType);

	public delegate int SwigDelegateOdDbSurface_72([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbSurface_73([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_74([MarshalAs(UnmanagedType.LPWStr)] string layerName);

	public delegate int SwigDelegateOdDbSurface_75(IntPtr layerId, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbSurface_76(IntPtr layerId, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_77(IntPtr layerId);

	public delegate int SwigDelegateOdDbSurface_78([MarshalAs(UnmanagedType.LPWStr)] string linetypeName, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_79([MarshalAs(UnmanagedType.LPWStr)] string linetypeName);

	public delegate int SwigDelegateOdDbSurface_80(IntPtr linetypeID, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_81(IntPtr linetypeID);

	public delegate int SwigDelegateOdDbSurface_82([MarshalAs(UnmanagedType.LPWStr)] string materialName, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_83([MarshalAs(UnmanagedType.LPWStr)] string materialName);

	public delegate int SwigDelegateOdDbSurface_84(IntPtr materialID, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_85(IntPtr materialID);

	public delegate int SwigDelegateOdDbSurface_86(IntPtr visualStyleId, int vstype, bool doSubents);

	public delegate IntPtr SwigDelegateOdDbSurface_87();

	public delegate void SwigDelegateOdDbSurface_88(IntPtr mapper, bool doSubents);

	public delegate void SwigDelegateOdDbSurface_89(IntPtr mapper);

	public delegate int SwigDelegateOdDbSurface_90(double linetypeScale, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_91(double linetypeScale);

	public delegate int SwigDelegateOdDbSurface_92(int lineWeight, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_93(int lineWeight);

	public delegate bool SwigDelegateOdDbSurface_94();

	public delegate void SwigDelegateOdDbSurface_95(bool castShadows);

	public delegate bool SwigDelegateOdDbSurface_96();

	public delegate void SwigDelegateOdDbSurface_97(bool receiveShadows);

	public delegate int SwigDelegateOdDbSurface_98();

	public delegate bool SwigDelegateOdDbSurface_99();

	public delegate int SwigDelegateOdDbSurface_100(IntPtr plane, OdDb_Planarity planarity);

	public delegate int SwigDelegateOdDbSurface_101(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbSurface_102(IntPtr pBlockRecord);

	public delegate int SwigDelegateOdDbSurface_103(IntPtr entitySet);

	public delegate int SwigDelegateOdDbSurface_104(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbSurface_105(IntPtr pBlockRecord);

	public delegate void SwigDelegateOdDbSurface_106(IntPtr pDb, bool doSubents);

	public delegate void SwigDelegateOdDbSurface_107();

	public delegate void SwigDelegateOdDbSurface_108(int status);

	public delegate void SwigDelegateOdDbSurface_109(IntPtr pWd, int ver);

	public delegate IntPtr SwigDelegateOdDbSurface_110();

	public delegate int SwigDelegateOdDbSurface_111(IntPtr xM);

	public delegate bool SwigDelegateOdDbSurface_112();

	public delegate bool SwigDelegateOdDbSurface_113();

	public delegate void SwigDelegateOdDbSurface_114(int status);

	public delegate int SwigDelegateOdDbSurface_115(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints);

	public delegate int SwigDelegateOdDbSurface_116(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insertionMat);

	public delegate bool SwigDelegateOdDbSurface_117();

	public delegate int SwigDelegateOdDbSurface_118(IntPtr gripPoints);

	public delegate int SwigDelegateOdDbSurface_119(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbSurface_120(IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags);

	public delegate int SwigDelegateOdDbSurface_121(IntPtr grips, IntPtr offset, int bitFlags);

	public delegate int SwigDelegateOdDbSurface_122(IntPtr stretchPoints);

	public delegate int SwigDelegateOdDbSurface_123(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbSurface_124(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbSurface_125(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbSurface_126(IntPtr pEnt, int intType, IntPtr points);

	public delegate int SwigDelegateOdDbSurface_127(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbSurface_128(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbSurface_129(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points);

	public delegate void SwigDelegateOdDbSurface_130(bool bDoIt, IntPtr pSubId, bool highlightAll);

	public delegate void SwigDelegateOdDbSurface_131(bool bDoIt, IntPtr pSubId);

	public delegate void SwigDelegateOdDbSurface_132(bool bDoIt);

	public delegate void SwigDelegateOdDbSurface_133();

	public delegate int SwigDelegateOdDbSurface_134();

	public delegate int SwigDelegateOdDbSurface_135(int visibility, bool doSubents);

	public delegate int SwigDelegateOdDbSurface_136(int visibility);

	public delegate int SwigDelegateOdDbSurface_137(IntPtr paths);

	public delegate int SwigDelegateOdDbSurface_138(IntPtr paths);

	public delegate int SwigDelegateOdDbSurface_139(IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags);

	public delegate int SwigDelegateOdDbSurface_140(IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags);

	public delegate int SwigDelegateOdDbSurface_141(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr viewXform, IntPtr subentPaths);

	public delegate int SwigDelegateOdDbSurface_142(IntPtr paths, IntPtr xform);

	public delegate int SwigDelegateOdDbSurface_143(IntPtr path, IntPtr clsId);

	public delegate int SwigDelegateOdDbSurface_144(IntPtr path, IntPtr extents);

	public delegate void SwigDelegateOdDbSurface_145(int status, IntPtr subentity);

	public delegate ushort SwigDelegateOdDbSurface_146();

	public delegate void SwigDelegateOdDbSurface_147(ushort numIsolines);

	public delegate ushort SwigDelegateOdDbSurface_148();

	public delegate void SwigDelegateOdDbSurface_149(ushort numIsolines);

	public delegate int SwigDelegateOdDbSurface_150(IntPtr regions);

	public delegate int SwigDelegateOdDbSurface_151(double thickness, bool bBothSides, IntPtr pSolid);

	public delegate int SwigDelegateOdDbSurface_152(double area);

	public delegate int SwigDelegateOdDbSurface_153(IntPtr pGeometry);

	public delegate IntPtr SwigDelegateOdDbSurface_154();

	public delegate IntPtr SwigDelegateOdDbSurface_155(IntPtr ent);

	public delegate IntPtr SwigDelegateOdDbSurface_156(IntPtr id);

	public delegate int SwigDelegateOdDbSurface_157(IntPtr interferenceObjects, IntPtr pEntity, uint flags);

	public delegate int SwigDelegateOdDbSurface_158(IntPtr pSurface, IntPtr pNewSurface);

	public delegate int SwigDelegateOdDbSurface_159(IntPtr pSurface, IntPtr pNewSurface);

	public delegate int SwigDelegateOdDbSurface_160(IntPtr pSolid, IntPtr pNewSurface);

	public delegate int SwigDelegateOdDbSurface_161(IntPtr pSurface, IntPtr intersectionEntities);

	public delegate int SwigDelegateOdDbSurface_162(IntPtr pSolid, IntPtr intersectionEntities);

	public delegate int SwigDelegateOdDbSurface_163(IntPtr pEntity);

	public delegate int SwigDelegateOdDbSurface_164(IntPtr sectionPlane, IntPtr sectionObjects);

	public delegate int SwigDelegateOdDbSurface_165(IntPtr slicePlane, IntPtr pNegHalfSurface, IntPtr pNewSurface);

	public delegate int SwigDelegateOdDbSurface_166(IntPtr pSlicingSurface, IntPtr pNegHalfSurface, IntPtr pNewSurface);

	public delegate int SwigDelegateOdDbSurface_167(IntPtr edgeSubentIds, IntPtr baseFaceSubentId, double baseDist, double otherDist);

	public delegate int SwigDelegateOdDbSurface_168(IntPtr edgeSubentIds, IntPtr radius, IntPtr startSetback, IntPtr endSetback);

	public delegate int SwigDelegateOdDbSurface_169(IntPtr subentId, IntPtr color);

	public delegate int SwigDelegateOdDbSurface_170(IntPtr subentId, IntPtr color);

	public delegate int SwigDelegateOdDbSurface_171(IntPtr subentId, IntPtr matId);

	public delegate int SwigDelegateOdDbSurface_172(IntPtr subentId, IntPtr matId);

	public delegate int SwigDelegateOdDbSurface_173(IntPtr subentId, IntPtr mapper);

	public delegate int SwigDelegateOdDbSurface_174(IntPtr subentId, IntPtr mapper);

	public delegate int SwigDelegateOdDbSurface_175(IntPtr nurbSurfaceArray);

	public delegate uint SwigDelegateOdDbSurface_176();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbSurface_0 swigDelegate0;

	private SwigDelegateOdDbSurface_1 swigDelegate1;

	private SwigDelegateOdDbSurface_2 swigDelegate2;

	private SwigDelegateOdDbSurface_3 swigDelegate3;

	private SwigDelegateOdDbSurface_4 swigDelegate4;

	private SwigDelegateOdDbSurface_5 swigDelegate5;

	private SwigDelegateOdDbSurface_6 swigDelegate6;

	private SwigDelegateOdDbSurface_7 swigDelegate7;

	private SwigDelegateOdDbSurface_8 swigDelegate8;

	private SwigDelegateOdDbSurface_9 swigDelegate9;

	private SwigDelegateOdDbSurface_10 swigDelegate10;

	private SwigDelegateOdDbSurface_11 swigDelegate11;

	private SwigDelegateOdDbSurface_12 swigDelegate12;

	private SwigDelegateOdDbSurface_13 swigDelegate13;

	private SwigDelegateOdDbSurface_14 swigDelegate14;

	private SwigDelegateOdDbSurface_15 swigDelegate15;

	private SwigDelegateOdDbSurface_16 swigDelegate16;

	private SwigDelegateOdDbSurface_17 swigDelegate17;

	private SwigDelegateOdDbSurface_18 swigDelegate18;

	private SwigDelegateOdDbSurface_19 swigDelegate19;

	private SwigDelegateOdDbSurface_20 swigDelegate20;

	private SwigDelegateOdDbSurface_21 swigDelegate21;

	private SwigDelegateOdDbSurface_22 swigDelegate22;

	private SwigDelegateOdDbSurface_23 swigDelegate23;

	private SwigDelegateOdDbSurface_24 swigDelegate24;

	private SwigDelegateOdDbSurface_25 swigDelegate25;

	private SwigDelegateOdDbSurface_26 swigDelegate26;

	private SwigDelegateOdDbSurface_27 swigDelegate27;

	private SwigDelegateOdDbSurface_28 swigDelegate28;

	private SwigDelegateOdDbSurface_29 swigDelegate29;

	private SwigDelegateOdDbSurface_30 swigDelegate30;

	private SwigDelegateOdDbSurface_31 swigDelegate31;

	private SwigDelegateOdDbSurface_32 swigDelegate32;

	private SwigDelegateOdDbSurface_33 swigDelegate33;

	private SwigDelegateOdDbSurface_34 swigDelegate34;

	private SwigDelegateOdDbSurface_35 swigDelegate35;

	private SwigDelegateOdDbSurface_36 swigDelegate36;

	private SwigDelegateOdDbSurface_37 swigDelegate37;

	private SwigDelegateOdDbSurface_38 swigDelegate38;

	private SwigDelegateOdDbSurface_39 swigDelegate39;

	private SwigDelegateOdDbSurface_40 swigDelegate40;

	private SwigDelegateOdDbSurface_41 swigDelegate41;

	private SwigDelegateOdDbSurface_42 swigDelegate42;

	private SwigDelegateOdDbSurface_43 swigDelegate43;

	private SwigDelegateOdDbSurface_44 swigDelegate44;

	private SwigDelegateOdDbSurface_45 swigDelegate45;

	private SwigDelegateOdDbSurface_46 swigDelegate46;

	private SwigDelegateOdDbSurface_47 swigDelegate47;

	private SwigDelegateOdDbSurface_48 swigDelegate48;

	private SwigDelegateOdDbSurface_49 swigDelegate49;

	private SwigDelegateOdDbSurface_50 swigDelegate50;

	private SwigDelegateOdDbSurface_51 swigDelegate51;

	private SwigDelegateOdDbSurface_52 swigDelegate52;

	private SwigDelegateOdDbSurface_53 swigDelegate53;

	private SwigDelegateOdDbSurface_54 swigDelegate54;

	private SwigDelegateOdDbSurface_55 swigDelegate55;

	private SwigDelegateOdDbSurface_56 swigDelegate56;

	private SwigDelegateOdDbSurface_57 swigDelegate57;

	private SwigDelegateOdDbSurface_58 swigDelegate58;

	private SwigDelegateOdDbSurface_59 swigDelegate59;

	private SwigDelegateOdDbSurface_60 swigDelegate60;

	private SwigDelegateOdDbSurface_61 swigDelegate61;

	private SwigDelegateOdDbSurface_62 swigDelegate62;

	private SwigDelegateOdDbSurface_63 swigDelegate63;

	private SwigDelegateOdDbSurface_64 swigDelegate64;

	private SwigDelegateOdDbSurface_65 swigDelegate65;

	private SwigDelegateOdDbSurface_66 swigDelegate66;

	private SwigDelegateOdDbSurface_67 swigDelegate67;

	private SwigDelegateOdDbSurface_68 swigDelegate68;

	private SwigDelegateOdDbSurface_69 swigDelegate69;

	private SwigDelegateOdDbSurface_70 swigDelegate70;

	private SwigDelegateOdDbSurface_71 swigDelegate71;

	private SwigDelegateOdDbSurface_72 swigDelegate72;

	private SwigDelegateOdDbSurface_73 swigDelegate73;

	private SwigDelegateOdDbSurface_74 swigDelegate74;

	private SwigDelegateOdDbSurface_75 swigDelegate75;

	private SwigDelegateOdDbSurface_76 swigDelegate76;

	private SwigDelegateOdDbSurface_77 swigDelegate77;

	private SwigDelegateOdDbSurface_78 swigDelegate78;

	private SwigDelegateOdDbSurface_79 swigDelegate79;

	private SwigDelegateOdDbSurface_80 swigDelegate80;

	private SwigDelegateOdDbSurface_81 swigDelegate81;

	private SwigDelegateOdDbSurface_82 swigDelegate82;

	private SwigDelegateOdDbSurface_83 swigDelegate83;

	private SwigDelegateOdDbSurface_84 swigDelegate84;

	private SwigDelegateOdDbSurface_85 swigDelegate85;

	private SwigDelegateOdDbSurface_86 swigDelegate86;

	private SwigDelegateOdDbSurface_87 swigDelegate87;

	private SwigDelegateOdDbSurface_88 swigDelegate88;

	private SwigDelegateOdDbSurface_89 swigDelegate89;

	private SwigDelegateOdDbSurface_90 swigDelegate90;

	private SwigDelegateOdDbSurface_91 swigDelegate91;

	private SwigDelegateOdDbSurface_92 swigDelegate92;

	private SwigDelegateOdDbSurface_93 swigDelegate93;

	private SwigDelegateOdDbSurface_94 swigDelegate94;

	private SwigDelegateOdDbSurface_95 swigDelegate95;

	private SwigDelegateOdDbSurface_96 swigDelegate96;

	private SwigDelegateOdDbSurface_97 swigDelegate97;

	private SwigDelegateOdDbSurface_98 swigDelegate98;

	private SwigDelegateOdDbSurface_99 swigDelegate99;

	private SwigDelegateOdDbSurface_100 swigDelegate100;

	private SwigDelegateOdDbSurface_101 swigDelegate101;

	private SwigDelegateOdDbSurface_102 swigDelegate102;

	private SwigDelegateOdDbSurface_103 swigDelegate103;

	private SwigDelegateOdDbSurface_104 swigDelegate104;

	private SwigDelegateOdDbSurface_105 swigDelegate105;

	private SwigDelegateOdDbSurface_106 swigDelegate106;

	private SwigDelegateOdDbSurface_107 swigDelegate107;

	private SwigDelegateOdDbSurface_108 swigDelegate108;

	private SwigDelegateOdDbSurface_109 swigDelegate109;

	private SwigDelegateOdDbSurface_110 swigDelegate110;

	private SwigDelegateOdDbSurface_111 swigDelegate111;

	private SwigDelegateOdDbSurface_112 swigDelegate112;

	private SwigDelegateOdDbSurface_113 swigDelegate113;

	private SwigDelegateOdDbSurface_114 swigDelegate114;

	private SwigDelegateOdDbSurface_115 swigDelegate115;

	private SwigDelegateOdDbSurface_116 swigDelegate116;

	private SwigDelegateOdDbSurface_117 swigDelegate117;

	private SwigDelegateOdDbSurface_118 swigDelegate118;

	private SwigDelegateOdDbSurface_119 swigDelegate119;

	private SwigDelegateOdDbSurface_120 swigDelegate120;

	private SwigDelegateOdDbSurface_121 swigDelegate121;

	private SwigDelegateOdDbSurface_122 swigDelegate122;

	private SwigDelegateOdDbSurface_123 swigDelegate123;

	private SwigDelegateOdDbSurface_124 swigDelegate124;

	private SwigDelegateOdDbSurface_125 swigDelegate125;

	private SwigDelegateOdDbSurface_126 swigDelegate126;

	private SwigDelegateOdDbSurface_127 swigDelegate127;

	private SwigDelegateOdDbSurface_128 swigDelegate128;

	private SwigDelegateOdDbSurface_129 swigDelegate129;

	private SwigDelegateOdDbSurface_130 swigDelegate130;

	private SwigDelegateOdDbSurface_131 swigDelegate131;

	private SwigDelegateOdDbSurface_132 swigDelegate132;

	private SwigDelegateOdDbSurface_133 swigDelegate133;

	private SwigDelegateOdDbSurface_134 swigDelegate134;

	private SwigDelegateOdDbSurface_135 swigDelegate135;

	private SwigDelegateOdDbSurface_136 swigDelegate136;

	private SwigDelegateOdDbSurface_137 swigDelegate137;

	private SwigDelegateOdDbSurface_138 swigDelegate138;

	private SwigDelegateOdDbSurface_139 swigDelegate139;

	private SwigDelegateOdDbSurface_140 swigDelegate140;

	private SwigDelegateOdDbSurface_141 swigDelegate141;

	private SwigDelegateOdDbSurface_142 swigDelegate142;

	private SwigDelegateOdDbSurface_143 swigDelegate143;

	private SwigDelegateOdDbSurface_144 swigDelegate144;

	private SwigDelegateOdDbSurface_145 swigDelegate145;

	private SwigDelegateOdDbSurface_146 swigDelegate146;

	private SwigDelegateOdDbSurface_147 swigDelegate147;

	private SwigDelegateOdDbSurface_148 swigDelegate148;

	private SwigDelegateOdDbSurface_149 swigDelegate149;

	private SwigDelegateOdDbSurface_150 swigDelegate150;

	private SwigDelegateOdDbSurface_151 swigDelegate151;

	private SwigDelegateOdDbSurface_152 swigDelegate152;

	private SwigDelegateOdDbSurface_153 swigDelegate153;

	private SwigDelegateOdDbSurface_154 swigDelegate154;

	private SwigDelegateOdDbSurface_155 swigDelegate155;

	private SwigDelegateOdDbSurface_156 swigDelegate156;

	private SwigDelegateOdDbSurface_157 swigDelegate157;

	private SwigDelegateOdDbSurface_158 swigDelegate158;

	private SwigDelegateOdDbSurface_159 swigDelegate159;

	private SwigDelegateOdDbSurface_160 swigDelegate160;

	private SwigDelegateOdDbSurface_161 swigDelegate161;

	private SwigDelegateOdDbSurface_162 swigDelegate162;

	private SwigDelegateOdDbSurface_163 swigDelegate163;

	private SwigDelegateOdDbSurface_164 swigDelegate164;

	private SwigDelegateOdDbSurface_165 swigDelegate165;

	private SwigDelegateOdDbSurface_166 swigDelegate166;

	private SwigDelegateOdDbSurface_167 swigDelegate167;

	private SwigDelegateOdDbSurface_168 swigDelegate168;

	private SwigDelegateOdDbSurface_169 swigDelegate169;

	private SwigDelegateOdDbSurface_170 swigDelegate170;

	private SwigDelegateOdDbSurface_171 swigDelegate171;

	private SwigDelegateOdDbSurface_172 swigDelegate172;

	private SwigDelegateOdDbSurface_173 swigDelegate173;

	private SwigDelegateOdDbSurface_174 swigDelegate174;

	private SwigDelegateOdDbSurface_175 swigDelegate175;

	private SwigDelegateOdDbSurface_176 swigDelegate176;

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

	private static Type[] swigMethodTypes137 = new Type[1] { typeof(OdDbFullSubentPathArray) };

	private static Type[] swigMethodTypes138 = new Type[1] { typeof(OdDbFullSubentPathArray) };

	private static Type[] swigMethodTypes139 = new Type[4]
	{
		typeof(OdDbFullSubentPathArray),
		typeof(OdDbVoidPtrArray),
		typeof(OdGeVector3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes140 = new Type[6]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdDbGripDataPtrArray),
		typeof(double),
		typeof(int),
		typeof(OdGeVector3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes141 = new Type[5]
	{
		typeof(OdDb_SubentType),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdDbFullSubentPathArray)
	};

	private static Type[] swigMethodTypes142 = new Type[2]
	{
		typeof(OdDbFullSubentPathArray),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes143 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes144 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdGeExtents3d)
	};

	private static Type[] swigMethodTypes145 = new Type[2]
	{
		typeof(OdDb_GripStat),
		typeof(OdDbFullSubentPath)
	};

	private static Type[] swigMethodTypes146 = new Type[0];

	private static Type[] swigMethodTypes147 = new Type[1] { typeof(ushort) };

	private static Type[] swigMethodTypes148 = new Type[0];

	private static Type[] swigMethodTypes149 = new Type[1] { typeof(ushort) };

	private static Type[] swigMethodTypes150 = new Type[1] { typeof(OdDbEntityPtrArray) };

	private static Type[] swigMethodTypes151 = new Type[3]
	{
		typeof(double),
		typeof(bool),
		typeof(OdDb3dSolid).MakeByRefType()
	};

	private static Type[] swigMethodTypes152 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes153 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes154 = new Type[0];

	private static Type[] swigMethodTypes155 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes156 = new Type[1] { typeof(OdDbSubentId) };

	private static Type[] swigMethodTypes157 = new Type[3]
	{
		typeof(OdDbEntityPtrArray),
		typeof(OdDbEntity),
		typeof(uint)
	};

	private static Type[] swigMethodTypes158 = new Type[2]
	{
		typeof(OdDbSurface),
		typeof(OdDbSurface).MakeByRefType()
	};

	private static Type[] swigMethodTypes159 = new Type[2]
	{
		typeof(OdDbSurface),
		typeof(OdDbSurface).MakeByRefType()
	};

	private static Type[] swigMethodTypes160 = new Type[2]
	{
		typeof(OdDb3dSolid),
		typeof(OdDbSurface).MakeByRefType()
	};

	private static Type[] swigMethodTypes161 = new Type[2]
	{
		typeof(OdDbSurface),
		typeof(OdDbEntityPtrArray)
	};

	private static Type[] swigMethodTypes162 = new Type[2]
	{
		typeof(OdDb3dSolid),
		typeof(OdDbEntityPtrArray)
	};

	private static Type[] swigMethodTypes163 = new Type[1] { typeof(OdDbEntity) };

	private static Type[] swigMethodTypes164 = new Type[2]
	{
		typeof(OdGePlane),
		typeof(OdDbEntityPtrArray)
	};

	private static Type[] swigMethodTypes165 = new Type[3]
	{
		typeof(OdGePlane),
		typeof(OdDbSurface).MakeByRefType(),
		typeof(OdDbSurface).MakeByRefType()
	};

	private static Type[] swigMethodTypes166 = new Type[3]
	{
		typeof(OdDbSurface),
		typeof(OdDbSurface).MakeByRefType(),
		typeof(OdDbSurface).MakeByRefType()
	};

	private static Type[] swigMethodTypes167 = new Type[4]
	{
		typeof(OdArray_OdDbSubentId__p_OdObjectsAllocator),
		typeof(OdDbSubentId),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes168 = new Type[4]
	{
		typeof(OdArray_OdDbSubentId__p_OdObjectsAllocator),
		typeof(OdDoubleArray),
		typeof(OdDoubleArray),
		typeof(OdDoubleArray)
	};

	private static Type[] swigMethodTypes169 = new Type[2]
	{
		typeof(OdDbSubentId),
		typeof(OdCmColor)
	};

	private static Type[] swigMethodTypes170 = new Type[2]
	{
		typeof(OdDbSubentId),
		typeof(OdCmColor)
	};

	private static Type[] swigMethodTypes171 = new Type[2]
	{
		typeof(OdDbSubentId),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes172 = new Type[2]
	{
		typeof(OdDbSubentId),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes173 = new Type[2]
	{
		typeof(OdDbSubentId),
		typeof(OdGiMapper)
	};

	private static Type[] swigMethodTypes174 = new Type[2]
	{
		typeof(OdDbSubentId),
		typeof(OdGiMapper)
	};

	private static Type[] swigMethodTypes175 = new Type[1] { typeof(OdDbNurbSurfacePtrArray) };

	private static Type[] swigMethodTypes176 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSurface(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSurface obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbSurface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbSurface cast(OdRxObject pObj)
	{
		OdDbSurface rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_isASwigExplicitOdDbSurface(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_queryXSwigExplicitOdDbSurface(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual ushort uIsolineDensity()
	{
		ushort result = (SwigDerivedClassHasMethod("uIsolineDensity", swigMethodTypes146) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_uIsolineDensitySwigExplicitOdDbSurface(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_uIsolineDensity(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setUIsolineDensity(ushort numIsolines)
	{
		if (SwigDerivedClassHasMethod("setUIsolineDensity", swigMethodTypes147))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_setUIsolineDensitySwigExplicitOdDbSurface(swigCPtr, numIsolines);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_setUIsolineDensity(swigCPtr, numIsolines);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ushort vIsolineDensity()
	{
		ushort result = (SwigDerivedClassHasMethod("vIsolineDensity", swigMethodTypes148) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_vIsolineDensitySwigExplicitOdDbSurface(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_vIsolineDensity(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVIsolineDensity(ushort numIsolines)
	{
		if (SwigDerivedClassHasMethod("setVIsolineDensity", swigMethodTypes149))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_setVIsolineDensitySwigExplicitOdDbSurface(swigCPtr, numIsolines);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_setVIsolineDensity(swigCPtr, numIsolines);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdResult createFrom(OdDbEntity pFromEntity, ref OdDbSurface pNewSurface)
	{
		IntPtr jarg = ((pNewSurface == null) ? IntPtr.Zero : getCPtr(pNewSurface).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_createFrom(OdDbEntity.getCPtr(pFromEntity), ref jarg);
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
				pNewSurface = null;
			}
			else if (jarg != intPtr)
			{
				pNewSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult convertToRegion(OdDbEntityPtrArray regions)
	{
		int result = (SwigDerivedClassHasMethod("convertToRegion", swigMethodTypes150) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_convertToRegionSwigExplicitOdDbSurface(swigCPtr, OdDbEntityPtrArray.getCPtr(regions)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_convertToRegion(swigCPtr, OdDbEntityPtrArray.getCPtr(regions)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult thicken(double thickness, bool bBothSides, ref OdDb3dSolid pSolid)
	{
		IntPtr jarg = ((pSolid == null) ? IntPtr.Zero : OdDb3dSolid.getCPtr(pSolid).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = (SwigDerivedClassHasMethod("thicken", swigMethodTypes151) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_thickenSwigExplicitOdDbSurface(swigCPtr, thickness, bBothSides, ref jarg) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_thicken(swigCPtr, thickness, bBothSides, ref jarg));
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
				pSolid = null;
			}
			else if (jarg != intPtr)
			{
				pSolid = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getArea(out double area)
	{
		int result = (SwigDerivedClassHasMethod("getArea", swigMethodTypes152) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_getAreaSwigExplicitOdDbSurface(swigCPtr, out area) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_getArea(swigCPtr, out area));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public bool isNull()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_isNull(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult acisOut(OdStreamBuf pStreamBuf, int typeVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_acisOut__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), typeVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult acisOut(OdStreamBuf pStreamBuf)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_acisOut__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult acisIn(OdStreamBuf pStreamBuf, out int pTypeVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_acisIn__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), out pTypeVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult acisIn(OdStreamBuf pStreamBuf)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_acisIn__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void brep(OdBrBrep brep)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_brep(swigCPtr, OdBrBrep.getCPtr(brep));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getFaceMesh(GeMesh_OdGeTrMesh mesh, IntPtr iFace, wrTriangulationParams triangulationParams)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_getFaceMesh(swigCPtr, GeMesh_OdGeTrMesh.getCPtr(mesh), iFace, wrTriangulationParams.getCPtr(triangulationParams));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbObject decomposeForSave(DwgVersion ver, OdDbObjectId replaceId, out bool exchangeXData)
	{
		OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(SwigDerivedClassHasMethod("decomposeForSave", swigMethodTypes50) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_decomposeForSaveSwigExplicitOdDbSurface(swigCPtr, (int)ver, OdDbObjectId.getCPtr(replaceId), out exchangeXData) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_decomposeForSave(swigCPtr, (int)ver, OdDbObjectId.getCPtr(replaceId), out exchangeXData), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void saveAs(OdGiWorldDraw pWd, DwgVersion ver)
	{
		if (SwigDerivedClassHasMethod("saveAs", swigMethodTypes109))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_saveAsSwigExplicitOdDbSurface(swigCPtr, OdGiWorldDraw.getCPtr(pWd), (int)ver);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_saveAs(swigCPtr, OdGiWorldDraw.getCPtr(pWd), (int)ver);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult setBody(IntPtr pGeometry)
	{
		int result = (SwigDerivedClassHasMethod("setBody", swigMethodTypes153) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_setBodySwigExplicitOdDbSurface(swigCPtr, pGeometry) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_setBody(swigCPtr, pGeometry));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual IntPtr body()
	{
		IntPtr result = (SwigDerivedClassHasMethod("body", swigMethodTypes154) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_bodySwigExplicitOdDbSurface(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_body(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_dwgInFieldsSwigExplicitOdDbSurface(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_dwgOutFieldsSwigExplicitOdDbSurface(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_dxfInFieldsSwigExplicitOdDbSurface(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_dxfOutFieldsSwigExplicitOdDbSurface(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbSubentId internalSubentId(IntPtr ent)
	{
		OdDbSubentId result = new OdDbSubentId(SwigDerivedClassHasMethod("internalSubentId", swigMethodTypes155) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_internalSubentIdSwigExplicitOdDbSurface(swigCPtr, ent) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_internalSubentId(swigCPtr, ent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual IntPtr internalSubentPtr(OdDbSubentId id)
	{
		IntPtr result = (SwigDerivedClassHasMethod("internalSubentPtr", swigMethodTypes156) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_internalSubentPtrSwigExplicitOdDbSurface(swigCPtr, OdDbSubentId.getCPtr(id)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_internalSubentPtr(swigCPtr, OdDbSubentId.getCPtr(id)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult createInterferenceObjects(OdDbEntityPtrArray interferenceObjects, OdDbEntity pEntity, uint flags)
	{
		int result = (SwigDerivedClassHasMethod("createInterferenceObjects", swigMethodTypes157) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_createInterferenceObjectsSwigExplicitOdDbSurface(swigCPtr, OdDbEntityPtrArray.getCPtr(interferenceObjects), OdDbEntity.getCPtr(pEntity), flags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_createInterferenceObjects(swigCPtr, OdDbEntityPtrArray.getCPtr(interferenceObjects), OdDbEntity.getCPtr(pEntity), flags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult booleanUnion(OdDbSurface pSurface, ref OdDbSurface pNewSurface)
	{
		IntPtr jarg = ((pNewSurface == null) ? IntPtr.Zero : getCPtr(pNewSurface).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = (SwigDerivedClassHasMethod("booleanUnion", swigMethodTypes158) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_booleanUnionSwigExplicitOdDbSurface(swigCPtr, getCPtr(pSurface), ref jarg) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_booleanUnion(swigCPtr, getCPtr(pSurface), ref jarg));
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
				pNewSurface = null;
			}
			else if (jarg != intPtr)
			{
				pNewSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult booleanSubtract(OdDbSurface pSurface, ref OdDbSurface pNewSurface)
	{
		IntPtr jarg = ((pNewSurface == null) ? IntPtr.Zero : getCPtr(pNewSurface).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = (SwigDerivedClassHasMethod("booleanSubtract", swigMethodTypes159) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_booleanSubtractSwigExplicitOdDbSurface__SWIG_0(swigCPtr, getCPtr(pSurface), ref jarg) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_booleanSubtract__SWIG_0(swigCPtr, getCPtr(pSurface), ref jarg));
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
				pNewSurface = null;
			}
			else if (jarg != intPtr)
			{
				pNewSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult booleanSubtract(OdDb3dSolid pSolid, ref OdDbSurface pNewSurface)
	{
		IntPtr jarg = ((pNewSurface == null) ? IntPtr.Zero : getCPtr(pNewSurface).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = (SwigDerivedClassHasMethod("booleanSubtract", swigMethodTypes160) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_booleanSubtractSwigExplicitOdDbSurface__SWIG_1(swigCPtr, OdDb3dSolid.getCPtr(pSolid), ref jarg) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_booleanSubtract__SWIG_1(swigCPtr, OdDb3dSolid.getCPtr(pSolid), ref jarg));
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
				pNewSurface = null;
			}
			else if (jarg != intPtr)
			{
				pNewSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult booleanIntersect(OdDbSurface pSurface, OdDbEntityPtrArray intersectionEntities)
	{
		int result = (SwigDerivedClassHasMethod("booleanIntersect", swigMethodTypes161) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_booleanIntersectSwigExplicitOdDbSurface__SWIG_0(swigCPtr, getCPtr(pSurface), OdDbEntityPtrArray.getCPtr(intersectionEntities)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_booleanIntersect__SWIG_0(swigCPtr, getCPtr(pSurface), OdDbEntityPtrArray.getCPtr(intersectionEntities)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult booleanIntersect(OdDb3dSolid pSolid, OdDbEntityPtrArray intersectionEntities)
	{
		int result = (SwigDerivedClassHasMethod("booleanIntersect", swigMethodTypes162) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_booleanIntersectSwigExplicitOdDbSurface__SWIG_1(swigCPtr, OdDb3dSolid.getCPtr(pSolid), OdDbEntityPtrArray.getCPtr(intersectionEntities)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_booleanIntersect__SWIG_1(swigCPtr, OdDb3dSolid.getCPtr(pSolid), OdDbEntityPtrArray.getCPtr(intersectionEntities)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult imprintEntity(OdDbEntity pEntity)
	{
		int result = (SwigDerivedClassHasMethod("imprintEntity", swigMethodTypes163) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_imprintEntitySwigExplicitOdDbSurface(swigCPtr, OdDbEntity.getCPtr(pEntity)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_imprintEntity(swigCPtr, OdDbEntity.getCPtr(pEntity)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSectionObjects(OdGePlane sectionPlane, OdDbEntityPtrArray sectionObjects)
	{
		int result = (SwigDerivedClassHasMethod("createSectionObjects", swigMethodTypes164) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_createSectionObjectsSwigExplicitOdDbSurface(swigCPtr, OdGePlane.getCPtr(sectionPlane), OdDbEntityPtrArray.getCPtr(sectionObjects)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_createSectionObjects(swigCPtr, OdGePlane.getCPtr(sectionPlane), OdDbEntityPtrArray.getCPtr(sectionObjects)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult sliceByPlane(OdGePlane slicePlane, ref OdDbSurface pNegHalfSurface, ref OdDbSurface pNewSurface)
	{
		IntPtr jarg = ((pNegHalfSurface == null) ? IntPtr.Zero : getCPtr(pNegHalfSurface).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((pNewSurface == null) ? IntPtr.Zero : getCPtr(pNewSurface).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			int result = (SwigDerivedClassHasMethod("sliceByPlane", swigMethodTypes165) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_sliceByPlaneSwigExplicitOdDbSurface(swigCPtr, OdGePlane.getCPtr(slicePlane), ref jarg, ref jarg2) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_sliceByPlane(swigCPtr, OdGePlane.getCPtr(slicePlane), ref jarg, ref jarg2));
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
				pNegHalfSurface = null;
			}
			else if (jarg != intPtr)
			{
				pNegHalfSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				pNewSurface = null;
			}
			else if (jarg2 != intPtr2)
			{
				pNewSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult sliceBySurface(OdDbSurface pSlicingSurface, ref OdDbSurface pNegHalfSurface, ref OdDbSurface pNewSurface)
	{
		IntPtr jarg = ((pNegHalfSurface == null) ? IntPtr.Zero : getCPtr(pNegHalfSurface).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((pNewSurface == null) ? IntPtr.Zero : getCPtr(pNewSurface).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			int result = (SwigDerivedClassHasMethod("sliceBySurface", swigMethodTypes166) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_sliceBySurfaceSwigExplicitOdDbSurface(swigCPtr, getCPtr(pSlicingSurface), ref jarg, ref jarg2) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_sliceBySurface(swigCPtr, getCPtr(pSlicingSurface), ref jarg, ref jarg2));
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
				pNegHalfSurface = null;
			}
			else if (jarg != intPtr)
			{
				pNegHalfSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				pNewSurface = null;
			}
			else if (jarg2 != intPtr2)
			{
				pNewSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult chamferEdges(OdArray_OdDbSubentId__p_OdObjectsAllocator edgeSubentIds, OdDbSubentId baseFaceSubentId, double baseDist, double otherDist)
	{
		int result = (SwigDerivedClassHasMethod("chamferEdges", swigMethodTypes167) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_chamferEdgesSwigExplicitOdDbSurface(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(edgeSubentIds), OdDbSubentId.getCPtr(baseFaceSubentId), baseDist, otherDist) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_chamferEdges(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(edgeSubentIds), OdDbSubentId.getCPtr(baseFaceSubentId), baseDist, otherDist));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult filletEdges(OdArray_OdDbSubentId__p_OdObjectsAllocator edgeSubentIds, OdDoubleArray radius, OdDoubleArray startSetback, OdDoubleArray endSetback)
	{
		int result = (SwigDerivedClassHasMethod("filletEdges", swigMethodTypes168) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_filletEdgesSwigExplicitOdDbSurface(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(edgeSubentIds), OdDoubleArray.getCPtr(radius).Handle, OdDoubleArray.getCPtr(startSetback).Handle, OdDoubleArray.getCPtr(endSetback).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_filletEdges(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(edgeSubentIds), OdDoubleArray.getCPtr(radius).Handle, OdDoubleArray.getCPtr(startSetback).Handle, OdDoubleArray.getCPtr(endSetback).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setSubentColor(OdDbSubentId subentId, OdCmColor color)
	{
		int result = (SwigDerivedClassHasMethod("setSubentColor", swigMethodTypes169) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_setSubentColorSwigExplicitOdDbSurface(swigCPtr, OdDbSubentId.getCPtr(subentId), OdCmColor.getCPtr(color)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_setSubentColor(swigCPtr, OdDbSubentId.getCPtr(subentId), OdCmColor.getCPtr(color)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentColor(OdDbSubentId subentId, OdCmColor color)
	{
		int result = (SwigDerivedClassHasMethod("getSubentColor", swigMethodTypes170) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_getSubentColorSwigExplicitOdDbSurface(swigCPtr, OdDbSubentId.getCPtr(subentId), OdCmColor.getCPtr(color)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_getSubentColor(swigCPtr, OdDbSubentId.getCPtr(subentId), OdCmColor.getCPtr(color)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setSubentMaterial(OdDbSubentId subentId, OdDbObjectId matId)
	{
		int result = (SwigDerivedClassHasMethod("setSubentMaterial", swigMethodTypes171) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_setSubentMaterialSwigExplicitOdDbSurface(swigCPtr, OdDbSubentId.getCPtr(subentId), OdDbObjectId.getCPtr(matId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_setSubentMaterial(swigCPtr, OdDbSubentId.getCPtr(subentId), OdDbObjectId.getCPtr(matId)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentMaterial(OdDbSubentId subentId, OdDbObjectId matId)
	{
		int result = (SwigDerivedClassHasMethod("getSubentMaterial", swigMethodTypes172) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_getSubentMaterialSwigExplicitOdDbSurface(swigCPtr, OdDbSubentId.getCPtr(subentId), OdDbObjectId.getCPtr(matId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_getSubentMaterial(swigCPtr, OdDbSubentId.getCPtr(subentId), OdDbObjectId.getCPtr(matId)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setSubentMaterialMapper(OdDbSubentId subentId, OdGiMapper mapper)
	{
		int result = (SwigDerivedClassHasMethod("setSubentMaterialMapper", swigMethodTypes173) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_setSubentMaterialMapperSwigExplicitOdDbSurface(swigCPtr, OdDbSubentId.getCPtr(subentId), OdGiMapper.getCPtr(mapper)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_setSubentMaterialMapper(swigCPtr, OdDbSubentId.getCPtr(subentId), OdGiMapper.getCPtr(mapper)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentMaterialMapper(OdDbSubentId subentId, OdGiMapper mapper)
	{
		int result = (SwigDerivedClassHasMethod("getSubentMaterialMapper", swigMethodTypes174) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_getSubentMaterialMapperSwigExplicitOdDbSurface(swigCPtr, OdDbSubentId.getCPtr(subentId), OdGiMapper.getCPtr(mapper)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_getSubentMaterialMapper(swigCPtr, OdDbSubentId.getCPtr(subentId), OdGiMapper.getCPtr(mapper)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public new virtual OdResult subGetSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d viewXform, OdDbFullSubentPathArray subentPaths)
	{
		int result = (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes141) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_subGetSubentPathsAtGsMarkerSwigExplicitOdDbSurface(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(viewXform), OdDbFullSubentPathArray.getCPtr(subentPaths)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_subGetSubentPathsAtGsMarker(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(viewXform), OdDbFullSubentPathArray.getCPtr(subentPaths)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult convertToNurbSurface(OdDbNurbSurfacePtrArray nurbSurfaceArray)
	{
		int result = (SwigDerivedClassHasMethod("convertToNurbSurface", swigMethodTypes175) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_convertToNurbSurfaceSwigExplicitOdDbSurface(swigCPtr, OdDbNurbSurfacePtrArray.getCPtr(nurbSurfaceArray)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_convertToNurbSurface(swigCPtr, OdDbNurbSurfacePtrArray.getCPtr(nurbSurfaceArray)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult trimSurface(OdDbObjectId blankSurfaceId, OdDbObjectIdArray toolIds, OdDbObjectIdArray toolCurveIds, OdGeVector3dArray projVectors, OdGePoint3d pickPoint, OdGeVector3d viewVector, bool bAutoExtend, bool bAssociativeEnabled)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_trimSurface(OdDbObjectId.getCPtr(blankSurfaceId), OdDbObjectIdArray.getCPtr(toolIds), OdDbObjectIdArray.getCPtr(toolCurveIds), OdGeVector3dArray.getCPtr(projVectors).Handle, OdGePoint3d.getCPtr(pickPoint), OdGeVector3d.getCPtr(viewVector), bAutoExtend, bAssociativeEnabled);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult projectOnToSurface(OdDbEntity pEntityToProject, OdGeVector3d projectionDirection, OdDbEntityPtrArray projectedEntities)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_projectOnToSurface(swigCPtr, OdDbEntity.getCPtr(pEntityToProject), OdGeVector3d.getCPtr(projectionDirection), OdDbEntityPtrArray.getCPtr(projectedEntities));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getPerimeter(out double arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_getPerimeter(swigCPtr, out arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult rayTest(OdGePoint3d rayBasePoint, OdGeVector3d rayDir, double rayRadius, OdArray_OdDbSubentId_OdObjectsAllocator subEntIds, OdDoubleArray parameters)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_rayTest(swigCPtr, OdGePoint3d.getCPtr(rayBasePoint), OdGeVector3d.getCPtr(rayDir), rayRadius, OdArray_OdDbSubentId_OdObjectsAllocator.getCPtr(subEntIds), OdDoubleArray.getCPtr(parameters).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult createOffsetSurface(OdDbEntity pInputSurface, double dOffsetDistance, ref OdDbEntity offsetSurface)
	{
		IntPtr jarg = ((offsetSurface == null) ? IntPtr.Zero : OdDbEntity.getCPtr(offsetSurface).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_createOffsetSurface__SWIG_0(OdDbEntity.getCPtr(pInputSurface), dOffsetDistance, ref jarg);
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
				offsetSurface = null;
			}
			else if (jarg != intPtr)
			{
				offsetSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdResult createOffsetSurface(OdDbEntity pInputSurface, double dOffsetDistance, bool bAssociativeEnabled, OdDbObjectId offsetSurfaceId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_createOffsetSurface__SWIG_1(OdDbEntity.getCPtr(pInputSurface), dOffsetDistance, bAssociativeEnabled, OdDbObjectId.getCPtr(offsetSurfaceId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult createFilletSurface(OdDbObjectId surfId1, OdGePoint3d pickPt1, OdDbObjectId surfId2, OdGePoint3d pickPt2, double dRadius, OdDb_FilletTrimMode trimMode, OdGeVector3d projDir, ref OdDbSurface filletSurface)
	{
		IntPtr jarg = ((filletSurface == null) ? IntPtr.Zero : getCPtr(filletSurface).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_createFilletSurface__SWIG_0(OdDbObjectId.getCPtr(surfId1), OdGePoint3d.getCPtr(pickPt1), OdDbObjectId.getCPtr(surfId2), OdGePoint3d.getCPtr(pickPt2), dRadius, (int)trimMode, OdGeVector3d.getCPtr(projDir), ref jarg);
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
				filletSurface = null;
			}
			else if (jarg != intPtr)
			{
				filletSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdResult createFilletSurface(OdDbObjectId surfId1, OdGePoint3d pickPt1, OdDbObjectId surfId2, OdGePoint3d pickPt2, double dRadius, OdDb_FilletTrimMode trimMode, OdGeVector3d projDir, bool bAssociativeEnabled, OdDbObjectId filletSurfaceId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_createFilletSurface__SWIG_1(OdDbObjectId.getCPtr(surfId1), OdGePoint3d.getCPtr(pickPt1), OdDbObjectId.getCPtr(surfId2), OdGePoint3d.getCPtr(pickPt2), dRadius, (int)trimMode, OdGeVector3d.getCPtr(projDir), bAssociativeEnabled, OdDbObjectId.getCPtr(filletSurfaceId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult createExtendSurface(OdDbObjectId sourceSurface, OdArray_OdDbSubentId_OdObjectsAllocator edgesId, double dExtDist, OdDbSurface_EdgeExtensionType extOption, bool bAssociativeEnabled, OdDbObjectId newExtendSurfaceId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_createExtendSurface(OdDbObjectId.getCPtr(sourceSurface), OdArray_OdDbSubentId_OdObjectsAllocator.getCPtr(edgesId), dExtDist, (int)extOption, bAssociativeEnabled, OdDbObjectId.getCPtr(newExtendSurfaceId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult createNetworkSurface(OdArray_OdSmartPtr_OdDb3dProfile_OdObjectsAllocator uProfiles, OdArray_OdSmartPtr_OdDb3dProfile_OdObjectsAllocator vProfiles, ref OdDbSurface newSurface)
	{
		IntPtr jarg = ((newSurface == null) ? IntPtr.Zero : getCPtr(newSurface).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_createNetworkSurface(OdArray_OdSmartPtr_OdDb3dProfile_OdObjectsAllocator.getCPtr(uProfiles), OdArray_OdSmartPtr_OdDb3dProfile_OdObjectsAllocator.getCPtr(vProfiles), ref jarg);
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
				newSurface = null;
			}
			else if (jarg != intPtr)
			{
				newSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdResult extendEdges(OdDbFullSubentPathArray edgesId, double dExtDist, OdDbSurface_EdgeExtensionType extOption, bool bAssociativeEnabled)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_extendEdges(swigCPtr, OdDbFullSubentPathArray.getCPtr(edgesId), dExtDist, (int)extOption, bAssociativeEnabled);
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_subHandOverToSwigExplicitOdDbSurface(swigCPtr, OdDbObject.getCPtr(pNewObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_subHandOverTo(swigCPtr, OdDbObject.getCPtr(pNewObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void subClose()
	{
		if (SwigDerivedClassHasMethod("subClose", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_subCloseSwigExplicitOdDbSurface(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_subClose(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint numChanges()
	{
		uint result = (SwigDerivedClassHasMethod("numChanges", swigMethodTypes176) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_numChangesSwigExplicitOdDbSurface(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_numChanges(swigCPtr));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_copyFromSwigExplicitOdDbSurface(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult SubExplode(OdRxObjectPtrArray entitySet)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_SubExplode(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubTransformBy(OdGeMatrix3d xfm)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_SubTransformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override bool SubWorldDraw(OdGiWorldDraw pWd)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_SubWorldDraw(swigCPtr, OdGiWorldDraw.getCPtr(pWd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void SubViewportDraw(OdGiViewportDraw pVd)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_SubViewportDraw(swigCPtr, OdGiViewportDraw.getCPtr(pVd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult SubGetClassID(IntPtr pClsid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_SubGetClassID(swigCPtr, pClsid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbEntity SubSubentPtr(OdDbFullSubentPath id)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_SubSubentPtr(swigCPtr, OdDbFullSubentPath.getCPtr(id)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult SubGetGsMarkersAtSubentPath(OdDbFullSubentPath subPath, OdGsMarkerArray gsMarkers)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_SubGetGsMarkersAtSubentPath(swigCPtr, OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubGetSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d viewXform, OdDbFullSubentPathArray subentPaths, OdDbObjectIdArray pEntAndInsertStack)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_SubGetSubentPathsAtGsMarker(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(viewXform), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(pEntAndInsertStack));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubGetTransformedCopy(OdGeMatrix3d mat, ref OdDbEntity pCopy)
	{
		IntPtr jarg = ((pCopy == null) ? IntPtr.Zero : OdDbEntity.getCPtr(pCopy).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_SubGetTransformedCopy(swigCPtr, OdGeMatrix3d.getCPtr(mat), ref jarg);
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

	public override uint SubSetAttributes(OdGiDrawableTraits pTraits)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_SubSetAttributes(swigCPtr, OdGiDrawableTraits.getCPtr(pTraits));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult SubGetGeomExtents(OdGeExtents3d extents)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_SubGetGeomExtents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbSurface createObject()
	{
		OdDbSurface rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_createObject(), bOwn: true, bTryAddToTransaction: true);
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
			swigDelegate50 = SwigDirectorMethoddecomposeForSave;
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
		if (SwigDerivedClassHasMethod("subDeleteSubentPaths", swigMethodTypes137))
		{
			swigDelegate137 = SwigDirectorMethodsubDeleteSubentPaths;
		}
		if (SwigDerivedClassHasMethod("subAddSubentPaths", swigMethodTypes138))
		{
			swigDelegate138 = SwigDirectorMethodsubAddSubentPaths;
		}
		if (SwigDerivedClassHasMethod("subMoveGripPointsAtSubentPaths", swigMethodTypes139))
		{
			swigDelegate139 = SwigDirectorMethodsubMoveGripPointsAtSubentPaths;
		}
		if (SwigDerivedClassHasMethod("subGetGripPointsAtSubentPath", swigMethodTypes140))
		{
			swigDelegate140 = SwigDirectorMethodsubGetGripPointsAtSubentPath;
		}
		if (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes141))
		{
			swigDelegate141 = SwigDirectorMethodsubGetSubentPathsAtGsMarker;
		}
		if (SwigDerivedClassHasMethod("subTransformSubentPathsBy", swigMethodTypes142))
		{
			swigDelegate142 = SwigDirectorMethodsubTransformSubentPathsBy;
		}
		if (SwigDerivedClassHasMethod("subGetSubentClassId", swigMethodTypes143))
		{
			swigDelegate143 = SwigDirectorMethodsubGetSubentClassId;
		}
		if (SwigDerivedClassHasMethod("subGetSubentPathGeomExtents", swigMethodTypes144))
		{
			swigDelegate144 = SwigDirectorMethodsubGetSubentPathGeomExtents;
		}
		if (SwigDerivedClassHasMethod("subSubentGripStatus", swigMethodTypes145))
		{
			swigDelegate145 = SwigDirectorMethodsubSubentGripStatus;
		}
		if (SwigDerivedClassHasMethod("uIsolineDensity", swigMethodTypes146))
		{
			swigDelegate146 = SwigDirectorMethoduIsolineDensity;
		}
		if (SwigDerivedClassHasMethod("setUIsolineDensity", swigMethodTypes147))
		{
			swigDelegate147 = SwigDirectorMethodsetUIsolineDensity;
		}
		if (SwigDerivedClassHasMethod("vIsolineDensity", swigMethodTypes148))
		{
			swigDelegate148 = SwigDirectorMethodvIsolineDensity;
		}
		if (SwigDerivedClassHasMethod("setVIsolineDensity", swigMethodTypes149))
		{
			swigDelegate149 = SwigDirectorMethodsetVIsolineDensity;
		}
		if (SwigDerivedClassHasMethod("convertToRegion", swigMethodTypes150))
		{
			swigDelegate150 = SwigDirectorMethodconvertToRegion;
		}
		if (SwigDerivedClassHasMethod("thicken", swigMethodTypes151))
		{
			swigDelegate151 = SwigDirectorMethodthicken;
		}
		if (SwigDerivedClassHasMethod("getArea", swigMethodTypes152))
		{
			swigDelegate152 = SwigDirectorMethodgetArea;
		}
		if (SwigDerivedClassHasMethod("setBody", swigMethodTypes153))
		{
			swigDelegate153 = SwigDirectorMethodsetBody;
		}
		if (SwigDerivedClassHasMethod("body", swigMethodTypes154))
		{
			swigDelegate154 = SwigDirectorMethodbody;
		}
		if (SwigDerivedClassHasMethod("internalSubentId", swigMethodTypes155))
		{
			swigDelegate155 = SwigDirectorMethodinternalSubentId;
		}
		if (SwigDerivedClassHasMethod("internalSubentPtr", swigMethodTypes156))
		{
			swigDelegate156 = SwigDirectorMethodinternalSubentPtr;
		}
		if (SwigDerivedClassHasMethod("createInterferenceObjects", swigMethodTypes157))
		{
			swigDelegate157 = SwigDirectorMethodcreateInterferenceObjects;
		}
		if (SwigDerivedClassHasMethod("booleanUnion", swigMethodTypes158))
		{
			swigDelegate158 = SwigDirectorMethodbooleanUnion;
		}
		if (SwigDerivedClassHasMethod("booleanSubtract", swigMethodTypes159))
		{
			swigDelegate159 = SwigDirectorMethodbooleanSubtract__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("booleanSubtract", swigMethodTypes160))
		{
			swigDelegate160 = SwigDirectorMethodbooleanSubtract__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("booleanIntersect", swigMethodTypes161))
		{
			swigDelegate161 = SwigDirectorMethodbooleanIntersect__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("booleanIntersect", swigMethodTypes162))
		{
			swigDelegate162 = SwigDirectorMethodbooleanIntersect__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("imprintEntity", swigMethodTypes163))
		{
			swigDelegate163 = SwigDirectorMethodimprintEntity;
		}
		if (SwigDerivedClassHasMethod("createSectionObjects", swigMethodTypes164))
		{
			swigDelegate164 = SwigDirectorMethodcreateSectionObjects;
		}
		if (SwigDerivedClassHasMethod("sliceByPlane", swigMethodTypes165))
		{
			swigDelegate165 = SwigDirectorMethodsliceByPlane;
		}
		if (SwigDerivedClassHasMethod("sliceBySurface", swigMethodTypes166))
		{
			swigDelegate166 = SwigDirectorMethodsliceBySurface;
		}
		if (SwigDerivedClassHasMethod("chamferEdges", swigMethodTypes167))
		{
			swigDelegate167 = SwigDirectorMethodchamferEdges;
		}
		if (SwigDerivedClassHasMethod("filletEdges", swigMethodTypes168))
		{
			swigDelegate168 = SwigDirectorMethodfilletEdges;
		}
		if (SwigDerivedClassHasMethod("setSubentColor", swigMethodTypes169))
		{
			swigDelegate169 = SwigDirectorMethodsetSubentColor;
		}
		if (SwigDerivedClassHasMethod("getSubentColor", swigMethodTypes170))
		{
			swigDelegate170 = SwigDirectorMethodgetSubentColor;
		}
		if (SwigDerivedClassHasMethod("setSubentMaterial", swigMethodTypes171))
		{
			swigDelegate171 = SwigDirectorMethodsetSubentMaterial;
		}
		if (SwigDerivedClassHasMethod("getSubentMaterial", swigMethodTypes172))
		{
			swigDelegate172 = SwigDirectorMethodgetSubentMaterial;
		}
		if (SwigDerivedClassHasMethod("setSubentMaterialMapper", swigMethodTypes173))
		{
			swigDelegate173 = SwigDirectorMethodsetSubentMaterialMapper;
		}
		if (SwigDerivedClassHasMethod("getSubentMaterialMapper", swigMethodTypes174))
		{
			swigDelegate174 = SwigDirectorMethodgetSubentMaterialMapper;
		}
		if (SwigDerivedClassHasMethod("convertToNurbSurface", swigMethodTypes175))
		{
			swigDelegate175 = SwigDirectorMethodconvertToNurbSurface;
		}
		if (SwigDerivedClassHasMethod("numChanges", swigMethodTypes176))
		{
			swigDelegate176 = SwigDirectorMethodnumChanges;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSurface_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125, swigDelegate126, swigDelegate127, swigDelegate128, swigDelegate129, swigDelegate130, swigDelegate131, swigDelegate132, swigDelegate133, swigDelegate134, swigDelegate135, swigDelegate136, swigDelegate137, swigDelegate138, swigDelegate139, swigDelegate140, swigDelegate141, swigDelegate142, swigDelegate143, swigDelegate144, swigDelegate145, swigDelegate146, swigDelegate147, swigDelegate148, swigDelegate149, swigDelegate150, swigDelegate151, swigDelegate152, swigDelegate153, swigDelegate154, swigDelegate155, swigDelegate156, swigDelegate157, swigDelegate158, swigDelegate159, swigDelegate160, swigDelegate161, swigDelegate162, swigDelegate163, swigDelegate164, swigDelegate165, swigDelegate166, swigDelegate167, swigDelegate168, swigDelegate169, swigDelegate170, swigDelegate171, swigDelegate172, swigDelegate173, swigDelegate174, swigDelegate175, swigDelegate176);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbSurface));
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

	private IntPtr SwigDirectorMethoddecomposeForSave(int ver, IntPtr replaceId, bool exchangeXData)
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

	private int SwigDirectorMethodsubGetSubentPathsAtGsMarker(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr viewXform, IntPtr subentPaths)
	{
		return (int)subGetSubentPathsAtGsMarker((OdDb_SubentType)type, gsMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGeMatrix3d(viewXform, cMemoryOwn: false), new OdDbFullSubentPathArray(subentPaths, cMemoryOwn: false));
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

	private ushort SwigDirectorMethoduIsolineDensity()
	{
		return uIsolineDensity();
	}

	private void SwigDirectorMethodsetUIsolineDensity(ushort numIsolines)
	{
		try
		{
			setUIsolineDensity(numIsolines);
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

	private ushort SwigDirectorMethodvIsolineDensity()
	{
		return vIsolineDensity();
	}

	private void SwigDirectorMethodsetVIsolineDensity(ushort numIsolines)
	{
		try
		{
			setVIsolineDensity(numIsolines);
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

	private int SwigDirectorMethodconvertToRegion(IntPtr regions)
	{
		return (int)convertToRegion(new OdDbEntityPtrArray(regions, cMemoryOwn: false));
	}

	private int SwigDirectorMethodthicken(double thickness, bool bBothSides, IntPtr pSolid)
	{
		OdSwigDirectorHelper.director_UnpackData(pSolid, out var pOriginalObject, out var pFunction);
		OdDb3dSolid pSolid2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)thicken(thickness, bBothSides, ref pSolid2);
		}
		finally
		{
			IntPtr intPtr = OdDb3dSolid.getCPtr(pSolid2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pSolid);
		}
	}

	private int SwigDirectorMethodgetArea(double area)
	{
		return (int)getArea(out area);
	}

	private int SwigDirectorMethodsetBody(IntPtr pGeometry)
	{
		return (int)setBody(pGeometry);
	}

	private IntPtr SwigDirectorMethodbody()
	{
		return body();
	}

	private IntPtr SwigDirectorMethodinternalSubentId(IntPtr ent)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbSubentId.getCPtr(internalSubentId(ent)).Handle;
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

	private IntPtr SwigDirectorMethodinternalSubentPtr(IntPtr id)
	{
		return internalSubentPtr(new OdDbSubentId(id, cMemoryOwn: false));
	}

	private int SwigDirectorMethodcreateInterferenceObjects(IntPtr interferenceObjects, IntPtr pEntity, uint flags)
	{
		return (int)createInterferenceObjects(new OdDbEntityPtrArray(interferenceObjects, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: true, bTryAddToTransaction: false), flags);
	}

	private int SwigDirectorMethodbooleanUnion(IntPtr pSurface, IntPtr pNewSurface)
	{
		OdSwigDirectorHelper.director_UnpackData(pNewSurface, out var pOriginalObject, out var pFunction);
		OdDbSurface pNewSurface2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)booleanUnion(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(pSurface, bOwn: false, bTryAddToTransaction: false), ref pNewSurface2);
		}
		finally
		{
			IntPtr intPtr = getCPtr(pNewSurface2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pNewSurface);
		}
	}

	private int SwigDirectorMethodbooleanSubtract__SWIG_0(IntPtr pSurface, IntPtr pNewSurface)
	{
		OdSwigDirectorHelper.director_UnpackData(pNewSurface, out var pOriginalObject, out var pFunction);
		OdDbSurface pNewSurface2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)booleanSubtract(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(pSurface, bOwn: false, bTryAddToTransaction: false), ref pNewSurface2);
		}
		finally
		{
			IntPtr intPtr = getCPtr(pNewSurface2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pNewSurface);
		}
	}

	private int SwigDirectorMethodbooleanSubtract__SWIG_1(IntPtr pSolid, IntPtr pNewSurface)
	{
		OdSwigDirectorHelper.director_UnpackData(pNewSurface, out var pOriginalObject, out var pFunction);
		OdDbSurface pNewSurface2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)booleanSubtract(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), ref pNewSurface2);
		}
		finally
		{
			IntPtr intPtr = getCPtr(pNewSurface2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pNewSurface);
		}
	}

	private int SwigDirectorMethodbooleanIntersect__SWIG_0(IntPtr pSurface, IntPtr intersectionEntities)
	{
		return (int)booleanIntersect(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(pSurface, bOwn: false, bTryAddToTransaction: false), new OdDbEntityPtrArray(intersectionEntities, cMemoryOwn: false));
	}

	private int SwigDirectorMethodbooleanIntersect__SWIG_1(IntPtr pSolid, IntPtr intersectionEntities)
	{
		return (int)booleanIntersect(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), new OdDbEntityPtrArray(intersectionEntities, cMemoryOwn: false));
	}

	private int SwigDirectorMethodimprintEntity(IntPtr pEntity)
	{
		return (int)imprintEntity(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodcreateSectionObjects(IntPtr sectionPlane, IntPtr sectionObjects)
	{
		return (int)createSectionObjects(new OdGePlane(sectionPlane, cMemoryOwn: false), new OdDbEntityPtrArray(sectionObjects, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsliceByPlane(IntPtr slicePlane, IntPtr pNegHalfSurface, IntPtr pNewSurface)
	{
		OdSwigDirectorHelper.director_UnpackData(pNegHalfSurface, out var pOriginalObject, out var pFunction);
		OdDbSurface pNegHalfSurface2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		OdSwigDirectorHelper.director_UnpackData(pNewSurface, out var pOriginalObject2, out var pFunction2);
		OdDbSurface pNewSurface2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(pOriginalObject2, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)sliceByPlane(new OdGePlane(slicePlane, cMemoryOwn: false), ref pNegHalfSurface2, ref pNewSurface2);
		}
		finally
		{
			IntPtr intPtr = getCPtr(pNegHalfSurface2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pNegHalfSurface);
			IntPtr intPtr2 = getCPtr(pNewSurface2).Handle;
			if (pOriginalObject2 != intPtr2)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction2, intPtr2);
			}
			OdSwigDirectorHelper.director_freeData(pNewSurface);
		}
	}

	private int SwigDirectorMethodsliceBySurface(IntPtr pSlicingSurface, IntPtr pNegHalfSurface, IntPtr pNewSurface)
	{
		OdSwigDirectorHelper.director_UnpackData(pNegHalfSurface, out var pOriginalObject, out var pFunction);
		OdDbSurface pNegHalfSurface2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		OdSwigDirectorHelper.director_UnpackData(pNewSurface, out var pOriginalObject2, out var pFunction2);
		OdDbSurface pNewSurface2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(pOriginalObject2, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)sliceBySurface(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(pSlicingSurface, bOwn: true, bTryAddToTransaction: false), ref pNegHalfSurface2, ref pNewSurface2);
		}
		finally
		{
			IntPtr intPtr = getCPtr(pNegHalfSurface2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pNegHalfSurface);
			IntPtr intPtr2 = getCPtr(pNewSurface2).Handle;
			if (pOriginalObject2 != intPtr2)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction2, intPtr2);
			}
			OdSwigDirectorHelper.director_freeData(pNewSurface);
		}
	}

	private int SwigDirectorMethodchamferEdges(IntPtr edgeSubentIds, IntPtr baseFaceSubentId, double baseDist, double otherDist)
	{
		return (int)chamferEdges(new OdArray_OdDbSubentId__p_OdObjectsAllocator(edgeSubentIds, cMemoryOwn: false), new OdDbSubentId(baseFaceSubentId, cMemoryOwn: false), baseDist, otherDist);
	}

	private int SwigDirectorMethodfilletEdges(IntPtr edgeSubentIds, IntPtr radius, IntPtr startSetback, IntPtr endSetback)
	{
		return (int)filletEdges(new OdArray_OdDbSubentId__p_OdObjectsAllocator(edgeSubentIds, cMemoryOwn: false), new OdDoubleArray(radius, cMemoryOwn: true), new OdDoubleArray(startSetback, cMemoryOwn: true), new OdDoubleArray(endSetback, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsetSubentColor(IntPtr subentId, IntPtr color)
	{
		return (int)setSubentColor(new OdDbSubentId(subentId, cMemoryOwn: false), new OdCmColor(color, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetSubentColor(IntPtr subentId, IntPtr color)
	{
		return (int)getSubentColor(new OdDbSubentId(subentId, cMemoryOwn: false), new OdCmColor(color, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsetSubentMaterial(IntPtr subentId, IntPtr matId)
	{
		return (int)setSubentMaterial(new OdDbSubentId(subentId, cMemoryOwn: false), new OdDbObjectId(matId, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetSubentMaterial(IntPtr subentId, IntPtr matId)
	{
		return (int)getSubentMaterial(new OdDbSubentId(subentId, cMemoryOwn: false), new OdDbObjectId(matId, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsetSubentMaterialMapper(IntPtr subentId, IntPtr mapper)
	{
		return (int)setSubentMaterialMapper(new OdDbSubentId(subentId, cMemoryOwn: false), new OdGiMapper(mapper, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetSubentMaterialMapper(IntPtr subentId, IntPtr mapper)
	{
		return (int)getSubentMaterialMapper(new OdDbSubentId(subentId, cMemoryOwn: false), new OdGiMapper(mapper, cMemoryOwn: false));
	}

	private int SwigDirectorMethodconvertToNurbSurface(IntPtr nurbSurfaceArray)
	{
		return (int)convertToNurbSurface(new OdDbNurbSurfacePtrArray(nurbSurfaceArray, cMemoryOwn: false));
	}

	private uint SwigDirectorMethodnumChanges()
	{
		return numChanges();
	}
}

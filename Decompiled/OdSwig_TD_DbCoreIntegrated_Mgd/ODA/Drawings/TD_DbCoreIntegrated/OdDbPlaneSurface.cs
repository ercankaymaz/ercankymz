using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbPlaneSurface : OdDbSurface
{
	public delegate IntPtr SwigDelegateOdDbPlaneSurface_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_1();

	public delegate void SwigDelegateOdDbPlaneSurface_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbPlaneSurface_3();

	public delegate bool SwigDelegateOdDbPlaneSurface_4();

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_5();

	public delegate void SwigDelegateOdDbPlaneSurface_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_7();

	public delegate void SwigDelegateOdDbPlaneSurface_8(IntPtr ownerId);

	public delegate int SwigDelegateOdDbPlaneSurface_9(int mode);

	public delegate void SwigDelegateOdDbPlaneSurface_10();

	public delegate int SwigDelegateOdDbPlaneSurface_11(bool erasing);

	public delegate void SwigDelegateOdDbPlaneSurface_12(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbPlaneSurface_13(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbPlaneSurface_14(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbPlaneSurface_15(IntPtr otherId);

	public delegate void SwigDelegateOdDbPlaneSurface_16(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbPlaneSurface_17(IntPtr pFiler);

	public delegate void SwigDelegateOdDbPlaneSurface_18(IntPtr pFiler);

	public delegate int SwigDelegateOdDbPlaneSurface_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbPlaneSurface_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbPlaneSurface_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbPlaneSurface_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbPlaneSurface_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbPlaneSurface_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbPlaneSurface_25();

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_26([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbPlaneSurface_27(IntPtr pRb);

	public delegate void SwigDelegateOdDbPlaneSurface_28(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbPlaneSurface_29(IntPtr objId);

	public delegate void SwigDelegateOdDbPlaneSurface_30(IntPtr objId);

	public delegate void SwigDelegateOdDbPlaneSurface_31(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbPlaneSurface_32();

	public delegate void SwigDelegateOdDbPlaneSurface_33(IntPtr idPair, IntPtr pOwnerObject, IntPtr ownerIdMap);

	public delegate void SwigDelegateOdDbPlaneSurface_34(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbPlaneSurface_35(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbPlaneSurface_36(IntPtr pObject);

	public delegate void SwigDelegateOdDbPlaneSurface_37(IntPtr pObject);

	public delegate void SwigDelegateOdDbPlaneSurface_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbPlaneSurface_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbPlaneSurface_40(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbPlaneSurface_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbPlaneSurface_42(IntPtr pObject);

	public delegate void SwigDelegateOdDbPlaneSurface_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbPlaneSurface_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbPlaneSurface_45(IntPtr objectId);

	public delegate void SwigDelegateOdDbPlaneSurface_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbPlaneSurface_47(IntPtr pSource);

	public delegate int SwigDelegateOdDbPlaneSurface_48(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbPlaneSurface_49(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_50(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_51(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbPlaneSurface_52(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_53();

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_54([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbPlaneSurface_55(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_57(IntPtr pClass);

	public delegate int SwigDelegateOdDbPlaneSurface_58(IntPtr color, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_59(IntPtr color);

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_60();

	public delegate int SwigDelegateOdDbPlaneSurface_61(ushort colorIndex, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_62(ushort colorIndex);

	public delegate int SwigDelegateOdDbPlaneSurface_63(IntPtr colorId, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_64(IntPtr colorId);

	public delegate int SwigDelegateOdDbPlaneSurface_65(IntPtr transparency, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_66(IntPtr transparency);

	public delegate int SwigDelegateOdDbPlaneSurface_67([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_68([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName);

	public delegate int SwigDelegateOdDbPlaneSurface_69(int plotStyleNameType, IntPtr plotStyleNameId, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_70(int plotStyleNameType, IntPtr plotStyleNameId);

	public delegate int SwigDelegateOdDbPlaneSurface_71(int plotStyleNameType);

	public delegate int SwigDelegateOdDbPlaneSurface_72([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbPlaneSurface_73([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_74([MarshalAs(UnmanagedType.LPWStr)] string layerName);

	public delegate int SwigDelegateOdDbPlaneSurface_75(IntPtr layerId, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbPlaneSurface_76(IntPtr layerId, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_77(IntPtr layerId);

	public delegate int SwigDelegateOdDbPlaneSurface_78([MarshalAs(UnmanagedType.LPWStr)] string linetypeName, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_79([MarshalAs(UnmanagedType.LPWStr)] string linetypeName);

	public delegate int SwigDelegateOdDbPlaneSurface_80(IntPtr linetypeID, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_81(IntPtr linetypeID);

	public delegate int SwigDelegateOdDbPlaneSurface_82([MarshalAs(UnmanagedType.LPWStr)] string materialName, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_83([MarshalAs(UnmanagedType.LPWStr)] string materialName);

	public delegate int SwigDelegateOdDbPlaneSurface_84(IntPtr materialID, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_85(IntPtr materialID);

	public delegate int SwigDelegateOdDbPlaneSurface_86(IntPtr visualStyleId, int vstype, bool doSubents);

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_87();

	public delegate void SwigDelegateOdDbPlaneSurface_88(IntPtr mapper, bool doSubents);

	public delegate void SwigDelegateOdDbPlaneSurface_89(IntPtr mapper);

	public delegate int SwigDelegateOdDbPlaneSurface_90(double linetypeScale, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_91(double linetypeScale);

	public delegate int SwigDelegateOdDbPlaneSurface_92(int lineWeight, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_93(int lineWeight);

	public delegate bool SwigDelegateOdDbPlaneSurface_94();

	public delegate void SwigDelegateOdDbPlaneSurface_95(bool castShadows);

	public delegate bool SwigDelegateOdDbPlaneSurface_96();

	public delegate void SwigDelegateOdDbPlaneSurface_97(bool receiveShadows);

	public delegate int SwigDelegateOdDbPlaneSurface_98();

	public delegate bool SwigDelegateOdDbPlaneSurface_99();

	public delegate int SwigDelegateOdDbPlaneSurface_100(IntPtr plane, OdDb_Planarity planarity);

	public delegate int SwigDelegateOdDbPlaneSurface_101(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbPlaneSurface_102(IntPtr pBlockRecord);

	public delegate int SwigDelegateOdDbPlaneSurface_103(IntPtr entitySet);

	public delegate int SwigDelegateOdDbPlaneSurface_104(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbPlaneSurface_105(IntPtr pBlockRecord);

	public delegate void SwigDelegateOdDbPlaneSurface_106(IntPtr pDb, bool doSubents);

	public delegate void SwigDelegateOdDbPlaneSurface_107();

	public delegate void SwigDelegateOdDbPlaneSurface_108(int status);

	public delegate void SwigDelegateOdDbPlaneSurface_109(IntPtr pWd, int ver);

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_110();

	public delegate int SwigDelegateOdDbPlaneSurface_111(IntPtr xM);

	public delegate bool SwigDelegateOdDbPlaneSurface_112();

	public delegate bool SwigDelegateOdDbPlaneSurface_113();

	public delegate void SwigDelegateOdDbPlaneSurface_114(int status);

	public delegate int SwigDelegateOdDbPlaneSurface_115(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints);

	public delegate int SwigDelegateOdDbPlaneSurface_116(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insertionMat);

	public delegate bool SwigDelegateOdDbPlaneSurface_117();

	public delegate int SwigDelegateOdDbPlaneSurface_118(IntPtr gripPoints);

	public delegate int SwigDelegateOdDbPlaneSurface_119(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbPlaneSurface_120(IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags);

	public delegate int SwigDelegateOdDbPlaneSurface_121(IntPtr grips, IntPtr offset, int bitFlags);

	public delegate int SwigDelegateOdDbPlaneSurface_122(IntPtr stretchPoints);

	public delegate int SwigDelegateOdDbPlaneSurface_123(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbPlaneSurface_124(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbPlaneSurface_125(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbPlaneSurface_126(IntPtr pEnt, int intType, IntPtr points);

	public delegate int SwigDelegateOdDbPlaneSurface_127(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbPlaneSurface_128(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbPlaneSurface_129(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points);

	public delegate void SwigDelegateOdDbPlaneSurface_130(bool bDoIt, IntPtr pSubId, bool highlightAll);

	public delegate void SwigDelegateOdDbPlaneSurface_131(bool bDoIt, IntPtr pSubId);

	public delegate void SwigDelegateOdDbPlaneSurface_132(bool bDoIt);

	public delegate void SwigDelegateOdDbPlaneSurface_133();

	public delegate int SwigDelegateOdDbPlaneSurface_134();

	public delegate int SwigDelegateOdDbPlaneSurface_135(int visibility, bool doSubents);

	public delegate int SwigDelegateOdDbPlaneSurface_136(int visibility);

	public delegate int SwigDelegateOdDbPlaneSurface_137(IntPtr paths);

	public delegate int SwigDelegateOdDbPlaneSurface_138(IntPtr paths);

	public delegate int SwigDelegateOdDbPlaneSurface_139(IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags);

	public delegate int SwigDelegateOdDbPlaneSurface_140(IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags);

	public delegate int SwigDelegateOdDbPlaneSurface_141(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr viewXform, IntPtr subentPaths);

	public delegate int SwigDelegateOdDbPlaneSurface_142(IntPtr paths, IntPtr xform);

	public delegate int SwigDelegateOdDbPlaneSurface_143(IntPtr path, IntPtr clsId);

	public delegate int SwigDelegateOdDbPlaneSurface_144(IntPtr path, IntPtr extents);

	public delegate void SwigDelegateOdDbPlaneSurface_145(int status, IntPtr subentity);

	public delegate ushort SwigDelegateOdDbPlaneSurface_146();

	public delegate void SwigDelegateOdDbPlaneSurface_147(ushort numIsolines);

	public delegate ushort SwigDelegateOdDbPlaneSurface_148();

	public delegate void SwigDelegateOdDbPlaneSurface_149(ushort numIsolines);

	public delegate int SwigDelegateOdDbPlaneSurface_150(IntPtr regions);

	public delegate int SwigDelegateOdDbPlaneSurface_151(double thickness, bool bBothSides, IntPtr pSolid);

	public delegate int SwigDelegateOdDbPlaneSurface_152(double area);

	public delegate int SwigDelegateOdDbPlaneSurface_153(IntPtr pGeometry);

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_154();

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_155(IntPtr ent);

	public delegate IntPtr SwigDelegateOdDbPlaneSurface_156(IntPtr id);

	public delegate int SwigDelegateOdDbPlaneSurface_157(IntPtr interferenceObjects, IntPtr pEntity, uint flags);

	public delegate int SwigDelegateOdDbPlaneSurface_158(IntPtr pSurface, IntPtr pNewSurface);

	public delegate int SwigDelegateOdDbPlaneSurface_159(IntPtr pSurface, IntPtr pNewSurface);

	public delegate int SwigDelegateOdDbPlaneSurface_160(IntPtr pSolid, IntPtr pNewSurface);

	public delegate int SwigDelegateOdDbPlaneSurface_161(IntPtr pSurface, IntPtr intersectionEntities);

	public delegate int SwigDelegateOdDbPlaneSurface_162(IntPtr pSolid, IntPtr intersectionEntities);

	public delegate int SwigDelegateOdDbPlaneSurface_163(IntPtr pEntity);

	public delegate int SwigDelegateOdDbPlaneSurface_164(IntPtr sectionPlane, IntPtr sectionObjects);

	public delegate int SwigDelegateOdDbPlaneSurface_165(IntPtr slicePlane, IntPtr pNegHalfSurface, IntPtr pNewSurface);

	public delegate int SwigDelegateOdDbPlaneSurface_166(IntPtr pSlicingSurface, IntPtr pNegHalfSurface, IntPtr pNewSurface);

	public delegate int SwigDelegateOdDbPlaneSurface_167(IntPtr edgeSubentIds, IntPtr baseFaceSubentId, double baseDist, double otherDist);

	public delegate int SwigDelegateOdDbPlaneSurface_168(IntPtr edgeSubentIds, IntPtr radius, IntPtr startSetback, IntPtr endSetback);

	public delegate int SwigDelegateOdDbPlaneSurface_169(IntPtr subentId, IntPtr color);

	public delegate int SwigDelegateOdDbPlaneSurface_170(IntPtr subentId, IntPtr color);

	public delegate int SwigDelegateOdDbPlaneSurface_171(IntPtr subentId, IntPtr matId);

	public delegate int SwigDelegateOdDbPlaneSurface_172(IntPtr subentId, IntPtr matId);

	public delegate int SwigDelegateOdDbPlaneSurface_173(IntPtr subentId, IntPtr mapper);

	public delegate int SwigDelegateOdDbPlaneSurface_174(IntPtr subentId, IntPtr mapper);

	public delegate int SwigDelegateOdDbPlaneSurface_175(IntPtr nurbSurfaceArray);

	public delegate uint SwigDelegateOdDbPlaneSurface_176();

	public delegate int SwigDelegateOdDbPlaneSurface_177(IntPtr pRegion);

	public delegate bool SwigDelegateOdDbPlaneSurface_178();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbPlaneSurface_0 swigDelegate0;

	private SwigDelegateOdDbPlaneSurface_1 swigDelegate1;

	private SwigDelegateOdDbPlaneSurface_2 swigDelegate2;

	private SwigDelegateOdDbPlaneSurface_3 swigDelegate3;

	private SwigDelegateOdDbPlaneSurface_4 swigDelegate4;

	private SwigDelegateOdDbPlaneSurface_5 swigDelegate5;

	private SwigDelegateOdDbPlaneSurface_6 swigDelegate6;

	private SwigDelegateOdDbPlaneSurface_7 swigDelegate7;

	private SwigDelegateOdDbPlaneSurface_8 swigDelegate8;

	private SwigDelegateOdDbPlaneSurface_9 swigDelegate9;

	private SwigDelegateOdDbPlaneSurface_10 swigDelegate10;

	private SwigDelegateOdDbPlaneSurface_11 swigDelegate11;

	private SwigDelegateOdDbPlaneSurface_12 swigDelegate12;

	private SwigDelegateOdDbPlaneSurface_13 swigDelegate13;

	private SwigDelegateOdDbPlaneSurface_14 swigDelegate14;

	private SwigDelegateOdDbPlaneSurface_15 swigDelegate15;

	private SwigDelegateOdDbPlaneSurface_16 swigDelegate16;

	private SwigDelegateOdDbPlaneSurface_17 swigDelegate17;

	private SwigDelegateOdDbPlaneSurface_18 swigDelegate18;

	private SwigDelegateOdDbPlaneSurface_19 swigDelegate19;

	private SwigDelegateOdDbPlaneSurface_20 swigDelegate20;

	private SwigDelegateOdDbPlaneSurface_21 swigDelegate21;

	private SwigDelegateOdDbPlaneSurface_22 swigDelegate22;

	private SwigDelegateOdDbPlaneSurface_23 swigDelegate23;

	private SwigDelegateOdDbPlaneSurface_24 swigDelegate24;

	private SwigDelegateOdDbPlaneSurface_25 swigDelegate25;

	private SwigDelegateOdDbPlaneSurface_26 swigDelegate26;

	private SwigDelegateOdDbPlaneSurface_27 swigDelegate27;

	private SwigDelegateOdDbPlaneSurface_28 swigDelegate28;

	private SwigDelegateOdDbPlaneSurface_29 swigDelegate29;

	private SwigDelegateOdDbPlaneSurface_30 swigDelegate30;

	private SwigDelegateOdDbPlaneSurface_31 swigDelegate31;

	private SwigDelegateOdDbPlaneSurface_32 swigDelegate32;

	private SwigDelegateOdDbPlaneSurface_33 swigDelegate33;

	private SwigDelegateOdDbPlaneSurface_34 swigDelegate34;

	private SwigDelegateOdDbPlaneSurface_35 swigDelegate35;

	private SwigDelegateOdDbPlaneSurface_36 swigDelegate36;

	private SwigDelegateOdDbPlaneSurface_37 swigDelegate37;

	private SwigDelegateOdDbPlaneSurface_38 swigDelegate38;

	private SwigDelegateOdDbPlaneSurface_39 swigDelegate39;

	private SwigDelegateOdDbPlaneSurface_40 swigDelegate40;

	private SwigDelegateOdDbPlaneSurface_41 swigDelegate41;

	private SwigDelegateOdDbPlaneSurface_42 swigDelegate42;

	private SwigDelegateOdDbPlaneSurface_43 swigDelegate43;

	private SwigDelegateOdDbPlaneSurface_44 swigDelegate44;

	private SwigDelegateOdDbPlaneSurface_45 swigDelegate45;

	private SwigDelegateOdDbPlaneSurface_46 swigDelegate46;

	private SwigDelegateOdDbPlaneSurface_47 swigDelegate47;

	private SwigDelegateOdDbPlaneSurface_48 swigDelegate48;

	private SwigDelegateOdDbPlaneSurface_49 swigDelegate49;

	private SwigDelegateOdDbPlaneSurface_50 swigDelegate50;

	private SwigDelegateOdDbPlaneSurface_51 swigDelegate51;

	private SwigDelegateOdDbPlaneSurface_52 swigDelegate52;

	private SwigDelegateOdDbPlaneSurface_53 swigDelegate53;

	private SwigDelegateOdDbPlaneSurface_54 swigDelegate54;

	private SwigDelegateOdDbPlaneSurface_55 swigDelegate55;

	private SwigDelegateOdDbPlaneSurface_56 swigDelegate56;

	private SwigDelegateOdDbPlaneSurface_57 swigDelegate57;

	private SwigDelegateOdDbPlaneSurface_58 swigDelegate58;

	private SwigDelegateOdDbPlaneSurface_59 swigDelegate59;

	private SwigDelegateOdDbPlaneSurface_60 swigDelegate60;

	private SwigDelegateOdDbPlaneSurface_61 swigDelegate61;

	private SwigDelegateOdDbPlaneSurface_62 swigDelegate62;

	private SwigDelegateOdDbPlaneSurface_63 swigDelegate63;

	private SwigDelegateOdDbPlaneSurface_64 swigDelegate64;

	private SwigDelegateOdDbPlaneSurface_65 swigDelegate65;

	private SwigDelegateOdDbPlaneSurface_66 swigDelegate66;

	private SwigDelegateOdDbPlaneSurface_67 swigDelegate67;

	private SwigDelegateOdDbPlaneSurface_68 swigDelegate68;

	private SwigDelegateOdDbPlaneSurface_69 swigDelegate69;

	private SwigDelegateOdDbPlaneSurface_70 swigDelegate70;

	private SwigDelegateOdDbPlaneSurface_71 swigDelegate71;

	private SwigDelegateOdDbPlaneSurface_72 swigDelegate72;

	private SwigDelegateOdDbPlaneSurface_73 swigDelegate73;

	private SwigDelegateOdDbPlaneSurface_74 swigDelegate74;

	private SwigDelegateOdDbPlaneSurface_75 swigDelegate75;

	private SwigDelegateOdDbPlaneSurface_76 swigDelegate76;

	private SwigDelegateOdDbPlaneSurface_77 swigDelegate77;

	private SwigDelegateOdDbPlaneSurface_78 swigDelegate78;

	private SwigDelegateOdDbPlaneSurface_79 swigDelegate79;

	private SwigDelegateOdDbPlaneSurface_80 swigDelegate80;

	private SwigDelegateOdDbPlaneSurface_81 swigDelegate81;

	private SwigDelegateOdDbPlaneSurface_82 swigDelegate82;

	private SwigDelegateOdDbPlaneSurface_83 swigDelegate83;

	private SwigDelegateOdDbPlaneSurface_84 swigDelegate84;

	private SwigDelegateOdDbPlaneSurface_85 swigDelegate85;

	private SwigDelegateOdDbPlaneSurface_86 swigDelegate86;

	private SwigDelegateOdDbPlaneSurface_87 swigDelegate87;

	private SwigDelegateOdDbPlaneSurface_88 swigDelegate88;

	private SwigDelegateOdDbPlaneSurface_89 swigDelegate89;

	private SwigDelegateOdDbPlaneSurface_90 swigDelegate90;

	private SwigDelegateOdDbPlaneSurface_91 swigDelegate91;

	private SwigDelegateOdDbPlaneSurface_92 swigDelegate92;

	private SwigDelegateOdDbPlaneSurface_93 swigDelegate93;

	private SwigDelegateOdDbPlaneSurface_94 swigDelegate94;

	private SwigDelegateOdDbPlaneSurface_95 swigDelegate95;

	private SwigDelegateOdDbPlaneSurface_96 swigDelegate96;

	private SwigDelegateOdDbPlaneSurface_97 swigDelegate97;

	private SwigDelegateOdDbPlaneSurface_98 swigDelegate98;

	private SwigDelegateOdDbPlaneSurface_99 swigDelegate99;

	private SwigDelegateOdDbPlaneSurface_100 swigDelegate100;

	private SwigDelegateOdDbPlaneSurface_101 swigDelegate101;

	private SwigDelegateOdDbPlaneSurface_102 swigDelegate102;

	private SwigDelegateOdDbPlaneSurface_103 swigDelegate103;

	private SwigDelegateOdDbPlaneSurface_104 swigDelegate104;

	private SwigDelegateOdDbPlaneSurface_105 swigDelegate105;

	private SwigDelegateOdDbPlaneSurface_106 swigDelegate106;

	private SwigDelegateOdDbPlaneSurface_107 swigDelegate107;

	private SwigDelegateOdDbPlaneSurface_108 swigDelegate108;

	private SwigDelegateOdDbPlaneSurface_109 swigDelegate109;

	private SwigDelegateOdDbPlaneSurface_110 swigDelegate110;

	private SwigDelegateOdDbPlaneSurface_111 swigDelegate111;

	private SwigDelegateOdDbPlaneSurface_112 swigDelegate112;

	private SwigDelegateOdDbPlaneSurface_113 swigDelegate113;

	private SwigDelegateOdDbPlaneSurface_114 swigDelegate114;

	private SwigDelegateOdDbPlaneSurface_115 swigDelegate115;

	private SwigDelegateOdDbPlaneSurface_116 swigDelegate116;

	private SwigDelegateOdDbPlaneSurface_117 swigDelegate117;

	private SwigDelegateOdDbPlaneSurface_118 swigDelegate118;

	private SwigDelegateOdDbPlaneSurface_119 swigDelegate119;

	private SwigDelegateOdDbPlaneSurface_120 swigDelegate120;

	private SwigDelegateOdDbPlaneSurface_121 swigDelegate121;

	private SwigDelegateOdDbPlaneSurface_122 swigDelegate122;

	private SwigDelegateOdDbPlaneSurface_123 swigDelegate123;

	private SwigDelegateOdDbPlaneSurface_124 swigDelegate124;

	private SwigDelegateOdDbPlaneSurface_125 swigDelegate125;

	private SwigDelegateOdDbPlaneSurface_126 swigDelegate126;

	private SwigDelegateOdDbPlaneSurface_127 swigDelegate127;

	private SwigDelegateOdDbPlaneSurface_128 swigDelegate128;

	private SwigDelegateOdDbPlaneSurface_129 swigDelegate129;

	private SwigDelegateOdDbPlaneSurface_130 swigDelegate130;

	private SwigDelegateOdDbPlaneSurface_131 swigDelegate131;

	private SwigDelegateOdDbPlaneSurface_132 swigDelegate132;

	private SwigDelegateOdDbPlaneSurface_133 swigDelegate133;

	private SwigDelegateOdDbPlaneSurface_134 swigDelegate134;

	private SwigDelegateOdDbPlaneSurface_135 swigDelegate135;

	private SwigDelegateOdDbPlaneSurface_136 swigDelegate136;

	private SwigDelegateOdDbPlaneSurface_137 swigDelegate137;

	private SwigDelegateOdDbPlaneSurface_138 swigDelegate138;

	private SwigDelegateOdDbPlaneSurface_139 swigDelegate139;

	private SwigDelegateOdDbPlaneSurface_140 swigDelegate140;

	private SwigDelegateOdDbPlaneSurface_141 swigDelegate141;

	private SwigDelegateOdDbPlaneSurface_142 swigDelegate142;

	private SwigDelegateOdDbPlaneSurface_143 swigDelegate143;

	private SwigDelegateOdDbPlaneSurface_144 swigDelegate144;

	private SwigDelegateOdDbPlaneSurface_145 swigDelegate145;

	private SwigDelegateOdDbPlaneSurface_146 swigDelegate146;

	private SwigDelegateOdDbPlaneSurface_147 swigDelegate147;

	private SwigDelegateOdDbPlaneSurface_148 swigDelegate148;

	private SwigDelegateOdDbPlaneSurface_149 swigDelegate149;

	private SwigDelegateOdDbPlaneSurface_150 swigDelegate150;

	private SwigDelegateOdDbPlaneSurface_151 swigDelegate151;

	private SwigDelegateOdDbPlaneSurface_152 swigDelegate152;

	private SwigDelegateOdDbPlaneSurface_153 swigDelegate153;

	private SwigDelegateOdDbPlaneSurface_154 swigDelegate154;

	private SwigDelegateOdDbPlaneSurface_155 swigDelegate155;

	private SwigDelegateOdDbPlaneSurface_156 swigDelegate156;

	private SwigDelegateOdDbPlaneSurface_157 swigDelegate157;

	private SwigDelegateOdDbPlaneSurface_158 swigDelegate158;

	private SwigDelegateOdDbPlaneSurface_159 swigDelegate159;

	private SwigDelegateOdDbPlaneSurface_160 swigDelegate160;

	private SwigDelegateOdDbPlaneSurface_161 swigDelegate161;

	private SwigDelegateOdDbPlaneSurface_162 swigDelegate162;

	private SwigDelegateOdDbPlaneSurface_163 swigDelegate163;

	private SwigDelegateOdDbPlaneSurface_164 swigDelegate164;

	private SwigDelegateOdDbPlaneSurface_165 swigDelegate165;

	private SwigDelegateOdDbPlaneSurface_166 swigDelegate166;

	private SwigDelegateOdDbPlaneSurface_167 swigDelegate167;

	private SwigDelegateOdDbPlaneSurface_168 swigDelegate168;

	private SwigDelegateOdDbPlaneSurface_169 swigDelegate169;

	private SwigDelegateOdDbPlaneSurface_170 swigDelegate170;

	private SwigDelegateOdDbPlaneSurface_171 swigDelegate171;

	private SwigDelegateOdDbPlaneSurface_172 swigDelegate172;

	private SwigDelegateOdDbPlaneSurface_173 swigDelegate173;

	private SwigDelegateOdDbPlaneSurface_174 swigDelegate174;

	private SwigDelegateOdDbPlaneSurface_175 swigDelegate175;

	private SwigDelegateOdDbPlaneSurface_176 swigDelegate176;

	private SwigDelegateOdDbPlaneSurface_177 swigDelegate177;

	private SwigDelegateOdDbPlaneSurface_178 swigDelegate178;

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

	private static Type[] swigMethodTypes177 = new Type[1] { typeof(OdDbRegion) };

	private static Type[] swigMethodTypes178 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbPlaneSurface(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbPlaneSurface obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbPlaneSurface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbPlaneSurface cast(OdRxObject pObj)
	{
		OdDbPlaneSurface rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlaneSurface>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_isASwigExplicitOdDbPlaneSurface(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_queryXSwigExplicitOdDbPlaneSurface(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult createFromRegion(OdDbRegion pRegion)
	{
		int result = (SwigDerivedClassHasMethod("createFromRegion", swigMethodTypes177) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_createFromRegionSwigExplicitOdDbPlaneSurface(swigCPtr, OdDbRegion.getCPtr(pRegion)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_createFromRegion(swigCPtr, OdDbRegion.getCPtr(pRegion)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_dwgInFieldsSwigExplicitOdDbPlaneSurface(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_dwgOutFieldsSwigExplicitOdDbPlaneSurface(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_dxfInFieldsSwigExplicitOdDbPlaneSurface(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_dxfOutFieldsSwigExplicitOdDbPlaneSurface(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isDependent()
	{
		bool result = (SwigDerivedClassHasMethod("isDependent", swigMethodTypes178) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_isDependentSwigExplicitOdDbPlaneSurface(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_isDependent(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult getPlane(OdGePlane plane, out OdDb_Planarity planarity)
	{
		int result = (SwigDerivedClassHasMethod("getPlane", swigMethodTypes100) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_getPlaneSwigExplicitOdDbPlaneSurface(swigCPtr, OdGePlane.getCPtr(plane), out planarity) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_getPlane(swigCPtr, OdGePlane.getCPtr(plane), out planarity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult SubGetClassID(IntPtr pClsid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_SubGetClassID(swigCPtr, pClsid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult SubExplode(OdRxObjectPtrArray entitySet)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_SubExplode(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbPlaneSurface createObject()
	{
		OdDbPlaneSurface rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlaneSurface>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("createFromRegion", swigMethodTypes177))
		{
			swigDelegate177 = SwigDirectorMethodcreateFromRegion;
		}
		if (SwigDerivedClassHasMethod("isDependent", swigMethodTypes178))
		{
			swigDelegate178 = SwigDirectorMethodisDependent;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlaneSurface_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125, swigDelegate126, swigDelegate127, swigDelegate128, swigDelegate129, swigDelegate130, swigDelegate131, swigDelegate132, swigDelegate133, swigDelegate134, swigDelegate135, swigDelegate136, swigDelegate137, swigDelegate138, swigDelegate139, swigDelegate140, swigDelegate141, swigDelegate142, swigDelegate143, swigDelegate144, swigDelegate145, swigDelegate146, swigDelegate147, swigDelegate148, swigDelegate149, swigDelegate150, swigDelegate151, swigDelegate152, swigDelegate153, swigDelegate154, swigDelegate155, swigDelegate156, swigDelegate157, swigDelegate158, swigDelegate159, swigDelegate160, swigDelegate161, swigDelegate162, swigDelegate163, swigDelegate164, swigDelegate165, swigDelegate166, swigDelegate167, swigDelegate168, swigDelegate169, swigDelegate170, swigDelegate171, swigDelegate172, swigDelegate173, swigDelegate174, swigDelegate175, swigDelegate176, swigDelegate177, swigDelegate178);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbPlaneSurface));
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
			IntPtr intPtr = OdDbSurface.getCPtr(pNewSurface2).Handle;
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
			IntPtr intPtr = OdDbSurface.getCPtr(pNewSurface2).Handle;
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
			IntPtr intPtr = OdDbSurface.getCPtr(pNewSurface2).Handle;
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
			IntPtr intPtr = OdDbSurface.getCPtr(pNegHalfSurface2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pNegHalfSurface);
			IntPtr intPtr2 = OdDbSurface.getCPtr(pNewSurface2).Handle;
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
			IntPtr intPtr = OdDbSurface.getCPtr(pNegHalfSurface2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pNegHalfSurface);
			IntPtr intPtr2 = OdDbSurface.getCPtr(pNewSurface2).Handle;
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

	private int SwigDirectorMethodcreateFromRegion(IntPtr pRegion)
	{
		return (int)createFromRegion(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbRegion>(pRegion, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisDependent()
	{
		return isDependent();
	}
}

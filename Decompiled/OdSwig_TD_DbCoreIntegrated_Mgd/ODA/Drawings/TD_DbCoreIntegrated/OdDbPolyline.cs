using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbPolyline : OdDbCurve
{
	public delegate IntPtr SwigDelegateOdDbPolyline_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbPolyline_1();

	public delegate void SwigDelegateOdDbPolyline_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbPolyline_3();

	public delegate bool SwigDelegateOdDbPolyline_4();

	public delegate IntPtr SwigDelegateOdDbPolyline_5();

	public delegate void SwigDelegateOdDbPolyline_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbPolyline_7();

	public delegate void SwigDelegateOdDbPolyline_8(IntPtr ownerId);

	public delegate int SwigDelegateOdDbPolyline_9(int mode);

	public delegate void SwigDelegateOdDbPolyline_10();

	public delegate int SwigDelegateOdDbPolyline_11(bool erasing);

	public delegate void SwigDelegateOdDbPolyline_12(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbPolyline_13(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbPolyline_14(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbPolyline_15(IntPtr otherId);

	public delegate void SwigDelegateOdDbPolyline_16(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbPolyline_17(IntPtr pFiler);

	public delegate void SwigDelegateOdDbPolyline_18(IntPtr pFiler);

	public delegate int SwigDelegateOdDbPolyline_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbPolyline_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbPolyline_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbPolyline_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbPolyline_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbPolyline_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbPolyline_25();

	public delegate IntPtr SwigDelegateOdDbPolyline_26([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbPolyline_27(IntPtr pRb);

	public delegate void SwigDelegateOdDbPolyline_28(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbPolyline_29(IntPtr objId);

	public delegate void SwigDelegateOdDbPolyline_30(IntPtr objId);

	public delegate void SwigDelegateOdDbPolyline_31(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbPolyline_32();

	public delegate void SwigDelegateOdDbPolyline_33(IntPtr idPair, IntPtr pOwnerObject, IntPtr ownerIdMap);

	public delegate void SwigDelegateOdDbPolyline_34(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbPolyline_35(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbPolyline_36(IntPtr pObject);

	public delegate void SwigDelegateOdDbPolyline_37(IntPtr pObject);

	public delegate void SwigDelegateOdDbPolyline_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbPolyline_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbPolyline_40(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbPolyline_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbPolyline_42(IntPtr pObject);

	public delegate void SwigDelegateOdDbPolyline_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbPolyline_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbPolyline_45(IntPtr objectId);

	public delegate void SwigDelegateOdDbPolyline_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbPolyline_47(IntPtr pSource);

	public delegate int SwigDelegateOdDbPolyline_48(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbPolyline_49(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbPolyline_50(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbPolyline_51(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbPolyline_52(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbPolyline_53();

	public delegate IntPtr SwigDelegateOdDbPolyline_54([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbPolyline_55(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbPolyline_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbPolyline_57(IntPtr pClass);

	public delegate int SwigDelegateOdDbPolyline_58(IntPtr color, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_59(IntPtr color);

	public delegate IntPtr SwigDelegateOdDbPolyline_60();

	public delegate int SwigDelegateOdDbPolyline_61(ushort colorIndex, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_62(ushort colorIndex);

	public delegate int SwigDelegateOdDbPolyline_63(IntPtr colorId, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_64(IntPtr colorId);

	public delegate int SwigDelegateOdDbPolyline_65(IntPtr transparency, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_66(IntPtr transparency);

	public delegate int SwigDelegateOdDbPolyline_67([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_68([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName);

	public delegate int SwigDelegateOdDbPolyline_69(int plotStyleNameType, IntPtr plotStyleNameId, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_70(int plotStyleNameType, IntPtr plotStyleNameId);

	public delegate int SwigDelegateOdDbPolyline_71(int plotStyleNameType);

	public delegate int SwigDelegateOdDbPolyline_72([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbPolyline_73([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_74([MarshalAs(UnmanagedType.LPWStr)] string layerName);

	public delegate int SwigDelegateOdDbPolyline_75(IntPtr layerId, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbPolyline_76(IntPtr layerId, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_77(IntPtr layerId);

	public delegate int SwigDelegateOdDbPolyline_78([MarshalAs(UnmanagedType.LPWStr)] string linetypeName, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_79([MarshalAs(UnmanagedType.LPWStr)] string linetypeName);

	public delegate int SwigDelegateOdDbPolyline_80(IntPtr linetypeID, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_81(IntPtr linetypeID);

	public delegate int SwigDelegateOdDbPolyline_82([MarshalAs(UnmanagedType.LPWStr)] string materialName, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_83([MarshalAs(UnmanagedType.LPWStr)] string materialName);

	public delegate int SwigDelegateOdDbPolyline_84(IntPtr materialID, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_85(IntPtr materialID);

	public delegate int SwigDelegateOdDbPolyline_86(IntPtr visualStyleId, int vstype, bool doSubents);

	public delegate IntPtr SwigDelegateOdDbPolyline_87();

	public delegate void SwigDelegateOdDbPolyline_88(IntPtr mapper, bool doSubents);

	public delegate void SwigDelegateOdDbPolyline_89(IntPtr mapper);

	public delegate int SwigDelegateOdDbPolyline_90(double linetypeScale, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_91(double linetypeScale);

	public delegate int SwigDelegateOdDbPolyline_92(int lineWeight, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_93(int lineWeight);

	public delegate bool SwigDelegateOdDbPolyline_94();

	public delegate void SwigDelegateOdDbPolyline_95(bool castShadows);

	public delegate bool SwigDelegateOdDbPolyline_96();

	public delegate void SwigDelegateOdDbPolyline_97(bool receiveShadows);

	public delegate int SwigDelegateOdDbPolyline_98();

	public delegate bool SwigDelegateOdDbPolyline_99();

	public delegate int SwigDelegateOdDbPolyline_100(IntPtr plane, OdDb_Planarity planarity);

	public delegate int SwigDelegateOdDbPolyline_101(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbPolyline_102(IntPtr pBlockRecord);

	public delegate int SwigDelegateOdDbPolyline_103(IntPtr entitySet);

	public delegate int SwigDelegateOdDbPolyline_104(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbPolyline_105(IntPtr pBlockRecord);

	public delegate void SwigDelegateOdDbPolyline_106(IntPtr pDb, bool doSubEnts);

	public delegate void SwigDelegateOdDbPolyline_107();

	public delegate void SwigDelegateOdDbPolyline_108(int status);

	public delegate void SwigDelegateOdDbPolyline_109(IntPtr pWd, int ver);

	public delegate IntPtr SwigDelegateOdDbPolyline_110();

	public delegate int SwigDelegateOdDbPolyline_111(IntPtr xM);

	public delegate bool SwigDelegateOdDbPolyline_112();

	public delegate bool SwigDelegateOdDbPolyline_113();

	public delegate void SwigDelegateOdDbPolyline_114(int status);

	public delegate int SwigDelegateOdDbPolyline_115(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints);

	public delegate int SwigDelegateOdDbPolyline_116(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insertionMat);

	public delegate bool SwigDelegateOdDbPolyline_117();

	public delegate int SwigDelegateOdDbPolyline_118(IntPtr gripPoints);

	public delegate int SwigDelegateOdDbPolyline_119(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbPolyline_120(IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags);

	public delegate int SwigDelegateOdDbPolyline_121(IntPtr grips, IntPtr offset, int bitFlags);

	public delegate int SwigDelegateOdDbPolyline_122(IntPtr stretchPoints);

	public delegate int SwigDelegateOdDbPolyline_123(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbPolyline_124(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbPolyline_125(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbPolyline_126(IntPtr pEnt, int intType, IntPtr points);

	public delegate int SwigDelegateOdDbPolyline_127(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbPolyline_128(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbPolyline_129(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points);

	public delegate void SwigDelegateOdDbPolyline_130(bool bDoIt, IntPtr pSubId, bool highlightAll);

	public delegate void SwigDelegateOdDbPolyline_131(bool bDoIt, IntPtr pSubId);

	public delegate void SwigDelegateOdDbPolyline_132(bool bDoIt);

	public delegate void SwigDelegateOdDbPolyline_133();

	public delegate int SwigDelegateOdDbPolyline_134();

	public delegate int SwigDelegateOdDbPolyline_135(int visibility, bool doSubents);

	public delegate int SwigDelegateOdDbPolyline_136(int visibility);

	public delegate int SwigDelegateOdDbPolyline_137(IntPtr extents);

	public delegate int SwigDelegateOdDbPolyline_138(IntPtr paths);

	public delegate int SwigDelegateOdDbPolyline_139(IntPtr paths);

	public delegate int SwigDelegateOdDbPolyline_140(IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags);

	public delegate int SwigDelegateOdDbPolyline_141(IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags);

	public delegate int SwigDelegateOdDbPolyline_142(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths);

	public delegate int SwigDelegateOdDbPolyline_143(IntPtr paths, IntPtr xform);

	public delegate int SwigDelegateOdDbPolyline_144(IntPtr path, IntPtr clsId);

	public delegate int SwigDelegateOdDbPolyline_145(IntPtr path, IntPtr extents);

	public delegate void SwigDelegateOdDbPolyline_146(int status, IntPtr subentity);

	public delegate bool SwigDelegateOdDbPolyline_147();

	public delegate bool SwigDelegateOdDbPolyline_148();

	public delegate int SwigDelegateOdDbPolyline_149(double startParam);

	public delegate int SwigDelegateOdDbPolyline_150(double endParam);

	public delegate int SwigDelegateOdDbPolyline_151(IntPtr startPoint);

	public delegate int SwigDelegateOdDbPolyline_152(IntPtr endPoint);

	public delegate int SwigDelegateOdDbPolyline_153(double param, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdDbPolyline_154(IntPtr pointOnCurve, double param);

	public delegate int SwigDelegateOdDbPolyline_155(double param, double dist);

	public delegate int SwigDelegateOdDbPolyline_156(double dist, double param);

	public delegate int SwigDelegateOdDbPolyline_157(IntPtr pointOnCurve, double dist);

	public delegate int SwigDelegateOdDbPolyline_158(double dist, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdDbPolyline_159(double param, IntPtr firstDeriv);

	public delegate int SwigDelegateOdDbPolyline_160(IntPtr pointOnCurve, IntPtr firstDeriv);

	public delegate int SwigDelegateOdDbPolyline_161(double param, IntPtr secondDeriv);

	public delegate int SwigDelegateOdDbPolyline_162(IntPtr pointOnCurve, IntPtr secondDeriv);

	public delegate int SwigDelegateOdDbPolyline_163(IntPtr givenPoint, IntPtr pointOnCurve, bool extend);

	public delegate int SwigDelegateOdDbPolyline_164(IntPtr givenPoint, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdDbPolyline_165(IntPtr givenPoint, IntPtr normal, IntPtr pointOnCurve, bool extend);

	public delegate int SwigDelegateOdDbPolyline_166(IntPtr givenPoint, IntPtr normal, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdDbPolyline_167(IntPtr spline);

	public delegate int SwigDelegateOdDbPolyline_168(double param);

	public delegate int SwigDelegateOdDbPolyline_169(bool extendStart, IntPtr toPoint);

	public delegate int SwigDelegateOdDbPolyline_170(double area);

	public delegate int SwigDelegateOdDbPolyline_171(IntPtr projPlane, IntPtr pProjCurve);

	public delegate int SwigDelegateOdDbPolyline_172(IntPtr projPlane, IntPtr projDirection, IntPtr pProjCurve);

	public delegate int SwigDelegateOdDbPolyline_173(double offsetDistance, IntPtr offsetCurves);

	public delegate int SwigDelegateOdDbPolyline_174(IntPtr normal, double offsetDistance, IntPtr offsetCurves);

	public delegate int SwigDelegateOdDbPolyline_175(IntPtr params_, IntPtr curveSegments);

	public delegate int SwigDelegateOdDbPolyline_176(IntPtr points, IntPtr curveSegments);

	public delegate int SwigDelegateOdDbPolyline_177();

	public delegate int SwigDelegateOdDbPolyline_178(IntPtr pGeCurve, IntPtr tol);

	public delegate int SwigDelegateOdDbPolyline_179(IntPtr pGeCurve);

	public delegate int SwigDelegateOdDbPolyline_180(IntPtr geCurve, IntPtr normal, IntPtr tol);

	public delegate int SwigDelegateOdDbPolyline_181(IntPtr geCurve, IntPtr normal);

	public delegate int SwigDelegateOdDbPolyline_182(IntPtr geCurve);

	public delegate int SwigDelegateOdDbPolyline_183(IntPtr arg0);

	public delegate bool SwigDelegateOdDbPolyline_184(uint segmentIndex, IntPtr point2d, double param);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbPolyline_0 swigDelegate0;

	private SwigDelegateOdDbPolyline_1 swigDelegate1;

	private SwigDelegateOdDbPolyline_2 swigDelegate2;

	private SwigDelegateOdDbPolyline_3 swigDelegate3;

	private SwigDelegateOdDbPolyline_4 swigDelegate4;

	private SwigDelegateOdDbPolyline_5 swigDelegate5;

	private SwigDelegateOdDbPolyline_6 swigDelegate6;

	private SwigDelegateOdDbPolyline_7 swigDelegate7;

	private SwigDelegateOdDbPolyline_8 swigDelegate8;

	private SwigDelegateOdDbPolyline_9 swigDelegate9;

	private SwigDelegateOdDbPolyline_10 swigDelegate10;

	private SwigDelegateOdDbPolyline_11 swigDelegate11;

	private SwigDelegateOdDbPolyline_12 swigDelegate12;

	private SwigDelegateOdDbPolyline_13 swigDelegate13;

	private SwigDelegateOdDbPolyline_14 swigDelegate14;

	private SwigDelegateOdDbPolyline_15 swigDelegate15;

	private SwigDelegateOdDbPolyline_16 swigDelegate16;

	private SwigDelegateOdDbPolyline_17 swigDelegate17;

	private SwigDelegateOdDbPolyline_18 swigDelegate18;

	private SwigDelegateOdDbPolyline_19 swigDelegate19;

	private SwigDelegateOdDbPolyline_20 swigDelegate20;

	private SwigDelegateOdDbPolyline_21 swigDelegate21;

	private SwigDelegateOdDbPolyline_22 swigDelegate22;

	private SwigDelegateOdDbPolyline_23 swigDelegate23;

	private SwigDelegateOdDbPolyline_24 swigDelegate24;

	private SwigDelegateOdDbPolyline_25 swigDelegate25;

	private SwigDelegateOdDbPolyline_26 swigDelegate26;

	private SwigDelegateOdDbPolyline_27 swigDelegate27;

	private SwigDelegateOdDbPolyline_28 swigDelegate28;

	private SwigDelegateOdDbPolyline_29 swigDelegate29;

	private SwigDelegateOdDbPolyline_30 swigDelegate30;

	private SwigDelegateOdDbPolyline_31 swigDelegate31;

	private SwigDelegateOdDbPolyline_32 swigDelegate32;

	private SwigDelegateOdDbPolyline_33 swigDelegate33;

	private SwigDelegateOdDbPolyline_34 swigDelegate34;

	private SwigDelegateOdDbPolyline_35 swigDelegate35;

	private SwigDelegateOdDbPolyline_36 swigDelegate36;

	private SwigDelegateOdDbPolyline_37 swigDelegate37;

	private SwigDelegateOdDbPolyline_38 swigDelegate38;

	private SwigDelegateOdDbPolyline_39 swigDelegate39;

	private SwigDelegateOdDbPolyline_40 swigDelegate40;

	private SwigDelegateOdDbPolyline_41 swigDelegate41;

	private SwigDelegateOdDbPolyline_42 swigDelegate42;

	private SwigDelegateOdDbPolyline_43 swigDelegate43;

	private SwigDelegateOdDbPolyline_44 swigDelegate44;

	private SwigDelegateOdDbPolyline_45 swigDelegate45;

	private SwigDelegateOdDbPolyline_46 swigDelegate46;

	private SwigDelegateOdDbPolyline_47 swigDelegate47;

	private SwigDelegateOdDbPolyline_48 swigDelegate48;

	private SwigDelegateOdDbPolyline_49 swigDelegate49;

	private SwigDelegateOdDbPolyline_50 swigDelegate50;

	private SwigDelegateOdDbPolyline_51 swigDelegate51;

	private SwigDelegateOdDbPolyline_52 swigDelegate52;

	private SwigDelegateOdDbPolyline_53 swigDelegate53;

	private SwigDelegateOdDbPolyline_54 swigDelegate54;

	private SwigDelegateOdDbPolyline_55 swigDelegate55;

	private SwigDelegateOdDbPolyline_56 swigDelegate56;

	private SwigDelegateOdDbPolyline_57 swigDelegate57;

	private SwigDelegateOdDbPolyline_58 swigDelegate58;

	private SwigDelegateOdDbPolyline_59 swigDelegate59;

	private SwigDelegateOdDbPolyline_60 swigDelegate60;

	private SwigDelegateOdDbPolyline_61 swigDelegate61;

	private SwigDelegateOdDbPolyline_62 swigDelegate62;

	private SwigDelegateOdDbPolyline_63 swigDelegate63;

	private SwigDelegateOdDbPolyline_64 swigDelegate64;

	private SwigDelegateOdDbPolyline_65 swigDelegate65;

	private SwigDelegateOdDbPolyline_66 swigDelegate66;

	private SwigDelegateOdDbPolyline_67 swigDelegate67;

	private SwigDelegateOdDbPolyline_68 swigDelegate68;

	private SwigDelegateOdDbPolyline_69 swigDelegate69;

	private SwigDelegateOdDbPolyline_70 swigDelegate70;

	private SwigDelegateOdDbPolyline_71 swigDelegate71;

	private SwigDelegateOdDbPolyline_72 swigDelegate72;

	private SwigDelegateOdDbPolyline_73 swigDelegate73;

	private SwigDelegateOdDbPolyline_74 swigDelegate74;

	private SwigDelegateOdDbPolyline_75 swigDelegate75;

	private SwigDelegateOdDbPolyline_76 swigDelegate76;

	private SwigDelegateOdDbPolyline_77 swigDelegate77;

	private SwigDelegateOdDbPolyline_78 swigDelegate78;

	private SwigDelegateOdDbPolyline_79 swigDelegate79;

	private SwigDelegateOdDbPolyline_80 swigDelegate80;

	private SwigDelegateOdDbPolyline_81 swigDelegate81;

	private SwigDelegateOdDbPolyline_82 swigDelegate82;

	private SwigDelegateOdDbPolyline_83 swigDelegate83;

	private SwigDelegateOdDbPolyline_84 swigDelegate84;

	private SwigDelegateOdDbPolyline_85 swigDelegate85;

	private SwigDelegateOdDbPolyline_86 swigDelegate86;

	private SwigDelegateOdDbPolyline_87 swigDelegate87;

	private SwigDelegateOdDbPolyline_88 swigDelegate88;

	private SwigDelegateOdDbPolyline_89 swigDelegate89;

	private SwigDelegateOdDbPolyline_90 swigDelegate90;

	private SwigDelegateOdDbPolyline_91 swigDelegate91;

	private SwigDelegateOdDbPolyline_92 swigDelegate92;

	private SwigDelegateOdDbPolyline_93 swigDelegate93;

	private SwigDelegateOdDbPolyline_94 swigDelegate94;

	private SwigDelegateOdDbPolyline_95 swigDelegate95;

	private SwigDelegateOdDbPolyline_96 swigDelegate96;

	private SwigDelegateOdDbPolyline_97 swigDelegate97;

	private SwigDelegateOdDbPolyline_98 swigDelegate98;

	private SwigDelegateOdDbPolyline_99 swigDelegate99;

	private SwigDelegateOdDbPolyline_100 swigDelegate100;

	private SwigDelegateOdDbPolyline_101 swigDelegate101;

	private SwigDelegateOdDbPolyline_102 swigDelegate102;

	private SwigDelegateOdDbPolyline_103 swigDelegate103;

	private SwigDelegateOdDbPolyline_104 swigDelegate104;

	private SwigDelegateOdDbPolyline_105 swigDelegate105;

	private SwigDelegateOdDbPolyline_106 swigDelegate106;

	private SwigDelegateOdDbPolyline_107 swigDelegate107;

	private SwigDelegateOdDbPolyline_108 swigDelegate108;

	private SwigDelegateOdDbPolyline_109 swigDelegate109;

	private SwigDelegateOdDbPolyline_110 swigDelegate110;

	private SwigDelegateOdDbPolyline_111 swigDelegate111;

	private SwigDelegateOdDbPolyline_112 swigDelegate112;

	private SwigDelegateOdDbPolyline_113 swigDelegate113;

	private SwigDelegateOdDbPolyline_114 swigDelegate114;

	private SwigDelegateOdDbPolyline_115 swigDelegate115;

	private SwigDelegateOdDbPolyline_116 swigDelegate116;

	private SwigDelegateOdDbPolyline_117 swigDelegate117;

	private SwigDelegateOdDbPolyline_118 swigDelegate118;

	private SwigDelegateOdDbPolyline_119 swigDelegate119;

	private SwigDelegateOdDbPolyline_120 swigDelegate120;

	private SwigDelegateOdDbPolyline_121 swigDelegate121;

	private SwigDelegateOdDbPolyline_122 swigDelegate122;

	private SwigDelegateOdDbPolyline_123 swigDelegate123;

	private SwigDelegateOdDbPolyline_124 swigDelegate124;

	private SwigDelegateOdDbPolyline_125 swigDelegate125;

	private SwigDelegateOdDbPolyline_126 swigDelegate126;

	private SwigDelegateOdDbPolyline_127 swigDelegate127;

	private SwigDelegateOdDbPolyline_128 swigDelegate128;

	private SwigDelegateOdDbPolyline_129 swigDelegate129;

	private SwigDelegateOdDbPolyline_130 swigDelegate130;

	private SwigDelegateOdDbPolyline_131 swigDelegate131;

	private SwigDelegateOdDbPolyline_132 swigDelegate132;

	private SwigDelegateOdDbPolyline_133 swigDelegate133;

	private SwigDelegateOdDbPolyline_134 swigDelegate134;

	private SwigDelegateOdDbPolyline_135 swigDelegate135;

	private SwigDelegateOdDbPolyline_136 swigDelegate136;

	private SwigDelegateOdDbPolyline_137 swigDelegate137;

	private SwigDelegateOdDbPolyline_138 swigDelegate138;

	private SwigDelegateOdDbPolyline_139 swigDelegate139;

	private SwigDelegateOdDbPolyline_140 swigDelegate140;

	private SwigDelegateOdDbPolyline_141 swigDelegate141;

	private SwigDelegateOdDbPolyline_142 swigDelegate142;

	private SwigDelegateOdDbPolyline_143 swigDelegate143;

	private SwigDelegateOdDbPolyline_144 swigDelegate144;

	private SwigDelegateOdDbPolyline_145 swigDelegate145;

	private SwigDelegateOdDbPolyline_146 swigDelegate146;

	private SwigDelegateOdDbPolyline_147 swigDelegate147;

	private SwigDelegateOdDbPolyline_148 swigDelegate148;

	private SwigDelegateOdDbPolyline_149 swigDelegate149;

	private SwigDelegateOdDbPolyline_150 swigDelegate150;

	private SwigDelegateOdDbPolyline_151 swigDelegate151;

	private SwigDelegateOdDbPolyline_152 swigDelegate152;

	private SwigDelegateOdDbPolyline_153 swigDelegate153;

	private SwigDelegateOdDbPolyline_154 swigDelegate154;

	private SwigDelegateOdDbPolyline_155 swigDelegate155;

	private SwigDelegateOdDbPolyline_156 swigDelegate156;

	private SwigDelegateOdDbPolyline_157 swigDelegate157;

	private SwigDelegateOdDbPolyline_158 swigDelegate158;

	private SwigDelegateOdDbPolyline_159 swigDelegate159;

	private SwigDelegateOdDbPolyline_160 swigDelegate160;

	private SwigDelegateOdDbPolyline_161 swigDelegate161;

	private SwigDelegateOdDbPolyline_162 swigDelegate162;

	private SwigDelegateOdDbPolyline_163 swigDelegate163;

	private SwigDelegateOdDbPolyline_164 swigDelegate164;

	private SwigDelegateOdDbPolyline_165 swigDelegate165;

	private SwigDelegateOdDbPolyline_166 swigDelegate166;

	private SwigDelegateOdDbPolyline_167 swigDelegate167;

	private SwigDelegateOdDbPolyline_168 swigDelegate168;

	private SwigDelegateOdDbPolyline_169 swigDelegate169;

	private SwigDelegateOdDbPolyline_170 swigDelegate170;

	private SwigDelegateOdDbPolyline_171 swigDelegate171;

	private SwigDelegateOdDbPolyline_172 swigDelegate172;

	private SwigDelegateOdDbPolyline_173 swigDelegate173;

	private SwigDelegateOdDbPolyline_174 swigDelegate174;

	private SwigDelegateOdDbPolyline_175 swigDelegate175;

	private SwigDelegateOdDbPolyline_176 swigDelegate176;

	private SwigDelegateOdDbPolyline_177 swigDelegate177;

	private SwigDelegateOdDbPolyline_178 swigDelegate178;

	private SwigDelegateOdDbPolyline_179 swigDelegate179;

	private SwigDelegateOdDbPolyline_180 swigDelegate180;

	private SwigDelegateOdDbPolyline_181 swigDelegate181;

	private SwigDelegateOdDbPolyline_182 swigDelegate182;

	private SwigDelegateOdDbPolyline_183 swigDelegate183;

	private SwigDelegateOdDbPolyline_184 swigDelegate184;

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

	private static Type[] swigMethodTypes142 = new Type[5]
	{
		typeof(OdDb_SubentType),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdDbFullSubentPathArray)
	};

	private static Type[] swigMethodTypes143 = new Type[2]
	{
		typeof(OdDbFullSubentPathArray),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes144 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes145 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdGeExtents3d)
	};

	private static Type[] swigMethodTypes146 = new Type[2]
	{
		typeof(OdDb_GripStat),
		typeof(OdDbFullSubentPath)
	};

	private static Type[] swigMethodTypes147 = new Type[0];

	private static Type[] swigMethodTypes148 = new Type[0];

	private static Type[] swigMethodTypes149 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes150 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes151 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes152 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes153 = new Type[2]
	{
		typeof(double),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes154 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes155 = new Type[2]
	{
		typeof(double),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes156 = new Type[2]
	{
		typeof(double),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes157 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes158 = new Type[2]
	{
		typeof(double),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes159 = new Type[2]
	{
		typeof(double),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes160 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes161 = new Type[2]
	{
		typeof(double),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes162 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes163 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes164 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes165 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGePoint3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes166 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes167 = new Type[1] { typeof(OdDbSpline).MakeByRefType() };

	private static Type[] swigMethodTypes168 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes169 = new Type[2]
	{
		typeof(bool),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes170 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes171 = new Type[2]
	{
		typeof(OdGePlane),
		typeof(OdDbCurve).MakeByRefType()
	};

	private static Type[] swigMethodTypes172 = new Type[3]
	{
		typeof(OdGePlane),
		typeof(OdGeVector3d),
		typeof(OdDbCurve).MakeByRefType()
	};

	private static Type[] swigMethodTypes173 = new Type[2]
	{
		typeof(double),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes174 = new Type[3]
	{
		typeof(OdGeVector3d),
		typeof(double),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes175 = new Type[2]
	{
		typeof(OdDoubleArray),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes176 = new Type[2]
	{
		typeof(OdGePoint3dArray),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes177 = new Type[0];

	private static Type[] swigMethodTypes178 = new Type[2]
	{
		typeof(OdGeCurve3d).MakeByRefType(),
		typeof(OdGeTol)
	};

	private static Type[] swigMethodTypes179 = new Type[1] { typeof(OdGeCurve3d).MakeByRefType() };

	private static Type[] swigMethodTypes180 = new Type[3]
	{
		typeof(OdGeCurve3d),
		typeof(OdGeVector3d),
		typeof(OdGeTol)
	};

	private static Type[] swigMethodTypes181 = new Type[2]
	{
		typeof(OdGeCurve3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes182 = new Type[1] { typeof(OdGeCurve3d) };

	private static Type[] swigMethodTypes183 = new Type[1] { typeof(OdDbVertex) };

	private static Type[] swigMethodTypes184 = new Type[3]
	{
		typeof(uint),
		typeof(OdGePoint2d),
		typeof(double).MakeByRefType()
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbPolyline(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbPolyline obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbPolyline(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbPolyline cast(OdRxObject pObj)
	{
		OdDbPolyline rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPolyline>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_isASwigExplicitOdDbPolyline(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_queryXSwigExplicitOdDbPolyline(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult convertFrom(OdDbEntity pSource, bool transferId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_convertFrom__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSource), transferId);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult convertFrom(OdDbEntity pSource)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_convertFrom__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSource));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult convertTo(OdDb2dPolyline pDest, bool transferId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_convertTo__SWIG_0(swigCPtr, OdDb2dPolyline.getCPtr(pDest), transferId);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult convertTo(OdDb2dPolyline pDest)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_convertTo__SWIG_1(swigCPtr, OdDb2dPolyline.getCPtr(pDest));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void getPointAt(uint vertexIndex, OdGePoint2d point2d)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getPointAt__SWIG_0(swigCPtr, vertexIndex, OdGePoint2d.getCPtr(point2d));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPointAt(uint vertexIndex, OdGePoint3d point3d)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getPointAt__SWIG_1(swigCPtr, vertexIndex, OdGePoint3d.getCPtr(point3d));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbPolyline_SegType segType(uint segmentIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_segType(swigCPtr, segmentIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbPolyline_SegType)result;
	}

	public void getLineSegAt(uint segmentIndex, OdGeLineSeg2d line2d)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getLineSegAt__SWIG_0(swigCPtr, segmentIndex, OdGeLineSeg2d.getCPtr(line2d));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLineSegAt(uint segmentIndex, OdGeLineSeg3d line3d)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getLineSegAt__SWIG_1(swigCPtr, segmentIndex, OdGeLineSeg3d.getCPtr(line3d));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getArcSegAt(uint segmentIndex, OdGeCircArc2d arc2d)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getArcSegAt__SWIG_0(swigCPtr, segmentIndex, OdGeCircArc2d.getCPtr(arc2d));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getArcSegAt(uint segmentIndex, OdGeCircArc3d arc3d)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getArcSegAt__SWIG_1(swigCPtr, segmentIndex, OdGeCircArc3d.getCPtr(arc3d));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool onSegAt(uint segmentIndex, OdGePoint2d point2d, out double param)
	{
		bool result = (SwigDerivedClassHasMethod("onSegAt", swigMethodTypes184) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_onSegAtSwigExplicitOdDbPolyline(swigCPtr, segmentIndex, OdGePoint2d.getCPtr(point2d), out param) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_onSegAt(swigCPtr, segmentIndex, OdGePoint2d.getCPtr(point2d), out param));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setClosed(bool closed)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setClosed(swigCPtr, closed);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPlinegen(bool plinegen)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setPlinegen(swigCPtr, plinegen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setElevation(double elevation)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setElevation(swigCPtr, elevation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setThickness(double thickness)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setThickness(swigCPtr, thickness);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setConstantWidth(double constantWidth)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setConstantWidth(swigCPtr, constantWidth);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setNormal(OdGeVector3d normal)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setNormal(swigCPtr, OdGeVector3d.getCPtr(normal));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isOnlyLines()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_isOnlyLines(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasPlinegen()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_hasPlinegen(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double elevation()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_elevation(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double thickness()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_thickness(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getConstantWidth()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getConstantWidth__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult getConstantWidth(out double dWidth)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getConstantWidth__SWIG_1(swigCPtr, out dWidth);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdGeVector3d normal()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_normal(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void addVertexAt(uint vertexIndex, OdGePoint2d point2d, double bulge, double startWidth, double endWidth, int vertexIdentifier)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_addVertexAt__SWIG_0(swigCPtr, vertexIndex, OdGePoint2d.getCPtr(point2d), bulge, startWidth, endWidth, vertexIdentifier);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addVertexAt(uint vertexIndex, OdGePoint2d point2d, double bulge, double startWidth, double endWidth)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_addVertexAt__SWIG_1(swigCPtr, vertexIndex, OdGePoint2d.getCPtr(point2d), bulge, startWidth, endWidth);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addVertexAt(uint vertexIndex, OdGePoint2d point2d, double bulge, double startWidth)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_addVertexAt__SWIG_2(swigCPtr, vertexIndex, OdGePoint2d.getCPtr(point2d), bulge, startWidth);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addVertexAt(uint vertexIndex, OdGePoint2d point2d, double bulge)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_addVertexAt__SWIG_3(swigCPtr, vertexIndex, OdGePoint2d.getCPtr(point2d), bulge);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addVertexAt(uint vertexIndex, OdGePoint2d point2d)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_addVertexAt__SWIG_4(swigCPtr, vertexIndex, OdGePoint2d.getCPtr(point2d));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void removeVertexAt(uint vertexIndex)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_removeVertexAt(swigCPtr, vertexIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint numVerts()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_numVerts(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getBulgeAt(uint index)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getBulgeAt(swigCPtr, index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getVertexIdentifierAt(uint index)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getVertexIdentifierAt(swigCPtr, index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getWidthsAt(uint segmentIndex, out double startWidth, out double endWidth)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getWidthsAt(swigCPtr, segmentIndex, out startWidth, out endWidth);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPointAt(uint vertexIndex, OdGePoint2d point2d)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setPointAt(swigCPtr, vertexIndex, OdGePoint2d.getCPtr(point2d));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBulgeAt(uint index, double bulge)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setBulgeAt(swigCPtr, index, bulge);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setVertexIdentifierAt(uint index, int suggestedId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setVertexIdentifierAt(swigCPtr, index, suggestedId);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setWidthsAt(uint index, double startWidth, double endWidth)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setWidthsAt(swigCPtr, index, startWidth, endWidth);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void minimizeMemory()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_minimizeMemory(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void maximizeMemory()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_maximizeMemory(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void reset(bool reuse, uint numVerts)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_reset(swigCPtr, reuse, numVerts);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasBulges()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_hasBulges(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasVertexIdentifiers()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_hasVertexIdentifiers(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasWidth()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_hasWidth(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_dwgInFieldsSwigExplicitOdDbPolyline(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_dwgOutFieldsSwigExplicitOdDbPolyline(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_dxfInFieldsSwigExplicitOdDbPolyline(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult dxfInFields_R12(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields_R12", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_dxfInFields_R12SwigExplicitOdDbPolyline(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_dxfInFields_R12(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_dxfOutFieldsSwigExplicitOdDbPolyline(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isPlanar()
	{
		bool result = (SwigDerivedClassHasMethod("isPlanar", swigMethodTypes99) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_isPlanarSwigExplicitOdDbPolyline(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_isPlanar(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult getPlane(OdGePlane plane, out OdDb_Planarity planarity)
	{
		int result = (SwigDerivedClassHasMethod("getPlane", swigMethodTypes100) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getPlaneSwigExplicitOdDbPolyline(swigCPtr, OdGePlane.getCPtr(plane), out planarity) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getPlane(swigCPtr, OdGePlane.getCPtr(plane), out planarity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override bool isClosed()
	{
		bool result = (SwigDerivedClassHasMethod("isClosed", swigMethodTypes147) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_isClosedSwigExplicitOdDbPolyline(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_isClosed(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isPeriodic()
	{
		bool result = (SwigDerivedClassHasMethod("isPeriodic", swigMethodTypes148) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_isPeriodicSwigExplicitOdDbPolyline(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_isPeriodic(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult getStartParam(out double startParam)
	{
		int result = (SwigDerivedClassHasMethod("getStartParam", swigMethodTypes149) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getStartParamSwigExplicitOdDbPolyline(swigCPtr, out startParam) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getStartParam(swigCPtr, out startParam));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getEndParam(out double endParam)
	{
		int result = (SwigDerivedClassHasMethod("getEndParam", swigMethodTypes150) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getEndParamSwigExplicitOdDbPolyline(swigCPtr, out endParam) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getEndParam(swigCPtr, out endParam));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getStartPoint(OdGePoint3d startPoint)
	{
		int result = (SwigDerivedClassHasMethod("getStartPoint", swigMethodTypes151) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getStartPointSwigExplicitOdDbPolyline(swigCPtr, OdGePoint3d.getCPtr(startPoint)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getStartPoint(swigCPtr, OdGePoint3d.getCPtr(startPoint)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getEndPoint(OdGePoint3d endPoint)
	{
		int result = (SwigDerivedClassHasMethod("getEndPoint", swigMethodTypes152) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getEndPointSwigExplicitOdDbPolyline(swigCPtr, OdGePoint3d.getCPtr(endPoint)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getEndPoint(swigCPtr, OdGePoint3d.getCPtr(endPoint)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getPointAtParam(double param, OdGePoint3d pointOnCurve)
	{
		int result = (SwigDerivedClassHasMethod("getPointAtParam", swigMethodTypes153) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getPointAtParamSwigExplicitOdDbPolyline(swigCPtr, param, OdGePoint3d.getCPtr(pointOnCurve)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getPointAtParam(swigCPtr, param, OdGePoint3d.getCPtr(pointOnCurve)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getParamAtPoint(OdGePoint3d pointOnCurve, out double param)
	{
		int result = (SwigDerivedClassHasMethod("getParamAtPoint", swigMethodTypes154) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getParamAtPointSwigExplicitOdDbPolyline(swigCPtr, OdGePoint3d.getCPtr(pointOnCurve), out param) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getParamAtPoint(swigCPtr, OdGePoint3d.getCPtr(pointOnCurve), out param));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getFirstDeriv(double param, OdGeVector3d firstDeriv)
	{
		int result = (SwigDerivedClassHasMethod("getFirstDeriv", swigMethodTypes159) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getFirstDerivSwigExplicitOdDbPolyline(swigCPtr, param, OdGeVector3d.getCPtr(firstDeriv)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getFirstDeriv(swigCPtr, param, OdGeVector3d.getCPtr(firstDeriv)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getSecondDeriv(double param, OdGeVector3d secondDeriv)
	{
		int result = (SwigDerivedClassHasMethod("getSecondDeriv", swigMethodTypes161) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getSecondDerivSwigExplicitOdDbPolyline(swigCPtr, param, OdGeVector3d.getCPtr(secondDeriv)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getSecondDeriv(swigCPtr, param, OdGeVector3d.getCPtr(secondDeriv)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getArea(out double area)
	{
		int result = (SwigDerivedClassHasMethod("getArea", swigMethodTypes170) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getAreaSwigExplicitOdDbPolyline(swigCPtr, out area) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getArea(swigCPtr, out area));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getDistAtParam(double param, out double dist)
	{
		int result = (SwigDerivedClassHasMethod("getDistAtParam", swigMethodTypes155) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getDistAtParamSwigExplicitOdDbPolyline(swigCPtr, param, out dist) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getDistAtParam(swigCPtr, param, out dist));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getParamAtDist(double dist, out double param)
	{
		int result = (SwigDerivedClassHasMethod("getParamAtDist", swigMethodTypes156) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getParamAtDistSwigExplicitOdDbPolyline(swigCPtr, dist, out param) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getParamAtDist(swigCPtr, dist, out param));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult explodeGeometry(OdRxObjectPtrArray entitySet)
	{
		int result = (SwigDerivedClassHasMethod("explodeGeometry", swigMethodTypes103) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_explodeGeometrySwigExplicitOdDbPolyline(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_explodeGeometry(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult reverseCurve()
	{
		int result = (SwigDerivedClassHasMethod("reverseCurve", swigMethodTypes177) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_reverseCurveSwigExplicitOdDbPolyline(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_reverseCurve(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdGeMatrix3d getEcs()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("getEcs", swigMethodTypes110) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getEcsSwigExplicitOdDbPolyline(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getEcs(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult getOdGeCurve(out OdGeCurve3d pGeCurve, OdGeTol tol)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = (SwigDerivedClassHasMethod("getOdGeCurve", swigMethodTypes178) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getOdGeCurveSwigExplicitOdDbPolyline__SWIG_0(swigCPtr, out jarg, OdGeTol.getCPtr(tol)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getOdGeCurve__SWIG_0(swigCPtr, out jarg, OdGeTol.getCPtr(tol)));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, bIsWrapperOwnNativeObject: true));
			pGeCurve = ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, currentTransaction == null);
		}
	}

	public override OdResult getOdGeCurve(out OdGeCurve3d pGeCurve)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = (SwigDerivedClassHasMethod("getOdGeCurve", swigMethodTypes179) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getOdGeCurveSwigExplicitOdDbPolyline__SWIG_1(swigCPtr, out jarg) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getOdGeCurve__SWIG_1(swigCPtr, out jarg));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, bIsWrapperOwnNativeObject: true));
			pGeCurve = ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, currentTransaction == null);
		}
	}

	public override OdResult setFromOdGeCurve(OdGeCurve3d geCurve, OdGeVector3d normal, OdGeTol tol)
	{
		int result = (SwigDerivedClassHasMethod("setFromOdGeCurve", swigMethodTypes180) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setFromOdGeCurveSwigExplicitOdDbPolyline__SWIG_0(swigCPtr, OdGeCurve3d.getCPtr(geCurve), OdGeVector3d.getCPtr(normal), OdGeTol.getCPtr(tol)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setFromOdGeCurve__SWIG_0(swigCPtr, OdGeCurve3d.getCPtr(geCurve), OdGeVector3d.getCPtr(normal), OdGeTol.getCPtr(tol)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setFromOdGeCurve(OdGeCurve3d geCurve, OdGeVector3d normal)
	{
		int result = (SwigDerivedClassHasMethod("setFromOdGeCurve", swigMethodTypes181) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setFromOdGeCurveSwigExplicitOdDbPolyline__SWIG_1(swigCPtr, OdGeCurve3d.getCPtr(geCurve), OdGeVector3d.getCPtr(normal)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setFromOdGeCurve__SWIG_1(swigCPtr, OdGeCurve3d.getCPtr(geCurve), OdGeVector3d.getCPtr(normal)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult setFromOdGeCurve(OdGeCurve3d geCurve)
	{
		int result = (SwigDerivedClassHasMethod("setFromOdGeCurve", swigMethodTypes182) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setFromOdGeCurveSwigExplicitOdDbPolyline__SWIG_2(swigCPtr, OdGeCurve3d.getCPtr(geCurve)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_setFromOdGeCurve__SWIG_2(swigCPtr, OdGeCurve3d.getCPtr(geCurve)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void subSetDatabaseDefaults(OdDbDatabase pDb, bool doSubEnts)
	{
		if (SwigDerivedClassHasMethod("subSetDatabaseDefaults", swigMethodTypes106))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_subSetDatabaseDefaultsSwigExplicitOdDbPolyline(swigCPtr, OdDbDatabase.getCPtr(pDb), doSubEnts);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_subSetDatabaseDefaults(swigCPtr, OdDbDatabase.getCPtr(pDb), doSubEnts);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult getSplitCurves(OdGePoint3dArray points, OdRxObjectPtrArray curveSegments)
	{
		int result = (SwigDerivedClassHasMethod("getSplitCurves", swigMethodTypes176) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getSplitCurvesSwigExplicitOdDbPolyline__SWIG_0(swigCPtr, OdGePoint3dArray.getCPtr(points).Handle, OdRxObjectPtrArray.getCPtr(curveSegments).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getSplitCurves__SWIG_0(swigCPtr, OdGePoint3dArray.getCPtr(points).Handle, OdRxObjectPtrArray.getCPtr(curveSegments).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getSplitCurves(OdDoubleArray params_, OdRxObjectPtrArray curveSegments)
	{
		int result = (SwigDerivedClassHasMethod("getSplitCurves", swigMethodTypes175) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getSplitCurvesSwigExplicitOdDbPolyline__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(params_).Handle, OdRxObjectPtrArray.getCPtr(curveSegments).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getSplitCurves__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(params_).Handle, OdRxObjectPtrArray.getCPtr(curveSegments).Handle));
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
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_SubGetTransformedCopy(swigCPtr, OdGeMatrix3d.getCPtr(mat), ref jarg);
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

	public virtual OdResult SubTransformBy(OdGeMatrix3d xfm)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_SubTransformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override bool SubWorldDraw(OdGiWorldDraw pWd)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_SubWorldDraw(swigCPtr, OdGiWorldDraw.getCPtr(pWd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void SubViewportDraw(OdGiViewportDraw pVd)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_SubViewportDraw(swigCPtr, OdGiViewportDraw.getCPtr(pVd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult SubGetClassID(IntPtr pClsid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_SubGetClassID(swigCPtr, pClsid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubExplode(OdRxObjectPtrArray entitySet)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_SubExplode(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubGetSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d viewXform, OdDbFullSubentPathArray subentPaths, OdDbObjectIdArray pEntAndInsertStack)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_SubGetSubentPathsAtGsMarker(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(viewXform), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(pEntAndInsertStack));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubGetGsMarkersAtSubentPath(OdDbFullSubentPath subPath, OdGsMarkerArray gsMarkers)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_SubGetGsMarkersAtSubentPath(swigCPtr, OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbEntity SubSubentPtr(OdDbFullSubentPath path)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_SubSubentPtr(swigCPtr, OdDbFullSubentPath.getCPtr(path)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbPolyline createObject()
	{
		OdDbPolyline rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPolyline>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_createObject(), bOwn: true, bTryAddToTransaction: true);
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
			swigDelegate142 = SwigDirectorMethodsubGetSubentPathsAtGsMarker__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subTransformSubentPathsBy", swigMethodTypes143))
		{
			swigDelegate143 = SwigDirectorMethodsubTransformSubentPathsBy;
		}
		if (SwigDerivedClassHasMethod("subGetSubentClassId", swigMethodTypes144))
		{
			swigDelegate144 = SwigDirectorMethodsubGetSubentClassId;
		}
		if (SwigDerivedClassHasMethod("subGetSubentPathGeomExtents", swigMethodTypes145))
		{
			swigDelegate145 = SwigDirectorMethodsubGetSubentPathGeomExtents;
		}
		if (SwigDerivedClassHasMethod("subSubentGripStatus", swigMethodTypes146))
		{
			swigDelegate146 = SwigDirectorMethodsubSubentGripStatus;
		}
		if (SwigDerivedClassHasMethod("isClosed", swigMethodTypes147))
		{
			swigDelegate147 = SwigDirectorMethodisClosed;
		}
		if (SwigDerivedClassHasMethod("isPeriodic", swigMethodTypes148))
		{
			swigDelegate148 = SwigDirectorMethodisPeriodic;
		}
		if (SwigDerivedClassHasMethod("getStartParam", swigMethodTypes149))
		{
			swigDelegate149 = SwigDirectorMethodgetStartParam;
		}
		if (SwigDerivedClassHasMethod("getEndParam", swigMethodTypes150))
		{
			swigDelegate150 = SwigDirectorMethodgetEndParam;
		}
		if (SwigDerivedClassHasMethod("getStartPoint", swigMethodTypes151))
		{
			swigDelegate151 = SwigDirectorMethodgetStartPoint;
		}
		if (SwigDerivedClassHasMethod("getEndPoint", swigMethodTypes152))
		{
			swigDelegate152 = SwigDirectorMethodgetEndPoint;
		}
		if (SwigDerivedClassHasMethod("getPointAtParam", swigMethodTypes153))
		{
			swigDelegate153 = SwigDirectorMethodgetPointAtParam;
		}
		if (SwigDerivedClassHasMethod("getParamAtPoint", swigMethodTypes154))
		{
			swigDelegate154 = SwigDirectorMethodgetParamAtPoint;
		}
		if (SwigDerivedClassHasMethod("getDistAtParam", swigMethodTypes155))
		{
			swigDelegate155 = SwigDirectorMethodgetDistAtParam;
		}
		if (SwigDerivedClassHasMethod("getParamAtDist", swigMethodTypes156))
		{
			swigDelegate156 = SwigDirectorMethodgetParamAtDist;
		}
		if (SwigDerivedClassHasMethod("getDistAtPoint", swigMethodTypes157))
		{
			swigDelegate157 = SwigDirectorMethodgetDistAtPoint;
		}
		if (SwigDerivedClassHasMethod("getPointAtDist", swigMethodTypes158))
		{
			swigDelegate158 = SwigDirectorMethodgetPointAtDist;
		}
		if (SwigDerivedClassHasMethod("getFirstDeriv", swigMethodTypes159))
		{
			swigDelegate159 = SwigDirectorMethodgetFirstDeriv;
		}
		if (SwigDerivedClassHasMethod("getFirstDeriv", swigMethodTypes160))
		{
			swigDelegate160 = SwigDirectorMethodgetFirstDeriv__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getSecondDeriv", swigMethodTypes161))
		{
			swigDelegate161 = SwigDirectorMethodgetSecondDeriv;
		}
		if (SwigDerivedClassHasMethod("getSecondDeriv", swigMethodTypes162))
		{
			swigDelegate162 = SwigDirectorMethodgetSecondDeriv__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getClosestPointTo", swigMethodTypes163))
		{
			swigDelegate163 = SwigDirectorMethodgetClosestPointTo__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getClosestPointTo", swigMethodTypes164))
		{
			swigDelegate164 = SwigDirectorMethodgetClosestPointTo__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getClosestPointTo", swigMethodTypes165))
		{
			swigDelegate165 = SwigDirectorMethodgetClosestPointTo__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getClosestPointTo", swigMethodTypes166))
		{
			swigDelegate166 = SwigDirectorMethodgetClosestPointTo__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getSpline", swigMethodTypes167))
		{
			swigDelegate167 = SwigDirectorMethodgetSpline;
		}
		if (SwigDerivedClassHasMethod("extend", swigMethodTypes168))
		{
			swigDelegate168 = SwigDirectorMethodextend__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("extend", swigMethodTypes169))
		{
			swigDelegate169 = SwigDirectorMethodextend__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getArea", swigMethodTypes170))
		{
			swigDelegate170 = SwigDirectorMethodgetArea;
		}
		if (SwigDerivedClassHasMethod("getOrthoProjectedCurve", swigMethodTypes171))
		{
			swigDelegate171 = SwigDirectorMethodgetOrthoProjectedCurve;
		}
		if (SwigDerivedClassHasMethod("getProjectedCurve", swigMethodTypes172))
		{
			swigDelegate172 = SwigDirectorMethodgetProjectedCurve;
		}
		if (SwigDerivedClassHasMethod("getOffsetCurves", swigMethodTypes173))
		{
			swigDelegate173 = SwigDirectorMethodgetOffsetCurves;
		}
		if (SwigDerivedClassHasMethod("getOffsetCurvesGivenPlaneNormal", swigMethodTypes174))
		{
			swigDelegate174 = SwigDirectorMethodgetOffsetCurvesGivenPlaneNormal;
		}
		if (SwigDerivedClassHasMethod("getSplitCurves", swigMethodTypes175))
		{
			swigDelegate175 = SwigDirectorMethodgetSplitCurves__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getSplitCurves", swigMethodTypes176))
		{
			swigDelegate176 = SwigDirectorMethodgetSplitCurves__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("reverseCurve", swigMethodTypes177))
		{
			swigDelegate177 = SwigDirectorMethodreverseCurve;
		}
		if (SwigDerivedClassHasMethod("getOdGeCurve", swigMethodTypes178))
		{
			swigDelegate178 = SwigDirectorMethodgetOdGeCurve__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getOdGeCurve", swigMethodTypes179))
		{
			swigDelegate179 = SwigDirectorMethodgetOdGeCurve__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setFromOdGeCurve", swigMethodTypes180))
		{
			swigDelegate180 = SwigDirectorMethodsetFromOdGeCurve__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setFromOdGeCurve", swigMethodTypes181))
		{
			swigDelegate181 = SwigDirectorMethodsetFromOdGeCurve__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setFromOdGeCurve", swigMethodTypes182))
		{
			swigDelegate182 = SwigDirectorMethodsetFromOdGeCurve__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("findVertexIndex", swigMethodTypes183))
		{
			swigDelegate183 = SwigDirectorMethodfindVertexIndex;
		}
		if (SwigDerivedClassHasMethod("onSegAt", swigMethodTypes184))
		{
			swigDelegate184 = SwigDirectorMethodonSegAt;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPolyline_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125, swigDelegate126, swigDelegate127, swigDelegate128, swigDelegate129, swigDelegate130, swigDelegate131, swigDelegate132, swigDelegate133, swigDelegate134, swigDelegate135, swigDelegate136, swigDelegate137, swigDelegate138, swigDelegate139, swigDelegate140, swigDelegate141, swigDelegate142, swigDelegate143, swigDelegate144, swigDelegate145, swigDelegate146, swigDelegate147, swigDelegate148, swigDelegate149, swigDelegate150, swigDelegate151, swigDelegate152, swigDelegate153, swigDelegate154, swigDelegate155, swigDelegate156, swigDelegate157, swigDelegate158, swigDelegate159, swigDelegate160, swigDelegate161, swigDelegate162, swigDelegate163, swigDelegate164, swigDelegate165, swigDelegate166, swigDelegate167, swigDelegate168, swigDelegate169, swigDelegate170, swigDelegate171, swigDelegate172, swigDelegate173, swigDelegate174, swigDelegate175, swigDelegate176, swigDelegate177, swigDelegate178, swigDelegate179, swigDelegate180, swigDelegate181, swigDelegate182, swigDelegate183, swigDelegate184);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbPolyline));
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

	private void SwigDirectorMethodsubSetDatabaseDefaults(IntPtr pDb, bool doSubEnts)
	{
		try
		{
			subSetDatabaseDefaults(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), doSubEnts);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

	private int SwigDirectorMethodsubGetSubentPathsAtGsMarker__SWIG_1(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths)
	{
		return (int)subGetSubentPathsAtGsMarker((OdDb_SubentType)type, gsMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGeMatrix3d(xfm, cMemoryOwn: false), new OdDbFullSubentPathArray(subentPaths, cMemoryOwn: false));
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

	private bool SwigDirectorMethodisClosed()
	{
		return isClosed();
	}

	private bool SwigDirectorMethodisPeriodic()
	{
		return isPeriodic();
	}

	private int SwigDirectorMethodgetStartParam(double startParam)
	{
		return (int)getStartParam(out startParam);
	}

	private int SwigDirectorMethodgetEndParam(double endParam)
	{
		return (int)getEndParam(out endParam);
	}

	private int SwigDirectorMethodgetStartPoint(IntPtr startPoint)
	{
		return (int)getStartPoint(new OdGePoint3d(startPoint, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetEndPoint(IntPtr endPoint)
	{
		return (int)getEndPoint(new OdGePoint3d(endPoint, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetPointAtParam(double param, IntPtr pointOnCurve)
	{
		return (int)getPointAtParam(param, new OdGePoint3d(pointOnCurve, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetParamAtPoint(IntPtr pointOnCurve, double param)
	{
		return (int)getParamAtPoint(new OdGePoint3d(pointOnCurve, cMemoryOwn: false), out param);
	}

	private int SwigDirectorMethodgetDistAtParam(double param, double dist)
	{
		return (int)getDistAtParam(param, out dist);
	}

	private int SwigDirectorMethodgetParamAtDist(double dist, double param)
	{
		return (int)getParamAtDist(dist, out param);
	}

	private int SwigDirectorMethodgetDistAtPoint(IntPtr pointOnCurve, double dist)
	{
		return (int)getDistAtPoint(new OdGePoint3d(pointOnCurve, cMemoryOwn: false), out dist);
	}

	private int SwigDirectorMethodgetPointAtDist(double dist, IntPtr pointOnCurve)
	{
		return (int)getPointAtDist(dist, new OdGePoint3d(pointOnCurve, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetFirstDeriv(double param, IntPtr firstDeriv)
	{
		return (int)getFirstDeriv(param, new OdGeVector3d(firstDeriv, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetFirstDeriv__SWIG_1(IntPtr pointOnCurve, IntPtr firstDeriv)
	{
		return (int)getFirstDeriv(new OdGePoint3d(pointOnCurve, cMemoryOwn: false), new OdGeVector3d(firstDeriv, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetSecondDeriv(double param, IntPtr secondDeriv)
	{
		return (int)getSecondDeriv(param, new OdGeVector3d(secondDeriv, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetSecondDeriv__SWIG_1(IntPtr pointOnCurve, IntPtr secondDeriv)
	{
		return (int)getSecondDeriv(new OdGePoint3d(pointOnCurve, cMemoryOwn: false), new OdGeVector3d(secondDeriv, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetClosestPointTo__SWIG_0(IntPtr givenPoint, IntPtr pointOnCurve, bool extend)
	{
		return (int)getClosestPointTo(new OdGePoint3d(givenPoint, cMemoryOwn: false), new OdGePoint3d(pointOnCurve, cMemoryOwn: false), extend);
	}

	private int SwigDirectorMethodgetClosestPointTo__SWIG_1(IntPtr givenPoint, IntPtr pointOnCurve)
	{
		return (int)getClosestPointTo(new OdGePoint3d(givenPoint, cMemoryOwn: false), new OdGePoint3d(pointOnCurve, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetClosestPointTo__SWIG_2(IntPtr givenPoint, IntPtr normal, IntPtr pointOnCurve, bool extend)
	{
		return (int)getClosestPointTo(new OdGePoint3d(givenPoint, cMemoryOwn: false), new OdGeVector3d(normal, cMemoryOwn: false), new OdGePoint3d(pointOnCurve, cMemoryOwn: false), extend);
	}

	private int SwigDirectorMethodgetClosestPointTo__SWIG_3(IntPtr givenPoint, IntPtr normal, IntPtr pointOnCurve)
	{
		return (int)getClosestPointTo(new OdGePoint3d(givenPoint, cMemoryOwn: false), new OdGeVector3d(normal, cMemoryOwn: false), new OdGePoint3d(pointOnCurve, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetSpline(IntPtr spline)
	{
		OdSwigDirectorHelper.director_UnpackData(spline, out var pOriginalObject, out var pFunction);
		OdDbSpline spline2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSpline>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getSpline(ref spline2);
		}
		finally
		{
			IntPtr intPtr = OdDbSpline.getCPtr(spline2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(spline);
		}
	}

	private int SwigDirectorMethodextend__SWIG_0(double param)
	{
		return (int)extend(param);
	}

	private int SwigDirectorMethodextend__SWIG_1(bool extendStart, IntPtr toPoint)
	{
		return (int)extend(extendStart, new OdGePoint3d(toPoint, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetArea(double area)
	{
		return (int)getArea(out area);
	}

	private int SwigDirectorMethodgetOrthoProjectedCurve(IntPtr projPlane, IntPtr pProjCurve)
	{
		OdSwigDirectorHelper.director_UnpackData(pProjCurve, out var pOriginalObject, out var pFunction);
		OdDbCurve pProjCurve2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getOrthoProjectedCurve(new OdGePlane(projPlane, cMemoryOwn: false), ref pProjCurve2);
		}
		finally
		{
			IntPtr intPtr = OdDbCurve.getCPtr(pProjCurve2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pProjCurve);
		}
	}

	private int SwigDirectorMethodgetProjectedCurve(IntPtr projPlane, IntPtr projDirection, IntPtr pProjCurve)
	{
		OdSwigDirectorHelper.director_UnpackData(pProjCurve, out var pOriginalObject, out var pFunction);
		OdDbCurve pProjCurve2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getProjectedCurve(new OdGePlane(projPlane, cMemoryOwn: false), new OdGeVector3d(projDirection, cMemoryOwn: false), ref pProjCurve2);
		}
		finally
		{
			IntPtr intPtr = OdDbCurve.getCPtr(pProjCurve2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pProjCurve);
		}
	}

	private int SwigDirectorMethodgetOffsetCurves(double offsetDistance, IntPtr offsetCurves)
	{
		return (int)getOffsetCurves(offsetDistance, new OdRxObjectPtrArray(offsetCurves, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetOffsetCurvesGivenPlaneNormal(IntPtr normal, double offsetDistance, IntPtr offsetCurves)
	{
		return (int)getOffsetCurvesGivenPlaneNormal(new OdGeVector3d(normal, cMemoryOwn: false), offsetDistance, new OdRxObjectPtrArray(offsetCurves, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetSplitCurves__SWIG_1(IntPtr params_, IntPtr curveSegments)
	{
		return (int)getSplitCurves(new OdDoubleArray(params_, cMemoryOwn: true), new OdRxObjectPtrArray(curveSegments, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetSplitCurves__SWIG_0(IntPtr points, IntPtr curveSegments)
	{
		return (int)getSplitCurves(new OdGePoint3dArray(points, cMemoryOwn: true), new OdRxObjectPtrArray(curveSegments, cMemoryOwn: true));
	}

	private int SwigDirectorMethodreverseCurve()
	{
		return (int)reverseCurve();
	}

	private int SwigDirectorMethodgetOdGeCurve__SWIG_0(IntPtr pGeCurve, IntPtr tol)
	{
		OdGeCurve3d pGeCurve2 = new OdGeCurve3d(pGeCurve, cMemoryOwn: true);
		try
		{
			return (int)getOdGeCurve(out pGeCurve2, new OdGeTol(tol, cMemoryOwn: false));
		}
		finally
		{
			pGeCurve = OdGeCurve3d.getCPtr(pGeCurve2).Handle;
		}
	}

	private int SwigDirectorMethodgetOdGeCurve__SWIG_1(IntPtr pGeCurve)
	{
		OdGeCurve3d pGeCurve2 = new OdGeCurve3d(pGeCurve, cMemoryOwn: true);
		try
		{
			return (int)getOdGeCurve(out pGeCurve2);
		}
		finally
		{
			pGeCurve = OdGeCurve3d.getCPtr(pGeCurve2).Handle;
		}
	}

	private int SwigDirectorMethodsetFromOdGeCurve__SWIG_0(IntPtr geCurve, IntPtr normal, IntPtr tol)
	{
		return (int)setFromOdGeCurve(ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdGeCurve3d>(geCurve, bOwn: false, bTryAddToTransaction: false), (normal == IntPtr.Zero) ? null : new OdGeVector3d(normal, cMemoryOwn: false), new OdGeTol(tol, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsetFromOdGeCurve__SWIG_1(IntPtr geCurve, IntPtr normal)
	{
		return (int)setFromOdGeCurve(ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdGeCurve3d>(geCurve, bOwn: false, bTryAddToTransaction: false), (normal == IntPtr.Zero) ? null : new OdGeVector3d(normal, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsetFromOdGeCurve__SWIG_2(IntPtr geCurve)
	{
		return (int)setFromOdGeCurve(ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdGeCurve3d>(geCurve, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodfindVertexIndex(IntPtr arg0)
	{
		return findVertexIndex(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbVertex>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodonSegAt(uint segmentIndex, IntPtr point2d, double param)
	{
		return onSegAt(segmentIndex, new OdGePoint2d(point2d, cMemoryOwn: false), out param);
	}
}

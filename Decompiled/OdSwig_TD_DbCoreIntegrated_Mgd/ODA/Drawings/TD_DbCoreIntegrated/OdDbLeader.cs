using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbLeader : OdDbCurve
{
	public delegate IntPtr SwigDelegateOdDbLeader_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbLeader_1();

	public delegate void SwigDelegateOdDbLeader_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbLeader_3();

	public delegate bool SwigDelegateOdDbLeader_4();

	public delegate IntPtr SwigDelegateOdDbLeader_5();

	public delegate void SwigDelegateOdDbLeader_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbLeader_7();

	public delegate void SwigDelegateOdDbLeader_8(IntPtr ownerId);

	public delegate int SwigDelegateOdDbLeader_9(int mode);

	public delegate void SwigDelegateOdDbLeader_10();

	public delegate int SwigDelegateOdDbLeader_11(bool erasing);

	public delegate void SwigDelegateOdDbLeader_12(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbLeader_13(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbLeader_14(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbLeader_15(IntPtr otherId);

	public delegate void SwigDelegateOdDbLeader_16(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbLeader_17(IntPtr pFiler);

	public delegate void SwigDelegateOdDbLeader_18(IntPtr pFiler);

	public delegate int SwigDelegateOdDbLeader_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbLeader_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbLeader_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbLeader_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbLeader_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbLeader_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbLeader_25();

	public delegate IntPtr SwigDelegateOdDbLeader_26([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbLeader_27(IntPtr pRb);

	public delegate void SwigDelegateOdDbLeader_28(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbLeader_29(IntPtr objId);

	public delegate void SwigDelegateOdDbLeader_30(IntPtr objId);

	public delegate void SwigDelegateOdDbLeader_31(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbLeader_32();

	public delegate void SwigDelegateOdDbLeader_33(IntPtr idPair, IntPtr pOwnerObject, IntPtr ownerIdMap);

	public delegate void SwigDelegateOdDbLeader_34(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbLeader_35(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbLeader_36(IntPtr pObject);

	public delegate void SwigDelegateOdDbLeader_37(IntPtr pObject);

	public delegate void SwigDelegateOdDbLeader_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbLeader_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbLeader_40(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbLeader_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbLeader_42(IntPtr pObject);

	public delegate void SwigDelegateOdDbLeader_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbLeader_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbLeader_45(IntPtr objectId);

	public delegate void SwigDelegateOdDbLeader_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbLeader_47(IntPtr pSource);

	public delegate int SwigDelegateOdDbLeader_48(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbLeader_49(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbLeader_50(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbLeader_51(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbLeader_52(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbLeader_53();

	public delegate IntPtr SwigDelegateOdDbLeader_54([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbLeader_55(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbLeader_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbLeader_57(IntPtr pClass);

	public delegate int SwigDelegateOdDbLeader_58(IntPtr color, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_59(IntPtr color);

	public delegate IntPtr SwigDelegateOdDbLeader_60();

	public delegate int SwigDelegateOdDbLeader_61(ushort colorIndex, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_62(ushort colorIndex);

	public delegate int SwigDelegateOdDbLeader_63(IntPtr colorId, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_64(IntPtr colorId);

	public delegate int SwigDelegateOdDbLeader_65(IntPtr transparency, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_66(IntPtr transparency);

	public delegate int SwigDelegateOdDbLeader_67([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_68([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName);

	public delegate int SwigDelegateOdDbLeader_69(int plotStyleNameType, IntPtr plotStyleNameId, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_70(int plotStyleNameType, IntPtr plotStyleNameId);

	public delegate int SwigDelegateOdDbLeader_71(int plotStyleNameType);

	public delegate int SwigDelegateOdDbLeader_72([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbLeader_73([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_74([MarshalAs(UnmanagedType.LPWStr)] string layerName);

	public delegate int SwigDelegateOdDbLeader_75(IntPtr layerId, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbLeader_76(IntPtr layerId, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_77(IntPtr layerId);

	public delegate int SwigDelegateOdDbLeader_78([MarshalAs(UnmanagedType.LPWStr)] string linetypeName, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_79([MarshalAs(UnmanagedType.LPWStr)] string linetypeName);

	public delegate int SwigDelegateOdDbLeader_80(IntPtr linetypeID, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_81(IntPtr linetypeID);

	public delegate int SwigDelegateOdDbLeader_82([MarshalAs(UnmanagedType.LPWStr)] string materialName, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_83([MarshalAs(UnmanagedType.LPWStr)] string materialName);

	public delegate int SwigDelegateOdDbLeader_84(IntPtr materialID, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_85(IntPtr materialID);

	public delegate int SwigDelegateOdDbLeader_86(IntPtr visualStyleId, int vstype, bool doSubents);

	public delegate IntPtr SwigDelegateOdDbLeader_87();

	public delegate void SwigDelegateOdDbLeader_88(IntPtr mapper, bool doSubents);

	public delegate void SwigDelegateOdDbLeader_89(IntPtr mapper);

	public delegate int SwigDelegateOdDbLeader_90(double linetypeScale, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_91(double linetypeScale);

	public delegate int SwigDelegateOdDbLeader_92(int lineWeight, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_93(int lineWeight);

	public delegate bool SwigDelegateOdDbLeader_94();

	public delegate void SwigDelegateOdDbLeader_95(bool castShadows);

	public delegate bool SwigDelegateOdDbLeader_96();

	public delegate void SwigDelegateOdDbLeader_97(bool receiveShadows);

	public delegate int SwigDelegateOdDbLeader_98();

	public delegate bool SwigDelegateOdDbLeader_99();

	public delegate int SwigDelegateOdDbLeader_100(IntPtr plane, OdDb_Planarity planarity);

	public delegate int SwigDelegateOdDbLeader_101(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbLeader_102(IntPtr pBlockRecord);

	public delegate int SwigDelegateOdDbLeader_103(IntPtr entitySet);

	public delegate int SwigDelegateOdDbLeader_104(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbLeader_105(IntPtr pBlockRecord);

	public delegate void SwigDelegateOdDbLeader_106(IntPtr pDb, bool doSubents);

	public delegate void SwigDelegateOdDbLeader_107();

	public delegate void SwigDelegateOdDbLeader_108(int status);

	public delegate void SwigDelegateOdDbLeader_109(IntPtr pWd, int ver);

	public delegate IntPtr SwigDelegateOdDbLeader_110();

	public delegate int SwigDelegateOdDbLeader_111(IntPtr xM);

	public delegate bool SwigDelegateOdDbLeader_112();

	public delegate bool SwigDelegateOdDbLeader_113();

	public delegate void SwigDelegateOdDbLeader_114(int status);

	public delegate int SwigDelegateOdDbLeader_115(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints);

	public delegate int SwigDelegateOdDbLeader_116(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insertionMat);

	public delegate bool SwigDelegateOdDbLeader_117();

	public delegate int SwigDelegateOdDbLeader_118(IntPtr gripPoints);

	public delegate int SwigDelegateOdDbLeader_119(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbLeader_120(IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags);

	public delegate int SwigDelegateOdDbLeader_121(IntPtr grips, IntPtr offset, int bitFlags);

	public delegate int SwigDelegateOdDbLeader_122(IntPtr stretchPoints);

	public delegate int SwigDelegateOdDbLeader_123(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbLeader_124(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbLeader_125(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbLeader_126(IntPtr pEnt, int intType, IntPtr points);

	public delegate int SwigDelegateOdDbLeader_127(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbLeader_128(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbLeader_129(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points);

	public delegate void SwigDelegateOdDbLeader_130(bool bDoIt, IntPtr pSubId, bool highlightAll);

	public delegate void SwigDelegateOdDbLeader_131(bool bDoIt, IntPtr pSubId);

	public delegate void SwigDelegateOdDbLeader_132(bool bDoIt);

	public delegate void SwigDelegateOdDbLeader_133();

	public delegate int SwigDelegateOdDbLeader_134();

	public delegate int SwigDelegateOdDbLeader_135(int visibility, bool doSubents);

	public delegate int SwigDelegateOdDbLeader_136(int visibility);

	public delegate int SwigDelegateOdDbLeader_137(IntPtr extents);

	public delegate int SwigDelegateOdDbLeader_138(IntPtr paths);

	public delegate int SwigDelegateOdDbLeader_139(IntPtr paths);

	public delegate int SwigDelegateOdDbLeader_140(IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags);

	public delegate int SwigDelegateOdDbLeader_141(IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags);

	public delegate int SwigDelegateOdDbLeader_142(int type, IntPtr gsMark, IntPtr arg2, IntPtr arg3, IntPtr subentPaths, IntPtr pEntAndInsertStack);

	public delegate int SwigDelegateOdDbLeader_143(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths);

	public delegate int SwigDelegateOdDbLeader_144(IntPtr subPath, IntPtr gsMarkers);

	public delegate IntPtr SwigDelegateOdDbLeader_145(IntPtr path);

	public delegate int SwigDelegateOdDbLeader_146(IntPtr paths, IntPtr xform);

	public delegate int SwigDelegateOdDbLeader_147(IntPtr path, IntPtr clsId);

	public delegate int SwigDelegateOdDbLeader_148(IntPtr path, IntPtr extents);

	public delegate void SwigDelegateOdDbLeader_149(int status, IntPtr subentity);

	public delegate bool SwigDelegateOdDbLeader_150();

	public delegate bool SwigDelegateOdDbLeader_151();

	public delegate int SwigDelegateOdDbLeader_152(double startParam);

	public delegate int SwigDelegateOdDbLeader_153(double endParam);

	public delegate int SwigDelegateOdDbLeader_154(IntPtr startPoint);

	public delegate int SwigDelegateOdDbLeader_155(IntPtr endPoint);

	public delegate int SwigDelegateOdDbLeader_156(double param, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdDbLeader_157(IntPtr pointOnCurve, double param);

	public delegate int SwigDelegateOdDbLeader_158(double param, double dist);

	public delegate int SwigDelegateOdDbLeader_159(double dist, double param);

	public delegate int SwigDelegateOdDbLeader_160(IntPtr pointOnCurve, double dist);

	public delegate int SwigDelegateOdDbLeader_161(double dist, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdDbLeader_162(double param, IntPtr firstDeriv);

	public delegate int SwigDelegateOdDbLeader_163(IntPtr pointOnCurve, IntPtr firstDeriv);

	public delegate int SwigDelegateOdDbLeader_164(double param, IntPtr secondDeriv);

	public delegate int SwigDelegateOdDbLeader_165(IntPtr pointOnCurve, IntPtr secondDeriv);

	public delegate int SwigDelegateOdDbLeader_166(IntPtr givenPoint, IntPtr pointOnCurve, bool extend);

	public delegate int SwigDelegateOdDbLeader_167(IntPtr givenPoint, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdDbLeader_168(IntPtr givenPoint, IntPtr normal, IntPtr pointOnCurve, bool extend);

	public delegate int SwigDelegateOdDbLeader_169(IntPtr givenPoint, IntPtr normal, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdDbLeader_170(IntPtr spline);

	public delegate int SwigDelegateOdDbLeader_171(double param);

	public delegate int SwigDelegateOdDbLeader_172(bool extendStart, IntPtr toPoint);

	public delegate int SwigDelegateOdDbLeader_173(double area);

	public delegate int SwigDelegateOdDbLeader_174(IntPtr projPlane, IntPtr pProjCurve);

	public delegate int SwigDelegateOdDbLeader_175(IntPtr projPlane, IntPtr projDirection, IntPtr pProjCurve);

	public delegate int SwigDelegateOdDbLeader_176(double offsetDistance, IntPtr offsetCurves);

	public delegate int SwigDelegateOdDbLeader_177(IntPtr normal, double offsetDistance, IntPtr offsetCurves);

	public delegate int SwigDelegateOdDbLeader_178(IntPtr params_, IntPtr curveSegments);

	public delegate int SwigDelegateOdDbLeader_179(IntPtr points, IntPtr curveSegments);

	public delegate int SwigDelegateOdDbLeader_180();

	public delegate int SwigDelegateOdDbLeader_181(IntPtr pGeCurve, IntPtr tol);

	public delegate int SwigDelegateOdDbLeader_182(IntPtr pGeCurve);

	public delegate int SwigDelegateOdDbLeader_183(IntPtr geCurve, IntPtr normal, IntPtr tol);

	public delegate int SwigDelegateOdDbLeader_184(IntPtr geCurve, IntPtr normal);

	public delegate int SwigDelegateOdDbLeader_185(IntPtr geCurve);

	public delegate int SwigDelegateOdDbLeader_186(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdDbLeader_187();

	public delegate int SwigDelegateOdDbLeader_188();

	public delegate bool SwigDelegateOdDbLeader_189(IntPtr vertex);

	public delegate void SwigDelegateOdDbLeader_190();

	public delegate IntPtr SwigDelegateOdDbLeader_191();

	public delegate IntPtr SwigDelegateOdDbLeader_192();

	public delegate IntPtr SwigDelegateOdDbLeader_193(int vertexIndex);

	public delegate bool SwigDelegateOdDbLeader_194(int vertexIndex, IntPtr vertex);

	public delegate bool SwigDelegateOdDbLeader_195();

	public delegate void SwigDelegateOdDbLeader_196();

	public delegate void SwigDelegateOdDbLeader_197();

	public delegate bool SwigDelegateOdDbLeader_198();

	public delegate bool SwigDelegateOdDbLeader_199();

	public delegate void SwigDelegateOdDbLeader_200();

	public delegate void SwigDelegateOdDbLeader_201();

	public delegate bool SwigDelegateOdDbLeader_202();

	public delegate IntPtr SwigDelegateOdDbLeader_203();

	public delegate void SwigDelegateOdDbLeader_204(IntPtr dimStyleId);

	public delegate void SwigDelegateOdDbLeader_205(IntPtr annoId);

	public delegate void SwigDelegateOdDbLeader_206(IntPtr annoId, IntPtr xDir, double annotationWidth, double annotationHeight, bool hookLineOnXDir);

	public delegate void SwigDelegateOdDbLeader_207();

	public delegate IntPtr SwigDelegateOdDbLeader_208();

	public delegate IntPtr SwigDelegateOdDbLeader_209();

	public delegate IntPtr SwigDelegateOdDbLeader_210();

	public delegate void SwigDelegateOdDbLeader_211(IntPtr offset);

	public delegate double SwigDelegateOdDbLeader_212();

	public delegate IntPtr SwigDelegateOdDbLeader_213();

	public delegate double SwigDelegateOdDbLeader_214();

	public delegate int SwigDelegateOdDbLeader_215();

	public delegate IntPtr SwigDelegateOdDbLeader_216();

	public delegate bool SwigDelegateOdDbLeader_217();

	public delegate double SwigDelegateOdDbLeader_218();

	public delegate int SwigDelegateOdDbLeader_219();

	public delegate IntPtr SwigDelegateOdDbLeader_220();

	public delegate double SwigDelegateOdDbLeader_221();

	public delegate void SwigDelegateOdDbLeader_222(double val);

	public delegate void SwigDelegateOdDbLeader_223(IntPtr val);

	public delegate void SwigDelegateOdDbLeader_224(double val);

	public delegate void SwigDelegateOdDbLeader_225(IntPtr val);

	public delegate void SwigDelegateOdDbLeader_226([MarshalAs(UnmanagedType.LPWStr)] string val);

	public delegate void SwigDelegateOdDbLeader_227(int val);

	public delegate void SwigDelegateOdDbLeader_228(bool val);

	public delegate void SwigDelegateOdDbLeader_229(double val);

	public delegate void SwigDelegateOdDbLeader_230(int val);

	public delegate void SwigDelegateOdDbLeader_231(IntPtr val);

	public delegate void SwigDelegateOdDbLeader_232(double val);

	public delegate int SwigDelegateOdDbLeader_233();

	public delegate void SwigDelegateOdDbLeader_234(IntPtr leaderPlane);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbLeader_0 swigDelegate0;

	private SwigDelegateOdDbLeader_1 swigDelegate1;

	private SwigDelegateOdDbLeader_2 swigDelegate2;

	private SwigDelegateOdDbLeader_3 swigDelegate3;

	private SwigDelegateOdDbLeader_4 swigDelegate4;

	private SwigDelegateOdDbLeader_5 swigDelegate5;

	private SwigDelegateOdDbLeader_6 swigDelegate6;

	private SwigDelegateOdDbLeader_7 swigDelegate7;

	private SwigDelegateOdDbLeader_8 swigDelegate8;

	private SwigDelegateOdDbLeader_9 swigDelegate9;

	private SwigDelegateOdDbLeader_10 swigDelegate10;

	private SwigDelegateOdDbLeader_11 swigDelegate11;

	private SwigDelegateOdDbLeader_12 swigDelegate12;

	private SwigDelegateOdDbLeader_13 swigDelegate13;

	private SwigDelegateOdDbLeader_14 swigDelegate14;

	private SwigDelegateOdDbLeader_15 swigDelegate15;

	private SwigDelegateOdDbLeader_16 swigDelegate16;

	private SwigDelegateOdDbLeader_17 swigDelegate17;

	private SwigDelegateOdDbLeader_18 swigDelegate18;

	private SwigDelegateOdDbLeader_19 swigDelegate19;

	private SwigDelegateOdDbLeader_20 swigDelegate20;

	private SwigDelegateOdDbLeader_21 swigDelegate21;

	private SwigDelegateOdDbLeader_22 swigDelegate22;

	private SwigDelegateOdDbLeader_23 swigDelegate23;

	private SwigDelegateOdDbLeader_24 swigDelegate24;

	private SwigDelegateOdDbLeader_25 swigDelegate25;

	private SwigDelegateOdDbLeader_26 swigDelegate26;

	private SwigDelegateOdDbLeader_27 swigDelegate27;

	private SwigDelegateOdDbLeader_28 swigDelegate28;

	private SwigDelegateOdDbLeader_29 swigDelegate29;

	private SwigDelegateOdDbLeader_30 swigDelegate30;

	private SwigDelegateOdDbLeader_31 swigDelegate31;

	private SwigDelegateOdDbLeader_32 swigDelegate32;

	private SwigDelegateOdDbLeader_33 swigDelegate33;

	private SwigDelegateOdDbLeader_34 swigDelegate34;

	private SwigDelegateOdDbLeader_35 swigDelegate35;

	private SwigDelegateOdDbLeader_36 swigDelegate36;

	private SwigDelegateOdDbLeader_37 swigDelegate37;

	private SwigDelegateOdDbLeader_38 swigDelegate38;

	private SwigDelegateOdDbLeader_39 swigDelegate39;

	private SwigDelegateOdDbLeader_40 swigDelegate40;

	private SwigDelegateOdDbLeader_41 swigDelegate41;

	private SwigDelegateOdDbLeader_42 swigDelegate42;

	private SwigDelegateOdDbLeader_43 swigDelegate43;

	private SwigDelegateOdDbLeader_44 swigDelegate44;

	private SwigDelegateOdDbLeader_45 swigDelegate45;

	private SwigDelegateOdDbLeader_46 swigDelegate46;

	private SwigDelegateOdDbLeader_47 swigDelegate47;

	private SwigDelegateOdDbLeader_48 swigDelegate48;

	private SwigDelegateOdDbLeader_49 swigDelegate49;

	private SwigDelegateOdDbLeader_50 swigDelegate50;

	private SwigDelegateOdDbLeader_51 swigDelegate51;

	private SwigDelegateOdDbLeader_52 swigDelegate52;

	private SwigDelegateOdDbLeader_53 swigDelegate53;

	private SwigDelegateOdDbLeader_54 swigDelegate54;

	private SwigDelegateOdDbLeader_55 swigDelegate55;

	private SwigDelegateOdDbLeader_56 swigDelegate56;

	private SwigDelegateOdDbLeader_57 swigDelegate57;

	private SwigDelegateOdDbLeader_58 swigDelegate58;

	private SwigDelegateOdDbLeader_59 swigDelegate59;

	private SwigDelegateOdDbLeader_60 swigDelegate60;

	private SwigDelegateOdDbLeader_61 swigDelegate61;

	private SwigDelegateOdDbLeader_62 swigDelegate62;

	private SwigDelegateOdDbLeader_63 swigDelegate63;

	private SwigDelegateOdDbLeader_64 swigDelegate64;

	private SwigDelegateOdDbLeader_65 swigDelegate65;

	private SwigDelegateOdDbLeader_66 swigDelegate66;

	private SwigDelegateOdDbLeader_67 swigDelegate67;

	private SwigDelegateOdDbLeader_68 swigDelegate68;

	private SwigDelegateOdDbLeader_69 swigDelegate69;

	private SwigDelegateOdDbLeader_70 swigDelegate70;

	private SwigDelegateOdDbLeader_71 swigDelegate71;

	private SwigDelegateOdDbLeader_72 swigDelegate72;

	private SwigDelegateOdDbLeader_73 swigDelegate73;

	private SwigDelegateOdDbLeader_74 swigDelegate74;

	private SwigDelegateOdDbLeader_75 swigDelegate75;

	private SwigDelegateOdDbLeader_76 swigDelegate76;

	private SwigDelegateOdDbLeader_77 swigDelegate77;

	private SwigDelegateOdDbLeader_78 swigDelegate78;

	private SwigDelegateOdDbLeader_79 swigDelegate79;

	private SwigDelegateOdDbLeader_80 swigDelegate80;

	private SwigDelegateOdDbLeader_81 swigDelegate81;

	private SwigDelegateOdDbLeader_82 swigDelegate82;

	private SwigDelegateOdDbLeader_83 swigDelegate83;

	private SwigDelegateOdDbLeader_84 swigDelegate84;

	private SwigDelegateOdDbLeader_85 swigDelegate85;

	private SwigDelegateOdDbLeader_86 swigDelegate86;

	private SwigDelegateOdDbLeader_87 swigDelegate87;

	private SwigDelegateOdDbLeader_88 swigDelegate88;

	private SwigDelegateOdDbLeader_89 swigDelegate89;

	private SwigDelegateOdDbLeader_90 swigDelegate90;

	private SwigDelegateOdDbLeader_91 swigDelegate91;

	private SwigDelegateOdDbLeader_92 swigDelegate92;

	private SwigDelegateOdDbLeader_93 swigDelegate93;

	private SwigDelegateOdDbLeader_94 swigDelegate94;

	private SwigDelegateOdDbLeader_95 swigDelegate95;

	private SwigDelegateOdDbLeader_96 swigDelegate96;

	private SwigDelegateOdDbLeader_97 swigDelegate97;

	private SwigDelegateOdDbLeader_98 swigDelegate98;

	private SwigDelegateOdDbLeader_99 swigDelegate99;

	private SwigDelegateOdDbLeader_100 swigDelegate100;

	private SwigDelegateOdDbLeader_101 swigDelegate101;

	private SwigDelegateOdDbLeader_102 swigDelegate102;

	private SwigDelegateOdDbLeader_103 swigDelegate103;

	private SwigDelegateOdDbLeader_104 swigDelegate104;

	private SwigDelegateOdDbLeader_105 swigDelegate105;

	private SwigDelegateOdDbLeader_106 swigDelegate106;

	private SwigDelegateOdDbLeader_107 swigDelegate107;

	private SwigDelegateOdDbLeader_108 swigDelegate108;

	private SwigDelegateOdDbLeader_109 swigDelegate109;

	private SwigDelegateOdDbLeader_110 swigDelegate110;

	private SwigDelegateOdDbLeader_111 swigDelegate111;

	private SwigDelegateOdDbLeader_112 swigDelegate112;

	private SwigDelegateOdDbLeader_113 swigDelegate113;

	private SwigDelegateOdDbLeader_114 swigDelegate114;

	private SwigDelegateOdDbLeader_115 swigDelegate115;

	private SwigDelegateOdDbLeader_116 swigDelegate116;

	private SwigDelegateOdDbLeader_117 swigDelegate117;

	private SwigDelegateOdDbLeader_118 swigDelegate118;

	private SwigDelegateOdDbLeader_119 swigDelegate119;

	private SwigDelegateOdDbLeader_120 swigDelegate120;

	private SwigDelegateOdDbLeader_121 swigDelegate121;

	private SwigDelegateOdDbLeader_122 swigDelegate122;

	private SwigDelegateOdDbLeader_123 swigDelegate123;

	private SwigDelegateOdDbLeader_124 swigDelegate124;

	private SwigDelegateOdDbLeader_125 swigDelegate125;

	private SwigDelegateOdDbLeader_126 swigDelegate126;

	private SwigDelegateOdDbLeader_127 swigDelegate127;

	private SwigDelegateOdDbLeader_128 swigDelegate128;

	private SwigDelegateOdDbLeader_129 swigDelegate129;

	private SwigDelegateOdDbLeader_130 swigDelegate130;

	private SwigDelegateOdDbLeader_131 swigDelegate131;

	private SwigDelegateOdDbLeader_132 swigDelegate132;

	private SwigDelegateOdDbLeader_133 swigDelegate133;

	private SwigDelegateOdDbLeader_134 swigDelegate134;

	private SwigDelegateOdDbLeader_135 swigDelegate135;

	private SwigDelegateOdDbLeader_136 swigDelegate136;

	private SwigDelegateOdDbLeader_137 swigDelegate137;

	private SwigDelegateOdDbLeader_138 swigDelegate138;

	private SwigDelegateOdDbLeader_139 swigDelegate139;

	private SwigDelegateOdDbLeader_140 swigDelegate140;

	private SwigDelegateOdDbLeader_141 swigDelegate141;

	private SwigDelegateOdDbLeader_142 swigDelegate142;

	private SwigDelegateOdDbLeader_143 swigDelegate143;

	private SwigDelegateOdDbLeader_144 swigDelegate144;

	private SwigDelegateOdDbLeader_145 swigDelegate145;

	private SwigDelegateOdDbLeader_146 swigDelegate146;

	private SwigDelegateOdDbLeader_147 swigDelegate147;

	private SwigDelegateOdDbLeader_148 swigDelegate148;

	private SwigDelegateOdDbLeader_149 swigDelegate149;

	private SwigDelegateOdDbLeader_150 swigDelegate150;

	private SwigDelegateOdDbLeader_151 swigDelegate151;

	private SwigDelegateOdDbLeader_152 swigDelegate152;

	private SwigDelegateOdDbLeader_153 swigDelegate153;

	private SwigDelegateOdDbLeader_154 swigDelegate154;

	private SwigDelegateOdDbLeader_155 swigDelegate155;

	private SwigDelegateOdDbLeader_156 swigDelegate156;

	private SwigDelegateOdDbLeader_157 swigDelegate157;

	private SwigDelegateOdDbLeader_158 swigDelegate158;

	private SwigDelegateOdDbLeader_159 swigDelegate159;

	private SwigDelegateOdDbLeader_160 swigDelegate160;

	private SwigDelegateOdDbLeader_161 swigDelegate161;

	private SwigDelegateOdDbLeader_162 swigDelegate162;

	private SwigDelegateOdDbLeader_163 swigDelegate163;

	private SwigDelegateOdDbLeader_164 swigDelegate164;

	private SwigDelegateOdDbLeader_165 swigDelegate165;

	private SwigDelegateOdDbLeader_166 swigDelegate166;

	private SwigDelegateOdDbLeader_167 swigDelegate167;

	private SwigDelegateOdDbLeader_168 swigDelegate168;

	private SwigDelegateOdDbLeader_169 swigDelegate169;

	private SwigDelegateOdDbLeader_170 swigDelegate170;

	private SwigDelegateOdDbLeader_171 swigDelegate171;

	private SwigDelegateOdDbLeader_172 swigDelegate172;

	private SwigDelegateOdDbLeader_173 swigDelegate173;

	private SwigDelegateOdDbLeader_174 swigDelegate174;

	private SwigDelegateOdDbLeader_175 swigDelegate175;

	private SwigDelegateOdDbLeader_176 swigDelegate176;

	private SwigDelegateOdDbLeader_177 swigDelegate177;

	private SwigDelegateOdDbLeader_178 swigDelegate178;

	private SwigDelegateOdDbLeader_179 swigDelegate179;

	private SwigDelegateOdDbLeader_180 swigDelegate180;

	private SwigDelegateOdDbLeader_181 swigDelegate181;

	private SwigDelegateOdDbLeader_182 swigDelegate182;

	private SwigDelegateOdDbLeader_183 swigDelegate183;

	private SwigDelegateOdDbLeader_184 swigDelegate184;

	private SwigDelegateOdDbLeader_185 swigDelegate185;

	private SwigDelegateOdDbLeader_186 swigDelegate186;

	private SwigDelegateOdDbLeader_187 swigDelegate187;

	private SwigDelegateOdDbLeader_188 swigDelegate188;

	private SwigDelegateOdDbLeader_189 swigDelegate189;

	private SwigDelegateOdDbLeader_190 swigDelegate190;

	private SwigDelegateOdDbLeader_191 swigDelegate191;

	private SwigDelegateOdDbLeader_192 swigDelegate192;

	private SwigDelegateOdDbLeader_193 swigDelegate193;

	private SwigDelegateOdDbLeader_194 swigDelegate194;

	private SwigDelegateOdDbLeader_195 swigDelegate195;

	private SwigDelegateOdDbLeader_196 swigDelegate196;

	private SwigDelegateOdDbLeader_197 swigDelegate197;

	private SwigDelegateOdDbLeader_198 swigDelegate198;

	private SwigDelegateOdDbLeader_199 swigDelegate199;

	private SwigDelegateOdDbLeader_200 swigDelegate200;

	private SwigDelegateOdDbLeader_201 swigDelegate201;

	private SwigDelegateOdDbLeader_202 swigDelegate202;

	private SwigDelegateOdDbLeader_203 swigDelegate203;

	private SwigDelegateOdDbLeader_204 swigDelegate204;

	private SwigDelegateOdDbLeader_205 swigDelegate205;

	private SwigDelegateOdDbLeader_206 swigDelegate206;

	private SwigDelegateOdDbLeader_207 swigDelegate207;

	private SwigDelegateOdDbLeader_208 swigDelegate208;

	private SwigDelegateOdDbLeader_209 swigDelegate209;

	private SwigDelegateOdDbLeader_210 swigDelegate210;

	private SwigDelegateOdDbLeader_211 swigDelegate211;

	private SwigDelegateOdDbLeader_212 swigDelegate212;

	private SwigDelegateOdDbLeader_213 swigDelegate213;

	private SwigDelegateOdDbLeader_214 swigDelegate214;

	private SwigDelegateOdDbLeader_215 swigDelegate215;

	private SwigDelegateOdDbLeader_216 swigDelegate216;

	private SwigDelegateOdDbLeader_217 swigDelegate217;

	private SwigDelegateOdDbLeader_218 swigDelegate218;

	private SwigDelegateOdDbLeader_219 swigDelegate219;

	private SwigDelegateOdDbLeader_220 swigDelegate220;

	private SwigDelegateOdDbLeader_221 swigDelegate221;

	private SwigDelegateOdDbLeader_222 swigDelegate222;

	private SwigDelegateOdDbLeader_223 swigDelegate223;

	private SwigDelegateOdDbLeader_224 swigDelegate224;

	private SwigDelegateOdDbLeader_225 swigDelegate225;

	private SwigDelegateOdDbLeader_226 swigDelegate226;

	private SwigDelegateOdDbLeader_227 swigDelegate227;

	private SwigDelegateOdDbLeader_228 swigDelegate228;

	private SwigDelegateOdDbLeader_229 swigDelegate229;

	private SwigDelegateOdDbLeader_230 swigDelegate230;

	private SwigDelegateOdDbLeader_231 swigDelegate231;

	private SwigDelegateOdDbLeader_232 swigDelegate232;

	private SwigDelegateOdDbLeader_233 swigDelegate233;

	private SwigDelegateOdDbLeader_234 swigDelegate234;

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

	private static Type[] swigMethodTypes152 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes153 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes154 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes155 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes156 = new Type[2]
	{
		typeof(double),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes157 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes158 = new Type[2]
	{
		typeof(double),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes159 = new Type[2]
	{
		typeof(double),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes160 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes161 = new Type[2]
	{
		typeof(double),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes162 = new Type[2]
	{
		typeof(double),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes163 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes164 = new Type[2]
	{
		typeof(double),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes165 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes166 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes167 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes168 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGePoint3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes169 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes170 = new Type[1] { typeof(OdDbSpline).MakeByRefType() };

	private static Type[] swigMethodTypes171 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes172 = new Type[2]
	{
		typeof(bool),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes173 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes174 = new Type[2]
	{
		typeof(OdGePlane),
		typeof(OdDbCurve).MakeByRefType()
	};

	private static Type[] swigMethodTypes175 = new Type[3]
	{
		typeof(OdGePlane),
		typeof(OdGeVector3d),
		typeof(OdDbCurve).MakeByRefType()
	};

	private static Type[] swigMethodTypes176 = new Type[2]
	{
		typeof(double),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes177 = new Type[3]
	{
		typeof(OdGeVector3d),
		typeof(double),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes178 = new Type[2]
	{
		typeof(OdDoubleArray),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes179 = new Type[2]
	{
		typeof(OdGePoint3dArray),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes180 = new Type[0];

	private static Type[] swigMethodTypes181 = new Type[2]
	{
		typeof(OdGeCurve3d).MakeByRefType(),
		typeof(OdGeTol)
	};

	private static Type[] swigMethodTypes182 = new Type[1] { typeof(OdGeCurve3d).MakeByRefType() };

	private static Type[] swigMethodTypes183 = new Type[3]
	{
		typeof(OdGeCurve3d),
		typeof(OdGeVector3d),
		typeof(OdGeTol)
	};

	private static Type[] swigMethodTypes184 = new Type[2]
	{
		typeof(OdGeCurve3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes185 = new Type[1] { typeof(OdGeCurve3d) };

	private static Type[] swigMethodTypes186 = new Type[1] { typeof(OdDbVertex) };

	private static Type[] swigMethodTypes187 = new Type[0];

	private static Type[] swigMethodTypes188 = new Type[0];

	private static Type[] swigMethodTypes189 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes190 = new Type[0];

	private static Type[] swigMethodTypes191 = new Type[0];

	private static Type[] swigMethodTypes192 = new Type[0];

	private static Type[] swigMethodTypes193 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes194 = new Type[2]
	{
		typeof(int),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes195 = new Type[0];

	private static Type[] swigMethodTypes196 = new Type[0];

	private static Type[] swigMethodTypes197 = new Type[0];

	private static Type[] swigMethodTypes198 = new Type[0];

	private static Type[] swigMethodTypes199 = new Type[0];

	private static Type[] swigMethodTypes200 = new Type[0];

	private static Type[] swigMethodTypes201 = new Type[0];

	private static Type[] swigMethodTypes202 = new Type[0];

	private static Type[] swigMethodTypes203 = new Type[0];

	private static Type[] swigMethodTypes204 = new Type[1] { typeof(OdDbHardPointerId) };

	private static Type[] swigMethodTypes205 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes206 = new Type[5]
	{
		typeof(OdDbObjectId),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double),
		typeof(bool)
	};

	private static Type[] swigMethodTypes207 = new Type[0];

	private static Type[] swigMethodTypes208 = new Type[0];

	private static Type[] swigMethodTypes209 = new Type[0];

	private static Type[] swigMethodTypes210 = new Type[0];

	private static Type[] swigMethodTypes211 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes212 = new Type[0];

	private static Type[] swigMethodTypes213 = new Type[0];

	private static Type[] swigMethodTypes214 = new Type[0];

	private static Type[] swigMethodTypes215 = new Type[0];

	private static Type[] swigMethodTypes216 = new Type[0];

	private static Type[] swigMethodTypes217 = new Type[0];

	private static Type[] swigMethodTypes218 = new Type[0];

	private static Type[] swigMethodTypes219 = new Type[0];

	private static Type[] swigMethodTypes220 = new Type[0];

	private static Type[] swigMethodTypes221 = new Type[0];

	private static Type[] swigMethodTypes222 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes223 = new Type[1] { typeof(OdCmColor) };

	private static Type[] swigMethodTypes224 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes225 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes226 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes227 = new Type[1] { typeof(LineWeight) };

	private static Type[] swigMethodTypes228 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes229 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes230 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes231 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes232 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes233 = new Type[0];

	private static Type[] swigMethodTypes234 = new Type[1] { typeof(OdGePlane) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbLeader(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbLeader obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbLeader(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbLeader cast(OdRxObject pObj)
	{
		OdDbLeader rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLeader>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isASwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_queryXSwigExplicitOdDbLeader(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGeVector3d normal()
	{
		OdGeVector3d result = new OdGeVector3d(SwigDerivedClassHasMethod("normal", swigMethodTypes187) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_normalSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_normal(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int numVertices()
	{
		int result = (SwigDerivedClassHasMethod("numVertices", swigMethodTypes188) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_numVerticesSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_numVertices(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool appendVertex(OdGePoint3d vertex)
	{
		bool result = (SwigDerivedClassHasMethod("appendVertex", swigMethodTypes189) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_appendVertexSwigExplicitOdDbLeader(swigCPtr, OdGePoint3d.getCPtr(vertex)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_appendVertex(swigCPtr, OdGePoint3d.getCPtr(vertex)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void removeLastVertex()
	{
		if (SwigDerivedClassHasMethod("removeLastVertex", swigMethodTypes190))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_removeLastVertexSwigExplicitOdDbLeader(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_removeLastVertex(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint3d firstVertex()
	{
		OdGePoint3d result = new OdGePoint3d(SwigDerivedClassHasMethod("firstVertex", swigMethodTypes191) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_firstVertexSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_firstVertex(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d lastVertex()
	{
		OdGePoint3d result = new OdGePoint3d(SwigDerivedClassHasMethod("lastVertex", swigMethodTypes192) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_lastVertexSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_lastVertex(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d vertexAt(int vertexIndex)
	{
		OdGePoint3d result = new OdGePoint3d(SwigDerivedClassHasMethod("vertexAt", swigMethodTypes193) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_vertexAtSwigExplicitOdDbLeader(swigCPtr, vertexIndex) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_vertexAt(swigCPtr, vertexIndex), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setVertexAt(int vertexIndex, OdGePoint3d vertex)
	{
		bool result = (SwigDerivedClassHasMethod("setVertexAt", swigMethodTypes194) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setVertexAtSwigExplicitOdDbLeader(swigCPtr, vertexIndex, OdGePoint3d.getCPtr(vertex)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setVertexAt(swigCPtr, vertexIndex, OdGePoint3d.getCPtr(vertex)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isArrowHeadEnabled()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isArrowHeadEnabled(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasArrowHead()
	{
		bool result = (SwigDerivedClassHasMethod("hasArrowHead", swigMethodTypes195) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_hasArrowHeadSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_hasArrowHead(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void enableArrowHead()
	{
		if (SwigDerivedClassHasMethod("enableArrowHead", swigMethodTypes196))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_enableArrowHeadSwigExplicitOdDbLeader(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_enableArrowHead(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void disableArrowHead()
	{
		if (SwigDerivedClassHasMethod("disableArrowHead", swigMethodTypes197))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_disableArrowHeadSwigExplicitOdDbLeader(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_disableArrowHead(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hasHookLine()
	{
		bool result = (SwigDerivedClassHasMethod("hasHookLine", swigMethodTypes198) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_hasHookLineSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_hasHookLine(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isHookLineOnXDir()
	{
		bool result = (SwigDerivedClassHasMethod("isHookLineOnXDir", swigMethodTypes199) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isHookLineOnXDirSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isHookLineOnXDir(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setToSplineLeader()
	{
		if (SwigDerivedClassHasMethod("setToSplineLeader", swigMethodTypes200))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setToSplineLeaderSwigExplicitOdDbLeader(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setToSplineLeader(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setToStraightLeader()
	{
		if (SwigDerivedClassHasMethod("setToStraightLeader", swigMethodTypes201))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setToStraightLeaderSwigExplicitOdDbLeader(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setToStraightLeader(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isSplined()
	{
		bool result = (SwigDerivedClassHasMethod("isSplined", swigMethodTypes202) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isSplinedSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isSplined(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbHardPointerId dimensionStyle()
	{
		OdDbHardPointerId result = new OdDbHardPointerId(SwigDerivedClassHasMethod("dimensionStyle", swigMethodTypes203) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimensionStyleSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimensionStyle(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimensionStyle(OdDbHardPointerId dimStyleId)
	{
		if (SwigDerivedClassHasMethod("setDimensionStyle", swigMethodTypes204))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimensionStyleSwigExplicitOdDbLeader(swigCPtr, OdDbHardPointerId.getCPtr(dimStyleId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimensionStyle(swigCPtr, OdDbHardPointerId.getCPtr(dimStyleId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void attachAnnotation(OdDbObjectId annoId)
	{
		if (SwigDerivedClassHasMethod("attachAnnotation", swigMethodTypes205))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_attachAnnotationSwigExplicitOdDbLeader__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(annoId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_attachAnnotation__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(annoId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void attachAnnotation(OdDbObjectId annoId, OdGeVector3d xDir, double annotationWidth, double annotationHeight, bool hookLineOnXDir)
	{
		if (SwigDerivedClassHasMethod("attachAnnotation", swigMethodTypes206))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_attachAnnotationSwigExplicitOdDbLeader__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(annoId), OdGeVector3d.getCPtr(xDir), annotationWidth, annotationHeight, hookLineOnXDir);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_attachAnnotation__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(annoId), OdGeVector3d.getCPtr(xDir), annotationWidth, annotationHeight, hookLineOnXDir);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void detachAnnotation()
	{
		if (SwigDerivedClassHasMethod("detachAnnotation", swigMethodTypes207))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_detachAnnotationSwigExplicitOdDbLeader(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_detachAnnotation(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId annotationObjId()
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("annotationObjId", swigMethodTypes208) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_annotationObjIdSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_annotationObjId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d annotationXDir()
	{
		OdGeVector3d result = new OdGeVector3d(SwigDerivedClassHasMethod("annotationXDir", swigMethodTypes209) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_annotationXDirSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_annotationXDir(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d annotationOffset()
	{
		OdGeVector3d result = new OdGeVector3d(SwigDerivedClassHasMethod("annotationOffset", swigMethodTypes210) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_annotationOffsetSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_annotationOffset(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAnnotationOffset(OdGeVector3d offset)
	{
		if (SwigDerivedClassHasMethod("setAnnotationOffset", swigMethodTypes211))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setAnnotationOffsetSwigExplicitOdDbLeader(swigCPtr, OdGeVector3d.getCPtr(offset));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setAnnotationOffset(swigCPtr, OdGeVector3d.getCPtr(offset));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbLeader_AnnoType annoType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_annoType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbLeader_AnnoType)result;
	}

	public double annoHeight()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_annoHeight(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double annoWidth()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_annoWidth(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double dimasz()
	{
		double result = (SwigDerivedClassHasMethod("dimasz", swigMethodTypes212) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimaszSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimasz(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor dimclrd()
	{
		OdCmColor result = new OdCmColor(SwigDerivedClassHasMethod("dimclrd", swigMethodTypes213) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimclrdSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimclrd(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double dimgap()
	{
		double result = (SwigDerivedClassHasMethod("dimgap", swigMethodTypes214) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimgapSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimgap(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual LineWeight dimlwd()
	{
		int result = (SwigDerivedClassHasMethod("dimlwd", swigMethodTypes215) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimlwdSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimlwd(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual OdDbObjectId dimldrblk()
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("dimldrblk", swigMethodTypes216) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimldrblkSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimldrblk(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool dimsah()
	{
		bool result = (SwigDerivedClassHasMethod("dimsah", swigMethodTypes217) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimsahSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimsah(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double dimscale()
	{
		double result = (SwigDerivedClassHasMethod("dimscale", swigMethodTypes218) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimscaleSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimscale(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int dimtad()
	{
		int result = (SwigDerivedClassHasMethod("dimtad", swigMethodTypes219) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimtadSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimtad(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId dimtxsty()
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("dimtxsty", swigMethodTypes220) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimtxstySwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimtxsty(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double dimtxt()
	{
		double result = (SwigDerivedClassHasMethod("dimtxt", swigMethodTypes221) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimtxtSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dimtxt(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimasz(double val)
	{
		if (SwigDerivedClassHasMethod("setDimasz", swigMethodTypes222))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimaszSwigExplicitOdDbLeader(swigCPtr, val);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimasz(swigCPtr, val);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimclrd(OdCmColor val)
	{
		if (SwigDerivedClassHasMethod("setDimclrd", swigMethodTypes223))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimclrdSwigExplicitOdDbLeader(swigCPtr, OdCmColor.getCPtr(val));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimclrd(swigCPtr, OdCmColor.getCPtr(val));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimgap(double val)
	{
		if (SwigDerivedClassHasMethod("setDimgap", swigMethodTypes224))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimgapSwigExplicitOdDbLeader(swigCPtr, val);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimgap(swigCPtr, val);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimldrblk(OdDbObjectId val)
	{
		if (SwigDerivedClassHasMethod("setDimldrblk", swigMethodTypes225))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimldrblkSwigExplicitOdDbLeader__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(val));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimldrblk__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(val));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimldrblk(string val)
	{
		if (SwigDerivedClassHasMethod("setDimldrblk", swigMethodTypes226))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimldrblkSwigExplicitOdDbLeader__SWIG_1(swigCPtr, val);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimldrblk__SWIG_1(swigCPtr, val);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimlwd(LineWeight val)
	{
		if (SwigDerivedClassHasMethod("setDimlwd", swigMethodTypes227))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimlwdSwigExplicitOdDbLeader(swigCPtr, (int)val);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimlwd(swigCPtr, (int)val);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimsah(bool val)
	{
		if (SwigDerivedClassHasMethod("setDimsah", swigMethodTypes228))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimsahSwigExplicitOdDbLeader(swigCPtr, val);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimsah(swigCPtr, val);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimscale(double val)
	{
		if (SwigDerivedClassHasMethod("setDimscale", swigMethodTypes229))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimscaleSwigExplicitOdDbLeader(swigCPtr, val);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimscale(swigCPtr, val);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimtad(int val)
	{
		if (SwigDerivedClassHasMethod("setDimtad", swigMethodTypes230))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimtadSwigExplicitOdDbLeader(swigCPtr, val);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimtad(swigCPtr, val);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimtxsty(OdDbObjectId val)
	{
		if (SwigDerivedClassHasMethod("setDimtxsty", swigMethodTypes231))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimtxstySwigExplicitOdDbLeader(swigCPtr, OdDbObjectId.getCPtr(val));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimtxsty(swigCPtr, OdDbObjectId.getCPtr(val));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimtxt(double val)
	{
		if (SwigDerivedClassHasMethod("setDimtxt", swigMethodTypes232))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimtxtSwigExplicitOdDbLeader(swigCPtr, val);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimtxt(swigCPtr, val);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dwgInFieldsSwigExplicitOdDbLeader(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dwgOutFieldsSwigExplicitOdDbLeader(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dxfInFieldsSwigExplicitOdDbLeader(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dxfOutFieldsSwigExplicitOdDbLeader(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_subCloseSwigExplicitOdDbLeader(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_subClose(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isPlanar()
	{
		bool result = (SwigDerivedClassHasMethod("isPlanar", swigMethodTypes99) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isPlanarSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isPlanar(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult getPlane(OdGePlane plane, out OdDb_Planarity planarity)
	{
		int result = (SwigDerivedClassHasMethod("getPlane", swigMethodTypes100) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getPlaneSwigExplicitOdDbLeader(swigCPtr, OdGePlane.getCPtr(plane), out planarity) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getPlane(swigCPtr, OdGePlane.getCPtr(plane), out planarity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override bool isClosed()
	{
		bool result = (SwigDerivedClassHasMethod("isClosed", swigMethodTypes150) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isClosedSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isClosed(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isPeriodic()
	{
		bool result = (SwigDerivedClassHasMethod("isPeriodic", swigMethodTypes151) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isPeriodicSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_isPeriodic(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult getStartParam(out double startParam)
	{
		int result = (SwigDerivedClassHasMethod("getStartParam", swigMethodTypes152) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getStartParamSwigExplicitOdDbLeader(swigCPtr, out startParam) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getStartParam(swigCPtr, out startParam));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getEndParam(out double endParam)
	{
		int result = (SwigDerivedClassHasMethod("getEndParam", swigMethodTypes153) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getEndParamSwigExplicitOdDbLeader(swigCPtr, out endParam) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getEndParam(swigCPtr, out endParam));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getStartPoint(OdGePoint3d startPoint)
	{
		int result = (SwigDerivedClassHasMethod("getStartPoint", swigMethodTypes154) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getStartPointSwigExplicitOdDbLeader(swigCPtr, OdGePoint3d.getCPtr(startPoint)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getStartPoint(swigCPtr, OdGePoint3d.getCPtr(startPoint)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getEndPoint(OdGePoint3d endPoint)
	{
		int result = (SwigDerivedClassHasMethod("getEndPoint", swigMethodTypes155) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getEndPointSwigExplicitOdDbLeader(swigCPtr, OdGePoint3d.getCPtr(endPoint)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getEndPoint(swigCPtr, OdGePoint3d.getCPtr(endPoint)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getPointAtParam(double param, OdGePoint3d pointOnCurve)
	{
		int result = (SwigDerivedClassHasMethod("getPointAtParam", swigMethodTypes156) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getPointAtParamSwigExplicitOdDbLeader(swigCPtr, param, OdGePoint3d.getCPtr(pointOnCurve)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getPointAtParam(swigCPtr, param, OdGePoint3d.getCPtr(pointOnCurve)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getParamAtPoint(OdGePoint3d pointOnCurve, out double param)
	{
		int result = (SwigDerivedClassHasMethod("getParamAtPoint", swigMethodTypes157) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getParamAtPointSwigExplicitOdDbLeader(swigCPtr, OdGePoint3d.getCPtr(pointOnCurve), out param) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getParamAtPoint(swigCPtr, OdGePoint3d.getCPtr(pointOnCurve), out param));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getDistAtParam(double param, out double dist)
	{
		int result = (SwigDerivedClassHasMethod("getDistAtParam", swigMethodTypes158) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getDistAtParamSwigExplicitOdDbLeader(swigCPtr, param, out dist) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getDistAtParam(swigCPtr, param, out dist));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getParamAtDist(double dist, out double param)
	{
		int result = (SwigDerivedClassHasMethod("getParamAtDist", swigMethodTypes159) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getParamAtDistSwigExplicitOdDbLeader(swigCPtr, dist, out param) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getParamAtDist(swigCPtr, dist, out param));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getFirstDeriv(double param, OdGeVector3d firstDeriv)
	{
		int result = (SwigDerivedClassHasMethod("getFirstDeriv", swigMethodTypes162) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getFirstDerivSwigExplicitOdDbLeader(swigCPtr, param, OdGeVector3d.getCPtr(firstDeriv)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getFirstDeriv(swigCPtr, param, OdGeVector3d.getCPtr(firstDeriv)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getSecondDeriv(double param, OdGeVector3d secondDeriv)
	{
		int result = (SwigDerivedClassHasMethod("getSecondDeriv", swigMethodTypes164) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getSecondDerivSwigExplicitOdDbLeader(swigCPtr, param, OdGeVector3d.getCPtr(secondDeriv)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getSecondDeriv(swigCPtr, param, OdGeVector3d.getCPtr(secondDeriv)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getOdGeCurve(out OdGeCurve3d pGeCurve, OdGeTol tol)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = (SwigDerivedClassHasMethod("getOdGeCurve", swigMethodTypes181) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getOdGeCurveSwigExplicitOdDbLeader(swigCPtr, out jarg, OdGeTol.getCPtr(tol)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getOdGeCurve(swigCPtr, out jarg, OdGeTol.getCPtr(tol)));
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

	public override OdResult getArea(out double area)
	{
		int result = (SwigDerivedClassHasMethod("getArea", swigMethodTypes173) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getAreaSwigExplicitOdDbLeader(swigCPtr, out area) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getArea(swigCPtr, out area));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void subSetDatabaseDefaults(OdDbDatabase pDb, bool doSubents)
	{
		if (SwigDerivedClassHasMethod("subSetDatabaseDefaults", swigMethodTypes106))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_subSetDatabaseDefaultsSwigExplicitOdDbLeader(swigCPtr, OdDbDatabase.getCPtr(pDb), doSubents);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_subSetDatabaseDefaults(swigCPtr, OdDbDatabase.getCPtr(pDb), doSubents);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult evaluateLeader()
	{
		int result = (SwigDerivedClassHasMethod("evaluateLeader", swigMethodTypes233) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_evaluateLeaderSwigExplicitOdDbLeader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_evaluateLeader(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void modifiedGraphics(OdDbObject pObject)
	{
		if (SwigDerivedClassHasMethod("modifiedGraphics", swigMethodTypes46))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_modifiedGraphicsSwigExplicitOdDbLeader(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_modifiedGraphics(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void erased(OdDbObject pObject, bool erasing)
	{
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes35))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_erasedSwigExplicitOdDbLeader__SWIG_0(swigCPtr, OdDbObject.getCPtr(pObject), erasing);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_erased__SWIG_0(swigCPtr, OdDbObject.getCPtr(pObject), erasing);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void erased(OdDbObject pObject)
	{
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes36))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_erasedSwigExplicitOdDbLeader__SWIG_1(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_erased__SWIG_1(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDimstyleData(OdDbDimStyleTableRecord pRecord)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getDimstyleData(swigCPtr, OdDbDimStyleTableRecord.getCPtr(pRecord));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDimstyleData(OdDbDimStyleTableRecord pDimstyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimstyleData__SWIG_0(swigCPtr, OdDbDimStyleTableRecord.getCPtr(pDimstyle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDimstyleData(OdDbObjectId dimstyleID)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setDimstyleData__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(dimstyleID));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPlane(OdGePlane leaderPlane)
	{
		if (SwigDerivedClassHasMethod("setPlane", swigMethodTypes234))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setPlaneSwigExplicitOdDbLeader(swigCPtr, OdGePlane.getCPtr(leaderPlane));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_setPlane(swigCPtr, OdGePlane.getCPtr(leaderPlane));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult getSplitCurves(OdGePoint3dArray points, OdRxObjectPtrArray curveSegments)
	{
		int result = (SwigDerivedClassHasMethod("getSplitCurves", swigMethodTypes179) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getSplitCurvesSwigExplicitOdDbLeader__SWIG_0(swigCPtr, OdGePoint3dArray.getCPtr(points).Handle, OdRxObjectPtrArray.getCPtr(curveSegments).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getSplitCurves__SWIG_0(swigCPtr, OdGePoint3dArray.getCPtr(points).Handle, OdRxObjectPtrArray.getCPtr(curveSegments).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getSplitCurves(OdDoubleArray params_, OdRxObjectPtrArray curveSegments)
	{
		int result = (SwigDerivedClassHasMethod("getSplitCurves", swigMethodTypes178) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getSplitCurvesSwigExplicitOdDbLeader__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(params_).Handle, OdRxObjectPtrArray.getCPtr(curveSegments).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getSplitCurves__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(params_).Handle, OdRxObjectPtrArray.getCPtr(curveSegments).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected override OdResult subGetSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d arg2, OdGeMatrix3d arg3, OdDbFullSubentPathArray subentPaths, OdDbObjectIdArray pEntAndInsertStack)
	{
		int result = (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes142) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_subGetSubentPathsAtGsMarkerSwigExplicitOdDbLeader(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(arg2), OdGeMatrix3d.getCPtr(arg3), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(pEntAndInsertStack)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_subGetSubentPathsAtGsMarker(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(arg2), OdGeMatrix3d.getCPtr(arg3), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(pEntAndInsertStack)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected override OdResult subGetGsMarkersAtSubentPath(OdDbFullSubentPath subPath, OdGsMarkerArray gsMarkers)
	{
		int result = (SwigDerivedClassHasMethod("subGetGsMarkersAtSubentPath", swigMethodTypes144) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_subGetGsMarkersAtSubentPathSwigExplicitOdDbLeader(swigCPtr, OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_subGetGsMarkersAtSubentPath(swigCPtr, OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult SubGetClassID(IntPtr pClsid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_SubGetClassID(swigCPtr, pClsid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override bool SubWorldDraw(OdGiWorldDraw pWd)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_SubWorldDraw(swigCPtr, OdGiWorldDraw.getCPtr(pWd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void SubViewportDraw(OdGiViewportDraw pVd)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_SubViewportDraw(swigCPtr, OdGiViewportDraw.getCPtr(pVd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult SubExplode(OdRxObjectPtrArray entitySet)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_SubExplode(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override uint SubSetAttributes(OdGiDrawableTraits pTraits)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_SubSetAttributes(swigCPtr, OdGiDrawableTraits.getCPtr(pTraits));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult SubTransformBy(OdGeMatrix3d xfm)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_SubTransformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubGetTransformedCopy(OdGeMatrix3d xform, ref OdDbEntity pEnt)
	{
		IntPtr jarg = ((pEnt == null) ? IntPtr.Zero : OdDbEntity.getCPtr(pEnt).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_SubGetTransformedCopy(swigCPtr, OdGeMatrix3d.getCPtr(xform), ref jarg);
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

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbLeader createObject()
	{
		OdDbLeader rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLeader>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_createObject(), bOwn: true, bTryAddToTransaction: true);
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
			swigDelegate142 = SwigDirectorMethodsubGetSubentPathsAtGsMarker;
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
		if (SwigDerivedClassHasMethod("isClosed", swigMethodTypes150))
		{
			swigDelegate150 = SwigDirectorMethodisClosed;
		}
		if (SwigDerivedClassHasMethod("isPeriodic", swigMethodTypes151))
		{
			swigDelegate151 = SwigDirectorMethodisPeriodic;
		}
		if (SwigDerivedClassHasMethod("getStartParam", swigMethodTypes152))
		{
			swigDelegate152 = SwigDirectorMethodgetStartParam;
		}
		if (SwigDerivedClassHasMethod("getEndParam", swigMethodTypes153))
		{
			swigDelegate153 = SwigDirectorMethodgetEndParam;
		}
		if (SwigDerivedClassHasMethod("getStartPoint", swigMethodTypes154))
		{
			swigDelegate154 = SwigDirectorMethodgetStartPoint;
		}
		if (SwigDerivedClassHasMethod("getEndPoint", swigMethodTypes155))
		{
			swigDelegate155 = SwigDirectorMethodgetEndPoint;
		}
		if (SwigDerivedClassHasMethod("getPointAtParam", swigMethodTypes156))
		{
			swigDelegate156 = SwigDirectorMethodgetPointAtParam;
		}
		if (SwigDerivedClassHasMethod("getParamAtPoint", swigMethodTypes157))
		{
			swigDelegate157 = SwigDirectorMethodgetParamAtPoint;
		}
		if (SwigDerivedClassHasMethod("getDistAtParam", swigMethodTypes158))
		{
			swigDelegate158 = SwigDirectorMethodgetDistAtParam;
		}
		if (SwigDerivedClassHasMethod("getParamAtDist", swigMethodTypes159))
		{
			swigDelegate159 = SwigDirectorMethodgetParamAtDist;
		}
		if (SwigDerivedClassHasMethod("getDistAtPoint", swigMethodTypes160))
		{
			swigDelegate160 = SwigDirectorMethodgetDistAtPoint;
		}
		if (SwigDerivedClassHasMethod("getPointAtDist", swigMethodTypes161))
		{
			swigDelegate161 = SwigDirectorMethodgetPointAtDist;
		}
		if (SwigDerivedClassHasMethod("getFirstDeriv", swigMethodTypes162))
		{
			swigDelegate162 = SwigDirectorMethodgetFirstDeriv;
		}
		if (SwigDerivedClassHasMethod("getFirstDeriv", swigMethodTypes163))
		{
			swigDelegate163 = SwigDirectorMethodgetFirstDeriv__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getSecondDeriv", swigMethodTypes164))
		{
			swigDelegate164 = SwigDirectorMethodgetSecondDeriv;
		}
		if (SwigDerivedClassHasMethod("getSecondDeriv", swigMethodTypes165))
		{
			swigDelegate165 = SwigDirectorMethodgetSecondDeriv__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getClosestPointTo", swigMethodTypes166))
		{
			swigDelegate166 = SwigDirectorMethodgetClosestPointTo__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getClosestPointTo", swigMethodTypes167))
		{
			swigDelegate167 = SwigDirectorMethodgetClosestPointTo__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getClosestPointTo", swigMethodTypes168))
		{
			swigDelegate168 = SwigDirectorMethodgetClosestPointTo__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getClosestPointTo", swigMethodTypes169))
		{
			swigDelegate169 = SwigDirectorMethodgetClosestPointTo__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getSpline", swigMethodTypes170))
		{
			swigDelegate170 = SwigDirectorMethodgetSpline;
		}
		if (SwigDerivedClassHasMethod("extend", swigMethodTypes171))
		{
			swigDelegate171 = SwigDirectorMethodextend__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("extend", swigMethodTypes172))
		{
			swigDelegate172 = SwigDirectorMethodextend__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getArea", swigMethodTypes173))
		{
			swigDelegate173 = SwigDirectorMethodgetArea;
		}
		if (SwigDerivedClassHasMethod("getOrthoProjectedCurve", swigMethodTypes174))
		{
			swigDelegate174 = SwigDirectorMethodgetOrthoProjectedCurve;
		}
		if (SwigDerivedClassHasMethod("getProjectedCurve", swigMethodTypes175))
		{
			swigDelegate175 = SwigDirectorMethodgetProjectedCurve;
		}
		if (SwigDerivedClassHasMethod("getOffsetCurves", swigMethodTypes176))
		{
			swigDelegate176 = SwigDirectorMethodgetOffsetCurves;
		}
		if (SwigDerivedClassHasMethod("getOffsetCurvesGivenPlaneNormal", swigMethodTypes177))
		{
			swigDelegate177 = SwigDirectorMethodgetOffsetCurvesGivenPlaneNormal;
		}
		if (SwigDerivedClassHasMethod("getSplitCurves", swigMethodTypes178))
		{
			swigDelegate178 = SwigDirectorMethodgetSplitCurves__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getSplitCurves", swigMethodTypes179))
		{
			swigDelegate179 = SwigDirectorMethodgetSplitCurves__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("reverseCurve", swigMethodTypes180))
		{
			swigDelegate180 = SwigDirectorMethodreverseCurve;
		}
		if (SwigDerivedClassHasMethod("getOdGeCurve", swigMethodTypes181))
		{
			swigDelegate181 = SwigDirectorMethodgetOdGeCurve;
		}
		if (SwigDerivedClassHasMethod("getOdGeCurve", swigMethodTypes182))
		{
			swigDelegate182 = SwigDirectorMethodgetOdGeCurve__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setFromOdGeCurve", swigMethodTypes183))
		{
			swigDelegate183 = SwigDirectorMethodsetFromOdGeCurve__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setFromOdGeCurve", swigMethodTypes184))
		{
			swigDelegate184 = SwigDirectorMethodsetFromOdGeCurve__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setFromOdGeCurve", swigMethodTypes185))
		{
			swigDelegate185 = SwigDirectorMethodsetFromOdGeCurve__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("findVertexIndex", swigMethodTypes186))
		{
			swigDelegate186 = SwigDirectorMethodfindVertexIndex;
		}
		if (SwigDerivedClassHasMethod("normal", swigMethodTypes187))
		{
			swigDelegate187 = SwigDirectorMethodnormal;
		}
		if (SwigDerivedClassHasMethod("numVertices", swigMethodTypes188))
		{
			swigDelegate188 = SwigDirectorMethodnumVertices;
		}
		if (SwigDerivedClassHasMethod("appendVertex", swigMethodTypes189))
		{
			swigDelegate189 = SwigDirectorMethodappendVertex;
		}
		if (SwigDerivedClassHasMethod("removeLastVertex", swigMethodTypes190))
		{
			swigDelegate190 = SwigDirectorMethodremoveLastVertex;
		}
		if (SwigDerivedClassHasMethod("firstVertex", swigMethodTypes191))
		{
			swigDelegate191 = SwigDirectorMethodfirstVertex;
		}
		if (SwigDerivedClassHasMethod("lastVertex", swigMethodTypes192))
		{
			swigDelegate192 = SwigDirectorMethodlastVertex;
		}
		if (SwigDerivedClassHasMethod("vertexAt", swigMethodTypes193))
		{
			swigDelegate193 = SwigDirectorMethodvertexAt;
		}
		if (SwigDerivedClassHasMethod("setVertexAt", swigMethodTypes194))
		{
			swigDelegate194 = SwigDirectorMethodsetVertexAt;
		}
		if (SwigDerivedClassHasMethod("hasArrowHead", swigMethodTypes195))
		{
			swigDelegate195 = SwigDirectorMethodhasArrowHead;
		}
		if (SwigDerivedClassHasMethod("enableArrowHead", swigMethodTypes196))
		{
			swigDelegate196 = SwigDirectorMethodenableArrowHead;
		}
		if (SwigDerivedClassHasMethod("disableArrowHead", swigMethodTypes197))
		{
			swigDelegate197 = SwigDirectorMethoddisableArrowHead;
		}
		if (SwigDerivedClassHasMethod("hasHookLine", swigMethodTypes198))
		{
			swigDelegate198 = SwigDirectorMethodhasHookLine;
		}
		if (SwigDerivedClassHasMethod("isHookLineOnXDir", swigMethodTypes199))
		{
			swigDelegate199 = SwigDirectorMethodisHookLineOnXDir;
		}
		if (SwigDerivedClassHasMethod("setToSplineLeader", swigMethodTypes200))
		{
			swigDelegate200 = SwigDirectorMethodsetToSplineLeader;
		}
		if (SwigDerivedClassHasMethod("setToStraightLeader", swigMethodTypes201))
		{
			swigDelegate201 = SwigDirectorMethodsetToStraightLeader;
		}
		if (SwigDerivedClassHasMethod("isSplined", swigMethodTypes202))
		{
			swigDelegate202 = SwigDirectorMethodisSplined;
		}
		if (SwigDerivedClassHasMethod("dimensionStyle", swigMethodTypes203))
		{
			swigDelegate203 = SwigDirectorMethoddimensionStyle;
		}
		if (SwigDerivedClassHasMethod("setDimensionStyle", swigMethodTypes204))
		{
			swigDelegate204 = SwigDirectorMethodsetDimensionStyle;
		}
		if (SwigDerivedClassHasMethod("attachAnnotation", swigMethodTypes205))
		{
			swigDelegate205 = SwigDirectorMethodattachAnnotation__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("attachAnnotation", swigMethodTypes206))
		{
			swigDelegate206 = SwigDirectorMethodattachAnnotation__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("detachAnnotation", swigMethodTypes207))
		{
			swigDelegate207 = SwigDirectorMethoddetachAnnotation;
		}
		if (SwigDerivedClassHasMethod("annotationObjId", swigMethodTypes208))
		{
			swigDelegate208 = SwigDirectorMethodannotationObjId;
		}
		if (SwigDerivedClassHasMethod("annotationXDir", swigMethodTypes209))
		{
			swigDelegate209 = SwigDirectorMethodannotationXDir;
		}
		if (SwigDerivedClassHasMethod("annotationOffset", swigMethodTypes210))
		{
			swigDelegate210 = SwigDirectorMethodannotationOffset;
		}
		if (SwigDerivedClassHasMethod("setAnnotationOffset", swigMethodTypes211))
		{
			swigDelegate211 = SwigDirectorMethodsetAnnotationOffset;
		}
		if (SwigDerivedClassHasMethod("dimasz", swigMethodTypes212))
		{
			swigDelegate212 = SwigDirectorMethoddimasz;
		}
		if (SwigDerivedClassHasMethod("dimclrd", swigMethodTypes213))
		{
			swigDelegate213 = SwigDirectorMethoddimclrd;
		}
		if (SwigDerivedClassHasMethod("dimgap", swigMethodTypes214))
		{
			swigDelegate214 = SwigDirectorMethoddimgap;
		}
		if (SwigDerivedClassHasMethod("dimlwd", swigMethodTypes215))
		{
			swigDelegate215 = SwigDirectorMethoddimlwd;
		}
		if (SwigDerivedClassHasMethod("dimldrblk", swigMethodTypes216))
		{
			swigDelegate216 = SwigDirectorMethoddimldrblk;
		}
		if (SwigDerivedClassHasMethod("dimsah", swigMethodTypes217))
		{
			swigDelegate217 = SwigDirectorMethoddimsah;
		}
		if (SwigDerivedClassHasMethod("dimscale", swigMethodTypes218))
		{
			swigDelegate218 = SwigDirectorMethoddimscale;
		}
		if (SwigDerivedClassHasMethod("dimtad", swigMethodTypes219))
		{
			swigDelegate219 = SwigDirectorMethoddimtad;
		}
		if (SwigDerivedClassHasMethod("dimtxsty", swigMethodTypes220))
		{
			swigDelegate220 = SwigDirectorMethoddimtxsty;
		}
		if (SwigDerivedClassHasMethod("dimtxt", swigMethodTypes221))
		{
			swigDelegate221 = SwigDirectorMethoddimtxt;
		}
		if (SwigDerivedClassHasMethod("setDimasz", swigMethodTypes222))
		{
			swigDelegate222 = SwigDirectorMethodsetDimasz;
		}
		if (SwigDerivedClassHasMethod("setDimclrd", swigMethodTypes223))
		{
			swigDelegate223 = SwigDirectorMethodsetDimclrd;
		}
		if (SwigDerivedClassHasMethod("setDimgap", swigMethodTypes224))
		{
			swigDelegate224 = SwigDirectorMethodsetDimgap;
		}
		if (SwigDerivedClassHasMethod("setDimldrblk", swigMethodTypes225))
		{
			swigDelegate225 = SwigDirectorMethodsetDimldrblk__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDimldrblk", swigMethodTypes226))
		{
			swigDelegate226 = SwigDirectorMethodsetDimldrblk__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setDimlwd", swigMethodTypes227))
		{
			swigDelegate227 = SwigDirectorMethodsetDimlwd;
		}
		if (SwigDerivedClassHasMethod("setDimsah", swigMethodTypes228))
		{
			swigDelegate228 = SwigDirectorMethodsetDimsah;
		}
		if (SwigDerivedClassHasMethod("setDimscale", swigMethodTypes229))
		{
			swigDelegate229 = SwigDirectorMethodsetDimscale;
		}
		if (SwigDerivedClassHasMethod("setDimtad", swigMethodTypes230))
		{
			swigDelegate230 = SwigDirectorMethodsetDimtad;
		}
		if (SwigDerivedClassHasMethod("setDimtxsty", swigMethodTypes231))
		{
			swigDelegate231 = SwigDirectorMethodsetDimtxsty;
		}
		if (SwigDerivedClassHasMethod("setDimtxt", swigMethodTypes232))
		{
			swigDelegate232 = SwigDirectorMethodsetDimtxt;
		}
		if (SwigDerivedClassHasMethod("evaluateLeader", swigMethodTypes233))
		{
			swigDelegate233 = SwigDirectorMethodevaluateLeader;
		}
		if (SwigDerivedClassHasMethod("setPlane", swigMethodTypes234))
		{
			swigDelegate234 = SwigDirectorMethodsetPlane;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLeader_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125, swigDelegate126, swigDelegate127, swigDelegate128, swigDelegate129, swigDelegate130, swigDelegate131, swigDelegate132, swigDelegate133, swigDelegate134, swigDelegate135, swigDelegate136, swigDelegate137, swigDelegate138, swigDelegate139, swigDelegate140, swigDelegate141, swigDelegate142, swigDelegate143, swigDelegate144, swigDelegate145, swigDelegate146, swigDelegate147, swigDelegate148, swigDelegate149, swigDelegate150, swigDelegate151, swigDelegate152, swigDelegate153, swigDelegate154, swigDelegate155, swigDelegate156, swigDelegate157, swigDelegate158, swigDelegate159, swigDelegate160, swigDelegate161, swigDelegate162, swigDelegate163, swigDelegate164, swigDelegate165, swigDelegate166, swigDelegate167, swigDelegate168, swigDelegate169, swigDelegate170, swigDelegate171, swigDelegate172, swigDelegate173, swigDelegate174, swigDelegate175, swigDelegate176, swigDelegate177, swigDelegate178, swigDelegate179, swigDelegate180, swigDelegate181, swigDelegate182, swigDelegate183, swigDelegate184, swigDelegate185, swigDelegate186, swigDelegate187, swigDelegate188, swigDelegate189, swigDelegate190, swigDelegate191, swigDelegate192, swigDelegate193, swigDelegate194, swigDelegate195, swigDelegate196, swigDelegate197, swigDelegate198, swigDelegate199, swigDelegate200, swigDelegate201, swigDelegate202, swigDelegate203, swigDelegate204, swigDelegate205, swigDelegate206, swigDelegate207, swigDelegate208, swigDelegate209, swigDelegate210, swigDelegate211, swigDelegate212, swigDelegate213, swigDelegate214, swigDelegate215, swigDelegate216, swigDelegate217, swigDelegate218, swigDelegate219, swigDelegate220, swigDelegate221, swigDelegate222, swigDelegate223, swigDelegate224, swigDelegate225, swigDelegate226, swigDelegate227, swigDelegate228, swigDelegate229, swigDelegate230, swigDelegate231, swigDelegate232, swigDelegate233, swigDelegate234);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbLeader));
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

	private int SwigDirectorMethodsubGetSubentPathsAtGsMarker(int type, IntPtr gsMark, IntPtr arg2, IntPtr arg3, IntPtr subentPaths, IntPtr pEntAndInsertStack)
	{
		return (int)subGetSubentPathsAtGsMarker((OdDb_SubentType)type, gsMark, new OdGePoint3d(arg2, cMemoryOwn: false), new OdGeMatrix3d(arg3, cMemoryOwn: false), new OdDbFullSubentPathArray(subentPaths, cMemoryOwn: false), (pEntAndInsertStack == IntPtr.Zero) ? null : new OdDbObjectIdArray(pEntAndInsertStack, cMemoryOwn: false));
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

	private int SwigDirectorMethodgetOdGeCurve(IntPtr pGeCurve, IntPtr tol)
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

	private IntPtr SwigDirectorMethodnormal()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(normal()).Handle;
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

	private int SwigDirectorMethodnumVertices()
	{
		return numVertices();
	}

	private bool SwigDirectorMethodappendVertex(IntPtr vertex)
	{
		return appendVertex(new OdGePoint3d(vertex, cMemoryOwn: false));
	}

	private void SwigDirectorMethodremoveLastVertex()
	{
		try
		{
			removeLastVertex();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodfirstVertex()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(firstVertex()).Handle;
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

	private IntPtr SwigDirectorMethodlastVertex()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(lastVertex()).Handle;
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

	private IntPtr SwigDirectorMethodvertexAt(int vertexIndex)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(vertexAt(vertexIndex)).Handle;
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

	private bool SwigDirectorMethodsetVertexAt(int vertexIndex, IntPtr vertex)
	{
		return setVertexAt(vertexIndex, new OdGePoint3d(vertex, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodhasArrowHead()
	{
		return hasArrowHead();
	}

	private void SwigDirectorMethodenableArrowHead()
	{
		try
		{
			enableArrowHead();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddisableArrowHead()
	{
		try
		{
			disableArrowHead();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodhasHookLine()
	{
		return hasHookLine();
	}

	private bool SwigDirectorMethodisHookLineOnXDir()
	{
		return isHookLineOnXDir();
	}

	private void SwigDirectorMethodsetToSplineLeader()
	{
		try
		{
			setToSplineLeader();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetToStraightLeader()
	{
		try
		{
			setToStraightLeader();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisSplined()
	{
		return isSplined();
	}

	private IntPtr SwigDirectorMethoddimensionStyle()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbHardPointerId.getCPtr(dimensionStyle()).Handle;
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

	private void SwigDirectorMethodsetDimensionStyle(IntPtr dimStyleId)
	{
		try
		{
			setDimensionStyle(new OdDbHardPointerId(dimStyleId, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodattachAnnotation__SWIG_0(IntPtr annoId)
	{
		try
		{
			attachAnnotation(new OdDbObjectId(annoId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodattachAnnotation__SWIG_1(IntPtr annoId, IntPtr xDir, double annotationWidth, double annotationHeight, bool hookLineOnXDir)
	{
		try
		{
			attachAnnotation(new OdDbObjectId(annoId, cMemoryOwn: true), new OdGeVector3d(xDir, cMemoryOwn: true), annotationWidth, annotationHeight, hookLineOnXDir);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddetachAnnotation()
	{
		try
		{
			detachAnnotation();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodannotationObjId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(annotationObjId()).Handle;
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

	private IntPtr SwigDirectorMethodannotationXDir()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(annotationXDir()).Handle;
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

	private IntPtr SwigDirectorMethodannotationOffset()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(annotationOffset()).Handle;
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

	private void SwigDirectorMethodsetAnnotationOffset(IntPtr offset)
	{
		try
		{
			setAnnotationOffset(new OdGeVector3d(offset, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethoddimasz()
	{
		return dimasz();
	}

	private IntPtr SwigDirectorMethoddimclrd()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(dimclrd()).Handle;
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

	private double SwigDirectorMethoddimgap()
	{
		return dimgap();
	}

	private int SwigDirectorMethoddimlwd()
	{
		return (int)dimlwd();
	}

	private IntPtr SwigDirectorMethoddimldrblk()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(dimldrblk()).Handle;
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

	private bool SwigDirectorMethoddimsah()
	{
		return dimsah();
	}

	private double SwigDirectorMethoddimscale()
	{
		return dimscale();
	}

	private int SwigDirectorMethoddimtad()
	{
		return dimtad();
	}

	private IntPtr SwigDirectorMethoddimtxsty()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(dimtxsty()).Handle;
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

	private double SwigDirectorMethoddimtxt()
	{
		return dimtxt();
	}

	private void SwigDirectorMethodsetDimasz(double val)
	{
		try
		{
			setDimasz(val);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimclrd(IntPtr val)
	{
		try
		{
			setDimclrd(new OdCmColor(val, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimgap(double val)
	{
		try
		{
			setDimgap(val);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimldrblk__SWIG_0(IntPtr val)
	{
		try
		{
			setDimldrblk(new OdDbObjectId(val, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimldrblk__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string val)
	{
		try
		{
			setDimldrblk(val);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimlwd(int val)
	{
		try
		{
			setDimlwd((LineWeight)val);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimsah(bool val)
	{
		try
		{
			setDimsah(val);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimscale(double val)
	{
		try
		{
			setDimscale(val);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimtad(int val)
	{
		try
		{
			setDimtad(val);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimtxsty(IntPtr val)
	{
		try
		{
			setDimtxsty(new OdDbObjectId(val, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimtxt(double val)
	{
		try
		{
			setDimtxt(val);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodevaluateLeader()
	{
		return (int)evaluateLeader();
	}

	private void SwigDirectorMethodsetPlane(IntPtr leaderPlane)
	{
		try
		{
			setPlane(new OdGePlane(leaderPlane, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

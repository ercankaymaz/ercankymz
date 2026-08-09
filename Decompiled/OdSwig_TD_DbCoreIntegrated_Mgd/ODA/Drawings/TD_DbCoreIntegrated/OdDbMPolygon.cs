using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbMPolygon : OdDbEntity
{
	public delegate IntPtr SwigDelegateOdDbMPolygon_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbMPolygon_1();

	public delegate void SwigDelegateOdDbMPolygon_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbMPolygon_3();

	public delegate bool SwigDelegateOdDbMPolygon_4();

	public delegate IntPtr SwigDelegateOdDbMPolygon_5();

	public delegate void SwigDelegateOdDbMPolygon_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbMPolygon_7();

	public delegate void SwigDelegateOdDbMPolygon_8(IntPtr ownerId);

	public delegate int SwigDelegateOdDbMPolygon_9(int mode);

	public delegate void SwigDelegateOdDbMPolygon_10();

	public delegate int SwigDelegateOdDbMPolygon_11(bool erasing);

	public delegate void SwigDelegateOdDbMPolygon_12(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbMPolygon_13(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbMPolygon_14(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbMPolygon_15(IntPtr otherId);

	public delegate void SwigDelegateOdDbMPolygon_16(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbMPolygon_17(IntPtr pFiler);

	public delegate void SwigDelegateOdDbMPolygon_18(IntPtr pFiler);

	public delegate int SwigDelegateOdDbMPolygon_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbMPolygon_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbMPolygon_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbMPolygon_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbMPolygon_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbMPolygon_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbMPolygon_25();

	public delegate IntPtr SwigDelegateOdDbMPolygon_26([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbMPolygon_27(IntPtr pRb);

	public delegate void SwigDelegateOdDbMPolygon_28(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbMPolygon_29(IntPtr objId);

	public delegate void SwigDelegateOdDbMPolygon_30(IntPtr objId);

	public delegate void SwigDelegateOdDbMPolygon_31(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbMPolygon_32();

	public delegate void SwigDelegateOdDbMPolygon_33(IntPtr idPair, IntPtr pOwnerObject, IntPtr ownerIdMap);

	public delegate void SwigDelegateOdDbMPolygon_34(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbMPolygon_35(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbMPolygon_36(IntPtr pObject);

	public delegate void SwigDelegateOdDbMPolygon_37(IntPtr pObject);

	public delegate void SwigDelegateOdDbMPolygon_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbMPolygon_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbMPolygon_40(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbMPolygon_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbMPolygon_42(IntPtr pObject);

	public delegate void SwigDelegateOdDbMPolygon_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbMPolygon_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbMPolygon_45(IntPtr objectId);

	public delegate void SwigDelegateOdDbMPolygon_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbMPolygon_47(IntPtr pSource);

	public delegate int SwigDelegateOdDbMPolygon_48(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbMPolygon_49(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbMPolygon_50(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbMPolygon_51(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbMPolygon_52(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbMPolygon_53();

	public delegate IntPtr SwigDelegateOdDbMPolygon_54([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbMPolygon_55(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbMPolygon_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbMPolygon_57(IntPtr pClass);

	public delegate int SwigDelegateOdDbMPolygon_58(IntPtr color, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_59(IntPtr color);

	public delegate IntPtr SwigDelegateOdDbMPolygon_60();

	public delegate int SwigDelegateOdDbMPolygon_61(ushort colorIndex, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_62(ushort colorIndex);

	public delegate int SwigDelegateOdDbMPolygon_63(IntPtr colorId, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_64(IntPtr colorId);

	public delegate int SwigDelegateOdDbMPolygon_65(IntPtr transparency, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_66(IntPtr transparency);

	public delegate int SwigDelegateOdDbMPolygon_67([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_68([MarshalAs(UnmanagedType.LPWStr)] string plotStyleName);

	public delegate int SwigDelegateOdDbMPolygon_69(int plotStyleNameType, IntPtr plotStyleNameId, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_70(int plotStyleNameType, IntPtr plotStyleNameId);

	public delegate int SwigDelegateOdDbMPolygon_71(int plotStyleNameType);

	public delegate int SwigDelegateOdDbMPolygon_72([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbMPolygon_73([MarshalAs(UnmanagedType.LPWStr)] string layerName, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_74([MarshalAs(UnmanagedType.LPWStr)] string layerName);

	public delegate int SwigDelegateOdDbMPolygon_75(IntPtr layerId, bool doSubents, bool allowHiddenLayer);

	public delegate int SwigDelegateOdDbMPolygon_76(IntPtr layerId, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_77(IntPtr layerId);

	public delegate int SwigDelegateOdDbMPolygon_78([MarshalAs(UnmanagedType.LPWStr)] string linetypeName, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_79([MarshalAs(UnmanagedType.LPWStr)] string linetypeName);

	public delegate int SwigDelegateOdDbMPolygon_80(IntPtr linetypeID, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_81(IntPtr linetypeID);

	public delegate int SwigDelegateOdDbMPolygon_82([MarshalAs(UnmanagedType.LPWStr)] string materialName, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_83([MarshalAs(UnmanagedType.LPWStr)] string materialName);

	public delegate int SwigDelegateOdDbMPolygon_84(IntPtr materialID, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_85(IntPtr materialID);

	public delegate int SwigDelegateOdDbMPolygon_86(IntPtr visualStyleId, int vstype, bool doSubents);

	public delegate IntPtr SwigDelegateOdDbMPolygon_87();

	public delegate void SwigDelegateOdDbMPolygon_88(IntPtr mapper, bool doSubents);

	public delegate void SwigDelegateOdDbMPolygon_89(IntPtr mapper);

	public delegate int SwigDelegateOdDbMPolygon_90(double linetypeScale, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_91(double linetypeScale);

	public delegate int SwigDelegateOdDbMPolygon_92(int lineWeight, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_93(int lineWeight);

	public delegate bool SwigDelegateOdDbMPolygon_94();

	public delegate void SwigDelegateOdDbMPolygon_95(bool castShadows);

	public delegate bool SwigDelegateOdDbMPolygon_96();

	public delegate void SwigDelegateOdDbMPolygon_97(bool receiveShadows);

	public delegate int SwigDelegateOdDbMPolygon_98();

	public delegate bool SwigDelegateOdDbMPolygon_99();

	public delegate int SwigDelegateOdDbMPolygon_100(IntPtr plane, OdDb_Planarity planarity);

	public delegate int SwigDelegateOdDbMPolygon_101(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbMPolygon_102(IntPtr pBlockRecord);

	public delegate int SwigDelegateOdDbMPolygon_103(IntPtr entitySet);

	public delegate int SwigDelegateOdDbMPolygon_104(IntPtr pBlockRecord, IntPtr ids);

	public delegate int SwigDelegateOdDbMPolygon_105(IntPtr pBlockRecord);

	public delegate void SwigDelegateOdDbMPolygon_106(IntPtr pDb, bool doSubents);

	public delegate void SwigDelegateOdDbMPolygon_107();

	public delegate void SwigDelegateOdDbMPolygon_108(int status);

	public delegate void SwigDelegateOdDbMPolygon_109(IntPtr pWd, int ver);

	public delegate IntPtr SwigDelegateOdDbMPolygon_110();

	public delegate int SwigDelegateOdDbMPolygon_111(IntPtr xfm, IntPtr pCopy);

	public delegate int SwigDelegateOdDbMPolygon_112(IntPtr xM);

	public delegate bool SwigDelegateOdDbMPolygon_113();

	public delegate bool SwigDelegateOdDbMPolygon_114();

	public delegate void SwigDelegateOdDbMPolygon_115(int status);

	public delegate int SwigDelegateOdDbMPolygon_116(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints);

	public delegate int SwigDelegateOdDbMPolygon_117(int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insertionMat);

	public delegate bool SwigDelegateOdDbMPolygon_118();

	public delegate int SwigDelegateOdDbMPolygon_119(IntPtr gripPoints);

	public delegate int SwigDelegateOdDbMPolygon_120(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbMPolygon_121(IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags);

	public delegate int SwigDelegateOdDbMPolygon_122(IntPtr grips, IntPtr offset, int bitFlags);

	public delegate int SwigDelegateOdDbMPolygon_123(IntPtr stretchPoints);

	public delegate int SwigDelegateOdDbMPolygon_124(IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbMPolygon_125(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbMPolygon_126(IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbMPolygon_127(IntPtr pEnt, int intType, IntPtr points);

	public delegate int SwigDelegateOdDbMPolygon_128(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbMPolygon_129(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbMPolygon_130(IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points);

	public delegate void SwigDelegateOdDbMPolygon_131(bool bDoIt, IntPtr pSubId, bool highlightAll);

	public delegate void SwigDelegateOdDbMPolygon_132(bool bDoIt, IntPtr pSubId);

	public delegate void SwigDelegateOdDbMPolygon_133(bool bDoIt);

	public delegate void SwigDelegateOdDbMPolygon_134();

	public delegate int SwigDelegateOdDbMPolygon_135();

	public delegate int SwigDelegateOdDbMPolygon_136(int visibility, bool doSubents);

	public delegate int SwigDelegateOdDbMPolygon_137(int visibility);

	public delegate int SwigDelegateOdDbMPolygon_138(IntPtr extents);

	public delegate int SwigDelegateOdDbMPolygon_139(IntPtr paths);

	public delegate int SwigDelegateOdDbMPolygon_140(IntPtr paths);

	public delegate int SwigDelegateOdDbMPolygon_141(IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags);

	public delegate int SwigDelegateOdDbMPolygon_142(IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags);

	public delegate int SwigDelegateOdDbMPolygon_143(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths, IntPtr pEntAndInsertStack);

	public delegate int SwigDelegateOdDbMPolygon_144(int type, IntPtr gsMark, IntPtr pickPoint, IntPtr xfm, IntPtr subentPaths);

	public delegate int SwigDelegateOdDbMPolygon_145(IntPtr subPath, IntPtr gsMarkers);

	public delegate int SwigDelegateOdDbMPolygon_146(IntPtr paths, IntPtr xform);

	public delegate int SwigDelegateOdDbMPolygon_147(IntPtr path, IntPtr clsId);

	public delegate int SwigDelegateOdDbMPolygon_148(IntPtr path, IntPtr extents);

	public delegate void SwigDelegateOdDbMPolygon_149(int status, IntPtr subentity);

	public delegate IntPtr SwigDelegateOdDbMPolygon_150();

	public delegate IntPtr SwigDelegateOdDbMPolygon_151();

	public delegate double SwigDelegateOdDbMPolygon_152();

	public delegate void SwigDelegateOdDbMPolygon_153(double elevation);

	public delegate IntPtr SwigDelegateOdDbMPolygon_154();

	public delegate void SwigDelegateOdDbMPolygon_155(IntPtr normal);

	public delegate int SwigDelegateOdDbMPolygon_156(bool bUnderestimateNumLines);

	public delegate int SwigDelegateOdDbMPolygon_157();

	public delegate int SwigDelegateOdDbMPolygon_158();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbMPolygon_159();

	public delegate void SwigDelegateOdDbMPolygon_160(int patType, [MarshalAs(UnmanagedType.LPWStr)] string patName);

	public delegate double SwigDelegateOdDbMPolygon_161();

	public delegate void SwigDelegateOdDbMPolygon_162(double angle);

	public delegate double SwigDelegateOdDbMPolygon_163();

	public delegate void SwigDelegateOdDbMPolygon_164(double space);

	public delegate double SwigDelegateOdDbMPolygon_165();

	public delegate void SwigDelegateOdDbMPolygon_166(double scale);

	public delegate bool SwigDelegateOdDbMPolygon_167();

	public delegate void SwigDelegateOdDbMPolygon_168(bool isDouble);

	public delegate int SwigDelegateOdDbMPolygon_169();

	public delegate void SwigDelegateOdDbMPolygon_170(int index, double angle, double baseX, double baseY, double offsetX, double offsetY, IntPtr dashes);

	public delegate IntPtr SwigDelegateOdDbMPolygon_171();

	public delegate void SwigDelegateOdDbMPolygon_172(IntPtr pc);

	public delegate int SwigDelegateOdDbMPolygon_173(double area, bool areaViaHatch);

	public delegate int SwigDelegateOdDbMPolygon_174(double area);

	public delegate IntPtr SwigDelegateOdDbMPolygon_175();

	public delegate int SwigDelegateOdDbMPolygon_176(IntPtr pCircle, bool excludeCrossing, double tol);

	public delegate int SwigDelegateOdDbMPolygon_177(IntPtr pCircle, bool excludeCrossing);

	public delegate int SwigDelegateOdDbMPolygon_178(IntPtr pCircle);

	public delegate int SwigDelegateOdDbMPolygon_179(IntPtr pPoly, bool excludeCrossing, double tol);

	public delegate int SwigDelegateOdDbMPolygon_180(IntPtr pPoly, bool excludeCrossing);

	public delegate int SwigDelegateOdDbMPolygon_181(IntPtr pPoly);

	public delegate int SwigDelegateOdDbMPolygon_182(IntPtr pPoly, bool excludeCrossing, double tol);

	public delegate int SwigDelegateOdDbMPolygon_183(IntPtr pPoly, bool excludeCrossing);

	public delegate int SwigDelegateOdDbMPolygon_184(IntPtr pPoly);

	public delegate int SwigDelegateOdDbMPolygon_185();

	public delegate int SwigDelegateOdDbMPolygon_186(int loopIndex, IntPtr vertices, IntPtr bulges);

	public delegate int SwigDelegateOdDbMPolygon_187(IntPtr vertices, IntPtr bulges, bool excludeCrossing, double tol);

	public delegate int SwigDelegateOdDbMPolygon_188(IntPtr vertices, IntPtr bulges, bool excludeCrossing);

	public delegate int SwigDelegateOdDbMPolygon_189(IntPtr vertices, IntPtr bulges);

	public delegate int SwigDelegateOdDbMPolygon_190(int loopIndex, IntPtr vertices, IntPtr bulges, bool excludeCrossing, double tol);

	public delegate int SwigDelegateOdDbMPolygon_191(int loopIndex, IntPtr vertices, IntPtr bulges, bool excludeCrossing);

	public delegate int SwigDelegateOdDbMPolygon_192(int loopIndex, IntPtr vertices, IntPtr bulges);

	public delegate int SwigDelegateOdDbMPolygon_193(int loopIndex, IntPtr vertices, IntPtr bulges, bool excludeCrossing, double tol);

	public delegate int SwigDelegateOdDbMPolygon_194(int loopIndex, IntPtr vertices, IntPtr bulges, bool excludeCrossing);

	public delegate int SwigDelegateOdDbMPolygon_195(int loopIndex, IntPtr vertices, IntPtr bulges);

	public delegate int SwigDelegateOdDbMPolygon_196(IntPtr loopIndices, IntPtr vertices, IntPtr bulges, IntPtr rejectedLoop, bool excludeCrossing, double tol);

	public delegate int SwigDelegateOdDbMPolygon_197(IntPtr loopIndices, IntPtr vertices, IntPtr bulges, IntPtr rejectedLoop, bool excludeCrossing);

	public delegate int SwigDelegateOdDbMPolygon_198(IntPtr loopIndices, IntPtr vertices, IntPtr bulges, IntPtr rejectedLoop);

	public delegate int SwigDelegateOdDbMPolygon_199(int loopIndex);

	public delegate int SwigDelegateOdDbMPolygon_200(int lindex, OdDbMPolygon_loopDir dir);

	public delegate int SwigDelegateOdDbMPolygon_201(int lindex, int dir);

	public delegate bool SwigDelegateOdDbMPolygon_202(IntPtr worldPt, int loop, double tol);

	public delegate bool SwigDelegateOdDbMPolygon_203(IntPtr worldPt, int loop);

	public delegate int SwigDelegateOdDbMPolygon_204(IntPtr worldPt, IntPtr loopsArray, double tol);

	public delegate int SwigDelegateOdDbMPolygon_205(IntPtr worldPt, IntPtr loopsArray);

	public delegate int SwigDelegateOdDbMPolygon_206(int curLoop);

	public delegate int SwigDelegateOdDbMPolygon_207(IntPtr loopNode);

	public delegate void SwigDelegateOdDbMPolygon_208(IntPtr loopNode);

	public delegate int SwigDelegateOdDbMPolygon_209(IntPtr worldPt);

	public delegate double SwigDelegateOdDbMPolygon_210();

	public delegate int SwigDelegateOdDbMPolygon_211();

	public delegate bool SwigDelegateOdDbMPolygon_212();

	public delegate int SwigDelegateOdDbMPolygon_213();

	public delegate int SwigDelegateOdDbMPolygon_214(IntPtr ids, IntPtr rejectedObjs, bool excludeCrossing, double tol);

	public delegate int SwigDelegateOdDbMPolygon_215(IntPtr ids, IntPtr rejectedObjs, bool excludeCrossing);

	public delegate int SwigDelegateOdDbMPolygon_216(IntPtr ids, IntPtr rejectedObjs);

	public delegate int SwigDelegateOdDbMPolygon_217(IntPtr vertices, IntPtr bulges, IntPtr rejectedObjs, bool excludeCrossing, double tol);

	public delegate int SwigDelegateOdDbMPolygon_218(IntPtr vertices, IntPtr bulges, IntPtr rejectedObjs, bool excludeCrossing);

	public delegate int SwigDelegateOdDbMPolygon_219(IntPtr vertices, IntPtr bulges, IntPtr rejectedObjs);

	public delegate int SwigDelegateOdDbMPolygon_220(int curLoop, IntPtr selectedLoopIndexes);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbMPolygon_0 swigDelegate0;

	private SwigDelegateOdDbMPolygon_1 swigDelegate1;

	private SwigDelegateOdDbMPolygon_2 swigDelegate2;

	private SwigDelegateOdDbMPolygon_3 swigDelegate3;

	private SwigDelegateOdDbMPolygon_4 swigDelegate4;

	private SwigDelegateOdDbMPolygon_5 swigDelegate5;

	private SwigDelegateOdDbMPolygon_6 swigDelegate6;

	private SwigDelegateOdDbMPolygon_7 swigDelegate7;

	private SwigDelegateOdDbMPolygon_8 swigDelegate8;

	private SwigDelegateOdDbMPolygon_9 swigDelegate9;

	private SwigDelegateOdDbMPolygon_10 swigDelegate10;

	private SwigDelegateOdDbMPolygon_11 swigDelegate11;

	private SwigDelegateOdDbMPolygon_12 swigDelegate12;

	private SwigDelegateOdDbMPolygon_13 swigDelegate13;

	private SwigDelegateOdDbMPolygon_14 swigDelegate14;

	private SwigDelegateOdDbMPolygon_15 swigDelegate15;

	private SwigDelegateOdDbMPolygon_16 swigDelegate16;

	private SwigDelegateOdDbMPolygon_17 swigDelegate17;

	private SwigDelegateOdDbMPolygon_18 swigDelegate18;

	private SwigDelegateOdDbMPolygon_19 swigDelegate19;

	private SwigDelegateOdDbMPolygon_20 swigDelegate20;

	private SwigDelegateOdDbMPolygon_21 swigDelegate21;

	private SwigDelegateOdDbMPolygon_22 swigDelegate22;

	private SwigDelegateOdDbMPolygon_23 swigDelegate23;

	private SwigDelegateOdDbMPolygon_24 swigDelegate24;

	private SwigDelegateOdDbMPolygon_25 swigDelegate25;

	private SwigDelegateOdDbMPolygon_26 swigDelegate26;

	private SwigDelegateOdDbMPolygon_27 swigDelegate27;

	private SwigDelegateOdDbMPolygon_28 swigDelegate28;

	private SwigDelegateOdDbMPolygon_29 swigDelegate29;

	private SwigDelegateOdDbMPolygon_30 swigDelegate30;

	private SwigDelegateOdDbMPolygon_31 swigDelegate31;

	private SwigDelegateOdDbMPolygon_32 swigDelegate32;

	private SwigDelegateOdDbMPolygon_33 swigDelegate33;

	private SwigDelegateOdDbMPolygon_34 swigDelegate34;

	private SwigDelegateOdDbMPolygon_35 swigDelegate35;

	private SwigDelegateOdDbMPolygon_36 swigDelegate36;

	private SwigDelegateOdDbMPolygon_37 swigDelegate37;

	private SwigDelegateOdDbMPolygon_38 swigDelegate38;

	private SwigDelegateOdDbMPolygon_39 swigDelegate39;

	private SwigDelegateOdDbMPolygon_40 swigDelegate40;

	private SwigDelegateOdDbMPolygon_41 swigDelegate41;

	private SwigDelegateOdDbMPolygon_42 swigDelegate42;

	private SwigDelegateOdDbMPolygon_43 swigDelegate43;

	private SwigDelegateOdDbMPolygon_44 swigDelegate44;

	private SwigDelegateOdDbMPolygon_45 swigDelegate45;

	private SwigDelegateOdDbMPolygon_46 swigDelegate46;

	private SwigDelegateOdDbMPolygon_47 swigDelegate47;

	private SwigDelegateOdDbMPolygon_48 swigDelegate48;

	private SwigDelegateOdDbMPolygon_49 swigDelegate49;

	private SwigDelegateOdDbMPolygon_50 swigDelegate50;

	private SwigDelegateOdDbMPolygon_51 swigDelegate51;

	private SwigDelegateOdDbMPolygon_52 swigDelegate52;

	private SwigDelegateOdDbMPolygon_53 swigDelegate53;

	private SwigDelegateOdDbMPolygon_54 swigDelegate54;

	private SwigDelegateOdDbMPolygon_55 swigDelegate55;

	private SwigDelegateOdDbMPolygon_56 swigDelegate56;

	private SwigDelegateOdDbMPolygon_57 swigDelegate57;

	private SwigDelegateOdDbMPolygon_58 swigDelegate58;

	private SwigDelegateOdDbMPolygon_59 swigDelegate59;

	private SwigDelegateOdDbMPolygon_60 swigDelegate60;

	private SwigDelegateOdDbMPolygon_61 swigDelegate61;

	private SwigDelegateOdDbMPolygon_62 swigDelegate62;

	private SwigDelegateOdDbMPolygon_63 swigDelegate63;

	private SwigDelegateOdDbMPolygon_64 swigDelegate64;

	private SwigDelegateOdDbMPolygon_65 swigDelegate65;

	private SwigDelegateOdDbMPolygon_66 swigDelegate66;

	private SwigDelegateOdDbMPolygon_67 swigDelegate67;

	private SwigDelegateOdDbMPolygon_68 swigDelegate68;

	private SwigDelegateOdDbMPolygon_69 swigDelegate69;

	private SwigDelegateOdDbMPolygon_70 swigDelegate70;

	private SwigDelegateOdDbMPolygon_71 swigDelegate71;

	private SwigDelegateOdDbMPolygon_72 swigDelegate72;

	private SwigDelegateOdDbMPolygon_73 swigDelegate73;

	private SwigDelegateOdDbMPolygon_74 swigDelegate74;

	private SwigDelegateOdDbMPolygon_75 swigDelegate75;

	private SwigDelegateOdDbMPolygon_76 swigDelegate76;

	private SwigDelegateOdDbMPolygon_77 swigDelegate77;

	private SwigDelegateOdDbMPolygon_78 swigDelegate78;

	private SwigDelegateOdDbMPolygon_79 swigDelegate79;

	private SwigDelegateOdDbMPolygon_80 swigDelegate80;

	private SwigDelegateOdDbMPolygon_81 swigDelegate81;

	private SwigDelegateOdDbMPolygon_82 swigDelegate82;

	private SwigDelegateOdDbMPolygon_83 swigDelegate83;

	private SwigDelegateOdDbMPolygon_84 swigDelegate84;

	private SwigDelegateOdDbMPolygon_85 swigDelegate85;

	private SwigDelegateOdDbMPolygon_86 swigDelegate86;

	private SwigDelegateOdDbMPolygon_87 swigDelegate87;

	private SwigDelegateOdDbMPolygon_88 swigDelegate88;

	private SwigDelegateOdDbMPolygon_89 swigDelegate89;

	private SwigDelegateOdDbMPolygon_90 swigDelegate90;

	private SwigDelegateOdDbMPolygon_91 swigDelegate91;

	private SwigDelegateOdDbMPolygon_92 swigDelegate92;

	private SwigDelegateOdDbMPolygon_93 swigDelegate93;

	private SwigDelegateOdDbMPolygon_94 swigDelegate94;

	private SwigDelegateOdDbMPolygon_95 swigDelegate95;

	private SwigDelegateOdDbMPolygon_96 swigDelegate96;

	private SwigDelegateOdDbMPolygon_97 swigDelegate97;

	private SwigDelegateOdDbMPolygon_98 swigDelegate98;

	private SwigDelegateOdDbMPolygon_99 swigDelegate99;

	private SwigDelegateOdDbMPolygon_100 swigDelegate100;

	private SwigDelegateOdDbMPolygon_101 swigDelegate101;

	private SwigDelegateOdDbMPolygon_102 swigDelegate102;

	private SwigDelegateOdDbMPolygon_103 swigDelegate103;

	private SwigDelegateOdDbMPolygon_104 swigDelegate104;

	private SwigDelegateOdDbMPolygon_105 swigDelegate105;

	private SwigDelegateOdDbMPolygon_106 swigDelegate106;

	private SwigDelegateOdDbMPolygon_107 swigDelegate107;

	private SwigDelegateOdDbMPolygon_108 swigDelegate108;

	private SwigDelegateOdDbMPolygon_109 swigDelegate109;

	private SwigDelegateOdDbMPolygon_110 swigDelegate110;

	private SwigDelegateOdDbMPolygon_111 swigDelegate111;

	private SwigDelegateOdDbMPolygon_112 swigDelegate112;

	private SwigDelegateOdDbMPolygon_113 swigDelegate113;

	private SwigDelegateOdDbMPolygon_114 swigDelegate114;

	private SwigDelegateOdDbMPolygon_115 swigDelegate115;

	private SwigDelegateOdDbMPolygon_116 swigDelegate116;

	private SwigDelegateOdDbMPolygon_117 swigDelegate117;

	private SwigDelegateOdDbMPolygon_118 swigDelegate118;

	private SwigDelegateOdDbMPolygon_119 swigDelegate119;

	private SwigDelegateOdDbMPolygon_120 swigDelegate120;

	private SwigDelegateOdDbMPolygon_121 swigDelegate121;

	private SwigDelegateOdDbMPolygon_122 swigDelegate122;

	private SwigDelegateOdDbMPolygon_123 swigDelegate123;

	private SwigDelegateOdDbMPolygon_124 swigDelegate124;

	private SwigDelegateOdDbMPolygon_125 swigDelegate125;

	private SwigDelegateOdDbMPolygon_126 swigDelegate126;

	private SwigDelegateOdDbMPolygon_127 swigDelegate127;

	private SwigDelegateOdDbMPolygon_128 swigDelegate128;

	private SwigDelegateOdDbMPolygon_129 swigDelegate129;

	private SwigDelegateOdDbMPolygon_130 swigDelegate130;

	private SwigDelegateOdDbMPolygon_131 swigDelegate131;

	private SwigDelegateOdDbMPolygon_132 swigDelegate132;

	private SwigDelegateOdDbMPolygon_133 swigDelegate133;

	private SwigDelegateOdDbMPolygon_134 swigDelegate134;

	private SwigDelegateOdDbMPolygon_135 swigDelegate135;

	private SwigDelegateOdDbMPolygon_136 swigDelegate136;

	private SwigDelegateOdDbMPolygon_137 swigDelegate137;

	private SwigDelegateOdDbMPolygon_138 swigDelegate138;

	private SwigDelegateOdDbMPolygon_139 swigDelegate139;

	private SwigDelegateOdDbMPolygon_140 swigDelegate140;

	private SwigDelegateOdDbMPolygon_141 swigDelegate141;

	private SwigDelegateOdDbMPolygon_142 swigDelegate142;

	private SwigDelegateOdDbMPolygon_143 swigDelegate143;

	private SwigDelegateOdDbMPolygon_144 swigDelegate144;

	private SwigDelegateOdDbMPolygon_145 swigDelegate145;

	private SwigDelegateOdDbMPolygon_146 swigDelegate146;

	private SwigDelegateOdDbMPolygon_147 swigDelegate147;

	private SwigDelegateOdDbMPolygon_148 swigDelegate148;

	private SwigDelegateOdDbMPolygon_149 swigDelegate149;

	private SwigDelegateOdDbMPolygon_150 swigDelegate150;

	private SwigDelegateOdDbMPolygon_151 swigDelegate151;

	private SwigDelegateOdDbMPolygon_152 swigDelegate152;

	private SwigDelegateOdDbMPolygon_153 swigDelegate153;

	private SwigDelegateOdDbMPolygon_154 swigDelegate154;

	private SwigDelegateOdDbMPolygon_155 swigDelegate155;

	private SwigDelegateOdDbMPolygon_156 swigDelegate156;

	private SwigDelegateOdDbMPolygon_157 swigDelegate157;

	private SwigDelegateOdDbMPolygon_158 swigDelegate158;

	private SwigDelegateOdDbMPolygon_159 swigDelegate159;

	private SwigDelegateOdDbMPolygon_160 swigDelegate160;

	private SwigDelegateOdDbMPolygon_161 swigDelegate161;

	private SwigDelegateOdDbMPolygon_162 swigDelegate162;

	private SwigDelegateOdDbMPolygon_163 swigDelegate163;

	private SwigDelegateOdDbMPolygon_164 swigDelegate164;

	private SwigDelegateOdDbMPolygon_165 swigDelegate165;

	private SwigDelegateOdDbMPolygon_166 swigDelegate166;

	private SwigDelegateOdDbMPolygon_167 swigDelegate167;

	private SwigDelegateOdDbMPolygon_168 swigDelegate168;

	private SwigDelegateOdDbMPolygon_169 swigDelegate169;

	private SwigDelegateOdDbMPolygon_170 swigDelegate170;

	private SwigDelegateOdDbMPolygon_171 swigDelegate171;

	private SwigDelegateOdDbMPolygon_172 swigDelegate172;

	private SwigDelegateOdDbMPolygon_173 swigDelegate173;

	private SwigDelegateOdDbMPolygon_174 swigDelegate174;

	private SwigDelegateOdDbMPolygon_175 swigDelegate175;

	private SwigDelegateOdDbMPolygon_176 swigDelegate176;

	private SwigDelegateOdDbMPolygon_177 swigDelegate177;

	private SwigDelegateOdDbMPolygon_178 swigDelegate178;

	private SwigDelegateOdDbMPolygon_179 swigDelegate179;

	private SwigDelegateOdDbMPolygon_180 swigDelegate180;

	private SwigDelegateOdDbMPolygon_181 swigDelegate181;

	private SwigDelegateOdDbMPolygon_182 swigDelegate182;

	private SwigDelegateOdDbMPolygon_183 swigDelegate183;

	private SwigDelegateOdDbMPolygon_184 swigDelegate184;

	private SwigDelegateOdDbMPolygon_185 swigDelegate185;

	private SwigDelegateOdDbMPolygon_186 swigDelegate186;

	private SwigDelegateOdDbMPolygon_187 swigDelegate187;

	private SwigDelegateOdDbMPolygon_188 swigDelegate188;

	private SwigDelegateOdDbMPolygon_189 swigDelegate189;

	private SwigDelegateOdDbMPolygon_190 swigDelegate190;

	private SwigDelegateOdDbMPolygon_191 swigDelegate191;

	private SwigDelegateOdDbMPolygon_192 swigDelegate192;

	private SwigDelegateOdDbMPolygon_193 swigDelegate193;

	private SwigDelegateOdDbMPolygon_194 swigDelegate194;

	private SwigDelegateOdDbMPolygon_195 swigDelegate195;

	private SwigDelegateOdDbMPolygon_196 swigDelegate196;

	private SwigDelegateOdDbMPolygon_197 swigDelegate197;

	private SwigDelegateOdDbMPolygon_198 swigDelegate198;

	private SwigDelegateOdDbMPolygon_199 swigDelegate199;

	private SwigDelegateOdDbMPolygon_200 swigDelegate200;

	private SwigDelegateOdDbMPolygon_201 swigDelegate201;

	private SwigDelegateOdDbMPolygon_202 swigDelegate202;

	private SwigDelegateOdDbMPolygon_203 swigDelegate203;

	private SwigDelegateOdDbMPolygon_204 swigDelegate204;

	private SwigDelegateOdDbMPolygon_205 swigDelegate205;

	private SwigDelegateOdDbMPolygon_206 swigDelegate206;

	private SwigDelegateOdDbMPolygon_207 swigDelegate207;

	private SwigDelegateOdDbMPolygon_208 swigDelegate208;

	private SwigDelegateOdDbMPolygon_209 swigDelegate209;

	private SwigDelegateOdDbMPolygon_210 swigDelegate210;

	private SwigDelegateOdDbMPolygon_211 swigDelegate211;

	private SwigDelegateOdDbMPolygon_212 swigDelegate212;

	private SwigDelegateOdDbMPolygon_213 swigDelegate213;

	private SwigDelegateOdDbMPolygon_214 swigDelegate214;

	private SwigDelegateOdDbMPolygon_215 swigDelegate215;

	private SwigDelegateOdDbMPolygon_216 swigDelegate216;

	private SwigDelegateOdDbMPolygon_217 swigDelegate217;

	private SwigDelegateOdDbMPolygon_218 swigDelegate218;

	private SwigDelegateOdDbMPolygon_219 swigDelegate219;

	private SwigDelegateOdDbMPolygon_220 swigDelegate220;

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

	private static Type[] swigMethodTypes136 = new Type[2]
	{
		typeof(OdDb_Visibility),
		typeof(bool)
	};

	private static Type[] swigMethodTypes137 = new Type[1] { typeof(OdDb_Visibility) };

	private static Type[] swigMethodTypes138 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes139 = new Type[1] { typeof(OdDbFullSubentPathArray) };

	private static Type[] swigMethodTypes140 = new Type[1] { typeof(OdDbFullSubentPathArray) };

	private static Type[] swigMethodTypes141 = new Type[4]
	{
		typeof(OdDbFullSubentPathArray),
		typeof(OdDbVoidPtrArray),
		typeof(OdGeVector3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes142 = new Type[6]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdDbGripDataPtrArray),
		typeof(double),
		typeof(int),
		typeof(OdGeVector3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes143 = new Type[6]
	{
		typeof(OdDb_SubentType),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdDbFullSubentPathArray),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes144 = new Type[5]
	{
		typeof(OdDb_SubentType),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdDbFullSubentPathArray)
	};

	private static Type[] swigMethodTypes145 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdGsMarkerArray)
	};

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

	private static Type[] swigMethodTypes153 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes154 = new Type[0];

	private static Type[] swigMethodTypes155 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes156 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes157 = new Type[0];

	private static Type[] swigMethodTypes158 = new Type[0];

	private static Type[] swigMethodTypes159 = new Type[0];

	private static Type[] swigMethodTypes160 = new Type[2]
	{
		typeof(OdDbHatch_HatchPatternType),
		typeof(string)
	};

	private static Type[] swigMethodTypes161 = new Type[0];

	private static Type[] swigMethodTypes162 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes163 = new Type[0];

	private static Type[] swigMethodTypes164 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes165 = new Type[0];

	private static Type[] swigMethodTypes166 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes167 = new Type[0];

	private static Type[] swigMethodTypes168 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes169 = new Type[0];

	private static Type[] swigMethodTypes170 = new Type[7]
	{
		typeof(int),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(OdDoubleArray)
	};

	private static Type[] swigMethodTypes171 = new Type[0];

	private static Type[] swigMethodTypes172 = new Type[1] { typeof(OdCmColor) };

	private static Type[] swigMethodTypes173 = new Type[2]
	{
		typeof(double).MakeByRefType(),
		typeof(bool)
	};

	private static Type[] swigMethodTypes174 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes175 = new Type[0];

	private static Type[] swigMethodTypes176 = new Type[3]
	{
		typeof(OdDbCircle),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes177 = new Type[2]
	{
		typeof(OdDbCircle),
		typeof(bool)
	};

	private static Type[] swigMethodTypes178 = new Type[1] { typeof(OdDbCircle) };

	private static Type[] swigMethodTypes179 = new Type[3]
	{
		typeof(OdDbPolyline),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes180 = new Type[2]
	{
		typeof(OdDbPolyline),
		typeof(bool)
	};

	private static Type[] swigMethodTypes181 = new Type[1] { typeof(OdDbPolyline) };

	private static Type[] swigMethodTypes182 = new Type[3]
	{
		typeof(OdDb2dPolyline),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes183 = new Type[2]
	{
		typeof(OdDb2dPolyline),
		typeof(bool)
	};

	private static Type[] swigMethodTypes184 = new Type[1] { typeof(OdDb2dPolyline) };

	private static Type[] swigMethodTypes185 = new Type[0];

	private static Type[] swigMethodTypes186 = new Type[3]
	{
		typeof(int),
		typeof(OdGePoint2dArray),
		typeof(OdDoubleArray)
	};

	private static Type[] swigMethodTypes187 = new Type[4]
	{
		typeof(OdGePoint2dArray),
		typeof(OdDoubleArray),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes188 = new Type[3]
	{
		typeof(OdGePoint2dArray),
		typeof(OdDoubleArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes189 = new Type[2]
	{
		typeof(OdGePoint2dArray),
		typeof(OdDoubleArray)
	};

	private static Type[] swigMethodTypes190 = new Type[5]
	{
		typeof(int),
		typeof(OdGePoint2dArray),
		typeof(OdDoubleArray),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes191 = new Type[4]
	{
		typeof(int),
		typeof(OdGePoint2dArray),
		typeof(OdDoubleArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes192 = new Type[3]
	{
		typeof(int),
		typeof(OdGePoint2dArray),
		typeof(OdDoubleArray)
	};

	private static Type[] swigMethodTypes193 = new Type[5]
	{
		typeof(int),
		typeof(OdGePoint2dArray),
		typeof(OdDoubleArray),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes194 = new Type[4]
	{
		typeof(int),
		typeof(OdGePoint2dArray),
		typeof(OdDoubleArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes195 = new Type[3]
	{
		typeof(int),
		typeof(OdGePoint2dArray),
		typeof(OdDoubleArray)
	};

	private static Type[] swigMethodTypes196 = new Type[6]
	{
		typeof(OdIntArray),
		typeof(OdGePoint2dArrayArray),
		typeof(SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t),
		typeof(OdIntArray),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes197 = new Type[5]
	{
		typeof(OdIntArray),
		typeof(OdGePoint2dArrayArray),
		typeof(SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t),
		typeof(OdIntArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes198 = new Type[4]
	{
		typeof(OdIntArray),
		typeof(OdGePoint2dArrayArray),
		typeof(SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t),
		typeof(OdIntArray)
	};

	private static Type[] swigMethodTypes199 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes200 = new Type[2]
	{
		typeof(int),
		typeof(OdDbMPolygon_loopDir).MakeByRefType()
	};

	private static Type[] swigMethodTypes201 = new Type[2]
	{
		typeof(int),
		typeof(OdDbMPolygon_loopDir)
	};

	private static Type[] swigMethodTypes202 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(int),
		typeof(double)
	};

	private static Type[] swigMethodTypes203 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes204 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdIntArray),
		typeof(double)
	};

	private static Type[] swigMethodTypes205 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdIntArray)
	};

	private static Type[] swigMethodTypes206 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes207 = new Type[1] { typeof(OdDbMPolygonNode).MakeByRefType() };

	private static Type[] swigMethodTypes208 = new Type[1] { typeof(OdDbMPolygonNode) };

	private static Type[] swigMethodTypes209 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes210 = new Type[0];

	private static Type[] swigMethodTypes211 = new Type[0];

	private static Type[] swigMethodTypes212 = new Type[0];

	private static Type[] swigMethodTypes213 = new Type[0];

	private static Type[] swigMethodTypes214 = new Type[4]
	{
		typeof(OdDbObjectIdArray),
		typeof(OdIntArray),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes215 = new Type[3]
	{
		typeof(OdDbObjectIdArray),
		typeof(OdIntArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes216 = new Type[2]
	{
		typeof(OdDbObjectIdArray),
		typeof(OdIntArray)
	};

	private static Type[] swigMethodTypes217 = new Type[5]
	{
		typeof(OdGePoint2dArrayArray),
		typeof(SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t),
		typeof(OdIntArray),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes218 = new Type[4]
	{
		typeof(OdGePoint2dArrayArray),
		typeof(SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t),
		typeof(OdIntArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes219 = new Type[3]
	{
		typeof(OdGePoint2dArrayArray),
		typeof(SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t),
		typeof(OdIntArray)
	};

	private static Type[] swigMethodTypes220 = new Type[2]
	{
		typeof(int),
		typeof(OdIntArray)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbMPolygon(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbMPolygon obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbMPolygon(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbMPolygon cast(OdRxObject pObj)
	{
		OdDbMPolygon rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbMPolygon>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_isASwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_queryXSwigExplicitOdDbMPolygon(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbHatch hatch()
	{
		OdDbHatch rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbHatch>(SwigDerivedClassHasMethod("hatch", swigMethodTypes150) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_hatchSwigExplicitOdDbMPolygon__SWIG_0(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_hatch__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual double elevation()
	{
		double result = (SwigDerivedClassHasMethod("elevation", swigMethodTypes152) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_elevationSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_elevation(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setElevation(double elevation)
	{
		if (SwigDerivedClassHasMethod("setElevation", swigMethodTypes153))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setElevationSwigExplicitOdDbMPolygon(swigCPtr, elevation);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setElevation(swigCPtr, elevation);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeVector3d normal()
	{
		OdGeVector3d result = new OdGeVector3d(SwigDerivedClassHasMethod("normal", swigMethodTypes154) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_normalSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_normal(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setNormal(OdGeVector3d normal)
	{
		if (SwigDerivedClassHasMethod("setNormal", swigMethodTypes155))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setNormalSwigExplicitOdDbMPolygon(swigCPtr, OdGeVector3d.getCPtr(normal));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setNormal(swigCPtr, OdGeVector3d.getCPtr(normal));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult evaluateHatch(bool bUnderestimateNumLines)
	{
		int result = (SwigDerivedClassHasMethod("evaluateHatch", swigMethodTypes156) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_evaluateHatchSwigExplicitOdDbMPolygon__SWIG_0(swigCPtr, bUnderestimateNumLines) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_evaluateHatch__SWIG_0(swigCPtr, bUnderestimateNumLines));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult evaluateHatch()
	{
		int result = (SwigDerivedClassHasMethod("evaluateHatch", swigMethodTypes157) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_evaluateHatchSwigExplicitOdDbMPolygon__SWIG_1(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_evaluateHatch__SWIG_1(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbHatch_HatchPatternType patternType()
	{
		int result = (SwigDerivedClassHasMethod("patternType", swigMethodTypes158) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternTypeSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternType(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbHatch_HatchPatternType)result;
	}

	public virtual string patternName()
	{
		string result = (SwigDerivedClassHasMethod("patternName", swigMethodTypes159) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternNameSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternName(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPattern(OdDbHatch_HatchPatternType patType, string patName)
	{
		if (SwigDerivedClassHasMethod("setPattern", swigMethodTypes160))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setPatternSwigExplicitOdDbMPolygon(swigCPtr, (int)patType, patName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setPattern(swigCPtr, (int)patType, patName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double patternAngle()
	{
		double result = (SwigDerivedClassHasMethod("patternAngle", swigMethodTypes161) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternAngleSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternAngle(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPatternAngle(double angle)
	{
		if (SwigDerivedClassHasMethod("setPatternAngle", swigMethodTypes162))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setPatternAngleSwigExplicitOdDbMPolygon(swigCPtr, angle);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setPatternAngle(swigCPtr, angle);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double patternSpace()
	{
		double result = (SwigDerivedClassHasMethod("patternSpace", swigMethodTypes163) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternSpaceSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternSpace(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPatternSpace(double space)
	{
		if (SwigDerivedClassHasMethod("setPatternSpace", swigMethodTypes164))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setPatternSpaceSwigExplicitOdDbMPolygon(swigCPtr, space);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setPatternSpace(swigCPtr, space);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double patternScale()
	{
		double result = (SwigDerivedClassHasMethod("patternScale", swigMethodTypes165) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternScaleSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternScale(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPatternScale(double scale)
	{
		if (SwigDerivedClassHasMethod("setPatternScale", swigMethodTypes166))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setPatternScaleSwigExplicitOdDbMPolygon(swigCPtr, scale);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setPatternScale(swigCPtr, scale);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool patternDouble()
	{
		bool result = (SwigDerivedClassHasMethod("patternDouble", swigMethodTypes167) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternDoubleSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternDouble(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPatternDouble(bool isDouble)
	{
		if (SwigDerivedClassHasMethod("setPatternDouble", swigMethodTypes168))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setPatternDoubleSwigExplicitOdDbMPolygon(swigCPtr, isDouble);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setPatternDouble(swigCPtr, isDouble);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int numPatternDefinitions()
	{
		int result = (SwigDerivedClassHasMethod("numPatternDefinitions", swigMethodTypes169) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_numPatternDefinitionsSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_numPatternDefinitions(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getPatternDefinitionAt(int index, out double angle, out double baseX, out double baseY, out double offsetX, out double offsetY, OdDoubleArray dashes)
	{
		if (SwigDerivedClassHasMethod("getPatternDefinitionAt", swigMethodTypes170))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getPatternDefinitionAtSwigExplicitOdDbMPolygon(swigCPtr, index, out angle, out baseX, out baseY, out offsetX, out offsetY, OdDoubleArray.getCPtr(dashes).Handle);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getPatternDefinitionAt(swigCPtr, index, out angle, out baseX, out baseY, out offsetX, out offsetY, OdDoubleArray.getCPtr(dashes).Handle);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGradientAngle(double angle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setGradientAngle(swigCPtr, angle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGradientShift(float shiftValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setGradientShift(swigCPtr, shiftValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGradientOneColorMode(bool oneColorMode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setGradientOneColorMode(swigCPtr, oneColorMode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGradientColors(uint count, OdCmColor colors, double values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setGradientColors(swigCPtr, count, OdCmColor.getCPtr(colors), values);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGradient(OdDbHatch_GradientPatternType gradType, string gradName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setGradient(swigCPtr, (int)gradType, gradName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor patternColor()
	{
		OdCmColor result = new OdCmColor(SwigDerivedClassHasMethod("patternColor", swigMethodTypes171) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternColorSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_patternColor(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPatternColor(OdCmColor pc)
	{
		if (SwigDerivedClassHasMethod("setPatternColor", swigMethodTypes172))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setPatternColorSwigExplicitOdDbMPolygon(swigCPtr, OdCmColor.getCPtr(pc));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setPatternColor(swigCPtr, OdCmColor.getCPtr(pc));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult getArea(out double area, bool areaViaHatch)
	{
		int result = (SwigDerivedClassHasMethod("getArea", swigMethodTypes173) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getAreaSwigExplicitOdDbMPolygon__SWIG_0(swigCPtr, out area, areaViaHatch) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getArea__SWIG_0(swigCPtr, out area, areaViaHatch));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getArea(out double area)
	{
		int result = (SwigDerivedClassHasMethod("getArea", swigMethodTypes174) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getAreaSwigExplicitOdDbMPolygon__SWIG_1(swigCPtr, out area) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getArea__SWIG_1(swigCPtr, out area));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdGeVector2d getOffsetVector()
	{
		OdGeVector2d result = new OdGeVector2d(SwigDerivedClassHasMethod("getOffsetVector", swigMethodTypes175) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getOffsetVectorSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getOffsetVector(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult appendLoopFromBoundary(OdDbCircle pCircle, bool excludeCrossing, double tol)
	{
		int result = (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes176) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundarySwigExplicitOdDbMPolygon__SWIG_0(swigCPtr, OdDbCircle.getCPtr(pCircle), excludeCrossing, tol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundary__SWIG_0(swigCPtr, OdDbCircle.getCPtr(pCircle), excludeCrossing, tol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult appendLoopFromBoundary(OdDbCircle pCircle, bool excludeCrossing)
	{
		int result = (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes177) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundarySwigExplicitOdDbMPolygon__SWIG_1(swigCPtr, OdDbCircle.getCPtr(pCircle), excludeCrossing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundary__SWIG_1(swigCPtr, OdDbCircle.getCPtr(pCircle), excludeCrossing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult appendLoopFromBoundary(OdDbCircle pCircle)
	{
		int result = (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes178) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundarySwigExplicitOdDbMPolygon__SWIG_2(swigCPtr, OdDbCircle.getCPtr(pCircle)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundary__SWIG_2(swigCPtr, OdDbCircle.getCPtr(pCircle)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult appendLoopFromBoundary(OdDbPolyline pPoly, bool excludeCrossing, double tol)
	{
		int result = (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes179) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundarySwigExplicitOdDbMPolygon__SWIG_3(swigCPtr, OdDbPolyline.getCPtr(pPoly), excludeCrossing, tol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundary__SWIG_3(swigCPtr, OdDbPolyline.getCPtr(pPoly), excludeCrossing, tol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult appendLoopFromBoundary(OdDbPolyline pPoly, bool excludeCrossing)
	{
		int result = (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes180) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundarySwigExplicitOdDbMPolygon__SWIG_4(swigCPtr, OdDbPolyline.getCPtr(pPoly), excludeCrossing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundary__SWIG_4(swigCPtr, OdDbPolyline.getCPtr(pPoly), excludeCrossing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult appendLoopFromBoundary(OdDbPolyline pPoly)
	{
		int result = (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes181) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundarySwigExplicitOdDbMPolygon__SWIG_5(swigCPtr, OdDbPolyline.getCPtr(pPoly)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundary__SWIG_5(swigCPtr, OdDbPolyline.getCPtr(pPoly)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult appendLoopFromBoundary(OdDb2dPolyline pPoly, bool excludeCrossing, double tol)
	{
		int result = (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes182) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundarySwigExplicitOdDbMPolygon__SWIG_6(swigCPtr, OdDb2dPolyline.getCPtr(pPoly), excludeCrossing, tol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundary__SWIG_6(swigCPtr, OdDb2dPolyline.getCPtr(pPoly), excludeCrossing, tol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult appendLoopFromBoundary(OdDb2dPolyline pPoly, bool excludeCrossing)
	{
		int result = (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes183) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundarySwigExplicitOdDbMPolygon__SWIG_7(swigCPtr, OdDb2dPolyline.getCPtr(pPoly), excludeCrossing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundary__SWIG_7(swigCPtr, OdDb2dPolyline.getCPtr(pPoly), excludeCrossing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult appendLoopFromBoundary(OdDb2dPolyline pPoly)
	{
		int result = (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes184) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundarySwigExplicitOdDbMPolygon__SWIG_8(swigCPtr, OdDb2dPolyline.getCPtr(pPoly)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendLoopFromBoundary__SWIG_8(swigCPtr, OdDb2dPolyline.getCPtr(pPoly)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual int numMPolygonLoops()
	{
		int result = (SwigDerivedClassHasMethod("numMPolygonLoops", swigMethodTypes185) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_numMPolygonLoopsSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_numMPolygonLoops(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getMPolygonLoopAt(int loopIndex, OdGePoint2dArray vertices, OdDoubleArray bulges)
	{
		int result = (SwigDerivedClassHasMethod("getMPolygonLoopAt", swigMethodTypes186) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getMPolygonLoopAtSwigExplicitOdDbMPolygon(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getMPolygonLoopAt(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult appendMPolygonLoop(OdGePoint2dArray vertices, OdDoubleArray bulges, bool excludeCrossing, double tol)
	{
		int result = (SwigDerivedClassHasMethod("appendMPolygonLoop", swigMethodTypes187) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendMPolygonLoopSwigExplicitOdDbMPolygon__SWIG_0(swigCPtr, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle, excludeCrossing, tol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendMPolygonLoop__SWIG_0(swigCPtr, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle, excludeCrossing, tol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult appendMPolygonLoop(OdGePoint2dArray vertices, OdDoubleArray bulges, bool excludeCrossing)
	{
		int result = (SwigDerivedClassHasMethod("appendMPolygonLoop", swigMethodTypes188) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendMPolygonLoopSwigExplicitOdDbMPolygon__SWIG_1(swigCPtr, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle, excludeCrossing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendMPolygonLoop__SWIG_1(swigCPtr, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle, excludeCrossing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult appendMPolygonLoop(OdGePoint2dArray vertices, OdDoubleArray bulges)
	{
		int result = (SwigDerivedClassHasMethod("appendMPolygonLoop", swigMethodTypes189) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendMPolygonLoopSwigExplicitOdDbMPolygon__SWIG_2(swigCPtr, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_appendMPolygonLoop__SWIG_2(swigCPtr, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult insertMPolygonLoopAt(int loopIndex, OdGePoint2dArray vertices, OdDoubleArray bulges, bool excludeCrossing, double tol)
	{
		int result = (SwigDerivedClassHasMethod("insertMPolygonLoopAt", swigMethodTypes190) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_insertMPolygonLoopAtSwigExplicitOdDbMPolygon__SWIG_0(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle, excludeCrossing, tol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_insertMPolygonLoopAt__SWIG_0(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle, excludeCrossing, tol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult insertMPolygonLoopAt(int loopIndex, OdGePoint2dArray vertices, OdDoubleArray bulges, bool excludeCrossing)
	{
		int result = (SwigDerivedClassHasMethod("insertMPolygonLoopAt", swigMethodTypes191) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_insertMPolygonLoopAtSwigExplicitOdDbMPolygon__SWIG_1(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle, excludeCrossing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_insertMPolygonLoopAt__SWIG_1(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle, excludeCrossing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult insertMPolygonLoopAt(int loopIndex, OdGePoint2dArray vertices, OdDoubleArray bulges)
	{
		int result = (SwigDerivedClassHasMethod("insertMPolygonLoopAt", swigMethodTypes192) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_insertMPolygonLoopAtSwigExplicitOdDbMPolygon__SWIG_2(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_insertMPolygonLoopAt__SWIG_2(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult replaceMPolygonLoopAt(int loopIndex, OdGePoint2dArray vertices, OdDoubleArray bulges, bool excludeCrossing, double tol)
	{
		int result = (SwigDerivedClassHasMethod("replaceMPolygonLoopAt", swigMethodTypes193) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_replaceMPolygonLoopAtSwigExplicitOdDbMPolygon__SWIG_0(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle, excludeCrossing, tol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_replaceMPolygonLoopAt__SWIG_0(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle, excludeCrossing, tol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult replaceMPolygonLoopAt(int loopIndex, OdGePoint2dArray vertices, OdDoubleArray bulges, bool excludeCrossing)
	{
		int result = (SwigDerivedClassHasMethod("replaceMPolygonLoopAt", swigMethodTypes194) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_replaceMPolygonLoopAtSwigExplicitOdDbMPolygon__SWIG_1(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle, excludeCrossing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_replaceMPolygonLoopAt__SWIG_1(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle, excludeCrossing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult replaceMPolygonLoopAt(int loopIndex, OdGePoint2dArray vertices, OdDoubleArray bulges)
	{
		int result = (SwigDerivedClassHasMethod("replaceMPolygonLoopAt", swigMethodTypes195) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_replaceMPolygonLoopAtSwigExplicitOdDbMPolygon__SWIG_2(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_replaceMPolygonLoopAt__SWIG_2(swigCPtr, loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult replaceMPolygonLoopAt(OdIntArray loopIndices, OdGePoint2dArrayArray vertices, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t bulges, OdIntArray rejectedLoop, bool excludeCrossing, double tol)
	{
		int result = (SwigDerivedClassHasMethod("replaceMPolygonLoopAt", swigMethodTypes196) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_replaceMPolygonLoopAtSwigExplicitOdDbMPolygon__SWIG_3(swigCPtr, OdIntArray.getCPtr(loopIndices).Handle, OdGePoint2dArrayArray.getCPtr(vertices).Handle, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t.getCPtr(bulges), OdIntArray.getCPtr(rejectedLoop).Handle, excludeCrossing, tol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_replaceMPolygonLoopAt__SWIG_3(swigCPtr, OdIntArray.getCPtr(loopIndices).Handle, OdGePoint2dArrayArray.getCPtr(vertices).Handle, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t.getCPtr(bulges), OdIntArray.getCPtr(rejectedLoop).Handle, excludeCrossing, tol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult replaceMPolygonLoopAt(OdIntArray loopIndices, OdGePoint2dArrayArray vertices, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t bulges, OdIntArray rejectedLoop, bool excludeCrossing)
	{
		int result = (SwigDerivedClassHasMethod("replaceMPolygonLoopAt", swigMethodTypes197) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_replaceMPolygonLoopAtSwigExplicitOdDbMPolygon__SWIG_4(swigCPtr, OdIntArray.getCPtr(loopIndices).Handle, OdGePoint2dArrayArray.getCPtr(vertices).Handle, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t.getCPtr(bulges), OdIntArray.getCPtr(rejectedLoop).Handle, excludeCrossing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_replaceMPolygonLoopAt__SWIG_4(swigCPtr, OdIntArray.getCPtr(loopIndices).Handle, OdGePoint2dArrayArray.getCPtr(vertices).Handle, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t.getCPtr(bulges), OdIntArray.getCPtr(rejectedLoop).Handle, excludeCrossing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult replaceMPolygonLoopAt(OdIntArray loopIndices, OdGePoint2dArrayArray vertices, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t bulges, OdIntArray rejectedLoop)
	{
		int result = (SwigDerivedClassHasMethod("replaceMPolygonLoopAt", swigMethodTypes198) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_replaceMPolygonLoopAtSwigExplicitOdDbMPolygon__SWIG_5(swigCPtr, OdIntArray.getCPtr(loopIndices).Handle, OdGePoint2dArrayArray.getCPtr(vertices).Handle, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t.getCPtr(bulges), OdIntArray.getCPtr(rejectedLoop).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_replaceMPolygonLoopAt__SWIG_5(swigCPtr, OdIntArray.getCPtr(loopIndices).Handle, OdGePoint2dArrayArray.getCPtr(vertices).Handle, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t.getCPtr(bulges), OdIntArray.getCPtr(rejectedLoop).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult removeMPolygonLoopAt(int loopIndex)
	{
		int result = (SwigDerivedClassHasMethod("removeMPolygonLoopAt", swigMethodTypes199) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_removeMPolygonLoopAtSwigExplicitOdDbMPolygon(swigCPtr, loopIndex) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_removeMPolygonLoopAt(swigCPtr, loopIndex));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getLoopDirection(int lindex, out OdDbMPolygon_loopDir dir)
	{
		int result = (SwigDerivedClassHasMethod("getLoopDirection", swigMethodTypes200) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getLoopDirectionSwigExplicitOdDbMPolygon(swigCPtr, lindex, out dir) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getLoopDirection(swigCPtr, lindex, out dir));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setLoopDirection(int lindex, OdDbMPolygon_loopDir dir)
	{
		int result = (SwigDerivedClassHasMethod("setLoopDirection", swigMethodTypes201) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setLoopDirectionSwigExplicitOdDbMPolygon(swigCPtr, lindex, (int)dir) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_setLoopDirection(swigCPtr, lindex, (int)dir));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool isPointOnLoopBoundary(OdGePoint3d worldPt, int loop, double tol)
	{
		bool result = (SwigDerivedClassHasMethod("isPointOnLoopBoundary", swigMethodTypes202) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_isPointOnLoopBoundarySwigExplicitOdDbMPolygon__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(worldPt), loop, tol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_isPointOnLoopBoundary__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(worldPt), loop, tol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isPointOnLoopBoundary(OdGePoint3d worldPt, int loop)
	{
		bool result = (SwigDerivedClassHasMethod("isPointOnLoopBoundary", swigMethodTypes203) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_isPointOnLoopBoundarySwigExplicitOdDbMPolygon__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(worldPt), loop) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_isPointOnLoopBoundary__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(worldPt), loop));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int isPointInsideMPolygon(OdGePoint3d worldPt, OdIntArray loopsArray, double tol)
	{
		int result = (SwigDerivedClassHasMethod("isPointInsideMPolygon", swigMethodTypes204) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_isPointInsideMPolygonSwigExplicitOdDbMPolygon__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(worldPt), OdIntArray.getCPtr(loopsArray).Handle, tol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_isPointInsideMPolygon__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(worldPt), OdIntArray.getCPtr(loopsArray).Handle, tol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int isPointInsideMPolygon(OdGePoint3d worldPt, OdIntArray loopsArray)
	{
		int result = (SwigDerivedClassHasMethod("isPointInsideMPolygon", swigMethodTypes205) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_isPointInsideMPolygonSwigExplicitOdDbMPolygon__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(worldPt), OdIntArray.getCPtr(loopsArray).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_isPointInsideMPolygon__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(worldPt), OdIntArray.getCPtr(loopsArray).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getParentLoop(int curLoop)
	{
		int result = (SwigDerivedClassHasMethod("getParentLoop", swigMethodTypes206) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getParentLoopSwigExplicitOdDbMPolygon(swigCPtr, curLoop) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getParentLoop(swigCPtr, curLoop));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getMPolygonTree(out OdDbMPolygonNode loopNode)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = (SwigDerivedClassHasMethod("getMPolygonTree", swigMethodTypes207) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getMPolygonTreeSwigExplicitOdDbMPolygon(swigCPtr, out jarg) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getMPolygonTree(swigCPtr, out jarg));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdDbMPolygonNode>(typeof(OdDbMPolygonNode), jarg, bIsWrapperOwnNativeObject: true));
			loopNode = ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdDbMPolygonNode>(typeof(OdDbMPolygonNode), jarg, currentTransaction == null);
		}
	}

	public virtual void deleteMPolygonTree(OdDbMPolygonNode loopNode)
	{
		if (SwigDerivedClassHasMethod("deleteMPolygonTree", swigMethodTypes208))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_deleteMPolygonTreeSwigExplicitOdDbMPolygon(swigCPtr, OdDbMPolygonNode.getCPtr(loopNode));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_deleteMPolygonTree(swigCPtr, OdDbMPolygonNode.getCPtr(loopNode));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int getClosestLoopTo(OdGePoint3d worldPt)
	{
		int result = (SwigDerivedClassHasMethod("getClosestLoopTo", swigMethodTypes209) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getClosestLoopToSwigExplicitOdDbMPolygon(swigCPtr, OdGePoint3d.getCPtr(worldPt)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getClosestLoopTo(swigCPtr, OdGePoint3d.getCPtr(worldPt)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getPerimeter()
	{
		double result = (SwigDerivedClassHasMethod("getPerimeter", swigMethodTypes210) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getPerimeterSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getPerimeter(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult balanceTree()
	{
		int result = (SwigDerivedClassHasMethod("balanceTree", swigMethodTypes211) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_balanceTreeSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_balanceTree(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool isBalanced()
	{
		bool result = (SwigDerivedClassHasMethod("isBalanced", swigMethodTypes212) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_isBalancedSwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_isBalanced(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult balanceDisplay()
	{
		int result = (SwigDerivedClassHasMethod("balanceDisplay", swigMethodTypes213) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_balanceDisplaySwigExplicitOdDbMPolygon(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_balanceDisplay(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createLoopsFromBoundaries(OdDbObjectIdArray ids, OdIntArray rejectedObjs, bool excludeCrossing, double tol)
	{
		int result = (SwigDerivedClassHasMethod("createLoopsFromBoundaries", swigMethodTypes214) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createLoopsFromBoundariesSwigExplicitOdDbMPolygon__SWIG_0(swigCPtr, OdDbObjectIdArray.getCPtr(ids), OdIntArray.getCPtr(rejectedObjs).Handle, excludeCrossing, tol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createLoopsFromBoundaries__SWIG_0(swigCPtr, OdDbObjectIdArray.getCPtr(ids), OdIntArray.getCPtr(rejectedObjs).Handle, excludeCrossing, tol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createLoopsFromBoundaries(OdDbObjectIdArray ids, OdIntArray rejectedObjs, bool excludeCrossing)
	{
		int result = (SwigDerivedClassHasMethod("createLoopsFromBoundaries", swigMethodTypes215) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createLoopsFromBoundariesSwigExplicitOdDbMPolygon__SWIG_1(swigCPtr, OdDbObjectIdArray.getCPtr(ids), OdIntArray.getCPtr(rejectedObjs).Handle, excludeCrossing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createLoopsFromBoundaries__SWIG_1(swigCPtr, OdDbObjectIdArray.getCPtr(ids), OdIntArray.getCPtr(rejectedObjs).Handle, excludeCrossing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createLoopsFromBoundaries(OdDbObjectIdArray ids, OdIntArray rejectedObjs)
	{
		int result = (SwigDerivedClassHasMethod("createLoopsFromBoundaries", swigMethodTypes216) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createLoopsFromBoundariesSwigExplicitOdDbMPolygon__SWIG_2(swigCPtr, OdDbObjectIdArray.getCPtr(ids), OdIntArray.getCPtr(rejectedObjs).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createLoopsFromBoundaries__SWIG_2(swigCPtr, OdDbObjectIdArray.getCPtr(ids), OdIntArray.getCPtr(rejectedObjs).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createLoops(OdGePoint2dArrayArray vertices, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t bulges, OdIntArray rejectedObjs, bool excludeCrossing, double tol)
	{
		int result = (SwigDerivedClassHasMethod("createLoops", swigMethodTypes217) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createLoopsSwigExplicitOdDbMPolygon__SWIG_0(swigCPtr, OdGePoint2dArrayArray.getCPtr(vertices).Handle, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t.getCPtr(bulges), OdIntArray.getCPtr(rejectedObjs).Handle, excludeCrossing, tol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createLoops__SWIG_0(swigCPtr, OdGePoint2dArrayArray.getCPtr(vertices).Handle, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t.getCPtr(bulges), OdIntArray.getCPtr(rejectedObjs).Handle, excludeCrossing, tol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createLoops(OdGePoint2dArrayArray vertices, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t bulges, OdIntArray rejectedObjs, bool excludeCrossing)
	{
		int result = (SwigDerivedClassHasMethod("createLoops", swigMethodTypes218) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createLoopsSwigExplicitOdDbMPolygon__SWIG_1(swigCPtr, OdGePoint2dArrayArray.getCPtr(vertices).Handle, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t.getCPtr(bulges), OdIntArray.getCPtr(rejectedObjs).Handle, excludeCrossing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createLoops__SWIG_1(swigCPtr, OdGePoint2dArrayArray.getCPtr(vertices).Handle, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t.getCPtr(bulges), OdIntArray.getCPtr(rejectedObjs).Handle, excludeCrossing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createLoops(OdGePoint2dArrayArray vertices, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t bulges, OdIntArray rejectedObjs)
	{
		int result = (SwigDerivedClassHasMethod("createLoops", swigMethodTypes219) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createLoopsSwigExplicitOdDbMPolygon__SWIG_2(swigCPtr, OdGePoint2dArrayArray.getCPtr(vertices).Handle, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t.getCPtr(bulges), OdIntArray.getCPtr(rejectedObjs).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createLoops__SWIG_2(swigCPtr, OdGePoint2dArrayArray.getCPtr(vertices).Handle, SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t.getCPtr(bulges), OdIntArray.getCPtr(rejectedObjs).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getChildLoops(int curLoop, OdIntArray selectedLoopIndexes)
	{
		int result = (SwigDerivedClassHasMethod("getChildLoops", swigMethodTypes220) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getChildLoopsSwigExplicitOdDbMPolygon(swigCPtr, curLoop, OdIntArray.getCPtr(selectedLoopIndexes).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getChildLoops(swigCPtr, curLoop, OdIntArray.getCPtr(selectedLoopIndexes).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_dwgInFieldsSwigExplicitOdDbMPolygon(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_dwgOutFieldsSwigExplicitOdDbMPolygon(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_dxfInFieldsSwigExplicitOdDbMPolygon(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_dxfOutFieldsSwigExplicitOdDbMPolygon(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void subSetDatabaseDefaults(OdDbDatabase pDb, bool doSubents)
	{
		if (SwigDerivedClassHasMethod("subSetDatabaseDefaults", swigMethodTypes106))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_subSetDatabaseDefaultsSwigExplicitOdDbMPolygon(swigCPtr, OdDbDatabase.getCPtr(pDb), doSubents);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_subSetDatabaseDefaults(swigCPtr, OdDbDatabase.getCPtr(pDb), doSubents);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void saveAs(OdGiWorldDraw pWd, DwgVersion ver)
	{
		if (SwigDerivedClassHasMethod("saveAs", swigMethodTypes109))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_saveAsSwigExplicitOdDbMPolygon(swigCPtr, OdGiWorldDraw.getCPtr(pWd), (int)ver);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_saveAs(swigCPtr, OdGiWorldDraw.getCPtr(pWd), (int)ver);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbEntity SubSubentPtr(OdDbFullSubentPath path)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_SubSubentPtr(swigCPtr, OdDbFullSubentPath.getCPtr(path)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult SubExplode(OdRxObjectPtrArray entitySet)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_SubExplode(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubTransformBy(OdGeMatrix3d xfn)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_SubTransformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfn));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override bool SubWorldDraw(OdGiWorldDraw pWd)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_SubWorldDraw(swigCPtr, OdGiWorldDraw.getCPtr(pWd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbMPolygon createObject()
	{
		OdDbMPolygon rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbMPolygon>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_createObject(), bOwn: true, bTryAddToTransaction: true);
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
			swigDelegate136 = SwigDirectorMethodsubSetVisibility__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subSetVisibility", swigMethodTypes137))
		{
			swigDelegate137 = SwigDirectorMethodsubSetVisibility__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subGetGeomExtents", swigMethodTypes138))
		{
			swigDelegate138 = SwigDirectorMethodsubGetGeomExtents;
		}
		if (SwigDerivedClassHasMethod("subDeleteSubentPaths", swigMethodTypes139))
		{
			swigDelegate139 = SwigDirectorMethodsubDeleteSubentPaths;
		}
		if (SwigDerivedClassHasMethod("subAddSubentPaths", swigMethodTypes140))
		{
			swigDelegate140 = SwigDirectorMethodsubAddSubentPaths;
		}
		if (SwigDerivedClassHasMethod("subMoveGripPointsAtSubentPaths", swigMethodTypes141))
		{
			swigDelegate141 = SwigDirectorMethodsubMoveGripPointsAtSubentPaths;
		}
		if (SwigDerivedClassHasMethod("subGetGripPointsAtSubentPath", swigMethodTypes142))
		{
			swigDelegate142 = SwigDirectorMethodsubGetGripPointsAtSubentPath;
		}
		if (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes143))
		{
			swigDelegate143 = SwigDirectorMethodsubGetSubentPathsAtGsMarker__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subGetSubentPathsAtGsMarker", swigMethodTypes144))
		{
			swigDelegate144 = SwigDirectorMethodsubGetSubentPathsAtGsMarker__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subGetGsMarkersAtSubentPath", swigMethodTypes145))
		{
			swigDelegate145 = SwigDirectorMethodsubGetGsMarkersAtSubentPath;
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
		if (SwigDerivedClassHasMethod("hatch", swigMethodTypes150))
		{
			swigDelegate150 = SwigDirectorMethodhatch__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("hatch", swigMethodTypes151))
		{
			swigDelegate151 = SwigDirectorMethodhatch__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("elevation", swigMethodTypes152))
		{
			swigDelegate152 = SwigDirectorMethodelevation;
		}
		if (SwigDerivedClassHasMethod("setElevation", swigMethodTypes153))
		{
			swigDelegate153 = SwigDirectorMethodsetElevation;
		}
		if (SwigDerivedClassHasMethod("normal", swigMethodTypes154))
		{
			swigDelegate154 = SwigDirectorMethodnormal;
		}
		if (SwigDerivedClassHasMethod("setNormal", swigMethodTypes155))
		{
			swigDelegate155 = SwigDirectorMethodsetNormal;
		}
		if (SwigDerivedClassHasMethod("evaluateHatch", swigMethodTypes156))
		{
			swigDelegate156 = SwigDirectorMethodevaluateHatch__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("evaluateHatch", swigMethodTypes157))
		{
			swigDelegate157 = SwigDirectorMethodevaluateHatch__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("patternType", swigMethodTypes158))
		{
			swigDelegate158 = SwigDirectorMethodpatternType;
		}
		if (SwigDerivedClassHasMethod("patternName", swigMethodTypes159))
		{
			swigDelegate159 = SwigDirectorMethodpatternName;
		}
		if (SwigDerivedClassHasMethod("setPattern", swigMethodTypes160))
		{
			swigDelegate160 = SwigDirectorMethodsetPattern;
		}
		if (SwigDerivedClassHasMethod("patternAngle", swigMethodTypes161))
		{
			swigDelegate161 = SwigDirectorMethodpatternAngle;
		}
		if (SwigDerivedClassHasMethod("setPatternAngle", swigMethodTypes162))
		{
			swigDelegate162 = SwigDirectorMethodsetPatternAngle;
		}
		if (SwigDerivedClassHasMethod("patternSpace", swigMethodTypes163))
		{
			swigDelegate163 = SwigDirectorMethodpatternSpace;
		}
		if (SwigDerivedClassHasMethod("setPatternSpace", swigMethodTypes164))
		{
			swigDelegate164 = SwigDirectorMethodsetPatternSpace;
		}
		if (SwigDerivedClassHasMethod("patternScale", swigMethodTypes165))
		{
			swigDelegate165 = SwigDirectorMethodpatternScale;
		}
		if (SwigDerivedClassHasMethod("setPatternScale", swigMethodTypes166))
		{
			swigDelegate166 = SwigDirectorMethodsetPatternScale;
		}
		if (SwigDerivedClassHasMethod("patternDouble", swigMethodTypes167))
		{
			swigDelegate167 = SwigDirectorMethodpatternDouble;
		}
		if (SwigDerivedClassHasMethod("setPatternDouble", swigMethodTypes168))
		{
			swigDelegate168 = SwigDirectorMethodsetPatternDouble;
		}
		if (SwigDerivedClassHasMethod("numPatternDefinitions", swigMethodTypes169))
		{
			swigDelegate169 = SwigDirectorMethodnumPatternDefinitions;
		}
		if (SwigDerivedClassHasMethod("getPatternDefinitionAt", swigMethodTypes170))
		{
			swigDelegate170 = SwigDirectorMethodgetPatternDefinitionAt;
		}
		if (SwigDerivedClassHasMethod("patternColor", swigMethodTypes171))
		{
			swigDelegate171 = SwigDirectorMethodpatternColor;
		}
		if (SwigDerivedClassHasMethod("setPatternColor", swigMethodTypes172))
		{
			swigDelegate172 = SwigDirectorMethodsetPatternColor;
		}
		if (SwigDerivedClassHasMethod("getArea", swigMethodTypes173))
		{
			swigDelegate173 = SwigDirectorMethodgetArea__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getArea", swigMethodTypes174))
		{
			swigDelegate174 = SwigDirectorMethodgetArea__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getOffsetVector", swigMethodTypes175))
		{
			swigDelegate175 = SwigDirectorMethodgetOffsetVector;
		}
		if (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes176))
		{
			swigDelegate176 = SwigDirectorMethodappendLoopFromBoundary__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes177))
		{
			swigDelegate177 = SwigDirectorMethodappendLoopFromBoundary__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes178))
		{
			swigDelegate178 = SwigDirectorMethodappendLoopFromBoundary__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes179))
		{
			swigDelegate179 = SwigDirectorMethodappendLoopFromBoundary__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes180))
		{
			swigDelegate180 = SwigDirectorMethodappendLoopFromBoundary__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes181))
		{
			swigDelegate181 = SwigDirectorMethodappendLoopFromBoundary__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes182))
		{
			swigDelegate182 = SwigDirectorMethodappendLoopFromBoundary__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes183))
		{
			swigDelegate183 = SwigDirectorMethodappendLoopFromBoundary__SWIG_7;
		}
		if (SwigDerivedClassHasMethod("appendLoopFromBoundary", swigMethodTypes184))
		{
			swigDelegate184 = SwigDirectorMethodappendLoopFromBoundary__SWIG_8;
		}
		if (SwigDerivedClassHasMethod("numMPolygonLoops", swigMethodTypes185))
		{
			swigDelegate185 = SwigDirectorMethodnumMPolygonLoops;
		}
		if (SwigDerivedClassHasMethod("getMPolygonLoopAt", swigMethodTypes186))
		{
			swigDelegate186 = SwigDirectorMethodgetMPolygonLoopAt;
		}
		if (SwigDerivedClassHasMethod("appendMPolygonLoop", swigMethodTypes187))
		{
			swigDelegate187 = SwigDirectorMethodappendMPolygonLoop__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("appendMPolygonLoop", swigMethodTypes188))
		{
			swigDelegate188 = SwigDirectorMethodappendMPolygonLoop__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("appendMPolygonLoop", swigMethodTypes189))
		{
			swigDelegate189 = SwigDirectorMethodappendMPolygonLoop__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("insertMPolygonLoopAt", swigMethodTypes190))
		{
			swigDelegate190 = SwigDirectorMethodinsertMPolygonLoopAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("insertMPolygonLoopAt", swigMethodTypes191))
		{
			swigDelegate191 = SwigDirectorMethodinsertMPolygonLoopAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("insertMPolygonLoopAt", swigMethodTypes192))
		{
			swigDelegate192 = SwigDirectorMethodinsertMPolygonLoopAt__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("replaceMPolygonLoopAt", swigMethodTypes193))
		{
			swigDelegate193 = SwigDirectorMethodreplaceMPolygonLoopAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("replaceMPolygonLoopAt", swigMethodTypes194))
		{
			swigDelegate194 = SwigDirectorMethodreplaceMPolygonLoopAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("replaceMPolygonLoopAt", swigMethodTypes195))
		{
			swigDelegate195 = SwigDirectorMethodreplaceMPolygonLoopAt__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("replaceMPolygonLoopAt", swigMethodTypes196))
		{
			swigDelegate196 = SwigDirectorMethodreplaceMPolygonLoopAt__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("replaceMPolygonLoopAt", swigMethodTypes197))
		{
			swigDelegate197 = SwigDirectorMethodreplaceMPolygonLoopAt__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("replaceMPolygonLoopAt", swigMethodTypes198))
		{
			swigDelegate198 = SwigDirectorMethodreplaceMPolygonLoopAt__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("removeMPolygonLoopAt", swigMethodTypes199))
		{
			swigDelegate199 = SwigDirectorMethodremoveMPolygonLoopAt;
		}
		if (SwigDerivedClassHasMethod("getLoopDirection", swigMethodTypes200))
		{
			swigDelegate200 = SwigDirectorMethodgetLoopDirection;
		}
		if (SwigDerivedClassHasMethod("setLoopDirection", swigMethodTypes201))
		{
			swigDelegate201 = SwigDirectorMethodsetLoopDirection;
		}
		if (SwigDerivedClassHasMethod("isPointOnLoopBoundary", swigMethodTypes202))
		{
			swigDelegate202 = SwigDirectorMethodisPointOnLoopBoundary__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("isPointOnLoopBoundary", swigMethodTypes203))
		{
			swigDelegate203 = SwigDirectorMethodisPointOnLoopBoundary__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isPointInsideMPolygon", swigMethodTypes204))
		{
			swigDelegate204 = SwigDirectorMethodisPointInsideMPolygon__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("isPointInsideMPolygon", swigMethodTypes205))
		{
			swigDelegate205 = SwigDirectorMethodisPointInsideMPolygon__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getParentLoop", swigMethodTypes206))
		{
			swigDelegate206 = SwigDirectorMethodgetParentLoop;
		}
		if (SwigDerivedClassHasMethod("getMPolygonTree", swigMethodTypes207))
		{
			swigDelegate207 = SwigDirectorMethodgetMPolygonTree;
		}
		if (SwigDerivedClassHasMethod("deleteMPolygonTree", swigMethodTypes208))
		{
			swigDelegate208 = SwigDirectorMethoddeleteMPolygonTree;
		}
		if (SwigDerivedClassHasMethod("getClosestLoopTo", swigMethodTypes209))
		{
			swigDelegate209 = SwigDirectorMethodgetClosestLoopTo;
		}
		if (SwigDerivedClassHasMethod("getPerimeter", swigMethodTypes210))
		{
			swigDelegate210 = SwigDirectorMethodgetPerimeter;
		}
		if (SwigDerivedClassHasMethod("balanceTree", swigMethodTypes211))
		{
			swigDelegate211 = SwigDirectorMethodbalanceTree;
		}
		if (SwigDerivedClassHasMethod("isBalanced", swigMethodTypes212))
		{
			swigDelegate212 = SwigDirectorMethodisBalanced;
		}
		if (SwigDerivedClassHasMethod("balanceDisplay", swigMethodTypes213))
		{
			swigDelegate213 = SwigDirectorMethodbalanceDisplay;
		}
		if (SwigDerivedClassHasMethod("createLoopsFromBoundaries", swigMethodTypes214))
		{
			swigDelegate214 = SwigDirectorMethodcreateLoopsFromBoundaries__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createLoopsFromBoundaries", swigMethodTypes215))
		{
			swigDelegate215 = SwigDirectorMethodcreateLoopsFromBoundaries__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createLoopsFromBoundaries", swigMethodTypes216))
		{
			swigDelegate216 = SwigDirectorMethodcreateLoopsFromBoundaries__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("createLoops", swigMethodTypes217))
		{
			swigDelegate217 = SwigDirectorMethodcreateLoops__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createLoops", swigMethodTypes218))
		{
			swigDelegate218 = SwigDirectorMethodcreateLoops__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createLoops", swigMethodTypes219))
		{
			swigDelegate219 = SwigDirectorMethodcreateLoops__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getChildLoops", swigMethodTypes220))
		{
			swigDelegate220 = SwigDirectorMethodgetChildLoops;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygon_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125, swigDelegate126, swigDelegate127, swigDelegate128, swigDelegate129, swigDelegate130, swigDelegate131, swigDelegate132, swigDelegate133, swigDelegate134, swigDelegate135, swigDelegate136, swigDelegate137, swigDelegate138, swigDelegate139, swigDelegate140, swigDelegate141, swigDelegate142, swigDelegate143, swigDelegate144, swigDelegate145, swigDelegate146, swigDelegate147, swigDelegate148, swigDelegate149, swigDelegate150, swigDelegate151, swigDelegate152, swigDelegate153, swigDelegate154, swigDelegate155, swigDelegate156, swigDelegate157, swigDelegate158, swigDelegate159, swigDelegate160, swigDelegate161, swigDelegate162, swigDelegate163, swigDelegate164, swigDelegate165, swigDelegate166, swigDelegate167, swigDelegate168, swigDelegate169, swigDelegate170, swigDelegate171, swigDelegate172, swigDelegate173, swigDelegate174, swigDelegate175, swigDelegate176, swigDelegate177, swigDelegate178, swigDelegate179, swigDelegate180, swigDelegate181, swigDelegate182, swigDelegate183, swigDelegate184, swigDelegate185, swigDelegate186, swigDelegate187, swigDelegate188, swigDelegate189, swigDelegate190, swigDelegate191, swigDelegate192, swigDelegate193, swigDelegate194, swigDelegate195, swigDelegate196, swigDelegate197, swigDelegate198, swigDelegate199, swigDelegate200, swigDelegate201, swigDelegate202, swigDelegate203, swigDelegate204, swigDelegate205, swigDelegate206, swigDelegate207, swigDelegate208, swigDelegate209, swigDelegate210, swigDelegate211, swigDelegate212, swigDelegate213, swigDelegate214, swigDelegate215, swigDelegate216, swigDelegate217, swigDelegate218, swigDelegate219, swigDelegate220);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbMPolygon));
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

	private IntPtr SwigDirectorMethodhatch__SWIG_0()
	{
		return OdDbHatch.getCPtr(hatch()).Handle;
	}

	private IntPtr SwigDirectorMethodhatch__SWIG_1()
	{
		return OdDbHatch.getCPtr(hatch()).Handle;
	}

	private double SwigDirectorMethodelevation()
	{
		return elevation();
	}

	private void SwigDirectorMethodsetElevation(double elevation)
	{
		try
		{
			setElevation(elevation);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
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

	private void SwigDirectorMethodsetNormal(IntPtr normal)
	{
		try
		{
			setNormal(new OdGeVector3d(normal, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodevaluateHatch__SWIG_0(bool bUnderestimateNumLines)
	{
		return (int)evaluateHatch(bUnderestimateNumLines);
	}

	private int SwigDirectorMethodevaluateHatch__SWIG_1()
	{
		return (int)evaluateHatch();
	}

	private int SwigDirectorMethodpatternType()
	{
		return (int)patternType();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodpatternName()
	{
		return patternName();
	}

	private void SwigDirectorMethodsetPattern(int patType, [MarshalAs(UnmanagedType.LPWStr)] string patName)
	{
		try
		{
			setPattern((OdDbHatch_HatchPatternType)patType, patName);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodpatternAngle()
	{
		return patternAngle();
	}

	private void SwigDirectorMethodsetPatternAngle(double angle)
	{
		try
		{
			setPatternAngle(angle);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodpatternSpace()
	{
		return patternSpace();
	}

	private void SwigDirectorMethodsetPatternSpace(double space)
	{
		try
		{
			setPatternSpace(space);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodpatternScale()
	{
		return patternScale();
	}

	private void SwigDirectorMethodsetPatternScale(double scale)
	{
		try
		{
			setPatternScale(scale);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodpatternDouble()
	{
		return patternDouble();
	}

	private void SwigDirectorMethodsetPatternDouble(bool isDouble)
	{
		try
		{
			setPatternDouble(isDouble);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodnumPatternDefinitions()
	{
		return numPatternDefinitions();
	}

	private void SwigDirectorMethodgetPatternDefinitionAt(int index, double angle, double baseX, double baseY, double offsetX, double offsetY, IntPtr dashes)
	{
		try
		{
			getPatternDefinitionAt(index, out angle, out baseX, out baseY, out offsetX, out offsetY, new OdDoubleArray(dashes, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodpatternColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(patternColor()).Handle;
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

	private void SwigDirectorMethodsetPatternColor(IntPtr pc)
	{
		try
		{
			setPatternColor(new OdCmColor(pc, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodgetArea__SWIG_0(double area, bool areaViaHatch)
	{
		return (int)getArea(out area, areaViaHatch);
	}

	private int SwigDirectorMethodgetArea__SWIG_1(double area)
	{
		return (int)getArea(out area);
	}

	private IntPtr SwigDirectorMethodgetOffsetVector()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector2d.getCPtr(getOffsetVector()).Handle;
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

	private int SwigDirectorMethodappendLoopFromBoundary__SWIG_0(IntPtr pCircle, bool excludeCrossing, double tol)
	{
		return (int)appendLoopFromBoundary(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCircle>(pCircle, bOwn: false, bTryAddToTransaction: false), excludeCrossing, tol);
	}

	private int SwigDirectorMethodappendLoopFromBoundary__SWIG_1(IntPtr pCircle, bool excludeCrossing)
	{
		return (int)appendLoopFromBoundary(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCircle>(pCircle, bOwn: false, bTryAddToTransaction: false), excludeCrossing);
	}

	private int SwigDirectorMethodappendLoopFromBoundary__SWIG_2(IntPtr pCircle)
	{
		return (int)appendLoopFromBoundary(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCircle>(pCircle, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodappendLoopFromBoundary__SWIG_3(IntPtr pPoly, bool excludeCrossing, double tol)
	{
		return (int)appendLoopFromBoundary(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPolyline>(pPoly, bOwn: false, bTryAddToTransaction: false), excludeCrossing, tol);
	}

	private int SwigDirectorMethodappendLoopFromBoundary__SWIG_4(IntPtr pPoly, bool excludeCrossing)
	{
		return (int)appendLoopFromBoundary(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPolyline>(pPoly, bOwn: false, bTryAddToTransaction: false), excludeCrossing);
	}

	private int SwigDirectorMethodappendLoopFromBoundary__SWIG_5(IntPtr pPoly)
	{
		return (int)appendLoopFromBoundary(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPolyline>(pPoly, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodappendLoopFromBoundary__SWIG_6(IntPtr pPoly, bool excludeCrossing, double tol)
	{
		return (int)appendLoopFromBoundary(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb2dPolyline>(pPoly, bOwn: false, bTryAddToTransaction: false), excludeCrossing, tol);
	}

	private int SwigDirectorMethodappendLoopFromBoundary__SWIG_7(IntPtr pPoly, bool excludeCrossing)
	{
		return (int)appendLoopFromBoundary(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb2dPolyline>(pPoly, bOwn: false, bTryAddToTransaction: false), excludeCrossing);
	}

	private int SwigDirectorMethodappendLoopFromBoundary__SWIG_8(IntPtr pPoly)
	{
		return (int)appendLoopFromBoundary(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb2dPolyline>(pPoly, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodnumMPolygonLoops()
	{
		return numMPolygonLoops();
	}

	private int SwigDirectorMethodgetMPolygonLoopAt(int loopIndex, IntPtr vertices, IntPtr bulges)
	{
		return (int)getMPolygonLoopAt(loopIndex, new OdGePoint2dArray(vertices, cMemoryOwn: true), new OdDoubleArray(bulges, cMemoryOwn: true));
	}

	private int SwigDirectorMethodappendMPolygonLoop__SWIG_0(IntPtr vertices, IntPtr bulges, bool excludeCrossing, double tol)
	{
		return (int)appendMPolygonLoop(new OdGePoint2dArray(vertices, cMemoryOwn: true), new OdDoubleArray(bulges, cMemoryOwn: true), excludeCrossing, tol);
	}

	private int SwigDirectorMethodappendMPolygonLoop__SWIG_1(IntPtr vertices, IntPtr bulges, bool excludeCrossing)
	{
		return (int)appendMPolygonLoop(new OdGePoint2dArray(vertices, cMemoryOwn: true), new OdDoubleArray(bulges, cMemoryOwn: true), excludeCrossing);
	}

	private int SwigDirectorMethodappendMPolygonLoop__SWIG_2(IntPtr vertices, IntPtr bulges)
	{
		return (int)appendMPolygonLoop(new OdGePoint2dArray(vertices, cMemoryOwn: true), new OdDoubleArray(bulges, cMemoryOwn: true));
	}

	private int SwigDirectorMethodinsertMPolygonLoopAt__SWIG_0(int loopIndex, IntPtr vertices, IntPtr bulges, bool excludeCrossing, double tol)
	{
		return (int)insertMPolygonLoopAt(loopIndex, new OdGePoint2dArray(vertices, cMemoryOwn: true), new OdDoubleArray(bulges, cMemoryOwn: true), excludeCrossing, tol);
	}

	private int SwigDirectorMethodinsertMPolygonLoopAt__SWIG_1(int loopIndex, IntPtr vertices, IntPtr bulges, bool excludeCrossing)
	{
		return (int)insertMPolygonLoopAt(loopIndex, new OdGePoint2dArray(vertices, cMemoryOwn: true), new OdDoubleArray(bulges, cMemoryOwn: true), excludeCrossing);
	}

	private int SwigDirectorMethodinsertMPolygonLoopAt__SWIG_2(int loopIndex, IntPtr vertices, IntPtr bulges)
	{
		return (int)insertMPolygonLoopAt(loopIndex, new OdGePoint2dArray(vertices, cMemoryOwn: true), new OdDoubleArray(bulges, cMemoryOwn: true));
	}

	private int SwigDirectorMethodreplaceMPolygonLoopAt__SWIG_0(int loopIndex, IntPtr vertices, IntPtr bulges, bool excludeCrossing, double tol)
	{
		return (int)replaceMPolygonLoopAt(loopIndex, new OdGePoint2dArray(vertices, cMemoryOwn: true), new OdDoubleArray(bulges, cMemoryOwn: true), excludeCrossing, tol);
	}

	private int SwigDirectorMethodreplaceMPolygonLoopAt__SWIG_1(int loopIndex, IntPtr vertices, IntPtr bulges, bool excludeCrossing)
	{
		return (int)replaceMPolygonLoopAt(loopIndex, new OdGePoint2dArray(vertices, cMemoryOwn: true), new OdDoubleArray(bulges, cMemoryOwn: true), excludeCrossing);
	}

	private int SwigDirectorMethodreplaceMPolygonLoopAt__SWIG_2(int loopIndex, IntPtr vertices, IntPtr bulges)
	{
		return (int)replaceMPolygonLoopAt(loopIndex, new OdGePoint2dArray(vertices, cMemoryOwn: true), new OdDoubleArray(bulges, cMemoryOwn: true));
	}

	private int SwigDirectorMethodreplaceMPolygonLoopAt__SWIG_3(IntPtr loopIndices, IntPtr vertices, IntPtr bulges, IntPtr rejectedLoop, bool excludeCrossing, double tol)
	{
		return (int)replaceMPolygonLoopAt(new OdIntArray(loopIndices, cMemoryOwn: true), new OdGePoint2dArrayArray(vertices, cMemoryOwn: true), new SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t(bulges, futureUse: false), new OdIntArray(rejectedLoop, cMemoryOwn: true), excludeCrossing, tol);
	}

	private int SwigDirectorMethodreplaceMPolygonLoopAt__SWIG_4(IntPtr loopIndices, IntPtr vertices, IntPtr bulges, IntPtr rejectedLoop, bool excludeCrossing)
	{
		return (int)replaceMPolygonLoopAt(new OdIntArray(loopIndices, cMemoryOwn: true), new OdGePoint2dArrayArray(vertices, cMemoryOwn: true), new SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t(bulges, futureUse: false), new OdIntArray(rejectedLoop, cMemoryOwn: true), excludeCrossing);
	}

	private int SwigDirectorMethodreplaceMPolygonLoopAt__SWIG_5(IntPtr loopIndices, IntPtr vertices, IntPtr bulges, IntPtr rejectedLoop)
	{
		return (int)replaceMPolygonLoopAt(new OdIntArray(loopIndices, cMemoryOwn: true), new OdGePoint2dArrayArray(vertices, cMemoryOwn: true), new SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t(bulges, futureUse: false), new OdIntArray(rejectedLoop, cMemoryOwn: true));
	}

	private int SwigDirectorMethodremoveMPolygonLoopAt(int loopIndex)
	{
		return (int)removeMPolygonLoopAt(loopIndex);
	}

	private int SwigDirectorMethodgetLoopDirection(int lindex, OdDbMPolygon_loopDir dir)
	{
		return (int)getLoopDirection(lindex, out dir);
	}

	private int SwigDirectorMethodsetLoopDirection(int lindex, int dir)
	{
		return (int)setLoopDirection(lindex, (OdDbMPolygon_loopDir)dir);
	}

	private bool SwigDirectorMethodisPointOnLoopBoundary__SWIG_0(IntPtr worldPt, int loop, double tol)
	{
		return isPointOnLoopBoundary(new OdGePoint3d(worldPt, cMemoryOwn: false), loop, tol);
	}

	private bool SwigDirectorMethodisPointOnLoopBoundary__SWIG_1(IntPtr worldPt, int loop)
	{
		return isPointOnLoopBoundary(new OdGePoint3d(worldPt, cMemoryOwn: false), loop);
	}

	private int SwigDirectorMethodisPointInsideMPolygon__SWIG_0(IntPtr worldPt, IntPtr loopsArray, double tol)
	{
		return isPointInsideMPolygon(new OdGePoint3d(worldPt, cMemoryOwn: false), new OdIntArray(loopsArray, cMemoryOwn: true), tol);
	}

	private int SwigDirectorMethodisPointInsideMPolygon__SWIG_1(IntPtr worldPt, IntPtr loopsArray)
	{
		return isPointInsideMPolygon(new OdGePoint3d(worldPt, cMemoryOwn: false), new OdIntArray(loopsArray, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetParentLoop(int curLoop)
	{
		return getParentLoop(curLoop);
	}

	private int SwigDirectorMethodgetMPolygonTree(IntPtr loopNode)
	{
		OdDbMPolygonNode loopNode2 = new OdDbMPolygonNode(loopNode, cMemoryOwn: true);
		try
		{
			return (int)getMPolygonTree(out loopNode2);
		}
		finally
		{
			loopNode = OdDbMPolygonNode.getCPtr(loopNode2).Handle;
		}
	}

	private void SwigDirectorMethoddeleteMPolygonTree(IntPtr loopNode)
	{
		try
		{
			deleteMPolygonTree((loopNode == IntPtr.Zero) ? null : new OdDbMPolygonNode(loopNode, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodgetClosestLoopTo(IntPtr worldPt)
	{
		return getClosestLoopTo(new OdGePoint3d(worldPt, cMemoryOwn: false));
	}

	private double SwigDirectorMethodgetPerimeter()
	{
		return getPerimeter();
	}

	private int SwigDirectorMethodbalanceTree()
	{
		return (int)balanceTree();
	}

	private bool SwigDirectorMethodisBalanced()
	{
		return isBalanced();
	}

	private int SwigDirectorMethodbalanceDisplay()
	{
		return (int)balanceDisplay();
	}

	private int SwigDirectorMethodcreateLoopsFromBoundaries__SWIG_0(IntPtr ids, IntPtr rejectedObjs, bool excludeCrossing, double tol)
	{
		return (int)createLoopsFromBoundaries(new OdDbObjectIdArray(ids, cMemoryOwn: false), new OdIntArray(rejectedObjs, cMemoryOwn: true), excludeCrossing, tol);
	}

	private int SwigDirectorMethodcreateLoopsFromBoundaries__SWIG_1(IntPtr ids, IntPtr rejectedObjs, bool excludeCrossing)
	{
		return (int)createLoopsFromBoundaries(new OdDbObjectIdArray(ids, cMemoryOwn: false), new OdIntArray(rejectedObjs, cMemoryOwn: true), excludeCrossing);
	}

	private int SwigDirectorMethodcreateLoopsFromBoundaries__SWIG_2(IntPtr ids, IntPtr rejectedObjs)
	{
		return (int)createLoopsFromBoundaries(new OdDbObjectIdArray(ids, cMemoryOwn: false), new OdIntArray(rejectedObjs, cMemoryOwn: true));
	}

	private int SwigDirectorMethodcreateLoops__SWIG_0(IntPtr vertices, IntPtr bulges, IntPtr rejectedObjs, bool excludeCrossing, double tol)
	{
		return (int)createLoops(new OdGePoint2dArrayArray(vertices, cMemoryOwn: true), new SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t(bulges, futureUse: false), new OdIntArray(rejectedObjs, cMemoryOwn: true), excludeCrossing, tol);
	}

	private int SwigDirectorMethodcreateLoops__SWIG_1(IntPtr vertices, IntPtr bulges, IntPtr rejectedObjs, bool excludeCrossing)
	{
		return (int)createLoops(new OdGePoint2dArrayArray(vertices, cMemoryOwn: true), new SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t(bulges, futureUse: false), new OdIntArray(rejectedObjs, cMemoryOwn: true), excludeCrossing);
	}

	private int SwigDirectorMethodcreateLoops__SWIG_2(IntPtr vertices, IntPtr bulges, IntPtr rejectedObjs)
	{
		return (int)createLoops(new OdGePoint2dArrayArray(vertices, cMemoryOwn: true), new SWIGTYPE_p_OdArrayT_OdArrayT_double_OdMemoryAllocatorT_double_t_t_t(bulges, futureUse: false), new OdIntArray(rejectedObjs, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetChildLoops(int curLoop, IntPtr selectedLoopIndexes)
	{
		return (int)getChildLoops(curLoop, new OdIntArray(selectedLoopIndexes, cMemoryOwn: true));
	}
}

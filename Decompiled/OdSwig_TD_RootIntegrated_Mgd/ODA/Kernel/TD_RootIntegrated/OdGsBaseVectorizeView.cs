using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBaseVectorizeView : OdGsViewImpl
{
	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_1();

	public delegate void SwigDelegateOdGsBaseVectorizeView_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_3();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_4();

	public delegate void SwigDelegateOdGsBaseVectorizeView_5(IntPtr pUserGiContext);

	public delegate double SwigDelegateOdGsBaseVectorizeView_6();

	public delegate void SwigDelegateOdGsBaseVectorizeView_7(double scale);

	public delegate void SwigDelegateOdGsBaseVectorizeView_8(IntPtr numLineweights, ushort altSourceLwds);

	public delegate void SwigDelegateOdGsBaseVectorizeView_9(IntPtr numLineweights);

	public delegate void SwigDelegateOdGsBaseVectorizeView_10(IntPtr lowerLeft, IntPtr upperRight);

	public delegate void SwigDelegateOdGsBaseVectorizeView_11(IntPtr screenRect);

	public delegate void SwigDelegateOdGsBaseVectorizeView_12(IntPtr screenRec);

	public delegate void SwigDelegateOdGsBaseVectorizeView_13(IntPtr lowerLeft, IntPtr upperRight);

	public delegate void SwigDelegateOdGsBaseVectorizeView_14(IntPtr screenRect);

	public delegate void SwigDelegateOdGsBaseVectorizeView_15(IntPtr screenRec);

	public delegate void SwigDelegateOdGsBaseVectorizeView_16(IntPtr numContours);

	public delegate void SwigDelegateOdGsBaseVectorizeView_17(IntPtr numContours);

	public delegate void SwigDelegateOdGsBaseVectorizeView_18(IntPtr counts, IntPtr dcPts);

	public delegate void SwigDelegateOdGsBaseVectorizeView_19(IntPtr counts, IntPtr vertices);

	public delegate void SwigDelegateOdGsBaseVectorizeView_20(IntPtr pBoundary, IntPtr pClipInfo);

	public delegate void SwigDelegateOdGsBaseVectorizeView_21(IntPtr pBoundary);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_22(IntPtr ppClipInfo);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_23();

	public delegate void SwigDelegateOdGsBaseVectorizeView_24(uint color, int width);

	public delegate void SwigDelegateOdGsBaseVectorizeView_25(uint color, int width);

	public delegate void SwigDelegateOdGsBaseVectorizeView_26(bool visible);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_27();

	public delegate void SwigDelegateOdGsBaseVectorizeView_28(IntPtr position, IntPtr target, IntPtr upVector, double fieldWidth, double fieldHeight, int projection);

	public delegate void SwigDelegateOdGsBaseVectorizeView_29(IntPtr position, IntPtr target, IntPtr upVector, double fieldWidth, double fieldHeight);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_30();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_31();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_32();

	public delegate double SwigDelegateOdGsBaseVectorizeView_33();

	public delegate void SwigDelegateOdGsBaseVectorizeView_34(double lensLength);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_35();

	public delegate double SwigDelegateOdGsBaseVectorizeView_36();

	public delegate double SwigDelegateOdGsBaseVectorizeView_37();

	public delegate void SwigDelegateOdGsBaseVectorizeView_38(bool enable);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_39();

	public delegate void SwigDelegateOdGsBaseVectorizeView_40(double distance);

	public delegate double SwigDelegateOdGsBaseVectorizeView_41();

	public delegate void SwigDelegateOdGsBaseVectorizeView_42(bool enable);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_43();

	public delegate void SwigDelegateOdGsBaseVectorizeView_44(double distance);

	public delegate double SwigDelegateOdGsBaseVectorizeView_45();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_46();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_47();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_48();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_49();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_50();

	public delegate void SwigDelegateOdGsBaseVectorizeView_51(int mode);

	public delegate int SwigDelegateOdGsBaseVectorizeView_52();

	public delegate bool SwigDelegateOdGsBaseVectorizeView_53(IntPtr sceneGraph, IntPtr model);

	public delegate int SwigDelegateOdGsBaseVectorizeView_54();

	public delegate bool SwigDelegateOdGsBaseVectorizeView_55(IntPtr sceneGraph);

	public delegate void SwigDelegateOdGsBaseVectorizeView_56();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_57(IntPtr pDrawable);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_58();

	public delegate void SwigDelegateOdGsBaseVectorizeView_59();

	public delegate void SwigDelegateOdGsBaseVectorizeView_60(IntPtr rect);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_61();

	public delegate void SwigDelegateOdGsBaseVectorizeView_62();

	public delegate void SwigDelegateOdGsBaseVectorizeView_63(double frameRateInHz);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_64();

	public delegate double SwigDelegateOdGsBaseVectorizeView_65();

	public delegate void SwigDelegateOdGsBaseVectorizeView_66();

	public delegate void SwigDelegateOdGsBaseVectorizeView_67();

	public delegate void SwigDelegateOdGsBaseVectorizeView_68();

	public delegate void SwigDelegateOdGsBaseVectorizeView_69();

	public delegate bool SwigDelegateOdGsBaseVectorizeView_70();

	public delegate void SwigDelegateOdGsBaseVectorizeView_71(IntPtr layerID);

	public delegate void SwigDelegateOdGsBaseVectorizeView_72(IntPtr layerID);

	public delegate void SwigDelegateOdGsBaseVectorizeView_73();

	public delegate void SwigDelegateOdGsBaseVectorizeView_74();

	public delegate void SwigDelegateOdGsBaseVectorizeView_75(IntPtr points, IntPtr pReactor, int mode);

	public delegate void SwigDelegateOdGsBaseVectorizeView_76(IntPtr dollyVector);

	public delegate void SwigDelegateOdGsBaseVectorizeView_77(double xDolly, double yDolly, double zDolly);

	public delegate void SwigDelegateOdGsBaseVectorizeView_78(double rollAngle);

	public delegate void SwigDelegateOdGsBaseVectorizeView_79(double xOrbit, double yOrbit);

	public delegate void SwigDelegateOdGsBaseVectorizeView_80(double zoomFactor);

	public delegate void SwigDelegateOdGsBaseVectorizeView_81(double xPan, double yPan);

	public delegate void SwigDelegateOdGsBaseVectorizeView_82(IntPtr minPt, IntPtr maxPt);

	public delegate void SwigDelegateOdGsBaseVectorizeView_83(IntPtr lowerLeft, IntPtr upperRight);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_84(IntPtr pt);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_85(IntPtr minPt, IntPtr maxPt);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_86(bool cloneViewParameters, bool cloneGeometry);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_87(bool cloneViewParameters);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_88();

	public delegate void SwigDelegateOdGsBaseVectorizeView_89(IntPtr pView);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_90();

	public delegate void SwigDelegateOdGsBaseVectorizeView_91(bool enabled);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_92();

	public delegate void SwigDelegateOdGsBaseVectorizeView_93(double magnitude, double parallax);

	public delegate void SwigDelegateOdGsBaseVectorizeView_94(double magnitude, double parallax);

	public delegate void SwigDelegateOdGsBaseVectorizeView_95(IntPtr pLightsIterator);

	public delegate void SwigDelegateOdGsBaseVectorizeView_96(double linetypeScaleMultiplier);

	public delegate double SwigDelegateOdGsBaseVectorizeView_97();

	public delegate void SwigDelegateOdGsBaseVectorizeView_98(double linetypeAlternateScaleMultiplier);

	public delegate double SwigDelegateOdGsBaseVectorizeView_99();

	public delegate void SwigDelegateOdGsBaseVectorizeView_100(int color);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_101(IntPtr screenPoint);

	public delegate void SwigDelegateOdGsBaseVectorizeView_102(IntPtr givenWorldpt, IntPtr pixelArea, bool includePerspective);

	public delegate void SwigDelegateOdGsBaseVectorizeView_103(IntPtr givenWorldpt, IntPtr pixelArea);

	public delegate void SwigDelegateOdGsBaseVectorizeView_104(IntPtr backgroundId);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_105();

	public delegate void SwigDelegateOdGsBaseVectorizeView_106(IntPtr visualStyleId);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_107();

	public delegate void SwigDelegateOdGsBaseVectorizeView_108(IntPtr visualStyle);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_109(IntPtr vs);

	public delegate void SwigDelegateOdGsBaseVectorizeView_110(bool bEnable, int lightType);

	public delegate void SwigDelegateOdGsBaseVectorizeView_111(bool bEnable);

	public delegate void SwigDelegateOdGsBaseVectorizeView_112(IntPtr pImage, IntPtr region);

	public delegate void SwigDelegateOdGsBaseVectorizeView_113(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize, IntPtr pCtx);

	public delegate void SwigDelegateOdGsBaseVectorizeView_114(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize);

	public delegate void SwigDelegateOdGsBaseVectorizeView_115(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList);

	public delegate void SwigDelegateOdGsBaseVectorizeView_116(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor);

	public delegate void SwigDelegateOdGsBaseVectorizeView_117(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList, uint nObjectListSize);

	public delegate void SwigDelegateOdGsBaseVectorizeView_118(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList);

	public delegate void SwigDelegateOdGsBaseVectorizeView_119(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor, bool bSortedSelection);

	public delegate void SwigDelegateOdGsBaseVectorizeView_120(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor);

	public delegate void SwigDelegateOdGsBaseVectorizeView_121(uint nMode);

	public delegate uint SwigDelegateOdGsBaseVectorizeView_122();

	public delegate void SwigDelegateOdGsBaseVectorizeView_123(bool bEnable);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_124();

	public delegate void SwigDelegateOdGsBaseVectorizeView_125(bool bEnable);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_126();

	public delegate void SwigDelegateOdGsBaseVectorizeView_127(IntPtr pDevice, IntPtr pViewInfo, bool enableLayerVisibilityPerView);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_128(IntPtr extents);

	public delegate void SwigDelegateOdGsBaseVectorizeView_129(IntPtr aPtDc, IntPtr pReactor, int mode);

	public delegate void SwigDelegateOdGsBaseVectorizeView_130();

	public delegate bool SwigDelegateOdGsBaseVectorizeView_131();

	public delegate bool SwigDelegateOdGsBaseVectorizeView_132();

	public delegate void SwigDelegateOdGsBaseVectorizeView_133(bool bSet);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_134();

	public delegate bool SwigDelegateOdGsBaseVectorizeView_135();

	public delegate void SwigDelegateOdGsBaseVectorizeView_136(bool bSet);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_137();

	public delegate void SwigDelegateOdGsBaseVectorizeView_138(bool bSet);

	public delegate void SwigDelegateOdGsBaseVectorizeView_139(IntPtr worldExt, IntPtr pModel, int extendByLineweight);

	public delegate void SwigDelegateOdGsBaseVectorizeView_140(IntPtr worldExt, IntPtr pModel);

	public delegate int SwigDelegateOdGsBaseVectorizeView_141();

	public delegate double SwigDelegateOdGsBaseVectorizeView_142(int deviationType, IntPtr pointOnCurve, bool bRecalculate);

	public delegate double SwigDelegateOdGsBaseVectorizeView_143(int deviationType, IntPtr pointOnCurve);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_144(IntPtr pView);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_145();

	public delegate void SwigDelegateOdGsBaseVectorizeView_146(IntPtr pModel);

	public delegate void SwigDelegateOdGsBaseVectorizeView_147(IntPtr pModel);

	public delegate int SwigDelegateOdGsBaseVectorizeView_148();

	public delegate void SwigDelegateOdGsBaseVectorizeView_149();

	public delegate bool SwigDelegateOdGsBaseVectorizeView_150();

	public delegate void SwigDelegateOdGsBaseVectorizeView_151(IntPtr xfm);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_152(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_153(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_154(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_155(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseVectorizeView_156();

	public delegate void SwigDelegateOdGsBaseVectorizeView_157(bool bSet);

	public delegate uint SwigDelegateOdGsBaseVectorizeView_158();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizeView_159(bool bDisplay);

	public delegate void SwigDelegateOdGsBaseVectorizeView_160(IntPtr pVect);

	public delegate void SwigDelegateOdGsBaseVectorizeView_161();

	public delegate void SwigDelegateOdGsBaseVectorizeView_162();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsBaseVectorizeView_0 swigDelegate0;

	private SwigDelegateOdGsBaseVectorizeView_1 swigDelegate1;

	private SwigDelegateOdGsBaseVectorizeView_2 swigDelegate2;

	private SwigDelegateOdGsBaseVectorizeView_3 swigDelegate3;

	private SwigDelegateOdGsBaseVectorizeView_4 swigDelegate4;

	private SwigDelegateOdGsBaseVectorizeView_5 swigDelegate5;

	private SwigDelegateOdGsBaseVectorizeView_6 swigDelegate6;

	private SwigDelegateOdGsBaseVectorizeView_7 swigDelegate7;

	private SwigDelegateOdGsBaseVectorizeView_8 swigDelegate8;

	private SwigDelegateOdGsBaseVectorizeView_9 swigDelegate9;

	private SwigDelegateOdGsBaseVectorizeView_10 swigDelegate10;

	private SwigDelegateOdGsBaseVectorizeView_11 swigDelegate11;

	private SwigDelegateOdGsBaseVectorizeView_12 swigDelegate12;

	private SwigDelegateOdGsBaseVectorizeView_13 swigDelegate13;

	private SwigDelegateOdGsBaseVectorizeView_14 swigDelegate14;

	private SwigDelegateOdGsBaseVectorizeView_15 swigDelegate15;

	private SwigDelegateOdGsBaseVectorizeView_16 swigDelegate16;

	private SwigDelegateOdGsBaseVectorizeView_17 swigDelegate17;

	private SwigDelegateOdGsBaseVectorizeView_18 swigDelegate18;

	private SwigDelegateOdGsBaseVectorizeView_19 swigDelegate19;

	private SwigDelegateOdGsBaseVectorizeView_20 swigDelegate20;

	private SwigDelegateOdGsBaseVectorizeView_21 swigDelegate21;

	private SwigDelegateOdGsBaseVectorizeView_22 swigDelegate22;

	private SwigDelegateOdGsBaseVectorizeView_23 swigDelegate23;

	private SwigDelegateOdGsBaseVectorizeView_24 swigDelegate24;

	private SwigDelegateOdGsBaseVectorizeView_25 swigDelegate25;

	private SwigDelegateOdGsBaseVectorizeView_26 swigDelegate26;

	private SwigDelegateOdGsBaseVectorizeView_27 swigDelegate27;

	private SwigDelegateOdGsBaseVectorizeView_28 swigDelegate28;

	private SwigDelegateOdGsBaseVectorizeView_29 swigDelegate29;

	private SwigDelegateOdGsBaseVectorizeView_30 swigDelegate30;

	private SwigDelegateOdGsBaseVectorizeView_31 swigDelegate31;

	private SwigDelegateOdGsBaseVectorizeView_32 swigDelegate32;

	private SwigDelegateOdGsBaseVectorizeView_33 swigDelegate33;

	private SwigDelegateOdGsBaseVectorizeView_34 swigDelegate34;

	private SwigDelegateOdGsBaseVectorizeView_35 swigDelegate35;

	private SwigDelegateOdGsBaseVectorizeView_36 swigDelegate36;

	private SwigDelegateOdGsBaseVectorizeView_37 swigDelegate37;

	private SwigDelegateOdGsBaseVectorizeView_38 swigDelegate38;

	private SwigDelegateOdGsBaseVectorizeView_39 swigDelegate39;

	private SwigDelegateOdGsBaseVectorizeView_40 swigDelegate40;

	private SwigDelegateOdGsBaseVectorizeView_41 swigDelegate41;

	private SwigDelegateOdGsBaseVectorizeView_42 swigDelegate42;

	private SwigDelegateOdGsBaseVectorizeView_43 swigDelegate43;

	private SwigDelegateOdGsBaseVectorizeView_44 swigDelegate44;

	private SwigDelegateOdGsBaseVectorizeView_45 swigDelegate45;

	private SwigDelegateOdGsBaseVectorizeView_46 swigDelegate46;

	private SwigDelegateOdGsBaseVectorizeView_47 swigDelegate47;

	private SwigDelegateOdGsBaseVectorizeView_48 swigDelegate48;

	private SwigDelegateOdGsBaseVectorizeView_49 swigDelegate49;

	private SwigDelegateOdGsBaseVectorizeView_50 swigDelegate50;

	private SwigDelegateOdGsBaseVectorizeView_51 swigDelegate51;

	private SwigDelegateOdGsBaseVectorizeView_52 swigDelegate52;

	private SwigDelegateOdGsBaseVectorizeView_53 swigDelegate53;

	private SwigDelegateOdGsBaseVectorizeView_54 swigDelegate54;

	private SwigDelegateOdGsBaseVectorizeView_55 swigDelegate55;

	private SwigDelegateOdGsBaseVectorizeView_56 swigDelegate56;

	private SwigDelegateOdGsBaseVectorizeView_57 swigDelegate57;

	private SwigDelegateOdGsBaseVectorizeView_58 swigDelegate58;

	private SwigDelegateOdGsBaseVectorizeView_59 swigDelegate59;

	private SwigDelegateOdGsBaseVectorizeView_60 swigDelegate60;

	private SwigDelegateOdGsBaseVectorizeView_61 swigDelegate61;

	private SwigDelegateOdGsBaseVectorizeView_62 swigDelegate62;

	private SwigDelegateOdGsBaseVectorizeView_63 swigDelegate63;

	private SwigDelegateOdGsBaseVectorizeView_64 swigDelegate64;

	private SwigDelegateOdGsBaseVectorizeView_65 swigDelegate65;

	private SwigDelegateOdGsBaseVectorizeView_66 swigDelegate66;

	private SwigDelegateOdGsBaseVectorizeView_67 swigDelegate67;

	private SwigDelegateOdGsBaseVectorizeView_68 swigDelegate68;

	private SwigDelegateOdGsBaseVectorizeView_69 swigDelegate69;

	private SwigDelegateOdGsBaseVectorizeView_70 swigDelegate70;

	private SwigDelegateOdGsBaseVectorizeView_71 swigDelegate71;

	private SwigDelegateOdGsBaseVectorizeView_72 swigDelegate72;

	private SwigDelegateOdGsBaseVectorizeView_73 swigDelegate73;

	private SwigDelegateOdGsBaseVectorizeView_74 swigDelegate74;

	private SwigDelegateOdGsBaseVectorizeView_75 swigDelegate75;

	private SwigDelegateOdGsBaseVectorizeView_76 swigDelegate76;

	private SwigDelegateOdGsBaseVectorizeView_77 swigDelegate77;

	private SwigDelegateOdGsBaseVectorizeView_78 swigDelegate78;

	private SwigDelegateOdGsBaseVectorizeView_79 swigDelegate79;

	private SwigDelegateOdGsBaseVectorizeView_80 swigDelegate80;

	private SwigDelegateOdGsBaseVectorizeView_81 swigDelegate81;

	private SwigDelegateOdGsBaseVectorizeView_82 swigDelegate82;

	private SwigDelegateOdGsBaseVectorizeView_83 swigDelegate83;

	private SwigDelegateOdGsBaseVectorizeView_84 swigDelegate84;

	private SwigDelegateOdGsBaseVectorizeView_85 swigDelegate85;

	private SwigDelegateOdGsBaseVectorizeView_86 swigDelegate86;

	private SwigDelegateOdGsBaseVectorizeView_87 swigDelegate87;

	private SwigDelegateOdGsBaseVectorizeView_88 swigDelegate88;

	private SwigDelegateOdGsBaseVectorizeView_89 swigDelegate89;

	private SwigDelegateOdGsBaseVectorizeView_90 swigDelegate90;

	private SwigDelegateOdGsBaseVectorizeView_91 swigDelegate91;

	private SwigDelegateOdGsBaseVectorizeView_92 swigDelegate92;

	private SwigDelegateOdGsBaseVectorizeView_93 swigDelegate93;

	private SwigDelegateOdGsBaseVectorizeView_94 swigDelegate94;

	private SwigDelegateOdGsBaseVectorizeView_95 swigDelegate95;

	private SwigDelegateOdGsBaseVectorizeView_96 swigDelegate96;

	private SwigDelegateOdGsBaseVectorizeView_97 swigDelegate97;

	private SwigDelegateOdGsBaseVectorizeView_98 swigDelegate98;

	private SwigDelegateOdGsBaseVectorizeView_99 swigDelegate99;

	private SwigDelegateOdGsBaseVectorizeView_100 swigDelegate100;

	private SwigDelegateOdGsBaseVectorizeView_101 swigDelegate101;

	private SwigDelegateOdGsBaseVectorizeView_102 swigDelegate102;

	private SwigDelegateOdGsBaseVectorizeView_103 swigDelegate103;

	private SwigDelegateOdGsBaseVectorizeView_104 swigDelegate104;

	private SwigDelegateOdGsBaseVectorizeView_105 swigDelegate105;

	private SwigDelegateOdGsBaseVectorizeView_106 swigDelegate106;

	private SwigDelegateOdGsBaseVectorizeView_107 swigDelegate107;

	private SwigDelegateOdGsBaseVectorizeView_108 swigDelegate108;

	private SwigDelegateOdGsBaseVectorizeView_109 swigDelegate109;

	private SwigDelegateOdGsBaseVectorizeView_110 swigDelegate110;

	private SwigDelegateOdGsBaseVectorizeView_111 swigDelegate111;

	private SwigDelegateOdGsBaseVectorizeView_112 swigDelegate112;

	private SwigDelegateOdGsBaseVectorizeView_113 swigDelegate113;

	private SwigDelegateOdGsBaseVectorizeView_114 swigDelegate114;

	private SwigDelegateOdGsBaseVectorizeView_115 swigDelegate115;

	private SwigDelegateOdGsBaseVectorizeView_116 swigDelegate116;

	private SwigDelegateOdGsBaseVectorizeView_117 swigDelegate117;

	private SwigDelegateOdGsBaseVectorizeView_118 swigDelegate118;

	private SwigDelegateOdGsBaseVectorizeView_119 swigDelegate119;

	private SwigDelegateOdGsBaseVectorizeView_120 swigDelegate120;

	private SwigDelegateOdGsBaseVectorizeView_121 swigDelegate121;

	private SwigDelegateOdGsBaseVectorizeView_122 swigDelegate122;

	private SwigDelegateOdGsBaseVectorizeView_123 swigDelegate123;

	private SwigDelegateOdGsBaseVectorizeView_124 swigDelegate124;

	private SwigDelegateOdGsBaseVectorizeView_125 swigDelegate125;

	private SwigDelegateOdGsBaseVectorizeView_126 swigDelegate126;

	private SwigDelegateOdGsBaseVectorizeView_127 swigDelegate127;

	private SwigDelegateOdGsBaseVectorizeView_128 swigDelegate128;

	private SwigDelegateOdGsBaseVectorizeView_129 swigDelegate129;

	private SwigDelegateOdGsBaseVectorizeView_130 swigDelegate130;

	private SwigDelegateOdGsBaseVectorizeView_131 swigDelegate131;

	private SwigDelegateOdGsBaseVectorizeView_132 swigDelegate132;

	private SwigDelegateOdGsBaseVectorizeView_133 swigDelegate133;

	private SwigDelegateOdGsBaseVectorizeView_134 swigDelegate134;

	private SwigDelegateOdGsBaseVectorizeView_135 swigDelegate135;

	private SwigDelegateOdGsBaseVectorizeView_136 swigDelegate136;

	private SwigDelegateOdGsBaseVectorizeView_137 swigDelegate137;

	private SwigDelegateOdGsBaseVectorizeView_138 swigDelegate138;

	private SwigDelegateOdGsBaseVectorizeView_139 swigDelegate139;

	private SwigDelegateOdGsBaseVectorizeView_140 swigDelegate140;

	private SwigDelegateOdGsBaseVectorizeView_141 swigDelegate141;

	private SwigDelegateOdGsBaseVectorizeView_142 swigDelegate142;

	private SwigDelegateOdGsBaseVectorizeView_143 swigDelegate143;

	private SwigDelegateOdGsBaseVectorizeView_144 swigDelegate144;

	private SwigDelegateOdGsBaseVectorizeView_145 swigDelegate145;

	private SwigDelegateOdGsBaseVectorizeView_146 swigDelegate146;

	private SwigDelegateOdGsBaseVectorizeView_147 swigDelegate147;

	private SwigDelegateOdGsBaseVectorizeView_148 swigDelegate148;

	private SwigDelegateOdGsBaseVectorizeView_149 swigDelegate149;

	private SwigDelegateOdGsBaseVectorizeView_150 swigDelegate150;

	private SwigDelegateOdGsBaseVectorizeView_151 swigDelegate151;

	private SwigDelegateOdGsBaseVectorizeView_152 swigDelegate152;

	private SwigDelegateOdGsBaseVectorizeView_153 swigDelegate153;

	private SwigDelegateOdGsBaseVectorizeView_154 swigDelegate154;

	private SwigDelegateOdGsBaseVectorizeView_155 swigDelegate155;

	private SwigDelegateOdGsBaseVectorizeView_156 swigDelegate156;

	private SwigDelegateOdGsBaseVectorizeView_157 swigDelegate157;

	private SwigDelegateOdGsBaseVectorizeView_158 swigDelegate158;

	private SwigDelegateOdGsBaseVectorizeView_159 swigDelegate159;

	private SwigDelegateOdGsBaseVectorizeView_160 swigDelegate160;

	private SwigDelegateOdGsBaseVectorizeView_161 swigDelegate161;

	private SwigDelegateOdGsBaseVectorizeView_162 swigDelegate162;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGiContext) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(byte[]),
		typeof(ushort)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(byte[]) };

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdGePoint2d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdGsDCRectDouble) };

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdGePoint2d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdGsDCRectDouble) };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdGsDCPointArray[]) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGePoint2dArray[]) };

	private static Type[] swigMethodTypes18 = new Type[2]
	{
		typeof(OdIntArray),
		typeof(OdGsDCPointArray)
	};

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(OdIntArray),
		typeof(OdGePoint2dArray)
	};

	private static Type[] swigMethodTypes20 = new Type[2]
	{
		typeof(OdGiClipBoundary),
		typeof(OdGiAbstractClipBoundary)
	};

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGiClipBoundary) };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdGiAbstractClipBoundary) };

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[2]
	{
		typeof(uint),
		typeof(int)
	};

	private static Type[] swigMethodTypes25 = new Type[2]
	{
		typeof(uint).MakeByRefType(),
		typeof(int).MakeByRefType()
	};

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double),
		typeof(OdGsView_Projection)
	};

	private static Type[] swigMethodTypes29 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes30 = new Type[0];

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[0];

	private static Type[] swigMethodTypes34 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes35 = new Type[0];

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[0];

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes39 = new Type[0];

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[0];

	private static Type[] swigMethodTypes47 = new Type[0];

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[0];

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdGsView_RenderMode) };

	private static Type[] swigMethodTypes52 = new Type[0];

	private static Type[] swigMethodTypes53 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGsModel)
	};

	private static Type[] swigMethodTypes54 = new Type[0];

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes56 = new Type[0];

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes58 = new Type[0];

	private static Type[] swigMethodTypes59 = new Type[0];

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes61 = new Type[0];

	private static Type[] swigMethodTypes62 = new Type[0];

	private static Type[] swigMethodTypes63 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes64 = new Type[0];

	private static Type[] swigMethodTypes65 = new Type[0];

	private static Type[] swigMethodTypes66 = new Type[0];

	private static Type[] swigMethodTypes67 = new Type[0];

	private static Type[] swigMethodTypes68 = new Type[0];

	private static Type[] swigMethodTypes69 = new Type[0];

	private static Type[] swigMethodTypes70 = new Type[0];

	private static Type[] swigMethodTypes71 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes72 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes73 = new Type[0];

	private static Type[] swigMethodTypes74 = new Type[0];

	private static Type[] swigMethodTypes75 = new Type[3]
	{
		typeof(OdGsDCPoint[]),
		typeof(OdGsSelectionReactor),
		typeof(OdGsView_SelectionMode)
	};

	private static Type[] swigMethodTypes76 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes77 = new Type[3]
	{
		typeof(double),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes78 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes79 = new Type[2]
	{
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes80 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes81 = new Type[2]
	{
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes82 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes83 = new Type[2]
	{
		typeof(OdGePoint2d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes84 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes85 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes86 = new Type[2]
	{
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes87 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes88 = new Type[0];

	private static Type[] swigMethodTypes89 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes90 = new Type[0];

	private static Type[] swigMethodTypes91 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes92 = new Type[0];

	private static Type[] swigMethodTypes93 = new Type[2]
	{
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes94 = new Type[2]
	{
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes95 = new Type[1] { typeof(OdRxIterator) };

	private static Type[] swigMethodTypes96 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes97 = new Type[0];

	private static Type[] swigMethodTypes98 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes99 = new Type[0];

	private static Type[] swigMethodTypes100 = new Type[1] { typeof(OdGsView_ClearColor) };

	private static Type[] swigMethodTypes101 = new Type[1] { typeof(OdGePoint2d) };

	private static Type[] swigMethodTypes102 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint2d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes103 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes104 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes105 = new Type[0];

	private static Type[] swigMethodTypes106 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes107 = new Type[0];

	private static Type[] swigMethodTypes108 = new Type[1] { typeof(OdGiVisualStyle) };

	private static Type[] swigMethodTypes109 = new Type[1] { typeof(OdGiVisualStyle).MakeByRefType() };

	private static Type[] swigMethodTypes110 = new Type[2]
	{
		typeof(bool),
		typeof(OdGsView_DefaultLightingType)
	};

	private static Type[] swigMethodTypes111 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes112 = new Type[2]
	{
		typeof(OdGiRasterImage).MakeByRefType(),
		typeof(OdGsDCRect)
	};

	private static Type[] swigMethodTypes113 = new Type[6]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionContext)
	};

	private static Type[] swigMethodTypes114 = new Type[5]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGiPathNode[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes115 = new Type[4]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGiPathNode[])
	};

	private static Type[] swigMethodTypes116 = new Type[3]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor)
	};

	private static Type[] swigMethodTypes117 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGsRayTraceReactor),
		typeof(bool),
		typeof(OdGiPathNode[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes118 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGsRayTraceReactor),
		typeof(bool),
		typeof(OdGiPathNode[])
	};

	private static Type[] swigMethodTypes119 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGsRayTraceReactor),
		typeof(bool)
	};

	private static Type[] swigMethodTypes120 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGsRayTraceReactor)
	};

	private static Type[] swigMethodTypes121 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes122 = new Type[0];

	private static Type[] swigMethodTypes123 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes124 = new Type[0];

	private static Type[] swigMethodTypes125 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes126 = new Type[0];

	private static Type[] swigMethodTypes127 = new Type[3]
	{
		typeof(OdGsBaseVectorizeDevice),
		typeof(OdGsClientViewInfo),
		typeof(bool)
	};

	private static Type[] swigMethodTypes128 = new Type[1] { typeof(OdGeBoundBlock3d) };

	private static Type[] swigMethodTypes129 = new Type[3]
	{
		typeof(OdGePoint2d[]),
		typeof(OdGsSelectionReactor),
		typeof(OdGsView_SelectionMode)
	};

	private static Type[] swigMethodTypes130 = new Type[0];

	private static Type[] swigMethodTypes131 = new Type[0];

	private static Type[] swigMethodTypes132 = new Type[0];

	private static Type[] swigMethodTypes133 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes134 = new Type[0];

	private static Type[] swigMethodTypes135 = new Type[0];

	private static Type[] swigMethodTypes136 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes137 = new Type[0];

	private static Type[] swigMethodTypes138 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes139 = new Type[3]
	{
		typeof(OdGeExtents3d),
		typeof(OdGsBaseModel),
		typeof(LineWeight)
	};

	private static Type[] swigMethodTypes140 = new Type[2]
	{
		typeof(OdGeExtents3d),
		typeof(OdGsBaseModel)
	};

	private static Type[] swigMethodTypes141 = new Type[0];

	private static Type[] swigMethodTypes142 = new Type[3]
	{
		typeof(OdGiDeviationType),
		typeof(OdGePoint3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes143 = new Type[2]
	{
		typeof(OdGiDeviationType),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes144 = new Type[1] { typeof(OdGsViewImpl) };

	private static Type[] swigMethodTypes145 = new Type[0];

	private static Type[] swigMethodTypes146 = new Type[1] { typeof(OdGsModel) };

	private static Type[] swigMethodTypes147 = new Type[1] { typeof(OdGsModel) };

	private static Type[] swigMethodTypes148 = new Type[0];

	private static Type[] swigMethodTypes149 = new Type[0];

	private static Type[] swigMethodTypes150 = new Type[0];

	private static Type[] swigMethodTypes151 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes152 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes153 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes154 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes155 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes156 = new Type[0];

	private static Type[] swigMethodTypes157 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes158 = new Type[0];

	private static Type[] swigMethodTypes159 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes160 = new Type[1] { typeof(OdGsBaseVectorizer) };

	private static Type[] swigMethodTypes161 = new Type[0];

	private static Type[] swigMethodTypes162 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBaseVectorizeView(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBaseVectorizeView obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseVectorizeView(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGsBaseVectorizeView()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBaseVectorizeView(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdGsBaseVectorizeView safeCast(OdGsView pView)
	{
		OdGsBaseVectorizeView rXObject = Helpers.GetRXObject<OdGsBaseVectorizeView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_safeCast(OdGsView.getCPtr(pView)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGiContext userGiContext()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(SwigDerivedClassHasMethod("userGiContext", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_userGiContextSwigExplicitOdGsBaseVectorizeView(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_userGiContext(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void setUserGiContext(OdGiContext pUserGiContext)
	{
		if (SwigDerivedClassHasMethod("setUserGiContext", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_setUserGiContextSwigExplicitOdGsBaseVectorizeView(swigCPtr, OdGiContext.getCPtr(pUserGiContext));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_setUserGiContext(swigCPtr, OdGiContext.getCPtr(pUserGiContext));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void update()
	{
		if (SwigDerivedClassHasMethod("update", swigMethodTypes62))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_updateSwigExplicitOdGsBaseVectorizeView(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_update(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void select(OdGePoint2d[] aPtDc, OdGsSelectionReactor pReactor, OdGsView_SelectionMode mode)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(aPtDc);
		try
		{
			if (SwigDerivedClassHasMethod("select", swigMethodTypes129))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_selectSwigExplicitOdGsBaseVectorizeView(swigCPtr, intPtr, OdGsSelectionReactor.getCPtr(pReactor), (int)mode);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_select(swigCPtr, intPtr, OdGsSelectionReactor.getCPtr(pReactor), (int)mode);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public override bool viewExtents(OdGeBoundBlock3d extents)
	{
		bool result = (SwigDerivedClassHasMethod("viewExtents", swigMethodTypes128) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_viewExtentsSwigExplicitOdGsBaseVectorizeView(swigCPtr, OdGeBoundBlock3d.getCPtr(extents)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_viewExtents(swigCPtr, OdGeBoundBlock3d.getCPtr(extents)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void collide(OdGiPathNode[] pInputList, uint nInputListSize, OdGsCollisionDetectionReactor pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize, OdGsCollisionDetectionContext pCtx)
	{
		if (SwigDerivedClassHasMethod("collide", swigMethodTypes113))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_collideSwigExplicitOdGsBaseVectorizeView__SWIG_0(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList, nCollisionWithListSize, OdGsCollisionDetectionContext.getCPtr(pCtx));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_collide__SWIG_0(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList, nCollisionWithListSize, OdGsCollisionDetectionContext.getCPtr(pCtx));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void collide(OdGiPathNode[] pInputList, uint nInputListSize, OdGsCollisionDetectionReactor pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize)
	{
		if (SwigDerivedClassHasMethod("collide", swigMethodTypes114))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_collideSwigExplicitOdGsBaseVectorizeView__SWIG_1(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList, nCollisionWithListSize);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_collide__SWIG_1(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList, nCollisionWithListSize);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void collide(OdGiPathNode[] pInputList, uint nInputListSize, OdGsCollisionDetectionReactor pReactor, OdGiPathNode[] pCollisionWithList)
	{
		if (SwigDerivedClassHasMethod("collide", swigMethodTypes115))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_collideSwigExplicitOdGsBaseVectorizeView__SWIG_2(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_collide__SWIG_2(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void collide(OdGiPathNode[] pInputList, uint nInputListSize, OdGsCollisionDetectionReactor pReactor)
	{
		if (SwigDerivedClassHasMethod("collide", swigMethodTypes116))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_collideSwigExplicitOdGsBaseVectorizeView__SWIG_3(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_collide__SWIG_3(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void rayTrace(OdGePoint3d rayOrigin, OdGeVector3d rayDirection, OdGsRayTraceReactor pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList, uint nObjectListSize)
	{
		if (SwigDerivedClassHasMethod("rayTrace", swigMethodTypes117))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_rayTraceSwigExplicitOdGsBaseVectorizeView__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor), bSortedSelection, pObjectList, nObjectListSize);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_rayTrace__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor), bSortedSelection, pObjectList, nObjectListSize);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void rayTrace(OdGePoint3d rayOrigin, OdGeVector3d rayDirection, OdGsRayTraceReactor pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList)
	{
		if (SwigDerivedClassHasMethod("rayTrace", swigMethodTypes118))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_rayTraceSwigExplicitOdGsBaseVectorizeView__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor), bSortedSelection, pObjectList);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_rayTrace__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor), bSortedSelection, pObjectList);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void rayTrace(OdGePoint3d rayOrigin, OdGeVector3d rayDirection, OdGsRayTraceReactor pReactor, bool bSortedSelection)
	{
		if (SwigDerivedClassHasMethod("rayTrace", swigMethodTypes119))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_rayTraceSwigExplicitOdGsBaseVectorizeView__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor), bSortedSelection);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_rayTrace__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor), bSortedSelection);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void rayTrace(OdGePoint3d rayOrigin, OdGeVector3d rayDirection, OdGsRayTraceReactor pReactor)
	{
		if (SwigDerivedClassHasMethod("rayTrace", swigMethodTypes120))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_rayTraceSwigExplicitOdGsBaseVectorizeView__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_rayTrace__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint numVectorizers()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_numVectorizers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual OdGsBaseVectorizer getVectorizer(bool bDisplay)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_getVectorizer(swigCPtr, bDisplay);
		OdGsBaseVectorizer result = ((intPtr == IntPtr.Zero) ? null : new OdGsBaseVectorizer(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual void releaseVectorizer(OdGsBaseVectorizer pVect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_releaseVectorizer(swigCPtr, OdGsBaseVectorizer.getCPtr(pVect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void updateGeometry()
	{
		if (SwigDerivedClassHasMethod("updateGeometry", swigMethodTypes161))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_updateGeometrySwigExplicitOdGsBaseVectorizeView(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_updateGeometry(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void updateScreen()
	{
		if (SwigDerivedClassHasMethod("updateScreen", swigMethodTypes162))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_updateScreenSwigExplicitOdGsBaseVectorizeView(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_updateScreen(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool SceneDept(out double zNear, out double zFar, OdGsOverlayId nOverlay)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_SceneDept__SWIG_0(swigCPtr, out zNear, out zFar, (int)nOverlay);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool SceneDept(out double zNear, out double zFar)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_SceneDept__SWIG_1(swigCPtr, out zNear, out zFar);
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
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("device", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddevice;
		}
		if (SwigDerivedClassHasMethod("userGiContext", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoduserGiContext;
		}
		if (SwigDerivedClassHasMethod("setUserGiContext", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetUserGiContext;
		}
		if (SwigDerivedClassHasMethod("lineweightToDcScale", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodlineweightToDcScale;
		}
		if (SwigDerivedClassHasMethod("setLineweightToDcScale", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetLineweightToDcScale;
		}
		if (SwigDerivedClassHasMethod("setLineweightEnum", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetLineweightEnum;
		}
		if (SwigDerivedClassHasMethod("setLineweightEnum", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetLineweightEnum__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setViewport", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetViewport__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setViewport", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetViewport__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setViewport", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetViewport__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getViewport", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetViewport__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getViewport", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetViewport__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getViewport", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetViewport__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setViewportClipRegion", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetViewportClipRegion__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setViewportClipRegion", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetViewportClipRegion__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("viewportClipRegion", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodviewportClipRegion__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("viewportClipRegion", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodviewportClipRegion__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setViewport3dClipping", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsetViewport3dClipping__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setViewport3dClipping", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetViewport3dClipping__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("viewport3dClipping", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodviewport3dClipping__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("viewport3dClipping", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodviewport3dClipping__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setViewportBorderProperties", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsetViewportBorderProperties;
		}
		if (SwigDerivedClassHasMethod("getViewportBorderProperties", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodgetViewportBorderProperties;
		}
		if (SwigDerivedClassHasMethod("setViewportBorderVisibility", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodsetViewportBorderVisibility;
		}
		if (SwigDerivedClassHasMethod("isViewportBorderVisible", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodisViewportBorderVisible;
		}
		if (SwigDerivedClassHasMethod("setView", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodsetView__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setView", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodsetView__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("position", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodposition;
		}
		if (SwigDerivedClassHasMethod("target", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodtarget;
		}
		if (SwigDerivedClassHasMethod("upVector", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodupVector;
		}
		if (SwigDerivedClassHasMethod("lensLength", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodlensLength;
		}
		if (SwigDerivedClassHasMethod("setLensLength", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodsetLensLength;
		}
		if (SwigDerivedClassHasMethod("isPerspective", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodisPerspective;
		}
		if (SwigDerivedClassHasMethod("fieldWidth", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodfieldWidth;
		}
		if (SwigDerivedClassHasMethod("fieldHeight", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodfieldHeight;
		}
		if (SwigDerivedClassHasMethod("setEnableFrontClip", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodsetEnableFrontClip;
		}
		if (SwigDerivedClassHasMethod("isFrontClipped", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodisFrontClipped;
		}
		if (SwigDerivedClassHasMethod("setFrontClip", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodsetFrontClip;
		}
		if (SwigDerivedClassHasMethod("frontClip", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodfrontClip;
		}
		if (SwigDerivedClassHasMethod("setEnableBackClip", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodsetEnableBackClip;
		}
		if (SwigDerivedClassHasMethod("isBackClipped", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodisBackClipped;
		}
		if (SwigDerivedClassHasMethod("setBackClip", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodsetBackClip;
		}
		if (SwigDerivedClassHasMethod("backClip", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodbackClip;
		}
		if (SwigDerivedClassHasMethod("viewingMatrix", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodviewingMatrix;
		}
		if (SwigDerivedClassHasMethod("projectionMatrix", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodprojectionMatrix__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("screenMatrix", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodscreenMatrix;
		}
		if (SwigDerivedClassHasMethod("worldToDeviceMatrix", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodworldToDeviceMatrix__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("objectToDeviceMatrix", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodobjectToDeviceMatrix__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setMode", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodsetMode;
		}
		if (SwigDerivedClassHasMethod("mode", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodmode;
		}
		if (SwigDerivedClassHasMethod("add", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodadd;
		}
		if (SwigDerivedClassHasMethod("numRootDrawables", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodnumRootDrawables;
		}
		if (SwigDerivedClassHasMethod("erase", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethoderase;
		}
		if (SwigDerivedClassHasMethod("eraseAll", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethoderaseAll;
		}
		if (SwigDerivedClassHasMethod("getModel", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodgetModel;
		}
		if (SwigDerivedClassHasMethod("getModelList", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodgetModelList;
		}
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodinvalidate__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodinvalidate__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isValid", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodisValid;
		}
		if (SwigDerivedClassHasMethod("update", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodupdate;
		}
		if (SwigDerivedClassHasMethod("beginInteractivity", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodbeginInteractivity;
		}
		if (SwigDerivedClassHasMethod("isInInteractivity", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodisInInteractivity;
		}
		if (SwigDerivedClassHasMethod("interactivityFrameRate", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodinteractivityFrameRate;
		}
		if (SwigDerivedClassHasMethod("endInteractivity", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodendInteractivity;
		}
		if (SwigDerivedClassHasMethod("flush", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodflush;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodhide;
		}
		if (SwigDerivedClassHasMethod("show", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodshow;
		}
		if (SwigDerivedClassHasMethod("isVisible", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodisVisible;
		}
		if (SwigDerivedClassHasMethod("freezeLayer", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodfreezeLayer;
		}
		if (SwigDerivedClassHasMethod("thawLayer", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodthawLayer;
		}
		if (SwigDerivedClassHasMethod("clearFrozenLayers", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodclearFrozenLayers;
		}
		if (SwigDerivedClassHasMethod("invalidateCachedViewportGeometry", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodinvalidateCachedViewportGeometry__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("select", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodselect__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("dolly", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethoddolly__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("dolly", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethoddolly__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("roll", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodroll;
		}
		if (SwigDerivedClassHasMethod("orbit", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodorbit;
		}
		if (SwigDerivedClassHasMethod("zoom", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodzoom;
		}
		if (SwigDerivedClassHasMethod("pan", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodpan;
		}
		if (SwigDerivedClassHasMethod("zoomExtents", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodzoomExtents;
		}
		if (SwigDerivedClassHasMethod("zoomWindow", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodzoomWindow;
		}
		if (SwigDerivedClassHasMethod("pointInView", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodpointInView;
		}
		if (SwigDerivedClassHasMethod("extentsInView", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodextentsInView;
		}
		if (SwigDerivedClassHasMethod("cloneView", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodcloneView__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("cloneView", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodcloneView__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("cloneView", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodcloneView__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("viewParameters", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodviewParameters;
		}
		if (SwigDerivedClassHasMethod("exceededBounds", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodexceededBounds;
		}
		if (SwigDerivedClassHasMethod("enableStereo", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodenableStereo;
		}
		if (SwigDerivedClassHasMethod("isStereoEnabled", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodisStereoEnabled;
		}
		if (SwigDerivedClassHasMethod("setStereoParameters", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodsetStereoParameters;
		}
		if (SwigDerivedClassHasMethod("getStereoParameters", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodgetStereoParameters;
		}
		if (SwigDerivedClassHasMethod("initLights", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodinitLights;
		}
		if (SwigDerivedClassHasMethod("setLinetypeScaleMultiplier", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodsetLinetypeScaleMultiplier;
		}
		if (SwigDerivedClassHasMethod("linetypeScaleMultiplier", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodlinetypeScaleMultiplier;
		}
		if (SwigDerivedClassHasMethod("setAlternateLinetypeScaleMultiplier", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodsetAlternateLinetypeScaleMultiplier;
		}
		if (SwigDerivedClassHasMethod("linetypeAlternateScaleMultiplier", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethodlinetypeAlternateScaleMultiplier;
		}
		if (SwigDerivedClassHasMethod("setClearColor", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodsetClearColor;
		}
		if (SwigDerivedClassHasMethod("pointInViewport", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodpointInViewport;
		}
		if (SwigDerivedClassHasMethod("getNumPixelsInUnitSquare", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getNumPixelsInUnitSquare", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setBackground", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethodsetBackground;
		}
		if (SwigDerivedClassHasMethod("background", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodbackground;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethodsetVisualStyle__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("visualStyle", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodvisualStyle__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethodsetVisualStyle__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("visualStyle", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodvisualStyle__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("enableDefaultLighting", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodenableDefaultLighting__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("enableDefaultLighting", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodenableDefaultLighting__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getSnapShot", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodgetSnapShot;
		}
		if (SwigDerivedClassHasMethod("collide", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethodcollide__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("collide", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodcollide__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("collide", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethodcollide__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("collide", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethodcollide__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("rayTrace", swigMethodTypes117))
		{
			swigDelegate117 = SwigDirectorMethodrayTrace__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("rayTrace", swigMethodTypes118))
		{
			swigDelegate118 = SwigDirectorMethodrayTrace__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("rayTrace", swigMethodTypes119))
		{
			swigDelegate119 = SwigDirectorMethodrayTrace__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("rayTrace", swigMethodTypes120))
		{
			swigDelegate120 = SwigDirectorMethodrayTrace__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("enableAntiAliasing", swigMethodTypes121))
		{
			swigDelegate121 = SwigDirectorMethodenableAntiAliasing;
		}
		if (SwigDerivedClassHasMethod("antiAliasingMode", swigMethodTypes122))
		{
			swigDelegate122 = SwigDirectorMethodantiAliasingMode;
		}
		if (SwigDerivedClassHasMethod("enableSSAO", swigMethodTypes123))
		{
			swigDelegate123 = SwigDirectorMethodenableSSAO;
		}
		if (SwigDerivedClassHasMethod("ssaoMode", swigMethodTypes124))
		{
			swigDelegate124 = SwigDirectorMethodssaoMode;
		}
		if (SwigDerivedClassHasMethod("enableRayTracedView", swigMethodTypes125))
		{
			swigDelegate125 = SwigDirectorMethodenableRayTracedView;
		}
		if (SwigDerivedClassHasMethod("rayTracedView", swigMethodTypes126))
		{
			swigDelegate126 = SwigDirectorMethodrayTracedView;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes127))
		{
			swigDelegate127 = SwigDirectorMethodinit;
		}
		if (SwigDerivedClassHasMethod("viewExtents", swigMethodTypes128))
		{
			swigDelegate128 = SwigDirectorMethodviewExtents;
		}
		if (SwigDerivedClassHasMethod("select", swigMethodTypes129))
		{
			swigDelegate129 = SwigDirectorMethodselect;
		}
		if (SwigDerivedClassHasMethod("clearLinetypeCache", swigMethodTypes130))
		{
			swigDelegate130 = SwigDirectorMethodclearLinetypeCache;
		}
		if (SwigDerivedClassHasMethod("isSupportLegacyWireframeMode", swigMethodTypes131))
		{
			swigDelegate131 = SwigDirectorMethodisSupportLegacyWireframeMode;
		}
		if (SwigDerivedClassHasMethod("isLegacyWireframeMode", swigMethodTypes132))
		{
			swigDelegate132 = SwigDirectorMethodisLegacyWireframeMode;
		}
		if (SwigDerivedClassHasMethod("setLegacyWireframeMode", swigMethodTypes133))
		{
			swigDelegate133 = SwigDirectorMethodsetLegacyWireframeMode;
		}
		if (SwigDerivedClassHasMethod("isSupportLegacyHiddenMode", swigMethodTypes134))
		{
			swigDelegate134 = SwigDirectorMethodisSupportLegacyHiddenMode;
		}
		if (SwigDerivedClassHasMethod("isLegacyHiddenMode", swigMethodTypes135))
		{
			swigDelegate135 = SwigDirectorMethodisLegacyHiddenMode;
		}
		if (SwigDerivedClassHasMethod("setLegacyHiddenMode", swigMethodTypes136))
		{
			swigDelegate136 = SwigDirectorMethodsetLegacyHiddenMode;
		}
		if (SwigDerivedClassHasMethod("isPlotTransparency", swigMethodTypes137))
		{
			swigDelegate137 = SwigDirectorMethodisPlotTransparency;
		}
		if (SwigDerivedClassHasMethod("setPlotTransparency", swigMethodTypes138))
		{
			swigDelegate138 = SwigDirectorMethodsetPlotTransparency;
		}
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes139))
		{
			swigDelegate139 = SwigDirectorMethodinvalidate__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes140))
		{
			swigDelegate140 = SwigDirectorMethodinvalidate__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getRegenType", swigMethodTypes141))
		{
			swigDelegate141 = SwigDirectorMethodgetRegenType;
		}
		if (SwigDerivedClassHasMethod("getDeviation", swigMethodTypes142))
		{
			swigDelegate142 = SwigDirectorMethodgetDeviation__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getDeviation", swigMethodTypes143))
		{
			swigDelegate143 = SwigDirectorMethodgetDeviation__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isLocalViewportIdCompatible", swigMethodTypes144))
		{
			swigDelegate144 = SwigDirectorMethodisLocalViewportIdCompatible;
		}
		if (SwigDerivedClassHasMethod("isViewRegenerated", swigMethodTypes145))
		{
			swigDelegate145 = SwigDirectorMethodisViewRegenerated;
		}
		if (SwigDerivedClassHasMethod("registerOverlay", swigMethodTypes146))
		{
			swigDelegate146 = SwigDirectorMethodregisterOverlay;
		}
		if (SwigDerivedClassHasMethod("unregisterOverlay", swigMethodTypes147))
		{
			swigDelegate147 = SwigDirectorMethodunregisterOverlay;
		}
		if (SwigDerivedClassHasMethod("partialUpdateExtentsEnlargement", swigMethodTypes148))
		{
			swigDelegate148 = SwigDirectorMethodpartialUpdateExtentsEnlargement;
		}
		if (SwigDerivedClassHasMethod("initCullingVolume", swigMethodTypes149))
		{
			swigDelegate149 = SwigDirectorMethodinitCullingVolume;
		}
		if (SwigDerivedClassHasMethod("isCullingVolumeInitialized", swigMethodTypes150))
		{
			swigDelegate150 = SwigDirectorMethodisCullingVolumeInitialized;
		}
		if (SwigDerivedClassHasMethod("cullingVolumeTransformBy", swigMethodTypes151))
		{
			swigDelegate151 = SwigDirectorMethodcullingVolumeTransformBy;
		}
		if (SwigDerivedClassHasMethod("saveViewState", swigMethodTypes152))
		{
			swigDelegate152 = SwigDirectorMethodsaveViewState;
		}
		if (SwigDerivedClassHasMethod("loadViewState", swigMethodTypes153))
		{
			swigDelegate153 = SwigDirectorMethodloadViewState;
		}
		if (SwigDerivedClassHasMethod("saveClientViewState", swigMethodTypes154))
		{
			swigDelegate154 = SwigDirectorMethodsaveClientViewState;
		}
		if (SwigDerivedClassHasMethod("loadClientViewState", swigMethodTypes155))
		{
			swigDelegate155 = SwigDirectorMethodloadClientViewState;
		}
		if (SwigDerivedClassHasMethod("isShowFrozenLayers", swigMethodTypes156))
		{
			swigDelegate156 = SwigDirectorMethodisShowFrozenLayers;
		}
		if (SwigDerivedClassHasMethod("setShowFrozenLayers", swigMethodTypes157))
		{
			swigDelegate157 = SwigDirectorMethodsetShowFrozenLayers;
		}
		if (SwigDerivedClassHasMethod("numVectorizers", swigMethodTypes158))
		{
			swigDelegate158 = SwigDirectorMethodnumVectorizers;
		}
		if (SwigDerivedClassHasMethod("getVectorizer", swigMethodTypes159))
		{
			swigDelegate159 = SwigDirectorMethodgetVectorizer;
		}
		if (SwigDerivedClassHasMethod("releaseVectorizer", swigMethodTypes160))
		{
			swigDelegate160 = SwigDirectorMethodreleaseVectorizer;
		}
		if (SwigDerivedClassHasMethod("updateGeometry", swigMethodTypes161))
		{
			swigDelegate161 = SwigDirectorMethodupdateGeometry;
		}
		if (SwigDerivedClassHasMethod("updateScreen", swigMethodTypes162))
		{
			swigDelegate162 = SwigDirectorMethodupdateScreen;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizeView_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125, swigDelegate126, swigDelegate127, swigDelegate128, swigDelegate129, swigDelegate130, swigDelegate131, swigDelegate132, swigDelegate133, swigDelegate134, swigDelegate135, swigDelegate136, swigDelegate137, swigDelegate138, swigDelegate139, swigDelegate140, swigDelegate141, swigDelegate142, swigDelegate143, swigDelegate144, swigDelegate145, swigDelegate146, swigDelegate147, swigDelegate148, swigDelegate149, swigDelegate150, swigDelegate151, swigDelegate152, swigDelegate153, swigDelegate154, swigDelegate155, swigDelegate156, swigDelegate157, swigDelegate158, swigDelegate159, swigDelegate160, swigDelegate161, swigDelegate162);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsBaseVectorizeView));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethoddevice()
	{
		return OdGsDevice.getCPtr(device()).Handle;
	}

	private IntPtr SwigDirectorMethoduserGiContext()
	{
		return OdGiContext.getCPtr(userGiContext()).Handle;
	}

	private void SwigDirectorMethodsetUserGiContext(IntPtr pUserGiContext)
	{
		try
		{
			setUserGiContext(Helpers.GetRXObject<OdGiContext>(pUserGiContext, bOwn: false, bTryAddToTransaction: false));
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

	private double SwigDirectorMethodlineweightToDcScale()
	{
		return lineweightToDcScale();
	}

	private void SwigDirectorMethodsetLineweightToDcScale(double scale)
	{
		try
		{
			setLineweightToDcScale(scale);
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

	private void SwigDirectorMethodsetLineweightEnum(IntPtr numLineweights, ushort altSourceLwds)
	{
		try
		{
			setLineweightEnum(Helpers.UnMarshalbyteFixedArray(numLineweights), altSourceLwds);
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

	private void SwigDirectorMethodsetLineweightEnum__SWIG_1(IntPtr numLineweights)
	{
		try
		{
			setLineweightEnum(Helpers.UnMarshalbyteFixedArray(numLineweights));
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

	private void SwigDirectorMethodsetViewport__SWIG_0(IntPtr lowerLeft, IntPtr upperRight)
	{
		try
		{
			setViewport(new OdGePoint2d(lowerLeft, cMemoryOwn: false), new OdGePoint2d(upperRight, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetViewport__SWIG_1(IntPtr screenRect)
	{
		try
		{
			setViewport(new OdGsDCRect(screenRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetViewport__SWIG_2(IntPtr screenRec)
	{
		try
		{
			setViewport(new OdGsDCRectDouble(screenRec, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetViewport__SWIG_0(IntPtr lowerLeft, IntPtr upperRight)
	{
		try
		{
			getViewport(new OdGePoint2d(lowerLeft, cMemoryOwn: false), new OdGePoint2d(upperRight, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetViewport__SWIG_1(IntPtr screenRect)
	{
		try
		{
			getViewport(new OdGsDCRect(screenRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetViewport__SWIG_2(IntPtr screenRec)
	{
		try
		{
			getViewport(new OdGsDCRectDouble(screenRec, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetViewportClipRegion__SWIG_1(IntPtr numContours)
	{
		try
		{
			setViewportClipRegion(Helpers.UnMarshalDCClipRegion(numContours));
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

	private void SwigDirectorMethodsetViewportClipRegion__SWIG_0(IntPtr numContours)
	{
		try
		{
			setViewportClipRegion(Helpers.UnMarshalClipRegion(numContours));
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

	private void SwigDirectorMethodviewportClipRegion__SWIG_1(IntPtr counts, IntPtr dcPts)
	{
		try
		{
			viewportClipRegion(new OdIntArray(counts, cMemoryOwn: true), new OdGsDCPointArray(dcPts, cMemoryOwn: true));
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

	private void SwigDirectorMethodviewportClipRegion__SWIG_0(IntPtr counts, IntPtr vertices)
	{
		try
		{
			viewportClipRegion(new OdIntArray(counts, cMemoryOwn: true), new OdGePoint2dArray(vertices, cMemoryOwn: true));
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

	private void SwigDirectorMethodsetViewport3dClipping__SWIG_0(IntPtr pBoundary, IntPtr pClipInfo)
	{
		try
		{
			setViewport3dClipping((pBoundary == IntPtr.Zero) ? null : new OdGiClipBoundary(pBoundary, cMemoryOwn: false), (pClipInfo == IntPtr.Zero) ? null : new OdGiAbstractClipBoundary(pClipInfo, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetViewport3dClipping__SWIG_1(IntPtr pBoundary)
	{
		try
		{
			setViewport3dClipping((pBoundary == IntPtr.Zero) ? null : new OdGiClipBoundary(pBoundary, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodviewport3dClipping__SWIG_0(IntPtr ppClipInfo)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiClipBoundary.getCPtr(viewport3dClipping(new OdGiAbstractClipBoundary(ppClipInfo, cMemoryOwn: true))).Handle;
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

	private IntPtr SwigDirectorMethodviewport3dClipping__SWIG_1()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiClipBoundary.getCPtr(viewport3dClipping()).Handle;
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

	private void SwigDirectorMethodsetViewportBorderProperties(uint color, int width)
	{
		try
		{
			setViewportBorderProperties(color, width);
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

	private void SwigDirectorMethodgetViewportBorderProperties(uint color, int width)
	{
		try
		{
			getViewportBorderProperties(out color, out width);
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

	private void SwigDirectorMethodsetViewportBorderVisibility(bool visible)
	{
		try
		{
			setViewportBorderVisibility(visible);
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

	private bool SwigDirectorMethodisViewportBorderVisible()
	{
		return isViewportBorderVisible();
	}

	private void SwigDirectorMethodsetView__SWIG_0(IntPtr position, IntPtr target, IntPtr upVector, double fieldWidth, double fieldHeight, int projection)
	{
		try
		{
			setView(new OdGePoint3d(position, cMemoryOwn: false), new OdGePoint3d(target, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fieldWidth, fieldHeight, (OdGsView_Projection)projection);
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

	private void SwigDirectorMethodsetView__SWIG_1(IntPtr position, IntPtr target, IntPtr upVector, double fieldWidth, double fieldHeight)
	{
		try
		{
			setView(new OdGePoint3d(position, cMemoryOwn: false), new OdGePoint3d(target, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), fieldWidth, fieldHeight);
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

	private IntPtr SwigDirectorMethodposition()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(position()).Handle;
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

	private IntPtr SwigDirectorMethodtarget()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(target()).Handle;
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

	private IntPtr SwigDirectorMethodupVector()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(upVector()).Handle;
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

	private double SwigDirectorMethodlensLength()
	{
		return lensLength();
	}

	private void SwigDirectorMethodsetLensLength(double lensLength)
	{
		try
		{
			setLensLength(lensLength);
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

	private bool SwigDirectorMethodisPerspective()
	{
		return isPerspective();
	}

	private double SwigDirectorMethodfieldWidth()
	{
		return fieldWidth();
	}

	private double SwigDirectorMethodfieldHeight()
	{
		return fieldHeight();
	}

	private void SwigDirectorMethodsetEnableFrontClip(bool enable)
	{
		try
		{
			setEnableFrontClip(enable);
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

	private bool SwigDirectorMethodisFrontClipped()
	{
		return isFrontClipped();
	}

	private void SwigDirectorMethodsetFrontClip(double distance)
	{
		try
		{
			setFrontClip(distance);
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

	private double SwigDirectorMethodfrontClip()
	{
		return frontClip();
	}

	private void SwigDirectorMethodsetEnableBackClip(bool enable)
	{
		try
		{
			setEnableBackClip(enable);
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

	private bool SwigDirectorMethodisBackClipped()
	{
		return isBackClipped();
	}

	private void SwigDirectorMethodsetBackClip(double distance)
	{
		try
		{
			setBackClip(distance);
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

	private double SwigDirectorMethodbackClip()
	{
		return backClip();
	}

	private IntPtr SwigDirectorMethodviewingMatrix()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(viewingMatrix()).Handle;
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

	private IntPtr SwigDirectorMethodprojectionMatrix__SWIG_0()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(projectionMatrix()).Handle;
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

	private IntPtr SwigDirectorMethodscreenMatrix()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(screenMatrix()).Handle;
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

	private IntPtr SwigDirectorMethodworldToDeviceMatrix__SWIG_0()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(worldToDeviceMatrix()).Handle;
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

	private IntPtr SwigDirectorMethodobjectToDeviceMatrix__SWIG_0()
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

	private void SwigDirectorMethodsetMode(int mode)
	{
		try
		{
			setMode((OdGsView_RenderMode)mode);
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

	private int SwigDirectorMethodmode()
	{
		return (int)mode();
	}

	private bool SwigDirectorMethodadd(IntPtr sceneGraph, IntPtr model)
	{
		return add(Helpers.GetRXObject<OdGiDrawable>(sceneGraph, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsModel>(model, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodnumRootDrawables()
	{
		return numRootDrawables();
	}

	private bool SwigDirectorMethoderase(IntPtr sceneGraph)
	{
		return erase(Helpers.GetRXObject<OdGiDrawable>(sceneGraph, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethoderaseAll()
	{
		try
		{
			eraseAll();
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

	private IntPtr SwigDirectorMethodgetModel(IntPtr pDrawable)
	{
		return OdGsModel.getCPtr(getModel(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetModelList()
	{
		return OdGsModelArray.getCPtr(getModelList()).Handle;
	}

	private void SwigDirectorMethodinvalidate__SWIG_0()
	{
		try
		{
			invalidate();
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

	private void SwigDirectorMethodinvalidate__SWIG_1(IntPtr rect)
	{
		try
		{
			invalidate(new OdGsDCRect(rect, cMemoryOwn: false));
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

	private bool SwigDirectorMethodisValid()
	{
		return isValid();
	}

	private void SwigDirectorMethodupdate()
	{
		try
		{
			update();
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

	private void SwigDirectorMethodbeginInteractivity(double frameRateInHz)
	{
		try
		{
			beginInteractivity(frameRateInHz);
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

	private bool SwigDirectorMethodisInInteractivity()
	{
		return isInInteractivity();
	}

	private double SwigDirectorMethodinteractivityFrameRate()
	{
		return interactivityFrameRate();
	}

	private void SwigDirectorMethodendInteractivity()
	{
		try
		{
			endInteractivity();
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

	private void SwigDirectorMethodflush()
	{
		try
		{
			flush();
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

	private void SwigDirectorMethodhide()
	{
		try
		{
			hide();
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

	private void SwigDirectorMethodshow()
	{
		try
		{
			show();
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

	private bool SwigDirectorMethodisVisible()
	{
		return isVisible();
	}

	private void SwigDirectorMethodfreezeLayer(IntPtr layerID)
	{
		try
		{
			freezeLayer((layerID == IntPtr.Zero) ? null : new OdDbStub(layerID, cMemoryOwn: false));
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

	private void SwigDirectorMethodthawLayer(IntPtr layerID)
	{
		try
		{
			thawLayer((layerID == IntPtr.Zero) ? null : new OdDbStub(layerID, cMemoryOwn: false));
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

	private void SwigDirectorMethodclearFrozenLayers()
	{
		try
		{
			clearFrozenLayers();
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

	private void SwigDirectorMethodinvalidateCachedViewportGeometry__SWIG_0()
	{
		try
		{
			invalidateCachedViewportGeometry();
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

	private void SwigDirectorMethodselect__SWIG_0(IntPtr points, IntPtr pReactor, int mode)
	{
		try
		{
			select(Helpers.UnMarshalOdGsDCPointArray(points), (pReactor == IntPtr.Zero) ? null : new OdGsSelectionReactor(pReactor, cMemoryOwn: false), (OdGsView_SelectionMode)mode);
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

	private void SwigDirectorMethoddolly__SWIG_0(IntPtr dollyVector)
	{
		try
		{
			dolly(new OdGeVector3d(dollyVector, cMemoryOwn: false));
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

	private void SwigDirectorMethoddolly__SWIG_1(double xDolly, double yDolly, double zDolly)
	{
		try
		{
			dolly(xDolly, yDolly, zDolly);
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

	private void SwigDirectorMethodroll(double rollAngle)
	{
		try
		{
			roll(rollAngle);
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

	private void SwigDirectorMethodorbit(double xOrbit, double yOrbit)
	{
		try
		{
			orbit(xOrbit, yOrbit);
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

	private void SwigDirectorMethodzoom(double zoomFactor)
	{
		try
		{
			zoom(zoomFactor);
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

	private void SwigDirectorMethodpan(double xPan, double yPan)
	{
		try
		{
			pan(xPan, yPan);
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

	private void SwigDirectorMethodzoomExtents(IntPtr minPt, IntPtr maxPt)
	{
		try
		{
			zoomExtents(new OdGePoint3d(minPt, cMemoryOwn: false), new OdGePoint3d(maxPt, cMemoryOwn: false));
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

	private void SwigDirectorMethodzoomWindow(IntPtr lowerLeft, IntPtr upperRight)
	{
		try
		{
			zoomWindow(new OdGePoint2d(lowerLeft, cMemoryOwn: false), new OdGePoint2d(upperRight, cMemoryOwn: false));
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

	private bool SwigDirectorMethodpointInView(IntPtr pt)
	{
		return pointInView(new OdGePoint3d(pt, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodextentsInView(IntPtr minPt, IntPtr maxPt)
	{
		return extentsInView(new OdGePoint3d(minPt, cMemoryOwn: false), new OdGePoint3d(maxPt, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodcloneView__SWIG_0(bool cloneViewParameters, bool cloneGeometry)
	{
		return OdGsView.getCPtr(cloneView(cloneViewParameters, cloneGeometry)).Handle;
	}

	private IntPtr SwigDirectorMethodcloneView__SWIG_1(bool cloneViewParameters)
	{
		return OdGsView.getCPtr(cloneView(cloneViewParameters)).Handle;
	}

	private IntPtr SwigDirectorMethodcloneView__SWIG_2()
	{
		return OdGsView.getCPtr(cloneView()).Handle;
	}

	private void SwigDirectorMethodviewParameters(IntPtr pView)
	{
		try
		{
			viewParameters(Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodexceededBounds()
	{
		return exceededBounds();
	}

	private void SwigDirectorMethodenableStereo(bool enabled)
	{
		try
		{
			enableStereo(enabled);
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

	private bool SwigDirectorMethodisStereoEnabled()
	{
		return isStereoEnabled();
	}

	private void SwigDirectorMethodsetStereoParameters(double magnitude, double parallax)
	{
		try
		{
			setStereoParameters(magnitude, parallax);
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

	private void SwigDirectorMethodgetStereoParameters(double magnitude, double parallax)
	{
		try
		{
			getStereoParameters(out magnitude, out parallax);
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

	private void SwigDirectorMethodinitLights(IntPtr pLightsIterator)
	{
		try
		{
			initLights(Helpers.GetRXObject<OdRxIterator>(pLightsIterator, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodsetLinetypeScaleMultiplier(double linetypeScaleMultiplier)
	{
		try
		{
			setLinetypeScaleMultiplier(linetypeScaleMultiplier);
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

	private double SwigDirectorMethodlinetypeScaleMultiplier()
	{
		return linetypeScaleMultiplier();
	}

	private void SwigDirectorMethodsetAlternateLinetypeScaleMultiplier(double linetypeAlternateScaleMultiplier)
	{
		try
		{
			setAlternateLinetypeScaleMultiplier(linetypeAlternateScaleMultiplier);
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

	private double SwigDirectorMethodlinetypeAlternateScaleMultiplier()
	{
		return linetypeAlternateScaleMultiplier();
	}

	private void SwigDirectorMethodsetClearColor(int color)
	{
		try
		{
			setClearColor((OdGsView_ClearColor)color);
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

	private bool SwigDirectorMethodpointInViewport(IntPtr screenPoint)
	{
		return pointInViewport(new OdGePoint2d(screenPoint, cMemoryOwn: false));
	}

	private void SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_0(IntPtr givenWorldpt, IntPtr pixelArea, bool includePerspective)
	{
		try
		{
			getNumPixelsInUnitSquare(new OdGePoint3d(givenWorldpt, cMemoryOwn: false), new OdGePoint2d(pixelArea, cMemoryOwn: false), includePerspective);
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

	private void SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_1(IntPtr givenWorldpt, IntPtr pixelArea)
	{
		try
		{
			getNumPixelsInUnitSquare(new OdGePoint3d(givenWorldpt, cMemoryOwn: false), new OdGePoint2d(pixelArea, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetBackground(IntPtr backgroundId)
	{
		try
		{
			setBackground((backgroundId == IntPtr.Zero) ? null : new OdDbStub(backgroundId, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodbackground()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(background()).Handle;
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

	private void SwigDirectorMethodsetVisualStyle__SWIG_0(IntPtr visualStyleId)
	{
		try
		{
			setVisualStyle((visualStyleId == IntPtr.Zero) ? null : new OdDbStub(visualStyleId, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodvisualStyle__SWIG_0()
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

	private void SwigDirectorMethodsetVisualStyle__SWIG_1(IntPtr visualStyle)
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

	private bool SwigDirectorMethodvisualStyle__SWIG_1(IntPtr vs)
	{
		OdSwigDirectorHelper.director_UnpackData(vs, out var pOriginalObject, out var pFunction);
		OdGiVisualStyle vs2 = Helpers.GetRXObject<OdGiVisualStyle>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return visualStyle(ref vs2);
		}
		finally
		{
			IntPtr handle = OdGiVisualStyle.getCPtr(vs2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(vs);
		}
	}

	private void SwigDirectorMethodenableDefaultLighting__SWIG_0(bool bEnable, int lightType)
	{
		try
		{
			enableDefaultLighting(bEnable, (OdGsView_DefaultLightingType)lightType);
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

	private void SwigDirectorMethodenableDefaultLighting__SWIG_1(bool bEnable)
	{
		try
		{
			enableDefaultLighting(bEnable);
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

	private void SwigDirectorMethodgetSnapShot(IntPtr pImage, IntPtr region)
	{
		OdSwigDirectorHelper.director_UnpackData(pImage, out var pOriginalObject, out var pFunction);
		OdGiRasterImage pImage2 = Helpers.GetRXObject<OdGiRasterImage>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			getSnapShot(ref pImage2, new OdGsDCRect(region, cMemoryOwn: false));
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
			IntPtr handle = OdGiRasterImage.getCPtr(pImage2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pImage);
		}
	}

	private void SwigDirectorMethodcollide__SWIG_0(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize, IntPtr pCtx)
	{
		try
		{
			collide(pInputList, nInputListSize, (pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false), pCollisionWithList, nCollisionWithListSize, (pCtx == IntPtr.Zero) ? null : new OdGsCollisionDetectionContext(pCtx, cMemoryOwn: false));
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

	private void SwigDirectorMethodcollide__SWIG_1(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize)
	{
		try
		{
			collide(pInputList, nInputListSize, (pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false), pCollisionWithList, nCollisionWithListSize);
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

	private void SwigDirectorMethodcollide__SWIG_2(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList)
	{
		try
		{
			collide(pInputList, nInputListSize, (pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false), pCollisionWithList);
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

	private void SwigDirectorMethodcollide__SWIG_3(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor)
	{
		try
		{
			collide(pInputList, nInputListSize, (pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false));
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

	private void SwigDirectorMethodrayTrace__SWIG_0(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList, uint nObjectListSize)
	{
		try
		{
			rayTrace(new OdGePoint3d(rayOrigin, cMemoryOwn: false), new OdGeVector3d(rayDirection, cMemoryOwn: false), (pReactor == IntPtr.Zero) ? null : new OdGsRayTraceReactor(pReactor, cMemoryOwn: false), bSortedSelection, pObjectList, nObjectListSize);
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

	private void SwigDirectorMethodrayTrace__SWIG_1(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList)
	{
		try
		{
			rayTrace(new OdGePoint3d(rayOrigin, cMemoryOwn: false), new OdGeVector3d(rayDirection, cMemoryOwn: false), (pReactor == IntPtr.Zero) ? null : new OdGsRayTraceReactor(pReactor, cMemoryOwn: false), bSortedSelection, pObjectList);
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

	private void SwigDirectorMethodrayTrace__SWIG_2(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor, bool bSortedSelection)
	{
		try
		{
			rayTrace(new OdGePoint3d(rayOrigin, cMemoryOwn: false), new OdGeVector3d(rayDirection, cMemoryOwn: false), (pReactor == IntPtr.Zero) ? null : new OdGsRayTraceReactor(pReactor, cMemoryOwn: false), bSortedSelection);
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

	private void SwigDirectorMethodrayTrace__SWIG_3(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor)
	{
		try
		{
			rayTrace(new OdGePoint3d(rayOrigin, cMemoryOwn: false), new OdGeVector3d(rayDirection, cMemoryOwn: false), (pReactor == IntPtr.Zero) ? null : new OdGsRayTraceReactor(pReactor, cMemoryOwn: false));
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

	private void SwigDirectorMethodenableAntiAliasing(uint nMode)
	{
		try
		{
			enableAntiAliasing(nMode);
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

	private uint SwigDirectorMethodantiAliasingMode()
	{
		return antiAliasingMode();
	}

	private void SwigDirectorMethodenableSSAO(bool bEnable)
	{
		try
		{
			enableSSAO(bEnable);
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

	private bool SwigDirectorMethodssaoMode()
	{
		return ssaoMode();
	}

	private void SwigDirectorMethodenableRayTracedView(bool bEnable)
	{
		try
		{
			enableRayTracedView(bEnable);
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

	private bool SwigDirectorMethodrayTracedView()
	{
		return rayTracedView();
	}

	private void SwigDirectorMethodinit(IntPtr pDevice, IntPtr pViewInfo, bool enableLayerVisibilityPerView)
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

	private bool SwigDirectorMethodviewExtents(IntPtr extents)
	{
		return viewExtents(new OdGeBoundBlock3d(extents, cMemoryOwn: false));
	}

	private void SwigDirectorMethodselect(IntPtr aPtDc, IntPtr pReactor, int mode)
	{
		try
		{
			select(Helpers.UnMarshalPoint2dArray(aPtDc), (pReactor == IntPtr.Zero) ? null : new OdGsSelectionReactor(pReactor, cMemoryOwn: false), (OdGsView_SelectionMode)mode);
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

	private bool SwigDirectorMethodisSupportLegacyWireframeMode()
	{
		return isSupportLegacyWireframeMode();
	}

	private bool SwigDirectorMethodisLegacyWireframeMode()
	{
		return isLegacyWireframeMode();
	}

	private void SwigDirectorMethodsetLegacyWireframeMode(bool bSet)
	{
		try
		{
			setLegacyWireframeMode(bSet);
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

	private bool SwigDirectorMethodisSupportLegacyHiddenMode()
	{
		return isSupportLegacyHiddenMode();
	}

	private bool SwigDirectorMethodisLegacyHiddenMode()
	{
		return isLegacyHiddenMode();
	}

	private void SwigDirectorMethodsetLegacyHiddenMode(bool bSet)
	{
		try
		{
			setLegacyHiddenMode(bSet);
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

	private bool SwigDirectorMethodisPlotTransparency()
	{
		return isPlotTransparency();
	}

	private void SwigDirectorMethodsetPlotTransparency(bool bSet)
	{
		try
		{
			setPlotTransparency(bSet);
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

	private void SwigDirectorMethodinvalidate__SWIG_2(IntPtr worldExt, IntPtr pModel, int extendByLineweight)
	{
		try
		{
			invalidate(new OdGeExtents3d(worldExt, cMemoryOwn: false), Helpers.GetRXObject<OdGsBaseModel>(pModel, bOwn: false, bTryAddToTransaction: false), (LineWeight)extendByLineweight);
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

	private void SwigDirectorMethodinvalidate__SWIG_3(IntPtr worldExt, IntPtr pModel)
	{
		try
		{
			invalidate(new OdGeExtents3d(worldExt, cMemoryOwn: false), Helpers.GetRXObject<OdGsBaseModel>(pModel, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodgetRegenType()
	{
		return (int)getRegenType();
	}

	private double SwigDirectorMethodgetDeviation__SWIG_0(int deviationType, IntPtr pointOnCurve, bool bRecalculate)
	{
		return getDeviation((OdGiDeviationType)deviationType, new OdGePoint3d(pointOnCurve, cMemoryOwn: false), bRecalculate);
	}

	private double SwigDirectorMethodgetDeviation__SWIG_1(int deviationType, IntPtr pointOnCurve)
	{
		return getDeviation((OdGiDeviationType)deviationType, new OdGePoint3d(pointOnCurve, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisLocalViewportIdCompatible(IntPtr pView)
	{
		return isLocalViewportIdCompatible(Helpers.GetRXObject<OdGsViewImpl>(pView, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisViewRegenerated()
	{
		return isViewRegenerated();
	}

	private void SwigDirectorMethodregisterOverlay(IntPtr pModel)
	{
		try
		{
			registerOverlay(Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodunregisterOverlay(IntPtr pModel)
	{
		try
		{
			unregisterOverlay(Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodpartialUpdateExtentsEnlargement()
	{
		return partialUpdateExtentsEnlargement();
	}

	private void SwigDirectorMethodinitCullingVolume()
	{
		try
		{
			initCullingVolume();
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

	private bool SwigDirectorMethodisCullingVolumeInitialized()
	{
		return isCullingVolumeInitialized();
	}

	private void SwigDirectorMethodcullingVolumeTransformBy(IntPtr xfm)
	{
		try
		{
			cullingVolumeTransformBy(new OdGeMatrix3d(xfm, cMemoryOwn: false));
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

	private bool SwigDirectorMethodsaveViewState(IntPtr pFiler)
	{
		return saveViewState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodloadViewState(IntPtr pFiler)
	{
		return loadViewState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsaveClientViewState(IntPtr pFiler)
	{
		return saveClientViewState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodloadClientViewState(IntPtr pFiler)
	{
		return loadClientViewState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisShowFrozenLayers()
	{
		return isShowFrozenLayers();
	}

	private void SwigDirectorMethodsetShowFrozenLayers(bool bSet)
	{
		try
		{
			setShowFrozenLayers(bSet);
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

	private IntPtr SwigDirectorMethodgetVectorizer(bool bDisplay)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGsBaseVectorizer.getCPtr(getVectorizer(bDisplay)).Handle;
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

	private void SwigDirectorMethodreleaseVectorizer(IntPtr pVect)
	{
		try
		{
			releaseVectorizer((pVect == IntPtr.Zero) ? null : new OdGsBaseVectorizer(pVect, cMemoryOwn: false));
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

	private void SwigDirectorMethodupdateGeometry()
	{
		try
		{
			updateGeometry();
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

	private void SwigDirectorMethodupdateScreen()
	{
		try
		{
			updateScreen();
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

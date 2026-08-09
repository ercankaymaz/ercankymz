using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiBaseVectorizer : OdGiWorldDrawImpl, OdGiConveyorContext, OdGiDeviation
{
	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_0(IntPtr pProtocolClass);

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_1();

	public delegate void SwigDelegateOdGiBaseVectorizer_2(ushort color);

	public delegate void SwigDelegateOdGiBaseVectorizer_3(IntPtr trueColor);

	public delegate void SwigDelegateOdGiBaseVectorizer_4(IntPtr layerId);

	public delegate void SwigDelegateOdGiBaseVectorizer_5(IntPtr lineTypeId);

	public delegate void SwigDelegateOdGiBaseVectorizer_6(IntPtr selectionMarker);

	public delegate void SwigDelegateOdGiBaseVectorizer_7(int fillType);

	public delegate void SwigDelegateOdGiBaseVectorizer_8(IntPtr pNormal);

	public delegate void SwigDelegateOdGiBaseVectorizer_9();

	public delegate void SwigDelegateOdGiBaseVectorizer_10(int lineWeight);

	public delegate void SwigDelegateOdGiBaseVectorizer_11(double lineTypeScale);

	public delegate void SwigDelegateOdGiBaseVectorizer_12();

	public delegate void SwigDelegateOdGiBaseVectorizer_13(double thickness);

	public delegate void SwigDelegateOdGiBaseVectorizer_14(int plotStyleNameType, IntPtr pPlotStyleNameId);

	public delegate void SwigDelegateOdGiBaseVectorizer_15(int plotStyleNameType);

	public delegate void SwigDelegateOdGiBaseVectorizer_16(IntPtr pMaterialId);

	public delegate void SwigDelegateOdGiBaseVectorizer_17(IntPtr pMapper);

	public delegate void SwigDelegateOdGiBaseVectorizer_18(IntPtr pVisualStyleId);

	public delegate void SwigDelegateOdGiBaseVectorizer_19(IntPtr transparency);

	public delegate void SwigDelegateOdGiBaseVectorizer_20(uint drawFlags);

	public delegate void SwigDelegateOdGiBaseVectorizer_21(uint lockFlags);

	public delegate void SwigDelegateOdGiBaseVectorizer_22(bool bSelectionFlag);

	public delegate void SwigDelegateOdGiBaseVectorizer_23(int shadowFlags);

	public delegate void SwigDelegateOdGiBaseVectorizer_24(bool bSectionableFlag);

	public delegate void SwigDelegateOdGiBaseVectorizer_25(int selectionFlags);

	public delegate ushort SwigDelegateOdGiBaseVectorizer_26();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_27();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_28();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_29();

	public delegate int SwigDelegateOdGiBaseVectorizer_30();

	public delegate bool SwigDelegateOdGiBaseVectorizer_31(IntPtr normal);

	public delegate int SwigDelegateOdGiBaseVectorizer_32();

	public delegate double SwigDelegateOdGiBaseVectorizer_33();

	public delegate double SwigDelegateOdGiBaseVectorizer_34();

	public delegate int SwigDelegateOdGiBaseVectorizer_35();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_36();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_37();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_38();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_39();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_40();

	public delegate uint SwigDelegateOdGiBaseVectorizer_41();

	public delegate uint SwigDelegateOdGiBaseVectorizer_42();

	public delegate bool SwigDelegateOdGiBaseVectorizer_43();

	public delegate int SwigDelegateOdGiBaseVectorizer_44();

	public delegate bool SwigDelegateOdGiBaseVectorizer_45();

	public delegate int SwigDelegateOdGiBaseVectorizer_46();

	public delegate void SwigDelegateOdGiBaseVectorizer_47(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_48();

	public delegate void SwigDelegateOdGiBaseVectorizer_49(IntPtr pLSMod);

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_50();

	public delegate void SwigDelegateOdGiBaseVectorizer_51(IntPtr pFill);

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_52();

	public delegate void SwigDelegateOdGiBaseVectorizer_53(IntPtr pAuxData);

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_54();

	public delegate bool SwigDelegateOdGiBaseVectorizer_55(IntPtr pOverride);

	public delegate void SwigDelegateOdGiBaseVectorizer_56();

	public delegate bool SwigDelegateOdGiBaseVectorizer_57(IntPtr pOverride);

	public delegate void SwigDelegateOdGiBaseVectorizer_58();

	public delegate uint SwigDelegateOdGiBaseVectorizer_59();

	public delegate void SwigDelegateOdGiBaseVectorizer_60(IntPtr lightId);

	public delegate void SwigDelegateOdGiBaseVectorizer_61(IntPtr pUserContext);

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_62(IntPtr layerId);

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_63();

	public delegate bool SwigDelegateOdGiBaseVectorizer_64(IntPtr layerId);

	public delegate void SwigDelegateOdGiBaseVectorizer_65();

	public delegate void SwigDelegateOdGiBaseVectorizer_66(int bit, bool value);

	public delegate void SwigDelegateOdGiBaseVectorizer_67(int bit);

	public delegate bool SwigDelegateOdGiBaseVectorizer_68();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_69();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_70();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_71();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_72();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_73();

	public delegate void SwigDelegateOdGiBaseVectorizer_74(IntPtr pSource, IntPtr destination);

	public delegate double SwigDelegateOdGiBaseVectorizer_75();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_76();

	public delegate void SwigDelegateOdGiBaseVectorizer_77(IntPtr traits, IntPtr fillNormal);

	public delegate void SwigDelegateOdGiBaseVectorizer_78(IntPtr traits);

	public delegate void SwigDelegateOdGiBaseVectorizer_79(IntPtr nSelectionMarker);

	public delegate bool SwigDelegateOdGiBaseVectorizer_80();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_81();

	public delegate void SwigDelegateOdGiBaseVectorizer_82();

	public delegate void SwigDelegateOdGiBaseVectorizer_83();

	public delegate bool SwigDelegateOdGiBaseVectorizer_84();

	public delegate double SwigDelegateOdGiBaseVectorizer_85(int deviationType, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdGiBaseVectorizer_86();

	public delegate bool SwigDelegateOdGiBaseVectorizer_87();

	public delegate uint SwigDelegateOdGiBaseVectorizer_88();

	public delegate uint SwigDelegateOdGiBaseVectorizer_89();

	public delegate bool SwigDelegateOdGiBaseVectorizer_90(uint viewportId);

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_91();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_92();

	public delegate void SwigDelegateOdGiBaseVectorizer_93(IntPtr center, double radius, IntPtr normal);

	public delegate void SwigDelegateOdGiBaseVectorizer_94(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint);

	public delegate void SwigDelegateOdGiBaseVectorizer_95(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle, int arcType);

	public delegate void SwigDelegateOdGiBaseVectorizer_96(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle);

	public delegate void SwigDelegateOdGiBaseVectorizer_97(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint, int arcType);

	public delegate void SwigDelegateOdGiBaseVectorizer_98(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint);

	public delegate void SwigDelegateOdGiBaseVectorizer_99(IntPtr numVertices, IntPtr pNormal, IntPtr baseSubEntMarker);

	public delegate void SwigDelegateOdGiBaseVectorizer_100(IntPtr numVertices, IntPtr pNormal);

	public delegate void SwigDelegateOdGiBaseVectorizer_101(IntPtr numVertices);

	public delegate void SwigDelegateOdGiBaseVectorizer_102(IntPtr numVertices);

	public delegate void SwigDelegateOdGiBaseVectorizer_103(IntPtr numVertices, IntPtr pNormal);

	public delegate void SwigDelegateOdGiBaseVectorizer_104(IntPtr polyline, uint fromIndex, uint numSegs);

	public delegate void SwigDelegateOdGiBaseVectorizer_105(IntPtr polyline, uint fromIndex);

	public delegate void SwigDelegateOdGiBaseVectorizer_106(IntPtr polyline);

	public delegate void SwigDelegateOdGiBaseVectorizer_107(IntPtr position, IntPtr normal, IntPtr direction, double height, double width, double oblique, [MarshalAs(UnmanagedType.LPWStr)] string msg);

	public delegate void SwigDelegateOdGiBaseVectorizer_108(IntPtr position, IntPtr normal, IntPtr direction, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle);

	public delegate void SwigDelegateOdGiBaseVectorizer_109(IntPtr firstPoint, IntPtr secondPoint);

	public delegate void SwigDelegateOdGiBaseVectorizer_110(IntPtr basePoint, IntPtr throughPoint);

	public delegate void SwigDelegateOdGiBaseVectorizer_111(IntPtr nurbsCurve);

	public delegate void SwigDelegateOdGiBaseVectorizer_112(IntPtr ellipArc, IntPtr endPointsOverrides, int arcType);

	public delegate void SwigDelegateOdGiBaseVectorizer_113(IntPtr ellipArc, IntPtr endPointsOverrides);

	public delegate void SwigDelegateOdGiBaseVectorizer_114(IntPtr ellipArc);

	public delegate void SwigDelegateOdGiBaseVectorizer_115(IntPtr numRows);

	public delegate void SwigDelegateOdGiBaseVectorizer_116(IntPtr numVertices);

	public delegate void SwigDelegateOdGiBaseVectorizer_117(IntPtr img, IntPtr origin, IntPtr uVec, IntPtr vVec, int trpMode);

	public delegate void SwigDelegateOdGiBaseVectorizer_118(IntPtr img, IntPtr origin, IntPtr uVec, IntPtr vVec);

	public delegate void SwigDelegateOdGiBaseVectorizer_119(IntPtr edges);

	public delegate void SwigDelegateOdGiBaseVectorizer_120(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pSubEntMarkers, int nPointSize);

	public delegate void SwigDelegateOdGiBaseVectorizer_121(int numPoints, IntPtr startPoint, IntPtr dirToNextPoint);

	public delegate void SwigDelegateOdGiBaseVectorizer_122(IntPtr pCloud);

	public delegate void SwigDelegateOdGiBaseVectorizer_123(IntPtr pBoundary);

	public delegate void SwigDelegateOdGiBaseVectorizer_124(IntPtr pBoundary, IntPtr pClipInfo);

	public delegate void SwigDelegateOdGiBaseVectorizer_125();

	public delegate void SwigDelegateOdGiBaseVectorizer_126(IntPtr xfm);

	public delegate void SwigDelegateOdGiBaseVectorizer_127(IntPtr normal);

	public delegate void SwigDelegateOdGiBaseVectorizer_128();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_129();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_130();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_131(int behavior, IntPtr pos);

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_132(int behavior, IntPtr scale);

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_133(int behavior);

	public delegate void SwigDelegateOdGiBaseVectorizer_134(IntPtr pDrawable);

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_135();

	public delegate uint SwigDelegateOdGiBaseVectorizer_136(IntPtr pDrawable);

	public delegate bool SwigDelegateOdGiBaseVectorizer_137(uint drawableFlags, IntPtr pDrawable);

	public delegate void SwigDelegateOdGiBaseVectorizer_138(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness, double contrast, double fade);

	public delegate void SwigDelegateOdGiBaseVectorizer_139(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness, double contrast);

	public delegate void SwigDelegateOdGiBaseVectorizer_140(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness);

	public delegate void SwigDelegateOdGiBaseVectorizer_141(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency);

	public delegate void SwigDelegateOdGiBaseVectorizer_142(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary);

	public delegate void SwigDelegateOdGiBaseVectorizer_143(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile, bool bDcAligned, bool bAllowClipping);

	public delegate void SwigDelegateOdGiBaseVectorizer_144(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile, bool bDcAligned);

	public delegate void SwigDelegateOdGiBaseVectorizer_145(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile);

	public delegate void SwigDelegateOdGiBaseVectorizer_146(IntPtr numVertices);

	public delegate void SwigDelegateOdGiBaseVectorizer_147(IntPtr numVertices);

	public delegate void SwigDelegateOdGiBaseVectorizer_148(IntPtr numVertices);

	public delegate void SwigDelegateOdGiBaseVectorizer_149(IntPtr numVertices);

	public delegate void SwigDelegateOdGiBaseVectorizer_150();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_151();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_152();

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_153();

	public delegate void SwigDelegateOdGiBaseVectorizer_154(IntPtr arg0, IntPtr arg1, IntPtr arg2);

	public delegate IntPtr SwigDelegateOdGiBaseVectorizer_155();

	public delegate double SwigDelegateOdGiBaseVectorizer_156();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiBaseVectorizer_0 swigDelegate0;

	private SwigDelegateOdGiBaseVectorizer_1 swigDelegate1;

	private SwigDelegateOdGiBaseVectorizer_2 swigDelegate2;

	private SwigDelegateOdGiBaseVectorizer_3 swigDelegate3;

	private SwigDelegateOdGiBaseVectorizer_4 swigDelegate4;

	private SwigDelegateOdGiBaseVectorizer_5 swigDelegate5;

	private SwigDelegateOdGiBaseVectorizer_6 swigDelegate6;

	private SwigDelegateOdGiBaseVectorizer_7 swigDelegate7;

	private SwigDelegateOdGiBaseVectorizer_8 swigDelegate8;

	private SwigDelegateOdGiBaseVectorizer_9 swigDelegate9;

	private SwigDelegateOdGiBaseVectorizer_10 swigDelegate10;

	private SwigDelegateOdGiBaseVectorizer_11 swigDelegate11;

	private SwigDelegateOdGiBaseVectorizer_12 swigDelegate12;

	private SwigDelegateOdGiBaseVectorizer_13 swigDelegate13;

	private SwigDelegateOdGiBaseVectorizer_14 swigDelegate14;

	private SwigDelegateOdGiBaseVectorizer_15 swigDelegate15;

	private SwigDelegateOdGiBaseVectorizer_16 swigDelegate16;

	private SwigDelegateOdGiBaseVectorizer_17 swigDelegate17;

	private SwigDelegateOdGiBaseVectorizer_18 swigDelegate18;

	private SwigDelegateOdGiBaseVectorizer_19 swigDelegate19;

	private SwigDelegateOdGiBaseVectorizer_20 swigDelegate20;

	private SwigDelegateOdGiBaseVectorizer_21 swigDelegate21;

	private SwigDelegateOdGiBaseVectorizer_22 swigDelegate22;

	private SwigDelegateOdGiBaseVectorizer_23 swigDelegate23;

	private SwigDelegateOdGiBaseVectorizer_24 swigDelegate24;

	private SwigDelegateOdGiBaseVectorizer_25 swigDelegate25;

	private SwigDelegateOdGiBaseVectorizer_26 swigDelegate26;

	private SwigDelegateOdGiBaseVectorizer_27 swigDelegate27;

	private SwigDelegateOdGiBaseVectorizer_28 swigDelegate28;

	private SwigDelegateOdGiBaseVectorizer_29 swigDelegate29;

	private SwigDelegateOdGiBaseVectorizer_30 swigDelegate30;

	private SwigDelegateOdGiBaseVectorizer_31 swigDelegate31;

	private SwigDelegateOdGiBaseVectorizer_32 swigDelegate32;

	private SwigDelegateOdGiBaseVectorizer_33 swigDelegate33;

	private SwigDelegateOdGiBaseVectorizer_34 swigDelegate34;

	private SwigDelegateOdGiBaseVectorizer_35 swigDelegate35;

	private SwigDelegateOdGiBaseVectorizer_36 swigDelegate36;

	private SwigDelegateOdGiBaseVectorizer_37 swigDelegate37;

	private SwigDelegateOdGiBaseVectorizer_38 swigDelegate38;

	private SwigDelegateOdGiBaseVectorizer_39 swigDelegate39;

	private SwigDelegateOdGiBaseVectorizer_40 swigDelegate40;

	private SwigDelegateOdGiBaseVectorizer_41 swigDelegate41;

	private SwigDelegateOdGiBaseVectorizer_42 swigDelegate42;

	private SwigDelegateOdGiBaseVectorizer_43 swigDelegate43;

	private SwigDelegateOdGiBaseVectorizer_44 swigDelegate44;

	private SwigDelegateOdGiBaseVectorizer_45 swigDelegate45;

	private SwigDelegateOdGiBaseVectorizer_46 swigDelegate46;

	private SwigDelegateOdGiBaseVectorizer_47 swigDelegate47;

	private SwigDelegateOdGiBaseVectorizer_48 swigDelegate48;

	private SwigDelegateOdGiBaseVectorizer_49 swigDelegate49;

	private SwigDelegateOdGiBaseVectorizer_50 swigDelegate50;

	private SwigDelegateOdGiBaseVectorizer_51 swigDelegate51;

	private SwigDelegateOdGiBaseVectorizer_52 swigDelegate52;

	private SwigDelegateOdGiBaseVectorizer_53 swigDelegate53;

	private SwigDelegateOdGiBaseVectorizer_54 swigDelegate54;

	private SwigDelegateOdGiBaseVectorizer_55 swigDelegate55;

	private SwigDelegateOdGiBaseVectorizer_56 swigDelegate56;

	private SwigDelegateOdGiBaseVectorizer_57 swigDelegate57;

	private SwigDelegateOdGiBaseVectorizer_58 swigDelegate58;

	private SwigDelegateOdGiBaseVectorizer_59 swigDelegate59;

	private SwigDelegateOdGiBaseVectorizer_60 swigDelegate60;

	private SwigDelegateOdGiBaseVectorizer_61 swigDelegate61;

	private SwigDelegateOdGiBaseVectorizer_62 swigDelegate62;

	private SwigDelegateOdGiBaseVectorizer_63 swigDelegate63;

	private SwigDelegateOdGiBaseVectorizer_64 swigDelegate64;

	private SwigDelegateOdGiBaseVectorizer_65 swigDelegate65;

	private SwigDelegateOdGiBaseVectorizer_66 swigDelegate66;

	private SwigDelegateOdGiBaseVectorizer_67 swigDelegate67;

	private SwigDelegateOdGiBaseVectorizer_68 swigDelegate68;

	private SwigDelegateOdGiBaseVectorizer_69 swigDelegate69;

	private SwigDelegateOdGiBaseVectorizer_70 swigDelegate70;

	private SwigDelegateOdGiBaseVectorizer_71 swigDelegate71;

	private SwigDelegateOdGiBaseVectorizer_72 swigDelegate72;

	private SwigDelegateOdGiBaseVectorizer_73 swigDelegate73;

	private SwigDelegateOdGiBaseVectorizer_74 swigDelegate74;

	private SwigDelegateOdGiBaseVectorizer_75 swigDelegate75;

	private SwigDelegateOdGiBaseVectorizer_76 swigDelegate76;

	private SwigDelegateOdGiBaseVectorizer_77 swigDelegate77;

	private SwigDelegateOdGiBaseVectorizer_78 swigDelegate78;

	private SwigDelegateOdGiBaseVectorizer_79 swigDelegate79;

	private SwigDelegateOdGiBaseVectorizer_80 swigDelegate80;

	private SwigDelegateOdGiBaseVectorizer_81 swigDelegate81;

	private SwigDelegateOdGiBaseVectorizer_82 swigDelegate82;

	private SwigDelegateOdGiBaseVectorizer_83 swigDelegate83;

	private SwigDelegateOdGiBaseVectorizer_84 swigDelegate84;

	private SwigDelegateOdGiBaseVectorizer_85 swigDelegate85;

	private SwigDelegateOdGiBaseVectorizer_86 swigDelegate86;

	private SwigDelegateOdGiBaseVectorizer_87 swigDelegate87;

	private SwigDelegateOdGiBaseVectorizer_88 swigDelegate88;

	private SwigDelegateOdGiBaseVectorizer_89 swigDelegate89;

	private SwigDelegateOdGiBaseVectorizer_90 swigDelegate90;

	private SwigDelegateOdGiBaseVectorizer_91 swigDelegate91;

	private SwigDelegateOdGiBaseVectorizer_92 swigDelegate92;

	private SwigDelegateOdGiBaseVectorizer_93 swigDelegate93;

	private SwigDelegateOdGiBaseVectorizer_94 swigDelegate94;

	private SwigDelegateOdGiBaseVectorizer_95 swigDelegate95;

	private SwigDelegateOdGiBaseVectorizer_96 swigDelegate96;

	private SwigDelegateOdGiBaseVectorizer_97 swigDelegate97;

	private SwigDelegateOdGiBaseVectorizer_98 swigDelegate98;

	private SwigDelegateOdGiBaseVectorizer_99 swigDelegate99;

	private SwigDelegateOdGiBaseVectorizer_100 swigDelegate100;

	private SwigDelegateOdGiBaseVectorizer_101 swigDelegate101;

	private SwigDelegateOdGiBaseVectorizer_102 swigDelegate102;

	private SwigDelegateOdGiBaseVectorizer_103 swigDelegate103;

	private SwigDelegateOdGiBaseVectorizer_104 swigDelegate104;

	private SwigDelegateOdGiBaseVectorizer_105 swigDelegate105;

	private SwigDelegateOdGiBaseVectorizer_106 swigDelegate106;

	private SwigDelegateOdGiBaseVectorizer_107 swigDelegate107;

	private SwigDelegateOdGiBaseVectorizer_108 swigDelegate108;

	private SwigDelegateOdGiBaseVectorizer_109 swigDelegate109;

	private SwigDelegateOdGiBaseVectorizer_110 swigDelegate110;

	private SwigDelegateOdGiBaseVectorizer_111 swigDelegate111;

	private SwigDelegateOdGiBaseVectorizer_112 swigDelegate112;

	private SwigDelegateOdGiBaseVectorizer_113 swigDelegate113;

	private SwigDelegateOdGiBaseVectorizer_114 swigDelegate114;

	private SwigDelegateOdGiBaseVectorizer_115 swigDelegate115;

	private SwigDelegateOdGiBaseVectorizer_116 swigDelegate116;

	private SwigDelegateOdGiBaseVectorizer_117 swigDelegate117;

	private SwigDelegateOdGiBaseVectorizer_118 swigDelegate118;

	private SwigDelegateOdGiBaseVectorizer_119 swigDelegate119;

	private SwigDelegateOdGiBaseVectorizer_120 swigDelegate120;

	private SwigDelegateOdGiBaseVectorizer_121 swigDelegate121;

	private SwigDelegateOdGiBaseVectorizer_122 swigDelegate122;

	private SwigDelegateOdGiBaseVectorizer_123 swigDelegate123;

	private SwigDelegateOdGiBaseVectorizer_124 swigDelegate124;

	private SwigDelegateOdGiBaseVectorizer_125 swigDelegate125;

	private SwigDelegateOdGiBaseVectorizer_126 swigDelegate126;

	private SwigDelegateOdGiBaseVectorizer_127 swigDelegate127;

	private SwigDelegateOdGiBaseVectorizer_128 swigDelegate128;

	private SwigDelegateOdGiBaseVectorizer_129 swigDelegate129;

	private SwigDelegateOdGiBaseVectorizer_130 swigDelegate130;

	private SwigDelegateOdGiBaseVectorizer_131 swigDelegate131;

	private SwigDelegateOdGiBaseVectorizer_132 swigDelegate132;

	private SwigDelegateOdGiBaseVectorizer_133 swigDelegate133;

	private SwigDelegateOdGiBaseVectorizer_134 swigDelegate134;

	private SwigDelegateOdGiBaseVectorizer_135 swigDelegate135;

	private SwigDelegateOdGiBaseVectorizer_136 swigDelegate136;

	private SwigDelegateOdGiBaseVectorizer_137 swigDelegate137;

	private SwigDelegateOdGiBaseVectorizer_138 swigDelegate138;

	private SwigDelegateOdGiBaseVectorizer_139 swigDelegate139;

	private SwigDelegateOdGiBaseVectorizer_140 swigDelegate140;

	private SwigDelegateOdGiBaseVectorizer_141 swigDelegate141;

	private SwigDelegateOdGiBaseVectorizer_142 swigDelegate142;

	private SwigDelegateOdGiBaseVectorizer_143 swigDelegate143;

	private SwigDelegateOdGiBaseVectorizer_144 swigDelegate144;

	private SwigDelegateOdGiBaseVectorizer_145 swigDelegate145;

	private SwigDelegateOdGiBaseVectorizer_146 swigDelegate146;

	private SwigDelegateOdGiBaseVectorizer_147 swigDelegate147;

	private SwigDelegateOdGiBaseVectorizer_148 swigDelegate148;

	private SwigDelegateOdGiBaseVectorizer_149 swigDelegate149;

	private SwigDelegateOdGiBaseVectorizer_150 swigDelegate150;

	private SwigDelegateOdGiBaseVectorizer_151 swigDelegate151;

	private SwigDelegateOdGiBaseVectorizer_152 swigDelegate152;

	private SwigDelegateOdGiBaseVectorizer_153 swigDelegate153;

	private SwigDelegateOdGiBaseVectorizer_154 swigDelegate154;

	private SwigDelegateOdGiBaseVectorizer_155 swigDelegate155;

	private SwigDelegateOdGiBaseVectorizer_156 swigDelegate156;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(ushort) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGiFillType) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(LineWeight) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(PlotStyleNameType),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(PlotStyleNameType) };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGiMapper) };

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdCmTransparency) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(OdGiSubEntityTraits_ShadowFlags) };

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(OdGiSubEntityTraits_SelectionFlags) };

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[0];

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[0];

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[0];

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[0];

	private static Type[] swigMethodTypes38 = new Type[0];

	private static Type[] swigMethodTypes39 = new Type[0];

	private static Type[] swigMethodTypes40 = new Type[0];

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[0];

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[0];

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[0];

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(OdGiDgLinetypeModifiers) };

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdGiFill) };

	private static Type[] swigMethodTypes52 = new Type[0];

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(OdGiAuxiliaryData) };

	private static Type[] swigMethodTypes54 = new Type[0];

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdGiLineweightOverride) };

	private static Type[] swigMethodTypes56 = new Type[0];

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(OdGiPalette) };

	private static Type[] swigMethodTypes58 = new Type[0];

	private static Type[] swigMethodTypes59 = new Type[0];

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(OdGiContext) };

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes63 = new Type[0];

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes65 = new Type[0];

	private static Type[] swigMethodTypes66 = new Type[2]
	{
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes67 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes68 = new Type[0];

	private static Type[] swigMethodTypes69 = new Type[0];

	private static Type[] swigMethodTypes70 = new Type[0];

	private static Type[] swigMethodTypes71 = new Type[0];

	private static Type[] swigMethodTypes72 = new Type[0];

	private static Type[] swigMethodTypes73 = new Type[0];

	private static Type[] swigMethodTypes74 = new Type[2]
	{
		typeof(OdGiSubEntityTraitsData),
		typeof(OdGiSubEntityTraitsData)
	};

	private static Type[] swigMethodTypes75 = new Type[0];

	private static Type[] swigMethodTypes76 = new Type[0];

	private static Type[] swigMethodTypes77 = new Type[2]
	{
		typeof(OdGiSubEntityTraitsData),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes78 = new Type[1] { typeof(OdGiSubEntityTraitsData) };

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes80 = new Type[0];

	private static Type[] swigMethodTypes81 = new Type[0];

	private static Type[] swigMethodTypes82 = new Type[0];

	private static Type[] swigMethodTypes83 = new Type[0];

	private static Type[] swigMethodTypes84 = new Type[0];

	private static Type[] swigMethodTypes85 = new Type[2]
	{
		typeof(OdGiDeviationType),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes86 = new Type[0];

	private static Type[] swigMethodTypes87 = new Type[0];

	private static Type[] swigMethodTypes88 = new Type[0];

	private static Type[] swigMethodTypes89 = new Type[0];

	private static Type[] swigMethodTypes90 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes91 = new Type[0];

	private static Type[] swigMethodTypes92 = new Type[0];

	private static Type[] swigMethodTypes93 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(double),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes94 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes95 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(double),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(OdGiArcType)
	};

	private static Type[] swigMethodTypes96 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(double),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double)
	};

	private static Type[] swigMethodTypes97 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGiArcType)
	};

	private static Type[] swigMethodTypes98 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes99 = new Type[3]
	{
		typeof(OdGePoint3d[]),
		typeof(OdGeVector3d),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes100 = new Type[2]
	{
		typeof(OdGePoint3d[]),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes101 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes102 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes103 = new Type[2]
	{
		typeof(OdGePoint3d[]),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes104 = new Type[3]
	{
		typeof(OdGiPolyline),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes105 = new Type[2]
	{
		typeof(OdGiPolyline),
		typeof(uint)
	};

	private static Type[] swigMethodTypes106 = new Type[1] { typeof(OdGiPolyline) };

	private static Type[] swigMethodTypes107 = new Type[7]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(string)
	};

	private static Type[] swigMethodTypes108 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(string),
		typeof(bool),
		typeof(OdGiTextStyle)
	};

	private static Type[] swigMethodTypes109 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes110 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes111 = new Type[1] { typeof(OdGeNurbCurve3d) };

	private static Type[] swigMethodTypes112 = new Type[3]
	{
		typeof(OdGeEllipArc3d),
		typeof(OdGePoint3d[]),
		typeof(OdGiArcType)
	};

	private static Type[] swigMethodTypes113 = new Type[2]
	{
		typeof(OdGeEllipArc3d),
		typeof(OdGePoint3d[])
	};

	private static Type[] swigMethodTypes114 = new Type[1] { typeof(OdGeEllipArc3d) };

	private static Type[] swigMethodTypes115 = new Type[1] { typeof(MeshData) };

	private static Type[] swigMethodTypes116 = new Type[1] { typeof(ShellData) };

	private static Type[] swigMethodTypes117 = new Type[5]
	{
		typeof(OdGiImageBGRA32),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiRasterImage_TransparencyMode)
	};

	private static Type[] swigMethodTypes118 = new Type[4]
	{
		typeof(OdGiImageBGRA32),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes119 = new Type[1] { typeof(OdGeCurve2dArray) };

	private static Type[] swigMethodTypes120 = new Type[6]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor),
		typeof(OdCmTransparency),
		typeof(OdGeVector3d),
		typeof(IntPtr[]),
		typeof(int)
	};

	private static Type[] swigMethodTypes121 = new Type[3]
	{
		typeof(int),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes122 = new Type[1] { typeof(OdGiPointCloud) };

	private static Type[] swigMethodTypes123 = new Type[1] { typeof(OdGiClipBoundary) };

	private static Type[] swigMethodTypes124 = new Type[2]
	{
		typeof(OdGiClipBoundary),
		typeof(OdGiAbstractClipBoundary)
	};

	private static Type[] swigMethodTypes125 = new Type[0];

	private static Type[] swigMethodTypes126 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes127 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes128 = new Type[0];

	private static Type[] swigMethodTypes129 = new Type[0];

	private static Type[] swigMethodTypes130 = new Type[0];

	private static Type[] swigMethodTypes131 = new Type[2]
	{
		typeof(OdGiPositionTransformBehavior),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes132 = new Type[2]
	{
		typeof(OdGiScaleTransformBehavior),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes133 = new Type[1] { typeof(OdGiOrientationTransformBehavior) };

	private static Type[] swigMethodTypes134 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes135 = new Type[0];

	private static Type[] swigMethodTypes136 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes137 = new Type[2]
	{
		typeof(uint),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes138 = new Type[9]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiRasterImage),
		typeof(OdGePoint2d[]),
		typeof(bool),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes139 = new Type[8]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiRasterImage),
		typeof(OdGePoint2d[]),
		typeof(bool),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes140 = new Type[7]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiRasterImage),
		typeof(OdGePoint2d[]),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes141 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiRasterImage),
		typeof(OdGePoint2d[]),
		typeof(bool)
	};

	private static Type[] swigMethodTypes142 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiRasterImage),
		typeof(OdGePoint2d[])
	};

	private static Type[] swigMethodTypes143 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiMetafile),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes144 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiMetafile),
		typeof(bool)
	};

	private static Type[] swigMethodTypes145 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiMetafile)
	};

	private static Type[] swigMethodTypes146 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes147 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes148 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes149 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes150 = new Type[0];

	private static Type[] swigMethodTypes151 = new Type[0];

	private static Type[] swigMethodTypes152 = new Type[0];

	private static Type[] swigMethodTypes153 = new Type[0];

	private static Type[] swigMethodTypes154 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes155 = new Type[0];

	private static Type[] swigMethodTypes156 = new Type[0];

	public OdGiDrawableDesc m_pDrawableDesc
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_m_pDrawableDesc_get(swigCPtr);
			OdGiDrawableDesc result = ((intPtr == IntPtr.Zero) ? null : new OdGiDrawableDesc(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_m_pDrawableDesc_set(swigCPtr, OdGiDrawableDesc.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_nDrawableAttributes
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_m_nDrawableAttributes_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_m_nDrawableAttributes_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiBaseVectorizer(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiBaseVectorizer obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiBaseVectorizer()
	{
		Dispose(disposing: false);
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdGiConveyorContext.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_OdGiConveyorContext_GetInterfaceCPtr(swigCPtr.Handle));
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdGiDeviation.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_OdGiDeviation_GetInterfaceCPtr(swigCPtr.Handle));
	}

	protected virtual OdDbStub switchLayer(OdDbStub layerId)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("switchLayer", swigMethodTypes62) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_switchLayerSwigExplicitOdGiBaseVectorizer(swigCPtr, OdDbStub.getCPtr(layerId)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_switchLayer(swigCPtr, OdDbStub.getCPtr(layerId)));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual OdGiLayerTraitsData effectiveLayerTraits()
	{
		OdGiLayerTraitsData result = new OdGiLayerTraitsData(SwigDerivedClassHasMethod("effectiveLayerTraits", swigMethodTypes63) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_effectiveLayerTraitsSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_effectiveLayerTraits(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual bool layerVisible(OdDbStub layerId)
	{
		bool result = (SwigDerivedClassHasMethod("layerVisible", swigMethodTypes64) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_layerVisibleSwigExplicitOdGiBaseVectorizer(swigCPtr, OdDbStub.getCPtr(layerId)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_layerVisible(swigCPtr, OdDbStub.getCPtr(layerId)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEntityTraitsDataChanged(int bit)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_isEntityTraitsDataChanged__SWIG_0(swigCPtr, bit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEntityTraitsDataChanged()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_isEntityTraitsDataChanged__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEntityTraitsDataChanged()
	{
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes65))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEntityTraitsDataChangedSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEntityTraitsDataChanged__SWIG_0(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEntityTraitsDataChanged(int bit, bool value)
	{
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes66))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEntityTraitsDataChangedSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, bit, value);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEntityTraitsDataChanged__SWIG_1(swigCPtr, bit, value);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEntityTraitsDataChanged(int bit)
	{
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes67))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEntityTraitsDataChangedSwigExplicitOdGiBaseVectorizer__SWIG_2(swigCPtr, bit);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEntityTraitsDataChanged__SWIG_2(swigCPtr, bit);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearEntityTraitsDataChanged()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_clearEntityTraitsDataChanged(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool effectivelyVisible()
	{
		bool result = (SwigDerivedClassHasMethod("effectivelyVisible", swigMethodTypes68) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_effectivelyVisibleSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_effectivelyVisible(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiContext giContext()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(SwigDerivedClassHasMethod("giContext", swigMethodTypes69) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_giContextSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_giContext(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiDrawableDesc currentDrawableDesc()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("currentDrawableDesc", swigMethodTypes70) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_currentDrawableDescSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_currentDrawableDesc(swigCPtr));
		OdGiDrawableDesc result = ((intPtr == IntPtr.Zero) ? null : new OdGiDrawableDesc(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDrawable currentDrawable()
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(SwigDerivedClassHasMethod("currentDrawable", swigMethodTypes71) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_currentDrawableSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_currentDrawable(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiViewport giViewport()
	{
		OdGiViewport rXObject = Helpers.GetRXObject<OdGiViewport>(SwigDerivedClassHasMethod("giViewport", swigMethodTypes72) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_giViewportSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_giViewport(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsView gsView()
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(SwigDerivedClassHasMethod("gsView", swigMethodTypes73) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_gsViewSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_gsView(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiDrawableDesc drawableDesc()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_drawableDesc(swigCPtr);
		OdGiDrawableDesc result = ((intPtr == IntPtr.Zero) ? null : new OdGiDrawableDesc(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual void affectTraits(OdGiSubEntityTraitsData pSource, OdGiSubEntityTraitsData destination)
	{
		if (SwigDerivedClassHasMethod("affectTraits", swigMethodTypes74))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_affectTraitsSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGiSubEntityTraitsData.getCPtr(pSource), OdGiSubEntityTraitsData.getCPtr(destination));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_affectTraits(swigCPtr, OdGiSubEntityTraitsData.getCPtr(pSource), OdGiSubEntityTraitsData.getCPtr(destination));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual double linetypeGenerationCriteria()
	{
		double result = (SwigDerivedClassHasMethod("linetypeGenerationCriteria", swigMethodTypes75) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_linetypeGenerationCriteriaSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_linetypeGenerationCriteria(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiSubEntityTraitsData effectiveTraits()
	{
		OdGiSubEntityTraitsData result = new OdGiSubEntityTraitsData(SwigDerivedClassHasMethod("effectiveTraits", swigMethodTypes76) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_effectiveTraitsSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_effectiveTraits(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEffectiveTraits(OdGiSubEntityTraitsData traits, OdGeVector3d fillNormal)
	{
		if (SwigDerivedClassHasMethod("setEffectiveTraits", swigMethodTypes77))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEffectiveTraitsSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, OdGiSubEntityTraitsData.getCPtr(traits), OdGeVector3d.getCPtr(fillNormal));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEffectiveTraits__SWIG_0(swigCPtr, OdGiSubEntityTraitsData.getCPtr(traits), OdGeVector3d.getCPtr(fillNormal));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEffectiveTraits(OdGiSubEntityTraitsData traits)
	{
		if (SwigDerivedClassHasMethod("setEffectiveTraits", swigMethodTypes78))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEffectiveTraitsSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, OdGiSubEntityTraitsData.getCPtr(traits));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEffectiveTraits__SWIG_1(swigCPtr, OdGiSubEntityTraitsData.getCPtr(traits));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void selectionMarkerOnChange(IntPtr nSelectionMarker)
	{
		if (SwigDerivedClassHasMethod("selectionMarkerOnChange", swigMethodTypes79))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_selectionMarkerOnChangeSwigExplicitOdGiBaseVectorizer(swigCPtr, nSelectionMarker);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_selectionMarkerOnChange(swigCPtr, nSelectionMarker);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual bool updateExtentsOnly()
	{
		bool result = (SwigDerivedClassHasMethod("updateExtentsOnly", swigMethodTypes80) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_updateExtentsOnlySwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_updateExtentsOnly(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiBaseVectorizer()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiBaseVectorizer(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiBaseVectorizer) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_isASwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass pProtocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_queryXSwigExplicitOdGiBaseVectorizer(swigCPtr, OdRxClass.getCPtr(pProtocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_queryX(swigCPtr, OdRxClass.getCPtr(pProtocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiConveyorOutput output()
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(SwigDerivedClassHasMethod("output", swigMethodTypes81) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_outputSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_output(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEyeToOutputTransform(OdGeMatrix3d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEyeToOutputTransform(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d eyeToOutputTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_eyeToOutputTransform__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void eyeToOutputTransform(OdGeMatrix3d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_eyeToOutputTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiConveyorContext drawContext()
	{
		OdGiConveyorContext_Internal result = new OdGiConveyorContext_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_drawContext__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void beginViewVectorization()
	{
		if (SwigDerivedClassHasMethod("beginViewVectorization", swigMethodTypes82))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_beginViewVectorizationSwigExplicitOdGiBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_beginViewVectorization(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endViewVectorization()
	{
		if (SwigDerivedClassHasMethod("endViewVectorization", swigMethodTypes83))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_endViewVectorizationSwigExplicitOdGiBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_endViewVectorization(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setTrueColor(OdCmEntityColor trueColor)
	{
		if (SwigDerivedClassHasMethod("setTrueColor", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setTrueColorSwigExplicitOdGiBaseVectorizer(swigCPtr, OdCmEntityColor.getCPtr(trueColor));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setTrueColor(swigCPtr, OdCmEntityColor.getCPtr(trueColor));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setColor(ushort color)
	{
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setColorSwigExplicitOdGiBaseVectorizer(swigCPtr, color);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setColor(swigCPtr, color);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLayer(OdDbStub layerId)
	{
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setLayerSwigExplicitOdGiBaseVectorizer(swigCPtr, OdDbStub.getCPtr(layerId));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setLayer(swigCPtr, OdDbStub.getCPtr(layerId));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineType(OdDbStub lineTypeId)
	{
		if (SwigDerivedClassHasMethod("setLineType", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setLineTypeSwigExplicitOdGiBaseVectorizer(swigCPtr, OdDbStub.getCPtr(lineTypeId));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setLineType(swigCPtr, OdDbStub.getCPtr(lineTypeId));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setFillType(OdGiFillType fillType)
	{
		if (SwigDerivedClassHasMethod("setFillType", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setFillTypeSwigExplicitOdGiBaseVectorizer(swigCPtr, (int)fillType);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setFillType(swigCPtr, (int)fillType);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineWeight(LineWeight lineWeight)
	{
		if (SwigDerivedClassHasMethod("setLineWeight", swigMethodTypes10))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setLineWeightSwigExplicitOdGiBaseVectorizer(swigCPtr, (int)lineWeight);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setLineWeight(swigCPtr, (int)lineWeight);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setThickness(double thickness)
	{
		if (SwigDerivedClassHasMethod("setThickness", swigMethodTypes13))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setThicknessSwigExplicitOdGiBaseVectorizer(swigCPtr, thickness);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setThickness(swigCPtr, thickness);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setPlotStyleName(PlotStyleNameType plotStyleNameType, OdDbStub pPlotStyleNameId)
	{
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes14))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setPlotStyleNameSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, (int)plotStyleNameType, OdDbStub.getCPtr(pPlotStyleNameId));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setPlotStyleName__SWIG_0(swigCPtr, (int)plotStyleNameType, OdDbStub.getCPtr(pPlotStyleNameId));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setPlotStyleName(PlotStyleNameType plotStyleNameType)
	{
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes15))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setPlotStyleNameSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, (int)plotStyleNameType);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setPlotStyleName__SWIG_1(swigCPtr, (int)plotStyleNameType);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSelectionMarker(IntPtr selectionMarker)
	{
		if (SwigDerivedClassHasMethod("setSelectionMarker", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setSelectionMarkerSwigExplicitOdGiBaseVectorizer(swigCPtr, selectionMarker);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setSelectionMarker(swigCPtr, selectionMarker);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setMaterial(OdDbStub pMaterialId)
	{
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes16))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setMaterialSwigExplicitOdGiBaseVectorizer(swigCPtr, OdDbStub.getCPtr(pMaterialId));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setMaterial(swigCPtr, OdDbStub.getCPtr(pMaterialId));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setMapper(OdGiMapper pMapper)
	{
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes17))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setMapperSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGiMapper.getCPtr(pMapper));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setMapper(swigCPtr, OdGiMapper.getCPtr(pMapper));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setVisualStyle(OdDbStub pVisualStyleId)
	{
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes18))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setVisualStyleSwigExplicitOdGiBaseVectorizer(swigCPtr, OdDbStub.getCPtr(pVisualStyleId));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setVisualStyle(swigCPtr, OdDbStub.getCPtr(pVisualStyleId));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setTransparency(OdCmTransparency transparency)
	{
		if (SwigDerivedClassHasMethod("setTransparency", swigMethodTypes19))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setTransparencySwigExplicitOdGiBaseVectorizer(swigCPtr, OdCmTransparency.getCPtr(transparency));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setTransparency(swigCPtr, OdCmTransparency.getCPtr(transparency));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setDrawFlags(uint drawFlags)
	{
		if (SwigDerivedClassHasMethod("setDrawFlags", swigMethodTypes20))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setDrawFlagsSwigExplicitOdGiBaseVectorizer(swigCPtr, drawFlags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setDrawFlags(swigCPtr, drawFlags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLockFlags(uint lockFlags)
	{
		if (SwigDerivedClassHasMethod("setLockFlags", swigMethodTypes21))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setLockFlagsSwigExplicitOdGiBaseVectorizer(swigCPtr, lockFlags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setLockFlags(swigCPtr, lockFlags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSelectionGeom(bool bSelectionFlag)
	{
		if (SwigDerivedClassHasMethod("setSelectionGeom", swigMethodTypes22))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setSelectionGeomSwigExplicitOdGiBaseVectorizer(swigCPtr, bSelectionFlag);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setSelectionGeom(swigCPtr, bSelectionFlag);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setShadowFlags(OdGiSubEntityTraits_ShadowFlags shadowFlags)
	{
		if (SwigDerivedClassHasMethod("setShadowFlags", swigMethodTypes23))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setShadowFlagsSwigExplicitOdGiBaseVectorizer(swigCPtr, (int)shadowFlags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setShadowFlags(swigCPtr, (int)shadowFlags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSectionable(bool bSectionableFlag)
	{
		if (SwigDerivedClassHasMethod("setSectionable", swigMethodTypes24))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setSectionableSwigExplicitOdGiBaseVectorizer(swigCPtr, bSectionableFlag);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setSectionable(swigCPtr, bSectionableFlag);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSelectionFlags(OdGiSubEntityTraits_SelectionFlags selectionFlags)
	{
		if (SwigDerivedClassHasMethod("setSelectionFlags", swigMethodTypes25))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setSelectionFlagsSwigExplicitOdGiBaseVectorizer(swigCPtr, (int)selectionFlags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setSelectionFlags(swigCPtr, (int)selectionFlags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSecondaryTrueColor(OdCmEntityColor color)
	{
		if (SwigDerivedClassHasMethod("setSecondaryTrueColor", swigMethodTypes47))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setSecondaryTrueColorSwigExplicitOdGiBaseVectorizer(swigCPtr, OdCmEntityColor.getCPtr(color));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setSecondaryTrueColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineStyleModifiers(OdGiDgLinetypeModifiers pLSMod)
	{
		if (SwigDerivedClassHasMethod("setLineStyleModifiers", swigMethodTypes49))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setLineStyleModifiersSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGiDgLinetypeModifiers.getCPtr(pLSMod));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setLineStyleModifiers(swigCPtr, OdGiDgLinetypeModifiers.getCPtr(pLSMod));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setFill(OdGiFill pFill)
	{
		if (SwigDerivedClassHasMethod("setFill", swigMethodTypes51))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setFillSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGiFill.getCPtr(pFill));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setFill(swigCPtr, OdGiFill.getCPtr(pFill));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setAuxData(OdGiAuxiliaryData pAuxData)
	{
		if (SwigDerivedClassHasMethod("setAuxData", swigMethodTypes53))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setAuxDataSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGiAuxiliaryData.getCPtr(pAuxData));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setAuxData(swigCPtr, OdGiAuxiliaryData.getCPtr(pAuxData));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdGiContext context()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_context(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual bool regenAbort()
	{
		bool result = (SwigDerivedClassHasMethod("regenAbort", swigMethodTypes84) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_regenAbortSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_regenAbort(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiSubEntityTraits subEntityTraits()
	{
		OdGiSubEntityTraits rXObject = Helpers.GetRXObject<OdGiSubEntityTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_subEntityTraits(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual double deviation(OdGiDeviationType deviationType, OdGePoint3d pointOnCurve)
	{
		double result = (SwigDerivedClassHasMethod("deviation", swigMethodTypes85) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_deviationSwigExplicitOdGiBaseVectorizer(swigCPtr, (int)deviationType, OdGePoint3d.getCPtr(pointOnCurve)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_deviation(swigCPtr, (int)deviationType, OdGePoint3d.getCPtr(pointOnCurve)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiRegenType regenType()
	{
		int result = (SwigDerivedClassHasMethod("regenType", swigMethodTypes86) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_regenTypeSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_regenType(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRegenType)result;
	}

	public new virtual uint numberOfIsolines()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_numberOfIsolines(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiGeometry rawGeometry()
	{
		OdGiGeometry rXObject = Helpers.GetRXObject<OdGiGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rawGeometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual bool isDragging()
	{
		bool result = (SwigDerivedClassHasMethod("isDragging", swigMethodTypes87) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_isDraggingSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_isDragging(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint drawContextFlags()
	{
		uint result = (SwigDerivedClassHasMethod("drawContextFlags", swigMethodTypes88) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_drawContextFlagsSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_drawContextFlags(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDrawContextFlags(uint flags, bool bFlag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setDrawContextFlags(swigCPtr, flags, bFlag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint sequenceNumber()
	{
		uint result = (SwigDerivedClassHasMethod("sequenceNumber", swigMethodTypes89) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_sequenceNumberSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_sequenceNumber(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isValidId(uint viewportId)
	{
		bool result = (SwigDerivedClassHasMethod("isValidId", swigMethodTypes90) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_isValidIdSwigExplicitOdGiBaseVectorizer(swigCPtr, viewportId) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_isValidId(swigCPtr, viewportId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub viewportObjectId()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("viewportObjectId", swigMethodTypes91) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_viewportObjectIdSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_viewportObjectId(swigCPtr));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiViewport viewport()
	{
		OdGiViewport rXObject = Helpers.GetRXObject<OdGiViewport>(SwigDerivedClassHasMethod("viewport", swigMethodTypes92) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_viewportSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_viewport(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual void circle(OdGePoint3d center, double radius, OdGeVector3d normal)
	{
		if (SwigDerivedClassHasMethod("circle", swigMethodTypes93))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_circleSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_circle__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void circle(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint)
	{
		if (SwigDerivedClassHasMethod("circle", swigMethodTypes94))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_circleSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_circle__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void circularArc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, double sweepAngle, OdGiArcType arcType)
	{
		if (SwigDerivedClassHasMethod("circularArc", swigMethodTypes95))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_circularArcSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle, (int)arcType);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_circularArc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle, (int)arcType);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circularArc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, double sweepAngle)
	{
		if (SwigDerivedClassHasMethod("circularArc", swigMethodTypes96))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_circularArcSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_circularArc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void circularArc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint, OdGiArcType arcType)
	{
		if (SwigDerivedClassHasMethod("circularArc", swigMethodTypes97))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_circularArcSwigExplicitOdGiBaseVectorizer__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint), (int)arcType);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_circularArc__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint), (int)arcType);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circularArc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint)
	{
		if (SwigDerivedClassHasMethod("circularArc", swigMethodTypes98))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_circularArcSwigExplicitOdGiBaseVectorizer__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_circularArc__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void polyline(OdGePoint3d[] numVertices, OdGeVector3d pNormal, IntPtr baseSubEntMarker)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			if (SwigDerivedClassHasMethod("polyline", swigMethodTypes99))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polylineSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal), baseSubEntMarker);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polyline__SWIG_0(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal), baseSubEntMarker);
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

	public virtual void polyline(OdGePoint3d[] numVertices, OdGeVector3d pNormal)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			if (SwigDerivedClassHasMethod("polyline", swigMethodTypes100))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polylineSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polyline__SWIG_1(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal));
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

	public virtual void polyline(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			if (SwigDerivedClassHasMethod("polyline", swigMethodTypes101))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polylineSwigExplicitOdGiBaseVectorizer__SWIG_2(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polyline__SWIG_2(swigCPtr, intPtr);
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

	public new virtual void polygon(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			if (SwigDerivedClassHasMethod("polygon", swigMethodTypes102))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polygonSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polygon__SWIG_0(swigCPtr, intPtr);
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

	public new virtual void polygon(OdGePoint3d[] numVertices, OdGeVector3d pNormal)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			if (SwigDerivedClassHasMethod("polygon", swigMethodTypes103))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polygonSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polygon__SWIG_1(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal));
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

	public new virtual void pline(OdGiPolyline polyline, uint fromIndex, uint numSegs)
	{
		if (SwigDerivedClassHasMethod("pline", swigMethodTypes104))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_plineSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, OdGiPolyline.getCPtr(polyline), fromIndex, numSegs);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pline__SWIG_0(swigCPtr, OdGiPolyline.getCPtr(polyline), fromIndex, numSegs);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pline(OdGiPolyline polyline, uint fromIndex)
	{
		if (SwigDerivedClassHasMethod("pline", swigMethodTypes105))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_plineSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, OdGiPolyline.getCPtr(polyline), fromIndex);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pline__SWIG_1(swigCPtr, OdGiPolyline.getCPtr(polyline), fromIndex);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pline(OdGiPolyline polyline)
	{
		if (SwigDerivedClassHasMethod("pline", swigMethodTypes106))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_plineSwigExplicitOdGiBaseVectorizer__SWIG_2(swigCPtr, OdGiPolyline.getCPtr(polyline));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pline__SWIG_2(swigCPtr, OdGiPolyline.getCPtr(polyline));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void shape(OdGePoint3d position, OdGeVector3d normal, OdGeVector3d direction, int shapeNumber, OdGiTextStyle pTextStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_shape(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), shapeNumber, OdGiTextStyle.getCPtr(pTextStyle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void text(OdGePoint3d position, OdGeVector3d normal, OdGeVector3d direction, double height, double width, double oblique, string msg)
	{
		if (SwigDerivedClassHasMethod("text", swigMethodTypes107))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_textSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), height, width, oblique, msg);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_text__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), height, width, oblique, msg);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void text(OdGePoint3d position, OdGeVector3d normal, OdGeVector3d direction, string msg, bool raw, OdGiTextStyle pTextStyle)
	{
		if (SwigDerivedClassHasMethod("text", swigMethodTypes108))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_textSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), msg, raw, OdGiTextStyle.getCPtr(pTextStyle));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_text__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), msg, raw, OdGiTextStyle.getCPtr(pTextStyle));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void xline(OdGePoint3d firstPoint, OdGePoint3d secondPoint)
	{
		if (SwigDerivedClassHasMethod("xline", swigMethodTypes109))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_xlineSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_xline(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void ray(OdGePoint3d basePoint, OdGePoint3d throughPoint)
	{
		if (SwigDerivedClassHasMethod("ray", swigMethodTypes110))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_raySwigExplicitOdGiBaseVectorizer(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGePoint3d.getCPtr(throughPoint));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_ray(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGePoint3d.getCPtr(throughPoint));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void nurbs(OdGeNurbCurve3d nurbsCurve)
	{
		if (SwigDerivedClassHasMethod("nurbs", swigMethodTypes111))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_nurbsSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGeNurbCurve3d.getCPtr(nurbsCurve));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_nurbs(swigCPtr, OdGeNurbCurve3d.getCPtr(nurbsCurve));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void EllipArc(OdGeEllipArc3d ellipArc, OdGePoint3d[] endPointsOverrides, OdGiArcType arcType)
	{
		IntPtr intPtr = Helpers.MarshalPointPair(endPointsOverrides);
		try
		{
			if (SwigDerivedClassHasMethod("EllipArc", swigMethodTypes112))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_EllipArcSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc), intPtr, (int)arcType);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_EllipArc(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc), intPtr, (int)arcType);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
		}
	}

	public virtual void ellipticArc(OdGeEllipArc3d ellipArc, OdGePoint3d[] endPointsOverrides)
	{
		IntPtr intPtr = Helpers.MarshalPointPair(endPointsOverrides);
		try
		{
			if (SwigDerivedClassHasMethod("ellipticArc", swigMethodTypes113))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_ellipticArcSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc), intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_ellipticArc__SWIG_0(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc), intPtr);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
		}
	}

	public virtual void ellipticArc(OdGeEllipArc3d ellipArc)
	{
		if (SwigDerivedClassHasMethod("ellipticArc", swigMethodTypes114))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_ellipticArcSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_ellipticArc__SWIG_1(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void mesh(MeshData numRows)
	{
		IntPtr intPtr = Helpers.MarshalMeshData(numRows);
		try
		{
			if (SwigDerivedClassHasMethod("mesh", swigMethodTypes115))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_meshSwigExplicitOdGiBaseVectorizer(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_mesh(swigCPtr, intPtr);
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

	public new virtual void shell(ShellData numVertices)
	{
		IntPtr intPtr = Helpers.MarshalShellData(numVertices);
		try
		{
			if (SwigDerivedClassHasMethod("shell", swigMethodTypes116))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_shellSwigExplicitOdGiBaseVectorizer(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_shell(swigCPtr, intPtr);
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

	public virtual void image(OdGiImageBGRA32 img, OdGePoint3d origin, OdGeVector3d uVec, OdGeVector3d vVec, OdGiRasterImage_TransparencyMode trpMode)
	{
		if (SwigDerivedClassHasMethod("image", swigMethodTypes117))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_imageSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, OdGiImageBGRA32.getCPtr(img), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uVec), OdGeVector3d.getCPtr(vVec), (int)trpMode);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_image__SWIG_0(swigCPtr, OdGiImageBGRA32.getCPtr(img), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uVec), OdGeVector3d.getCPtr(vVec), (int)trpMode);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void image(OdGiImageBGRA32 img, OdGePoint3d origin, OdGeVector3d uVec, OdGeVector3d vVec)
	{
		if (SwigDerivedClassHasMethod("image", swigMethodTypes118))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_imageSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, OdGiImageBGRA32.getCPtr(img), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uVec), OdGeVector3d.getCPtr(vVec));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_image__SWIG_1(swigCPtr, OdGiImageBGRA32.getCPtr(img), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uVec), OdGeVector3d.getCPtr(vVec));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void edge(OdGeCurve2dArray edges)
	{
		if (SwigDerivedClassHasMethod("edge", swigMethodTypes119))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_edgeSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGeCurve2dArray.getCPtr(edges));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_edge(swigCPtr, OdGeCurve2dArray.getCPtr(edges));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polypoint(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, IntPtr[] pSubEntMarkers, int nPointSize)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes120))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polypointSwigExplicitOdGiBaseVectorizer(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers), nPointSize);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polypoint(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers), nPointSize);
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

	public virtual void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes, OdCmEntityColor pFillColors, OdCmTransparency pFillTransparencies)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polyPolygon__SWIG_0(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors), ref pOutlinePsLinetypes, OdCmEntityColor.getCPtr(pFillColors), OdCmTransparency.getCPtr(pFillTransparencies));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes, OdCmEntityColor pFillColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polyPolygon__SWIG_1(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors), ref pOutlinePsLinetypes, OdCmEntityColor.getCPtr(pFillColors));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polyPolygon__SWIG_2(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors), ref pOutlinePsLinetypes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polyPolygon__SWIG_3(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polyPolygon__SWIG_4(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rowOfDots(int numPoints, OdGePoint3d startPoint, OdGeVector3d dirToNextPoint)
	{
		if (SwigDerivedClassHasMethod("rowOfDots", swigMethodTypes121))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rowOfDotsSwigExplicitOdGiBaseVectorizer(swigCPtr, numPoints, OdGePoint3d.getCPtr(startPoint), OdGeVector3d.getCPtr(dirToNextPoint));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rowOfDots(swigCPtr, numPoints, OdGePoint3d.getCPtr(startPoint), OdGeVector3d.getCPtr(dirToNextPoint));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pointCloud(OdGiPointCloud pCloud)
	{
		if (SwigDerivedClassHasMethod("pointCloud", swigMethodTypes122))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pointCloudSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGiPointCloud.getCPtr(pCloud));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pointCloud(swigCPtr, OdGiPointCloud.getCPtr(pCloud));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void pushClipBoundary(OdGiClipBoundary pBoundary)
	{
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes123))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushClipBoundarySwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushClipBoundary__SWIG_0(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipBoundary(OdGiClipBoundary pBoundary, OdGiAbstractClipBoundary pClipInfo)
	{
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes124))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushClipBoundarySwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushClipBoundary__SWIG_1(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void drawClipBoundary(OdGiClipBoundary pBoundary, OdGiAbstractClipBoundary pClipInfo)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_drawClipBoundary(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void popClipBoundary()
	{
		if (SwigDerivedClassHasMethod("popClipBoundary", swigMethodTypes125))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_popClipBoundarySwigExplicitOdGiBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_popClipBoundary(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isClipping()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_isClipping(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void pushModelTransform(OdGeMatrix3d xfm)
	{
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes126))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushModelTransformSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushModelTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void pushModelTransform(OdGeVector3d normal)
	{
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes127))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushModelTransformSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, OdGeVector3d.getCPtr(normal));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushModelTransform__SWIG_1(swigCPtr, OdGeVector3d.getCPtr(normal));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void popModelTransform()
	{
		if (SwigDerivedClassHasMethod("popModelTransform", swigMethodTypes128))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_popModelTransformSwigExplicitOdGiBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_popModelTransform(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdGeMatrix3d getModelToWorldTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("getModelToWorldTransform", swigMethodTypes129) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_getModelToWorldTransformSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_getModelToWorldTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGeMatrix3d getWorldToModelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("getWorldToModelTransform", swigMethodTypes130) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_getWorldToModelTransformSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_getWorldToModelTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d pushPositionTransform(OdGiPositionTransformBehavior behavior, OdGePoint3d pos)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("pushPositionTransform", swigMethodTypes131) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushPositionTransformSwigExplicitOdGiBaseVectorizer(swigCPtr, (int)behavior, OdGePoint3d.getCPtr(pos)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushPositionTransform(swigCPtr, (int)behavior, OdGePoint3d.getCPtr(pos)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d pushScaleTransform(OdGiScaleTransformBehavior behavior, OdGePoint3d scale)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("pushScaleTransform", swigMethodTypes132) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushScaleTransformSwigExplicitOdGiBaseVectorizer(swigCPtr, (int)behavior, OdGePoint3d.getCPtr(scale)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushScaleTransform(swigCPtr, (int)behavior, OdGePoint3d.getCPtr(scale)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d pushOrientationTransform(OdGiOrientationTransformBehavior behavior)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("pushOrientationTransform", swigMethodTypes133) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushOrientationTransformSwigExplicitOdGiBaseVectorizer(swigCPtr, (int)behavior) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushOrientationTransform(swigCPtr, (int)behavior), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isXrefOverride()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_isXrefOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setXrefOverride(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setXrefOverride(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void draw(OdGiDrawable pDrawable)
	{
		if (SwigDerivedClassHasMethod("draw", swigMethodTypes134))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_drawSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGiDrawable.getCPtr(pDrawable));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_draw(swigCPtr, OdGiDrawable.getCPtr(pDrawable));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdGiPathNode currentGiPath()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("currentGiPath", swigMethodTypes135) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_currentGiPathSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_currentGiPath(swigCPtr));
		OdGiPathNode result = ((intPtr == IntPtr.Zero) ? null : new OdGiPathNode(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint setAttributes(OdGiDrawable pDrawable)
	{
		uint result = (SwigDerivedClassHasMethod("setAttributes", swigMethodTypes136) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setAttributesSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGiDrawable.getCPtr(pDrawable)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setAttributes(swigCPtr, OdGiDrawable.getCPtr(pDrawable)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint drawableAttributes()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_drawableAttributes(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool needDraw(uint drawableFlags)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_needDraw(swigCPtr, drawableFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool doDraw(uint drawableFlags, OdGiDrawable pDrawable)
	{
		bool result = (SwigDerivedClassHasMethod("doDraw", swigMethodTypes137) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_doDrawSwigExplicitOdGiBaseVectorizer(swigCPtr, drawableFlags, OdGiDrawable.getCPtr(pDrawable)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_doDraw(swigCPtr, drawableFlags, OdGiDrawable.getCPtr(pDrawable)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setExtents(OdGePoint3d newExtents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setExtents(swigCPtr, OdGePoint3d.getCPtr(newExtents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void startAttributesSegment()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_startAttributesSegment(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isAttributesSegmentEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_isAttributesSegmentEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void rasterImageDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary, bool transparency, double brightness, double contrast, double fade)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(uvBoundary);
		try
		{
			if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes138))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rasterImageDcSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency, brightness, contrast, fade);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rasterImageDc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency, brightness, contrast, fade);
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

	public virtual void rasterImageDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary, bool transparency, double brightness, double contrast)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(uvBoundary);
		try
		{
			if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes139))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rasterImageDcSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency, brightness, contrast);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rasterImageDc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency, brightness, contrast);
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

	public virtual void rasterImageDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary, bool transparency, double brightness)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(uvBoundary);
		try
		{
			if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes140))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rasterImageDcSwigExplicitOdGiBaseVectorizer__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency, brightness);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rasterImageDc__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency, brightness);
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

	public virtual void rasterImageDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary, bool transparency)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(uvBoundary);
		try
		{
			if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes141))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rasterImageDcSwigExplicitOdGiBaseVectorizer__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rasterImageDc__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency);
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

	public virtual void rasterImageDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(uvBoundary);
		try
		{
			if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes142))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rasterImageDcSwigExplicitOdGiBaseVectorizer__SWIG_4(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_rasterImageDc__SWIG_4(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr);
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

	public virtual void metafileDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile, bool bDcAligned, bool bAllowClipping)
	{
		if (SwigDerivedClassHasMethod("metafileDc", swigMethodTypes143))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_metafileDcSwigExplicitOdGiBaseVectorizer__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile), bDcAligned, bAllowClipping);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_metafileDc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile), bDcAligned, bAllowClipping);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void metafileDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile, bool bDcAligned)
	{
		if (SwigDerivedClassHasMethod("metafileDc", swigMethodTypes144))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_metafileDcSwigExplicitOdGiBaseVectorizer__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile), bDcAligned);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_metafileDc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile), bDcAligned);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void metafileDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile)
	{
		if (SwigDerivedClassHasMethod("metafileDc", swigMethodTypes145))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_metafileDcSwigExplicitOdGiBaseVectorizer__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_metafileDc__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polylineEye(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			if (SwigDerivedClassHasMethod("polylineEye", swigMethodTypes146))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polylineEyeSwigExplicitOdGiBaseVectorizer(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polylineEye(swigCPtr, intPtr);
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

	public virtual void polygonEye(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			if (SwigDerivedClassHasMethod("polygonEye", swigMethodTypes147))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polygonEyeSwigExplicitOdGiBaseVectorizer(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polygonEye(swigCPtr, intPtr);
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

	public virtual void polylineDc(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			if (SwigDerivedClassHasMethod("polylineDc", swigMethodTypes148))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polylineDcSwigExplicitOdGiBaseVectorizer(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polylineDc(swigCPtr, intPtr);
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

	public virtual void polygonDc(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			if (SwigDerivedClassHasMethod("polygonDc", swigMethodTypes149))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polygonDcSwigExplicitOdGiBaseVectorizer(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polygonDc(swigCPtr, intPtr);
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

	public void polylineCs(OdGiContext_CoordinatesSystem cs, OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polylineCs(swigCPtr, (int)cs, intPtr);
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

	public void polygonCs(OdGiContext_CoordinatesSystem cs, OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_polygonCs(swigCPtr, (int)cs, intPtr);
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

	public virtual void onTraitsModified()
	{
		if (SwigDerivedClassHasMethod("onTraitsModified", swigMethodTypes150))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_onTraitsModifiedSwigExplicitOdGiBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_onTraitsModified(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiDeviation modelDeviation()
	{
		OdGiDeviation_Internal result = new OdGiDeviation_Internal(SwigDerivedClassHasMethod("modelDeviation", swigMethodTypes151) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_modelDeviationSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_modelDeviation(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDeviation worldDeviation()
	{
		OdGiDeviation_Internal result = new OdGiDeviation_Internal(SwigDerivedClassHasMethod("worldDeviation", swigMethodTypes152) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_worldDeviationSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_worldDeviation(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDeviation eyeDeviation()
	{
		OdGiDeviation_Internal result = new OdGiDeviation_Internal(SwigDerivedClassHasMethod("eyeDeviation", swigMethodTypes153) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_eyeDeviationSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_eyeDeviation(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMaterialTraitsData effectiveMaterialTraitsData()
	{
		OdGiMaterialTraitsData result = new OdGiMaterialTraitsData(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_effectiveMaterialTraitsData__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void effectiveMaterialTraitsData(OdGiMaterialTraitsData data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_effectiveMaterialTraitsData__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(data));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setEffectiveMaterialTraitsData(OdDbStub materialId, OdGiMaterialTraitsData data, bool bForce)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEffectiveMaterialTraitsData__SWIG_0(swigCPtr, OdDbStub.getCPtr(materialId), OdGiMaterialTraitsData.getCPtr(data), bForce);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setEffectiveMaterialTraitsData(OdDbStub materialId, OdGiMaterialTraitsData data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setEffectiveMaterialTraitsData__SWIG_1(swigCPtr, OdDbStub.getCPtr(materialId), OdGiMaterialTraitsData.getCPtr(data));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public IntPtr selectionMarker()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_selectionMarker(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiSubEntityTraitsData byBlockTraits()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_byBlockTraits(swigCPtr);
		OdGiSubEntityTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiSubEntityTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setByBlockTraits(OdGiSubEntityTraitsData pByBlock)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setByBlockTraits(swigCPtr, OdGiSubEntityTraitsData.getCPtr(pByBlock));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxObject saveByBlockTraits()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_saveByBlockTraits(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static IntPtr OdGiBaseVectorizer_OdGiViewportDraw__Upcast(IntPtr ptr)
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_OdGiBaseVectorizer_OdGiViewportDraw__Upcast(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiModelToViewProc GetModelToEyeProc()
	{
		OdGiModelToViewProc rXObject = Helpers.GetRXObject<OdGiModelToViewProc>(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_GetModelToEyeProc(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setFillPlane(OdGeVector3d pNormal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setFillPlane__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(pNormal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFillPlane()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setFillPlane__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineTypeScale(double lineTypeScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setLineTypeScale__SWIG_0(swigCPtr, lineTypeScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineTypeScale()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setLineTypeScale__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool fillPlane(OdGeVector3d normal)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_fillPlane(swigCPtr, OdGeVector3d.getCPtr(normal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool pushLineweightOverride(OdGiLineweightOverride pOverride)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushLineweightOverride(swigCPtr, OdGiLineweightOverride.getCPtr(pOverride));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void popLineweightOverride()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_popLineweightOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool pushPaletteOverride(OdGiPalette pOverride)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_pushPaletteOverride(swigCPtr, OdGiPalette.getCPtr(pOverride));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void popPaletteOverride()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_popPaletteOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint setupForEntity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_setupForEntity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void addLight(OdDbStub lightId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_addLight(swigCPtr, OdDbStub.getCPtr(lightId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onTextProcessing(OdGePoint3d arg0, OdGeVector3d arg1, OdGeVector3d arg2)
	{
		if (SwigDerivedClassHasMethod("onTextProcessing", swigMethodTypes154))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_onTextProcessingSwigExplicitOdGiBaseVectorizer(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGeVector3d.getCPtr(arg1), OdGeVector3d.getCPtr(arg2));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_onTextProcessing(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGeVector3d.getCPtr(arg1), OdGeVector3d.getCPtr(arg2));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiLineweightOverride currentLineweightOverride()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("currentLineweightOverride", swigMethodTypes155) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_currentLineweightOverrideSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_currentLineweightOverride(swigCPtr));
		OdGiLineweightOverride result = ((intPtr == IntPtr.Zero) ? null : new OdGiLineweightOverride(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double annotationScale()
	{
		double result = (SwigDerivedClassHasMethod("annotationScale", swigMethodTypes156) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_annotationScaleSwigExplicitOdGiBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_annotationScale(swigCPtr));
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
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodsetColor;
		}
		if (SwigDerivedClassHasMethod("setTrueColor", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetTrueColor;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetLayer;
		}
		if (SwigDerivedClassHasMethod("setLineType", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetLineType;
		}
		if (SwigDerivedClassHasMethod("setSelectionMarker", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetSelectionMarker;
		}
		if (SwigDerivedClassHasMethod("setFillType", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetFillType;
		}
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetFillPlane__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetFillPlane__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLineWeight", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetLineWeight;
		}
		if (SwigDerivedClassHasMethod("setLineTypeScale", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetLineTypeScale;
		}
		if (SwigDerivedClassHasMethod("setLineTypeScale", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetLineTypeScale__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setThickness", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetThickness;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetPlotStyleName__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetPlotStyleName__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetMaterial;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetMapper;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodsetVisualStyle;
		}
		if (SwigDerivedClassHasMethod("setTransparency", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetTransparency;
		}
		if (SwigDerivedClassHasMethod("setDrawFlags", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsetDrawFlags;
		}
		if (SwigDerivedClassHasMethod("setLockFlags", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetLockFlags;
		}
		if (SwigDerivedClassHasMethod("setSelectionGeom", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodsetSelectionGeom;
		}
		if (SwigDerivedClassHasMethod("setShadowFlags", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodsetShadowFlags;
		}
		if (SwigDerivedClassHasMethod("setSectionable", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsetSectionable;
		}
		if (SwigDerivedClassHasMethod("setSelectionFlags", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetSelectionFlags;
		}
		if (SwigDerivedClassHasMethod("color", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodcolor;
		}
		if (SwigDerivedClassHasMethod("trueColor", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodtrueColor;
		}
		if (SwigDerivedClassHasMethod("layer", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodlayer;
		}
		if (SwigDerivedClassHasMethod("lineType", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodlineType;
		}
		if (SwigDerivedClassHasMethod("fillType", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodfillType;
		}
		if (SwigDerivedClassHasMethod("fillPlane", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodfillPlane;
		}
		if (SwigDerivedClassHasMethod("lineWeight", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodlineWeight;
		}
		if (SwigDerivedClassHasMethod("lineTypeScale", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodlineTypeScale;
		}
		if (SwigDerivedClassHasMethod("thickness", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodthickness;
		}
		if (SwigDerivedClassHasMethod("plotStyleNameType", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodplotStyleNameType;
		}
		if (SwigDerivedClassHasMethod("plotStyleNameId", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodplotStyleNameId;
		}
		if (SwigDerivedClassHasMethod("material", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodmaterial;
		}
		if (SwigDerivedClassHasMethod("mapper", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodmapper;
		}
		if (SwigDerivedClassHasMethod("visualStyle", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodvisualStyle;
		}
		if (SwigDerivedClassHasMethod("transparency", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodtransparency;
		}
		if (SwigDerivedClassHasMethod("drawFlags", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethoddrawFlags;
		}
		if (SwigDerivedClassHasMethod("lockFlags", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodlockFlags;
		}
		if (SwigDerivedClassHasMethod("selectionGeom", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodselectionGeom;
		}
		if (SwigDerivedClassHasMethod("shadowFlags", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodshadowFlags;
		}
		if (SwigDerivedClassHasMethod("sectionable", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodsectionable;
		}
		if (SwigDerivedClassHasMethod("selectionFlags", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodselectionFlags;
		}
		if (SwigDerivedClassHasMethod("setSecondaryTrueColor", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodsetSecondaryTrueColor;
		}
		if (SwigDerivedClassHasMethod("secondaryTrueColor", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodsecondaryTrueColor;
		}
		if (SwigDerivedClassHasMethod("setLineStyleModifiers", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodsetLineStyleModifiers;
		}
		if (SwigDerivedClassHasMethod("lineStyleModifiers", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodlineStyleModifiers;
		}
		if (SwigDerivedClassHasMethod("setFill", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodsetFill;
		}
		if (SwigDerivedClassHasMethod("fill", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodfill;
		}
		if (SwigDerivedClassHasMethod("setAuxData", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodsetAuxData;
		}
		if (SwigDerivedClassHasMethod("auxData", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodauxData;
		}
		if (SwigDerivedClassHasMethod("pushLineweightOverride", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodpushLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("popLineweightOverride", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodpopLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("pushPaletteOverride", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodpushPaletteOverride;
		}
		if (SwigDerivedClassHasMethod("popPaletteOverride", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodpopPaletteOverride;
		}
		if (SwigDerivedClassHasMethod("setupForEntity", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodsetupForEntity;
		}
		if (SwigDerivedClassHasMethod("addLight", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodaddLight;
		}
		if (SwigDerivedClassHasMethod("setContext", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodsetContext;
		}
		if (SwigDerivedClassHasMethod("switchLayer", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodswitchLayer;
		}
		if (SwigDerivedClassHasMethod("effectiveLayerTraits", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodeffectiveLayerTraits;
		}
		if (SwigDerivedClassHasMethod("layerVisible", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodlayerVisible;
		}
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("effectivelyVisible", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodeffectivelyVisible;
		}
		if (SwigDerivedClassHasMethod("giContext", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodgiContext;
		}
		if (SwigDerivedClassHasMethod("currentDrawableDesc", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodcurrentDrawableDesc;
		}
		if (SwigDerivedClassHasMethod("currentDrawable", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodcurrentDrawable;
		}
		if (SwigDerivedClassHasMethod("giViewport", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodgiViewport;
		}
		if (SwigDerivedClassHasMethod("gsView", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodgsView;
		}
		if (SwigDerivedClassHasMethod("affectTraits", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodaffectTraits;
		}
		if (SwigDerivedClassHasMethod("linetypeGenerationCriteria", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodlinetypeGenerationCriteria;
		}
		if (SwigDerivedClassHasMethod("effectiveTraits", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodeffectiveTraits;
		}
		if (SwigDerivedClassHasMethod("setEffectiveTraits", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodsetEffectiveTraits__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setEffectiveTraits", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodsetEffectiveTraits__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("selectionMarkerOnChange", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodselectionMarkerOnChange;
		}
		if (SwigDerivedClassHasMethod("updateExtentsOnly", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodupdateExtentsOnly;
		}
		if (SwigDerivedClassHasMethod("output", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodoutput;
		}
		if (SwigDerivedClassHasMethod("beginViewVectorization", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodbeginViewVectorization;
		}
		if (SwigDerivedClassHasMethod("endViewVectorization", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodendViewVectorization;
		}
		if (SwigDerivedClassHasMethod("regenAbort", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodregenAbort;
		}
		if (SwigDerivedClassHasMethod("deviation", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethoddeviation;
		}
		if (SwigDerivedClassHasMethod("regenType", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodregenType;
		}
		if (SwigDerivedClassHasMethod("isDragging", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodisDragging;
		}
		if (SwigDerivedClassHasMethod("drawContextFlags", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethoddrawContextFlags;
		}
		if (SwigDerivedClassHasMethod("sequenceNumber", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodsequenceNumber;
		}
		if (SwigDerivedClassHasMethod("isValidId", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodisValidId;
		}
		if (SwigDerivedClassHasMethod("viewportObjectId", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodviewportObjectId;
		}
		if (SwigDerivedClassHasMethod("viewport", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodviewport;
		}
		if (SwigDerivedClassHasMethod("circle", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodcircle__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("circle", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodcircle__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("circularArc", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodcircularArc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("circularArc", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodcircularArc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("circularArc", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodcircularArc__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("circularArc", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodcircularArc__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("polyline", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethodpolyline__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("polyline", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodpolyline__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("polyline", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodpolyline__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("polygon", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethodpolygon__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("polygon", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethodpolygon__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("pline", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethodpline__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pline", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodpline__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("pline", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethodpline__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("text", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodtext__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("text", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethodtext__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("xline", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodxline;
		}
		if (SwigDerivedClassHasMethod("ray", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodray;
		}
		if (SwigDerivedClassHasMethod("nurbs", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodnurbs;
		}
		if (SwigDerivedClassHasMethod("EllipArc", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodEllipArc;
		}
		if (SwigDerivedClassHasMethod("ellipticArc", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethodellipticArc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("ellipticArc", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodellipticArc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("mesh", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethodmesh;
		}
		if (SwigDerivedClassHasMethod("shell", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethodshell;
		}
		if (SwigDerivedClassHasMethod("image", swigMethodTypes117))
		{
			swigDelegate117 = SwigDirectorMethodimage__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("image", swigMethodTypes118))
		{
			swigDelegate118 = SwigDirectorMethodimage__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("edge", swigMethodTypes119))
		{
			swigDelegate119 = SwigDirectorMethodedge;
		}
		if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes120))
		{
			swigDelegate120 = SwigDirectorMethodpolypoint;
		}
		if (SwigDerivedClassHasMethod("rowOfDots", swigMethodTypes121))
		{
			swigDelegate121 = SwigDirectorMethodrowOfDots;
		}
		if (SwigDerivedClassHasMethod("pointCloud", swigMethodTypes122))
		{
			swigDelegate122 = SwigDirectorMethodpointCloud;
		}
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes123))
		{
			swigDelegate123 = SwigDirectorMethodpushClipBoundary__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes124))
		{
			swigDelegate124 = SwigDirectorMethodpushClipBoundary__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("popClipBoundary", swigMethodTypes125))
		{
			swigDelegate125 = SwigDirectorMethodpopClipBoundary;
		}
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes126))
		{
			swigDelegate126 = SwigDirectorMethodpushModelTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes127))
		{
			swigDelegate127 = SwigDirectorMethodpushModelTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("popModelTransform", swigMethodTypes128))
		{
			swigDelegate128 = SwigDirectorMethodpopModelTransform;
		}
		if (SwigDerivedClassHasMethod("getModelToWorldTransform", swigMethodTypes129))
		{
			swigDelegate129 = SwigDirectorMethodgetModelToWorldTransform;
		}
		if (SwigDerivedClassHasMethod("getWorldToModelTransform", swigMethodTypes130))
		{
			swigDelegate130 = SwigDirectorMethodgetWorldToModelTransform;
		}
		if (SwigDerivedClassHasMethod("pushPositionTransform", swigMethodTypes131))
		{
			swigDelegate131 = SwigDirectorMethodpushPositionTransform;
		}
		if (SwigDerivedClassHasMethod("pushScaleTransform", swigMethodTypes132))
		{
			swigDelegate132 = SwigDirectorMethodpushScaleTransform;
		}
		if (SwigDerivedClassHasMethod("pushOrientationTransform", swigMethodTypes133))
		{
			swigDelegate133 = SwigDirectorMethodpushOrientationTransform;
		}
		if (SwigDerivedClassHasMethod("draw", swigMethodTypes134))
		{
			swigDelegate134 = SwigDirectorMethoddraw;
		}
		if (SwigDerivedClassHasMethod("currentGiPath", swigMethodTypes135))
		{
			swigDelegate135 = SwigDirectorMethodcurrentGiPath;
		}
		if (SwigDerivedClassHasMethod("setAttributes", swigMethodTypes136))
		{
			swigDelegate136 = SwigDirectorMethodsetAttributes;
		}
		if (SwigDerivedClassHasMethod("doDraw", swigMethodTypes137))
		{
			swigDelegate137 = SwigDirectorMethoddoDraw;
		}
		if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes138))
		{
			swigDelegate138 = SwigDirectorMethodrasterImageDc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes139))
		{
			swigDelegate139 = SwigDirectorMethodrasterImageDc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes140))
		{
			swigDelegate140 = SwigDirectorMethodrasterImageDc__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes141))
		{
			swigDelegate141 = SwigDirectorMethodrasterImageDc__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes142))
		{
			swigDelegate142 = SwigDirectorMethodrasterImageDc__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("metafileDc", swigMethodTypes143))
		{
			swigDelegate143 = SwigDirectorMethodmetafileDc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("metafileDc", swigMethodTypes144))
		{
			swigDelegate144 = SwigDirectorMethodmetafileDc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("metafileDc", swigMethodTypes145))
		{
			swigDelegate145 = SwigDirectorMethodmetafileDc__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("polylineEye", swigMethodTypes146))
		{
			swigDelegate146 = SwigDirectorMethodpolylineEye;
		}
		if (SwigDerivedClassHasMethod("polygonEye", swigMethodTypes147))
		{
			swigDelegate147 = SwigDirectorMethodpolygonEye;
		}
		if (SwigDerivedClassHasMethod("polylineDc", swigMethodTypes148))
		{
			swigDelegate148 = SwigDirectorMethodpolylineDc;
		}
		if (SwigDerivedClassHasMethod("polygonDc", swigMethodTypes149))
		{
			swigDelegate149 = SwigDirectorMethodpolygonDc;
		}
		if (SwigDerivedClassHasMethod("onTraitsModified", swigMethodTypes150))
		{
			swigDelegate150 = SwigDirectorMethodonTraitsModified;
		}
		if (SwigDerivedClassHasMethod("modelDeviation", swigMethodTypes151))
		{
			swigDelegate151 = SwigDirectorMethodmodelDeviation;
		}
		if (SwigDerivedClassHasMethod("worldDeviation", swigMethodTypes152))
		{
			swigDelegate152 = SwigDirectorMethodworldDeviation;
		}
		if (SwigDerivedClassHasMethod("eyeDeviation", swigMethodTypes153))
		{
			swigDelegate153 = SwigDirectorMethodeyeDeviation;
		}
		if (SwigDerivedClassHasMethod("onTextProcessing", swigMethodTypes154))
		{
			swigDelegate154 = SwigDirectorMethodonTextProcessing;
		}
		if (SwigDerivedClassHasMethod("currentLineweightOverride", swigMethodTypes155))
		{
			swigDelegate155 = SwigDirectorMethodcurrentLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("annotationScale", swigMethodTypes156))
		{
			swigDelegate156 = SwigDirectorMethodannotationScale;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizer_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125, swigDelegate126, swigDelegate127, swigDelegate128, swigDelegate129, swigDelegate130, swigDelegate131, swigDelegate132, swigDelegate133, swigDelegate134, swigDelegate135, swigDelegate136, swigDelegate137, swigDelegate138, swigDelegate139, swigDelegate140, swigDelegate141, swigDelegate142, swigDelegate143, swigDelegate144, swigDelegate145, swigDelegate146, swigDelegate147, swigDelegate148, swigDelegate149, swigDelegate150, swigDelegate151, swigDelegate152, swigDelegate153, swigDelegate154, swigDelegate155, swigDelegate156);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiBaseVectorizer));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pProtocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(pProtocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodsetColor(ushort color)
	{
		try
		{
			setColor(color);
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

	private void SwigDirectorMethodsetTrueColor(IntPtr trueColor)
	{
		try
		{
			setTrueColor(new OdCmEntityColor(trueColor, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetLayer(IntPtr layerId)
	{
		try
		{
			setLayer((layerId == IntPtr.Zero) ? null : new OdDbStub(layerId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetLineType(IntPtr lineTypeId)
	{
		try
		{
			setLineType((lineTypeId == IntPtr.Zero) ? null : new OdDbStub(lineTypeId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetLineWeight(int lineWeight)
	{
		try
		{
			setLineWeight((LineWeight)lineWeight);
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

	private void SwigDirectorMethodsetLineTypeScale(double lineTypeScale)
	{
		try
		{
			setLineTypeScale(lineTypeScale);
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

	private void SwigDirectorMethodsetLineTypeScale__SWIG_1()
	{
		try
		{
			setLineTypeScale();
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

	private void SwigDirectorMethodsetThickness(double thickness)
	{
		try
		{
			setThickness(thickness);
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

	private void SwigDirectorMethodsetPlotStyleName__SWIG_0(int plotStyleNameType, IntPtr pPlotStyleNameId)
	{
		try
		{
			setPlotStyleName((PlotStyleNameType)plotStyleNameType, (pPlotStyleNameId == IntPtr.Zero) ? null : new OdDbStub(pPlotStyleNameId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetPlotStyleName__SWIG_1(int plotStyleNameType)
	{
		try
		{
			setPlotStyleName((PlotStyleNameType)plotStyleNameType);
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

	private void SwigDirectorMethodsetMaterial(IntPtr pMaterialId)
	{
		try
		{
			setMaterial((pMaterialId == IntPtr.Zero) ? null : new OdDbStub(pMaterialId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper(IntPtr pMapper)
	{
		try
		{
			setMapper((pMapper == IntPtr.Zero) ? null : new OdGiMapper(pMapper, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetVisualStyle(IntPtr pVisualStyleId)
	{
		try
		{
			setVisualStyle((pVisualStyleId == IntPtr.Zero) ? null : new OdDbStub(pVisualStyleId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetTransparency(IntPtr transparency)
	{
		try
		{
			setTransparency(new OdCmTransparency(transparency, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDrawFlags(uint drawFlags)
	{
		try
		{
			setDrawFlags(drawFlags);
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

	private void SwigDirectorMethodsetLockFlags(uint lockFlags)
	{
		try
		{
			setLockFlags(lockFlags);
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

	private void SwigDirectorMethodsetSelectionGeom(bool bSelectionFlag)
	{
		try
		{
			setSelectionGeom(bSelectionFlag);
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

	private void SwigDirectorMethodsetShadowFlags(int shadowFlags)
	{
		try
		{
			setShadowFlags((OdGiSubEntityTraits_ShadowFlags)shadowFlags);
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

	private void SwigDirectorMethodsetSectionable(bool bSectionableFlag)
	{
		try
		{
			setSectionable(bSectionableFlag);
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

	private void SwigDirectorMethodsetSelectionFlags(int selectionFlags)
	{
		try
		{
			setSelectionFlags((OdGiSubEntityTraits_SelectionFlags)selectionFlags);
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

	private ushort SwigDirectorMethodcolor()
	{
		return color();
	}

	private IntPtr SwigDirectorMethodtrueColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(trueColor()).Handle;
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

	private IntPtr SwigDirectorMethodlayer()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(layer()).Handle;
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

	private IntPtr SwigDirectorMethodlineType()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(lineType()).Handle;
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

	private int SwigDirectorMethodfillType()
	{
		return (int)fillType();
	}

	private bool SwigDirectorMethodfillPlane(IntPtr normal)
	{
		return fillPlane(new OdGeVector3d(normal, cMemoryOwn: false));
	}

	private int SwigDirectorMethodlineWeight()
	{
		return (int)lineWeight();
	}

	private double SwigDirectorMethodlineTypeScale()
	{
		return lineTypeScale();
	}

	private double SwigDirectorMethodthickness()
	{
		return thickness();
	}

	private int SwigDirectorMethodplotStyleNameType()
	{
		return (int)plotStyleNameType();
	}

	private IntPtr SwigDirectorMethodplotStyleNameId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(plotStyleNameId()).Handle;
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

	private IntPtr SwigDirectorMethodmaterial()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(material()).Handle;
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

	private IntPtr SwigDirectorMethodmapper()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiMapper.getCPtr(mapper()).Handle;
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

	private IntPtr SwigDirectorMethodtransparency()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmTransparency.getCPtr(transparency()).Handle;
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

	private uint SwigDirectorMethoddrawFlags()
	{
		return drawFlags();
	}

	private uint SwigDirectorMethodlockFlags()
	{
		return lockFlags();
	}

	private bool SwigDirectorMethodselectionGeom()
	{
		return selectionGeom();
	}

	private int SwigDirectorMethodshadowFlags()
	{
		return (int)shadowFlags();
	}

	private bool SwigDirectorMethodsectionable()
	{
		return sectionable();
	}

	private int SwigDirectorMethodselectionFlags()
	{
		return (int)selectionFlags();
	}

	private void SwigDirectorMethodsetSecondaryTrueColor(IntPtr color)
	{
		try
		{
			setSecondaryTrueColor(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodsecondaryTrueColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(secondaryTrueColor()).Handle;
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

	private void SwigDirectorMethodsetLineStyleModifiers(IntPtr pLSMod)
	{
		try
		{
			setLineStyleModifiers((pLSMod == IntPtr.Zero) ? null : new OdGiDgLinetypeModifiers(pLSMod, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodlineStyleModifiers()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiDgLinetypeModifiers.getCPtr(lineStyleModifiers()).Handle;
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

	private void SwigDirectorMethodsetFill(IntPtr pFill)
	{
		try
		{
			setFill(Helpers.GetRXObject<OdGiFill>(pFill, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodfill()
	{
		return OdGiFill.getCPtr(fill()).Handle;
	}

	private void SwigDirectorMethodsetAuxData(IntPtr pAuxData)
	{
		try
		{
			setAuxData(Helpers.GetRXObject<OdGiAuxiliaryData>(pAuxData, bOwn: true, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodauxData()
	{
		return OdGiAuxiliaryData.getCPtr(auxData()).Handle;
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

	private uint SwigDirectorMethodsetupForEntity()
	{
		return setupForEntity();
	}

	private void SwigDirectorMethodaddLight(IntPtr lightId)
	{
		try
		{
			addLight((lightId == IntPtr.Zero) ? null : new OdDbStub(lightId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetContext(IntPtr pUserContext)
	{
		try
		{
			setContext(Helpers.GetRXObject<OdGiContext>(pUserContext, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodswitchLayer(IntPtr layerId)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(switchLayer((layerId == IntPtr.Zero) ? null : new OdDbStub(layerId, cMemoryOwn: false))).Handle;
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

	private IntPtr SwigDirectorMethodeffectiveLayerTraits()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiLayerTraitsData.getCPtr(effectiveLayerTraits()).Handle;
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

	private bool SwigDirectorMethodlayerVisible(IntPtr layerId)
	{
		return layerVisible((layerId == IntPtr.Zero) ? null : new OdDbStub(layerId, cMemoryOwn: false));
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

	private bool SwigDirectorMethodeffectivelyVisible()
	{
		return effectivelyVisible();
	}

	private IntPtr SwigDirectorMethodgiContext()
	{
		return OdGiContext.getCPtr(giContext()).Handle;
	}

	private IntPtr SwigDirectorMethodcurrentDrawableDesc()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiDrawableDesc.getCPtr(currentDrawableDesc()).Handle;
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

	private IntPtr SwigDirectorMethodcurrentDrawable()
	{
		return OdGiDrawable.getCPtr(currentDrawable()).Handle;
	}

	private IntPtr SwigDirectorMethodgiViewport()
	{
		return OdGiViewport.getCPtr(giViewport()).Handle;
	}

	private IntPtr SwigDirectorMethodgsView()
	{
		return OdGsView.getCPtr(gsView()).Handle;
	}

	private void SwigDirectorMethodaffectTraits(IntPtr pSource, IntPtr destination)
	{
		try
		{
			affectTraits((pSource == IntPtr.Zero) ? null : new OdGiSubEntityTraitsData(pSource, cMemoryOwn: false), new OdGiSubEntityTraitsData(destination, cMemoryOwn: false));
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

	private double SwigDirectorMethodlinetypeGenerationCriteria()
	{
		return linetypeGenerationCriteria();
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

	private void SwigDirectorMethodsetEffectiveTraits__SWIG_0(IntPtr traits, IntPtr fillNormal)
	{
		try
		{
			setEffectiveTraits(new OdGiSubEntityTraitsData(traits, cMemoryOwn: false), (fillNormal == IntPtr.Zero) ? null : new OdGeVector3d(fillNormal, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetEffectiveTraits__SWIG_1(IntPtr traits)
	{
		try
		{
			setEffectiveTraits(new OdGiSubEntityTraitsData(traits, cMemoryOwn: false));
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

	private void SwigDirectorMethodselectionMarkerOnChange(IntPtr nSelectionMarker)
	{
		try
		{
			selectionMarkerOnChange(nSelectionMarker);
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

	private bool SwigDirectorMethodupdateExtentsOnly()
	{
		return updateExtentsOnly();
	}

	private IntPtr SwigDirectorMethodoutput()
	{
		return output().GetInterfaceCPtr().Handle;
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

	private bool SwigDirectorMethodregenAbort()
	{
		return regenAbort();
	}

	private double SwigDirectorMethoddeviation(int deviationType, IntPtr pointOnCurve)
	{
		return deviation((OdGiDeviationType)deviationType, new OdGePoint3d(pointOnCurve, cMemoryOwn: false));
	}

	private int SwigDirectorMethodregenType()
	{
		return (int)regenType();
	}

	private bool SwigDirectorMethodisDragging()
	{
		return isDragging();
	}

	private uint SwigDirectorMethoddrawContextFlags()
	{
		return drawContextFlags();
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

	private IntPtr SwigDirectorMethodviewport()
	{
		return OdGiViewport.getCPtr(viewport()).Handle;
	}

	private void SwigDirectorMethodcircle__SWIG_0(IntPtr center, double radius, IntPtr normal)
	{
		try
		{
			circle(new OdGePoint3d(center, cMemoryOwn: false), radius, new OdGeVector3d(normal, cMemoryOwn: false));
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

	private void SwigDirectorMethodcircle__SWIG_1(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint)
	{
		try
		{
			circle(new OdGePoint3d(firstPoint, cMemoryOwn: false), new OdGePoint3d(secondPoint, cMemoryOwn: false), new OdGePoint3d(thirdPoint, cMemoryOwn: false));
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

	private void SwigDirectorMethodcircularArc__SWIG_0(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle, int arcType)
	{
		try
		{
			circularArc(new OdGePoint3d(center, cMemoryOwn: false), radius, new OdGeVector3d(normal, cMemoryOwn: false), new OdGeVector3d(startVector, cMemoryOwn: false), sweepAngle, (OdGiArcType)arcType);
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

	private void SwigDirectorMethodcircularArc__SWIG_1(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle)
	{
		try
		{
			circularArc(new OdGePoint3d(center, cMemoryOwn: false), radius, new OdGeVector3d(normal, cMemoryOwn: false), new OdGeVector3d(startVector, cMemoryOwn: false), sweepAngle);
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

	private void SwigDirectorMethodcircularArc__SWIG_2(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint, int arcType)
	{
		try
		{
			circularArc(new OdGePoint3d(firstPoint, cMemoryOwn: false), new OdGePoint3d(secondPoint, cMemoryOwn: false), new OdGePoint3d(thirdPoint, cMemoryOwn: false), (OdGiArcType)arcType);
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

	private void SwigDirectorMethodcircularArc__SWIG_3(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint)
	{
		try
		{
			circularArc(new OdGePoint3d(firstPoint, cMemoryOwn: false), new OdGePoint3d(secondPoint, cMemoryOwn: false), new OdGePoint3d(thirdPoint, cMemoryOwn: false));
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

	private void SwigDirectorMethodpolyline__SWIG_0(IntPtr numVertices, IntPtr pNormal, IntPtr baseSubEntMarker)
	{
		try
		{
			polyline(Helpers.UnMarshalPoint3dArray(numVertices), (pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false), baseSubEntMarker);
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

	private void SwigDirectorMethodpolyline__SWIG_1(IntPtr numVertices, IntPtr pNormal)
	{
		try
		{
			polyline(Helpers.UnMarshalPoint3dArray(numVertices), (pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false));
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

	private void SwigDirectorMethodpolyline__SWIG_2(IntPtr numVertices)
	{
		try
		{
			polyline(Helpers.UnMarshalPoint3dArray(numVertices));
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

	private void SwigDirectorMethodpolygon__SWIG_0(IntPtr numVertices)
	{
		try
		{
			polygon(Helpers.UnMarshalPoint3dArray(numVertices));
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

	private void SwigDirectorMethodpolygon__SWIG_1(IntPtr numVertices, IntPtr pNormal)
	{
		try
		{
			polygon(Helpers.UnMarshalPoint3dArray(numVertices), (pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false));
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

	private void SwigDirectorMethodpline__SWIG_0(IntPtr polyline, uint fromIndex, uint numSegs)
	{
		try
		{
			pline(Helpers.GetRXObject<OdGiPolyline>(polyline, bOwn: false, bTryAddToTransaction: false), fromIndex, numSegs);
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

	private void SwigDirectorMethodpline__SWIG_1(IntPtr polyline, uint fromIndex)
	{
		try
		{
			pline(Helpers.GetRXObject<OdGiPolyline>(polyline, bOwn: false, bTryAddToTransaction: false), fromIndex);
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

	private void SwigDirectorMethodpline__SWIG_2(IntPtr polyline)
	{
		try
		{
			pline(Helpers.GetRXObject<OdGiPolyline>(polyline, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodtext__SWIG_0(IntPtr position, IntPtr normal, IntPtr direction, double height, double width, double oblique, [MarshalAs(UnmanagedType.LPWStr)] string msg)
	{
		try
		{
			text(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(normal, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), height, width, oblique, msg);
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

	private void SwigDirectorMethodtext__SWIG_1(IntPtr position, IntPtr normal, IntPtr direction, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle)
	{
		try
		{
			text(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(normal, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), msg, raw, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false));
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

	private void SwigDirectorMethodnurbs(IntPtr nurbsCurve)
	{
		try
		{
			nurbs(new OdGeNurbCurve3d(nurbsCurve, cMemoryOwn: false));
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

	private void SwigDirectorMethodEllipArc(IntPtr ellipArc, IntPtr endPointsOverrides, int arcType)
	{
		try
		{
			EllipArc(new OdGeEllipArc3d(ellipArc, cMemoryOwn: false), Helpers.UnMarshalPointPair(endPointsOverrides), (OdGiArcType)arcType);
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

	private void SwigDirectorMethodellipticArc__SWIG_0(IntPtr ellipArc, IntPtr endPointsOverrides)
	{
		try
		{
			ellipticArc(new OdGeEllipArc3d(ellipArc, cMemoryOwn: false), Helpers.UnMarshalPointPair(endPointsOverrides));
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

	private void SwigDirectorMethodellipticArc__SWIG_1(IntPtr ellipArc)
	{
		try
		{
			ellipticArc(new OdGeEllipArc3d(ellipArc, cMemoryOwn: false));
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

	private void SwigDirectorMethodimage__SWIG_0(IntPtr img, IntPtr origin, IntPtr uVec, IntPtr vVec, int trpMode)
	{
		try
		{
			image(new OdGiImageBGRA32(img, cMemoryOwn: false), new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(uVec, cMemoryOwn: false), new OdGeVector3d(vVec, cMemoryOwn: false), (OdGiRasterImage_TransparencyMode)trpMode);
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

	private void SwigDirectorMethodimage__SWIG_1(IntPtr img, IntPtr origin, IntPtr uVec, IntPtr vVec)
	{
		try
		{
			image(new OdGiImageBGRA32(img, cMemoryOwn: false), new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(uVec, cMemoryOwn: false), new OdGeVector3d(vVec, cMemoryOwn: false));
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

	private void SwigDirectorMethodedge(IntPtr edges)
	{
		try
		{
			edge(new OdGeCurve2dArray(edges, cMemoryOwn: false));
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

	private void SwigDirectorMethodpolypoint(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pSubEntMarkers, int nPointSize)
	{
		try
		{
			polypoint(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false), (pTransparency == IntPtr.Zero) ? null : new OdCmTransparency(pTransparency, cMemoryOwn: false), (pNormals == IntPtr.Zero) ? null : new OdGeVector3d(pNormals, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pSubEntMarkers), nPointSize);
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

	private void SwigDirectorMethodrowOfDots(int numPoints, IntPtr startPoint, IntPtr dirToNextPoint)
	{
		try
		{
			rowOfDots(numPoints, new OdGePoint3d(startPoint, cMemoryOwn: false), new OdGeVector3d(dirToNextPoint, cMemoryOwn: false));
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

	private void SwigDirectorMethodpointCloud(IntPtr pCloud)
	{
		try
		{
			pointCloud(Helpers.GetRXObject<OdGiPointCloud>(pCloud, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodpushPositionTransform(int behavior, IntPtr pos)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(pushPositionTransform((OdGiPositionTransformBehavior)behavior, new OdGePoint3d(pos, cMemoryOwn: false))).Handle;
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

	private IntPtr SwigDirectorMethodpushScaleTransform(int behavior, IntPtr scale)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(pushScaleTransform((OdGiScaleTransformBehavior)behavior, new OdGePoint3d(scale, cMemoryOwn: false))).Handle;
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

	private IntPtr SwigDirectorMethodpushOrientationTransform(int behavior)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(pushOrientationTransform((OdGiOrientationTransformBehavior)behavior)).Handle;
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

	private IntPtr SwigDirectorMethodcurrentGiPath()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiPathNode.getCPtr(currentGiPath()).Handle;
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

	private uint SwigDirectorMethodsetAttributes(IntPtr pDrawable)
	{
		return setAttributes(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethoddoDraw(uint drawableFlags, IntPtr pDrawable)
	{
		return doDraw(drawableFlags, Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodrasterImageDc__SWIG_0(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness, double contrast, double fade)
	{
		try
		{
			rasterImageDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalPoint2dArray(uvBoundary), transparency, brightness, contrast, fade);
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

	private void SwigDirectorMethodrasterImageDc__SWIG_1(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness, double contrast)
	{
		try
		{
			rasterImageDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalPoint2dArray(uvBoundary), transparency, brightness, contrast);
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

	private void SwigDirectorMethodrasterImageDc__SWIG_2(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness)
	{
		try
		{
			rasterImageDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalPoint2dArray(uvBoundary), transparency, brightness);
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

	private void SwigDirectorMethodrasterImageDc__SWIG_3(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency)
	{
		try
		{
			rasterImageDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalPoint2dArray(uvBoundary), transparency);
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

	private void SwigDirectorMethodrasterImageDc__SWIG_4(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary)
	{
		try
		{
			rasterImageDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalPoint2dArray(uvBoundary));
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

	private void SwigDirectorMethodmetafileDc__SWIG_0(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile, bool bDcAligned, bool bAllowClipping)
	{
		try
		{
			metafileDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiMetafile>(pMetafile, bOwn: false, bTryAddToTransaction: false), bDcAligned, bAllowClipping);
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

	private void SwigDirectorMethodmetafileDc__SWIG_1(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile, bool bDcAligned)
	{
		try
		{
			metafileDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiMetafile>(pMetafile, bOwn: false, bTryAddToTransaction: false), bDcAligned);
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

	private void SwigDirectorMethodmetafileDc__SWIG_2(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile)
	{
		try
		{
			metafileDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiMetafile>(pMetafile, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodpolylineEye(IntPtr numVertices)
	{
		try
		{
			polylineEye(Helpers.UnMarshalPoint3dArray(numVertices));
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

	private void SwigDirectorMethodpolygonEye(IntPtr numVertices)
	{
		try
		{
			polygonEye(Helpers.UnMarshalPoint3dArray(numVertices));
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

	private void SwigDirectorMethodpolylineDc(IntPtr numVertices)
	{
		try
		{
			polylineDc(Helpers.UnMarshalPoint3dArray(numVertices));
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

	private void SwigDirectorMethodpolygonDc(IntPtr numVertices)
	{
		try
		{
			polygonDc(Helpers.UnMarshalPoint3dArray(numVertices));
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

	private IntPtr SwigDirectorMethodmodelDeviation()
	{
		return modelDeviation().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodworldDeviation()
	{
		return worldDeviation().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodeyeDeviation()
	{
		return eyeDeviation().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodonTextProcessing(IntPtr arg0, IntPtr arg1, IntPtr arg2)
	{
		try
		{
			onTextProcessing(new OdGePoint3d(arg0, cMemoryOwn: false), new OdGeVector3d(arg1, cMemoryOwn: false), new OdGeVector3d(arg2, cMemoryOwn: false));
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

	private double SwigDirectorMethodannotationScale()
	{
		return annotationScale();
	}
}

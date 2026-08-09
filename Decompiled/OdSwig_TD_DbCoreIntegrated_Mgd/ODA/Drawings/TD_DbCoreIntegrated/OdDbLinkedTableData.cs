using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbLinkedTableData : OdDbLinkedData
{
	public delegate IntPtr SwigDelegateOdDbLinkedTableData_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_1();

	public delegate void SwigDelegateOdDbLinkedTableData_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbLinkedTableData_3();

	public delegate bool SwigDelegateOdDbLinkedTableData_4();

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_5();

	public delegate void SwigDelegateOdDbLinkedTableData_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_7();

	public delegate uint SwigDelegateOdDbLinkedTableData_8(IntPtr vd);

	public delegate uint SwigDelegateOdDbLinkedTableData_9();

	public delegate void SwigDelegateOdDbLinkedTableData_10(IntPtr ownerId);

	public delegate int SwigDelegateOdDbLinkedTableData_11(int mode);

	public delegate void SwigDelegateOdDbLinkedTableData_12();

	public delegate int SwigDelegateOdDbLinkedTableData_13(bool erasing);

	public delegate void SwigDelegateOdDbLinkedTableData_14(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbLinkedTableData_15(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbLinkedTableData_16(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbLinkedTableData_17(IntPtr otherId);

	public delegate void SwigDelegateOdDbLinkedTableData_18(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbLinkedTableData_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbLinkedTableData_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbLinkedTableData_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbLinkedTableData_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbLinkedTableData_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbLinkedTableData_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbLinkedTableData_25(IntPtr pFiler);

	public delegate void SwigDelegateOdDbLinkedTableData_26(IntPtr pFiler);

	public delegate int SwigDelegateOdDbLinkedTableData_27();

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_28([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbLinkedTableData_29(IntPtr pRb);

	public delegate void SwigDelegateOdDbLinkedTableData_30(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbLinkedTableData_31(IntPtr objId);

	public delegate void SwigDelegateOdDbLinkedTableData_32(IntPtr objId);

	public delegate void SwigDelegateOdDbLinkedTableData_33(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbLinkedTableData_34();

	public delegate void SwigDelegateOdDbLinkedTableData_35(IntPtr idPair, IntPtr pOwnerObject, IntPtr idMap);

	public delegate void SwigDelegateOdDbLinkedTableData_36(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbLinkedTableData_37(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbLinkedTableData_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbLinkedTableData_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbLinkedTableData_40(IntPtr pObject);

	public delegate void SwigDelegateOdDbLinkedTableData_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbLinkedTableData_42(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbLinkedTableData_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbLinkedTableData_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbLinkedTableData_45(IntPtr pObject);

	public delegate void SwigDelegateOdDbLinkedTableData_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbLinkedTableData_47(IntPtr objectId);

	public delegate void SwigDelegateOdDbLinkedTableData_48(IntPtr pObject);

	public delegate void SwigDelegateOdDbLinkedTableData_49(IntPtr pSource);

	public delegate int SwigDelegateOdDbLinkedTableData_50(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbLinkedTableData_51(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_52(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_53(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbLinkedTableData_54(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_55();

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbLinkedTableData_57(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_58([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_59(IntPtr pClass);

	public delegate int SwigDelegateOdDbLinkedTableData_60(IntPtr pClsid);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLinkedTableData_61();

	public delegate void SwigDelegateOdDbLinkedTableData_62([MarshalAs(UnmanagedType.LPWStr)] string name);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLinkedTableData_63();

	public delegate void SwigDelegateOdDbLinkedTableData_64([MarshalAs(UnmanagedType.LPWStr)] string description);

	public delegate void SwigDelegateOdDbLinkedTableData_65(int nRows, int nCols);

	public delegate int SwigDelegateOdDbLinkedTableData_66();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLinkedTableData_67(int nIndex);

	public delegate void SwigDelegateOdDbLinkedTableData_68(int nIndex, [MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate int SwigDelegateOdDbLinkedTableData_69(int nNumCols);

	public delegate int SwigDelegateOdDbLinkedTableData_70(int nIndex, int nNumCols);

	public delegate void SwigDelegateOdDbLinkedTableData_71(int nIndex, int nNumColsToDelete);

	public delegate int SwigDelegateOdDbLinkedTableData_72();

	public delegate bool SwigDelegateOdDbLinkedTableData_73(int nIndex, bool bRow);

	public delegate int SwigDelegateOdDbLinkedTableData_74(int nNumRows);

	public delegate int SwigDelegateOdDbLinkedTableData_75(int nIndex, int nNumRows);

	public delegate bool SwigDelegateOdDbLinkedTableData_76(int nIndex, int nCount, bool bRow);

	public delegate void SwigDelegateOdDbLinkedTableData_77(int nIndex, int nNumRowsToDelete);

	public delegate bool SwigDelegateOdDbLinkedTableData_78(int nRow, int nCol);

	public delegate int SwigDelegateOdDbLinkedTableData_79(int nRow, int nCol);

	public delegate void SwigDelegateOdDbLinkedTableData_80(int nRow, int nCol, int nCellState);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLinkedTableData_81(int nRow, int nCol);

	public delegate void SwigDelegateOdDbLinkedTableData_82(int nRow, int nCol, [MarshalAs(UnmanagedType.LPWStr)] string sToolTip);

	public delegate int SwigDelegateOdDbLinkedTableData_83(int nRow, int nCol);

	public delegate void SwigDelegateOdDbLinkedTableData_84(int nRow, int nCol, int nData);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_85(int nRow, int nCol, [MarshalAs(UnmanagedType.LPWStr)] string sKey);

	public delegate void SwigDelegateOdDbLinkedTableData_86(int nRow, int nCol, [MarshalAs(UnmanagedType.LPWStr)] string sKey, IntPtr pData);

	public delegate uint SwigDelegateOdDbLinkedTableData_87(int nRow, int nCol);

	public delegate uint SwigDelegateOdDbLinkedTableData_88(int nRow, int nCol, int nIndex);

	public delegate void SwigDelegateOdDbLinkedTableData_89(int nRow, int nCol, int nFromIndex, int nToIndex);

	public delegate void SwigDelegateOdDbLinkedTableData_90(int nRow, int nCol, uint nContent);

	public delegate void SwigDelegateOdDbLinkedTableData_91(int nRow, int nCol);

	public delegate void SwigDelegateOdDbLinkedTableData_92(IntPtr range);

	public delegate int SwigDelegateOdDbLinkedTableData_93(int nRow, int nCol);

	public delegate int SwigDelegateOdDbLinkedTableData_94(int nRow, int nCol, uint nContent);

	public delegate void SwigDelegateOdDbLinkedTableData_95(int nRow, int nCol, OdValue_DataType nDataType, OdValue_UnitType nUnitType);

	public delegate void SwigDelegateOdDbLinkedTableData_96(int nRow, int nCol, uint nContent, OdValue_DataType nDataType, OdValue_UnitType nUnitType);

	public delegate void SwigDelegateOdDbLinkedTableData_97(int nRow, int nCol, int nDataType, int nUnitType);

	public delegate void SwigDelegateOdDbLinkedTableData_98(int nRow, int nCol, uint nContent, int nDataType, int nUnitType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLinkedTableData_99(int nRow, int nCol);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLinkedTableData_100(int nRow, int nCol, uint nContent);

	public delegate void SwigDelegateOdDbLinkedTableData_101(int nRow, int nCol, [MarshalAs(UnmanagedType.LPWStr)] string sFormat);

	public delegate void SwigDelegateOdDbLinkedTableData_102(int nRow, int nCol, uint nContent, [MarshalAs(UnmanagedType.LPWStr)] string sFormat);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_103(int nRow, int nCol);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_104(int nRow, int nCol, uint nContent, int nOption);

	public delegate void SwigDelegateOdDbLinkedTableData_105(int nRow, int nCol, IntPtr value);

	public delegate void SwigDelegateOdDbLinkedTableData_106(int nRow, int nCol, uint nContent, IntPtr value);

	public delegate void SwigDelegateOdDbLinkedTableData_107(int nRow, int nCol, uint nContent, IntPtr value, int nOption);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLinkedTableData_108(int nRow, int nCol);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLinkedTableData_109(int nRow, int nCol, uint nContent);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLinkedTableData_110(int nRow, int nCol, uint nContent, int nOption);

	public delegate void SwigDelegateOdDbLinkedTableData_111(int nRow, int nCol, [MarshalAs(UnmanagedType.LPWStr)] string sText);

	public delegate void SwigDelegateOdDbLinkedTableData_112(int nRow, int nCol, uint nContent, [MarshalAs(UnmanagedType.LPWStr)] string sText);

	public delegate bool SwigDelegateOdDbLinkedTableData_113(int nRow, int nCol, uint nContent);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLinkedTableData_114(int nRow, int nCol, uint nContent);

	public delegate void SwigDelegateOdDbLinkedTableData_115(int nRow, int nCol, uint nContent, [MarshalAs(UnmanagedType.LPWStr)] string sFormula);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_116(int nRow, int nCol);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_117(int nRow, int nCol, uint nContent);

	public delegate void SwigDelegateOdDbLinkedTableData_118(int nRow, int nCol, IntPtr idField);

	public delegate void SwigDelegateOdDbLinkedTableData_119(int nRow, int nCol, uint nContent, IntPtr idField);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_120(int nRow, int nCol, uint nContent, int mode);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_121(int nRow, int nCol);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_122(int nRow, int nCol, uint nContent);

	public delegate void SwigDelegateOdDbLinkedTableData_123(int nRow, int nCol, IntPtr idBTR);

	public delegate void SwigDelegateOdDbLinkedTableData_124(int nRow, int nCol, uint nContent, IntPtr idBTR);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLinkedTableData_125(int nRow, int nCol, IntPtr idAttDef);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLinkedTableData_126(int nRow, int nCol, uint nContent, IntPtr idAttDef);

	public delegate void SwigDelegateOdDbLinkedTableData_127(int nRow, int nCol, IntPtr idAttDef, [MarshalAs(UnmanagedType.LPWStr)] string sAttValue);

	public delegate void SwigDelegateOdDbLinkedTableData_128(int nRow, int nCol, uint nContent, IntPtr idAttDef, [MarshalAs(UnmanagedType.LPWStr)] string sAttValue);

	public delegate bool SwigDelegateOdDbLinkedTableData_129(int nRow, int nCol);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_130(int nRow, int nCol);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_131(int nRow, int nCol, int mode);

	public delegate int SwigDelegateOdDbLinkedTableData_132(IntPtr pRange, IntPtr dataLinkIds);

	public delegate void SwigDelegateOdDbLinkedTableData_133(int nRow, int nCol, IntPtr idDataLink, bool bUpdate);

	public delegate void SwigDelegateOdDbLinkedTableData_134(IntPtr range, IntPtr idDataLink, bool bUpdate);

	public delegate IntPtr SwigDelegateOdDbLinkedTableData_135(int nRow, int nCol);

	public delegate void SwigDelegateOdDbLinkedTableData_136(int nRow, int nCol);

	public delegate void SwigDelegateOdDbLinkedTableData_137();

	public delegate void SwigDelegateOdDbLinkedTableData_138(int nRow, int nCol, int nDir, int nOption);

	public delegate void SwigDelegateOdDbLinkedTableData_139(int nDir, int nOption);

	public delegate void SwigDelegateOdDbLinkedTableData_140();

	public delegate void SwigDelegateOdDbLinkedTableData_141(IntPtr pSrc, int nOption);

	public delegate void SwigDelegateOdDbLinkedTableData_142(IntPtr pSrc, int nOption, IntPtr srcRange, IntPtr targetRange, IntPtr pNewTargetRange);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbLinkedTableData_0 swigDelegate0;

	private SwigDelegateOdDbLinkedTableData_1 swigDelegate1;

	private SwigDelegateOdDbLinkedTableData_2 swigDelegate2;

	private SwigDelegateOdDbLinkedTableData_3 swigDelegate3;

	private SwigDelegateOdDbLinkedTableData_4 swigDelegate4;

	private SwigDelegateOdDbLinkedTableData_5 swigDelegate5;

	private SwigDelegateOdDbLinkedTableData_6 swigDelegate6;

	private SwigDelegateOdDbLinkedTableData_7 swigDelegate7;

	private SwigDelegateOdDbLinkedTableData_8 swigDelegate8;

	private SwigDelegateOdDbLinkedTableData_9 swigDelegate9;

	private SwigDelegateOdDbLinkedTableData_10 swigDelegate10;

	private SwigDelegateOdDbLinkedTableData_11 swigDelegate11;

	private SwigDelegateOdDbLinkedTableData_12 swigDelegate12;

	private SwigDelegateOdDbLinkedTableData_13 swigDelegate13;

	private SwigDelegateOdDbLinkedTableData_14 swigDelegate14;

	private SwigDelegateOdDbLinkedTableData_15 swigDelegate15;

	private SwigDelegateOdDbLinkedTableData_16 swigDelegate16;

	private SwigDelegateOdDbLinkedTableData_17 swigDelegate17;

	private SwigDelegateOdDbLinkedTableData_18 swigDelegate18;

	private SwigDelegateOdDbLinkedTableData_19 swigDelegate19;

	private SwigDelegateOdDbLinkedTableData_20 swigDelegate20;

	private SwigDelegateOdDbLinkedTableData_21 swigDelegate21;

	private SwigDelegateOdDbLinkedTableData_22 swigDelegate22;

	private SwigDelegateOdDbLinkedTableData_23 swigDelegate23;

	private SwigDelegateOdDbLinkedTableData_24 swigDelegate24;

	private SwigDelegateOdDbLinkedTableData_25 swigDelegate25;

	private SwigDelegateOdDbLinkedTableData_26 swigDelegate26;

	private SwigDelegateOdDbLinkedTableData_27 swigDelegate27;

	private SwigDelegateOdDbLinkedTableData_28 swigDelegate28;

	private SwigDelegateOdDbLinkedTableData_29 swigDelegate29;

	private SwigDelegateOdDbLinkedTableData_30 swigDelegate30;

	private SwigDelegateOdDbLinkedTableData_31 swigDelegate31;

	private SwigDelegateOdDbLinkedTableData_32 swigDelegate32;

	private SwigDelegateOdDbLinkedTableData_33 swigDelegate33;

	private SwigDelegateOdDbLinkedTableData_34 swigDelegate34;

	private SwigDelegateOdDbLinkedTableData_35 swigDelegate35;

	private SwigDelegateOdDbLinkedTableData_36 swigDelegate36;

	private SwigDelegateOdDbLinkedTableData_37 swigDelegate37;

	private SwigDelegateOdDbLinkedTableData_38 swigDelegate38;

	private SwigDelegateOdDbLinkedTableData_39 swigDelegate39;

	private SwigDelegateOdDbLinkedTableData_40 swigDelegate40;

	private SwigDelegateOdDbLinkedTableData_41 swigDelegate41;

	private SwigDelegateOdDbLinkedTableData_42 swigDelegate42;

	private SwigDelegateOdDbLinkedTableData_43 swigDelegate43;

	private SwigDelegateOdDbLinkedTableData_44 swigDelegate44;

	private SwigDelegateOdDbLinkedTableData_45 swigDelegate45;

	private SwigDelegateOdDbLinkedTableData_46 swigDelegate46;

	private SwigDelegateOdDbLinkedTableData_47 swigDelegate47;

	private SwigDelegateOdDbLinkedTableData_48 swigDelegate48;

	private SwigDelegateOdDbLinkedTableData_49 swigDelegate49;

	private SwigDelegateOdDbLinkedTableData_50 swigDelegate50;

	private SwigDelegateOdDbLinkedTableData_51 swigDelegate51;

	private SwigDelegateOdDbLinkedTableData_52 swigDelegate52;

	private SwigDelegateOdDbLinkedTableData_53 swigDelegate53;

	private SwigDelegateOdDbLinkedTableData_54 swigDelegate54;

	private SwigDelegateOdDbLinkedTableData_55 swigDelegate55;

	private SwigDelegateOdDbLinkedTableData_56 swigDelegate56;

	private SwigDelegateOdDbLinkedTableData_57 swigDelegate57;

	private SwigDelegateOdDbLinkedTableData_58 swigDelegate58;

	private SwigDelegateOdDbLinkedTableData_59 swigDelegate59;

	private SwigDelegateOdDbLinkedTableData_60 swigDelegate60;

	private SwigDelegateOdDbLinkedTableData_61 swigDelegate61;

	private SwigDelegateOdDbLinkedTableData_62 swigDelegate62;

	private SwigDelegateOdDbLinkedTableData_63 swigDelegate63;

	private SwigDelegateOdDbLinkedTableData_64 swigDelegate64;

	private SwigDelegateOdDbLinkedTableData_65 swigDelegate65;

	private SwigDelegateOdDbLinkedTableData_66 swigDelegate66;

	private SwigDelegateOdDbLinkedTableData_67 swigDelegate67;

	private SwigDelegateOdDbLinkedTableData_68 swigDelegate68;

	private SwigDelegateOdDbLinkedTableData_69 swigDelegate69;

	private SwigDelegateOdDbLinkedTableData_70 swigDelegate70;

	private SwigDelegateOdDbLinkedTableData_71 swigDelegate71;

	private SwigDelegateOdDbLinkedTableData_72 swigDelegate72;

	private SwigDelegateOdDbLinkedTableData_73 swigDelegate73;

	private SwigDelegateOdDbLinkedTableData_74 swigDelegate74;

	private SwigDelegateOdDbLinkedTableData_75 swigDelegate75;

	private SwigDelegateOdDbLinkedTableData_76 swigDelegate76;

	private SwigDelegateOdDbLinkedTableData_77 swigDelegate77;

	private SwigDelegateOdDbLinkedTableData_78 swigDelegate78;

	private SwigDelegateOdDbLinkedTableData_79 swigDelegate79;

	private SwigDelegateOdDbLinkedTableData_80 swigDelegate80;

	private SwigDelegateOdDbLinkedTableData_81 swigDelegate81;

	private SwigDelegateOdDbLinkedTableData_82 swigDelegate82;

	private SwigDelegateOdDbLinkedTableData_83 swigDelegate83;

	private SwigDelegateOdDbLinkedTableData_84 swigDelegate84;

	private SwigDelegateOdDbLinkedTableData_85 swigDelegate85;

	private SwigDelegateOdDbLinkedTableData_86 swigDelegate86;

	private SwigDelegateOdDbLinkedTableData_87 swigDelegate87;

	private SwigDelegateOdDbLinkedTableData_88 swigDelegate88;

	private SwigDelegateOdDbLinkedTableData_89 swigDelegate89;

	private SwigDelegateOdDbLinkedTableData_90 swigDelegate90;

	private SwigDelegateOdDbLinkedTableData_91 swigDelegate91;

	private SwigDelegateOdDbLinkedTableData_92 swigDelegate92;

	private SwigDelegateOdDbLinkedTableData_93 swigDelegate93;

	private SwigDelegateOdDbLinkedTableData_94 swigDelegate94;

	private SwigDelegateOdDbLinkedTableData_95 swigDelegate95;

	private SwigDelegateOdDbLinkedTableData_96 swigDelegate96;

	private SwigDelegateOdDbLinkedTableData_97 swigDelegate97;

	private SwigDelegateOdDbLinkedTableData_98 swigDelegate98;

	private SwigDelegateOdDbLinkedTableData_99 swigDelegate99;

	private SwigDelegateOdDbLinkedTableData_100 swigDelegate100;

	private SwigDelegateOdDbLinkedTableData_101 swigDelegate101;

	private SwigDelegateOdDbLinkedTableData_102 swigDelegate102;

	private SwigDelegateOdDbLinkedTableData_103 swigDelegate103;

	private SwigDelegateOdDbLinkedTableData_104 swigDelegate104;

	private SwigDelegateOdDbLinkedTableData_105 swigDelegate105;

	private SwigDelegateOdDbLinkedTableData_106 swigDelegate106;

	private SwigDelegateOdDbLinkedTableData_107 swigDelegate107;

	private SwigDelegateOdDbLinkedTableData_108 swigDelegate108;

	private SwigDelegateOdDbLinkedTableData_109 swigDelegate109;

	private SwigDelegateOdDbLinkedTableData_110 swigDelegate110;

	private SwigDelegateOdDbLinkedTableData_111 swigDelegate111;

	private SwigDelegateOdDbLinkedTableData_112 swigDelegate112;

	private SwigDelegateOdDbLinkedTableData_113 swigDelegate113;

	private SwigDelegateOdDbLinkedTableData_114 swigDelegate114;

	private SwigDelegateOdDbLinkedTableData_115 swigDelegate115;

	private SwigDelegateOdDbLinkedTableData_116 swigDelegate116;

	private SwigDelegateOdDbLinkedTableData_117 swigDelegate117;

	private SwigDelegateOdDbLinkedTableData_118 swigDelegate118;

	private SwigDelegateOdDbLinkedTableData_119 swigDelegate119;

	private SwigDelegateOdDbLinkedTableData_120 swigDelegate120;

	private SwigDelegateOdDbLinkedTableData_121 swigDelegate121;

	private SwigDelegateOdDbLinkedTableData_122 swigDelegate122;

	private SwigDelegateOdDbLinkedTableData_123 swigDelegate123;

	private SwigDelegateOdDbLinkedTableData_124 swigDelegate124;

	private SwigDelegateOdDbLinkedTableData_125 swigDelegate125;

	private SwigDelegateOdDbLinkedTableData_126 swigDelegate126;

	private SwigDelegateOdDbLinkedTableData_127 swigDelegate127;

	private SwigDelegateOdDbLinkedTableData_128 swigDelegate128;

	private SwigDelegateOdDbLinkedTableData_129 swigDelegate129;

	private SwigDelegateOdDbLinkedTableData_130 swigDelegate130;

	private SwigDelegateOdDbLinkedTableData_131 swigDelegate131;

	private SwigDelegateOdDbLinkedTableData_132 swigDelegate132;

	private SwigDelegateOdDbLinkedTableData_133 swigDelegate133;

	private SwigDelegateOdDbLinkedTableData_134 swigDelegate134;

	private SwigDelegateOdDbLinkedTableData_135 swigDelegate135;

	private SwigDelegateOdDbLinkedTableData_136 swigDelegate136;

	private SwigDelegateOdDbLinkedTableData_137 swigDelegate137;

	private SwigDelegateOdDbLinkedTableData_138 swigDelegate138;

	private SwigDelegateOdDbLinkedTableData_139 swigDelegate139;

	private SwigDelegateOdDbLinkedTableData_140 swigDelegate140;

	private SwigDelegateOdDbLinkedTableData_141 swigDelegate141;

	private SwigDelegateOdDbLinkedTableData_142 swigDelegate142;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGsCache) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGiViewportDraw) };

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdDb_OpenMode) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes15 = new Type[3]
	{
		typeof(OdDbObjectId),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes16 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdDbAuditInfo) };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(OdResBuf) };

	private static Type[] swigMethodTypes30 = new Type[2]
	{
		typeof(OdDbDwgFiler),
		typeof(OdRxClass)
	};

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes32 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[3]
	{
		typeof(OdDbIdPair),
		typeof(OdDbObject),
		typeof(OdDbIdMapping).MakeByRefType()
	};

	private static Type[] swigMethodTypes36 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes37 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes39 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes42 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes45 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes46 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes48 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes50 = new Type[2]
	{
		typeof(OdDbFiler),
		typeof(MaintReleaseVer).MakeByRefType()
	};

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdDbFiler) };

	private static Type[] swigMethodTypes52 = new Type[3]
	{
		typeof(DwgVersion),
		typeof(OdDbObjectId),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes53 = new Type[4]
	{
		typeof(OdDb_SaveType),
		typeof(DwgVersion),
		typeof(OdDbObjectId),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes54 = new Type[3]
	{
		typeof(OdDb_SaveType),
		typeof(DwgVersion),
		typeof(OdDbAuditInfo)
	};

	private static Type[] swigMethodTypes55 = new Type[0];

	private static Type[] swigMethodTypes56 = new Type[2]
	{
		typeof(string),
		typeof(OdDbField)
	};

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes61 = new Type[0];

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes63 = new Type[0];

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes65 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes66 = new Type[0];

	private static Type[] swigMethodTypes67 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes68 = new Type[2]
	{
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes69 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes70 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes71 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes72 = new Type[0];

	private static Type[] swigMethodTypes73 = new Type[2]
	{
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes74 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes75 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes76 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes77 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes78 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes79 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes80 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(OdDb_CellState)
	};

	private static Type[] swigMethodTypes81 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes82 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes83 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes84 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes85 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes86 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(string),
		typeof(OdValue)
	};

	private static Type[] swigMethodTypes87 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes88 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes89 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes90 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(uint)
	};

	private static Type[] swigMethodTypes91 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes92 = new Type[1] { typeof(OdCellRange) };

	private static Type[] swigMethodTypes93 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes94 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(uint)
	};

	private static Type[] swigMethodTypes95 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(OdValue_DataType).MakeByRefType(),
		typeof(OdValue_UnitType).MakeByRefType()
	};

	private static Type[] swigMethodTypes96 = new Type[5]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(OdValue_DataType).MakeByRefType(),
		typeof(OdValue_UnitType).MakeByRefType()
	};

	private static Type[] swigMethodTypes97 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(OdValue_DataType),
		typeof(OdValue_UnitType)
	};

	private static Type[] swigMethodTypes98 = new Type[5]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(OdValue_DataType),
		typeof(OdValue_UnitType)
	};

	private static Type[] swigMethodTypes99 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes100 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(uint)
	};

	private static Type[] swigMethodTypes101 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes102 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(string)
	};

	private static Type[] swigMethodTypes103 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes104 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(OdValue_FormatOption)
	};

	private static Type[] swigMethodTypes105 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(OdValue)
	};

	private static Type[] swigMethodTypes106 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(OdValue)
	};

	private static Type[] swigMethodTypes107 = new Type[5]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(OdValue),
		typeof(OdValue_ParseOption)
	};

	private static Type[] swigMethodTypes108 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes109 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(uint)
	};

	private static Type[] swigMethodTypes110 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(OdValue_FormatOption)
	};

	private static Type[] swigMethodTypes111 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes112 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(string)
	};

	private static Type[] swigMethodTypes113 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(uint)
	};

	private static Type[] swigMethodTypes114 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(uint)
	};

	private static Type[] swigMethodTypes115 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(string)
	};

	private static Type[] swigMethodTypes116 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes117 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(uint)
	};

	private static Type[] swigMethodTypes118 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes119 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes120 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(OdDb_OpenMode)
	};

	private static Type[] swigMethodTypes121 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes122 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(uint)
	};

	private static Type[] swigMethodTypes123 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes124 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes125 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes126 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes127 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(OdDbObjectId),
		typeof(string)
	};

	private static Type[] swigMethodTypes128 = new Type[5]
	{
		typeof(int),
		typeof(int),
		typeof(uint),
		typeof(OdDbObjectId),
		typeof(string)
	};

	private static Type[] swigMethodTypes129 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes130 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes131 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(OdDb_OpenMode)
	};

	private static Type[] swigMethodTypes132 = new Type[2]
	{
		typeof(OdCellRange),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes133 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes134 = new Type[3]
	{
		typeof(OdCellRange),
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes135 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes136 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes137 = new Type[0];

	private static Type[] swigMethodTypes138 = new Type[4]
	{
		typeof(int),
		typeof(int),
		typeof(OdDb_UpdateDirection),
		typeof(OdDb_UpdateOption)
	};

	private static Type[] swigMethodTypes139 = new Type[2]
	{
		typeof(OdDb_UpdateDirection),
		typeof(OdDb_UpdateOption)
	};

	private static Type[] swigMethodTypes140 = new Type[0];

	private static Type[] swigMethodTypes141 = new Type[2]
	{
		typeof(OdDbLinkedTableData),
		typeof(OdDb_TableCopyOption)
	};

	private static Type[] swigMethodTypes142 = new Type[5]
	{
		typeof(OdDbLinkedTableData),
		typeof(OdDb_TableCopyOption),
		typeof(OdCellRange),
		typeof(OdCellRange),
		typeof(OdCellRange)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbLinkedTableData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbLinkedTableData obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbLinkedTableData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbLinkedTableData cast(OdRxObject pObj)
	{
		OdDbLinkedTableData rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLinkedTableData>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_isASwigExplicitOdDbLinkedTableData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_queryXSwigExplicitOdDbLinkedTableData(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setSize(int nRows, int nCols)
	{
		if (SwigDerivedClassHasMethod("setSize", swigMethodTypes65))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setSizeSwigExplicitOdDbLinkedTableData(swigCPtr, nRows, nCols);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setSize(swigCPtr, nRows, nCols);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int numColumns()
	{
		int result = (SwigDerivedClassHasMethod("numColumns", swigMethodTypes66) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_numColumnsSwigExplicitOdDbLinkedTableData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_numColumns(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getColumnName(int nIndex)
	{
		string result = (SwigDerivedClassHasMethod("getColumnName", swigMethodTypes67) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getColumnNameSwigExplicitOdDbLinkedTableData(swigCPtr, nIndex) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getColumnName(swigCPtr, nIndex));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColumnName(int nIndex, string name)
	{
		if (SwigDerivedClassHasMethod("setColumnName", swigMethodTypes68))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setColumnNameSwigExplicitOdDbLinkedTableData(swigCPtr, nIndex, name);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setColumnName(swigCPtr, nIndex, name);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int appendColumn(int nNumCols)
	{
		int result = (SwigDerivedClassHasMethod("appendColumn", swigMethodTypes69) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_appendColumnSwigExplicitOdDbLinkedTableData(swigCPtr, nNumCols) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_appendColumn(swigCPtr, nNumCols));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int insertColumn(int nIndex, int nNumCols)
	{
		int result = (SwigDerivedClassHasMethod("insertColumn", swigMethodTypes70) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_insertColumnSwigExplicitOdDbLinkedTableData(swigCPtr, nIndex, nNumCols) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_insertColumn(swigCPtr, nIndex, nNumCols));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void deleteColumn(int nIndex, int nNumColsToDelete)
	{
		if (SwigDerivedClassHasMethod("deleteColumn", swigMethodTypes71))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_deleteColumnSwigExplicitOdDbLinkedTableData(swigCPtr, nIndex, nNumColsToDelete);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_deleteColumn(swigCPtr, nIndex, nNumColsToDelete);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int numRows()
	{
		int result = (SwigDerivedClassHasMethod("numRows", swigMethodTypes72) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_numRowsSwigExplicitOdDbLinkedTableData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_numRows(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool canInsert(int nIndex, bool bRow)
	{
		bool result = (SwigDerivedClassHasMethod("canInsert", swigMethodTypes73) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_canInsertSwigExplicitOdDbLinkedTableData(swigCPtr, nIndex, bRow) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_canInsert(swigCPtr, nIndex, bRow));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int appendRow(int nNumRows)
	{
		int result = (SwigDerivedClassHasMethod("appendRow", swigMethodTypes74) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_appendRowSwigExplicitOdDbLinkedTableData(swigCPtr, nNumRows) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_appendRow(swigCPtr, nNumRows));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int insertRow(int nIndex, int nNumRows)
	{
		int result = (SwigDerivedClassHasMethod("insertRow", swigMethodTypes75) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_insertRowSwigExplicitOdDbLinkedTableData(swigCPtr, nIndex, nNumRows) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_insertRow(swigCPtr, nIndex, nNumRows));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool canDelete(int nIndex, int nCount, bool bRow)
	{
		bool result = (SwigDerivedClassHasMethod("canDelete", swigMethodTypes76) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_canDeleteSwigExplicitOdDbLinkedTableData(swigCPtr, nIndex, nCount, bRow) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_canDelete(swigCPtr, nIndex, nCount, bRow));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void deleteRow(int nIndex, int nNumRowsToDelete)
	{
		if (SwigDerivedClassHasMethod("deleteRow", swigMethodTypes77))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_deleteRowSwigExplicitOdDbLinkedTableData(swigCPtr, nIndex, nNumRowsToDelete);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_deleteRow(swigCPtr, nIndex, nNumRowsToDelete);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isContentEditable(int nRow, int nCol)
	{
		bool result = (SwigDerivedClassHasMethod("isContentEditable", swigMethodTypes78) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_isContentEditableSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_isContentEditable(swigCPtr, nRow, nCol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDb_CellState cellState(int nRow, int nCol)
	{
		int result = (SwigDerivedClassHasMethod("cellState", swigMethodTypes79) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_cellStateSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_cellState(swigCPtr, nRow, nCol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellState)result;
	}

	public virtual void setCellState(int nRow, int nCol, OdDb_CellState nCellState)
	{
		if (SwigDerivedClassHasMethod("setCellState", swigMethodTypes80))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setCellStateSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol, (int)nCellState);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setCellState(swigCPtr, nRow, nCol, (int)nCellState);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getToolTip(int nRow, int nCol)
	{
		string result = (SwigDerivedClassHasMethod("getToolTip", swigMethodTypes81) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getToolTipSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getToolTip(swigCPtr, nRow, nCol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setToolTip(int nRow, int nCol, string sToolTip)
	{
		if (SwigDerivedClassHasMethod("setToolTip", swigMethodTypes82))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setToolTipSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol, sToolTip);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setToolTip(swigCPtr, nRow, nCol, sToolTip);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int getCustomData(int nRow, int nCol)
	{
		int result = (SwigDerivedClassHasMethod("getCustomData", swigMethodTypes83) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getCustomDataSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getCustomData__SWIG_0(swigCPtr, nRow, nCol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setCustomData(int nRow, int nCol, int nData)
	{
		if (SwigDerivedClassHasMethod("setCustomData", swigMethodTypes84))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setCustomDataSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, nData);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setCustomData__SWIG_0(swigCPtr, nRow, nCol, nData);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdValue getCustomData(int nRow, int nCol, string sKey)
	{
		OdValue result = new OdValue(SwigDerivedClassHasMethod("getCustomData", swigMethodTypes85) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getCustomDataSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, sKey) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getCustomData__SWIG_1(swigCPtr, nRow, nCol, sKey), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setCustomData(int nRow, int nCol, string sKey, OdValue pData)
	{
		if (SwigDerivedClassHasMethod("setCustomData", swigMethodTypes86))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setCustomDataSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, sKey, OdValue.getCPtr(pData));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setCustomData__SWIG_1(swigCPtr, nRow, nCol, sKey, OdValue.getCPtr(pData));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint numContents(int nRow, int nCol)
	{
		uint result = (SwigDerivedClassHasMethod("numContents", swigMethodTypes87) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_numContentsSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_numContents(swigCPtr, nRow, nCol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint createContent(int nRow, int nCol, int nIndex)
	{
		uint result = (SwigDerivedClassHasMethod("createContent", swigMethodTypes88) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_createContentSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol, nIndex) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_createContent(swigCPtr, nRow, nCol, nIndex));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void moveContent(int nRow, int nCol, int nFromIndex, int nToIndex)
	{
		if (SwigDerivedClassHasMethod("moveContent", swigMethodTypes89))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_moveContentSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol, nFromIndex, nToIndex);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_moveContent(swigCPtr, nRow, nCol, nFromIndex, nToIndex);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void deleteContent(int nRow, int nCol, uint nContent)
	{
		if (SwigDerivedClassHasMethod("deleteContent", swigMethodTypes90))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_deleteContentSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, nContent);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_deleteContent__SWIG_0(swigCPtr, nRow, nCol, nContent);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void deleteContent(int nRow, int nCol)
	{
		if (SwigDerivedClassHasMethod("deleteContent", swigMethodTypes91))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_deleteContentSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_deleteContent__SWIG_1(swigCPtr, nRow, nCol);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void deleteContent(OdCellRange range)
	{
		if (SwigDerivedClassHasMethod("deleteContent", swigMethodTypes92))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_deleteContentSwigExplicitOdDbLinkedTableData__SWIG_2(swigCPtr, OdCellRange.getCPtr(range));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_deleteContent__SWIG_2(swigCPtr, OdCellRange.getCPtr(range));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_CellContentType contentType(int nRow, int nCol)
	{
		int result = (SwigDerivedClassHasMethod("contentType", swigMethodTypes93) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_contentTypeSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_contentType__SWIG_0(swigCPtr, nRow, nCol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellContentType)result;
	}

	public virtual OdDb_CellContentType contentType(int nRow, int nCol, uint nContent)
	{
		int result = (SwigDerivedClassHasMethod("contentType", swigMethodTypes94) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_contentTypeSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_contentType__SWIG_1(swigCPtr, nRow, nCol, nContent));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellContentType)result;
	}

	public virtual void getDataType(int nRow, int nCol, out OdValue_DataType nDataType, out OdValue_UnitType nUnitType)
	{
		if (SwigDerivedClassHasMethod("getDataType", swigMethodTypes95))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getDataTypeSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, out nDataType, out nUnitType);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getDataType__SWIG_0(swigCPtr, nRow, nCol, out nDataType, out nUnitType);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getDataType(int nRow, int nCol, uint nContent, out OdValue_DataType nDataType, out OdValue_UnitType nUnitType)
	{
		if (SwigDerivedClassHasMethod("getDataType", swigMethodTypes96))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getDataTypeSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent, out nDataType, out nUnitType);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getDataType__SWIG_1(swigCPtr, nRow, nCol, nContent, out nDataType, out nUnitType);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDataType(int nRow, int nCol, OdValue_DataType nDataType, OdValue_UnitType nUnitType)
	{
		if (SwigDerivedClassHasMethod("setDataType", swigMethodTypes97))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setDataTypeSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, (int)nDataType, (int)nUnitType);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setDataType__SWIG_0(swigCPtr, nRow, nCol, (int)nDataType, (int)nUnitType);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDataType(int nRow, int nCol, uint nContent, OdValue_DataType nDataType, OdValue_UnitType nUnitType)
	{
		if (SwigDerivedClassHasMethod("setDataType", swigMethodTypes98))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setDataTypeSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent, (int)nDataType, (int)nUnitType);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setDataType__SWIG_1(swigCPtr, nRow, nCol, nContent, (int)nDataType, (int)nUnitType);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string dataFormat(int nRow, int nCol)
	{
		string result = (SwigDerivedClassHasMethod("dataFormat", swigMethodTypes99) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_dataFormatSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_dataFormat__SWIG_0(swigCPtr, nRow, nCol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string dataFormat(int nRow, int nCol, uint nContent)
	{
		string result = (SwigDerivedClassHasMethod("dataFormat", swigMethodTypes100) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_dataFormatSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_dataFormat__SWIG_1(swigCPtr, nRow, nCol, nContent));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDataFormat(int nRow, int nCol, string sFormat)
	{
		if (SwigDerivedClassHasMethod("setDataFormat", swigMethodTypes101))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setDataFormatSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, sFormat);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setDataFormat__SWIG_0(swigCPtr, nRow, nCol, sFormat);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDataFormat(int nRow, int nCol, uint nContent, string sFormat)
	{
		if (SwigDerivedClassHasMethod("setDataFormat", swigMethodTypes102))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setDataFormatSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent, sFormat);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setDataFormat__SWIG_1(swigCPtr, nRow, nCol, nContent, sFormat);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdValue getValue(int nRow, int nCol)
	{
		OdValue result = new OdValue(SwigDerivedClassHasMethod("getValue", swigMethodTypes103) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getValueSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getValue__SWIG_0(swigCPtr, nRow, nCol), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdValue getValue(int nRow, int nCol, uint nContent, OdValue_FormatOption nOption)
	{
		OdValue result = new OdValue(SwigDerivedClassHasMethod("getValue", swigMethodTypes104) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getValueSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent, (int)nOption) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getValue__SWIG_1(swigCPtr, nRow, nCol, nContent, (int)nOption), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setValue(int nRow, int nCol, OdValue value)
	{
		if (SwigDerivedClassHasMethod("setValue", swigMethodTypes105))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setValueSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, OdValue.getCPtr(value));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setValue__SWIG_0(swigCPtr, nRow, nCol, OdValue.getCPtr(value));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setValue(int nRow, int nCol, uint nContent, OdValue value)
	{
		if (SwigDerivedClassHasMethod("setValue", swigMethodTypes106))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setValueSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent, OdValue.getCPtr(value));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setValue__SWIG_1(swigCPtr, nRow, nCol, nContent, OdValue.getCPtr(value));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setValue(int nRow, int nCol, uint nContent, OdValue value, OdValue_ParseOption nOption)
	{
		if (SwigDerivedClassHasMethod("setValue", swigMethodTypes107))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setValueSwigExplicitOdDbLinkedTableData__SWIG_2(swigCPtr, nRow, nCol, nContent, OdValue.getCPtr(value), (int)nOption);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setValue__SWIG_2(swigCPtr, nRow, nCol, nContent, OdValue.getCPtr(value), (int)nOption);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getText(int nRow, int nCol)
	{
		string result = (SwigDerivedClassHasMethod("getText", swigMethodTypes108) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getTextSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getText__SWIG_0(swigCPtr, nRow, nCol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getText(int nRow, int nCol, uint nContent)
	{
		string result = (SwigDerivedClassHasMethod("getText", swigMethodTypes109) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getTextSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getText__SWIG_1(swigCPtr, nRow, nCol, nContent));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getText(int nRow, int nCol, uint nContent, OdValue_FormatOption nOption)
	{
		string result = (SwigDerivedClassHasMethod("getText", swigMethodTypes110) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getTextSwigExplicitOdDbLinkedTableData__SWIG_2(swigCPtr, nRow, nCol, nContent, (int)nOption) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getText__SWIG_2(swigCPtr, nRow, nCol, nContent, (int)nOption));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setText(int nRow, int nCol, string sText)
	{
		if (SwigDerivedClassHasMethod("setText", swigMethodTypes111))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setTextSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, sText);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setText__SWIG_0(swigCPtr, nRow, nCol, sText);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setText(int nRow, int nCol, uint nContent, string sText)
	{
		if (SwigDerivedClassHasMethod("setText", swigMethodTypes112))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setTextSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent, sText);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setText__SWIG_1(swigCPtr, nRow, nCol, nContent, sText);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hasFormula(int nRow, int nCol, uint nContent)
	{
		bool result = (SwigDerivedClassHasMethod("hasFormula", swigMethodTypes113) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_hasFormulaSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol, nContent) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_hasFormula(swigCPtr, nRow, nCol, nContent));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFormula(int nRow, int nCol, uint nContent)
	{
		string result = (SwigDerivedClassHasMethod("getFormula", swigMethodTypes114) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getFormulaSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol, nContent) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getFormula(swigCPtr, nRow, nCol, nContent));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFormula(int nRow, int nCol, uint nContent, string sFormula)
	{
		if (SwigDerivedClassHasMethod("setFormula", swigMethodTypes115))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setFormulaSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol, nContent, sFormula);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setFormula(swigCPtr, nRow, nCol, nContent, sFormula);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId getFieldId(int nRow, int nCol)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("getFieldId", swigMethodTypes116) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getFieldIdSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getFieldId__SWIG_0(swigCPtr, nRow, nCol), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getFieldId(int nRow, int nCol, uint nContent)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("getFieldId", swigMethodTypes117) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getFieldIdSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getFieldId__SWIG_1(swigCPtr, nRow, nCol, nContent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFieldId(int nRow, int nCol, OdDbObjectId idField)
	{
		if (SwigDerivedClassHasMethod("setFieldId", swigMethodTypes118))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setFieldIdSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, OdDbObjectId.getCPtr(idField));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setFieldId__SWIG_0(swigCPtr, nRow, nCol, OdDbObjectId.getCPtr(idField));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFieldId(int nRow, int nCol, uint nContent, OdDbObjectId idField)
	{
		if (SwigDerivedClassHasMethod("setFieldId", swigMethodTypes119))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setFieldIdSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent, OdDbObjectId.getCPtr(idField));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setFieldId__SWIG_1(swigCPtr, nRow, nCol, nContent, OdDbObjectId.getCPtr(idField));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbField getField(int nRow, int nCol, uint nContent, OdDb_OpenMode mode)
	{
		OdDbField rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbField>(SwigDerivedClassHasMethod("getField", swigMethodTypes120) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getFieldSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol, nContent, (int)mode) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getField(swigCPtr, nRow, nCol, nContent, (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbObjectId getBlockTableRecordId(int nRow, int nCol)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("getBlockTableRecordId", swigMethodTypes121) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getBlockTableRecordIdSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getBlockTableRecordId__SWIG_0(swigCPtr, nRow, nCol), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getBlockTableRecordId(int nRow, int nCol, uint nContent)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("getBlockTableRecordId", swigMethodTypes122) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getBlockTableRecordIdSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getBlockTableRecordId__SWIG_1(swigCPtr, nRow, nCol, nContent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBlockTableRecordId(int nRow, int nCol, OdDbObjectId idBTR)
	{
		if (SwigDerivedClassHasMethod("setBlockTableRecordId", swigMethodTypes123))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setBlockTableRecordIdSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, OdDbObjectId.getCPtr(idBTR));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setBlockTableRecordId__SWIG_0(swigCPtr, nRow, nCol, OdDbObjectId.getCPtr(idBTR));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBlockTableRecordId(int nRow, int nCol, uint nContent, OdDbObjectId idBTR)
	{
		if (SwigDerivedClassHasMethod("setBlockTableRecordId", swigMethodTypes124))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setBlockTableRecordIdSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent, OdDbObjectId.getCPtr(idBTR));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setBlockTableRecordId__SWIG_1(swigCPtr, nRow, nCol, nContent, OdDbObjectId.getCPtr(idBTR));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getBlockAttributeValue(int nRow, int nCol, OdDbObjectId idAttDef)
	{
		string result = (SwigDerivedClassHasMethod("getBlockAttributeValue", swigMethodTypes125) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getBlockAttributeValueSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, OdDbObjectId.getCPtr(idAttDef)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getBlockAttributeValue__SWIG_0(swigCPtr, nRow, nCol, OdDbObjectId.getCPtr(idAttDef)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getBlockAttributeValue(int nRow, int nCol, uint nContent, OdDbObjectId idAttDef)
	{
		string result = (SwigDerivedClassHasMethod("getBlockAttributeValue", swigMethodTypes126) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getBlockAttributeValueSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent, OdDbObjectId.getCPtr(idAttDef)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getBlockAttributeValue__SWIG_1(swigCPtr, nRow, nCol, nContent, OdDbObjectId.getCPtr(idAttDef)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBlockAttributeValue(int nRow, int nCol, OdDbObjectId idAttDef, string sAttValue)
	{
		if (SwigDerivedClassHasMethod("setBlockAttributeValue", swigMethodTypes127))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setBlockAttributeValueSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, OdDbObjectId.getCPtr(idAttDef), sAttValue);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setBlockAttributeValue__SWIG_0(swigCPtr, nRow, nCol, OdDbObjectId.getCPtr(idAttDef), sAttValue);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBlockAttributeValue(int nRow, int nCol, uint nContent, OdDbObjectId idAttDef, string sAttValue)
	{
		if (SwigDerivedClassHasMethod("setBlockAttributeValue", swigMethodTypes128))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setBlockAttributeValueSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, nContent, OdDbObjectId.getCPtr(idAttDef), sAttValue);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setBlockAttributeValue__SWIG_1(swigCPtr, nRow, nCol, nContent, OdDbObjectId.getCPtr(idAttDef), sAttValue);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isLinked(int nRow, int nCol)
	{
		bool result = (SwigDerivedClassHasMethod("isLinked", swigMethodTypes129) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_isLinkedSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_isLinked(swigCPtr, nRow, nCol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getDataLink(int nRow, int nCol)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("getDataLink", swigMethodTypes130) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getDataLinkSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getDataLink__SWIG_0(swigCPtr, nRow, nCol), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbDataLink getDataLink(int nRow, int nCol, OdDb_OpenMode mode)
	{
		OdDbDataLink rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataLink>(SwigDerivedClassHasMethod("getDataLink", swigMethodTypes131) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getDataLinkSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, nRow, nCol, (int)mode) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getDataLink__SWIG_1(swigCPtr, nRow, nCol, (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual int getDataLink(OdCellRange pRange, OdDbObjectIdArray dataLinkIds)
	{
		int result = (SwigDerivedClassHasMethod("getDataLink", swigMethodTypes132) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getDataLinkSwigExplicitOdDbLinkedTableData__SWIG_2(swigCPtr, OdCellRange.getCPtr(pRange), OdDbObjectIdArray.getCPtr(dataLinkIds)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getDataLink__SWIG_2(swigCPtr, OdCellRange.getCPtr(pRange), OdDbObjectIdArray.getCPtr(dataLinkIds)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDataLink(int nRow, int nCol, OdDbObjectId idDataLink, bool bUpdate)
	{
		if (SwigDerivedClassHasMethod("setDataLink", swigMethodTypes133))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setDataLinkSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, OdDbObjectId.getCPtr(idDataLink), bUpdate);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setDataLink__SWIG_0(swigCPtr, nRow, nCol, OdDbObjectId.getCPtr(idDataLink), bUpdate);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDataLink(OdCellRange range, OdDbObjectId idDataLink, bool bUpdate)
	{
		if (SwigDerivedClassHasMethod("setDataLink", swigMethodTypes134))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setDataLinkSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, OdCellRange.getCPtr(range), OdDbObjectId.getCPtr(idDataLink), bUpdate);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_setDataLink__SWIG_1(swigCPtr, OdCellRange.getCPtr(range), OdDbObjectId.getCPtr(idDataLink), bUpdate);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCellRange getDataLinkRange(int nRow, int nCol)
	{
		OdCellRange result = new OdCellRange(SwigDerivedClassHasMethod("getDataLinkRange", swigMethodTypes135) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getDataLinkRangeSwigExplicitOdDbLinkedTableData(swigCPtr, nRow, nCol) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getDataLinkRange(swigCPtr, nRow, nCol), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void removeDataLink(int nRow, int nCol)
	{
		if (SwigDerivedClassHasMethod("removeDataLink", swigMethodTypes136))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_removeDataLinkSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_removeDataLink__SWIG_0(swigCPtr, nRow, nCol);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeDataLink()
	{
		if (SwigDerivedClassHasMethod("removeDataLink", swigMethodTypes137))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_removeDataLinkSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_removeDataLink__SWIG_1(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void updateDataLink(int nRow, int nCol, OdDb_UpdateDirection nDir, OdDb_UpdateOption nOption)
	{
		if (SwigDerivedClassHasMethod("updateDataLink", swigMethodTypes138))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_updateDataLinkSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, nRow, nCol, (int)nDir, (int)nOption);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_updateDataLink__SWIG_0(swigCPtr, nRow, nCol, (int)nDir, (int)nOption);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void updateDataLink(OdDb_UpdateDirection nDir, OdDb_UpdateOption nOption)
	{
		if (SwigDerivedClassHasMethod("updateDataLink", swigMethodTypes139))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_updateDataLinkSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, (int)nDir, (int)nOption);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_updateDataLink__SWIG_1(swigCPtr, (int)nDir, (int)nOption);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void clear()
	{
		if (SwigDerivedClassHasMethod("clear", swigMethodTypes140))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_clearSwigExplicitOdDbLinkedTableData(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_clear(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void copyFrom(OdRxObject pSource)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_copyFromSwigExplicitOdDbLinkedTableData__SWIG_0(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_copyFrom__SWIG_0(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void copyFrom(OdDbLinkedTableData pSrc, OdDb_TableCopyOption nOption)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes141))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_copyFromSwigExplicitOdDbLinkedTableData__SWIG_1(swigCPtr, getCPtr(pSrc), (int)nOption);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_copyFrom__SWIG_1(swigCPtr, getCPtr(pSrc), (int)nOption);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void copyFrom(OdDbLinkedTableData pSrc, OdDb_TableCopyOption nOption, OdCellRange srcRange, OdCellRange targetRange, OdCellRange pNewTargetRange)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes142))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_copyFromSwigExplicitOdDbLinkedTableData__SWIG_2(swigCPtr, getCPtr(pSrc), (int)nOption, OdCellRange.getCPtr(srcRange), OdCellRange.getCPtr(targetRange), OdCellRange.getCPtr(pNewTargetRange));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_copyFrom__SWIG_2(swigCPtr, getCPtr(pSrc), (int)nOption, OdCellRange.getCPtr(srcRange), OdCellRange.getCPtr(targetRange), OdCellRange.getCPtr(pNewTargetRange));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbTableIterator getIterator()
	{
		OdDbTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getIterator__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbTableIterator getIterator(OdCellRange pRange, OdDb_TableIteratorOption nOption)
	{
		OdDbTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getIterator__SWIG_1(swigCPtr, OdCellRange.getCPtr(pRange), (int)nOption), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_dwgInFieldsSwigExplicitOdDbLinkedTableData(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dwgOutFields(OdDbDwgFiler pFiler)
	{
		if (SwigDerivedClassHasMethod("dwgOutFields", swigMethodTypes22))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_dwgOutFieldsSwigExplicitOdDbLinkedTableData(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_dxfInFieldsSwigExplicitOdDbLinkedTableData(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dxfOutFields(OdDbDxfFiler pFiler)
	{
		if (SwigDerivedClassHasMethod("dxfOutFields", swigMethodTypes24))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_dxfOutFieldsSwigExplicitOdDbLinkedTableData(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbLinkedTableData createObject()
	{
		OdDbLinkedTableData rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLinkedTableData>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_createObject(), bOwn: true, bTryAddToTransaction: true);
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
			swigDelegate2 = SwigDirectorMethodcopyFrom__SWIG_0;
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
		if (SwigDerivedClassHasMethod("subViewportDrawLogicalFlags", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsubViewportDrawLogicalFlags;
		}
		if (SwigDerivedClassHasMethod("subRegenSupportFlags", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsubRegenSupportFlags;
		}
		if (SwigDerivedClassHasMethod("setOwnerId", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetOwnerId;
		}
		if (SwigDerivedClassHasMethod("subOpen", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsubOpen;
		}
		if (SwigDerivedClassHasMethod("subClose", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsubClose;
		}
		if (SwigDerivedClassHasMethod("subErase", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsubErase;
		}
		if (SwigDerivedClassHasMethod("subHandOverTo", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsubHandOverTo;
		}
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsubSwapIdWith__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsubSwapIdWith__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsubSwapIdWith__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("audit", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodaudit;
		}
		if (SwigDerivedClassHasMethod("dxfIn", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethoddxfIn;
		}
		if (SwigDerivedClassHasMethod("dxfOut", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethoddxfOut;
		}
		if (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethoddwgInFields;
		}
		if (SwigDerivedClassHasMethod("dwgOutFields", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethoddwgOutFields;
		}
		if (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethoddxfInFields;
		}
		if (SwigDerivedClassHasMethod("dxfOutFields", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethoddxfOutFields;
		}
		if (SwigDerivedClassHasMethod("dxfInFields_R12", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethoddxfInFields_R12;
		}
		if (SwigDerivedClassHasMethod("dxfOutFields_R12", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethoddxfOutFields_R12;
		}
		if (SwigDerivedClassHasMethod("mergeStyle", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodmergeStyle;
		}
		if (SwigDerivedClassHasMethod("xData", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodxData;
		}
		if (SwigDerivedClassHasMethod("setXData", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodsetXData;
		}
		if (SwigDerivedClassHasMethod("applyPartialUndo", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodapplyPartialUndo;
		}
		if (SwigDerivedClassHasMethod("addPersistentReactor", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodaddPersistentReactor;
		}
		if (SwigDerivedClassHasMethod("removePersistentReactor", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodremovePersistentReactor;
		}
		if (SwigDerivedClassHasMethod("recvPropagateModify", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodrecvPropagateModify;
		}
		if (SwigDerivedClassHasMethod("xmitPropagateModify", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodxmitPropagateModify;
		}
		if (SwigDerivedClassHasMethod("appendToOwner", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodappendToOwner;
		}
		if (SwigDerivedClassHasMethod("copied", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodcopied;
		}
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethoderased__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethoderased__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("goodbye", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodgoodbye;
		}
		if (SwigDerivedClassHasMethod("openedForModify", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodopenedForModify;
		}
		if (SwigDerivedClassHasMethod("modified", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodmodified;
		}
		if (SwigDerivedClassHasMethod("subObjModified", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodsubObjModified;
		}
		if (SwigDerivedClassHasMethod("modifyUndone", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodmodifyUndone;
		}
		if (SwigDerivedClassHasMethod("modifiedXData", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodmodifiedXData;
		}
		if (SwigDerivedClassHasMethod("unappended", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodunappended;
		}
		if (SwigDerivedClassHasMethod("reappended", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodreappended;
		}
		if (SwigDerivedClassHasMethod("objectClosed", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodobjectClosed;
		}
		if (SwigDerivedClassHasMethod("modifiedGraphics", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodmodifiedGraphics;
		}
		if (SwigDerivedClassHasMethod("copyMeFrom", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodcopyMeFrom;
		}
		if (SwigDerivedClassHasMethod("getObjectSaveVersion", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodgetObjectSaveVersion__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getObjectSaveVersion", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodgetObjectSaveVersion__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("decomposeForSave", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethoddecomposeForSave__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("decomposeForSave", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethoddecomposeForSave__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("composeForLoad", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodcomposeForLoad;
		}
		if (SwigDerivedClassHasMethod("drawable", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethoddrawable;
		}
		if (SwigDerivedClassHasMethod("setField", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodsetField;
		}
		if (SwigDerivedClassHasMethod("removeField", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodremoveField__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("removeField", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodremoveField__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("saveAsClass", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodsaveAsClass;
		}
		if (SwigDerivedClassHasMethod("subGetClassID", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodsubGetClassID;
		}
		if (SwigDerivedClassHasMethod("name", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodname;
		}
		if (SwigDerivedClassHasMethod("setName", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodsetName;
		}
		if (SwigDerivedClassHasMethod("description", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethoddescription;
		}
		if (SwigDerivedClassHasMethod("setDescription", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodsetDescription;
		}
		if (SwigDerivedClassHasMethod("setSize", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodsetSize;
		}
		if (SwigDerivedClassHasMethod("numColumns", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodnumColumns;
		}
		if (SwigDerivedClassHasMethod("getColumnName", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodgetColumnName;
		}
		if (SwigDerivedClassHasMethod("setColumnName", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodsetColumnName;
		}
		if (SwigDerivedClassHasMethod("appendColumn", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodappendColumn;
		}
		if (SwigDerivedClassHasMethod("insertColumn", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodinsertColumn;
		}
		if (SwigDerivedClassHasMethod("deleteColumn", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethoddeleteColumn;
		}
		if (SwigDerivedClassHasMethod("numRows", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodnumRows;
		}
		if (SwigDerivedClassHasMethod("canInsert", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodcanInsert;
		}
		if (SwigDerivedClassHasMethod("appendRow", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodappendRow;
		}
		if (SwigDerivedClassHasMethod("insertRow", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodinsertRow;
		}
		if (SwigDerivedClassHasMethod("canDelete", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodcanDelete;
		}
		if (SwigDerivedClassHasMethod("deleteRow", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethoddeleteRow;
		}
		if (SwigDerivedClassHasMethod("isContentEditable", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodisContentEditable;
		}
		if (SwigDerivedClassHasMethod("cellState", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodcellState;
		}
		if (SwigDerivedClassHasMethod("setCellState", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodsetCellState;
		}
		if (SwigDerivedClassHasMethod("getToolTip", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodgetToolTip;
		}
		if (SwigDerivedClassHasMethod("setToolTip", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodsetToolTip;
		}
		if (SwigDerivedClassHasMethod("getCustomData", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodgetCustomData__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setCustomData", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodsetCustomData__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getCustomData", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodgetCustomData__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setCustomData", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodsetCustomData__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("numContents", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodnumContents;
		}
		if (SwigDerivedClassHasMethod("createContent", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodcreateContent;
		}
		if (SwigDerivedClassHasMethod("moveContent", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodmoveContent;
		}
		if (SwigDerivedClassHasMethod("deleteContent", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethoddeleteContent__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("deleteContent", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethoddeleteContent__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("deleteContent", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethoddeleteContent__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("contentType", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodcontentType__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("contentType", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodcontentType__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getDataType", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodgetDataType__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getDataType", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodgetDataType__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setDataType", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodsetDataType__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDataType", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodsetDataType__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("dataFormat", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethoddataFormat__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("dataFormat", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethoddataFormat__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setDataFormat", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodsetDataFormat__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDataFormat", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethodsetDataFormat__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getValue", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethodgetValue__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getValue", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethodgetValue__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setValue", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodsetValue__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setValue", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethodsetValue__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setValue", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodsetValue__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getText", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethodgetText__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getText", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodgetText__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getText", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodgetText__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setText", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodsetText__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setText", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodsetText__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("hasFormula", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethodhasFormula;
		}
		if (SwigDerivedClassHasMethod("getFormula", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodgetFormula;
		}
		if (SwigDerivedClassHasMethod("setFormula", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethodsetFormula;
		}
		if (SwigDerivedClassHasMethod("getFieldId", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethodgetFieldId__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getFieldId", swigMethodTypes117))
		{
			swigDelegate117 = SwigDirectorMethodgetFieldId__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setFieldId", swigMethodTypes118))
		{
			swigDelegate118 = SwigDirectorMethodsetFieldId__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setFieldId", swigMethodTypes119))
		{
			swigDelegate119 = SwigDirectorMethodsetFieldId__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getField", swigMethodTypes120))
		{
			swigDelegate120 = SwigDirectorMethodgetField;
		}
		if (SwigDerivedClassHasMethod("getBlockTableRecordId", swigMethodTypes121))
		{
			swigDelegate121 = SwigDirectorMethodgetBlockTableRecordId__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getBlockTableRecordId", swigMethodTypes122))
		{
			swigDelegate122 = SwigDirectorMethodgetBlockTableRecordId__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setBlockTableRecordId", swigMethodTypes123))
		{
			swigDelegate123 = SwigDirectorMethodsetBlockTableRecordId__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setBlockTableRecordId", swigMethodTypes124))
		{
			swigDelegate124 = SwigDirectorMethodsetBlockTableRecordId__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getBlockAttributeValue", swigMethodTypes125))
		{
			swigDelegate125 = SwigDirectorMethodgetBlockAttributeValue__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getBlockAttributeValue", swigMethodTypes126))
		{
			swigDelegate126 = SwigDirectorMethodgetBlockAttributeValue__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setBlockAttributeValue", swigMethodTypes127))
		{
			swigDelegate127 = SwigDirectorMethodsetBlockAttributeValue__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setBlockAttributeValue", swigMethodTypes128))
		{
			swigDelegate128 = SwigDirectorMethodsetBlockAttributeValue__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isLinked", swigMethodTypes129))
		{
			swigDelegate129 = SwigDirectorMethodisLinked;
		}
		if (SwigDerivedClassHasMethod("getDataLink", swigMethodTypes130))
		{
			swigDelegate130 = SwigDirectorMethodgetDataLink__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getDataLink", swigMethodTypes131))
		{
			swigDelegate131 = SwigDirectorMethodgetDataLink__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getDataLink", swigMethodTypes132))
		{
			swigDelegate132 = SwigDirectorMethodgetDataLink__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setDataLink", swigMethodTypes133))
		{
			swigDelegate133 = SwigDirectorMethodsetDataLink__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDataLink", swigMethodTypes134))
		{
			swigDelegate134 = SwigDirectorMethodsetDataLink__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getDataLinkRange", swigMethodTypes135))
		{
			swigDelegate135 = SwigDirectorMethodgetDataLinkRange;
		}
		if (SwigDerivedClassHasMethod("removeDataLink", swigMethodTypes136))
		{
			swigDelegate136 = SwigDirectorMethodremoveDataLink__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("removeDataLink", swigMethodTypes137))
		{
			swigDelegate137 = SwigDirectorMethodremoveDataLink__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("updateDataLink", swigMethodTypes138))
		{
			swigDelegate138 = SwigDirectorMethodupdateDataLink__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("updateDataLink", swigMethodTypes139))
		{
			swigDelegate139 = SwigDirectorMethodupdateDataLink__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("clear", swigMethodTypes140))
		{
			swigDelegate140 = SwigDirectorMethodclear;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes141))
		{
			swigDelegate141 = SwigDirectorMethodcopyFrom__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes142))
		{
			swigDelegate142 = SwigDirectorMethodcopyFrom__SWIG_2;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLinkedTableData_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125, swigDelegate126, swigDelegate127, swigDelegate128, swigDelegate129, swigDelegate130, swigDelegate131, swigDelegate132, swigDelegate133, swigDelegate134, swigDelegate135, swigDelegate136, swigDelegate137, swigDelegate138, swigDelegate139, swigDelegate140, swigDelegate141, swigDelegate142);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbLinkedTableData));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom__SWIG_0(IntPtr pSource)
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

	private uint SwigDirectorMethodsubViewportDrawLogicalFlags(IntPtr vd)
	{
		return subViewportDrawLogicalFlags(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiViewportDraw>(vd, bOwn: false, bTryAddToTransaction: false));
	}

	private uint SwigDirectorMethodsubRegenSupportFlags()
	{
		return subRegenSupportFlags();
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

	private void SwigDirectorMethodappendToOwner(IntPtr idPair, IntPtr pOwnerObject, IntPtr idMap)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			appendToOwner(new OdDbIdPair(idPair, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOwnerObject, bOwn: false, bTryAddToTransaction: false), ref idMap2);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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
			IntPtr intPtr = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != intPtr)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
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

	private int SwigDirectorMethodsubGetClassID(IntPtr pClsid)
	{
		return (int)subGetClassID(pClsid);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodname()
	{
		return name();
	}

	private void SwigDirectorMethodsetName([MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		try
		{
			setName(name);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethoddescription()
	{
		return description();
	}

	private void SwigDirectorMethodsetDescription([MarshalAs(UnmanagedType.LPWStr)] string description)
	{
		try
		{
			setDescription(description);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetSize(int nRows, int nCols)
	{
		try
		{
			setSize(nRows, nCols);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodnumColumns()
	{
		return numColumns();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetColumnName(int nIndex)
	{
		return getColumnName(nIndex);
	}

	private void SwigDirectorMethodsetColumnName(int nIndex, [MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		try
		{
			setColumnName(nIndex, name);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodappendColumn(int nNumCols)
	{
		return appendColumn(nNumCols);
	}

	private int SwigDirectorMethodinsertColumn(int nIndex, int nNumCols)
	{
		return insertColumn(nIndex, nNumCols);
	}

	private void SwigDirectorMethoddeleteColumn(int nIndex, int nNumColsToDelete)
	{
		try
		{
			deleteColumn(nIndex, nNumColsToDelete);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodnumRows()
	{
		return numRows();
	}

	private bool SwigDirectorMethodcanInsert(int nIndex, bool bRow)
	{
		return canInsert(nIndex, bRow);
	}

	private int SwigDirectorMethodappendRow(int nNumRows)
	{
		return appendRow(nNumRows);
	}

	private int SwigDirectorMethodinsertRow(int nIndex, int nNumRows)
	{
		return insertRow(nIndex, nNumRows);
	}

	private bool SwigDirectorMethodcanDelete(int nIndex, int nCount, bool bRow)
	{
		return canDelete(nIndex, nCount, bRow);
	}

	private void SwigDirectorMethoddeleteRow(int nIndex, int nNumRowsToDelete)
	{
		try
		{
			deleteRow(nIndex, nNumRowsToDelete);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisContentEditable(int nRow, int nCol)
	{
		return isContentEditable(nRow, nCol);
	}

	private int SwigDirectorMethodcellState(int nRow, int nCol)
	{
		return (int)cellState(nRow, nCol);
	}

	private void SwigDirectorMethodsetCellState(int nRow, int nCol, int nCellState)
	{
		try
		{
			setCellState(nRow, nCol, (OdDb_CellState)nCellState);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetToolTip(int nRow, int nCol)
	{
		return getToolTip(nRow, nCol);
	}

	private void SwigDirectorMethodsetToolTip(int nRow, int nCol, [MarshalAs(UnmanagedType.LPWStr)] string sToolTip)
	{
		try
		{
			setToolTip(nRow, nCol, sToolTip);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodgetCustomData__SWIG_0(int nRow, int nCol)
	{
		return getCustomData(nRow, nCol);
	}

	private void SwigDirectorMethodsetCustomData__SWIG_0(int nRow, int nCol, int nData)
	{
		try
		{
			setCustomData(nRow, nCol, nData);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetCustomData__SWIG_1(int nRow, int nCol, [MarshalAs(UnmanagedType.LPWStr)] string sKey)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdValue.getCPtr(getCustomData(nRow, nCol, sKey)).Handle;
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

	private void SwigDirectorMethodsetCustomData__SWIG_1(int nRow, int nCol, [MarshalAs(UnmanagedType.LPWStr)] string sKey, IntPtr pData)
	{
		try
		{
			setCustomData(nRow, nCol, sKey, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(pData, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethodnumContents(int nRow, int nCol)
	{
		return numContents(nRow, nCol);
	}

	private uint SwigDirectorMethodcreateContent(int nRow, int nCol, int nIndex)
	{
		return createContent(nRow, nCol, nIndex);
	}

	private void SwigDirectorMethodmoveContent(int nRow, int nCol, int nFromIndex, int nToIndex)
	{
		try
		{
			moveContent(nRow, nCol, nFromIndex, nToIndex);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddeleteContent__SWIG_0(int nRow, int nCol, uint nContent)
	{
		try
		{
			deleteContent(nRow, nCol, nContent);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddeleteContent__SWIG_1(int nRow, int nCol)
	{
		try
		{
			deleteContent(nRow, nCol);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddeleteContent__SWIG_2(IntPtr range)
	{
		try
		{
			deleteContent(new OdCellRange(range, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodcontentType__SWIG_0(int nRow, int nCol)
	{
		return (int)contentType(nRow, nCol);
	}

	private int SwigDirectorMethodcontentType__SWIG_1(int nRow, int nCol, uint nContent)
	{
		return (int)contentType(nRow, nCol, nContent);
	}

	private void SwigDirectorMethodgetDataType__SWIG_0(int nRow, int nCol, OdValue_DataType nDataType, OdValue_UnitType nUnitType)
	{
		try
		{
			getDataType(nRow, nCol, out nDataType, out nUnitType);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodgetDataType__SWIG_1(int nRow, int nCol, uint nContent, OdValue_DataType nDataType, OdValue_UnitType nUnitType)
	{
		try
		{
			getDataType(nRow, nCol, nContent, out nDataType, out nUnitType);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDataType__SWIG_0(int nRow, int nCol, int nDataType, int nUnitType)
	{
		try
		{
			setDataType(nRow, nCol, (OdValue_DataType)nDataType, (OdValue_UnitType)nUnitType);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDataType__SWIG_1(int nRow, int nCol, uint nContent, int nDataType, int nUnitType)
	{
		try
		{
			setDataType(nRow, nCol, nContent, (OdValue_DataType)nDataType, (OdValue_UnitType)nUnitType);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethoddataFormat__SWIG_0(int nRow, int nCol)
	{
		return dataFormat(nRow, nCol);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethoddataFormat__SWIG_1(int nRow, int nCol, uint nContent)
	{
		return dataFormat(nRow, nCol, nContent);
	}

	private void SwigDirectorMethodsetDataFormat__SWIG_0(int nRow, int nCol, [MarshalAs(UnmanagedType.LPWStr)] string sFormat)
	{
		try
		{
			setDataFormat(nRow, nCol, sFormat);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDataFormat__SWIG_1(int nRow, int nCol, uint nContent, [MarshalAs(UnmanagedType.LPWStr)] string sFormat)
	{
		try
		{
			setDataFormat(nRow, nCol, nContent, sFormat);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetValue__SWIG_0(int nRow, int nCol)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdValue.getCPtr(getValue(nRow, nCol)).Handle;
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

	private IntPtr SwigDirectorMethodgetValue__SWIG_1(int nRow, int nCol, uint nContent, int nOption)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdValue.getCPtr(getValue(nRow, nCol, nContent, (OdValue_FormatOption)nOption)).Handle;
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

	private void SwigDirectorMethodsetValue__SWIG_0(int nRow, int nCol, IntPtr value)
	{
		try
		{
			setValue(nRow, nCol, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(value, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetValue__SWIG_1(int nRow, int nCol, uint nContent, IntPtr value)
	{
		try
		{
			setValue(nRow, nCol, nContent, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(value, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetValue__SWIG_2(int nRow, int nCol, uint nContent, IntPtr value, int nOption)
	{
		try
		{
			setValue(nRow, nCol, nContent, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(value, bOwn: false, bTryAddToTransaction: false), (OdValue_ParseOption)nOption);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetText__SWIG_0(int nRow, int nCol)
	{
		return getText(nRow, nCol);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetText__SWIG_1(int nRow, int nCol, uint nContent)
	{
		return getText(nRow, nCol, nContent);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetText__SWIG_2(int nRow, int nCol, uint nContent, int nOption)
	{
		return getText(nRow, nCol, nContent, (OdValue_FormatOption)nOption);
	}

	private void SwigDirectorMethodsetText__SWIG_0(int nRow, int nCol, [MarshalAs(UnmanagedType.LPWStr)] string sText)
	{
		try
		{
			setText(nRow, nCol, sText);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetText__SWIG_1(int nRow, int nCol, uint nContent, [MarshalAs(UnmanagedType.LPWStr)] string sText)
	{
		try
		{
			setText(nRow, nCol, nContent, sText);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodhasFormula(int nRow, int nCol, uint nContent)
	{
		return hasFormula(nRow, nCol, nContent);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFormula(int nRow, int nCol, uint nContent)
	{
		return getFormula(nRow, nCol, nContent);
	}

	private void SwigDirectorMethodsetFormula(int nRow, int nCol, uint nContent, [MarshalAs(UnmanagedType.LPWStr)] string sFormula)
	{
		try
		{
			setFormula(nRow, nCol, nContent, sFormula);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetFieldId__SWIG_0(int nRow, int nCol)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(getFieldId(nRow, nCol)).Handle;
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

	private IntPtr SwigDirectorMethodgetFieldId__SWIG_1(int nRow, int nCol, uint nContent)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(getFieldId(nRow, nCol, nContent)).Handle;
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

	private void SwigDirectorMethodsetFieldId__SWIG_0(int nRow, int nCol, IntPtr idField)
	{
		try
		{
			setFieldId(nRow, nCol, new OdDbObjectId(idField, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetFieldId__SWIG_1(int nRow, int nCol, uint nContent, IntPtr idField)
	{
		try
		{
			setFieldId(nRow, nCol, nContent, new OdDbObjectId(idField, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetField(int nRow, int nCol, uint nContent, int mode)
	{
		return OdDbField.getCPtr(getField(nRow, nCol, nContent, (OdDb_OpenMode)mode)).Handle;
	}

	private IntPtr SwigDirectorMethodgetBlockTableRecordId__SWIG_0(int nRow, int nCol)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(getBlockTableRecordId(nRow, nCol)).Handle;
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

	private IntPtr SwigDirectorMethodgetBlockTableRecordId__SWIG_1(int nRow, int nCol, uint nContent)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(getBlockTableRecordId(nRow, nCol, nContent)).Handle;
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

	private void SwigDirectorMethodsetBlockTableRecordId__SWIG_0(int nRow, int nCol, IntPtr idBTR)
	{
		try
		{
			setBlockTableRecordId(nRow, nCol, new OdDbObjectId(idBTR, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetBlockTableRecordId__SWIG_1(int nRow, int nCol, uint nContent, IntPtr idBTR)
	{
		try
		{
			setBlockTableRecordId(nRow, nCol, nContent, new OdDbObjectId(idBTR, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetBlockAttributeValue__SWIG_0(int nRow, int nCol, IntPtr idAttDef)
	{
		return getBlockAttributeValue(nRow, nCol, new OdDbObjectId(idAttDef, cMemoryOwn: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetBlockAttributeValue__SWIG_1(int nRow, int nCol, uint nContent, IntPtr idAttDef)
	{
		return getBlockAttributeValue(nRow, nCol, nContent, new OdDbObjectId(idAttDef, cMemoryOwn: false));
	}

	private void SwigDirectorMethodsetBlockAttributeValue__SWIG_0(int nRow, int nCol, IntPtr idAttDef, [MarshalAs(UnmanagedType.LPWStr)] string sAttValue)
	{
		try
		{
			setBlockAttributeValue(nRow, nCol, new OdDbObjectId(idAttDef, cMemoryOwn: false), sAttValue);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetBlockAttributeValue__SWIG_1(int nRow, int nCol, uint nContent, IntPtr idAttDef, [MarshalAs(UnmanagedType.LPWStr)] string sAttValue)
	{
		try
		{
			setBlockAttributeValue(nRow, nCol, nContent, new OdDbObjectId(idAttDef, cMemoryOwn: false), sAttValue);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisLinked(int nRow, int nCol)
	{
		return isLinked(nRow, nCol);
	}

	private IntPtr SwigDirectorMethodgetDataLink__SWIG_0(int nRow, int nCol)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(getDataLink(nRow, nCol)).Handle;
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

	private IntPtr SwigDirectorMethodgetDataLink__SWIG_1(int nRow, int nCol, int mode)
	{
		return OdDbDataLink.getCPtr(getDataLink(nRow, nCol, (OdDb_OpenMode)mode)).Handle;
	}

	private int SwigDirectorMethodgetDataLink__SWIG_2(IntPtr pRange, IntPtr dataLinkIds)
	{
		return getDataLink(new OdCellRange(pRange, cMemoryOwn: false), new OdDbObjectIdArray(dataLinkIds, cMemoryOwn: false));
	}

	private void SwigDirectorMethodsetDataLink__SWIG_0(int nRow, int nCol, IntPtr idDataLink, bool bUpdate)
	{
		try
		{
			setDataLink(nRow, nCol, new OdDbObjectId(idDataLink, cMemoryOwn: false), bUpdate);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDataLink__SWIG_1(IntPtr range, IntPtr idDataLink, bool bUpdate)
	{
		try
		{
			setDataLink(new OdCellRange(range, cMemoryOwn: false), new OdDbObjectId(idDataLink, cMemoryOwn: false), bUpdate);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetDataLinkRange(int nRow, int nCol)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCellRange.getCPtr(getDataLinkRange(nRow, nCol)).Handle;
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

	private void SwigDirectorMethodremoveDataLink__SWIG_0(int nRow, int nCol)
	{
		try
		{
			removeDataLink(nRow, nCol);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodremoveDataLink__SWIG_1()
	{
		try
		{
			removeDataLink();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodupdateDataLink__SWIG_0(int nRow, int nCol, int nDir, int nOption)
	{
		try
		{
			updateDataLink(nRow, nCol, (OdDb_UpdateDirection)nDir, (OdDb_UpdateOption)nOption);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodupdateDataLink__SWIG_1(int nDir, int nOption)
	{
		try
		{
			updateDataLink((OdDb_UpdateDirection)nDir, (OdDb_UpdateOption)nOption);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodclear()
	{
		try
		{
			clear();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodcopyFrom__SWIG_1(IntPtr pSrc, int nOption)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLinkedTableData>(pSrc, bOwn: false, bTryAddToTransaction: false), (OdDb_TableCopyOption)nOption);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodcopyFrom__SWIG_2(IntPtr pSrc, int nOption, IntPtr srcRange, IntPtr targetRange, IntPtr pNewTargetRange)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLinkedTableData>(pSrc, bOwn: false, bTryAddToTransaction: false), (OdDb_TableCopyOption)nOption, new OdCellRange(srcRange, cMemoryOwn: false), new OdCellRange(targetRange, cMemoryOwn: false), (pNewTargetRange == IntPtr.Zero) ? null : new OdCellRange(pNewTargetRange, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

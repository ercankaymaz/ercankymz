using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbTableStyle : OdDbObject
{
	public delegate IntPtr SwigDelegateOdDbTableStyle_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbTableStyle_1();

	public delegate void SwigDelegateOdDbTableStyle_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbTableStyle_3();

	public delegate bool SwigDelegateOdDbTableStyle_4();

	public delegate IntPtr SwigDelegateOdDbTableStyle_5();

	public delegate void SwigDelegateOdDbTableStyle_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbTableStyle_7();

	public delegate uint SwigDelegateOdDbTableStyle_8(IntPtr vd);

	public delegate uint SwigDelegateOdDbTableStyle_9();

	public delegate void SwigDelegateOdDbTableStyle_10(IntPtr ownerId);

	public delegate int SwigDelegateOdDbTableStyle_11(int mode);

	public delegate void SwigDelegateOdDbTableStyle_12();

	public delegate int SwigDelegateOdDbTableStyle_13(bool erasing);

	public delegate void SwigDelegateOdDbTableStyle_14(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbTableStyle_15(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbTableStyle_16(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbTableStyle_17(IntPtr otherId);

	public delegate void SwigDelegateOdDbTableStyle_18(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbTableStyle_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbTableStyle_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbTableStyle_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbTableStyle_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbTableStyle_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbTableStyle_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbTableStyle_25(IntPtr pFiler);

	public delegate void SwigDelegateOdDbTableStyle_26(IntPtr pFiler);

	public delegate int SwigDelegateOdDbTableStyle_27();

	public delegate IntPtr SwigDelegateOdDbTableStyle_28([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbTableStyle_29(IntPtr pRb);

	public delegate void SwigDelegateOdDbTableStyle_30(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbTableStyle_31(IntPtr objId);

	public delegate void SwigDelegateOdDbTableStyle_32(IntPtr objId);

	public delegate void SwigDelegateOdDbTableStyle_33(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbTableStyle_34();

	public delegate void SwigDelegateOdDbTableStyle_35(IntPtr idPair, IntPtr pOwnerObject, IntPtr idMap);

	public delegate void SwigDelegateOdDbTableStyle_36(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbTableStyle_37(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbTableStyle_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbTableStyle_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbTableStyle_40(IntPtr pObject);

	public delegate void SwigDelegateOdDbTableStyle_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbTableStyle_42(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbTableStyle_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbTableStyle_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbTableStyle_45(IntPtr pObject);

	public delegate void SwigDelegateOdDbTableStyle_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbTableStyle_47(IntPtr objectId);

	public delegate void SwigDelegateOdDbTableStyle_48(IntPtr pObject);

	public delegate void SwigDelegateOdDbTableStyle_49(IntPtr pSource);

	public delegate int SwigDelegateOdDbTableStyle_50(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbTableStyle_51(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbTableStyle_52(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbTableStyle_53(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbTableStyle_54(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbTableStyle_55();

	public delegate IntPtr SwigDelegateOdDbTableStyle_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbTableStyle_57(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbTableStyle_58([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbTableStyle_59(IntPtr pClass);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbTableStyle_60();

	public delegate void SwigDelegateOdDbTableStyle_61([MarshalAs(UnmanagedType.LPWStr)] string name);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbTableStyle_62();

	public delegate void SwigDelegateOdDbTableStyle_63([MarshalAs(UnmanagedType.LPWStr)] string description);

	public delegate uint SwigDelegateOdDbTableStyle_64();

	public delegate void SwigDelegateOdDbTableStyle_65(uint bitFlags);

	public delegate int SwigDelegateOdDbTableStyle_66();

	public delegate void SwigDelegateOdDbTableStyle_67(int flowDirection);

	public delegate double SwigDelegateOdDbTableStyle_68();

	public delegate void SwigDelegateOdDbTableStyle_69(double cellMargin);

	public delegate double SwigDelegateOdDbTableStyle_70();

	public delegate void SwigDelegateOdDbTableStyle_71(double cellMargin);

	public delegate bool SwigDelegateOdDbTableStyle_72();

	public delegate void SwigDelegateOdDbTableStyle_73(bool suppress);

	public delegate bool SwigDelegateOdDbTableStyle_74();

	public delegate void SwigDelegateOdDbTableStyle_75(bool suppress);

	public delegate IntPtr SwigDelegateOdDbTableStyle_76(int rowType);

	public delegate IntPtr SwigDelegateOdDbTableStyle_77();

	public delegate void SwigDelegateOdDbTableStyle_78(IntPtr textStyleId, int rowTypes);

	public delegate void SwigDelegateOdDbTableStyle_79(IntPtr textStyleId);

	public delegate double SwigDelegateOdDbTableStyle_80(int rowType);

	public delegate double SwigDelegateOdDbTableStyle_81();

	public delegate void SwigDelegateOdDbTableStyle_82(double height, int rowTypes);

	public delegate void SwigDelegateOdDbTableStyle_83(double height);

	public delegate int SwigDelegateOdDbTableStyle_84(int rowType);

	public delegate int SwigDelegateOdDbTableStyle_85();

	public delegate void SwigDelegateOdDbTableStyle_86(int alignment, int rowTypes);

	public delegate void SwigDelegateOdDbTableStyle_87(int alignment);

	public delegate IntPtr SwigDelegateOdDbTableStyle_88(int rowType);

	public delegate IntPtr SwigDelegateOdDbTableStyle_89();

	public delegate void SwigDelegateOdDbTableStyle_90(IntPtr color, int rowTypes);

	public delegate void SwigDelegateOdDbTableStyle_91(IntPtr color);

	public delegate IntPtr SwigDelegateOdDbTableStyle_92(int rowType);

	public delegate IntPtr SwigDelegateOdDbTableStyle_93();

	public delegate void SwigDelegateOdDbTableStyle_94(IntPtr color, int rowTypes);

	public delegate void SwigDelegateOdDbTableStyle_95(IntPtr color);

	public delegate bool SwigDelegateOdDbTableStyle_96(int rowType);

	public delegate bool SwigDelegateOdDbTableStyle_97();

	public delegate void SwigDelegateOdDbTableStyle_98(bool disable, int rowTypes);

	public delegate void SwigDelegateOdDbTableStyle_99(bool disable);

	public delegate int SwigDelegateOdDbTableStyle_100(int gridlineType, int rowType);

	public delegate int SwigDelegateOdDbTableStyle_101(int gridlineType);

	public delegate void SwigDelegateOdDbTableStyle_102(int lineWeight, int gridlineTypes, int rowTypes);

	public delegate void SwigDelegateOdDbTableStyle_103(int lineWeight, int gridlineTypes);

	public delegate void SwigDelegateOdDbTableStyle_104(int lineWeight);

	public delegate IntPtr SwigDelegateOdDbTableStyle_105(int gridlineType, int rowType);

	public delegate IntPtr SwigDelegateOdDbTableStyle_106(int gridlineType);

	public delegate void SwigDelegateOdDbTableStyle_107(IntPtr color, int gridlineTypes, int rowTypes);

	public delegate void SwigDelegateOdDbTableStyle_108(IntPtr color, int gridlineTypes);

	public delegate void SwigDelegateOdDbTableStyle_109(IntPtr color);

	public delegate int SwigDelegateOdDbTableStyle_110(int gridlineType, int rowType);

	public delegate int SwigDelegateOdDbTableStyle_111(int gridlineType);

	public delegate void SwigDelegateOdDbTableStyle_112(int gridVisiblity, int gridlineTypes, int rowTypes);

	public delegate void SwigDelegateOdDbTableStyle_113(int gridVisiblity, int gridlineTypes);

	public delegate void SwigDelegateOdDbTableStyle_114(int gridVisiblity);

	public delegate void SwigDelegateOdDbTableStyle_115(OdValue_DataType nDataType, OdValue_UnitType nUnitType, int rowType);

	public delegate void SwigDelegateOdDbTableStyle_116(OdValue_DataType nDataType, OdValue_UnitType nUnitType);

	public delegate void SwigDelegateOdDbTableStyle_117(int nDataType, int nUnitType, int rowTypes);

	public delegate void SwigDelegateOdDbTableStyle_118(int nDataType, int nUnitType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbTableStyle_119(int rowType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbTableStyle_120();

	public delegate void SwigDelegateOdDbTableStyle_121([MarshalAs(UnmanagedType.LPWStr)] string pszFormat, int rowTypes);

	public delegate void SwigDelegateOdDbTableStyle_122([MarshalAs(UnmanagedType.LPWStr)] string pszFormat);

	public delegate IntPtr SwigDelegateOdDbTableStyle_123(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string styleName);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbTableStyle_0 swigDelegate0;

	private SwigDelegateOdDbTableStyle_1 swigDelegate1;

	private SwigDelegateOdDbTableStyle_2 swigDelegate2;

	private SwigDelegateOdDbTableStyle_3 swigDelegate3;

	private SwigDelegateOdDbTableStyle_4 swigDelegate4;

	private SwigDelegateOdDbTableStyle_5 swigDelegate5;

	private SwigDelegateOdDbTableStyle_6 swigDelegate6;

	private SwigDelegateOdDbTableStyle_7 swigDelegate7;

	private SwigDelegateOdDbTableStyle_8 swigDelegate8;

	private SwigDelegateOdDbTableStyle_9 swigDelegate9;

	private SwigDelegateOdDbTableStyle_10 swigDelegate10;

	private SwigDelegateOdDbTableStyle_11 swigDelegate11;

	private SwigDelegateOdDbTableStyle_12 swigDelegate12;

	private SwigDelegateOdDbTableStyle_13 swigDelegate13;

	private SwigDelegateOdDbTableStyle_14 swigDelegate14;

	private SwigDelegateOdDbTableStyle_15 swigDelegate15;

	private SwigDelegateOdDbTableStyle_16 swigDelegate16;

	private SwigDelegateOdDbTableStyle_17 swigDelegate17;

	private SwigDelegateOdDbTableStyle_18 swigDelegate18;

	private SwigDelegateOdDbTableStyle_19 swigDelegate19;

	private SwigDelegateOdDbTableStyle_20 swigDelegate20;

	private SwigDelegateOdDbTableStyle_21 swigDelegate21;

	private SwigDelegateOdDbTableStyle_22 swigDelegate22;

	private SwigDelegateOdDbTableStyle_23 swigDelegate23;

	private SwigDelegateOdDbTableStyle_24 swigDelegate24;

	private SwigDelegateOdDbTableStyle_25 swigDelegate25;

	private SwigDelegateOdDbTableStyle_26 swigDelegate26;

	private SwigDelegateOdDbTableStyle_27 swigDelegate27;

	private SwigDelegateOdDbTableStyle_28 swigDelegate28;

	private SwigDelegateOdDbTableStyle_29 swigDelegate29;

	private SwigDelegateOdDbTableStyle_30 swigDelegate30;

	private SwigDelegateOdDbTableStyle_31 swigDelegate31;

	private SwigDelegateOdDbTableStyle_32 swigDelegate32;

	private SwigDelegateOdDbTableStyle_33 swigDelegate33;

	private SwigDelegateOdDbTableStyle_34 swigDelegate34;

	private SwigDelegateOdDbTableStyle_35 swigDelegate35;

	private SwigDelegateOdDbTableStyle_36 swigDelegate36;

	private SwigDelegateOdDbTableStyle_37 swigDelegate37;

	private SwigDelegateOdDbTableStyle_38 swigDelegate38;

	private SwigDelegateOdDbTableStyle_39 swigDelegate39;

	private SwigDelegateOdDbTableStyle_40 swigDelegate40;

	private SwigDelegateOdDbTableStyle_41 swigDelegate41;

	private SwigDelegateOdDbTableStyle_42 swigDelegate42;

	private SwigDelegateOdDbTableStyle_43 swigDelegate43;

	private SwigDelegateOdDbTableStyle_44 swigDelegate44;

	private SwigDelegateOdDbTableStyle_45 swigDelegate45;

	private SwigDelegateOdDbTableStyle_46 swigDelegate46;

	private SwigDelegateOdDbTableStyle_47 swigDelegate47;

	private SwigDelegateOdDbTableStyle_48 swigDelegate48;

	private SwigDelegateOdDbTableStyle_49 swigDelegate49;

	private SwigDelegateOdDbTableStyle_50 swigDelegate50;

	private SwigDelegateOdDbTableStyle_51 swigDelegate51;

	private SwigDelegateOdDbTableStyle_52 swigDelegate52;

	private SwigDelegateOdDbTableStyle_53 swigDelegate53;

	private SwigDelegateOdDbTableStyle_54 swigDelegate54;

	private SwigDelegateOdDbTableStyle_55 swigDelegate55;

	private SwigDelegateOdDbTableStyle_56 swigDelegate56;

	private SwigDelegateOdDbTableStyle_57 swigDelegate57;

	private SwigDelegateOdDbTableStyle_58 swigDelegate58;

	private SwigDelegateOdDbTableStyle_59 swigDelegate59;

	private SwigDelegateOdDbTableStyle_60 swigDelegate60;

	private SwigDelegateOdDbTableStyle_61 swigDelegate61;

	private SwigDelegateOdDbTableStyle_62 swigDelegate62;

	private SwigDelegateOdDbTableStyle_63 swigDelegate63;

	private SwigDelegateOdDbTableStyle_64 swigDelegate64;

	private SwigDelegateOdDbTableStyle_65 swigDelegate65;

	private SwigDelegateOdDbTableStyle_66 swigDelegate66;

	private SwigDelegateOdDbTableStyle_67 swigDelegate67;

	private SwigDelegateOdDbTableStyle_68 swigDelegate68;

	private SwigDelegateOdDbTableStyle_69 swigDelegate69;

	private SwigDelegateOdDbTableStyle_70 swigDelegate70;

	private SwigDelegateOdDbTableStyle_71 swigDelegate71;

	private SwigDelegateOdDbTableStyle_72 swigDelegate72;

	private SwigDelegateOdDbTableStyle_73 swigDelegate73;

	private SwigDelegateOdDbTableStyle_74 swigDelegate74;

	private SwigDelegateOdDbTableStyle_75 swigDelegate75;

	private SwigDelegateOdDbTableStyle_76 swigDelegate76;

	private SwigDelegateOdDbTableStyle_77 swigDelegate77;

	private SwigDelegateOdDbTableStyle_78 swigDelegate78;

	private SwigDelegateOdDbTableStyle_79 swigDelegate79;

	private SwigDelegateOdDbTableStyle_80 swigDelegate80;

	private SwigDelegateOdDbTableStyle_81 swigDelegate81;

	private SwigDelegateOdDbTableStyle_82 swigDelegate82;

	private SwigDelegateOdDbTableStyle_83 swigDelegate83;

	private SwigDelegateOdDbTableStyle_84 swigDelegate84;

	private SwigDelegateOdDbTableStyle_85 swigDelegate85;

	private SwigDelegateOdDbTableStyle_86 swigDelegate86;

	private SwigDelegateOdDbTableStyle_87 swigDelegate87;

	private SwigDelegateOdDbTableStyle_88 swigDelegate88;

	private SwigDelegateOdDbTableStyle_89 swigDelegate89;

	private SwigDelegateOdDbTableStyle_90 swigDelegate90;

	private SwigDelegateOdDbTableStyle_91 swigDelegate91;

	private SwigDelegateOdDbTableStyle_92 swigDelegate92;

	private SwigDelegateOdDbTableStyle_93 swigDelegate93;

	private SwigDelegateOdDbTableStyle_94 swigDelegate94;

	private SwigDelegateOdDbTableStyle_95 swigDelegate95;

	private SwigDelegateOdDbTableStyle_96 swigDelegate96;

	private SwigDelegateOdDbTableStyle_97 swigDelegate97;

	private SwigDelegateOdDbTableStyle_98 swigDelegate98;

	private SwigDelegateOdDbTableStyle_99 swigDelegate99;

	private SwigDelegateOdDbTableStyle_100 swigDelegate100;

	private SwigDelegateOdDbTableStyle_101 swigDelegate101;

	private SwigDelegateOdDbTableStyle_102 swigDelegate102;

	private SwigDelegateOdDbTableStyle_103 swigDelegate103;

	private SwigDelegateOdDbTableStyle_104 swigDelegate104;

	private SwigDelegateOdDbTableStyle_105 swigDelegate105;

	private SwigDelegateOdDbTableStyle_106 swigDelegate106;

	private SwigDelegateOdDbTableStyle_107 swigDelegate107;

	private SwigDelegateOdDbTableStyle_108 swigDelegate108;

	private SwigDelegateOdDbTableStyle_109 swigDelegate109;

	private SwigDelegateOdDbTableStyle_110 swigDelegate110;

	private SwigDelegateOdDbTableStyle_111 swigDelegate111;

	private SwigDelegateOdDbTableStyle_112 swigDelegate112;

	private SwigDelegateOdDbTableStyle_113 swigDelegate113;

	private SwigDelegateOdDbTableStyle_114 swigDelegate114;

	private SwigDelegateOdDbTableStyle_115 swigDelegate115;

	private SwigDelegateOdDbTableStyle_116 swigDelegate116;

	private SwigDelegateOdDbTableStyle_117 swigDelegate117;

	private SwigDelegateOdDbTableStyle_118 swigDelegate118;

	private SwigDelegateOdDbTableStyle_119 swigDelegate119;

	private SwigDelegateOdDbTableStyle_120 swigDelegate120;

	private SwigDelegateOdDbTableStyle_121 swigDelegate121;

	private SwigDelegateOdDbTableStyle_122 swigDelegate122;

	private SwigDelegateOdDbTableStyle_123 swigDelegate123;

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

	private static Type[] swigMethodTypes60 = new Type[0];

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes62 = new Type[0];

	private static Type[] swigMethodTypes63 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes64 = new Type[0];

	private static Type[] swigMethodTypes65 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes66 = new Type[0];

	private static Type[] swigMethodTypes67 = new Type[1] { typeof(OdDb_FlowDirection) };

	private static Type[] swigMethodTypes68 = new Type[0];

	private static Type[] swigMethodTypes69 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes70 = new Type[0];

	private static Type[] swigMethodTypes71 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes72 = new Type[0];

	private static Type[] swigMethodTypes73 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes74 = new Type[0];

	private static Type[] swigMethodTypes75 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes76 = new Type[1] { typeof(OdDb_RowType) };

	private static Type[] swigMethodTypes77 = new Type[0];

	private static Type[] swigMethodTypes78 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(int)
	};

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes80 = new Type[1] { typeof(OdDb_RowType) };

	private static Type[] swigMethodTypes81 = new Type[0];

	private static Type[] swigMethodTypes82 = new Type[2]
	{
		typeof(double),
		typeof(int)
	};

	private static Type[] swigMethodTypes83 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes84 = new Type[1] { typeof(OdDb_RowType) };

	private static Type[] swigMethodTypes85 = new Type[0];

	private static Type[] swigMethodTypes86 = new Type[2]
	{
		typeof(OdDb_CellAlignment),
		typeof(int)
	};

	private static Type[] swigMethodTypes87 = new Type[1] { typeof(OdDb_CellAlignment) };

	private static Type[] swigMethodTypes88 = new Type[1] { typeof(OdDb_RowType) };

	private static Type[] swigMethodTypes89 = new Type[0];

	private static Type[] swigMethodTypes90 = new Type[2]
	{
		typeof(OdCmColor),
		typeof(int)
	};

	private static Type[] swigMethodTypes91 = new Type[1] { typeof(OdCmColor) };

	private static Type[] swigMethodTypes92 = new Type[1] { typeof(OdDb_RowType) };

	private static Type[] swigMethodTypes93 = new Type[0];

	private static Type[] swigMethodTypes94 = new Type[2]
	{
		typeof(OdCmColor),
		typeof(int)
	};

	private static Type[] swigMethodTypes95 = new Type[1] { typeof(OdCmColor) };

	private static Type[] swigMethodTypes96 = new Type[1] { typeof(OdDb_RowType) };

	private static Type[] swigMethodTypes97 = new Type[0];

	private static Type[] swigMethodTypes98 = new Type[2]
	{
		typeof(bool),
		typeof(int)
	};

	private static Type[] swigMethodTypes99 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes100 = new Type[2]
	{
		typeof(OdDb_GridLineType),
		typeof(OdDb_RowType)
	};

	private static Type[] swigMethodTypes101 = new Type[1] { typeof(OdDb_GridLineType) };

	private static Type[] swigMethodTypes102 = new Type[3]
	{
		typeof(LineWeight),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes103 = new Type[2]
	{
		typeof(LineWeight),
		typeof(int)
	};

	private static Type[] swigMethodTypes104 = new Type[1] { typeof(LineWeight) };

	private static Type[] swigMethodTypes105 = new Type[2]
	{
		typeof(OdDb_GridLineType),
		typeof(OdDb_RowType)
	};

	private static Type[] swigMethodTypes106 = new Type[1] { typeof(OdDb_GridLineType) };

	private static Type[] swigMethodTypes107 = new Type[3]
	{
		typeof(OdCmColor),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes108 = new Type[2]
	{
		typeof(OdCmColor),
		typeof(int)
	};

	private static Type[] swigMethodTypes109 = new Type[1] { typeof(OdCmColor) };

	private static Type[] swigMethodTypes110 = new Type[2]
	{
		typeof(OdDb_GridLineType),
		typeof(OdDb_RowType)
	};

	private static Type[] swigMethodTypes111 = new Type[1] { typeof(OdDb_GridLineType) };

	private static Type[] swigMethodTypes112 = new Type[3]
	{
		typeof(OdDb_Visibility),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes113 = new Type[2]
	{
		typeof(OdDb_Visibility),
		typeof(int)
	};

	private static Type[] swigMethodTypes114 = new Type[1] { typeof(OdDb_Visibility) };

	private static Type[] swigMethodTypes115 = new Type[3]
	{
		typeof(OdValue_DataType).MakeByRefType(),
		typeof(OdValue_UnitType).MakeByRefType(),
		typeof(OdDb_RowType)
	};

	private static Type[] swigMethodTypes116 = new Type[2]
	{
		typeof(OdValue_DataType).MakeByRefType(),
		typeof(OdValue_UnitType).MakeByRefType()
	};

	private static Type[] swigMethodTypes117 = new Type[3]
	{
		typeof(OdValue_DataType),
		typeof(OdValue_UnitType),
		typeof(int)
	};

	private static Type[] swigMethodTypes118 = new Type[2]
	{
		typeof(OdValue_DataType),
		typeof(OdValue_UnitType)
	};

	private static Type[] swigMethodTypes119 = new Type[1] { typeof(OdDb_RowType) };

	private static Type[] swigMethodTypes120 = new Type[0];

	private static Type[] swigMethodTypes121 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes122 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes123 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(string)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbTableStyle(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbTableStyle obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbTableStyle(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbTableStyle cast(OdRxObject pObj)
	{
		OdDbTableStyle rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableStyle>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_isASwigExplicitOdDbTableStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_queryXSwigExplicitOdDbTableStyle(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string getName()
	{
		string result = (SwigDerivedClassHasMethod("getName", swigMethodTypes60) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_getNameSwigExplicitOdDbTableStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_getName(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setName(string name)
	{
		if (SwigDerivedClassHasMethod("setName", swigMethodTypes61))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setNameSwigExplicitOdDbTableStyle(swigCPtr, name);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setName(swigCPtr, name);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string description()
	{
		string result = (SwigDerivedClassHasMethod("description", swigMethodTypes62) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_descriptionSwigExplicitOdDbTableStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_description(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDescription(string description)
	{
		if (SwigDerivedClassHasMethod("setDescription", swigMethodTypes63))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setDescriptionSwigExplicitOdDbTableStyle(swigCPtr, description);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setDescription(swigCPtr, description);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint bitFlags()
	{
		uint result = (SwigDerivedClassHasMethod("bitFlags", swigMethodTypes64) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_bitFlagsSwigExplicitOdDbTableStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_bitFlags(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBitFlags(uint bitFlags)
	{
		if (SwigDerivedClassHasMethod("setBitFlags", swigMethodTypes65))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setBitFlagsSwigExplicitOdDbTableStyle(swigCPtr, bitFlags);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setBitFlags(swigCPtr, bitFlags);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_FlowDirection flowDirection()
	{
		int result = (SwigDerivedClassHasMethod("flowDirection", swigMethodTypes66) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_flowDirectionSwigExplicitOdDbTableStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_flowDirection(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_FlowDirection)result;
	}

	public virtual void setFlowDirection(OdDb_FlowDirection flowDirection)
	{
		if (SwigDerivedClassHasMethod("setFlowDirection", swigMethodTypes67))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setFlowDirectionSwigExplicitOdDbTableStyle(swigCPtr, (int)flowDirection);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setFlowDirection(swigCPtr, (int)flowDirection);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double horzCellMargin()
	{
		double result = (SwigDerivedClassHasMethod("horzCellMargin", swigMethodTypes68) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_horzCellMarginSwigExplicitOdDbTableStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_horzCellMargin(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHorzCellMargin(double cellMargin)
	{
		if (SwigDerivedClassHasMethod("setHorzCellMargin", swigMethodTypes69))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setHorzCellMarginSwigExplicitOdDbTableStyle(swigCPtr, cellMargin);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setHorzCellMargin(swigCPtr, cellMargin);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double vertCellMargin()
	{
		double result = (SwigDerivedClassHasMethod("vertCellMargin", swigMethodTypes70) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_vertCellMarginSwigExplicitOdDbTableStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_vertCellMargin(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVertCellMargin(double cellMargin)
	{
		if (SwigDerivedClassHasMethod("setVertCellMargin", swigMethodTypes71))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setVertCellMarginSwigExplicitOdDbTableStyle(swigCPtr, cellMargin);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setVertCellMargin(swigCPtr, cellMargin);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isTitleSuppressed()
	{
		bool result = (SwigDerivedClassHasMethod("isTitleSuppressed", swigMethodTypes72) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_isTitleSuppressedSwigExplicitOdDbTableStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_isTitleSuppressed(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void suppressTitleRow(bool suppress)
	{
		if (SwigDerivedClassHasMethod("suppressTitleRow", swigMethodTypes73))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_suppressTitleRowSwigExplicitOdDbTableStyle(swigCPtr, suppress);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_suppressTitleRow(swigCPtr, suppress);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isHeaderSuppressed()
	{
		bool result = (SwigDerivedClassHasMethod("isHeaderSuppressed", swigMethodTypes74) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_isHeaderSuppressedSwigExplicitOdDbTableStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_isHeaderSuppressed(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void suppressHeaderRow(bool suppress)
	{
		if (SwigDerivedClassHasMethod("suppressHeaderRow", swigMethodTypes75))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_suppressHeaderRowSwigExplicitOdDbTableStyle(swigCPtr, suppress);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_suppressHeaderRow(swigCPtr, suppress);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId textStyle(OdDb_RowType rowType)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("textStyle", swigMethodTypes76) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_textStyleSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)rowType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_textStyle__SWIG_0(swigCPtr, (int)rowType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId textStyle()
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("textStyle", swigMethodTypes77) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_textStyleSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_textStyle__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTextStyle(OdDbObjectId textStyleId, int rowTypes)
	{
		if (SwigDerivedClassHasMethod("setTextStyle", swigMethodTypes78))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setTextStyleSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(textStyleId), rowTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setTextStyle__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(textStyleId), rowTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextStyle(OdDbObjectId textStyleId)
	{
		if (SwigDerivedClassHasMethod("setTextStyle", swigMethodTypes79))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setTextStyleSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(textStyleId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setTextStyle__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(textStyleId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double textHeight(OdDb_RowType rowType)
	{
		double result = (SwigDerivedClassHasMethod("textHeight", swigMethodTypes80) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_textHeightSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)rowType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_textHeight__SWIG_0(swigCPtr, (int)rowType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double textHeight()
	{
		double result = (SwigDerivedClassHasMethod("textHeight", swigMethodTypes81) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_textHeightSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_textHeight__SWIG_1(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTextHeight(double height, int rowTypes)
	{
		if (SwigDerivedClassHasMethod("setTextHeight", swigMethodTypes82))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setTextHeightSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, height, rowTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setTextHeight__SWIG_0(swigCPtr, height, rowTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextHeight(double height)
	{
		if (SwigDerivedClassHasMethod("setTextHeight", swigMethodTypes83))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setTextHeightSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, height);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setTextHeight__SWIG_1(swigCPtr, height);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_CellAlignment alignment(OdDb_RowType rowType)
	{
		int result = (SwigDerivedClassHasMethod("alignment", swigMethodTypes84) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_alignmentSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)rowType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_alignment__SWIG_0(swigCPtr, (int)rowType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellAlignment)result;
	}

	public virtual OdDb_CellAlignment alignment()
	{
		int result = (SwigDerivedClassHasMethod("alignment", swigMethodTypes85) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_alignmentSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_alignment__SWIG_1(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellAlignment)result;
	}

	public virtual void setAlignment(OdDb_CellAlignment alignment, int rowTypes)
	{
		if (SwigDerivedClassHasMethod("setAlignment", swigMethodTypes86))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setAlignmentSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)alignment, rowTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setAlignment__SWIG_0(swigCPtr, (int)alignment, rowTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setAlignment(OdDb_CellAlignment alignment)
	{
		if (SwigDerivedClassHasMethod("setAlignment", swigMethodTypes87))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setAlignmentSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, (int)alignment);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setAlignment__SWIG_1(swigCPtr, (int)alignment);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor color(OdDb_RowType rowType)
	{
		OdCmColor result = new OdCmColor(SwigDerivedClassHasMethod("color", swigMethodTypes88) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_colorSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)rowType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_color__SWIG_0(swigCPtr, (int)rowType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor color()
	{
		OdCmColor result = new OdCmColor(SwigDerivedClassHasMethod("color", swigMethodTypes89) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_colorSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_color__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColor(OdCmColor color, int rowTypes)
	{
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes90))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setColorSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), rowTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setColor__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), rowTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setColor(OdCmColor color)
	{
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes91))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setColorSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, OdCmColor.getCPtr(color));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setColor__SWIG_1(swigCPtr, OdCmColor.getCPtr(color));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor backgroundColor(OdDb_RowType rowType)
	{
		OdCmColor result = new OdCmColor(SwigDerivedClassHasMethod("backgroundColor", swigMethodTypes92) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_backgroundColorSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)rowType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_backgroundColor__SWIG_0(swigCPtr, (int)rowType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor backgroundColor()
	{
		OdCmColor result = new OdCmColor(SwigDerivedClassHasMethod("backgroundColor", swigMethodTypes93) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_backgroundColorSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_backgroundColor__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBackgroundColor(OdCmColor color, int rowTypes)
	{
		if (SwigDerivedClassHasMethod("setBackgroundColor", swigMethodTypes94))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setBackgroundColorSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), rowTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setBackgroundColor__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), rowTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBackgroundColor(OdCmColor color)
	{
		if (SwigDerivedClassHasMethod("setBackgroundColor", swigMethodTypes95))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setBackgroundColorSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, OdCmColor.getCPtr(color));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setBackgroundColor__SWIG_1(swigCPtr, OdCmColor.getCPtr(color));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isBackgroundColorNone(OdDb_RowType rowType)
	{
		bool result = (SwigDerivedClassHasMethod("isBackgroundColorNone", swigMethodTypes96) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_isBackgroundColorNoneSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)rowType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_isBackgroundColorNone__SWIG_0(swigCPtr, (int)rowType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isBackgroundColorNone()
	{
		bool result = (SwigDerivedClassHasMethod("isBackgroundColorNone", swigMethodTypes97) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_isBackgroundColorNoneSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_isBackgroundColorNone__SWIG_1(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBackgroundColorNone(bool disable, int rowTypes)
	{
		if (SwigDerivedClassHasMethod("setBackgroundColorNone", swigMethodTypes98))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setBackgroundColorNoneSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, disable, rowTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setBackgroundColorNone__SWIG_0(swigCPtr, disable, rowTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBackgroundColorNone(bool disable)
	{
		if (SwigDerivedClassHasMethod("setBackgroundColorNone", swigMethodTypes99))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setBackgroundColorNoneSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, disable);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setBackgroundColorNone__SWIG_1(swigCPtr, disable);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual LineWeight gridLineWeight(OdDb_GridLineType gridlineType, OdDb_RowType rowType)
	{
		int result = (SwigDerivedClassHasMethod("gridLineWeight", swigMethodTypes100) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridLineWeightSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)gridlineType, (int)rowType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridLineWeight__SWIG_0(swigCPtr, (int)gridlineType, (int)rowType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual LineWeight gridLineWeight(OdDb_GridLineType gridlineType)
	{
		int result = (SwigDerivedClassHasMethod("gridLineWeight", swigMethodTypes101) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridLineWeightSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, (int)gridlineType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridLineWeight__SWIG_1(swigCPtr, (int)gridlineType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual void setGridLineWeight(LineWeight lineWeight, int gridlineTypes, int rowTypes)
	{
		if (SwigDerivedClassHasMethod("setGridLineWeight", swigMethodTypes102))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridLineWeightSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)lineWeight, gridlineTypes, rowTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridLineWeight__SWIG_0(swigCPtr, (int)lineWeight, gridlineTypes, rowTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGridLineWeight(LineWeight lineWeight, int gridlineTypes)
	{
		if (SwigDerivedClassHasMethod("setGridLineWeight", swigMethodTypes103))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridLineWeightSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, (int)lineWeight, gridlineTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridLineWeight__SWIG_1(swigCPtr, (int)lineWeight, gridlineTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGridLineWeight(LineWeight lineWeight)
	{
		if (SwigDerivedClassHasMethod("setGridLineWeight", swigMethodTypes104))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridLineWeightSwigExplicitOdDbTableStyle__SWIG_2(swigCPtr, (int)lineWeight);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridLineWeight__SWIG_2(swigCPtr, (int)lineWeight);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor gridColor(OdDb_GridLineType gridlineType, OdDb_RowType rowType)
	{
		OdCmColor result = new OdCmColor(SwigDerivedClassHasMethod("gridColor", swigMethodTypes105) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridColorSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)gridlineType, (int)rowType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridColor__SWIG_0(swigCPtr, (int)gridlineType, (int)rowType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor gridColor(OdDb_GridLineType gridlineType)
	{
		OdCmColor result = new OdCmColor(SwigDerivedClassHasMethod("gridColor", swigMethodTypes106) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridColorSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, (int)gridlineType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridColor__SWIG_1(swigCPtr, (int)gridlineType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGridColor(OdCmColor color, int gridlineTypes, int rowTypes)
	{
		if (SwigDerivedClassHasMethod("setGridColor", swigMethodTypes107))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridColorSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), gridlineTypes, rowTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridColor__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), gridlineTypes, rowTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGridColor(OdCmColor color, int gridlineTypes)
	{
		if (SwigDerivedClassHasMethod("setGridColor", swigMethodTypes108))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridColorSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, OdCmColor.getCPtr(color), gridlineTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridColor__SWIG_1(swigCPtr, OdCmColor.getCPtr(color), gridlineTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGridColor(OdCmColor color)
	{
		if (SwigDerivedClassHasMethod("setGridColor", swigMethodTypes109))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridColorSwigExplicitOdDbTableStyle__SWIG_2(swigCPtr, OdCmColor.getCPtr(color));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridColor__SWIG_2(swigCPtr, OdCmColor.getCPtr(color));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_Visibility gridVisibility(OdDb_GridLineType gridlineType, OdDb_RowType rowType)
	{
		int result = (SwigDerivedClassHasMethod("gridVisibility", swigMethodTypes110) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridVisibilitySwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)gridlineType, (int)rowType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridVisibility__SWIG_0(swigCPtr, (int)gridlineType, (int)rowType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	public virtual OdDb_Visibility gridVisibility(OdDb_GridLineType gridlineType)
	{
		int result = (SwigDerivedClassHasMethod("gridVisibility", swigMethodTypes111) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridVisibilitySwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, (int)gridlineType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridVisibility__SWIG_1(swigCPtr, (int)gridlineType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	public virtual void setGridVisibility(OdDb_Visibility gridVisiblity, int gridlineTypes, int rowTypes)
	{
		if (SwigDerivedClassHasMethod("setGridVisibility", swigMethodTypes112))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridVisibilitySwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)gridVisiblity, gridlineTypes, rowTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridVisibility__SWIG_0(swigCPtr, (int)gridVisiblity, gridlineTypes, rowTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGridVisibility(OdDb_Visibility gridVisiblity, int gridlineTypes)
	{
		if (SwigDerivedClassHasMethod("setGridVisibility", swigMethodTypes113))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridVisibilitySwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, (int)gridVisiblity, gridlineTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridVisibility__SWIG_1(swigCPtr, (int)gridVisiblity, gridlineTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGridVisibility(OdDb_Visibility gridVisiblity)
	{
		if (SwigDerivedClassHasMethod("setGridVisibility", swigMethodTypes114))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridVisibilitySwigExplicitOdDbTableStyle__SWIG_2(swigCPtr, (int)gridVisiblity);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridVisibility__SWIG_2(swigCPtr, (int)gridVisiblity);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getDataType(out OdValue_DataType nDataType, out OdValue_UnitType nUnitType, OdDb_RowType rowType)
	{
		if (SwigDerivedClassHasMethod("getDataType", swigMethodTypes115))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_getDataTypeSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, out nDataType, out nUnitType, (int)rowType);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_getDataType__SWIG_0(swigCPtr, out nDataType, out nUnitType, (int)rowType);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getDataType(out OdValue_DataType nDataType, out OdValue_UnitType nUnitType)
	{
		if (SwigDerivedClassHasMethod("getDataType", swigMethodTypes116))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_getDataTypeSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, out nDataType, out nUnitType);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_getDataType__SWIG_1(swigCPtr, out nDataType, out nUnitType);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDataType(OdValue_DataType nDataType, OdValue_UnitType nUnitType, int rowTypes)
	{
		if (SwigDerivedClassHasMethod("setDataType", swigMethodTypes117))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setDataTypeSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)nDataType, (int)nUnitType, rowTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setDataType__SWIG_0(swigCPtr, (int)nDataType, (int)nUnitType, rowTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDataType(OdValue_DataType nDataType, OdValue_UnitType nUnitType)
	{
		if (SwigDerivedClassHasMethod("setDataType", swigMethodTypes118))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setDataTypeSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, (int)nDataType, (int)nUnitType);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setDataType__SWIG_1(swigCPtr, (int)nDataType, (int)nUnitType);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string format(OdDb_RowType rowType)
	{
		string result = (SwigDerivedClassHasMethod("format", swigMethodTypes119) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_formatSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, (int)rowType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_format__SWIG_0(swigCPtr, (int)rowType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string format()
	{
		string result = (SwigDerivedClassHasMethod("format", swigMethodTypes120) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_formatSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_format__SWIG_1(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFormat(string pszFormat, int rowTypes)
	{
		if (SwigDerivedClassHasMethod("setFormat", swigMethodTypes121))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setFormatSwigExplicitOdDbTableStyle__SWIG_0(swigCPtr, pszFormat, rowTypes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setFormat__SWIG_0(swigCPtr, pszFormat, rowTypes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFormat(string pszFormat)
	{
		if (SwigDerivedClassHasMethod("setFormat", swigMethodTypes122))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setFormatSwigExplicitOdDbTableStyle__SWIG_1(swigCPtr, pszFormat);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setFormat__SWIG_1(swigCPtr, pszFormat);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_dwgInFieldsSwigExplicitOdDbTableStyle(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_dwgOutFieldsSwigExplicitOdDbTableStyle(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_dxfInFieldsSwigExplicitOdDbTableStyle(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_dxfOutFieldsSwigExplicitOdDbTableStyle(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDatabaseDefaults(OdDbDatabase pDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setDatabaseDefaults__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDatabaseDefaults()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setDatabaseDefaults__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId postTableStyleToDb(OdDbDatabase pDb, string styleName)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("postTableStyleToDb", swigMethodTypes123) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_postTableStyleToDbSwigExplicitOdDbTableStyle(swigCPtr, OdDbDatabase.getCPtr(pDb), styleName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_postTableStyleToDb(swigCPtr, OdDbDatabase.getCPtr(pDb), styleName), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string createCellStyle()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_createCellStyle__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void createCellStyle(string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_createCellStyle__SWIG_1(swigCPtr, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createCellStyle(string cellStyle, string fromCellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_createCellStyle__SWIG_2(swigCPtr, cellStyle, fromCellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void renameCellStyle(string oldName, string newName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_renameCellStyle(swigCPtr, oldName, newName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteCellStyle(string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_deleteCellStyle(swigCPtr, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void copyCellStyle(string srcCellStyle, string targetCellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_copyCellStyle__SWIG_0(swigCPtr, srcCellStyle, targetCellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void copyCellStyle(OdDbTableStyle pSrc, string srcCellStyle, string targetCellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_copyCellStyle__SWIG_1(swigCPtr, getCPtr(pSrc), srcCellStyle, targetCellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getUniqueCellStyleName(string baseName, ref string sUniqueName)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sUniqueName);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_getUniqueCellStyleName(swigCPtr, baseName, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				sUniqueName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public bool isCellStyleInUse(string cellStyle)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_isCellStyleInUse(swigCPtr, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numCellStyles()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_numCellStyles(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getCellStyles(OdStringArray cellstyles)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_getCellStyles(swigCPtr, OdStringArray.getCPtr(cellstyles).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int cellStyleId(string cellStyle)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_cellStyleId(swigCPtr, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string cellStyleName(int cellStyle)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_cellStyleName(swigCPtr, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId textStyle(string cellStyle)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_textStyle__SWIG_2(swigCPtr, cellStyle), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTextStyle(OdDbObjectId id, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setTextStyle__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(id), cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double textHeight(string cellStyle)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_textHeight__SWIG_2(swigCPtr, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTextHeight(double dHeight, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setTextHeight__SWIG_2(swigCPtr, dHeight, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDb_CellAlignment alignment(string cellStyle)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_alignment__SWIG_2(swigCPtr, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellAlignment)result;
	}

	public void setAlignment(OdDb_CellAlignment alignment, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setAlignment__SWIG_2(swigCPtr, (int)alignment, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmColor color(string cellStyle)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_color__SWIG_2(swigCPtr, cellStyle), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColor(OdCmColor color, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setColor__SWIG_2(swigCPtr, OdCmColor.getCPtr(color), cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmColor backgroundColor(string cellStyle)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_backgroundColor__SWIG_2(swigCPtr, cellStyle), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBackgroundColor(OdCmColor color, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setBackgroundColor__SWIG_2(swigCPtr, OdCmColor.getCPtr(color), cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDataType(out OdValue_DataType nDataType, out OdValue_UnitType nUnitType, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_getDataType__SWIG_2(swigCPtr, out nDataType, out nUnitType, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDataType(OdValue_DataType nDataType, OdValue_UnitType nUnitType, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setDataType__SWIG_2(swigCPtr, (int)nDataType, (int)nUnitType, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string format(string cellStyle)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_format__SWIG_2(swigCPtr, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFormat(string format, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setFormat__SWIG_2(swigCPtr, format, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int cellClass(string cellStyle)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_cellClass(swigCPtr, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCellClass(int nClass, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setCellClass(swigCPtr, nClass, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double rotation(string cellStyle)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_rotation(swigCPtr, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRotation(double rotation, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setRotation(swigCPtr, rotation, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isMergeAllEnabled(string cellStyle)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_isMergeAllEnabled(swigCPtr, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableMergeAll(bool bEnable, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_enableMergeAll(swigCPtr, bEnable, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double margin(OdDb_CellMargin nMargin, string cellStyle)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_margin(swigCPtr, (int)nMargin, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMargin(OdDb_CellMargin nMargins, double fMargin, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setMargin(swigCPtr, (int)nMargins, fMargin, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public LineWeight gridLineWeight(OdDb_GridLineType gridLineType, string cellStyle)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridLineWeight__SWIG_2(swigCPtr, (int)gridLineType, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public void setGridLineWeight(LineWeight lineWeight, OdDb_GridLineType gridLineTypes, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridLineWeight__SWIG_3(swigCPtr, (int)lineWeight, (int)gridLineTypes, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmColor gridColor(OdDb_GridLineType gridLineType, string cellStyle)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridColor__SWIG_2(swigCPtr, (int)gridLineType, cellStyle), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGridColor(OdCmColor color, OdDb_GridLineType gridLineTypes, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridColor__SWIG_3(swigCPtr, OdCmColor.getCPtr(color), (int)gridLineTypes, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDb_Visibility gridVisibility(OdDb_GridLineType gridLineType, string cellStyle)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridVisibility__SWIG_2(swigCPtr, (int)gridLineType, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	public void setGridVisibility(OdDb_Visibility visible, OdDb_GridLineType gridLineTypes, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridVisibility__SWIG_3(swigCPtr, (int)visible, (int)gridLineTypes, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double gridDoubleLineSpacing(OdDb_GridLineType gridLineType, string cellStyle)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridDoubleLineSpacing(swigCPtr, (int)gridLineType, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGridDoubleLineSpacing(double fSpacing, OdDb_GridLineType gridLineTypes, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridDoubleLineSpacing(swigCPtr, fSpacing, (int)gridLineTypes, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDb_GridLineStyle gridLineStyle(OdDb_GridLineType gridLineType, string cellStyle)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridLineStyle(swigCPtr, (int)gridLineType, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_GridLineStyle)result;
	}

	public void setGridLineStyle(OdDb_GridLineStyle nLineStyle, OdDb_GridLineType gridLineTypes, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridLineStyle(swigCPtr, (int)nLineStyle, (int)gridLineTypes, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId gridLinetype(OdDb_GridLineType gridLineType, string cellStyle)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_gridLinetype(swigCPtr, (int)gridLineType, cellStyle), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGridLinetype(OdDbObjectId id, OdDb_GridLineType gridLineTypes, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridLinetype(swigCPtr, OdDbObjectId.getCPtr(id), (int)gridLineTypes, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getGridProperty(OdGridProperty gridProp, OdDb_GridLineType nGridLineTypes, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_getGridProperty(swigCPtr, OdGridProperty.getCPtr(gridProp), (int)nGridLineTypes, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGridProperty(OdGridProperty gridProp, OdDb_GridLineType nGridLineTypes, string cellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setGridProperty(swigCPtr, OdGridProperty.getCPtr(gridProp), (int)nGridLineTypes, cellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId getTemplate()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_getTemplate(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTemplate(OdDbObjectId templateId, OdDb_MergeCellStyleOption nOption)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_setTemplate(swigCPtr, OdDbObjectId.getCPtr(templateId), (int)nOption);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId removeTemplate()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_removeTemplate(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult SubGetClassID(IntPtr pClsid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_SubGetClassID(swigCPtr, pClsid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbTableStyle createObject()
	{
		OdDbTableStyle rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableStyle>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("getName", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodgetName;
		}
		if (SwigDerivedClassHasMethod("setName", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodsetName;
		}
		if (SwigDerivedClassHasMethod("description", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethoddescription;
		}
		if (SwigDerivedClassHasMethod("setDescription", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodsetDescription;
		}
		if (SwigDerivedClassHasMethod("bitFlags", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodbitFlags;
		}
		if (SwigDerivedClassHasMethod("setBitFlags", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodsetBitFlags;
		}
		if (SwigDerivedClassHasMethod("flowDirection", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodflowDirection;
		}
		if (SwigDerivedClassHasMethod("setFlowDirection", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodsetFlowDirection;
		}
		if (SwigDerivedClassHasMethod("horzCellMargin", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodhorzCellMargin;
		}
		if (SwigDerivedClassHasMethod("setHorzCellMargin", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodsetHorzCellMargin;
		}
		if (SwigDerivedClassHasMethod("vertCellMargin", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodvertCellMargin;
		}
		if (SwigDerivedClassHasMethod("setVertCellMargin", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodsetVertCellMargin;
		}
		if (SwigDerivedClassHasMethod("isTitleSuppressed", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodisTitleSuppressed;
		}
		if (SwigDerivedClassHasMethod("suppressTitleRow", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodsuppressTitleRow;
		}
		if (SwigDerivedClassHasMethod("isHeaderSuppressed", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodisHeaderSuppressed;
		}
		if (SwigDerivedClassHasMethod("suppressHeaderRow", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodsuppressHeaderRow;
		}
		if (SwigDerivedClassHasMethod("textStyle", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodtextStyle__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("textStyle", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodtextStyle__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setTextStyle", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodsetTextStyle__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setTextStyle", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodsetTextStyle__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("textHeight", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodtextHeight__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("textHeight", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodtextHeight__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setTextHeight", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodsetTextHeight__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setTextHeight", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodsetTextHeight__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("alignment", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodalignment__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("alignment", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodalignment__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setAlignment", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodsetAlignment__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setAlignment", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodsetAlignment__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("color", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodcolor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("color", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodcolor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodsetColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodsetColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("backgroundColor", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodbackgroundColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("backgroundColor", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodbackgroundColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setBackgroundColor", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodsetBackgroundColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setBackgroundColor", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodsetBackgroundColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isBackgroundColorNone", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodisBackgroundColorNone__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("isBackgroundColorNone", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodisBackgroundColorNone__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setBackgroundColorNone", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodsetBackgroundColorNone__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setBackgroundColorNone", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethodsetBackgroundColorNone__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("gridLineWeight", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodgridLineWeight__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("gridLineWeight", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodgridLineWeight__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setGridLineWeight", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethodsetGridLineWeight__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setGridLineWeight", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethodsetGridLineWeight__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setGridLineWeight", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethodsetGridLineWeight__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("gridColor", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodgridColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("gridColor", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethodgridColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setGridColor", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodsetGridColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setGridColor", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethodsetGridColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setGridColor", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodsetGridColor__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("gridVisibility", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodgridVisibility__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("gridVisibility", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodgridVisibility__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setGridVisibility", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodsetGridVisibility__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setGridVisibility", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethodsetGridVisibility__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setGridVisibility", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodsetGridVisibility__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getDataType", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethodgetDataType__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getDataType", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethodgetDataType__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setDataType", swigMethodTypes117))
		{
			swigDelegate117 = SwigDirectorMethodsetDataType__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDataType", swigMethodTypes118))
		{
			swigDelegate118 = SwigDirectorMethodsetDataType__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("format", swigMethodTypes119))
		{
			swigDelegate119 = SwigDirectorMethodformat__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("format", swigMethodTypes120))
		{
			swigDelegate120 = SwigDirectorMethodformat__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setFormat", swigMethodTypes121))
		{
			swigDelegate121 = SwigDirectorMethodsetFormat__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setFormat", swigMethodTypes122))
		{
			swigDelegate122 = SwigDirectorMethodsetFormat__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("postTableStyleToDb", swigMethodTypes123))
		{
			swigDelegate123 = SwigDirectorMethodpostTableStyleToDb;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableStyle_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbTableStyle));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetName()
	{
		return getName();
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

	private uint SwigDirectorMethodbitFlags()
	{
		return bitFlags();
	}

	private void SwigDirectorMethodsetBitFlags(uint bitFlags)
	{
		try
		{
			setBitFlags(bitFlags);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodflowDirection()
	{
		return (int)flowDirection();
	}

	private void SwigDirectorMethodsetFlowDirection(int flowDirection)
	{
		try
		{
			setFlowDirection((OdDb_FlowDirection)flowDirection);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodhorzCellMargin()
	{
		return horzCellMargin();
	}

	private void SwigDirectorMethodsetHorzCellMargin(double cellMargin)
	{
		try
		{
			setHorzCellMargin(cellMargin);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodvertCellMargin()
	{
		return vertCellMargin();
	}

	private void SwigDirectorMethodsetVertCellMargin(double cellMargin)
	{
		try
		{
			setVertCellMargin(cellMargin);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisTitleSuppressed()
	{
		return isTitleSuppressed();
	}

	private void SwigDirectorMethodsuppressTitleRow(bool suppress)
	{
		try
		{
			suppressTitleRow(suppress);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisHeaderSuppressed()
	{
		return isHeaderSuppressed();
	}

	private void SwigDirectorMethodsuppressHeaderRow(bool suppress)
	{
		try
		{
			suppressHeaderRow(suppress);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodtextStyle__SWIG_0(int rowType)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(textStyle((OdDb_RowType)rowType)).Handle;
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

	private IntPtr SwigDirectorMethodtextStyle__SWIG_1()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(textStyle()).Handle;
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

	private void SwigDirectorMethodsetTextStyle__SWIG_0(IntPtr textStyleId, int rowTypes)
	{
		try
		{
			setTextStyle(new OdDbObjectId(textStyleId, cMemoryOwn: true), rowTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetTextStyle__SWIG_1(IntPtr textStyleId)
	{
		try
		{
			setTextStyle(new OdDbObjectId(textStyleId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodtextHeight__SWIG_0(int rowType)
	{
		return textHeight((OdDb_RowType)rowType);
	}

	private double SwigDirectorMethodtextHeight__SWIG_1()
	{
		return textHeight();
	}

	private void SwigDirectorMethodsetTextHeight__SWIG_0(double height, int rowTypes)
	{
		try
		{
			setTextHeight(height, rowTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetTextHeight__SWIG_1(double height)
	{
		try
		{
			setTextHeight(height);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodalignment__SWIG_0(int rowType)
	{
		return (int)alignment((OdDb_RowType)rowType);
	}

	private int SwigDirectorMethodalignment__SWIG_1()
	{
		return (int)alignment();
	}

	private void SwigDirectorMethodsetAlignment__SWIG_0(int alignment, int rowTypes)
	{
		try
		{
			setAlignment((OdDb_CellAlignment)alignment, rowTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetAlignment__SWIG_1(int alignment)
	{
		try
		{
			setAlignment((OdDb_CellAlignment)alignment);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodcolor__SWIG_0(int rowType)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(color((OdDb_RowType)rowType)).Handle;
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

	private IntPtr SwigDirectorMethodcolor__SWIG_1()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(color()).Handle;
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

	private void SwigDirectorMethodsetColor__SWIG_0(IntPtr color, int rowTypes)
	{
		try
		{
			setColor(new OdCmColor(color, cMemoryOwn: false), rowTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetColor__SWIG_1(IntPtr color)
	{
		try
		{
			setColor(new OdCmColor(color, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodbackgroundColor__SWIG_0(int rowType)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(backgroundColor((OdDb_RowType)rowType)).Handle;
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

	private IntPtr SwigDirectorMethodbackgroundColor__SWIG_1()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(backgroundColor()).Handle;
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

	private void SwigDirectorMethodsetBackgroundColor__SWIG_0(IntPtr color, int rowTypes)
	{
		try
		{
			setBackgroundColor(new OdCmColor(color, cMemoryOwn: false), rowTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetBackgroundColor__SWIG_1(IntPtr color)
	{
		try
		{
			setBackgroundColor(new OdCmColor(color, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisBackgroundColorNone__SWIG_0(int rowType)
	{
		return isBackgroundColorNone((OdDb_RowType)rowType);
	}

	private bool SwigDirectorMethodisBackgroundColorNone__SWIG_1()
	{
		return isBackgroundColorNone();
	}

	private void SwigDirectorMethodsetBackgroundColorNone__SWIG_0(bool disable, int rowTypes)
	{
		try
		{
			setBackgroundColorNone(disable, rowTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetBackgroundColorNone__SWIG_1(bool disable)
	{
		try
		{
			setBackgroundColorNone(disable);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodgridLineWeight__SWIG_0(int gridlineType, int rowType)
	{
		return (int)gridLineWeight((OdDb_GridLineType)gridlineType, (OdDb_RowType)rowType);
	}

	private int SwigDirectorMethodgridLineWeight__SWIG_1(int gridlineType)
	{
		return (int)gridLineWeight((OdDb_GridLineType)gridlineType);
	}

	private void SwigDirectorMethodsetGridLineWeight__SWIG_0(int lineWeight, int gridlineTypes, int rowTypes)
	{
		try
		{
			setGridLineWeight((LineWeight)lineWeight, gridlineTypes, rowTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetGridLineWeight__SWIG_1(int lineWeight, int gridlineTypes)
	{
		try
		{
			setGridLineWeight((LineWeight)lineWeight, gridlineTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetGridLineWeight__SWIG_2(int lineWeight)
	{
		try
		{
			setGridLineWeight((LineWeight)lineWeight);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgridColor__SWIG_0(int gridlineType, int rowType)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(gridColor((OdDb_GridLineType)gridlineType, (OdDb_RowType)rowType)).Handle;
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

	private IntPtr SwigDirectorMethodgridColor__SWIG_1(int gridlineType)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(gridColor((OdDb_GridLineType)gridlineType)).Handle;
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

	private void SwigDirectorMethodsetGridColor__SWIG_0(IntPtr color, int gridlineTypes, int rowTypes)
	{
		try
		{
			setGridColor(new OdCmColor(color, cMemoryOwn: true), gridlineTypes, rowTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetGridColor__SWIG_1(IntPtr color, int gridlineTypes)
	{
		try
		{
			setGridColor(new OdCmColor(color, cMemoryOwn: true), gridlineTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetGridColor__SWIG_2(IntPtr color)
	{
		try
		{
			setGridColor(new OdCmColor(color, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodgridVisibility__SWIG_0(int gridlineType, int rowType)
	{
		return (int)gridVisibility((OdDb_GridLineType)gridlineType, (OdDb_RowType)rowType);
	}

	private int SwigDirectorMethodgridVisibility__SWIG_1(int gridlineType)
	{
		return (int)gridVisibility((OdDb_GridLineType)gridlineType);
	}

	private void SwigDirectorMethodsetGridVisibility__SWIG_0(int gridVisiblity, int gridlineTypes, int rowTypes)
	{
		try
		{
			setGridVisibility((OdDb_Visibility)gridVisiblity, gridlineTypes, rowTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetGridVisibility__SWIG_1(int gridVisiblity, int gridlineTypes)
	{
		try
		{
			setGridVisibility((OdDb_Visibility)gridVisiblity, gridlineTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetGridVisibility__SWIG_2(int gridVisiblity)
	{
		try
		{
			setGridVisibility((OdDb_Visibility)gridVisiblity);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodgetDataType__SWIG_0(OdValue_DataType nDataType, OdValue_UnitType nUnitType, int rowType)
	{
		try
		{
			getDataType(out nDataType, out nUnitType, (OdDb_RowType)rowType);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodgetDataType__SWIG_1(OdValue_DataType nDataType, OdValue_UnitType nUnitType)
	{
		try
		{
			getDataType(out nDataType, out nUnitType);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDataType__SWIG_0(int nDataType, int nUnitType, int rowTypes)
	{
		try
		{
			setDataType((OdValue_DataType)nDataType, (OdValue_UnitType)nUnitType, rowTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDataType__SWIG_1(int nDataType, int nUnitType)
	{
		try
		{
			setDataType((OdValue_DataType)nDataType, (OdValue_UnitType)nUnitType);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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
	private string SwigDirectorMethodformat__SWIG_0(int rowType)
	{
		return format((OdDb_RowType)rowType);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodformat__SWIG_1()
	{
		return format();
	}

	private void SwigDirectorMethodsetFormat__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string pszFormat, int rowTypes)
	{
		try
		{
			setFormat(pszFormat, rowTypes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetFormat__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string pszFormat)
	{
		try
		{
			setFormat(pszFormat);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodpostTableStyleToDb(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string styleName)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(postTableStyleToDb(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), styleName)).Handle;
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
}

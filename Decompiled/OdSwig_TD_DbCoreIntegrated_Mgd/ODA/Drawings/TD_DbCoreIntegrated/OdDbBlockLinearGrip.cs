using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbBlockLinearGrip : OdDbBlockGrip
{
	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_1();

	public delegate void SwigDelegateOdDbBlockLinearGrip_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbBlockLinearGrip_3();

	public delegate bool SwigDelegateOdDbBlockLinearGrip_4();

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_5();

	public delegate void SwigDelegateOdDbBlockLinearGrip_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_7();

	public delegate uint SwigDelegateOdDbBlockLinearGrip_8(IntPtr vd);

	public delegate uint SwigDelegateOdDbBlockLinearGrip_9();

	public delegate void SwigDelegateOdDbBlockLinearGrip_10(IntPtr ownerId);

	public delegate int SwigDelegateOdDbBlockLinearGrip_11(int mode);

	public delegate void SwigDelegateOdDbBlockLinearGrip_12();

	public delegate int SwigDelegateOdDbBlockLinearGrip_13(bool erasing);

	public delegate void SwigDelegateOdDbBlockLinearGrip_14(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbBlockLinearGrip_15(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbBlockLinearGrip_16(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbBlockLinearGrip_17(IntPtr otherId);

	public delegate void SwigDelegateOdDbBlockLinearGrip_18(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbBlockLinearGrip_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbBlockLinearGrip_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbBlockLinearGrip_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbBlockLinearGrip_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbBlockLinearGrip_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbBlockLinearGrip_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbBlockLinearGrip_25(IntPtr pFiler);

	public delegate void SwigDelegateOdDbBlockLinearGrip_26(IntPtr pFiler);

	public delegate int SwigDelegateOdDbBlockLinearGrip_27();

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_28([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbBlockLinearGrip_29(IntPtr pRb);

	public delegate void SwigDelegateOdDbBlockLinearGrip_30(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbBlockLinearGrip_31(IntPtr objId);

	public delegate void SwigDelegateOdDbBlockLinearGrip_32(IntPtr objId);

	public delegate void SwigDelegateOdDbBlockLinearGrip_33(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbBlockLinearGrip_34();

	public delegate void SwigDelegateOdDbBlockLinearGrip_35(IntPtr idPair, IntPtr pOwnerObject, IntPtr idMap);

	public delegate void SwigDelegateOdDbBlockLinearGrip_36(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbBlockLinearGrip_37(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbBlockLinearGrip_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbBlockLinearGrip_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbBlockLinearGrip_40(IntPtr pObject);

	public delegate void SwigDelegateOdDbBlockLinearGrip_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbBlockLinearGrip_42(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbBlockLinearGrip_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbBlockLinearGrip_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbBlockLinearGrip_45(IntPtr pObject);

	public delegate void SwigDelegateOdDbBlockLinearGrip_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbBlockLinearGrip_47(IntPtr objectId);

	public delegate void SwigDelegateOdDbBlockLinearGrip_48(IntPtr pObject);

	public delegate void SwigDelegateOdDbBlockLinearGrip_49(IntPtr pSource);

	public delegate int SwigDelegateOdDbBlockLinearGrip_50(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbBlockLinearGrip_51(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_52(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_53(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbBlockLinearGrip_54(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_55();

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbBlockLinearGrip_57(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_58([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_59(IntPtr pClass);

	public delegate int SwigDelegateOdDbBlockLinearGrip_60(IntPtr pClsid);

	public delegate void SwigDelegateOdDbBlockLinearGrip_61(uint arg0);

	public delegate void SwigDelegateOdDbBlockLinearGrip_62(uint adjEdgeNodeId);

	public delegate void SwigDelegateOdDbBlockLinearGrip_63(uint fromId, uint toId, bool isInvertible);

	public delegate void SwigDelegateOdDbBlockLinearGrip_64(IntPtr pFromGraph);

	public delegate void SwigDelegateOdDbBlockLinearGrip_65(IntPtr pIntoGraph);

	public delegate void SwigDelegateOdDbBlockLinearGrip_66(IntPtr pIntoGraph);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_67();

	public delegate void SwigDelegateOdDbBlockLinearGrip_68(IntPtr argumentActiveList);

	public delegate void SwigDelegateOdDbBlockLinearGrip_69(bool nodeIsActive);

	public delegate void SwigDelegateOdDbBlockLinearGrip_70(bool nodeIsActive);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_71(IntPtr arg0);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_72(IntPtr pOther);

	public delegate void SwigDelegateOdDbBlockLinearGrip_73(IntPtr idMap);

	public delegate int SwigDelegateOdDbBlockLinearGrip_74(IntPtr arg0);

	public delegate void SwigDelegateOdDbBlockLinearGrip_75(IntPtr arg0);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_76([MarshalAs(UnmanagedType.LPWStr)] string arg0);

	public delegate int SwigDelegateOdDbBlockLinearGrip_77([MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_78([MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_79([MarshalAs(UnmanagedType.LPWStr)] string connectionName, IntPtr pValue);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_80([MarshalAs(UnmanagedType.LPWStr)] string arg0, uint arg1, [MarshalAs(UnmanagedType.LPWStr)] string arg2);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_81([MarshalAs(UnmanagedType.LPWStr)] string arg0, uint arg1, [MarshalAs(UnmanagedType.LPWStr)] string arg2);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_82([MarshalAs(UnmanagedType.LPWStr)] string arg0, uint arg1, [MarshalAs(UnmanagedType.LPWStr)] string arg2);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_83([MarshalAs(UnmanagedType.LPWStr)] string arg0, IntPtr arg1);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_84([MarshalAs(UnmanagedType.LPWStr)] string arg0, uint arg1, IntPtr arg2);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBlockLinearGrip_85();

	public delegate void SwigDelegateOdDbBlockLinearGrip_86([MarshalAs(UnmanagedType.LPWStr)] string arg0);

	public delegate uint SwigDelegateOdDbBlockLinearGrip_87();

	public delegate void SwigDelegateOdDbBlockLinearGrip_88();

	public delegate int SwigDelegateOdDbBlockLinearGrip_89();

	public delegate int SwigDelegateOdDbBlockLinearGrip_90();

	public delegate void SwigDelegateOdDbBlockLinearGrip_91(IntPtr points);

	public delegate void SwigDelegateOdDbBlockLinearGrip_92(IntPtr indices, IntPtr offset);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_93();

	public delegate bool SwigDelegateOdDbBlockLinearGrip_94();

	public delegate bool SwigDelegateOdDbBlockLinearGrip_95(IntPtr arg0, bool bRequireEvaluate);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_96(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_97();

	public delegate bool SwigDelegateOdDbBlockLinearGrip_98();

	public delegate void SwigDelegateOdDbBlockLinearGrip_99(bool arg0);

	public delegate void SwigDelegateOdDbBlockLinearGrip_100(IntPtr arg0);

	public delegate int SwigDelegateOdDbBlockLinearGrip_101(IntPtr arg0);

	public delegate int SwigDelegateOdDbBlockLinearGrip_102(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_103();

	public delegate IntPtr SwigDelegateOdDbBlockLinearGrip_104();

	public delegate bool SwigDelegateOdDbBlockLinearGrip_105(IntPtr arg0);

	public delegate void SwigDelegateOdDbBlockLinearGrip_106(IntPtr entityId, IntPtr blockId);

	public delegate void SwigDelegateOdDbBlockLinearGrip_107(IntPtr entityId, IntPtr blockId);

	public delegate void SwigDelegateOdDbBlockLinearGrip_108(IntPtr entityId, IntPtr blockId);

	public delegate bool SwigDelegateOdDbBlockLinearGrip_109(IntPtr arg0);

	public delegate void SwigDelegateOdDbBlockLinearGrip_110(IntPtr entityId, IntPtr blockId);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBlockLinearGrip_0 swigDelegate0;

	private SwigDelegateOdDbBlockLinearGrip_1 swigDelegate1;

	private SwigDelegateOdDbBlockLinearGrip_2 swigDelegate2;

	private SwigDelegateOdDbBlockLinearGrip_3 swigDelegate3;

	private SwigDelegateOdDbBlockLinearGrip_4 swigDelegate4;

	private SwigDelegateOdDbBlockLinearGrip_5 swigDelegate5;

	private SwigDelegateOdDbBlockLinearGrip_6 swigDelegate6;

	private SwigDelegateOdDbBlockLinearGrip_7 swigDelegate7;

	private SwigDelegateOdDbBlockLinearGrip_8 swigDelegate8;

	private SwigDelegateOdDbBlockLinearGrip_9 swigDelegate9;

	private SwigDelegateOdDbBlockLinearGrip_10 swigDelegate10;

	private SwigDelegateOdDbBlockLinearGrip_11 swigDelegate11;

	private SwigDelegateOdDbBlockLinearGrip_12 swigDelegate12;

	private SwigDelegateOdDbBlockLinearGrip_13 swigDelegate13;

	private SwigDelegateOdDbBlockLinearGrip_14 swigDelegate14;

	private SwigDelegateOdDbBlockLinearGrip_15 swigDelegate15;

	private SwigDelegateOdDbBlockLinearGrip_16 swigDelegate16;

	private SwigDelegateOdDbBlockLinearGrip_17 swigDelegate17;

	private SwigDelegateOdDbBlockLinearGrip_18 swigDelegate18;

	private SwigDelegateOdDbBlockLinearGrip_19 swigDelegate19;

	private SwigDelegateOdDbBlockLinearGrip_20 swigDelegate20;

	private SwigDelegateOdDbBlockLinearGrip_21 swigDelegate21;

	private SwigDelegateOdDbBlockLinearGrip_22 swigDelegate22;

	private SwigDelegateOdDbBlockLinearGrip_23 swigDelegate23;

	private SwigDelegateOdDbBlockLinearGrip_24 swigDelegate24;

	private SwigDelegateOdDbBlockLinearGrip_25 swigDelegate25;

	private SwigDelegateOdDbBlockLinearGrip_26 swigDelegate26;

	private SwigDelegateOdDbBlockLinearGrip_27 swigDelegate27;

	private SwigDelegateOdDbBlockLinearGrip_28 swigDelegate28;

	private SwigDelegateOdDbBlockLinearGrip_29 swigDelegate29;

	private SwigDelegateOdDbBlockLinearGrip_30 swigDelegate30;

	private SwigDelegateOdDbBlockLinearGrip_31 swigDelegate31;

	private SwigDelegateOdDbBlockLinearGrip_32 swigDelegate32;

	private SwigDelegateOdDbBlockLinearGrip_33 swigDelegate33;

	private SwigDelegateOdDbBlockLinearGrip_34 swigDelegate34;

	private SwigDelegateOdDbBlockLinearGrip_35 swigDelegate35;

	private SwigDelegateOdDbBlockLinearGrip_36 swigDelegate36;

	private SwigDelegateOdDbBlockLinearGrip_37 swigDelegate37;

	private SwigDelegateOdDbBlockLinearGrip_38 swigDelegate38;

	private SwigDelegateOdDbBlockLinearGrip_39 swigDelegate39;

	private SwigDelegateOdDbBlockLinearGrip_40 swigDelegate40;

	private SwigDelegateOdDbBlockLinearGrip_41 swigDelegate41;

	private SwigDelegateOdDbBlockLinearGrip_42 swigDelegate42;

	private SwigDelegateOdDbBlockLinearGrip_43 swigDelegate43;

	private SwigDelegateOdDbBlockLinearGrip_44 swigDelegate44;

	private SwigDelegateOdDbBlockLinearGrip_45 swigDelegate45;

	private SwigDelegateOdDbBlockLinearGrip_46 swigDelegate46;

	private SwigDelegateOdDbBlockLinearGrip_47 swigDelegate47;

	private SwigDelegateOdDbBlockLinearGrip_48 swigDelegate48;

	private SwigDelegateOdDbBlockLinearGrip_49 swigDelegate49;

	private SwigDelegateOdDbBlockLinearGrip_50 swigDelegate50;

	private SwigDelegateOdDbBlockLinearGrip_51 swigDelegate51;

	private SwigDelegateOdDbBlockLinearGrip_52 swigDelegate52;

	private SwigDelegateOdDbBlockLinearGrip_53 swigDelegate53;

	private SwigDelegateOdDbBlockLinearGrip_54 swigDelegate54;

	private SwigDelegateOdDbBlockLinearGrip_55 swigDelegate55;

	private SwigDelegateOdDbBlockLinearGrip_56 swigDelegate56;

	private SwigDelegateOdDbBlockLinearGrip_57 swigDelegate57;

	private SwigDelegateOdDbBlockLinearGrip_58 swigDelegate58;

	private SwigDelegateOdDbBlockLinearGrip_59 swigDelegate59;

	private SwigDelegateOdDbBlockLinearGrip_60 swigDelegate60;

	private SwigDelegateOdDbBlockLinearGrip_61 swigDelegate61;

	private SwigDelegateOdDbBlockLinearGrip_62 swigDelegate62;

	private SwigDelegateOdDbBlockLinearGrip_63 swigDelegate63;

	private SwigDelegateOdDbBlockLinearGrip_64 swigDelegate64;

	private SwigDelegateOdDbBlockLinearGrip_65 swigDelegate65;

	private SwigDelegateOdDbBlockLinearGrip_66 swigDelegate66;

	private SwigDelegateOdDbBlockLinearGrip_67 swigDelegate67;

	private SwigDelegateOdDbBlockLinearGrip_68 swigDelegate68;

	private SwigDelegateOdDbBlockLinearGrip_69 swigDelegate69;

	private SwigDelegateOdDbBlockLinearGrip_70 swigDelegate70;

	private SwigDelegateOdDbBlockLinearGrip_71 swigDelegate71;

	private SwigDelegateOdDbBlockLinearGrip_72 swigDelegate72;

	private SwigDelegateOdDbBlockLinearGrip_73 swigDelegate73;

	private SwigDelegateOdDbBlockLinearGrip_74 swigDelegate74;

	private SwigDelegateOdDbBlockLinearGrip_75 swigDelegate75;

	private SwigDelegateOdDbBlockLinearGrip_76 swigDelegate76;

	private SwigDelegateOdDbBlockLinearGrip_77 swigDelegate77;

	private SwigDelegateOdDbBlockLinearGrip_78 swigDelegate78;

	private SwigDelegateOdDbBlockLinearGrip_79 swigDelegate79;

	private SwigDelegateOdDbBlockLinearGrip_80 swigDelegate80;

	private SwigDelegateOdDbBlockLinearGrip_81 swigDelegate81;

	private SwigDelegateOdDbBlockLinearGrip_82 swigDelegate82;

	private SwigDelegateOdDbBlockLinearGrip_83 swigDelegate83;

	private SwigDelegateOdDbBlockLinearGrip_84 swigDelegate84;

	private SwigDelegateOdDbBlockLinearGrip_85 swigDelegate85;

	private SwigDelegateOdDbBlockLinearGrip_86 swigDelegate86;

	private SwigDelegateOdDbBlockLinearGrip_87 swigDelegate87;

	private SwigDelegateOdDbBlockLinearGrip_88 swigDelegate88;

	private SwigDelegateOdDbBlockLinearGrip_89 swigDelegate89;

	private SwigDelegateOdDbBlockLinearGrip_90 swigDelegate90;

	private SwigDelegateOdDbBlockLinearGrip_91 swigDelegate91;

	private SwigDelegateOdDbBlockLinearGrip_92 swigDelegate92;

	private SwigDelegateOdDbBlockLinearGrip_93 swigDelegate93;

	private SwigDelegateOdDbBlockLinearGrip_94 swigDelegate94;

	private SwigDelegateOdDbBlockLinearGrip_95 swigDelegate95;

	private SwigDelegateOdDbBlockLinearGrip_96 swigDelegate96;

	private SwigDelegateOdDbBlockLinearGrip_97 swigDelegate97;

	private SwigDelegateOdDbBlockLinearGrip_98 swigDelegate98;

	private SwigDelegateOdDbBlockLinearGrip_99 swigDelegate99;

	private SwigDelegateOdDbBlockLinearGrip_100 swigDelegate100;

	private SwigDelegateOdDbBlockLinearGrip_101 swigDelegate101;

	private SwigDelegateOdDbBlockLinearGrip_102 swigDelegate102;

	private SwigDelegateOdDbBlockLinearGrip_103 swigDelegate103;

	private SwigDelegateOdDbBlockLinearGrip_104 swigDelegate104;

	private SwigDelegateOdDbBlockLinearGrip_105 swigDelegate105;

	private SwigDelegateOdDbBlockLinearGrip_106 swigDelegate106;

	private SwigDelegateOdDbBlockLinearGrip_107 swigDelegate107;

	private SwigDelegateOdDbBlockLinearGrip_108 swigDelegate108;

	private SwigDelegateOdDbBlockLinearGrip_109 swigDelegate109;

	private SwigDelegateOdDbBlockLinearGrip_110 swigDelegate110;

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

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes63 = new Type[3]
	{
		typeof(uint),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(OdDbEvalGraph) };

	private static Type[] swigMethodTypes65 = new Type[1] { typeof(OdDbEvalGraph) };

	private static Type[] swigMethodTypes66 = new Type[1] { typeof(OdDbEvalGraph) };

	private static Type[] swigMethodTypes67 = new Type[0];

	private static Type[] swigMethodTypes68 = new Type[1] { typeof(OdDbEvalNodeIdArray) };

	private static Type[] swigMethodTypes69 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes70 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes71 = new Type[1] { typeof(OdDbEvalContext) };

	private static Type[] swigMethodTypes72 = new Type[1] { typeof(OdDbEvalExpr) };

	private static Type[] swigMethodTypes73 = new Type[1] { typeof(OdDbEvalIdMap) };

	private static Type[] swigMethodTypes74 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes75 = new Type[1] { typeof(OdStringArray) };

	private static Type[] swigMethodTypes76 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes77 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes78 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes79 = new Type[2]
	{
		typeof(string),
		typeof(OdResBuf)
	};

	private static Type[] swigMethodTypes80 = new Type[3]
	{
		typeof(string),
		typeof(uint),
		typeof(string)
	};

	private static Type[] swigMethodTypes81 = new Type[3]
	{
		typeof(string),
		typeof(uint),
		typeof(string)
	};

	private static Type[] swigMethodTypes82 = new Type[3]
	{
		typeof(string),
		typeof(uint),
		typeof(string)
	};

	private static Type[] swigMethodTypes83 = new Type[2]
	{
		typeof(string),
		typeof(OdDbEvalNodeIdArray)
	};

	private static Type[] swigMethodTypes84 = new Type[3]
	{
		typeof(string),
		typeof(uint),
		typeof(OdStringArray)
	};

	private static Type[] swigMethodTypes85 = new Type[0];

	private static Type[] swigMethodTypes86 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes87 = new Type[0];

	private static Type[] swigMethodTypes88 = new Type[0];

	private static Type[] swigMethodTypes89 = new Type[0];

	private static Type[] swigMethodTypes90 = new Type[0];

	private static Type[] swigMethodTypes91 = new Type[1] { typeof(OdGePoint3dArray) };

	private static Type[] swigMethodTypes92 = new Type[2]
	{
		typeof(OdIntArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes93 = new Type[0];

	private static Type[] swigMethodTypes94 = new Type[0];

	private static Type[] swigMethodTypes95 = new Type[2]
	{
		typeof(OdResBuf),
		typeof(bool)
	};

	private static Type[] swigMethodTypes96 = new Type[1] { typeof(OdResBuf) };

	private static Type[] swigMethodTypes97 = new Type[0];

	private static Type[] swigMethodTypes98 = new Type[0];

	private static Type[] swigMethodTypes99 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes100 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes101 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes102 = new Type[1] { typeof(OdDbBlockElementEntity) };

	private static Type[] swigMethodTypes103 = new Type[0];

	private static Type[] swigMethodTypes104 = new Type[0];

	private static Type[] swigMethodTypes105 = new Type[1] { typeof(OdDbBlockTableRecord) };

	private static Type[] swigMethodTypes106 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes107 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes108 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes109 = new Type[1] { typeof(OdDbBlockTableRecord) };

	private static Type[] swigMethodTypes110 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(OdDbObjectId)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBlockLinearGrip(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBlockLinearGrip obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbBlockLinearGrip(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBlockLinearGrip cast(OdRxObject pObj)
	{
		OdDbBlockLinearGrip rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockLinearGrip>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_isASwigExplicitOdDbBlockLinearGrip(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_queryXSwigExplicitOdDbBlockLinearGrip(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_dwgInFieldsSwigExplicitOdDbBlockLinearGrip(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_dwgOutFieldsSwigExplicitOdDbBlockLinearGrip(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_dxfInFieldsSwigExplicitOdDbBlockLinearGrip(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_dxfOutFieldsSwigExplicitOdDbBlockLinearGrip(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBlockLinearParameter getAssociatedLinearParameter(OdDb_OpenMode arg0)
	{
		OdDbBlockLinearParameter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockLinearParameter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_getAssociatedLinearParameter__SWIG_0(swigCPtr, (int)arg0), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbBlockLinearParameter getAssociatedLinearParameter()
	{
		OdDbBlockLinearParameter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockLinearParameter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_getAssociatedLinearParameter__SWIG_1(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGeVector3d orientation()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_orientation(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setOrientation(OdGeVector3d arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_setOrientation(swigCPtr, OdGeVector3d.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbBlockLinearGrip createObject()
	{
		OdDbBlockLinearGrip rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockLinearGrip>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("subGetClassID", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodsubGetClassID;
		}
		if (SwigDerivedClassHasMethod("adjacentNodeRemoved", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodadjacentNodeRemoved;
		}
		if (SwigDerivedClassHasMethod("adjacentEdgeRemoved", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodadjacentEdgeRemoved;
		}
		if (SwigDerivedClassHasMethod("adjacentEdgeAdded", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodadjacentEdgeAdded;
		}
		if (SwigDerivedClassHasMethod("movedFromGraph", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodmovedFromGraph;
		}
		if (SwigDerivedClassHasMethod("movedIntoGraph", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodmovedIntoGraph;
		}
		if (SwigDerivedClassHasMethod("copiedIntoGraph", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodcopiedIntoGraph;
		}
		if (SwigDerivedClassHasMethod("isActivatable", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodisActivatable;
		}
		if (SwigDerivedClassHasMethod("activated", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodactivated;
		}
		if (SwigDerivedClassHasMethod("graphEvalStart", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodgraphEvalStart;
		}
		if (SwigDerivedClassHasMethod("graphEvalAbort", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodgraphEvalAbort;
		}
		if (SwigDerivedClassHasMethod("evaluate", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodevaluate;
		}
		if (SwigDerivedClassHasMethod("equals", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodequals;
		}
		if (SwigDerivedClassHasMethod("remappedNodeIds", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodremappedNodeIds;
		}
		if (SwigDerivedClassHasMethod("postInDatabase", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodpostInDatabase;
		}
		if (SwigDerivedClassHasMethod("getConnectionNames", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodgetConnectionNames;
		}
		if (SwigDerivedClassHasMethod("hasConnectionNamed", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodhasConnectionNamed;
		}
		if (SwigDerivedClassHasMethod("getConnectionType", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodgetConnectionType;
		}
		if (SwigDerivedClassHasMethod("getConnectionValue", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodgetConnectionValue;
		}
		if (SwigDerivedClassHasMethod("setConnectionValue", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodsetConnectionValue;
		}
		if (SwigDerivedClassHasMethod("connectTo", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodconnectTo;
		}
		if (SwigDerivedClassHasMethod("disconnectFrom", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethoddisconnectFrom;
		}
		if (SwigDerivedClassHasMethod("connectionAllowed", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodconnectionAllowed;
		}
		if (SwigDerivedClassHasMethod("getConnectedObjects", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodgetConnectedObjects;
		}
		if (SwigDerivedClassHasMethod("getConnectedNames", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodgetConnectedNames;
		}
		if (SwigDerivedClassHasMethod("name", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodname;
		}
		if (SwigDerivedClassHasMethod("setName", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodsetName;
		}
		if (SwigDerivedClassHasMethod("alertState", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodalertState;
		}
		if (SwigDerivedClassHasMethod("auditAlertState", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodauditAlertState;
		}
		if (SwigDerivedClassHasMethod("getInstanceVersion", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodgetInstanceVersion;
		}
		if (SwigDerivedClassHasMethod("getInstanceMaintenanceVersion", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodgetInstanceMaintenanceVersion;
		}
		if (SwigDerivedClassHasMethod("getStretchPoints", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodgetStretchPoints;
		}
		if (SwigDerivedClassHasMethod("moveStretchPointsAt", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodmoveStretchPointsAt;
		}
		if (SwigDerivedClassHasMethod("historyRequired", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodhistoryRequired;
		}
		if (SwigDerivedClassHasMethod("hasInstanceData", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodhasInstanceData;
		}
		if (SwigDerivedClassHasMethod("loadInstanceData", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodloadInstanceData__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("loadInstanceData", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodloadInstanceData__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("saveInstanceData", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodsaveInstanceData;
		}
		if (SwigDerivedClassHasMethod("isMemberOfCurrentVisibilitySet", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodisMemberOfCurrentVisibilitySet;
		}
		if (SwigDerivedClassHasMethod("setMemberOfCurrentVisibilitySet", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethodsetMemberOfCurrentVisibilitySet;
		}
		if (SwigDerivedClassHasMethod("transformDefinitionBy", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodtransformDefinitionBy;
		}
		if (SwigDerivedClassHasMethod("transformBy", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodtransformBy;
		}
		if (SwigDerivedClassHasMethod("sync", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethodsync;
		}
		if (SwigDerivedClassHasMethod("getEntity", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethodgetEntity;
		}
		if (SwigDerivedClassHasMethod("getRxEntity", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethodgetRxEntity;
		}
		if (SwigDerivedClassHasMethod("onBeginEdit", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodonBeginEdit;
		}
		if (SwigDerivedClassHasMethod("onBeginEditEnded", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethodonBeginEditEnded;
		}
		if (SwigDerivedClassHasMethod("onBeginSaveStarted", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodonBeginSaveStarted;
		}
		if (SwigDerivedClassHasMethod("onBeginSaveEnded", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethodonBeginSaveEnded;
		}
		if (SwigDerivedClassHasMethod("onEndEdit", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodonEndEdit;
		}
		if (SwigDerivedClassHasMethod("onEndEditStarted", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodonEndEditStarted;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockLinearGrip_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBlockLinearGrip));
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

	private int SwigDirectorMethodsubGetClassID(IntPtr pClsid)
	{
		return (int)subGetClassID(pClsid);
	}

	private void SwigDirectorMethodadjacentNodeRemoved(uint arg0)
	{
		try
		{
			adjacentNodeRemoved(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodadjacentEdgeRemoved(uint adjEdgeNodeId)
	{
		try
		{
			adjacentEdgeRemoved(adjEdgeNodeId);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodadjacentEdgeAdded(uint fromId, uint toId, bool isInvertible)
	{
		try
		{
			adjacentEdgeAdded(fromId, toId, isInvertible);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodmovedFromGraph(IntPtr pFromGraph)
	{
		try
		{
			movedFromGraph(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalGraph>(pFromGraph, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodmovedIntoGraph(IntPtr pIntoGraph)
	{
		try
		{
			movedIntoGraph(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalGraph>(pIntoGraph, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodcopiedIntoGraph(IntPtr pIntoGraph)
	{
		try
		{
			copiedIntoGraph(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalGraph>(pIntoGraph, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisActivatable()
	{
		return isActivatable();
	}

	private void SwigDirectorMethodactivated(IntPtr argumentActiveList)
	{
		try
		{
			activated(new OdDbEvalNodeIdArray(argumentActiveList, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodgraphEvalStart(bool nodeIsActive)
	{
		try
		{
			graphEvalStart(nodeIsActive);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodgraphEvalAbort(bool nodeIsActive)
	{
		try
		{
			graphEvalAbort(nodeIsActive);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodevaluate(IntPtr arg0)
	{
		return evaluate(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalContext>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodequals(IntPtr pOther)
	{
		return equals(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalExpr>(pOther, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodremappedNodeIds(IntPtr idMap)
	{
		try
		{
			remappedNodeIds(new OdDbEvalIdMap(idMap, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodpostInDatabase(IntPtr arg0)
	{
		return (int)postInDatabase(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodgetConnectionNames(IntPtr arg0)
	{
		try
		{
			getConnectionNames(new OdStringArray(arg0, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodhasConnectionNamed([MarshalAs(UnmanagedType.LPWStr)] string arg0)
	{
		return hasConnectionNamed(arg0);
	}

	private int SwigDirectorMethodgetConnectionType([MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		return (int)getConnectionType(name);
	}

	private IntPtr SwigDirectorMethodgetConnectionValue([MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbEvalVariant.getCPtr(getConnectionValue(name)).Handle;
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

	private bool SwigDirectorMethodsetConnectionValue([MarshalAs(UnmanagedType.LPWStr)] string connectionName, IntPtr pValue)
	{
		return setConnectionValue(connectionName, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(pValue, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodconnectTo([MarshalAs(UnmanagedType.LPWStr)] string arg0, uint arg1, [MarshalAs(UnmanagedType.LPWStr)] string arg2)
	{
		return connectTo(arg0, arg1, arg2);
	}

	private bool SwigDirectorMethoddisconnectFrom([MarshalAs(UnmanagedType.LPWStr)] string arg0, uint arg1, [MarshalAs(UnmanagedType.LPWStr)] string arg2)
	{
		return disconnectFrom(arg0, arg1, arg2);
	}

	private bool SwigDirectorMethodconnectionAllowed([MarshalAs(UnmanagedType.LPWStr)] string arg0, uint arg1, [MarshalAs(UnmanagedType.LPWStr)] string arg2)
	{
		return connectionAllowed(arg0, arg1, arg2);
	}

	private bool SwigDirectorMethodgetConnectedObjects([MarshalAs(UnmanagedType.LPWStr)] string arg0, IntPtr arg1)
	{
		return getConnectedObjects(arg0, new OdDbEvalNodeIdArray(arg1, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodgetConnectedNames([MarshalAs(UnmanagedType.LPWStr)] string arg0, uint arg1, IntPtr arg2)
	{
		return getConnectedNames(arg0, arg1, new OdStringArray(arg2, cMemoryOwn: true));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodname()
	{
		return name();
	}

	private void SwigDirectorMethodsetName([MarshalAs(UnmanagedType.LPWStr)] string arg0)
	{
		try
		{
			setName(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethodalertState()
	{
		return alertState();
	}

	private void SwigDirectorMethodauditAlertState()
	{
		try
		{
			auditAlertState();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodgetInstanceVersion()
	{
		return (int)getInstanceVersion();
	}

	private int SwigDirectorMethodgetInstanceMaintenanceVersion()
	{
		return (int)getInstanceMaintenanceVersion();
	}

	private void SwigDirectorMethodgetStretchPoints(IntPtr points)
	{
		try
		{
			getStretchPoints(new OdGePoint3dArray(points, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodmoveStretchPointsAt(IntPtr indices, IntPtr offset)
	{
		try
		{
			moveStretchPointsAt(new OdIntArray(indices, cMemoryOwn: true), new OdGeVector3d(offset, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodhistoryRequired()
	{
		return historyRequired();
	}

	private bool SwigDirectorMethodhasInstanceData()
	{
		return hasInstanceData();
	}

	private bool SwigDirectorMethodloadInstanceData__SWIG_0(IntPtr arg0, bool bRequireEvaluate)
	{
		return loadInstanceData(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(arg0, bOwn: false, bTryAddToTransaction: false), bRequireEvaluate);
	}

	private bool SwigDirectorMethodloadInstanceData__SWIG_1(IntPtr arg0)
	{
		return loadInstanceData(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodsaveInstanceData()
	{
		return OdResBuf.getCPtr(saveInstanceData()).Handle;
	}

	private bool SwigDirectorMethodisMemberOfCurrentVisibilitySet()
	{
		return isMemberOfCurrentVisibilitySet();
	}

	private void SwigDirectorMethodsetMemberOfCurrentVisibilitySet(bool arg0)
	{
		try
		{
			setMemberOfCurrentVisibilitySet(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodtransformDefinitionBy(IntPtr arg0)
	{
		try
		{
			transformDefinitionBy(new OdGeMatrix3d(arg0, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodtransformBy(IntPtr arg0)
	{
		return (int)transformBy(new OdGeMatrix3d(arg0, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsync(IntPtr arg0)
	{
		return (int)sync(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockElementEntity>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodgetEntity()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(getEntity()).Handle;
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

	private IntPtr SwigDirectorMethodgetRxEntity()
	{
		return OdRxClass.getCPtr(getRxEntity()).Handle;
	}

	private bool SwigDirectorMethodonBeginEdit(IntPtr arg0)
	{
		return onBeginEdit(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableRecord>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodonBeginEditEnded(IntPtr entityId, IntPtr blockId)
	{
		try
		{
			onBeginEditEnded(new OdDbObjectId(entityId, cMemoryOwn: true), new OdDbObjectId(blockId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodonBeginSaveStarted(IntPtr entityId, IntPtr blockId)
	{
		try
		{
			onBeginSaveStarted(new OdDbObjectId(entityId, cMemoryOwn: true), new OdDbObjectId(blockId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodonBeginSaveEnded(IntPtr entityId, IntPtr blockId)
	{
		try
		{
			onBeginSaveEnded(new OdDbObjectId(entityId, cMemoryOwn: true), new OdDbObjectId(blockId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodonEndEdit(IntPtr arg0)
	{
		return onEndEdit(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableRecord>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodonEndEditStarted(IntPtr entityId, IntPtr blockId)
	{
		try
		{
			onEndEditStarted(new OdDbObjectId(entityId, cMemoryOwn: true), new OdDbObjectId(blockId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

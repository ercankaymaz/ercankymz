using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsFilerGSS : OdGsFiler
{
	public delegate IntPtr SwigDelegateOdGsFilerGSS_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsFilerGSS_1();

	public delegate void SwigDelegateOdGsFilerGSS_2(IntPtr pSource);

	public delegate uint SwigDelegateOdGsFilerGSS_3();

	public delegate void SwigDelegateOdGsFilerGSS_4(uint nVersion);

	public delegate int SwigDelegateOdGsFilerGSS_5();

	public delegate bool SwigDelegateOdGsFilerGSS_6(int arg0);

	public delegate IntPtr SwigDelegateOdGsFilerGSS_7(int arg0);

	public delegate bool SwigDelegateOdGsFilerGSS_8(IntPtr arg0);

	public delegate bool SwigDelegateOdGsFilerGSS_9(int arg0);

	public delegate void SwigDelegateOdGsFilerGSS_10(IntPtr pHandle);

	public delegate IntPtr SwigDelegateOdGsFilerGSS_11();

	public delegate void SwigDelegateOdGsFilerGSS_12(IntPtr pObj);

	public delegate IntPtr SwigDelegateOdGsFilerGSS_13();

	public delegate void SwigDelegateOdGsFilerGSS_14(IntPtr pData, uint nDataSize);

	public delegate void SwigDelegateOdGsFilerGSS_15(IntPtr pData, uint nDataSize);

	public delegate void SwigDelegateOdGsFilerGSS_16(bool bVal);

	public delegate bool SwigDelegateOdGsFilerGSS_17();

	public delegate void SwigDelegateOdGsFilerGSS_18(int val);

	public delegate int SwigDelegateOdGsFilerGSS_19();

	public delegate void SwigDelegateOdGsFilerGSS_20(uint val);

	public delegate uint SwigDelegateOdGsFilerGSS_21();

	public delegate void SwigDelegateOdGsFilerGSS_22(char val);

	public delegate char SwigDelegateOdGsFilerGSS_23();

	public delegate void SwigDelegateOdGsFilerGSS_24(byte val);

	public delegate byte SwigDelegateOdGsFilerGSS_25();

	public delegate void SwigDelegateOdGsFilerGSS_26(short val);

	public delegate short SwigDelegateOdGsFilerGSS_27();

	public delegate void SwigDelegateOdGsFilerGSS_28(ushort val);

	public delegate ushort SwigDelegateOdGsFilerGSS_29();

	public delegate void SwigDelegateOdGsFilerGSS_30(int val);

	public delegate int SwigDelegateOdGsFilerGSS_31();

	public delegate void SwigDelegateOdGsFilerGSS_32(uint val);

	public delegate uint SwigDelegateOdGsFilerGSS_33();

	public delegate void SwigDelegateOdGsFilerGSS_34(long val);

	public delegate long SwigDelegateOdGsFilerGSS_35();

	public delegate void SwigDelegateOdGsFilerGSS_36(ulong val);

	public delegate ulong SwigDelegateOdGsFilerGSS_37();

	public delegate void SwigDelegateOdGsFilerGSS_38(IntPtr val);

	public delegate IntPtr SwigDelegateOdGsFilerGSS_39();

	public delegate void SwigDelegateOdGsFilerGSS_40(uint val);

	public delegate uint SwigDelegateOdGsFilerGSS_41();

	public delegate void SwigDelegateOdGsFilerGSS_42(float val);

	public delegate float SwigDelegateOdGsFilerGSS_43();

	public delegate void SwigDelegateOdGsFilerGSS_44(double val);

	public delegate double SwigDelegateOdGsFilerGSS_45();

	public delegate void SwigDelegateOdGsFilerGSS_46(IntPtr pt);

	public delegate void SwigDelegateOdGsFilerGSS_47(IntPtr pt);

	public delegate void SwigDelegateOdGsFilerGSS_48(IntPtr vec);

	public delegate void SwigDelegateOdGsFilerGSS_49(IntPtr vec);

	public delegate void SwigDelegateOdGsFilerGSS_50(IntPtr pt);

	public delegate void SwigDelegateOdGsFilerGSS_51(IntPtr pt);

	public delegate void SwigDelegateOdGsFilerGSS_52(IntPtr vec);

	public delegate void SwigDelegateOdGsFilerGSS_53(IntPtr vec);

	public delegate void SwigDelegateOdGsFilerGSS_54(IntPtr mat);

	public delegate void SwigDelegateOdGsFilerGSS_55(IntPtr mat);

	public delegate void SwigDelegateOdGsFilerGSS_56(IntPtr ext);

	public delegate void SwigDelegateOdGsFilerGSS_57(IntPtr ext);

	public delegate void SwigDelegateOdGsFilerGSS_58([MarshalAs(UnmanagedType.LPWStr)] string str);

	public delegate void SwigDelegateOdGsFilerGSS_59(IntPtr str);

	public delegate void SwigDelegateOdGsFilerGSS_60([MarshalAs(UnmanagedType.LPWStr)] string str);

	public delegate void SwigDelegateOdGsFilerGSS_61(IntPtr str);

	public delegate void SwigDelegateOdGsFilerGSS_62(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_63(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_64(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_65(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_66(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_67(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_68(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_69(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_70(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_71(IntPtr rc);

	public delegate void SwigDelegateOdGsFilerGSS_72(IntPtr rcd);

	public delegate void SwigDelegateOdGsFilerGSS_73(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_74(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_75(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_76(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_77(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_78(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_79(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_80(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_81(IntPtr arr);

	public delegate void SwigDelegateOdGsFilerGSS_82(IntPtr dcrc);

	public delegate void SwigDelegateOdGsFilerGSS_83(IntPtr dcrcd);

	public delegate bool SwigDelegateOdGsFilerGSS_84(IntPtr pStream, bool bWrite);

	public delegate bool SwigDelegateOdGsFilerGSS_85(IntPtr pStream);

	public delegate IntPtr SwigDelegateOdGsFilerGSS_86();

	public delegate void SwigDelegateOdGsFilerGSS_87(IntPtr pDb);

	public delegate IntPtr SwigDelegateOdGsFilerGSS_88();

	public delegate void SwigDelegateOdGsFilerGSS_89(IntPtr pDb);

	public delegate bool SwigDelegateOdGsFilerGSS_90(IntPtr pDb);

	public delegate void SwigDelegateOdGsFilerGSS_91(ulong nSections);

	public delegate void SwigDelegateOdGsFilerGSS_92(int section, bool bSet);

	public delegate bool SwigDelegateOdGsFilerGSS_93(int section);

	public delegate void SwigDelegateOdGsFilerGSS_94(ulong nSections);

	public delegate void SwigDelegateOdGsFilerGSS_95(int section, bool bSet);

	public delegate bool SwigDelegateOdGsFilerGSS_96(int section);

	public delegate void SwigDelegateOdGsFilerGSS_97(int section);

	public delegate void SwigDelegateOdGsFilerGSS_98(int section);

	public delegate void SwigDelegateOdGsFilerGSS_99();

	public delegate int SwigDelegateOdGsFilerGSS_100();

	public delegate int SwigDelegateOdGsFilerGSS_101();

	public delegate void SwigDelegateOdGsFilerGSS_102();

	public delegate void SwigDelegateOdGsFilerGSS_103();

	public delegate bool SwigDelegateOdGsFilerGSS_104();

	public delegate IntPtr SwigDelegateOdGsFilerGSS_105();

	public delegate void SwigDelegateOdGsFilerGSS_106(bool bClear);

	public delegate void SwigDelegateOdGsFilerGSS_107();

	public delegate IntPtr SwigDelegateOdGsFilerGSS_108();

	public delegate void SwigDelegateOdGsFilerGSS_109(IntPtr pSubst);

	public delegate void SwigDelegateOdGsFilerGSS_110([MarshalAs(UnmanagedType.LPWStr)] string pName, IntPtr pObject);

	public delegate IntPtr SwigDelegateOdGsFilerGSS_111([MarshalAs(UnmanagedType.LPWStr)] string pName);

	public delegate bool SwigDelegateOdGsFilerGSS_112([MarshalAs(UnmanagedType.LPWStr)] string pName);

	public delegate void SwigDelegateOdGsFilerGSS_113();

	public delegate void SwigDelegateOdGsFilerGSS_114(IntPtr pPtr);

	public delegate void SwigDelegateOdGsFilerGSS_115(IntPtr pPtr);

	public delegate bool SwigDelegateOdGsFilerGSS_116(IntPtr pPtr);

	public delegate void SwigDelegateOdGsFilerGSS_117();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsFilerGSS_0 swigDelegate0;

	private SwigDelegateOdGsFilerGSS_1 swigDelegate1;

	private SwigDelegateOdGsFilerGSS_2 swigDelegate2;

	private SwigDelegateOdGsFilerGSS_3 swigDelegate3;

	private SwigDelegateOdGsFilerGSS_4 swigDelegate4;

	private SwigDelegateOdGsFilerGSS_5 swigDelegate5;

	private SwigDelegateOdGsFilerGSS_6 swigDelegate6;

	private SwigDelegateOdGsFilerGSS_7 swigDelegate7;

	private SwigDelegateOdGsFilerGSS_8 swigDelegate8;

	private SwigDelegateOdGsFilerGSS_9 swigDelegate9;

	private SwigDelegateOdGsFilerGSS_10 swigDelegate10;

	private SwigDelegateOdGsFilerGSS_11 swigDelegate11;

	private SwigDelegateOdGsFilerGSS_12 swigDelegate12;

	private SwigDelegateOdGsFilerGSS_13 swigDelegate13;

	private SwigDelegateOdGsFilerGSS_14 swigDelegate14;

	private SwigDelegateOdGsFilerGSS_15 swigDelegate15;

	private SwigDelegateOdGsFilerGSS_16 swigDelegate16;

	private SwigDelegateOdGsFilerGSS_17 swigDelegate17;

	private SwigDelegateOdGsFilerGSS_18 swigDelegate18;

	private SwigDelegateOdGsFilerGSS_19 swigDelegate19;

	private SwigDelegateOdGsFilerGSS_20 swigDelegate20;

	private SwigDelegateOdGsFilerGSS_21 swigDelegate21;

	private SwigDelegateOdGsFilerGSS_22 swigDelegate22;

	private SwigDelegateOdGsFilerGSS_23 swigDelegate23;

	private SwigDelegateOdGsFilerGSS_24 swigDelegate24;

	private SwigDelegateOdGsFilerGSS_25 swigDelegate25;

	private SwigDelegateOdGsFilerGSS_26 swigDelegate26;

	private SwigDelegateOdGsFilerGSS_27 swigDelegate27;

	private SwigDelegateOdGsFilerGSS_28 swigDelegate28;

	private SwigDelegateOdGsFilerGSS_29 swigDelegate29;

	private SwigDelegateOdGsFilerGSS_30 swigDelegate30;

	private SwigDelegateOdGsFilerGSS_31 swigDelegate31;

	private SwigDelegateOdGsFilerGSS_32 swigDelegate32;

	private SwigDelegateOdGsFilerGSS_33 swigDelegate33;

	private SwigDelegateOdGsFilerGSS_34 swigDelegate34;

	private SwigDelegateOdGsFilerGSS_35 swigDelegate35;

	private SwigDelegateOdGsFilerGSS_36 swigDelegate36;

	private SwigDelegateOdGsFilerGSS_37 swigDelegate37;

	private SwigDelegateOdGsFilerGSS_38 swigDelegate38;

	private SwigDelegateOdGsFilerGSS_39 swigDelegate39;

	private SwigDelegateOdGsFilerGSS_40 swigDelegate40;

	private SwigDelegateOdGsFilerGSS_41 swigDelegate41;

	private SwigDelegateOdGsFilerGSS_42 swigDelegate42;

	private SwigDelegateOdGsFilerGSS_43 swigDelegate43;

	private SwigDelegateOdGsFilerGSS_44 swigDelegate44;

	private SwigDelegateOdGsFilerGSS_45 swigDelegate45;

	private SwigDelegateOdGsFilerGSS_46 swigDelegate46;

	private SwigDelegateOdGsFilerGSS_47 swigDelegate47;

	private SwigDelegateOdGsFilerGSS_48 swigDelegate48;

	private SwigDelegateOdGsFilerGSS_49 swigDelegate49;

	private SwigDelegateOdGsFilerGSS_50 swigDelegate50;

	private SwigDelegateOdGsFilerGSS_51 swigDelegate51;

	private SwigDelegateOdGsFilerGSS_52 swigDelegate52;

	private SwigDelegateOdGsFilerGSS_53 swigDelegate53;

	private SwigDelegateOdGsFilerGSS_54 swigDelegate54;

	private SwigDelegateOdGsFilerGSS_55 swigDelegate55;

	private SwigDelegateOdGsFilerGSS_56 swigDelegate56;

	private SwigDelegateOdGsFilerGSS_57 swigDelegate57;

	private SwigDelegateOdGsFilerGSS_58 swigDelegate58;

	private SwigDelegateOdGsFilerGSS_59 swigDelegate59;

	private SwigDelegateOdGsFilerGSS_60 swigDelegate60;

	private SwigDelegateOdGsFilerGSS_61 swigDelegate61;

	private SwigDelegateOdGsFilerGSS_62 swigDelegate62;

	private SwigDelegateOdGsFilerGSS_63 swigDelegate63;

	private SwigDelegateOdGsFilerGSS_64 swigDelegate64;

	private SwigDelegateOdGsFilerGSS_65 swigDelegate65;

	private SwigDelegateOdGsFilerGSS_66 swigDelegate66;

	private SwigDelegateOdGsFilerGSS_67 swigDelegate67;

	private SwigDelegateOdGsFilerGSS_68 swigDelegate68;

	private SwigDelegateOdGsFilerGSS_69 swigDelegate69;

	private SwigDelegateOdGsFilerGSS_70 swigDelegate70;

	private SwigDelegateOdGsFilerGSS_71 swigDelegate71;

	private SwigDelegateOdGsFilerGSS_72 swigDelegate72;

	private SwigDelegateOdGsFilerGSS_73 swigDelegate73;

	private SwigDelegateOdGsFilerGSS_74 swigDelegate74;

	private SwigDelegateOdGsFilerGSS_75 swigDelegate75;

	private SwigDelegateOdGsFilerGSS_76 swigDelegate76;

	private SwigDelegateOdGsFilerGSS_77 swigDelegate77;

	private SwigDelegateOdGsFilerGSS_78 swigDelegate78;

	private SwigDelegateOdGsFilerGSS_79 swigDelegate79;

	private SwigDelegateOdGsFilerGSS_80 swigDelegate80;

	private SwigDelegateOdGsFilerGSS_81 swigDelegate81;

	private SwigDelegateOdGsFilerGSS_82 swigDelegate82;

	private SwigDelegateOdGsFilerGSS_83 swigDelegate83;

	private SwigDelegateOdGsFilerGSS_84 swigDelegate84;

	private SwigDelegateOdGsFilerGSS_85 swigDelegate85;

	private SwigDelegateOdGsFilerGSS_86 swigDelegate86;

	private SwigDelegateOdGsFilerGSS_87 swigDelegate87;

	private SwigDelegateOdGsFilerGSS_88 swigDelegate88;

	private SwigDelegateOdGsFilerGSS_89 swigDelegate89;

	private SwigDelegateOdGsFilerGSS_90 swigDelegate90;

	private SwigDelegateOdGsFilerGSS_91 swigDelegate91;

	private SwigDelegateOdGsFilerGSS_92 swigDelegate92;

	private SwigDelegateOdGsFilerGSS_93 swigDelegate93;

	private SwigDelegateOdGsFilerGSS_94 swigDelegate94;

	private SwigDelegateOdGsFilerGSS_95 swigDelegate95;

	private SwigDelegateOdGsFilerGSS_96 swigDelegate96;

	private SwigDelegateOdGsFilerGSS_97 swigDelegate97;

	private SwigDelegateOdGsFilerGSS_98 swigDelegate98;

	private SwigDelegateOdGsFilerGSS_99 swigDelegate99;

	private SwigDelegateOdGsFilerGSS_100 swigDelegate100;

	private SwigDelegateOdGsFilerGSS_101 swigDelegate101;

	private SwigDelegateOdGsFilerGSS_102 swigDelegate102;

	private SwigDelegateOdGsFilerGSS_103 swigDelegate103;

	private SwigDelegateOdGsFilerGSS_104 swigDelegate104;

	private SwigDelegateOdGsFilerGSS_105 swigDelegate105;

	private SwigDelegateOdGsFilerGSS_106 swigDelegate106;

	private SwigDelegateOdGsFilerGSS_107 swigDelegate107;

	private SwigDelegateOdGsFilerGSS_108 swigDelegate108;

	private SwigDelegateOdGsFilerGSS_109 swigDelegate109;

	private SwigDelegateOdGsFilerGSS_110 swigDelegate110;

	private SwigDelegateOdGsFilerGSS_111 swigDelegate111;

	private SwigDelegateOdGsFilerGSS_112 swigDelegate112;

	private SwigDelegateOdGsFilerGSS_113 swigDelegate113;

	private SwigDelegateOdGsFilerGSS_114 swigDelegate114;

	private SwigDelegateOdGsFilerGSS_115 swigDelegate115;

	private SwigDelegateOdGsFilerGSS_116 swigDelegate116;

	private SwigDelegateOdGsFilerGSS_117 swigDelegate117;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGsFilerExtension_Type) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGsFilerExtension_Type) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGsFilerExtension) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGsFilerExtension_Type) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(IntPtr),
		typeof(uint)
	};

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(IntPtr),
		typeof(uint)
	};

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(char) };

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes25 = new Type[0];

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(short) };

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(ushort) };

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes33 = new Type[0];

	private static Type[] swigMethodTypes34 = new Type[1] { typeof(long) };

	private static Type[] swigMethodTypes35 = new Type[0];

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(ulong) };

	private static Type[] swigMethodTypes37 = new Type[0];

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes39 = new Type[0];

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(float) };

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[1] { typeof(OdGePoint2d) };

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(OdGePoint2d) };

	private static Type[] swigMethodTypes48 = new Type[1] { typeof(OdGeVector2d) };

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(OdGeVector2d) };

	private static Type[] swigMethodTypes50 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes54 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes56 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(OdUInt8Array) };

	private static Type[] swigMethodTypes63 = new Type[1] { typeof(OdUInt16Array) };

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(OdUInt32Array) };

	private static Type[] swigMethodTypes65 = new Type[1] { typeof(OdUInt64Array) };

	private static Type[] swigMethodTypes66 = new Type[1] { typeof(OdIntArray) };

	private static Type[] swigMethodTypes67 = new Type[1] { typeof(OdFloatArray) };

	private static Type[] swigMethodTypes68 = new Type[1] { typeof(OdGePoint2dArray) };

	private static Type[] swigMethodTypes69 = new Type[1] { typeof(OdGePoint3dArray) };

	private static Type[] swigMethodTypes70 = new Type[1] { typeof(OdDbStubPtrArray) };

	private static Type[] swigMethodTypes71 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes72 = new Type[1] { typeof(OdGsDCRectDouble) };

	private static Type[] swigMethodTypes73 = new Type[1] { typeof(OdUInt8Array) };

	private static Type[] swigMethodTypes74 = new Type[1] { typeof(OdUInt16Array) };

	private static Type[] swigMethodTypes75 = new Type[1] { typeof(OdUInt32Array) };

	private static Type[] swigMethodTypes76 = new Type[1] { typeof(OdUInt64Array) };

	private static Type[] swigMethodTypes77 = new Type[1] { typeof(OdIntArray) };

	private static Type[] swigMethodTypes78 = new Type[1] { typeof(OdFloatArray) };

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(OdGePoint2dArray) };

	private static Type[] swigMethodTypes80 = new Type[1] { typeof(OdGePoint3dArray) };

	private static Type[] swigMethodTypes81 = new Type[1] { typeof(OdDbStubPtrArray) };

	private static Type[] swigMethodTypes82 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes83 = new Type[1] { typeof(OdGsDCRectDouble) };

	private static Type[] swigMethodTypes84 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(bool)
	};

	private static Type[] swigMethodTypes85 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes86 = new Type[0];

	private static Type[] swigMethodTypes87 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes88 = new Type[0];

	private static Type[] swigMethodTypes89 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes90 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes91 = new Type[1] { typeof(ulong) };

	private static Type[] swigMethodTypes92 = new Type[2]
	{
		typeof(OdGsFilerGSS_Section),
		typeof(bool)
	};

	private static Type[] swigMethodTypes93 = new Type[1] { typeof(OdGsFilerGSS_Section) };

	private static Type[] swigMethodTypes94 = new Type[1] { typeof(ulong) };

	private static Type[] swigMethodTypes95 = new Type[2]
	{
		typeof(OdGsFilerGSS_Section),
		typeof(bool)
	};

	private static Type[] swigMethodTypes96 = new Type[1] { typeof(OdGsFilerGSS_Section) };

	private static Type[] swigMethodTypes97 = new Type[1] { typeof(OdGsFilerGSS_Section) };

	private static Type[] swigMethodTypes98 = new Type[1] { typeof(OdGsFilerGSS_Section) };

	private static Type[] swigMethodTypes99 = new Type[0];

	private static Type[] swigMethodTypes100 = new Type[0];

	private static Type[] swigMethodTypes101 = new Type[0];

	private static Type[] swigMethodTypes102 = new Type[0];

	private static Type[] swigMethodTypes103 = new Type[0];

	private static Type[] swigMethodTypes104 = new Type[0];

	private static Type[] swigMethodTypes105 = new Type[0];

	private static Type[] swigMethodTypes106 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes107 = new Type[0];

	private static Type[] swigMethodTypes108 = new Type[0];

	private static Type[] swigMethodTypes109 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes110 = new Type[2]
	{
		typeof(string),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes111 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes112 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes113 = new Type[0];

	private static Type[] swigMethodTypes114 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes115 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes116 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes117 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsFilerGSS(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsFilerGSS obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerGSS(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual bool setStream(OdStreamBuf pStream, bool bWrite)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_setStream__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStream), bWrite);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setStream(OdStreamBuf pStream)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_setStream__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStream));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdStreamBuf getStream()
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_getStream(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setDatabase(OdRxObject pDb)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_setDatabase(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject getDatabase()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_getDatabase(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGsFiler_FilerType filerType()
	{
		int result = (SwigDerivedClassHasMethod("filerType", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_filerTypeSwigExplicitOdGsFilerGSS(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_filerType(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFiler_FilerType)result;
	}

	public virtual void wrDbHash(OdRxObject pDb)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_wrDbHash(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool checkDbHash(OdRxObject pDb)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_checkDbHash(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setWriteSections(ulong nSections)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_setWriteSections(swigCPtr, nSections);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setWriteSection(OdGsFilerGSS_Section section, bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_setWriteSection(swigCPtr, (int)section, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isWriteSection(OdGsFilerGSS_Section section)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_isWriteSection(swigCPtr, (int)section);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setReadSections(ulong nSections)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_setReadSections(swigCPtr, nSections);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setReadSection(OdGsFilerGSS_Section section, bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_setReadSection(swigCPtr, (int)section, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isReadSection(OdGsFilerGSS_Section section)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_isReadSection(swigCPtr, (int)section);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrSectionBegin(OdGsFilerGSS_Section section)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_wrSectionBegin(swigCPtr, (int)section);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrSectionEnd(OdGsFilerGSS_Section section)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_wrSectionEnd(swigCPtr, (int)section);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrEOFSection()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_wrEOFSection(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsFilerGSS_Section rdSection()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_rdSection(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerGSS_Section)result;
	}

	public virtual OdGsFilerGSS_Section curSection()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_curSection(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerGSS_Section)result;
	}

	public virtual void skipSection()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_skipSection(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdBackSection()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_rdBackSection(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool checkEOF()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_checkEOF(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsFilerExtensionSubstitutor.Substitutor subst()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_subst(swigCPtr);
		OdGsFilerExtensionSubstitutor.Substitutor result = ((intPtr == IntPtr.Zero) ? null : new OdGsFilerExtensionSubstitutor.Substitutor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void makeSubstitutions(bool bClear)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_makeSubstitutions__SWIG_0(swigCPtr, bClear);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void makeSubstitutions()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_makeSubstitutions__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject getSubstitutor()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_getSubstitutor(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setSubstitutor(OdRxObject pSubst)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_setSubstitutor(swigCPtr, OdRxObject.getCPtr(pSubst));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setArbitraryData(string pName, OdRxObject pObject)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_setArbitraryData(swigCPtr, pName, OdRxObject.getCPtr(pObject));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject getArbitraryData(string pName)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_getArbitraryData(swigCPtr, pName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool hasArbitraryData(string pName)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_hasArbitraryData(swigCPtr, pName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clearArbitraryData()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_clearArbitraryData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void registerPtr(IntPtr pPtr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_registerPtr(swigCPtr, pPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void unregisterPtr(IntPtr pPtr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_unregisterPtr(swigCPtr, pPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isPtrRegistered(IntPtr pPtr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_isPtrRegistered(swigCPtr, pPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clearRegisteredPtrs()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_clearRegisteredPtrs(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGsFilerGSS cast(OdGsFiler pFiler)
	{
		OdGsFilerGSS rXObject = Helpers.GetRXObject<OdGsFilerGSS>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_cast__SWIG_0(OdGsFiler.getCPtr(pFiler)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsFilerGSS createObject(OdStreamBuf pStream, bool bForWrite, OdRxObject pDb, uint nVersion)
	{
		OdGsFilerGSS rXObject = Helpers.GetRXObject<OdGsFilerGSS>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_createObject__SWIG_0(OdStreamBuf.getCPtr(pStream), bForWrite, OdRxObject.getCPtr(pDb), nVersion), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsFilerGSS createObject(OdStreamBuf pStream, bool bForWrite, OdRxObject pDb)
	{
		OdGsFilerGSS rXObject = Helpers.GetRXObject<OdGsFilerGSS>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_createObject__SWIG_1(OdStreamBuf.getCPtr(pStream), bForWrite, OdRxObject.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsFilerGSS()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerGSS(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsFilerGSS) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		if (SwigDerivedClassHasMethod("version", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodversion;
		}
		if (SwigDerivedClassHasMethod("setVersion", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetVersion;
		}
		if (SwigDerivedClassHasMethod("filerType", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodfilerType;
		}
		if (SwigDerivedClassHasMethod("hasExtension", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodhasExtension;
		}
		if (SwigDerivedClassHasMethod("getExtension", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetExtension;
		}
		if (SwigDerivedClassHasMethod("installExtension", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodinstallExtension;
		}
		if (SwigDerivedClassHasMethod("uninstallExtension", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethoduninstallExtension;
		}
		if (SwigDerivedClassHasMethod("wrHandle", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodwrHandle;
		}
		if (SwigDerivedClassHasMethod("rdHandle", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodrdHandle;
		}
		if (SwigDerivedClassHasMethod("wrClass", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodwrClass;
		}
		if (SwigDerivedClassHasMethod("rdClass", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodrdClass;
		}
		if (SwigDerivedClassHasMethod("wrRawData", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodwrRawData;
		}
		if (SwigDerivedClassHasMethod("rdRawData", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodrdRawData;
		}
		if (SwigDerivedClassHasMethod("wrBool", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodwrBool;
		}
		if (SwigDerivedClassHasMethod("rdBool", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodrdBool;
		}
		if (SwigDerivedClassHasMethod("wrInt", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodwrInt;
		}
		if (SwigDerivedClassHasMethod("rdInt", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodrdInt;
		}
		if (SwigDerivedClassHasMethod("wrUInt", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodwrUInt;
		}
		if (SwigDerivedClassHasMethod("rdUInt", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodrdUInt;
		}
		if (SwigDerivedClassHasMethod("wrChar", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodwrChar;
		}
		if (SwigDerivedClassHasMethod("rdChar", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodrdChar;
		}
		if (SwigDerivedClassHasMethod("wrUInt8", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodwrUInt8;
		}
		if (SwigDerivedClassHasMethod("rdUInt8", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodrdUInt8;
		}
		if (SwigDerivedClassHasMethod("wrInt16", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodwrInt16;
		}
		if (SwigDerivedClassHasMethod("rdInt16", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodrdInt16;
		}
		if (SwigDerivedClassHasMethod("wrUInt16", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodwrUInt16;
		}
		if (SwigDerivedClassHasMethod("rdUInt16", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodrdUInt16;
		}
		if (SwigDerivedClassHasMethod("wrInt32", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodwrInt32;
		}
		if (SwigDerivedClassHasMethod("rdInt32", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodrdInt32;
		}
		if (SwigDerivedClassHasMethod("wrUInt32", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodwrUInt32;
		}
		if (SwigDerivedClassHasMethod("rdUInt32", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodrdUInt32;
		}
		if (SwigDerivedClassHasMethod("wrInt64", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodwrInt64;
		}
		if (SwigDerivedClassHasMethod("rdInt64", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodrdInt64;
		}
		if (SwigDerivedClassHasMethod("wrUInt64", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodwrUInt64;
		}
		if (SwigDerivedClassHasMethod("rdUInt64", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodrdUInt64;
		}
		if (SwigDerivedClassHasMethod("wrIntPtr", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodwrIntPtr;
		}
		if (SwigDerivedClassHasMethod("rdIntPtr", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodrdIntPtr;
		}
		if (SwigDerivedClassHasMethod("wrCOLORREF", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodwrCOLORREF;
		}
		if (SwigDerivedClassHasMethod("rdCOLORREF", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodrdCOLORREF;
		}
		if (SwigDerivedClassHasMethod("wrFloat", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodwrFloat;
		}
		if (SwigDerivedClassHasMethod("rdFloat", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodrdFloat;
		}
		if (SwigDerivedClassHasMethod("wrDouble", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodwrDouble;
		}
		if (SwigDerivedClassHasMethod("rdDouble", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodrdDouble;
		}
		if (SwigDerivedClassHasMethod("wrPoint2d", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodwrPoint2d;
		}
		if (SwigDerivedClassHasMethod("rdPoint2d", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodrdPoint2d;
		}
		if (SwigDerivedClassHasMethod("wrVector2d", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodwrVector2d;
		}
		if (SwigDerivedClassHasMethod("rdVector2d", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodrdVector2d;
		}
		if (SwigDerivedClassHasMethod("wrPoint3d", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodwrPoint3d;
		}
		if (SwigDerivedClassHasMethod("rdPoint3d", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodrdPoint3d;
		}
		if (SwigDerivedClassHasMethod("wrVector3d", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodwrVector3d;
		}
		if (SwigDerivedClassHasMethod("rdVector3d", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodrdVector3d;
		}
		if (SwigDerivedClassHasMethod("wrMatrix3d", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodwrMatrix3d;
		}
		if (SwigDerivedClassHasMethod("rdMatrix3d", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodrdMatrix3d;
		}
		if (SwigDerivedClassHasMethod("wrExtents3d", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodwrExtents3d;
		}
		if (SwigDerivedClassHasMethod("rdExtents3d", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodrdExtents3d;
		}
		if (SwigDerivedClassHasMethod("wrAnsiString", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodwrAnsiString;
		}
		if (SwigDerivedClassHasMethod("rdAnsiString", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodrdAnsiString;
		}
		if (SwigDerivedClassHasMethod("wrString", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodwrString;
		}
		if (SwigDerivedClassHasMethod("rdString", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodrdString;
		}
		if (SwigDerivedClassHasMethod("wrUInt8Array", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodwrUInt8Array;
		}
		if (SwigDerivedClassHasMethod("wrUInt16Array", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodwrUInt16Array;
		}
		if (SwigDerivedClassHasMethod("wrUInt32Array", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodwrUInt32Array;
		}
		if (SwigDerivedClassHasMethod("wrUInt64Array", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodwrUInt64Array;
		}
		if (SwigDerivedClassHasMethod("wrIntArray", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodwrIntArray;
		}
		if (SwigDerivedClassHasMethod("wrFloatArray", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodwrFloatArray;
		}
		if (SwigDerivedClassHasMethod("wrPoint2dArray", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodwrPoint2dArray;
		}
		if (SwigDerivedClassHasMethod("wrPoint3dArray", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodwrPoint3dArray;
		}
		if (SwigDerivedClassHasMethod("wrDbStubPtrArray", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodwrDbStubPtrArray;
		}
		if (SwigDerivedClassHasMethod("wrGsDCRect", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodwrGsDCRect;
		}
		if (SwigDerivedClassHasMethod("wrGsDCRectDouble", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodwrGsDCRectDouble;
		}
		if (SwigDerivedClassHasMethod("rdUInt8Array", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodrdUInt8Array;
		}
		if (SwigDerivedClassHasMethod("rdUInt16Array", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodrdUInt16Array;
		}
		if (SwigDerivedClassHasMethod("rdUInt32Array", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodrdUInt32Array;
		}
		if (SwigDerivedClassHasMethod("rdUInt64Array", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodrdUInt64Array;
		}
		if (SwigDerivedClassHasMethod("rdIntArray", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodrdIntArray;
		}
		if (SwigDerivedClassHasMethod("rdFloatArray", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodrdFloatArray;
		}
		if (SwigDerivedClassHasMethod("rdPoint2dArray", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodrdPoint2dArray;
		}
		if (SwigDerivedClassHasMethod("rdPoint3dArray", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodrdPoint3dArray;
		}
		if (SwigDerivedClassHasMethod("rdDbStubPtrArray", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodrdDbStubPtrArray;
		}
		if (SwigDerivedClassHasMethod("rdGsDCRect", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodrdGsDCRect;
		}
		if (SwigDerivedClassHasMethod("rdGsDCRectDouble", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodrdGsDCRectDouble;
		}
		if (SwigDerivedClassHasMethod("setStream", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodsetStream__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setStream", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodsetStream__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getStream", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodgetStream;
		}
		if (SwigDerivedClassHasMethod("setDatabase", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodsetDatabase;
		}
		if (SwigDerivedClassHasMethod("getDatabase", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodgetDatabase;
		}
		if (SwigDerivedClassHasMethod("wrDbHash", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodwrDbHash;
		}
		if (SwigDerivedClassHasMethod("checkDbHash", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodcheckDbHash;
		}
		if (SwigDerivedClassHasMethod("setWriteSections", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodsetWriteSections;
		}
		if (SwigDerivedClassHasMethod("setWriteSection", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodsetWriteSection;
		}
		if (SwigDerivedClassHasMethod("isWriteSection", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodisWriteSection;
		}
		if (SwigDerivedClassHasMethod("setReadSections", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodsetReadSections;
		}
		if (SwigDerivedClassHasMethod("setReadSection", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodsetReadSection;
		}
		if (SwigDerivedClassHasMethod("isReadSection", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodisReadSection;
		}
		if (SwigDerivedClassHasMethod("wrSectionBegin", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodwrSectionBegin;
		}
		if (SwigDerivedClassHasMethod("wrSectionEnd", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodwrSectionEnd;
		}
		if (SwigDerivedClassHasMethod("wrEOFSection", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethodwrEOFSection;
		}
		if (SwigDerivedClassHasMethod("rdSection", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodrdSection;
		}
		if (SwigDerivedClassHasMethod("curSection", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodcurSection;
		}
		if (SwigDerivedClassHasMethod("skipSection", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethodskipSection;
		}
		if (SwigDerivedClassHasMethod("rdBackSection", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethodrdBackSection;
		}
		if (SwigDerivedClassHasMethod("checkEOF", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethodcheckEOF;
		}
		if (SwigDerivedClassHasMethod("subst", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodsubst;
		}
		if (SwigDerivedClassHasMethod("makeSubstitutions", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethodmakeSubstitutions__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("makeSubstitutions", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodmakeSubstitutions__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getSubstitutor", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethodgetSubstitutor;
		}
		if (SwigDerivedClassHasMethod("setSubstitutor", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodsetSubstitutor;
		}
		if (SwigDerivedClassHasMethod("setArbitraryData", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodsetArbitraryData;
		}
		if (SwigDerivedClassHasMethod("getArbitraryData", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodgetArbitraryData;
		}
		if (SwigDerivedClassHasMethod("hasArbitraryData", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodhasArbitraryData;
		}
		if (SwigDerivedClassHasMethod("clearArbitraryData", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethodclearArbitraryData;
		}
		if (SwigDerivedClassHasMethod("registerPtr", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodregisterPtr;
		}
		if (SwigDerivedClassHasMethod("unregisterPtr", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethodunregisterPtr;
		}
		if (SwigDerivedClassHasMethod("isPtrRegistered", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethodisPtrRegistered;
		}
		if (SwigDerivedClassHasMethod("clearRegisteredPtrs", swigMethodTypes117))
		{
			swigDelegate117 = SwigDirectorMethodclearRegisteredPtrs;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerGSS_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsFilerGSS));
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

	private uint SwigDirectorMethodversion()
	{
		return version();
	}

	private void SwigDirectorMethodsetVersion(uint nVersion)
	{
		try
		{
			setVersion(nVersion);
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

	private int SwigDirectorMethodfilerType()
	{
		return (int)filerType();
	}

	private bool SwigDirectorMethodhasExtension(int arg0)
	{
		return hasExtension((OdGsFilerExtension_Type)arg0);
	}

	private IntPtr SwigDirectorMethodgetExtension(int arg0)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGsFilerExtension.getCPtr(getExtension((OdGsFilerExtension_Type)arg0)).Handle;
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

	private bool SwigDirectorMethodinstallExtension(IntPtr arg0)
	{
		return installExtension((arg0 == IntPtr.Zero) ? null : new OdGsFilerExtension(arg0, cMemoryOwn: false));
	}

	private bool SwigDirectorMethoduninstallExtension(int arg0)
	{
		return uninstallExtension((OdGsFilerExtension_Type)arg0);
	}

	private void SwigDirectorMethodwrHandle(IntPtr pHandle)
	{
		try
		{
			wrHandle((pHandle == IntPtr.Zero) ? null : new OdDbStub(pHandle, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodrdHandle()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(rdHandle()).Handle;
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

	private void SwigDirectorMethodwrClass(IntPtr pObj)
	{
		try
		{
			wrClass(Helpers.GetRXObject<OdRxObject>(pObj, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodrdClass()
	{
		return OdRxObject.getCPtr(rdClass()).Handle;
	}

	private void SwigDirectorMethodwrRawData(IntPtr pData, uint nDataSize)
	{
		try
		{
			wrRawData(pData, nDataSize);
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

	private void SwigDirectorMethodrdRawData(IntPtr pData, uint nDataSize)
	{
		try
		{
			rdRawData(pData, nDataSize);
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

	private void SwigDirectorMethodwrBool(bool bVal)
	{
		try
		{
			wrBool(bVal);
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

	private bool SwigDirectorMethodrdBool()
	{
		return rdBool();
	}

	private void SwigDirectorMethodwrInt(int val)
	{
		try
		{
			wrInt(val);
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

	private int SwigDirectorMethodrdInt()
	{
		return rdInt();
	}

	private void SwigDirectorMethodwrUInt(uint val)
	{
		try
		{
			wrUInt(val);
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

	private uint SwigDirectorMethodrdUInt()
	{
		return rdUInt();
	}

	private void SwigDirectorMethodwrChar(char val)
	{
		try
		{
			wrChar(val);
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

	private char SwigDirectorMethodrdChar()
	{
		return rdChar();
	}

	private void SwigDirectorMethodwrUInt8(byte val)
	{
		try
		{
			wrUInt8(val);
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

	private byte SwigDirectorMethodrdUInt8()
	{
		return rdUInt8();
	}

	private void SwigDirectorMethodwrInt16(short val)
	{
		try
		{
			wrInt16(val);
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

	private short SwigDirectorMethodrdInt16()
	{
		return rdInt16();
	}

	private void SwigDirectorMethodwrUInt16(ushort val)
	{
		try
		{
			wrUInt16(val);
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

	private ushort SwigDirectorMethodrdUInt16()
	{
		return rdUInt16();
	}

	private void SwigDirectorMethodwrInt32(int val)
	{
		try
		{
			wrInt32(val);
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

	private int SwigDirectorMethodrdInt32()
	{
		return rdInt32();
	}

	private void SwigDirectorMethodwrUInt32(uint val)
	{
		try
		{
			wrUInt32(val);
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

	private uint SwigDirectorMethodrdUInt32()
	{
		return rdUInt32();
	}

	private void SwigDirectorMethodwrInt64(long val)
	{
		try
		{
			wrInt64(val);
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

	private long SwigDirectorMethodrdInt64()
	{
		return rdInt64();
	}

	private void SwigDirectorMethodwrUInt64(ulong val)
	{
		try
		{
			wrUInt64(val);
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

	private ulong SwigDirectorMethodrdUInt64()
	{
		return rdUInt64();
	}

	private void SwigDirectorMethodwrIntPtr(IntPtr val)
	{
		try
		{
			wrIntPtr(val);
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

	private IntPtr SwigDirectorMethodrdIntPtr()
	{
		return rdIntPtr();
	}

	private void SwigDirectorMethodwrCOLORREF(uint val)
	{
		try
		{
			wrCOLORREF(val);
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

	private uint SwigDirectorMethodrdCOLORREF()
	{
		return rdCOLORREF();
	}

	private void SwigDirectorMethodwrFloat(float val)
	{
		try
		{
			wrFloat(val);
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

	private float SwigDirectorMethodrdFloat()
	{
		return rdFloat();
	}

	private void SwigDirectorMethodwrDouble(double val)
	{
		try
		{
			wrDouble(val);
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

	private double SwigDirectorMethodrdDouble()
	{
		return rdDouble();
	}

	private void SwigDirectorMethodwrPoint2d(IntPtr pt)
	{
		try
		{
			wrPoint2d(new OdGePoint2d(pt, cMemoryOwn: false));
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

	private void SwigDirectorMethodrdPoint2d(IntPtr pt)
	{
		try
		{
			rdPoint2d(new OdGePoint2d(pt, cMemoryOwn: false));
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

	private void SwigDirectorMethodwrVector2d(IntPtr vec)
	{
		try
		{
			wrVector2d(new OdGeVector2d(vec, cMemoryOwn: true));
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

	private void SwigDirectorMethodrdVector2d(IntPtr vec)
	{
		try
		{
			rdVector2d(new OdGeVector2d(vec, cMemoryOwn: true));
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

	private void SwigDirectorMethodwrPoint3d(IntPtr pt)
	{
		try
		{
			wrPoint3d(new OdGePoint3d(pt, cMemoryOwn: false));
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

	private void SwigDirectorMethodrdPoint3d(IntPtr pt)
	{
		try
		{
			rdPoint3d(new OdGePoint3d(pt, cMemoryOwn: false));
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

	private void SwigDirectorMethodwrVector3d(IntPtr vec)
	{
		try
		{
			wrVector3d(new OdGeVector3d(vec, cMemoryOwn: false));
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

	private void SwigDirectorMethodrdVector3d(IntPtr vec)
	{
		try
		{
			rdVector3d(new OdGeVector3d(vec, cMemoryOwn: false));
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

	private void SwigDirectorMethodwrMatrix3d(IntPtr mat)
	{
		try
		{
			wrMatrix3d(new OdGeMatrix3d(mat, cMemoryOwn: false));
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

	private void SwigDirectorMethodrdMatrix3d(IntPtr mat)
	{
		try
		{
			rdMatrix3d(new OdGeMatrix3d(mat, cMemoryOwn: false));
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

	private void SwigDirectorMethodwrExtents3d(IntPtr ext)
	{
		try
		{
			wrExtents3d(new OdGeExtents3d(ext, cMemoryOwn: false));
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

	private void SwigDirectorMethodrdExtents3d(IntPtr ext)
	{
		try
		{
			rdExtents3d(new OdGeExtents3d(ext, cMemoryOwn: false));
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

	private void SwigDirectorMethodwrAnsiString([MarshalAs(UnmanagedType.LPWStr)] string str)
	{
		try
		{
			wrAnsiString(str);
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

	private void SwigDirectorMethodrdAnsiString(IntPtr str)
	{
		OdSwigDirectorHelper.director_UnpackData(str, out var pOriginalObject, out var pFunction);
		string str2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = str2;
		try
		{
			rdAnsiString(ref str2);
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
			if (str2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(str2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(str);
		}
	}

	private void SwigDirectorMethodwrString([MarshalAs(UnmanagedType.LPWStr)] string str)
	{
		try
		{
			wrString(str);
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

	private void SwigDirectorMethodrdString(IntPtr str)
	{
		OdSwigDirectorHelper.director_UnpackData(str, out var pOriginalObject, out var pFunction);
		string str2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = str2;
		try
		{
			rdString(ref str2);
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
			if (str2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(str2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(str);
		}
	}

	private void SwigDirectorMethodwrUInt8Array(IntPtr arr)
	{
		try
		{
			wrUInt8Array(new OdUInt8Array(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodwrUInt16Array(IntPtr arr)
	{
		try
		{
			wrUInt16Array(new OdUInt16Array(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodwrUInt32Array(IntPtr arr)
	{
		try
		{
			wrUInt32Array(new OdUInt32Array(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodwrUInt64Array(IntPtr arr)
	{
		try
		{
			wrUInt64Array(new OdUInt64Array(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodwrIntArray(IntPtr arr)
	{
		try
		{
			wrIntArray(new OdIntArray(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodwrFloatArray(IntPtr arr)
	{
		try
		{
			wrFloatArray(new OdFloatArray(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodwrPoint2dArray(IntPtr arr)
	{
		try
		{
			wrPoint2dArray(new OdGePoint2dArray(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodwrPoint3dArray(IntPtr arr)
	{
		try
		{
			wrPoint3dArray(new OdGePoint3dArray(arr, cMemoryOwn: false));
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

	private void SwigDirectorMethodwrDbStubPtrArray(IntPtr arr)
	{
		try
		{
			wrDbStubPtrArray(new OdDbStubPtrArray(arr, cMemoryOwn: false));
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

	private void SwigDirectorMethodwrGsDCRect(IntPtr rc)
	{
		try
		{
			wrGsDCRect(new OdGsDCRect(rc, cMemoryOwn: false));
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

	private void SwigDirectorMethodwrGsDCRectDouble(IntPtr rcd)
	{
		try
		{
			wrGsDCRectDouble(new OdGsDCRectDouble(rcd, cMemoryOwn: false));
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

	private void SwigDirectorMethodrdUInt8Array(IntPtr arr)
	{
		try
		{
			rdUInt8Array(new OdUInt8Array(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodrdUInt16Array(IntPtr arr)
	{
		try
		{
			rdUInt16Array(new OdUInt16Array(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodrdUInt32Array(IntPtr arr)
	{
		try
		{
			rdUInt32Array(new OdUInt32Array(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodrdUInt64Array(IntPtr arr)
	{
		try
		{
			rdUInt64Array(new OdUInt64Array(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodrdIntArray(IntPtr arr)
	{
		try
		{
			rdIntArray(new OdIntArray(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodrdFloatArray(IntPtr arr)
	{
		try
		{
			rdFloatArray(new OdFloatArray(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodrdPoint2dArray(IntPtr arr)
	{
		try
		{
			rdPoint2dArray(new OdGePoint2dArray(arr, cMemoryOwn: true));
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

	private void SwigDirectorMethodrdPoint3dArray(IntPtr arr)
	{
		try
		{
			rdPoint3dArray(new OdGePoint3dArray(arr, cMemoryOwn: false));
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

	private void SwigDirectorMethodrdDbStubPtrArray(IntPtr arr)
	{
		try
		{
			rdDbStubPtrArray(new OdDbStubPtrArray(arr, cMemoryOwn: false));
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

	private void SwigDirectorMethodrdGsDCRect(IntPtr dcrc)
	{
		try
		{
			rdGsDCRect(new OdGsDCRect(dcrc, cMemoryOwn: false));
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

	private void SwigDirectorMethodrdGsDCRectDouble(IntPtr dcrcd)
	{
		try
		{
			rdGsDCRectDouble(new OdGsDCRectDouble(dcrcd, cMemoryOwn: false));
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

	private bool SwigDirectorMethodsetStream__SWIG_0(IntPtr pStream, bool bWrite)
	{
		return setStream(Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: false, bTryAddToTransaction: false), bWrite);
	}

	private bool SwigDirectorMethodsetStream__SWIG_1(IntPtr pStream)
	{
		return setStream(Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodgetStream()
	{
		return OdStreamBuf.getCPtr(getStream()).Handle;
	}

	private void SwigDirectorMethodsetDatabase(IntPtr pDb)
	{
		try
		{
			setDatabase(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodgetDatabase()
	{
		return OdRxObject.getCPtr(getDatabase()).Handle;
	}

	private void SwigDirectorMethodwrDbHash(IntPtr pDb)
	{
		try
		{
			wrDbHash(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodcheckDbHash(IntPtr pDb)
	{
		return checkDbHash(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetWriteSections(ulong nSections)
	{
		try
		{
			setWriteSections(nSections);
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

	private void SwigDirectorMethodsetWriteSection(int section, bool bSet)
	{
		try
		{
			setWriteSection((OdGsFilerGSS_Section)section, bSet);
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

	private bool SwigDirectorMethodisWriteSection(int section)
	{
		return isWriteSection((OdGsFilerGSS_Section)section);
	}

	private void SwigDirectorMethodsetReadSections(ulong nSections)
	{
		try
		{
			setReadSections(nSections);
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

	private void SwigDirectorMethodsetReadSection(int section, bool bSet)
	{
		try
		{
			setReadSection((OdGsFilerGSS_Section)section, bSet);
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

	private bool SwigDirectorMethodisReadSection(int section)
	{
		return isReadSection((OdGsFilerGSS_Section)section);
	}

	private void SwigDirectorMethodwrSectionBegin(int section)
	{
		try
		{
			wrSectionBegin((OdGsFilerGSS_Section)section);
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

	private void SwigDirectorMethodwrSectionEnd(int section)
	{
		try
		{
			wrSectionEnd((OdGsFilerGSS_Section)section);
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

	private void SwigDirectorMethodwrEOFSection()
	{
		try
		{
			wrEOFSection();
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

	private int SwigDirectorMethodrdSection()
	{
		return (int)rdSection();
	}

	private int SwigDirectorMethodcurSection()
	{
		return (int)curSection();
	}

	private void SwigDirectorMethodskipSection()
	{
		try
		{
			skipSection();
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

	private void SwigDirectorMethodrdBackSection()
	{
		try
		{
			rdBackSection();
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

	private bool SwigDirectorMethodcheckEOF()
	{
		return checkEOF();
	}

	private IntPtr SwigDirectorMethodsubst()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGsFilerExtensionSubstitutor.Substitutor.getCPtr(subst()).Handle;
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

	private void SwigDirectorMethodmakeSubstitutions__SWIG_0(bool bClear)
	{
		try
		{
			makeSubstitutions(bClear);
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

	private void SwigDirectorMethodmakeSubstitutions__SWIG_1()
	{
		try
		{
			makeSubstitutions();
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

	private IntPtr SwigDirectorMethodgetSubstitutor()
	{
		return OdRxObject.getCPtr(getSubstitutor()).Handle;
	}

	private void SwigDirectorMethodsetSubstitutor(IntPtr pSubst)
	{
		try
		{
			setSubstitutor(Helpers.GetRXObject<OdRxObject>(pSubst, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodsetArbitraryData([MarshalAs(UnmanagedType.LPWStr)] string pName, IntPtr pObject)
	{
		try
		{
			setArbitraryData(pName, Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodgetArbitraryData([MarshalAs(UnmanagedType.LPWStr)] string pName)
	{
		return OdRxObject.getCPtr(getArbitraryData(pName)).Handle;
	}

	private bool SwigDirectorMethodhasArbitraryData([MarshalAs(UnmanagedType.LPWStr)] string pName)
	{
		return hasArbitraryData(pName);
	}

	private void SwigDirectorMethodclearArbitraryData()
	{
		try
		{
			clearArbitraryData();
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

	private void SwigDirectorMethodregisterPtr(IntPtr pPtr)
	{
		try
		{
			registerPtr(pPtr);
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

	private void SwigDirectorMethodunregisterPtr(IntPtr pPtr)
	{
		try
		{
			unregisterPtr(pPtr);
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

	private bool SwigDirectorMethodisPtrRegistered(IntPtr pPtr)
	{
		return isPtrRegistered(pPtr);
	}

	private void SwigDirectorMethodclearRegisteredPtrs()
	{
		try
		{
			clearRegisteredPtrs();
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

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbMaterial : OdDbObject
{
	public delegate IntPtr SwigDelegateOdDbMaterial_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbMaterial_1();

	public delegate void SwigDelegateOdDbMaterial_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbMaterial_3();

	public delegate bool SwigDelegateOdDbMaterial_4();

	public delegate IntPtr SwigDelegateOdDbMaterial_5();

	public delegate void SwigDelegateOdDbMaterial_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbMaterial_7();

	public delegate uint SwigDelegateOdDbMaterial_8(IntPtr vd);

	public delegate uint SwigDelegateOdDbMaterial_9();

	public delegate void SwigDelegateOdDbMaterial_10(IntPtr ownerId);

	public delegate int SwigDelegateOdDbMaterial_11(int mode);

	public delegate void SwigDelegateOdDbMaterial_12();

	public delegate int SwigDelegateOdDbMaterial_13(bool erasing);

	public delegate void SwigDelegateOdDbMaterial_14(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbMaterial_15(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbMaterial_16(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbMaterial_17(IntPtr otherId);

	public delegate void SwigDelegateOdDbMaterial_18(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbMaterial_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbMaterial_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbMaterial_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbMaterial_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbMaterial_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbMaterial_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbMaterial_25(IntPtr pFiler);

	public delegate void SwigDelegateOdDbMaterial_26(IntPtr pFiler);

	public delegate int SwigDelegateOdDbMaterial_27();

	public delegate IntPtr SwigDelegateOdDbMaterial_28([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbMaterial_29(IntPtr pRb);

	public delegate void SwigDelegateOdDbMaterial_30(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbMaterial_31(IntPtr objId);

	public delegate void SwigDelegateOdDbMaterial_32(IntPtr objId);

	public delegate void SwigDelegateOdDbMaterial_33(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbMaterial_34();

	public delegate void SwigDelegateOdDbMaterial_35(IntPtr idPair, IntPtr pOwnerObject, IntPtr idMap);

	public delegate void SwigDelegateOdDbMaterial_36(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbMaterial_37(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbMaterial_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbMaterial_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbMaterial_40(IntPtr pObject);

	public delegate void SwigDelegateOdDbMaterial_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbMaterial_42(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbMaterial_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbMaterial_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbMaterial_45(IntPtr pObject);

	public delegate void SwigDelegateOdDbMaterial_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbMaterial_47(IntPtr objectId);

	public delegate void SwigDelegateOdDbMaterial_48(IntPtr pObject);

	public delegate void SwigDelegateOdDbMaterial_49(IntPtr pSource);

	public delegate int SwigDelegateOdDbMaterial_50(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbMaterial_51(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbMaterial_52(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbMaterial_53(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbMaterial_54(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbMaterial_55();

	public delegate IntPtr SwigDelegateOdDbMaterial_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbMaterial_57(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbMaterial_58([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbMaterial_59(IntPtr pClass);

	public delegate int SwigDelegateOdDbMaterial_60([MarshalAs(UnmanagedType.LPWStr)] string name);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbMaterial_61();

	public delegate void SwigDelegateOdDbMaterial_62([MarshalAs(UnmanagedType.LPWStr)] string description);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbMaterial_63();

	public delegate void SwigDelegateOdDbMaterial_64(IntPtr ambientColor);

	public delegate void SwigDelegateOdDbMaterial_65(IntPtr ambientColor);

	public delegate void SwigDelegateOdDbMaterial_66(IntPtr diffuseColor, IntPtr diffuseMap);

	public delegate void SwigDelegateOdDbMaterial_67(IntPtr diffuseColor, IntPtr diffuseMap);

	public delegate void SwigDelegateOdDbMaterial_68(IntPtr specularColor, IntPtr specularMap, double glossFactor);

	public delegate void SwigDelegateOdDbMaterial_69(IntPtr specularColor, IntPtr specularMap, double glossFactor);

	public delegate void SwigDelegateOdDbMaterial_70(IntPtr reflectionMap);

	public delegate void SwigDelegateOdDbMaterial_71(IntPtr reflectionMap);

	public delegate void SwigDelegateOdDbMaterial_72(double opacityPercentage, IntPtr opacityMap);

	public delegate void SwigDelegateOdDbMaterial_73(double opacityPercentage, IntPtr opacityMap);

	public delegate void SwigDelegateOdDbMaterial_74(IntPtr bumpMap);

	public delegate void SwigDelegateOdDbMaterial_75(IntPtr map);

	public delegate void SwigDelegateOdDbMaterial_76(double refractionIndex, IntPtr refractionMap);

	public delegate void SwigDelegateOdDbMaterial_77(double refractionIndex, IntPtr refractionMap);

	public delegate double SwigDelegateOdDbMaterial_78();

	public delegate void SwigDelegateOdDbMaterial_79(double translucence);

	public delegate double SwigDelegateOdDbMaterial_80();

	public delegate void SwigDelegateOdDbMaterial_81(double selfIllumination);

	public delegate double SwigDelegateOdDbMaterial_82();

	public delegate void SwigDelegateOdDbMaterial_83(double reflectivity);

	public delegate int SwigDelegateOdDbMaterial_84();

	public delegate void SwigDelegateOdDbMaterial_85(int mode);

	public delegate int SwigDelegateOdDbMaterial_86();

	public delegate void SwigDelegateOdDbMaterial_87(int channelFlags);

	public delegate int SwigDelegateOdDbMaterial_88();

	public delegate void SwigDelegateOdDbMaterial_89(int illuminationMode);

	public delegate double SwigDelegateOdDbMaterial_90();

	public delegate void SwigDelegateOdDbMaterial_91(double scale);

	public delegate double SwigDelegateOdDbMaterial_92();

	public delegate void SwigDelegateOdDbMaterial_93(double scale);

	public delegate double SwigDelegateOdDbMaterial_94();

	public delegate void SwigDelegateOdDbMaterial_95(double scale);

	public delegate double SwigDelegateOdDbMaterial_96();

	public delegate void SwigDelegateOdDbMaterial_97(double scale);

	public delegate bool SwigDelegateOdDbMaterial_98();

	public delegate void SwigDelegateOdDbMaterial_99(bool flag);

	public delegate int SwigDelegateOdDbMaterial_100();

	public delegate void SwigDelegateOdDbMaterial_101(int mode);

	public delegate double SwigDelegateOdDbMaterial_102();

	public delegate void SwigDelegateOdDbMaterial_103(double value);

	public delegate double SwigDelegateOdDbMaterial_104();

	public delegate void SwigDelegateOdDbMaterial_105(double value);

	public delegate void SwigDelegateOdDbMaterial_106(IntPtr normalMap, OdGiMaterialTraits_NormalMapMethod method, double strength);

	public delegate void SwigDelegateOdDbMaterial_107(IntPtr normalMap, int method, double strength);

	public delegate bool SwigDelegateOdDbMaterial_108();

	public delegate void SwigDelegateOdDbMaterial_109(bool flag);

	public delegate int SwigDelegateOdDbMaterial_110();

	public delegate void SwigDelegateOdDbMaterial_111(int mode);

	public delegate int SwigDelegateOdDbMaterial_112();

	public delegate void SwigDelegateOdDbMaterial_113(int mode);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbMaterial_0 swigDelegate0;

	private SwigDelegateOdDbMaterial_1 swigDelegate1;

	private SwigDelegateOdDbMaterial_2 swigDelegate2;

	private SwigDelegateOdDbMaterial_3 swigDelegate3;

	private SwigDelegateOdDbMaterial_4 swigDelegate4;

	private SwigDelegateOdDbMaterial_5 swigDelegate5;

	private SwigDelegateOdDbMaterial_6 swigDelegate6;

	private SwigDelegateOdDbMaterial_7 swigDelegate7;

	private SwigDelegateOdDbMaterial_8 swigDelegate8;

	private SwigDelegateOdDbMaterial_9 swigDelegate9;

	private SwigDelegateOdDbMaterial_10 swigDelegate10;

	private SwigDelegateOdDbMaterial_11 swigDelegate11;

	private SwigDelegateOdDbMaterial_12 swigDelegate12;

	private SwigDelegateOdDbMaterial_13 swigDelegate13;

	private SwigDelegateOdDbMaterial_14 swigDelegate14;

	private SwigDelegateOdDbMaterial_15 swigDelegate15;

	private SwigDelegateOdDbMaterial_16 swigDelegate16;

	private SwigDelegateOdDbMaterial_17 swigDelegate17;

	private SwigDelegateOdDbMaterial_18 swigDelegate18;

	private SwigDelegateOdDbMaterial_19 swigDelegate19;

	private SwigDelegateOdDbMaterial_20 swigDelegate20;

	private SwigDelegateOdDbMaterial_21 swigDelegate21;

	private SwigDelegateOdDbMaterial_22 swigDelegate22;

	private SwigDelegateOdDbMaterial_23 swigDelegate23;

	private SwigDelegateOdDbMaterial_24 swigDelegate24;

	private SwigDelegateOdDbMaterial_25 swigDelegate25;

	private SwigDelegateOdDbMaterial_26 swigDelegate26;

	private SwigDelegateOdDbMaterial_27 swigDelegate27;

	private SwigDelegateOdDbMaterial_28 swigDelegate28;

	private SwigDelegateOdDbMaterial_29 swigDelegate29;

	private SwigDelegateOdDbMaterial_30 swigDelegate30;

	private SwigDelegateOdDbMaterial_31 swigDelegate31;

	private SwigDelegateOdDbMaterial_32 swigDelegate32;

	private SwigDelegateOdDbMaterial_33 swigDelegate33;

	private SwigDelegateOdDbMaterial_34 swigDelegate34;

	private SwigDelegateOdDbMaterial_35 swigDelegate35;

	private SwigDelegateOdDbMaterial_36 swigDelegate36;

	private SwigDelegateOdDbMaterial_37 swigDelegate37;

	private SwigDelegateOdDbMaterial_38 swigDelegate38;

	private SwigDelegateOdDbMaterial_39 swigDelegate39;

	private SwigDelegateOdDbMaterial_40 swigDelegate40;

	private SwigDelegateOdDbMaterial_41 swigDelegate41;

	private SwigDelegateOdDbMaterial_42 swigDelegate42;

	private SwigDelegateOdDbMaterial_43 swigDelegate43;

	private SwigDelegateOdDbMaterial_44 swigDelegate44;

	private SwigDelegateOdDbMaterial_45 swigDelegate45;

	private SwigDelegateOdDbMaterial_46 swigDelegate46;

	private SwigDelegateOdDbMaterial_47 swigDelegate47;

	private SwigDelegateOdDbMaterial_48 swigDelegate48;

	private SwigDelegateOdDbMaterial_49 swigDelegate49;

	private SwigDelegateOdDbMaterial_50 swigDelegate50;

	private SwigDelegateOdDbMaterial_51 swigDelegate51;

	private SwigDelegateOdDbMaterial_52 swigDelegate52;

	private SwigDelegateOdDbMaterial_53 swigDelegate53;

	private SwigDelegateOdDbMaterial_54 swigDelegate54;

	private SwigDelegateOdDbMaterial_55 swigDelegate55;

	private SwigDelegateOdDbMaterial_56 swigDelegate56;

	private SwigDelegateOdDbMaterial_57 swigDelegate57;

	private SwigDelegateOdDbMaterial_58 swigDelegate58;

	private SwigDelegateOdDbMaterial_59 swigDelegate59;

	private SwigDelegateOdDbMaterial_60 swigDelegate60;

	private SwigDelegateOdDbMaterial_61 swigDelegate61;

	private SwigDelegateOdDbMaterial_62 swigDelegate62;

	private SwigDelegateOdDbMaterial_63 swigDelegate63;

	private SwigDelegateOdDbMaterial_64 swigDelegate64;

	private SwigDelegateOdDbMaterial_65 swigDelegate65;

	private SwigDelegateOdDbMaterial_66 swigDelegate66;

	private SwigDelegateOdDbMaterial_67 swigDelegate67;

	private SwigDelegateOdDbMaterial_68 swigDelegate68;

	private SwigDelegateOdDbMaterial_69 swigDelegate69;

	private SwigDelegateOdDbMaterial_70 swigDelegate70;

	private SwigDelegateOdDbMaterial_71 swigDelegate71;

	private SwigDelegateOdDbMaterial_72 swigDelegate72;

	private SwigDelegateOdDbMaterial_73 swigDelegate73;

	private SwigDelegateOdDbMaterial_74 swigDelegate74;

	private SwigDelegateOdDbMaterial_75 swigDelegate75;

	private SwigDelegateOdDbMaterial_76 swigDelegate76;

	private SwigDelegateOdDbMaterial_77 swigDelegate77;

	private SwigDelegateOdDbMaterial_78 swigDelegate78;

	private SwigDelegateOdDbMaterial_79 swigDelegate79;

	private SwigDelegateOdDbMaterial_80 swigDelegate80;

	private SwigDelegateOdDbMaterial_81 swigDelegate81;

	private SwigDelegateOdDbMaterial_82 swigDelegate82;

	private SwigDelegateOdDbMaterial_83 swigDelegate83;

	private SwigDelegateOdDbMaterial_84 swigDelegate84;

	private SwigDelegateOdDbMaterial_85 swigDelegate85;

	private SwigDelegateOdDbMaterial_86 swigDelegate86;

	private SwigDelegateOdDbMaterial_87 swigDelegate87;

	private SwigDelegateOdDbMaterial_88 swigDelegate88;

	private SwigDelegateOdDbMaterial_89 swigDelegate89;

	private SwigDelegateOdDbMaterial_90 swigDelegate90;

	private SwigDelegateOdDbMaterial_91 swigDelegate91;

	private SwigDelegateOdDbMaterial_92 swigDelegate92;

	private SwigDelegateOdDbMaterial_93 swigDelegate93;

	private SwigDelegateOdDbMaterial_94 swigDelegate94;

	private SwigDelegateOdDbMaterial_95 swigDelegate95;

	private SwigDelegateOdDbMaterial_96 swigDelegate96;

	private SwigDelegateOdDbMaterial_97 swigDelegate97;

	private SwigDelegateOdDbMaterial_98 swigDelegate98;

	private SwigDelegateOdDbMaterial_99 swigDelegate99;

	private SwigDelegateOdDbMaterial_100 swigDelegate100;

	private SwigDelegateOdDbMaterial_101 swigDelegate101;

	private SwigDelegateOdDbMaterial_102 swigDelegate102;

	private SwigDelegateOdDbMaterial_103 swigDelegate103;

	private SwigDelegateOdDbMaterial_104 swigDelegate104;

	private SwigDelegateOdDbMaterial_105 swigDelegate105;

	private SwigDelegateOdDbMaterial_106 swigDelegate106;

	private SwigDelegateOdDbMaterial_107 swigDelegate107;

	private SwigDelegateOdDbMaterial_108 swigDelegate108;

	private SwigDelegateOdDbMaterial_109 swigDelegate109;

	private SwigDelegateOdDbMaterial_110 swigDelegate110;

	private SwigDelegateOdDbMaterial_111 swigDelegate111;

	private SwigDelegateOdDbMaterial_112 swigDelegate112;

	private SwigDelegateOdDbMaterial_113 swigDelegate113;

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

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes61 = new Type[0];

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes63 = new Type[0];

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(OdGiMaterialColor) };

	private static Type[] swigMethodTypes65 = new Type[1] { typeof(OdGiMaterialColor) };

	private static Type[] swigMethodTypes66 = new Type[2]
	{
		typeof(OdGiMaterialColor),
		typeof(OdGiMaterialMap)
	};

	private static Type[] swigMethodTypes67 = new Type[2]
	{
		typeof(OdGiMaterialColor),
		typeof(OdGiMaterialMap)
	};

	private static Type[] swigMethodTypes68 = new Type[3]
	{
		typeof(OdGiMaterialColor),
		typeof(OdGiMaterialMap),
		typeof(double)
	};

	private static Type[] swigMethodTypes69 = new Type[3]
	{
		typeof(OdGiMaterialColor),
		typeof(OdGiMaterialMap),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes70 = new Type[1] { typeof(OdGiMaterialMap) };

	private static Type[] swigMethodTypes71 = new Type[1] { typeof(OdGiMaterialMap) };

	private static Type[] swigMethodTypes72 = new Type[2]
	{
		typeof(double),
		typeof(OdGiMaterialMap)
	};

	private static Type[] swigMethodTypes73 = new Type[2]
	{
		typeof(double).MakeByRefType(),
		typeof(OdGiMaterialMap)
	};

	private static Type[] swigMethodTypes74 = new Type[1] { typeof(OdGiMaterialMap) };

	private static Type[] swigMethodTypes75 = new Type[1] { typeof(OdGiMaterialMap) };

	private static Type[] swigMethodTypes76 = new Type[2]
	{
		typeof(double),
		typeof(OdGiMaterialMap)
	};

	private static Type[] swigMethodTypes77 = new Type[2]
	{
		typeof(double).MakeByRefType(),
		typeof(OdGiMaterialMap)
	};

	private static Type[] swigMethodTypes78 = new Type[0];

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes80 = new Type[0];

	private static Type[] swigMethodTypes81 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes82 = new Type[0];

	private static Type[] swigMethodTypes83 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes84 = new Type[0];

	private static Type[] swigMethodTypes85 = new Type[1] { typeof(OdGiMaterialTraits_Mode) };

	private static Type[] swigMethodTypes86 = new Type[0];

	private static Type[] swigMethodTypes87 = new Type[1] { typeof(OdGiMaterialTraits_ChannelFlags) };

	private static Type[] swigMethodTypes88 = new Type[0];

	private static Type[] swigMethodTypes89 = new Type[1] { typeof(OdGiMaterialTraits_IlluminationModel) };

	private static Type[] swigMethodTypes90 = new Type[0];

	private static Type[] swigMethodTypes91 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes92 = new Type[0];

	private static Type[] swigMethodTypes93 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes94 = new Type[0];

	private static Type[] swigMethodTypes95 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes96 = new Type[0];

	private static Type[] swigMethodTypes97 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes98 = new Type[0];

	private static Type[] swigMethodTypes99 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes100 = new Type[0];

	private static Type[] swigMethodTypes101 = new Type[1] { typeof(OdGiMaterialTraits_LuminanceMode) };

	private static Type[] swigMethodTypes102 = new Type[0];

	private static Type[] swigMethodTypes103 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes104 = new Type[0];

	private static Type[] swigMethodTypes105 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes106 = new Type[3]
	{
		typeof(OdGiMaterialMap),
		typeof(OdGiMaterialTraits_NormalMapMethod).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes107 = new Type[3]
	{
		typeof(OdGiMaterialMap),
		typeof(OdGiMaterialTraits_NormalMapMethod),
		typeof(double)
	};

	private static Type[] swigMethodTypes108 = new Type[0];

	private static Type[] swigMethodTypes109 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes110 = new Type[0];

	private static Type[] swigMethodTypes111 = new Type[1] { typeof(OdGiMaterialTraits_GlobalIlluminationMode) };

	private static Type[] swigMethodTypes112 = new Type[0];

	private static Type[] swigMethodTypes113 = new Type[1] { typeof(OdGiMaterialTraits_FinalGatherMode) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbMaterial(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbMaterial obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbMaterial(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbMaterial cast(OdRxObject pObj)
	{
		OdDbMaterial rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbMaterial>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_isASwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_queryXSwigExplicitOdDbMaterial(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult setName(string name)
	{
		int result = (SwigDerivedClassHasMethod("setName", swigMethodTypes60) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setNameSwigExplicitOdDbMaterial(swigCPtr, name) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setName(swigCPtr, name));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual string name()
	{
		string result = (SwigDerivedClassHasMethod("name", swigMethodTypes61) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_nameSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_name(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDescription(string description)
	{
		if (SwigDerivedClassHasMethod("setDescription", swigMethodTypes62))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setDescriptionSwigExplicitOdDbMaterial(swigCPtr, description);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setDescription(swigCPtr, description);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string description()
	{
		string result = (SwigDerivedClassHasMethod("description", swigMethodTypes63) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_descriptionSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_description(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAmbient(OdGiMaterialColor ambientColor)
	{
		if (SwigDerivedClassHasMethod("setAmbient", swigMethodTypes64))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setAmbientSwigExplicitOdDbMaterial(swigCPtr, OdGiMaterialColor.getCPtr(ambientColor));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setAmbient(swigCPtr, OdGiMaterialColor.getCPtr(ambientColor));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void ambient(OdGiMaterialColor ambientColor)
	{
		if (SwigDerivedClassHasMethod("ambient", swigMethodTypes65))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_ambientSwigExplicitOdDbMaterial(swigCPtr, OdGiMaterialColor.getCPtr(ambientColor));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_ambient(swigCPtr, OdGiMaterialColor.getCPtr(ambientColor));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDiffuse(OdGiMaterialColor diffuseColor, OdGiMaterialMap diffuseMap)
	{
		if (SwigDerivedClassHasMethod("setDiffuse", swigMethodTypes66))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setDiffuseSwigExplicitOdDbMaterial(swigCPtr, OdGiMaterialColor.getCPtr(diffuseColor), OdGiMaterialMap.getCPtr(diffuseMap));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setDiffuse(swigCPtr, OdGiMaterialColor.getCPtr(diffuseColor), OdGiMaterialMap.getCPtr(diffuseMap));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void diffuse(OdGiMaterialColor diffuseColor, OdGiMaterialMap diffuseMap)
	{
		if (SwigDerivedClassHasMethod("diffuse", swigMethodTypes67))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_diffuseSwigExplicitOdDbMaterial(swigCPtr, OdGiMaterialColor.getCPtr(diffuseColor), OdGiMaterialMap.getCPtr(diffuseMap));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_diffuse(swigCPtr, OdGiMaterialColor.getCPtr(diffuseColor), OdGiMaterialMap.getCPtr(diffuseMap));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSpecular(OdGiMaterialColor specularColor, OdGiMaterialMap specularMap, double glossFactor)
	{
		if (SwigDerivedClassHasMethod("setSpecular", swigMethodTypes68))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setSpecularSwigExplicitOdDbMaterial(swigCPtr, OdGiMaterialColor.getCPtr(specularColor), OdGiMaterialMap.getCPtr(specularMap), glossFactor);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setSpecular(swigCPtr, OdGiMaterialColor.getCPtr(specularColor), OdGiMaterialMap.getCPtr(specularMap), glossFactor);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void specular(OdGiMaterialColor specularColor, OdGiMaterialMap specularMap, out double glossFactor)
	{
		if (SwigDerivedClassHasMethod("specular", swigMethodTypes69))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_specularSwigExplicitOdDbMaterial(swigCPtr, OdGiMaterialColor.getCPtr(specularColor), OdGiMaterialMap.getCPtr(specularMap), out glossFactor);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_specular(swigCPtr, OdGiMaterialColor.getCPtr(specularColor), OdGiMaterialMap.getCPtr(specularMap), out glossFactor);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setReflection(OdGiMaterialMap reflectionMap)
	{
		if (SwigDerivedClassHasMethod("setReflection", swigMethodTypes70))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setReflectionSwigExplicitOdDbMaterial(swigCPtr, OdGiMaterialMap.getCPtr(reflectionMap));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setReflection(swigCPtr, OdGiMaterialMap.getCPtr(reflectionMap));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void reflection(OdGiMaterialMap reflectionMap)
	{
		if (SwigDerivedClassHasMethod("reflection", swigMethodTypes71))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_reflectionSwigExplicitOdDbMaterial(swigCPtr, OdGiMaterialMap.getCPtr(reflectionMap));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_reflection(swigCPtr, OdGiMaterialMap.getCPtr(reflectionMap));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setOpacity(double opacityPercentage, OdGiMaterialMap opacityMap)
	{
		if (SwigDerivedClassHasMethod("setOpacity", swigMethodTypes72))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setOpacitySwigExplicitOdDbMaterial(swigCPtr, opacityPercentage, OdGiMaterialMap.getCPtr(opacityMap));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setOpacity(swigCPtr, opacityPercentage, OdGiMaterialMap.getCPtr(opacityMap));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void opacity(out double opacityPercentage, OdGiMaterialMap opacityMap)
	{
		if (SwigDerivedClassHasMethod("opacity", swigMethodTypes73))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_opacitySwigExplicitOdDbMaterial(swigCPtr, out opacityPercentage, OdGiMaterialMap.getCPtr(opacityMap));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_opacity(swigCPtr, out opacityPercentage, OdGiMaterialMap.getCPtr(opacityMap));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBump(OdGiMaterialMap bumpMap)
	{
		if (SwigDerivedClassHasMethod("setBump", swigMethodTypes74))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setBumpSwigExplicitOdDbMaterial(swigCPtr, OdGiMaterialMap.getCPtr(bumpMap));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setBump(swigCPtr, OdGiMaterialMap.getCPtr(bumpMap));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void bump(OdGiMaterialMap map)
	{
		if (SwigDerivedClassHasMethod("bump", swigMethodTypes75))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_bumpSwigExplicitOdDbMaterial(swigCPtr, OdGiMaterialMap.getCPtr(map));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_bump(swigCPtr, OdGiMaterialMap.getCPtr(map));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRefraction(double refractionIndex, OdGiMaterialMap refractionMap)
	{
		if (SwigDerivedClassHasMethod("setRefraction", swigMethodTypes76))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setRefractionSwigExplicitOdDbMaterial(swigCPtr, refractionIndex, OdGiMaterialMap.getCPtr(refractionMap));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setRefraction(swigCPtr, refractionIndex, OdGiMaterialMap.getCPtr(refractionMap));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void refraction(out double refractionIndex, OdGiMaterialMap refractionMap)
	{
		if (SwigDerivedClassHasMethod("refraction", swigMethodTypes77))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_refractionSwigExplicitOdDbMaterial(swigCPtr, out refractionIndex, OdGiMaterialMap.getCPtr(refractionMap));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_refraction(swigCPtr, out refractionIndex, OdGiMaterialMap.getCPtr(refractionMap));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_dwgInFieldsSwigExplicitOdDbMaterial(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_dwgOutFieldsSwigExplicitOdDbMaterial(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_dxfInFieldsSwigExplicitOdDbMaterial(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_dxfOutFieldsSwigExplicitOdDbMaterial(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGiDrawable drawable()
	{
		OdGiDrawable rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiDrawable>(SwigDerivedClassHasMethod("drawable", swigMethodTypes55) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_drawableSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_drawable(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual double translucence()
	{
		double result = (SwigDerivedClassHasMethod("translucence", swigMethodTypes78) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_translucenceSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_translucence(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTranslucence(double translucence)
	{
		if (SwigDerivedClassHasMethod("setTranslucence", swigMethodTypes79))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setTranslucenceSwigExplicitOdDbMaterial(swigCPtr, translucence);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setTranslucence(swigCPtr, translucence);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double selfIllumination()
	{
		double result = (SwigDerivedClassHasMethod("selfIllumination", swigMethodTypes80) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_selfIlluminationSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_selfIllumination(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSelfIllumination(double selfIllumination)
	{
		if (SwigDerivedClassHasMethod("setSelfIllumination", swigMethodTypes81))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setSelfIlluminationSwigExplicitOdDbMaterial(swigCPtr, selfIllumination);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setSelfIllumination(swigCPtr, selfIllumination);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double reflectivity()
	{
		double result = (SwigDerivedClassHasMethod("reflectivity", swigMethodTypes82) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_reflectivitySwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_reflectivity(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setReflectivity(double reflectivity)
	{
		if (SwigDerivedClassHasMethod("setReflectivity", swigMethodTypes83))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setReflectivitySwigExplicitOdDbMaterial(swigCPtr, reflectivity);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setReflectivity(swigCPtr, reflectivity);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTraits_Mode mode()
	{
		int result = (SwigDerivedClassHasMethod("mode", swigMethodTypes84) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_modeSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_mode(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_Mode)result;
	}

	public virtual void setMode(OdGiMaterialTraits_Mode mode)
	{
		if (SwigDerivedClassHasMethod("setMode", swigMethodTypes85))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setModeSwigExplicitOdDbMaterial(swigCPtr, (int)mode);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setMode(swigCPtr, (int)mode);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTraits_ChannelFlags channelFlags()
	{
		int result = (SwigDerivedClassHasMethod("channelFlags", swigMethodTypes86) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_channelFlagsSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_channelFlags(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_ChannelFlags)result;
	}

	public virtual void setChannelFlags(OdGiMaterialTraits_ChannelFlags channelFlags)
	{
		if (SwigDerivedClassHasMethod("setChannelFlags", swigMethodTypes87))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setChannelFlagsSwigExplicitOdDbMaterial(swigCPtr, (int)channelFlags);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setChannelFlags(swigCPtr, (int)channelFlags);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTraits_IlluminationModel illuminationModel()
	{
		int result = (SwigDerivedClassHasMethod("illuminationModel", swigMethodTypes88) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_illuminationModelSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_illuminationModel(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_IlluminationModel)result;
	}

	public virtual void setIlluminationModel(OdGiMaterialTraits_IlluminationModel illuminationMode)
	{
		if (SwigDerivedClassHasMethod("setIlluminationModel", swigMethodTypes89))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setIlluminationModelSwigExplicitOdDbMaterial(swigCPtr, (int)illuminationMode);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setIlluminationModel(swigCPtr, (int)illuminationMode);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double colorBleedScale()
	{
		double result = (SwigDerivedClassHasMethod("colorBleedScale", swigMethodTypes90) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_colorBleedScaleSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_colorBleedScale(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColorBleedScale(double scale)
	{
		if (SwigDerivedClassHasMethod("setColorBleedScale", swigMethodTypes91))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setColorBleedScaleSwigExplicitOdDbMaterial(swigCPtr, scale);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setColorBleedScale(swigCPtr, scale);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double indirectBumpScale()
	{
		double result = (SwigDerivedClassHasMethod("indirectBumpScale", swigMethodTypes92) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_indirectBumpScaleSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_indirectBumpScale(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setIndirectBumpScale(double scale)
	{
		if (SwigDerivedClassHasMethod("setIndirectBumpScale", swigMethodTypes93))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setIndirectBumpScaleSwigExplicitOdDbMaterial(swigCPtr, scale);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setIndirectBumpScale(swigCPtr, scale);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double reflectanceScale()
	{
		double result = (SwigDerivedClassHasMethod("reflectanceScale", swigMethodTypes94) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_reflectanceScaleSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_reflectanceScale(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setReflectanceScale(double scale)
	{
		if (SwigDerivedClassHasMethod("setReflectanceScale", swigMethodTypes95))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setReflectanceScaleSwigExplicitOdDbMaterial(swigCPtr, scale);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setReflectanceScale(swigCPtr, scale);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double transmittanceScale()
	{
		double result = (SwigDerivedClassHasMethod("transmittanceScale", swigMethodTypes96) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_transmittanceScaleSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_transmittanceScale(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTransmittanceScale(double scale)
	{
		if (SwigDerivedClassHasMethod("setTransmittanceScale", swigMethodTypes97))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setTransmittanceScaleSwigExplicitOdDbMaterial(swigCPtr, scale);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setTransmittanceScale(swigCPtr, scale);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool twoSided()
	{
		bool result = (SwigDerivedClassHasMethod("twoSided", swigMethodTypes98) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_twoSidedSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_twoSided(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTwoSided(bool flag)
	{
		if (SwigDerivedClassHasMethod("setTwoSided", swigMethodTypes99))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setTwoSidedSwigExplicitOdDbMaterial(swigCPtr, flag);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setTwoSided(swigCPtr, flag);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTraits_LuminanceMode luminanceMode()
	{
		int result = (SwigDerivedClassHasMethod("luminanceMode", swigMethodTypes100) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_luminanceModeSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_luminanceMode(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_LuminanceMode)result;
	}

	public virtual void setLuminanceMode(OdGiMaterialTraits_LuminanceMode mode)
	{
		if (SwigDerivedClassHasMethod("setLuminanceMode", swigMethodTypes101))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setLuminanceModeSwigExplicitOdDbMaterial(swigCPtr, (int)mode);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setLuminanceMode(swigCPtr, (int)mode);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double luminance()
	{
		double result = (SwigDerivedClassHasMethod("luminance", swigMethodTypes102) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_luminanceSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_luminance(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLuminance(double value)
	{
		if (SwigDerivedClassHasMethod("setLuminance", swigMethodTypes103))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setLuminanceSwigExplicitOdDbMaterial(swigCPtr, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setLuminance(swigCPtr, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double shininess()
	{
		double result = (SwigDerivedClassHasMethod("shininess", swigMethodTypes104) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_shininessSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_shininess(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setShininess(double value)
	{
		if (SwigDerivedClassHasMethod("setShininess", swigMethodTypes105))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setShininessSwigExplicitOdDbMaterial(swigCPtr, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setShininess(swigCPtr, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void NormalMap(OdGiMaterialMap normalMap, out OdGiMaterialTraits_NormalMapMethod method, out double strength)
	{
		if (SwigDerivedClassHasMethod("NormalMap", swigMethodTypes106))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_NormalMapSwigExplicitOdDbMaterial(swigCPtr, OdGiMaterialMap.getCPtr(normalMap), out method, out strength);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_NormalMap(swigCPtr, OdGiMaterialMap.getCPtr(normalMap), out method, out strength);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setNormalMap(OdGiMaterialMap normalMap, OdGiMaterialTraits_NormalMapMethod method, double strength)
	{
		if (SwigDerivedClassHasMethod("setNormalMap", swigMethodTypes107))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setNormalMapSwigExplicitOdDbMaterial(swigCPtr, OdGiMaterialMap.getCPtr(normalMap), (int)method, strength);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setNormalMap(swigCPtr, OdGiMaterialMap.getCPtr(normalMap), (int)method, strength);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isAnonymous()
	{
		bool result = (SwigDerivedClassHasMethod("isAnonymous", swigMethodTypes108) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_isAnonymousSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_isAnonymous(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAnonymous(bool flag)
	{
		if (SwigDerivedClassHasMethod("setAnonymous", swigMethodTypes109))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setAnonymousSwigExplicitOdDbMaterial(swigCPtr, flag);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setAnonymous(swigCPtr, flag);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTraits_GlobalIlluminationMode globalIllumination()
	{
		int result = (SwigDerivedClassHasMethod("globalIllumination", swigMethodTypes110) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_globalIlluminationSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_globalIllumination(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_GlobalIlluminationMode)result;
	}

	public virtual void setGlobalIllumination(OdGiMaterialTraits_GlobalIlluminationMode mode)
	{
		if (SwigDerivedClassHasMethod("setGlobalIllumination", swigMethodTypes111))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setGlobalIlluminationSwigExplicitOdDbMaterial(swigCPtr, (int)mode);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setGlobalIllumination(swigCPtr, (int)mode);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTraits_FinalGatherMode finalGather()
	{
		int result = (SwigDerivedClassHasMethod("finalGather", swigMethodTypes112) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_finalGatherSwigExplicitOdDbMaterial(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_finalGather(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTraits_FinalGatherMode)result;
	}

	public virtual void setFinalGather(OdGiMaterialTraits_FinalGatherMode mode)
	{
		if (SwigDerivedClassHasMethod("setFinalGather", swigMethodTypes113))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setFinalGatherSwigExplicitOdDbMaterial(swigCPtr, (int)mode);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_setFinalGather(swigCPtr, (int)mode);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult subErase(bool erasing)
	{
		int result = (SwigDerivedClassHasMethod("subErase", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_subEraseSwigExplicitOdDbMaterial(swigCPtr, erasing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_subErase(swigCPtr, erasing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getFbx(ref OdMaterialFBXAssetXData pAssetXData)
	{
		IntPtr jarg = ((pAssetXData == null) ? IntPtr.Zero : OdMaterialFBXAssetXData.getCPtr(pAssetXData).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_getFbx(swigCPtr, ref jarg);
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
				pAssetXData = null;
			}
			else if (jarg != intPtr)
			{
				pAssetXData = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdMaterialFBXAssetXData>(jarg, bOwn: true, bTryAddToTransaction: false);
			}
		}
	}

	public override uint SubSetAttributes(OdGiDrawableTraits pTraits)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_SubSetAttributes(swigCPtr, OdGiDrawableTraits.getCPtr(pTraits));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult SubGetClassID(IntPtr pClsid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_SubGetClassID(swigCPtr, pClsid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbMaterial createObject()
	{
		OdDbMaterial rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbMaterial>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("setName", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodsetName;
		}
		if (SwigDerivedClassHasMethod("name", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodname;
		}
		if (SwigDerivedClassHasMethod("setDescription", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodsetDescription;
		}
		if (SwigDerivedClassHasMethod("description", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethoddescription;
		}
		if (SwigDerivedClassHasMethod("setAmbient", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodsetAmbient;
		}
		if (SwigDerivedClassHasMethod("ambient", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodambient;
		}
		if (SwigDerivedClassHasMethod("setDiffuse", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodsetDiffuse;
		}
		if (SwigDerivedClassHasMethod("diffuse", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethoddiffuse;
		}
		if (SwigDerivedClassHasMethod("setSpecular", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodsetSpecular;
		}
		if (SwigDerivedClassHasMethod("specular", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodspecular;
		}
		if (SwigDerivedClassHasMethod("setReflection", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodsetReflection;
		}
		if (SwigDerivedClassHasMethod("reflection", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodreflection;
		}
		if (SwigDerivedClassHasMethod("setOpacity", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodsetOpacity;
		}
		if (SwigDerivedClassHasMethod("opacity", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodopacity;
		}
		if (SwigDerivedClassHasMethod("setBump", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodsetBump;
		}
		if (SwigDerivedClassHasMethod("bump", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodbump;
		}
		if (SwigDerivedClassHasMethod("setRefraction", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodsetRefraction;
		}
		if (SwigDerivedClassHasMethod("refraction", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodrefraction;
		}
		if (SwigDerivedClassHasMethod("translucence", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodtranslucence;
		}
		if (SwigDerivedClassHasMethod("setTranslucence", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodsetTranslucence;
		}
		if (SwigDerivedClassHasMethod("selfIllumination", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodselfIllumination;
		}
		if (SwigDerivedClassHasMethod("setSelfIllumination", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodsetSelfIllumination;
		}
		if (SwigDerivedClassHasMethod("reflectivity", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodreflectivity;
		}
		if (SwigDerivedClassHasMethod("setReflectivity", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodsetReflectivity;
		}
		if (SwigDerivedClassHasMethod("mode", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodmode;
		}
		if (SwigDerivedClassHasMethod("setMode", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodsetMode;
		}
		if (SwigDerivedClassHasMethod("channelFlags", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodchannelFlags;
		}
		if (SwigDerivedClassHasMethod("setChannelFlags", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodsetChannelFlags;
		}
		if (SwigDerivedClassHasMethod("illuminationModel", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodilluminationModel;
		}
		if (SwigDerivedClassHasMethod("setIlluminationModel", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodsetIlluminationModel;
		}
		if (SwigDerivedClassHasMethod("colorBleedScale", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodcolorBleedScale;
		}
		if (SwigDerivedClassHasMethod("setColorBleedScale", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodsetColorBleedScale;
		}
		if (SwigDerivedClassHasMethod("indirectBumpScale", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodindirectBumpScale;
		}
		if (SwigDerivedClassHasMethod("setIndirectBumpScale", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodsetIndirectBumpScale;
		}
		if (SwigDerivedClassHasMethod("reflectanceScale", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodreflectanceScale;
		}
		if (SwigDerivedClassHasMethod("setReflectanceScale", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodsetReflectanceScale;
		}
		if (SwigDerivedClassHasMethod("transmittanceScale", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodtransmittanceScale;
		}
		if (SwigDerivedClassHasMethod("setTransmittanceScale", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodsetTransmittanceScale;
		}
		if (SwigDerivedClassHasMethod("twoSided", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodtwoSided;
		}
		if (SwigDerivedClassHasMethod("setTwoSided", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethodsetTwoSided;
		}
		if (SwigDerivedClassHasMethod("luminanceMode", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodluminanceMode;
		}
		if (SwigDerivedClassHasMethod("setLuminanceMode", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodsetLuminanceMode;
		}
		if (SwigDerivedClassHasMethod("luminance", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethodluminance;
		}
		if (SwigDerivedClassHasMethod("setLuminance", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethodsetLuminance;
		}
		if (SwigDerivedClassHasMethod("shininess", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethodshininess;
		}
		if (SwigDerivedClassHasMethod("setShininess", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodsetShininess;
		}
		if (SwigDerivedClassHasMethod("NormalMap", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethodNormalMap;
		}
		if (SwigDerivedClassHasMethod("setNormalMap", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodsetNormalMap;
		}
		if (SwigDerivedClassHasMethod("isAnonymous", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethodisAnonymous;
		}
		if (SwigDerivedClassHasMethod("setAnonymous", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodsetAnonymous;
		}
		if (SwigDerivedClassHasMethod("globalIllumination", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodglobalIllumination;
		}
		if (SwigDerivedClassHasMethod("setGlobalIllumination", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodsetGlobalIllumination;
		}
		if (SwigDerivedClassHasMethod("finalGather", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodfinalGather;
		}
		if (SwigDerivedClassHasMethod("setFinalGather", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethodsetFinalGather;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMaterial_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbMaterial));
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

	private int SwigDirectorMethodsetName([MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		return (int)setName(name);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodname()
	{
		return name();
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethoddescription()
	{
		return description();
	}

	private void SwigDirectorMethodsetAmbient(IntPtr ambientColor)
	{
		try
		{
			setAmbient(new OdGiMaterialColor(ambientColor, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodambient(IntPtr ambientColor)
	{
		try
		{
			ambient(new OdGiMaterialColor(ambientColor, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDiffuse(IntPtr diffuseColor, IntPtr diffuseMap)
	{
		try
		{
			setDiffuse(new OdGiMaterialColor(diffuseColor, cMemoryOwn: false), new OdGiMaterialMap(diffuseMap, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddiffuse(IntPtr diffuseColor, IntPtr diffuseMap)
	{
		try
		{
			diffuse(new OdGiMaterialColor(diffuseColor, cMemoryOwn: false), new OdGiMaterialMap(diffuseMap, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetSpecular(IntPtr specularColor, IntPtr specularMap, double glossFactor)
	{
		try
		{
			setSpecular(new OdGiMaterialColor(specularColor, cMemoryOwn: false), new OdGiMaterialMap(specularMap, cMemoryOwn: false), glossFactor);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodspecular(IntPtr specularColor, IntPtr specularMap, double glossFactor)
	{
		try
		{
			specular(new OdGiMaterialColor(specularColor, cMemoryOwn: false), new OdGiMaterialMap(specularMap, cMemoryOwn: false), out glossFactor);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetReflection(IntPtr reflectionMap)
	{
		try
		{
			setReflection(new OdGiMaterialMap(reflectionMap, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodreflection(IntPtr reflectionMap)
	{
		try
		{
			reflection(new OdGiMaterialMap(reflectionMap, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetOpacity(double opacityPercentage, IntPtr opacityMap)
	{
		try
		{
			setOpacity(opacityPercentage, new OdGiMaterialMap(opacityMap, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodopacity(double opacityPercentage, IntPtr opacityMap)
	{
		try
		{
			opacity(out opacityPercentage, new OdGiMaterialMap(opacityMap, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetBump(IntPtr bumpMap)
	{
		try
		{
			setBump(new OdGiMaterialMap(bumpMap, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbump(IntPtr map)
	{
		try
		{
			bump(new OdGiMaterialMap(map, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetRefraction(double refractionIndex, IntPtr refractionMap)
	{
		try
		{
			setRefraction(refractionIndex, new OdGiMaterialMap(refractionMap, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodrefraction(double refractionIndex, IntPtr refractionMap)
	{
		try
		{
			refraction(out refractionIndex, new OdGiMaterialMap(refractionMap, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodtranslucence()
	{
		return translucence();
	}

	private void SwigDirectorMethodsetTranslucence(double translucence)
	{
		try
		{
			setTranslucence(translucence);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodselfIllumination()
	{
		return selfIllumination();
	}

	private void SwigDirectorMethodsetSelfIllumination(double selfIllumination)
	{
		try
		{
			setSelfIllumination(selfIllumination);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodreflectivity()
	{
		return reflectivity();
	}

	private void SwigDirectorMethodsetReflectivity(double reflectivity)
	{
		try
		{
			setReflectivity(reflectivity);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodmode()
	{
		return (int)mode();
	}

	private void SwigDirectorMethodsetMode(int mode)
	{
		try
		{
			setMode((OdGiMaterialTraits_Mode)mode);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodchannelFlags()
	{
		return (int)channelFlags();
	}

	private void SwigDirectorMethodsetChannelFlags(int channelFlags)
	{
		try
		{
			setChannelFlags((OdGiMaterialTraits_ChannelFlags)channelFlags);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodilluminationModel()
	{
		return (int)illuminationModel();
	}

	private void SwigDirectorMethodsetIlluminationModel(int illuminationMode)
	{
		try
		{
			setIlluminationModel((OdGiMaterialTraits_IlluminationModel)illuminationMode);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodcolorBleedScale()
	{
		return colorBleedScale();
	}

	private void SwigDirectorMethodsetColorBleedScale(double scale)
	{
		try
		{
			setColorBleedScale(scale);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodindirectBumpScale()
	{
		return indirectBumpScale();
	}

	private void SwigDirectorMethodsetIndirectBumpScale(double scale)
	{
		try
		{
			setIndirectBumpScale(scale);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodreflectanceScale()
	{
		return reflectanceScale();
	}

	private void SwigDirectorMethodsetReflectanceScale(double scale)
	{
		try
		{
			setReflectanceScale(scale);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodtransmittanceScale()
	{
		return transmittanceScale();
	}

	private void SwigDirectorMethodsetTransmittanceScale(double scale)
	{
		try
		{
			setTransmittanceScale(scale);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodtwoSided()
	{
		return twoSided();
	}

	private void SwigDirectorMethodsetTwoSided(bool flag)
	{
		try
		{
			setTwoSided(flag);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodluminanceMode()
	{
		return (int)luminanceMode();
	}

	private void SwigDirectorMethodsetLuminanceMode(int mode)
	{
		try
		{
			setLuminanceMode((OdGiMaterialTraits_LuminanceMode)mode);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodluminance()
	{
		return luminance();
	}

	private void SwigDirectorMethodsetLuminance(double value)
	{
		try
		{
			setLuminance(value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private double SwigDirectorMethodshininess()
	{
		return shininess();
	}

	private void SwigDirectorMethodsetShininess(double value)
	{
		try
		{
			setShininess(value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodNormalMap(IntPtr normalMap, OdGiMaterialTraits_NormalMapMethod method, double strength)
	{
		try
		{
			NormalMap(new OdGiMaterialMap(normalMap, cMemoryOwn: false), out method, out strength);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetNormalMap(IntPtr normalMap, int method, double strength)
	{
		try
		{
			setNormalMap(new OdGiMaterialMap(normalMap, cMemoryOwn: false), (OdGiMaterialTraits_NormalMapMethod)method, strength);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisAnonymous()
	{
		return isAnonymous();
	}

	private void SwigDirectorMethodsetAnonymous(bool flag)
	{
		try
		{
			setAnonymous(flag);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodglobalIllumination()
	{
		return (int)globalIllumination();
	}

	private void SwigDirectorMethodsetGlobalIllumination(int mode)
	{
		try
		{
			setGlobalIllumination((OdGiMaterialTraits_GlobalIlluminationMode)mode);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodfinalGather()
	{
		return (int)finalGather();
	}

	private void SwigDirectorMethodsetFinalGather(int mode)
	{
		try
		{
			setFinalGather((OdGiMaterialTraits_FinalGatherMode)mode);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDimensionObjectContextData : OdDbAnnotScaleObjectContextData
{
	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_1();

	public delegate void SwigDelegateOdDbDimensionObjectContextData_2(IntPtr arg0);

	public delegate int SwigDelegateOdDbDimensionObjectContextData_3();

	public delegate bool SwigDelegateOdDbDimensionObjectContextData_4();

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_5();

	public delegate void SwigDelegateOdDbDimensionObjectContextData_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_7();

	public delegate uint SwigDelegateOdDbDimensionObjectContextData_8(IntPtr vd);

	public delegate uint SwigDelegateOdDbDimensionObjectContextData_9();

	public delegate void SwigDelegateOdDbDimensionObjectContextData_10(IntPtr ownerId);

	public delegate int SwigDelegateOdDbDimensionObjectContextData_11(int mode);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_12();

	public delegate int SwigDelegateOdDbDimensionObjectContextData_13(bool erasing);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_14(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_15(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_16(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_17(IntPtr otherId);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_18(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbDimensionObjectContextData_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbDimensionObjectContextData_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbDimensionObjectContextData_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbDimensionObjectContextData_25(IntPtr pFiler);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_26(IntPtr pFiler);

	public delegate int SwigDelegateOdDbDimensionObjectContextData_27();

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_28([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_29(IntPtr pRb);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_30(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_31(IntPtr objId);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_32(IntPtr objId);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_33(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_34();

	public delegate void SwigDelegateOdDbDimensionObjectContextData_35(IntPtr idPair, IntPtr pOwnerObject, IntPtr idMap);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_36(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_37(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_40(IntPtr pObject);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_42(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_45(IntPtr pObject);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_47(IntPtr objectId);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_48(IntPtr pObject);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_49(IntPtr pSource);

	public delegate int SwigDelegateOdDbDimensionObjectContextData_50(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbDimensionObjectContextData_51(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_52(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_53(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_54(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_55();

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbDimensionObjectContextData_57(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_58([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_59(IntPtr pClass);

	public delegate int SwigDelegateOdDbDimensionObjectContextData_60(IntPtr pClsid);

	public delegate int SwigDelegateOdDbDimensionObjectContextData_61(IntPtr arg0);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_62(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_63();

	public delegate bool SwigDelegateOdDbDimensionObjectContextData_64(IntPtr arg0);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_65(IntPtr arg0);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_66();

	public delegate int SwigDelegateOdDbDimensionObjectContextData_67(double arg0);

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_68();

	public delegate void SwigDelegateOdDbDimensionObjectContextData_69(IntPtr arg0);

	public delegate bool SwigDelegateOdDbDimensionObjectContextData_70(int arg0);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_71(int arg0, bool arg1);

	public delegate short SwigDelegateOdDbDimensionObjectContextData_72();

	public delegate bool SwigDelegateOdDbDimensionObjectContextData_73();

	public delegate bool SwigDelegateOdDbDimensionObjectContextData_74();

	public delegate short SwigDelegateOdDbDimensionObjectContextData_75();

	public delegate bool SwigDelegateOdDbDimensionObjectContextData_76();

	public delegate void SwigDelegateOdDbDimensionObjectContextData_77(short arg0);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_78(bool arg0);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_79(bool arg0);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_80(short arg0);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_81(bool arg0);

	public delegate bool SwigDelegateOdDbDimensionObjectContextData_82();

	public delegate IntPtr SwigDelegateOdDbDimensionObjectContextData_83();

	public delegate double SwigDelegateOdDbDimensionObjectContextData_84();

	public delegate bool SwigDelegateOdDbDimensionObjectContextData_85();

	public delegate bool SwigDelegateOdDbDimensionObjectContextData_86();

	public delegate void SwigDelegateOdDbDimensionObjectContextData_87(bool arg0);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_88(IntPtr arg0);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_89(double arg0);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_90(bool arg0);

	public delegate void SwigDelegateOdDbDimensionObjectContextData_91(bool arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbDimensionObjectContextData_0 swigDelegate0;

	private SwigDelegateOdDbDimensionObjectContextData_1 swigDelegate1;

	private SwigDelegateOdDbDimensionObjectContextData_2 swigDelegate2;

	private SwigDelegateOdDbDimensionObjectContextData_3 swigDelegate3;

	private SwigDelegateOdDbDimensionObjectContextData_4 swigDelegate4;

	private SwigDelegateOdDbDimensionObjectContextData_5 swigDelegate5;

	private SwigDelegateOdDbDimensionObjectContextData_6 swigDelegate6;

	private SwigDelegateOdDbDimensionObjectContextData_7 swigDelegate7;

	private SwigDelegateOdDbDimensionObjectContextData_8 swigDelegate8;

	private SwigDelegateOdDbDimensionObjectContextData_9 swigDelegate9;

	private SwigDelegateOdDbDimensionObjectContextData_10 swigDelegate10;

	private SwigDelegateOdDbDimensionObjectContextData_11 swigDelegate11;

	private SwigDelegateOdDbDimensionObjectContextData_12 swigDelegate12;

	private SwigDelegateOdDbDimensionObjectContextData_13 swigDelegate13;

	private SwigDelegateOdDbDimensionObjectContextData_14 swigDelegate14;

	private SwigDelegateOdDbDimensionObjectContextData_15 swigDelegate15;

	private SwigDelegateOdDbDimensionObjectContextData_16 swigDelegate16;

	private SwigDelegateOdDbDimensionObjectContextData_17 swigDelegate17;

	private SwigDelegateOdDbDimensionObjectContextData_18 swigDelegate18;

	private SwigDelegateOdDbDimensionObjectContextData_19 swigDelegate19;

	private SwigDelegateOdDbDimensionObjectContextData_20 swigDelegate20;

	private SwigDelegateOdDbDimensionObjectContextData_21 swigDelegate21;

	private SwigDelegateOdDbDimensionObjectContextData_22 swigDelegate22;

	private SwigDelegateOdDbDimensionObjectContextData_23 swigDelegate23;

	private SwigDelegateOdDbDimensionObjectContextData_24 swigDelegate24;

	private SwigDelegateOdDbDimensionObjectContextData_25 swigDelegate25;

	private SwigDelegateOdDbDimensionObjectContextData_26 swigDelegate26;

	private SwigDelegateOdDbDimensionObjectContextData_27 swigDelegate27;

	private SwigDelegateOdDbDimensionObjectContextData_28 swigDelegate28;

	private SwigDelegateOdDbDimensionObjectContextData_29 swigDelegate29;

	private SwigDelegateOdDbDimensionObjectContextData_30 swigDelegate30;

	private SwigDelegateOdDbDimensionObjectContextData_31 swigDelegate31;

	private SwigDelegateOdDbDimensionObjectContextData_32 swigDelegate32;

	private SwigDelegateOdDbDimensionObjectContextData_33 swigDelegate33;

	private SwigDelegateOdDbDimensionObjectContextData_34 swigDelegate34;

	private SwigDelegateOdDbDimensionObjectContextData_35 swigDelegate35;

	private SwigDelegateOdDbDimensionObjectContextData_36 swigDelegate36;

	private SwigDelegateOdDbDimensionObjectContextData_37 swigDelegate37;

	private SwigDelegateOdDbDimensionObjectContextData_38 swigDelegate38;

	private SwigDelegateOdDbDimensionObjectContextData_39 swigDelegate39;

	private SwigDelegateOdDbDimensionObjectContextData_40 swigDelegate40;

	private SwigDelegateOdDbDimensionObjectContextData_41 swigDelegate41;

	private SwigDelegateOdDbDimensionObjectContextData_42 swigDelegate42;

	private SwigDelegateOdDbDimensionObjectContextData_43 swigDelegate43;

	private SwigDelegateOdDbDimensionObjectContextData_44 swigDelegate44;

	private SwigDelegateOdDbDimensionObjectContextData_45 swigDelegate45;

	private SwigDelegateOdDbDimensionObjectContextData_46 swigDelegate46;

	private SwigDelegateOdDbDimensionObjectContextData_47 swigDelegate47;

	private SwigDelegateOdDbDimensionObjectContextData_48 swigDelegate48;

	private SwigDelegateOdDbDimensionObjectContextData_49 swigDelegate49;

	private SwigDelegateOdDbDimensionObjectContextData_50 swigDelegate50;

	private SwigDelegateOdDbDimensionObjectContextData_51 swigDelegate51;

	private SwigDelegateOdDbDimensionObjectContextData_52 swigDelegate52;

	private SwigDelegateOdDbDimensionObjectContextData_53 swigDelegate53;

	private SwigDelegateOdDbDimensionObjectContextData_54 swigDelegate54;

	private SwigDelegateOdDbDimensionObjectContextData_55 swigDelegate55;

	private SwigDelegateOdDbDimensionObjectContextData_56 swigDelegate56;

	private SwigDelegateOdDbDimensionObjectContextData_57 swigDelegate57;

	private SwigDelegateOdDbDimensionObjectContextData_58 swigDelegate58;

	private SwigDelegateOdDbDimensionObjectContextData_59 swigDelegate59;

	private SwigDelegateOdDbDimensionObjectContextData_60 swigDelegate60;

	private SwigDelegateOdDbDimensionObjectContextData_61 swigDelegate61;

	private SwigDelegateOdDbDimensionObjectContextData_62 swigDelegate62;

	private SwigDelegateOdDbDimensionObjectContextData_63 swigDelegate63;

	private SwigDelegateOdDbDimensionObjectContextData_64 swigDelegate64;

	private SwigDelegateOdDbDimensionObjectContextData_65 swigDelegate65;

	private SwigDelegateOdDbDimensionObjectContextData_66 swigDelegate66;

	private SwigDelegateOdDbDimensionObjectContextData_67 swigDelegate67;

	private SwigDelegateOdDbDimensionObjectContextData_68 swigDelegate68;

	private SwigDelegateOdDbDimensionObjectContextData_69 swigDelegate69;

	private SwigDelegateOdDbDimensionObjectContextData_70 swigDelegate70;

	private SwigDelegateOdDbDimensionObjectContextData_71 swigDelegate71;

	private SwigDelegateOdDbDimensionObjectContextData_72 swigDelegate72;

	private SwigDelegateOdDbDimensionObjectContextData_73 swigDelegate73;

	private SwigDelegateOdDbDimensionObjectContextData_74 swigDelegate74;

	private SwigDelegateOdDbDimensionObjectContextData_75 swigDelegate75;

	private SwigDelegateOdDbDimensionObjectContextData_76 swigDelegate76;

	private SwigDelegateOdDbDimensionObjectContextData_77 swigDelegate77;

	private SwigDelegateOdDbDimensionObjectContextData_78 swigDelegate78;

	private SwigDelegateOdDbDimensionObjectContextData_79 swigDelegate79;

	private SwigDelegateOdDbDimensionObjectContextData_80 swigDelegate80;

	private SwigDelegateOdDbDimensionObjectContextData_81 swigDelegate81;

	private SwigDelegateOdDbDimensionObjectContextData_82 swigDelegate82;

	private SwigDelegateOdDbDimensionObjectContextData_83 swigDelegate83;

	private SwigDelegateOdDbDimensionObjectContextData_84 swigDelegate84;

	private SwigDelegateOdDbDimensionObjectContextData_85 swigDelegate85;

	private SwigDelegateOdDbDimensionObjectContextData_86 swigDelegate86;

	private SwigDelegateOdDbDimensionObjectContextData_87 swigDelegate87;

	private SwigDelegateOdDbDimensionObjectContextData_88 swigDelegate88;

	private SwigDelegateOdDbDimensionObjectContextData_89 swigDelegate89;

	private SwigDelegateOdDbDimensionObjectContextData_90 swigDelegate90;

	private SwigDelegateOdDbDimensionObjectContextData_91 swigDelegate91;

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

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes63 = new Type[0];

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(OdDbObjectContext) };

	private static Type[] swigMethodTypes65 = new Type[1] { typeof(OdDbObjectContext) };

	private static Type[] swigMethodTypes66 = new Type[0];

	private static Type[] swigMethodTypes67 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes68 = new Type[0];

	private static Type[] swigMethodTypes69 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes70 = new Type[1] { typeof(OdDbDimensionObjectContextData_OverrideCode) };

	private static Type[] swigMethodTypes71 = new Type[2]
	{
		typeof(OdDbDimensionObjectContextData_OverrideCode),
		typeof(bool)
	};

	private static Type[] swigMethodTypes72 = new Type[0];

	private static Type[] swigMethodTypes73 = new Type[0];

	private static Type[] swigMethodTypes74 = new Type[0];

	private static Type[] swigMethodTypes75 = new Type[0];

	private static Type[] swigMethodTypes76 = new Type[0];

	private static Type[] swigMethodTypes77 = new Type[1] { typeof(short) };

	private static Type[] swigMethodTypes78 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes80 = new Type[1] { typeof(short) };

	private static Type[] swigMethodTypes81 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes82 = new Type[0];

	private static Type[] swigMethodTypes83 = new Type[0];

	private static Type[] swigMethodTypes84 = new Type[0];

	private static Type[] swigMethodTypes85 = new Type[0];

	private static Type[] swigMethodTypes86 = new Type[0];

	private static Type[] swigMethodTypes87 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes88 = new Type[1] { typeof(OdGePoint2d) };

	private static Type[] swigMethodTypes89 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes90 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes91 = new Type[1] { typeof(bool) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDimensionObjectContextData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDimensionObjectContextData obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDimensionObjectContextData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbDimensionObjectContextData cast(OdRxObject pObj)
	{
		OdDbDimensionObjectContextData rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDimensionObjectContextData>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_isASwigExplicitOdDbDimensionObjectContextData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_queryXSwigExplicitOdDbDimensionObjectContextData(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbObjectId blockIndex()
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("blockIndex", swigMethodTypes68) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_blockIndexSwigExplicitOdDbDimensionObjectContextData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_blockIndex(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBlockIndex(OdDbObjectId arg0)
	{
		if (SwigDerivedClassHasMethod("setBlockIndex", swigMethodTypes69))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setBlockIndexSwigExplicitOdDbDimensionObjectContextData(swigCPtr, OdDbObjectId.getCPtr(arg0));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setBlockIndex(swigCPtr, OdDbObjectId.getCPtr(arg0));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setNDBRDimBlock(OdDbBlockTableRecord arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setNDBRDimBlock(swigCPtr, OdDbBlockTableRecord.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBlockTableRecord getNDBRDimBlock()
	{
		OdDbBlockTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableRecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_getNDBRDimBlock(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool hasOverride(OdDbDimensionObjectContextData_OverrideCode arg0)
	{
		bool result = (SwigDerivedClassHasMethod("hasOverride", swigMethodTypes70) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_hasOverrideSwigExplicitOdDbDimensionObjectContextData(swigCPtr, (int)arg0) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_hasOverride(swigCPtr, (int)arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOverride(OdDbDimensionObjectContextData_OverrideCode arg0, bool arg1)
	{
		if (SwigDerivedClassHasMethod("setOverride", swigMethodTypes71))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setOverrideSwigExplicitOdDbDimensionObjectContextData(swigCPtr, (int)arg0, arg1);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setOverride(swigCPtr, (int)arg0, arg1);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimatfit()
	{
		short result = (SwigDerivedClassHasMethod("dimatfit", swigMethodTypes72) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dimatfitSwigExplicitOdDbDimensionObjectContextData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dimatfit(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool dimsoxd()
	{
		bool result = (SwigDerivedClassHasMethod("dimsoxd", swigMethodTypes73) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dimsoxdSwigExplicitOdDbDimensionObjectContextData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dimsoxd(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool dimtix()
	{
		bool result = (SwigDerivedClassHasMethod("dimtix", swigMethodTypes74) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dimtixSwigExplicitOdDbDimensionObjectContextData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dimtix(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short dimtmove()
	{
		short result = (SwigDerivedClassHasMethod("dimtmove", swigMethodTypes75) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dimtmoveSwigExplicitOdDbDimensionObjectContextData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dimtmove(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool dimtofl()
	{
		bool result = (SwigDerivedClassHasMethod("dimtofl", swigMethodTypes76) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dimtoflSwigExplicitOdDbDimensionObjectContextData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dimtofl(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimatfit(short arg0)
	{
		if (SwigDerivedClassHasMethod("setDimatfit", swigMethodTypes77))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setDimatfitSwigExplicitOdDbDimensionObjectContextData(swigCPtr, arg0);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setDimatfit(swigCPtr, arg0);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimsoxd(bool arg0)
	{
		if (SwigDerivedClassHasMethod("setDimsoxd", swigMethodTypes78))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setDimsoxdSwigExplicitOdDbDimensionObjectContextData(swigCPtr, arg0);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setDimsoxd(swigCPtr, arg0);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimtix(bool arg0)
	{
		if (SwigDerivedClassHasMethod("setDimtix", swigMethodTypes79))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setDimtixSwigExplicitOdDbDimensionObjectContextData(swigCPtr, arg0);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setDimtix(swigCPtr, arg0);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimtmove(short arg0)
	{
		if (SwigDerivedClassHasMethod("setDimtmove", swigMethodTypes80))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setDimtmoveSwigExplicitOdDbDimensionObjectContextData(swigCPtr, arg0);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setDimtmove(swigCPtr, arg0);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDimtofl(bool arg0)
	{
		if (SwigDerivedClassHasMethod("setDimtofl", swigMethodTypes81))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setDimtoflSwigExplicitOdDbDimensionObjectContextData(swigCPtr, arg0);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setDimtofl(swigCPtr, arg0);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool defTextLocation()
	{
		bool result = (SwigDerivedClassHasMethod("defTextLocation", swigMethodTypes82) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_defTextLocationSwigExplicitOdDbDimensionObjectContextData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_defTextLocation(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint2d textLocation()
	{
		OdGePoint2d result = new OdGePoint2d(SwigDerivedClassHasMethod("textLocation", swigMethodTypes83) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_textLocationSwigExplicitOdDbDimensionObjectContextData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_textLocation(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double textRotation()
	{
		double result = (SwigDerivedClassHasMethod("textRotation", swigMethodTypes84) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_textRotationSwigExplicitOdDbDimensionObjectContextData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_textRotation(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getArrowFirstIsFlipped()
	{
		bool result = (SwigDerivedClassHasMethod("getArrowFirstIsFlipped", swigMethodTypes85) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_getArrowFirstIsFlippedSwigExplicitOdDbDimensionObjectContextData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_getArrowFirstIsFlipped(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getArrowSecondIsFlipped()
	{
		bool result = (SwigDerivedClassHasMethod("getArrowSecondIsFlipped", swigMethodTypes86) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_getArrowSecondIsFlippedSwigExplicitOdDbDimensionObjectContextData(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_getArrowSecondIsFlipped(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDefTextLocation(bool arg0)
	{
		if (SwigDerivedClassHasMethod("setDefTextLocation", swigMethodTypes87))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setDefTextLocationSwigExplicitOdDbDimensionObjectContextData(swigCPtr, arg0);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setDefTextLocation(swigCPtr, arg0);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextLocation(OdGePoint2d arg0)
	{
		if (SwigDerivedClassHasMethod("setTextLocation", swigMethodTypes88))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setTextLocationSwigExplicitOdDbDimensionObjectContextData(swigCPtr, OdGePoint2d.getCPtr(arg0));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setTextLocation(swigCPtr, OdGePoint2d.getCPtr(arg0));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextRotation(double arg0)
	{
		if (SwigDerivedClassHasMethod("setTextRotation", swigMethodTypes89))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setTextRotationSwigExplicitOdDbDimensionObjectContextData(swigCPtr, arg0);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setTextRotation(swigCPtr, arg0);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setArrowFirstIsFlipped(bool arg0)
	{
		if (SwigDerivedClassHasMethod("setArrowFirstIsFlipped", swigMethodTypes90))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setArrowFirstIsFlippedSwigExplicitOdDbDimensionObjectContextData(swigCPtr, arg0);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setArrowFirstIsFlipped(swigCPtr, arg0);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setArrowSecondIsFlipped(bool arg0)
	{
		if (SwigDerivedClassHasMethod("setArrowSecondIsFlipped", swigMethodTypes91))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setArrowSecondIsFlippedSwigExplicitOdDbDimensionObjectContextData(swigCPtr, arg0);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_setArrowSecondIsFlipped(swigCPtr, arg0);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void copyFrom(OdRxObject arg0)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_copyFromSwigExplicitOdDbDimensionObjectContextData(swigCPtr, OdRxObject.getCPtr(arg0));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_copyFrom(swigCPtr, OdRxObject.getCPtr(arg0));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dxfInFieldsSwigExplicitOdDbDimensionObjectContextData(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dxfOutFieldsSwigExplicitOdDbDimensionObjectContextData(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void transformBy(OdGeMatrix3d mx)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(mx));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbDimensionObjectContextData createObject()
	{
		OdDbDimensionObjectContextData rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDimensionObjectContextData>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("dwgInContextData", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethoddwgInContextData;
		}
		if (SwigDerivedClassHasMethod("dwgOutContextData", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethoddwgOutContextData;
		}
		if (SwigDerivedClassHasMethod("context", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodcontext;
		}
		if (SwigDerivedClassHasMethod("matchesContext", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodmatchesContext;
		}
		if (SwigDerivedClassHasMethod("setContext", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodsetContext;
		}
		if (SwigDerivedClassHasMethod("setContextToNull", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodsetContextToNull;
		}
		if (SwigDerivedClassHasMethod("getScale", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodgetScale;
		}
		if (SwigDerivedClassHasMethod("blockIndex", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodblockIndex;
		}
		if (SwigDerivedClassHasMethod("setBlockIndex", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodsetBlockIndex;
		}
		if (SwigDerivedClassHasMethod("hasOverride", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodhasOverride;
		}
		if (SwigDerivedClassHasMethod("setOverride", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodsetOverride;
		}
		if (SwigDerivedClassHasMethod("dimatfit", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethoddimatfit;
		}
		if (SwigDerivedClassHasMethod("dimsoxd", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethoddimsoxd;
		}
		if (SwigDerivedClassHasMethod("dimtix", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethoddimtix;
		}
		if (SwigDerivedClassHasMethod("dimtmove", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethoddimtmove;
		}
		if (SwigDerivedClassHasMethod("dimtofl", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethoddimtofl;
		}
		if (SwigDerivedClassHasMethod("setDimatfit", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodsetDimatfit;
		}
		if (SwigDerivedClassHasMethod("setDimsoxd", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodsetDimsoxd;
		}
		if (SwigDerivedClassHasMethod("setDimtix", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodsetDimtix;
		}
		if (SwigDerivedClassHasMethod("setDimtmove", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodsetDimtmove;
		}
		if (SwigDerivedClassHasMethod("setDimtofl", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodsetDimtofl;
		}
		if (SwigDerivedClassHasMethod("defTextLocation", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethoddefTextLocation;
		}
		if (SwigDerivedClassHasMethod("textLocation", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodtextLocation;
		}
		if (SwigDerivedClassHasMethod("textRotation", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodtextRotation;
		}
		if (SwigDerivedClassHasMethod("getArrowFirstIsFlipped", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodgetArrowFirstIsFlipped;
		}
		if (SwigDerivedClassHasMethod("getArrowSecondIsFlipped", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodgetArrowSecondIsFlipped;
		}
		if (SwigDerivedClassHasMethod("setDefTextLocation", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodsetDefTextLocation;
		}
		if (SwigDerivedClassHasMethod("setTextLocation", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodsetTextLocation;
		}
		if (SwigDerivedClassHasMethod("setTextRotation", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodsetTextRotation;
		}
		if (SwigDerivedClassHasMethod("setArrowFirstIsFlipped", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodsetArrowFirstIsFlipped;
		}
		if (SwigDerivedClassHasMethod("setArrowSecondIsFlipped", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodsetArrowSecondIsFlipped;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionObjectContextData_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbDimensionObjectContextData));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr arg0)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

	private int SwigDirectorMethoddwgInContextData(IntPtr arg0)
	{
		return (int)dwgInContextData(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethoddwgOutContextData(IntPtr arg0)
	{
		try
		{
			dwgOutContextData(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(arg0, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodcontext()
	{
		return OdDbObjectContext.getCPtr(context()).Handle;
	}

	private bool SwigDirectorMethodmatchesContext(IntPtr arg0)
	{
		return matchesContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetContext(IntPtr arg0)
	{
		try
		{
			setContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(arg0, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetContextToNull()
	{
		try
		{
			setContextToNull();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodgetScale(double arg0)
	{
		return (int)getScale(out arg0);
	}

	private IntPtr SwigDirectorMethodblockIndex()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(blockIndex()).Handle;
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

	private void SwigDirectorMethodsetBlockIndex(IntPtr arg0)
	{
		try
		{
			setBlockIndex(new OdDbObjectId(arg0, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodhasOverride(int arg0)
	{
		return hasOverride((OdDbDimensionObjectContextData_OverrideCode)arg0);
	}

	private void SwigDirectorMethodsetOverride(int arg0, bool arg1)
	{
		try
		{
			setOverride((OdDbDimensionObjectContextData_OverrideCode)arg0, arg1);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private short SwigDirectorMethoddimatfit()
	{
		return dimatfit();
	}

	private bool SwigDirectorMethoddimsoxd()
	{
		return dimsoxd();
	}

	private bool SwigDirectorMethoddimtix()
	{
		return dimtix();
	}

	private short SwigDirectorMethoddimtmove()
	{
		return dimtmove();
	}

	private bool SwigDirectorMethoddimtofl()
	{
		return dimtofl();
	}

	private void SwigDirectorMethodsetDimatfit(short arg0)
	{
		try
		{
			setDimatfit(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimsoxd(bool arg0)
	{
		try
		{
			setDimsoxd(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimtix(bool arg0)
	{
		try
		{
			setDimtix(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimtmove(short arg0)
	{
		try
		{
			setDimtmove(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetDimtofl(bool arg0)
	{
		try
		{
			setDimtofl(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethoddefTextLocation()
	{
		return defTextLocation();
	}

	private IntPtr SwigDirectorMethodtextLocation()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint2d.getCPtr(textLocation()).Handle;
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

	private double SwigDirectorMethodtextRotation()
	{
		return textRotation();
	}

	private bool SwigDirectorMethodgetArrowFirstIsFlipped()
	{
		return getArrowFirstIsFlipped();
	}

	private bool SwigDirectorMethodgetArrowSecondIsFlipped()
	{
		return getArrowSecondIsFlipped();
	}

	private void SwigDirectorMethodsetDefTextLocation(bool arg0)
	{
		try
		{
			setDefTextLocation(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetTextLocation(IntPtr arg0)
	{
		try
		{
			setTextLocation(new OdGePoint2d(arg0, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetTextRotation(double arg0)
	{
		try
		{
			setTextRotation(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetArrowFirstIsFlipped(bool arg0)
	{
		try
		{
			setArrowFirstIsFlipped(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetArrowSecondIsFlipped(bool arg0)
	{
		try
		{
			setArrowSecondIsFlipped(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

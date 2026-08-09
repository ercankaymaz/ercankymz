using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDataTable : OdDbObject
{
	public delegate IntPtr SwigDelegateOdDbDataTable_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbDataTable_1();

	public delegate void SwigDelegateOdDbDataTable_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbDataTable_3();

	public delegate bool SwigDelegateOdDbDataTable_4();

	public delegate IntPtr SwigDelegateOdDbDataTable_5();

	public delegate void SwigDelegateOdDbDataTable_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbDataTable_7();

	public delegate uint SwigDelegateOdDbDataTable_8(IntPtr vd);

	public delegate uint SwigDelegateOdDbDataTable_9();

	public delegate void SwigDelegateOdDbDataTable_10(IntPtr ownerId);

	public delegate int SwigDelegateOdDbDataTable_11(int mode);

	public delegate void SwigDelegateOdDbDataTable_12();

	public delegate int SwigDelegateOdDbDataTable_13(bool erasing);

	public delegate void SwigDelegateOdDbDataTable_14(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbDataTable_15(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbDataTable_16(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbDataTable_17(IntPtr otherId);

	public delegate void SwigDelegateOdDbDataTable_18(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbDataTable_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbDataTable_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbDataTable_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbDataTable_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbDataTable_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbDataTable_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbDataTable_25(IntPtr pFiler);

	public delegate void SwigDelegateOdDbDataTable_26(IntPtr pFiler);

	public delegate int SwigDelegateOdDbDataTable_27();

	public delegate IntPtr SwigDelegateOdDbDataTable_28([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbDataTable_29(IntPtr pRb);

	public delegate void SwigDelegateOdDbDataTable_30(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbDataTable_31(IntPtr objId);

	public delegate void SwigDelegateOdDbDataTable_32(IntPtr objId);

	public delegate void SwigDelegateOdDbDataTable_33(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbDataTable_34();

	public delegate void SwigDelegateOdDbDataTable_35(IntPtr idPair, IntPtr pOwnerObject, IntPtr idMap);

	public delegate void SwigDelegateOdDbDataTable_36(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbDataTable_37(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbDataTable_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbDataTable_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbDataTable_40(IntPtr pObject);

	public delegate void SwigDelegateOdDbDataTable_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbDataTable_42(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbDataTable_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbDataTable_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbDataTable_45(IntPtr pObject);

	public delegate void SwigDelegateOdDbDataTable_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbDataTable_47(IntPtr objectId);

	public delegate void SwigDelegateOdDbDataTable_48(IntPtr pObject);

	public delegate void SwigDelegateOdDbDataTable_49(IntPtr pSource);

	public delegate int SwigDelegateOdDbDataTable_50(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbDataTable_51(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbDataTable_52(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbDataTable_53(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbDataTable_54(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbDataTable_55();

	public delegate IntPtr SwigDelegateOdDbDataTable_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbDataTable_57(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbDataTable_58([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbDataTable_59(IntPtr pClass);

	public delegate int SwigDelegateOdDbDataTable_60(IntPtr pClsid);

	public delegate uint SwigDelegateOdDbDataTable_61();

	public delegate uint SwigDelegateOdDbDataTable_62();

	public delegate void SwigDelegateOdDbDataTable_63(uint n);

	public delegate void SwigDelegateOdDbDataTable_64(uint n);

	public delegate uint SwigDelegateOdDbDataTable_65();

	public delegate uint SwigDelegateOdDbDataTable_66();

	public delegate void SwigDelegateOdDbDataTable_67(uint n);

	public delegate void SwigDelegateOdDbDataTable_68(uint n);

	public delegate uint SwigDelegateOdDbDataTable_69();

	public delegate uint SwigDelegateOdDbDataTable_70();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDataTable_71();

	public delegate void SwigDelegateOdDbDataTable_72([MarshalAs(UnmanagedType.LPWStr)] string pName);

	public delegate IntPtr SwigDelegateOdDbDataTable_73(uint index);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDataTable_74(uint index);

	public delegate int SwigDelegateOdDbDataTable_75(uint index);

	public delegate int SwigDelegateOdDbDataTable_76([MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate void SwigDelegateOdDbDataTable_77(int type, [MarshalAs(UnmanagedType.LPWStr)] string colName);

	public delegate void SwigDelegateOdDbDataTable_78(uint index, int type, [MarshalAs(UnmanagedType.LPWStr)] string colName);

	public delegate void SwigDelegateOdDbDataTable_79(uint index);

	public delegate void SwigDelegateOdDbDataTable_80(uint index, IntPtr outRow);

	public delegate void SwigDelegateOdDbDataTable_81(uint index, IntPtr row, bool bValidate);

	public delegate void SwigDelegateOdDbDataTable_82(uint index, IntPtr row);

	public delegate void SwigDelegateOdDbDataTable_83(IntPtr row, bool bValidate);

	public delegate void SwigDelegateOdDbDataTable_84(IntPtr row);

	public delegate void SwigDelegateOdDbDataTable_85(uint index, IntPtr row, bool bValidate);

	public delegate void SwigDelegateOdDbDataTable_86(uint index, IntPtr row);

	public delegate void SwigDelegateOdDbDataTable_87(uint index);

	public delegate IntPtr SwigDelegateOdDbDataTable_88(uint row, uint col);

	public delegate void SwigDelegateOdDbDataTable_89(uint row, uint col, IntPtr cell);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbDataTable_0 swigDelegate0;

	private SwigDelegateOdDbDataTable_1 swigDelegate1;

	private SwigDelegateOdDbDataTable_2 swigDelegate2;

	private SwigDelegateOdDbDataTable_3 swigDelegate3;

	private SwigDelegateOdDbDataTable_4 swigDelegate4;

	private SwigDelegateOdDbDataTable_5 swigDelegate5;

	private SwigDelegateOdDbDataTable_6 swigDelegate6;

	private SwigDelegateOdDbDataTable_7 swigDelegate7;

	private SwigDelegateOdDbDataTable_8 swigDelegate8;

	private SwigDelegateOdDbDataTable_9 swigDelegate9;

	private SwigDelegateOdDbDataTable_10 swigDelegate10;

	private SwigDelegateOdDbDataTable_11 swigDelegate11;

	private SwigDelegateOdDbDataTable_12 swigDelegate12;

	private SwigDelegateOdDbDataTable_13 swigDelegate13;

	private SwigDelegateOdDbDataTable_14 swigDelegate14;

	private SwigDelegateOdDbDataTable_15 swigDelegate15;

	private SwigDelegateOdDbDataTable_16 swigDelegate16;

	private SwigDelegateOdDbDataTable_17 swigDelegate17;

	private SwigDelegateOdDbDataTable_18 swigDelegate18;

	private SwigDelegateOdDbDataTable_19 swigDelegate19;

	private SwigDelegateOdDbDataTable_20 swigDelegate20;

	private SwigDelegateOdDbDataTable_21 swigDelegate21;

	private SwigDelegateOdDbDataTable_22 swigDelegate22;

	private SwigDelegateOdDbDataTable_23 swigDelegate23;

	private SwigDelegateOdDbDataTable_24 swigDelegate24;

	private SwigDelegateOdDbDataTable_25 swigDelegate25;

	private SwigDelegateOdDbDataTable_26 swigDelegate26;

	private SwigDelegateOdDbDataTable_27 swigDelegate27;

	private SwigDelegateOdDbDataTable_28 swigDelegate28;

	private SwigDelegateOdDbDataTable_29 swigDelegate29;

	private SwigDelegateOdDbDataTable_30 swigDelegate30;

	private SwigDelegateOdDbDataTable_31 swigDelegate31;

	private SwigDelegateOdDbDataTable_32 swigDelegate32;

	private SwigDelegateOdDbDataTable_33 swigDelegate33;

	private SwigDelegateOdDbDataTable_34 swigDelegate34;

	private SwigDelegateOdDbDataTable_35 swigDelegate35;

	private SwigDelegateOdDbDataTable_36 swigDelegate36;

	private SwigDelegateOdDbDataTable_37 swigDelegate37;

	private SwigDelegateOdDbDataTable_38 swigDelegate38;

	private SwigDelegateOdDbDataTable_39 swigDelegate39;

	private SwigDelegateOdDbDataTable_40 swigDelegate40;

	private SwigDelegateOdDbDataTable_41 swigDelegate41;

	private SwigDelegateOdDbDataTable_42 swigDelegate42;

	private SwigDelegateOdDbDataTable_43 swigDelegate43;

	private SwigDelegateOdDbDataTable_44 swigDelegate44;

	private SwigDelegateOdDbDataTable_45 swigDelegate45;

	private SwigDelegateOdDbDataTable_46 swigDelegate46;

	private SwigDelegateOdDbDataTable_47 swigDelegate47;

	private SwigDelegateOdDbDataTable_48 swigDelegate48;

	private SwigDelegateOdDbDataTable_49 swigDelegate49;

	private SwigDelegateOdDbDataTable_50 swigDelegate50;

	private SwigDelegateOdDbDataTable_51 swigDelegate51;

	private SwigDelegateOdDbDataTable_52 swigDelegate52;

	private SwigDelegateOdDbDataTable_53 swigDelegate53;

	private SwigDelegateOdDbDataTable_54 swigDelegate54;

	private SwigDelegateOdDbDataTable_55 swigDelegate55;

	private SwigDelegateOdDbDataTable_56 swigDelegate56;

	private SwigDelegateOdDbDataTable_57 swigDelegate57;

	private SwigDelegateOdDbDataTable_58 swigDelegate58;

	private SwigDelegateOdDbDataTable_59 swigDelegate59;

	private SwigDelegateOdDbDataTable_60 swigDelegate60;

	private SwigDelegateOdDbDataTable_61 swigDelegate61;

	private SwigDelegateOdDbDataTable_62 swigDelegate62;

	private SwigDelegateOdDbDataTable_63 swigDelegate63;

	private SwigDelegateOdDbDataTable_64 swigDelegate64;

	private SwigDelegateOdDbDataTable_65 swigDelegate65;

	private SwigDelegateOdDbDataTable_66 swigDelegate66;

	private SwigDelegateOdDbDataTable_67 swigDelegate67;

	private SwigDelegateOdDbDataTable_68 swigDelegate68;

	private SwigDelegateOdDbDataTable_69 swigDelegate69;

	private SwigDelegateOdDbDataTable_70 swigDelegate70;

	private SwigDelegateOdDbDataTable_71 swigDelegate71;

	private SwigDelegateOdDbDataTable_72 swigDelegate72;

	private SwigDelegateOdDbDataTable_73 swigDelegate73;

	private SwigDelegateOdDbDataTable_74 swigDelegate74;

	private SwigDelegateOdDbDataTable_75 swigDelegate75;

	private SwigDelegateOdDbDataTable_76 swigDelegate76;

	private SwigDelegateOdDbDataTable_77 swigDelegate77;

	private SwigDelegateOdDbDataTable_78 swigDelegate78;

	private SwigDelegateOdDbDataTable_79 swigDelegate79;

	private SwigDelegateOdDbDataTable_80 swigDelegate80;

	private SwigDelegateOdDbDataTable_81 swigDelegate81;

	private SwigDelegateOdDbDataTable_82 swigDelegate82;

	private SwigDelegateOdDbDataTable_83 swigDelegate83;

	private SwigDelegateOdDbDataTable_84 swigDelegate84;

	private SwigDelegateOdDbDataTable_85 swigDelegate85;

	private SwigDelegateOdDbDataTable_86 swigDelegate86;

	private SwigDelegateOdDbDataTable_87 swigDelegate87;

	private SwigDelegateOdDbDataTable_88 swigDelegate88;

	private SwigDelegateOdDbDataTable_89 swigDelegate89;

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

	private static Type[] swigMethodTypes62 = new Type[0];

	private static Type[] swigMethodTypes63 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes65 = new Type[0];

	private static Type[] swigMethodTypes66 = new Type[0];

	private static Type[] swigMethodTypes67 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes68 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes69 = new Type[0];

	private static Type[] swigMethodTypes70 = new Type[0];

	private static Type[] swigMethodTypes71 = new Type[0];

	private static Type[] swigMethodTypes72 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes73 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes74 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes75 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes76 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes77 = new Type[2]
	{
		typeof(OdDbDataCell_CellType),
		typeof(string)
	};

	private static Type[] swigMethodTypes78 = new Type[3]
	{
		typeof(uint),
		typeof(OdDbDataCell_CellType),
		typeof(string)
	};

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes80 = new Type[2]
	{
		typeof(uint),
		typeof(OdDbDataCellArray)
	};

	private static Type[] swigMethodTypes81 = new Type[3]
	{
		typeof(uint),
		typeof(OdDbDataCellArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes82 = new Type[2]
	{
		typeof(uint),
		typeof(OdDbDataCellArray)
	};

	private static Type[] swigMethodTypes83 = new Type[2]
	{
		typeof(OdDbDataCellArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes84 = new Type[1] { typeof(OdDbDataCellArray) };

	private static Type[] swigMethodTypes85 = new Type[3]
	{
		typeof(uint),
		typeof(OdDbDataCellArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes86 = new Type[2]
	{
		typeof(uint),
		typeof(OdDbDataCellArray)
	};

	private static Type[] swigMethodTypes87 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes88 = new Type[2]
	{
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes89 = new Type[3]
	{
		typeof(uint),
		typeof(uint),
		typeof(OdDbDataCell)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDataTable(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDataTable obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDataTable(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbDataTable cast(OdRxObject pObj)
	{
		OdDbDataTable rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataTable>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_isASwigExplicitOdDbDataTable(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_queryXSwigExplicitOdDbDataTable(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint numColumns()
	{
		uint result = (SwigDerivedClassHasMethod("numColumns", swigMethodTypes61) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_numColumnsSwigExplicitOdDbDataTable(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_numColumns(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numRows()
	{
		uint result = (SwigDerivedClassHasMethod("numRows", swigMethodTypes62) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_numRowsSwigExplicitOdDbDataTable(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_numRows(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setNumRowsPhysicalSize(uint n)
	{
		if (SwigDerivedClassHasMethod("setNumRowsPhysicalSize", swigMethodTypes63))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setNumRowsPhysicalSizeSwigExplicitOdDbDataTable(swigCPtr, n);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setNumRowsPhysicalSize(swigCPtr, n);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setNumRowsGrowSize(uint n)
	{
		if (SwigDerivedClassHasMethod("setNumRowsGrowSize", swigMethodTypes64))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setNumRowsGrowSizeSwigExplicitOdDbDataTable(swigCPtr, n);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setNumRowsGrowSize(swigCPtr, n);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint numRowsPhysicalSize()
	{
		uint result = (SwigDerivedClassHasMethod("numRowsPhysicalSize", swigMethodTypes65) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_numRowsPhysicalSizeSwigExplicitOdDbDataTable(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_numRowsPhysicalSize(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numRowsGrowSize()
	{
		uint result = (SwigDerivedClassHasMethod("numRowsGrowSize", swigMethodTypes66) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_numRowsGrowSizeSwigExplicitOdDbDataTable(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_numRowsGrowSize(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setNumColsPhysicalSize(uint n)
	{
		if (SwigDerivedClassHasMethod("setNumColsPhysicalSize", swigMethodTypes67))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setNumColsPhysicalSizeSwigExplicitOdDbDataTable(swigCPtr, n);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setNumColsPhysicalSize(swigCPtr, n);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setNumColsGrowSize(uint n)
	{
		if (SwigDerivedClassHasMethod("setNumColsGrowSize", swigMethodTypes68))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setNumColsGrowSizeSwigExplicitOdDbDataTable(swigCPtr, n);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setNumColsGrowSize(swigCPtr, n);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint numColsPhysicalSize()
	{
		uint result = (SwigDerivedClassHasMethod("numColsPhysicalSize", swigMethodTypes69) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_numColsPhysicalSizeSwigExplicitOdDbDataTable(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_numColsPhysicalSize(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numColsGrowSize()
	{
		uint result = (SwigDerivedClassHasMethod("numColsGrowSize", swigMethodTypes70) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_numColsGrowSizeSwigExplicitOdDbDataTable(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_numColsGrowSize(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string tableName()
	{
		string result = (SwigDerivedClassHasMethod("tableName", swigMethodTypes71) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_tableNameSwigExplicitOdDbDataTable(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_tableName(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTableName(string pName)
	{
		if (SwigDerivedClassHasMethod("setTableName", swigMethodTypes72))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setTableNameSwigExplicitOdDbDataTable(swigCPtr, pName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setTableName(swigCPtr, pName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbDataColumn getColumnAt(uint index)
	{
		OdDbDataColumn rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataColumn>(SwigDerivedClassHasMethod("getColumnAt", swigMethodTypes73) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_getColumnAtSwigExplicitOdDbDataTable(swigCPtr, index) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_getColumnAt(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string columnNameAt(uint index)
	{
		string result = (SwigDerivedClassHasMethod("columnNameAt", swigMethodTypes74) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_columnNameAtSwigExplicitOdDbDataTable(swigCPtr, index) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_columnNameAt(swigCPtr, index));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbDataCell_CellType columnTypeAt(uint index)
	{
		int result = (SwigDerivedClassHasMethod("columnTypeAt", swigMethodTypes75) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_columnTypeAtSwigExplicitOdDbDataTable(swigCPtr, index) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_columnTypeAt(swigCPtr, index));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbDataCell_CellType)result;
	}

	public virtual int columnIndexAtName(string name)
	{
		int result = (SwigDerivedClassHasMethod("columnIndexAtName", swigMethodTypes76) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_columnIndexAtNameSwigExplicitOdDbDataTable(swigCPtr, name) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_columnIndexAtName(swigCPtr, name));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void appendColumn(OdDbDataCell_CellType type, string colName)
	{
		if (SwigDerivedClassHasMethod("appendColumn", swigMethodTypes77))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_appendColumnSwigExplicitOdDbDataTable(swigCPtr, (int)type, colName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_appendColumn(swigCPtr, (int)type, colName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void insertColumnAt(uint index, OdDbDataCell_CellType type, string colName)
	{
		if (SwigDerivedClassHasMethod("insertColumnAt", swigMethodTypes78))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_insertColumnAtSwigExplicitOdDbDataTable(swigCPtr, index, (int)type, colName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_insertColumnAt(swigCPtr, index, (int)type, colName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeColumnAt(uint index)
	{
		if (SwigDerivedClassHasMethod("removeColumnAt", swigMethodTypes79))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_removeColumnAtSwigExplicitOdDbDataTable(swigCPtr, index);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_removeColumnAt(swigCPtr, index);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getRowAt(uint index, OdDbDataCellArray outRow)
	{
		if (SwigDerivedClassHasMethod("getRowAt", swigMethodTypes80))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_getRowAtSwigExplicitOdDbDataTable(swigCPtr, index, OdDbDataCellArray.getCPtr(outRow));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_getRowAt(swigCPtr, index, OdDbDataCellArray.getCPtr(outRow));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRowAt(uint index, OdDbDataCellArray row, bool bValidate)
	{
		if (SwigDerivedClassHasMethod("setRowAt", swigMethodTypes81))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setRowAtSwigExplicitOdDbDataTable__SWIG_0(swigCPtr, index, OdDbDataCellArray.getCPtr(row), bValidate);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setRowAt__SWIG_0(swigCPtr, index, OdDbDataCellArray.getCPtr(row), bValidate);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRowAt(uint index, OdDbDataCellArray row)
	{
		if (SwigDerivedClassHasMethod("setRowAt", swigMethodTypes82))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setRowAtSwigExplicitOdDbDataTable__SWIG_1(swigCPtr, index, OdDbDataCellArray.getCPtr(row));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setRowAt__SWIG_1(swigCPtr, index, OdDbDataCellArray.getCPtr(row));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void appendRow(OdDbDataCellArray row, bool bValidate)
	{
		if (SwigDerivedClassHasMethod("appendRow", swigMethodTypes83))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_appendRowSwigExplicitOdDbDataTable__SWIG_0(swigCPtr, OdDbDataCellArray.getCPtr(row), bValidate);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_appendRow__SWIG_0(swigCPtr, OdDbDataCellArray.getCPtr(row), bValidate);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void appendRow(OdDbDataCellArray row)
	{
		if (SwigDerivedClassHasMethod("appendRow", swigMethodTypes84))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_appendRowSwigExplicitOdDbDataTable__SWIG_1(swigCPtr, OdDbDataCellArray.getCPtr(row));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_appendRow__SWIG_1(swigCPtr, OdDbDataCellArray.getCPtr(row));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void insertRowAt(uint index, OdDbDataCellArray row, bool bValidate)
	{
		if (SwigDerivedClassHasMethod("insertRowAt", swigMethodTypes85))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_insertRowAtSwigExplicitOdDbDataTable__SWIG_0(swigCPtr, index, OdDbDataCellArray.getCPtr(row), bValidate);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_insertRowAt__SWIG_0(swigCPtr, index, OdDbDataCellArray.getCPtr(row), bValidate);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void insertRowAt(uint index, OdDbDataCellArray row)
	{
		if (SwigDerivedClassHasMethod("insertRowAt", swigMethodTypes86))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_insertRowAtSwigExplicitOdDbDataTable__SWIG_1(swigCPtr, index, OdDbDataCellArray.getCPtr(row));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_insertRowAt__SWIG_1(swigCPtr, index, OdDbDataCellArray.getCPtr(row));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeRowAt(uint index)
	{
		if (SwigDerivedClassHasMethod("removeRowAt", swigMethodTypes87))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_removeRowAtSwigExplicitOdDbDataTable(swigCPtr, index);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_removeRowAt(swigCPtr, index);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbDataCell getCellAt(uint row, uint col)
	{
		OdDbDataCell rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataCell>(SwigDerivedClassHasMethod("getCellAt", swigMethodTypes88) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_getCellAtSwigExplicitOdDbDataTable(swigCPtr, row, col) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_getCellAt(swigCPtr, row, col), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setCellAt(uint row, uint col, OdDbDataCell cell)
	{
		if (SwigDerivedClassHasMethod("setCellAt", swigMethodTypes89))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setCellAtSwigExplicitOdDbDataTable(swigCPtr, row, col, OdDbDataCell.getCPtr(cell));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_setCellAt(swigCPtr, row, col, OdDbDataCell.getCPtr(cell));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_dwgInFieldsSwigExplicitOdDbDataTable(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_dwgOutFieldsSwigExplicitOdDbDataTable(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_dxfInFieldsSwigExplicitOdDbDataTable(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_dxfOutFieldsSwigExplicitOdDbDataTable(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbDataTable createObject()
	{
		OdDbDataTable rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataTable>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("numColumns", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodnumColumns;
		}
		if (SwigDerivedClassHasMethod("numRows", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodnumRows;
		}
		if (SwigDerivedClassHasMethod("setNumRowsPhysicalSize", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodsetNumRowsPhysicalSize;
		}
		if (SwigDerivedClassHasMethod("setNumRowsGrowSize", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodsetNumRowsGrowSize;
		}
		if (SwigDerivedClassHasMethod("numRowsPhysicalSize", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodnumRowsPhysicalSize;
		}
		if (SwigDerivedClassHasMethod("numRowsGrowSize", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodnumRowsGrowSize;
		}
		if (SwigDerivedClassHasMethod("setNumColsPhysicalSize", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodsetNumColsPhysicalSize;
		}
		if (SwigDerivedClassHasMethod("setNumColsGrowSize", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodsetNumColsGrowSize;
		}
		if (SwigDerivedClassHasMethod("numColsPhysicalSize", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodnumColsPhysicalSize;
		}
		if (SwigDerivedClassHasMethod("numColsGrowSize", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodnumColsGrowSize;
		}
		if (SwigDerivedClassHasMethod("tableName", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodtableName;
		}
		if (SwigDerivedClassHasMethod("setTableName", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodsetTableName;
		}
		if (SwigDerivedClassHasMethod("getColumnAt", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodgetColumnAt;
		}
		if (SwigDerivedClassHasMethod("columnNameAt", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodcolumnNameAt;
		}
		if (SwigDerivedClassHasMethod("columnTypeAt", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodcolumnTypeAt;
		}
		if (SwigDerivedClassHasMethod("columnIndexAtName", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodcolumnIndexAtName;
		}
		if (SwigDerivedClassHasMethod("appendColumn", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodappendColumn;
		}
		if (SwigDerivedClassHasMethod("insertColumnAt", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodinsertColumnAt;
		}
		if (SwigDerivedClassHasMethod("removeColumnAt", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodremoveColumnAt;
		}
		if (SwigDerivedClassHasMethod("getRowAt", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodgetRowAt;
		}
		if (SwigDerivedClassHasMethod("setRowAt", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodsetRowAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setRowAt", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodsetRowAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("appendRow", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodappendRow__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("appendRow", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodappendRow__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("insertRowAt", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodinsertRowAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("insertRowAt", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodinsertRowAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("removeRowAt", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodremoveRowAt;
		}
		if (SwigDerivedClassHasMethod("getCellAt", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodgetCellAt;
		}
		if (SwigDerivedClassHasMethod("setCellAt", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodsetCellAt;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataTable_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbDataTable));
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

	private uint SwigDirectorMethodnumColumns()
	{
		return numColumns();
	}

	private uint SwigDirectorMethodnumRows()
	{
		return numRows();
	}

	private void SwigDirectorMethodsetNumRowsPhysicalSize(uint n)
	{
		try
		{
			setNumRowsPhysicalSize(n);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetNumRowsGrowSize(uint n)
	{
		try
		{
			setNumRowsGrowSize(n);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethodnumRowsPhysicalSize()
	{
		return numRowsPhysicalSize();
	}

	private uint SwigDirectorMethodnumRowsGrowSize()
	{
		return numRowsGrowSize();
	}

	private void SwigDirectorMethodsetNumColsPhysicalSize(uint n)
	{
		try
		{
			setNumColsPhysicalSize(n);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetNumColsGrowSize(uint n)
	{
		try
		{
			setNumColsGrowSize(n);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethodnumColsPhysicalSize()
	{
		return numColsPhysicalSize();
	}

	private uint SwigDirectorMethodnumColsGrowSize()
	{
		return numColsGrowSize();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodtableName()
	{
		return tableName();
	}

	private void SwigDirectorMethodsetTableName([MarshalAs(UnmanagedType.LPWStr)] string pName)
	{
		try
		{
			setTableName(pName);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetColumnAt(uint index)
	{
		return OdDbDataColumn.getCPtr(getColumnAt(index)).Handle;
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodcolumnNameAt(uint index)
	{
		return columnNameAt(index);
	}

	private int SwigDirectorMethodcolumnTypeAt(uint index)
	{
		return (int)columnTypeAt(index);
	}

	private int SwigDirectorMethodcolumnIndexAtName([MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		return columnIndexAtName(name);
	}

	private void SwigDirectorMethodappendColumn(int type, [MarshalAs(UnmanagedType.LPWStr)] string colName)
	{
		try
		{
			appendColumn((OdDbDataCell_CellType)type, colName);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodinsertColumnAt(uint index, int type, [MarshalAs(UnmanagedType.LPWStr)] string colName)
	{
		try
		{
			insertColumnAt(index, (OdDbDataCell_CellType)type, colName);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodremoveColumnAt(uint index)
	{
		try
		{
			removeColumnAt(index);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodgetRowAt(uint index, IntPtr outRow)
	{
		try
		{
			getRowAt(index, new OdDbDataCellArray(outRow, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetRowAt__SWIG_0(uint index, IntPtr row, bool bValidate)
	{
		try
		{
			setRowAt(index, new OdDbDataCellArray(row, cMemoryOwn: false), bValidate);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetRowAt__SWIG_1(uint index, IntPtr row)
	{
		try
		{
			setRowAt(index, new OdDbDataCellArray(row, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodappendRow__SWIG_0(IntPtr row, bool bValidate)
	{
		try
		{
			appendRow(new OdDbDataCellArray(row, cMemoryOwn: false), bValidate);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodappendRow__SWIG_1(IntPtr row)
	{
		try
		{
			appendRow(new OdDbDataCellArray(row, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodinsertRowAt__SWIG_0(uint index, IntPtr row, bool bValidate)
	{
		try
		{
			insertRowAt(index, new OdDbDataCellArray(row, cMemoryOwn: false), bValidate);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodinsertRowAt__SWIG_1(uint index, IntPtr row)
	{
		try
		{
			insertRowAt(index, new OdDbDataCellArray(row, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodremoveRowAt(uint index)
	{
		try
		{
			removeRowAt(index);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetCellAt(uint row, uint col)
	{
		return OdDbDataCell.getCPtr(getCellAt(row, col)).Handle;
	}

	private void SwigDirectorMethodsetCellAt(uint row, uint col, IntPtr cell)
	{
		try
		{
			setCellAt(row, col, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataCell>(cell, bOwn: true, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

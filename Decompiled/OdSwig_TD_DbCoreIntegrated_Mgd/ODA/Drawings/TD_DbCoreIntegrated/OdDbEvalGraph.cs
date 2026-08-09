using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbEvalGraph : OdDbObject
{
	public delegate IntPtr SwigDelegateOdDbEvalGraph_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbEvalGraph_1();

	public delegate void SwigDelegateOdDbEvalGraph_2(IntPtr p);

	public delegate int SwigDelegateOdDbEvalGraph_3();

	public delegate bool SwigDelegateOdDbEvalGraph_4();

	public delegate IntPtr SwigDelegateOdDbEvalGraph_5();

	public delegate void SwigDelegateOdDbEvalGraph_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbEvalGraph_7();

	public delegate uint SwigDelegateOdDbEvalGraph_8(IntPtr vd);

	public delegate uint SwigDelegateOdDbEvalGraph_9();

	public delegate void SwigDelegateOdDbEvalGraph_10(IntPtr ownerId);

	public delegate int SwigDelegateOdDbEvalGraph_11(int mode);

	public delegate void SwigDelegateOdDbEvalGraph_12();

	public delegate int SwigDelegateOdDbEvalGraph_13(bool erasing);

	public delegate void SwigDelegateOdDbEvalGraph_14(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbEvalGraph_15(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbEvalGraph_16(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbEvalGraph_17(IntPtr otherId);

	public delegate void SwigDelegateOdDbEvalGraph_18(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbEvalGraph_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbEvalGraph_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbEvalGraph_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbEvalGraph_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbEvalGraph_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbEvalGraph_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbEvalGraph_25(IntPtr pFiler);

	public delegate void SwigDelegateOdDbEvalGraph_26(IntPtr pFiler);

	public delegate int SwigDelegateOdDbEvalGraph_27();

	public delegate IntPtr SwigDelegateOdDbEvalGraph_28([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbEvalGraph_29(IntPtr pRb);

	public delegate void SwigDelegateOdDbEvalGraph_30(IntPtr pFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbEvalGraph_31(IntPtr objId);

	public delegate void SwigDelegateOdDbEvalGraph_32(IntPtr objId);

	public delegate void SwigDelegateOdDbEvalGraph_33(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbEvalGraph_34();

	public delegate void SwigDelegateOdDbEvalGraph_35(IntPtr idPair, IntPtr pOwnerObject, IntPtr idMap);

	public delegate void SwigDelegateOdDbEvalGraph_36(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbEvalGraph_37(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbEvalGraph_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbEvalGraph_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbEvalGraph_40(IntPtr pObject);

	public delegate void SwigDelegateOdDbEvalGraph_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbEvalGraph_42(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbEvalGraph_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbEvalGraph_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbEvalGraph_45(IntPtr pObject);

	public delegate void SwigDelegateOdDbEvalGraph_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbEvalGraph_47(IntPtr objectId);

	public delegate void SwigDelegateOdDbEvalGraph_48(IntPtr pObject);

	public delegate void SwigDelegateOdDbEvalGraph_49(IntPtr pSource);

	public delegate int SwigDelegateOdDbEvalGraph_50(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbEvalGraph_51(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbEvalGraph_52(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbEvalGraph_53(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbEvalGraph_54(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbEvalGraph_55();

	public delegate IntPtr SwigDelegateOdDbEvalGraph_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbEvalGraph_57(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbEvalGraph_58([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbEvalGraph_59(IntPtr pClass);

	public delegate int SwigDelegateOdDbEvalGraph_60(IntPtr pClsid);

	public delegate uint SwigDelegateOdDbEvalGraph_61(IntPtr pNode);

	public delegate bool SwigDelegateOdDbEvalGraph_62(uint nodeId);

	public delegate bool SwigDelegateOdDbEvalGraph_63(IntPtr pNode);

	public delegate void SwigDelegateOdDbEvalGraph_64(IntPtr allNodes);

	public delegate IntPtr SwigDelegateOdDbEvalGraph_65(uint nodeId, int openMode);

	public delegate IntPtr SwigDelegateOdDbEvalGraph_66(uint nodeId);

	public delegate bool SwigDelegateOdDbEvalGraph_67(uint idFrom, uint idTo);

	public delegate bool SwigDelegateOdDbEvalGraph_68(uint idFrom, uint idTo, bool invertible);

	public delegate bool SwigDelegateOdDbEvalGraph_69(uint idFrom, uint idTo);

	public delegate void SwigDelegateOdDbEvalGraph_70(uint nodeId, IntPtr edges);

	public delegate void SwigDelegateOdDbEvalGraph_71(uint nodeId, IntPtr edges);

	public delegate bool SwigDelegateOdDbEvalGraph_72(uint idFrom, uint idTo, IntPtr edgeInfo);

	public delegate void SwigDelegateOdDbEvalGraph_73(IntPtr pGraphToAdd, IntPtr idMap);

	public delegate bool SwigDelegateOdDbEvalGraph_74();

	public delegate bool SwigDelegateOdDbEvalGraph_75(IntPtr pContext);

	public delegate bool SwigDelegateOdDbEvalGraph_76(IntPtr pContext, IntPtr nodesToActivate);

	public delegate bool SwigDelegateOdDbEvalGraph_77(IntPtr activatedNodes);

	public delegate bool SwigDelegateOdDbEvalGraph_78(IntPtr activatedNodes, IntPtr pActiveSubgraph);

	public delegate bool SwigDelegateOdDbEvalGraph_79(IntPtr activatedNodes, IntPtr pActiveSubgraph, IntPtr pCycleNodes);

	public delegate bool SwigDelegateOdDbEvalGraph_80(uint nodeId, bool isActive);

	public delegate bool SwigDelegateOdDbEvalGraph_81(IntPtr pOther);

	public delegate bool SwigDelegateOdDbEvalGraph_82(IntPtr pOther);

	public delegate int SwigDelegateOdDbEvalGraph_83(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbEvalGraph_0 swigDelegate0;

	private SwigDelegateOdDbEvalGraph_1 swigDelegate1;

	private SwigDelegateOdDbEvalGraph_2 swigDelegate2;

	private SwigDelegateOdDbEvalGraph_3 swigDelegate3;

	private SwigDelegateOdDbEvalGraph_4 swigDelegate4;

	private SwigDelegateOdDbEvalGraph_5 swigDelegate5;

	private SwigDelegateOdDbEvalGraph_6 swigDelegate6;

	private SwigDelegateOdDbEvalGraph_7 swigDelegate7;

	private SwigDelegateOdDbEvalGraph_8 swigDelegate8;

	private SwigDelegateOdDbEvalGraph_9 swigDelegate9;

	private SwigDelegateOdDbEvalGraph_10 swigDelegate10;

	private SwigDelegateOdDbEvalGraph_11 swigDelegate11;

	private SwigDelegateOdDbEvalGraph_12 swigDelegate12;

	private SwigDelegateOdDbEvalGraph_13 swigDelegate13;

	private SwigDelegateOdDbEvalGraph_14 swigDelegate14;

	private SwigDelegateOdDbEvalGraph_15 swigDelegate15;

	private SwigDelegateOdDbEvalGraph_16 swigDelegate16;

	private SwigDelegateOdDbEvalGraph_17 swigDelegate17;

	private SwigDelegateOdDbEvalGraph_18 swigDelegate18;

	private SwigDelegateOdDbEvalGraph_19 swigDelegate19;

	private SwigDelegateOdDbEvalGraph_20 swigDelegate20;

	private SwigDelegateOdDbEvalGraph_21 swigDelegate21;

	private SwigDelegateOdDbEvalGraph_22 swigDelegate22;

	private SwigDelegateOdDbEvalGraph_23 swigDelegate23;

	private SwigDelegateOdDbEvalGraph_24 swigDelegate24;

	private SwigDelegateOdDbEvalGraph_25 swigDelegate25;

	private SwigDelegateOdDbEvalGraph_26 swigDelegate26;

	private SwigDelegateOdDbEvalGraph_27 swigDelegate27;

	private SwigDelegateOdDbEvalGraph_28 swigDelegate28;

	private SwigDelegateOdDbEvalGraph_29 swigDelegate29;

	private SwigDelegateOdDbEvalGraph_30 swigDelegate30;

	private SwigDelegateOdDbEvalGraph_31 swigDelegate31;

	private SwigDelegateOdDbEvalGraph_32 swigDelegate32;

	private SwigDelegateOdDbEvalGraph_33 swigDelegate33;

	private SwigDelegateOdDbEvalGraph_34 swigDelegate34;

	private SwigDelegateOdDbEvalGraph_35 swigDelegate35;

	private SwigDelegateOdDbEvalGraph_36 swigDelegate36;

	private SwigDelegateOdDbEvalGraph_37 swigDelegate37;

	private SwigDelegateOdDbEvalGraph_38 swigDelegate38;

	private SwigDelegateOdDbEvalGraph_39 swigDelegate39;

	private SwigDelegateOdDbEvalGraph_40 swigDelegate40;

	private SwigDelegateOdDbEvalGraph_41 swigDelegate41;

	private SwigDelegateOdDbEvalGraph_42 swigDelegate42;

	private SwigDelegateOdDbEvalGraph_43 swigDelegate43;

	private SwigDelegateOdDbEvalGraph_44 swigDelegate44;

	private SwigDelegateOdDbEvalGraph_45 swigDelegate45;

	private SwigDelegateOdDbEvalGraph_46 swigDelegate46;

	private SwigDelegateOdDbEvalGraph_47 swigDelegate47;

	private SwigDelegateOdDbEvalGraph_48 swigDelegate48;

	private SwigDelegateOdDbEvalGraph_49 swigDelegate49;

	private SwigDelegateOdDbEvalGraph_50 swigDelegate50;

	private SwigDelegateOdDbEvalGraph_51 swigDelegate51;

	private SwigDelegateOdDbEvalGraph_52 swigDelegate52;

	private SwigDelegateOdDbEvalGraph_53 swigDelegate53;

	private SwigDelegateOdDbEvalGraph_54 swigDelegate54;

	private SwigDelegateOdDbEvalGraph_55 swigDelegate55;

	private SwigDelegateOdDbEvalGraph_56 swigDelegate56;

	private SwigDelegateOdDbEvalGraph_57 swigDelegate57;

	private SwigDelegateOdDbEvalGraph_58 swigDelegate58;

	private SwigDelegateOdDbEvalGraph_59 swigDelegate59;

	private SwigDelegateOdDbEvalGraph_60 swigDelegate60;

	private SwigDelegateOdDbEvalGraph_61 swigDelegate61;

	private SwigDelegateOdDbEvalGraph_62 swigDelegate62;

	private SwigDelegateOdDbEvalGraph_63 swigDelegate63;

	private SwigDelegateOdDbEvalGraph_64 swigDelegate64;

	private SwigDelegateOdDbEvalGraph_65 swigDelegate65;

	private SwigDelegateOdDbEvalGraph_66 swigDelegate66;

	private SwigDelegateOdDbEvalGraph_67 swigDelegate67;

	private SwigDelegateOdDbEvalGraph_68 swigDelegate68;

	private SwigDelegateOdDbEvalGraph_69 swigDelegate69;

	private SwigDelegateOdDbEvalGraph_70 swigDelegate70;

	private SwigDelegateOdDbEvalGraph_71 swigDelegate71;

	private SwigDelegateOdDbEvalGraph_72 swigDelegate72;

	private SwigDelegateOdDbEvalGraph_73 swigDelegate73;

	private SwigDelegateOdDbEvalGraph_74 swigDelegate74;

	private SwigDelegateOdDbEvalGraph_75 swigDelegate75;

	private SwigDelegateOdDbEvalGraph_76 swigDelegate76;

	private SwigDelegateOdDbEvalGraph_77 swigDelegate77;

	private SwigDelegateOdDbEvalGraph_78 swigDelegate78;

	private SwigDelegateOdDbEvalGraph_79 swigDelegate79;

	private SwigDelegateOdDbEvalGraph_80 swigDelegate80;

	private SwigDelegateOdDbEvalGraph_81 swigDelegate81;

	private SwigDelegateOdDbEvalGraph_82 swigDelegate82;

	private SwigDelegateOdDbEvalGraph_83 swigDelegate83;

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

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(OdDbEvalExpr) };

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes63 = new Type[1] { typeof(OdDbEvalExpr) };

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(OdDbEvalNodeIdArray) };

	private static Type[] swigMethodTypes65 = new Type[2]
	{
		typeof(uint),
		typeof(OdDb_OpenMode)
	};

	private static Type[] swigMethodTypes66 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes67 = new Type[2]
	{
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes68 = new Type[3]
	{
		typeof(uint),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes69 = new Type[2]
	{
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes70 = new Type[2]
	{
		typeof(uint),
		typeof(OdDbEvalEdgeInfoArray)
	};

	private static Type[] swigMethodTypes71 = new Type[2]
	{
		typeof(uint),
		typeof(OdDbEvalEdgeInfoArray)
	};

	private static Type[] swigMethodTypes72 = new Type[3]
	{
		typeof(uint),
		typeof(uint),
		typeof(OdDbEvalEdgeInfo)
	};

	private static Type[] swigMethodTypes73 = new Type[2]
	{
		typeof(OdDbEvalGraph),
		typeof(OdDbEvalIdMap).MakeByRefType()
	};

	private static Type[] swigMethodTypes74 = new Type[0];

	private static Type[] swigMethodTypes75 = new Type[1] { typeof(OdDbEvalContext) };

	private static Type[] swigMethodTypes76 = new Type[2]
	{
		typeof(OdDbEvalContext),
		typeof(OdDbEvalNodeIdArray)
	};

	private static Type[] swigMethodTypes77 = new Type[1] { typeof(OdDbEvalNodeIdArray) };

	private static Type[] swigMethodTypes78 = new Type[2]
	{
		typeof(OdDbEvalNodeIdArray),
		typeof(OdDbEvalNodeIdArray)
	};

	private static Type[] swigMethodTypes79 = new Type[3]
	{
		typeof(OdDbEvalNodeIdArray),
		typeof(OdDbEvalNodeIdArray),
		typeof(OdDbEvalNodeIdArray)
	};

	private static Type[] swigMethodTypes80 = new Type[2]
	{
		typeof(uint),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes81 = new Type[1] { typeof(OdDbEvalGraph) };

	private static Type[] swigMethodTypes82 = new Type[1] { typeof(OdDbEvalGraph) };

	private static Type[] swigMethodTypes83 = new Type[1] { typeof(OdDbDatabase) };

	public const uint kNullNodeId = 0u;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbEvalGraph(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbEvalGraph obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbEvalGraph(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbEvalGraph cast(OdRxObject pObj)
	{
		OdDbEvalGraph rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalGraph>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_isASwigExplicitOdDbEvalGraph(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_queryXSwigExplicitOdDbEvalGraph(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbEvalGraph()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbEvalGraph(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbEvalGraph) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public static bool hasGraph(OdDbObject pObj, string key)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_hasGraph(OdDbObject.getCPtr(pObj), key);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbEvalGraph getGraph(OdDbObject pObj, string pKey, OdDb_OpenMode openMode)
	{
		OdDbEvalGraph rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalGraph>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getGraph__SWIG_0(OdDbObject.getCPtr(pObj), pKey, (int)openMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEvalGraph getGraph(OdDbObject pObj, string pKey)
	{
		OdDbEvalGraph rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalGraph>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getGraph__SWIG_1(OdDbObject.getCPtr(pObj), pKey), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static bool createGraph(OdDbObject pObj, string key)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_createGraph(OdDbObject.getCPtr(pObj), key);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool removeGraph(OdDbObject pObj, string pKey)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_removeGraph(OdDbObject.getCPtr(pObj), pKey);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint addNode(OdDbEvalExpr pNode)
	{
		uint result = (SwigDerivedClassHasMethod("addNode", swigMethodTypes61) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_addNodeSwigExplicitOdDbEvalGraph(swigCPtr, OdDbEvalExpr.getCPtr(pNode)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_addNode(swigCPtr, OdDbEvalExpr.getCPtr(pNode)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool removeNode(uint nodeId)
	{
		bool result = (SwigDerivedClassHasMethod("removeNode", swigMethodTypes62) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_removeNodeSwigExplicitOdDbEvalGraph__SWIG_0(swigCPtr, nodeId) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_removeNode__SWIG_0(swigCPtr, nodeId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool removeNode(OdDbEvalExpr pNode)
	{
		bool result = (SwigDerivedClassHasMethod("removeNode", swigMethodTypes63) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_removeNodeSwigExplicitOdDbEvalGraph__SWIG_1(swigCPtr, OdDbEvalExpr.getCPtr(pNode)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_removeNode__SWIG_1(swigCPtr, OdDbEvalExpr.getCPtr(pNode)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getAllNodes(OdDbEvalNodeIdArray allNodes)
	{
		if (SwigDerivedClassHasMethod("getAllNodes", swigMethodTypes64))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getAllNodesSwigExplicitOdDbEvalGraph(swigCPtr, OdDbEvalNodeIdArray.getCPtr(allNodes));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getAllNodes(swigCPtr, OdDbEvalNodeIdArray.getCPtr(allNodes));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbEvalExpr getNode(uint nodeId, OdDb_OpenMode openMode)
	{
		OdDbEvalExpr rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalExpr>(SwigDerivedClassHasMethod("getNode", swigMethodTypes65) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getNodeSwigExplicitOdDbEvalGraph__SWIG_0(swigCPtr, nodeId, (int)openMode) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getNode__SWIG_0(swigCPtr, nodeId, (int)openMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbEvalExpr getNode(uint nodeId)
	{
		OdDbEvalExpr rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalExpr>(SwigDerivedClassHasMethod("getNode", swigMethodTypes66) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getNodeSwigExplicitOdDbEvalGraph__SWIG_1(swigCPtr, nodeId) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getNode__SWIG_1(swigCPtr, nodeId), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool addEdge(uint idFrom, uint idTo)
	{
		bool result = (SwigDerivedClassHasMethod("addEdge", swigMethodTypes67) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_addEdgeSwigExplicitOdDbEvalGraph__SWIG_0(swigCPtr, idFrom, idTo) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_addEdge__SWIG_0(swigCPtr, idFrom, idTo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool addEdge(uint idFrom, uint idTo, bool invertible)
	{
		bool result = (SwigDerivedClassHasMethod("addEdge", swigMethodTypes68) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_addEdgeSwigExplicitOdDbEvalGraph__SWIG_1(swigCPtr, idFrom, idTo, invertible) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_addEdge__SWIG_1(swigCPtr, idFrom, idTo, invertible));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool removeEdge(uint idFrom, uint idTo)
	{
		bool result = (SwigDerivedClassHasMethod("removeEdge", swigMethodTypes69) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_removeEdgeSwigExplicitOdDbEvalGraph(swigCPtr, idFrom, idTo) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_removeEdge(swigCPtr, idFrom, idTo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getIncomingEdges(uint nodeId, OdDbEvalEdgeInfoArray edges)
	{
		if (SwigDerivedClassHasMethod("getIncomingEdges", swigMethodTypes70))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getIncomingEdgesSwigExplicitOdDbEvalGraph(swigCPtr, nodeId, OdDbEvalEdgeInfoArray.getCPtr(edges));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getIncomingEdges(swigCPtr, nodeId, OdDbEvalEdgeInfoArray.getCPtr(edges));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getOutgoingEdges(uint nodeId, OdDbEvalEdgeInfoArray edges)
	{
		if (SwigDerivedClassHasMethod("getOutgoingEdges", swigMethodTypes71))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getOutgoingEdgesSwigExplicitOdDbEvalGraph(swigCPtr, nodeId, OdDbEvalEdgeInfoArray.getCPtr(edges));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getOutgoingEdges(swigCPtr, nodeId, OdDbEvalEdgeInfoArray.getCPtr(edges));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getEdgeInfo(uint idFrom, uint idTo, OdDbEvalEdgeInfo edgeInfo)
	{
		bool result = (SwigDerivedClassHasMethod("getEdgeInfo", swigMethodTypes72) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getEdgeInfoSwigExplicitOdDbEvalGraph(swigCPtr, idFrom, idTo, OdDbEvalEdgeInfo.getCPtr(edgeInfo)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getEdgeInfo(swigCPtr, idFrom, idTo, OdDbEvalEdgeInfo.getCPtr(edgeInfo)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void addGraph(OdDbEvalGraph pGraphToAdd, ref OdDbEvalIdMap idMap)
	{
		IntPtr jarg = OdDbEvalIdMap.getCPtr(idMap).Handle;
		try
		{
			if (SwigDerivedClassHasMethod("addGraph", swigMethodTypes73))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_addGraphSwigExplicitOdDbEvalGraph(swigCPtr, getCPtr(pGraphToAdd), ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_addGraph(swigCPtr, getCPtr(pGraphToAdd), ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (OdDbEvalIdMap.getCPtr(idMap).Handle != jarg)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdDbEvalIdMap>(typeof(OdDbEvalIdMap), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}

	public virtual bool evaluate()
	{
		bool result = (SwigDerivedClassHasMethod("evaluate", swigMethodTypes74) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_evaluateSwigExplicitOdDbEvalGraph__SWIG_0(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_evaluate__SWIG_0(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool evaluate(OdDbEvalContext pContext)
	{
		bool result = (SwigDerivedClassHasMethod("evaluate", swigMethodTypes75) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_evaluateSwigExplicitOdDbEvalGraph__SWIG_1(swigCPtr, OdDbEvalContext.getCPtr(pContext)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_evaluate__SWIG_1(swigCPtr, OdDbEvalContext.getCPtr(pContext)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool evaluate(OdDbEvalContext pContext, OdDbEvalNodeIdArray nodesToActivate)
	{
		bool result = (SwigDerivedClassHasMethod("evaluate", swigMethodTypes76) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_evaluateSwigExplicitOdDbEvalGraph__SWIG_2(swigCPtr, OdDbEvalContext.getCPtr(pContext), OdDbEvalNodeIdArray.getCPtr(nodesToActivate)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_evaluate__SWIG_2(swigCPtr, OdDbEvalContext.getCPtr(pContext), OdDbEvalNodeIdArray.getCPtr(nodesToActivate)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool activate(OdDbEvalNodeIdArray activatedNodes)
	{
		bool result = (SwigDerivedClassHasMethod("activate", swigMethodTypes77) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_activateSwigExplicitOdDbEvalGraph__SWIG_0(swigCPtr, OdDbEvalNodeIdArray.getCPtr(activatedNodes)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_activate__SWIG_0(swigCPtr, OdDbEvalNodeIdArray.getCPtr(activatedNodes)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool activate(OdDbEvalNodeIdArray activatedNodes, OdDbEvalNodeIdArray pActiveSubgraph)
	{
		bool result = (SwigDerivedClassHasMethod("activate", swigMethodTypes78) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_activateSwigExplicitOdDbEvalGraph__SWIG_1(swigCPtr, OdDbEvalNodeIdArray.getCPtr(activatedNodes), OdDbEvalNodeIdArray.getCPtr(pActiveSubgraph)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_activate__SWIG_1(swigCPtr, OdDbEvalNodeIdArray.getCPtr(activatedNodes), OdDbEvalNodeIdArray.getCPtr(pActiveSubgraph)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool activate(OdDbEvalNodeIdArray activatedNodes, OdDbEvalNodeIdArray pActiveSubgraph, OdDbEvalNodeIdArray pCycleNodes)
	{
		bool result = (SwigDerivedClassHasMethod("activate", swigMethodTypes79) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_activateSwigExplicitOdDbEvalGraph__SWIG_2(swigCPtr, OdDbEvalNodeIdArray.getCPtr(activatedNodes), OdDbEvalNodeIdArray.getCPtr(pActiveSubgraph), OdDbEvalNodeIdArray.getCPtr(pCycleNodes)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_activate__SWIG_2(swigCPtr, OdDbEvalNodeIdArray.getCPtr(activatedNodes), OdDbEvalNodeIdArray.getCPtr(pActiveSubgraph), OdDbEvalNodeIdArray.getCPtr(pCycleNodes)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getIsActive(uint nodeId, out bool isActive)
	{
		bool result = (SwigDerivedClassHasMethod("getIsActive", swigMethodTypes80) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getIsActiveSwigExplicitOdDbEvalGraph(swigCPtr, nodeId, out isActive) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getIsActive(swigCPtr, nodeId, out isActive));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool equals(OdDbEvalGraph pOther)
	{
		bool result = (SwigDerivedClassHasMethod("equals", swigMethodTypes81) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_equalsSwigExplicitOdDbEvalGraph(swigCPtr, getCPtr(pOther)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_equals(swigCPtr, getCPtr(pOther)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isSubgraphOf(OdDbEvalGraph pOther)
	{
		bool result = (SwigDerivedClassHasMethod("isSubgraphOf", swigMethodTypes82) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_isSubgraphOfSwigExplicitOdDbEvalGraph(swigCPtr, getCPtr(pOther)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_isSubgraphOf(swigCPtr, getCPtr(pOther)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_dwgInFieldsSwigExplicitOdDbEvalGraph(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_dwgOutFieldsSwigExplicitOdDbEvalGraph(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_dxfInFieldsSwigExplicitOdDbEvalGraph(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_dxfOutFieldsSwigExplicitOdDbEvalGraph(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void applyPartialUndo(OdDbDwgFiler pFiler, OdRxClass pClassObj)
	{
		if (SwigDerivedClassHasMethod("applyPartialUndo", swigMethodTypes30))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_applyPartialUndoSwigExplicitOdDbEvalGraph(swigCPtr, OdDbDwgFiler.getCPtr(pFiler), OdRxClass.getCPtr(pClassObj));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_applyPartialUndo(swigCPtr, OdDbDwgFiler.getCPtr(pFiler), OdRxClass.getCPtr(pClassObj));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void copyFrom(OdRxObject p)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_copyFromSwigExplicitOdDbEvalGraph(swigCPtr, OdRxObject.getCPtr(p));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_copyFrom(swigCPtr, OdRxObject.getCPtr(p));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult postInDatabase(OdDbDatabase arg0)
	{
		int result = (SwigDerivedClassHasMethod("postInDatabase", swigMethodTypes83) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_postInDatabaseSwigExplicitOdDbEvalGraph(swigCPtr, OdDbDatabase.getCPtr(arg0)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_postInDatabase(swigCPtr, OdDbDatabase.getCPtr(arg0)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void subHandOverTo(OdDbObject pNewObject)
	{
		if (SwigDerivedClassHasMethod("subHandOverTo", swigMethodTypes14))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_subHandOverToSwigExplicitOdDbEvalGraph(swigCPtr, OdDbObject.getCPtr(pNewObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_subHandOverTo(swigCPtr, OdDbObject.getCPtr(pNewObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbEvalGraph createObject()
	{
		OdDbEvalGraph rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalGraph>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("addNode", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodaddNode;
		}
		if (SwigDerivedClassHasMethod("removeNode", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodremoveNode__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("removeNode", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodremoveNode__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getAllNodes", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodgetAllNodes;
		}
		if (SwigDerivedClassHasMethod("getNode", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodgetNode__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getNode", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodgetNode__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("addEdge", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodaddEdge__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("addEdge", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodaddEdge__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("removeEdge", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodremoveEdge;
		}
		if (SwigDerivedClassHasMethod("getIncomingEdges", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodgetIncomingEdges;
		}
		if (SwigDerivedClassHasMethod("getOutgoingEdges", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodgetOutgoingEdges;
		}
		if (SwigDerivedClassHasMethod("getEdgeInfo", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodgetEdgeInfo;
		}
		if (SwigDerivedClassHasMethod("addGraph", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodaddGraph;
		}
		if (SwigDerivedClassHasMethod("evaluate", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodevaluate__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("evaluate", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodevaluate__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("evaluate", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodevaluate__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("activate", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodactivate__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("activate", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodactivate__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("activate", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodactivate__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getIsActive", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodgetIsActive;
		}
		if (SwigDerivedClassHasMethod("equals", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodequals;
		}
		if (SwigDerivedClassHasMethod("isSubgraphOf", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodisSubgraphOf;
		}
		if (SwigDerivedClassHasMethod("postInDatabase", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodpostInDatabase;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalGraph_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbEvalGraph));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr p)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(p, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

	private void SwigDirectorMethodapplyPartialUndo(IntPtr pFiler, IntPtr pClassObj)
	{
		try
		{
			applyPartialUndo(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(pFiler, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(pClassObj, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

	private uint SwigDirectorMethodaddNode(IntPtr pNode)
	{
		return addNode(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalExpr>(pNode, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodremoveNode__SWIG_0(uint nodeId)
	{
		return removeNode(nodeId);
	}

	private bool SwigDirectorMethodremoveNode__SWIG_1(IntPtr pNode)
	{
		return removeNode(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalExpr>(pNode, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodgetAllNodes(IntPtr allNodes)
	{
		try
		{
			getAllNodes(new OdDbEvalNodeIdArray(allNodes, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetNode__SWIG_0(uint nodeId, int openMode)
	{
		return OdDbEvalExpr.getCPtr(getNode(nodeId, (OdDb_OpenMode)openMode)).Handle;
	}

	private IntPtr SwigDirectorMethodgetNode__SWIG_1(uint nodeId)
	{
		return OdDbEvalExpr.getCPtr(getNode(nodeId)).Handle;
	}

	private bool SwigDirectorMethodaddEdge__SWIG_0(uint idFrom, uint idTo)
	{
		return addEdge(idFrom, idTo);
	}

	private bool SwigDirectorMethodaddEdge__SWIG_1(uint idFrom, uint idTo, bool invertible)
	{
		return addEdge(idFrom, idTo, invertible);
	}

	private bool SwigDirectorMethodremoveEdge(uint idFrom, uint idTo)
	{
		return removeEdge(idFrom, idTo);
	}

	private void SwigDirectorMethodgetIncomingEdges(uint nodeId, IntPtr edges)
	{
		try
		{
			getIncomingEdges(nodeId, new OdDbEvalEdgeInfoArray(edges, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodgetOutgoingEdges(uint nodeId, IntPtr edges)
	{
		try
		{
			getOutgoingEdges(nodeId, new OdDbEvalEdgeInfoArray(edges, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodgetEdgeInfo(uint idFrom, uint idTo, IntPtr edgeInfo)
	{
		return getEdgeInfo(idFrom, idTo, new OdDbEvalEdgeInfo(edgeInfo, cMemoryOwn: false));
	}

	private void SwigDirectorMethodaddGraph(IntPtr pGraphToAdd, IntPtr idMap)
	{
		OdDbEvalIdMap idMap2 = new OdDbEvalIdMap(idMap, cMemoryOwn: true);
		try
		{
			addGraph(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalGraph>(pGraphToAdd, bOwn: false, bTryAddToTransaction: false), ref idMap2);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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
			idMap = OdDbEvalIdMap.getCPtr(idMap2).Handle;
		}
	}

	private bool SwigDirectorMethodevaluate__SWIG_0()
	{
		return evaluate();
	}

	private bool SwigDirectorMethodevaluate__SWIG_1(IntPtr pContext)
	{
		return evaluate(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalContext>(pContext, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodevaluate__SWIG_2(IntPtr pContext, IntPtr nodesToActivate)
	{
		return evaluate(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalContext>(pContext, bOwn: false, bTryAddToTransaction: false), new OdDbEvalNodeIdArray(nodesToActivate, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodactivate__SWIG_0(IntPtr activatedNodes)
	{
		return activate(new OdDbEvalNodeIdArray(activatedNodes, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodactivate__SWIG_1(IntPtr activatedNodes, IntPtr pActiveSubgraph)
	{
		return activate(new OdDbEvalNodeIdArray(activatedNodes, cMemoryOwn: false), new OdDbEvalNodeIdArray(pActiveSubgraph, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodactivate__SWIG_2(IntPtr activatedNodes, IntPtr pActiveSubgraph, IntPtr pCycleNodes)
	{
		return activate(new OdDbEvalNodeIdArray(activatedNodes, cMemoryOwn: false), new OdDbEvalNodeIdArray(pActiveSubgraph, cMemoryOwn: false), new OdDbEvalNodeIdArray(pCycleNodes, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodgetIsActive(uint nodeId, bool isActive)
	{
		return getIsActive(nodeId, out isActive);
	}

	private bool SwigDirectorMethodequals(IntPtr pOther)
	{
		return equals(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalGraph>(pOther, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisSubgraphOf(IntPtr pOther)
	{
		return isSubgraphOf(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalGraph>(pOther, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodpostInDatabase(IntPtr arg0)
	{
		return (int)postInDatabase(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(arg0, bOwn: false, bTryAddToTransaction: false));
	}
}

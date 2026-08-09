using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDetailViewStyle : OdDbModelDocViewStyle
{
	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_1();

	public delegate void SwigDelegateOdDbDetailViewStyle_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbDetailViewStyle_3();

	public delegate bool SwigDelegateOdDbDetailViewStyle_4();

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_5();

	public delegate void SwigDelegateOdDbDetailViewStyle_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_7();

	public delegate uint SwigDelegateOdDbDetailViewStyle_8(IntPtr vd);

	public delegate uint SwigDelegateOdDbDetailViewStyle_9();

	public delegate void SwigDelegateOdDbDetailViewStyle_10(IntPtr ownerId);

	public delegate void SwigDelegateOdDbDetailViewStyle_11();

	public delegate int SwigDelegateOdDbDetailViewStyle_12(bool erasing);

	public delegate void SwigDelegateOdDbDetailViewStyle_13(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbDetailViewStyle_14(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbDetailViewStyle_15(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbDetailViewStyle_16(IntPtr otherId);

	public delegate void SwigDelegateOdDbDetailViewStyle_17(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbDetailViewStyle_18(IntPtr pFiler);

	public delegate void SwigDelegateOdDbDetailViewStyle_19(IntPtr pFiler);

	public delegate int SwigDelegateOdDbDetailViewStyle_20(IntPtr pFiler);

	public delegate void SwigDelegateOdDbDetailViewStyle_21(IntPtr pFiler);

	public delegate int SwigDelegateOdDbDetailViewStyle_22();

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_23([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbDetailViewStyle_24(IntPtr pRb);

	public delegate void SwigDelegateOdDbDetailViewStyle_25(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbDetailViewStyle_26(IntPtr objId);

	public delegate void SwigDelegateOdDbDetailViewStyle_27(IntPtr objId);

	public delegate void SwigDelegateOdDbDetailViewStyle_28(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbDetailViewStyle_29();

	public delegate void SwigDelegateOdDbDetailViewStyle_30(IntPtr idPair, IntPtr pOwnerObject, IntPtr idMap);

	public delegate void SwigDelegateOdDbDetailViewStyle_31(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbDetailViewStyle_32(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbDetailViewStyle_33(IntPtr pObject);

	public delegate void SwigDelegateOdDbDetailViewStyle_34(IntPtr pObject);

	public delegate void SwigDelegateOdDbDetailViewStyle_35(IntPtr pObject);

	public delegate void SwigDelegateOdDbDetailViewStyle_36(IntPtr pObject);

	public delegate void SwigDelegateOdDbDetailViewStyle_37(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbDetailViewStyle_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbDetailViewStyle_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbDetailViewStyle_40(IntPtr pObject);

	public delegate void SwigDelegateOdDbDetailViewStyle_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbDetailViewStyle_42(IntPtr objectId);

	public delegate void SwigDelegateOdDbDetailViewStyle_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbDetailViewStyle_44(IntPtr pSource);

	public delegate int SwigDelegateOdDbDetailViewStyle_45(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbDetailViewStyle_46(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_47(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_48(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbDetailViewStyle_49(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_50();

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_51([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbDetailViewStyle_52(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_53([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_54(IntPtr pClass);

	public delegate int SwigDelegateOdDbDetailViewStyle_55(IntPtr pClsid);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDetailViewStyle_56();

	public delegate void SwigDelegateOdDbDetailViewStyle_57([MarshalAs(UnmanagedType.LPWStr)] string name);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDetailViewStyle_58();

	public delegate void SwigDelegateOdDbDetailViewStyle_59([MarshalAs(UnmanagedType.LPWStr)] string description);

	public delegate void SwigDelegateOdDbDetailViewStyle_60(IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_61(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string styleName);

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_62();

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_63();

	public delegate double SwigDelegateOdDbDetailViewStyle_64();

	public delegate double SwigDelegateOdDbDetailViewStyle_65();

	public delegate int SwigDelegateOdDbDetailViewStyle_66();

	public delegate int SwigDelegateOdDbDetailViewStyle_67();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDetailViewStyle_68();

	public delegate IntPtr SwigDelegateOdDbDetailViewStyle_69(IntPtr idMap, IntPtr pOwner);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbDetailViewStyle_0 swigDelegate0;

	private SwigDelegateOdDbDetailViewStyle_1 swigDelegate1;

	private SwigDelegateOdDbDetailViewStyle_2 swigDelegate2;

	private SwigDelegateOdDbDetailViewStyle_3 swigDelegate3;

	private SwigDelegateOdDbDetailViewStyle_4 swigDelegate4;

	private SwigDelegateOdDbDetailViewStyle_5 swigDelegate5;

	private SwigDelegateOdDbDetailViewStyle_6 swigDelegate6;

	private SwigDelegateOdDbDetailViewStyle_7 swigDelegate7;

	private SwigDelegateOdDbDetailViewStyle_8 swigDelegate8;

	private SwigDelegateOdDbDetailViewStyle_9 swigDelegate9;

	private SwigDelegateOdDbDetailViewStyle_10 swigDelegate10;

	private SwigDelegateOdDbDetailViewStyle_11 swigDelegate11;

	private SwigDelegateOdDbDetailViewStyle_12 swigDelegate12;

	private SwigDelegateOdDbDetailViewStyle_13 swigDelegate13;

	private SwigDelegateOdDbDetailViewStyle_14 swigDelegate14;

	private SwigDelegateOdDbDetailViewStyle_15 swigDelegate15;

	private SwigDelegateOdDbDetailViewStyle_16 swigDelegate16;

	private SwigDelegateOdDbDetailViewStyle_17 swigDelegate17;

	private SwigDelegateOdDbDetailViewStyle_18 swigDelegate18;

	private SwigDelegateOdDbDetailViewStyle_19 swigDelegate19;

	private SwigDelegateOdDbDetailViewStyle_20 swigDelegate20;

	private SwigDelegateOdDbDetailViewStyle_21 swigDelegate21;

	private SwigDelegateOdDbDetailViewStyle_22 swigDelegate22;

	private SwigDelegateOdDbDetailViewStyle_23 swigDelegate23;

	private SwigDelegateOdDbDetailViewStyle_24 swigDelegate24;

	private SwigDelegateOdDbDetailViewStyle_25 swigDelegate25;

	private SwigDelegateOdDbDetailViewStyle_26 swigDelegate26;

	private SwigDelegateOdDbDetailViewStyle_27 swigDelegate27;

	private SwigDelegateOdDbDetailViewStyle_28 swigDelegate28;

	private SwigDelegateOdDbDetailViewStyle_29 swigDelegate29;

	private SwigDelegateOdDbDetailViewStyle_30 swigDelegate30;

	private SwigDelegateOdDbDetailViewStyle_31 swigDelegate31;

	private SwigDelegateOdDbDetailViewStyle_32 swigDelegate32;

	private SwigDelegateOdDbDetailViewStyle_33 swigDelegate33;

	private SwigDelegateOdDbDetailViewStyle_34 swigDelegate34;

	private SwigDelegateOdDbDetailViewStyle_35 swigDelegate35;

	private SwigDelegateOdDbDetailViewStyle_36 swigDelegate36;

	private SwigDelegateOdDbDetailViewStyle_37 swigDelegate37;

	private SwigDelegateOdDbDetailViewStyle_38 swigDelegate38;

	private SwigDelegateOdDbDetailViewStyle_39 swigDelegate39;

	private SwigDelegateOdDbDetailViewStyle_40 swigDelegate40;

	private SwigDelegateOdDbDetailViewStyle_41 swigDelegate41;

	private SwigDelegateOdDbDetailViewStyle_42 swigDelegate42;

	private SwigDelegateOdDbDetailViewStyle_43 swigDelegate43;

	private SwigDelegateOdDbDetailViewStyle_44 swigDelegate44;

	private SwigDelegateOdDbDetailViewStyle_45 swigDelegate45;

	private SwigDelegateOdDbDetailViewStyle_46 swigDelegate46;

	private SwigDelegateOdDbDetailViewStyle_47 swigDelegate47;

	private SwigDelegateOdDbDetailViewStyle_48 swigDelegate48;

	private SwigDelegateOdDbDetailViewStyle_49 swigDelegate49;

	private SwigDelegateOdDbDetailViewStyle_50 swigDelegate50;

	private SwigDelegateOdDbDetailViewStyle_51 swigDelegate51;

	private SwigDelegateOdDbDetailViewStyle_52 swigDelegate52;

	private SwigDelegateOdDbDetailViewStyle_53 swigDelegate53;

	private SwigDelegateOdDbDetailViewStyle_54 swigDelegate54;

	private SwigDelegateOdDbDetailViewStyle_55 swigDelegate55;

	private SwigDelegateOdDbDetailViewStyle_56 swigDelegate56;

	private SwigDelegateOdDbDetailViewStyle_57 swigDelegate57;

	private SwigDelegateOdDbDetailViewStyle_58 swigDelegate58;

	private SwigDelegateOdDbDetailViewStyle_59 swigDelegate59;

	private SwigDelegateOdDbDetailViewStyle_60 swigDelegate60;

	private SwigDelegateOdDbDetailViewStyle_61 swigDelegate61;

	private SwigDelegateOdDbDetailViewStyle_62 swigDelegate62;

	private SwigDelegateOdDbDetailViewStyle_63 swigDelegate63;

	private SwigDelegateOdDbDetailViewStyle_64 swigDelegate64;

	private SwigDelegateOdDbDetailViewStyle_65 swigDelegate65;

	private SwigDelegateOdDbDetailViewStyle_66 swigDelegate66;

	private SwigDelegateOdDbDetailViewStyle_67 swigDelegate67;

	private SwigDelegateOdDbDetailViewStyle_68 swigDelegate68;

	private SwigDelegateOdDbDetailViewStyle_69 swigDelegate69;

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

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes14 = new Type[3]
	{
		typeof(OdDbObjectId),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdDbAuditInfo) };

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdResBuf) };

	private static Type[] swigMethodTypes25 = new Type[2]
	{
		typeof(OdDbDwgFiler),
		typeof(OdRxClass)
	};

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[3]
	{
		typeof(OdDbIdPair),
		typeof(OdDbObject),
		typeof(OdDbIdMapping).MakeByRefType()
	};

	private static Type[] swigMethodTypes31 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes32 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes34 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes35 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes37 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes39 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes45 = new Type[2]
	{
		typeof(OdDbFiler),
		typeof(MaintReleaseVer).MakeByRefType()
	};

	private static Type[] swigMethodTypes46 = new Type[1] { typeof(OdDbFiler) };

	private static Type[] swigMethodTypes47 = new Type[3]
	{
		typeof(DwgVersion),
		typeof(OdDbObjectId),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes48 = new Type[4]
	{
		typeof(OdDb_SaveType),
		typeof(DwgVersion),
		typeof(OdDbObjectId),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes49 = new Type[3]
	{
		typeof(OdDb_SaveType),
		typeof(DwgVersion),
		typeof(OdDbAuditInfo)
	};

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[2]
	{
		typeof(string),
		typeof(OdDbField)
	};

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes54 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes56 = new Type[0];

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes58 = new Type[0];

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes61 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(string)
	};

	private static Type[] swigMethodTypes62 = new Type[0];

	private static Type[] swigMethodTypes63 = new Type[0];

	private static Type[] swigMethodTypes64 = new Type[0];

	private static Type[] swigMethodTypes65 = new Type[0];

	private static Type[] swigMethodTypes66 = new Type[0];

	private static Type[] swigMethodTypes67 = new Type[0];

	private static Type[] swigMethodTypes68 = new Type[0];

	private static Type[] swigMethodTypes69 = new Type[2]
	{
		typeof(OdDbIdMapping).MakeByRefType(),
		typeof(OdDbObject)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDetailViewStyle(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDetailViewStyle obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDetailViewStyle(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbDetailViewStyle cast(OdRxObject pObj)
	{
		OdDbDetailViewStyle rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDetailViewStyle>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_isASwigExplicitOdDbDetailViewStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_queryXSwigExplicitOdDbDetailViewStyle(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbDetailViewStyle createObject()
	{
		OdDbDetailViewStyle rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDetailViewStyle>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObjectId identifierStyleId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_identifierStyleId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setIdentifierStyleId(OdDbObjectId objId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setIdentifierStyleId(swigCPtr, OdDbObjectId.getCPtr(objId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdCmColor identifierColor()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_identifierColor(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setIdentifierColor(OdCmColor color)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setIdentifierColor(swigCPtr, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public double identifierHeight()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_identifierHeight(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setIdentifierHeight(double height)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setIdentifierHeight(swigCPtr, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public double identifierOffset()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_identifierOffset(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setIdentifierOffset(double offset)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setIdentifierOffset(swigCPtr, offset);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDbDetailViewStyle_IdentifierPlacement identifierPlacement()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_identifierPlacement(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbDetailViewStyle_IdentifierPlacement)result;
	}

	public OdResult setIdentifierPlacement(OdDbDetailViewStyle_IdentifierPlacement placement)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setIdentifierPlacement(swigCPtr, (int)placement);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDbObjectId arrowSymbolId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_arrowSymbolId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setArrowSymbolId(OdDbObjectId arrowSymbolId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setArrowSymbolId(swigCPtr, OdDbObjectId.getCPtr(arrowSymbolId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdCmColor arrowSymbolColor()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_arrowSymbolColor(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setArrowSymbolColor(OdCmColor color)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setArrowSymbolColor(swigCPtr, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public double arrowSymbolSize()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_arrowSymbolSize(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setArrowSymbolSize(double size)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setArrowSymbolSize(swigCPtr, size);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public bool showArrows()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_showArrows(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setShowArrows(bool bValue)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setShowArrows(swigCPtr, bValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public LineWeight boundaryLineWeight()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_boundaryLineWeight(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public OdResult setBoundaryLineWeight(LineWeight lineweight)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setBoundaryLineWeight(swigCPtr, (int)lineweight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdCmColor boundaryLineColor()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_boundaryLineColor(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setBoundaryLineColor(OdCmColor color)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setBoundaryLineColor(swigCPtr, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDbObjectId boundaryLineTypeId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_boundaryLineTypeId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setBoundaryLineTypeId(OdDbObjectId objId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setBoundaryLineTypeId(swigCPtr, OdDbObjectId.getCPtr(objId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public LineWeight connectionLineWeight()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_connectionLineWeight(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public OdResult setConnectionLineWeight(LineWeight lineweight)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setConnectionLineWeight(swigCPtr, (int)lineweight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdCmColor connectionLineColor()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_connectionLineColor(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setConnectionLineColor(OdCmColor color)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setConnectionLineColor(swigCPtr, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDbObjectId connectionLineTypeId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_connectionLineTypeId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setConnectionLineTypeId(OdDbObjectId objId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setConnectionLineTypeId(swigCPtr, OdDbObjectId.getCPtr(objId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdDbObjectId viewLabelTextStyleId()
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("viewLabelTextStyleId", swigMethodTypes62) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelTextStyleIdSwigExplicitOdDbDetailViewStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelTextStyleId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setViewLabelTextStyleId(OdDbObjectId objId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setViewLabelTextStyleId(swigCPtr, OdDbObjectId.getCPtr(objId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdCmColor viewLabelTextColor()
	{
		OdCmColor result = new OdCmColor(SwigDerivedClassHasMethod("viewLabelTextColor", swigMethodTypes63) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelTextColorSwigExplicitOdDbDetailViewStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelTextColor(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setViewLabelTextColor(OdCmColor color)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setViewLabelTextColor(swigCPtr, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override double viewLabelTextHeight()
	{
		double result = (SwigDerivedClassHasMethod("viewLabelTextHeight", swigMethodTypes64) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelTextHeightSwigExplicitOdDbDetailViewStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelTextHeight(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setViewLabelTextHeight(double height)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setViewLabelTextHeight(swigCPtr, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override double viewLabelOffset()
	{
		double result = (SwigDerivedClassHasMethod("viewLabelOffset", swigMethodTypes65) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelOffsetSwigExplicitOdDbDetailViewStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelOffset(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setViewLabelOffset(double offset)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setViewLabelOffset(swigCPtr, offset);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public new virtual OdDbModelDocViewStyle_AttachmentPoint viewLabelAttachment()
	{
		int result = (SwigDerivedClassHasMethod("viewLabelAttachment", swigMethodTypes66) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelAttachmentSwigExplicitOdDbDetailViewStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelAttachment(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbModelDocViewStyle_AttachmentPoint)result;
	}

	public OdResult setViewLabelAttachment(OdDbModelDocViewStyle_AttachmentPoint attachment)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setViewLabelAttachment(swigCPtr, (int)attachment);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public new virtual OdDbModelDocViewStyle_TextAlignment viewLabelAlignment()
	{
		int result = (SwigDerivedClassHasMethod("viewLabelAlignment", swigMethodTypes67) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelAlignmentSwigExplicitOdDbDetailViewStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelAlignment(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbModelDocViewStyle_TextAlignment)result;
	}

	public OdResult setViewLabelAlignment(OdDbModelDocViewStyle_TextAlignment alignment)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setViewLabelAlignment(swigCPtr, (int)alignment);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override string viewLabelPattern()
	{
		string result = (SwigDerivedClassHasMethod("viewLabelPattern", swigMethodTypes68) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelPatternSwigExplicitOdDbDetailViewStyle(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_viewLabelPattern(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getViewLabelPattern(OdDbField pField)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_getViewLabelPattern__SWIG_0(swigCPtr, OdDbField.getCPtr(pField));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getViewLabelPattern()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_getViewLabelPattern__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setViewLabelPattern(string pattern, OdDbField pField)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setViewLabelPattern__SWIG_0(swigCPtr, pattern, OdDbField.getCPtr(pField));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setViewLabelPattern(string pattern)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setViewLabelPattern__SWIG_1(swigCPtr, pattern);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public bool showViewLabel()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_showViewLabel(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setShowViewLabel(bool bValue)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setShowViewLabel(swigCPtr, bValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDbDetailViewStyle_ModelEdge modelEdge()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_modelEdge(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbDetailViewStyle_ModelEdge)result;
	}

	public OdResult setModelEdge(OdDbDetailViewStyle_ModelEdge placement)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setModelEdge(swigCPtr, (int)placement);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public LineWeight borderLineWeight()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_borderLineWeight(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public OdResult setBorderLineWeight(LineWeight lineweight)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setBorderLineWeight(swigCPtr, (int)lineweight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdCmColor borderLineColor()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_borderLineColor(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setBorderLineColor(OdCmColor color)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setBorderLineColor(swigCPtr, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDbObjectId borderLineTypeId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_borderLineTypeId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setBorderLineTypeId(OdDbObjectId objId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_setBorderLineTypeId(swigCPtr, OdDbObjectId.getCPtr(objId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdDbObjectId defaultDetailViewStyle(OdDbDatabase db, bool init)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_defaultDetailViewStyle__SWIG_0(OdDbDatabase.getCPtr(db), init), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId defaultDetailViewStyle(OdDbDatabase db)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_defaultDetailViewStyle__SWIG_1(OdDbDatabase.getCPtr(db)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbObjectId postViewStyleToDb(OdDbDatabase pDb, string styleName)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("postViewStyleToDb", swigMethodTypes61) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_postViewStyleToDbSwigExplicitOdDbDetailViewStyle(swigCPtr, OdDbDatabase.getCPtr(pDb), styleName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_postViewStyleToDb(swigCPtr, OdDbDatabase.getCPtr(pDb), styleName), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual OdDbObject subWblockClone(ref OdDbIdMapping idMap, OdDbObject pOwner)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(SwigDerivedClassHasMethod("subWblockClone", swigMethodTypes69) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_subWblockCloneSwigExplicitOdDbDetailViewStyle(swigCPtr, ref jarg, OdDbObject.getCPtr(pOwner)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_subWblockClone(swigCPtr, ref jarg, OdDbObject.getCPtr(pOwner)), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("subClose", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsubClose;
		}
		if (SwigDerivedClassHasMethod("subErase", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsubErase;
		}
		if (SwigDerivedClassHasMethod("subHandOverTo", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsubHandOverTo;
		}
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsubSwapIdWith__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsubSwapIdWith__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("subSwapIdWith", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsubSwapIdWith__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("audit", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodaudit;
		}
		if (SwigDerivedClassHasMethod("dxfIn", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethoddxfIn;
		}
		if (SwigDerivedClassHasMethod("dxfOut", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethoddxfOut;
		}
		if (SwigDerivedClassHasMethod("dxfInFields_R12", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethoddxfInFields_R12;
		}
		if (SwigDerivedClassHasMethod("dxfOutFields_R12", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethoddxfOutFields_R12;
		}
		if (SwigDerivedClassHasMethod("mergeStyle", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodmergeStyle;
		}
		if (SwigDerivedClassHasMethod("xData", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodxData;
		}
		if (SwigDerivedClassHasMethod("setXData", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsetXData;
		}
		if (SwigDerivedClassHasMethod("applyPartialUndo", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodapplyPartialUndo;
		}
		if (SwigDerivedClassHasMethod("addPersistentReactor", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodaddPersistentReactor;
		}
		if (SwigDerivedClassHasMethod("removePersistentReactor", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodremovePersistentReactor;
		}
		if (SwigDerivedClassHasMethod("recvPropagateModify", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodrecvPropagateModify;
		}
		if (SwigDerivedClassHasMethod("xmitPropagateModify", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodxmitPropagateModify;
		}
		if (SwigDerivedClassHasMethod("appendToOwner", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodappendToOwner;
		}
		if (SwigDerivedClassHasMethod("copied", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodcopied;
		}
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethoderased__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethoderased__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("goodbye", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodgoodbye;
		}
		if (SwigDerivedClassHasMethod("openedForModify", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodopenedForModify;
		}
		if (SwigDerivedClassHasMethod("modified", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodmodified;
		}
		if (SwigDerivedClassHasMethod("subObjModified", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodsubObjModified;
		}
		if (SwigDerivedClassHasMethod("modifyUndone", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodmodifyUndone;
		}
		if (SwigDerivedClassHasMethod("modifiedXData", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodmodifiedXData;
		}
		if (SwigDerivedClassHasMethod("unappended", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodunappended;
		}
		if (SwigDerivedClassHasMethod("reappended", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodreappended;
		}
		if (SwigDerivedClassHasMethod("objectClosed", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodobjectClosed;
		}
		if (SwigDerivedClassHasMethod("modifiedGraphics", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodmodifiedGraphics;
		}
		if (SwigDerivedClassHasMethod("copyMeFrom", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodcopyMeFrom;
		}
		if (SwigDerivedClassHasMethod("getObjectSaveVersion", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodgetObjectSaveVersion__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getObjectSaveVersion", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodgetObjectSaveVersion__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("decomposeForSave", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethoddecomposeForSave__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("decomposeForSave", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethoddecomposeForSave__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("composeForLoad", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodcomposeForLoad;
		}
		if (SwigDerivedClassHasMethod("drawable", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethoddrawable;
		}
		if (SwigDerivedClassHasMethod("setField", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodsetField;
		}
		if (SwigDerivedClassHasMethod("removeField", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodremoveField__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("removeField", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodremoveField__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("saveAsClass", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodsaveAsClass;
		}
		if (SwigDerivedClassHasMethod("subGetClassID", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodsubGetClassID;
		}
		if (SwigDerivedClassHasMethod("getName", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodgetName;
		}
		if (SwigDerivedClassHasMethod("setName", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodsetName;
		}
		if (SwigDerivedClassHasMethod("description", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethoddescription;
		}
		if (SwigDerivedClassHasMethod("setDescription", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodsetDescription;
		}
		if (SwigDerivedClassHasMethod("setDatabaseDefaults", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodsetDatabaseDefaults;
		}
		if (SwigDerivedClassHasMethod("postViewStyleToDb", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodpostViewStyleToDb;
		}
		if (SwigDerivedClassHasMethod("viewLabelTextStyleId", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodviewLabelTextStyleId;
		}
		if (SwigDerivedClassHasMethod("viewLabelTextColor", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodviewLabelTextColor;
		}
		if (SwigDerivedClassHasMethod("viewLabelTextHeight", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodviewLabelTextHeight;
		}
		if (SwigDerivedClassHasMethod("viewLabelOffset", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodviewLabelOffset;
		}
		if (SwigDerivedClassHasMethod("viewLabelAttachment", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodviewLabelAttachment;
		}
		if (SwigDerivedClassHasMethod("viewLabelAlignment", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodviewLabelAlignment;
		}
		if (SwigDerivedClassHasMethod("viewLabelPattern", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodviewLabelPattern;
		}
		if (SwigDerivedClassHasMethod("subWblockClone", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodsubWblockClone;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDetailViewStyle_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbDetailViewStyle));
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

	private void SwigDirectorMethodsetDatabaseDefaults(IntPtr pDb)
	{
		try
		{
			setDatabaseDefaults(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodpostViewStyleToDb(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string styleName)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(postViewStyleToDb(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), styleName)).Handle;
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

	private IntPtr SwigDirectorMethodviewLabelTextStyleId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(viewLabelTextStyleId()).Handle;
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

	private IntPtr SwigDirectorMethodviewLabelTextColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(viewLabelTextColor()).Handle;
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

	private double SwigDirectorMethodviewLabelTextHeight()
	{
		return viewLabelTextHeight();
	}

	private double SwigDirectorMethodviewLabelOffset()
	{
		return viewLabelOffset();
	}

	private int SwigDirectorMethodviewLabelAttachment()
	{
		return (int)viewLabelAttachment();
	}

	private int SwigDirectorMethodviewLabelAlignment()
	{
		return (int)viewLabelAlignment();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodviewLabelPattern()
	{
		return viewLabelPattern();
	}

	private IntPtr SwigDirectorMethodsubWblockClone(IntPtr idMap, IntPtr pOwner)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return OdDbObject.getCPtr(subWblockClone(ref idMap2, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOwner, bOwn: false, bTryAddToTransaction: false))).Handle;
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
}

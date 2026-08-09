using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbSectionSettings : OdDbObject
{
	public delegate IntPtr SwigDelegateOdDbSectionSettings_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbSectionSettings_1();

	public delegate void SwigDelegateOdDbSectionSettings_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbSectionSettings_3();

	public delegate bool SwigDelegateOdDbSectionSettings_4();

	public delegate IntPtr SwigDelegateOdDbSectionSettings_5();

	public delegate void SwigDelegateOdDbSectionSettings_6(IntPtr pNode);

	public delegate IntPtr SwigDelegateOdDbSectionSettings_7();

	public delegate uint SwigDelegateOdDbSectionSettings_8(IntPtr vd);

	public delegate uint SwigDelegateOdDbSectionSettings_9();

	public delegate void SwigDelegateOdDbSectionSettings_10(IntPtr ownerId);

	public delegate int SwigDelegateOdDbSectionSettings_11(int mode);

	public delegate void SwigDelegateOdDbSectionSettings_12();

	public delegate int SwigDelegateOdDbSectionSettings_13(bool erasing);

	public delegate void SwigDelegateOdDbSectionSettings_14(IntPtr pNewObject);

	public delegate void SwigDelegateOdDbSectionSettings_15(IntPtr otherId, bool swapXdata, bool swapExtDict);

	public delegate void SwigDelegateOdDbSectionSettings_16(IntPtr otherId, bool swapXdata);

	public delegate void SwigDelegateOdDbSectionSettings_17(IntPtr otherId);

	public delegate void SwigDelegateOdDbSectionSettings_18(IntPtr pAuditInfo);

	public delegate int SwigDelegateOdDbSectionSettings_19(IntPtr pFiler);

	public delegate void SwigDelegateOdDbSectionSettings_20(IntPtr pFiler);

	public delegate int SwigDelegateOdDbSectionSettings_21(IntPtr pFiler);

	public delegate void SwigDelegateOdDbSectionSettings_22(IntPtr pFiler);

	public delegate int SwigDelegateOdDbSectionSettings_23(IntPtr pFiler);

	public delegate void SwigDelegateOdDbSectionSettings_24(IntPtr pFiler);

	public delegate int SwigDelegateOdDbSectionSettings_25(IntPtr pFiler);

	public delegate void SwigDelegateOdDbSectionSettings_26(IntPtr pFiler);

	public delegate int SwigDelegateOdDbSectionSettings_27();

	public delegate IntPtr SwigDelegateOdDbSectionSettings_28([MarshalAs(UnmanagedType.LPWStr)] string regappName);

	public delegate void SwigDelegateOdDbSectionSettings_29(IntPtr pRb);

	public delegate void SwigDelegateOdDbSectionSettings_30(IntPtr pUndoFiler, IntPtr pClassObj);

	public delegate void SwigDelegateOdDbSectionSettings_31(IntPtr objId);

	public delegate void SwigDelegateOdDbSectionSettings_32(IntPtr objId);

	public delegate void SwigDelegateOdDbSectionSettings_33(IntPtr pSubObj);

	public delegate void SwigDelegateOdDbSectionSettings_34();

	public delegate void SwigDelegateOdDbSectionSettings_35(IntPtr idPair, IntPtr pOwnerObject, IntPtr idMap);

	public delegate void SwigDelegateOdDbSectionSettings_36(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbSectionSettings_37(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbSectionSettings_38(IntPtr pObject);

	public delegate void SwigDelegateOdDbSectionSettings_39(IntPtr pObject);

	public delegate void SwigDelegateOdDbSectionSettings_40(IntPtr pObject);

	public delegate void SwigDelegateOdDbSectionSettings_41(IntPtr pObject);

	public delegate void SwigDelegateOdDbSectionSettings_42(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbSectionSettings_43(IntPtr pObject);

	public delegate void SwigDelegateOdDbSectionSettings_44(IntPtr pObject);

	public delegate void SwigDelegateOdDbSectionSettings_45(IntPtr pObject);

	public delegate void SwigDelegateOdDbSectionSettings_46(IntPtr pObject);

	public delegate void SwigDelegateOdDbSectionSettings_47(IntPtr objectId);

	public delegate void SwigDelegateOdDbSectionSettings_48(IntPtr pObject);

	public delegate void SwigDelegateOdDbSectionSettings_49(IntPtr pSource);

	public delegate int SwigDelegateOdDbSectionSettings_50(IntPtr pFiler, MaintReleaseVer pMaintVer);

	public delegate int SwigDelegateOdDbSectionSettings_51(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdDbSectionSettings_52(int ver, IntPtr replaceId, bool exchangeXData);

	public delegate IntPtr SwigDelegateOdDbSectionSettings_53(int format, int ver, IntPtr replaceId, bool exchangeXData);

	public delegate void SwigDelegateOdDbSectionSettings_54(int format, int version, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbSectionSettings_55();

	public delegate IntPtr SwigDelegateOdDbSectionSettings_56([MarshalAs(UnmanagedType.LPWStr)] string fieldName, IntPtr pField);

	public delegate int SwigDelegateOdDbSectionSettings_57(IntPtr fieldId);

	public delegate IntPtr SwigDelegateOdDbSectionSettings_58([MarshalAs(UnmanagedType.LPWStr)] string fieldName);

	public delegate IntPtr SwigDelegateOdDbSectionSettings_59(IntPtr pClass);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbSectionSettings_0 swigDelegate0;

	private SwigDelegateOdDbSectionSettings_1 swigDelegate1;

	private SwigDelegateOdDbSectionSettings_2 swigDelegate2;

	private SwigDelegateOdDbSectionSettings_3 swigDelegate3;

	private SwigDelegateOdDbSectionSettings_4 swigDelegate4;

	private SwigDelegateOdDbSectionSettings_5 swigDelegate5;

	private SwigDelegateOdDbSectionSettings_6 swigDelegate6;

	private SwigDelegateOdDbSectionSettings_7 swigDelegate7;

	private SwigDelegateOdDbSectionSettings_8 swigDelegate8;

	private SwigDelegateOdDbSectionSettings_9 swigDelegate9;

	private SwigDelegateOdDbSectionSettings_10 swigDelegate10;

	private SwigDelegateOdDbSectionSettings_11 swigDelegate11;

	private SwigDelegateOdDbSectionSettings_12 swigDelegate12;

	private SwigDelegateOdDbSectionSettings_13 swigDelegate13;

	private SwigDelegateOdDbSectionSettings_14 swigDelegate14;

	private SwigDelegateOdDbSectionSettings_15 swigDelegate15;

	private SwigDelegateOdDbSectionSettings_16 swigDelegate16;

	private SwigDelegateOdDbSectionSettings_17 swigDelegate17;

	private SwigDelegateOdDbSectionSettings_18 swigDelegate18;

	private SwigDelegateOdDbSectionSettings_19 swigDelegate19;

	private SwigDelegateOdDbSectionSettings_20 swigDelegate20;

	private SwigDelegateOdDbSectionSettings_21 swigDelegate21;

	private SwigDelegateOdDbSectionSettings_22 swigDelegate22;

	private SwigDelegateOdDbSectionSettings_23 swigDelegate23;

	private SwigDelegateOdDbSectionSettings_24 swigDelegate24;

	private SwigDelegateOdDbSectionSettings_25 swigDelegate25;

	private SwigDelegateOdDbSectionSettings_26 swigDelegate26;

	private SwigDelegateOdDbSectionSettings_27 swigDelegate27;

	private SwigDelegateOdDbSectionSettings_28 swigDelegate28;

	private SwigDelegateOdDbSectionSettings_29 swigDelegate29;

	private SwigDelegateOdDbSectionSettings_30 swigDelegate30;

	private SwigDelegateOdDbSectionSettings_31 swigDelegate31;

	private SwigDelegateOdDbSectionSettings_32 swigDelegate32;

	private SwigDelegateOdDbSectionSettings_33 swigDelegate33;

	private SwigDelegateOdDbSectionSettings_34 swigDelegate34;

	private SwigDelegateOdDbSectionSettings_35 swigDelegate35;

	private SwigDelegateOdDbSectionSettings_36 swigDelegate36;

	private SwigDelegateOdDbSectionSettings_37 swigDelegate37;

	private SwigDelegateOdDbSectionSettings_38 swigDelegate38;

	private SwigDelegateOdDbSectionSettings_39 swigDelegate39;

	private SwigDelegateOdDbSectionSettings_40 swigDelegate40;

	private SwigDelegateOdDbSectionSettings_41 swigDelegate41;

	private SwigDelegateOdDbSectionSettings_42 swigDelegate42;

	private SwigDelegateOdDbSectionSettings_43 swigDelegate43;

	private SwigDelegateOdDbSectionSettings_44 swigDelegate44;

	private SwigDelegateOdDbSectionSettings_45 swigDelegate45;

	private SwigDelegateOdDbSectionSettings_46 swigDelegate46;

	private SwigDelegateOdDbSectionSettings_47 swigDelegate47;

	private SwigDelegateOdDbSectionSettings_48 swigDelegate48;

	private SwigDelegateOdDbSectionSettings_49 swigDelegate49;

	private SwigDelegateOdDbSectionSettings_50 swigDelegate50;

	private SwigDelegateOdDbSectionSettings_51 swigDelegate51;

	private SwigDelegateOdDbSectionSettings_52 swigDelegate52;

	private SwigDelegateOdDbSectionSettings_53 swigDelegate53;

	private SwigDelegateOdDbSectionSettings_54 swigDelegate54;

	private SwigDelegateOdDbSectionSettings_55 swigDelegate55;

	private SwigDelegateOdDbSectionSettings_56 swigDelegate56;

	private SwigDelegateOdDbSectionSettings_57 swigDelegate57;

	private SwigDelegateOdDbSectionSettings_58 swigDelegate58;

	private SwigDelegateOdDbSectionSettings_59 swigDelegate59;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSectionSettings(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSectionSettings obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbSectionSettings(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbSectionSettings cast(OdRxObject pObj)
	{
		OdDbSectionSettings rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSectionSettings>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_isASwigExplicitOdDbSectionSettings(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_queryXSwigExplicitOdDbSectionSettings(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_dwgInFieldsSwigExplicitOdDbSectionSettings(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_dwgOutFieldsSwigExplicitOdDbSectionSettings(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_dxfInFieldsSwigExplicitOdDbSectionSettings(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_dxfOutFieldsSwigExplicitOdDbSectionSettings(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void reset()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_reset__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void reset(OdDbSectionSettings_SectionType nSecType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_reset__SWIG_1(swigCPtr, (int)nSecType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbSectionSettings_SectionType currentSectionType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_currentSectionType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbSectionSettings_SectionType)result;
	}

	public void setCurrentSectionType(OdDbSectionSettings_SectionType nSecType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setCurrentSectionType(swigCPtr, (int)nSecType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbSectionSettings_Generation generationOptions(OdDbSectionSettings_SectionType nSecType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_generationOptions(swigCPtr, (int)nSecType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbSectionSettings_Generation)result;
	}

	public void setGenerationOptions(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Generation nOptions)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setGenerationOptions(swigCPtr, (int)nSecType, (int)nOptions);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSourceObjects(OdDbSectionSettings_SectionType nSecType, OdDbObjectIdArray ids)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_getSourceObjects(swigCPtr, (int)nSecType, OdDbObjectIdArray.getCPtr(ids));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSourceObjects(OdDbSectionSettings_SectionType nSecType, OdDbObjectIdArray ids)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setSourceObjects(swigCPtr, (int)nSecType, OdDbObjectIdArray.getCPtr(ids));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId destinationBlock(OdDbSectionSettings_SectionType nSecType)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_destinationBlock(swigCPtr, (int)nSecType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDestinationBlock(OdDbSectionSettings_SectionType nSecType, OdDbObjectId id)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setDestinationBlock(swigCPtr, (int)nSecType, OdDbObjectId.getCPtr(id));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string destinationFile(OdDbSectionSettings_SectionType nSecType)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_destinationFile(swigCPtr, (int)nSecType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDestinationFile(OdDbSectionSettings_SectionType nSecType, string pszFileName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setDestinationFile(swigCPtr, (int)nSecType, pszFileName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool visibility(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_visibility(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVisibility(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, bool bVisible)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setVisibility(swigCPtr, (int)nSecType, (int)nGeometry, bVisible);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmColor color(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_color(swigCPtr, (int)nSecType, (int)nGeometry), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColor(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setColor(swigCPtr, (int)nSecType, (int)nGeometry, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string layer(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_layer(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLayer(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, string pszLayer)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setLayer(swigCPtr, (int)nSecType, (int)nGeometry, pszLayer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string linetype(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_linetype(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLinetype(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, string pszLinetype)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setLinetype(swigCPtr, (int)nSecType, (int)nGeometry, pszLinetype);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double linetypeScale(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_linetypeScale(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLinetypeScale(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, double fScale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setLinetypeScale(swigCPtr, (int)nSecType, (int)nGeometry, fScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string plotStyleName(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_plotStyleName(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPlotStyleName(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, string pszPlotStyleName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setPlotStyleName(swigCPtr, (int)nSecType, (int)nGeometry, pszPlotStyleName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public LineWeight lineWeight(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_lineWeight(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public void setLineWeight(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, LineWeight nLineWeight)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setLineWeight(swigCPtr, (int)nSecType, (int)nGeometry, (int)nLineWeight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int faceTransparency(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_faceTransparency(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFaceTransparency(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, int nTransparency)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setFaceTransparency(swigCPtr, (int)nSecType, (int)nGeometry, nTransparency);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int edgeTransparency(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_edgeTransparency(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEdgeTransparency(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, int nTransparency)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setEdgeTransparency(swigCPtr, (int)nSecType, (int)nGeometry, nTransparency);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hatchVisibility(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_hatchVisibility(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHatchVisibility(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, bool bVisible)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setHatchVisibility(swigCPtr, (int)nSecType, (int)nGeometry, bVisible);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getHatchPattern(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, out OdDbHatch_HatchPatternType nPatternType, ref string pszPatternName)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(pszPatternName);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_getHatchPattern(swigCPtr, (int)nSecType, (int)nGeometry, out nPatternType, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				pszPatternName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void setHatchPattern(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, OdDbHatch_HatchPatternType nPatternType, string pszPatternName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setHatchPattern(swigCPtr, (int)nSecType, (int)nGeometry, (int)nPatternType, pszPatternName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double hatchAngle(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_hatchAngle(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHatchAngle(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, double fAngle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setHatchAngle(swigCPtr, (int)nSecType, (int)nGeometry, fAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double hatchSpacing(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_hatchSpacing(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHatchSpacing(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, double fSpacing)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setHatchSpacing(swigCPtr, (int)nSecType, (int)nGeometry, fSpacing);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double hatchScale(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_hatchScale(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHatchScale(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, double fScale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setHatchScale(swigCPtr, (int)nSecType, (int)nGeometry, fScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hiddenLine(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_hiddenLine(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHiddenLine(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, bool bHiddenLine)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setHiddenLine(swigCPtr, (int)nSecType, (int)nGeometry, bHiddenLine);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool divisionLines(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_divisionLines(swigCPtr, (int)nSecType, (int)nGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDivisionLines(OdDbSectionSettings_SectionType nSecType, OdDbSectionSettings_Geometry nGeometry, bool bShow)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_setDivisionLines(swigCPtr, (int)nSecType, (int)nGeometry, bShow);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult SubGetClassID(IntPtr pClsid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_SubGetClassID(swigCPtr, pClsid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbSectionSettings createObject()
	{
		OdDbSectionSettings rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSectionSettings>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionSettings_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbSectionSettings));
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
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdRxEventReactor : OdRxObject
{
	public delegate IntPtr SwigDelegateOdRxEventReactor_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxEventReactor_1();

	public delegate void SwigDelegateOdRxEventReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdRxEventReactor_3(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate void SwigDelegateOdRxEventReactor_4(IntPtr pDb);

	public delegate void SwigDelegateOdRxEventReactor_5(IntPtr pDb);

	public delegate void SwigDelegateOdRxEventReactor_6(IntPtr pDb);

	public delegate void SwigDelegateOdRxEventReactor_7(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string intendedName);

	public delegate void SwigDelegateOdRxEventReactor_8(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string actualName);

	public delegate void SwigDelegateOdRxEventReactor_9(IntPtr pDb);

	public delegate void SwigDelegateOdRxEventReactor_10(IntPtr pDb);

	public delegate void SwigDelegateOdRxEventReactor_11(IntPtr pDb);

	public delegate void SwigDelegateOdRxEventReactor_12(IntPtr pDb);

	public delegate void SwigDelegateOdRxEventReactor_13(IntPtr pDb);

	public delegate void SwigDelegateOdRxEventReactor_14(IntPtr pDb);

	public delegate void SwigDelegateOdRxEventReactor_15(IntPtr pDb);

	public delegate void SwigDelegateOdRxEventReactor_16(IntPtr pToDb, [MarshalAs(UnmanagedType.LPWStr)] string blockName, IntPtr pFromDb);

	public delegate void SwigDelegateOdRxEventReactor_17(IntPtr pToDb, IntPtr xfm, IntPtr pFromDb);

	public delegate void SwigDelegateOdRxEventReactor_18(IntPtr pToDb, IntPtr idMap, IntPtr pFromDb);

	public delegate void SwigDelegateOdRxEventReactor_19(IntPtr pToDb);

	public delegate void SwigDelegateOdRxEventReactor_20(IntPtr pToDb);

	public delegate void SwigDelegateOdRxEventReactor_21(IntPtr pFromDb);

	public delegate void SwigDelegateOdRxEventReactor_22(IntPtr pToDb, IntPtr pFromDb, IntPtr insertionPoint);

	public delegate void SwigDelegateOdRxEventReactor_23(IntPtr pToDb, IntPtr pFromDb, IntPtr blockId);

	public delegate void SwigDelegateOdRxEventReactor_24(IntPtr pToDb, IntPtr pFromDb);

	public delegate void SwigDelegateOdRxEventReactor_25(IntPtr pToDb, IntPtr idMap, IntPtr pFromDb);

	public delegate void SwigDelegateOdRxEventReactor_26(IntPtr pToDb);

	public delegate void SwigDelegateOdRxEventReactor_27(IntPtr pToDb);

	public delegate void SwigDelegateOdRxEventReactor_28(IntPtr pFromDb, IntPtr idMap);

	public delegate void SwigDelegateOdRxEventReactor_29(IntPtr pToDb, IntPtr idMap);

	public delegate void SwigDelegateOdRxEventReactor_30(IntPtr idMap);

	public delegate void SwigDelegateOdRxEventReactor_31(IntPtr idMap);

	public delegate void SwigDelegateOdRxEventReactor_32(IntPtr idMap);

	public delegate void SwigDelegateOdRxEventReactor_33(IntPtr pDb);

	public delegate void SwigDelegateOdRxEventReactor_34(IntPtr pHostDb, int subCmd, IntPtr btrIds, IntPtr btrNames, IntPtr paths, bool vetoOp);

	public delegate void SwigDelegateOdRxEventReactor_35(IntPtr pHostDb, int subCmd, IntPtr btrIds, IntPtr btrNames, IntPtr paths);

	public delegate void SwigDelegateOdRxEventReactor_36(IntPtr pHostDb, int subCmd, IntPtr btrIds, IntPtr btrNames, IntPtr paths);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxEventReactor_0 swigDelegate0;

	private SwigDelegateOdRxEventReactor_1 swigDelegate1;

	private SwigDelegateOdRxEventReactor_2 swigDelegate2;

	private SwigDelegateOdRxEventReactor_3 swigDelegate3;

	private SwigDelegateOdRxEventReactor_4 swigDelegate4;

	private SwigDelegateOdRxEventReactor_5 swigDelegate5;

	private SwigDelegateOdRxEventReactor_6 swigDelegate6;

	private SwigDelegateOdRxEventReactor_7 swigDelegate7;

	private SwigDelegateOdRxEventReactor_8 swigDelegate8;

	private SwigDelegateOdRxEventReactor_9 swigDelegate9;

	private SwigDelegateOdRxEventReactor_10 swigDelegate10;

	private SwigDelegateOdRxEventReactor_11 swigDelegate11;

	private SwigDelegateOdRxEventReactor_12 swigDelegate12;

	private SwigDelegateOdRxEventReactor_13 swigDelegate13;

	private SwigDelegateOdRxEventReactor_14 swigDelegate14;

	private SwigDelegateOdRxEventReactor_15 swigDelegate15;

	private SwigDelegateOdRxEventReactor_16 swigDelegate16;

	private SwigDelegateOdRxEventReactor_17 swigDelegate17;

	private SwigDelegateOdRxEventReactor_18 swigDelegate18;

	private SwigDelegateOdRxEventReactor_19 swigDelegate19;

	private SwigDelegateOdRxEventReactor_20 swigDelegate20;

	private SwigDelegateOdRxEventReactor_21 swigDelegate21;

	private SwigDelegateOdRxEventReactor_22 swigDelegate22;

	private SwigDelegateOdRxEventReactor_23 swigDelegate23;

	private SwigDelegateOdRxEventReactor_24 swigDelegate24;

	private SwigDelegateOdRxEventReactor_25 swigDelegate25;

	private SwigDelegateOdRxEventReactor_26 swigDelegate26;

	private SwigDelegateOdRxEventReactor_27 swigDelegate27;

	private SwigDelegateOdRxEventReactor_28 swigDelegate28;

	private SwigDelegateOdRxEventReactor_29 swigDelegate29;

	private SwigDelegateOdRxEventReactor_30 swigDelegate30;

	private SwigDelegateOdRxEventReactor_31 swigDelegate31;

	private SwigDelegateOdRxEventReactor_32 swigDelegate32;

	private SwigDelegateOdRxEventReactor_33 swigDelegate33;

	private SwigDelegateOdRxEventReactor_34 swigDelegate34;

	private SwigDelegateOdRxEventReactor_35 swigDelegate35;

	private SwigDelegateOdRxEventReactor_36 swigDelegate36;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(string)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(string)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes16 = new Type[3]
	{
		typeof(OdDbDatabase),
		typeof(string),
		typeof(OdDbDatabase)
	};

	private static Type[] swigMethodTypes17 = new Type[3]
	{
		typeof(OdDbDatabase),
		typeof(OdGeMatrix3d),
		typeof(OdDbDatabase)
	};

	private static Type[] swigMethodTypes18 = new Type[3]
	{
		typeof(OdDbDatabase),
		typeof(OdDbIdMapping).MakeByRefType(),
		typeof(OdDbDatabase)
	};

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes22 = new Type[3]
	{
		typeof(OdDbDatabase),
		typeof(OdDbDatabase),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes23 = new Type[3]
	{
		typeof(OdDbDatabase),
		typeof(OdDbDatabase),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes24 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(OdDbDatabase)
	};

	private static Type[] swigMethodTypes25 = new Type[3]
	{
		typeof(OdDbDatabase),
		typeof(OdDbIdMapping).MakeByRefType(),
		typeof(OdDbDatabase)
	};

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes28 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(OdDbIdMapping).MakeByRefType()
	};

	private static Type[] swigMethodTypes29 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(OdDbIdMapping).MakeByRefType()
	};

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(OdDbIdMapping).MakeByRefType() };

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(OdDbIdMapping).MakeByRefType() };

	private static Type[] swigMethodTypes32 = new Type[1] { typeof(OdDbIdMapping).MakeByRefType() };

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes34 = new Type[6]
	{
		typeof(OdDbDatabase),
		typeof(OdXrefSubCommand),
		typeof(OdDbObjectIdArray),
		typeof(OdStringArray),
		typeof(OdStringArray),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes35 = new Type[5]
	{
		typeof(OdDbDatabase),
		typeof(OdXrefSubCommand),
		typeof(OdDbObjectIdArray),
		typeof(OdStringArray),
		typeof(OdStringArray)
	};

	private static Type[] swigMethodTypes36 = new Type[5]
	{
		typeof(OdDbDatabase),
		typeof(OdXrefSubCommand),
		typeof(OdDbObjectIdArray),
		typeof(OdStringArray),
		typeof(OdStringArray)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxEventReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxEventReactor obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdRxEventReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxEventReactor cast(OdRxObject pObj)
	{
		OdRxEventReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxEventReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_isASwigExplicitOdRxEventReactor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_queryXSwigExplicitOdRxEventReactor(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void dwgFileOpened(OdDbDatabase pDb, string filename)
	{
		if (SwigDerivedClassHasMethod("dwgFileOpened", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_dwgFileOpenedSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb), filename);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_dwgFileOpened(swigCPtr, OdDbDatabase.getCPtr(pDb), filename);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void initialDwgFileOpenComplete(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("initialDwgFileOpenComplete", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_initialDwgFileOpenCompleteSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_initialDwgFileOpenComplete(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void databaseConstructed(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("databaseConstructed", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_databaseConstructedSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_databaseConstructed(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void databaseToBeDestroyed(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("databaseToBeDestroyed", swigMethodTypes6))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_databaseToBeDestroyedSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_databaseToBeDestroyed(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginSave(OdDbDatabase pDb, string intendedName)
	{
		if (SwigDerivedClassHasMethod("beginSave", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginSaveSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb), intendedName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginSave(swigCPtr, OdDbDatabase.getCPtr(pDb), intendedName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void saveComplete(OdDbDatabase pDb, string actualName)
	{
		if (SwigDerivedClassHasMethod("saveComplete", swigMethodTypes8))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_saveCompleteSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb), actualName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_saveComplete(swigCPtr, OdDbDatabase.getCPtr(pDb), actualName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortSave(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("abortSave", swigMethodTypes9))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_abortSaveSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_abortSave(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginDxfIn(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("beginDxfIn", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginDxfInSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginDxfIn(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortDxfIn(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("abortDxfIn", swigMethodTypes11))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_abortDxfInSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_abortDxfIn(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void dxfInComplete(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("dxfInComplete", swigMethodTypes12))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_dxfInCompleteSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_dxfInComplete(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginDxfOut(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("beginDxfOut", swigMethodTypes13))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginDxfOutSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginDxfOut(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortDxfOut(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("abortDxfOut", swigMethodTypes14))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_abortDxfOutSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_abortDxfOut(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void dxfOutComplete(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("dxfOutComplete", swigMethodTypes15))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_dxfOutCompleteSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_dxfOutComplete(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginInsert(OdDbDatabase pToDb, string blockName, OdDbDatabase pFromDb)
	{
		if (SwigDerivedClassHasMethod("beginInsert", swigMethodTypes16))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginInsertSwigExplicitOdRxEventReactor__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pToDb), blockName, OdDbDatabase.getCPtr(pFromDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginInsert__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pToDb), blockName, OdDbDatabase.getCPtr(pFromDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginInsert(OdDbDatabase pToDb, OdGeMatrix3d xfm, OdDbDatabase pFromDb)
	{
		if (SwigDerivedClassHasMethod("beginInsert", swigMethodTypes17))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginInsertSwigExplicitOdRxEventReactor__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdGeMatrix3d.getCPtr(xfm), OdDbDatabase.getCPtr(pFromDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginInsert__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdGeMatrix3d.getCPtr(xfm), OdDbDatabase.getCPtr(pFromDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void otherInsert(OdDbDatabase pToDb, ref OdDbIdMapping idMap, OdDbDatabase pFromDb)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("otherInsert", swigMethodTypes18))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_otherInsertSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb), ref jarg, OdDbDatabase.getCPtr(pFromDb));
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_otherInsert(swigCPtr, OdDbDatabase.getCPtr(pToDb), ref jarg, OdDbDatabase.getCPtr(pFromDb));
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
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

	public virtual void abortInsert(OdDbDatabase pToDb)
	{
		if (SwigDerivedClassHasMethod("abortInsert", swigMethodTypes19))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_abortInsertSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_abortInsert(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endInsert(OdDbDatabase pToDb)
	{
		if (SwigDerivedClassHasMethod("endInsert", swigMethodTypes20))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_endInsertSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_endInsert(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wblockNotice(OdDbDatabase pFromDb)
	{
		if (SwigDerivedClassHasMethod("wblockNotice", swigMethodTypes21))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_wblockNoticeSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pFromDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_wblockNotice(swigCPtr, OdDbDatabase.getCPtr(pFromDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginWblock(OdDbDatabase pToDb, OdDbDatabase pFromDb, OdGePoint3d insertionPoint)
	{
		if (SwigDerivedClassHasMethod("beginWblock", swigMethodTypes22))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginWblockSwigExplicitOdRxEventReactor__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdDbDatabase.getCPtr(pFromDb), OdGePoint3d.getCPtr(insertionPoint));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginWblock__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdDbDatabase.getCPtr(pFromDb), OdGePoint3d.getCPtr(insertionPoint));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginWblock(OdDbDatabase pToDb, OdDbDatabase pFromDb, OdDbObjectId blockId)
	{
		if (SwigDerivedClassHasMethod("beginWblock", swigMethodTypes23))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginWblockSwigExplicitOdRxEventReactor__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdDbDatabase.getCPtr(pFromDb), OdDbObjectId.getCPtr(blockId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginWblock__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdDbDatabase.getCPtr(pFromDb), OdDbObjectId.getCPtr(blockId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginWblock(OdDbDatabase pToDb, OdDbDatabase pFromDb)
	{
		if (SwigDerivedClassHasMethod("beginWblock", swigMethodTypes24))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginWblockSwigExplicitOdRxEventReactor__SWIG_2(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdDbDatabase.getCPtr(pFromDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginWblock__SWIG_2(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdDbDatabase.getCPtr(pFromDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void otherWblock(OdDbDatabase pToDb, ref OdDbIdMapping idMap, OdDbDatabase pFromDb)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("otherWblock", swigMethodTypes25))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_otherWblockSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb), ref jarg, OdDbDatabase.getCPtr(pFromDb));
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_otherWblock(swigCPtr, OdDbDatabase.getCPtr(pToDb), ref jarg, OdDbDatabase.getCPtr(pFromDb));
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
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

	public virtual void abortWblock(OdDbDatabase pToDb)
	{
		if (SwigDerivedClassHasMethod("abortWblock", swigMethodTypes26))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_abortWblockSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_abortWblock(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endWblock(OdDbDatabase pToDb)
	{
		if (SwigDerivedClassHasMethod("endWblock", swigMethodTypes27))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_endWblockSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_endWblock(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginWblockObjects(OdDbDatabase pFromDb, ref OdDbIdMapping idMap)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("beginWblockObjects", swigMethodTypes28))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginWblockObjectsSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pFromDb), ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginWblockObjects(swigCPtr, OdDbDatabase.getCPtr(pFromDb), ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
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

	public virtual void beginDeepClone(OdDbDatabase pToDb, ref OdDbIdMapping idMap)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("beginDeepClone", swigMethodTypes29))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginDeepCloneSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb), ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginDeepClone(swigCPtr, OdDbDatabase.getCPtr(pToDb), ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
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

	public virtual void beginDeepCloneXlation(ref OdDbIdMapping idMap)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("beginDeepCloneXlation", swigMethodTypes30))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginDeepCloneXlationSwigExplicitOdRxEventReactor(swigCPtr, ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_beginDeepCloneXlation(swigCPtr, ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
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

	public virtual void abortDeepClone(ref OdDbIdMapping idMap)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("abortDeepClone", swigMethodTypes31))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_abortDeepCloneSwigExplicitOdRxEventReactor(swigCPtr, ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_abortDeepClone(swigCPtr, ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
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

	public virtual void endDeepClone(ref OdDbIdMapping idMap)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("endDeepClone", swigMethodTypes32))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_endDeepCloneSwigExplicitOdRxEventReactor(swigCPtr, ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_endDeepClone(swigCPtr, ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
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

	public virtual void partialOpenNotice(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("partialOpenNotice", swigMethodTypes33))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_partialOpenNoticeSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_partialOpenNotice(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xrefSubCommandStart(OdDbDatabase pHostDb, OdXrefSubCommand subCmd, OdDbObjectIdArray btrIds, OdStringArray btrNames, OdStringArray paths, out bool vetoOp)
	{
		if (SwigDerivedClassHasMethod("xrefSubCommandStart", swigMethodTypes34))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_xrefSubCommandStartSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle, out vetoOp);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_xrefSubCommandStart(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle, out vetoOp);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xrefSubCommandEnd(OdDbDatabase pHostDb, OdXrefSubCommand subCmd, OdDbObjectIdArray btrIds, OdStringArray btrNames, OdStringArray paths)
	{
		if (SwigDerivedClassHasMethod("xrefSubCommandEnd", swigMethodTypes35))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_xrefSubCommandEndSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_xrefSubCommandEnd(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xrefSubCommandAborted(OdDbDatabase pHostDb, OdXrefSubCommand subCmd, OdDbObjectIdArray btrIds, OdStringArray btrNames, OdStringArray paths)
	{
		if (SwigDerivedClassHasMethod("xrefSubCommandAborted", swigMethodTypes36))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_xrefSubCommandAbortedSwigExplicitOdRxEventReactor(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_xrefSubCommandAborted(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxEventReactor createObject()
	{
		OdRxEventReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxEventReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxEventReactor()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdRxEventReactor(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxEventReactor) != GetType();
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
		if (SwigDerivedClassHasMethod("dwgFileOpened", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddwgFileOpened;
		}
		if (SwigDerivedClassHasMethod("initialDwgFileOpenComplete", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodinitialDwgFileOpenComplete;
		}
		if (SwigDerivedClassHasMethod("databaseConstructed", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoddatabaseConstructed;
		}
		if (SwigDerivedClassHasMethod("databaseToBeDestroyed", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoddatabaseToBeDestroyed;
		}
		if (SwigDerivedClassHasMethod("beginSave", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodbeginSave;
		}
		if (SwigDerivedClassHasMethod("saveComplete", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsaveComplete;
		}
		if (SwigDerivedClassHasMethod("abortSave", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodabortSave;
		}
		if (SwigDerivedClassHasMethod("beginDxfIn", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodbeginDxfIn;
		}
		if (SwigDerivedClassHasMethod("abortDxfIn", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodabortDxfIn;
		}
		if (SwigDerivedClassHasMethod("dxfInComplete", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethoddxfInComplete;
		}
		if (SwigDerivedClassHasMethod("beginDxfOut", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodbeginDxfOut;
		}
		if (SwigDerivedClassHasMethod("abortDxfOut", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodabortDxfOut;
		}
		if (SwigDerivedClassHasMethod("dxfOutComplete", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethoddxfOutComplete;
		}
		if (SwigDerivedClassHasMethod("beginInsert", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodbeginInsert__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("beginInsert", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodbeginInsert__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("otherInsert", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodotherInsert;
		}
		if (SwigDerivedClassHasMethod("abortInsert", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodabortInsert;
		}
		if (SwigDerivedClassHasMethod("endInsert", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodendInsert;
		}
		if (SwigDerivedClassHasMethod("wblockNotice", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodwblockNotice;
		}
		if (SwigDerivedClassHasMethod("beginWblock", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodbeginWblock__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("beginWblock", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodbeginWblock__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("beginWblock", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodbeginWblock__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("otherWblock", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodotherWblock;
		}
		if (SwigDerivedClassHasMethod("abortWblock", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodabortWblock;
		}
		if (SwigDerivedClassHasMethod("endWblock", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodendWblock;
		}
		if (SwigDerivedClassHasMethod("beginWblockObjects", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodbeginWblockObjects;
		}
		if (SwigDerivedClassHasMethod("beginDeepClone", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodbeginDeepClone;
		}
		if (SwigDerivedClassHasMethod("beginDeepCloneXlation", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodbeginDeepCloneXlation;
		}
		if (SwigDerivedClassHasMethod("abortDeepClone", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodabortDeepClone;
		}
		if (SwigDerivedClassHasMethod("endDeepClone", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodendDeepClone;
		}
		if (SwigDerivedClassHasMethod("partialOpenNotice", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodpartialOpenNotice;
		}
		if (SwigDerivedClassHasMethod("xrefSubCommandStart", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodxrefSubCommandStart;
		}
		if (SwigDerivedClassHasMethod("xrefSubCommandEnd", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodxrefSubCommandEnd;
		}
		if (SwigDerivedClassHasMethod("xrefSubCommandAborted", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodxrefSubCommandAborted;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxEventReactor));
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

	private void SwigDirectorMethoddwgFileOpened(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		try
		{
			dwgFileOpened(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), filename);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodinitialDwgFileOpenComplete(IntPtr pDb)
	{
		try
		{
			initialDwgFileOpenComplete(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddatabaseConstructed(IntPtr pDb)
	{
		try
		{
			databaseConstructed(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddatabaseToBeDestroyed(IntPtr pDb)
	{
		try
		{
			databaseToBeDestroyed(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginSave(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string intendedName)
	{
		try
		{
			beginSave(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), intendedName);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsaveComplete(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string actualName)
	{
		try
		{
			saveComplete(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), actualName);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodabortSave(IntPtr pDb)
	{
		try
		{
			abortSave(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginDxfIn(IntPtr pDb)
	{
		try
		{
			beginDxfIn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodabortDxfIn(IntPtr pDb)
	{
		try
		{
			abortDxfIn(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddxfInComplete(IntPtr pDb)
	{
		try
		{
			dxfInComplete(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginDxfOut(IntPtr pDb)
	{
		try
		{
			beginDxfOut(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodabortDxfOut(IntPtr pDb)
	{
		try
		{
			abortDxfOut(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddxfOutComplete(IntPtr pDb)
	{
		try
		{
			dxfOutComplete(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginInsert__SWIG_0(IntPtr pToDb, [MarshalAs(UnmanagedType.LPWStr)] string blockName, IntPtr pFromDb)
	{
		try
		{
			beginInsert(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false), blockName, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginInsert__SWIG_1(IntPtr pToDb, IntPtr xfm, IntPtr pFromDb)
	{
		try
		{
			beginInsert(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false), new OdGeMatrix3d(xfm, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodotherInsert(IntPtr pToDb, IntPtr idMap, IntPtr pFromDb)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			otherInsert(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false), ref idMap2, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}

	private void SwigDirectorMethodabortInsert(IntPtr pToDb)
	{
		try
		{
			abortInsert(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodendInsert(IntPtr pToDb)
	{
		try
		{
			endInsert(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodwblockNotice(IntPtr pFromDb)
	{
		try
		{
			wblockNotice(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginWblock__SWIG_0(IntPtr pToDb, IntPtr pFromDb, IntPtr insertionPoint)
	{
		try
		{
			beginWblock(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(insertionPoint, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginWblock__SWIG_1(IntPtr pToDb, IntPtr pFromDb, IntPtr blockId)
	{
		try
		{
			beginWblock(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false), new OdDbObjectId(blockId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginWblock__SWIG_2(IntPtr pToDb, IntPtr pFromDb)
	{
		try
		{
			beginWblock(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodotherWblock(IntPtr pToDb, IntPtr idMap, IntPtr pFromDb)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			otherWblock(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false), ref idMap2, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}

	private void SwigDirectorMethodabortWblock(IntPtr pToDb)
	{
		try
		{
			abortWblock(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodendWblock(IntPtr pToDb)
	{
		try
		{
			endWblock(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginWblockObjects(IntPtr pFromDb, IntPtr idMap)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			beginWblockObjects(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false), ref idMap2);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}

	private void SwigDirectorMethodbeginDeepClone(IntPtr pToDb, IntPtr idMap)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			beginDeepClone(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false), ref idMap2);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}

	private void SwigDirectorMethodbeginDeepCloneXlation(IntPtr idMap)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			beginDeepCloneXlation(ref idMap2);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}

	private void SwigDirectorMethodabortDeepClone(IntPtr idMap)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			abortDeepClone(ref idMap2);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}

	private void SwigDirectorMethodendDeepClone(IntPtr idMap)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			endDeepClone(ref idMap2);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}

	private void SwigDirectorMethodpartialOpenNotice(IntPtr pDb)
	{
		try
		{
			partialOpenNotice(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodxrefSubCommandStart(IntPtr pHostDb, int subCmd, IntPtr btrIds, IntPtr btrNames, IntPtr paths, bool vetoOp)
	{
		try
		{
			xrefSubCommandStart(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pHostDb, bOwn: false, bTryAddToTransaction: false), (OdXrefSubCommand)subCmd, new OdDbObjectIdArray(btrIds, cMemoryOwn: false), new OdStringArray(btrNames, cMemoryOwn: true), new OdStringArray(paths, cMemoryOwn: true), out vetoOp);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodxrefSubCommandEnd(IntPtr pHostDb, int subCmd, IntPtr btrIds, IntPtr btrNames, IntPtr paths)
	{
		try
		{
			xrefSubCommandEnd(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pHostDb, bOwn: false, bTryAddToTransaction: false), (OdXrefSubCommand)subCmd, new OdDbObjectIdArray(btrIds, cMemoryOwn: false), new OdStringArray(btrNames, cMemoryOwn: true), new OdStringArray(paths, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodxrefSubCommandAborted(IntPtr pHostDb, int subCmd, IntPtr btrIds, IntPtr btrNames, IntPtr paths)
	{
		try
		{
			xrefSubCommandAborted(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pHostDb, bOwn: false, bTryAddToTransaction: false), (OdXrefSubCommand)subCmd, new OdDbObjectIdArray(btrIds, cMemoryOwn: false), new OdStringArray(btrNames, cMemoryOwn: true), new OdStringArray(paths, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdEditorReactor : OdRxEventReactor
{
	public delegate IntPtr SwigDelegateOdEditorReactor_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdEditorReactor_1();

	public delegate void SwigDelegateOdEditorReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdEditorReactor_3(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate void SwigDelegateOdEditorReactor_4(IntPtr pDb);

	public delegate void SwigDelegateOdEditorReactor_5(IntPtr pDb);

	public delegate void SwigDelegateOdEditorReactor_6(IntPtr pDb);

	public delegate void SwigDelegateOdEditorReactor_7(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string intendedName);

	public delegate void SwigDelegateOdEditorReactor_8(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string actualName);

	public delegate void SwigDelegateOdEditorReactor_9(IntPtr pDb);

	public delegate void SwigDelegateOdEditorReactor_10(IntPtr pDb);

	public delegate void SwigDelegateOdEditorReactor_11(IntPtr pDb);

	public delegate void SwigDelegateOdEditorReactor_12(IntPtr pDb);

	public delegate void SwigDelegateOdEditorReactor_13(IntPtr pDb);

	public delegate void SwigDelegateOdEditorReactor_14(IntPtr pDb);

	public delegate void SwigDelegateOdEditorReactor_15(IntPtr pDb);

	public delegate void SwigDelegateOdEditorReactor_16(IntPtr pToDb, [MarshalAs(UnmanagedType.LPWStr)] string blockName, IntPtr pFromDb);

	public delegate void SwigDelegateOdEditorReactor_17(IntPtr pToDb, IntPtr xfm, IntPtr pFromDb);

	public delegate void SwigDelegateOdEditorReactor_18(IntPtr pToDb, IntPtr idMap, IntPtr pFromDb);

	public delegate void SwigDelegateOdEditorReactor_19(IntPtr pToDb);

	public delegate void SwigDelegateOdEditorReactor_20(IntPtr pToDb);

	public delegate void SwigDelegateOdEditorReactor_21(IntPtr pFromDb);

	public delegate void SwigDelegateOdEditorReactor_22(IntPtr pToDb, IntPtr pFromDb, IntPtr insertionPoint);

	public delegate void SwigDelegateOdEditorReactor_23(IntPtr pToDb, IntPtr pFromDb, IntPtr blockId);

	public delegate void SwigDelegateOdEditorReactor_24(IntPtr pToDb, IntPtr pFromDb);

	public delegate void SwigDelegateOdEditorReactor_25(IntPtr pToDb, IntPtr idMap, IntPtr pFromDb);

	public delegate void SwigDelegateOdEditorReactor_26(IntPtr pToDb);

	public delegate void SwigDelegateOdEditorReactor_27(IntPtr pToDb);

	public delegate void SwigDelegateOdEditorReactor_28(IntPtr pFromDb, IntPtr idMap);

	public delegate void SwigDelegateOdEditorReactor_29(IntPtr pToDb, IntPtr idMap);

	public delegate void SwigDelegateOdEditorReactor_30(IntPtr idMap);

	public delegate void SwigDelegateOdEditorReactor_31(IntPtr idMap);

	public delegate void SwigDelegateOdEditorReactor_32(IntPtr idMap);

	public delegate void SwigDelegateOdEditorReactor_33(IntPtr pDb);

	public delegate void SwigDelegateOdEditorReactor_34(IntPtr pHostDb, int subCmd, IntPtr btrIds, IntPtr btrNames, IntPtr paths, bool veto);

	public delegate void SwigDelegateOdEditorReactor_35(IntPtr pHostDb, int subCmd, IntPtr btrIds, IntPtr btrNames, IntPtr paths);

	public delegate void SwigDelegateOdEditorReactor_36(IntPtr pHostDb, int subCmd, IntPtr btrIds, IntPtr btrNames, IntPtr paths);

	public delegate void SwigDelegateOdEditorReactor_37([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate void SwigDelegateOdEditorReactor_38([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate void SwigDelegateOdEditorReactor_39(IntPtr pDb);

	public delegate void SwigDelegateOdEditorReactor_40(IntPtr pToDb, [MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pFromDb);

	public delegate void SwigDelegateOdEditorReactor_41(IntPtr pToDb, IntPtr pFromDb);

	public delegate void SwigDelegateOdEditorReactor_42(IntPtr pFromDb);

	public delegate void SwigDelegateOdEditorReactor_43(IntPtr pToDb);

	public delegate void SwigDelegateOdEditorReactor_44(IntPtr newId, IntPtr oldId);

	public delegate void SwigDelegateOdEditorReactor_45(IntPtr pToDb, IntPtr id, IntPtr pFromDb);

	public delegate void SwigDelegateOdEditorReactor_46(IntPtr pToDb, [MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pFromDb);

	public delegate void SwigDelegateOdEditorReactor_47(IntPtr pToDb);

	public delegate void SwigDelegateOdEditorReactor_48(IntPtr pToDb);

	public delegate void SwigDelegateOdEditorReactor_49(int activity, IntPtr blockId);

	public delegate void SwigDelegateOdEditorReactor_50(int activity, [MarshalAs(UnmanagedType.LPWStr)] string xrefPath);

	public delegate void SwigDelegateOdEditorReactor_51(int activity, [MarshalAs(UnmanagedType.LPWStr)] string xrefPath);

	public delegate void SwigDelegateOdEditorReactor_52(int activity, IntPtr blockId);

	public delegate void SwigDelegateOdEditorReactor_53(int activity, IntPtr blockId, [MarshalAs(UnmanagedType.LPWStr)] string newPath);

	public delegate void SwigDelegateOdEditorReactor_54(int activity, IntPtr blockId);

	public delegate void SwigDelegateOdEditorReactor_55(int activity, IntPtr blockId);

	public delegate void SwigDelegateOdEditorReactor_56(int activity, bool undoAuto);

	public delegate void SwigDelegateOdEditorReactor_57(int activity, int option);

	public delegate void SwigDelegateOdEditorReactor_58(int activity);

	public delegate void SwigDelegateOdEditorReactor_59(int activity);

	public delegate void SwigDelegateOdEditorReactor_60(int activity);

	public delegate void SwigDelegateOdEditorReactor_61(int activity);

	public delegate void SwigDelegateOdEditorReactor_62(int activity, int numSteps);

	public delegate void SwigDelegateOdEditorReactor_63();

	public delegate void SwigDelegateOdEditorReactor_64([MarshalAs(UnmanagedType.LPWStr)] string newLayoutName);

	public delegate void SwigDelegateOdEditorReactor_65(ulong hwndDocFrame, bool moved);

	public delegate void SwigDelegateOdEditorReactor_66(ulong hwndMainFrame, bool moved);

	public delegate void SwigDelegateOdEditorReactor_67(IntPtr clickPoint);

	public delegate void SwigDelegateOdEditorReactor_68(IntPtr clickPoint);

	public delegate void SwigDelegateOdEditorReactor_69(bool largeBitmaps);

	public delegate void SwigDelegateOdEditorReactor_70(bool largeBitmaps);

	public delegate void SwigDelegateOdEditorReactor_71(IntPtr objectIds);

	public delegate void SwigDelegateOdEditorReactor_72();

	public delegate void SwigDelegateOdEditorReactor_73();

	public delegate void SwigDelegateOdEditorReactor_74();

	public delegate void SwigDelegateOdEditorReactor_75([MarshalAs(UnmanagedType.LPWStr)] string contextString);

	public delegate void SwigDelegateOdEditorReactor_76([MarshalAs(UnmanagedType.LPWStr)] string contextString);

	public delegate void SwigDelegateOdEditorReactor_77(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string varName);

	public delegate void SwigDelegateOdEditorReactor_78(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string varName);

	public delegate void SwigDelegateOdEditorReactor_79(IntPtr pHostDb, int subCmd, IntPtr btrIds, IntPtr btrNames, IntPtr paths);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdEditorReactor_0 swigDelegate0;

	private SwigDelegateOdEditorReactor_1 swigDelegate1;

	private SwigDelegateOdEditorReactor_2 swigDelegate2;

	private SwigDelegateOdEditorReactor_3 swigDelegate3;

	private SwigDelegateOdEditorReactor_4 swigDelegate4;

	private SwigDelegateOdEditorReactor_5 swigDelegate5;

	private SwigDelegateOdEditorReactor_6 swigDelegate6;

	private SwigDelegateOdEditorReactor_7 swigDelegate7;

	private SwigDelegateOdEditorReactor_8 swigDelegate8;

	private SwigDelegateOdEditorReactor_9 swigDelegate9;

	private SwigDelegateOdEditorReactor_10 swigDelegate10;

	private SwigDelegateOdEditorReactor_11 swigDelegate11;

	private SwigDelegateOdEditorReactor_12 swigDelegate12;

	private SwigDelegateOdEditorReactor_13 swigDelegate13;

	private SwigDelegateOdEditorReactor_14 swigDelegate14;

	private SwigDelegateOdEditorReactor_15 swigDelegate15;

	private SwigDelegateOdEditorReactor_16 swigDelegate16;

	private SwigDelegateOdEditorReactor_17 swigDelegate17;

	private SwigDelegateOdEditorReactor_18 swigDelegate18;

	private SwigDelegateOdEditorReactor_19 swigDelegate19;

	private SwigDelegateOdEditorReactor_20 swigDelegate20;

	private SwigDelegateOdEditorReactor_21 swigDelegate21;

	private SwigDelegateOdEditorReactor_22 swigDelegate22;

	private SwigDelegateOdEditorReactor_23 swigDelegate23;

	private SwigDelegateOdEditorReactor_24 swigDelegate24;

	private SwigDelegateOdEditorReactor_25 swigDelegate25;

	private SwigDelegateOdEditorReactor_26 swigDelegate26;

	private SwigDelegateOdEditorReactor_27 swigDelegate27;

	private SwigDelegateOdEditorReactor_28 swigDelegate28;

	private SwigDelegateOdEditorReactor_29 swigDelegate29;

	private SwigDelegateOdEditorReactor_30 swigDelegate30;

	private SwigDelegateOdEditorReactor_31 swigDelegate31;

	private SwigDelegateOdEditorReactor_32 swigDelegate32;

	private SwigDelegateOdEditorReactor_33 swigDelegate33;

	private SwigDelegateOdEditorReactor_34 swigDelegate34;

	private SwigDelegateOdEditorReactor_35 swigDelegate35;

	private SwigDelegateOdEditorReactor_36 swigDelegate36;

	private SwigDelegateOdEditorReactor_37 swigDelegate37;

	private SwigDelegateOdEditorReactor_38 swigDelegate38;

	private SwigDelegateOdEditorReactor_39 swigDelegate39;

	private SwigDelegateOdEditorReactor_40 swigDelegate40;

	private SwigDelegateOdEditorReactor_41 swigDelegate41;

	private SwigDelegateOdEditorReactor_42 swigDelegate42;

	private SwigDelegateOdEditorReactor_43 swigDelegate43;

	private SwigDelegateOdEditorReactor_44 swigDelegate44;

	private SwigDelegateOdEditorReactor_45 swigDelegate45;

	private SwigDelegateOdEditorReactor_46 swigDelegate46;

	private SwigDelegateOdEditorReactor_47 swigDelegate47;

	private SwigDelegateOdEditorReactor_48 swigDelegate48;

	private SwigDelegateOdEditorReactor_49 swigDelegate49;

	private SwigDelegateOdEditorReactor_50 swigDelegate50;

	private SwigDelegateOdEditorReactor_51 swigDelegate51;

	private SwigDelegateOdEditorReactor_52 swigDelegate52;

	private SwigDelegateOdEditorReactor_53 swigDelegate53;

	private SwigDelegateOdEditorReactor_54 swigDelegate54;

	private SwigDelegateOdEditorReactor_55 swigDelegate55;

	private SwigDelegateOdEditorReactor_56 swigDelegate56;

	private SwigDelegateOdEditorReactor_57 swigDelegate57;

	private SwigDelegateOdEditorReactor_58 swigDelegate58;

	private SwigDelegateOdEditorReactor_59 swigDelegate59;

	private SwigDelegateOdEditorReactor_60 swigDelegate60;

	private SwigDelegateOdEditorReactor_61 swigDelegate61;

	private SwigDelegateOdEditorReactor_62 swigDelegate62;

	private SwigDelegateOdEditorReactor_63 swigDelegate63;

	private SwigDelegateOdEditorReactor_64 swigDelegate64;

	private SwigDelegateOdEditorReactor_65 swigDelegate65;

	private SwigDelegateOdEditorReactor_66 swigDelegate66;

	private SwigDelegateOdEditorReactor_67 swigDelegate67;

	private SwigDelegateOdEditorReactor_68 swigDelegate68;

	private SwigDelegateOdEditorReactor_69 swigDelegate69;

	private SwigDelegateOdEditorReactor_70 swigDelegate70;

	private SwigDelegateOdEditorReactor_71 swigDelegate71;

	private SwigDelegateOdEditorReactor_72 swigDelegate72;

	private SwigDelegateOdEditorReactor_73 swigDelegate73;

	private SwigDelegateOdEditorReactor_74 swigDelegate74;

	private SwigDelegateOdEditorReactor_75 swigDelegate75;

	private SwigDelegateOdEditorReactor_76 swigDelegate76;

	private SwigDelegateOdEditorReactor_77 swigDelegate77;

	private SwigDelegateOdEditorReactor_78 swigDelegate78;

	private SwigDelegateOdEditorReactor_79 swigDelegate79;

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

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes39 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes40 = new Type[3]
	{
		typeof(OdDbDatabase),
		typeof(string),
		typeof(OdDbDatabase)
	};

	private static Type[] swigMethodTypes41 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(OdDbDatabase)
	};

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes44 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes45 = new Type[3]
	{
		typeof(OdDbDatabase),
		typeof(OdDbObjectId),
		typeof(OdDbDatabase)
	};

	private static Type[] swigMethodTypes46 = new Type[3]
	{
		typeof(OdDbDatabase),
		typeof(string),
		typeof(OdDbDatabase)
	};

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes48 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes49 = new Type[2]
	{
		typeof(int),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes50 = new Type[2]
	{
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes51 = new Type[2]
	{
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes52 = new Type[2]
	{
		typeof(int),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes53 = new Type[3]
	{
		typeof(int),
		typeof(OdDbObjectId),
		typeof(string)
	};

	private static Type[] swigMethodTypes54 = new Type[2]
	{
		typeof(int),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes55 = new Type[2]
	{
		typeof(int),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes56 = new Type[2]
	{
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes57 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes62 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes63 = new Type[0];

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes65 = new Type[2]
	{
		typeof(ulong),
		typeof(bool)
	};

	private static Type[] swigMethodTypes66 = new Type[2]
	{
		typeof(ulong),
		typeof(bool)
	};

	private static Type[] swigMethodTypes67 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes68 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes69 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes70 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes71 = new Type[1] { typeof(OdDbObjectIdArray) };

	private static Type[] swigMethodTypes72 = new Type[0];

	private static Type[] swigMethodTypes73 = new Type[0];

	private static Type[] swigMethodTypes74 = new Type[0];

	private static Type[] swigMethodTypes75 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes76 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes77 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(string)
	};

	private static Type[] swigMethodTypes78 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(string)
	};

	private static Type[] swigMethodTypes79 = new Type[5]
	{
		typeof(OdDbDatabase),
		typeof(OdXrefSubCommand),
		typeof(OdDbObjectIdArray),
		typeof(OdStringArray),
		typeof(OdStringArray)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdEditorReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdEditorReactor obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdEditorReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdEditorReactor()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdEditorReactor(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdEditorReactor cast(OdRxObject pObj)
	{
		OdEditorReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEditorReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_isASwigExplicitOdEditorReactor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_queryXSwigExplicitOdEditorReactor(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void beginDwgOpen(string filename)
	{
		if (SwigDerivedClassHasMethod("beginDwgOpen", swigMethodTypes37))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginDwgOpenSwigExplicitOdEditorReactor(swigCPtr, filename);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginDwgOpen(swigCPtr, filename);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endDwgOpen(string filename)
	{
		if (SwigDerivedClassHasMethod("endDwgOpen", swigMethodTypes38))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_endDwgOpenSwigExplicitOdEditorReactor(swigCPtr, filename);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_endDwgOpen(swigCPtr, filename);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginClose(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("beginClose", swigMethodTypes39))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginCloseSwigExplicitOdEditorReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginClose(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void dwgFileOpened(OdDbDatabase pDb, string filename)
	{
		if (SwigDerivedClassHasMethod("dwgFileOpened", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_dwgFileOpenedSwigExplicitOdEditorReactor(swigCPtr, OdDbDatabase.getCPtr(pDb), filename);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_dwgFileOpened(swigCPtr, OdDbDatabase.getCPtr(pDb), filename);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginAttach(OdDbDatabase pToDb, string filename, OdDbDatabase pFromDb)
	{
		if (SwigDerivedClassHasMethod("beginAttach", swigMethodTypes40))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginAttachSwigExplicitOdEditorReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb), filename, OdDbDatabase.getCPtr(pFromDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginAttach(swigCPtr, OdDbDatabase.getCPtr(pToDb), filename, OdDbDatabase.getCPtr(pFromDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void otherAttach(OdDbDatabase pToDb, OdDbDatabase pFromDb)
	{
		if (SwigDerivedClassHasMethod("otherAttach", swigMethodTypes41))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_otherAttachSwigExplicitOdEditorReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdDbDatabase.getCPtr(pFromDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_otherAttach(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdDbDatabase.getCPtr(pFromDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortAttach(OdDbDatabase pFromDb)
	{
		if (SwigDerivedClassHasMethod("abortAttach", swigMethodTypes42))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_abortAttachSwigExplicitOdEditorReactor(swigCPtr, OdDbDatabase.getCPtr(pFromDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_abortAttach(swigCPtr, OdDbDatabase.getCPtr(pFromDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endAttach(OdDbDatabase pToDb)
	{
		if (SwigDerivedClassHasMethod("endAttach", swigMethodTypes43))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_endAttachSwigExplicitOdEditorReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_endAttach(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void redirected(OdDbObjectId newId, OdDbObjectId oldId)
	{
		if (SwigDerivedClassHasMethod("redirected", swigMethodTypes44))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_redirectedSwigExplicitOdEditorReactor(swigCPtr, OdDbObjectId.getCPtr(newId), OdDbObjectId.getCPtr(oldId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_redirected(swigCPtr, OdDbObjectId.getCPtr(newId), OdDbObjectId.getCPtr(oldId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void comandeered(OdDbDatabase pToDb, OdDbObjectId id, OdDbDatabase pFromDb)
	{
		if (SwigDerivedClassHasMethod("comandeered", swigMethodTypes45))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_comandeeredSwigExplicitOdEditorReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdDbObjectId.getCPtr(id), OdDbDatabase.getCPtr(pFromDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_comandeered(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdDbObjectId.getCPtr(id), OdDbDatabase.getCPtr(pFromDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginRestore(OdDbDatabase pToDb, string filename, OdDbDatabase pFromDb)
	{
		if (SwigDerivedClassHasMethod("beginRestore", swigMethodTypes46))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginRestoreSwigExplicitOdEditorReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb), filename, OdDbDatabase.getCPtr(pFromDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginRestore(swigCPtr, OdDbDatabase.getCPtr(pToDb), filename, OdDbDatabase.getCPtr(pFromDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortRestore(OdDbDatabase pToDb)
	{
		if (SwigDerivedClassHasMethod("abortRestore", swigMethodTypes47))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_abortRestoreSwigExplicitOdEditorReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_abortRestore(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endRestore(OdDbDatabase pToDb)
	{
		if (SwigDerivedClassHasMethod("endRestore", swigMethodTypes48))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_endRestoreSwigExplicitOdEditorReactor(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_endRestore(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xrefSubcommandBindItem(int activity, OdDbObjectId blockId)
	{
		if (SwigDerivedClassHasMethod("xrefSubcommandBindItem", swigMethodTypes49))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandBindItemSwigExplicitOdEditorReactor(swigCPtr, activity, OdDbObjectId.getCPtr(blockId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandBindItem(swigCPtr, activity, OdDbObjectId.getCPtr(blockId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xrefSubcommandAttachItem(int activity, string xrefPath)
	{
		if (SwigDerivedClassHasMethod("xrefSubcommandAttachItem", swigMethodTypes50))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandAttachItemSwigExplicitOdEditorReactor(swigCPtr, activity, xrefPath);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandAttachItem(swigCPtr, activity, xrefPath);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xrefSubcommandOverlayItem(int activity, string xrefPath)
	{
		if (SwigDerivedClassHasMethod("xrefSubcommandOverlayItem", swigMethodTypes51))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandOverlayItemSwigExplicitOdEditorReactor(swigCPtr, activity, xrefPath);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandOverlayItem(swigCPtr, activity, xrefPath);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xrefSubcommandDetachItem(int activity, OdDbObjectId blockId)
	{
		if (SwigDerivedClassHasMethod("xrefSubcommandDetachItem", swigMethodTypes52))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandDetachItemSwigExplicitOdEditorReactor(swigCPtr, activity, OdDbObjectId.getCPtr(blockId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandDetachItem(swigCPtr, activity, OdDbObjectId.getCPtr(blockId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xrefSubcommandPathItem(int activity, OdDbObjectId blockId, string newPath)
	{
		if (SwigDerivedClassHasMethod("xrefSubcommandPathItem", swigMethodTypes53))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandPathItemSwigExplicitOdEditorReactor(swigCPtr, activity, OdDbObjectId.getCPtr(blockId), newPath);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandPathItem(swigCPtr, activity, OdDbObjectId.getCPtr(blockId), newPath);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xrefSubcommandReloadItem(int activity, OdDbObjectId blockId)
	{
		if (SwigDerivedClassHasMethod("xrefSubcommandReloadItem", swigMethodTypes54))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandReloadItemSwigExplicitOdEditorReactor(swigCPtr, activity, OdDbObjectId.getCPtr(blockId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandReloadItem(swigCPtr, activity, OdDbObjectId.getCPtr(blockId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xrefSubcommandUnloadItem(int activity, OdDbObjectId blockId)
	{
		if (SwigDerivedClassHasMethod("xrefSubcommandUnloadItem", swigMethodTypes55))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandUnloadItemSwigExplicitOdEditorReactor(swigCPtr, activity, OdDbObjectId.getCPtr(blockId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubcommandUnloadItem(swigCPtr, activity, OdDbObjectId.getCPtr(blockId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void undoSubcommandAuto(int activity, bool undoAuto)
	{
		if (SwigDerivedClassHasMethod("undoSubcommandAuto", swigMethodTypes56))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandAutoSwigExplicitOdEditorReactor(swigCPtr, activity, undoAuto);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandAuto(swigCPtr, activity, undoAuto);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void undoSubcommandControl(int activity, int option)
	{
		if (SwigDerivedClassHasMethod("undoSubcommandControl", swigMethodTypes57))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandControlSwigExplicitOdEditorReactor(swigCPtr, activity, option);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandControl(swigCPtr, activity, option);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void undoSubcommandBegin(int activity)
	{
		if (SwigDerivedClassHasMethod("undoSubcommandBegin", swigMethodTypes58))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandBeginSwigExplicitOdEditorReactor(swigCPtr, activity);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandBegin(swigCPtr, activity);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void undoSubcommandEnd(int activity)
	{
		if (SwigDerivedClassHasMethod("undoSubcommandEnd", swigMethodTypes59))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandEndSwigExplicitOdEditorReactor(swigCPtr, activity);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandEnd(swigCPtr, activity);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void undoSubcommandMark(int activity)
	{
		if (SwigDerivedClassHasMethod("undoSubcommandMark", swigMethodTypes60))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandMarkSwigExplicitOdEditorReactor(swigCPtr, activity);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandMark(swigCPtr, activity);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void undoSubcommandBack(int activity)
	{
		if (SwigDerivedClassHasMethod("undoSubcommandBack", swigMethodTypes61))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandBackSwigExplicitOdEditorReactor(swigCPtr, activity);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandBack(swigCPtr, activity);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void undoSubcommandNumber(int activity, int numSteps)
	{
		if (SwigDerivedClassHasMethod("undoSubcommandNumber", swigMethodTypes62))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandNumberSwigExplicitOdEditorReactor(swigCPtr, activity, numSteps);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_undoSubcommandNumber(swigCPtr, activity, numSteps);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pickfirstModified()
	{
		if (SwigDerivedClassHasMethod("pickfirstModified", swigMethodTypes63))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_pickfirstModifiedSwigExplicitOdEditorReactor(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_pickfirstModified(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layoutSwitched(string newLayoutName)
	{
		if (SwigDerivedClassHasMethod("layoutSwitched", swigMethodTypes64))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_layoutSwitchedSwigExplicitOdEditorReactor(swigCPtr, newLayoutName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_layoutSwitched(swigCPtr, newLayoutName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void docFrameMovedOrResized(ulong hwndDocFrame, bool moved)
	{
		if (SwigDerivedClassHasMethod("docFrameMovedOrResized", swigMethodTypes65))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_docFrameMovedOrResizedSwigExplicitOdEditorReactor(swigCPtr, hwndDocFrame, moved);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_docFrameMovedOrResized(swigCPtr, hwndDocFrame, moved);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mainFrameMovedOrResized(ulong hwndMainFrame, bool moved)
	{
		if (SwigDerivedClassHasMethod("mainFrameMovedOrResized", swigMethodTypes66))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_mainFrameMovedOrResizedSwigExplicitOdEditorReactor(swigCPtr, hwndMainFrame, moved);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_mainFrameMovedOrResized(swigCPtr, hwndMainFrame, moved);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginDoubleClick(OdGePoint3d clickPoint)
	{
		if (SwigDerivedClassHasMethod("beginDoubleClick", swigMethodTypes67))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginDoubleClickSwigExplicitOdEditorReactor(swigCPtr, OdGePoint3d.getCPtr(clickPoint));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginDoubleClick(swigCPtr, OdGePoint3d.getCPtr(clickPoint));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginRightClick(OdGePoint3d clickPoint)
	{
		if (SwigDerivedClassHasMethod("beginRightClick", swigMethodTypes68))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginRightClickSwigExplicitOdEditorReactor(swigCPtr, OdGePoint3d.getCPtr(clickPoint));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginRightClick(swigCPtr, OdGePoint3d.getCPtr(clickPoint));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void toolbarBitmapSizeWillChange(bool largeBitmaps)
	{
		if (SwigDerivedClassHasMethod("toolbarBitmapSizeWillChange", swigMethodTypes69))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_toolbarBitmapSizeWillChangeSwigExplicitOdEditorReactor(swigCPtr, largeBitmaps);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_toolbarBitmapSizeWillChange(swigCPtr, largeBitmaps);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void toolbarBitmapSizeChanged(bool largeBitmaps)
	{
		if (SwigDerivedClassHasMethod("toolbarBitmapSizeChanged", swigMethodTypes70))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_toolbarBitmapSizeChangedSwigExplicitOdEditorReactor(swigCPtr, largeBitmaps);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_toolbarBitmapSizeChanged(swigCPtr, largeBitmaps);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void objectsLazyLoaded(OdDbObjectIdArray objectIds)
	{
		if (SwigDerivedClassHasMethod("objectsLazyLoaded", swigMethodTypes71))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_objectsLazyLoadedSwigExplicitOdEditorReactor(swigCPtr, OdDbObjectIdArray.getCPtr(objectIds));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_objectsLazyLoaded(swigCPtr, OdDbObjectIdArray.getCPtr(objectIds));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginQuit()
	{
		if (SwigDerivedClassHasMethod("beginQuit", swigMethodTypes72))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginQuitSwigExplicitOdEditorReactor(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_beginQuit(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void quitAborted()
	{
		if (SwigDerivedClassHasMethod("quitAborted", swigMethodTypes73))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_quitAbortedSwigExplicitOdEditorReactor(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_quitAborted(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void quitWillStart()
	{
		if (SwigDerivedClassHasMethod("quitWillStart", swigMethodTypes74))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_quitWillStartSwigExplicitOdEditorReactor(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_quitWillStart(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void modelessOperationWillStart(string contextString)
	{
		if (SwigDerivedClassHasMethod("modelessOperationWillStart", swigMethodTypes75))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_modelessOperationWillStartSwigExplicitOdEditorReactor(swigCPtr, contextString);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_modelessOperationWillStart(swigCPtr, contextString);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void modelessOperationEnded(string contextString)
	{
		if (SwigDerivedClassHasMethod("modelessOperationEnded", swigMethodTypes76))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_modelessOperationEndedSwigExplicitOdEditorReactor(swigCPtr, contextString);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_modelessOperationEnded(swigCPtr, contextString);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void sysVarChanged(OdDbDatabase pDb, string varName)
	{
		if (SwigDerivedClassHasMethod("sysVarChanged", swigMethodTypes77))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_sysVarChangedSwigExplicitOdEditorReactor(swigCPtr, OdDbDatabase.getCPtr(pDb), varName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_sysVarChanged(swigCPtr, OdDbDatabase.getCPtr(pDb), varName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void sysVarWillChange(OdDbDatabase pDb, string varName)
	{
		if (SwigDerivedClassHasMethod("sysVarWillChange", swigMethodTypes78))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_sysVarWillChangeSwigExplicitOdEditorReactor(swigCPtr, OdDbDatabase.getCPtr(pDb), varName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_sysVarWillChange(swigCPtr, OdDbDatabase.getCPtr(pDb), varName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xrefSubCommandStart(OdDbDatabase pHostDb, OdXrefSubCommand subCmd, OdDbObjectIdArray btrIds, OdStringArray btrNames, OdStringArray paths)
	{
		if (SwigDerivedClassHasMethod("xrefSubCommandStart", swigMethodTypes79))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubCommandStartSwigExplicitOdEditorReactor__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubCommandStart__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void xrefSubCommandStart(OdDbDatabase pHostDb, OdXrefSubCommand subCmd, OdDbObjectIdArray btrIds, OdStringArray btrNames, OdStringArray paths, out bool veto)
	{
		if (SwigDerivedClassHasMethod("xrefSubCommandStart", swigMethodTypes34))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubCommandStartSwigExplicitOdEditorReactor__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle, out veto);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_xrefSubCommandStart__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle, out veto);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdEditorReactor createObject()
	{
		OdEditorReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEditorReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_createObject(), bOwn: true, bTryAddToTransaction: true);
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
			swigDelegate34 = SwigDirectorMethodxrefSubCommandStart__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("xrefSubCommandEnd", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodxrefSubCommandEnd;
		}
		if (SwigDerivedClassHasMethod("xrefSubCommandAborted", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodxrefSubCommandAborted;
		}
		if (SwigDerivedClassHasMethod("beginDwgOpen", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodbeginDwgOpen;
		}
		if (SwigDerivedClassHasMethod("endDwgOpen", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodendDwgOpen;
		}
		if (SwigDerivedClassHasMethod("beginClose", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodbeginClose;
		}
		if (SwigDerivedClassHasMethod("beginAttach", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodbeginAttach;
		}
		if (SwigDerivedClassHasMethod("otherAttach", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodotherAttach;
		}
		if (SwigDerivedClassHasMethod("abortAttach", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodabortAttach;
		}
		if (SwigDerivedClassHasMethod("endAttach", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodendAttach;
		}
		if (SwigDerivedClassHasMethod("redirected", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodredirected;
		}
		if (SwigDerivedClassHasMethod("comandeered", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodcomandeered;
		}
		if (SwigDerivedClassHasMethod("beginRestore", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodbeginRestore;
		}
		if (SwigDerivedClassHasMethod("abortRestore", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodabortRestore;
		}
		if (SwigDerivedClassHasMethod("endRestore", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodendRestore;
		}
		if (SwigDerivedClassHasMethod("xrefSubcommandBindItem", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodxrefSubcommandBindItem;
		}
		if (SwigDerivedClassHasMethod("xrefSubcommandAttachItem", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodxrefSubcommandAttachItem;
		}
		if (SwigDerivedClassHasMethod("xrefSubcommandOverlayItem", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodxrefSubcommandOverlayItem;
		}
		if (SwigDerivedClassHasMethod("xrefSubcommandDetachItem", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodxrefSubcommandDetachItem;
		}
		if (SwigDerivedClassHasMethod("xrefSubcommandPathItem", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodxrefSubcommandPathItem;
		}
		if (SwigDerivedClassHasMethod("xrefSubcommandReloadItem", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodxrefSubcommandReloadItem;
		}
		if (SwigDerivedClassHasMethod("xrefSubcommandUnloadItem", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodxrefSubcommandUnloadItem;
		}
		if (SwigDerivedClassHasMethod("undoSubcommandAuto", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodundoSubcommandAuto;
		}
		if (SwigDerivedClassHasMethod("undoSubcommandControl", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodundoSubcommandControl;
		}
		if (SwigDerivedClassHasMethod("undoSubcommandBegin", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodundoSubcommandBegin;
		}
		if (SwigDerivedClassHasMethod("undoSubcommandEnd", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodundoSubcommandEnd;
		}
		if (SwigDerivedClassHasMethod("undoSubcommandMark", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodundoSubcommandMark;
		}
		if (SwigDerivedClassHasMethod("undoSubcommandBack", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodundoSubcommandBack;
		}
		if (SwigDerivedClassHasMethod("undoSubcommandNumber", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodundoSubcommandNumber;
		}
		if (SwigDerivedClassHasMethod("pickfirstModified", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodpickfirstModified;
		}
		if (SwigDerivedClassHasMethod("layoutSwitched", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodlayoutSwitched;
		}
		if (SwigDerivedClassHasMethod("docFrameMovedOrResized", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethoddocFrameMovedOrResized;
		}
		if (SwigDerivedClassHasMethod("mainFrameMovedOrResized", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodmainFrameMovedOrResized;
		}
		if (SwigDerivedClassHasMethod("beginDoubleClick", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodbeginDoubleClick;
		}
		if (SwigDerivedClassHasMethod("beginRightClick", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodbeginRightClick;
		}
		if (SwigDerivedClassHasMethod("toolbarBitmapSizeWillChange", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodtoolbarBitmapSizeWillChange;
		}
		if (SwigDerivedClassHasMethod("toolbarBitmapSizeChanged", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodtoolbarBitmapSizeChanged;
		}
		if (SwigDerivedClassHasMethod("objectsLazyLoaded", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodobjectsLazyLoaded;
		}
		if (SwigDerivedClassHasMethod("beginQuit", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodbeginQuit;
		}
		if (SwigDerivedClassHasMethod("quitAborted", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodquitAborted;
		}
		if (SwigDerivedClassHasMethod("quitWillStart", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodquitWillStart;
		}
		if (SwigDerivedClassHasMethod("modelessOperationWillStart", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodmodelessOperationWillStart;
		}
		if (SwigDerivedClassHasMethod("modelessOperationEnded", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodmodelessOperationEnded;
		}
		if (SwigDerivedClassHasMethod("sysVarChanged", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodsysVarChanged;
		}
		if (SwigDerivedClassHasMethod("sysVarWillChange", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodsysVarWillChange;
		}
		if (SwigDerivedClassHasMethod("xrefSubCommandStart", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodxrefSubCommandStart__SWIG_0;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdEditorReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdEditorReactor));
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

	private void SwigDirectorMethodxrefSubCommandStart__SWIG_1(IntPtr pHostDb, int subCmd, IntPtr btrIds, IntPtr btrNames, IntPtr paths, bool veto)
	{
		try
		{
			xrefSubCommandStart(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pHostDb, bOwn: false, bTryAddToTransaction: false), (OdXrefSubCommand)subCmd, new OdDbObjectIdArray(btrIds, cMemoryOwn: false), new OdStringArray(btrNames, cMemoryOwn: true), new OdStringArray(paths, cMemoryOwn: true), out veto);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

	private void SwigDirectorMethodbeginDwgOpen([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		try
		{
			beginDwgOpen(filename);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodendDwgOpen([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		try
		{
			endDwgOpen(filename);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginClose(IntPtr pDb)
	{
		try
		{
			beginClose(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginAttach(IntPtr pToDb, [MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pFromDb)
	{
		try
		{
			beginAttach(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false), filename, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodotherAttach(IntPtr pToDb, IntPtr pFromDb)
	{
		try
		{
			otherAttach(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodabortAttach(IntPtr pFromDb)
	{
		try
		{
			abortAttach(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodendAttach(IntPtr pToDb)
	{
		try
		{
			endAttach(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodredirected(IntPtr newId, IntPtr oldId)
	{
		try
		{
			redirected(new OdDbObjectId(newId, cMemoryOwn: true), new OdDbObjectId(oldId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodcomandeered(IntPtr pToDb, IntPtr id, IntPtr pFromDb)
	{
		try
		{
			comandeered(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false), new OdDbObjectId(id, cMemoryOwn: true), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginRestore(IntPtr pToDb, [MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pFromDb)
	{
		try
		{
			beginRestore(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false), filename, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pFromDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodabortRestore(IntPtr pToDb)
	{
		try
		{
			abortRestore(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodendRestore(IntPtr pToDb)
	{
		try
		{
			endRestore(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pToDb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodxrefSubcommandBindItem(int activity, IntPtr blockId)
	{
		try
		{
			xrefSubcommandBindItem(activity, new OdDbObjectId(blockId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodxrefSubcommandAttachItem(int activity, [MarshalAs(UnmanagedType.LPWStr)] string xrefPath)
	{
		try
		{
			xrefSubcommandAttachItem(activity, xrefPath);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodxrefSubcommandOverlayItem(int activity, [MarshalAs(UnmanagedType.LPWStr)] string xrefPath)
	{
		try
		{
			xrefSubcommandOverlayItem(activity, xrefPath);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodxrefSubcommandDetachItem(int activity, IntPtr blockId)
	{
		try
		{
			xrefSubcommandDetachItem(activity, new OdDbObjectId(blockId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodxrefSubcommandPathItem(int activity, IntPtr blockId, [MarshalAs(UnmanagedType.LPWStr)] string newPath)
	{
		try
		{
			xrefSubcommandPathItem(activity, new OdDbObjectId(blockId, cMemoryOwn: true), newPath);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodxrefSubcommandReloadItem(int activity, IntPtr blockId)
	{
		try
		{
			xrefSubcommandReloadItem(activity, new OdDbObjectId(blockId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodxrefSubcommandUnloadItem(int activity, IntPtr blockId)
	{
		try
		{
			xrefSubcommandUnloadItem(activity, new OdDbObjectId(blockId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodundoSubcommandAuto(int activity, bool undoAuto)
	{
		try
		{
			undoSubcommandAuto(activity, undoAuto);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodundoSubcommandControl(int activity, int option)
	{
		try
		{
			undoSubcommandControl(activity, option);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodundoSubcommandBegin(int activity)
	{
		try
		{
			undoSubcommandBegin(activity);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodundoSubcommandEnd(int activity)
	{
		try
		{
			undoSubcommandEnd(activity);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodundoSubcommandMark(int activity)
	{
		try
		{
			undoSubcommandMark(activity);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodundoSubcommandBack(int activity)
	{
		try
		{
			undoSubcommandBack(activity);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodundoSubcommandNumber(int activity, int numSteps)
	{
		try
		{
			undoSubcommandNumber(activity, numSteps);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpickfirstModified()
	{
		try
		{
			pickfirstModified();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodlayoutSwitched([MarshalAs(UnmanagedType.LPWStr)] string newLayoutName)
	{
		try
		{
			layoutSwitched(newLayoutName);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddocFrameMovedOrResized(ulong hwndDocFrame, bool moved)
	{
		try
		{
			docFrameMovedOrResized(hwndDocFrame, moved);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodmainFrameMovedOrResized(ulong hwndMainFrame, bool moved)
	{
		try
		{
			mainFrameMovedOrResized(hwndMainFrame, moved);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginDoubleClick(IntPtr clickPoint)
	{
		try
		{
			beginDoubleClick(new OdGePoint3d(clickPoint, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginRightClick(IntPtr clickPoint)
	{
		try
		{
			beginRightClick(new OdGePoint3d(clickPoint, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodtoolbarBitmapSizeWillChange(bool largeBitmaps)
	{
		try
		{
			toolbarBitmapSizeWillChange(largeBitmaps);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodtoolbarBitmapSizeChanged(bool largeBitmaps)
	{
		try
		{
			toolbarBitmapSizeChanged(largeBitmaps);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodobjectsLazyLoaded(IntPtr objectIds)
	{
		try
		{
			objectsLazyLoaded(new OdDbObjectIdArray(objectIds, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodbeginQuit()
	{
		try
		{
			beginQuit();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodquitAborted()
	{
		try
		{
			quitAborted();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodquitWillStart()
	{
		try
		{
			quitWillStart();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodmodelessOperationWillStart([MarshalAs(UnmanagedType.LPWStr)] string contextString)
	{
		try
		{
			modelessOperationWillStart(contextString);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodmodelessOperationEnded([MarshalAs(UnmanagedType.LPWStr)] string contextString)
	{
		try
		{
			modelessOperationEnded(contextString);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsysVarChanged(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string varName)
	{
		try
		{
			sysVarChanged(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), varName);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsysVarWillChange(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string varName)
	{
		try
		{
			sysVarWillChange(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), varName);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodxrefSubCommandStart__SWIG_0(IntPtr pHostDb, int subCmd, IntPtr btrIds, IntPtr btrNames, IntPtr paths)
	{
		try
		{
			xrefSubCommandStart(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pHostDb, bOwn: false, bTryAddToTransaction: false), (OdXrefSubCommand)subCmd, new OdDbObjectIdArray(btrIds, cMemoryOwn: false), new OdStringArray(btrNames, cMemoryOwn: true), new OdStringArray(paths, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

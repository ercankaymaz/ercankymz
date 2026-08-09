using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class ExHostAppServices : OdDbHostAppServices2
{
	public delegate IntPtr SwigDelegateExHostAppServices_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateExHostAppServices_1();

	public delegate void SwigDelegateExHostAppServices_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_3([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb, int hint);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_4([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_5([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate IntPtr SwigDelegateExHostAppServices_6();

	public delegate void SwigDelegateExHostAppServices_7(IntPtr pProgressMeter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_8();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_9();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_10();

	public delegate int SwigDelegateExHostAppServices_11();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_12();

	public delegate int SwigDelegateExHostAppServices_13();

	public delegate int SwigDelegateExHostAppServices_14();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_15();

	public delegate void SwigDelegateExHostAppServices_16([MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateExHostAppServices_17(string warnVisGroup, [MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateExHostAppServices_18(int warningOb);

	public delegate void SwigDelegateExHostAppServices_19(string warnVisGroup, int warningOb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_20(uint errorCode);

	public delegate IntPtr SwigDelegateExHostAppServices_21();

	public delegate IntPtr SwigDelegateExHostAppServices_22();

	public delegate void SwigDelegateExHostAppServices_23(IntPtr pAuditInfo, [MarshalAs(UnmanagedType.LPWStr)] string strLine, int printDest);

	public delegate bool SwigDelegateExHostAppServices_24(IntPtr description, IntPtr filename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_25();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_26();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_27([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_28([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_29(IntPtr pFont, char unicodeChar, IntPtr pDb);

	public delegate bool SwigDelegateExHostAppServices_30(IntPtr aDirs);

	public delegate void SwigDelegateExHostAppServices_31(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath, [MarshalAs(UnmanagedType.LPWStr)] string sFilter);

	public delegate void SwigDelegateExHostAppServices_32(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_33(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename, [MarshalAs(UnmanagedType.LPWStr)] string filter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_34(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_35(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_36(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_37(int flags);

	public delegate IntPtr SwigDelegateExHostAppServices_38(IntPtr pViewObj, IntPtr pDb, uint flags);

	public delegate IntPtr SwigDelegateExHostAppServices_39(IntPtr pViewObj, IntPtr pDb);

	public delegate IntPtr SwigDelegateExHostAppServices_40(IntPtr pViewObj);

	public delegate IntPtr SwigDelegateExHostAppServices_41();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_42();

	public delegate int SwigDelegateExHostAppServices_43(int mtMode);

	public delegate int SwigDelegateExHostAppServices_44([MarshalAs(UnmanagedType.LPWStr)] string varName, IntPtr value);

	public delegate int SwigDelegateExHostAppServices_45([MarshalAs(UnmanagedType.LPWStr)] string varName, [MarshalAs(UnmanagedType.LPWStr)] string newValue);

	public delegate IntPtr SwigDelegateExHostAppServices_46();

	public delegate IntPtr SwigDelegateExHostAppServices_47(IntPtr pStreamBuf, bool allowCPConversion, bool partialLoad, [MarshalAs(UnmanagedType.LPWStr)] string password);

	public delegate IntPtr SwigDelegateExHostAppServices_48(IntPtr pStreamBuf, bool allowCPConversion, bool partialLoad);

	public delegate IntPtr SwigDelegateExHostAppServices_49(IntPtr pStreamBuf, bool allowCPConversion);

	public delegate IntPtr SwigDelegateExHostAppServices_50(IntPtr pStreamBuf);

	public delegate IntPtr SwigDelegateExHostAppServices_51(IntPtr pStreamBuf, IntPtr pAuditInfo, [MarshalAs(UnmanagedType.LPWStr)] string password);

	public delegate IntPtr SwigDelegateExHostAppServices_52(IntPtr pStreamBuf, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateExHostAppServices_53(IntPtr pStreamBuf);

	public delegate IntPtr SwigDelegateExHostAppServices_54([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad, int shareMode, [MarshalAs(UnmanagedType.LPWStr)] string password);

	public delegate IntPtr SwigDelegateExHostAppServices_55([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad, int shareMode);

	public delegate IntPtr SwigDelegateExHostAppServices_56([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad);

	public delegate IntPtr SwigDelegateExHostAppServices_57([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion);

	public delegate IntPtr SwigDelegateExHostAppServices_58([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate void SwigDelegateExHostAppServices_59(int warningOb, IntPtr objectId);

	public delegate void SwigDelegateExHostAppServices_60(string warnVisGroup, int warningOb, IntPtr objectId);

	public delegate void SwigDelegateExHostAppServices_61(IntPtr err);

	public delegate void SwigDelegateExHostAppServices_62(string warnVisGroup, IntPtr err);

	public delegate bool SwigDelegateExHostAppServices_63();

	public delegate IntPtr SwigDelegateExHostAppServices_64();

	public delegate IntPtr SwigDelegateExHostAppServices_65();

	public delegate bool SwigDelegateExHostAppServices_66([MarshalAs(UnmanagedType.LPWStr)] string dwgName, bool isXref, IntPtr password);

	public delegate IntPtr SwigDelegateExHostAppServices_67();

	public delegate IntPtr SwigDelegateExHostAppServices_68();

	public delegate IntPtr SwigDelegateExHostAppServices_69();

	public delegate uint SwigDelegateExHostAppServices_70();

	public delegate void SwigDelegateExHostAppServices_71(uint nWidth, uint nHeight);

	public delegate IntPtr SwigDelegateExHostAppServices_72(IntPtr arg0);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateExHostAppServices_73(IntPtr pRecord);

	public delegate void SwigDelegateExHostAppServices_74([MarshalAs(UnmanagedType.LPWStr)] string displayString);

	public delegate void SwigDelegateExHostAppServices_75();

	public delegate void SwigDelegateExHostAppServices_76();

	public delegate void SwigDelegateExHostAppServices_77();

	public delegate void SwigDelegateExHostAppServices_78(int max);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateExHostAppServices_0 swigDelegate0;

	private SwigDelegateExHostAppServices_1 swigDelegate1;

	private SwigDelegateExHostAppServices_2 swigDelegate2;

	private SwigDelegateExHostAppServices_3 swigDelegate3;

	private SwigDelegateExHostAppServices_4 swigDelegate4;

	private SwigDelegateExHostAppServices_5 swigDelegate5;

	private SwigDelegateExHostAppServices_6 swigDelegate6;

	private SwigDelegateExHostAppServices_7 swigDelegate7;

	private SwigDelegateExHostAppServices_8 swigDelegate8;

	private SwigDelegateExHostAppServices_9 swigDelegate9;

	private SwigDelegateExHostAppServices_10 swigDelegate10;

	private SwigDelegateExHostAppServices_11 swigDelegate11;

	private SwigDelegateExHostAppServices_12 swigDelegate12;

	private SwigDelegateExHostAppServices_13 swigDelegate13;

	private SwigDelegateExHostAppServices_14 swigDelegate14;

	private SwigDelegateExHostAppServices_15 swigDelegate15;

	private SwigDelegateExHostAppServices_16 swigDelegate16;

	private SwigDelegateExHostAppServices_17 swigDelegate17;

	private SwigDelegateExHostAppServices_18 swigDelegate18;

	private SwigDelegateExHostAppServices_19 swigDelegate19;

	private SwigDelegateExHostAppServices_20 swigDelegate20;

	private SwigDelegateExHostAppServices_21 swigDelegate21;

	private SwigDelegateExHostAppServices_22 swigDelegate22;

	private SwigDelegateExHostAppServices_23 swigDelegate23;

	private SwigDelegateExHostAppServices_24 swigDelegate24;

	private SwigDelegateExHostAppServices_25 swigDelegate25;

	private SwigDelegateExHostAppServices_26 swigDelegate26;

	private SwigDelegateExHostAppServices_27 swigDelegate27;

	private SwigDelegateExHostAppServices_28 swigDelegate28;

	private SwigDelegateExHostAppServices_29 swigDelegate29;

	private SwigDelegateExHostAppServices_30 swigDelegate30;

	private SwigDelegateExHostAppServices_31 swigDelegate31;

	private SwigDelegateExHostAppServices_32 swigDelegate32;

	private SwigDelegateExHostAppServices_33 swigDelegate33;

	private SwigDelegateExHostAppServices_34 swigDelegate34;

	private SwigDelegateExHostAppServices_35 swigDelegate35;

	private SwigDelegateExHostAppServices_36 swigDelegate36;

	private SwigDelegateExHostAppServices_37 swigDelegate37;

	private SwigDelegateExHostAppServices_38 swigDelegate38;

	private SwigDelegateExHostAppServices_39 swigDelegate39;

	private SwigDelegateExHostAppServices_40 swigDelegate40;

	private SwigDelegateExHostAppServices_41 swigDelegate41;

	private SwigDelegateExHostAppServices_42 swigDelegate42;

	private SwigDelegateExHostAppServices_43 swigDelegate43;

	private SwigDelegateExHostAppServices_44 swigDelegate44;

	private SwigDelegateExHostAppServices_45 swigDelegate45;

	private SwigDelegateExHostAppServices_46 swigDelegate46;

	private SwigDelegateExHostAppServices_47 swigDelegate47;

	private SwigDelegateExHostAppServices_48 swigDelegate48;

	private SwigDelegateExHostAppServices_49 swigDelegate49;

	private SwigDelegateExHostAppServices_50 swigDelegate50;

	private SwigDelegateExHostAppServices_51 swigDelegate51;

	private SwigDelegateExHostAppServices_52 swigDelegate52;

	private SwigDelegateExHostAppServices_53 swigDelegate53;

	private SwigDelegateExHostAppServices_54 swigDelegate54;

	private SwigDelegateExHostAppServices_55 swigDelegate55;

	private SwigDelegateExHostAppServices_56 swigDelegate56;

	private SwigDelegateExHostAppServices_57 swigDelegate57;

	private SwigDelegateExHostAppServices_58 swigDelegate58;

	private SwigDelegateExHostAppServices_59 swigDelegate59;

	private SwigDelegateExHostAppServices_60 swigDelegate60;

	private SwigDelegateExHostAppServices_61 swigDelegate61;

	private SwigDelegateExHostAppServices_62 swigDelegate62;

	private SwigDelegateExHostAppServices_63 swigDelegate63;

	private SwigDelegateExHostAppServices_64 swigDelegate64;

	private SwigDelegateExHostAppServices_65 swigDelegate65;

	private SwigDelegateExHostAppServices_66 swigDelegate66;

	private SwigDelegateExHostAppServices_67 swigDelegate67;

	private SwigDelegateExHostAppServices_68 swigDelegate68;

	private SwigDelegateExHostAppServices_69 swigDelegate69;

	private SwigDelegateExHostAppServices_70 swigDelegate70;

	private SwigDelegateExHostAppServices_71 swigDelegate71;

	private SwigDelegateExHostAppServices_72 swigDelegate72;

	private SwigDelegateExHostAppServices_73 swigDelegate73;

	private SwigDelegateExHostAppServices_74 swigDelegate74;

	private SwigDelegateExHostAppServices_75 swigDelegate75;

	private SwigDelegateExHostAppServices_76 swigDelegate76;

	private SwigDelegateExHostAppServices_77 swigDelegate77;

	private SwigDelegateExHostAppServices_78 swigDelegate78;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(string),
		typeof(OdRxObject),
		typeof(OdDbBaseHostAppServices_FindFileHint)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(string),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdDbHostAppProgressMeter) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdResult) };

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(string),
		typeof(OdResult)
	};

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[3]
	{
		typeof(OdAuditInfo),
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes24 = new Type[2]
	{
		typeof(OdTtfDescriptor),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes25 = new Type[0];

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[2]
	{
		typeof(string),
		typeof(OdTagFontType)
	};

	private static Type[] swigMethodTypes28 = new Type[2]
	{
		typeof(string),
		typeof(OdTagFontType)
	};

	private static Type[] swigMethodTypes29 = new Type[3]
	{
		typeof(OdFont),
		typeof(char),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(OdStringArray) };

	private static Type[] swigMethodTypes31 = new Type[3]
	{
		typeof(OdStringArray),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes32 = new Type[2]
	{
		typeof(OdStringArray),
		typeof(string)
	};

	private static Type[] swigMethodTypes33 = new Type[5]
	{
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes34 = new Type[4]
	{
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes35 = new Type[3]
	{
		typeof(int),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes36 = new Type[2]
	{
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes38 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdRxObject),
		typeof(uint)
	};

	private static Type[] swigMethodTypes39 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[0];

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(MultiThreadedMode) };

	private static Type[] swigMethodTypes44 = new Type[2]
	{
		typeof(string),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes45 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes46 = new Type[0];

	private static Type[] swigMethodTypes47 = new Type[4]
	{
		typeof(OdStreamBuf),
		typeof(bool),
		typeof(bool),
		typeof(string)
	};

	private static Type[] swigMethodTypes48 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes49 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(bool)
	};

	private static Type[] swigMethodTypes50 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes51 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(OdDbAuditInfo),
		typeof(string)
	};

	private static Type[] swigMethodTypes52 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(OdDbAuditInfo)
	};

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes54 = new Type[5]
	{
		typeof(string),
		typeof(bool),
		typeof(bool),
		typeof(Oda_FileShareMode),
		typeof(string)
	};

	private static Type[] swigMethodTypes55 = new Type[4]
	{
		typeof(string),
		typeof(bool),
		typeof(bool),
		typeof(Oda_FileShareMode)
	};

	private static Type[] swigMethodTypes56 = new Type[3]
	{
		typeof(string),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes57 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes59 = new Type[2]
	{
		typeof(OdResult),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes60 = new Type[3]
	{
		typeof(string),
		typeof(OdResult),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(OdError) };

	private static Type[] swigMethodTypes62 = new Type[2]
	{
		typeof(string),
		typeof(OdError)
	};

	private static Type[] swigMethodTypes63 = new Type[0];

	private static Type[] swigMethodTypes64 = new Type[0];

	private static Type[] swigMethodTypes65 = new Type[0];

	private static Type[] swigMethodTypes66 = new Type[3]
	{
		typeof(string),
		typeof(bool),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes67 = new Type[0];

	private static Type[] swigMethodTypes68 = new Type[0];

	private static Type[] swigMethodTypes69 = new Type[0];

	private static Type[] swigMethodTypes70 = new Type[0];

	private static Type[] swigMethodTypes71 = new Type[2]
	{
		typeof(uint).MakeByRefType(),
		typeof(uint).MakeByRefType()
	};

	private static Type[] swigMethodTypes72 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes73 = new Type[1] { typeof(OdDbSymbolTableRecord) };

	private static Type[] swigMethodTypes74 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes75 = new Type[0];

	private static Type[] swigMethodTypes76 = new Type[0];

	private static Type[] swigMethodTypes77 = new Type[0];

	private static Type[] swigMethodTypes78 = new Type[1] { typeof(int) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public ExHostAppServices(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(ExHostAppServices obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_ExHostAppServices(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public ExHostAppServices()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_ExHostAppServices(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public override OdDbHostAppProgressMeter newProgressMeter()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("newProgressMeter", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_newProgressMeterSwigExplicitExHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_newProgressMeter(swigCPtr));
		OdDbHostAppProgressMeter result = ((intPtr == IntPtr.Zero) ? null : new OdDbHostAppProgressMeter(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void releaseProgressMeter(OdDbHostAppProgressMeter pProgressMeter)
	{
		if (SwigDerivedClassHasMethod("releaseProgressMeter", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_releaseProgressMeterSwigExplicitExHostAppServices(swigCPtr, OdDbHostAppProgressMeter.getCPtr(pProgressMeter));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_releaseProgressMeter(swigCPtr, OdDbHostAppProgressMeter.getCPtr(pProgressMeter));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void start(string displayString)
	{
		if (SwigDerivedClassHasMethod("start", swigMethodTypes74))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_startSwigExplicitExHostAppServices__SWIG_0(swigCPtr, displayString);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_start__SWIG_0(swigCPtr, displayString);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void start()
	{
		if (SwigDerivedClassHasMethod("start", swigMethodTypes75))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_startSwigExplicitExHostAppServices__SWIG_1(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_start__SWIG_1(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void stop()
	{
		if (SwigDerivedClassHasMethod("stop", swigMethodTypes76))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_stopSwigExplicitExHostAppServices(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_stop(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void meterProgress()
	{
		if (SwigDerivedClassHasMethod("meterProgress", swigMethodTypes77))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_meterProgressSwigExplicitExHostAppServices(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_meterProgress(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLimit(int max)
	{
		if (SwigDerivedClassHasMethod("setLimit", swigMethodTypes78))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_setLimitSwigExplicitExHostAppServices(swigCPtr, max);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_setLimit(swigCPtr, max);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void disableOutput(bool disable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_disableOutput(swigCPtr, disable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPrefix(string prefix)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_setPrefix(swigCPtr, prefix);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdHatchPatternManager patternManager()
	{
		OdHatchPatternManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdHatchPatternManager>(SwigDerivedClassHasMethod("patternManager", swigMethodTypes65) ? TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_patternManagerSwigExplicitExHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_patternManager(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdDbDatabase readFile(string filename, bool allowCPConversion, bool partialLoad, Oda_FileShareMode shareMode, string password)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("readFile", swigMethodTypes54) ? TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_readFileSwigExplicitExHostAppServices(swigCPtr, filename, allowCPConversion, partialLoad, (int)shareMode, password) : TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_readFile(swigCPtr, filename, allowCPConversion, partialLoad, (int)shareMode, password), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("findFile", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodfindFile__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("findFile", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodfindFile__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("findFile", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodfindFile__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("newProgressMeter", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodnewProgressMeter;
		}
		if (SwigDerivedClassHasMethod("releaseProgressMeter", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodreleaseProgressMeter;
		}
		if (SwigDerivedClassHasMethod("program", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodprogram;
		}
		if (SwigDerivedClassHasMethod("product", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodproduct;
		}
		if (SwigDerivedClassHasMethod("companyName", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcompanyName;
		}
		if (SwigDerivedClassHasMethod("prodcode", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodprodcode;
		}
		if (SwigDerivedClassHasMethod("releaseMajorMinorString", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodreleaseMajorMinorString;
		}
		if (SwigDerivedClassHasMethod("releaseMajorVersion", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodreleaseMajorVersion;
		}
		if (SwigDerivedClassHasMethod("releaseMinorVersion", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodreleaseMinorVersion;
		}
		if (SwigDerivedClassHasMethod("versionString", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodversionString;
		}
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodwarning__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodwarning__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodwarning__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodwarning__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getErrorDescription", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetErrorDescription;
		}
		if (SwigDerivedClassHasMethod("newUndoController", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodnewUndoController;
		}
		if (SwigDerivedClassHasMethod("newUndoStream", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodnewUndoStream;
		}
		if (SwigDerivedClassHasMethod("auditPrintReport", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodauditPrintReport;
		}
		if (SwigDerivedClassHasMethod("ttfFileNameByDescriptor", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodttfFileNameByDescriptor;
		}
		if (SwigDerivedClassHasMethod("getAlternateFontName", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodgetAlternateFontName;
		}
		if (SwigDerivedClassHasMethod("getFontMapFileName", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodgetFontMapFileName;
		}
		if (SwigDerivedClassHasMethod("getPreferableFont", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodgetPreferableFont;
		}
		if (SwigDerivedClassHasMethod("getSubstituteFont", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodgetSubstituteFont;
		}
		if (SwigDerivedClassHasMethod("getSubstituteFontByChar", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodgetSubstituteFontByChar;
		}
		if (SwigDerivedClassHasMethod("getSystemFontFolders", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodgetSystemFontFolders;
		}
		if (SwigDerivedClassHasMethod("collectFilePathsInDirectory", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodcollectFilePathsInDirectory__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("collectFilePathsInDirectory", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodcollectFilePathsInDirectory__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodfileDialog__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodfileDialog__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodfileDialog__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodfileDialog__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodfileDialog__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodgsBitmapDevice__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodgsBitmapDevice__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodgsBitmapDevice__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodgsBitmapDevice__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getTempPath", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodgetTempPath;
		}
		if (SwigDerivedClassHasMethod("numThreads", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodnumThreads;
		}
		if (SwigDerivedClassHasMethod("getEnv", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodgetEnv;
		}
		if (SwigDerivedClassHasMethod("setEnv", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodsetEnv;
		}
		if (SwigDerivedClassHasMethod("databaseClass", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethoddatabaseClass;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodreadFile__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodreadFile__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodreadFile__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodreadFile__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("recoverFile", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodrecoverFile__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("recoverFile", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodrecoverFile__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("recoverFile", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodrecoverFile__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodreadFile;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodreadFile__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodreadFile__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodreadFile__SWIG_7;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodreadFile__SWIG_8;
		}
		if (SwigDerivedClassHasMethod("warning1", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodwarning1;
		}
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodwarning;
		}
		if (SwigDerivedClassHasMethod("warning2", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodwarning2;
		}
		if (SwigDerivedClassHasMethod("warning3", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodwarning3;
		}
		if (SwigDerivedClassHasMethod("doFullCRCCheck", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethoddoFullCRCCheck;
		}
		if (SwigDerivedClassHasMethod("plotSettingsValidator", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodplotSettingsValidator;
		}
		if (SwigDerivedClassHasMethod("patternManager", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodpatternManager;
		}
		if (SwigDerivedClassHasMethod("getPassword", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodgetPassword;
		}
		if (SwigDerivedClassHasMethod("getPasswordCache", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodgetPasswordCache;
		}
		if (SwigDerivedClassHasMethod("newPageController", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodnewPageController;
		}
		if (SwigDerivedClassHasMethod("layoutManager", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodlayoutManager;
		}
		if (SwigDerivedClassHasMethod("educationalPlotStamp", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodeducationalPlotStamp;
		}
		if (SwigDerivedClassHasMethod("getThumbSize", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodgetThumbSize;
		}
		if (SwigDerivedClassHasMethod("getHistoryFile", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodgetHistoryFile;
		}
		if (SwigDerivedClassHasMethod("fixName", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodfixName;
		}
		if (SwigDerivedClassHasMethod("start", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodstart__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("start", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodstart__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("stop", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodstop;
		}
		if (SwigDerivedClassHasMethod("meterProgress", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodmeterProgress;
		}
		if (SwigDerivedClassHasMethod("setLimit", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodsetLimit;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExHostAppServices_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(ExHostAppServices));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfindFile__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb, int hint)
	{
		return findFile(filename, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), (OdDbBaseHostAppServices_FindFileHint)hint);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfindFile__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb)
	{
		return findFile(filename, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfindFile__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		return findFile(filename);
	}

	private IntPtr SwigDirectorMethodnewProgressMeter()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbHostAppProgressMeter.getCPtr(newProgressMeter()).Handle;
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

	private void SwigDirectorMethodreleaseProgressMeter(IntPtr pProgressMeter)
	{
		try
		{
			releaseProgressMeter((pProgressMeter == IntPtr.Zero) ? null : new OdDbHostAppProgressMeter(pProgressMeter, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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
	private string SwigDirectorMethodprogram()
	{
		return program();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodproduct()
	{
		return product();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodcompanyName()
	{
		return companyName();
	}

	private int SwigDirectorMethodprodcode()
	{
		return (int)prodcode();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodreleaseMajorMinorString()
	{
		return releaseMajorMinorString();
	}

	private int SwigDirectorMethodreleaseMajorVersion()
	{
		return releaseMajorVersion();
	}

	private int SwigDirectorMethodreleaseMinorVersion()
	{
		return releaseMinorVersion();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodversionString()
	{
		return versionString();
	}

	private void SwigDirectorMethodwarning__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string message)
	{
		try
		{
			warning(message);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodwarning__SWIG_1(string warnVisGroup, [MarshalAs(UnmanagedType.LPWStr)] string message)
	{
		try
		{
			warning(warnVisGroup, message);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodwarning__SWIG_2(int warningOb)
	{
		try
		{
			warning((OdResult)warningOb);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodwarning__SWIG_3(string warnVisGroup, int warningOb)
	{
		try
		{
			warning(warnVisGroup, (OdResult)warningOb);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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
	private string SwigDirectorMethodgetErrorDescription(uint errorCode)
	{
		return getErrorDescription(errorCode);
	}

	private IntPtr SwigDirectorMethodnewUndoController()
	{
		return OdDbUndoController.getCPtr(newUndoController()).Handle;
	}

	private IntPtr SwigDirectorMethodnewUndoStream()
	{
		return OdStreamBuf.getCPtr(newUndoStream()).Handle;
	}

	private void SwigDirectorMethodauditPrintReport(IntPtr pAuditInfo, [MarshalAs(UnmanagedType.LPWStr)] string strLine, int printDest)
	{
		try
		{
			auditPrintReport((pAuditInfo == IntPtr.Zero) ? null : new OdAuditInfo(pAuditInfo, cMemoryOwn: false), strLine, printDest);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodttfFileNameByDescriptor(IntPtr description, IntPtr filename)
	{
		OdSwigDirectorHelper.director_UnpackData(filename, out var pOriginalObject, out var pFunction);
		string filename2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = filename2;
		try
		{
			return ttfFileNameByDescriptor(new OdTtfDescriptor(description, cMemoryOwn: false), ref filename2);
		}
		finally
		{
			if (filename2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(filename2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(filename);
		}
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetAlternateFontName()
	{
		return getAlternateFontName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFontMapFileName()
	{
		return getFontMapFileName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetPreferableFont([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType)
	{
		return getPreferableFont(fontName, (OdTagFontType)fontType);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetSubstituteFont([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType)
	{
		return getSubstituteFont(fontName, (OdTagFontType)fontType);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetSubstituteFontByChar(IntPtr pFont, char unicodeChar, IntPtr pDb)
	{
		return getSubstituteFontByChar(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFont>(pFont, bOwn: false, bTryAddToTransaction: false), unicodeChar, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodgetSystemFontFolders(IntPtr aDirs)
	{
		return getSystemFontFolders(new OdStringArray(aDirs, cMemoryOwn: true));
	}

	private void SwigDirectorMethodcollectFilePathsInDirectory__SWIG_0(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath, [MarshalAs(UnmanagedType.LPWStr)] string sFilter)
	{
		try
		{
			collectFilePathsInDirectory(new OdStringArray(res, cMemoryOwn: true), sPath, sFilter);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodcollectFilePathsInDirectory__SWIG_1(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath)
	{
		try
		{
			collectFilePathsInDirectory(new OdStringArray(res, cMemoryOwn: true), sPath);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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
	private string SwigDirectorMethodfileDialog__SWIG_0(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename, [MarshalAs(UnmanagedType.LPWStr)] string filter)
	{
		return fileDialog(flags, dialogCaption, defExt, defFilename, filter);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfileDialog__SWIG_1(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename)
	{
		return fileDialog(flags, dialogCaption, defExt, defFilename);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfileDialog__SWIG_2(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt)
	{
		return fileDialog(flags, dialogCaption, defExt);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfileDialog__SWIG_3(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption)
	{
		return fileDialog(flags, dialogCaption);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfileDialog__SWIG_4(int flags)
	{
		return fileDialog(flags);
	}

	private IntPtr SwigDirectorMethodgsBitmapDevice__SWIG_0(IntPtr pViewObj, IntPtr pDb, uint flags)
	{
		return OdGsDevice.getCPtr(gsBitmapDevice(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewObj, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), flags)).Handle;
	}

	private IntPtr SwigDirectorMethodgsBitmapDevice__SWIG_1(IntPtr pViewObj, IntPtr pDb)
	{
		return OdGsDevice.getCPtr(gsBitmapDevice(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewObj, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgsBitmapDevice__SWIG_2(IntPtr pViewObj)
	{
		return OdGsDevice.getCPtr(gsBitmapDevice(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pViewObj, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgsBitmapDevice__SWIG_3()
	{
		return OdGsDevice.getCPtr(gsBitmapDevice()).Handle;
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetTempPath()
	{
		return getTempPath();
	}

	private int SwigDirectorMethodnumThreads(int mtMode)
	{
		return numThreads((MultiThreadedMode)mtMode);
	}

	private int SwigDirectorMethodgetEnv([MarshalAs(UnmanagedType.LPWStr)] string varName, IntPtr value)
	{
		OdSwigDirectorHelper.director_UnpackData(value, out var pOriginalObject, out var pFunction);
		string value2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = value2;
		try
		{
			return (int)getEnv(varName, ref value2);
		}
		finally
		{
			if (value2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(value2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(value);
		}
	}

	private int SwigDirectorMethodsetEnv([MarshalAs(UnmanagedType.LPWStr)] string varName, [MarshalAs(UnmanagedType.LPWStr)] string newValue)
	{
		return (int)setEnv(varName, newValue);
	}

	private IntPtr SwigDirectorMethoddatabaseClass()
	{
		return OdRxClass.getCPtr(databaseClass()).Handle;
	}

	private IntPtr SwigDirectorMethodreadFile__SWIG_0(IntPtr pStreamBuf, bool allowCPConversion, bool partialLoad, [MarshalAs(UnmanagedType.LPWStr)] string password)
	{
		return OdDbDatabase.getCPtr(readFile(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), allowCPConversion, partialLoad, password)).Handle;
	}

	private IntPtr SwigDirectorMethodreadFile__SWIG_1(IntPtr pStreamBuf, bool allowCPConversion, bool partialLoad)
	{
		return OdDbDatabase.getCPtr(readFile(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), allowCPConversion, partialLoad)).Handle;
	}

	private IntPtr SwigDirectorMethodreadFile__SWIG_2(IntPtr pStreamBuf, bool allowCPConversion)
	{
		return OdDbDatabase.getCPtr(readFile(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), allowCPConversion)).Handle;
	}

	private IntPtr SwigDirectorMethodreadFile__SWIG_3(IntPtr pStreamBuf)
	{
		return OdDbDatabase.getCPtr(readFile(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodrecoverFile__SWIG_0(IntPtr pStreamBuf, IntPtr pAuditInfo, [MarshalAs(UnmanagedType.LPWStr)] string password)
	{
		return OdDbDatabase.getCPtr(recoverFile(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), (pAuditInfo == IntPtr.Zero) ? null : new OdDbAuditInfo(pAuditInfo, cMemoryOwn: false), password)).Handle;
	}

	private IntPtr SwigDirectorMethodrecoverFile__SWIG_1(IntPtr pStreamBuf, IntPtr pAuditInfo)
	{
		return OdDbDatabase.getCPtr(recoverFile(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), (pAuditInfo == IntPtr.Zero) ? null : new OdDbAuditInfo(pAuditInfo, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodrecoverFile__SWIG_2(IntPtr pStreamBuf)
	{
		return OdDbDatabase.getCPtr(recoverFile(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodreadFile([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad, int shareMode, [MarshalAs(UnmanagedType.LPWStr)] string password)
	{
		return OdDbDatabase.getCPtr(readFile(filename, allowCPConversion, partialLoad, (Oda_FileShareMode)shareMode, password)).Handle;
	}

	private IntPtr SwigDirectorMethodreadFile__SWIG_5([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad, int shareMode)
	{
		return OdDbDatabase.getCPtr(readFile(filename, allowCPConversion, partialLoad, (Oda_FileShareMode)shareMode)).Handle;
	}

	private IntPtr SwigDirectorMethodreadFile__SWIG_6([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad)
	{
		return OdDbDatabase.getCPtr(readFile(filename, allowCPConversion, partialLoad)).Handle;
	}

	private IntPtr SwigDirectorMethodreadFile__SWIG_7([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion)
	{
		return OdDbDatabase.getCPtr(readFile(filename, allowCPConversion)).Handle;
	}

	private IntPtr SwigDirectorMethodreadFile__SWIG_8([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		return OdDbDatabase.getCPtr(readFile(filename)).Handle;
	}

	private void SwigDirectorMethodwarning1(int warningOb, IntPtr objectId)
	{
		try
		{
			warning1((OdResult)warningOb, new OdDbObjectId(objectId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodwarning(string warnVisGroup, int warningOb, IntPtr objectId)
	{
		try
		{
			warning(warnVisGroup, (OdResult)warningOb, new OdDbObjectId(objectId, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodwarning2(IntPtr err)
	{
		try
		{
			warning2(new OdError(err, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdEdOtherInput err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (OdError err4)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err4);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodwarning3(string warnVisGroup, IntPtr err)
	{
		try
		{
			warning3(warnVisGroup, new OdError(err, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdEdOtherInput err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (OdError err4)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err4);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethoddoFullCRCCheck()
	{
		return doFullCRCCheck();
	}

	private IntPtr SwigDirectorMethodplotSettingsValidator()
	{
		return OdDbPlotSettingsValidator.getCPtr(plotSettingsValidator()).Handle;
	}

	private IntPtr SwigDirectorMethodpatternManager()
	{
		return OdHatchPatternManager.getCPtr(patternManager()).Handle;
	}

	private bool SwigDirectorMethodgetPassword([MarshalAs(UnmanagedType.LPWStr)] string dwgName, bool isXref, IntPtr password)
	{
		OdSwigDirectorHelper.director_UnpackData(password, out var pOriginalObject, out var pFunction);
		string password2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = password2;
		try
		{
			return getPassword(dwgName, isXref, ref password2);
		}
		finally
		{
			if (password2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(password2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(password);
		}
	}

	private IntPtr SwigDirectorMethodgetPasswordCache()
	{
		return OdPwdCache.getCPtr(getPasswordCache()).Handle;
	}

	private IntPtr SwigDirectorMethodnewPageController()
	{
		return OdDbPageController.getCPtr(newPageController()).Handle;
	}

	private IntPtr SwigDirectorMethodlayoutManager()
	{
		return OdDbLayoutManager.getCPtr(layoutManager()).Handle;
	}

	private uint SwigDirectorMethodeducationalPlotStamp()
	{
		return educationalPlotStamp();
	}

	private void SwigDirectorMethodgetThumbSize(uint nWidth, uint nHeight)
	{
		try
		{
			getThumbSize(out nWidth, out nHeight);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetHistoryFile(IntPtr arg0)
	{
		return OdStreamBuf.getCPtr(getHistoryFile(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(arg0, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfixName(IntPtr pRecord)
	{
		return fixName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSymbolTableRecord>(pRecord, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodstart__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string displayString)
	{
		try
		{
			start(displayString);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodstart__SWIG_1()
	{
		try
		{
			start();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodstop()
	{
		try
		{
			stop();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodmeterProgress()
	{
		try
		{
			meterProgress();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetLimit(int max)
	{
		try
		{
			setLimit(max);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
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

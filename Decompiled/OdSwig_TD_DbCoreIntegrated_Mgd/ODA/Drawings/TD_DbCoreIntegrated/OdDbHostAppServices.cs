using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbHostAppServices : OdDbBaseHostAppServices
{
	public delegate IntPtr SwigDelegateOdDbHostAppServices_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_1();

	public delegate void SwigDelegateOdDbHostAppServices_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_3([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb, int hint);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_4([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_5([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_6();

	public delegate void SwigDelegateOdDbHostAppServices_7(IntPtr pProgressMeter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_8();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_9();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_10();

	public delegate int SwigDelegateOdDbHostAppServices_11();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_12();

	public delegate int SwigDelegateOdDbHostAppServices_13();

	public delegate int SwigDelegateOdDbHostAppServices_14();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_15();

	public delegate void SwigDelegateOdDbHostAppServices_16([MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateOdDbHostAppServices_17(string warnVisGroup, [MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateOdDbHostAppServices_18(int warningOb);

	public delegate void SwigDelegateOdDbHostAppServices_19(string warnVisGroup, int warningOb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_20(uint errorCode);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_21();

	public delegate IntPtr SwigDelegateOdDbHostAppServices_22();

	public delegate void SwigDelegateOdDbHostAppServices_23(IntPtr pAuditInfo, [MarshalAs(UnmanagedType.LPWStr)] string strLine, int printDest);

	public delegate bool SwigDelegateOdDbHostAppServices_24(IntPtr description, IntPtr filename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_25();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_26();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_27([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_28([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_29(IntPtr pFont, char unicodeChar, IntPtr pDb);

	public delegate bool SwigDelegateOdDbHostAppServices_30(IntPtr aDirs);

	public delegate void SwigDelegateOdDbHostAppServices_31(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath, [MarshalAs(UnmanagedType.LPWStr)] string sFilter);

	public delegate void SwigDelegateOdDbHostAppServices_32(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_33(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename, [MarshalAs(UnmanagedType.LPWStr)] string filter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_34(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_35(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_36(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_37(int flags);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_38(IntPtr pViewObj, IntPtr pDb, uint flags);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_39(IntPtr pViewObj, IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_40(IntPtr pViewObj);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_41();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_42();

	public delegate short SwigDelegateOdDbHostAppServices_43();

	public delegate int SwigDelegateOdDbHostAppServices_44(int mtMode);

	public delegate int SwigDelegateOdDbHostAppServices_45([MarshalAs(UnmanagedType.LPWStr)] string varName, IntPtr value);

	public delegate int SwigDelegateOdDbHostAppServices_46([MarshalAs(UnmanagedType.LPWStr)] string varName, [MarshalAs(UnmanagedType.LPWStr)] string newValue);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_47(int unFormat);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_48();

	public delegate IntPtr SwigDelegateOdDbHostAppServices_49();

	public delegate IntPtr SwigDelegateOdDbHostAppServices_50(bool createDefault, int measurement);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_51(bool createDefault);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_52();

	public delegate IntPtr SwigDelegateOdDbHostAppServices_53(IntPtr pStreamBuf, bool allowCPConversion, bool partialLoad, [MarshalAs(UnmanagedType.LPWStr)] string password);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_54(IntPtr pStreamBuf, bool allowCPConversion, bool partialLoad);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_55(IntPtr pStreamBuf, bool allowCPConversion);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_56(IntPtr pStreamBuf);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_57(IntPtr pStreamBuf, IntPtr pAuditInfo, [MarshalAs(UnmanagedType.LPWStr)] string password);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_58(IntPtr pStreamBuf, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_59(IntPtr pStreamBuf);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_60([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad, int shareMode, [MarshalAs(UnmanagedType.LPWStr)] string password);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_61([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad, int shareMode);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_62([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_63([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_64([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate void SwigDelegateOdDbHostAppServices_65(int warningOb, IntPtr objectId);

	public delegate void SwigDelegateOdDbHostAppServices_66(string warnVisGroup, int warningOb, IntPtr objectId);

	public delegate void SwigDelegateOdDbHostAppServices_67(IntPtr err);

	public delegate void SwigDelegateOdDbHostAppServices_68(string warnVisGroup, IntPtr err);

	public delegate bool SwigDelegateOdDbHostAppServices_69();

	public delegate IntPtr SwigDelegateOdDbHostAppServices_70();

	public delegate IntPtr SwigDelegateOdDbHostAppServices_71();

	public delegate bool SwigDelegateOdDbHostAppServices_72([MarshalAs(UnmanagedType.LPWStr)] string dwgName, bool isXref, IntPtr password);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_73();

	public delegate IntPtr SwigDelegateOdDbHostAppServices_74();

	public delegate IntPtr SwigDelegateOdDbHostAppServices_75();

	public delegate uint SwigDelegateOdDbHostAppServices_76();

	public delegate IntPtr SwigDelegateOdDbHostAppServices_77();

	public delegate void SwigDelegateOdDbHostAppServices_78(uint nWidth, uint nHeight);

	public delegate IntPtr SwigDelegateOdDbHostAppServices_79(IntPtr arg0);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices_80(IntPtr pRecord);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbHostAppServices_0 swigDelegate0;

	private SwigDelegateOdDbHostAppServices_1 swigDelegate1;

	private SwigDelegateOdDbHostAppServices_2 swigDelegate2;

	private SwigDelegateOdDbHostAppServices_3 swigDelegate3;

	private SwigDelegateOdDbHostAppServices_4 swigDelegate4;

	private SwigDelegateOdDbHostAppServices_5 swigDelegate5;

	private SwigDelegateOdDbHostAppServices_6 swigDelegate6;

	private SwigDelegateOdDbHostAppServices_7 swigDelegate7;

	private SwigDelegateOdDbHostAppServices_8 swigDelegate8;

	private SwigDelegateOdDbHostAppServices_9 swigDelegate9;

	private SwigDelegateOdDbHostAppServices_10 swigDelegate10;

	private SwigDelegateOdDbHostAppServices_11 swigDelegate11;

	private SwigDelegateOdDbHostAppServices_12 swigDelegate12;

	private SwigDelegateOdDbHostAppServices_13 swigDelegate13;

	private SwigDelegateOdDbHostAppServices_14 swigDelegate14;

	private SwigDelegateOdDbHostAppServices_15 swigDelegate15;

	private SwigDelegateOdDbHostAppServices_16 swigDelegate16;

	private SwigDelegateOdDbHostAppServices_17 swigDelegate17;

	private SwigDelegateOdDbHostAppServices_18 swigDelegate18;

	private SwigDelegateOdDbHostAppServices_19 swigDelegate19;

	private SwigDelegateOdDbHostAppServices_20 swigDelegate20;

	private SwigDelegateOdDbHostAppServices_21 swigDelegate21;

	private SwigDelegateOdDbHostAppServices_22 swigDelegate22;

	private SwigDelegateOdDbHostAppServices_23 swigDelegate23;

	private SwigDelegateOdDbHostAppServices_24 swigDelegate24;

	private SwigDelegateOdDbHostAppServices_25 swigDelegate25;

	private SwigDelegateOdDbHostAppServices_26 swigDelegate26;

	private SwigDelegateOdDbHostAppServices_27 swigDelegate27;

	private SwigDelegateOdDbHostAppServices_28 swigDelegate28;

	private SwigDelegateOdDbHostAppServices_29 swigDelegate29;

	private SwigDelegateOdDbHostAppServices_30 swigDelegate30;

	private SwigDelegateOdDbHostAppServices_31 swigDelegate31;

	private SwigDelegateOdDbHostAppServices_32 swigDelegate32;

	private SwigDelegateOdDbHostAppServices_33 swigDelegate33;

	private SwigDelegateOdDbHostAppServices_34 swigDelegate34;

	private SwigDelegateOdDbHostAppServices_35 swigDelegate35;

	private SwigDelegateOdDbHostAppServices_36 swigDelegate36;

	private SwigDelegateOdDbHostAppServices_37 swigDelegate37;

	private SwigDelegateOdDbHostAppServices_38 swigDelegate38;

	private SwigDelegateOdDbHostAppServices_39 swigDelegate39;

	private SwigDelegateOdDbHostAppServices_40 swigDelegate40;

	private SwigDelegateOdDbHostAppServices_41 swigDelegate41;

	private SwigDelegateOdDbHostAppServices_42 swigDelegate42;

	private SwigDelegateOdDbHostAppServices_43 swigDelegate43;

	private SwigDelegateOdDbHostAppServices_44 swigDelegate44;

	private SwigDelegateOdDbHostAppServices_45 swigDelegate45;

	private SwigDelegateOdDbHostAppServices_46 swigDelegate46;

	private SwigDelegateOdDbHostAppServices_47 swigDelegate47;

	private SwigDelegateOdDbHostAppServices_48 swigDelegate48;

	private SwigDelegateOdDbHostAppServices_49 swigDelegate49;

	private SwigDelegateOdDbHostAppServices_50 swigDelegate50;

	private SwigDelegateOdDbHostAppServices_51 swigDelegate51;

	private SwigDelegateOdDbHostAppServices_52 swigDelegate52;

	private SwigDelegateOdDbHostAppServices_53 swigDelegate53;

	private SwigDelegateOdDbHostAppServices_54 swigDelegate54;

	private SwigDelegateOdDbHostAppServices_55 swigDelegate55;

	private SwigDelegateOdDbHostAppServices_56 swigDelegate56;

	private SwigDelegateOdDbHostAppServices_57 swigDelegate57;

	private SwigDelegateOdDbHostAppServices_58 swigDelegate58;

	private SwigDelegateOdDbHostAppServices_59 swigDelegate59;

	private SwigDelegateOdDbHostAppServices_60 swigDelegate60;

	private SwigDelegateOdDbHostAppServices_61 swigDelegate61;

	private SwigDelegateOdDbHostAppServices_62 swigDelegate62;

	private SwigDelegateOdDbHostAppServices_63 swigDelegate63;

	private SwigDelegateOdDbHostAppServices_64 swigDelegate64;

	private SwigDelegateOdDbHostAppServices_65 swigDelegate65;

	private SwigDelegateOdDbHostAppServices_66 swigDelegate66;

	private SwigDelegateOdDbHostAppServices_67 swigDelegate67;

	private SwigDelegateOdDbHostAppServices_68 swigDelegate68;

	private SwigDelegateOdDbHostAppServices_69 swigDelegate69;

	private SwigDelegateOdDbHostAppServices_70 swigDelegate70;

	private SwigDelegateOdDbHostAppServices_71 swigDelegate71;

	private SwigDelegateOdDbHostAppServices_72 swigDelegate72;

	private SwigDelegateOdDbHostAppServices_73 swigDelegate73;

	private SwigDelegateOdDbHostAppServices_74 swigDelegate74;

	private SwigDelegateOdDbHostAppServices_75 swigDelegate75;

	private SwigDelegateOdDbHostAppServices_76 swigDelegate76;

	private SwigDelegateOdDbHostAppServices_77 swigDelegate77;

	private SwigDelegateOdDbHostAppServices_78 swigDelegate78;

	private SwigDelegateOdDbHostAppServices_79 swigDelegate79;

	private SwigDelegateOdDbHostAppServices_80 swigDelegate80;

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

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(MultiThreadedMode) };

	private static Type[] swigMethodTypes45 = new Type[2]
	{
		typeof(string),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes46 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(Oda_UserNameFormat) };

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[0];

	private static Type[] swigMethodTypes50 = new Type[2]
	{
		typeof(bool),
		typeof(MeasurementValue)
	};

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes52 = new Type[0];

	private static Type[] swigMethodTypes53 = new Type[4]
	{
		typeof(OdStreamBuf),
		typeof(bool),
		typeof(bool),
		typeof(string)
	};

	private static Type[] swigMethodTypes54 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes55 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(bool)
	};

	private static Type[] swigMethodTypes56 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes57 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(OdDbAuditInfo),
		typeof(string)
	};

	private static Type[] swigMethodTypes58 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(OdDbAuditInfo)
	};

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes60 = new Type[5]
	{
		typeof(string),
		typeof(bool),
		typeof(bool),
		typeof(Oda_FileShareMode),
		typeof(string)
	};

	private static Type[] swigMethodTypes61 = new Type[4]
	{
		typeof(string),
		typeof(bool),
		typeof(bool),
		typeof(Oda_FileShareMode)
	};

	private static Type[] swigMethodTypes62 = new Type[3]
	{
		typeof(string),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes63 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes65 = new Type[2]
	{
		typeof(OdResult),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes66 = new Type[3]
	{
		typeof(string),
		typeof(OdResult),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes67 = new Type[1] { typeof(OdError) };

	private static Type[] swigMethodTypes68 = new Type[2]
	{
		typeof(string),
		typeof(OdError)
	};

	private static Type[] swigMethodTypes69 = new Type[0];

	private static Type[] swigMethodTypes70 = new Type[0];

	private static Type[] swigMethodTypes71 = new Type[0];

	private static Type[] swigMethodTypes72 = new Type[3]
	{
		typeof(string),
		typeof(bool),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes73 = new Type[0];

	private static Type[] swigMethodTypes74 = new Type[0];

	private static Type[] swigMethodTypes75 = new Type[0];

	private static Type[] swigMethodTypes76 = new Type[0];

	private static Type[] swigMethodTypes77 = new Type[0];

	private static Type[] swigMethodTypes78 = new Type[2]
	{
		typeof(uint).MakeByRefType(),
		typeof(uint).MakeByRefType()
	};

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes80 = new Type[1] { typeof(OdDbSymbolTableRecord) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbHostAppServices(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbHostAppServices obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbHostAppServices(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbHostAppServices cast(OdRxObject pObj)
	{
		OdDbHostAppServices rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbHostAppServices>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_isASwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_queryXSwigExplicitOdDbHostAppServices(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbHostAppServices createObject()
	{
		OdDbHostAppServices rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbHostAppServices>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbHostAppServices()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbHostAppServices(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbHostAppServices) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override string findFile(string filename, OdRxObject pDb, OdDbBaseHostAppServices_FindFileHint hint)
	{
		string result = (SwigDerivedClassHasMethod("findFile", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_findFileSwigExplicitOdDbHostAppServices__SWIG_0(swigCPtr, filename, OdRxObject.getCPtr(pDb), (int)hint) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_findFile__SWIG_0(swigCPtr, filename, OdRxObject.getCPtr(pDb), (int)hint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string findFile(string filename, OdRxObject pDb)
	{
		string result = (SwigDerivedClassHasMethod("findFile", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_findFileSwigExplicitOdDbHostAppServices__SWIG_1(swigCPtr, filename, OdRxObject.getCPtr(pDb)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_findFile__SWIG_1(swigCPtr, filename, OdRxObject.getCPtr(pDb)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string findFile(string filename)
	{
		string result = (SwigDerivedClassHasMethod("findFile", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_findFileSwigExplicitOdDbHostAppServices__SWIG_2(swigCPtr, filename) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_findFile__SWIG_2(swigCPtr, filename));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbHostAppProgressMeter newProgressMeter()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("newProgressMeter", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_newProgressMeterSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_newProgressMeter(swigCPtr));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_releaseProgressMeterSwigExplicitOdDbHostAppServices(swigCPtr, OdDbHostAppProgressMeter.getCPtr(pProgressMeter));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_releaseProgressMeter(swigCPtr, OdDbHostAppProgressMeter.getCPtr(pProgressMeter));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxClass databaseClass()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("databaseClass", swigMethodTypes49) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_databaseClassSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_databaseClass(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase createDatabase(bool createDefault, MeasurementValue measurement)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("createDatabase", swigMethodTypes50) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_createDatabaseSwigExplicitOdDbHostAppServices__SWIG_0(swigCPtr, createDefault, (int)measurement) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_createDatabase__SWIG_0(swigCPtr, createDefault, (int)measurement), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase createDatabase(bool createDefault)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("createDatabase", swigMethodTypes51) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_createDatabaseSwigExplicitOdDbHostAppServices__SWIG_1(swigCPtr, createDefault) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_createDatabase__SWIG_1(swigCPtr, createDefault), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase createDatabase()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("createDatabase", swigMethodTypes52) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_createDatabaseSwigExplicitOdDbHostAppServices__SWIG_2(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_createDatabase__SWIG_2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase readFile(OdStreamBuf pStreamBuf, bool allowCPConversion, bool partialLoad, string password)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("readFile", swigMethodTypes53) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFileSwigExplicitOdDbHostAppServices__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), allowCPConversion, partialLoad, password) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFile__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), allowCPConversion, partialLoad, password), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase readFile(OdStreamBuf pStreamBuf, bool allowCPConversion, bool partialLoad)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("readFile", swigMethodTypes54) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFileSwigExplicitOdDbHostAppServices__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), allowCPConversion, partialLoad) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFile__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), allowCPConversion, partialLoad), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase readFile(OdStreamBuf pStreamBuf, bool allowCPConversion)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("readFile", swigMethodTypes55) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFileSwigExplicitOdDbHostAppServices__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), allowCPConversion) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFile__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), allowCPConversion), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase readFile(OdStreamBuf pStreamBuf)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("readFile", swigMethodTypes56) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFileSwigExplicitOdDbHostAppServices__SWIG_3(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFile__SWIG_3(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase recoverFile(OdStreamBuf pStreamBuf, OdDbAuditInfo pAuditInfo, string password)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("recoverFile", swigMethodTypes57) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_recoverFileSwigExplicitOdDbHostAppServices__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), OdDbAuditInfo.getCPtr(pAuditInfo), password) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_recoverFile__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), OdDbAuditInfo.getCPtr(pAuditInfo), password), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase recoverFile(OdStreamBuf pStreamBuf, OdDbAuditInfo pAuditInfo)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("recoverFile", swigMethodTypes58) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_recoverFileSwigExplicitOdDbHostAppServices__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), OdDbAuditInfo.getCPtr(pAuditInfo)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_recoverFile__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), OdDbAuditInfo.getCPtr(pAuditInfo)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase recoverFile(OdStreamBuf pStreamBuf)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("recoverFile", swigMethodTypes59) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_recoverFileSwigExplicitOdDbHostAppServices__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_recoverFile__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase readFile(string filename, bool allowCPConversion, bool partialLoad, Oda_FileShareMode shareMode, string password)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("readFile", swigMethodTypes60) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFileSwigExplicitOdDbHostAppServices__SWIG_4(swigCPtr, filename, allowCPConversion, partialLoad, (int)shareMode, password) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFile__SWIG_4(swigCPtr, filename, allowCPConversion, partialLoad, (int)shareMode, password), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase readFile(string filename, bool allowCPConversion, bool partialLoad, Oda_FileShareMode shareMode)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("readFile", swigMethodTypes61) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFileSwigExplicitOdDbHostAppServices__SWIG_5(swigCPtr, filename, allowCPConversion, partialLoad, (int)shareMode) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFile__SWIG_5(swigCPtr, filename, allowCPConversion, partialLoad, (int)shareMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase readFile(string filename, bool allowCPConversion, bool partialLoad)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("readFile", swigMethodTypes62) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFileSwigExplicitOdDbHostAppServices__SWIG_6(swigCPtr, filename, allowCPConversion, partialLoad) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFile__SWIG_6(swigCPtr, filename, allowCPConversion, partialLoad), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase readFile(string filename, bool allowCPConversion)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("readFile", swigMethodTypes63) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFileSwigExplicitOdDbHostAppServices__SWIG_7(swigCPtr, filename, allowCPConversion) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFile__SWIG_7(swigCPtr, filename, allowCPConversion), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase readFile(string filename)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("readFile", swigMethodTypes64) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFileSwigExplicitOdDbHostAppServices__SWIG_8(swigCPtr, filename) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_readFile__SWIG_8(swigCPtr, filename), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override string program()
	{
		string result = (SwigDerivedClassHasMethod("program", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_programSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_program(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string product()
	{
		string result = (SwigDerivedClassHasMethod("product", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_productSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_product(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string companyName()
	{
		string result = (SwigDerivedClassHasMethod("companyName", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_companyNameSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_companyName(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override ProdIdCode prodcode()
	{
		int result = (SwigDerivedClassHasMethod("prodcode", swigMethodTypes11) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_prodcodeSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_prodcode(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (ProdIdCode)result;
	}

	public override string releaseMajorMinorString()
	{
		string result = (SwigDerivedClassHasMethod("releaseMajorMinorString", swigMethodTypes12) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_releaseMajorMinorStringSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_releaseMajorMinorString(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override int releaseMajorVersion()
	{
		int result = (SwigDerivedClassHasMethod("releaseMajorVersion", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_releaseMajorVersionSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_releaseMajorVersion(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override int releaseMinorVersion()
	{
		int result = (SwigDerivedClassHasMethod("releaseMinorVersion", swigMethodTypes14) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_releaseMinorVersionSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_releaseMinorVersion(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string versionString()
	{
		string result = (SwigDerivedClassHasMethod("versionString", swigMethodTypes15) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_versionStringSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_versionString(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void warning1(OdResult warningOb, OdDbObjectId objectId)
	{
		if (SwigDerivedClassHasMethod("warning1", swigMethodTypes65))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_warning1SwigExplicitOdDbHostAppServices(swigCPtr, (int)warningOb, OdDbObjectId.getCPtr(objectId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_warning1(swigCPtr, (int)warningOb, OdDbObjectId.getCPtr(objectId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void warning(string warnVisGroup, OdResult warningOb, OdDbObjectId objectId)
	{
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes66))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_warningSwigExplicitOdDbHostAppServices(swigCPtr, warnVisGroup, (int)warningOb, OdDbObjectId.getCPtr(objectId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_warning(swigCPtr, warnVisGroup, (int)warningOb, OdDbObjectId.getCPtr(objectId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void warning2(OdError err)
	{
		if (SwigDerivedClassHasMethod("warning2", swigMethodTypes67))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_warning2SwigExplicitOdDbHostAppServices(swigCPtr, OdError.getCPtr(err));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_warning2(swigCPtr, OdError.getCPtr(err));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void warning3(string warnVisGroup, OdError err)
	{
		if (SwigDerivedClassHasMethod("warning3", swigMethodTypes68))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_warning3SwigExplicitOdDbHostAppServices(swigCPtr, warnVisGroup, OdError.getCPtr(err));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_warning3(swigCPtr, warnVisGroup, OdError.getCPtr(err));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override string getErrorDescription(uint errorCode)
	{
		string result = (SwigDerivedClassHasMethod("getErrorDescription", swigMethodTypes20) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getErrorDescriptionSwigExplicitOdDbHostAppServices(swigCPtr, errorCode) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getErrorDescription(swigCPtr, errorCode));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool doFullCRCCheck()
	{
		bool result = (SwigDerivedClassHasMethod("doFullCRCCheck", swigMethodTypes69) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_doFullCRCCheckSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_doFullCRCCheck(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbUndoController newUndoController()
	{
		OdDbUndoController rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUndoController>(SwigDerivedClassHasMethod("newUndoController", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_newUndoControllerSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_newUndoController(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void auditPrintReport(OdAuditInfo pAuditInfo, string strLine, int printDest)
	{
		if (SwigDerivedClassHasMethod("auditPrintReport", swigMethodTypes23))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_auditPrintReportSwigExplicitOdDbHostAppServices(swigCPtr, OdAuditInfo.getCPtr(pAuditInfo), strLine, printDest);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_auditPrintReport(swigCPtr, OdAuditInfo.getCPtr(pAuditInfo), strLine, printDest);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbPlotSettingsValidator plotSettingsValidator()
	{
		OdDbPlotSettingsValidator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettingsValidator>(SwigDerivedClassHasMethod("plotSettingsValidator", swigMethodTypes70) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_plotSettingsValidatorSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_plotSettingsValidator(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override string getAlternateFontName()
	{
		string result = (SwigDerivedClassHasMethod("getAlternateFontName", swigMethodTypes25) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getAlternateFontNameSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getAlternateFontName(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string getFontMapFileName()
	{
		string result = (SwigDerivedClassHasMethod("getFontMapFileName", swigMethodTypes26) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getFontMapFileNameSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getFontMapFileName(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string getPreferableFont(string fontName, OdTagFontType fontType)
	{
		string result = (SwigDerivedClassHasMethod("getPreferableFont", swigMethodTypes27) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPreferableFontSwigExplicitOdDbHostAppServices(swigCPtr, fontName, (int)fontType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPreferableFont(swigCPtr, fontName, (int)fontType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string getSubstituteFont(string fontName, OdTagFontType fontType)
	{
		string result = (SwigDerivedClassHasMethod("getSubstituteFont", swigMethodTypes28) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSubstituteFontSwigExplicitOdDbHostAppServices(swigCPtr, fontName, (int)fontType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSubstituteFont(swigCPtr, fontName, (int)fontType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string getSubstituteFontByChar(OdFont pFont, char unicodeChar, OdRxObject pDb)
	{
		string result = (SwigDerivedClassHasMethod("getSubstituteFontByChar", swigMethodTypes29) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSubstituteFontByCharSwigExplicitOdDbHostAppServices(swigCPtr, OdFont.getCPtr(pFont), unicodeChar, OdRxObject.getCPtr(pDb)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSubstituteFontByChar(swigCPtr, OdFont.getCPtr(pFont), unicodeChar, OdRxObject.getCPtr(pDb)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool getSystemFontFolders(OdStringArray aDirs)
	{
		bool result = (SwigDerivedClassHasMethod("getSystemFontFolders", swigMethodTypes30) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSystemFontFoldersSwigExplicitOdDbHostAppServices(swigCPtr, OdStringArray.getCPtr(aDirs).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSystemFontFolders(swigCPtr, OdStringArray.getCPtr(aDirs).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void collectFilePathsInDirectory(OdStringArray res, string sPath, string sFilter)
	{
		if (SwigDerivedClassHasMethod("collectFilePathsInDirectory", swigMethodTypes31))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_collectFilePathsInDirectorySwigExplicitOdDbHostAppServices__SWIG_0(swigCPtr, OdStringArray.getCPtr(res).Handle, sPath, sFilter);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_collectFilePathsInDirectory__SWIG_0(swigCPtr, OdStringArray.getCPtr(res).Handle, sPath, sFilter);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void collectFilePathsInDirectory(OdStringArray res, string sPath)
	{
		if (SwigDerivedClassHasMethod("collectFilePathsInDirectory", swigMethodTypes32))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_collectFilePathsInDirectorySwigExplicitOdDbHostAppServices__SWIG_1(swigCPtr, OdStringArray.getCPtr(res).Handle, sPath);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_collectFilePathsInDirectory__SWIG_1(swigCPtr, OdStringArray.getCPtr(res).Handle, sPath);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdHatchPatternManager patternManager()
	{
		OdHatchPatternManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdHatchPatternManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_patternManager(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool getPassword(string dwgName, bool isXref, ref string password)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(password);
		IntPtr intPtr = jarg;
		try
		{
			bool result = (SwigDerivedClassHasMethod("getPassword", swigMethodTypes72) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPasswordSwigExplicitOdDbHostAppServices(swigCPtr, dwgName, isXref, ref jarg) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPassword(swigCPtr, dwgName, isXref, ref jarg));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				password = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdPwdCache getPasswordCache()
	{
		OdPwdCache rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdPwdCache>(SwigDerivedClassHasMethod("getPasswordCache", swigMethodTypes73) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPasswordCacheSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPasswordCache(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbPageController newPageController()
	{
		OdDbPageController rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPageController>(SwigDerivedClassHasMethod("newPageController", swigMethodTypes74) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_newPageControllerSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_newPageController(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override string fileDialog(int flags, string dialogCaption, string defExt, string defFilename, string filter)
	{
		string result = (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes33) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_fileDialogSwigExplicitOdDbHostAppServices__SWIG_0(swigCPtr, flags, dialogCaption, defExt, defFilename, filter) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_fileDialog__SWIG_0(swigCPtr, flags, dialogCaption, defExt, defFilename, filter));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string fileDialog(int flags, string dialogCaption, string defExt, string defFilename)
	{
		string result = (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes34) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_fileDialogSwigExplicitOdDbHostAppServices__SWIG_1(swigCPtr, flags, dialogCaption, defExt, defFilename) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_fileDialog__SWIG_1(swigCPtr, flags, dialogCaption, defExt, defFilename));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string fileDialog(int flags, string dialogCaption, string defExt)
	{
		string result = (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes35) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_fileDialogSwigExplicitOdDbHostAppServices__SWIG_2(swigCPtr, flags, dialogCaption, defExt) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_fileDialog__SWIG_2(swigCPtr, flags, dialogCaption, defExt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string fileDialog(int flags, string dialogCaption)
	{
		string result = (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes36) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_fileDialogSwigExplicitOdDbHostAppServices__SWIG_3(swigCPtr, flags, dialogCaption) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_fileDialog__SWIG_3(swigCPtr, flags, dialogCaption));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string fileDialog(int flags)
	{
		string result = (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes37) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_fileDialogSwigExplicitOdDbHostAppServices__SWIG_4(swigCPtr, flags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_fileDialog__SWIG_4(swigCPtr, flags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbLayoutManager layoutManager()
	{
		OdDbLayoutManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayoutManager>(SwigDerivedClassHasMethod("layoutManager", swigMethodTypes75) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_layoutManagerSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_layoutManager(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint educationalPlotStamp()
	{
		uint result = (SwigDerivedClassHasMethod("educationalPlotStamp", swigMethodTypes76) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_educationalPlotStampSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_educationalPlotStamp(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbBaseHostAppServices getDgnHostAppServices()
	{
		OdDbBaseHostAppServices rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBaseHostAppServices>(SwigDerivedClassHasMethod("getDgnHostAppServices", swigMethodTypes77) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getDgnHostAppServicesSwigExplicitOdDbHostAppServices(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getDgnHostAppServices(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void getThumbSize(out uint nWidth, out uint nHeight)
	{
		if (SwigDerivedClassHasMethod("getThumbSize", swigMethodTypes78))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getThumbSizeSwigExplicitOdDbHostAppServices(swigCPtr, out nWidth, out nHeight);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getThumbSize(swigCPtr, out nWidth, out nHeight);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsDevice gsBitmapDevice(OdRxObject pViewObj, OdRxObject pDb, uint flags)
	{
		OdGsDevice rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes38) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_gsBitmapDeviceSwigExplicitOdDbHostAppServices__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewObj), OdRxObject.getCPtr(pDb), flags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_gsBitmapDevice__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewObj), OdRxObject.getCPtr(pDb), flags), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGsDevice gsBitmapDevice(OdRxObject pViewObj, OdRxObject pDb)
	{
		OdGsDevice rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes39) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_gsBitmapDeviceSwigExplicitOdDbHostAppServices__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewObj), OdRxObject.getCPtr(pDb)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_gsBitmapDevice__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewObj), OdRxObject.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGsDevice gsBitmapDevice(OdRxObject pViewObj)
	{
		OdGsDevice rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes40) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_gsBitmapDeviceSwigExplicitOdDbHostAppServices__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_gsBitmapDevice__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGsDevice gsBitmapDevice()
	{
		OdGsDevice rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes41) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_gsBitmapDeviceSwigExplicitOdDbHostAppServices__SWIG_3(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_gsBitmapDevice__SWIG_3(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdStreamBuf getHistoryFile(OdDbDatabase arg0)
	{
		OdStreamBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(SwigDerivedClassHasMethod("getHistoryFile", swigMethodTypes79) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getHistoryFileSwigExplicitOdDbHostAppServices(swigCPtr, OdDbDatabase.getCPtr(arg0)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getHistoryFile(swigCPtr, OdDbDatabase.getCPtr(arg0)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdResult BrepBuilder(OdBrepBuilder brepBuilder, BrepType bbType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_BrepBuilder(swigCPtr, OdBrepBuilder.getCPtr(brepBuilder), (int)bbType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual string fixName(OdDbSymbolTableRecord pRecord)
	{
		string result = (SwigDerivedClassHasMethod("fixName", swigMethodTypes80) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_fixNameSwigExplicitOdDbHostAppServices(swigCPtr, OdDbSymbolTableRecord.getCPtr(pRecord)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_fixName(swigCPtr, OdDbSymbolTableRecord.getCPtr(pRecord)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ushort getPLOTTRANSPARENCYOVERRIDE()
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPLOTTRANSPARENCYOVERRIDE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPLOTTRANSPARENCYOVERRIDE(ushort val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPLOTTRANSPARENCYOVERRIDE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getATTREQ()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getATTREQ(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setATTREQ(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setATTREQ(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getATTDIA()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getATTDIA(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setATTDIA(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setATTDIA(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getBLIPMODE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getBLIPMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBLIPMODE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setBLIPMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getDELOBJ()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getDELOBJ(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDELOBJ(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setDELOBJ(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getFILEDIA()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getFILEDIA(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFILEDIA(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setFILEDIA(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getCOORDS()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getCOORDS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setCOORDS(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setCOORDS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getDRAGMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getDRAGMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDRAGMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setDRAGMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getOSMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getOSMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOSMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setOSMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor getBACTIONCOLOR()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getBACTIONCOLOR(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBACTIONCOLOR(OdCmColor val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setBACTIONCOLOR(swigCPtr, OdCmColor.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getBDEPENDENCYHIGHLIGHT()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getBDEPENDENCYHIGHLIGHT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBDEPENDENCYHIGHLIGHT(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setBDEPENDENCYHIGHLIGHT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor getBGRIPOBJCOLOR()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getBGRIPOBJCOLOR(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBGRIPOBJCOLOR(OdCmColor val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setBGRIPOBJCOLOR(swigCPtr, OdCmColor.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getBGRIPOBJSIZE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getBGRIPOBJSIZE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBGRIPOBJSIZE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setBGRIPOBJSIZE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor getBPARAMETERCOLOR()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getBPARAMETERCOLOR(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBPARAMETERCOLOR(OdCmColor val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setBPARAMETERCOLOR(swigCPtr, OdCmColor.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getBPARAMETERFONT()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getBPARAMETERFONT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBPARAMETERFONT(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setBPARAMETERFONT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getBPARAMETERSIZE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getBPARAMETERSIZE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBPARAMETERSIZE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setBPARAMETERSIZE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getBPTEXTHORIZONTAL()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getBPTEXTHORIZONTAL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBPTEXTHORIZONTAL(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setBPTEXTHORIZONTAL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getBTMARKDISPLAY()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getBTMARKDISPLAY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBTMARKDISPLAY(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setBTMARKDISPLAY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getPICKFIRST()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPICKFIRST(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPICKFIRST(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPICKFIRST(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPICKBOX()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPICKBOX(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPICKBOX(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPICKBOX(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getAPERTURE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getAPERTURE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAPERTURE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setAPERTURE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPICKADD()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPICKADD(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPICKADD(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPICKADD(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPICKSTYLE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPICKSTYLE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPICKSTYLE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPICKSTYLE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double getLWDISPSCALE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getLWDISPSCALE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLWDISPSCALE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setLWDISPSCALE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual LineWeight getLWDEFAULT()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getLWDEFAULT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual void setLWDEFAULT(LineWeight val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setLWDEFAULT(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getFONTALT()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getFONTALT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFONTALT(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setFONTALT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPLINETYPE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPLINETYPE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPLINETYPE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPLINETYPE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getPLINEREVERSEWIDTHS()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPLINEREVERSEWIDTHS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPLINEREVERSEWIDTHS(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPLINEREVERSEWIDTHS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_ProxyImage getPROXYSHOW()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPROXYSHOW(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_ProxyImage)result;
	}

	public virtual void setPROXYSHOW(OdDb_ProxyImage val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPROXYSHOW(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getTEXTFILL()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getTEXTFILL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTEXTFILL(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setTEXTFILL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getGRIPHOVER()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getGRIPHOVER(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGRIPHOVER(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setGRIPHOVER(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getGRIPOBJLIMIT()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getGRIPOBJLIMIT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGRIPOBJLIMIT(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setGRIPOBJLIMIT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getGRIPTIPS()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getGRIPTIPS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGRIPTIPS(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setGRIPTIPS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getHPASSOC()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getHPASSOC(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHPASSOC(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setHPASSOC(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getLOCALROOTPREFIX()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getLOCALROOTPREFIX(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLOCALROOTPREFIX(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setLOCALROOTPREFIX(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getLOGFILEMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getLOGFILEMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLOGFILEMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setLOGFILEMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getMAXHATCHDENSITY()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getMAXHATCHDENSITY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMAXHATCHDENSITY(uint val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setMAXHATCHDENSITY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getSILHGENMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSILHGENMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSILHGENMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setSILHGENMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getSMOOTHMESHCONVERT()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSMOOTHMESHCONVERT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSMOOTHMESHCONVERT(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setSMOOTHMESHCONVERT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getSILHWIDTH()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSILHWIDTH(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSILHWIDTH(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setSILHWIDTH(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getFIELDDISPLAY()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getFIELDDISPLAY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFIELDDISPLAY(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setFIELDDISPLAY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getUCSVIEW()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getUCSVIEW(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setUCSVIEW(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setUCSVIEW(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getGRIPBLOCK()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getGRIPBLOCK(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGRIPBLOCK(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setGRIPBLOCK(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getGRIPCOLOR()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getGRIPCOLOR(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGRIPCOLOR(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setGRIPCOLOR(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getGRIPCONTOUR()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getGRIPCONTOUR(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGRIPCONTOUR(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setGRIPCONTOUR(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getGRIPDYNCOLOR()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getGRIPDYNCOLOR(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGRIPDYNCOLOR(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setGRIPDYNCOLOR(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getGRIPHOT()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getGRIPHOT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGRIPHOT(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setGRIPHOT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getGRIPS()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getGRIPS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGRIPS(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setGRIPS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getGRIPSIZE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getGRIPSIZE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGRIPSIZE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setGRIPSIZE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getSAVEFIDELITY()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSAVEFIDELITY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSAVEFIDELITY(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setSAVEFIDELITY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getDWFOSNAP()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getDWFOSNAP(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDWFOSNAP(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setDWFOSNAP(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getDGNOSNAP()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getDGNOSNAP(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDGNOSNAP(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setDGNOSNAP(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte getOLEQUALITY()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getOLEQUALITY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOLEQUALITY(byte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setOLEQUALITY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual sbyte getOLEHIDE()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getOLEHIDE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOLEHIDE(sbyte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setOLEHIDE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getISAVEPERCENT()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getISAVEPERCENT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setISAVEPERCENT(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setISAVEPERCENT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getDEMANDLOAD()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getDEMANDLOAD(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDEMANDLOAD(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setDEMANDLOAD(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getLAYLOCKFADECTL()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getLAYLOCKFADECTL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLAYLOCKFADECTL(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setLAYLOCKFADECTL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getTHUMBSIZE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getTHUMBSIZE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTHUMBSIZE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setTHUMBSIZE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPUBLISHHATCH()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPUBLISHHATCH(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPUBLISHHATCH(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPUBLISHHATCH(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getOPENPARTIAL()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getOPENPARTIAL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOPENPARTIAL(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setOPENPARTIAL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double getDGNIMPORTMAX()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getDGNIMPORTMAX(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDGNIMPORTMAX(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setDGNIMPORTMAX(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPLINECONVERTMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPLINECONVERTMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPLINECONVERTMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPLINECONVERTMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getPDFOSNAP()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPDFOSNAP(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPDFOSNAP(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPDFOSNAP(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getXFADECTL()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getXFADECTL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setXFADECTL(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setXFADECTL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getXDWGFADECTL()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getXDWGFADECTL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setXDWGFADECTL(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setXDWGFADECTL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPARAMETERCOPYMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPARAMETERCOPYMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPARAMETERCOPYMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPARAMETERCOPYMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getOBJECTISOLATIONMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getOBJECTISOLATIONMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOBJECTISOLATIONMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setOBJECTISOLATIONMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getARRAYTYPE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getARRAYTYPE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setARRAYTYPE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setARRAYTYPE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPOINTCLOUDAUTOUPDATE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPOINTCLOUDAUTOUPDATE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPOINTCLOUDAUTOUPDATE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPOINTCLOUDAUTOUPDATE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPOINTCLOUDDENSITY()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPOINTCLOUDDENSITY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPOINTCLOUDDENSITY(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPOINTCLOUDDENSITY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPOINTCLOUDLOCK()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPOINTCLOUDLOCK(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPOINTCLOUDLOCK(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPOINTCLOUDLOCK(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPOINTCLOUDRTDENSITY()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPOINTCLOUDRTDENSITY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPOINTCLOUDRTDENSITY(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPOINTCLOUDRTDENSITY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getARRAYASSOCIATIVITY()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getARRAYASSOCIATIVITY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setARRAYASSOCIATIVITY(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setARRAYASSOCIATIVITY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPOINTCLOUDBOUNDARY()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPOINTCLOUDBOUNDARY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPOINTCLOUDBOUNDARY(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPOINTCLOUDBOUNDARY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getPOINTCLOUDPOINTMAX()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPOINTCLOUDPOINTMAX(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPOINTCLOUDPOINTMAX(uint val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPOINTCLOUDPOINTMAX(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getTEXTALIGNMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getTEXTALIGNMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTEXTALIGNMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setTEXTALIGNMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getLINESMOOTHING()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getLINESMOOTHING(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLINESMOOTHING(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setLINESMOOTHING(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getHPLINETYPE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getHPLINETYPE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHPLINETYPE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setHPLINETYPE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double getHPGAPTOL()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getHPGAPTOL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHPGAPTOL(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setHPGAPTOL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int getPOINTCLOUDPOINTMAXLEGACY()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPOINTCLOUDPOINTMAXLEGACY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPOINTCLOUDPOINTMAXLEGACY(int val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPOINTCLOUDPOINTMAXLEGACY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getPOINTCLOUDLOD()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPOINTCLOUDLOD(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPOINTCLOUDLOD(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPOINTCLOUDLOD(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getREVCLOUDCREATEMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getREVCLOUDCREATEMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setREVCLOUDCREATEMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setREVCLOUDCREATEMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getREVCLOUDGRIPS()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getREVCLOUDGRIPS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setREVCLOUDGRIPS(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setREVCLOUDGRIPS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getLTGAPSELECTION()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getLTGAPSELECTION(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLTGAPSELECTION(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setLTGAPSELECTION(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getSELECTIONEFFECTCOLOR()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSELECTIONEFFECTCOLOR(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSELECTIONEFFECTCOLOR(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setSELECTIONEFFECTCOLOR(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getSELECTIONEFFECT()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSELECTIONEFFECT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSELECTIONEFFECT(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setSELECTIONEFFECT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getIMAGEHLT()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getIMAGEHLT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setIMAGEHLT(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setIMAGEHLT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getHPMAXCONTOURPOINTS()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getHPMAXCONTOURPOINTS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHPMAXCONTOURPOINTS(uint val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setHPMAXCONTOURPOINTS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getHPCUTPOINTSLIMIT()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getHPCUTPOINTSLIMIT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHPCUTPOINTSLIMIT(uint val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setHPCUTPOINTSLIMIT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getHPSMOOTHEVALUATE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getHPSMOOTHEVALUATE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHPSMOOTHEVALUATE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setHPSMOOTHEVALUATE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getHPNEWDRAW()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getHPNEWDRAW(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHPNEWDRAW(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setHPNEWDRAW(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getSAVEROUNDTRIP()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getSAVEROUNDTRIP(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSAVEROUNDTRIP(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setSAVEROUNDTRIP(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double getR12SaveDeviation()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getR12SaveDeviation(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setR12SaveDeviation(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setR12SaveDeviation(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getR12SaveAccuracy()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getR12SaveAccuracy(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setR12SaveAccuracy(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setR12SaveAccuracy(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getAcisSaveAsMode()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getAcisSaveAsMode(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAcisSaveAsMode(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setAcisSaveAsMode(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual sbyte getAcisProxyMode()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getAcisProxyMode(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAcisProxyMode(sbyte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setAcisProxyMode(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getPLINECACHE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPLINECACHE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPLINECACHE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPLINECACHE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getDxfTextAdjustAlignment()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getDxfTextAdjustAlignment(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDxfTextAdjustAlignment(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setDxfTextAdjustAlignment(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getRecomputeDimBlocksRequired()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getRecomputeDimBlocksRequired(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRecomputeDimBlocksRequired(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setRecomputeDimBlocksRequired(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getAllowSavingEmptyAcisObjects()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getAllowSavingEmptyAcisObjects(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAllowSavingEmptyAcisObjects(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setAllowSavingEmptyAcisObjects(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getRestoreHatchFromBlkRef()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getRestoreHatchFromBlkRef(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRestoreHatchFromBlkRef(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setRestoreHatchFromBlkRef(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getARX_COMPATIBILITY_FLAGS()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getARX_COMPATIBILITY_FLAGS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setARX_COMPATIBILITY_FLAGS(uint val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setARX_COMPATIBILITY_FLAGS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override short getMtMode()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getMtMode(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMtMode(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setMtMode(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getNegativeHandlesReserved()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getNegativeHandlesReserved(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setNegativeHandlesReserved(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setNegativeHandlesReserved(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getVerticalApplicationsMode()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getVerticalApplicationsMode(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVerticalApplicationsMode(uint val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setVerticalApplicationsMode(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getEnableAcisAudit()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getEnableAcisAudit(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEnableAcisAudit(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setEnableAcisAudit(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getHonourLockedLayer()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getHonourLockedLayer(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHonourLockedLayer(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setHonourLockedLayer(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getTableIndicator()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getTableIndicator(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTableIndicator(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setTableIndicator(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getTableLinkIndicator()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getTableLinkIndicator(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTableLinkIndicator(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setTableLinkIndicator(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getTableSelectIndicator()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getTableSelectIndicator(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTableSelectIndicator(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setTableSelectIndicator(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getTableIndicatorColor()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getTableIndicatorColor(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTableIndicatorColor(uint val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setTableIndicatorColor(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getFieldIndicatorColor()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getFieldIndicatorColor(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFieldIndicatorColor(uint val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setFieldIndicatorColor(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getPDFIMPORTIMAGEPATH()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPDFIMPORTIMAGEPATH(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPDFIMPORTIMAGEPATH(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPDFIMPORTIMAGEPATH(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getPartialViewingMode()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getPartialViewingMode(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPartialViewingMode(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setPartialViewingMode(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getLineType3dPline()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getLineType3dPline(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLineType3dPline(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setLineType3dPline(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getXREFREGAPPCTL()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getXREFREGAPPCTL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setXREFREGAPPCTL(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setXREFREGAPPCTL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte getTRACEPAPERCTL()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getTRACEPAPERCTL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTRACEPAPERCTL(byte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setTRACEPAPERCTL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte getTRACEFADECTL()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getTRACEFADECTL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTRACEFADECTL(byte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setTRACEFADECTL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte getTRACEOSNAP()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getTRACEOSNAP(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTRACEOSNAP(byte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setTRACEOSNAP(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short getVISRETAINMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getVISRETAINMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVISRETAINMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setVISRETAINMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte getHPDRAWMODE()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_getHPDRAWMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHPDRAWMODE(byte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_setHPDRAWMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
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
		if (SwigDerivedClassHasMethod("getMtMode", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodgetMtMode;
		}
		if (SwigDerivedClassHasMethod("numThreads", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodnumThreads;
		}
		if (SwigDerivedClassHasMethod("getEnv", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodgetEnv;
		}
		if (SwigDerivedClassHasMethod("setEnv", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodsetEnv;
		}
		if (SwigDerivedClassHasMethod("getAppUserName", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodgetAppUserName__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getAppUserName", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodgetAppUserName__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("databaseClass", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethoddatabaseClass;
		}
		if (SwigDerivedClassHasMethod("createDatabase", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodcreateDatabase__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createDatabase", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodcreateDatabase__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createDatabase", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodcreateDatabase__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodreadFile__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodreadFile__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodreadFile__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodreadFile__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("recoverFile", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodrecoverFile__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("recoverFile", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodrecoverFile__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("recoverFile", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodrecoverFile__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodreadFile__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodreadFile__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodreadFile__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodreadFile__SWIG_7;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodreadFile__SWIG_8;
		}
		if (SwigDerivedClassHasMethod("warning1", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodwarning1;
		}
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodwarning;
		}
		if (SwigDerivedClassHasMethod("warning2", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodwarning2;
		}
		if (SwigDerivedClassHasMethod("warning3", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodwarning3;
		}
		if (SwigDerivedClassHasMethod("doFullCRCCheck", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethoddoFullCRCCheck;
		}
		if (SwigDerivedClassHasMethod("plotSettingsValidator", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodplotSettingsValidator;
		}
		if (SwigDerivedClassHasMethod("patternManager", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodpatternManager;
		}
		if (SwigDerivedClassHasMethod("getPassword", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodgetPassword;
		}
		if (SwigDerivedClassHasMethod("getPasswordCache", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodgetPasswordCache;
		}
		if (SwigDerivedClassHasMethod("newPageController", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodnewPageController;
		}
		if (SwigDerivedClassHasMethod("layoutManager", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodlayoutManager;
		}
		if (SwigDerivedClassHasMethod("educationalPlotStamp", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodeducationalPlotStamp;
		}
		if (SwigDerivedClassHasMethod("getDgnHostAppServices", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodgetDgnHostAppServices;
		}
		if (SwigDerivedClassHasMethod("getThumbSize", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodgetThumbSize;
		}
		if (SwigDerivedClassHasMethod("getHistoryFile", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodgetHistoryFile;
		}
		if (SwigDerivedClassHasMethod("fixName", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodfixName;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbHostAppServices));
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

	private short SwigDirectorMethodgetMtMode()
	{
		return getMtMode();
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetAppUserName__SWIG_0(int unFormat)
	{
		return getAppUserName((Oda_UserNameFormat)unFormat);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetAppUserName__SWIG_1()
	{
		return getAppUserName();
	}

	private IntPtr SwigDirectorMethoddatabaseClass()
	{
		return OdRxClass.getCPtr(databaseClass()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateDatabase__SWIG_0(bool createDefault, int measurement)
	{
		return OdDbDatabase.getCPtr(createDatabase(createDefault, (MeasurementValue)measurement)).Handle;
	}

	private IntPtr SwigDirectorMethodcreateDatabase__SWIG_1(bool createDefault)
	{
		return OdDbDatabase.getCPtr(createDatabase(createDefault)).Handle;
	}

	private IntPtr SwigDirectorMethodcreateDatabase__SWIG_2()
	{
		return OdDbDatabase.getCPtr(createDatabase()).Handle;
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

	private IntPtr SwigDirectorMethodreadFile__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad, int shareMode, [MarshalAs(UnmanagedType.LPWStr)] string password)
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

	private IntPtr SwigDirectorMethodgetDgnHostAppServices()
	{
		return OdDbBaseHostAppServices.getCPtr(getDgnHostAppServices()).Handle;
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
}

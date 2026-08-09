using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbHostAppServices2 : OdDbHostAppServices
{
	public delegate IntPtr SwigDelegateOdDbHostAppServices2_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_1();

	public delegate void SwigDelegateOdDbHostAppServices2_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_3([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb, int hint);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_4([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_5([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_6();

	public delegate void SwigDelegateOdDbHostAppServices2_7(IntPtr pProgressMeter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_8();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_9();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_10();

	public delegate int SwigDelegateOdDbHostAppServices2_11();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_12();

	public delegate int SwigDelegateOdDbHostAppServices2_13();

	public delegate int SwigDelegateOdDbHostAppServices2_14();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_15();

	public delegate void SwigDelegateOdDbHostAppServices2_16([MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateOdDbHostAppServices2_17(string warnVisGroup, [MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateOdDbHostAppServices2_18(int warningOb);

	public delegate void SwigDelegateOdDbHostAppServices2_19(string warnVisGroup, int warningOb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_20(uint errorCode);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_21();

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_22();

	public delegate void SwigDelegateOdDbHostAppServices2_23(IntPtr pAuditInfo, [MarshalAs(UnmanagedType.LPWStr)] string strLine, int printDest);

	public delegate bool SwigDelegateOdDbHostAppServices2_24(IntPtr description, IntPtr filename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_25();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_26();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_27([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_28([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_29(IntPtr pFont, char unicodeChar, IntPtr pDb);

	public delegate bool SwigDelegateOdDbHostAppServices2_30(IntPtr aDirs);

	public delegate void SwigDelegateOdDbHostAppServices2_31(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath, [MarshalAs(UnmanagedType.LPWStr)] string sFilter);

	public delegate void SwigDelegateOdDbHostAppServices2_32(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_33(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename, [MarshalAs(UnmanagedType.LPWStr)] string filter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_34(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_35(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_36(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_37(int flags);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_38(IntPtr pViewObj, IntPtr pDb, uint flags);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_39(IntPtr pViewObj, IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_40(IntPtr pViewObj);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_41();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_42();

	public delegate short SwigDelegateOdDbHostAppServices2_43();

	public delegate int SwigDelegateOdDbHostAppServices2_44(int mtMode);

	public delegate int SwigDelegateOdDbHostAppServices2_45([MarshalAs(UnmanagedType.LPWStr)] string varName, IntPtr value);

	public delegate int SwigDelegateOdDbHostAppServices2_46([MarshalAs(UnmanagedType.LPWStr)] string varName, [MarshalAs(UnmanagedType.LPWStr)] string newValue);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_47(int unFormat);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_48();

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_49();

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_50(bool createDefault, int measurement);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_51(bool createDefault);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_52();

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_53(IntPtr pStreamBuf, bool allowCPConversion, bool partialLoad, [MarshalAs(UnmanagedType.LPWStr)] string password);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_54(IntPtr pStreamBuf, bool allowCPConversion, bool partialLoad);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_55(IntPtr pStreamBuf, bool allowCPConversion);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_56(IntPtr pStreamBuf);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_57(IntPtr pStreamBuf, IntPtr pAuditInfo, [MarshalAs(UnmanagedType.LPWStr)] string password);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_58(IntPtr pStreamBuf, IntPtr pAuditInfo);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_59(IntPtr pStreamBuf);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_60([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad, int shareMode, [MarshalAs(UnmanagedType.LPWStr)] string password);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_61([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad, int shareMode);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_62([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion, bool partialLoad);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_63([MarshalAs(UnmanagedType.LPWStr)] string filename, bool allowCPConversion);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_64([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate void SwigDelegateOdDbHostAppServices2_65(int warningOb, IntPtr objectId);

	public delegate void SwigDelegateOdDbHostAppServices2_66(string warnVisGroup, int warningOb, IntPtr objectId);

	public delegate void SwigDelegateOdDbHostAppServices2_67(IntPtr err);

	public delegate void SwigDelegateOdDbHostAppServices2_68(string warnVisGroup, IntPtr err);

	public delegate bool SwigDelegateOdDbHostAppServices2_69();

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_70();

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_71();

	public delegate bool SwigDelegateOdDbHostAppServices2_72([MarshalAs(UnmanagedType.LPWStr)] string dwgName, bool isXref, IntPtr password);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_73();

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_74();

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_75();

	public delegate uint SwigDelegateOdDbHostAppServices2_76();

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_77();

	public delegate void SwigDelegateOdDbHostAppServices2_78(uint nWidth, uint nHeight);

	public delegate IntPtr SwigDelegateOdDbHostAppServices2_79(IntPtr arg0);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHostAppServices2_80(IntPtr pRecord);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbHostAppServices2_0 swigDelegate0;

	private SwigDelegateOdDbHostAppServices2_1 swigDelegate1;

	private SwigDelegateOdDbHostAppServices2_2 swigDelegate2;

	private SwigDelegateOdDbHostAppServices2_3 swigDelegate3;

	private SwigDelegateOdDbHostAppServices2_4 swigDelegate4;

	private SwigDelegateOdDbHostAppServices2_5 swigDelegate5;

	private SwigDelegateOdDbHostAppServices2_6 swigDelegate6;

	private SwigDelegateOdDbHostAppServices2_7 swigDelegate7;

	private SwigDelegateOdDbHostAppServices2_8 swigDelegate8;

	private SwigDelegateOdDbHostAppServices2_9 swigDelegate9;

	private SwigDelegateOdDbHostAppServices2_10 swigDelegate10;

	private SwigDelegateOdDbHostAppServices2_11 swigDelegate11;

	private SwigDelegateOdDbHostAppServices2_12 swigDelegate12;

	private SwigDelegateOdDbHostAppServices2_13 swigDelegate13;

	private SwigDelegateOdDbHostAppServices2_14 swigDelegate14;

	private SwigDelegateOdDbHostAppServices2_15 swigDelegate15;

	private SwigDelegateOdDbHostAppServices2_16 swigDelegate16;

	private SwigDelegateOdDbHostAppServices2_17 swigDelegate17;

	private SwigDelegateOdDbHostAppServices2_18 swigDelegate18;

	private SwigDelegateOdDbHostAppServices2_19 swigDelegate19;

	private SwigDelegateOdDbHostAppServices2_20 swigDelegate20;

	private SwigDelegateOdDbHostAppServices2_21 swigDelegate21;

	private SwigDelegateOdDbHostAppServices2_22 swigDelegate22;

	private SwigDelegateOdDbHostAppServices2_23 swigDelegate23;

	private SwigDelegateOdDbHostAppServices2_24 swigDelegate24;

	private SwigDelegateOdDbHostAppServices2_25 swigDelegate25;

	private SwigDelegateOdDbHostAppServices2_26 swigDelegate26;

	private SwigDelegateOdDbHostAppServices2_27 swigDelegate27;

	private SwigDelegateOdDbHostAppServices2_28 swigDelegate28;

	private SwigDelegateOdDbHostAppServices2_29 swigDelegate29;

	private SwigDelegateOdDbHostAppServices2_30 swigDelegate30;

	private SwigDelegateOdDbHostAppServices2_31 swigDelegate31;

	private SwigDelegateOdDbHostAppServices2_32 swigDelegate32;

	private SwigDelegateOdDbHostAppServices2_33 swigDelegate33;

	private SwigDelegateOdDbHostAppServices2_34 swigDelegate34;

	private SwigDelegateOdDbHostAppServices2_35 swigDelegate35;

	private SwigDelegateOdDbHostAppServices2_36 swigDelegate36;

	private SwigDelegateOdDbHostAppServices2_37 swigDelegate37;

	private SwigDelegateOdDbHostAppServices2_38 swigDelegate38;

	private SwigDelegateOdDbHostAppServices2_39 swigDelegate39;

	private SwigDelegateOdDbHostAppServices2_40 swigDelegate40;

	private SwigDelegateOdDbHostAppServices2_41 swigDelegate41;

	private SwigDelegateOdDbHostAppServices2_42 swigDelegate42;

	private SwigDelegateOdDbHostAppServices2_43 swigDelegate43;

	private SwigDelegateOdDbHostAppServices2_44 swigDelegate44;

	private SwigDelegateOdDbHostAppServices2_45 swigDelegate45;

	private SwigDelegateOdDbHostAppServices2_46 swigDelegate46;

	private SwigDelegateOdDbHostAppServices2_47 swigDelegate47;

	private SwigDelegateOdDbHostAppServices2_48 swigDelegate48;

	private SwigDelegateOdDbHostAppServices2_49 swigDelegate49;

	private SwigDelegateOdDbHostAppServices2_50 swigDelegate50;

	private SwigDelegateOdDbHostAppServices2_51 swigDelegate51;

	private SwigDelegateOdDbHostAppServices2_52 swigDelegate52;

	private SwigDelegateOdDbHostAppServices2_53 swigDelegate53;

	private SwigDelegateOdDbHostAppServices2_54 swigDelegate54;

	private SwigDelegateOdDbHostAppServices2_55 swigDelegate55;

	private SwigDelegateOdDbHostAppServices2_56 swigDelegate56;

	private SwigDelegateOdDbHostAppServices2_57 swigDelegate57;

	private SwigDelegateOdDbHostAppServices2_58 swigDelegate58;

	private SwigDelegateOdDbHostAppServices2_59 swigDelegate59;

	private SwigDelegateOdDbHostAppServices2_60 swigDelegate60;

	private SwigDelegateOdDbHostAppServices2_61 swigDelegate61;

	private SwigDelegateOdDbHostAppServices2_62 swigDelegate62;

	private SwigDelegateOdDbHostAppServices2_63 swigDelegate63;

	private SwigDelegateOdDbHostAppServices2_64 swigDelegate64;

	private SwigDelegateOdDbHostAppServices2_65 swigDelegate65;

	private SwigDelegateOdDbHostAppServices2_66 swigDelegate66;

	private SwigDelegateOdDbHostAppServices2_67 swigDelegate67;

	private SwigDelegateOdDbHostAppServices2_68 swigDelegate68;

	private SwigDelegateOdDbHostAppServices2_69 swigDelegate69;

	private SwigDelegateOdDbHostAppServices2_70 swigDelegate70;

	private SwigDelegateOdDbHostAppServices2_71 swigDelegate71;

	private SwigDelegateOdDbHostAppServices2_72 swigDelegate72;

	private SwigDelegateOdDbHostAppServices2_73 swigDelegate73;

	private SwigDelegateOdDbHostAppServices2_74 swigDelegate74;

	private SwigDelegateOdDbHostAppServices2_75 swigDelegate75;

	private SwigDelegateOdDbHostAppServices2_76 swigDelegate76;

	private SwigDelegateOdDbHostAppServices2_77 swigDelegate77;

	private SwigDelegateOdDbHostAppServices2_78 swigDelegate78;

	private SwigDelegateOdDbHostAppServices2_79 swigDelegate79;

	private SwigDelegateOdDbHostAppServices2_80 swigDelegate80;

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
	public OdDbHostAppServices2(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices2_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbHostAppServices2 obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbHostAppServices2(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbHostAppServices2()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbHostAppServices2(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices2_getRealClassName(ptr);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHostAppServices2_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbHostAppServices2));
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

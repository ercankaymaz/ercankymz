using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbUserIO : OdEdBaseUserIO
{
	public delegate IntPtr SwigDelegateOdDbUserIO_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbUserIO_1();

	public delegate void SwigDelegateOdDbUserIO_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbUserIO_3();

	public delegate int SwigDelegateOdDbUserIO_4([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal, int options, IntPtr pTracker);

	public delegate int SwigDelegateOdDbUserIO_5([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal, int options);

	public delegate int SwigDelegateOdDbUserIO_6([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal);

	public delegate int SwigDelegateOdDbUserIO_7([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate int SwigDelegateOdDbUserIO_8([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate int SwigDelegateOdDbUserIO_9([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate int SwigDelegateOdDbUserIO_10([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal);

	public delegate int SwigDelegateOdDbUserIO_11([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate int SwigDelegateOdDbUserIO_12([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate double SwigDelegateOdDbUserIO_13([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate double SwigDelegateOdDbUserIO_14([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate double SwigDelegateOdDbUserIO_15([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal);

	public delegate double SwigDelegateOdDbUserIO_16([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate double SwigDelegateOdDbUserIO_17([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_18([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_19([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_20([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_21([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_22([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate void SwigDelegateOdDbUserIO_23([MarshalAs(UnmanagedType.LPWStr)] string string_);

	public delegate IntPtr SwigDelegateOdDbUserIO_24([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate IntPtr SwigDelegateOdDbUserIO_25([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate IntPtr SwigDelegateOdDbUserIO_26([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue);

	public delegate IntPtr SwigDelegateOdDbUserIO_27([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate IntPtr SwigDelegateOdDbUserIO_28([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_29([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_30([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_31([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_32([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_33([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_34([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_35([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUserIO_36([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate void SwigDelegateOdDbUserIO_37([MarshalAs(UnmanagedType.LPWStr)] string errmsg);

	public delegate IntPtr SwigDelegateOdDbUserIO_38();

	public delegate void SwigDelegateOdDbUserIO_39(IntPtr pt);

	public delegate IntPtr SwigDelegateOdDbUserIO_40(IntPtr base_, IntPtr pModel);

	public delegate IntPtr SwigDelegateOdDbUserIO_41(IntPtr base_);

	public delegate IntPtr SwigDelegateOdDbUserIO_42(IntPtr base_, IntPtr pModel);

	public delegate IntPtr SwigDelegateOdDbUserIO_43(IntPtr base_);

	public delegate IntPtr SwigDelegateOdDbUserIO_44([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate IntPtr SwigDelegateOdDbUserIO_45([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate IntPtr SwigDelegateOdDbUserIO_46([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue);

	public delegate IntPtr SwigDelegateOdDbUserIO_47([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate IntPtr SwigDelegateOdDbUserIO_48([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate double SwigDelegateOdDbUserIO_49([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate double SwigDelegateOdDbUserIO_50([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate double SwigDelegateOdDbUserIO_51([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue);

	public delegate double SwigDelegateOdDbUserIO_52([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate double SwigDelegateOdDbUserIO_53([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate double SwigDelegateOdDbUserIO_54([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate double SwigDelegateOdDbUserIO_55([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate double SwigDelegateOdDbUserIO_56([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue);

	public delegate double SwigDelegateOdDbUserIO_57([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate double SwigDelegateOdDbUserIO_58([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate void SwigDelegateOdDbUserIO_59(IntPtr pSSet);

	public delegate IntPtr SwigDelegateOdDbUserIO_60();

	public delegate IntPtr SwigDelegateOdDbUserIO_61([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate IntPtr SwigDelegateOdDbUserIO_62([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate IntPtr SwigDelegateOdDbUserIO_63([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue);

	public delegate IntPtr SwigDelegateOdDbUserIO_64([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate IntPtr SwigDelegateOdDbUserIO_65([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate IntPtr SwigDelegateOdDbUserIO_66([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker, IntPtr ptsPointer);

	public delegate IntPtr SwigDelegateOdDbUserIO_67([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate IntPtr SwigDelegateOdDbUserIO_68([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate IntPtr SwigDelegateOdDbUserIO_69([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue);

	public delegate IntPtr SwigDelegateOdDbUserIO_70([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate IntPtr SwigDelegateOdDbUserIO_71([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate IntPtr SwigDelegateOdDbUserIO_72();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbUserIO_0 swigDelegate0;

	private SwigDelegateOdDbUserIO_1 swigDelegate1;

	private SwigDelegateOdDbUserIO_2 swigDelegate2;

	private SwigDelegateOdDbUserIO_3 swigDelegate3;

	private SwigDelegateOdDbUserIO_4 swigDelegate4;

	private SwigDelegateOdDbUserIO_5 swigDelegate5;

	private SwigDelegateOdDbUserIO_6 swigDelegate6;

	private SwigDelegateOdDbUserIO_7 swigDelegate7;

	private SwigDelegateOdDbUserIO_8 swigDelegate8;

	private SwigDelegateOdDbUserIO_9 swigDelegate9;

	private SwigDelegateOdDbUserIO_10 swigDelegate10;

	private SwigDelegateOdDbUserIO_11 swigDelegate11;

	private SwigDelegateOdDbUserIO_12 swigDelegate12;

	private SwigDelegateOdDbUserIO_13 swigDelegate13;

	private SwigDelegateOdDbUserIO_14 swigDelegate14;

	private SwigDelegateOdDbUserIO_15 swigDelegate15;

	private SwigDelegateOdDbUserIO_16 swigDelegate16;

	private SwigDelegateOdDbUserIO_17 swigDelegate17;

	private SwigDelegateOdDbUserIO_18 swigDelegate18;

	private SwigDelegateOdDbUserIO_19 swigDelegate19;

	private SwigDelegateOdDbUserIO_20 swigDelegate20;

	private SwigDelegateOdDbUserIO_21 swigDelegate21;

	private SwigDelegateOdDbUserIO_22 swigDelegate22;

	private SwigDelegateOdDbUserIO_23 swigDelegate23;

	private SwigDelegateOdDbUserIO_24 swigDelegate24;

	private SwigDelegateOdDbUserIO_25 swigDelegate25;

	private SwigDelegateOdDbUserIO_26 swigDelegate26;

	private SwigDelegateOdDbUserIO_27 swigDelegate27;

	private SwigDelegateOdDbUserIO_28 swigDelegate28;

	private SwigDelegateOdDbUserIO_29 swigDelegate29;

	private SwigDelegateOdDbUserIO_30 swigDelegate30;

	private SwigDelegateOdDbUserIO_31 swigDelegate31;

	private SwigDelegateOdDbUserIO_32 swigDelegate32;

	private SwigDelegateOdDbUserIO_33 swigDelegate33;

	private SwigDelegateOdDbUserIO_34 swigDelegate34;

	private SwigDelegateOdDbUserIO_35 swigDelegate35;

	private SwigDelegateOdDbUserIO_36 swigDelegate36;

	private SwigDelegateOdDbUserIO_37 swigDelegate37;

	private SwigDelegateOdDbUserIO_38 swigDelegate38;

	private SwigDelegateOdDbUserIO_39 swigDelegate39;

	private SwigDelegateOdDbUserIO_40 swigDelegate40;

	private SwigDelegateOdDbUserIO_41 swigDelegate41;

	private SwigDelegateOdDbUserIO_42 swigDelegate42;

	private SwigDelegateOdDbUserIO_43 swigDelegate43;

	private SwigDelegateOdDbUserIO_44 swigDelegate44;

	private SwigDelegateOdDbUserIO_45 swigDelegate45;

	private SwigDelegateOdDbUserIO_46 swigDelegate46;

	private SwigDelegateOdDbUserIO_47 swigDelegate47;

	private SwigDelegateOdDbUserIO_48 swigDelegate48;

	private SwigDelegateOdDbUserIO_49 swigDelegate49;

	private SwigDelegateOdDbUserIO_50 swigDelegate50;

	private SwigDelegateOdDbUserIO_51 swigDelegate51;

	private SwigDelegateOdDbUserIO_52 swigDelegate52;

	private SwigDelegateOdDbUserIO_53 swigDelegate53;

	private SwigDelegateOdDbUserIO_54 swigDelegate54;

	private SwigDelegateOdDbUserIO_55 swigDelegate55;

	private SwigDelegateOdDbUserIO_56 swigDelegate56;

	private SwigDelegateOdDbUserIO_57 swigDelegate57;

	private SwigDelegateOdDbUserIO_58 swigDelegate58;

	private SwigDelegateOdDbUserIO_59 swigDelegate59;

	private SwigDelegateOdDbUserIO_60 swigDelegate60;

	private SwigDelegateOdDbUserIO_61 swigDelegate61;

	private SwigDelegateOdDbUserIO_62 swigDelegate62;

	private SwigDelegateOdDbUserIO_63 swigDelegate63;

	private SwigDelegateOdDbUserIO_64 swigDelegate64;

	private SwigDelegateOdDbUserIO_65 swigDelegate65;

	private SwigDelegateOdDbUserIO_66 swigDelegate66;

	private SwigDelegateOdDbUserIO_67 swigDelegate67;

	private SwigDelegateOdDbUserIO_68 swigDelegate68;

	private SwigDelegateOdDbUserIO_69 swigDelegate69;

	private SwigDelegateOdDbUserIO_70 swigDelegate70;

	private SwigDelegateOdDbUserIO_71 swigDelegate71;

	private SwigDelegateOdDbUserIO_72 swigDelegate72;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[5]
	{
		typeof(string),
		typeof(string),
		typeof(int),
		typeof(int),
		typeof(OdEdIntegerTracker)
	};

	private static Type[] swigMethodTypes5 = new Type[4]
	{
		typeof(string),
		typeof(string),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes8 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(int),
		typeof(string),
		typeof(OdEdIntegerTracker)
	};

	private static Type[] swigMethodTypes9 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes10 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes13 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(double),
		typeof(string),
		typeof(OdEdRealTracker)
	};

	private static Type[] swigMethodTypes14 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(double),
		typeof(string)
	};

	private static Type[] swigMethodTypes15 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(double)
	};

	private static Type[] swigMethodTypes16 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes18 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(OdEdStringTracker)
	};

	private static Type[] swigMethodTypes19 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes20 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes21 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes24 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(OdCmColorBase),
		typeof(string),
		typeof(OdEdColorTracker)
	};

	private static Type[] swigMethodTypes25 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(OdCmColorBase),
		typeof(string)
	};

	private static Type[] swigMethodTypes26 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(OdCmColorBase)
	};

	private static Type[] swigMethodTypes27 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes29 = new Type[8]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(OdEdStringTracker)
	};

	private static Type[] swigMethodTypes30 = new Type[7]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes31 = new Type[6]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes32 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes33 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes34 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes35 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes38 = new Type[0];

	private static Type[] swigMethodTypes39 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes40 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGsModel)
	};

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes42 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGsModel)
	};

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes44 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(OdGePoint3d),
		typeof(string),
		typeof(OdEdPointTracker)
	};

	private static Type[] swigMethodTypes45 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(OdGePoint3d),
		typeof(string)
	};

	private static Type[] swigMethodTypes46 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes47 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes48 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes49 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(double),
		typeof(string),
		typeof(OdEdRealTracker)
	};

	private static Type[] swigMethodTypes50 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(double),
		typeof(string)
	};

	private static Type[] swigMethodTypes51 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(double)
	};

	private static Type[] swigMethodTypes52 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes54 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(double),
		typeof(string),
		typeof(OdEdRealTracker)
	};

	private static Type[] swigMethodTypes55 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(double),
		typeof(string)
	};

	private static Type[] swigMethodTypes56 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(double)
	};

	private static Type[] swigMethodTypes57 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(OdSelectionSet) };

	private static Type[] swigMethodTypes60 = new Type[0];

	private static Type[] swigMethodTypes61 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(OdCmColor),
		typeof(string),
		typeof(OdEdColorTracker)
	};

	private static Type[] swigMethodTypes62 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(OdCmColor),
		typeof(string)
	};

	private static Type[] swigMethodTypes63 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(OdCmColor)
	};

	private static Type[] swigMethodTypes64 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes65 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes66 = new Type[6]
	{
		typeof(string),
		typeof(int),
		typeof(OdSelectionSet),
		typeof(string),
		typeof(OdSSetTracker),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes67 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(OdSelectionSet),
		typeof(string),
		typeof(OdSSetTracker)
	};

	private static Type[] swigMethodTypes68 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(OdSelectionSet),
		typeof(string)
	};

	private static Type[] swigMethodTypes69 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(OdSelectionSet)
	};

	private static Type[] swigMethodTypes70 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes71 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes72 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbUserIO(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbUserIO obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbUserIO(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbUserIO()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbUserIO(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbUserIO cast(OdRxObject pObj)
	{
		OdDbUserIO rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUserIO>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_isASwigExplicitOdDbUserIO(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_queryXSwigExplicitOdDbUserIO(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbUserIO createObject()
	{
		OdDbUserIO rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUserIO>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setPickfirst(OdSelectionSet pSSet)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_setPickfirst(swigCPtr, OdSelectionSet.getCPtr(pSSet));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdSelectionSet pickfirst()
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_pickfirst(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdCmColor getColor(string prompt, int options, OdCmColor pDefaultValue, string keywords, OdEdColorTracker pTracker)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_getColor__SWIG_0(swigCPtr, prompt, options, OdCmColor.getCPtr(pDefaultValue), keywords, OdEdColorTracker.getCPtr(pTracker)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor getColor(string prompt, int options, OdCmColor pDefaultValue, string keywords)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_getColor__SWIG_1(swigCPtr, prompt, options, OdCmColor.getCPtr(pDefaultValue), keywords), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor getColor(string prompt, int options, OdCmColor pDefaultValue)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_getColor__SWIG_2(swigCPtr, prompt, options, OdCmColor.getCPtr(pDefaultValue)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor getColor(string prompt, int options)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_getColor__SWIG_3(swigCPtr, prompt, options), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor getColor(string prompt)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_getColor__SWIG_4(swigCPtr, prompt), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdSelectionSet select(string prompt, int options, OdSelectionSet pDefaultValue, string keywords, OdSSetTracker pTracker, OdGePoint3dArray ptsPointer)
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_select__SWIG_0(swigCPtr, prompt, options, OdSelectionSet.getCPtr(pDefaultValue), keywords, OdSSetTracker.getCPtr(pTracker), OdGePoint3dArray.getCPtr(ptsPointer).Handle), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet select(string prompt, int options, OdSelectionSet pDefaultValue, string keywords, OdSSetTracker pTracker)
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_select__SWIG_1(swigCPtr, prompt, options, OdSelectionSet.getCPtr(pDefaultValue), keywords, OdSSetTracker.getCPtr(pTracker)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet select(string prompt, int options, OdSelectionSet pDefaultValue, string keywords)
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_select__SWIG_2(swigCPtr, prompt, options, OdSelectionSet.getCPtr(pDefaultValue), keywords), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet select(string prompt, int options, OdSelectionSet pDefaultValue)
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_select__SWIG_3(swigCPtr, prompt, options, OdSelectionSet.getCPtr(pDefaultValue)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet select(string prompt, int options)
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_select__SWIG_4(swigCPtr, prompt, options), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet select(string prompt)
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_select__SWIG_5(swigCPtr, prompt), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet select()
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_select__SWIG_6(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("interactive", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinteractive;
		}
		if (SwigDerivedClassHasMethod("getKeyword", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetKeyword__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getKeyword", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetKeyword__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getKeyword", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetKeyword__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getKeyword", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetKeyword__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getInt", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetInt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getInt", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetInt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getInt", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetInt__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getInt", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetInt__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getInt", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetInt__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getReal", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetReal__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getReal", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetReal__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getReal", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetReal__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getReal", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetReal__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getReal", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetReal__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetString__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodgetString__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetString__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodgetString__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodgetString__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("putString", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodputString;
		}
		if (SwigDerivedClassHasMethod("getCmColor", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodgetCmColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getCmColor", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodgetCmColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getCmColor", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodgetCmColor__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getCmColor", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodgetCmColor__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getCmColor", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodgetCmColor__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodgetFilePath__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodgetFilePath__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodgetFilePath__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodgetFilePath__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodgetFilePath__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodgetFilePath__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodgetFilePath__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodgetFilePath__SWIG_7;
		}
		if (SwigDerivedClassHasMethod("putError", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodputError;
		}
		if (SwigDerivedClassHasMethod("getLASTPOINT", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodgetLASTPOINT;
		}
		if (SwigDerivedClassHasMethod("setLASTPOINT", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodsetLASTPOINT;
		}
		if (SwigDerivedClassHasMethod("createRubberBand", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodcreateRubberBand__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createRubberBand", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodcreateRubberBand__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createRectFrame", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodcreateRectFrame__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createRectFrame", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodcreateRectFrame__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getPoint", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodgetPoint__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getPoint", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodgetPoint__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getPoint", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodgetPoint__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getPoint", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodgetPoint__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getPoint", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodgetPoint__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getAngle", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodgetAngle__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getAngle", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodgetAngle__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getAngle", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodgetAngle__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getAngle", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodgetAngle__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getAngle", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodgetAngle__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getDist", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodgetDist__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getDist", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodgetDist__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getDist", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodgetDist__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getDist", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodgetDist__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getDist", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodgetDist__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("setPickfirst", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodsetPickfirst;
		}
		if (SwigDerivedClassHasMethod("pickfirst", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodpickfirst;
		}
		if (SwigDerivedClassHasMethod("getColor", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodgetColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getColor", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodgetColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getColor", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodgetColor__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getColor", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodgetColor__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getColor", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodgetColor__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("select", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodselect__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("select", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodselect__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("select", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodselect__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("select", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodselect__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("select", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodselect__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("select", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodselect__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("select", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodselect__SWIG_6;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUserIO_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbUserIO));
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

	private bool SwigDirectorMethodinteractive()
	{
		return interactive();
	}

	private int SwigDirectorMethodgetKeyword__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal, int options, IntPtr pTracker)
	{
		return getKeyword(prompt, keywords, defVal, options, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdIntegerTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodgetKeyword__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal, int options)
	{
		return getKeyword(prompt, keywords, defVal, options);
	}

	private int SwigDirectorMethodgetKeyword__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal)
	{
		return getKeyword(prompt, keywords, defVal);
	}

	private int SwigDirectorMethodgetKeyword__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return getKeyword(prompt, keywords);
	}

	private int SwigDirectorMethodgetInt__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return getInt(prompt, options, defVal, keywords, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdIntegerTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodgetInt__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return getInt(prompt, options, defVal, keywords);
	}

	private int SwigDirectorMethodgetInt__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal)
	{
		return getInt(prompt, options, defVal);
	}

	private int SwigDirectorMethodgetInt__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return getInt(prompt, options);
	}

	private int SwigDirectorMethodgetInt__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return getInt(prompt);
	}

	private double SwigDirectorMethodgetReal__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return getReal(prompt, options, defVal, keywords, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdRealTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodgetReal__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return getReal(prompt, options, defVal, keywords);
	}

	private double SwigDirectorMethodgetReal__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal)
	{
		return getReal(prompt, options, defVal);
	}

	private double SwigDirectorMethodgetReal__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return getReal(prompt, options);
	}

	private double SwigDirectorMethodgetReal__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return getReal(prompt);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return getString(prompt, options, defValue, keywords, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdStringTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return getString(prompt, options, defValue, keywords);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue)
	{
		return getString(prompt, options, defValue);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return getString(prompt, options);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return getString(prompt);
	}

	private void SwigDirectorMethodputString([MarshalAs(UnmanagedType.LPWStr)] string string_)
	{
		try
		{
			putString(string_);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt, options, ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdCmColorBase>(pDefaultValue, bOwn: false, bTryAddToTransaction: false), keywords, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdColorTracker>(pTracker, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt, options, ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdCmColorBase>(pDefaultValue, bOwn: false, bTryAddToTransaction: false), keywords)).Handle;
	}

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt, options, ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdCmColorBase>(pDefaultValue, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt, options)).Handle;
	}

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt)).Handle;
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return getFilePath(prompt, options, dialogCaption, defExt, fileName, filter, keywords, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdStringTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return getFilePath(prompt, options, dialogCaption, defExt, fileName, filter, keywords);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter)
	{
		return getFilePath(prompt, options, dialogCaption, defExt, fileName, filter);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName)
	{
		return getFilePath(prompt, options, dialogCaption, defExt, fileName);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt)
	{
		return getFilePath(prompt, options, dialogCaption, defExt);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_5([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption)
	{
		return getFilePath(prompt, options, dialogCaption);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_6([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return getFilePath(prompt, options);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_7([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return getFilePath(prompt);
	}

	private void SwigDirectorMethodputError([MarshalAs(UnmanagedType.LPWStr)] string errmsg)
	{
		try
		{
			putError(errmsg);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetLASTPOINT()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getLASTPOINT()).Handle;
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

	private void SwigDirectorMethodsetLASTPOINT(IntPtr pt)
	{
		try
		{
			setLASTPOINT(new OdGePoint3d(pt, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodcreateRubberBand__SWIG_0(IntPtr base_, IntPtr pModel)
	{
		return OdEdPointDefTracker.getCPtr(createRubberBand(new OdGePoint3d(base_, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcreateRubberBand__SWIG_1(IntPtr base_)
	{
		return OdEdPointDefTracker.getCPtr(createRubberBand(new OdGePoint3d(base_, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcreateRectFrame__SWIG_0(IntPtr base_, IntPtr pModel)
	{
		return OdEdPointDefTracker.getCPtr(createRectFrame(new OdGePoint3d(base_, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcreateRectFrame__SWIG_1(IntPtr base_)
	{
		return OdEdPointDefTracker.getCPtr(createRectFrame(new OdGePoint3d(base_, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetPoint__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getPoint(prompt, options, (pDefaultValue == IntPtr.Zero) ? null : new OdGePoint3d(pDefaultValue, cMemoryOwn: false), keywords, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdPointTracker>(pTracker, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodgetPoint__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getPoint(prompt, options, (pDefaultValue == IntPtr.Zero) ? null : new OdGePoint3d(pDefaultValue, cMemoryOwn: false), keywords)).Handle;
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

	private IntPtr SwigDirectorMethodgetPoint__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getPoint(prompt, options, (pDefaultValue == IntPtr.Zero) ? null : new OdGePoint3d(pDefaultValue, cMemoryOwn: false))).Handle;
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

	private IntPtr SwigDirectorMethodgetPoint__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getPoint(prompt, options)).Handle;
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

	private IntPtr SwigDirectorMethodgetPoint__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getPoint(prompt)).Handle;
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

	private double SwigDirectorMethodgetAngle__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return getAngle(prompt, options, defaultValue, keywords, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdRealTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodgetAngle__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return getAngle(prompt, options, defaultValue, keywords);
	}

	private double SwigDirectorMethodgetAngle__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue)
	{
		return getAngle(prompt, options, defaultValue);
	}

	private double SwigDirectorMethodgetAngle__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return getAngle(prompt, options);
	}

	private double SwigDirectorMethodgetAngle__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return getAngle(prompt);
	}

	private double SwigDirectorMethodgetDist__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return getDist(prompt, options, defaultValue, keywords, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdRealTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodgetDist__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return getDist(prompt, options, defaultValue, keywords);
	}

	private double SwigDirectorMethodgetDist__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue)
	{
		return getDist(prompt, options, defaultValue);
	}

	private double SwigDirectorMethodgetDist__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return getDist(prompt, options);
	}

	private double SwigDirectorMethodgetDist__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return getDist(prompt);
	}

	private void SwigDirectorMethodsetPickfirst(IntPtr pSSet)
	{
		try
		{
			setPickfirst(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(pSSet, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodpickfirst()
	{
		return OdSelectionSet.getCPtr(pickfirst()).Handle;
	}

	private IntPtr SwigDirectorMethodgetColor__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(getColor(prompt, options, (pDefaultValue == IntPtr.Zero) ? null : new OdCmColor(pDefaultValue, cMemoryOwn: false), keywords, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdColorTracker>(pTracker, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodgetColor__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(getColor(prompt, options, (pDefaultValue == IntPtr.Zero) ? null : new OdCmColor(pDefaultValue, cMemoryOwn: false), keywords)).Handle;
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

	private IntPtr SwigDirectorMethodgetColor__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(getColor(prompt, options, (pDefaultValue == IntPtr.Zero) ? null : new OdCmColor(pDefaultValue, cMemoryOwn: false))).Handle;
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

	private IntPtr SwigDirectorMethodgetColor__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(getColor(prompt, options)).Handle;
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

	private IntPtr SwigDirectorMethodgetColor__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmColor.getCPtr(getColor(prompt)).Handle;
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

	private IntPtr SwigDirectorMethodselect__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker, IntPtr ptsPointer)
	{
		return OdSelectionSet.getCPtr(select(prompt, options, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(pDefaultValue, bOwn: false, bTryAddToTransaction: false), keywords, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSSetTracker>(pTracker, bOwn: false, bTryAddToTransaction: false), new OdGePoint3dArray(ptsPointer, cMemoryOwn: true))).Handle;
	}

	private IntPtr SwigDirectorMethodselect__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return OdSelectionSet.getCPtr(select(prompt, options, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(pDefaultValue, bOwn: false, bTryAddToTransaction: false), keywords, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSSetTracker>(pTracker, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodselect__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return OdSelectionSet.getCPtr(select(prompt, options, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(pDefaultValue, bOwn: false, bTryAddToTransaction: false), keywords)).Handle;
	}

	private IntPtr SwigDirectorMethodselect__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue)
	{
		return OdSelectionSet.getCPtr(select(prompt, options, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(pDefaultValue, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodselect__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return OdSelectionSet.getCPtr(select(prompt, options)).Handle;
	}

	private IntPtr SwigDirectorMethodselect__SWIG_5([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return OdSelectionSet.getCPtr(select(prompt)).Handle;
	}

	private IntPtr SwigDirectorMethodselect__SWIG_6()
	{
		return OdSelectionSet.getCPtr(select()).Handle;
	}
}

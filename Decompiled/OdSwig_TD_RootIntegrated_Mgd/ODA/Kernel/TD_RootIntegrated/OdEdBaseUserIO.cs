using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdEdBaseUserIO : OdEdUserIO
{
	public delegate IntPtr SwigDelegateOdEdBaseUserIO_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_1();

	public delegate void SwigDelegateOdEdBaseUserIO_2(IntPtr pSource);

	public delegate bool SwigDelegateOdEdBaseUserIO_3();

	public delegate int SwigDelegateOdEdBaseUserIO_4([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal, int options, IntPtr pTracker);

	public delegate int SwigDelegateOdEdBaseUserIO_5([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal, int options);

	public delegate int SwigDelegateOdEdBaseUserIO_6([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal);

	public delegate int SwigDelegateOdEdBaseUserIO_7([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate int SwigDelegateOdEdBaseUserIO_8([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate int SwigDelegateOdEdBaseUserIO_9([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate int SwigDelegateOdEdBaseUserIO_10([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal);

	public delegate int SwigDelegateOdEdBaseUserIO_11([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate int SwigDelegateOdEdBaseUserIO_12([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate double SwigDelegateOdEdBaseUserIO_13([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate double SwigDelegateOdEdBaseUserIO_14([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate double SwigDelegateOdEdBaseUserIO_15([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal);

	public delegate double SwigDelegateOdEdBaseUserIO_16([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate double SwigDelegateOdEdBaseUserIO_17([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_18([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_19([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_20([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_21([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_22([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate void SwigDelegateOdEdBaseUserIO_23([MarshalAs(UnmanagedType.LPWStr)] string string_);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_24([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_25([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_26([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_27([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_28([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_29([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_30([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_31([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_32([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_33([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_34([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_35([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseUserIO_36([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate void SwigDelegateOdEdBaseUserIO_37([MarshalAs(UnmanagedType.LPWStr)] string errmsg);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_38();

	public delegate void SwigDelegateOdEdBaseUserIO_39(IntPtr pt);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_40(IntPtr base_, IntPtr pModel);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_41(IntPtr base_);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_42(IntPtr base_, IntPtr pModel);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_43(IntPtr base_);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_44([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_45([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_46([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_47([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate IntPtr SwigDelegateOdEdBaseUserIO_48([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate double SwigDelegateOdEdBaseUserIO_49([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate double SwigDelegateOdEdBaseUserIO_50([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate double SwigDelegateOdEdBaseUserIO_51([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue);

	public delegate double SwigDelegateOdEdBaseUserIO_52([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate double SwigDelegateOdEdBaseUserIO_53([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate double SwigDelegateOdEdBaseUserIO_54([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate double SwigDelegateOdEdBaseUserIO_55([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate double SwigDelegateOdEdBaseUserIO_56([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue);

	public delegate double SwigDelegateOdEdBaseUserIO_57([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate double SwigDelegateOdEdBaseUserIO_58([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdEdBaseUserIO_0 swigDelegate0;

	private SwigDelegateOdEdBaseUserIO_1 swigDelegate1;

	private SwigDelegateOdEdBaseUserIO_2 swigDelegate2;

	private SwigDelegateOdEdBaseUserIO_3 swigDelegate3;

	private SwigDelegateOdEdBaseUserIO_4 swigDelegate4;

	private SwigDelegateOdEdBaseUserIO_5 swigDelegate5;

	private SwigDelegateOdEdBaseUserIO_6 swigDelegate6;

	private SwigDelegateOdEdBaseUserIO_7 swigDelegate7;

	private SwigDelegateOdEdBaseUserIO_8 swigDelegate8;

	private SwigDelegateOdEdBaseUserIO_9 swigDelegate9;

	private SwigDelegateOdEdBaseUserIO_10 swigDelegate10;

	private SwigDelegateOdEdBaseUserIO_11 swigDelegate11;

	private SwigDelegateOdEdBaseUserIO_12 swigDelegate12;

	private SwigDelegateOdEdBaseUserIO_13 swigDelegate13;

	private SwigDelegateOdEdBaseUserIO_14 swigDelegate14;

	private SwigDelegateOdEdBaseUserIO_15 swigDelegate15;

	private SwigDelegateOdEdBaseUserIO_16 swigDelegate16;

	private SwigDelegateOdEdBaseUserIO_17 swigDelegate17;

	private SwigDelegateOdEdBaseUserIO_18 swigDelegate18;

	private SwigDelegateOdEdBaseUserIO_19 swigDelegate19;

	private SwigDelegateOdEdBaseUserIO_20 swigDelegate20;

	private SwigDelegateOdEdBaseUserIO_21 swigDelegate21;

	private SwigDelegateOdEdBaseUserIO_22 swigDelegate22;

	private SwigDelegateOdEdBaseUserIO_23 swigDelegate23;

	private SwigDelegateOdEdBaseUserIO_24 swigDelegate24;

	private SwigDelegateOdEdBaseUserIO_25 swigDelegate25;

	private SwigDelegateOdEdBaseUserIO_26 swigDelegate26;

	private SwigDelegateOdEdBaseUserIO_27 swigDelegate27;

	private SwigDelegateOdEdBaseUserIO_28 swigDelegate28;

	private SwigDelegateOdEdBaseUserIO_29 swigDelegate29;

	private SwigDelegateOdEdBaseUserIO_30 swigDelegate30;

	private SwigDelegateOdEdBaseUserIO_31 swigDelegate31;

	private SwigDelegateOdEdBaseUserIO_32 swigDelegate32;

	private SwigDelegateOdEdBaseUserIO_33 swigDelegate33;

	private SwigDelegateOdEdBaseUserIO_34 swigDelegate34;

	private SwigDelegateOdEdBaseUserIO_35 swigDelegate35;

	private SwigDelegateOdEdBaseUserIO_36 swigDelegate36;

	private SwigDelegateOdEdBaseUserIO_37 swigDelegate37;

	private SwigDelegateOdEdBaseUserIO_38 swigDelegate38;

	private SwigDelegateOdEdBaseUserIO_39 swigDelegate39;

	private SwigDelegateOdEdBaseUserIO_40 swigDelegate40;

	private SwigDelegateOdEdBaseUserIO_41 swigDelegate41;

	private SwigDelegateOdEdBaseUserIO_42 swigDelegate42;

	private SwigDelegateOdEdBaseUserIO_43 swigDelegate43;

	private SwigDelegateOdEdBaseUserIO_44 swigDelegate44;

	private SwigDelegateOdEdBaseUserIO_45 swigDelegate45;

	private SwigDelegateOdEdBaseUserIO_46 swigDelegate46;

	private SwigDelegateOdEdBaseUserIO_47 swigDelegate47;

	private SwigDelegateOdEdBaseUserIO_48 swigDelegate48;

	private SwigDelegateOdEdBaseUserIO_49 swigDelegate49;

	private SwigDelegateOdEdBaseUserIO_50 swigDelegate50;

	private SwigDelegateOdEdBaseUserIO_51 swigDelegate51;

	private SwigDelegateOdEdBaseUserIO_52 swigDelegate52;

	private SwigDelegateOdEdBaseUserIO_53 swigDelegate53;

	private SwigDelegateOdEdBaseUserIO_54 swigDelegate54;

	private SwigDelegateOdEdBaseUserIO_55 swigDelegate55;

	private SwigDelegateOdEdBaseUserIO_56 swigDelegate56;

	private SwigDelegateOdEdBaseUserIO_57 swigDelegate57;

	private SwigDelegateOdEdBaseUserIO_58 swigDelegate58;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdEdBaseUserIO(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdEdBaseUserIO obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdEdBaseUserIO(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdEdBaseUserIO cast(OdRxObject pObj)
	{
		OdEdBaseUserIO rXObject = Helpers.GetRXObject<OdEdBaseUserIO>(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_isASwigExplicitOdEdBaseUserIO(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_queryXSwigExplicitOdEdBaseUserIO(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdEdBaseUserIO createObject()
	{
		OdEdBaseUserIO rXObject = Helpers.GetRXObject<OdEdBaseUserIO>(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGePoint3d getLASTPOINT()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getLASTPOINT(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLASTPOINT(OdGePoint3d pt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_setLASTPOINT(swigCPtr, OdGePoint3d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdEdPointDefTracker createRubberBand(OdGePoint3d base_, OdGsModel pModel)
	{
		OdEdPointDefTracker rXObject = Helpers.GetRXObject<OdEdPointDefTracker>(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_createRubberBand__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(base_), OdGsModel.getCPtr(pModel)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdPointDefTracker createRubberBand(OdGePoint3d base_)
	{
		OdEdPointDefTracker rXObject = Helpers.GetRXObject<OdEdPointDefTracker>(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_createRubberBand__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(base_)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdPointDefTracker createRectFrame(OdGePoint3d base_, OdGsModel pModel)
	{
		OdEdPointDefTracker rXObject = Helpers.GetRXObject<OdEdPointDefTracker>(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_createRectFrame__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(base_), OdGsModel.getCPtr(pModel)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdPointDefTracker createRectFrame(OdGePoint3d base_)
	{
		OdEdPointDefTracker rXObject = Helpers.GetRXObject<OdEdPointDefTracker>(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_createRectFrame__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(base_)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGePoint3d getPoint(string prompt, int options, OdGePoint3d pDefaultValue, string keywords, OdEdPointTracker pTracker)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getPoint__SWIG_0(swigCPtr, prompt, options, OdGePoint3d.getCPtr(pDefaultValue), keywords, OdEdPointTracker.getCPtr(pTracker)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPoint(string prompt, int options, OdGePoint3d pDefaultValue, string keywords)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getPoint__SWIG_1(swigCPtr, prompt, options, OdGePoint3d.getCPtr(pDefaultValue), keywords), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPoint(string prompt, int options, OdGePoint3d pDefaultValue)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getPoint__SWIG_2(swigCPtr, prompt, options, OdGePoint3d.getCPtr(pDefaultValue)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPoint(string prompt, int options)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getPoint__SWIG_3(swigCPtr, prompt, options), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPoint(string prompt)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getPoint__SWIG_4(swigCPtr, prompt), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getAngle(string prompt, int options, double defaultValue, string keywords, OdEdRealTracker pTracker)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getAngle__SWIG_0(swigCPtr, prompt, options, defaultValue, keywords, OdEdRealTracker.getCPtr(pTracker));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getAngle(string prompt, int options, double defaultValue, string keywords)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getAngle__SWIG_1(swigCPtr, prompt, options, defaultValue, keywords);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getAngle(string prompt, int options, double defaultValue)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getAngle__SWIG_2(swigCPtr, prompt, options, defaultValue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getAngle(string prompt, int options)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getAngle__SWIG_3(swigCPtr, prompt, options);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getAngle(string prompt)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getAngle__SWIG_4(swigCPtr, prompt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getDist(string prompt, int options, double defaultValue, string keywords, OdEdRealTracker pTracker)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getDist__SWIG_0(swigCPtr, prompt, options, defaultValue, keywords, OdEdRealTracker.getCPtr(pTracker));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getDist(string prompt, int options, double defaultValue, string keywords)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getDist__SWIG_1(swigCPtr, prompt, options, defaultValue, keywords);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getDist(string prompt, int options, double defaultValue)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getDist__SWIG_2(swigCPtr, prompt, options, defaultValue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getDist(string prompt, int options)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getDist__SWIG_3(swigCPtr, prompt, options);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getDist(string prompt)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getDist__SWIG_4(swigCPtr, prompt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdEdBaseUserIO()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdEdBaseUserIO(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdEdBaseUserIO) != GetType();
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
		TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseUserIO_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdEdBaseUserIO));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodinteractive()
	{
		return interactive();
	}

	private int SwigDirectorMethodgetKeyword__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal, int options, IntPtr pTracker)
	{
		return getKeyword(prompt, keywords, defVal, options, Helpers.GetRXObject<OdEdIntegerTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
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
		return getInt(prompt, options, defVal, keywords, Helpers.GetRXObject<OdEdIntegerTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
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
		return getReal(prompt, options, defVal, keywords, Helpers.GetRXObject<OdEdRealTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
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
		return getString(prompt, options, defValue, keywords, Helpers.GetRXObject<OdEdStringTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
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
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt, options, Helpers.GetObject<OdCmColorBase>(pDefaultValue, bOwn: false, bTryAddToTransaction: false), keywords, Helpers.GetRXObject<OdEdColorTracker>(pTracker, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt, options, Helpers.GetObject<OdCmColorBase>(pDefaultValue, bOwn: false, bTryAddToTransaction: false), keywords)).Handle;
	}

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt, options, Helpers.GetObject<OdCmColorBase>(pDefaultValue, bOwn: false, bTryAddToTransaction: false))).Handle;
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
		return getFilePath(prompt, options, dialogCaption, defExt, fileName, filter, keywords, Helpers.GetRXObject<OdEdStringTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
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
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
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
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
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
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodcreateRubberBand__SWIG_0(IntPtr base_, IntPtr pModel)
	{
		return OdEdPointDefTracker.getCPtr(createRubberBand(new OdGePoint3d(base_, cMemoryOwn: false), Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcreateRubberBand__SWIG_1(IntPtr base_)
	{
		return OdEdPointDefTracker.getCPtr(createRubberBand(new OdGePoint3d(base_, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcreateRectFrame__SWIG_0(IntPtr base_, IntPtr pModel)
	{
		return OdEdPointDefTracker.getCPtr(createRectFrame(new OdGePoint3d(base_, cMemoryOwn: false), Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false))).Handle;
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
				return OdGePoint3d.getCPtr(getPoint(prompt, options, (pDefaultValue == IntPtr.Zero) ? null : new OdGePoint3d(pDefaultValue, cMemoryOwn: false), keywords, Helpers.GetRXObject<OdEdPointTracker>(pTracker, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
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
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
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
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
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
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
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
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private double SwigDirectorMethodgetAngle__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return getAngle(prompt, options, defaultValue, keywords, Helpers.GetRXObject<OdEdRealTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
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
		return getDist(prompt, options, defaultValue, keywords, Helpers.GetRXObject<OdEdRealTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
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
}

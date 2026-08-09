using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDxfFiler : OdDbFiler
{
	public delegate IntPtr SwigDelegateOdDbDxfFiler_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbDxfFiler_1();

	public delegate void SwigDelegateOdDbDxfFiler_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbDxfFiler_3();

	public delegate void SwigDelegateOdDbDxfFiler_4();

	public delegate int SwigDelegateOdDbDxfFiler_5();

	public delegate IntPtr SwigDelegateOdDbDxfFiler_6();

	public delegate int SwigDelegateOdDbDxfFiler_7(MaintReleaseVer pMaintReleaseVer);

	public delegate int SwigDelegateOdDbDxfFiler_8();

	public delegate void SwigDelegateOdDbDxfFiler_9(long offset, int seekType);

	public delegate ulong SwigDelegateOdDbDxfFiler_10();

	public delegate int SwigDelegateOdDbDxfFiler_11();

	public delegate void SwigDelegateOdDbDxfFiler_12(int decimalDigits);

	public delegate void SwigDelegateOdDbDxfFiler_13();

	public delegate bool SwigDelegateOdDbDxfFiler_14();

	public delegate bool SwigDelegateOdDbDxfFiler_15();

	public delegate bool SwigDelegateOdDbDxfFiler_16();

	public delegate bool SwigDelegateOdDbDxfFiler_17();

	public delegate bool SwigDelegateOdDbDxfFiler_18([MarshalAs(UnmanagedType.LPWStr)] string subClassName);

	public delegate bool SwigDelegateOdDbDxfFiler_19();

	public delegate int SwigDelegateOdDbDxfFiler_20();

	public delegate IntPtr SwigDelegateOdDbDxfFiler_21();

	public delegate void SwigDelegateOdDbDxfFiler_22(IntPtr pRb);

	public delegate void SwigDelegateOdDbDxfFiler_23();

	public delegate void SwigDelegateOdDbDxfFiler_24(IntPtr value);

	public delegate bool SwigDelegateOdDbDxfFiler_25();

	public delegate sbyte SwigDelegateOdDbDxfFiler_26();

	public delegate short SwigDelegateOdDbDxfFiler_27();

	public delegate int SwigDelegateOdDbDxfFiler_28();

	public delegate long SwigDelegateOdDbDxfFiler_29();

	public delegate byte SwigDelegateOdDbDxfFiler_30();

	public delegate ushort SwigDelegateOdDbDxfFiler_31();

	public delegate uint SwigDelegateOdDbDxfFiler_32();

	public delegate ulong SwigDelegateOdDbDxfFiler_33();

	public delegate IntPtr SwigDelegateOdDbDxfFiler_34();

	public delegate IntPtr SwigDelegateOdDbDxfFiler_35();

	public delegate double SwigDelegateOdDbDxfFiler_36();

	public delegate double SwigDelegateOdDbDxfFiler_37();

	public delegate void SwigDelegateOdDbDxfFiler_38(IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_39(IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_40(IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_41(IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_42(IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_43(IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_44(IntPtr pSource);

	public delegate void SwigDelegateOdDbDxfFiler_45(int groupCode, [MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate void SwigDelegateOdDbDxfFiler_46(int groupCode, [MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate void SwigDelegateOdDbDxfFiler_47(int groupCode, bool value);

	public delegate void SwigDelegateOdDbDxfFiler_48(int groupCode, sbyte value);

	public delegate void SwigDelegateOdDbDxfFiler_49(int groupCode, byte value);

	public delegate void SwigDelegateOdDbDxfFiler_50(int groupCode, short value);

	public delegate void SwigDelegateOdDbDxfFiler_51(int groupCode, ushort value);

	public delegate void SwigDelegateOdDbDxfFiler_52(int groupCode, int value);

	public delegate void SwigDelegateOdDbDxfFiler_53(int groupCode, uint value);

	public delegate void SwigDelegateOdDbDxfFiler_54(int groupCode, long value);

	public delegate void SwigDelegateOdDbDxfFiler_55(int groupCode, ulong value);

	public delegate void SwigDelegateOdDbDxfFiler_56(int groupCode, IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_57(int groupCode, IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_58(int groupCode, double value, int precision);

	public delegate void SwigDelegateOdDbDxfFiler_59(int groupCode, double value);

	public delegate void SwigDelegateOdDbDxfFiler_60(int groupCode, double value, int precision);

	public delegate void SwigDelegateOdDbDxfFiler_61(int groupCode, double value);

	public delegate void SwigDelegateOdDbDxfFiler_62(int groupCode, IntPtr value, int precision);

	public delegate void SwigDelegateOdDbDxfFiler_63(int groupCode, IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_64(int groupCode, IntPtr value, int precision);

	public delegate void SwigDelegateOdDbDxfFiler_65(int groupCode, IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_66(int groupCode, IntPtr value, int precision);

	public delegate void SwigDelegateOdDbDxfFiler_67(int groupCode, IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_68(int groupCode, IntPtr value, int precision);

	public delegate void SwigDelegateOdDbDxfFiler_69(int groupCode, IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_70(int groupCode, IntPtr value, int precision);

	public delegate void SwigDelegateOdDbDxfFiler_71(int groupCode, IntPtr value);

	public delegate void SwigDelegateOdDbDxfFiler_72(int groupCode, IntPtr buffer);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbDxfFiler_0 swigDelegate0;

	private SwigDelegateOdDbDxfFiler_1 swigDelegate1;

	private SwigDelegateOdDbDxfFiler_2 swigDelegate2;

	private SwigDelegateOdDbDxfFiler_3 swigDelegate3;

	private SwigDelegateOdDbDxfFiler_4 swigDelegate4;

	private SwigDelegateOdDbDxfFiler_5 swigDelegate5;

	private SwigDelegateOdDbDxfFiler_6 swigDelegate6;

	private SwigDelegateOdDbDxfFiler_7 swigDelegate7;

	private SwigDelegateOdDbDxfFiler_8 swigDelegate8;

	private SwigDelegateOdDbDxfFiler_9 swigDelegate9;

	private SwigDelegateOdDbDxfFiler_10 swigDelegate10;

	private SwigDelegateOdDbDxfFiler_11 swigDelegate11;

	private SwigDelegateOdDbDxfFiler_12 swigDelegate12;

	private SwigDelegateOdDbDxfFiler_13 swigDelegate13;

	private SwigDelegateOdDbDxfFiler_14 swigDelegate14;

	private SwigDelegateOdDbDxfFiler_15 swigDelegate15;

	private SwigDelegateOdDbDxfFiler_16 swigDelegate16;

	private SwigDelegateOdDbDxfFiler_17 swigDelegate17;

	private SwigDelegateOdDbDxfFiler_18 swigDelegate18;

	private SwigDelegateOdDbDxfFiler_19 swigDelegate19;

	private SwigDelegateOdDbDxfFiler_20 swigDelegate20;

	private SwigDelegateOdDbDxfFiler_21 swigDelegate21;

	private SwigDelegateOdDbDxfFiler_22 swigDelegate22;

	private SwigDelegateOdDbDxfFiler_23 swigDelegate23;

	private SwigDelegateOdDbDxfFiler_24 swigDelegate24;

	private SwigDelegateOdDbDxfFiler_25 swigDelegate25;

	private SwigDelegateOdDbDxfFiler_26 swigDelegate26;

	private SwigDelegateOdDbDxfFiler_27 swigDelegate27;

	private SwigDelegateOdDbDxfFiler_28 swigDelegate28;

	private SwigDelegateOdDbDxfFiler_29 swigDelegate29;

	private SwigDelegateOdDbDxfFiler_30 swigDelegate30;

	private SwigDelegateOdDbDxfFiler_31 swigDelegate31;

	private SwigDelegateOdDbDxfFiler_32 swigDelegate32;

	private SwigDelegateOdDbDxfFiler_33 swigDelegate33;

	private SwigDelegateOdDbDxfFiler_34 swigDelegate34;

	private SwigDelegateOdDbDxfFiler_35 swigDelegate35;

	private SwigDelegateOdDbDxfFiler_36 swigDelegate36;

	private SwigDelegateOdDbDxfFiler_37 swigDelegate37;

	private SwigDelegateOdDbDxfFiler_38 swigDelegate38;

	private SwigDelegateOdDbDxfFiler_39 swigDelegate39;

	private SwigDelegateOdDbDxfFiler_40 swigDelegate40;

	private SwigDelegateOdDbDxfFiler_41 swigDelegate41;

	private SwigDelegateOdDbDxfFiler_42 swigDelegate42;

	private SwigDelegateOdDbDxfFiler_43 swigDelegate43;

	private SwigDelegateOdDbDxfFiler_44 swigDelegate44;

	private SwigDelegateOdDbDxfFiler_45 swigDelegate45;

	private SwigDelegateOdDbDxfFiler_46 swigDelegate46;

	private SwigDelegateOdDbDxfFiler_47 swigDelegate47;

	private SwigDelegateOdDbDxfFiler_48 swigDelegate48;

	private SwigDelegateOdDbDxfFiler_49 swigDelegate49;

	private SwigDelegateOdDbDxfFiler_50 swigDelegate50;

	private SwigDelegateOdDbDxfFiler_51 swigDelegate51;

	private SwigDelegateOdDbDxfFiler_52 swigDelegate52;

	private SwigDelegateOdDbDxfFiler_53 swigDelegate53;

	private SwigDelegateOdDbDxfFiler_54 swigDelegate54;

	private SwigDelegateOdDbDxfFiler_55 swigDelegate55;

	private SwigDelegateOdDbDxfFiler_56 swigDelegate56;

	private SwigDelegateOdDbDxfFiler_57 swigDelegate57;

	private SwigDelegateOdDbDxfFiler_58 swigDelegate58;

	private SwigDelegateOdDbDxfFiler_59 swigDelegate59;

	private SwigDelegateOdDbDxfFiler_60 swigDelegate60;

	private SwigDelegateOdDbDxfFiler_61 swigDelegate61;

	private SwigDelegateOdDbDxfFiler_62 swigDelegate62;

	private SwigDelegateOdDbDxfFiler_63 swigDelegate63;

	private SwigDelegateOdDbDxfFiler_64 swigDelegate64;

	private SwigDelegateOdDbDxfFiler_65 swigDelegate65;

	private SwigDelegateOdDbDxfFiler_66 swigDelegate66;

	private SwigDelegateOdDbDxfFiler_67 swigDelegate67;

	private SwigDelegateOdDbDxfFiler_68 swigDelegate68;

	private SwigDelegateOdDbDxfFiler_69 swigDelegate69;

	private SwigDelegateOdDbDxfFiler_70 swigDelegate70;

	private SwigDelegateOdDbDxfFiler_71 swigDelegate71;

	private SwigDelegateOdDbDxfFiler_72 swigDelegate72;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(MaintReleaseVer).MakeByRefType() };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(long),
		typeof(OdDb_FilerSeekType)
	};

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdResBuf) };

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes25 = new Type[0];

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[0];

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[0];

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[0];

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[0];

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(OdGePoint2d) };

	private static Type[] swigMethodTypes39 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(OdGeVector2d) };

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(OdGeScale3d) };

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(OdBinaryData) };

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes45 = new Type[2]
	{
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes46 = new Type[2]
	{
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes47 = new Type[2]
	{
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes48 = new Type[2]
	{
		typeof(int),
		typeof(sbyte)
	};

	private static Type[] swigMethodTypes49 = new Type[2]
	{
		typeof(int),
		typeof(byte)
	};

	private static Type[] swigMethodTypes50 = new Type[2]
	{
		typeof(int),
		typeof(short)
	};

	private static Type[] swigMethodTypes51 = new Type[2]
	{
		typeof(int),
		typeof(ushort)
	};

	private static Type[] swigMethodTypes52 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes53 = new Type[2]
	{
		typeof(int),
		typeof(uint)
	};

	private static Type[] swigMethodTypes54 = new Type[2]
	{
		typeof(int),
		typeof(long)
	};

	private static Type[] swigMethodTypes55 = new Type[2]
	{
		typeof(int),
		typeof(ulong)
	};

	private static Type[] swigMethodTypes56 = new Type[2]
	{
		typeof(int),
		typeof(OdDbHandle)
	};

	private static Type[] swigMethodTypes57 = new Type[2]
	{
		typeof(int),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes58 = new Type[3]
	{
		typeof(int),
		typeof(double),
		typeof(int)
	};

	private static Type[] swigMethodTypes59 = new Type[2]
	{
		typeof(int),
		typeof(double)
	};

	private static Type[] swigMethodTypes60 = new Type[3]
	{
		typeof(int),
		typeof(double),
		typeof(int)
	};

	private static Type[] swigMethodTypes61 = new Type[2]
	{
		typeof(int),
		typeof(double)
	};

	private static Type[] swigMethodTypes62 = new Type[3]
	{
		typeof(int),
		typeof(OdGePoint2d),
		typeof(int)
	};

	private static Type[] swigMethodTypes63 = new Type[2]
	{
		typeof(int),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes64 = new Type[3]
	{
		typeof(int),
		typeof(OdGePoint3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes65 = new Type[2]
	{
		typeof(int),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes66 = new Type[3]
	{
		typeof(int),
		typeof(OdGeVector2d),
		typeof(int)
	};

	private static Type[] swigMethodTypes67 = new Type[2]
	{
		typeof(int),
		typeof(OdGeVector2d)
	};

	private static Type[] swigMethodTypes68 = new Type[3]
	{
		typeof(int),
		typeof(OdGeVector3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes69 = new Type[2]
	{
		typeof(int),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes70 = new Type[3]
	{
		typeof(int),
		typeof(OdGeScale3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes71 = new Type[2]
	{
		typeof(int),
		typeof(OdGeScale3d)
	};

	private static Type[] swigMethodTypes72 = new Type[2]
	{
		typeof(int),
		typeof(byte[])
	};

	public const int kDfltPrec = -1;

	public const int kMaxPrec = 16;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDxfFiler(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDxfFiler obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDxfFiler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbDxfFiler()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDxfFiler(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbDxfFiler cast(OdRxObject pObj)
	{
		OdDbDxfFiler rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_isASwigExplicitOdDbDxfFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_queryXSwigExplicitOdDbDxfFiler(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbDxfFiler createObject()
	{
		OdDbDxfFiler rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void seek(long offset, OdDb_FilerSeekType seekType)
	{
		if (SwigDerivedClassHasMethod("seek", swigMethodTypes9))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_seekSwigExplicitOdDbDxfFiler(swigCPtr, offset, (int)seekType);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_seek(swigCPtr, offset, (int)seekType);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ulong tell()
	{
		ulong result = (SwigDerivedClassHasMethod("tell", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_tellSwigExplicitOdDbDxfFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_tell(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int precision()
	{
		int result = (SwigDerivedClassHasMethod("precision", swigMethodTypes11) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_precisionSwigExplicitOdDbDxfFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_precision(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPrecision(int decimalDigits)
	{
		if (SwigDerivedClassHasMethod("setPrecision", swigMethodTypes12))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_setPrecisionSwigExplicitOdDbDxfFiler(swigCPtr, decimalDigits);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_setPrecision(swigCPtr, decimalDigits);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeXDataStart()
	{
		if (SwigDerivedClassHasMethod("writeXDataStart", swigMethodTypes13))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_writeXDataStartSwigExplicitOdDbDxfFiler(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_writeXDataStart(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool includesDefaultValues()
	{
		bool result = (SwigDerivedClassHasMethod("includesDefaultValues", swigMethodTypes14) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_includesDefaultValuesSwigExplicitOdDbDxfFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_includesDefaultValues(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool atEOF()
	{
		bool result = (SwigDerivedClassHasMethod("atEOF", swigMethodTypes15) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_atEOFSwigExplicitOdDbDxfFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_atEOF(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool atEndOfObject()
	{
		bool result = (SwigDerivedClassHasMethod("atEndOfObject", swigMethodTypes16) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_atEndOfObjectSwigExplicitOdDbDxfFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_atEndOfObject(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool atExtendedData()
	{
		bool result = (SwigDerivedClassHasMethod("atExtendedData", swigMethodTypes17) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_atExtendedDataSwigExplicitOdDbDxfFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_atExtendedData(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool atSubclassData(string subClassName)
	{
		bool result = (SwigDerivedClassHasMethod("atSubclassData", swigMethodTypes18) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_atSubclassDataSwigExplicitOdDbDxfFiler(swigCPtr, subClassName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_atSubclassData(swigCPtr, subClassName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool atEmbeddedObjectStart()
	{
		bool result = (SwigDerivedClassHasMethod("atEmbeddedObjectStart", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_atEmbeddedObjectStartSwigExplicitOdDbDxfFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_atEmbeddedObjectStart(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int nextItem()
	{
		int result = (SwigDerivedClassHasMethod("nextItem", swigMethodTypes20) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_nextItemSwigExplicitOdDbDxfFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_nextItem(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResBuf nextRb()
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(SwigDerivedClassHasMethod("nextRb", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_nextRbSwigExplicitOdDbDxfFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_nextRb(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void writeRb(OdResBuf pRb)
	{
		if (SwigDerivedClassHasMethod("writeRb", swigMethodTypes22))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_writeRbSwigExplicitOdDbDxfFiler(swigCPtr, OdResBuf.getCPtr(pRb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_writeRb(swigCPtr, OdResBuf.getCPtr(pRb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushBackItem()
	{
		if (SwigDerivedClassHasMethod("pushBackItem", swigMethodTypes23))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_pushBackItemSwigExplicitOdDbDxfFiler(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_pushBackItem(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string rdString()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdString__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void rdString(ref string value)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(value);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdString__SWIG_1(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				value = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool rdBool()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdBool(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual sbyte rdInt8()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdInt8(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short rdInt16()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdInt16(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int rdInt32()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdInt32(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual long rdInt64()
	{
		long result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdInt64(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual byte rdUInt8()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdUInt8(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ushort rdUInt16()
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdUInt16(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint rdUInt32()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdUInt32(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ulong rdUInt64()
	{
		ulong result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdUInt64(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbHandle rdHandle()
	{
		OdDbHandle result = new OdDbHandle(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdHandle(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId rdObjectId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdObjectId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double rdAngle()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdAngle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double rdDouble()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdDouble(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void rdPoint2d(OdGePoint2d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdPoint2d(swigCPtr, OdGePoint2d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdPoint3d(OdGePoint3d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdPoint3d(swigCPtr, OdGePoint3d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdVector2d(OdGeVector2d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdVector2d(swigCPtr, OdGeVector2d.getCPtr(value).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdVector3d(OdGeVector3d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdVector3d(swigCPtr, OdGeVector3d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdScale3d(OdGeScale3d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdScale3d(swigCPtr, OdGeScale3d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdBinaryChunk(OdBinaryData value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_rdBinaryChunk(swigCPtr, OdBinaryData.getCPtr(value).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void copyItem(OdDbDxfFiler pSource)
	{
		if (SwigDerivedClassHasMethod("copyItem", swigMethodTypes44))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_copyItemSwigExplicitOdDbDxfFiler(swigCPtr, getCPtr(pSource));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_copyItem(swigCPtr, getCPtr(pSource));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrName(int groupCode, string value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrName(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrString(int groupCode, string value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrString(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrStringOpt(int groupCode, string value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrStringOpt(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrSubclassMarker(string value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrSubclassMarker(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrEmbeddedObjectStart()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrEmbeddedObjectStart(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrBool(int groupCode, bool value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrBool(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrBoolOpt(int groupCode, bool value, bool defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrBoolOpt(swigCPtr, groupCode, value, defaultValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrInt8(int groupCode, sbyte value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrInt8(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrInt8Opt(int groupCode, sbyte value, sbyte defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrInt8Opt(swigCPtr, groupCode, value, defaultValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrUInt8(int groupCode, byte value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrUInt8(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrUInt8Opt(int groupCode, byte value, byte defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrUInt8Opt(swigCPtr, groupCode, value, defaultValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrInt16(int groupCode, short value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrInt16(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrInt16Opt(int groupCode, short value, short defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrInt16Opt(swigCPtr, groupCode, value, defaultValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrUInt16(int groupCode, ushort value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrUInt16(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrUInt16Opt(int groupCode, ushort value, ushort defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrUInt16Opt(swigCPtr, groupCode, value, defaultValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrInt32(int groupCode, int value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrInt32(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrInt32Opt(int groupCode, int value, int defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrInt32Opt(swigCPtr, groupCode, value, defaultValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrUInt32(int groupCode, uint value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrUInt32(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrUInt32Opt(int groupCode, uint value, uint defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrUInt32Opt(swigCPtr, groupCode, value, defaultValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrInt64(int groupCode, long value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrInt64(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrInt64Opt(int groupCode, long value, long defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrInt64Opt(swigCPtr, groupCode, value, defaultValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrUInt64(int groupCode, ulong value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrUInt64(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrUInt64Opt(int groupCode, ulong value, ulong defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrUInt64Opt(swigCPtr, groupCode, value, defaultValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrHandle(int groupCode, OdDbHandle value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrHandle(swigCPtr, groupCode, OdDbHandle.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrObjectId(int groupCode, OdDbObjectId value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrObjectId(swigCPtr, groupCode, OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrObjectIdOpt(int groupCode, OdDbObjectId value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrObjectIdOpt(swigCPtr, groupCode, OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrAngle(int groupCode, double value, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrAngle__SWIG_0(swigCPtr, groupCode, value, precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrAngle(int groupCode, double value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrAngle__SWIG_1(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrAngleOpt(int groupCode, double value, double defaultValue, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrAngleOpt__SWIG_0(swigCPtr, groupCode, value, defaultValue, precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrAngleOpt(int groupCode, double value, double defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrAngleOpt__SWIG_1(swigCPtr, groupCode, value, defaultValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrAngleOpt(int groupCode, double value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrAngleOpt__SWIG_2(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrDouble(int groupCode, double value, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrDouble__SWIG_0(swigCPtr, groupCode, value, precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrDouble(int groupCode, double value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrDouble__SWIG_1(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrDoubleOpt(int groupCode, double value, double defaultValue, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrDoubleOpt__SWIG_0(swigCPtr, groupCode, value, defaultValue, precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrDoubleOpt(int groupCode, double value, double defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrDoubleOpt__SWIG_1(swigCPtr, groupCode, value, defaultValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrDoubleOpt(int groupCode, double value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrDoubleOpt__SWIG_2(swigCPtr, groupCode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrPoint2d(int groupCode, OdGePoint2d value, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrPoint2d__SWIG_0(swigCPtr, groupCode, OdGePoint2d.getCPtr(value), precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrPoint2d(int groupCode, OdGePoint2d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrPoint2d__SWIG_1(swigCPtr, groupCode, OdGePoint2d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrPoint2dOpt(int groupCode, OdGePoint2d value, OdGePoint2d defaultValue, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrPoint2dOpt__SWIG_0(swigCPtr, groupCode, OdGePoint2d.getCPtr(value), OdGePoint2d.getCPtr(defaultValue), precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrPoint2dOpt(int groupCode, OdGePoint2d value, OdGePoint2d defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrPoint2dOpt__SWIG_1(swigCPtr, groupCode, OdGePoint2d.getCPtr(value), OdGePoint2d.getCPtr(defaultValue));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrPoint3d(int groupCode, OdGePoint3d value, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrPoint3d__SWIG_0(swigCPtr, groupCode, OdGePoint3d.getCPtr(value), precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrPoint3d(int groupCode, OdGePoint3d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrPoint3d__SWIG_1(swigCPtr, groupCode, OdGePoint3d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrPoint3dOpt(int groupCode, OdGePoint3d value, OdGePoint3d defaultValue, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrPoint3dOpt__SWIG_0(swigCPtr, groupCode, OdGePoint3d.getCPtr(value), OdGePoint3d.getCPtr(defaultValue), precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrPoint3dOpt(int groupCode, OdGePoint3d value, OdGePoint3d defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrPoint3dOpt__SWIG_1(swigCPtr, groupCode, OdGePoint3d.getCPtr(value), OdGePoint3d.getCPtr(defaultValue));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrVector2d(int groupCode, OdGeVector2d value, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrVector2d__SWIG_0(swigCPtr, groupCode, OdGeVector2d.getCPtr(value).Handle, precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrVector2d(int groupCode, OdGeVector2d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrVector2d__SWIG_1(swigCPtr, groupCode, OdGeVector2d.getCPtr(value).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrVector2dOpt(int groupCode, OdGeVector2d value, OdGeVector2d defaultValue, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrVector2dOpt__SWIG_0(swigCPtr, groupCode, OdGeVector2d.getCPtr(value).Handle, OdGeVector2d.getCPtr(defaultValue).Handle, precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrVector2dOpt(int groupCode, OdGeVector2d value, OdGeVector2d defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrVector2dOpt__SWIG_1(swigCPtr, groupCode, OdGeVector2d.getCPtr(value).Handle, OdGeVector2d.getCPtr(defaultValue).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrVector3d(int groupCode, OdGeVector3d value, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrVector3d__SWIG_0(swigCPtr, groupCode, OdGeVector3d.getCPtr(value), precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrVector3d(int groupCode, OdGeVector3d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrVector3d__SWIG_1(swigCPtr, groupCode, OdGeVector3d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrVector3dOpt(int groupCode, OdGeVector3d value, OdGeVector3d defaultValue, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrVector3dOpt__SWIG_0(swigCPtr, groupCode, OdGeVector3d.getCPtr(value), OdGeVector3d.getCPtr(defaultValue), precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrVector3dOpt(int groupCode, OdGeVector3d value, OdGeVector3d defaultValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrVector3dOpt__SWIG_1(swigCPtr, groupCode, OdGeVector3d.getCPtr(value), OdGeVector3d.getCPtr(defaultValue));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrScale3d(int groupCode, OdGeScale3d value, int precision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrScale3d__SWIG_0(swigCPtr, groupCode, OdGeScale3d.getCPtr(value), precision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrScale3d(int groupCode, OdGeScale3d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrScale3d__SWIG_1(swigCPtr, groupCode, OdGeScale3d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrBinaryChunk(int groupCode, byte[] buffer)
	{
		IntPtr intPtr = ODA.Kernel.TD_RootIntegrated.Helpers.MarshalbyteFixedArray(buffer);
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrBinaryChunk__SWIG_0(swigCPtr, groupCode, intPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public void wrBinaryChunk(int groupCode, OdBinaryData value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_wrBinaryChunk__SWIG_1(swigCPtr, groupCode, OdBinaryData.getCPtr(value).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("filerStatus", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodfilerStatus;
		}
		if (SwigDerivedClassHasMethod("resetFilerStatus", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodresetFilerStatus;
		}
		if (SwigDerivedClassHasMethod("filerType", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodfilerType;
		}
		if (SwigDerivedClassHasMethod("database", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoddatabase;
		}
		if (SwigDerivedClassHasMethod("dwgVersion", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddwgVersion__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("dwgVersion", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddwgVersion__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("seek", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodseek;
		}
		if (SwigDerivedClassHasMethod("tell", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodtell;
		}
		if (SwigDerivedClassHasMethod("precision", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodprecision;
		}
		if (SwigDerivedClassHasMethod("setPrecision", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetPrecision;
		}
		if (SwigDerivedClassHasMethod("writeXDataStart", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodwriteXDataStart;
		}
		if (SwigDerivedClassHasMethod("includesDefaultValues", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodincludesDefaultValues;
		}
		if (SwigDerivedClassHasMethod("atEOF", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodatEOF;
		}
		if (SwigDerivedClassHasMethod("atEndOfObject", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodatEndOfObject;
		}
		if (SwigDerivedClassHasMethod("atExtendedData", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodatExtendedData;
		}
		if (SwigDerivedClassHasMethod("atSubclassData", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodatSubclassData;
		}
		if (SwigDerivedClassHasMethod("atEmbeddedObjectStart", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodatEmbeddedObjectStart;
		}
		if (SwigDerivedClassHasMethod("nextItem", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodnextItem;
		}
		if (SwigDerivedClassHasMethod("nextRb", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodnextRb;
		}
		if (SwigDerivedClassHasMethod("writeRb", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodwriteRb;
		}
		if (SwigDerivedClassHasMethod("pushBackItem", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodpushBackItem;
		}
		if (SwigDerivedClassHasMethod("rdString", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodrdString__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("rdBool", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodrdBool;
		}
		if (SwigDerivedClassHasMethod("rdInt8", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodrdInt8;
		}
		if (SwigDerivedClassHasMethod("rdInt16", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodrdInt16;
		}
		if (SwigDerivedClassHasMethod("rdInt32", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodrdInt32;
		}
		if (SwigDerivedClassHasMethod("rdInt64", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodrdInt64;
		}
		if (SwigDerivedClassHasMethod("rdUInt8", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodrdUInt8;
		}
		if (SwigDerivedClassHasMethod("rdUInt16", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodrdUInt16;
		}
		if (SwigDerivedClassHasMethod("rdUInt32", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodrdUInt32;
		}
		if (SwigDerivedClassHasMethod("rdUInt64", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodrdUInt64;
		}
		if (SwigDerivedClassHasMethod("rdHandle", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodrdHandle;
		}
		if (SwigDerivedClassHasMethod("rdObjectId", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodrdObjectId;
		}
		if (SwigDerivedClassHasMethod("rdAngle", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodrdAngle;
		}
		if (SwigDerivedClassHasMethod("rdDouble", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodrdDouble;
		}
		if (SwigDerivedClassHasMethod("rdPoint2d", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodrdPoint2d;
		}
		if (SwigDerivedClassHasMethod("rdPoint3d", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodrdPoint3d;
		}
		if (SwigDerivedClassHasMethod("rdVector2d", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodrdVector2d;
		}
		if (SwigDerivedClassHasMethod("rdVector3d", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodrdVector3d;
		}
		if (SwigDerivedClassHasMethod("rdScale3d", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodrdScale3d;
		}
		if (SwigDerivedClassHasMethod("rdBinaryChunk", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodrdBinaryChunk;
		}
		if (SwigDerivedClassHasMethod("copyItem", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodcopyItem;
		}
		if (SwigDerivedClassHasMethod("wrName", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodwrName;
		}
		if (SwigDerivedClassHasMethod("wrString", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodwrString;
		}
		if (SwigDerivedClassHasMethod("wrBool", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodwrBool;
		}
		if (SwigDerivedClassHasMethod("wrInt8", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodwrInt8;
		}
		if (SwigDerivedClassHasMethod("wrUInt8", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodwrUInt8;
		}
		if (SwigDerivedClassHasMethod("wrInt16", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodwrInt16;
		}
		if (SwigDerivedClassHasMethod("wrUInt16", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodwrUInt16;
		}
		if (SwigDerivedClassHasMethod("wrInt32", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodwrInt32;
		}
		if (SwigDerivedClassHasMethod("wrUInt32", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodwrUInt32;
		}
		if (SwigDerivedClassHasMethod("wrInt64", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodwrInt64;
		}
		if (SwigDerivedClassHasMethod("wrUInt64", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodwrUInt64;
		}
		if (SwigDerivedClassHasMethod("wrHandle", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodwrHandle;
		}
		if (SwigDerivedClassHasMethod("wrObjectId", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodwrObjectId;
		}
		if (SwigDerivedClassHasMethod("wrAngle", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodwrAngle__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("wrAngle", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodwrAngle__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("wrDouble", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodwrDouble__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("wrDouble", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodwrDouble__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("wrPoint2d", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodwrPoint2d__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("wrPoint2d", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodwrPoint2d__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("wrPoint3d", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodwrPoint3d__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("wrPoint3d", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodwrPoint3d__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("wrVector2d", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodwrVector2d__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("wrVector2d", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodwrVector2d__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("wrVector3d", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodwrVector3d__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("wrVector3d", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodwrVector3d__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("wrScale3d", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodwrScale3d__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("wrScale3d", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodwrScale3d__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("wrBinaryChunk", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodwrBinaryChunk__SWIG_0;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDxfFiler_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbDxfFiler));
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

	private int SwigDirectorMethodfilerStatus()
	{
		return (int)filerStatus();
	}

	private void SwigDirectorMethodresetFilerStatus()
	{
		try
		{
			resetFilerStatus();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private int SwigDirectorMethodfilerType()
	{
		return (int)filerType();
	}

	private IntPtr SwigDirectorMethoddatabase()
	{
		return OdDbDatabase.getCPtr(database()).Handle;
	}

	private int SwigDirectorMethoddwgVersion__SWIG_0(MaintReleaseVer pMaintReleaseVer)
	{
		return (int)dwgVersion(out pMaintReleaseVer);
	}

	private int SwigDirectorMethoddwgVersion__SWIG_1()
	{
		return (int)dwgVersion();
	}

	private void SwigDirectorMethodseek(long offset, int seekType)
	{
		try
		{
			seek(offset, (OdDb_FilerSeekType)seekType);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private ulong SwigDirectorMethodtell()
	{
		return tell();
	}

	private int SwigDirectorMethodprecision()
	{
		return precision();
	}

	private void SwigDirectorMethodsetPrecision(int decimalDigits)
	{
		try
		{
			setPrecision(decimalDigits);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwriteXDataStart()
	{
		try
		{
			writeXDataStart();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private bool SwigDirectorMethodincludesDefaultValues()
	{
		return includesDefaultValues();
	}

	private bool SwigDirectorMethodatEOF()
	{
		return atEOF();
	}

	private bool SwigDirectorMethodatEndOfObject()
	{
		return atEndOfObject();
	}

	private bool SwigDirectorMethodatExtendedData()
	{
		return atExtendedData();
	}

	private bool SwigDirectorMethodatSubclassData([MarshalAs(UnmanagedType.LPWStr)] string subClassName)
	{
		return atSubclassData(subClassName);
	}

	private bool SwigDirectorMethodatEmbeddedObjectStart()
	{
		return atEmbeddedObjectStart();
	}

	private int SwigDirectorMethodnextItem()
	{
		return nextItem();
	}

	private IntPtr SwigDirectorMethodnextRb()
	{
		return OdResBuf.getCPtr(nextRb()).Handle;
	}

	private void SwigDirectorMethodwriteRb(IntPtr pRb)
	{
		try
		{
			writeRb(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(pRb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodpushBackItem()
	{
		try
		{
			pushBackItem();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodrdString__SWIG_1(IntPtr value)
	{
		OdSwigDirectorHelper.director_UnpackData(value, out var pOriginalObject, out var pFunction);
		string value2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = value2;
		try
		{
			rdString(ref value2);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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
			if (value2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(value2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(value);
		}
	}

	private bool SwigDirectorMethodrdBool()
	{
		return rdBool();
	}

	private sbyte SwigDirectorMethodrdInt8()
	{
		return rdInt8();
	}

	private short SwigDirectorMethodrdInt16()
	{
		return rdInt16();
	}

	private int SwigDirectorMethodrdInt32()
	{
		return rdInt32();
	}

	private long SwigDirectorMethodrdInt64()
	{
		return rdInt64();
	}

	private byte SwigDirectorMethodrdUInt8()
	{
		return rdUInt8();
	}

	private ushort SwigDirectorMethodrdUInt16()
	{
		return rdUInt16();
	}

	private uint SwigDirectorMethodrdUInt32()
	{
		return rdUInt32();
	}

	private ulong SwigDirectorMethodrdUInt64()
	{
		return rdUInt64();
	}

	private IntPtr SwigDirectorMethodrdHandle()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbHandle.getCPtr(rdHandle()).Handle;
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

	private IntPtr SwigDirectorMethodrdObjectId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(rdObjectId()).Handle;
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

	private double SwigDirectorMethodrdAngle()
	{
		return rdAngle();
	}

	private double SwigDirectorMethodrdDouble()
	{
		return rdDouble();
	}

	private void SwigDirectorMethodrdPoint2d(IntPtr value)
	{
		try
		{
			rdPoint2d(new OdGePoint2d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodrdPoint3d(IntPtr value)
	{
		try
		{
			rdPoint3d(new OdGePoint3d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodrdVector2d(IntPtr value)
	{
		try
		{
			rdVector2d(new OdGeVector2d(value, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodrdVector3d(IntPtr value)
	{
		try
		{
			rdVector3d(new OdGeVector3d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodrdScale3d(IntPtr value)
	{
		try
		{
			rdScale3d(new OdGeScale3d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodrdBinaryChunk(IntPtr value)
	{
		try
		{
			rdBinaryChunk(new OdBinaryData(value, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodcopyItem(IntPtr pSource)
	{
		try
		{
			copyItem(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrName(int groupCode, [MarshalAs(UnmanagedType.LPWStr)] string value)
	{
		try
		{
			wrName(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrString(int groupCode, [MarshalAs(UnmanagedType.LPWStr)] string value)
	{
		try
		{
			wrString(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrBool(int groupCode, bool value)
	{
		try
		{
			wrBool(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrInt8(int groupCode, sbyte value)
	{
		try
		{
			wrInt8(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrUInt8(int groupCode, byte value)
	{
		try
		{
			wrUInt8(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrInt16(int groupCode, short value)
	{
		try
		{
			wrInt16(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrUInt16(int groupCode, ushort value)
	{
		try
		{
			wrUInt16(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrInt32(int groupCode, int value)
	{
		try
		{
			wrInt32(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrUInt32(int groupCode, uint value)
	{
		try
		{
			wrUInt32(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrInt64(int groupCode, long value)
	{
		try
		{
			wrInt64(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrUInt64(int groupCode, ulong value)
	{
		try
		{
			wrUInt64(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrHandle(int groupCode, IntPtr value)
	{
		try
		{
			wrHandle(groupCode, new OdDbHandle(value, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrObjectId(int groupCode, IntPtr value)
	{
		try
		{
			wrObjectId(groupCode, new OdDbObjectId(value, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrAngle__SWIG_0(int groupCode, double value, int precision)
	{
		try
		{
			wrAngle(groupCode, value, precision);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrAngle__SWIG_1(int groupCode, double value)
	{
		try
		{
			wrAngle(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrDouble__SWIG_0(int groupCode, double value, int precision)
	{
		try
		{
			wrDouble(groupCode, value, precision);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrDouble__SWIG_1(int groupCode, double value)
	{
		try
		{
			wrDouble(groupCode, value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrPoint2d__SWIG_0(int groupCode, IntPtr value, int precision)
	{
		try
		{
			wrPoint2d(groupCode, new OdGePoint2d(value, cMemoryOwn: false), precision);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrPoint2d__SWIG_1(int groupCode, IntPtr value)
	{
		try
		{
			wrPoint2d(groupCode, new OdGePoint2d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrPoint3d__SWIG_0(int groupCode, IntPtr value, int precision)
	{
		try
		{
			wrPoint3d(groupCode, new OdGePoint3d(value, cMemoryOwn: false), precision);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrPoint3d__SWIG_1(int groupCode, IntPtr value)
	{
		try
		{
			wrPoint3d(groupCode, new OdGePoint3d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrVector2d__SWIG_0(int groupCode, IntPtr value, int precision)
	{
		try
		{
			wrVector2d(groupCode, new OdGeVector2d(value, cMemoryOwn: true), precision);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrVector2d__SWIG_1(int groupCode, IntPtr value)
	{
		try
		{
			wrVector2d(groupCode, new OdGeVector2d(value, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrVector3d__SWIG_0(int groupCode, IntPtr value, int precision)
	{
		try
		{
			wrVector3d(groupCode, new OdGeVector3d(value, cMemoryOwn: false), precision);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrVector3d__SWIG_1(int groupCode, IntPtr value)
	{
		try
		{
			wrVector3d(groupCode, new OdGeVector3d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrScale3d__SWIG_0(int groupCode, IntPtr value, int precision)
	{
		try
		{
			wrScale3d(groupCode, new OdGeScale3d(value, cMemoryOwn: false), precision);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrScale3d__SWIG_1(int groupCode, IntPtr value)
	{
		try
		{
			wrScale3d(groupCode, new OdGeScale3d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrBinaryChunk__SWIG_0(int groupCode, IntPtr buffer)
	{
		try
		{
			wrBinaryChunk(groupCode, ODA.Kernel.TD_RootIntegrated.Helpers.UnMarshalbyteFixedArray(buffer));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

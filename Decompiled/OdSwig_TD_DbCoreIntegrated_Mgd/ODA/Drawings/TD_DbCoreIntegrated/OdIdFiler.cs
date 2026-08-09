using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdIdFiler : OdDbDwgFiler
{
	public delegate IntPtr SwigDelegateOdIdFiler_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdIdFiler_1();

	public delegate void SwigDelegateOdIdFiler_2(IntPtr pSource);

	public delegate int SwigDelegateOdIdFiler_3();

	public delegate void SwigDelegateOdIdFiler_4();

	public delegate int SwigDelegateOdIdFiler_5();

	public delegate IntPtr SwigDelegateOdIdFiler_6();

	public delegate void SwigDelegateOdIdFiler_7(long offset, int seekType);

	public delegate ulong SwigDelegateOdIdFiler_8();

	public delegate bool SwigDelegateOdIdFiler_9();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdIdFiler_10();

	public delegate void SwigDelegateOdIdFiler_11(IntPtr buffer, uint numBytes);

	public delegate sbyte SwigDelegateOdIdFiler_12();

	public delegate byte SwigDelegateOdIdFiler_13();

	public delegate short SwigDelegateOdIdFiler_14();

	public delegate int SwigDelegateOdIdFiler_15();

	public delegate long SwigDelegateOdIdFiler_16();

	public delegate IntPtr SwigDelegateOdIdFiler_17();

	public delegate double SwigDelegateOdIdFiler_18();

	public delegate double SwigDelegateOdIdFiler_19();

	public delegate IntPtr SwigDelegateOdIdFiler_20();

	public delegate IntPtr SwigDelegateOdIdFiler_21();

	public delegate IntPtr SwigDelegateOdIdFiler_22();

	public delegate IntPtr SwigDelegateOdIdFiler_23();

	public delegate IntPtr SwigDelegateOdIdFiler_24();

	public delegate IntPtr SwigDelegateOdIdFiler_25();

	public delegate IntPtr SwigDelegateOdIdFiler_26();

	public delegate IntPtr SwigDelegateOdIdFiler_27();

	public delegate IntPtr SwigDelegateOdIdFiler_28();

	public delegate IntPtr SwigDelegateOdIdFiler_29();

	public delegate double SwigDelegateOdIdFiler_30();

	public delegate IntPtr SwigDelegateOdIdFiler_31();

	public delegate void SwigDelegateOdIdFiler_32(bool value);

	public delegate void SwigDelegateOdIdFiler_33([MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate void SwigDelegateOdIdFiler_34(IntPtr buffer);

	public delegate void SwigDelegateOdIdFiler_35(sbyte value);

	public delegate void SwigDelegateOdIdFiler_36(byte value);

	public delegate void SwigDelegateOdIdFiler_37(short value);

	public delegate void SwigDelegateOdIdFiler_38(int value);

	public delegate void SwigDelegateOdIdFiler_39(long value);

	public delegate void SwigDelegateOdIdFiler_40(IntPtr value);

	public delegate void SwigDelegateOdIdFiler_41(double value);

	public delegate void SwigDelegateOdIdFiler_42(IntPtr value);

	public delegate void SwigDelegateOdIdFiler_43(IntPtr value);

	public delegate void SwigDelegateOdIdFiler_44(IntPtr value);

	public delegate void SwigDelegateOdIdFiler_45(IntPtr value);

	public delegate void SwigDelegateOdIdFiler_46(IntPtr value);

	public delegate void SwigDelegateOdIdFiler_47(IntPtr value);

	public delegate void SwigDelegateOdIdFiler_48(IntPtr value);

	public delegate void SwigDelegateOdIdFiler_49(IntPtr value);

	public delegate void SwigDelegateOdIdFiler_50(IntPtr value);

	public delegate void SwigDelegateOdIdFiler_51(IntPtr value);

	public delegate void SwigDelegateOdIdFiler_52(double value);

	public delegate void SwigDelegateOdIdFiler_53(IntPtr value);

	public delegate bool SwigDelegateOdIdFiler_54();

	public delegate void SwigDelegateOdIdFiler_55(IntPtr id, int rt);

	public delegate bool SwigDelegateOdIdFiler_56();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdIdFiler_0 swigDelegate0;

	private SwigDelegateOdIdFiler_1 swigDelegate1;

	private SwigDelegateOdIdFiler_2 swigDelegate2;

	private SwigDelegateOdIdFiler_3 swigDelegate3;

	private SwigDelegateOdIdFiler_4 swigDelegate4;

	private SwigDelegateOdIdFiler_5 swigDelegate5;

	private SwigDelegateOdIdFiler_6 swigDelegate6;

	private SwigDelegateOdIdFiler_7 swigDelegate7;

	private SwigDelegateOdIdFiler_8 swigDelegate8;

	private SwigDelegateOdIdFiler_9 swigDelegate9;

	private SwigDelegateOdIdFiler_10 swigDelegate10;

	private SwigDelegateOdIdFiler_11 swigDelegate11;

	private SwigDelegateOdIdFiler_12 swigDelegate12;

	private SwigDelegateOdIdFiler_13 swigDelegate13;

	private SwigDelegateOdIdFiler_14 swigDelegate14;

	private SwigDelegateOdIdFiler_15 swigDelegate15;

	private SwigDelegateOdIdFiler_16 swigDelegate16;

	private SwigDelegateOdIdFiler_17 swigDelegate17;

	private SwigDelegateOdIdFiler_18 swigDelegate18;

	private SwigDelegateOdIdFiler_19 swigDelegate19;

	private SwigDelegateOdIdFiler_20 swigDelegate20;

	private SwigDelegateOdIdFiler_21 swigDelegate21;

	private SwigDelegateOdIdFiler_22 swigDelegate22;

	private SwigDelegateOdIdFiler_23 swigDelegate23;

	private SwigDelegateOdIdFiler_24 swigDelegate24;

	private SwigDelegateOdIdFiler_25 swigDelegate25;

	private SwigDelegateOdIdFiler_26 swigDelegate26;

	private SwigDelegateOdIdFiler_27 swigDelegate27;

	private SwigDelegateOdIdFiler_28 swigDelegate28;

	private SwigDelegateOdIdFiler_29 swigDelegate29;

	private SwigDelegateOdIdFiler_30 swigDelegate30;

	private SwigDelegateOdIdFiler_31 swigDelegate31;

	private SwigDelegateOdIdFiler_32 swigDelegate32;

	private SwigDelegateOdIdFiler_33 swigDelegate33;

	private SwigDelegateOdIdFiler_34 swigDelegate34;

	private SwigDelegateOdIdFiler_35 swigDelegate35;

	private SwigDelegateOdIdFiler_36 swigDelegate36;

	private SwigDelegateOdIdFiler_37 swigDelegate37;

	private SwigDelegateOdIdFiler_38 swigDelegate38;

	private SwigDelegateOdIdFiler_39 swigDelegate39;

	private SwigDelegateOdIdFiler_40 swigDelegate40;

	private SwigDelegateOdIdFiler_41 swigDelegate41;

	private SwigDelegateOdIdFiler_42 swigDelegate42;

	private SwigDelegateOdIdFiler_43 swigDelegate43;

	private SwigDelegateOdIdFiler_44 swigDelegate44;

	private SwigDelegateOdIdFiler_45 swigDelegate45;

	private SwigDelegateOdIdFiler_46 swigDelegate46;

	private SwigDelegateOdIdFiler_47 swigDelegate47;

	private SwigDelegateOdIdFiler_48 swigDelegate48;

	private SwigDelegateOdIdFiler_49 swigDelegate49;

	private SwigDelegateOdIdFiler_50 swigDelegate50;

	private SwigDelegateOdIdFiler_51 swigDelegate51;

	private SwigDelegateOdIdFiler_52 swigDelegate52;

	private SwigDelegateOdIdFiler_53 swigDelegate53;

	private SwigDelegateOdIdFiler_54 swigDelegate54;

	private SwigDelegateOdIdFiler_55 swigDelegate55;

	private SwigDelegateOdIdFiler_56 swigDelegate56;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(long),
		typeof(OdDb_FilerSeekType)
	};

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(IntPtr),
		typeof(uint)
	};

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[0];

	private static Type[] swigMethodTypes25 = new Type[0];

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[0];

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes34 = new Type[1] { typeof(byte[]) };

	private static Type[] swigMethodTypes35 = new Type[1] { typeof(sbyte) };

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(short) };

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes39 = new Type[1] { typeof(long) };

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(OdDbHandle) };

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes45 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes46 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(OdGePoint2d) };

	private static Type[] swigMethodTypes48 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(OdGeVector2d) };

	private static Type[] swigMethodTypes50 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdGeScale3d) };

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes54 = new Type[0];

	private static Type[] swigMethodTypes55 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(ReferenceType)
	};

	private static Type[] swigMethodTypes56 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIdFiler(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIdFiler obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdIdFiler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdIdFiler()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdIdFiler(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public override void seek(long offset, OdDb_FilerSeekType seekType)
	{
		if (SwigDerivedClassHasMethod("seek", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_seekSwigExplicitOdIdFiler(swigCPtr, offset, (int)seekType);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_seek(swigCPtr, offset, (int)seekType);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override ulong tell()
	{
		ulong result = (SwigDerivedClassHasMethod("tell", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_tellSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_tell(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult filerStatus()
	{
		int result = (SwigDerivedClassHasMethod("filerStatus", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_filerStatusSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_filerStatus(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void resetFilerStatus()
	{
		if (SwigDerivedClassHasMethod("resetFilerStatus", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_resetFilerStatusSwigExplicitOdIdFiler(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_resetFilerStatus(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbFiler_FilerType filerType()
	{
		int result = (SwigDerivedClassHasMethod("filerType", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_filerTypeSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_filerType(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbFiler_FilerType)result;
	}

	public override DwgVersion dwgVersion(out MaintReleaseVer pMaintReleaseVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_dwgVersion__SWIG_0(swigCPtr, out pMaintReleaseVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public override DwgVersion dwgVersion()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_dwgVersion__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public override bool rdBool()
	{
		bool result = (SwigDerivedClassHasMethod("rdBool", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdBoolSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdBool(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string rdString()
	{
		string result = (SwigDerivedClassHasMethod("rdString", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdStringSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdString(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void rdBytes(IntPtr buffer, uint numBytes)
	{
		if (SwigDerivedClassHasMethod("rdBytes", swigMethodTypes11))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdBytesSwigExplicitOdIdFiler(swigCPtr, buffer, numBytes);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdBytes(swigCPtr, buffer, numBytes);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override sbyte rdInt8()
	{
		sbyte result = (SwigDerivedClassHasMethod("rdInt8", swigMethodTypes12) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdInt8SwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdInt8(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override byte rdUInt8()
	{
		byte result = (SwigDerivedClassHasMethod("rdUInt8", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdUInt8SwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdUInt8(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override short rdInt16()
	{
		short result = (SwigDerivedClassHasMethod("rdInt16", swigMethodTypes14) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdInt16SwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdInt16(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override int rdInt32()
	{
		int result = (SwigDerivedClassHasMethod("rdInt32", swigMethodTypes15) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdInt32SwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdInt32(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override long rdInt64()
	{
		long result = (SwigDerivedClassHasMethod("rdInt64", swigMethodTypes16) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdInt64SwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdInt64(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double rdDouble()
	{
		double result = (SwigDerivedClassHasMethod("rdDouble", swigMethodTypes18) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdDoubleSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdDouble(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbHandle rdDbHandle()
	{
		OdDbHandle result = new OdDbHandle(SwigDerivedClassHasMethod("rdDbHandle", swigMethodTypes20) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdDbHandleSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdDbHandle(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbObjectId rdSoftOwnershipId()
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("rdSoftOwnershipId", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdSoftOwnershipIdSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdSoftOwnershipId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbObjectId rdHardOwnershipId()
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("rdHardOwnershipId", swigMethodTypes22) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdHardOwnershipIdSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdHardOwnershipId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbObjectId rdHardPointerId()
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("rdHardPointerId", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdHardPointerIdSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdHardPointerId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbObjectId rdSoftPointerId()
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("rdSoftPointerId", swigMethodTypes24) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdSoftPointerIdSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdSoftPointerId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGePoint2d rdPoint2d()
	{
		OdGePoint2d result = new OdGePoint2d(SwigDerivedClassHasMethod("rdPoint2d", swigMethodTypes25) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdPoint2dSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdPoint2d(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGePoint3d rdPoint3d()
	{
		OdGePoint3d result = new OdGePoint3d(SwigDerivedClassHasMethod("rdPoint3d", swigMethodTypes26) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdPoint3dSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdPoint3d(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGeVector3d rdVector3d()
	{
		OdGeVector3d result = new OdGeVector3d(SwigDerivedClassHasMethod("rdVector3d", swigMethodTypes28) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdVector3dSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdVector3d(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGeVector2d rdVector2d()
	{
		OdGeVector2d result = new OdGeVector2d(SwigDerivedClassHasMethod("rdVector2d", swigMethodTypes27) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdVector2dSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdVector2d(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGeScale3d rdScale3d()
	{
		OdGeScale3d result = new OdGeScale3d(SwigDerivedClassHasMethod("rdScale3d", swigMethodTypes29) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdScale3dSwigExplicitOdIdFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_rdScale3d(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void wrBool(bool value)
	{
		if (SwigDerivedClassHasMethod("wrBool", swigMethodTypes32))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrBoolSwigExplicitOdIdFiler(swigCPtr, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrBool(swigCPtr, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrString(string value)
	{
		if (SwigDerivedClassHasMethod("wrString", swigMethodTypes33))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrStringSwigExplicitOdIdFiler(swigCPtr, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrString(swigCPtr, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrBytes(byte[] buffer)
	{
		IntPtr intPtr = ODA.Kernel.TD_RootIntegrated.Helpers.MarshalbyteFixedArray(buffer);
		try
		{
			if (SwigDerivedClassHasMethod("wrBytes", swigMethodTypes34))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrBytesSwigExplicitOdIdFiler(swigCPtr, intPtr);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrBytes(swigCPtr, intPtr);
			}
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

	public override void wrInt8(sbyte value)
	{
		if (SwigDerivedClassHasMethod("wrInt8", swigMethodTypes35))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrInt8SwigExplicitOdIdFiler(swigCPtr, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrInt8(swigCPtr, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrUInt8(byte value)
	{
		if (SwigDerivedClassHasMethod("wrUInt8", swigMethodTypes36))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrUInt8SwigExplicitOdIdFiler(swigCPtr, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrUInt8(swigCPtr, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrInt16(short value)
	{
		if (SwigDerivedClassHasMethod("wrInt16", swigMethodTypes37))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrInt16SwigExplicitOdIdFiler(swigCPtr, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrInt16(swigCPtr, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrInt32(int value)
	{
		if (SwigDerivedClassHasMethod("wrInt32", swigMethodTypes38))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrInt32SwigExplicitOdIdFiler(swigCPtr, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrInt32(swigCPtr, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrInt64(long value)
	{
		if (SwigDerivedClassHasMethod("wrInt64", swigMethodTypes39))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrInt64SwigExplicitOdIdFiler(swigCPtr, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrInt64(swigCPtr, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrDouble(double value)
	{
		if (SwigDerivedClassHasMethod("wrDouble", swigMethodTypes41))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrDoubleSwigExplicitOdIdFiler(swigCPtr, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrDouble(swigCPtr, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrDbHandle(OdDbHandle value)
	{
		if (SwigDerivedClassHasMethod("wrDbHandle", swigMethodTypes42))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrDbHandleSwigExplicitOdIdFiler(swigCPtr, OdDbHandle.getCPtr(value));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrDbHandle(swigCPtr, OdDbHandle.getCPtr(value));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrPoint2d(OdGePoint2d value)
	{
		if (SwigDerivedClassHasMethod("wrPoint2d", swigMethodTypes47))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrPoint2dSwigExplicitOdIdFiler(swigCPtr, OdGePoint2d.getCPtr(value));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrPoint2d(swigCPtr, OdGePoint2d.getCPtr(value));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrPoint3d(OdGePoint3d value)
	{
		if (SwigDerivedClassHasMethod("wrPoint3d", swigMethodTypes48))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrPoint3dSwigExplicitOdIdFiler(swigCPtr, OdGePoint3d.getCPtr(value));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrPoint3d(swigCPtr, OdGePoint3d.getCPtr(value));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrVector2d(OdGeVector2d value)
	{
		if (SwigDerivedClassHasMethod("wrVector2d", swigMethodTypes49))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrVector2dSwigExplicitOdIdFiler(swigCPtr, OdGeVector2d.getCPtr(value).Handle);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrVector2d(swigCPtr, OdGeVector2d.getCPtr(value).Handle);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrVector3d(OdGeVector3d value)
	{
		if (SwigDerivedClassHasMethod("wrVector3d", swigMethodTypes50))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrVector3dSwigExplicitOdIdFiler(swigCPtr, OdGeVector3d.getCPtr(value));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrVector3d(swigCPtr, OdGeVector3d.getCPtr(value));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void wrScale3d(OdGeScale3d value)
	{
		if (SwigDerivedClassHasMethod("wrScale3d", swigMethodTypes51))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrScale3dSwigExplicitOdIdFiler(swigCPtr, OdGeScale3d.getCPtr(value));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_wrScale3d(swigCPtr, OdGeScale3d.getCPtr(value));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("seek", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodseek;
		}
		if (SwigDerivedClassHasMethod("tell", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodtell;
		}
		if (SwigDerivedClassHasMethod("rdBool", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodrdBool;
		}
		if (SwigDerivedClassHasMethod("rdString", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodrdString;
		}
		if (SwigDerivedClassHasMethod("rdBytes", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodrdBytes;
		}
		if (SwigDerivedClassHasMethod("rdInt8", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodrdInt8;
		}
		if (SwigDerivedClassHasMethod("rdUInt8", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodrdUInt8;
		}
		if (SwigDerivedClassHasMethod("rdInt16", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodrdInt16;
		}
		if (SwigDerivedClassHasMethod("rdInt32", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodrdInt32;
		}
		if (SwigDerivedClassHasMethod("rdInt64", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodrdInt64;
		}
		if (SwigDerivedClassHasMethod("rdAddress", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodrdAddress;
		}
		if (SwigDerivedClassHasMethod("rdDouble", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodrdDouble;
		}
		if (SwigDerivedClassHasMethod("rdDoubleNoCheck", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodrdDoubleNoCheck;
		}
		if (SwigDerivedClassHasMethod("rdDbHandle", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodrdDbHandle;
		}
		if (SwigDerivedClassHasMethod("rdSoftOwnershipId", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodrdSoftOwnershipId;
		}
		if (SwigDerivedClassHasMethod("rdHardOwnershipId", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodrdHardOwnershipId;
		}
		if (SwigDerivedClassHasMethod("rdHardPointerId", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodrdHardPointerId;
		}
		if (SwigDerivedClassHasMethod("rdSoftPointerId", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodrdSoftPointerId;
		}
		if (SwigDerivedClassHasMethod("rdPoint2d", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodrdPoint2d;
		}
		if (SwigDerivedClassHasMethod("rdPoint3d", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodrdPoint3d;
		}
		if (SwigDerivedClassHasMethod("rdVector2d", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodrdVector2d;
		}
		if (SwigDerivedClassHasMethod("rdVector3d", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodrdVector3d;
		}
		if (SwigDerivedClassHasMethod("rdScale3d", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodrdScale3d;
		}
		if (SwigDerivedClassHasMethod("rdThickness", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodrdThickness;
		}
		if (SwigDerivedClassHasMethod("rdExtrusion", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodrdExtrusion;
		}
		if (SwigDerivedClassHasMethod("wrBool", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodwrBool;
		}
		if (SwigDerivedClassHasMethod("wrString", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodwrString;
		}
		if (SwigDerivedClassHasMethod("wrBytes", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodwrBytes;
		}
		if (SwigDerivedClassHasMethod("wrInt8", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodwrInt8;
		}
		if (SwigDerivedClassHasMethod("wrUInt8", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodwrUInt8;
		}
		if (SwigDerivedClassHasMethod("wrInt16", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodwrInt16;
		}
		if (SwigDerivedClassHasMethod("wrInt32", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodwrInt32;
		}
		if (SwigDerivedClassHasMethod("wrInt64", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodwrInt64;
		}
		if (SwigDerivedClassHasMethod("wrAddress", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodwrAddress;
		}
		if (SwigDerivedClassHasMethod("wrDouble", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodwrDouble;
		}
		if (SwigDerivedClassHasMethod("wrDbHandle", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodwrDbHandle;
		}
		if (SwigDerivedClassHasMethod("wrSoftOwnershipId", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodwrSoftOwnershipId;
		}
		if (SwigDerivedClassHasMethod("wrHardOwnershipId", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodwrHardOwnershipId;
		}
		if (SwigDerivedClassHasMethod("wrSoftPointerId", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodwrSoftPointerId;
		}
		if (SwigDerivedClassHasMethod("wrHardPointerId", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodwrHardPointerId;
		}
		if (SwigDerivedClassHasMethod("wrPoint2d", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodwrPoint2d;
		}
		if (SwigDerivedClassHasMethod("wrPoint3d", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodwrPoint3d;
		}
		if (SwigDerivedClassHasMethod("wrVector2d", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodwrVector2d;
		}
		if (SwigDerivedClassHasMethod("wrVector3d", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodwrVector3d;
		}
		if (SwigDerivedClassHasMethod("wrScale3d", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodwrScale3d;
		}
		if (SwigDerivedClassHasMethod("wrThickness", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodwrThickness;
		}
		if (SwigDerivedClassHasMethod("wrExtrusion", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodwrExtrusion;
		}
		if (SwigDerivedClassHasMethod("usesReferences", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodusesReferences;
		}
		if (SwigDerivedClassHasMethod("addReference", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodaddReference;
		}
		if (SwigDerivedClassHasMethod("isPersistentMode", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodisPersistentMode;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdIdFiler_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdIdFiler));
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

	private bool SwigDirectorMethodrdBool()
	{
		return rdBool();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodrdString()
	{
		return rdString();
	}

	private void SwigDirectorMethodrdBytes(IntPtr buffer, uint numBytes)
	{
		try
		{
			rdBytes(buffer, numBytes);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private sbyte SwigDirectorMethodrdInt8()
	{
		return rdInt8();
	}

	private byte SwigDirectorMethodrdUInt8()
	{
		return rdUInt8();
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

	private IntPtr SwigDirectorMethodrdAddress()
	{
		return rdAddress();
	}

	private double SwigDirectorMethodrdDouble()
	{
		return rdDouble();
	}

	private double SwigDirectorMethodrdDoubleNoCheck()
	{
		return rdDoubleNoCheck();
	}

	private IntPtr SwigDirectorMethodrdDbHandle()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbHandle.getCPtr(rdDbHandle()).Handle;
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

	private IntPtr SwigDirectorMethodrdSoftOwnershipId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(rdSoftOwnershipId()).Handle;
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

	private IntPtr SwigDirectorMethodrdHardOwnershipId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(rdHardOwnershipId()).Handle;
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

	private IntPtr SwigDirectorMethodrdHardPointerId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(rdHardPointerId()).Handle;
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

	private IntPtr SwigDirectorMethodrdSoftPointerId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(rdSoftPointerId()).Handle;
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

	private IntPtr SwigDirectorMethodrdPoint2d()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint2d.getCPtr(rdPoint2d()).Handle;
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

	private IntPtr SwigDirectorMethodrdPoint3d()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(rdPoint3d()).Handle;
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

	private IntPtr SwigDirectorMethodrdVector2d()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector2d.getCPtr(rdVector2d()).Handle;
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

	private IntPtr SwigDirectorMethodrdVector3d()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(rdVector3d()).Handle;
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

	private IntPtr SwigDirectorMethodrdScale3d()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeScale3d.getCPtr(rdScale3d()).Handle;
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

	private double SwigDirectorMethodrdThickness()
	{
		return rdThickness();
	}

	private IntPtr SwigDirectorMethodrdExtrusion()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(rdExtrusion()).Handle;
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

	private void SwigDirectorMethodwrBool(bool value)
	{
		try
		{
			wrBool(value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrString([MarshalAs(UnmanagedType.LPWStr)] string value)
	{
		try
		{
			wrString(value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrBytes(IntPtr buffer)
	{
		try
		{
			wrBytes(ODA.Kernel.TD_RootIntegrated.Helpers.UnMarshalbyteFixedArray(buffer));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrInt8(sbyte value)
	{
		try
		{
			wrInt8(value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrUInt8(byte value)
	{
		try
		{
			wrUInt8(value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrInt16(short value)
	{
		try
		{
			wrInt16(value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrInt32(int value)
	{
		try
		{
			wrInt32(value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrInt64(long value)
	{
		try
		{
			wrInt64(value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrAddress(IntPtr value)
	{
		try
		{
			wrAddress(value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrDouble(double value)
	{
		try
		{
			wrDouble(value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrDbHandle(IntPtr value)
	{
		try
		{
			wrDbHandle(new OdDbHandle(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrSoftOwnershipId(IntPtr value)
	{
		try
		{
			wrSoftOwnershipId(new OdDbObjectId(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrHardOwnershipId(IntPtr value)
	{
		try
		{
			wrHardOwnershipId(new OdDbObjectId(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrSoftPointerId(IntPtr value)
	{
		try
		{
			wrSoftPointerId(new OdDbObjectId(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrHardPointerId(IntPtr value)
	{
		try
		{
			wrHardPointerId(new OdDbObjectId(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrPoint2d(IntPtr value)
	{
		try
		{
			wrPoint2d(new OdGePoint2d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrPoint3d(IntPtr value)
	{
		try
		{
			wrPoint3d(new OdGePoint3d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrVector2d(IntPtr value)
	{
		try
		{
			wrVector2d(new OdGeVector2d(value, cMemoryOwn: true));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrVector3d(IntPtr value)
	{
		try
		{
			wrVector3d(new OdGeVector3d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrScale3d(IntPtr value)
	{
		try
		{
			wrScale3d(new OdGeScale3d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrThickness(double value)
	{
		try
		{
			wrThickness(value);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private void SwigDirectorMethodwrExtrusion(IntPtr value)
	{
		try
		{
			wrExtrusion(new OdGeVector3d(value, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private bool SwigDirectorMethodusesReferences()
	{
		return usesReferences();
	}

	private void SwigDirectorMethodaddReference(IntPtr id, int rt)
	{
		try
		{
			addReference(new OdDbObjectId(id, cMemoryOwn: true), (ReferenceType)rt);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
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

	private bool SwigDirectorMethodisPersistentMode()
	{
		return isPersistentMode();
	}
}

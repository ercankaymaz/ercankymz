using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDwgFiler : OdDbFiler
{
	public delegate IntPtr SwigDelegateOdDbDwgFiler_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbDwgFiler_1();

	public delegate void SwigDelegateOdDbDwgFiler_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbDwgFiler_3();

	public delegate void SwigDelegateOdDbDwgFiler_4();

	public delegate int SwigDelegateOdDbDwgFiler_5();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_6();

	public delegate int SwigDelegateOdDbDwgFiler_7(MaintReleaseVer pMaintReleaseVer);

	public delegate int SwigDelegateOdDbDwgFiler_8();

	public delegate void SwigDelegateOdDbDwgFiler_9(long offset, int seekType);

	public delegate ulong SwigDelegateOdDbDwgFiler_10();

	public delegate bool SwigDelegateOdDbDwgFiler_11();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDwgFiler_12();

	public delegate void SwigDelegateOdDbDwgFiler_13(IntPtr buffer, uint numBytes);

	public delegate sbyte SwigDelegateOdDbDwgFiler_14();

	public delegate byte SwigDelegateOdDbDwgFiler_15();

	public delegate short SwigDelegateOdDbDwgFiler_16();

	public delegate int SwigDelegateOdDbDwgFiler_17();

	public delegate long SwigDelegateOdDbDwgFiler_18();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_19();

	public delegate double SwigDelegateOdDbDwgFiler_20();

	public delegate double SwigDelegateOdDbDwgFiler_21();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_22();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_23();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_24();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_25();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_26();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_27();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_28();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_29();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_30();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_31();

	public delegate double SwigDelegateOdDbDwgFiler_32();

	public delegate IntPtr SwigDelegateOdDbDwgFiler_33();

	public delegate void SwigDelegateOdDbDwgFiler_34(bool value);

	public delegate void SwigDelegateOdDbDwgFiler_35([MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate void SwigDelegateOdDbDwgFiler_36(IntPtr buffer);

	public delegate void SwigDelegateOdDbDwgFiler_37(sbyte value);

	public delegate void SwigDelegateOdDbDwgFiler_38(byte value);

	public delegate void SwigDelegateOdDbDwgFiler_39(short value);

	public delegate void SwigDelegateOdDbDwgFiler_40(int value);

	public delegate void SwigDelegateOdDbDwgFiler_41(long value);

	public delegate void SwigDelegateOdDbDwgFiler_42(IntPtr value);

	public delegate void SwigDelegateOdDbDwgFiler_43(double value);

	public delegate void SwigDelegateOdDbDwgFiler_44(IntPtr value);

	public delegate void SwigDelegateOdDbDwgFiler_45(IntPtr value);

	public delegate void SwigDelegateOdDbDwgFiler_46(IntPtr value);

	public delegate void SwigDelegateOdDbDwgFiler_47(IntPtr value);

	public delegate void SwigDelegateOdDbDwgFiler_48(IntPtr value);

	public delegate void SwigDelegateOdDbDwgFiler_49(IntPtr value);

	public delegate void SwigDelegateOdDbDwgFiler_50(IntPtr value);

	public delegate void SwigDelegateOdDbDwgFiler_51(IntPtr value);

	public delegate void SwigDelegateOdDbDwgFiler_52(IntPtr value);

	public delegate void SwigDelegateOdDbDwgFiler_53(IntPtr value);

	public delegate void SwigDelegateOdDbDwgFiler_54(double value);

	public delegate void SwigDelegateOdDbDwgFiler_55(IntPtr value);

	public delegate bool SwigDelegateOdDbDwgFiler_56();

	public delegate void SwigDelegateOdDbDwgFiler_57(IntPtr id, int rt);

	public delegate bool SwigDelegateOdDbDwgFiler_58();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbDwgFiler_0 swigDelegate0;

	private SwigDelegateOdDbDwgFiler_1 swigDelegate1;

	private SwigDelegateOdDbDwgFiler_2 swigDelegate2;

	private SwigDelegateOdDbDwgFiler_3 swigDelegate3;

	private SwigDelegateOdDbDwgFiler_4 swigDelegate4;

	private SwigDelegateOdDbDwgFiler_5 swigDelegate5;

	private SwigDelegateOdDbDwgFiler_6 swigDelegate6;

	private SwigDelegateOdDbDwgFiler_7 swigDelegate7;

	private SwigDelegateOdDbDwgFiler_8 swigDelegate8;

	private SwigDelegateOdDbDwgFiler_9 swigDelegate9;

	private SwigDelegateOdDbDwgFiler_10 swigDelegate10;

	private SwigDelegateOdDbDwgFiler_11 swigDelegate11;

	private SwigDelegateOdDbDwgFiler_12 swigDelegate12;

	private SwigDelegateOdDbDwgFiler_13 swigDelegate13;

	private SwigDelegateOdDbDwgFiler_14 swigDelegate14;

	private SwigDelegateOdDbDwgFiler_15 swigDelegate15;

	private SwigDelegateOdDbDwgFiler_16 swigDelegate16;

	private SwigDelegateOdDbDwgFiler_17 swigDelegate17;

	private SwigDelegateOdDbDwgFiler_18 swigDelegate18;

	private SwigDelegateOdDbDwgFiler_19 swigDelegate19;

	private SwigDelegateOdDbDwgFiler_20 swigDelegate20;

	private SwigDelegateOdDbDwgFiler_21 swigDelegate21;

	private SwigDelegateOdDbDwgFiler_22 swigDelegate22;

	private SwigDelegateOdDbDwgFiler_23 swigDelegate23;

	private SwigDelegateOdDbDwgFiler_24 swigDelegate24;

	private SwigDelegateOdDbDwgFiler_25 swigDelegate25;

	private SwigDelegateOdDbDwgFiler_26 swigDelegate26;

	private SwigDelegateOdDbDwgFiler_27 swigDelegate27;

	private SwigDelegateOdDbDwgFiler_28 swigDelegate28;

	private SwigDelegateOdDbDwgFiler_29 swigDelegate29;

	private SwigDelegateOdDbDwgFiler_30 swigDelegate30;

	private SwigDelegateOdDbDwgFiler_31 swigDelegate31;

	private SwigDelegateOdDbDwgFiler_32 swigDelegate32;

	private SwigDelegateOdDbDwgFiler_33 swigDelegate33;

	private SwigDelegateOdDbDwgFiler_34 swigDelegate34;

	private SwigDelegateOdDbDwgFiler_35 swigDelegate35;

	private SwigDelegateOdDbDwgFiler_36 swigDelegate36;

	private SwigDelegateOdDbDwgFiler_37 swigDelegate37;

	private SwigDelegateOdDbDwgFiler_38 swigDelegate38;

	private SwigDelegateOdDbDwgFiler_39 swigDelegate39;

	private SwigDelegateOdDbDwgFiler_40 swigDelegate40;

	private SwigDelegateOdDbDwgFiler_41 swigDelegate41;

	private SwigDelegateOdDbDwgFiler_42 swigDelegate42;

	private SwigDelegateOdDbDwgFiler_43 swigDelegate43;

	private SwigDelegateOdDbDwgFiler_44 swigDelegate44;

	private SwigDelegateOdDbDwgFiler_45 swigDelegate45;

	private SwigDelegateOdDbDwgFiler_46 swigDelegate46;

	private SwigDelegateOdDbDwgFiler_47 swigDelegate47;

	private SwigDelegateOdDbDwgFiler_48 swigDelegate48;

	private SwigDelegateOdDbDwgFiler_49 swigDelegate49;

	private SwigDelegateOdDbDwgFiler_50 swigDelegate50;

	private SwigDelegateOdDbDwgFiler_51 swigDelegate51;

	private SwigDelegateOdDbDwgFiler_52 swigDelegate52;

	private SwigDelegateOdDbDwgFiler_53 swigDelegate53;

	private SwigDelegateOdDbDwgFiler_54 swigDelegate54;

	private SwigDelegateOdDbDwgFiler_55 swigDelegate55;

	private SwigDelegateOdDbDwgFiler_56 swigDelegate56;

	private SwigDelegateOdDbDwgFiler_57 swigDelegate57;

	private SwigDelegateOdDbDwgFiler_58 swigDelegate58;

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

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(IntPtr),
		typeof(uint)
	};

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

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[0];

	private static Type[] swigMethodTypes34 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes35 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(byte[]) };

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(sbyte) };

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes39 = new Type[1] { typeof(short) };

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(long) };

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdDbHandle) };

	private static Type[] swigMethodTypes45 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes46 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes48 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(OdGePoint2d) };

	private static Type[] swigMethodTypes50 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdGeVector2d) };

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(OdGeScale3d) };

	private static Type[] swigMethodTypes54 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes56 = new Type[0];

	private static Type[] swigMethodTypes57 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(ReferenceType)
	};

	private static Type[] swigMethodTypes58 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDwgFiler(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDwgFiler obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDwgFiler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbDwgFiler()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDwgFiler(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbDwgFiler cast(OdRxObject pObj)
	{
		OdDbDwgFiler rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_isASwigExplicitOdDbDwgFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_queryXSwigExplicitOdDbDwgFiler(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbDwgFiler createObject()
	{
		OdDbDwgFiler rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void seek(long offset, OdDb_FilerSeekType seekType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_seek(swigCPtr, offset, (int)seekType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ulong tell()
	{
		ulong result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_tell(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool rdBool()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdBool(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string rdString()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdString(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void rdBytes(IntPtr buffer, uint numBytes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdBytes(swigCPtr, buffer, numBytes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual sbyte rdInt8()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdInt8(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual byte rdUInt8()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdUInt8(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short rdInt16()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdInt16(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int rdInt32()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdInt32(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual long rdInt64()
	{
		long result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdInt64(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual IntPtr rdAddress()
	{
		IntPtr result = (SwigDerivedClassHasMethod("rdAddress", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdAddressSwigExplicitOdDbDwgFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdAddress(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double rdDouble()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdDouble(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double rdDoubleNoCheck()
	{
		double result = (SwigDerivedClassHasMethod("rdDoubleNoCheck", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdDoubleNoCheckSwigExplicitOdDbDwgFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdDoubleNoCheck(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbHandle rdDbHandle()
	{
		OdDbHandle result = new OdDbHandle(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdDbHandle(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId rdSoftOwnershipId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdSoftOwnershipId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId rdHardOwnershipId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdHardOwnershipId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId rdHardPointerId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdHardPointerId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId rdSoftPointerId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdSoftPointerId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint2d rdPoint2d()
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdPoint2d(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d rdPoint3d()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdPoint3d(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector2d rdVector2d()
	{
		OdGeVector2d result = new OdGeVector2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdVector2d(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d rdVector3d()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdVector3d(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeScale3d rdScale3d()
	{
		OdGeScale3d result = new OdGeScale3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdScale3d(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double rdThickness()
	{
		double result = (SwigDerivedClassHasMethod("rdThickness", swigMethodTypes32) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdThicknessSwigExplicitOdDbDwgFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdThickness(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d rdExtrusion()
	{
		OdGeVector3d result = new OdGeVector3d(SwigDerivedClassHasMethod("rdExtrusion", swigMethodTypes33) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdExtrusionSwigExplicitOdDbDwgFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_rdExtrusion(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrBool(bool value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrBool(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrString(string value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrString(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrBytes(byte[] buffer)
	{
		IntPtr intPtr = ODA.Kernel.TD_RootIntegrated.Helpers.MarshalbyteFixedArray(buffer);
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrBytes(swigCPtr, intPtr);
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

	public virtual void wrInt8(sbyte value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrInt8(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrUInt8(byte value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrUInt8(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrInt16(short value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrInt16(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrInt32(int value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrInt32(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrInt64(long value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrInt64(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrAddress(IntPtr value)
	{
		if (SwigDerivedClassHasMethod("wrAddress", swigMethodTypes42))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrAddressSwigExplicitOdDbDwgFiler(swigCPtr, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrAddress(swigCPtr, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrDouble(double value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrDouble(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrDbHandle(OdDbHandle value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrDbHandle(swigCPtr, OdDbHandle.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrSoftOwnershipId(OdDbObjectId value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrSoftOwnershipId(swigCPtr, OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrHardOwnershipId(OdDbObjectId value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrHardOwnershipId(swigCPtr, OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrSoftPointerId(OdDbObjectId value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrSoftPointerId(swigCPtr, OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrHardPointerId(OdDbObjectId value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrHardPointerId(swigCPtr, OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrPoint2d(OdGePoint2d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrPoint2d(swigCPtr, OdGePoint2d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrPoint3d(OdGePoint3d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrPoint3d(swigCPtr, OdGePoint3d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrVector2d(OdGeVector2d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrVector2d(swigCPtr, OdGeVector2d.getCPtr(value).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrVector3d(OdGeVector3d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrVector3d(swigCPtr, OdGeVector3d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrScale3d(OdGeScale3d value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrScale3d(swigCPtr, OdGeScale3d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrThickness(double value)
	{
		if (SwigDerivedClassHasMethod("wrThickness", swigMethodTypes54))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrThicknessSwigExplicitOdDbDwgFiler(swigCPtr, value);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrThickness(swigCPtr, value);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrExtrusion(OdGeVector3d value)
	{
		if (SwigDerivedClassHasMethod("wrExtrusion", swigMethodTypes55))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrExtrusionSwigExplicitOdDbDwgFiler(swigCPtr, OdGeVector3d.getCPtr(value));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_wrExtrusion(swigCPtr, OdGeVector3d.getCPtr(value));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool usesReferences()
	{
		bool result = (SwigDerivedClassHasMethod("usesReferences", swigMethodTypes56) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_usesReferencesSwigExplicitOdDbDwgFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_usesReferences(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void addReference(OdDbObjectId id, ReferenceType rt)
	{
		if (SwigDerivedClassHasMethod("addReference", swigMethodTypes57))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_addReferenceSwigExplicitOdDbDwgFiler(swigCPtr, OdDbObjectId.getCPtr(id), (int)rt);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_addReference(swigCPtr, OdDbObjectId.getCPtr(id), (int)rt);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isPersistentMode()
	{
		bool result = (SwigDerivedClassHasMethod("isPersistentMode", swigMethodTypes58) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_isPersistentModeSwigExplicitOdDbDwgFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_isPersistentMode(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("rdBool", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodrdBool;
		}
		if (SwigDerivedClassHasMethod("rdString", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodrdString;
		}
		if (SwigDerivedClassHasMethod("rdBytes", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodrdBytes;
		}
		if (SwigDerivedClassHasMethod("rdInt8", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodrdInt8;
		}
		if (SwigDerivedClassHasMethod("rdUInt8", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodrdUInt8;
		}
		if (SwigDerivedClassHasMethod("rdInt16", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodrdInt16;
		}
		if (SwigDerivedClassHasMethod("rdInt32", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodrdInt32;
		}
		if (SwigDerivedClassHasMethod("rdInt64", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodrdInt64;
		}
		if (SwigDerivedClassHasMethod("rdAddress", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodrdAddress;
		}
		if (SwigDerivedClassHasMethod("rdDouble", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodrdDouble;
		}
		if (SwigDerivedClassHasMethod("rdDoubleNoCheck", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodrdDoubleNoCheck;
		}
		if (SwigDerivedClassHasMethod("rdDbHandle", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodrdDbHandle;
		}
		if (SwigDerivedClassHasMethod("rdSoftOwnershipId", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodrdSoftOwnershipId;
		}
		if (SwigDerivedClassHasMethod("rdHardOwnershipId", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodrdHardOwnershipId;
		}
		if (SwigDerivedClassHasMethod("rdHardPointerId", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodrdHardPointerId;
		}
		if (SwigDerivedClassHasMethod("rdSoftPointerId", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodrdSoftPointerId;
		}
		if (SwigDerivedClassHasMethod("rdPoint2d", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodrdPoint2d;
		}
		if (SwigDerivedClassHasMethod("rdPoint3d", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodrdPoint3d;
		}
		if (SwigDerivedClassHasMethod("rdVector2d", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodrdVector2d;
		}
		if (SwigDerivedClassHasMethod("rdVector3d", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodrdVector3d;
		}
		if (SwigDerivedClassHasMethod("rdScale3d", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodrdScale3d;
		}
		if (SwigDerivedClassHasMethod("rdThickness", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodrdThickness;
		}
		if (SwigDerivedClassHasMethod("rdExtrusion", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodrdExtrusion;
		}
		if (SwigDerivedClassHasMethod("wrBool", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodwrBool;
		}
		if (SwigDerivedClassHasMethod("wrString", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodwrString;
		}
		if (SwigDerivedClassHasMethod("wrBytes", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodwrBytes;
		}
		if (SwigDerivedClassHasMethod("wrInt8", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodwrInt8;
		}
		if (SwigDerivedClassHasMethod("wrUInt8", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodwrUInt8;
		}
		if (SwigDerivedClassHasMethod("wrInt16", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodwrInt16;
		}
		if (SwigDerivedClassHasMethod("wrInt32", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodwrInt32;
		}
		if (SwigDerivedClassHasMethod("wrInt64", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodwrInt64;
		}
		if (SwigDerivedClassHasMethod("wrAddress", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodwrAddress;
		}
		if (SwigDerivedClassHasMethod("wrDouble", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodwrDouble;
		}
		if (SwigDerivedClassHasMethod("wrDbHandle", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodwrDbHandle;
		}
		if (SwigDerivedClassHasMethod("wrSoftOwnershipId", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodwrSoftOwnershipId;
		}
		if (SwigDerivedClassHasMethod("wrHardOwnershipId", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodwrHardOwnershipId;
		}
		if (SwigDerivedClassHasMethod("wrSoftPointerId", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodwrSoftPointerId;
		}
		if (SwigDerivedClassHasMethod("wrHardPointerId", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodwrHardPointerId;
		}
		if (SwigDerivedClassHasMethod("wrPoint2d", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodwrPoint2d;
		}
		if (SwigDerivedClassHasMethod("wrPoint3d", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodwrPoint3d;
		}
		if (SwigDerivedClassHasMethod("wrVector2d", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodwrVector2d;
		}
		if (SwigDerivedClassHasMethod("wrVector3d", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodwrVector3d;
		}
		if (SwigDerivedClassHasMethod("wrScale3d", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodwrScale3d;
		}
		if (SwigDerivedClassHasMethod("wrThickness", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodwrThickness;
		}
		if (SwigDerivedClassHasMethod("wrExtrusion", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodwrExtrusion;
		}
		if (SwigDerivedClassHasMethod("usesReferences", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodusesReferences;
		}
		if (SwigDerivedClassHasMethod("addReference", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodaddReference;
		}
		if (SwigDerivedClassHasMethod("isPersistentMode", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodisPersistentMode;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDwgFiler_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbDwgFiler));
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

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDeepCloneFiler : OdDbDwgFiler
{
	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_1();

	public delegate void SwigDelegateOdDbDeepCloneFiler_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbDeepCloneFiler_3();

	public delegate void SwigDelegateOdDbDeepCloneFiler_4();

	public delegate int SwigDelegateOdDbDeepCloneFiler_5();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_6();

	public delegate int SwigDelegateOdDbDeepCloneFiler_7(MaintReleaseVer pMaintReleaseVer);

	public delegate int SwigDelegateOdDbDeepCloneFiler_8();

	public delegate void SwigDelegateOdDbDeepCloneFiler_9(long offset, int seekType);

	public delegate ulong SwigDelegateOdDbDeepCloneFiler_10();

	public delegate bool SwigDelegateOdDbDeepCloneFiler_11();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDeepCloneFiler_12();

	public delegate void SwigDelegateOdDbDeepCloneFiler_13(IntPtr buffer, uint numBytes);

	public delegate sbyte SwigDelegateOdDbDeepCloneFiler_14();

	public delegate byte SwigDelegateOdDbDeepCloneFiler_15();

	public delegate short SwigDelegateOdDbDeepCloneFiler_16();

	public delegate int SwigDelegateOdDbDeepCloneFiler_17();

	public delegate long SwigDelegateOdDbDeepCloneFiler_18();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_19();

	public delegate double SwigDelegateOdDbDeepCloneFiler_20();

	public delegate double SwigDelegateOdDbDeepCloneFiler_21();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_22();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_23();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_24();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_25();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_26();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_27();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_28();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_29();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_30();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_31();

	public delegate double SwigDelegateOdDbDeepCloneFiler_32();

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_33();

	public delegate void SwigDelegateOdDbDeepCloneFiler_34(bool value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_35([MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_36(IntPtr buffer);

	public delegate void SwigDelegateOdDbDeepCloneFiler_37(sbyte value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_38(byte value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_39(short value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_40(int value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_41(long value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_42(IntPtr value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_43(double value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_44(IntPtr value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_45(IntPtr value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_46(IntPtr value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_47(IntPtr value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_48(IntPtr value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_49(IntPtr value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_50(IntPtr value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_51(IntPtr value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_52(IntPtr value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_53(IntPtr value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_54(double value);

	public delegate void SwigDelegateOdDbDeepCloneFiler_55(IntPtr value);

	public delegate bool SwigDelegateOdDbDeepCloneFiler_56();

	public delegate void SwigDelegateOdDbDeepCloneFiler_57(IntPtr id, int rt);

	public delegate bool SwigDelegateOdDbDeepCloneFiler_58();

	public delegate void SwigDelegateOdDbDeepCloneFiler_59();

	public delegate bool SwigDelegateOdDbDeepCloneFiler_60(IntPtr objectId);

	public delegate IntPtr SwigDelegateOdDbDeepCloneFiler_61();

	public delegate void SwigDelegateOdDbDeepCloneFiler_62();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbDeepCloneFiler_0 swigDelegate0;

	private SwigDelegateOdDbDeepCloneFiler_1 swigDelegate1;

	private SwigDelegateOdDbDeepCloneFiler_2 swigDelegate2;

	private SwigDelegateOdDbDeepCloneFiler_3 swigDelegate3;

	private SwigDelegateOdDbDeepCloneFiler_4 swigDelegate4;

	private SwigDelegateOdDbDeepCloneFiler_5 swigDelegate5;

	private SwigDelegateOdDbDeepCloneFiler_6 swigDelegate6;

	private SwigDelegateOdDbDeepCloneFiler_7 swigDelegate7;

	private SwigDelegateOdDbDeepCloneFiler_8 swigDelegate8;

	private SwigDelegateOdDbDeepCloneFiler_9 swigDelegate9;

	private SwigDelegateOdDbDeepCloneFiler_10 swigDelegate10;

	private SwigDelegateOdDbDeepCloneFiler_11 swigDelegate11;

	private SwigDelegateOdDbDeepCloneFiler_12 swigDelegate12;

	private SwigDelegateOdDbDeepCloneFiler_13 swigDelegate13;

	private SwigDelegateOdDbDeepCloneFiler_14 swigDelegate14;

	private SwigDelegateOdDbDeepCloneFiler_15 swigDelegate15;

	private SwigDelegateOdDbDeepCloneFiler_16 swigDelegate16;

	private SwigDelegateOdDbDeepCloneFiler_17 swigDelegate17;

	private SwigDelegateOdDbDeepCloneFiler_18 swigDelegate18;

	private SwigDelegateOdDbDeepCloneFiler_19 swigDelegate19;

	private SwigDelegateOdDbDeepCloneFiler_20 swigDelegate20;

	private SwigDelegateOdDbDeepCloneFiler_21 swigDelegate21;

	private SwigDelegateOdDbDeepCloneFiler_22 swigDelegate22;

	private SwigDelegateOdDbDeepCloneFiler_23 swigDelegate23;

	private SwigDelegateOdDbDeepCloneFiler_24 swigDelegate24;

	private SwigDelegateOdDbDeepCloneFiler_25 swigDelegate25;

	private SwigDelegateOdDbDeepCloneFiler_26 swigDelegate26;

	private SwigDelegateOdDbDeepCloneFiler_27 swigDelegate27;

	private SwigDelegateOdDbDeepCloneFiler_28 swigDelegate28;

	private SwigDelegateOdDbDeepCloneFiler_29 swigDelegate29;

	private SwigDelegateOdDbDeepCloneFiler_30 swigDelegate30;

	private SwigDelegateOdDbDeepCloneFiler_31 swigDelegate31;

	private SwigDelegateOdDbDeepCloneFiler_32 swigDelegate32;

	private SwigDelegateOdDbDeepCloneFiler_33 swigDelegate33;

	private SwigDelegateOdDbDeepCloneFiler_34 swigDelegate34;

	private SwigDelegateOdDbDeepCloneFiler_35 swigDelegate35;

	private SwigDelegateOdDbDeepCloneFiler_36 swigDelegate36;

	private SwigDelegateOdDbDeepCloneFiler_37 swigDelegate37;

	private SwigDelegateOdDbDeepCloneFiler_38 swigDelegate38;

	private SwigDelegateOdDbDeepCloneFiler_39 swigDelegate39;

	private SwigDelegateOdDbDeepCloneFiler_40 swigDelegate40;

	private SwigDelegateOdDbDeepCloneFiler_41 swigDelegate41;

	private SwigDelegateOdDbDeepCloneFiler_42 swigDelegate42;

	private SwigDelegateOdDbDeepCloneFiler_43 swigDelegate43;

	private SwigDelegateOdDbDeepCloneFiler_44 swigDelegate44;

	private SwigDelegateOdDbDeepCloneFiler_45 swigDelegate45;

	private SwigDelegateOdDbDeepCloneFiler_46 swigDelegate46;

	private SwigDelegateOdDbDeepCloneFiler_47 swigDelegate47;

	private SwigDelegateOdDbDeepCloneFiler_48 swigDelegate48;

	private SwigDelegateOdDbDeepCloneFiler_49 swigDelegate49;

	private SwigDelegateOdDbDeepCloneFiler_50 swigDelegate50;

	private SwigDelegateOdDbDeepCloneFiler_51 swigDelegate51;

	private SwigDelegateOdDbDeepCloneFiler_52 swigDelegate52;

	private SwigDelegateOdDbDeepCloneFiler_53 swigDelegate53;

	private SwigDelegateOdDbDeepCloneFiler_54 swigDelegate54;

	private SwigDelegateOdDbDeepCloneFiler_55 swigDelegate55;

	private SwigDelegateOdDbDeepCloneFiler_56 swigDelegate56;

	private SwigDelegateOdDbDeepCloneFiler_57 swigDelegate57;

	private SwigDelegateOdDbDeepCloneFiler_58 swigDelegate58;

	private SwigDelegateOdDbDeepCloneFiler_59 swigDelegate59;

	private SwigDelegateOdDbDeepCloneFiler_60 swigDelegate60;

	private SwigDelegateOdDbDeepCloneFiler_61 swigDelegate61;

	private SwigDelegateOdDbDeepCloneFiler_62 swigDelegate62;

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

	private static Type[] swigMethodTypes59 = new Type[0];

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes61 = new Type[0];

	private static Type[] swigMethodTypes62 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDeepCloneFiler(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDeepCloneFiler obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDeepCloneFiler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdDbDeepCloneFiler()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDeepCloneFiler(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbDeepCloneFiler) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdDbDeepCloneFiler cast(OdRxObject pObj)
	{
		OdDbDeepCloneFiler rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDeepCloneFiler>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_isASwigExplicitOdDbDeepCloneFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_queryXSwigExplicitOdDbDeepCloneFiler(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbDeepCloneFiler createObject()
	{
		OdDbDeepCloneFiler rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDeepCloneFiler>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_createObject__SWIG_0(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbDeepCloneFiler createObject(OdDbIdMapping pIdMapping)
	{
		OdDbDeepCloneFiler rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDeepCloneFiler>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_createObject__SWIG_1(OdDbIdMapping.getCPtr(pIdMapping)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void start()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_start(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool nextReference(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_nextReference(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbIdMapping idMapping()
	{
		OdDbIdMapping rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_idMapping(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void defaultProcessReferences()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_defaultProcessReferences(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("start", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodstart;
		}
		if (SwigDerivedClassHasMethod("nextReference", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodnextReference;
		}
		if (SwigDerivedClassHasMethod("idMapping", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodidMapping;
		}
		if (SwigDerivedClassHasMethod("defaultProcessReferences", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethoddefaultProcessReferences;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDeepCloneFiler_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbDeepCloneFiler));
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

	private void SwigDirectorMethodstart()
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

	private bool SwigDirectorMethodnextReference(IntPtr objectId)
	{
		return nextReference(new OdDbObjectId(objectId, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodidMapping()
	{
		return OdDbIdMapping.getCPtr(idMapping()).Handle;
	}

	private void SwigDirectorMethoddefaultProcessReferences()
	{
		try
		{
			defaultProcessReferences();
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

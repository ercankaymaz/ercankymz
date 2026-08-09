using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbBaseDatabasePE : OdRxObject
{
	public class DatabaseUnloadReactor : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DatabaseUnloadReactor(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(DatabaseUnloadReactor obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~DatabaseUnloadReactor()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			lock (this)
			{
				if (swigCPtr.Handle != IntPtr.Zero)
				{
					if (swigCMemOwn)
					{
						swigCMemOwn = false;
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbBaseDatabasePE_DatabaseUnloadReactor(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public virtual void goodbye(OdRxObject pDb)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_DatabaseUnloadReactor_goodbye(swigCPtr, OdRxObject.getCPtr(pDb));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_1();

	public delegate void SwigDelegateOdDbBaseDatabasePE_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_3(IntPtr pDb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseDatabasePE_4(IntPtr pDb);

	public delegate void SwigDelegateOdDbBaseDatabasePE_5(IntPtr pDb);

	public delegate void SwigDelegateOdDbBaseDatabasePE_6(IntPtr pDb);

	public delegate int SwigDelegateOdDbBaseDatabasePE_7(IntPtr pDb);

	public delegate int SwigDelegateOdDbBaseDatabasePE_8(IntPtr pDb, int nContext);

	public delegate int SwigDelegateOdDbBaseDatabasePE_9(IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_10(IntPtr pDb);

	public delegate void SwigDelegateOdDbBaseDatabasePE_11(IntPtr pDb, IntPtr layoutId, IntPtr names, IntPtr points, IntPtr pDevice);

	public delegate void SwigDelegateOdDbBaseDatabasePE_12(IntPtr pDb, IntPtr layoutId, IntPtr names, IntPtr points);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_13(IntPtr db, [MarshalAs(UnmanagedType.LPWStr)] string textString, int length, bool raw, IntPtr pTextStyle);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_14(IntPtr pDevice, IntPtr pGiCtx);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_15(IntPtr pDevice, IntPtr pGiCtx, IntPtr layoutId);

	public delegate void SwigDelegateOdDbBaseDatabasePE_16(IntPtr device, IntPtr giContext, IntPtr layoutId, uint palBg);

	public delegate void SwigDelegateOdDbBaseDatabasePE_17(IntPtr device, IntPtr giContext, IntPtr layoutId);

	public delegate void SwigDelegateOdDbBaseDatabasePE_18(IntPtr device, IntPtr giContext);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_19(IntPtr pGiCtx, IntPtr arg1);

	public delegate void SwigDelegateOdDbBaseDatabasePE_20(IntPtr clipBox, IntPtr pDevice, IntPtr db, uint extentsFlags, uint dpi);

	public delegate void SwigDelegateOdDbBaseDatabasePE_21(IntPtr clipBox, IntPtr pDevice, IntPtr db, uint extentsFlags);

	public delegate void SwigDelegateOdDbBaseDatabasePE_22(IntPtr clipBox, IntPtr pDevice, IntPtr db);

	public delegate void SwigDelegateOdDbBaseDatabasePE_23(IntPtr outputRect, IntPtr pDevice, IntPtr db, IntPtr plotExtents, uint extentsFlags, IntPtr objectId);

	public delegate void SwigDelegateOdDbBaseDatabasePE_24(IntPtr outputRect, IntPtr pDevice, IntPtr db, IntPtr plotExtents, uint extentsFlags);

	public delegate void SwigDelegateOdDbBaseDatabasePE_25(IntPtr outputRect, IntPtr pDevice, IntPtr db, IntPtr plotExtents);

	public delegate void SwigDelegateOdDbBaseDatabasePE_26(IntPtr pDwgContext, IntPtr db);

	public delegate bool SwigDelegateOdDbBaseDatabasePE_27(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_28(IntPtr db);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_29(IntPtr db, IntPtr arg1);

	public delegate void SwigDelegateOdDbBaseDatabasePE_30(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_31(IntPtr db);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_32(IntPtr db, [MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate void SwigDelegateOdDbBaseDatabasePE_33(IntPtr db, [MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate void SwigDelegateOdDbBaseDatabasePE_34(IntPtr pDb, IntPtr id);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_35(IntPtr db);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_36(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_37(IntPtr db, IntPtr pViewportId);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_38(IntPtr db, [MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_39(IntPtr db);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_40(IntPtr db);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_41(IntPtr db);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseDatabasePE_42(IntPtr db);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseDatabasePE_43(IntPtr db);

	public delegate int SwigDelegateOdDbBaseDatabasePE_44(IntPtr db);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_45(IntPtr db);

	public delegate int SwigDelegateOdDbBaseDatabasePE_46(IntPtr db);

	public delegate bool SwigDelegateOdDbBaseDatabasePE_47(IntPtr db, IntPtr pLTypeId, IntPtr LType);

	public delegate bool SwigDelegateOdDbBaseDatabasePE_48(IntPtr db, IntPtr idStyle, IntPtr shapeInfo);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_49(IntPtr obj);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_50(IntPtr db, ulong handle);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_51(IntPtr id);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_52(IntPtr id);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_53(IntPtr id);

	public delegate int SwigDelegateOdDbBaseDatabasePE_54(IntPtr db);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_55(IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_56(IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_57(IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_58(IntPtr pDb);

	public delegate void SwigDelegateOdDbBaseDatabasePE_59(IntPtr pDb, bool bOn);

	public delegate bool SwigDelegateOdDbBaseDatabasePE_60(IntPtr pDb);

	public delegate bool SwigDelegateOdDbBaseDatabasePE_61(IntPtr pDrw);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_62(IntPtr pId);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_63(IntPtr pId, bool bForWrite);

	public delegate bool SwigDelegateOdDbBaseDatabasePE_64(IntPtr pObj);

	public delegate void SwigDelegateOdDbBaseDatabasePE_65(IntPtr pObj);

	public delegate bool SwigDelegateOdDbBaseDatabasePE_66(IntPtr drawableId, IntPtr res);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_67(IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_68(IntPtr pDb, IntPtr pPrevReactor, IntPtr pReactorRedirect);

	public delegate void SwigDelegateOdDbBaseDatabasePE_69(IntPtr pDb, IntPtr pReactor);

	public delegate int SwigDelegateOdDbBaseDatabasePE_70(IntPtr material, IntPtr pSourceDb, IntPtr pDestinationDb, IntPtr pMaterialTraits, IntPtr pMaterialMapper, IntPtr pMaterialColor);

	public delegate int SwigDelegateOdDbBaseDatabasePE_71(IntPtr material, IntPtr pSourceDb, IntPtr pDestinationDb, IntPtr pMaterialTraits, IntPtr pMaterialMapper);

	public delegate int SwigDelegateOdDbBaseDatabasePE_72(IntPtr material, IntPtr pSourceDb, IntPtr pDestinationDb, IntPtr pMaterialTraits);

	public delegate bool SwigDelegateOdDbBaseDatabasePE_73(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_74(IntPtr pDb, IntPtr pDevice, IntPtr pView);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_75(IntPtr pDb, IntPtr pDevice);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_76(IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbBaseDatabasePE_77(IntPtr pDb, IntPtr pSSet);

	public delegate short SwigDelegateOdDbBaseDatabasePE_78(IntPtr arg0, short color);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBaseDatabasePE_0 swigDelegate0;

	private SwigDelegateOdDbBaseDatabasePE_1 swigDelegate1;

	private SwigDelegateOdDbBaseDatabasePE_2 swigDelegate2;

	private SwigDelegateOdDbBaseDatabasePE_3 swigDelegate3;

	private SwigDelegateOdDbBaseDatabasePE_4 swigDelegate4;

	private SwigDelegateOdDbBaseDatabasePE_5 swigDelegate5;

	private SwigDelegateOdDbBaseDatabasePE_6 swigDelegate6;

	private SwigDelegateOdDbBaseDatabasePE_7 swigDelegate7;

	private SwigDelegateOdDbBaseDatabasePE_8 swigDelegate8;

	private SwigDelegateOdDbBaseDatabasePE_9 swigDelegate9;

	private SwigDelegateOdDbBaseDatabasePE_10 swigDelegate10;

	private SwigDelegateOdDbBaseDatabasePE_11 swigDelegate11;

	private SwigDelegateOdDbBaseDatabasePE_12 swigDelegate12;

	private SwigDelegateOdDbBaseDatabasePE_13 swigDelegate13;

	private SwigDelegateOdDbBaseDatabasePE_14 swigDelegate14;

	private SwigDelegateOdDbBaseDatabasePE_15 swigDelegate15;

	private SwigDelegateOdDbBaseDatabasePE_16 swigDelegate16;

	private SwigDelegateOdDbBaseDatabasePE_17 swigDelegate17;

	private SwigDelegateOdDbBaseDatabasePE_18 swigDelegate18;

	private SwigDelegateOdDbBaseDatabasePE_19 swigDelegate19;

	private SwigDelegateOdDbBaseDatabasePE_20 swigDelegate20;

	private SwigDelegateOdDbBaseDatabasePE_21 swigDelegate21;

	private SwigDelegateOdDbBaseDatabasePE_22 swigDelegate22;

	private SwigDelegateOdDbBaseDatabasePE_23 swigDelegate23;

	private SwigDelegateOdDbBaseDatabasePE_24 swigDelegate24;

	private SwigDelegateOdDbBaseDatabasePE_25 swigDelegate25;

	private SwigDelegateOdDbBaseDatabasePE_26 swigDelegate26;

	private SwigDelegateOdDbBaseDatabasePE_27 swigDelegate27;

	private SwigDelegateOdDbBaseDatabasePE_28 swigDelegate28;

	private SwigDelegateOdDbBaseDatabasePE_29 swigDelegate29;

	private SwigDelegateOdDbBaseDatabasePE_30 swigDelegate30;

	private SwigDelegateOdDbBaseDatabasePE_31 swigDelegate31;

	private SwigDelegateOdDbBaseDatabasePE_32 swigDelegate32;

	private SwigDelegateOdDbBaseDatabasePE_33 swigDelegate33;

	private SwigDelegateOdDbBaseDatabasePE_34 swigDelegate34;

	private SwigDelegateOdDbBaseDatabasePE_35 swigDelegate35;

	private SwigDelegateOdDbBaseDatabasePE_36 swigDelegate36;

	private SwigDelegateOdDbBaseDatabasePE_37 swigDelegate37;

	private SwigDelegateOdDbBaseDatabasePE_38 swigDelegate38;

	private SwigDelegateOdDbBaseDatabasePE_39 swigDelegate39;

	private SwigDelegateOdDbBaseDatabasePE_40 swigDelegate40;

	private SwigDelegateOdDbBaseDatabasePE_41 swigDelegate41;

	private SwigDelegateOdDbBaseDatabasePE_42 swigDelegate42;

	private SwigDelegateOdDbBaseDatabasePE_43 swigDelegate43;

	private SwigDelegateOdDbBaseDatabasePE_44 swigDelegate44;

	private SwigDelegateOdDbBaseDatabasePE_45 swigDelegate45;

	private SwigDelegateOdDbBaseDatabasePE_46 swigDelegate46;

	private SwigDelegateOdDbBaseDatabasePE_47 swigDelegate47;

	private SwigDelegateOdDbBaseDatabasePE_48 swigDelegate48;

	private SwigDelegateOdDbBaseDatabasePE_49 swigDelegate49;

	private SwigDelegateOdDbBaseDatabasePE_50 swigDelegate50;

	private SwigDelegateOdDbBaseDatabasePE_51 swigDelegate51;

	private SwigDelegateOdDbBaseDatabasePE_52 swigDelegate52;

	private SwigDelegateOdDbBaseDatabasePE_53 swigDelegate53;

	private SwigDelegateOdDbBaseDatabasePE_54 swigDelegate54;

	private SwigDelegateOdDbBaseDatabasePE_55 swigDelegate55;

	private SwigDelegateOdDbBaseDatabasePE_56 swigDelegate56;

	private SwigDelegateOdDbBaseDatabasePE_57 swigDelegate57;

	private SwigDelegateOdDbBaseDatabasePE_58 swigDelegate58;

	private SwigDelegateOdDbBaseDatabasePE_59 swigDelegate59;

	private SwigDelegateOdDbBaseDatabasePE_60 swigDelegate60;

	private SwigDelegateOdDbBaseDatabasePE_61 swigDelegate61;

	private SwigDelegateOdDbBaseDatabasePE_62 swigDelegate62;

	private SwigDelegateOdDbBaseDatabasePE_63 swigDelegate63;

	private SwigDelegateOdDbBaseDatabasePE_64 swigDelegate64;

	private SwigDelegateOdDbBaseDatabasePE_65 swigDelegate65;

	private SwigDelegateOdDbBaseDatabasePE_66 swigDelegate66;

	private SwigDelegateOdDbBaseDatabasePE_67 swigDelegate67;

	private SwigDelegateOdDbBaseDatabasePE_68 swigDelegate68;

	private SwigDelegateOdDbBaseDatabasePE_69 swigDelegate69;

	private SwigDelegateOdDbBaseDatabasePE_70 swigDelegate70;

	private SwigDelegateOdDbBaseDatabasePE_71 swigDelegate71;

	private SwigDelegateOdDbBaseDatabasePE_72 swigDelegate72;

	private SwigDelegateOdDbBaseDatabasePE_73 swigDelegate73;

	private SwigDelegateOdDbBaseDatabasePE_74 swigDelegate74;

	private SwigDelegateOdDbBaseDatabasePE_75 swigDelegate75;

	private SwigDelegateOdDbBaseDatabasePE_76 swigDelegate76;

	private SwigDelegateOdDbBaseDatabasePE_77 swigDelegate77;

	private SwigDelegateOdDbBaseDatabasePE_78 swigDelegate78;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(int)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes11 = new Type[5]
	{
		typeof(OdRxObject),
		typeof(OdDbStub),
		typeof(OdStringArray),
		typeof(OdGePoint3dArray),
		typeof(OdGsDevice)
	};

	private static Type[] swigMethodTypes12 = new Type[4]
	{
		typeof(OdRxObject),
		typeof(OdDbStub),
		typeof(OdStringArray),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes13 = new Type[5]
	{
		typeof(OdRxObject),
		typeof(string),
		typeof(int),
		typeof(bool),
		typeof(OdGiTextStyle)
	};

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(OdGsDevice),
		typeof(OdGiDefaultContext)
	};

	private static Type[] swigMethodTypes15 = new Type[3]
	{
		typeof(OdGsDevice),
		typeof(OdGiDefaultContext),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes16 = new Type[4]
	{
		typeof(OdGsDevice),
		typeof(OdGiDefaultContext),
		typeof(OdDbStub),
		typeof(uint)
	};

	private static Type[] swigMethodTypes17 = new Type[3]
	{
		typeof(OdGsDevice),
		typeof(OdGiDefaultContext),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes18 = new Type[2]
	{
		typeof(OdGsDevice),
		typeof(OdGiDefaultContext)
	};

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(OdGiDefaultContext),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes20 = new Type[5]
	{
		typeof(OdGsDCRect),
		typeof(OdGsDevice),
		typeof(OdRxObject),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes21 = new Type[4]
	{
		typeof(OdGsDCRect),
		typeof(OdGsDevice),
		typeof(OdRxObject),
		typeof(uint)
	};

	private static Type[] swigMethodTypes22 = new Type[3]
	{
		typeof(OdGsDCRect),
		typeof(OdGsDevice),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes23 = new Type[6]
	{
		typeof(OdGsDCRect),
		typeof(OdGsDevice),
		typeof(OdRxObject),
		typeof(OdGeBoundBlock3d),
		typeof(uint),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes24 = new Type[5]
	{
		typeof(OdGsDCRect),
		typeof(OdGsDevice),
		typeof(OdRxObject),
		typeof(OdGeBoundBlock3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes25 = new Type[4]
	{
		typeof(OdGsDCRect),
		typeof(OdGsDevice),
		typeof(OdRxObject),
		typeof(OdGeBoundBlock3d)
	};

	private static Type[] swigMethodTypes26 = new Type[2]
	{
		typeof(OdGiDefaultContext),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes29 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGiContext)
	};

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes32 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes33 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes34 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes35 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes36 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes37 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes38 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes39 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes45 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes46 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes47 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdDbStub),
		typeof(OdGiLinetype)
	};

	private static Type[] swigMethodTypes48 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdDbStub),
		typeof(OdGiTextStyle)
	};

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes50 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(ulong)
	};

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes54 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes56 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes59 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes63 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(bool)
	};

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes65 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes66 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdGiAnnoScaleSet)
	};

	private static Type[] swigMethodTypes67 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes68 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdRxObject),
		typeof(DatabaseUnloadReactor)
	};

	private static Type[] swigMethodTypes69 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes70 = new Type[6]
	{
		typeof(OdDbStub).MakeByRefType(),
		typeof(OdRxObject),
		typeof(OdRxObject),
		typeof(OdGiMaterialTraits),
		typeof(OdGiMapper),
		typeof(OdCmEntityColor)
	};

	private static Type[] swigMethodTypes71 = new Type[5]
	{
		typeof(OdDbStub).MakeByRefType(),
		typeof(OdRxObject),
		typeof(OdRxObject),
		typeof(OdGiMaterialTraits),
		typeof(OdGiMapper)
	};

	private static Type[] swigMethodTypes72 = new Type[4]
	{
		typeof(OdDbStub).MakeByRefType(),
		typeof(OdRxObject),
		typeof(OdRxObject),
		typeof(OdGiMaterialTraits)
	};

	private static Type[] swigMethodTypes73 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes74 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdGsDevice),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes75 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGsDevice)
	};

	private static Type[] swigMethodTypes76 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes77 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes78 = new Type[2]
	{
		typeof(OdRxObject).MakeByRefType(),
		typeof(short).MakeByRefType()
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBaseDatabasePE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBaseDatabasePE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbBaseDatabasePE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBaseDatabasePE cast(OdRxObject pObj)
	{
		OdDbBaseDatabasePE rXObject = Helpers.GetRXObject<OdDbBaseDatabasePE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_isASwigExplicitOdDbBaseDatabasePE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_queryXSwigExplicitOdDbBaseDatabasePE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseDatabasePE createObject()
	{
		OdDbBaseDatabasePE rXObject = Helpers.GetRXObject<OdDbBaseDatabasePE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbBaseHostAppServices appServices(OdRxObject pDb)
	{
		OdDbBaseHostAppServices rXObject = Helpers.GetRXObject<OdDbBaseHostAppServices>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_appServices(swigCPtr, OdRxObject.getCPtr(pDb)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string getFilename(OdRxObject pDb)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getFilename(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void startTransaction(OdRxObject pDb)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_startTransaction(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortTransaction(OdRxObject pDb)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_abortTransaction(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult startUndoRecord(OdRxObject pDb)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_startUndoRecord(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult evaluateFields(OdRxObject pDb, int nContext)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_evaluateFields(swigCPtr, OdRxObject.getCPtr(pDb), nContext);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult undo(OdRxObject pDb)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_undo(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdGiDefaultContext createGiContext(OdRxObject pDb)
	{
		OdGiDefaultContext rXObject = Helpers.GetRXObject<OdGiDefaultContext>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_createGiContext(swigCPtr, OdRxObject.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void putNamedViewInfo(OdRxObject pDb, OdDbStub layoutId, OdStringArray names, OdGePoint3dArray points, OdGsDevice pDevice)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_putNamedViewInfo__SWIG_0(swigCPtr, OdRxObject.getCPtr(pDb), OdDbStub.getCPtr(layoutId), OdStringArray.getCPtr(names), OdGePoint3dArray.getCPtr(points), OdGsDevice.getCPtr(pDevice));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void putNamedViewInfo(OdRxObject pDb, OdDbStub layoutId, OdStringArray names, OdGePoint3dArray points)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_putNamedViewInfo__SWIG_1(swigCPtr, OdRxObject.getCPtr(pDb), OdDbStub.getCPtr(layoutId), OdStringArray.getCPtr(names), OdGePoint3dArray.getCPtr(points));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdBaseTextIterator createTextIterator(OdRxObject db, string textString, int length, bool raw, OdGiTextStyle pTextStyle)
	{
		OdBaseTextIterator rXObject = Helpers.GetRXObject<OdBaseTextIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_createTextIterator(swigCPtr, OdRxObject.getCPtr(db), textString, length, raw, OdGiTextStyle.getCPtr(pTextStyle)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsDevice setupActiveLayoutViews(OdGsDevice pDevice, OdGiDefaultContext pGiCtx)
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_setupActiveLayoutViews(swigCPtr, OdGsDevice.getCPtr(pDevice), OdGiDefaultContext.getCPtr(pGiCtx)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsDevice setupLayoutView(OdGsDevice pDevice, OdGiDefaultContext pGiCtx, OdDbStub layoutId)
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_setupLayoutView(swigCPtr, OdGsDevice.getCPtr(pDevice), OdGiDefaultContext.getCPtr(pGiCtx), OdDbStub.getCPtr(layoutId)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setupPalette(OdGsDevice device, OdGiDefaultContext giContext, OdDbStub layoutId, uint palBg)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_setupPalette__SWIG_0(swigCPtr, OdGsDevice.getCPtr(device), OdGiDefaultContext.getCPtr(giContext), OdDbStub.getCPtr(layoutId), palBg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setupPalette(OdGsDevice device, OdGiDefaultContext giContext, OdDbStub layoutId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_setupPalette__SWIG_1(swigCPtr, OdGsDevice.getCPtr(device), OdGiDefaultContext.getCPtr(giContext), OdDbStub.getCPtr(layoutId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setupPalette(OdGsDevice device, OdGiDefaultContext giContext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_setupPalette__SWIG_2(swigCPtr, OdGsDevice.getCPtr(device), OdGiDefaultContext.getCPtr(giContext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub getNextViewForActiveLayout(OdGiDefaultContext pGiCtx, OdDbStub arg1)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getNextViewForActiveLayout(swigCPtr, OdGiDefaultContext.getCPtr(pGiCtx), OdDbStub.getCPtr(arg1));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void applyLayoutSettings(OdGsDCRect clipBox, OdGsDevice pDevice, OdRxObject db, uint extentsFlags, uint dpi)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_applyLayoutSettings__SWIG_0(swigCPtr, OdGsDCRect.getCPtr(clipBox), OdGsDevice.getCPtr(pDevice), OdRxObject.getCPtr(db), extentsFlags, dpi);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void applyLayoutSettings(OdGsDCRect clipBox, OdGsDevice pDevice, OdRxObject db, uint extentsFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_applyLayoutSettings__SWIG_1(swigCPtr, OdGsDCRect.getCPtr(clipBox), OdGsDevice.getCPtr(pDevice), OdRxObject.getCPtr(db), extentsFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void applyLayoutSettings(OdGsDCRect clipBox, OdGsDevice pDevice, OdRxObject db)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_applyLayoutSettings__SWIG_2(swigCPtr, OdGsDCRect.getCPtr(clipBox), OdGsDevice.getCPtr(pDevice), OdRxObject.getCPtr(db));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void zoomToExtents(OdGsDCRect outputRect, OdGsDevice pDevice, OdRxObject db, OdGeBoundBlock3d plotExtents, uint extentsFlags, OdDbStub objectId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_zoomToExtents__SWIG_0(swigCPtr, OdGsDCRect.getCPtr(outputRect), OdGsDevice.getCPtr(pDevice), OdRxObject.getCPtr(db), OdGeBoundBlock3d.getCPtr(plotExtents), extentsFlags, OdDbStub.getCPtr(objectId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void zoomToExtents(OdGsDCRect outputRect, OdGsDevice pDevice, OdRxObject db, OdGeBoundBlock3d plotExtents, uint extentsFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_zoomToExtents__SWIG_1(swigCPtr, OdGsDCRect.getCPtr(outputRect), OdGsDevice.getCPtr(pDevice), OdRxObject.getCPtr(db), OdGeBoundBlock3d.getCPtr(plotExtents), extentsFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void zoomToExtents(OdGsDCRect outputRect, OdGsDevice pDevice, OdRxObject db, OdGeBoundBlock3d plotExtents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_zoomToExtents__SWIG_2(swigCPtr, OdGsDCRect.getCPtr(outputRect), OdGsDevice.getCPtr(pDevice), OdRxObject.getCPtr(db), OdGeBoundBlock3d.getCPtr(plotExtents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void loadPlotstyleTableForActiveLayout(OdGiDefaultContext pDwgContext, OdRxObject db)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_loadPlotstyleTableForActiveLayout(swigCPtr, OdGiDefaultContext.getCPtr(pDwgContext), OdRxObject.getCPtr(db));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isContextDependentLayers(OdRxObject arg0)
	{
		bool result = (SwigDerivedClassHasMethod("isContextDependentLayers", swigMethodTypes27) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_isContextDependentLayersSwigExplicitOdDbBaseDatabasePE(swigCPtr, OdRxObject.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_isContextDependentLayers(swigCPtr, OdRxObject.getCPtr(arg0)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxIterator layers(OdRxObject db)
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_layers__SWIG_0(swigCPtr, OdRxObject.getCPtr(db)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxIterator layers(OdRxObject db, OdGiContext arg1)
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(SwigDerivedClassHasMethod("layers", swigMethodTypes29) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_layersSwigExplicitOdDbBaseDatabasePE__SWIG_1(swigCPtr, OdRxObject.getCPtr(db), OdGiContext.getCPtr(arg1)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_layers__SWIG_1(swigCPtr, OdRxObject.getCPtr(db), OdGiContext.getCPtr(arg1)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void loadXrefs(OdRxObject arg0)
	{
		if (SwigDerivedClassHasMethod("loadXrefs", swigMethodTypes30))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_loadXrefsSwigExplicitOdDbBaseDatabasePE(swigCPtr, OdRxObject.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_loadXrefs(swigCPtr, OdRxObject.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxIterator visualStyles(OdRxObject db)
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_visualStyles(swigCPtr, OdRxObject.getCPtr(db)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbStub getVisualStyleId(OdRxObject db, string name)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getVisualStyleId(swigCPtr, OdRxObject.getCPtr(db), name);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObject currentLayout(OdRxObject pDb)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_currentLayout(swigCPtr, OdRxObject.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setCurrentLayout(OdRxObject db, string name)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_setCurrentLayout(swigCPtr, OdRxObject.getCPtr(db), name);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCurrentLayoutId(OdRxObject pDb, OdDbStub id)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_setCurrentLayoutId(swigCPtr, OdRxObject.getCPtr(pDb), OdDbStub.getCPtr(id));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxIterator layouts(OdRxObject db)
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_layouts(swigCPtr, OdRxObject.getCPtr(db)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject getLayout(OdRxObject pDb, string name)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("getLayout", swigMethodTypes36) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getLayoutSwigExplicitOdDbBaseDatabasePE(swigCPtr, OdRxObject.getCPtr(pDb), name) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getLayout(swigCPtr, OdRxObject.getCPtr(pDb), name), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxObject findLayoutByViewport(OdRxObject db, OdDbStub pViewportId)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_findLayoutByViewport(swigCPtr, OdRxObject.getCPtr(db), OdDbStub.getCPtr(pViewportId)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbStub findLayoutIdByViewport(OdRxObject db, OdDbStub pViewportId)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_findLayoutIdByViewport(swigCPtr, OdRxObject.getCPtr(db), OdDbStub.getCPtr(pViewportId));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub findLayoutNamed(OdRxObject db, string name)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_findLayoutNamed(swigCPtr, OdRxObject.getCPtr(db), name);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObject getFirstLayout(OdRxObject db)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getFirstLayout(swigCPtr, OdRxObject.getCPtr(db)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbStub getFirstLayoutId(OdRxObject db)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getFirstLayoutId(swigCPtr, OdRxObject.getCPtr(db));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdTimeStamp getCreationTime(OdRxObject db)
	{
		OdTimeStamp result = new OdTimeStamp(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getCreationTime(swigCPtr, OdRxObject.getCPtr(db)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdTimeStamp getUpdateTime(OdRxObject db)
	{
		OdTimeStamp result = new OdTimeStamp(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getUpdateTime(swigCPtr, OdRxObject.getCPtr(db)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFingerPrintGuid(OdRxObject db)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getFingerPrintGuid(swigCPtr, OdRxObject.getCPtr(db));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getVersionGuid(OdRxObject db)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getVersionGuid(swigCPtr, OdRxObject.getCPtr(db));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getUnits(OdRxObject db)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getUnits(swigCPtr, OdRxObject.getCPtr(db));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdUnitsFormatter baseFormatter(OdRxObject db)
	{
		OdUnitsFormatter rXObject = Helpers.GetRXObject<OdUnitsFormatter>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_baseFormatter(swigCPtr, OdRxObject.getCPtr(db)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual int getMeasurement(OdRxObject db)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getMeasurement(swigCPtr, OdRxObject.getCPtr(db));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getLineTypeById(OdRxObject db, OdDbStub pLTypeId, OdGiLinetype LType)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getLineTypeById(swigCPtr, OdRxObject.getCPtr(db), OdDbStub.getCPtr(pLTypeId), OdGiLinetype.getCPtr(LType));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getTextStyleById(OdRxObject db, OdDbStub idStyle, OdGiTextStyle shapeInfo)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getTextStyleById(swigCPtr, OdRxObject.getCPtr(db), OdDbStub.getCPtr(idStyle), OdGiTextStyle.getCPtr(shapeInfo));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub getId(OdRxObject obj)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getId(swigCPtr, OdRxObject.getCPtr(obj));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub getObject(OdRxObject db, ulong handle)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getObject(swigCPtr, OdRxObject.getCPtr(db), handle);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbHandle getHandle(OdDbStub id)
	{
		OdDbHandle result = new OdDbHandle(SwigDerivedClassHasMethod("getHandle", swigMethodTypes51) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getHandleSwigExplicitOdDbBaseDatabasePE(swigCPtr, OdDbStub.getCPtr(id)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getHandle(swigCPtr, OdDbStub.getCPtr(id)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxObject getDatabase(OdDbStub id)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("getDatabase", swigMethodTypes52) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getDatabaseSwigExplicitOdDbBaseDatabasePE(swigCPtr, OdDbStub.getCPtr(id)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getDatabase(swigCPtr, OdDbStub.getCPtr(id)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbStub getOwner(OdDbStub id)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("getOwner", swigMethodTypes53) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getOwnerSwigExplicitOdDbBaseDatabasePE(swigCPtr, OdDbStub.getCPtr(id)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getOwner(swigCPtr, OdDbStub.getCPtr(id)));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCodePageId getCodePage(OdRxObject db)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getCodePage(swigCPtr, OdRxObject.getCPtr(db));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCodePageId)result;
	}

	public virtual OdDbStub getModelBlockId(OdRxObject pDb)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getModelBlockId(swigCPtr, OdRxObject.getCPtr(pDb));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub getPaperBlockId(OdRxObject pDb)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getPaperBlockId(swigCPtr, OdRxObject.getCPtr(pDb));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub currentLayoutId(OdRxObject pDb)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_currentLayoutId(swigCPtr, OdRxObject.getCPtr(pDb));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub xrefBlockId(OdRxObject pDb)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_xrefBlockId(swigCPtr, OdRxObject.getCPtr(pDb));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMultiThreadedRender(OdRxObject pDb, bool bOn)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_setMultiThreadedRender(swigCPtr, OdRxObject.getCPtr(pDb), bOn);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isExclusiveReadingEnabled(OdRxObject pDb)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_isExclusiveReadingEnabled(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isAProxy(OdRxObject pDrw)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_isAProxy(swigCPtr, OdRxObject.getCPtr(pDrw));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxObject openObject(OdDbStub pId)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_openObject__SWIG_0(swigCPtr, OdDbStub.getCPtr(pId)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject openObject(OdDbStub pId, bool bForWrite)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_openObject__SWIG_1(swigCPtr, OdDbStub.getCPtr(pId), bForWrite), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool upgradeOpen(OdRxObject pObj)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_upgradeOpen(swigCPtr, OdRxObject.getCPtr(pObj));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void downgradeOpen(OdRxObject pObj)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_downgradeOpen(swigCPtr, OdRxObject.getCPtr(pObj));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getAnnoScaleSet(OdDbStub drawableId, OdGiAnnoScaleSet res)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getAnnoScaleSet(swigCPtr, OdDbStub.getCPtr(drawableId), OdGiAnnoScaleSet.getCPtr(res));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub getCurrentLongTransation(OdRxObject pDb)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getCurrentLongTransation(swigCPtr, OdRxObject.getCPtr(pDb));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxObject addDatabaseUnloadReactor(OdRxObject pDb, OdRxObject pPrevReactor, DatabaseUnloadReactor pReactorRedirect)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_addDatabaseUnloadReactor(swigCPtr, OdRxObject.getCPtr(pDb), OdRxObject.getCPtr(pPrevReactor), DatabaseUnloadReactor.getCPtr(pReactorRedirect)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void removeDatabaseUnloadReactor(OdRxObject pDb, OdRxObject pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_removeDatabaseUnloadReactor(swigCPtr, OdRxObject.getCPtr(pDb), OdRxObject.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult faceConversionHelper(out OdDbStub material, OdRxObject pSourceDb, OdRxObject pDestinationDb, OdGiMaterialTraits pMaterialTraits, OdGiMapper pMaterialMapper, OdCmEntityColor pMaterialColor)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_faceConversionHelper__SWIG_0(swigCPtr, out jarg, OdRxObject.getCPtr(pSourceDb), OdRxObject.getCPtr(pDestinationDb), OdGiMaterialTraits.getCPtr(pMaterialTraits), OdGiMapper.getCPtr(pMaterialMapper), OdCmEntityColor.getCPtr(pMaterialColor));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, bIsWrapperOwnNativeObject: true));
			material = Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, currentTransaction == null);
		}
	}

	public virtual OdResult faceConversionHelper(out OdDbStub material, OdRxObject pSourceDb, OdRxObject pDestinationDb, OdGiMaterialTraits pMaterialTraits, OdGiMapper pMaterialMapper)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_faceConversionHelper__SWIG_1(swigCPtr, out jarg, OdRxObject.getCPtr(pSourceDb), OdRxObject.getCPtr(pDestinationDb), OdGiMaterialTraits.getCPtr(pMaterialTraits), OdGiMapper.getCPtr(pMaterialMapper));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, bIsWrapperOwnNativeObject: true));
			material = Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, currentTransaction == null);
		}
	}

	public virtual OdResult faceConversionHelper(out OdDbStub material, OdRxObject pSourceDb, OdRxObject pDestinationDb, OdGiMaterialTraits pMaterialTraits)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_faceConversionHelper__SWIG_2(swigCPtr, out jarg, OdRxObject.getCPtr(pSourceDb), OdRxObject.getCPtr(pDestinationDb), OdGiMaterialTraits.getCPtr(pMaterialTraits));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, bIsWrapperOwnNativeObject: true));
			material = Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, currentTransaction == null);
		}
	}

	public virtual bool getDatabasePartialViewingMode(OdRxObject arg0)
	{
		bool result = (SwigDerivedClassHasMethod("getDatabasePartialViewingMode", swigMethodTypes73) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getDatabasePartialViewingModeSwigExplicitOdDbBaseDatabasePE(swigCPtr, OdRxObject.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getDatabasePartialViewingMode(swigCPtr, OdRxObject.getCPtr(arg0)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxObject getGeoData(OdRxObject pDb, OdGsDevice pDevice, OdGsView pView)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getGeoData__SWIG_0(swigCPtr, OdRxObject.getCPtr(pDb), OdGsDevice.getCPtr(pDevice), OdGsView.getCPtr(pView)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject getGeoData(OdRxObject pDb, OdGsDevice pDevice)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getGeoData__SWIG_1(swigCPtr, OdRxObject.getCPtr(pDb), OdGsDevice.getCPtr(pDevice)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject getGeoData(OdRxObject pDb)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getGeoData__SWIG_2(swigCPtr, OdRxObject.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiDefaultContext createFilteredGiContextForExport(OdRxObject pDb, OdRxObject pSSet)
	{
		OdGiDefaultContext rXObject = Helpers.GetRXObject<OdGiDefaultContext>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_createFilteredGiContextForExport(swigCPtr, OdRxObject.getCPtr(pDb), OdRxObject.getCPtr(pSSet)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual short getObscuredLtype(ref OdRxObject arg0, out short color)
	{
		IntPtr jarg = ((arg0 == null) ? IntPtr.Zero : OdRxObject.getCPtr(arg0).Handle);
		IntPtr intPtr = jarg;
		try
		{
			short result = (SwigDerivedClassHasMethod("getObscuredLtype", swigMethodTypes78) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getObscuredLtypeSwigExplicitOdDbBaseDatabasePE(swigCPtr, ref jarg, out color) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getObscuredLtype(swigCPtr, ref jarg, out color));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				arg0 = null;
			}
			if (jarg != intPtr)
			{
				arg0 = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbBaseDatabasePE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseDatabasePE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbBaseDatabasePE) != GetType();
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
		if (SwigDerivedClassHasMethod("appServices", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodappServices;
		}
		if (SwigDerivedClassHasMethod("getFilename", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetFilename;
		}
		if (SwigDerivedClassHasMethod("startTransaction", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodstartTransaction;
		}
		if (SwigDerivedClassHasMethod("abortTransaction", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodabortTransaction;
		}
		if (SwigDerivedClassHasMethod("startUndoRecord", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodstartUndoRecord;
		}
		if (SwigDerivedClassHasMethod("evaluateFields", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodevaluateFields;
		}
		if (SwigDerivedClassHasMethod("undo", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodundo;
		}
		if (SwigDerivedClassHasMethod("createGiContext", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcreateGiContext;
		}
		if (SwigDerivedClassHasMethod("putNamedViewInfo", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodputNamedViewInfo__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("putNamedViewInfo", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodputNamedViewInfo__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createTextIterator", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodcreateTextIterator;
		}
		if (SwigDerivedClassHasMethod("setupActiveLayoutViews", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetupActiveLayoutViews;
		}
		if (SwigDerivedClassHasMethod("setupLayoutView", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetupLayoutView;
		}
		if (SwigDerivedClassHasMethod("setupPalette", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetupPalette__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setupPalette", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetupPalette__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setupPalette", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodsetupPalette__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getNextViewForActiveLayout", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodgetNextViewForActiveLayout;
		}
		if (SwigDerivedClassHasMethod("applyLayoutSettings", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodapplyLayoutSettings__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("applyLayoutSettings", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodapplyLayoutSettings__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("applyLayoutSettings", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodapplyLayoutSettings__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("zoomToExtents", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodzoomToExtents__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("zoomToExtents", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodzoomToExtents__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("zoomToExtents", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodzoomToExtents__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("loadPlotstyleTableForActiveLayout", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodloadPlotstyleTableForActiveLayout;
		}
		if (SwigDerivedClassHasMethod("isContextDependentLayers", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodisContextDependentLayers;
		}
		if (SwigDerivedClassHasMethod("layers", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodlayers__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("layers", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodlayers__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("loadXrefs", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodloadXrefs;
		}
		if (SwigDerivedClassHasMethod("visualStyles", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodvisualStyles;
		}
		if (SwigDerivedClassHasMethod("getVisualStyleId", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodgetVisualStyleId;
		}
		if (SwigDerivedClassHasMethod("setCurrentLayout", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodsetCurrentLayout;
		}
		if (SwigDerivedClassHasMethod("setCurrentLayoutId", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodsetCurrentLayoutId;
		}
		if (SwigDerivedClassHasMethod("layouts", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodlayouts;
		}
		if (SwigDerivedClassHasMethod("getLayout", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodgetLayout;
		}
		if (SwigDerivedClassHasMethod("findLayoutIdByViewport", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodfindLayoutIdByViewport;
		}
		if (SwigDerivedClassHasMethod("findLayoutNamed", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodfindLayoutNamed;
		}
		if (SwigDerivedClassHasMethod("getFirstLayoutId", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodgetFirstLayoutId;
		}
		if (SwigDerivedClassHasMethod("getCreationTime", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodgetCreationTime;
		}
		if (SwigDerivedClassHasMethod("getUpdateTime", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodgetUpdateTime;
		}
		if (SwigDerivedClassHasMethod("getFingerPrintGuid", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodgetFingerPrintGuid;
		}
		if (SwigDerivedClassHasMethod("getVersionGuid", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodgetVersionGuid;
		}
		if (SwigDerivedClassHasMethod("getUnits", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodgetUnits;
		}
		if (SwigDerivedClassHasMethod("baseFormatter", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodbaseFormatter;
		}
		if (SwigDerivedClassHasMethod("getMeasurement", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodgetMeasurement;
		}
		if (SwigDerivedClassHasMethod("getLineTypeById", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodgetLineTypeById;
		}
		if (SwigDerivedClassHasMethod("getTextStyleById", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodgetTextStyleById;
		}
		if (SwigDerivedClassHasMethod("getId", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodgetId;
		}
		if (SwigDerivedClassHasMethod("getObject", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodgetObject;
		}
		if (SwigDerivedClassHasMethod("getHandle", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodgetHandle;
		}
		if (SwigDerivedClassHasMethod("getDatabase", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodgetDatabase;
		}
		if (SwigDerivedClassHasMethod("getOwner", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodgetOwner;
		}
		if (SwigDerivedClassHasMethod("getCodePage", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodgetCodePage;
		}
		if (SwigDerivedClassHasMethod("getModelBlockId", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodgetModelBlockId;
		}
		if (SwigDerivedClassHasMethod("getPaperBlockId", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodgetPaperBlockId;
		}
		if (SwigDerivedClassHasMethod("currentLayoutId", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodcurrentLayoutId;
		}
		if (SwigDerivedClassHasMethod("xrefBlockId", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodxrefBlockId;
		}
		if (SwigDerivedClassHasMethod("setMultiThreadedRender", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodsetMultiThreadedRender;
		}
		if (SwigDerivedClassHasMethod("isExclusiveReadingEnabled", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodisExclusiveReadingEnabled;
		}
		if (SwigDerivedClassHasMethod("isAProxy", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodisAProxy;
		}
		if (SwigDerivedClassHasMethod("openObject", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodopenObject__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("openObject", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodopenObject__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("upgradeOpen", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodupgradeOpen;
		}
		if (SwigDerivedClassHasMethod("downgradeOpen", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethoddowngradeOpen;
		}
		if (SwigDerivedClassHasMethod("getAnnoScaleSet", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodgetAnnoScaleSet;
		}
		if (SwigDerivedClassHasMethod("getCurrentLongTransation", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodgetCurrentLongTransation;
		}
		if (SwigDerivedClassHasMethod("addDatabaseUnloadReactor", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodaddDatabaseUnloadReactor;
		}
		if (SwigDerivedClassHasMethod("removeDatabaseUnloadReactor", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodremoveDatabaseUnloadReactor;
		}
		if (SwigDerivedClassHasMethod("faceConversionHelper", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodfaceConversionHelper__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("faceConversionHelper", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodfaceConversionHelper__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("faceConversionHelper", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodfaceConversionHelper__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getDatabasePartialViewingMode", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodgetDatabasePartialViewingMode;
		}
		if (SwigDerivedClassHasMethod("getGeoData", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodgetGeoData__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getGeoData", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodgetGeoData__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getGeoData", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodgetGeoData__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("createFilteredGiContextForExport", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodcreateFilteredGiContextForExport;
		}
		if (SwigDerivedClassHasMethod("getObscuredLtype", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodgetObscuredLtype;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseDatabasePE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBaseDatabasePE));
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

	private IntPtr SwigDirectorMethodappServices(IntPtr pDb)
	{
		return OdDbBaseHostAppServices.getCPtr(appServices(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilename(IntPtr pDb)
	{
		return getFilename(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodstartTransaction(IntPtr pDb)
	{
		try
		{
			startTransaction(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodabortTransaction(IntPtr pDb)
	{
		try
		{
			abortTransaction(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodstartUndoRecord(IntPtr pDb)
	{
		return (int)startUndoRecord(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodevaluateFields(IntPtr pDb, int nContext)
	{
		return (int)evaluateFields(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), nContext);
	}

	private int SwigDirectorMethodundo(IntPtr pDb)
	{
		return (int)undo(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodcreateGiContext(IntPtr pDb)
	{
		return OdGiDefaultContext.getCPtr(createGiContext(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private void SwigDirectorMethodputNamedViewInfo__SWIG_0(IntPtr pDb, IntPtr layoutId, IntPtr names, IntPtr points, IntPtr pDevice)
	{
		try
		{
			putNamedViewInfo(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), (layoutId == IntPtr.Zero) ? null : new OdDbStub(layoutId, cMemoryOwn: false), new OdStringArray(names, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: false), Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodputNamedViewInfo__SWIG_1(IntPtr pDb, IntPtr layoutId, IntPtr names, IntPtr points)
	{
		try
		{
			putNamedViewInfo(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), (layoutId == IntPtr.Zero) ? null : new OdDbStub(layoutId, cMemoryOwn: false), new OdStringArray(names, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcreateTextIterator(IntPtr db, [MarshalAs(UnmanagedType.LPWStr)] string textString, int length, bool raw, IntPtr pTextStyle)
	{
		return OdBaseTextIterator.getCPtr(createTextIterator(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), textString, length, raw, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodsetupActiveLayoutViews(IntPtr pDevice, IntPtr pGiCtx)
	{
		return OdGsDevice.getCPtr(setupActiveLayoutViews(Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDefaultContext>(pGiCtx, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodsetupLayoutView(IntPtr pDevice, IntPtr pGiCtx, IntPtr layoutId)
	{
		return OdGsDevice.getCPtr(setupLayoutView(Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDefaultContext>(pGiCtx, bOwn: false, bTryAddToTransaction: false), (layoutId == IntPtr.Zero) ? null : new OdDbStub(layoutId, cMemoryOwn: false))).Handle;
	}

	private void SwigDirectorMethodsetupPalette__SWIG_0(IntPtr device, IntPtr giContext, IntPtr layoutId, uint palBg)
	{
		try
		{
			setupPalette(Helpers.GetRXObject<OdGsDevice>(device, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDefaultContext>(giContext, bOwn: false, bTryAddToTransaction: false), (layoutId == IntPtr.Zero) ? null : new OdDbStub(layoutId, cMemoryOwn: false), palBg);
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

	private void SwigDirectorMethodsetupPalette__SWIG_1(IntPtr device, IntPtr giContext, IntPtr layoutId)
	{
		try
		{
			setupPalette(Helpers.GetRXObject<OdGsDevice>(device, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDefaultContext>(giContext, bOwn: false, bTryAddToTransaction: false), (layoutId == IntPtr.Zero) ? null : new OdDbStub(layoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetupPalette__SWIG_2(IntPtr device, IntPtr giContext)
	{
		try
		{
			setupPalette(Helpers.GetRXObject<OdGsDevice>(device, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDefaultContext>(giContext, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodgetNextViewForActiveLayout(IntPtr pGiCtx, IntPtr arg1)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getNextViewForActiveLayout(Helpers.GetRXObject<OdGiDefaultContext>(pGiCtx, bOwn: false, bTryAddToTransaction: false), (arg1 == IntPtr.Zero) ? null : new OdDbStub(arg1, cMemoryOwn: false))).Handle;
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

	private void SwigDirectorMethodapplyLayoutSettings__SWIG_0(IntPtr clipBox, IntPtr pDevice, IntPtr db, uint extentsFlags, uint dpi)
	{
		try
		{
			applyLayoutSettings(new OdGsDCRect(clipBox, cMemoryOwn: false), Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), extentsFlags, dpi);
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

	private void SwigDirectorMethodapplyLayoutSettings__SWIG_1(IntPtr clipBox, IntPtr pDevice, IntPtr db, uint extentsFlags)
	{
		try
		{
			applyLayoutSettings(new OdGsDCRect(clipBox, cMemoryOwn: false), Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), extentsFlags);
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

	private void SwigDirectorMethodapplyLayoutSettings__SWIG_2(IntPtr clipBox, IntPtr pDevice, IntPtr db)
	{
		try
		{
			applyLayoutSettings(new OdGsDCRect(clipBox, cMemoryOwn: false), Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodzoomToExtents__SWIG_0(IntPtr outputRect, IntPtr pDevice, IntPtr db, IntPtr plotExtents, uint extentsFlags, IntPtr objectId)
	{
		try
		{
			zoomToExtents(new OdGsDCRect(outputRect, cMemoryOwn: false), Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(plotExtents, cMemoryOwn: false), extentsFlags, (objectId == IntPtr.Zero) ? null : new OdDbStub(objectId, cMemoryOwn: false));
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

	private void SwigDirectorMethodzoomToExtents__SWIG_1(IntPtr outputRect, IntPtr pDevice, IntPtr db, IntPtr plotExtents, uint extentsFlags)
	{
		try
		{
			zoomToExtents(new OdGsDCRect(outputRect, cMemoryOwn: false), Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(plotExtents, cMemoryOwn: false), extentsFlags);
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

	private void SwigDirectorMethodzoomToExtents__SWIG_2(IntPtr outputRect, IntPtr pDevice, IntPtr db, IntPtr plotExtents)
	{
		try
		{
			zoomToExtents(new OdGsDCRect(outputRect, cMemoryOwn: false), Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), new OdGeBoundBlock3d(plotExtents, cMemoryOwn: false));
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

	private void SwigDirectorMethodloadPlotstyleTableForActiveLayout(IntPtr pDwgContext, IntPtr db)
	{
		try
		{
			loadPlotstyleTableForActiveLayout(Helpers.GetRXObject<OdGiDefaultContext>(pDwgContext, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodisContextDependentLayers(IntPtr arg0)
	{
		return isContextDependentLayers(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodlayers__SWIG_0(IntPtr db)
	{
		return OdRxIterator.getCPtr(layers(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodlayers__SWIG_1(IntPtr db, IntPtr arg1)
	{
		return OdRxIterator.getCPtr(layers(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(arg1, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private void SwigDirectorMethodloadXrefs(IntPtr arg0)
	{
		try
		{
			loadXrefs(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodvisualStyles(IntPtr db)
	{
		return OdRxIterator.getCPtr(visualStyles(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetVisualStyleId(IntPtr db, [MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getVisualStyleId(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), name)).Handle;
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

	private void SwigDirectorMethodsetCurrentLayout(IntPtr db, [MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		try
		{
			setCurrentLayout(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), name);
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

	private void SwigDirectorMethodsetCurrentLayoutId(IntPtr pDb, IntPtr id)
	{
		try
		{
			setCurrentLayoutId(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), (id == IntPtr.Zero) ? null : new OdDbStub(id, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodlayouts(IntPtr db)
	{
		return OdRxIterator.getCPtr(layouts(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetLayout(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		return OdRxObject.getCPtr(getLayout(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), name)).Handle;
	}

	private IntPtr SwigDirectorMethodfindLayoutIdByViewport(IntPtr db, IntPtr pViewportId)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(findLayoutIdByViewport(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), (pViewportId == IntPtr.Zero) ? null : new OdDbStub(pViewportId, cMemoryOwn: false))).Handle;
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

	private IntPtr SwigDirectorMethodfindLayoutNamed(IntPtr db, [MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(findLayoutNamed(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), name)).Handle;
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

	private IntPtr SwigDirectorMethodgetFirstLayoutId(IntPtr db)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getFirstLayoutId(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodgetCreationTime(IntPtr db)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdTimeStamp.getCPtr(getCreationTime(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodgetUpdateTime(IntPtr db)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdTimeStamp.getCPtr(getUpdateTime(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFingerPrintGuid(IntPtr db)
	{
		return getFingerPrintGuid(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetVersionGuid(IntPtr db)
	{
		return getVersionGuid(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodgetUnits(IntPtr db)
	{
		return getUnits(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodbaseFormatter(IntPtr db)
	{
		return OdUnitsFormatter.getCPtr(baseFormatter(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private int SwigDirectorMethodgetMeasurement(IntPtr db)
	{
		return getMeasurement(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodgetLineTypeById(IntPtr db, IntPtr pLTypeId, IntPtr LType)
	{
		return getLineTypeById(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), (pLTypeId == IntPtr.Zero) ? null : new OdDbStub(pLTypeId, cMemoryOwn: false), new OdGiLinetype(LType, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodgetTextStyleById(IntPtr db, IntPtr idStyle, IntPtr shapeInfo)
	{
		return getTextStyleById(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), (idStyle == IntPtr.Zero) ? null : new OdDbStub(idStyle, cMemoryOwn: false), new OdGiTextStyle(shapeInfo, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodgetId(IntPtr obj)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getId(Helpers.GetRXObject<OdRxObject>(obj, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodgetObject(IntPtr db, ulong handle)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getObject(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false), handle)).Handle;
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

	private IntPtr SwigDirectorMethodgetHandle(IntPtr id)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbHandle.getCPtr(getHandle((id == IntPtr.Zero) ? null : new OdDbStub(id, cMemoryOwn: false))).Handle;
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

	private IntPtr SwigDirectorMethodgetDatabase(IntPtr id)
	{
		return OdRxObject.getCPtr(getDatabase((id == IntPtr.Zero) ? null : new OdDbStub(id, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetOwner(IntPtr id)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getOwner((id == IntPtr.Zero) ? null : new OdDbStub(id, cMemoryOwn: false))).Handle;
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

	private int SwigDirectorMethodgetCodePage(IntPtr db)
	{
		return (int)getCodePage(Helpers.GetRXObject<OdRxObject>(db, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodgetModelBlockId(IntPtr pDb)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getModelBlockId(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodgetPaperBlockId(IntPtr pDb)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getPaperBlockId(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodcurrentLayoutId(IntPtr pDb)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(currentLayoutId(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodxrefBlockId(IntPtr pDb)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(xrefBlockId(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private void SwigDirectorMethodsetMultiThreadedRender(IntPtr pDb, bool bOn)
	{
		try
		{
			setMultiThreadedRender(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), bOn);
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

	private bool SwigDirectorMethodisExclusiveReadingEnabled(IntPtr pDb)
	{
		return isExclusiveReadingEnabled(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisAProxy(IntPtr pDrw)
	{
		return isAProxy(Helpers.GetRXObject<OdRxObject>(pDrw, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodopenObject__SWIG_0(IntPtr pId)
	{
		return OdRxObject.getCPtr(openObject((pId == IntPtr.Zero) ? null : new OdDbStub(pId, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodopenObject__SWIG_1(IntPtr pId, bool bForWrite)
	{
		return OdRxObject.getCPtr(openObject((pId == IntPtr.Zero) ? null : new OdDbStub(pId, cMemoryOwn: false), bForWrite)).Handle;
	}

	private bool SwigDirectorMethodupgradeOpen(IntPtr pObj)
	{
		return upgradeOpen(Helpers.GetRXObject<OdRxObject>(pObj, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethoddowngradeOpen(IntPtr pObj)
	{
		try
		{
			downgradeOpen(Helpers.GetRXObject<OdRxObject>(pObj, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodgetAnnoScaleSet(IntPtr drawableId, IntPtr res)
	{
		return getAnnoScaleSet((drawableId == IntPtr.Zero) ? null : new OdDbStub(drawableId, cMemoryOwn: false), new OdGiAnnoScaleSet(res, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodgetCurrentLongTransation(IntPtr pDb)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getCurrentLongTransation(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodaddDatabaseUnloadReactor(IntPtr pDb, IntPtr pPrevReactor, IntPtr pReactorRedirect)
	{
		return OdRxObject.getCPtr(addDatabaseUnloadReactor(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pPrevReactor, bOwn: false, bTryAddToTransaction: false), (pReactorRedirect == IntPtr.Zero) ? null : new DatabaseUnloadReactor(pReactorRedirect, cMemoryOwn: false))).Handle;
	}

	private void SwigDirectorMethodremoveDatabaseUnloadReactor(IntPtr pDb, IntPtr pReactor)
	{
		try
		{
			removeDatabaseUnloadReactor(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pReactor, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodfaceConversionHelper__SWIG_0(IntPtr material, IntPtr pSourceDb, IntPtr pDestinationDb, IntPtr pMaterialTraits, IntPtr pMaterialMapper, IntPtr pMaterialColor)
	{
		OdDbStub material2 = new OdDbStub(material, cMemoryOwn: true);
		try
		{
			return (int)faceConversionHelper(out material2, Helpers.GetRXObject<OdRxObject>(pSourceDb, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pDestinationDb, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTraits>(pMaterialTraits, bOwn: false, bTryAddToTransaction: false), (pMaterialMapper == IntPtr.Zero) ? null : new OdGiMapper(pMaterialMapper, cMemoryOwn: false), (pMaterialColor == IntPtr.Zero) ? null : new OdCmEntityColor(pMaterialColor, cMemoryOwn: false));
		}
		finally
		{
			material = OdDbStub.getCPtr(material2).Handle;
		}
	}

	private int SwigDirectorMethodfaceConversionHelper__SWIG_1(IntPtr material, IntPtr pSourceDb, IntPtr pDestinationDb, IntPtr pMaterialTraits, IntPtr pMaterialMapper)
	{
		OdDbStub material2 = new OdDbStub(material, cMemoryOwn: true);
		try
		{
			return (int)faceConversionHelper(out material2, Helpers.GetRXObject<OdRxObject>(pSourceDb, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pDestinationDb, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTraits>(pMaterialTraits, bOwn: false, bTryAddToTransaction: false), (pMaterialMapper == IntPtr.Zero) ? null : new OdGiMapper(pMaterialMapper, cMemoryOwn: false));
		}
		finally
		{
			material = OdDbStub.getCPtr(material2).Handle;
		}
	}

	private int SwigDirectorMethodfaceConversionHelper__SWIG_2(IntPtr material, IntPtr pSourceDb, IntPtr pDestinationDb, IntPtr pMaterialTraits)
	{
		OdDbStub material2 = new OdDbStub(material, cMemoryOwn: true);
		try
		{
			return (int)faceConversionHelper(out material2, Helpers.GetRXObject<OdRxObject>(pSourceDb, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pDestinationDb, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTraits>(pMaterialTraits, bOwn: false, bTryAddToTransaction: false));
		}
		finally
		{
			material = OdDbStub.getCPtr(material2).Handle;
		}
	}

	private bool SwigDirectorMethodgetDatabasePartialViewingMode(IntPtr arg0)
	{
		return getDatabasePartialViewingMode(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodgetGeoData__SWIG_0(IntPtr pDb, IntPtr pDevice, IntPtr pView)
	{
		return OdRxObject.getCPtr(getGeoData(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetGeoData__SWIG_1(IntPtr pDb, IntPtr pDevice)
	{
		return OdRxObject.getCPtr(getGeoData(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetGeoData__SWIG_2(IntPtr pDb)
	{
		return OdRxObject.getCPtr(getGeoData(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcreateFilteredGiContextForExport(IntPtr pDb, IntPtr pSSet)
	{
		return OdGiDefaultContext.getCPtr(createFilteredGiContextForExport(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pSSet, bOwn: true, bTryAddToTransaction: false))).Handle;
	}

	private short SwigDirectorMethodgetObscuredLtype(IntPtr arg0, short color)
	{
		OdSwigDirectorHelper.director_UnpackData(arg0, out var pOriginalObject, out var pFunction);
		OdRxObject arg1 = Helpers.GetRXObject<OdRxObject>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return getObscuredLtype(ref arg1, out color);
		}
		finally
		{
			IntPtr handle = OdRxObject.getCPtr(arg1).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(arg0);
		}
	}
}

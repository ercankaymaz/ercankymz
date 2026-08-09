using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdGiContextForDbDatabase : OdGiDefaultContext
{
	public delegate IntPtr SwigDelegateOdGiContextForDbDatabase_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiContextForDbDatabase_1();

	public delegate void SwigDelegateOdGiContextForDbDatabase_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiContextForDbDatabase_3();

	public delegate IntPtr SwigDelegateOdGiContextForDbDatabase_4(IntPtr drawableId);

	public delegate int SwigDelegateOdGiContextForDbDatabase_5();

	public delegate double SwigDelegateOdGiContextForDbDatabase_6();

	public delegate void SwigDelegateOdGiContextForDbDatabase_7(IntPtr textStyle);

	public delegate void SwigDelegateOdGiContextForDbDatabase_8(IntPtr pDraw, IntPtr position, int shapeNumber, IntPtr pTextStyle);

	public delegate void SwigDelegateOdGiContextForDbDatabase_9(IntPtr pDest, IntPtr position, IntPtr direction, IntPtr upVector, int shapeNumber, IntPtr pTextStyle, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiContextForDbDatabase_10(IntPtr pDraw, IntPtr position, [MarshalAs(UnmanagedType.LPWStr)] string msg, IntPtr pTextStyle, uint flags);

	public delegate void SwigDelegateOdGiContextForDbDatabase_11(IntPtr pDraw, IntPtr position, [MarshalAs(UnmanagedType.LPWStr)] string msg, IntPtr pTextStyle);

	public delegate void SwigDelegateOdGiContextForDbDatabase_12(IntPtr pDraw, IntPtr position, double height, double width, double oblique, [MarshalAs(UnmanagedType.LPWStr)] string msg);

	public delegate void SwigDelegateOdGiContextForDbDatabase_13(IntPtr pDest, IntPtr position, IntPtr direction, IntPtr upVector, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiContextForDbDatabase_14(IntPtr textStyle, [MarshalAs(UnmanagedType.LPWStr)] string msg, uint flags, IntPtr min, IntPtr max, IntPtr pEndPos);

	public delegate void SwigDelegateOdGiContextForDbDatabase_15(IntPtr textStyle, [MarshalAs(UnmanagedType.LPWStr)] string msg, uint flags, IntPtr min, IntPtr max);

	public delegate void SwigDelegateOdGiContextForDbDatabase_16(IntPtr textStyle, int shapeNumber, IntPtr min, IntPtr max);

	public delegate uint SwigDelegateOdGiContextForDbDatabase_17(IntPtr viewportId);

	public delegate bool SwigDelegateOdGiContextForDbDatabase_18();

	public delegate uint SwigDelegateOdGiContextForDbDatabase_19();

	public delegate bool SwigDelegateOdGiContextForDbDatabase_20();

	public delegate uint SwigDelegateOdGiContextForDbDatabase_21();

	public delegate bool SwigDelegateOdGiContextForDbDatabase_22();

	public delegate bool SwigDelegateOdGiContextForDbDatabase_23();

	public delegate uint SwigDelegateOdGiContextForDbDatabase_24();

	public delegate bool SwigDelegateOdGiContextForDbDatabase_25();

	public delegate double SwigDelegateOdGiContextForDbDatabase_26(IntPtr viewportId);

	public delegate int SwigDelegateOdGiContextForDbDatabase_27();

	public delegate uint SwigDelegateOdGiContextForDbDatabase_28();

	public delegate uint SwigDelegateOdGiContextForDbDatabase_29(int fadingType);

	public delegate uint SwigDelegateOdGiContextForDbDatabase_30(int glyphType);

	public delegate uint SwigDelegateOdGiContextForDbDatabase_31(int styleEntry);

	public delegate uint SwigDelegateOdGiContextForDbDatabase_32(uint nStyle, IntPtr selStyle);

	public delegate int SwigDelegateOdGiContextForDbDatabase_33(int csType);

	public delegate IntPtr SwigDelegateOdGiContextForDbDatabase_34(IntPtr viewportId);

	public delegate uint SwigDelegateOdGiContextForDbDatabase_35(IntPtr functionId, IntPtr pPathNode, uint nFlags);

	public delegate bool SwigDelegateOdGiContextForDbDatabase_36();

	public delegate bool SwigDelegateOdGiContextForDbDatabase_37();

	public delegate int SwigDelegateOdGiContextForDbDatabase_38();

	public delegate void SwigDelegateOdGiContextForDbDatabase_39(int penNumber, IntPtr plotStyleData);

	public delegate void SwigDelegateOdGiContextForDbDatabase_40(IntPtr psNameId, IntPtr plotStyleData);

	public delegate IntPtr SwigDelegateOdGiContextForDbDatabase_41(ulong objectId);

	public delegate IntPtr SwigDelegateOdGiContextForDbDatabase_42(IntPtr objectId);

	public delegate IntPtr SwigDelegateOdGiContextForDbDatabase_43(IntPtr objectId);

	public delegate IntPtr SwigDelegateOdGiContextForDbDatabase_44(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string strMatName);

	public delegate IntPtr SwigDelegateOdGiContextForDbDatabase_45(IntPtr pDb, ulong materialId);

	public delegate uint SwigDelegateOdGiContextForDbDatabase_46();

	public delegate IntPtr SwigDelegateOdGiContextForDbDatabase_47();

	public delegate uint SwigDelegateOdGiContextForDbDatabase_48();

	public delegate bool SwigDelegateOdGiContextForDbDatabase_49();

	public delegate bool SwigDelegateOdGiContextForDbDatabase_50();

	public delegate bool SwigDelegateOdGiContextForDbDatabase_51();

	public delegate void SwigDelegateOdGiContextForDbDatabase_52(bool plotGeneration);

	public delegate void SwigDelegateOdGiContextForDbDatabase_53(uint paletteBackground);

	public delegate bool SwigDelegateOdGiContextForDbDatabase_54();

	public delegate bool SwigDelegateOdGiContextForDbDatabase_55();

	public delegate bool SwigDelegateOdGiContextForDbDatabase_56();

	public delegate void SwigDelegateOdGiContextForDbDatabase_57(bool enable);

	public delegate int SwigDelegateOdGiContextForDbDatabase_58();

	public delegate void SwigDelegateOdGiContextForDbDatabase_59(int mode);

	public delegate void SwigDelegateOdGiContextForDbDatabase_60(IntPtr vpId, IntPtr viewInfo);

	public delegate void SwigDelegateOdGiContextForDbDatabase_61(IntPtr pView);

	public delegate void SwigDelegateOdGiContextForDbDatabase_62(IntPtr pCtxColors);

	public delegate bool SwigDelegateOdGiContextForDbDatabase_63();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiContextForDbDatabase_0 swigDelegate0;

	private SwigDelegateOdGiContextForDbDatabase_1 swigDelegate1;

	private SwigDelegateOdGiContextForDbDatabase_2 swigDelegate2;

	private SwigDelegateOdGiContextForDbDatabase_3 swigDelegate3;

	private SwigDelegateOdGiContextForDbDatabase_4 swigDelegate4;

	private SwigDelegateOdGiContextForDbDatabase_5 swigDelegate5;

	private SwigDelegateOdGiContextForDbDatabase_6 swigDelegate6;

	private SwigDelegateOdGiContextForDbDatabase_7 swigDelegate7;

	private SwigDelegateOdGiContextForDbDatabase_8 swigDelegate8;

	private SwigDelegateOdGiContextForDbDatabase_9 swigDelegate9;

	private SwigDelegateOdGiContextForDbDatabase_10 swigDelegate10;

	private SwigDelegateOdGiContextForDbDatabase_11 swigDelegate11;

	private SwigDelegateOdGiContextForDbDatabase_12 swigDelegate12;

	private SwigDelegateOdGiContextForDbDatabase_13 swigDelegate13;

	private SwigDelegateOdGiContextForDbDatabase_14 swigDelegate14;

	private SwigDelegateOdGiContextForDbDatabase_15 swigDelegate15;

	private SwigDelegateOdGiContextForDbDatabase_16 swigDelegate16;

	private SwigDelegateOdGiContextForDbDatabase_17 swigDelegate17;

	private SwigDelegateOdGiContextForDbDatabase_18 swigDelegate18;

	private SwigDelegateOdGiContextForDbDatabase_19 swigDelegate19;

	private SwigDelegateOdGiContextForDbDatabase_20 swigDelegate20;

	private SwigDelegateOdGiContextForDbDatabase_21 swigDelegate21;

	private SwigDelegateOdGiContextForDbDatabase_22 swigDelegate22;

	private SwigDelegateOdGiContextForDbDatabase_23 swigDelegate23;

	private SwigDelegateOdGiContextForDbDatabase_24 swigDelegate24;

	private SwigDelegateOdGiContextForDbDatabase_25 swigDelegate25;

	private SwigDelegateOdGiContextForDbDatabase_26 swigDelegate26;

	private SwigDelegateOdGiContextForDbDatabase_27 swigDelegate27;

	private SwigDelegateOdGiContextForDbDatabase_28 swigDelegate28;

	private SwigDelegateOdGiContextForDbDatabase_29 swigDelegate29;

	private SwigDelegateOdGiContextForDbDatabase_30 swigDelegate30;

	private SwigDelegateOdGiContextForDbDatabase_31 swigDelegate31;

	private SwigDelegateOdGiContextForDbDatabase_32 swigDelegate32;

	private SwigDelegateOdGiContextForDbDatabase_33 swigDelegate33;

	private SwigDelegateOdGiContextForDbDatabase_34 swigDelegate34;

	private SwigDelegateOdGiContextForDbDatabase_35 swigDelegate35;

	private SwigDelegateOdGiContextForDbDatabase_36 swigDelegate36;

	private SwigDelegateOdGiContextForDbDatabase_37 swigDelegate37;

	private SwigDelegateOdGiContextForDbDatabase_38 swigDelegate38;

	private SwigDelegateOdGiContextForDbDatabase_39 swigDelegate39;

	private SwigDelegateOdGiContextForDbDatabase_40 swigDelegate40;

	private SwigDelegateOdGiContextForDbDatabase_41 swigDelegate41;

	private SwigDelegateOdGiContextForDbDatabase_42 swigDelegate42;

	private SwigDelegateOdGiContextForDbDatabase_43 swigDelegate43;

	private SwigDelegateOdGiContextForDbDatabase_44 swigDelegate44;

	private SwigDelegateOdGiContextForDbDatabase_45 swigDelegate45;

	private SwigDelegateOdGiContextForDbDatabase_46 swigDelegate46;

	private SwigDelegateOdGiContextForDbDatabase_47 swigDelegate47;

	private SwigDelegateOdGiContextForDbDatabase_48 swigDelegate48;

	private SwigDelegateOdGiContextForDbDatabase_49 swigDelegate49;

	private SwigDelegateOdGiContextForDbDatabase_50 swigDelegate50;

	private SwigDelegateOdGiContextForDbDatabase_51 swigDelegate51;

	private SwigDelegateOdGiContextForDbDatabase_52 swigDelegate52;

	private SwigDelegateOdGiContextForDbDatabase_53 swigDelegate53;

	private SwigDelegateOdGiContextForDbDatabase_54 swigDelegate54;

	private SwigDelegateOdGiContextForDbDatabase_55 swigDelegate55;

	private SwigDelegateOdGiContextForDbDatabase_56 swigDelegate56;

	private SwigDelegateOdGiContextForDbDatabase_57 swigDelegate57;

	private SwigDelegateOdGiContextForDbDatabase_58 swigDelegate58;

	private SwigDelegateOdGiContextForDbDatabase_59 swigDelegate59;

	private SwigDelegateOdGiContextForDbDatabase_60 swigDelegate60;

	private SwigDelegateOdGiContextForDbDatabase_61 swigDelegate61;

	private SwigDelegateOdGiContextForDbDatabase_62 swigDelegate62;

	private SwigDelegateOdGiContextForDbDatabase_63 swigDelegate63;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGiTextStyle) };

	private static Type[] swigMethodTypes8 = new Type[4]
	{
		typeof(OdGiCommonDraw),
		typeof(OdGePoint3d),
		typeof(int),
		typeof(OdGiTextStyle)
	};

	private static Type[] swigMethodTypes9 = new Type[7]
	{
		typeof(OdGiConveyorGeometry),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(int),
		typeof(OdGiTextStyle),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes10 = new Type[5]
	{
		typeof(OdGiCommonDraw),
		typeof(OdGePoint3d),
		typeof(string),
		typeof(OdGiTextStyle),
		typeof(uint)
	};

	private static Type[] swigMethodTypes11 = new Type[4]
	{
		typeof(OdGiCommonDraw),
		typeof(OdGePoint3d),
		typeof(string),
		typeof(OdGiTextStyle)
	};

	private static Type[] swigMethodTypes12 = new Type[6]
	{
		typeof(OdGiCommonDraw),
		typeof(OdGePoint3d),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(string)
	};

	private static Type[] swigMethodTypes13 = new Type[8]
	{
		typeof(OdGiConveyorGeometry),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(string),
		typeof(bool),
		typeof(OdGiTextStyle),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes14 = new Type[6]
	{
		typeof(OdGiTextStyle),
		typeof(string),
		typeof(uint),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes15 = new Type[5]
	{
		typeof(OdGiTextStyle),
		typeof(string),
		typeof(uint),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes16 = new Type[4]
	{
		typeof(OdGiTextStyle),
		typeof(int),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[0];

	private static Type[] swigMethodTypes25 = new Type[0];

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(OdGiContext_FadingType) };

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(OdGiContext_GlyphType) };

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(OdGiContext_LineWeightStyle) };

	private static Type[] swigMethodTypes32 = new Type[2]
	{
		typeof(uint),
		typeof(OdGiSelectionStyle)
	};

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(OdGiContext_CoordinatesSystem) };

	private static Type[] swigMethodTypes34 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes35 = new Type[3]
	{
		typeof(IntPtr),
		typeof(OdGiPathNode),
		typeof(uint)
	};

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[0];

	private static Type[] swigMethodTypes38 = new Type[0];

	private static Type[] swigMethodTypes39 = new Type[2]
	{
		typeof(int),
		typeof(OdPsPlotStyleData)
	};

	private static Type[] swigMethodTypes40 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdPsPlotStyleData)
	};

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(ulong) };

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes44 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes45 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(ulong)
	};

	private static Type[] swigMethodTypes46 = new Type[0];

	private static Type[] swigMethodTypes47 = new Type[0];

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[0];

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[0];

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes54 = new Type[0];

	private static Type[] swigMethodTypes55 = new Type[0];

	private static Type[] swigMethodTypes56 = new Type[0];

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes58 = new Type[0];

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(OdGiDefaultContext_SolidHatchAsPolygonMode) };

	private static Type[] swigMethodTypes60 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(OdGsClientViewInfo)
	};

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(OdGiContextualColorsImpl) };

	private static Type[] swigMethodTypes63 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiContextForDbDatabase(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiContextForDbDatabase obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdGiContextForDbDatabase(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiContextForDbDatabase()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdGiContextForDbDatabase(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdGiContextForDbDatabase cast(OdRxObject pObj)
	{
		OdGiContextForDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiContextForDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_isASwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_queryXSwigExplicitOdGiContextForDbDatabase(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiContextForDbDatabase createObject()
	{
		OdGiContextForDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiContextForDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject database()
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("database", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_databaseSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGiDrawable openDrawable(OdDbStub drawableId)
	{
		OdGiDrawable rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiDrawable>(SwigDerivedClassHasMethod("openDrawable", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_openDrawableSwigExplicitOdGiContextForDbDatabase(swigCPtr, OdDbStub.getCPtr(drawableId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_openDrawable(swigCPtr, OdDbStub.getCPtr(drawableId)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override uint numberOfIsolines()
	{
		uint result = (SwigDerivedClassHasMethod("numberOfIsolines", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_numberOfIsolinesSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_numberOfIsolines(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double commonLinetypeScale()
	{
		double result = (SwigDerivedClassHasMethod("commonLinetypeScale", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_commonLinetypeScaleSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_commonLinetypeScale(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override LineWeight defaultLineWeight()
	{
		int result = (SwigDerivedClassHasMethod("defaultLineWeight", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_defaultLineWeightSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_defaultLineWeight(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public override bool quickTextMode()
	{
		bool result = (SwigDerivedClassHasMethod("quickTextMode", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_quickTextModeSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_quickTextMode(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint textQuality()
	{
		uint result = (SwigDerivedClassHasMethod("textQuality", swigMethodTypes24) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_textQualitySwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_textQuality(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool useTtfTriangleCache()
	{
		bool result = (SwigDerivedClassHasMethod("useTtfTriangleCache", swigMethodTypes25) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_useTtfTriangleCacheSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_useTtfTriangleCache(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiContext_ImageQuality imageQuality()
	{
		int result = (SwigDerivedClassHasMethod("imageQuality", swigMethodTypes27) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_imageQualitySwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_imageQuality(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiContext_ImageQuality)result;
	}

	public override uint imageSelectionBehavior()
	{
		uint result = (SwigDerivedClassHasMethod("imageSelectionBehavior", swigMethodTypes28) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_imageSelectionBehaviorSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_imageSelectionBehavior(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint fadingIntensityPercentage(OdGiContext_FadingType fadingType)
	{
		uint result = (SwigDerivedClassHasMethod("fadingIntensityPercentage", swigMethodTypes29) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_fadingIntensityPercentageSwigExplicitOdGiContextForDbDatabase(swigCPtr, (int)fadingType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_fadingIntensityPercentage(swigCPtr, (int)fadingType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool ttfPolyDraw()
	{
		bool result = (SwigDerivedClassHasMethod("ttfPolyDraw", swigMethodTypes36) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_ttfPolyDrawSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_ttfPolyDraw(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint displaySilhouettes()
	{
		uint result = (SwigDerivedClassHasMethod("displaySilhouettes", swigMethodTypes46) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_displaySilhouettesSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_displaySilhouettes(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDatabase(OdDbDatabase pDb, bool bTrackDbDestroy)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setDatabase__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pDb), bTrackDbDestroy);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDatabase(OdDbDatabase pDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setDatabase__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbDatabase getDatabase()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_getDatabase(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void fillGsClientViewInfo(OdDbObjectId vpId, OdGsClientViewInfo viewInfo)
	{
		if (SwigDerivedClassHasMethod("fillGsClientViewInfo", swigMethodTypes60))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_fillGsClientViewInfoSwigExplicitOdGiContextForDbDatabase(swigCPtr, OdDbObjectId.getCPtr(vpId), OdGsClientViewInfo.getCPtr(viewInfo));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_fillGsClientViewInfo(swigCPtr, OdDbObjectId.getCPtr(vpId), OdGsClientViewInfo.getCPtr(viewInfo));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbStub getStubByID(ulong objectId)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("getStubByID", swigMethodTypes41) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_getStubByIDSwigExplicitOdGiContextForDbDatabase(swigCPtr, objectId) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_getStubByID(swigCPtr, objectId));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbStub getStubByMatName(OdRxObject pDb, string strMatName)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("getStubByMatName", swigMethodTypes44) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_getStubByMatNameSwigExplicitOdGiContextForDbDatabase(swigCPtr, OdRxObject.getCPtr(pDb), strMatName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_getStubByMatName(swigCPtr, OdRxObject.getCPtr(pDb), strMatName));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbStub getStubByMaterialId(OdRxObject pDb, ulong materialId)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("getStubByMaterialId", swigMethodTypes45) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_getStubByMaterialIdSwigExplicitOdGiContextForDbDatabase(swigCPtr, OdRxObject.getCPtr(pDb), materialId) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_getStubByMaterialId(swigCPtr, OdRxObject.getCPtr(pDb), materialId));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void getDefaultTextStyle(OdGiTextStyle textStyle)
	{
		if (SwigDerivedClassHasMethod("getDefaultTextStyle", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_getDefaultTextStyleSwigExplicitOdGiContextForDbDatabase(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_getDefaultTextStyle(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override uint circleZoomPercent(OdDbStub viewportId)
	{
		uint result = (SwigDerivedClassHasMethod("circleZoomPercent", swigMethodTypes17) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_circleZoomPercentSwigExplicitOdGiContextForDbDatabase(swigCPtr, OdDbStub.getCPtr(viewportId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_circleZoomPercent(swigCPtr, OdDbStub.getCPtr(viewportId)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override IntPtr drawableFilterFunctionId(OdDbStub viewportId)
	{
		IntPtr result = (SwigDerivedClassHasMethod("drawableFilterFunctionId", swigMethodTypes34) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_drawableFilterFunctionIdSwigExplicitOdGiContextForDbDatabase(swigCPtr, OdDbStub.getCPtr(viewportId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_drawableFilterFunctionId(swigCPtr, OdDbStub.getCPtr(viewportId)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint drawableFilterFunction(IntPtr functionId, OdGiPathNode pPathNode, uint nFlags)
	{
		uint result = (SwigDerivedClassHasMethod("drawableFilterFunction", swigMethodTypes35) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_drawableFilterFunctionSwigExplicitOdGiContextForDbDatabase(swigCPtr, functionId, OdGiPathNode.getCPtr(pPathNode), nFlags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_drawableFilterFunction(swigCPtr, functionId, OdGiPathNode.getCPtr(pPathNode), nFlags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint selectionStyle(uint nStyle, OdGiSelectionStyle selStyle)
	{
		uint result = (SwigDerivedClassHasMethod("selectionStyle", swigMethodTypes32) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_selectionStyleSwigExplicitOdGiContextForDbDatabase(swigCPtr, nStyle, OdGiSelectionStyle.getCPtr(selStyle)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_selectionStyle(swigCPtr, nStyle, OdGiSelectionStyle.getCPtr(selStyle)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiContext_CoordinatesSystem customViewportGeometryCS(OdGiContext_CoordinatesSystem csType)
	{
		int result = (SwigDerivedClassHasMethod("customViewportGeometryCS", swigMethodTypes33) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_customViewportGeometryCSSwigExplicitOdGiContextForDbDatabase(swigCPtr, (int)csType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_customViewportGeometryCS(swigCPtr, (int)csType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiContext_CoordinatesSystem)result;
	}

	public void setViewportGeomCSCompatibility(bool bEnable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setViewportGeomCSCompatibility(swigCPtr, bEnable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool useGsModel()
	{
		bool result = (SwigDerivedClassHasMethod("useGsModel", swigMethodTypes56) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_useGsModelSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_useGsModel(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void enableGsModel(bool enable)
	{
		if (SwigDerivedClassHasMethod("enableGsModel", swigMethodTypes57))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_enableGsModelSwigExplicitOdGiContextForDbDatabase(swigCPtr, enable);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_enableGsModel(swigCPtr, enable);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isPlotGeneration()
	{
		bool result = (SwigDerivedClassHasMethod("isPlotGeneration", swigMethodTypes18) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_isPlotGenerationSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_isPlotGeneration(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setPlotGeneration(bool plotGeneration)
	{
		if (SwigDerivedClassHasMethod("setPlotGeneration", swigMethodTypes52))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setPlotGenerationSwigExplicitOdGiContextForDbDatabase(swigCPtr, plotGeneration);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setPlotGeneration(swigCPtr, plotGeneration);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isZeroTextNormals()
	{
		bool result = (SwigDerivedClassHasMethod("isZeroTextNormals", swigMethodTypes54) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_isZeroTextNormalsSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_isZeroTextNormals(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setZeroTextNormals(bool bZeroTextNormals)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setZeroTextNormals(swigCPtr, bZeroTextNormals);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isLayoutHelperLinkReactorsDisabled()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_isLayoutHelperLinkReactorsDisabled(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void disableLayoutHelperLinkReactors(bool bDisableLinkReactors)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_disableLayoutHelperLinkReactors(swigCPtr, bDisableLinkReactors);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isContextualColorsManagementEnabled()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_isContextualColorsManagementEnabled(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableContextualColorsManagement(bool bEnable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_enableContextualColorsManagement(swigCPtr, bEnable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void updateContextualColors(OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("updateContextualColors", swigMethodTypes61))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_updateContextualColorsSwigExplicitOdGiContextForDbDatabase(swigCPtr, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_updateContextualColors(swigCPtr, OdGsView.getCPtr(pView));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void fillContextualColors(OdGiContextualColorsImpl pCtxColors)
	{
		if (SwigDerivedClassHasMethod("fillContextualColors", swigMethodTypes62))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_fillContextualColorsSwigExplicitOdGiContextForDbDatabase(swigCPtr, OdGiContextualColorsImpl.getCPtr(pCtxColors));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_fillContextualColors(swigCPtr, OdGiContextualColorsImpl.getCPtr(pCtxColors));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTtfPolyDrawMode(bool bPolyDraw)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setTtfPolyDrawMode(swigCPtr, bPolyDraw);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUseTtfTriangleCache(bool bUseCache)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setUseTtfTriangleCache(swigCPtr, bUseCache);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isKeepPSLayoutHelperViewEnabled()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_isKeepPSLayoutHelperViewEnabled(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableKeepPSLayoutHelperView(bool bEnable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_enableKeepPSLayoutHelperView(swigCPtr, bEnable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool erasePSLayoutHelperView()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_erasePSLayoutHelperView(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setErasePSLayoutHelperView(bool bOn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setErasePSLayoutHelperView(swigCPtr, bOn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isConstantModelSpaceLineweightsEnabled()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_isConstantModelSpaceLineweightsEnabled(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableConstantModelSpaceLineweights(bool bEnable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_enableConstantModelSpaceLineweights(swigCPtr, bEnable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isForceDisplaySilhouettesEnabled()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_isForceDisplaySilhouettesEnabled(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setForceDisplaySilhouettes(bool bOn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setForceDisplaySilhouettes(swigCPtr, bOn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool fillTtf()
	{
		bool result = (SwigDerivedClassHasMethod("fillTtf", swigMethodTypes20) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_fillTtfSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_fillTtf(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool fillMode()
	{
		bool result = (SwigDerivedClassHasMethod("fillMode", swigMethodTypes22) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_fillModeSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_fillMode(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint paletteBackground()
	{
		uint result = (SwigDerivedClassHasMethod("paletteBackground", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_paletteBackgroundSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_paletteBackground(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setPaletteBackground(uint paletteBackground)
	{
		if (SwigDerivedClassHasMethod("setPaletteBackground", swigMethodTypes53))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setPaletteBackgroundSwigExplicitOdGiContextForDbDatabase(swigCPtr, paletteBackground);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setPaletteBackground(swigCPtr, paletteBackground);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void loadPlotStyleTable(OdStreamBuf pStreamBuf)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_loadPlotStyleTable(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGiContext_PStyleType plotStyleType()
	{
		int result = (SwigDerivedClassHasMethod("plotStyleType", swigMethodTypes38) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_plotStyleTypeSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_plotStyleType(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiContext_PStyleType)result;
	}

	public override void plotStyle(int penNumber, OdPsPlotStyleData plotStyleData)
	{
		if (SwigDerivedClassHasMethod("plotStyle", swigMethodTypes39))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_plotStyleSwigExplicitOdGiContextForDbDatabase__SWIG_0(swigCPtr, penNumber, OdPsPlotStyleData.getCPtr(plotStyleData));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_plotStyle__SWIG_0(swigCPtr, penNumber, OdPsPlotStyleData.getCPtr(plotStyleData));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void plotStyle(OdDbStub psNameId, OdPsPlotStyleData plotStyleData)
	{
		if (SwigDerivedClassHasMethod("plotStyle", swigMethodTypes40))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_plotStyleSwigExplicitOdGiContextForDbDatabase__SWIG_1(swigCPtr, OdDbStub.getCPtr(psNameId), OdPsPlotStyleData.getCPtr(plotStyleData));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_plotStyle__SWIG_1(swigCPtr, OdDbStub.getCPtr(psNameId), OdPsPlotStyleData.getCPtr(plotStyleData));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGiSectionGeometryManager getSectionGeometryManager()
	{
		OdGiSectionGeometryManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiSectionGeometryManager>(SwigDerivedClassHasMethod("getSectionGeometryManager", swigMethodTypes47) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_getSectionGeometryManagerSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_getSectionGeometryManager(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override uint antiAliasingMode()
	{
		uint result = (SwigDerivedClassHasMethod("antiAliasingMode", swigMethodTypes48) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_antiAliasingModeSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_antiAliasingMode(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool xrefPropertiesOverride()
	{
		bool result = (SwigDerivedClassHasMethod("xrefPropertiesOverride", swigMethodTypes49) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_xrefPropertiesOverrideSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_xrefPropertiesOverride(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool linetypeGapsSelection()
	{
		bool result = (SwigDerivedClassHasMethod("linetypeGapsSelection", swigMethodTypes51) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_linetypeGapsSelectionSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_linetypeGapsSelection(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiDefaultContext_SolidHatchAsPolygonMode hatchAsPolygon()
	{
		int result = (SwigDerivedClassHasMethod("hatchAsPolygon", swigMethodTypes58) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_hatchAsPolygonSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_hatchAsPolygon(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiDefaultContext_SolidHatchAsPolygonMode)result;
	}

	public override void setHatchAsPolygon(OdGiDefaultContext_SolidHatchAsPolygonMode mode)
	{
		if (SwigDerivedClassHasMethod("setHatchAsPolygon", swigMethodTypes59))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setHatchAsPolygonSwigExplicitOdGiContextForDbDatabase(swigCPtr, (int)mode);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_setHatchAsPolygon(swigCPtr, (int)mode);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool forceSortents()
	{
		bool result = (SwigDerivedClassHasMethod("forceSortents", swigMethodTypes63) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_forceSortentsSwigExplicitOdGiContextForDbDatabase(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_forceSortents(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("database", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddatabase;
		}
		if (SwigDerivedClassHasMethod("openDrawable", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodopenDrawable;
		}
		if (SwigDerivedClassHasMethod("defaultLineWeight", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoddefaultLineWeight;
		}
		if (SwigDerivedClassHasMethod("commonLinetypeScale", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcommonLinetypeScale;
		}
		if (SwigDerivedClassHasMethod("getDefaultTextStyle", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetDefaultTextStyle;
		}
		if (SwigDerivedClassHasMethod("drawShape", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddrawShape__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("drawShape", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethoddrawShape__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("drawText", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethoddrawText__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("drawText", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethoddrawText__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("drawText", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethoddrawText__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("drawText", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethoddrawText__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("textExtentsBox", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodtextExtentsBox__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("textExtentsBox", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodtextExtentsBox__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("shapeExtentsBox", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodshapeExtentsBox;
		}
		if (SwigDerivedClassHasMethod("circleZoomPercent", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodcircleZoomPercent;
		}
		if (SwigDerivedClassHasMethod("isPlotGeneration", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodisPlotGeneration;
		}
		if (SwigDerivedClassHasMethod("paletteBackground", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodpaletteBackground;
		}
		if (SwigDerivedClassHasMethod("fillTtf", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodfillTtf;
		}
		if (SwigDerivedClassHasMethod("numberOfIsolines", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodnumberOfIsolines;
		}
		if (SwigDerivedClassHasMethod("fillMode", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodfillMode;
		}
		if (SwigDerivedClassHasMethod("quickTextMode", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodquickTextMode;
		}
		if (SwigDerivedClassHasMethod("textQuality", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodtextQuality;
		}
		if (SwigDerivedClassHasMethod("useTtfTriangleCache", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethoduseTtfTriangleCache;
		}
		if (SwigDerivedClassHasMethod("getAnnotationScale", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodgetAnnotationScale;
		}
		if (SwigDerivedClassHasMethod("imageQuality", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodimageQuality;
		}
		if (SwigDerivedClassHasMethod("imageSelectionBehavior", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodimageSelectionBehavior;
		}
		if (SwigDerivedClassHasMethod("fadingIntensityPercentage", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodfadingIntensityPercentage;
		}
		if (SwigDerivedClassHasMethod("glyphSize", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodglyphSize;
		}
		if (SwigDerivedClassHasMethod("lineWeightConfiguration", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodlineWeightConfiguration;
		}
		if (SwigDerivedClassHasMethod("selectionStyle", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodselectionStyle;
		}
		if (SwigDerivedClassHasMethod("customViewportGeometryCS", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodcustomViewportGeometryCS;
		}
		if (SwigDerivedClassHasMethod("drawableFilterFunctionId", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethoddrawableFilterFunctionId;
		}
		if (SwigDerivedClassHasMethod("drawableFilterFunction", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethoddrawableFilterFunction;
		}
		if (SwigDerivedClassHasMethod("ttfPolyDraw", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodttfPolyDraw;
		}
		if (SwigDerivedClassHasMethod("regenAbort", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodregenAbort;
		}
		if (SwigDerivedClassHasMethod("plotStyleType", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodplotStyleType;
		}
		if (SwigDerivedClassHasMethod("plotStyle", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodplotStyle__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("plotStyle", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodplotStyle__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getStubByID", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodgetStubByID;
		}
		if (SwigDerivedClassHasMethod("getDatabaseByStub", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodgetDatabaseByStub;
		}
		if (SwigDerivedClassHasMethod("getOwnerIDByStub", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodgetOwnerIDByStub;
		}
		if (SwigDerivedClassHasMethod("getStubByMatName", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodgetStubByMatName;
		}
		if (SwigDerivedClassHasMethod("getStubByMaterialId", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodgetStubByMaterialId;
		}
		if (SwigDerivedClassHasMethod("displaySilhouettes", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethoddisplaySilhouettes;
		}
		if (SwigDerivedClassHasMethod("getSectionGeometryManager", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodgetSectionGeometryManager;
		}
		if (SwigDerivedClassHasMethod("antiAliasingMode", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodantiAliasingMode;
		}
		if (SwigDerivedClassHasMethod("xrefPropertiesOverride", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodxrefPropertiesOverride;
		}
		if (SwigDerivedClassHasMethod("multiplyByBlockLinetypeScales", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodmultiplyByBlockLinetypeScales;
		}
		if (SwigDerivedClassHasMethod("linetypeGapsSelection", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodlinetypeGapsSelection;
		}
		if (SwigDerivedClassHasMethod("setPlotGeneration", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodsetPlotGeneration;
		}
		if (SwigDerivedClassHasMethod("setPaletteBackground", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodsetPaletteBackground;
		}
		if (SwigDerivedClassHasMethod("isZeroTextNormals", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodisZeroTextNormals;
		}
		if (SwigDerivedClassHasMethod("supportVerticalTTFText", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodsupportVerticalTTFText;
		}
		if (SwigDerivedClassHasMethod("useGsModel", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethoduseGsModel;
		}
		if (SwigDerivedClassHasMethod("enableGsModel", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodenableGsModel;
		}
		if (SwigDerivedClassHasMethod("hatchAsPolygon", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodhatchAsPolygon;
		}
		if (SwigDerivedClassHasMethod("setHatchAsPolygon", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodsetHatchAsPolygon;
		}
		if (SwigDerivedClassHasMethod("fillGsClientViewInfo", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodfillGsClientViewInfo;
		}
		if (SwigDerivedClassHasMethod("updateContextualColors", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodupdateContextualColors;
		}
		if (SwigDerivedClassHasMethod("fillContextualColors", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodfillContextualColors;
		}
		if (SwigDerivedClassHasMethod("forceSortents", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodforceSortents;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGiContextForDbDatabase_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiContextForDbDatabase));
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

	private IntPtr SwigDirectorMethoddatabase()
	{
		return OdRxObject.getCPtr(database()).Handle;
	}

	private IntPtr SwigDirectorMethodopenDrawable(IntPtr drawableId)
	{
		return OdGiDrawable.getCPtr(openDrawable((drawableId == IntPtr.Zero) ? null : new OdDbStub(drawableId, cMemoryOwn: false))).Handle;
	}

	private int SwigDirectorMethoddefaultLineWeight()
	{
		return (int)defaultLineWeight();
	}

	private double SwigDirectorMethodcommonLinetypeScale()
	{
		return commonLinetypeScale();
	}

	private void SwigDirectorMethodgetDefaultTextStyle(IntPtr textStyle)
	{
		try
		{
			getDefaultTextStyle(new OdGiTextStyle(textStyle, cMemoryOwn: true));
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

	private void SwigDirectorMethoddrawShape__SWIG_0(IntPtr pDraw, IntPtr position, int shapeNumber, IntPtr pTextStyle)
	{
		try
		{
			drawShape(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiCommonDraw>(pDraw, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(position, cMemoryOwn: true), shapeNumber, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false));
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

	private void SwigDirectorMethoddrawShape__SWIG_1(IntPtr pDest, IntPtr position, IntPtr direction, IntPtr upVector, int shapeNumber, IntPtr pTextStyle, IntPtr pExtrusion)
	{
		try
		{
			drawShape(new OdGiConveyorGeometry_Internal(pDest, cMemoryOwn: false), new OdGePoint3d(position, cMemoryOwn: true), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), shapeNumber, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false), (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethoddrawText__SWIG_0(IntPtr pDraw, IntPtr position, [MarshalAs(UnmanagedType.LPWStr)] string msg, IntPtr pTextStyle, uint flags)
	{
		try
		{
			drawText(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiCommonDraw>(pDraw, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(position, cMemoryOwn: true), msg, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false), flags);
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

	private void SwigDirectorMethoddrawText__SWIG_1(IntPtr pDraw, IntPtr position, [MarshalAs(UnmanagedType.LPWStr)] string msg, IntPtr pTextStyle)
	{
		try
		{
			drawText(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiCommonDraw>(pDraw, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(position, cMemoryOwn: true), msg, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false));
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

	private void SwigDirectorMethoddrawText__SWIG_2(IntPtr pDraw, IntPtr position, double height, double width, double oblique, [MarshalAs(UnmanagedType.LPWStr)] string msg)
	{
		try
		{
			drawText(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiCommonDraw>(pDraw, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(position, cMemoryOwn: true), height, width, oblique, msg);
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

	private void SwigDirectorMethoddrawText__SWIG_3(IntPtr pDest, IntPtr position, IntPtr direction, IntPtr upVector, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle, IntPtr pExtrusion)
	{
		try
		{
			drawText(new OdGiConveyorGeometry_Internal(pDest, cMemoryOwn: false), new OdGePoint3d(position, cMemoryOwn: true), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), msg, raw, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false), (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethodtextExtentsBox__SWIG_0(IntPtr textStyle, [MarshalAs(UnmanagedType.LPWStr)] string msg, uint flags, IntPtr min, IntPtr max, IntPtr pEndPos)
	{
		try
		{
			textExtentsBox(new OdGiTextStyle(textStyle, cMemoryOwn: true), msg, flags, new OdGePoint3d(min, cMemoryOwn: false), new OdGePoint3d(max, cMemoryOwn: false), (pEndPos == IntPtr.Zero) ? null : new OdGePoint3d(pEndPos, cMemoryOwn: false));
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

	private void SwigDirectorMethodtextExtentsBox__SWIG_1(IntPtr textStyle, [MarshalAs(UnmanagedType.LPWStr)] string msg, uint flags, IntPtr min, IntPtr max)
	{
		try
		{
			textExtentsBox(new OdGiTextStyle(textStyle, cMemoryOwn: true), msg, flags, new OdGePoint3d(min, cMemoryOwn: false), new OdGePoint3d(max, cMemoryOwn: false));
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

	private void SwigDirectorMethodshapeExtentsBox(IntPtr textStyle, int shapeNumber, IntPtr min, IntPtr max)
	{
		try
		{
			shapeExtentsBox(new OdGiTextStyle(textStyle, cMemoryOwn: true), shapeNumber, new OdGePoint3d(min, cMemoryOwn: false), new OdGePoint3d(max, cMemoryOwn: false));
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

	private uint SwigDirectorMethodcircleZoomPercent(IntPtr viewportId)
	{
		return circleZoomPercent((viewportId == IntPtr.Zero) ? null : new OdDbStub(viewportId, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisPlotGeneration()
	{
		return isPlotGeneration();
	}

	private uint SwigDirectorMethodpaletteBackground()
	{
		return paletteBackground();
	}

	private bool SwigDirectorMethodfillTtf()
	{
		return fillTtf();
	}

	private uint SwigDirectorMethodnumberOfIsolines()
	{
		return numberOfIsolines();
	}

	private bool SwigDirectorMethodfillMode()
	{
		return fillMode();
	}

	private bool SwigDirectorMethodquickTextMode()
	{
		return quickTextMode();
	}

	private uint SwigDirectorMethodtextQuality()
	{
		return textQuality();
	}

	private bool SwigDirectorMethoduseTtfTriangleCache()
	{
		return useTtfTriangleCache();
	}

	private double SwigDirectorMethodgetAnnotationScale(IntPtr viewportId)
	{
		return getAnnotationScale((viewportId == IntPtr.Zero) ? null : new OdDbStub(viewportId, cMemoryOwn: false));
	}

	private int SwigDirectorMethodimageQuality()
	{
		return (int)imageQuality();
	}

	private uint SwigDirectorMethodimageSelectionBehavior()
	{
		return imageSelectionBehavior();
	}

	private uint SwigDirectorMethodfadingIntensityPercentage(int fadingType)
	{
		return fadingIntensityPercentage((OdGiContext_FadingType)fadingType);
	}

	private uint SwigDirectorMethodglyphSize(int glyphType)
	{
		return glyphSize((OdGiContext_GlyphType)glyphType);
	}

	private uint SwigDirectorMethodlineWeightConfiguration(int styleEntry)
	{
		return lineWeightConfiguration((OdGiContext_LineWeightStyle)styleEntry);
	}

	private uint SwigDirectorMethodselectionStyle(uint nStyle, IntPtr selStyle)
	{
		return selectionStyle(nStyle, new OdGiSelectionStyle(selStyle, cMemoryOwn: false));
	}

	private int SwigDirectorMethodcustomViewportGeometryCS(int csType)
	{
		return (int)customViewportGeometryCS((OdGiContext_CoordinatesSystem)csType);
	}

	private IntPtr SwigDirectorMethoddrawableFilterFunctionId(IntPtr viewportId)
	{
		return drawableFilterFunctionId((viewportId == IntPtr.Zero) ? null : new OdDbStub(viewportId, cMemoryOwn: false));
	}

	private uint SwigDirectorMethoddrawableFilterFunction(IntPtr functionId, IntPtr pPathNode, uint nFlags)
	{
		return drawableFilterFunction(functionId, (pPathNode == IntPtr.Zero) ? null : new OdGiPathNode(pPathNode, cMemoryOwn: false), nFlags);
	}

	private bool SwigDirectorMethodttfPolyDraw()
	{
		return ttfPolyDraw();
	}

	private bool SwigDirectorMethodregenAbort()
	{
		return regenAbort();
	}

	private int SwigDirectorMethodplotStyleType()
	{
		return (int)plotStyleType();
	}

	private void SwigDirectorMethodplotStyle__SWIG_0(int penNumber, IntPtr plotStyleData)
	{
		try
		{
			plotStyle(penNumber, new OdPsPlotStyleData(plotStyleData, cMemoryOwn: false));
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

	private void SwigDirectorMethodplotStyle__SWIG_1(IntPtr psNameId, IntPtr plotStyleData)
	{
		try
		{
			plotStyle((psNameId == IntPtr.Zero) ? null : new OdDbStub(psNameId, cMemoryOwn: false), new OdPsPlotStyleData(plotStyleData, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodgetStubByID(ulong objectId)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getStubByID(objectId)).Handle;
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

	private IntPtr SwigDirectorMethodgetDatabaseByStub(IntPtr objectId)
	{
		return OdRxObject.getCPtr(getDatabaseByStub((objectId == IntPtr.Zero) ? null : new OdDbStub(objectId, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetOwnerIDByStub(IntPtr objectId)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getOwnerIDByStub((objectId == IntPtr.Zero) ? null : new OdDbStub(objectId, cMemoryOwn: false))).Handle;
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

	private IntPtr SwigDirectorMethodgetStubByMatName(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string strMatName)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getStubByMatName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), strMatName)).Handle;
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

	private IntPtr SwigDirectorMethodgetStubByMaterialId(IntPtr pDb, ulong materialId)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getStubByMaterialId(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), materialId)).Handle;
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

	private uint SwigDirectorMethoddisplaySilhouettes()
	{
		return displaySilhouettes();
	}

	private IntPtr SwigDirectorMethodgetSectionGeometryManager()
	{
		return OdGiSectionGeometryManager.getCPtr(getSectionGeometryManager()).Handle;
	}

	private uint SwigDirectorMethodantiAliasingMode()
	{
		return antiAliasingMode();
	}

	private bool SwigDirectorMethodxrefPropertiesOverride()
	{
		return xrefPropertiesOverride();
	}

	private bool SwigDirectorMethodmultiplyByBlockLinetypeScales()
	{
		return multiplyByBlockLinetypeScales();
	}

	private bool SwigDirectorMethodlinetypeGapsSelection()
	{
		return linetypeGapsSelection();
	}

	private void SwigDirectorMethodsetPlotGeneration(bool plotGeneration)
	{
		try
		{
			setPlotGeneration(plotGeneration);
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

	private void SwigDirectorMethodsetPaletteBackground(uint paletteBackground)
	{
		try
		{
			setPaletteBackground(paletteBackground);
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

	private bool SwigDirectorMethodisZeroTextNormals()
	{
		return isZeroTextNormals();
	}

	private bool SwigDirectorMethodsupportVerticalTTFText()
	{
		return supportVerticalTTFText();
	}

	private bool SwigDirectorMethoduseGsModel()
	{
		return useGsModel();
	}

	private void SwigDirectorMethodenableGsModel(bool enable)
	{
		try
		{
			enableGsModel(enable);
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

	private int SwigDirectorMethodhatchAsPolygon()
	{
		return (int)hatchAsPolygon();
	}

	private void SwigDirectorMethodsetHatchAsPolygon(int mode)
	{
		try
		{
			setHatchAsPolygon((OdGiDefaultContext_SolidHatchAsPolygonMode)mode);
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

	private void SwigDirectorMethodfillGsClientViewInfo(IntPtr vpId, IntPtr viewInfo)
	{
		try
		{
			fillGsClientViewInfo(new OdDbObjectId(vpId, cMemoryOwn: false), new OdGsClientViewInfo(viewInfo, cMemoryOwn: false));
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

	private void SwigDirectorMethodupdateContextualColors(IntPtr pView)
	{
		try
		{
			updateContextualColors(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodfillContextualColors(IntPtr pCtxColors)
	{
		try
		{
			fillContextualColors(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiContextualColorsImpl>(pCtxColors, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodforceSortents()
	{
		return forceSortents();
	}
}

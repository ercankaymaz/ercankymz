using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDefaultContext : OdGiContext
{
	public delegate IntPtr SwigDelegateOdGiDefaultContext_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiDefaultContext_1();

	public delegate void SwigDelegateOdGiDefaultContext_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiDefaultContext_3();

	public delegate IntPtr SwigDelegateOdGiDefaultContext_4(IntPtr drawableId);

	public delegate int SwigDelegateOdGiDefaultContext_5();

	public delegate double SwigDelegateOdGiDefaultContext_6();

	public delegate void SwigDelegateOdGiDefaultContext_7(IntPtr textStyle);

	public delegate void SwigDelegateOdGiDefaultContext_8(IntPtr pDraw, IntPtr position, int shapeNumber, IntPtr pTextStyle);

	public delegate void SwigDelegateOdGiDefaultContext_9(IntPtr pDest, IntPtr position, IntPtr direction, IntPtr upVector, int shapeNumber, IntPtr pTextStyle, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiDefaultContext_10(IntPtr pDraw, IntPtr position, [MarshalAs(UnmanagedType.LPWStr)] string msg, IntPtr pTextStyle, uint flags);

	public delegate void SwigDelegateOdGiDefaultContext_11(IntPtr pDraw, IntPtr position, [MarshalAs(UnmanagedType.LPWStr)] string msg, IntPtr pTextStyle);

	public delegate void SwigDelegateOdGiDefaultContext_12(IntPtr pDraw, IntPtr position, double height, double width, double oblique, [MarshalAs(UnmanagedType.LPWStr)] string msg);

	public delegate void SwigDelegateOdGiDefaultContext_13(IntPtr pDest, IntPtr position, IntPtr direction, IntPtr upVector, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiDefaultContext_14(IntPtr textStyle, [MarshalAs(UnmanagedType.LPWStr)] string msg, uint flags, IntPtr min, IntPtr max, IntPtr pEndPos);

	public delegate void SwigDelegateOdGiDefaultContext_15(IntPtr textStyle, [MarshalAs(UnmanagedType.LPWStr)] string msg, uint flags, IntPtr min, IntPtr max);

	public delegate void SwigDelegateOdGiDefaultContext_16(IntPtr textStyle, int shapeNumber, IntPtr min, IntPtr max);

	public delegate uint SwigDelegateOdGiDefaultContext_17(IntPtr viewportId);

	public delegate bool SwigDelegateOdGiDefaultContext_18();

	public delegate uint SwigDelegateOdGiDefaultContext_19();

	public delegate bool SwigDelegateOdGiDefaultContext_20();

	public delegate uint SwigDelegateOdGiDefaultContext_21();

	public delegate bool SwigDelegateOdGiDefaultContext_22();

	public delegate bool SwigDelegateOdGiDefaultContext_23();

	public delegate uint SwigDelegateOdGiDefaultContext_24();

	public delegate bool SwigDelegateOdGiDefaultContext_25();

	public delegate double SwigDelegateOdGiDefaultContext_26(IntPtr viewportId);

	public delegate int SwigDelegateOdGiDefaultContext_27();

	public delegate uint SwigDelegateOdGiDefaultContext_28();

	public delegate uint SwigDelegateOdGiDefaultContext_29(int fadingType);

	public delegate uint SwigDelegateOdGiDefaultContext_30(int glyphType);

	public delegate uint SwigDelegateOdGiDefaultContext_31(int styleEntry);

	public delegate uint SwigDelegateOdGiDefaultContext_32(uint nStyle, IntPtr selStyle);

	public delegate int SwigDelegateOdGiDefaultContext_33(int csType);

	public delegate IntPtr SwigDelegateOdGiDefaultContext_34(IntPtr viewportId);

	public delegate uint SwigDelegateOdGiDefaultContext_35(IntPtr functionId, IntPtr pPathNode, uint nFlags);

	public delegate bool SwigDelegateOdGiDefaultContext_36();

	public delegate bool SwigDelegateOdGiDefaultContext_37();

	public delegate int SwigDelegateOdGiDefaultContext_38();

	public delegate void SwigDelegateOdGiDefaultContext_39(int penNumber, IntPtr plotStyleData);

	public delegate void SwigDelegateOdGiDefaultContext_40(IntPtr objectId, IntPtr plotStyleData);

	public delegate IntPtr SwigDelegateOdGiDefaultContext_41(ulong persistentId);

	public delegate IntPtr SwigDelegateOdGiDefaultContext_42(IntPtr objectId);

	public delegate IntPtr SwigDelegateOdGiDefaultContext_43(IntPtr objectId);

	public delegate IntPtr SwigDelegateOdGiDefaultContext_44(IntPtr pBaseDb, [MarshalAs(UnmanagedType.LPWStr)] string strMatName);

	public delegate IntPtr SwigDelegateOdGiDefaultContext_45(IntPtr pBaseDb, ulong materialId);

	public delegate uint SwigDelegateOdGiDefaultContext_46();

	public delegate IntPtr SwigDelegateOdGiDefaultContext_47();

	public delegate uint SwigDelegateOdGiDefaultContext_48();

	public delegate bool SwigDelegateOdGiDefaultContext_49();

	public delegate bool SwigDelegateOdGiDefaultContext_50();

	public delegate bool SwigDelegateOdGiDefaultContext_51();

	public delegate void SwigDelegateOdGiDefaultContext_52(bool plotGeneration);

	public delegate void SwigDelegateOdGiDefaultContext_53(uint paletteBackground);

	public delegate bool SwigDelegateOdGiDefaultContext_54();

	public delegate bool SwigDelegateOdGiDefaultContext_55();

	public delegate bool SwigDelegateOdGiDefaultContext_56();

	public delegate void SwigDelegateOdGiDefaultContext_57(bool enable);

	public delegate int SwigDelegateOdGiDefaultContext_58();

	public delegate void SwigDelegateOdGiDefaultContext_59(int mode);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiDefaultContext_0 swigDelegate0;

	private SwigDelegateOdGiDefaultContext_1 swigDelegate1;

	private SwigDelegateOdGiDefaultContext_2 swigDelegate2;

	private SwigDelegateOdGiDefaultContext_3 swigDelegate3;

	private SwigDelegateOdGiDefaultContext_4 swigDelegate4;

	private SwigDelegateOdGiDefaultContext_5 swigDelegate5;

	private SwigDelegateOdGiDefaultContext_6 swigDelegate6;

	private SwigDelegateOdGiDefaultContext_7 swigDelegate7;

	private SwigDelegateOdGiDefaultContext_8 swigDelegate8;

	private SwigDelegateOdGiDefaultContext_9 swigDelegate9;

	private SwigDelegateOdGiDefaultContext_10 swigDelegate10;

	private SwigDelegateOdGiDefaultContext_11 swigDelegate11;

	private SwigDelegateOdGiDefaultContext_12 swigDelegate12;

	private SwigDelegateOdGiDefaultContext_13 swigDelegate13;

	private SwigDelegateOdGiDefaultContext_14 swigDelegate14;

	private SwigDelegateOdGiDefaultContext_15 swigDelegate15;

	private SwigDelegateOdGiDefaultContext_16 swigDelegate16;

	private SwigDelegateOdGiDefaultContext_17 swigDelegate17;

	private SwigDelegateOdGiDefaultContext_18 swigDelegate18;

	private SwigDelegateOdGiDefaultContext_19 swigDelegate19;

	private SwigDelegateOdGiDefaultContext_20 swigDelegate20;

	private SwigDelegateOdGiDefaultContext_21 swigDelegate21;

	private SwigDelegateOdGiDefaultContext_22 swigDelegate22;

	private SwigDelegateOdGiDefaultContext_23 swigDelegate23;

	private SwigDelegateOdGiDefaultContext_24 swigDelegate24;

	private SwigDelegateOdGiDefaultContext_25 swigDelegate25;

	private SwigDelegateOdGiDefaultContext_26 swigDelegate26;

	private SwigDelegateOdGiDefaultContext_27 swigDelegate27;

	private SwigDelegateOdGiDefaultContext_28 swigDelegate28;

	private SwigDelegateOdGiDefaultContext_29 swigDelegate29;

	private SwigDelegateOdGiDefaultContext_30 swigDelegate30;

	private SwigDelegateOdGiDefaultContext_31 swigDelegate31;

	private SwigDelegateOdGiDefaultContext_32 swigDelegate32;

	private SwigDelegateOdGiDefaultContext_33 swigDelegate33;

	private SwigDelegateOdGiDefaultContext_34 swigDelegate34;

	private SwigDelegateOdGiDefaultContext_35 swigDelegate35;

	private SwigDelegateOdGiDefaultContext_36 swigDelegate36;

	private SwigDelegateOdGiDefaultContext_37 swigDelegate37;

	private SwigDelegateOdGiDefaultContext_38 swigDelegate38;

	private SwigDelegateOdGiDefaultContext_39 swigDelegate39;

	private SwigDelegateOdGiDefaultContext_40 swigDelegate40;

	private SwigDelegateOdGiDefaultContext_41 swigDelegate41;

	private SwigDelegateOdGiDefaultContext_42 swigDelegate42;

	private SwigDelegateOdGiDefaultContext_43 swigDelegate43;

	private SwigDelegateOdGiDefaultContext_44 swigDelegate44;

	private SwigDelegateOdGiDefaultContext_45 swigDelegate45;

	private SwigDelegateOdGiDefaultContext_46 swigDelegate46;

	private SwigDelegateOdGiDefaultContext_47 swigDelegate47;

	private SwigDelegateOdGiDefaultContext_48 swigDelegate48;

	private SwigDelegateOdGiDefaultContext_49 swigDelegate49;

	private SwigDelegateOdGiDefaultContext_50 swigDelegate50;

	private SwigDelegateOdGiDefaultContext_51 swigDelegate51;

	private SwigDelegateOdGiDefaultContext_52 swigDelegate52;

	private SwigDelegateOdGiDefaultContext_53 swigDelegate53;

	private SwigDelegateOdGiDefaultContext_54 swigDelegate54;

	private SwigDelegateOdGiDefaultContext_55 swigDelegate55;

	private SwigDelegateOdGiDefaultContext_56 swigDelegate56;

	private SwigDelegateOdGiDefaultContext_57 swigDelegate57;

	private SwigDelegateOdGiDefaultContext_58 swigDelegate58;

	private SwigDelegateOdGiDefaultContext_59 swigDelegate59;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDefaultContext(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDefaultContext obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDefaultContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiDefaultContext()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDefaultContext(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdGiDefaultContext cast(OdRxObject pObj)
	{
		OdGiDefaultContext rXObject = Helpers.GetRXObject<OdGiDefaultContext>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_isASwigExplicitOdGiDefaultContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_queryXSwigExplicitOdGiDefaultContext(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiDefaultContext createObject()
	{
		OdGiDefaultContext rXObject = Helpers.GetRXObject<OdGiDefaultContext>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void getDefaultTextStyle(OdGiTextStyle textStyle)
	{
		if (SwigDerivedClassHasMethod("getDefaultTextStyle", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_getDefaultTextStyleSwigExplicitOdGiDefaultContext(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_getDefaultTextStyle(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void drawText(OdGiCommonDraw pDraw, OdGePoint3d position, string msg, OdGiTextStyle pTextStyle, uint flags)
	{
		if (SwigDerivedClassHasMethod("drawText", swigMethodTypes10))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_drawTextSwigExplicitOdGiDefaultContext__SWIG_0(swigCPtr, OdGiCommonDraw.getCPtr(pDraw), OdGePoint3d.getCPtr(position), msg, OdGiTextStyle.getCPtr(pTextStyle), flags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_drawText__SWIG_0(swigCPtr, OdGiCommonDraw.getCPtr(pDraw), OdGePoint3d.getCPtr(position), msg, OdGiTextStyle.getCPtr(pTextStyle), flags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void drawText(OdGiCommonDraw pDraw, OdGePoint3d position, string msg, OdGiTextStyle pTextStyle)
	{
		if (SwigDerivedClassHasMethod("drawText", swigMethodTypes11))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_drawTextSwigExplicitOdGiDefaultContext__SWIG_1(swigCPtr, OdGiCommonDraw.getCPtr(pDraw), OdGePoint3d.getCPtr(position), msg, OdGiTextStyle.getCPtr(pTextStyle));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_drawText__SWIG_1(swigCPtr, OdGiCommonDraw.getCPtr(pDraw), OdGePoint3d.getCPtr(position), msg, OdGiTextStyle.getCPtr(pTextStyle));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void drawText(OdGiCommonDraw pDraw, OdGePoint3d position, double height, double width, double oblique, string msg)
	{
		if (SwigDerivedClassHasMethod("drawText", swigMethodTypes12))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_drawTextSwigExplicitOdGiDefaultContext__SWIG_2(swigCPtr, OdGiCommonDraw.getCPtr(pDraw), OdGePoint3d.getCPtr(position), height, width, oblique, msg);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_drawText__SWIG_2(swigCPtr, OdGiCommonDraw.getCPtr(pDraw), OdGePoint3d.getCPtr(position), height, width, oblique, msg);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void drawText(OdGiConveyorGeometry pDest, OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, string msg, bool raw, OdGiTextStyle pTextStyle, OdGeVector3d pExtrusion)
	{
		if (SwigDerivedClassHasMethod("drawText", swigMethodTypes13))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_drawTextSwigExplicitOdGiDefaultContext__SWIG_3(swigCPtr, pDest.GetInterfaceCPtr(), OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), msg, raw, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_drawText__SWIG_3(swigCPtr, pDest.GetInterfaceCPtr(), OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), msg, raw, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void drawShape(OdGiCommonDraw pDraw, OdGePoint3d position, int shapeNumber, OdGiTextStyle pTextStyle)
	{
		if (SwigDerivedClassHasMethod("drawShape", swigMethodTypes8))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_drawShapeSwigExplicitOdGiDefaultContext__SWIG_0(swigCPtr, OdGiCommonDraw.getCPtr(pDraw), OdGePoint3d.getCPtr(position), shapeNumber, OdGiTextStyle.getCPtr(pTextStyle));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_drawShape__SWIG_0(swigCPtr, OdGiCommonDraw.getCPtr(pDraw), OdGePoint3d.getCPtr(position), shapeNumber, OdGiTextStyle.getCPtr(pTextStyle));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void drawShape(OdGiConveyorGeometry pDest, OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, int shapeNumber, OdGiTextStyle pTextStyle, OdGeVector3d pExtrusion)
	{
		if (SwigDerivedClassHasMethod("drawShape", swigMethodTypes9))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_drawShapeSwigExplicitOdGiDefaultContext__SWIG_1(swigCPtr, pDest.GetInterfaceCPtr(), OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), shapeNumber, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_drawShape__SWIG_1(swigCPtr, pDest.GetInterfaceCPtr(), OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), shapeNumber, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void textExtentsBox(OdGiTextStyle textStyle, string msg, uint flags, OdGePoint3d min, OdGePoint3d max, OdGePoint3d pEndPos)
	{
		if (SwigDerivedClassHasMethod("textExtentsBox", swigMethodTypes14))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_textExtentsBoxSwigExplicitOdGiDefaultContext__SWIG_0(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle, msg, flags, OdGePoint3d.getCPtr(min), OdGePoint3d.getCPtr(max), OdGePoint3d.getCPtr(pEndPos));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_textExtentsBox__SWIG_0(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle, msg, flags, OdGePoint3d.getCPtr(min), OdGePoint3d.getCPtr(max), OdGePoint3d.getCPtr(pEndPos));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void textExtentsBox(OdGiTextStyle textStyle, string msg, uint flags, OdGePoint3d min, OdGePoint3d max)
	{
		if (SwigDerivedClassHasMethod("textExtentsBox", swigMethodTypes15))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_textExtentsBoxSwigExplicitOdGiDefaultContext__SWIG_1(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle, msg, flags, OdGePoint3d.getCPtr(min), OdGePoint3d.getCPtr(max));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_textExtentsBox__SWIG_1(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle, msg, flags, OdGePoint3d.getCPtr(min), OdGePoint3d.getCPtr(max));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void shapeExtentsBox(OdGiTextStyle textStyle, int shapeNumber, OdGePoint3d min, OdGePoint3d max)
	{
		if (SwigDerivedClassHasMethod("shapeExtentsBox", swigMethodTypes16))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_shapeExtentsBoxSwigExplicitOdGiDefaultContext(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle, shapeNumber, OdGePoint3d.getCPtr(min), OdGePoint3d.getCPtr(max));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_shapeExtentsBox(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle, shapeNumber, OdGePoint3d.getCPtr(min), OdGePoint3d.getCPtr(max));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPlotGeneration(bool plotGeneration)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_setPlotGeneration(swigCPtr, plotGeneration);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPaletteBackground(uint paletteBackground)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_setPaletteBackground(swigCPtr, paletteBackground);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isZeroTextNormals()
	{
		bool result = (SwigDerivedClassHasMethod("isZeroTextNormals", swigMethodTypes54) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_isZeroTextNormalsSwigExplicitOdGiDefaultContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_isZeroTextNormals(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool supportVerticalTTFText()
	{
		bool result = (SwigDerivedClassHasMethod("supportVerticalTTFText", swigMethodTypes55) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_supportVerticalTTFTextSwigExplicitOdGiDefaultContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_supportVerticalTTFText(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool useGsModel()
	{
		bool result = (SwigDerivedClassHasMethod("useGsModel", swigMethodTypes56) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_useGsModelSwigExplicitOdGiDefaultContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_useGsModel(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void enableGsModel(bool enable)
	{
		if (SwigDerivedClassHasMethod("enableGsModel", swigMethodTypes57))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_enableGsModelSwigExplicitOdGiDefaultContext(swigCPtr, enable);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_enableGsModel(swigCPtr, enable);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiDefaultContext_SolidHatchAsPolygonMode hatchAsPolygon()
	{
		int result = (SwigDerivedClassHasMethod("hatchAsPolygon", swigMethodTypes58) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_hatchAsPolygonSwigExplicitOdGiDefaultContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_hatchAsPolygon(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiDefaultContext_SolidHatchAsPolygonMode)result;
	}

	public virtual void setHatchAsPolygon(OdGiDefaultContext_SolidHatchAsPolygonMode mode)
	{
		if (SwigDerivedClassHasMethod("setHatchAsPolygon", swigMethodTypes59))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_setHatchAsPolygonSwigExplicitOdGiDefaultContext(swigCPtr, (int)mode);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_setHatchAsPolygon(swigCPtr, (int)mode);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbStub getStubByID(ulong persistentId)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("getStubByID", swigMethodTypes41) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_getStubByIDSwigExplicitOdGiDefaultContext(swigCPtr, persistentId) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_getStubByID(swigCPtr, persistentId));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override ulong getIDByStub(OdDbStub objectId)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_getIDByStub(swigCPtr, OdDbStub.getCPtr(objectId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdRxObject getDatabaseByStub(OdDbStub objectId)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("getDatabaseByStub", swigMethodTypes42) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_getDatabaseByStubSwigExplicitOdGiDefaultContext(swigCPtr, OdDbStub.getCPtr(objectId)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_getDatabaseByStub(swigCPtr, OdDbStub.getCPtr(objectId)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdDbStub getOwnerIDByStub(OdDbStub objectId)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("getOwnerIDByStub", swigMethodTypes43) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_getOwnerIDByStubSwigExplicitOdGiDefaultContext(swigCPtr, OdDbStub.getCPtr(objectId)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_getOwnerIDByStub(swigCPtr, OdDbStub.getCPtr(objectId)));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
			swigDelegate35 = SwigDirectorMethoddrawableFilterFunction__SWIG_1;
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDefaultContext_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiDefaultContext));
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

	private void SwigDirectorMethoddrawShape__SWIG_0(IntPtr pDraw, IntPtr position, int shapeNumber, IntPtr pTextStyle)
	{
		try
		{
			drawShape(Helpers.GetRXObject<OdGiCommonDraw>(pDraw, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(position, cMemoryOwn: false), shapeNumber, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false));
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

	private void SwigDirectorMethoddrawShape__SWIG_1(IntPtr pDest, IntPtr position, IntPtr direction, IntPtr upVector, int shapeNumber, IntPtr pTextStyle, IntPtr pExtrusion)
	{
		try
		{
			drawShape(new OdGiConveyorGeometry_Internal(pDest, cMemoryOwn: false), new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), shapeNumber, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false), (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethoddrawText__SWIG_0(IntPtr pDraw, IntPtr position, [MarshalAs(UnmanagedType.LPWStr)] string msg, IntPtr pTextStyle, uint flags)
	{
		try
		{
			drawText(Helpers.GetRXObject<OdGiCommonDraw>(pDraw, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(position, cMemoryOwn: false), msg, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false), flags);
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

	private void SwigDirectorMethoddrawText__SWIG_1(IntPtr pDraw, IntPtr position, [MarshalAs(UnmanagedType.LPWStr)] string msg, IntPtr pTextStyle)
	{
		try
		{
			drawText(Helpers.GetRXObject<OdGiCommonDraw>(pDraw, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(position, cMemoryOwn: false), msg, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false));
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

	private void SwigDirectorMethoddrawText__SWIG_2(IntPtr pDraw, IntPtr position, double height, double width, double oblique, [MarshalAs(UnmanagedType.LPWStr)] string msg)
	{
		try
		{
			drawText(Helpers.GetRXObject<OdGiCommonDraw>(pDraw, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(position, cMemoryOwn: false), height, width, oblique, msg);
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

	private void SwigDirectorMethoddrawText__SWIG_3(IntPtr pDest, IntPtr position, IntPtr direction, IntPtr upVector, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle, IntPtr pExtrusion)
	{
		try
		{
			drawText(new OdGiConveyorGeometry_Internal(pDest, cMemoryOwn: false), new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), msg, raw, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false), (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethodtextExtentsBox__SWIG_0(IntPtr textStyle, [MarshalAs(UnmanagedType.LPWStr)] string msg, uint flags, IntPtr min, IntPtr max, IntPtr pEndPos)
	{
		try
		{
			textExtentsBox(new OdGiTextStyle(textStyle, cMemoryOwn: true), msg, flags, new OdGePoint3d(min, cMemoryOwn: false), new OdGePoint3d(max, cMemoryOwn: false), (pEndPos == IntPtr.Zero) ? null : new OdGePoint3d(pEndPos, cMemoryOwn: false));
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

	private void SwigDirectorMethodtextExtentsBox__SWIG_1(IntPtr textStyle, [MarshalAs(UnmanagedType.LPWStr)] string msg, uint flags, IntPtr min, IntPtr max)
	{
		try
		{
			textExtentsBox(new OdGiTextStyle(textStyle, cMemoryOwn: true), msg, flags, new OdGePoint3d(min, cMemoryOwn: false), new OdGePoint3d(max, cMemoryOwn: false));
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

	private void SwigDirectorMethodshapeExtentsBox(IntPtr textStyle, int shapeNumber, IntPtr min, IntPtr max)
	{
		try
		{
			shapeExtentsBox(new OdGiTextStyle(textStyle, cMemoryOwn: true), shapeNumber, new OdGePoint3d(min, cMemoryOwn: false), new OdGePoint3d(max, cMemoryOwn: false));
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

	private uint SwigDirectorMethoddrawableFilterFunction__SWIG_1(IntPtr functionId, IntPtr pPathNode, uint nFlags)
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

	private void SwigDirectorMethodplotStyle__SWIG_1(IntPtr objectId, IntPtr plotStyleData)
	{
		try
		{
			plotStyle((objectId == IntPtr.Zero) ? null : new OdDbStub(objectId, cMemoryOwn: false), new OdPsPlotStyleData(plotStyleData, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodgetStubByID(ulong persistentId)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getStubByID(persistentId)).Handle;
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

	private IntPtr SwigDirectorMethodgetStubByMatName(IntPtr pBaseDb, [MarshalAs(UnmanagedType.LPWStr)] string strMatName)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getStubByMatName(Helpers.GetRXObject<OdRxObject>(pBaseDb, bOwn: false, bTryAddToTransaction: false), strMatName)).Handle;
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

	private IntPtr SwigDirectorMethodgetStubByMaterialId(IntPtr pBaseDb, ulong materialId)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getStubByMaterialId(Helpers.GetRXObject<OdRxObject>(pBaseDb, bOwn: false, bTryAddToTransaction: false), materialId)).Handle;
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

	private void SwigDirectorMethodsetPaletteBackground(uint paletteBackground)
	{
		try
		{
			setPaletteBackground(paletteBackground);
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
}

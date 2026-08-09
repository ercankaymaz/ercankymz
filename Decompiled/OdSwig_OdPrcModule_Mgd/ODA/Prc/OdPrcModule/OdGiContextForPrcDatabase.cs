using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdGiContextForPrcDatabase : OdGiDefaultContext
{
	public delegate IntPtr SwigDelegateOdGiContextForPrcDatabase_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiContextForPrcDatabase_1();

	public delegate void SwigDelegateOdGiContextForPrcDatabase_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiContextForPrcDatabase_3();

	public delegate IntPtr SwigDelegateOdGiContextForPrcDatabase_4(IntPtr drawableId);

	public delegate int SwigDelegateOdGiContextForPrcDatabase_5();

	public delegate double SwigDelegateOdGiContextForPrcDatabase_6();

	public delegate void SwigDelegateOdGiContextForPrcDatabase_7(IntPtr textStyle);

	public delegate void SwigDelegateOdGiContextForPrcDatabase_8(IntPtr pDraw, IntPtr position, int shapeNumber, IntPtr pTextStyle);

	public delegate void SwigDelegateOdGiContextForPrcDatabase_9(IntPtr pDest, IntPtr position, IntPtr direction, IntPtr upVector, int shapeNumber, IntPtr pTextStyle, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiContextForPrcDatabase_10(IntPtr pDraw, IntPtr position, [MarshalAs(UnmanagedType.LPWStr)] string msg, IntPtr pTextStyle, uint flags);

	public delegate void SwigDelegateOdGiContextForPrcDatabase_11(IntPtr pDraw, IntPtr position, [MarshalAs(UnmanagedType.LPWStr)] string msg, IntPtr pTextStyle);

	public delegate void SwigDelegateOdGiContextForPrcDatabase_12(IntPtr pDraw, IntPtr position, double height, double width, double oblique, [MarshalAs(UnmanagedType.LPWStr)] string msg);

	public delegate void SwigDelegateOdGiContextForPrcDatabase_13(IntPtr pDest, IntPtr position, IntPtr direction, IntPtr upVector, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiContextForPrcDatabase_14(IntPtr textStyle, [MarshalAs(UnmanagedType.LPWStr)] string msg, uint flags, IntPtr min, IntPtr max, IntPtr pEndPos);

	public delegate void SwigDelegateOdGiContextForPrcDatabase_15(IntPtr textStyle, [MarshalAs(UnmanagedType.LPWStr)] string msg, uint flags, IntPtr min, IntPtr max);

	public delegate void SwigDelegateOdGiContextForPrcDatabase_16(IntPtr textStyle, int shapeNumber, IntPtr min, IntPtr max);

	public delegate uint SwigDelegateOdGiContextForPrcDatabase_17(IntPtr viewportId);

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_18();

	public delegate uint SwigDelegateOdGiContextForPrcDatabase_19();

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_20();

	public delegate uint SwigDelegateOdGiContextForPrcDatabase_21();

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_22();

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_23();

	public delegate uint SwigDelegateOdGiContextForPrcDatabase_24();

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_25();

	public delegate double SwigDelegateOdGiContextForPrcDatabase_26(IntPtr viewportId);

	public delegate int SwigDelegateOdGiContextForPrcDatabase_27();

	public delegate uint SwigDelegateOdGiContextForPrcDatabase_28();

	public delegate uint SwigDelegateOdGiContextForPrcDatabase_29(int fadingType);

	public delegate uint SwigDelegateOdGiContextForPrcDatabase_30(int glyphType);

	public delegate uint SwigDelegateOdGiContextForPrcDatabase_31(int styleEntry);

	public delegate uint SwigDelegateOdGiContextForPrcDatabase_32(uint nStyle, IntPtr selStyle);

	public delegate int SwigDelegateOdGiContextForPrcDatabase_33(int csType);

	public delegate IntPtr SwigDelegateOdGiContextForPrcDatabase_34(IntPtr viewportId);

	public delegate uint SwigDelegateOdGiContextForPrcDatabase_35(IntPtr functionId, IntPtr pPathNode, uint nFlags);

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_36();

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_37();

	public delegate int SwigDelegateOdGiContextForPrcDatabase_38();

	public delegate void SwigDelegateOdGiContextForPrcDatabase_39(int penNumber, IntPtr plotStyleData);

	public delegate void SwigDelegateOdGiContextForPrcDatabase_40(IntPtr objectId, IntPtr plotStyleData);

	public delegate IntPtr SwigDelegateOdGiContextForPrcDatabase_41(ulong persistentId);

	public delegate IntPtr SwigDelegateOdGiContextForPrcDatabase_42(IntPtr objectId);

	public delegate IntPtr SwigDelegateOdGiContextForPrcDatabase_43(IntPtr objectId);

	public delegate IntPtr SwigDelegateOdGiContextForPrcDatabase_44(IntPtr pBaseDb, [MarshalAs(UnmanagedType.LPWStr)] string strMatName);

	public delegate IntPtr SwigDelegateOdGiContextForPrcDatabase_45(IntPtr pBaseDb, ulong materialId);

	public delegate uint SwigDelegateOdGiContextForPrcDatabase_46();

	public delegate IntPtr SwigDelegateOdGiContextForPrcDatabase_47();

	public delegate uint SwigDelegateOdGiContextForPrcDatabase_48();

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_49();

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_50();

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_51();

	public delegate void SwigDelegateOdGiContextForPrcDatabase_52(bool plotGeneration);

	public delegate void SwigDelegateOdGiContextForPrcDatabase_53(uint paletteBackground);

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_54();

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_55();

	public delegate bool SwigDelegateOdGiContextForPrcDatabase_56();

	public delegate void SwigDelegateOdGiContextForPrcDatabase_57(bool enable);

	public delegate int SwigDelegateOdGiContextForPrcDatabase_58();

	public delegate void SwigDelegateOdGiContextForPrcDatabase_59(int mode);

	public delegate void SwigDelegateOdGiContextForPrcDatabase_60(IntPtr viewInfo);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiContextForPrcDatabase_0 swigDelegate0;

	private SwigDelegateOdGiContextForPrcDatabase_1 swigDelegate1;

	private SwigDelegateOdGiContextForPrcDatabase_2 swigDelegate2;

	private SwigDelegateOdGiContextForPrcDatabase_3 swigDelegate3;

	private SwigDelegateOdGiContextForPrcDatabase_4 swigDelegate4;

	private SwigDelegateOdGiContextForPrcDatabase_5 swigDelegate5;

	private SwigDelegateOdGiContextForPrcDatabase_6 swigDelegate6;

	private SwigDelegateOdGiContextForPrcDatabase_7 swigDelegate7;

	private SwigDelegateOdGiContextForPrcDatabase_8 swigDelegate8;

	private SwigDelegateOdGiContextForPrcDatabase_9 swigDelegate9;

	private SwigDelegateOdGiContextForPrcDatabase_10 swigDelegate10;

	private SwigDelegateOdGiContextForPrcDatabase_11 swigDelegate11;

	private SwigDelegateOdGiContextForPrcDatabase_12 swigDelegate12;

	private SwigDelegateOdGiContextForPrcDatabase_13 swigDelegate13;

	private SwigDelegateOdGiContextForPrcDatabase_14 swigDelegate14;

	private SwigDelegateOdGiContextForPrcDatabase_15 swigDelegate15;

	private SwigDelegateOdGiContextForPrcDatabase_16 swigDelegate16;

	private SwigDelegateOdGiContextForPrcDatabase_17 swigDelegate17;

	private SwigDelegateOdGiContextForPrcDatabase_18 swigDelegate18;

	private SwigDelegateOdGiContextForPrcDatabase_19 swigDelegate19;

	private SwigDelegateOdGiContextForPrcDatabase_20 swigDelegate20;

	private SwigDelegateOdGiContextForPrcDatabase_21 swigDelegate21;

	private SwigDelegateOdGiContextForPrcDatabase_22 swigDelegate22;

	private SwigDelegateOdGiContextForPrcDatabase_23 swigDelegate23;

	private SwigDelegateOdGiContextForPrcDatabase_24 swigDelegate24;

	private SwigDelegateOdGiContextForPrcDatabase_25 swigDelegate25;

	private SwigDelegateOdGiContextForPrcDatabase_26 swigDelegate26;

	private SwigDelegateOdGiContextForPrcDatabase_27 swigDelegate27;

	private SwigDelegateOdGiContextForPrcDatabase_28 swigDelegate28;

	private SwigDelegateOdGiContextForPrcDatabase_29 swigDelegate29;

	private SwigDelegateOdGiContextForPrcDatabase_30 swigDelegate30;

	private SwigDelegateOdGiContextForPrcDatabase_31 swigDelegate31;

	private SwigDelegateOdGiContextForPrcDatabase_32 swigDelegate32;

	private SwigDelegateOdGiContextForPrcDatabase_33 swigDelegate33;

	private SwigDelegateOdGiContextForPrcDatabase_34 swigDelegate34;

	private SwigDelegateOdGiContextForPrcDatabase_35 swigDelegate35;

	private SwigDelegateOdGiContextForPrcDatabase_36 swigDelegate36;

	private SwigDelegateOdGiContextForPrcDatabase_37 swigDelegate37;

	private SwigDelegateOdGiContextForPrcDatabase_38 swigDelegate38;

	private SwigDelegateOdGiContextForPrcDatabase_39 swigDelegate39;

	private SwigDelegateOdGiContextForPrcDatabase_40 swigDelegate40;

	private SwigDelegateOdGiContextForPrcDatabase_41 swigDelegate41;

	private SwigDelegateOdGiContextForPrcDatabase_42 swigDelegate42;

	private SwigDelegateOdGiContextForPrcDatabase_43 swigDelegate43;

	private SwigDelegateOdGiContextForPrcDatabase_44 swigDelegate44;

	private SwigDelegateOdGiContextForPrcDatabase_45 swigDelegate45;

	private SwigDelegateOdGiContextForPrcDatabase_46 swigDelegate46;

	private SwigDelegateOdGiContextForPrcDatabase_47 swigDelegate47;

	private SwigDelegateOdGiContextForPrcDatabase_48 swigDelegate48;

	private SwigDelegateOdGiContextForPrcDatabase_49 swigDelegate49;

	private SwigDelegateOdGiContextForPrcDatabase_50 swigDelegate50;

	private SwigDelegateOdGiContextForPrcDatabase_51 swigDelegate51;

	private SwigDelegateOdGiContextForPrcDatabase_52 swigDelegate52;

	private SwigDelegateOdGiContextForPrcDatabase_53 swigDelegate53;

	private SwigDelegateOdGiContextForPrcDatabase_54 swigDelegate54;

	private SwigDelegateOdGiContextForPrcDatabase_55 swigDelegate55;

	private SwigDelegateOdGiContextForPrcDatabase_56 swigDelegate56;

	private SwigDelegateOdGiContextForPrcDatabase_57 swigDelegate57;

	private SwigDelegateOdGiContextForPrcDatabase_58 swigDelegate58;

	private SwigDelegateOdGiContextForPrcDatabase_59 swigDelegate59;

	private SwigDelegateOdGiContextForPrcDatabase_60 swigDelegate60;

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

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(OdGsClientViewInfo) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiContextForPrcDatabase(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiContextForPrcDatabase obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdGiContextForPrcDatabase(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiContextForPrcDatabase cast(OdRxObject pObj)
	{
		OdGiContextForPrcDatabase rXObject = Helpers.GetRXObject<OdGiContextForPrcDatabase>(OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_isASwigExplicitOdGiContextForPrcDatabase(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_queryXSwigExplicitOdGiContextForPrcDatabase(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcGraphicsValuesStorage graphicsValuesStorage()
	{
		OdPrcGraphicsValuesStorage result = new OdPrcGraphicsValuesStorage(OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_graphicsValuesStorage__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator references()
	{
		std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator result = new std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator(OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_references__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiContextForPrcDatabase_EPRCDrawOptions DrawMode()
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_DrawMode(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiContextForPrcDatabase_EPRCDrawOptions)result;
	}

	public void SetDrawMode(OdGiContextForPrcDatabase_EPRCDrawOptions drawMode)
	{
		OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_SetDrawMode(swigCPtr, (int)drawMode);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiContextForPrcDatabase()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdGiContextForPrcDatabase(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiContextForPrcDatabase) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override OdRxObject database()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("database", swigMethodTypes3) ? OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_databaseSwigExplicitOdGiContextForPrcDatabase(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override bool isPlotGeneration()
	{
		bool result = (SwigDerivedClassHasMethod("isPlotGeneration", swigMethodTypes18) ? OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_isPlotGenerationSwigExplicitOdGiContextForPrcDatabase(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_isPlotGeneration(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setPlotGeneration(bool plotGeneration)
	{
		if (SwigDerivedClassHasMethod("setPlotGeneration", swigMethodTypes52))
		{
			OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_setPlotGenerationSwigExplicitOdGiContextForPrcDatabase(swigCPtr, plotGeneration);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_setPlotGeneration(swigCPtr, plotGeneration);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setPaletteBackground(uint paletteBackground)
	{
		if (SwigDerivedClassHasMethod("setPaletteBackground", swigMethodTypes53))
		{
			OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_setPaletteBackgroundSwigExplicitOdGiContextForPrcDatabase(swigCPtr, paletteBackground);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_setPaletteBackground(swigCPtr, paletteBackground);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGiDrawable openDrawable(OdDbStub drawableId)
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(SwigDerivedClassHasMethod("openDrawable", swigMethodTypes4) ? OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_openDrawableSwigExplicitOdGiContextForPrcDatabase(swigCPtr, OdDbStub.getCPtr(drawableId)) : OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_openDrawable(swigCPtr, OdDbStub.getCPtr(drawableId)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override uint paletteBackground()
	{
		uint result = (SwigDerivedClassHasMethod("paletteBackground", swigMethodTypes19) ? OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_paletteBackgroundSwigExplicitOdGiContextForPrcDatabase(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_paletteBackground(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDatabase(OdPrcFile pPrcFile)
	{
		OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_setDatabase(swigCPtr, OdPrcFile.getCPtr(pPrcFile));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcFile getDatabase()
	{
		OdPrcFile rXObject = Helpers.GetRXObject<OdPrcFile>(OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_getDatabase(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void fillGsClientViewInfo(OdGsClientViewInfo viewInfo)
	{
		if (SwigDerivedClassHasMethod("fillGsClientViewInfo", swigMethodTypes60))
		{
			OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_fillGsClientViewInfoSwigExplicitOdGiContextForPrcDatabase(swigCPtr, OdGsClientViewInfo.getCPtr(viewInfo));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_fillGsClientViewInfo(swigCPtr, OdGsClientViewInfo.getCPtr(viewInfo));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override IntPtr drawableFilterFunctionId(OdDbStub viewportId)
	{
		IntPtr result = (SwigDerivedClassHasMethod("drawableFilterFunctionId", swigMethodTypes34) ? OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_drawableFilterFunctionIdSwigExplicitOdGiContextForPrcDatabase(swigCPtr, OdDbStub.getCPtr(viewportId)) : OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_drawableFilterFunctionId(swigCPtr, OdDbStub.getCPtr(viewportId)));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint drawableFilterFunction(IntPtr functionId, OdGiPathNode pPathNode, uint nFlags)
	{
		uint result = (SwigDerivedClassHasMethod("drawableFilterFunction", swigMethodTypes35) ? OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_drawableFilterFunctionSwigExplicitOdGiContextForPrcDatabase(swigCPtr, functionId, OdGiPathNode.getCPtr(pPathNode), nFlags) : OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_drawableFilterFunction(swigCPtr, functionId, OdGiPathNode.getCPtr(pPathNode), nFlags));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool useGsModel()
	{
		bool result = (SwigDerivedClassHasMethod("useGsModel", swigMethodTypes56) ? OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_useGsModelSwigExplicitOdGiContextForPrcDatabase(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_useGsModel(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void enableGsModel(bool enable)
	{
		if (SwigDerivedClassHasMethod("enableGsModel", swigMethodTypes57))
		{
			OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_enableGsModelSwigExplicitOdGiContextForPrcDatabase(swigCPtr, enable);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_enableGsModel(swigCPtr, enable);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbStub getStubByMaterialId(OdRxObject pBaseDb, ulong materialId)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("getStubByMaterialId", swigMethodTypes45) ? OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_getStubByMaterialIdSwigExplicitOdGiContextForPrcDatabase(swigCPtr, OdRxObject.getCPtr(pBaseDb), materialId) : OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_getStubByMaterialId(swigCPtr, OdRxObject.getCPtr(pBaseDb), materialId));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAlwaysShow(bool bShow)
	{
		OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_setAlwaysShow(swigCPtr, bShow);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isAlwaysShow()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_isAlwaysShow(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiContextForPrcDatabase createObject()
	{
		OdGiContextForPrcDatabase rXObject = Helpers.GetRXObject<OdGiContextForPrcDatabase>(OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setreferences(std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator value)
	{
		OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_setreferences(swigCPtr, std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
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
		OdPrcModule_GlobalsPINVOKE.OdGiContextForPrcDatabase_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiContextForPrcDatabase));
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
				OdPrcModule_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				OdPrcModule_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				OdPrcModule_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
				OdPrcModule_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				OdPrcModule_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				OdPrcModule_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
				OdPrcModule_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				OdPrcModule_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				OdPrcModule_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
				OdPrcModule_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				OdPrcModule_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				OdPrcModule_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodfillGsClientViewInfo(IntPtr viewInfo)
	{
		try
		{
			fillGsClientViewInfo(new OdGsClientViewInfo(viewInfo, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}

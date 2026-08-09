using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMentalRayRenderSettingsTraits : OdGiRenderSettingsTraits
{
	public delegate IntPtr SwigDelegateOdGiMentalRayRenderSettingsTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiMentalRayRenderSettingsTraits_1();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_3(bool enabled);

	public delegate bool SwigDelegateOdGiMentalRayRenderSettingsTraits_4();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_5(bool enabled);

	public delegate bool SwigDelegateOdGiMentalRayRenderSettingsTraits_6();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_7(bool enabled);

	public delegate bool SwigDelegateOdGiMentalRayRenderSettingsTraits_8();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_9(bool enabled);

	public delegate bool SwigDelegateOdGiMentalRayRenderSettingsTraits_10();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_11(bool enabled);

	public delegate bool SwigDelegateOdGiMentalRayRenderSettingsTraits_12();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_13(double scaleFactor);

	public delegate double SwigDelegateOdGiMentalRayRenderSettingsTraits_14();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_15(int min, int max);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_16(int min, int max);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_17(int filter, double width, double height);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_18(OdGiMrFilter_ filter, double width, double height);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_19(float r, float g, float b, float a);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_20(float r, float g, float b, float a);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_21(int mode);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_22();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_23(bool enabled);

	public delegate bool SwigDelegateOdGiMentalRayRenderSettingsTraits_24();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_25(bool enabled);

	public delegate bool SwigDelegateOdGiMentalRayRenderSettingsTraits_26();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_27(int reflection, int refraction, int sum);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_28(int reflection, int refraction, int sum);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_29(bool enabled);

	public delegate bool SwigDelegateOdGiMentalRayRenderSettingsTraits_30();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_31(int num);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_32();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_33(bool enabled);

	public delegate bool SwigDelegateOdGiMentalRayRenderSettingsTraits_34();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_35(double radius);

	public delegate double SwigDelegateOdGiMentalRayRenderSettingsTraits_36();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_37(int num);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_38();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_39(int reflection, int refraction, int sum);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_40(int reflection, int refraction, int sum);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_41(bool enabled);

	public delegate bool SwigDelegateOdGiMentalRayRenderSettingsTraits_42();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_43(int num);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_44();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_45(bool bMin, bool bMax, bool bPixels);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_46(bool bMin, bool bMax, bool bPixels);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_47(double min, double max);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_48(double min, double max);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_49(double luminance);

	public delegate double SwigDelegateOdGiMentalRayRenderSettingsTraits_50();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_51(int mode);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_52();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_53(int mode, float fSize);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_54(OdGiMrDiagnosticGridMode_ mode, float fSize);

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_55(int mode);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_56();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_57(int mode);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_58();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_59(bool enabled);

	public delegate bool SwigDelegateOdGiMentalRayRenderSettingsTraits_60();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_61([MarshalAs(UnmanagedType.LPWStr)] string miName);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGiMentalRayRenderSettingsTraits_62();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_63(int size);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_64();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_65(int order);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_66();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_67(int limit);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_68();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_69(float fScale);

	public delegate float SwigDelegateOdGiMentalRayRenderSettingsTraits_70();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_71(IntPtr pMonitor);

	public delegate IntPtr SwigDelegateOdGiMentalRayRenderSettingsTraits_72();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_73(int type);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_74();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_75(int mode);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_76();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_77(double multiplier);

	public delegate double SwigDelegateOdGiMentalRayRenderSettingsTraits_78();

	public delegate void SwigDelegateOdGiMentalRayRenderSettingsTraits_79(int mode);

	public delegate int SwigDelegateOdGiMentalRayRenderSettingsTraits_80();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_0 swigDelegate0;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_1 swigDelegate1;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_2 swigDelegate2;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_3 swigDelegate3;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_4 swigDelegate4;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_5 swigDelegate5;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_6 swigDelegate6;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_7 swigDelegate7;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_8 swigDelegate8;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_9 swigDelegate9;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_10 swigDelegate10;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_11 swigDelegate11;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_12 swigDelegate12;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_13 swigDelegate13;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_14 swigDelegate14;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_15 swigDelegate15;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_16 swigDelegate16;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_17 swigDelegate17;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_18 swigDelegate18;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_19 swigDelegate19;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_20 swigDelegate20;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_21 swigDelegate21;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_22 swigDelegate22;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_23 swigDelegate23;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_24 swigDelegate24;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_25 swigDelegate25;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_26 swigDelegate26;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_27 swigDelegate27;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_28 swigDelegate28;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_29 swigDelegate29;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_30 swigDelegate30;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_31 swigDelegate31;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_32 swigDelegate32;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_33 swigDelegate33;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_34 swigDelegate34;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_35 swigDelegate35;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_36 swigDelegate36;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_37 swigDelegate37;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_38 swigDelegate38;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_39 swigDelegate39;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_40 swigDelegate40;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_41 swigDelegate41;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_42 swigDelegate42;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_43 swigDelegate43;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_44 swigDelegate44;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_45 swigDelegate45;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_46 swigDelegate46;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_47 swigDelegate47;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_48 swigDelegate48;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_49 swigDelegate49;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_50 swigDelegate50;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_51 swigDelegate51;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_52 swigDelegate52;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_53 swigDelegate53;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_54 swigDelegate54;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_55 swigDelegate55;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_56 swigDelegate56;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_57 swigDelegate57;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_58 swigDelegate58;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_59 swigDelegate59;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_60 swigDelegate60;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_61 swigDelegate61;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_62 swigDelegate62;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_63 swigDelegate63;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_64 swigDelegate64;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_65 swigDelegate65;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_66 swigDelegate66;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_67 swigDelegate67;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_68 swigDelegate68;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_69 swigDelegate69;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_70 swigDelegate70;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_71 swigDelegate71;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_72 swigDelegate72;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_73 swigDelegate73;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_74 swigDelegate74;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_75 swigDelegate75;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_76 swigDelegate76;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_77 swigDelegate77;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_78 swigDelegate78;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_79 swigDelegate79;

	private SwigDelegateOdGiMentalRayRenderSettingsTraits_80 swigDelegate80;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes16 = new Type[2]
	{
		typeof(int).MakeByRefType(),
		typeof(int).MakeByRefType()
	};

	private static Type[] swigMethodTypes17 = new Type[3]
	{
		typeof(OdGiMrFilter_),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes18 = new Type[3]
	{
		typeof(OdGiMrFilter_).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes19 = new Type[4]
	{
		typeof(float),
		typeof(float),
		typeof(float),
		typeof(float)
	};

	private static Type[] swigMethodTypes20 = new Type[4]
	{
		typeof(float).MakeByRefType(),
		typeof(float).MakeByRefType(),
		typeof(float).MakeByRefType(),
		typeof(float).MakeByRefType()
	};

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGiMrShadowMode_) };

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes24 = new Type[0];

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes28 = new Type[3]
	{
		typeof(int).MakeByRefType(),
		typeof(int).MakeByRefType(),
		typeof(int).MakeByRefType()
	};

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes30 = new Type[0];

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes38 = new Type[0];

	private static Type[] swigMethodTypes39 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes40 = new Type[3]
	{
		typeof(int).MakeByRefType(),
		typeof(int).MakeByRefType(),
		typeof(int).MakeByRefType()
	};

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes42 = new Type[0];

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes44 = new Type[0];

	private static Type[] swigMethodTypes45 = new Type[3]
	{
		typeof(bool),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes46 = new Type[3]
	{
		typeof(bool).MakeByRefType(),
		typeof(bool).MakeByRefType(),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes47 = new Type[2]
	{
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes48 = new Type[2]
	{
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdGiMrDiagnosticMode_) };

	private static Type[] swigMethodTypes52 = new Type[0];

	private static Type[] swigMethodTypes53 = new Type[2]
	{
		typeof(OdGiMrDiagnosticGridMode_),
		typeof(float)
	};

	private static Type[] swigMethodTypes54 = new Type[2]
	{
		typeof(OdGiMrDiagnosticGridMode_).MakeByRefType(),
		typeof(float).MakeByRefType()
	};

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdGiMrDiagnosticPhotonMode_) };

	private static Type[] swigMethodTypes56 = new Type[0];

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(OdGiMrDiagnosticBSPMode_) };

	private static Type[] swigMethodTypes58 = new Type[0];

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes60 = new Type[0];

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes62 = new Type[0];

	private static Type[] swigMethodTypes63 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes64 = new Type[0];

	private static Type[] swigMethodTypes65 = new Type[1] { typeof(OdGiMrTileOrder_) };

	private static Type[] swigMethodTypes66 = new Type[0];

	private static Type[] swigMethodTypes67 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes68 = new Type[0];

	private static Type[] swigMethodTypes69 = new Type[1] { typeof(float) };

	private static Type[] swigMethodTypes70 = new Type[0];

	private static Type[] swigMethodTypes71 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes72 = new Type[0];

	private static Type[] swigMethodTypes73 = new Type[1] { typeof(OdGiMrExposureType_) };

	private static Type[] swigMethodTypes74 = new Type[0];

	private static Type[] swigMethodTypes75 = new Type[1] { typeof(OdGiMrFinalGatheringMode_) };

	private static Type[] swigMethodTypes76 = new Type[0];

	private static Type[] swigMethodTypes77 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes78 = new Type[0];

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(OdGiMrExportMIMode_) };

	private static Type[] swigMethodTypes80 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMentalRayRenderSettingsTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMentalRayRenderSettingsTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMentalRayRenderSettingsTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMentalRayRenderSettingsTraits cast(OdRxObject pObj)
	{
		OdGiMentalRayRenderSettingsTraits rXObject = Helpers.GetRXObject<OdGiMentalRayRenderSettingsTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_isASwigExplicitOdGiMentalRayRenderSettingsTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_queryXSwigExplicitOdGiMentalRayRenderSettingsTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiMentalRayRenderSettingsTraits createObject()
	{
		OdGiMentalRayRenderSettingsTraits rXObject = Helpers.GetRXObject<OdGiMentalRayRenderSettingsTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setSampling(int min, int max)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setSampling(swigCPtr, min, max);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void sampling(out int min, out int max)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_sampling(swigCPtr, out min, out max);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSamplingFilter(OdGiMrFilter_ filter, double width, double height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setSamplingFilter(swigCPtr, (int)filter, width, height);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void SamplingFilter(out OdGiMrFilter_ filter, out double width, out double height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_SamplingFilter(swigCPtr, out filter, out width, out height);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSamplingContrastColor(float r, float g, float b, float a)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setSamplingContrastColor(swigCPtr, r, g, b, a);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void samplingContrastColor(out float r, out float g, out float b, out float a)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_samplingContrastColor(swigCPtr, out r, out g, out b, out a);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setShadowMode(OdGiMrShadowMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setShadowMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMrShadowMode_ shadowMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_shadowMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrShadowMode_)result;
	}

	public virtual void setShadowMapEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setShadowMapEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool shadowMapEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_shadowMapEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRayTraceEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setRayTraceEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool rayTraceEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_rayTraceEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRayTraceDepth(int reflection, int refraction, int sum)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setRayTraceDepth(swigCPtr, reflection, refraction, sum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rayTraceDepth(out int reflection, out int refraction, out int sum)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_rayTraceDepth(swigCPtr, out reflection, out refraction, out sum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGlobalIlluminationEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setGlobalIlluminationEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool globalIlluminationEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_globalIlluminationEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGISampleCount(int num)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setGISampleCount(swigCPtr, num);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int giSampleCount()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_giSampleCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGISampleRadiusEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setGISampleRadiusEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool giSampleRadiusEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_giSampleRadiusEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGISampleRadius(double radius)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setGISampleRadius(swigCPtr, radius);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double giSampleRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_giSampleRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGIPhotonsPerLight(int num)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setGIPhotonsPerLight(swigCPtr, num);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int giPhotonsPerLight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_giPhotonsPerLight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPhotonTraceDepth(int reflection, int refraction, int sum)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setPhotonTraceDepth(swigCPtr, reflection, refraction, sum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void photonTraceDepth(out int reflection, out int refraction, out int sum)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_photonTraceDepth(swigCPtr, out reflection, out refraction, out sum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFinalGatheringEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setFinalGatheringEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool finalGatheringEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_finalGatheringEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFGRayCount(int num)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setFGRayCount(swigCPtr, num);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int fgRayCount()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_fgRayCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFGRadiusState(bool bMin, bool bMax, bool bPixels)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setFGRadiusState(swigCPtr, bMin, bMax, bPixels);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void fgSampleRadiusState(out bool bMin, out bool bMax, out bool bPixels)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_fgSampleRadiusState(swigCPtr, out bMin, out bMax, out bPixels);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFGSampleRadius(double min, double max)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setFGSampleRadius(swigCPtr, min, max);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void fgSampleRadius(out double min, out double max)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_fgSampleRadius(swigCPtr, out min, out max);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLightLuminanceScale(double luminance)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setLightLuminanceScale(swigCPtr, luminance);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double lightLuminanceScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_lightLuminanceScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDiagnosticMode(OdGiMrDiagnosticMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setDiagnosticMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMrDiagnosticMode_ diagnosticMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_diagnosticMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrDiagnosticMode_)result;
	}

	public virtual void setDiagnosticGridMode(OdGiMrDiagnosticGridMode_ mode, float fSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setDiagnosticGridMode(swigCPtr, (int)mode, fSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void diagnosticGridMode(out OdGiMrDiagnosticGridMode_ mode, out float fSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_diagnosticGridMode(swigCPtr, out mode, out fSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDiagnosticPhotonMode(OdGiMrDiagnosticPhotonMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setDiagnosticPhotonMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMrDiagnosticPhotonMode_ diagnosticPhotonMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_diagnosticPhotonMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrDiagnosticPhotonMode_)result;
	}

	public virtual void setDiagnosticBSPMode(OdGiMrDiagnosticBSPMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setDiagnosticBSPMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMrDiagnosticBSPMode_ diagnosticBSPMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_diagnosticBSPMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrDiagnosticBSPMode_)result;
	}

	public virtual void setExportMIEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setExportMIEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool exportMIEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_exportMIEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setExportMIFileName(string miName)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setExportMIFileName(swigCPtr, miName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string exportMIFileName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_exportMIFileName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTileSize(int size)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setTileSize(swigCPtr, size);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int tileSize()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_tileSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTileOrder(OdGiMrTileOrder_ order)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setTileOrder(swigCPtr, (int)order);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMrTileOrder_ tileOrder()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_tileOrder(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrTileOrder_)result;
	}

	public virtual void setMemoryLimit(int limit)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setMemoryLimit(swigCPtr, limit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int memoryLimit()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_memoryLimit(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEnergyMultiplier(float fScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setEnergyMultiplier(swigCPtr, fScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual float energyMultiplier()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_energyMultiplier(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setProgressMonitor(IntPtr pMonitor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setProgressMonitor(swigCPtr, pMonitor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual IntPtr progressMonitor()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_progressMonitor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setExposureType(OdGiMrExposureType_ type)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setExposureType(swigCPtr, (int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMrExposureType_ exposureType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_exposureType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrExposureType_)result;
	}

	public virtual void setFinalGatheringMode(OdGiMrFinalGatheringMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setFinalGatheringMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMrFinalGatheringMode_ finalGatheringMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_finalGatheringMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrFinalGatheringMode_)result;
	}

	public virtual void setShadowSamplingMultiplier(double multiplier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setShadowSamplingMultiplier(swigCPtr, multiplier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double shadowSamplingMultiplier()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_shadowSamplingMultiplier(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setExportMIMode(OdGiMrExportMIMode_ mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_setExportMIMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMrExportMIMode_ exportMIMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_exportMIMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMrExportMIMode_)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMentalRayRenderSettingsTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMentalRayRenderSettingsTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMentalRayRenderSettingsTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setMaterialEnabled", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetMaterialEnabled;
		}
		if (SwigDerivedClassHasMethod("materialEnabled", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodmaterialEnabled;
		}
		if (SwigDerivedClassHasMethod("setTextureSampling", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetTextureSampling;
		}
		if (SwigDerivedClassHasMethod("textureSampling", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodtextureSampling;
		}
		if (SwigDerivedClassHasMethod("setBackFacesEnabled", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetBackFacesEnabled;
		}
		if (SwigDerivedClassHasMethod("backFacesEnabled", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodbackFacesEnabled;
		}
		if (SwigDerivedClassHasMethod("setShadowsEnabled", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetShadowsEnabled;
		}
		if (SwigDerivedClassHasMethod("shadowsEnabled", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodshadowsEnabled;
		}
		if (SwigDerivedClassHasMethod("setDiagnosticBackgroundEnabled", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetDiagnosticBackgroundEnabled;
		}
		if (SwigDerivedClassHasMethod("diagnosticBackgroundEnabled", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethoddiagnosticBackgroundEnabled;
		}
		if (SwigDerivedClassHasMethod("setModelScaleFactor", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetModelScaleFactor;
		}
		if (SwigDerivedClassHasMethod("modelScaleFactor", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodmodelScaleFactor;
		}
		if (SwigDerivedClassHasMethod("setSampling", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetSampling;
		}
		if (SwigDerivedClassHasMethod("sampling", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsampling;
		}
		if (SwigDerivedClassHasMethod("setSamplingFilter", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetSamplingFilter;
		}
		if (SwigDerivedClassHasMethod("SamplingFilter", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodSamplingFilter;
		}
		if (SwigDerivedClassHasMethod("setSamplingContrastColor", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetSamplingContrastColor;
		}
		if (SwigDerivedClassHasMethod("samplingContrastColor", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsamplingContrastColor;
		}
		if (SwigDerivedClassHasMethod("setShadowMode", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetShadowMode;
		}
		if (SwigDerivedClassHasMethod("shadowMode", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodshadowMode;
		}
		if (SwigDerivedClassHasMethod("setShadowMapEnabled", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodsetShadowMapEnabled;
		}
		if (SwigDerivedClassHasMethod("shadowMapEnabled", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodshadowMapEnabled;
		}
		if (SwigDerivedClassHasMethod("setRayTraceEnabled", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetRayTraceEnabled;
		}
		if (SwigDerivedClassHasMethod("rayTraceEnabled", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodrayTraceEnabled;
		}
		if (SwigDerivedClassHasMethod("setRayTraceDepth", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodsetRayTraceDepth;
		}
		if (SwigDerivedClassHasMethod("rayTraceDepth", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodrayTraceDepth;
		}
		if (SwigDerivedClassHasMethod("setGlobalIlluminationEnabled", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodsetGlobalIlluminationEnabled;
		}
		if (SwigDerivedClassHasMethod("globalIlluminationEnabled", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodglobalIlluminationEnabled;
		}
		if (SwigDerivedClassHasMethod("setGISampleCount", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodsetGISampleCount;
		}
		if (SwigDerivedClassHasMethod("giSampleCount", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodgiSampleCount;
		}
		if (SwigDerivedClassHasMethod("setGISampleRadiusEnabled", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodsetGISampleRadiusEnabled;
		}
		if (SwigDerivedClassHasMethod("giSampleRadiusEnabled", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodgiSampleRadiusEnabled;
		}
		if (SwigDerivedClassHasMethod("setGISampleRadius", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodsetGISampleRadius;
		}
		if (SwigDerivedClassHasMethod("giSampleRadius", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodgiSampleRadius;
		}
		if (SwigDerivedClassHasMethod("setGIPhotonsPerLight", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodsetGIPhotonsPerLight;
		}
		if (SwigDerivedClassHasMethod("giPhotonsPerLight", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodgiPhotonsPerLight;
		}
		if (SwigDerivedClassHasMethod("setPhotonTraceDepth", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodsetPhotonTraceDepth;
		}
		if (SwigDerivedClassHasMethod("photonTraceDepth", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodphotonTraceDepth;
		}
		if (SwigDerivedClassHasMethod("setFinalGatheringEnabled", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodsetFinalGatheringEnabled;
		}
		if (SwigDerivedClassHasMethod("finalGatheringEnabled", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodfinalGatheringEnabled;
		}
		if (SwigDerivedClassHasMethod("setFGRayCount", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodsetFGRayCount;
		}
		if (SwigDerivedClassHasMethod("fgRayCount", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodfgRayCount;
		}
		if (SwigDerivedClassHasMethod("setFGRadiusState", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodsetFGRadiusState;
		}
		if (SwigDerivedClassHasMethod("fgSampleRadiusState", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodfgSampleRadiusState;
		}
		if (SwigDerivedClassHasMethod("setFGSampleRadius", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodsetFGSampleRadius;
		}
		if (SwigDerivedClassHasMethod("fgSampleRadius", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodfgSampleRadius;
		}
		if (SwigDerivedClassHasMethod("setLightLuminanceScale", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodsetLightLuminanceScale;
		}
		if (SwigDerivedClassHasMethod("lightLuminanceScale", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodlightLuminanceScale;
		}
		if (SwigDerivedClassHasMethod("setDiagnosticMode", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodsetDiagnosticMode;
		}
		if (SwigDerivedClassHasMethod("diagnosticMode", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethoddiagnosticMode;
		}
		if (SwigDerivedClassHasMethod("setDiagnosticGridMode", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodsetDiagnosticGridMode;
		}
		if (SwigDerivedClassHasMethod("diagnosticGridMode", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethoddiagnosticGridMode;
		}
		if (SwigDerivedClassHasMethod("setDiagnosticPhotonMode", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodsetDiagnosticPhotonMode;
		}
		if (SwigDerivedClassHasMethod("diagnosticPhotonMode", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethoddiagnosticPhotonMode;
		}
		if (SwigDerivedClassHasMethod("setDiagnosticBSPMode", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodsetDiagnosticBSPMode;
		}
		if (SwigDerivedClassHasMethod("diagnosticBSPMode", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethoddiagnosticBSPMode;
		}
		if (SwigDerivedClassHasMethod("setExportMIEnabled", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodsetExportMIEnabled;
		}
		if (SwigDerivedClassHasMethod("exportMIEnabled", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodexportMIEnabled;
		}
		if (SwigDerivedClassHasMethod("setExportMIFileName", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodsetExportMIFileName;
		}
		if (SwigDerivedClassHasMethod("exportMIFileName", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodexportMIFileName;
		}
		if (SwigDerivedClassHasMethod("setTileSize", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodsetTileSize;
		}
		if (SwigDerivedClassHasMethod("tileSize", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodtileSize;
		}
		if (SwigDerivedClassHasMethod("setTileOrder", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodsetTileOrder;
		}
		if (SwigDerivedClassHasMethod("tileOrder", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodtileOrder;
		}
		if (SwigDerivedClassHasMethod("setMemoryLimit", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodsetMemoryLimit;
		}
		if (SwigDerivedClassHasMethod("memoryLimit", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodmemoryLimit;
		}
		if (SwigDerivedClassHasMethod("setEnergyMultiplier", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodsetEnergyMultiplier;
		}
		if (SwigDerivedClassHasMethod("energyMultiplier", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodenergyMultiplier;
		}
		if (SwigDerivedClassHasMethod("setProgressMonitor", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodsetProgressMonitor;
		}
		if (SwigDerivedClassHasMethod("progressMonitor", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodprogressMonitor;
		}
		if (SwigDerivedClassHasMethod("setExposureType", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodsetExposureType;
		}
		if (SwigDerivedClassHasMethod("exposureType", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodexposureType;
		}
		if (SwigDerivedClassHasMethod("setFinalGatheringMode", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodsetFinalGatheringMode;
		}
		if (SwigDerivedClassHasMethod("finalGatheringMode", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodfinalGatheringMode;
		}
		if (SwigDerivedClassHasMethod("setShadowSamplingMultiplier", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodsetShadowSamplingMultiplier;
		}
		if (SwigDerivedClassHasMethod("shadowSamplingMultiplier", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodshadowSamplingMultiplier;
		}
		if (SwigDerivedClassHasMethod("setExportMIMode", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodsetExportMIMode;
		}
		if (SwigDerivedClassHasMethod("exportMIMode", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodexportMIMode;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMentalRayRenderSettingsTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMentalRayRenderSettingsTraits));
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

	private void SwigDirectorMethodsetMaterialEnabled(bool enabled)
	{
		try
		{
			setMaterialEnabled(enabled);
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

	private bool SwigDirectorMethodmaterialEnabled()
	{
		return materialEnabled();
	}

	private void SwigDirectorMethodsetTextureSampling(bool enabled)
	{
		try
		{
			setTextureSampling(enabled);
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

	private bool SwigDirectorMethodtextureSampling()
	{
		return textureSampling();
	}

	private void SwigDirectorMethodsetBackFacesEnabled(bool enabled)
	{
		try
		{
			setBackFacesEnabled(enabled);
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

	private bool SwigDirectorMethodbackFacesEnabled()
	{
		return backFacesEnabled();
	}

	private void SwigDirectorMethodsetShadowsEnabled(bool enabled)
	{
		try
		{
			setShadowsEnabled(enabled);
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

	private bool SwigDirectorMethodshadowsEnabled()
	{
		return shadowsEnabled();
	}

	private void SwigDirectorMethodsetDiagnosticBackgroundEnabled(bool enabled)
	{
		try
		{
			setDiagnosticBackgroundEnabled(enabled);
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

	private bool SwigDirectorMethoddiagnosticBackgroundEnabled()
	{
		return diagnosticBackgroundEnabled();
	}

	private void SwigDirectorMethodsetModelScaleFactor(double scaleFactor)
	{
		try
		{
			setModelScaleFactor(scaleFactor);
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

	private double SwigDirectorMethodmodelScaleFactor()
	{
		return modelScaleFactor();
	}

	private void SwigDirectorMethodsetSampling(int min, int max)
	{
		try
		{
			setSampling(min, max);
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

	private void SwigDirectorMethodsampling(int min, int max)
	{
		try
		{
			sampling(out min, out max);
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

	private void SwigDirectorMethodsetSamplingFilter(int filter, double width, double height)
	{
		try
		{
			setSamplingFilter((OdGiMrFilter_)filter, width, height);
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

	private void SwigDirectorMethodSamplingFilter(OdGiMrFilter_ filter, double width, double height)
	{
		try
		{
			SamplingFilter(out filter, out width, out height);
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

	private void SwigDirectorMethodsetSamplingContrastColor(float r, float g, float b, float a)
	{
		try
		{
			setSamplingContrastColor(r, g, b, a);
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

	private void SwigDirectorMethodsamplingContrastColor(float r, float g, float b, float a)
	{
		try
		{
			samplingContrastColor(out r, out g, out b, out a);
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

	private void SwigDirectorMethodsetShadowMode(int mode)
	{
		try
		{
			setShadowMode((OdGiMrShadowMode_)mode);
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

	private int SwigDirectorMethodshadowMode()
	{
		return (int)shadowMode();
	}

	private void SwigDirectorMethodsetShadowMapEnabled(bool enabled)
	{
		try
		{
			setShadowMapEnabled(enabled);
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

	private bool SwigDirectorMethodshadowMapEnabled()
	{
		return shadowMapEnabled();
	}

	private void SwigDirectorMethodsetRayTraceEnabled(bool enabled)
	{
		try
		{
			setRayTraceEnabled(enabled);
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

	private bool SwigDirectorMethodrayTraceEnabled()
	{
		return rayTraceEnabled();
	}

	private void SwigDirectorMethodsetRayTraceDepth(int reflection, int refraction, int sum)
	{
		try
		{
			setRayTraceDepth(reflection, refraction, sum);
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

	private void SwigDirectorMethodrayTraceDepth(int reflection, int refraction, int sum)
	{
		try
		{
			rayTraceDepth(out reflection, out refraction, out sum);
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

	private void SwigDirectorMethodsetGlobalIlluminationEnabled(bool enabled)
	{
		try
		{
			setGlobalIlluminationEnabled(enabled);
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

	private bool SwigDirectorMethodglobalIlluminationEnabled()
	{
		return globalIlluminationEnabled();
	}

	private void SwigDirectorMethodsetGISampleCount(int num)
	{
		try
		{
			setGISampleCount(num);
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

	private int SwigDirectorMethodgiSampleCount()
	{
		return giSampleCount();
	}

	private void SwigDirectorMethodsetGISampleRadiusEnabled(bool enabled)
	{
		try
		{
			setGISampleRadiusEnabled(enabled);
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

	private bool SwigDirectorMethodgiSampleRadiusEnabled()
	{
		return giSampleRadiusEnabled();
	}

	private void SwigDirectorMethodsetGISampleRadius(double radius)
	{
		try
		{
			setGISampleRadius(radius);
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

	private double SwigDirectorMethodgiSampleRadius()
	{
		return giSampleRadius();
	}

	private void SwigDirectorMethodsetGIPhotonsPerLight(int num)
	{
		try
		{
			setGIPhotonsPerLight(num);
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

	private int SwigDirectorMethodgiPhotonsPerLight()
	{
		return giPhotonsPerLight();
	}

	private void SwigDirectorMethodsetPhotonTraceDepth(int reflection, int refraction, int sum)
	{
		try
		{
			setPhotonTraceDepth(reflection, refraction, sum);
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

	private void SwigDirectorMethodphotonTraceDepth(int reflection, int refraction, int sum)
	{
		try
		{
			photonTraceDepth(out reflection, out refraction, out sum);
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

	private void SwigDirectorMethodsetFinalGatheringEnabled(bool enabled)
	{
		try
		{
			setFinalGatheringEnabled(enabled);
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

	private bool SwigDirectorMethodfinalGatheringEnabled()
	{
		return finalGatheringEnabled();
	}

	private void SwigDirectorMethodsetFGRayCount(int num)
	{
		try
		{
			setFGRayCount(num);
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

	private int SwigDirectorMethodfgRayCount()
	{
		return fgRayCount();
	}

	private void SwigDirectorMethodsetFGRadiusState(bool bMin, bool bMax, bool bPixels)
	{
		try
		{
			setFGRadiusState(bMin, bMax, bPixels);
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

	private void SwigDirectorMethodfgSampleRadiusState(bool bMin, bool bMax, bool bPixels)
	{
		try
		{
			fgSampleRadiusState(out bMin, out bMax, out bPixels);
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

	private void SwigDirectorMethodsetFGSampleRadius(double min, double max)
	{
		try
		{
			setFGSampleRadius(min, max);
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

	private void SwigDirectorMethodfgSampleRadius(double min, double max)
	{
		try
		{
			fgSampleRadius(out min, out max);
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

	private void SwigDirectorMethodsetLightLuminanceScale(double luminance)
	{
		try
		{
			setLightLuminanceScale(luminance);
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

	private double SwigDirectorMethodlightLuminanceScale()
	{
		return lightLuminanceScale();
	}

	private void SwigDirectorMethodsetDiagnosticMode(int mode)
	{
		try
		{
			setDiagnosticMode((OdGiMrDiagnosticMode_)mode);
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

	private int SwigDirectorMethoddiagnosticMode()
	{
		return (int)diagnosticMode();
	}

	private void SwigDirectorMethodsetDiagnosticGridMode(int mode, float fSize)
	{
		try
		{
			setDiagnosticGridMode((OdGiMrDiagnosticGridMode_)mode, fSize);
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

	private void SwigDirectorMethoddiagnosticGridMode(OdGiMrDiagnosticGridMode_ mode, float fSize)
	{
		try
		{
			diagnosticGridMode(out mode, out fSize);
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

	private void SwigDirectorMethodsetDiagnosticPhotonMode(int mode)
	{
		try
		{
			setDiagnosticPhotonMode((OdGiMrDiagnosticPhotonMode_)mode);
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

	private int SwigDirectorMethoddiagnosticPhotonMode()
	{
		return (int)diagnosticPhotonMode();
	}

	private void SwigDirectorMethodsetDiagnosticBSPMode(int mode)
	{
		try
		{
			setDiagnosticBSPMode((OdGiMrDiagnosticBSPMode_)mode);
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

	private int SwigDirectorMethoddiagnosticBSPMode()
	{
		return (int)diagnosticBSPMode();
	}

	private void SwigDirectorMethodsetExportMIEnabled(bool enabled)
	{
		try
		{
			setExportMIEnabled(enabled);
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

	private bool SwigDirectorMethodexportMIEnabled()
	{
		return exportMIEnabled();
	}

	private void SwigDirectorMethodsetExportMIFileName([MarshalAs(UnmanagedType.LPWStr)] string miName)
	{
		try
		{
			setExportMIFileName(miName);
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodexportMIFileName()
	{
		return exportMIFileName();
	}

	private void SwigDirectorMethodsetTileSize(int size)
	{
		try
		{
			setTileSize(size);
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

	private int SwigDirectorMethodtileSize()
	{
		return tileSize();
	}

	private void SwigDirectorMethodsetTileOrder(int order)
	{
		try
		{
			setTileOrder((OdGiMrTileOrder_)order);
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

	private int SwigDirectorMethodtileOrder()
	{
		return (int)tileOrder();
	}

	private void SwigDirectorMethodsetMemoryLimit(int limit)
	{
		try
		{
			setMemoryLimit(limit);
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

	private int SwigDirectorMethodmemoryLimit()
	{
		return memoryLimit();
	}

	private void SwigDirectorMethodsetEnergyMultiplier(float fScale)
	{
		try
		{
			setEnergyMultiplier(fScale);
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

	private float SwigDirectorMethodenergyMultiplier()
	{
		return energyMultiplier();
	}

	private void SwigDirectorMethodsetProgressMonitor(IntPtr pMonitor)
	{
		try
		{
			setProgressMonitor(pMonitor);
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

	private IntPtr SwigDirectorMethodprogressMonitor()
	{
		return progressMonitor();
	}

	private void SwigDirectorMethodsetExposureType(int type)
	{
		try
		{
			setExposureType((OdGiMrExposureType_)type);
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

	private int SwigDirectorMethodexposureType()
	{
		return (int)exposureType();
	}

	private void SwigDirectorMethodsetFinalGatheringMode(int mode)
	{
		try
		{
			setFinalGatheringMode((OdGiMrFinalGatheringMode_)mode);
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

	private int SwigDirectorMethodfinalGatheringMode()
	{
		return (int)finalGatheringMode();
	}

	private void SwigDirectorMethodsetShadowSamplingMultiplier(double multiplier)
	{
		try
		{
			setShadowSamplingMultiplier(multiplier);
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

	private double SwigDirectorMethodshadowSamplingMultiplier()
	{
		return shadowSamplingMultiplier();
	}

	private void SwigDirectorMethodsetExportMIMode(int mode)
	{
		try
		{
			setExportMIMode((OdGiMrExportMIMode_)mode);
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

	private int SwigDirectorMethodexportMIMode()
	{
		return (int)exportMIMode();
	}
}

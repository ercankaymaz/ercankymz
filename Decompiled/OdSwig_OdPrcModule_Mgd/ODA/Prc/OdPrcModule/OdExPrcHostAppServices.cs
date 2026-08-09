using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdExPrcHostAppServices : OdPrcHostAppServices
{
	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_1();

	public delegate void SwigDelegateOdExPrcHostAppServices_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_3([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb, int hint);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_4([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_5([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_6();

	public delegate void SwigDelegateOdExPrcHostAppServices_7(IntPtr pProgressMeter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_8();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_9();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_10();

	public delegate int SwigDelegateOdExPrcHostAppServices_11();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_12();

	public delegate int SwigDelegateOdExPrcHostAppServices_13();

	public delegate int SwigDelegateOdExPrcHostAppServices_14();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_15();

	public delegate void SwigDelegateOdExPrcHostAppServices_16([MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateOdExPrcHostAppServices_17(string warnVisGroup, [MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateOdExPrcHostAppServices_18(int warningOb);

	public delegate void SwigDelegateOdExPrcHostAppServices_19(string warnVisGroup, int warningOb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_20(uint errorCode);

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_21();

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_22();

	public delegate void SwigDelegateOdExPrcHostAppServices_23(IntPtr pAuditInfo, [MarshalAs(UnmanagedType.LPWStr)] string strLine, int printDest);

	public delegate bool SwigDelegateOdExPrcHostAppServices_24(IntPtr description, IntPtr filename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_25();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_26();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_27([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_28([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_29(IntPtr pFont, char unicodeChar, IntPtr pDb);

	public delegate bool SwigDelegateOdExPrcHostAppServices_30(IntPtr aDirs);

	public delegate void SwigDelegateOdExPrcHostAppServices_31(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath, [MarshalAs(UnmanagedType.LPWStr)] string sFilter);

	public delegate void SwigDelegateOdExPrcHostAppServices_32(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_33(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename, [MarshalAs(UnmanagedType.LPWStr)] string filter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_34(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_35(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_36(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_37(int flags);

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_38(IntPtr pViewObj, IntPtr pDb, uint flags);

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_39(IntPtr pViewObj, IntPtr pDb);

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_40(IntPtr pViewObj);

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_41();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_42();

	public delegate short SwigDelegateOdExPrcHostAppServices_43();

	public delegate int SwigDelegateOdExPrcHostAppServices_44(int mtMode);

	public delegate int SwigDelegateOdExPrcHostAppServices_45(IntPtr bbuilder, int bbType);

	public delegate int SwigDelegateOdExPrcHostAppServices_46([MarshalAs(UnmanagedType.LPWStr)] string varName, IntPtr value);

	public delegate int SwigDelegateOdExPrcHostAppServices_47([MarshalAs(UnmanagedType.LPWStr)] string varName, [MarshalAs(UnmanagedType.LPWStr)] string newValue);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_48(int unFormat);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdExPrcHostAppServices_49();

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_50();

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_51(int defaultContent);

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_52();

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_53(IntPtr pFileBuff);

	public delegate IntPtr SwigDelegateOdExPrcHostAppServices_54([MarshalAs(UnmanagedType.LPWStr)] string file);

	public delegate int SwigDelegateOdExPrcHostAppServices_55(IntPtr params_);

	public delegate int SwigDelegateOdExPrcHostAppServices_56(IntPtr params_);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdExPrcHostAppServices_0 swigDelegate0;

	private SwigDelegateOdExPrcHostAppServices_1 swigDelegate1;

	private SwigDelegateOdExPrcHostAppServices_2 swigDelegate2;

	private SwigDelegateOdExPrcHostAppServices_3 swigDelegate3;

	private SwigDelegateOdExPrcHostAppServices_4 swigDelegate4;

	private SwigDelegateOdExPrcHostAppServices_5 swigDelegate5;

	private SwigDelegateOdExPrcHostAppServices_6 swigDelegate6;

	private SwigDelegateOdExPrcHostAppServices_7 swigDelegate7;

	private SwigDelegateOdExPrcHostAppServices_8 swigDelegate8;

	private SwigDelegateOdExPrcHostAppServices_9 swigDelegate9;

	private SwigDelegateOdExPrcHostAppServices_10 swigDelegate10;

	private SwigDelegateOdExPrcHostAppServices_11 swigDelegate11;

	private SwigDelegateOdExPrcHostAppServices_12 swigDelegate12;

	private SwigDelegateOdExPrcHostAppServices_13 swigDelegate13;

	private SwigDelegateOdExPrcHostAppServices_14 swigDelegate14;

	private SwigDelegateOdExPrcHostAppServices_15 swigDelegate15;

	private SwigDelegateOdExPrcHostAppServices_16 swigDelegate16;

	private SwigDelegateOdExPrcHostAppServices_17 swigDelegate17;

	private SwigDelegateOdExPrcHostAppServices_18 swigDelegate18;

	private SwigDelegateOdExPrcHostAppServices_19 swigDelegate19;

	private SwigDelegateOdExPrcHostAppServices_20 swigDelegate20;

	private SwigDelegateOdExPrcHostAppServices_21 swigDelegate21;

	private SwigDelegateOdExPrcHostAppServices_22 swigDelegate22;

	private SwigDelegateOdExPrcHostAppServices_23 swigDelegate23;

	private SwigDelegateOdExPrcHostAppServices_24 swigDelegate24;

	private SwigDelegateOdExPrcHostAppServices_25 swigDelegate25;

	private SwigDelegateOdExPrcHostAppServices_26 swigDelegate26;

	private SwigDelegateOdExPrcHostAppServices_27 swigDelegate27;

	private SwigDelegateOdExPrcHostAppServices_28 swigDelegate28;

	private SwigDelegateOdExPrcHostAppServices_29 swigDelegate29;

	private SwigDelegateOdExPrcHostAppServices_30 swigDelegate30;

	private SwigDelegateOdExPrcHostAppServices_31 swigDelegate31;

	private SwigDelegateOdExPrcHostAppServices_32 swigDelegate32;

	private SwigDelegateOdExPrcHostAppServices_33 swigDelegate33;

	private SwigDelegateOdExPrcHostAppServices_34 swigDelegate34;

	private SwigDelegateOdExPrcHostAppServices_35 swigDelegate35;

	private SwigDelegateOdExPrcHostAppServices_36 swigDelegate36;

	private SwigDelegateOdExPrcHostAppServices_37 swigDelegate37;

	private SwigDelegateOdExPrcHostAppServices_38 swigDelegate38;

	private SwigDelegateOdExPrcHostAppServices_39 swigDelegate39;

	private SwigDelegateOdExPrcHostAppServices_40 swigDelegate40;

	private SwigDelegateOdExPrcHostAppServices_41 swigDelegate41;

	private SwigDelegateOdExPrcHostAppServices_42 swigDelegate42;

	private SwigDelegateOdExPrcHostAppServices_43 swigDelegate43;

	private SwigDelegateOdExPrcHostAppServices_44 swigDelegate44;

	private SwigDelegateOdExPrcHostAppServices_45 swigDelegate45;

	private SwigDelegateOdExPrcHostAppServices_46 swigDelegate46;

	private SwigDelegateOdExPrcHostAppServices_47 swigDelegate47;

	private SwigDelegateOdExPrcHostAppServices_48 swigDelegate48;

	private SwigDelegateOdExPrcHostAppServices_49 swigDelegate49;

	private SwigDelegateOdExPrcHostAppServices_50 swigDelegate50;

	private SwigDelegateOdExPrcHostAppServices_51 swigDelegate51;

	private SwigDelegateOdExPrcHostAppServices_52 swigDelegate52;

	private SwigDelegateOdExPrcHostAppServices_53 swigDelegate53;

	private SwigDelegateOdExPrcHostAppServices_54 swigDelegate54;

	private SwigDelegateOdExPrcHostAppServices_55 swigDelegate55;

	private SwigDelegateOdExPrcHostAppServices_56 swigDelegate56;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(string),
		typeof(OdRxObject),
		typeof(OdDbBaseHostAppServices_FindFileHint)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(string),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdDbHostAppProgressMeter) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdResult) };

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(string),
		typeof(OdResult)
	};

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[3]
	{
		typeof(OdAuditInfo),
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes24 = new Type[2]
	{
		typeof(OdTtfDescriptor),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes25 = new Type[0];

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[2]
	{
		typeof(string),
		typeof(OdTagFontType)
	};

	private static Type[] swigMethodTypes28 = new Type[2]
	{
		typeof(string),
		typeof(OdTagFontType)
	};

	private static Type[] swigMethodTypes29 = new Type[3]
	{
		typeof(OdFont),
		typeof(char),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(OdStringArray) };

	private static Type[] swigMethodTypes31 = new Type[3]
	{
		typeof(OdStringArray),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes32 = new Type[2]
	{
		typeof(OdStringArray),
		typeof(string)
	};

	private static Type[] swigMethodTypes33 = new Type[5]
	{
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes34 = new Type[4]
	{
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes35 = new Type[3]
	{
		typeof(int),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes36 = new Type[2]
	{
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes38 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdRxObject),
		typeof(uint)
	};

	private static Type[] swigMethodTypes39 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[0];

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(MultiThreadedMode) };

	private static Type[] swigMethodTypes45 = new Type[2]
	{
		typeof(OdBrepBuilder),
		typeof(BrepType)
	};

	private static Type[] swigMethodTypes46 = new Type[2]
	{
		typeof(string),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes47 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes48 = new Type[1] { typeof(Oda_UserNameFormat) };

	private static Type[] swigMethodTypes49 = new Type[0];

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdPrcHostAppServices_DatabaseDefaultContent) };

	private static Type[] swigMethodTypes52 = new Type[0];

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes54 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(wrTriangulationParams) };

	private static Type[] swigMethodTypes56 = new Type[1] { typeof(wrTriangulationParams) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdExPrcHostAppServices(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppServices_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdExPrcHostAppServices obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdExPrcHostAppServices(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdExPrcHostAppServices()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdExPrcHostAppServices(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdExPrcHostAppServices) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override OdDbHostAppProgressMeter newProgressMeter()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("newProgressMeter", swigMethodTypes6) ? OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppServices_newProgressMeterSwigExplicitOdExPrcHostAppServices(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppServices_newProgressMeter(swigCPtr));
		OdDbHostAppProgressMeter result = ((intPtr == IntPtr.Zero) ? null : new OdDbHostAppProgressMeter(intPtr, cMemoryOwn: false));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void releaseProgressMeter(OdDbHostAppProgressMeter pProgressMeter)
	{
		if (SwigDerivedClassHasMethod("releaseProgressMeter", swigMethodTypes7))
		{
			OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppServices_releaseProgressMeterSwigExplicitOdExPrcHostAppServices(swigCPtr, OdDbHostAppProgressMeter.getCPtr(pProgressMeter));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppServices_releaseProgressMeter(swigCPtr, OdDbHostAppProgressMeter.getCPtr(pProgressMeter));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void disableProgressMeterOutput(bool disable)
	{
		OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppServices_disableProgressMeterOutput(swigCPtr, disable);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppServices_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdExPrcHostAppServices createObject()
	{
		OdExPrcHostAppServices rXObject = Helpers.GetRXObject<OdExPrcHostAppServices>(OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppServices_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("findFile", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodfindFile__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("findFile", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodfindFile__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("findFile", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodfindFile__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("newProgressMeter", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodnewProgressMeter;
		}
		if (SwigDerivedClassHasMethod("releaseProgressMeter", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodreleaseProgressMeter;
		}
		if (SwigDerivedClassHasMethod("program", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodprogram;
		}
		if (SwigDerivedClassHasMethod("product", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodproduct;
		}
		if (SwigDerivedClassHasMethod("companyName", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcompanyName;
		}
		if (SwigDerivedClassHasMethod("prodcode", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodprodcode;
		}
		if (SwigDerivedClassHasMethod("releaseMajorMinorString", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodreleaseMajorMinorString;
		}
		if (SwigDerivedClassHasMethod("releaseMajorVersion", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodreleaseMajorVersion;
		}
		if (SwigDerivedClassHasMethod("releaseMinorVersion", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodreleaseMinorVersion;
		}
		if (SwigDerivedClassHasMethod("versionString", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodversionString;
		}
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodwarning__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodwarning__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodwarning__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodwarning__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getErrorDescription", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetErrorDescription;
		}
		if (SwigDerivedClassHasMethod("newUndoController", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodnewUndoController;
		}
		if (SwigDerivedClassHasMethod("newUndoStream", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodnewUndoStream;
		}
		if (SwigDerivedClassHasMethod("auditPrintReport", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodauditPrintReport;
		}
		if (SwigDerivedClassHasMethod("ttfFileNameByDescriptor", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodttfFileNameByDescriptor;
		}
		if (SwigDerivedClassHasMethod("getAlternateFontName", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodgetAlternateFontName;
		}
		if (SwigDerivedClassHasMethod("getFontMapFileName", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodgetFontMapFileName;
		}
		if (SwigDerivedClassHasMethod("getPreferableFont", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodgetPreferableFont;
		}
		if (SwigDerivedClassHasMethod("getSubstituteFont", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodgetSubstituteFont;
		}
		if (SwigDerivedClassHasMethod("getSubstituteFontByChar", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodgetSubstituteFontByChar;
		}
		if (SwigDerivedClassHasMethod("getSystemFontFolders", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodgetSystemFontFolders;
		}
		if (SwigDerivedClassHasMethod("collectFilePathsInDirectory", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodcollectFilePathsInDirectory__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("collectFilePathsInDirectory", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodcollectFilePathsInDirectory__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodfileDialog__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodfileDialog__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodfileDialog__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodfileDialog__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodfileDialog__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodgsBitmapDevice__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodgsBitmapDevice__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodgsBitmapDevice__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodgsBitmapDevice__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getTempPath", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodgetTempPath;
		}
		if (SwigDerivedClassHasMethod("getMtMode", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodgetMtMode;
		}
		if (SwigDerivedClassHasMethod("numThreads", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodnumThreads;
		}
		if (SwigDerivedClassHasMethod("BrepBuilder", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodBrepBuilder;
		}
		if (SwigDerivedClassHasMethod("getEnv", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodgetEnv;
		}
		if (SwigDerivedClassHasMethod("setEnv", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodsetEnv;
		}
		if (SwigDerivedClassHasMethod("getAppUserName", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodgetAppUserName__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getAppUserName", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodgetAppUserName__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("databaseClass", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethoddatabaseClass;
		}
		if (SwigDerivedClassHasMethod("createDatabase", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodcreateDatabase__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createDatabase", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodcreateDatabase__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodreadFile__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodreadFile__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setTriangulationParams", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodsetTriangulationParams;
		}
		if (SwigDerivedClassHasMethod("getTriangulationParams", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodgetTriangulationParams;
		}
		OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppServices_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdExPrcHostAppServices));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfindFile__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb, int hint)
	{
		return findFile(filename, Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), (OdDbBaseHostAppServices_FindFileHint)hint);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfindFile__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb)
	{
		return findFile(filename, Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfindFile__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		return findFile(filename);
	}

	private IntPtr SwigDirectorMethodnewProgressMeter()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbHostAppProgressMeter.getCPtr(newProgressMeter()).Handle;
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

	private void SwigDirectorMethodreleaseProgressMeter(IntPtr pProgressMeter)
	{
		try
		{
			releaseProgressMeter((pProgressMeter == IntPtr.Zero) ? null : new OdDbHostAppProgressMeter(pProgressMeter, cMemoryOwn: false));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodprogram()
	{
		return program();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodproduct()
	{
		return product();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodcompanyName()
	{
		return companyName();
	}

	private int SwigDirectorMethodprodcode()
	{
		return (int)prodcode();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodreleaseMajorMinorString()
	{
		return releaseMajorMinorString();
	}

	private int SwigDirectorMethodreleaseMajorVersion()
	{
		return releaseMajorVersion();
	}

	private int SwigDirectorMethodreleaseMinorVersion()
	{
		return releaseMinorVersion();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodversionString()
	{
		return versionString();
	}

	private void SwigDirectorMethodwarning__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string message)
	{
		try
		{
			warning(message);
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

	private void SwigDirectorMethodwarning__SWIG_1(string warnVisGroup, [MarshalAs(UnmanagedType.LPWStr)] string message)
	{
		try
		{
			warning(warnVisGroup, message);
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

	private void SwigDirectorMethodwarning__SWIG_2(int warningOb)
	{
		try
		{
			warning((OdResult)warningOb);
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

	private void SwigDirectorMethodwarning__SWIG_3(string warnVisGroup, int warningOb)
	{
		try
		{
			warning(warnVisGroup, (OdResult)warningOb);
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetErrorDescription(uint errorCode)
	{
		return getErrorDescription(errorCode);
	}

	private IntPtr SwigDirectorMethodnewUndoController()
	{
		return OdDbUndoController.getCPtr(newUndoController()).Handle;
	}

	private IntPtr SwigDirectorMethodnewUndoStream()
	{
		return OdStreamBuf.getCPtr(newUndoStream()).Handle;
	}

	private void SwigDirectorMethodauditPrintReport(IntPtr pAuditInfo, [MarshalAs(UnmanagedType.LPWStr)] string strLine, int printDest)
	{
		try
		{
			auditPrintReport((pAuditInfo == IntPtr.Zero) ? null : new OdAuditInfo(pAuditInfo, cMemoryOwn: false), strLine, printDest);
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

	private bool SwigDirectorMethodttfFileNameByDescriptor(IntPtr description, IntPtr filename)
	{
		OdSwigDirectorHelper.director_UnpackData(filename, out var pOriginalObject, out var pFunction);
		string filename2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = filename2;
		try
		{
			return ttfFileNameByDescriptor(new OdTtfDescriptor(description, cMemoryOwn: false), ref filename2);
		}
		finally
		{
			if (filename2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(filename2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(filename);
		}
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetAlternateFontName()
	{
		return getAlternateFontName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFontMapFileName()
	{
		return getFontMapFileName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetPreferableFont([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType)
	{
		return getPreferableFont(fontName, (OdTagFontType)fontType);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetSubstituteFont([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType)
	{
		return getSubstituteFont(fontName, (OdTagFontType)fontType);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetSubstituteFontByChar(IntPtr pFont, char unicodeChar, IntPtr pDb)
	{
		return getSubstituteFontByChar(Helpers.GetRXObject<OdFont>(pFont, bOwn: false, bTryAddToTransaction: false), unicodeChar, Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodgetSystemFontFolders(IntPtr aDirs)
	{
		return getSystemFontFolders(new OdStringArray(aDirs, cMemoryOwn: true));
	}

	private void SwigDirectorMethodcollectFilePathsInDirectory__SWIG_0(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath, [MarshalAs(UnmanagedType.LPWStr)] string sFilter)
	{
		try
		{
			collectFilePathsInDirectory(new OdStringArray(res, cMemoryOwn: true), sPath, sFilter);
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

	private void SwigDirectorMethodcollectFilePathsInDirectory__SWIG_1(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath)
	{
		try
		{
			collectFilePathsInDirectory(new OdStringArray(res, cMemoryOwn: true), sPath);
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfileDialog__SWIG_0(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename, [MarshalAs(UnmanagedType.LPWStr)] string filter)
	{
		return fileDialog(flags, dialogCaption, defExt, defFilename, filter);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfileDialog__SWIG_1(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename)
	{
		return fileDialog(flags, dialogCaption, defExt, defFilename);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfileDialog__SWIG_2(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt)
	{
		return fileDialog(flags, dialogCaption, defExt);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfileDialog__SWIG_3(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption)
	{
		return fileDialog(flags, dialogCaption);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfileDialog__SWIG_4(int flags)
	{
		return fileDialog(flags);
	}

	private IntPtr SwigDirectorMethodgsBitmapDevice__SWIG_0(IntPtr pViewObj, IntPtr pDb, uint flags)
	{
		return OdGsDevice.getCPtr(gsBitmapDevice(Helpers.GetRXObject<OdRxObject>(pViewObj, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), flags)).Handle;
	}

	private IntPtr SwigDirectorMethodgsBitmapDevice__SWIG_1(IntPtr pViewObj, IntPtr pDb)
	{
		return OdGsDevice.getCPtr(gsBitmapDevice(Helpers.GetRXObject<OdRxObject>(pViewObj, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgsBitmapDevice__SWIG_2(IntPtr pViewObj)
	{
		return OdGsDevice.getCPtr(gsBitmapDevice(Helpers.GetRXObject<OdRxObject>(pViewObj, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgsBitmapDevice__SWIG_3()
	{
		return OdGsDevice.getCPtr(gsBitmapDevice()).Handle;
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetTempPath()
	{
		return getTempPath();
	}

	private short SwigDirectorMethodgetMtMode()
	{
		return getMtMode();
	}

	private int SwigDirectorMethodnumThreads(int mtMode)
	{
		return numThreads((MultiThreadedMode)mtMode);
	}

	private int SwigDirectorMethodBrepBuilder(IntPtr bbuilder, int bbType)
	{
		return (int)BrepBuilder(new OdBrepBuilder(bbuilder, cMemoryOwn: false), (BrepType)bbType);
	}

	private int SwigDirectorMethodgetEnv([MarshalAs(UnmanagedType.LPWStr)] string varName, IntPtr value)
	{
		OdSwigDirectorHelper.director_UnpackData(value, out var pOriginalObject, out var pFunction);
		string value2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = value2;
		try
		{
			return (int)getEnv(varName, ref value2);
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

	private int SwigDirectorMethodsetEnv([MarshalAs(UnmanagedType.LPWStr)] string varName, [MarshalAs(UnmanagedType.LPWStr)] string newValue)
	{
		return (int)setEnv(varName, newValue);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetAppUserName__SWIG_0(int unFormat)
	{
		return getAppUserName((Oda_UserNameFormat)unFormat);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetAppUserName__SWIG_1()
	{
		return getAppUserName();
	}

	private IntPtr SwigDirectorMethoddatabaseClass()
	{
		return OdRxClass.getCPtr(databaseClass()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateDatabase__SWIG_0(int defaultContent)
	{
		return OdPrcFile.getCPtr(createDatabase((OdPrcHostAppServices_DatabaseDefaultContent)defaultContent)).Handle;
	}

	private IntPtr SwigDirectorMethodcreateDatabase__SWIG_1()
	{
		return OdPrcFile.getCPtr(createDatabase()).Handle;
	}

	private IntPtr SwigDirectorMethodreadFile__SWIG_0(IntPtr pFileBuff)
	{
		return OdPrcFile.getCPtr(readFile(Helpers.GetRXObject<OdStreamBuf>(pFileBuff, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodreadFile__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string file)
	{
		return OdPrcFile.getCPtr(readFile(file)).Handle;
	}

	private int SwigDirectorMethodsetTriangulationParams(IntPtr params_)
	{
		return (int)setTriangulationParams(new wrTriangulationParams(params_, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetTriangulationParams(IntPtr params_)
	{
		return (int)getTriangulationParams(new wrTriangulationParams(params_, cMemoryOwn: false));
	}
}

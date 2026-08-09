using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcHostAppServices : OdDbBaseHostAppServices
{
	public delegate IntPtr SwigDelegateOdPrcHostAppServices_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_1();

	public delegate void SwigDelegateOdPrcHostAppServices_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_3([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb, int hint);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_4([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_5([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_6();

	public delegate void SwigDelegateOdPrcHostAppServices_7(IntPtr pProgressMeter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_8();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_9();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_10();

	public delegate int SwigDelegateOdPrcHostAppServices_11();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_12();

	public delegate int SwigDelegateOdPrcHostAppServices_13();

	public delegate int SwigDelegateOdPrcHostAppServices_14();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_15();

	public delegate void SwigDelegateOdPrcHostAppServices_16([MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateOdPrcHostAppServices_17(string warnVisGroup, [MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateOdPrcHostAppServices_18(int warningOb);

	public delegate void SwigDelegateOdPrcHostAppServices_19(string warnVisGroup, int warningOb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_20(uint errorCode);

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_21();

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_22();

	public delegate void SwigDelegateOdPrcHostAppServices_23(IntPtr pAuditInfo, [MarshalAs(UnmanagedType.LPWStr)] string strLine, int printDest);

	public delegate bool SwigDelegateOdPrcHostAppServices_24(IntPtr description, IntPtr filename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_25();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_26();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_27([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_28([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_29(IntPtr pFont, char unicodeChar, IntPtr pDb);

	public delegate bool SwigDelegateOdPrcHostAppServices_30(IntPtr aDirs);

	public delegate void SwigDelegateOdPrcHostAppServices_31(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath, [MarshalAs(UnmanagedType.LPWStr)] string sFilter);

	public delegate void SwigDelegateOdPrcHostAppServices_32(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_33(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename, [MarshalAs(UnmanagedType.LPWStr)] string filter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_34(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_35(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_36(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_37(int flags);

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_38(IntPtr pViewObj, IntPtr pDb, uint flags);

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_39(IntPtr pViewObj, IntPtr pDb);

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_40(IntPtr pViewObj);

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_41();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_42();

	public delegate short SwigDelegateOdPrcHostAppServices_43();

	public delegate int SwigDelegateOdPrcHostAppServices_44(int mtMode);

	public delegate int SwigDelegateOdPrcHostAppServices_45(IntPtr bbuilder, int bbType);

	public delegate int SwigDelegateOdPrcHostAppServices_46([MarshalAs(UnmanagedType.LPWStr)] string varName, IntPtr value);

	public delegate int SwigDelegateOdPrcHostAppServices_47([MarshalAs(UnmanagedType.LPWStr)] string varName, [MarshalAs(UnmanagedType.LPWStr)] string newValue);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_48(int unFormat);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcHostAppServices_49();

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_50();

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_51(int defaultContent);

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_52();

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_53(IntPtr pFileBuff);

	public delegate IntPtr SwigDelegateOdPrcHostAppServices_54([MarshalAs(UnmanagedType.LPWStr)] string file);

	public delegate int SwigDelegateOdPrcHostAppServices_55(IntPtr params_);

	public delegate int SwigDelegateOdPrcHostAppServices_56(IntPtr params_);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcHostAppServices_0 swigDelegate0;

	private SwigDelegateOdPrcHostAppServices_1 swigDelegate1;

	private SwigDelegateOdPrcHostAppServices_2 swigDelegate2;

	private SwigDelegateOdPrcHostAppServices_3 swigDelegate3;

	private SwigDelegateOdPrcHostAppServices_4 swigDelegate4;

	private SwigDelegateOdPrcHostAppServices_5 swigDelegate5;

	private SwigDelegateOdPrcHostAppServices_6 swigDelegate6;

	private SwigDelegateOdPrcHostAppServices_7 swigDelegate7;

	private SwigDelegateOdPrcHostAppServices_8 swigDelegate8;

	private SwigDelegateOdPrcHostAppServices_9 swigDelegate9;

	private SwigDelegateOdPrcHostAppServices_10 swigDelegate10;

	private SwigDelegateOdPrcHostAppServices_11 swigDelegate11;

	private SwigDelegateOdPrcHostAppServices_12 swigDelegate12;

	private SwigDelegateOdPrcHostAppServices_13 swigDelegate13;

	private SwigDelegateOdPrcHostAppServices_14 swigDelegate14;

	private SwigDelegateOdPrcHostAppServices_15 swigDelegate15;

	private SwigDelegateOdPrcHostAppServices_16 swigDelegate16;

	private SwigDelegateOdPrcHostAppServices_17 swigDelegate17;

	private SwigDelegateOdPrcHostAppServices_18 swigDelegate18;

	private SwigDelegateOdPrcHostAppServices_19 swigDelegate19;

	private SwigDelegateOdPrcHostAppServices_20 swigDelegate20;

	private SwigDelegateOdPrcHostAppServices_21 swigDelegate21;

	private SwigDelegateOdPrcHostAppServices_22 swigDelegate22;

	private SwigDelegateOdPrcHostAppServices_23 swigDelegate23;

	private SwigDelegateOdPrcHostAppServices_24 swigDelegate24;

	private SwigDelegateOdPrcHostAppServices_25 swigDelegate25;

	private SwigDelegateOdPrcHostAppServices_26 swigDelegate26;

	private SwigDelegateOdPrcHostAppServices_27 swigDelegate27;

	private SwigDelegateOdPrcHostAppServices_28 swigDelegate28;

	private SwigDelegateOdPrcHostAppServices_29 swigDelegate29;

	private SwigDelegateOdPrcHostAppServices_30 swigDelegate30;

	private SwigDelegateOdPrcHostAppServices_31 swigDelegate31;

	private SwigDelegateOdPrcHostAppServices_32 swigDelegate32;

	private SwigDelegateOdPrcHostAppServices_33 swigDelegate33;

	private SwigDelegateOdPrcHostAppServices_34 swigDelegate34;

	private SwigDelegateOdPrcHostAppServices_35 swigDelegate35;

	private SwigDelegateOdPrcHostAppServices_36 swigDelegate36;

	private SwigDelegateOdPrcHostAppServices_37 swigDelegate37;

	private SwigDelegateOdPrcHostAppServices_38 swigDelegate38;

	private SwigDelegateOdPrcHostAppServices_39 swigDelegate39;

	private SwigDelegateOdPrcHostAppServices_40 swigDelegate40;

	private SwigDelegateOdPrcHostAppServices_41 swigDelegate41;

	private SwigDelegateOdPrcHostAppServices_42 swigDelegate42;

	private SwigDelegateOdPrcHostAppServices_43 swigDelegate43;

	private SwigDelegateOdPrcHostAppServices_44 swigDelegate44;

	private SwigDelegateOdPrcHostAppServices_45 swigDelegate45;

	private SwigDelegateOdPrcHostAppServices_46 swigDelegate46;

	private SwigDelegateOdPrcHostAppServices_47 swigDelegate47;

	private SwigDelegateOdPrcHostAppServices_48 swigDelegate48;

	private SwigDelegateOdPrcHostAppServices_49 swigDelegate49;

	private SwigDelegateOdPrcHostAppServices_50 swigDelegate50;

	private SwigDelegateOdPrcHostAppServices_51 swigDelegate51;

	private SwigDelegateOdPrcHostAppServices_52 swigDelegate52;

	private SwigDelegateOdPrcHostAppServices_53 swigDelegate53;

	private SwigDelegateOdPrcHostAppServices_54 swigDelegate54;

	private SwigDelegateOdPrcHostAppServices_55 swigDelegate55;

	private SwigDelegateOdPrcHostAppServices_56 swigDelegate56;

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
	public OdPrcHostAppServices(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcHostAppServices obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcHostAppServices(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPrcHostAppServices cast(OdRxObject pObj)
	{
		OdPrcHostAppServices rXObject = Helpers.GetRXObject<OdPrcHostAppServices>(OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_isASwigExplicitOdPrcHostAppServices(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_queryXSwigExplicitOdPrcHostAppServices(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcHostAppServices()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcHostAppServices(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcHostAppServices) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual OdRxClass databaseClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("databaseClass", swigMethodTypes50) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_databaseClassSwigExplicitOdPrcHostAppServices(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_databaseClass(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdPrcFile createDatabase(OdPrcHostAppServices_DatabaseDefaultContent defaultContent)
	{
		OdPrcFile rXObject = Helpers.GetRXObject<OdPrcFile>(SwigDerivedClassHasMethod("createDatabase", swigMethodTypes51) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_createDatabaseSwigExplicitOdPrcHostAppServices__SWIG_0(swigCPtr, (int)defaultContent) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_createDatabase__SWIG_0(swigCPtr, (int)defaultContent), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdPrcFile createDatabase()
	{
		OdPrcFile rXObject = Helpers.GetRXObject<OdPrcFile>(SwigDerivedClassHasMethod("createDatabase", swigMethodTypes52) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_createDatabaseSwigExplicitOdPrcHostAppServices__SWIG_1(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_createDatabase__SWIG_1(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override string findFile(string filename, OdRxObject pDb, OdDbBaseHostAppServices_FindFileHint hint)
	{
		string result = (SwigDerivedClassHasMethod("findFile", swigMethodTypes3) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_findFileSwigExplicitOdPrcHostAppServices__SWIG_0(swigCPtr, filename, OdRxObject.getCPtr(pDb), (int)hint) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_findFile__SWIG_0(swigCPtr, filename, OdRxObject.getCPtr(pDb), (int)hint));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string findFile(string filename, OdRxObject pDb)
	{
		string result = (SwigDerivedClassHasMethod("findFile", swigMethodTypes4) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_findFileSwigExplicitOdPrcHostAppServices__SWIG_1(swigCPtr, filename, OdRxObject.getCPtr(pDb)) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_findFile__SWIG_1(swigCPtr, filename, OdRxObject.getCPtr(pDb)));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string findFile(string filename)
	{
		string result = (SwigDerivedClassHasMethod("findFile", swigMethodTypes5) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_findFileSwigExplicitOdPrcHostAppServices__SWIG_2(swigCPtr, filename) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_findFile__SWIG_2(swigCPtr, filename));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string program()
	{
		string result = (SwigDerivedClassHasMethod("program", swigMethodTypes8) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_programSwigExplicitOdPrcHostAppServices(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_program(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string product()
	{
		string result = (SwigDerivedClassHasMethod("product", swigMethodTypes9) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_productSwigExplicitOdPrcHostAppServices(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_product(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string companyName()
	{
		string result = (SwigDerivedClassHasMethod("companyName", swigMethodTypes10) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_companyNameSwigExplicitOdPrcHostAppServices(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_companyName(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string releaseMajorMinorString()
	{
		string result = (SwigDerivedClassHasMethod("releaseMajorMinorString", swigMethodTypes12) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_releaseMajorMinorStringSwigExplicitOdPrcHostAppServices(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_releaseMajorMinorString(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string versionString()
	{
		string result = (SwigDerivedClassHasMethod("versionString", swigMethodTypes15) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_versionStringSwigExplicitOdPrcHostAppServices(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_versionString(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string getAlternateFontName()
	{
		string result = (SwigDerivedClassHasMethod("getAlternateFontName", swigMethodTypes25) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getAlternateFontNameSwigExplicitOdPrcHostAppServices(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getAlternateFontName(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string getFontMapFileName()
	{
		string result = (SwigDerivedClassHasMethod("getFontMapFileName", swigMethodTypes26) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getFontMapFileNameSwigExplicitOdPrcHostAppServices(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getFontMapFileName(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string getPreferableFont(string fontName, OdTagFontType fontType)
	{
		string result = (SwigDerivedClassHasMethod("getPreferableFont", swigMethodTypes27) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getPreferableFontSwigExplicitOdPrcHostAppServices(swigCPtr, fontName, (int)fontType) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getPreferableFont(swigCPtr, fontName, (int)fontType));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string getSubstituteFont(string fontName, OdTagFontType fontType)
	{
		string result = (SwigDerivedClassHasMethod("getSubstituteFont", swigMethodTypes28) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getSubstituteFontSwigExplicitOdPrcHostAppServices(swigCPtr, fontName, (int)fontType) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getSubstituteFont(swigCPtr, fontName, (int)fontType));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string getSubstituteFontByChar(OdFont pFont, char unicodeChar, OdRxObject pDb)
	{
		string result = (SwigDerivedClassHasMethod("getSubstituteFontByChar", swigMethodTypes29) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getSubstituteFontByCharSwigExplicitOdPrcHostAppServices(swigCPtr, OdFont.getCPtr(pFont), unicodeChar, OdRxObject.getCPtr(pDb)) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getSubstituteFontByChar(swigCPtr, OdFont.getCPtr(pFont), unicodeChar, OdRxObject.getCPtr(pDb)));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGsDevice gsBitmapDevice(OdRxObject pViewObj, OdRxObject pDb, uint flags)
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes38) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_gsBitmapDeviceSwigExplicitOdPrcHostAppServices__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewObj), OdRxObject.getCPtr(pDb), flags) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_gsBitmapDevice__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewObj), OdRxObject.getCPtr(pDb), flags), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGsDevice gsBitmapDevice(OdRxObject pViewObj, OdRxObject pDb)
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes39) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_gsBitmapDeviceSwigExplicitOdPrcHostAppServices__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewObj), OdRxObject.getCPtr(pDb)) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_gsBitmapDevice__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewObj), OdRxObject.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGsDevice gsBitmapDevice(OdRxObject pViewObj)
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes40) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_gsBitmapDeviceSwigExplicitOdPrcHostAppServices__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewObj)) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_gsBitmapDevice__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGsDevice gsBitmapDevice()
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes41) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_gsBitmapDeviceSwigExplicitOdPrcHostAppServices__SWIG_3(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_gsBitmapDevice__SWIG_3(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdPrcFile readFile(OdStreamBuf pFileBuff)
	{
		OdPrcFile rXObject = Helpers.GetRXObject<OdPrcFile>(SwigDerivedClassHasMethod("readFile", swigMethodTypes53) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_readFileSwigExplicitOdPrcHostAppServices__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pFileBuff)) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_readFile__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pFileBuff)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdPrcFile readFile(string file)
	{
		OdPrcFile rXObject = Helpers.GetRXObject<OdPrcFile>(SwigDerivedClassHasMethod("readFile", swigMethodTypes54) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_readFileSwigExplicitOdPrcHostAppServices__SWIG_1(swigCPtr, file) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_readFile__SWIG_1(swigCPtr, file), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult setTriangulationParams(wrTriangulationParams params_)
	{
		int result = (SwigDerivedClassHasMethod("setTriangulationParams", swigMethodTypes55) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_setTriangulationParamsSwigExplicitOdPrcHostAppServices(swigCPtr, wrTriangulationParams.getCPtr(params_)) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_setTriangulationParams(swigCPtr, wrTriangulationParams.getCPtr(params_)));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getTriangulationParams(wrTriangulationParams params_)
	{
		int result = (SwigDerivedClassHasMethod("getTriangulationParams", swigMethodTypes56) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getTriangulationParamsSwigExplicitOdPrcHostAppServices(swigCPtr, wrTriangulationParams.getCPtr(params_)) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getTriangulationParams(swigCPtr, wrTriangulationParams.getCPtr(params_)));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult BrepBuilder(OdBrepBuilder bbuilder, BrepType bbType)
	{
		int result = (SwigDerivedClassHasMethod("BrepBuilder", swigMethodTypes45) ? OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_BrepBuilderSwigExplicitOdPrcHostAppServices(swigCPtr, OdBrepBuilder.getCPtr(bbuilder), (int)bbType) : OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_BrepBuilder(swigCPtr, OdBrepBuilder.getCPtr(bbuilder), (int)bbType));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdPrcHostAppServices createObject()
	{
		OdPrcHostAppServices rXObject = Helpers.GetRXObject<OdPrcHostAppServices>(OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		OdPrcModule_GlobalsPINVOKE.OdPrcHostAppServices_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcHostAppServices));
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

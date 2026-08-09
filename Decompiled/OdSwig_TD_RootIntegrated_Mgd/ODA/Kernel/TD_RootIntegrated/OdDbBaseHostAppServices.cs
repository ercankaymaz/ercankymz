using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbBaseHostAppServices : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbBaseHostAppServices_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBaseHostAppServices_1();

	public delegate void SwigDelegateOdDbBaseHostAppServices_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_3([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb, int hint);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_4([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pDb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_5([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate IntPtr SwigDelegateOdDbBaseHostAppServices_6();

	public delegate void SwigDelegateOdDbBaseHostAppServices_7(IntPtr pProgressMeter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_8();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_9();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_10();

	public delegate int SwigDelegateOdDbBaseHostAppServices_11();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_12();

	public delegate int SwigDelegateOdDbBaseHostAppServices_13();

	public delegate int SwigDelegateOdDbBaseHostAppServices_14();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_15();

	public delegate void SwigDelegateOdDbBaseHostAppServices_16([MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateOdDbBaseHostAppServices_17(string warnVisGroup, [MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateOdDbBaseHostAppServices_18(int warningOb);

	public delegate void SwigDelegateOdDbBaseHostAppServices_19(string warnVisGroup, int warningOb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_20(uint errorCode);

	public delegate IntPtr SwigDelegateOdDbBaseHostAppServices_21();

	public delegate IntPtr SwigDelegateOdDbBaseHostAppServices_22();

	public delegate void SwigDelegateOdDbBaseHostAppServices_23(IntPtr pAuditInfo, [MarshalAs(UnmanagedType.LPWStr)] string strLine, int printDest);

	public delegate bool SwigDelegateOdDbBaseHostAppServices_24(IntPtr description, IntPtr filename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_25();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_26();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_27([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_28([MarshalAs(UnmanagedType.LPWStr)] string fontName, int fontType);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_29(IntPtr arg0, char arg1, IntPtr arg2);

	public delegate bool SwigDelegateOdDbBaseHostAppServices_30(IntPtr aDirs);

	public delegate void SwigDelegateOdDbBaseHostAppServices_31(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath, [MarshalAs(UnmanagedType.LPWStr)] string sFilter);

	public delegate void SwigDelegateOdDbBaseHostAppServices_32(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_33(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename, [MarshalAs(UnmanagedType.LPWStr)] string filter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_34(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string defFilename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_35(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_36(int flags, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_37(int flags);

	public delegate IntPtr SwigDelegateOdDbBaseHostAppServices_38(IntPtr pViewObj, IntPtr pDb, uint flags);

	public delegate IntPtr SwigDelegateOdDbBaseHostAppServices_39(IntPtr pViewObj, IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbBaseHostAppServices_40(IntPtr pViewObj);

	public delegate IntPtr SwigDelegateOdDbBaseHostAppServices_41();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_42();

	public delegate short SwigDelegateOdDbBaseHostAppServices_43();

	public delegate int SwigDelegateOdDbBaseHostAppServices_44(int mtMode);

	public delegate int SwigDelegateOdDbBaseHostAppServices_45(IntPtr bbuilder, int bbType);

	public delegate int SwigDelegateOdDbBaseHostAppServices_46([MarshalAs(UnmanagedType.LPWStr)] string varName, IntPtr value);

	public delegate int SwigDelegateOdDbBaseHostAppServices_47([MarshalAs(UnmanagedType.LPWStr)] string varName, [MarshalAs(UnmanagedType.LPWStr)] string newValue);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_48(int unFormat);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseHostAppServices_49();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBaseHostAppServices_0 swigDelegate0;

	private SwigDelegateOdDbBaseHostAppServices_1 swigDelegate1;

	private SwigDelegateOdDbBaseHostAppServices_2 swigDelegate2;

	private SwigDelegateOdDbBaseHostAppServices_3 swigDelegate3;

	private SwigDelegateOdDbBaseHostAppServices_4 swigDelegate4;

	private SwigDelegateOdDbBaseHostAppServices_5 swigDelegate5;

	private SwigDelegateOdDbBaseHostAppServices_6 swigDelegate6;

	private SwigDelegateOdDbBaseHostAppServices_7 swigDelegate7;

	private SwigDelegateOdDbBaseHostAppServices_8 swigDelegate8;

	private SwigDelegateOdDbBaseHostAppServices_9 swigDelegate9;

	private SwigDelegateOdDbBaseHostAppServices_10 swigDelegate10;

	private SwigDelegateOdDbBaseHostAppServices_11 swigDelegate11;

	private SwigDelegateOdDbBaseHostAppServices_12 swigDelegate12;

	private SwigDelegateOdDbBaseHostAppServices_13 swigDelegate13;

	private SwigDelegateOdDbBaseHostAppServices_14 swigDelegate14;

	private SwigDelegateOdDbBaseHostAppServices_15 swigDelegate15;

	private SwigDelegateOdDbBaseHostAppServices_16 swigDelegate16;

	private SwigDelegateOdDbBaseHostAppServices_17 swigDelegate17;

	private SwigDelegateOdDbBaseHostAppServices_18 swigDelegate18;

	private SwigDelegateOdDbBaseHostAppServices_19 swigDelegate19;

	private SwigDelegateOdDbBaseHostAppServices_20 swigDelegate20;

	private SwigDelegateOdDbBaseHostAppServices_21 swigDelegate21;

	private SwigDelegateOdDbBaseHostAppServices_22 swigDelegate22;

	private SwigDelegateOdDbBaseHostAppServices_23 swigDelegate23;

	private SwigDelegateOdDbBaseHostAppServices_24 swigDelegate24;

	private SwigDelegateOdDbBaseHostAppServices_25 swigDelegate25;

	private SwigDelegateOdDbBaseHostAppServices_26 swigDelegate26;

	private SwigDelegateOdDbBaseHostAppServices_27 swigDelegate27;

	private SwigDelegateOdDbBaseHostAppServices_28 swigDelegate28;

	private SwigDelegateOdDbBaseHostAppServices_29 swigDelegate29;

	private SwigDelegateOdDbBaseHostAppServices_30 swigDelegate30;

	private SwigDelegateOdDbBaseHostAppServices_31 swigDelegate31;

	private SwigDelegateOdDbBaseHostAppServices_32 swigDelegate32;

	private SwigDelegateOdDbBaseHostAppServices_33 swigDelegate33;

	private SwigDelegateOdDbBaseHostAppServices_34 swigDelegate34;

	private SwigDelegateOdDbBaseHostAppServices_35 swigDelegate35;

	private SwigDelegateOdDbBaseHostAppServices_36 swigDelegate36;

	private SwigDelegateOdDbBaseHostAppServices_37 swigDelegate37;

	private SwigDelegateOdDbBaseHostAppServices_38 swigDelegate38;

	private SwigDelegateOdDbBaseHostAppServices_39 swigDelegate39;

	private SwigDelegateOdDbBaseHostAppServices_40 swigDelegate40;

	private SwigDelegateOdDbBaseHostAppServices_41 swigDelegate41;

	private SwigDelegateOdDbBaseHostAppServices_42 swigDelegate42;

	private SwigDelegateOdDbBaseHostAppServices_43 swigDelegate43;

	private SwigDelegateOdDbBaseHostAppServices_44 swigDelegate44;

	private SwigDelegateOdDbBaseHostAppServices_45 swigDelegate45;

	private SwigDelegateOdDbBaseHostAppServices_46 swigDelegate46;

	private SwigDelegateOdDbBaseHostAppServices_47 swigDelegate47;

	private SwigDelegateOdDbBaseHostAppServices_48 swigDelegate48;

	private SwigDelegateOdDbBaseHostAppServices_49 swigDelegate49;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBaseHostAppServices(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBaseHostAppServices obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbBaseHostAppServices(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbBaseHostAppServices()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseHostAppServices(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbBaseHostAppServices cast(OdRxObject pObj)
	{
		OdDbBaseHostAppServices rXObject = Helpers.GetRXObject<OdDbBaseHostAppServices>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_isASwigExplicitOdDbBaseHostAppServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_queryXSwigExplicitOdDbBaseHostAppServices(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseHostAppServices createObject()
	{
		OdDbBaseHostAppServices rXObject = Helpers.GetRXObject<OdDbBaseHostAppServices>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string findFile(string filename, OdRxObject pDb, OdDbBaseHostAppServices_FindFileHint hint)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_findFile__SWIG_0(swigCPtr, filename, OdRxObject.getCPtr(pDb), (int)hint);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string findFile(string filename, OdRxObject pDb)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_findFile__SWIG_1(swigCPtr, filename, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string findFile(string filename)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_findFile__SWIG_2(swigCPtr, filename);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbHostAppProgressMeter newProgressMeter()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("newProgressMeter", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_newProgressMeterSwigExplicitOdDbBaseHostAppServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_newProgressMeter(swigCPtr));
		OdDbHostAppProgressMeter result = ((intPtr == IntPtr.Zero) ? null : new OdDbHostAppProgressMeter(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void releaseProgressMeter(OdDbHostAppProgressMeter pProgressMeter)
	{
		if (SwigDerivedClassHasMethod("releaseProgressMeter", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_releaseProgressMeterSwigExplicitOdDbBaseHostAppServices(swigCPtr, OdDbHostAppProgressMeter.getCPtr(pProgressMeter));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_releaseProgressMeter(swigCPtr, OdDbHostAppProgressMeter.getCPtr(pProgressMeter));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string program()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_program(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string product()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_product(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string companyName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_companyName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ProdIdCode prodcode()
	{
		int result = (SwigDerivedClassHasMethod("prodcode", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_prodcodeSwigExplicitOdDbBaseHostAppServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_prodcode(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (ProdIdCode)result;
	}

	public virtual string releaseMajorMinorString()
	{
		string result = (SwigDerivedClassHasMethod("releaseMajorMinorString", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_releaseMajorMinorStringSwigExplicitOdDbBaseHostAppServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_releaseMajorMinorString(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int releaseMajorVersion()
	{
		int result = (SwigDerivedClassHasMethod("releaseMajorVersion", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_releaseMajorVersionSwigExplicitOdDbBaseHostAppServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_releaseMajorVersion(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int releaseMinorVersion()
	{
		int result = (SwigDerivedClassHasMethod("releaseMinorVersion", swigMethodTypes14) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_releaseMinorVersionSwigExplicitOdDbBaseHostAppServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_releaseMinorVersion(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string versionString()
	{
		string result = (SwigDerivedClassHasMethod("versionString", swigMethodTypes15) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_versionStringSwigExplicitOdDbBaseHostAppServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_versionString(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void warning(string message)
	{
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes16))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_warningSwigExplicitOdDbBaseHostAppServices__SWIG_0(swigCPtr, message);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_warning__SWIG_0(swigCPtr, message);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void warning(string warnVisGroup, string message)
	{
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes17))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_warningSwigExplicitOdDbBaseHostAppServices__SWIG_1(swigCPtr, warnVisGroup, message);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_warning__SWIG_1(swigCPtr, warnVisGroup, message);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void warning(OdResult warningOb)
	{
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes18))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_warningSwigExplicitOdDbBaseHostAppServices__SWIG_2(swigCPtr, (int)warningOb);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_warning__SWIG_2(swigCPtr, (int)warningOb);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void warning(string warnVisGroup, OdResult warningOb)
	{
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes19))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_warningSwigExplicitOdDbBaseHostAppServices__SWIG_3(swigCPtr, warnVisGroup, (int)warningOb);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_warning__SWIG_3(swigCPtr, warnVisGroup, (int)warningOb);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getErrorDescription(uint errorCode)
	{
		string result = (SwigDerivedClassHasMethod("getErrorDescription", swigMethodTypes20) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getErrorDescriptionSwigExplicitOdDbBaseHostAppServices(swigCPtr, errorCode) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getErrorDescription(swigCPtr, errorCode));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbUndoController newUndoController()
	{
		OdDbUndoController rXObject = Helpers.GetRXObject<OdDbUndoController>(SwigDerivedClassHasMethod("newUndoController", swigMethodTypes21) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_newUndoControllerSwigExplicitOdDbBaseHostAppServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_newUndoController(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdStreamBuf newUndoStream()
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(SwigDerivedClassHasMethod("newUndoStream", swigMethodTypes22) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_newUndoStreamSwigExplicitOdDbBaseHostAppServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_newUndoStream(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void auditPrintReport(OdAuditInfo pAuditInfo, string strLine, int printDest)
	{
		if (SwigDerivedClassHasMethod("auditPrintReport", swigMethodTypes23))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_auditPrintReportSwigExplicitOdDbBaseHostAppServices(swigCPtr, OdAuditInfo.getCPtr(pAuditInfo), strLine, printDest);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_auditPrintReport(swigCPtr, OdAuditInfo.getCPtr(pAuditInfo), strLine, printDest);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool ttfFileNameByDescriptor(OdTtfDescriptor description, ref string filename)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(filename);
		IntPtr intPtr = jarg;
		try
		{
			bool result = (SwigDerivedClassHasMethod("ttfFileNameByDescriptor", swigMethodTypes24) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_ttfFileNameByDescriptorSwigExplicitOdDbBaseHostAppServices(swigCPtr, OdTtfDescriptor.getCPtr(description), ref jarg) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_ttfFileNameByDescriptor(swigCPtr, OdTtfDescriptor.getCPtr(description), ref jarg));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				filename = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual string getAlternateFontName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getAlternateFontName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFontMapFileName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getFontMapFileName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getPreferableFont(string fontName, OdTagFontType fontType)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getPreferableFont(swigCPtr, fontName, (int)fontType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getSubstituteFont(string fontName, OdTagFontType fontType)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getSubstituteFont(swigCPtr, fontName, (int)fontType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getSubstituteFontByChar(OdFont arg0, char arg1, OdRxObject arg2)
	{
		string result = (SwigDerivedClassHasMethod("getSubstituteFontByChar", swigMethodTypes29) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getSubstituteFontByCharSwigExplicitOdDbBaseHostAppServices(swigCPtr, OdFont.getCPtr(arg0), arg1, OdRxObject.getCPtr(arg2)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getSubstituteFontByChar(swigCPtr, OdFont.getCPtr(arg0), arg1, OdRxObject.getCPtr(arg2)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getSystemFontFolders(OdStringArray aDirs)
	{
		bool result = (SwigDerivedClassHasMethod("getSystemFontFolders", swigMethodTypes30) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getSystemFontFoldersSwigExplicitOdDbBaseHostAppServices(swigCPtr, OdStringArray.getCPtr(aDirs)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getSystemFontFolders(swigCPtr, OdStringArray.getCPtr(aDirs)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void collectFilePathsInDirectory(OdStringArray res, string sPath, string sFilter)
	{
		if (SwigDerivedClassHasMethod("collectFilePathsInDirectory", swigMethodTypes31))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_collectFilePathsInDirectorySwigExplicitOdDbBaseHostAppServices__SWIG_0(swigCPtr, OdStringArray.getCPtr(res), sPath, sFilter);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_collectFilePathsInDirectory__SWIG_0(swigCPtr, OdStringArray.getCPtr(res), sPath, sFilter);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void collectFilePathsInDirectory(OdStringArray res, string sPath)
	{
		if (SwigDerivedClassHasMethod("collectFilePathsInDirectory", swigMethodTypes32))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_collectFilePathsInDirectorySwigExplicitOdDbBaseHostAppServices__SWIG_1(swigCPtr, OdStringArray.getCPtr(res), sPath);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_collectFilePathsInDirectory__SWIG_1(swigCPtr, OdStringArray.getCPtr(res), sPath);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string fileDialog(int flags, string dialogCaption, string defExt, string defFilename, string filter)
	{
		string result = (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes33) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_fileDialogSwigExplicitOdDbBaseHostAppServices__SWIG_0(swigCPtr, flags, dialogCaption, defExt, defFilename, filter) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_fileDialog__SWIG_0(swigCPtr, flags, dialogCaption, defExt, defFilename, filter));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string fileDialog(int flags, string dialogCaption, string defExt, string defFilename)
	{
		string result = (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes34) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_fileDialogSwigExplicitOdDbBaseHostAppServices__SWIG_1(swigCPtr, flags, dialogCaption, defExt, defFilename) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_fileDialog__SWIG_1(swigCPtr, flags, dialogCaption, defExt, defFilename));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string fileDialog(int flags, string dialogCaption, string defExt)
	{
		string result = (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes35) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_fileDialogSwigExplicitOdDbBaseHostAppServices__SWIG_2(swigCPtr, flags, dialogCaption, defExt) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_fileDialog__SWIG_2(swigCPtr, flags, dialogCaption, defExt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string fileDialog(int flags, string dialogCaption)
	{
		string result = (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes36) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_fileDialogSwigExplicitOdDbBaseHostAppServices__SWIG_3(swigCPtr, flags, dialogCaption) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_fileDialog__SWIG_3(swigCPtr, flags, dialogCaption));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string fileDialog(int flags)
	{
		string result = (SwigDerivedClassHasMethod("fileDialog", swigMethodTypes37) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_fileDialogSwigExplicitOdDbBaseHostAppServices__SWIG_4(swigCPtr, flags) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_fileDialog__SWIG_4(swigCPtr, flags));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsDevice gsBitmapDevice(OdRxObject pViewObj, OdRxObject pDb, uint flags)
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes38) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_gsBitmapDeviceSwigExplicitOdDbBaseHostAppServices__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewObj), OdRxObject.getCPtr(pDb), flags) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_gsBitmapDevice__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewObj), OdRxObject.getCPtr(pDb), flags), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsDevice gsBitmapDevice(OdRxObject pViewObj, OdRxObject pDb)
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes39) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_gsBitmapDeviceSwigExplicitOdDbBaseHostAppServices__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewObj), OdRxObject.getCPtr(pDb)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_gsBitmapDevice__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewObj), OdRxObject.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsDevice gsBitmapDevice(OdRxObject pViewObj)
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes40) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_gsBitmapDeviceSwigExplicitOdDbBaseHostAppServices__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewObj)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_gsBitmapDevice__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsDevice gsBitmapDevice()
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("gsBitmapDevice", swigMethodTypes41) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_gsBitmapDeviceSwigExplicitOdDbBaseHostAppServices__SWIG_3(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_gsBitmapDevice__SWIG_3(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string getTempPath()
	{
		string result = (SwigDerivedClassHasMethod("getTempPath", swigMethodTypes42) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getTempPathSwigExplicitOdDbBaseHostAppServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getTempPath(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getMtMode()
	{
		short result = (SwigDerivedClassHasMethod("getMtMode", swigMethodTypes43) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getMtModeSwigExplicitOdDbBaseHostAppServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getMtMode(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int numThreads(MultiThreadedMode mtMode)
	{
		int result = (SwigDerivedClassHasMethod("numThreads", swigMethodTypes44) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_numThreadsSwigExplicitOdDbBaseHostAppServices(swigCPtr, (int)mtMode) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_numThreads(swigCPtr, (int)mtMode));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult BrepBuilder(OdBrepBuilder bbuilder, BrepType bbType)
	{
		int result = (SwigDerivedClassHasMethod("BrepBuilder", swigMethodTypes45) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_BrepBuilderSwigExplicitOdDbBaseHostAppServices(swigCPtr, OdBrepBuilder.getCPtr(bbuilder), (int)bbType) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_BrepBuilder(swigCPtr, OdBrepBuilder.getCPtr(bbuilder), (int)bbType));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getEnv(string varName, ref string value)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(value);
		IntPtr intPtr = jarg;
		try
		{
			int result = (SwigDerivedClassHasMethod("getEnv", swigMethodTypes46) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getEnvSwigExplicitOdDbBaseHostAppServices(swigCPtr, varName, ref jarg) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getEnv(swigCPtr, varName, ref jarg));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				value = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult setEnv(string varName, string newValue)
	{
		int result = (SwigDerivedClassHasMethod("setEnv", swigMethodTypes47) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_setEnvSwigExplicitOdDbBaseHostAppServices(swigCPtr, varName, newValue) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_setEnv(swigCPtr, varName, newValue));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual string getAppUserName(Oda_UserNameFormat unFormat)
	{
		string result = (SwigDerivedClassHasMethod("getAppUserName", swigMethodTypes48) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getAppUserNameSwigExplicitOdDbBaseHostAppServices__SWIG_0(swigCPtr, (int)unFormat) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getAppUserName__SWIG_0(swigCPtr, (int)unFormat));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getAppUserName()
	{
		string result = (SwigDerivedClassHasMethod("getAppUserName", swigMethodTypes49) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getAppUserNameSwigExplicitOdDbBaseHostAppServices__SWIG_1(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getAppUserName__SWIG_1(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_getRealClassName(ptr);
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
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHostAppServices_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBaseHostAppServices));
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

	private void SwigDirectorMethodreleaseProgressMeter(IntPtr pProgressMeter)
	{
		try
		{
			releaseProgressMeter((pProgressMeter == IntPtr.Zero) ? null : new OdDbHostAppProgressMeter(pProgressMeter, cMemoryOwn: false));
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

	private void SwigDirectorMethodwarning__SWIG_1(string warnVisGroup, [MarshalAs(UnmanagedType.LPWStr)] string message)
	{
		try
		{
			warning(warnVisGroup, message);
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

	private void SwigDirectorMethodwarning__SWIG_2(int warningOb)
	{
		try
		{
			warning((OdResult)warningOb);
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

	private void SwigDirectorMethodwarning__SWIG_3(string warnVisGroup, int warningOb)
	{
		try
		{
			warning(warnVisGroup, (OdResult)warningOb);
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
	private string SwigDirectorMethodgetSubstituteFontByChar(IntPtr arg0, char arg1, IntPtr arg2)
	{
		return getSubstituteFontByChar(Helpers.GetRXObject<OdFont>(arg0, bOwn: false, bTryAddToTransaction: false), arg1, Helpers.GetRXObject<OdRxObject>(arg2, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodgetSystemFontFolders(IntPtr aDirs)
	{
		return getSystemFontFolders(new OdStringArray(aDirs, cMemoryOwn: false));
	}

	private void SwigDirectorMethodcollectFilePathsInDirectory__SWIG_0(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath, [MarshalAs(UnmanagedType.LPWStr)] string sFilter)
	{
		try
		{
			collectFilePathsInDirectory(new OdStringArray(res, cMemoryOwn: false), sPath, sFilter);
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

	private void SwigDirectorMethodcollectFilePathsInDirectory__SWIG_1(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath)
	{
		try
		{
			collectFilePathsInDirectory(new OdStringArray(res, cMemoryOwn: false), sPath);
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
}

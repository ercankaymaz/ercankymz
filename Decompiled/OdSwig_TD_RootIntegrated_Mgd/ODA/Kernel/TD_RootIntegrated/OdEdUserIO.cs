using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdEdUserIO : OdRxObject
{
	public delegate IntPtr SwigDelegateOdEdUserIO_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdEdUserIO_1();

	public delegate void SwigDelegateOdEdUserIO_2(IntPtr pSource);

	public delegate bool SwigDelegateOdEdUserIO_3();

	public delegate int SwigDelegateOdEdUserIO_4([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal, int options, IntPtr pTracker);

	public delegate int SwigDelegateOdEdUserIO_5([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal, int options);

	public delegate int SwigDelegateOdEdUserIO_6([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal);

	public delegate int SwigDelegateOdEdUserIO_7([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate int SwigDelegateOdEdUserIO_8([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate int SwigDelegateOdEdUserIO_9([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate int SwigDelegateOdEdUserIO_10([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal);

	public delegate int SwigDelegateOdEdUserIO_11([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate int SwigDelegateOdEdUserIO_12([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate double SwigDelegateOdEdUserIO_13([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate double SwigDelegateOdEdUserIO_14([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate double SwigDelegateOdEdUserIO_15([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal);

	public delegate double SwigDelegateOdEdUserIO_16([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate double SwigDelegateOdEdUserIO_17([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_18([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_19([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_20([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_21([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_22([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate void SwigDelegateOdEdUserIO_23([MarshalAs(UnmanagedType.LPWStr)] string string_);

	public delegate IntPtr SwigDelegateOdEdUserIO_24([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	public delegate IntPtr SwigDelegateOdEdUserIO_25([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	public delegate IntPtr SwigDelegateOdEdUserIO_26([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue);

	public delegate IntPtr SwigDelegateOdEdUserIO_27([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	public delegate IntPtr SwigDelegateOdEdUserIO_28([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_29([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_30([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string keywords);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_31([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_32([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_33([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_34([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_35([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdUserIO_36([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate void SwigDelegateOdEdUserIO_37([MarshalAs(UnmanagedType.LPWStr)] string errmsg);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdEdUserIO_0 swigDelegate0;

	private SwigDelegateOdEdUserIO_1 swigDelegate1;

	private SwigDelegateOdEdUserIO_2 swigDelegate2;

	private SwigDelegateOdEdUserIO_3 swigDelegate3;

	private SwigDelegateOdEdUserIO_4 swigDelegate4;

	private SwigDelegateOdEdUserIO_5 swigDelegate5;

	private SwigDelegateOdEdUserIO_6 swigDelegate6;

	private SwigDelegateOdEdUserIO_7 swigDelegate7;

	private SwigDelegateOdEdUserIO_8 swigDelegate8;

	private SwigDelegateOdEdUserIO_9 swigDelegate9;

	private SwigDelegateOdEdUserIO_10 swigDelegate10;

	private SwigDelegateOdEdUserIO_11 swigDelegate11;

	private SwigDelegateOdEdUserIO_12 swigDelegate12;

	private SwigDelegateOdEdUserIO_13 swigDelegate13;

	private SwigDelegateOdEdUserIO_14 swigDelegate14;

	private SwigDelegateOdEdUserIO_15 swigDelegate15;

	private SwigDelegateOdEdUserIO_16 swigDelegate16;

	private SwigDelegateOdEdUserIO_17 swigDelegate17;

	private SwigDelegateOdEdUserIO_18 swigDelegate18;

	private SwigDelegateOdEdUserIO_19 swigDelegate19;

	private SwigDelegateOdEdUserIO_20 swigDelegate20;

	private SwigDelegateOdEdUserIO_21 swigDelegate21;

	private SwigDelegateOdEdUserIO_22 swigDelegate22;

	private SwigDelegateOdEdUserIO_23 swigDelegate23;

	private SwigDelegateOdEdUserIO_24 swigDelegate24;

	private SwigDelegateOdEdUserIO_25 swigDelegate25;

	private SwigDelegateOdEdUserIO_26 swigDelegate26;

	private SwigDelegateOdEdUserIO_27 swigDelegate27;

	private SwigDelegateOdEdUserIO_28 swigDelegate28;

	private SwigDelegateOdEdUserIO_29 swigDelegate29;

	private SwigDelegateOdEdUserIO_30 swigDelegate30;

	private SwigDelegateOdEdUserIO_31 swigDelegate31;

	private SwigDelegateOdEdUserIO_32 swigDelegate32;

	private SwigDelegateOdEdUserIO_33 swigDelegate33;

	private SwigDelegateOdEdUserIO_34 swigDelegate34;

	private SwigDelegateOdEdUserIO_35 swigDelegate35;

	private SwigDelegateOdEdUserIO_36 swigDelegate36;

	private SwigDelegateOdEdUserIO_37 swigDelegate37;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[5]
	{
		typeof(string),
		typeof(string),
		typeof(int),
		typeof(int),
		typeof(OdEdIntegerTracker)
	};

	private static Type[] swigMethodTypes5 = new Type[4]
	{
		typeof(string),
		typeof(string),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes8 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(int),
		typeof(string),
		typeof(OdEdIntegerTracker)
	};

	private static Type[] swigMethodTypes9 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes10 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes13 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(double),
		typeof(string),
		typeof(OdEdRealTracker)
	};

	private static Type[] swigMethodTypes14 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(double),
		typeof(string)
	};

	private static Type[] swigMethodTypes15 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(double)
	};

	private static Type[] swigMethodTypes16 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes18 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(OdEdStringTracker)
	};

	private static Type[] swigMethodTypes19 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes20 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes21 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes24 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(OdCmColorBase),
		typeof(string),
		typeof(OdEdColorTracker)
	};

	private static Type[] swigMethodTypes25 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(OdCmColorBase),
		typeof(string)
	};

	private static Type[] swigMethodTypes26 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(OdCmColorBase)
	};

	private static Type[] swigMethodTypes27 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes29 = new Type[8]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(OdEdStringTracker)
	};

	private static Type[] swigMethodTypes30 = new Type[7]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes31 = new Type[6]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes32 = new Type[5]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes33 = new Type[4]
	{
		typeof(string),
		typeof(int),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes34 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes35 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(string) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdEdUserIO(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdEdUserIO obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdEdUserIO(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdEdUserIO cast(OdRxObject pObj)
	{
		OdEdUserIO rXObject = Helpers.GetRXObject<OdEdUserIO>(TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_isASwigExplicitOdEdUserIO(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_queryXSwigExplicitOdEdUserIO(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdEdUserIO createObject()
	{
		OdEdUserIO rXObject = Helpers.GetRXObject<OdEdUserIO>(TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool interactive()
	{
		bool result = (SwigDerivedClassHasMethod("interactive", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_interactiveSwigExplicitOdEdUserIO(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_interactive(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getKeyword(string prompt, string keywords, int defVal, int options, OdEdIntegerTracker pTracker)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getKeyword__SWIG_0(swigCPtr, prompt, keywords, defVal, options, OdEdIntegerTracker.getCPtr(pTracker));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getKeyword(string prompt, string keywords, int defVal, int options)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getKeyword__SWIG_1(swigCPtr, prompt, keywords, defVal, options);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getKeyword(string prompt, string keywords, int defVal)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getKeyword__SWIG_2(swigCPtr, prompt, keywords, defVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getKeyword(string prompt, string keywords)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getKeyword__SWIG_3(swigCPtr, prompt, keywords);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getInt(string prompt, int options, int defVal, string keywords, OdEdIntegerTracker pTracker)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getInt__SWIG_0(swigCPtr, prompt, options, defVal, keywords, OdEdIntegerTracker.getCPtr(pTracker));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getInt(string prompt, int options, int defVal, string keywords)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getInt__SWIG_1(swigCPtr, prompt, options, defVal, keywords);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getInt(string prompt, int options, int defVal)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getInt__SWIG_2(swigCPtr, prompt, options, defVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getInt(string prompt, int options)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getInt__SWIG_3(swigCPtr, prompt, options);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getInt(string prompt)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getInt__SWIG_4(swigCPtr, prompt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getReal(string prompt, int options, double defVal, string keywords, OdEdRealTracker pTracker)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getReal__SWIG_0(swigCPtr, prompt, options, defVal, keywords, OdEdRealTracker.getCPtr(pTracker));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getReal(string prompt, int options, double defVal, string keywords)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getReal__SWIG_1(swigCPtr, prompt, options, defVal, keywords);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getReal(string prompt, int options, double defVal)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getReal__SWIG_2(swigCPtr, prompt, options, defVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getReal(string prompt, int options)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getReal__SWIG_3(swigCPtr, prompt, options);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getReal(string prompt)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getReal__SWIG_4(swigCPtr, prompt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getString(string prompt, int options, string defValue, string keywords, OdEdStringTracker pTracker)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getString__SWIG_0(swigCPtr, prompt, options, defValue, keywords, OdEdStringTracker.getCPtr(pTracker));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getString(string prompt, int options, string defValue, string keywords)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getString__SWIG_1(swigCPtr, prompt, options, defValue, keywords);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getString(string prompt, int options, string defValue)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getString__SWIG_2(swigCPtr, prompt, options, defValue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getString(string prompt, int options)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getString__SWIG_3(swigCPtr, prompt, options);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getString(string prompt)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getString__SWIG_4(swigCPtr, prompt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void putString(string string_)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_putString(swigCPtr, string_);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColorBase getCmColor(string prompt, int options, OdCmColorBase pDefaultValue, string keywords, OdEdColorTracker pTracker)
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getCmColor__SWIG_0(swigCPtr, prompt, options, OdCmColorBase.getCPtr(pDefaultValue), keywords, OdEdColorTracker.getCPtr(pTracker)), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColorBase getCmColor(string prompt, int options, OdCmColorBase pDefaultValue, string keywords)
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getCmColor__SWIG_1(swigCPtr, prompt, options, OdCmColorBase.getCPtr(pDefaultValue), keywords), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColorBase getCmColor(string prompt, int options, OdCmColorBase pDefaultValue)
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getCmColor__SWIG_2(swigCPtr, prompt, options, OdCmColorBase.getCPtr(pDefaultValue)), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColorBase getCmColor(string prompt, int options)
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getCmColor__SWIG_3(swigCPtr, prompt, options), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColorBase getCmColor(string prompt)
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getCmColor__SWIG_4(swigCPtr, prompt), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFilePath(string prompt, int options, string dialogCaption, string defExt, string fileName, string filter, string keywords, OdEdStringTracker pTracker)
	{
		string result = (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes29) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePathSwigExplicitOdEdUserIO__SWIG_0(swigCPtr, prompt, options, dialogCaption, defExt, fileName, filter, keywords, OdEdStringTracker.getCPtr(pTracker)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePath__SWIG_0(swigCPtr, prompt, options, dialogCaption, defExt, fileName, filter, keywords, OdEdStringTracker.getCPtr(pTracker)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFilePath(string prompt, int options, string dialogCaption, string defExt, string fileName, string filter, string keywords)
	{
		string result = (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes30) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePathSwigExplicitOdEdUserIO__SWIG_1(swigCPtr, prompt, options, dialogCaption, defExt, fileName, filter, keywords) : TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePath__SWIG_1(swigCPtr, prompt, options, dialogCaption, defExt, fileName, filter, keywords));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFilePath(string prompt, int options, string dialogCaption, string defExt, string fileName, string filter)
	{
		string result = (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes31) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePathSwigExplicitOdEdUserIO__SWIG_2(swigCPtr, prompt, options, dialogCaption, defExt, fileName, filter) : TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePath__SWIG_2(swigCPtr, prompt, options, dialogCaption, defExt, fileName, filter));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFilePath(string prompt, int options, string dialogCaption, string defExt, string fileName)
	{
		string result = (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes32) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePathSwigExplicitOdEdUserIO__SWIG_3(swigCPtr, prompt, options, dialogCaption, defExt, fileName) : TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePath__SWIG_3(swigCPtr, prompt, options, dialogCaption, defExt, fileName));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFilePath(string prompt, int options, string dialogCaption, string defExt)
	{
		string result = (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes33) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePathSwigExplicitOdEdUserIO__SWIG_4(swigCPtr, prompt, options, dialogCaption, defExt) : TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePath__SWIG_4(swigCPtr, prompt, options, dialogCaption, defExt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFilePath(string prompt, int options, string dialogCaption)
	{
		string result = (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes34) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePathSwigExplicitOdEdUserIO__SWIG_5(swigCPtr, prompt, options, dialogCaption) : TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePath__SWIG_5(swigCPtr, prompt, options, dialogCaption));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFilePath(string prompt, int options)
	{
		string result = (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes35) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePathSwigExplicitOdEdUserIO__SWIG_6(swigCPtr, prompt, options) : TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePath__SWIG_6(swigCPtr, prompt, options));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFilePath(string prompt)
	{
		string result = (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes36) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePathSwigExplicitOdEdUserIO__SWIG_7(swigCPtr, prompt) : TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getFilePath__SWIG_7(swigCPtr, prompt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void putError(string errmsg)
	{
		if (SwigDerivedClassHasMethod("putError", swigMethodTypes37))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_putErrorSwigExplicitOdEdUserIO(swigCPtr, errmsg);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_putError(swigCPtr, errmsg);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdEdUserIO()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdEdUserIO(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdEdUserIO) != GetType();
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
		if (SwigDerivedClassHasMethod("interactive", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinteractive;
		}
		if (SwigDerivedClassHasMethod("getKeyword", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetKeyword__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getKeyword", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetKeyword__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getKeyword", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetKeyword__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getKeyword", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetKeyword__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getInt", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetInt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getInt", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetInt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getInt", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetInt__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getInt", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetInt__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getInt", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetInt__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getReal", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetReal__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getReal", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetReal__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getReal", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetReal__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getReal", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetReal__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getReal", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetReal__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetString__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodgetString__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetString__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodgetString__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodgetString__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("putString", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodputString;
		}
		if (SwigDerivedClassHasMethod("getCmColor", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodgetCmColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getCmColor", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodgetCmColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getCmColor", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodgetCmColor__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getCmColor", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodgetCmColor__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getCmColor", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodgetCmColor__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodgetFilePath__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodgetFilePath__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodgetFilePath__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodgetFilePath__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodgetFilePath__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodgetFilePath__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodgetFilePath__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("getFilePath", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodgetFilePath__SWIG_7;
		}
		if (SwigDerivedClassHasMethod("putError", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodputError;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdEdUserIO_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdEdUserIO));
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

	private bool SwigDirectorMethodinteractive()
	{
		return interactive();
	}

	private int SwigDirectorMethodgetKeyword__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal, int options, IntPtr pTracker)
	{
		return getKeyword(prompt, keywords, defVal, options, Helpers.GetRXObject<OdEdIntegerTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodgetKeyword__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal, int options)
	{
		return getKeyword(prompt, keywords, defVal, options);
	}

	private int SwigDirectorMethodgetKeyword__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords, int defVal)
	{
		return getKeyword(prompt, keywords, defVal);
	}

	private int SwigDirectorMethodgetKeyword__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return getKeyword(prompt, keywords);
	}

	private int SwigDirectorMethodgetInt__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return getInt(prompt, options, defVal, keywords, Helpers.GetRXObject<OdEdIntegerTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodgetInt__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return getInt(prompt, options, defVal, keywords);
	}

	private int SwigDirectorMethodgetInt__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, int defVal)
	{
		return getInt(prompt, options, defVal);
	}

	private int SwigDirectorMethodgetInt__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return getInt(prompt, options);
	}

	private int SwigDirectorMethodgetInt__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return getInt(prompt);
	}

	private double SwigDirectorMethodgetReal__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return getReal(prompt, options, defVal, keywords, Helpers.GetRXObject<OdEdRealTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodgetReal__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return getReal(prompt, options, defVal, keywords);
	}

	private double SwigDirectorMethodgetReal__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, double defVal)
	{
		return getReal(prompt, options, defVal);
	}

	private double SwigDirectorMethodgetReal__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return getReal(prompt, options);
	}

	private double SwigDirectorMethodgetReal__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return getReal(prompt);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return getString(prompt, options, defValue, keywords, Helpers.GetRXObject<OdEdStringTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return getString(prompt, options, defValue, keywords);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string defValue)
	{
		return getString(prompt, options, defValue);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return getString(prompt, options);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return getString(prompt);
	}

	private void SwigDirectorMethodputString([MarshalAs(UnmanagedType.LPWStr)] string string_)
	{
		try
		{
			putString(string_);
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

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt, options, Helpers.GetObject<OdCmColorBase>(pDefaultValue, bOwn: false, bTryAddToTransaction: false), keywords, Helpers.GetRXObject<OdEdColorTracker>(pTracker, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt, options, Helpers.GetObject<OdCmColorBase>(pDefaultValue, bOwn: false, bTryAddToTransaction: false), keywords)).Handle;
	}

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pDefaultValue)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt, options, Helpers.GetObject<OdCmColorBase>(pDefaultValue, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt, options)).Handle;
	}

	private IntPtr SwigDirectorMethodgetCmColor__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return OdCmColorBase.getCPtr(getCmColor(prompt)).Handle;
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string keywords, IntPtr pTracker)
	{
		return getFilePath(prompt, options, dialogCaption, defExt, fileName, filter, keywords, Helpers.GetRXObject<OdEdStringTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		return getFilePath(prompt, options, dialogCaption, defExt, fileName, filter, keywords);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string filter)
	{
		return getFilePath(prompt, options, dialogCaption, defExt, fileName, filter);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt, [MarshalAs(UnmanagedType.LPWStr)] string fileName)
	{
		return getFilePath(prompt, options, dialogCaption, defExt, fileName);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption, [MarshalAs(UnmanagedType.LPWStr)] string defExt)
	{
		return getFilePath(prompt, options, dialogCaption, defExt);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_5([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, [MarshalAs(UnmanagedType.LPWStr)] string dialogCaption)
	{
		return getFilePath(prompt, options, dialogCaption);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_6([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return getFilePath(prompt, options);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilePath__SWIG_7([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return getFilePath(prompt);
	}

	private void SwigDirectorMethodputError([MarshalAs(UnmanagedType.LPWStr)] string errmsg)
	{
		try
		{
			putError(errmsg);
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

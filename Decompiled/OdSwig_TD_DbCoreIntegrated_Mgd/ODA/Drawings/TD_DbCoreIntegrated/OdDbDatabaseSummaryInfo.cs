using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDatabaseSummaryInfo : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbDatabaseSummaryInfo_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbDatabaseSummaryInfo_1();

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDatabaseSummaryInfo_3();

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_4([MarshalAs(UnmanagedType.LPWStr)] string title);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDatabaseSummaryInfo_5();

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_6([MarshalAs(UnmanagedType.LPWStr)] string subject);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDatabaseSummaryInfo_7();

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_8([MarshalAs(UnmanagedType.LPWStr)] string author);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDatabaseSummaryInfo_9();

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_10([MarshalAs(UnmanagedType.LPWStr)] string keywords);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDatabaseSummaryInfo_11();

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_12([MarshalAs(UnmanagedType.LPWStr)] string comments);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDatabaseSummaryInfo_13();

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_14([MarshalAs(UnmanagedType.LPWStr)] string lastSavedBy);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDatabaseSummaryInfo_15();

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_16([MarshalAs(UnmanagedType.LPWStr)] string revisionNumber);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDatabaseSummaryInfo_17();

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_18([MarshalAs(UnmanagedType.LPWStr)] string hyperlinkBase);

	public delegate int SwigDelegateOdDbDatabaseSummaryInfo_19();

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_20([MarshalAs(UnmanagedType.LPWStr)] string key, [MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_21(int fieldIndex);

	public delegate bool SwigDelegateOdDbDatabaseSummaryInfo_22([MarshalAs(UnmanagedType.LPWStr)] string key);

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_23(int fieldIndex, IntPtr key, IntPtr rvalue);

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_24(int fieldIndex, [MarshalAs(UnmanagedType.LPWStr)] string key, [MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate bool SwigDelegateOdDbDatabaseSummaryInfo_25([MarshalAs(UnmanagedType.LPWStr)] string customInfoKey, IntPtr rvalue);

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_26([MarshalAs(UnmanagedType.LPWStr)] string customInfoKey, [MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate IntPtr SwigDelegateOdDbDatabaseSummaryInfo_27();

	public delegate void SwigDelegateOdDbDatabaseSummaryInfo_28(IntPtr pDb);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbDatabaseSummaryInfo_0 swigDelegate0;

	private SwigDelegateOdDbDatabaseSummaryInfo_1 swigDelegate1;

	private SwigDelegateOdDbDatabaseSummaryInfo_2 swigDelegate2;

	private SwigDelegateOdDbDatabaseSummaryInfo_3 swigDelegate3;

	private SwigDelegateOdDbDatabaseSummaryInfo_4 swigDelegate4;

	private SwigDelegateOdDbDatabaseSummaryInfo_5 swigDelegate5;

	private SwigDelegateOdDbDatabaseSummaryInfo_6 swigDelegate6;

	private SwigDelegateOdDbDatabaseSummaryInfo_7 swigDelegate7;

	private SwigDelegateOdDbDatabaseSummaryInfo_8 swigDelegate8;

	private SwigDelegateOdDbDatabaseSummaryInfo_9 swigDelegate9;

	private SwigDelegateOdDbDatabaseSummaryInfo_10 swigDelegate10;

	private SwigDelegateOdDbDatabaseSummaryInfo_11 swigDelegate11;

	private SwigDelegateOdDbDatabaseSummaryInfo_12 swigDelegate12;

	private SwigDelegateOdDbDatabaseSummaryInfo_13 swigDelegate13;

	private SwigDelegateOdDbDatabaseSummaryInfo_14 swigDelegate14;

	private SwigDelegateOdDbDatabaseSummaryInfo_15 swigDelegate15;

	private SwigDelegateOdDbDatabaseSummaryInfo_16 swigDelegate16;

	private SwigDelegateOdDbDatabaseSummaryInfo_17 swigDelegate17;

	private SwigDelegateOdDbDatabaseSummaryInfo_18 swigDelegate18;

	private SwigDelegateOdDbDatabaseSummaryInfo_19 swigDelegate19;

	private SwigDelegateOdDbDatabaseSummaryInfo_20 swigDelegate20;

	private SwigDelegateOdDbDatabaseSummaryInfo_21 swigDelegate21;

	private SwigDelegateOdDbDatabaseSummaryInfo_22 swigDelegate22;

	private SwigDelegateOdDbDatabaseSummaryInfo_23 swigDelegate23;

	private SwigDelegateOdDbDatabaseSummaryInfo_24 swigDelegate24;

	private SwigDelegateOdDbDatabaseSummaryInfo_25 swigDelegate25;

	private SwigDelegateOdDbDatabaseSummaryInfo_26 swigDelegate26;

	private SwigDelegateOdDbDatabaseSummaryInfo_27 swigDelegate27;

	private SwigDelegateOdDbDatabaseSummaryInfo_28 swigDelegate28;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes23 = new Type[3]
	{
		typeof(int),
		typeof(string).MakeByRefType(),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes24 = new Type[3]
	{
		typeof(int),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes25 = new Type[2]
	{
		typeof(string),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes26 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(OdDbDatabase) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDatabaseSummaryInfo(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDatabaseSummaryInfo obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDatabaseSummaryInfo(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbDatabaseSummaryInfo cast(OdRxObject pObj)
	{
		OdDbDatabaseSummaryInfo rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabaseSummaryInfo>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_isASwigExplicitOdDbDatabaseSummaryInfo(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_queryXSwigExplicitOdDbDatabaseSummaryInfo(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbDatabaseSummaryInfo createObject()
	{
		OdDbDatabaseSummaryInfo rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabaseSummaryInfo>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string getTitle()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_getTitle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTitle(string title)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_setTitle(swigCPtr, title);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getSubject()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_getSubject(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSubject(string subject)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_setSubject(swigCPtr, subject);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getAuthor()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_getAuthor(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAuthor(string author)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_setAuthor(swigCPtr, author);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getKeywords()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_getKeywords(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setKeywords(string keywords)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_setKeywords(swigCPtr, keywords);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getComments()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_getComments(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setComments(string comments)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_setComments(swigCPtr, comments);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getLastSavedBy()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_getLastSavedBy(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLastSavedBy(string lastSavedBy)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_setLastSavedBy(swigCPtr, lastSavedBy);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getRevisionNumber()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_getRevisionNumber(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRevisionNumber(string revisionNumber)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_setRevisionNumber(swigCPtr, revisionNumber);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getHyperlinkBase()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_getHyperlinkBase(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHyperlinkBase(string hyperlinkBase)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_setHyperlinkBase(swigCPtr, hyperlinkBase);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int numCustomInfo()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_numCustomInfo(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void addCustomSummaryInfo(string key, string value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_addCustomSummaryInfo(swigCPtr, key, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void deleteCustomSummaryInfo(int fieldIndex)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_deleteCustomSummaryInfo__SWIG_0(swigCPtr, fieldIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool deleteCustomSummaryInfo(string key)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_deleteCustomSummaryInfo__SWIG_1(swigCPtr, key);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getCustomSummaryInfo(int fieldIndex, ref string key, ref string rvalue)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(key);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = Marshal.StringToCoTaskMemUni(rvalue);
		IntPtr intPtr2 = jarg2;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_getCustomSummaryInfo__SWIG_0(swigCPtr, fieldIndex, ref jarg, ref jarg2);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				key = Marshal.PtrToStringUni(jarg);
			}
			if (jarg2 != intPtr2)
			{
				rvalue = Marshal.PtrToStringUni(jarg2);
			}
		}
	}

	public virtual void setCustomSummaryInfo(int fieldIndex, string key, string value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_setCustomSummaryInfo__SWIG_0(swigCPtr, fieldIndex, key, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getCustomSummaryInfo(string customInfoKey, ref string rvalue)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(rvalue);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_getCustomSummaryInfo__SWIG_1(swigCPtr, customInfoKey, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				rvalue = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual void setCustomSummaryInfo(string customInfoKey, string value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_setCustomSummaryInfo__SWIG_1(swigCPtr, customInfoKey, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbDatabase database()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setDatabase(OdDbDatabase pDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_setDatabase(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getTitle", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetTitle;
		}
		if (SwigDerivedClassHasMethod("setTitle", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetTitle;
		}
		if (SwigDerivedClassHasMethod("getSubject", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetSubject;
		}
		if (SwigDerivedClassHasMethod("setSubject", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetSubject;
		}
		if (SwigDerivedClassHasMethod("getAuthor", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetAuthor;
		}
		if (SwigDerivedClassHasMethod("setAuthor", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetAuthor;
		}
		if (SwigDerivedClassHasMethod("getKeywords", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetKeywords;
		}
		if (SwigDerivedClassHasMethod("setKeywords", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetKeywords;
		}
		if (SwigDerivedClassHasMethod("getComments", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetComments;
		}
		if (SwigDerivedClassHasMethod("setComments", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetComments;
		}
		if (SwigDerivedClassHasMethod("getLastSavedBy", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetLastSavedBy;
		}
		if (SwigDerivedClassHasMethod("setLastSavedBy", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetLastSavedBy;
		}
		if (SwigDerivedClassHasMethod("getRevisionNumber", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetRevisionNumber;
		}
		if (SwigDerivedClassHasMethod("setRevisionNumber", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetRevisionNumber;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkBase", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetHyperlinkBase;
		}
		if (SwigDerivedClassHasMethod("setHyperlinkBase", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodsetHyperlinkBase;
		}
		if (SwigDerivedClassHasMethod("numCustomInfo", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodnumCustomInfo;
		}
		if (SwigDerivedClassHasMethod("addCustomSummaryInfo", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodaddCustomSummaryInfo;
		}
		if (SwigDerivedClassHasMethod("deleteCustomSummaryInfo", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethoddeleteCustomSummaryInfo__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("deleteCustomSummaryInfo", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethoddeleteCustomSummaryInfo__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getCustomSummaryInfo", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodgetCustomSummaryInfo__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setCustomSummaryInfo", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsetCustomSummaryInfo__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getCustomSummaryInfo", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodgetCustomSummaryInfo__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setCustomSummaryInfo", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodsetCustomSummaryInfo__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("database", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethoddatabase;
		}
		if (SwigDerivedClassHasMethod("setDatabase", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodsetDatabase;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabaseSummaryInfo_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbDatabaseSummaryInfo));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetTitle()
	{
		return getTitle();
	}

	private void SwigDirectorMethodsetTitle([MarshalAs(UnmanagedType.LPWStr)] string title)
	{
		try
		{
			setTitle(title);
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetSubject()
	{
		return getSubject();
	}

	private void SwigDirectorMethodsetSubject([MarshalAs(UnmanagedType.LPWStr)] string subject)
	{
		try
		{
			setSubject(subject);
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetAuthor()
	{
		return getAuthor();
	}

	private void SwigDirectorMethodsetAuthor([MarshalAs(UnmanagedType.LPWStr)] string author)
	{
		try
		{
			setAuthor(author);
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetKeywords()
	{
		return getKeywords();
	}

	private void SwigDirectorMethodsetKeywords([MarshalAs(UnmanagedType.LPWStr)] string keywords)
	{
		try
		{
			setKeywords(keywords);
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetComments()
	{
		return getComments();
	}

	private void SwigDirectorMethodsetComments([MarshalAs(UnmanagedType.LPWStr)] string comments)
	{
		try
		{
			setComments(comments);
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetLastSavedBy()
	{
		return getLastSavedBy();
	}

	private void SwigDirectorMethodsetLastSavedBy([MarshalAs(UnmanagedType.LPWStr)] string lastSavedBy)
	{
		try
		{
			setLastSavedBy(lastSavedBy);
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetRevisionNumber()
	{
		return getRevisionNumber();
	}

	private void SwigDirectorMethodsetRevisionNumber([MarshalAs(UnmanagedType.LPWStr)] string revisionNumber)
	{
		try
		{
			setRevisionNumber(revisionNumber);
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetHyperlinkBase()
	{
		return getHyperlinkBase();
	}

	private void SwigDirectorMethodsetHyperlinkBase([MarshalAs(UnmanagedType.LPWStr)] string hyperlinkBase)
	{
		try
		{
			setHyperlinkBase(hyperlinkBase);
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

	private int SwigDirectorMethodnumCustomInfo()
	{
		return numCustomInfo();
	}

	private void SwigDirectorMethodaddCustomSummaryInfo([MarshalAs(UnmanagedType.LPWStr)] string key, [MarshalAs(UnmanagedType.LPWStr)] string value)
	{
		try
		{
			addCustomSummaryInfo(key, value);
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

	private void SwigDirectorMethoddeleteCustomSummaryInfo__SWIG_0(int fieldIndex)
	{
		try
		{
			deleteCustomSummaryInfo(fieldIndex);
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

	private bool SwigDirectorMethoddeleteCustomSummaryInfo__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string key)
	{
		return deleteCustomSummaryInfo(key);
	}

	private void SwigDirectorMethodgetCustomSummaryInfo__SWIG_0(int fieldIndex, IntPtr key, IntPtr rvalue)
	{
		OdSwigDirectorHelper.director_UnpackData(key, out var pOriginalObject, out var pFunction);
		string key2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = key2;
		OdSwigDirectorHelper.director_UnpackData(rvalue, out var pOriginalObject2, out var pFunction2);
		string rvalue2 = Marshal.PtrToStringUni(pOriginalObject2);
		string text2 = rvalue2;
		try
		{
			getCustomSummaryInfo(fieldIndex, ref key2, ref rvalue2);
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
		finally
		{
			if (key2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(key2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(key);
			if (rvalue2 != text2)
			{
				IntPtr intPtr2 = Marshal.StringToCoTaskMemUni(rvalue2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction2, intPtr2);
				Marshal.FreeCoTaskMem(intPtr2);
			}
			OdSwigDirectorHelper.director_freeData(rvalue);
		}
	}

	private void SwigDirectorMethodsetCustomSummaryInfo__SWIG_0(int fieldIndex, [MarshalAs(UnmanagedType.LPWStr)] string key, [MarshalAs(UnmanagedType.LPWStr)] string value)
	{
		try
		{
			setCustomSummaryInfo(fieldIndex, key, value);
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

	private bool SwigDirectorMethodgetCustomSummaryInfo__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string customInfoKey, IntPtr rvalue)
	{
		OdSwigDirectorHelper.director_UnpackData(rvalue, out var pOriginalObject, out var pFunction);
		string rvalue2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = rvalue2;
		try
		{
			return getCustomSummaryInfo(customInfoKey, ref rvalue2);
		}
		finally
		{
			if (rvalue2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(rvalue2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(rvalue);
		}
	}

	private void SwigDirectorMethodsetCustomSummaryInfo__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string customInfoKey, [MarshalAs(UnmanagedType.LPWStr)] string value)
	{
		try
		{
			setCustomSummaryInfo(customInfoKey, value);
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
		return OdDbDatabase.getCPtr(database()).Handle;
	}

	private void SwigDirectorMethodsetDatabase(IntPtr pDb)
	{
		try
		{
			setDatabase(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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

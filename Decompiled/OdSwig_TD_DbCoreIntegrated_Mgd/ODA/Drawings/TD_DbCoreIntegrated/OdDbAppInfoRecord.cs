using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbAppInfoRecord : IDisposable
{
	public delegate int SwigDelegateOdDbAppInfoRecord_0();

	public delegate IntPtr SwigDelegateOdDbAppInfoRecord_1();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbAppInfoRecord_2();

	public delegate bool SwigDelegateOdDbAppInfoRecord_3(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_4(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_5(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_6(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_7(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_8(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_9(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_10(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_11(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_12(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_13(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_14(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_15(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_16(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_17(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_18(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_19(IntPtr outStr);

	public delegate bool SwigDelegateOdDbAppInfoRecord_20(IntPtr outStr);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdDbAppInfoRecord_0 swigDelegate0;

	private SwigDelegateOdDbAppInfoRecord_1 swigDelegate1;

	private SwigDelegateOdDbAppInfoRecord_2 swigDelegate2;

	private SwigDelegateOdDbAppInfoRecord_3 swigDelegate3;

	private SwigDelegateOdDbAppInfoRecord_4 swigDelegate4;

	private SwigDelegateOdDbAppInfoRecord_5 swigDelegate5;

	private SwigDelegateOdDbAppInfoRecord_6 swigDelegate6;

	private SwigDelegateOdDbAppInfoRecord_7 swigDelegate7;

	private SwigDelegateOdDbAppInfoRecord_8 swigDelegate8;

	private SwigDelegateOdDbAppInfoRecord_9 swigDelegate9;

	private SwigDelegateOdDbAppInfoRecord_10 swigDelegate10;

	private SwigDelegateOdDbAppInfoRecord_11 swigDelegate11;

	private SwigDelegateOdDbAppInfoRecord_12 swigDelegate12;

	private SwigDelegateOdDbAppInfoRecord_13 swigDelegate13;

	private SwigDelegateOdDbAppInfoRecord_14 swigDelegate14;

	private SwigDelegateOdDbAppInfoRecord_15 swigDelegate15;

	private SwigDelegateOdDbAppInfoRecord_16 swigDelegate16;

	private SwigDelegateOdDbAppInfoRecord_17 swigDelegate17;

	private SwigDelegateOdDbAppInfoRecord_18 swigDelegate18;

	private SwigDelegateOdDbAppInfoRecord_19 swigDelegate19;

	private SwigDelegateOdDbAppInfoRecord_20 swigDelegate20;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(string).MakeByRefType() };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbAppInfoRecord(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbAppInfoRecord obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbAppInfoRecord()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbAppInfoRecord(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual int recordType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_recordType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGUID getRecordGUID()
	{
		OdGUID result = new OdGUID(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getRecordGUID(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getRawRecordData()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getRawRecordData(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getProductInformation_name(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProductInformation_name(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProductInformation_build_version(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProductInformation_build_version(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProductInformation_registry_version(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProductInformation_registry_version(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProductInformation_install_id_string(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProductInformation_install_id_string(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProductInformation_registry_localeID(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProductInformation_registry_localeID(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProductInformation_git_commit_id(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProductInformation_git_commit_id(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProperty_Title(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProperty_Title(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProperty_Subject(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProperty_Subject(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProperty_Author(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProperty_Author(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProperty_Keywords(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProperty_Keywords(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProperty_Comments(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProperty_Comments(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProperty_LastSavedBy(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProperty_LastSavedBy(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProperty_RevisionNumber(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProperty_RevisionNumber(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProperty_TduUpdate(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProperty_TduUpdate(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProperty_TduCreate(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProperty_TduCreate(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProperty_HyperlinkBase(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProperty_HyperlinkBase(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProperty_ProductName(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProperty_ProductName(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getProperty_ProductBuildVersion(ref string outStr)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(outStr);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getProperty_ProductBuildVersion(swigCPtr, ref jarg);
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
				outStr = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbAppInfoRecord()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbAppInfoRecord(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbAppInfoRecord) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("recordType", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodrecordType;
		}
		if (SwigDerivedClassHasMethod("getRecordGUID", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetRecordGUID;
		}
		if (SwigDerivedClassHasMethod("getRawRecordData", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetRawRecordData;
		}
		if (SwigDerivedClassHasMethod("getProductInformation_name", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetProductInformation_name;
		}
		if (SwigDerivedClassHasMethod("getProductInformation_build_version", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetProductInformation_build_version;
		}
		if (SwigDerivedClassHasMethod("getProductInformation_registry_version", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetProductInformation_registry_version;
		}
		if (SwigDerivedClassHasMethod("getProductInformation_install_id_string", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetProductInformation_install_id_string;
		}
		if (SwigDerivedClassHasMethod("getProductInformation_registry_localeID", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetProductInformation_registry_localeID;
		}
		if (SwigDerivedClassHasMethod("getProductInformation_git_commit_id", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetProductInformation_git_commit_id;
		}
		if (SwigDerivedClassHasMethod("getProperty_Title", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetProperty_Title;
		}
		if (SwigDerivedClassHasMethod("getProperty_Subject", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetProperty_Subject;
		}
		if (SwigDerivedClassHasMethod("getProperty_Author", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetProperty_Author;
		}
		if (SwigDerivedClassHasMethod("getProperty_Keywords", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetProperty_Keywords;
		}
		if (SwigDerivedClassHasMethod("getProperty_Comments", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetProperty_Comments;
		}
		if (SwigDerivedClassHasMethod("getProperty_LastSavedBy", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetProperty_LastSavedBy;
		}
		if (SwigDerivedClassHasMethod("getProperty_RevisionNumber", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetProperty_RevisionNumber;
		}
		if (SwigDerivedClassHasMethod("getProperty_TduUpdate", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetProperty_TduUpdate;
		}
		if (SwigDerivedClassHasMethod("getProperty_TduCreate", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetProperty_TduCreate;
		}
		if (SwigDerivedClassHasMethod("getProperty_HyperlinkBase", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetProperty_HyperlinkBase;
		}
		if (SwigDerivedClassHasMethod("getProperty_ProductName", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodgetProperty_ProductName;
		}
		if (SwigDerivedClassHasMethod("getProperty_ProductBuildVersion", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetProperty_ProductBuildVersion;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecord_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbAppInfoRecord));
	}

	private int SwigDirectorMethodrecordType()
	{
		return recordType();
	}

	private IntPtr SwigDirectorMethodgetRecordGUID()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGUID.getCPtr(getRecordGUID()).Handle;
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetRawRecordData()
	{
		return getRawRecordData();
	}

	private bool SwigDirectorMethodgetProductInformation_name(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProductInformation_name(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProductInformation_build_version(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProductInformation_build_version(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProductInformation_registry_version(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProductInformation_registry_version(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProductInformation_install_id_string(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProductInformation_install_id_string(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProductInformation_registry_localeID(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProductInformation_registry_localeID(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProductInformation_git_commit_id(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProductInformation_git_commit_id(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProperty_Title(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProperty_Title(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProperty_Subject(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProperty_Subject(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProperty_Author(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProperty_Author(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProperty_Keywords(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProperty_Keywords(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProperty_Comments(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProperty_Comments(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProperty_LastSavedBy(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProperty_LastSavedBy(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProperty_RevisionNumber(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProperty_RevisionNumber(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProperty_TduUpdate(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProperty_TduUpdate(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProperty_TduCreate(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProperty_TduCreate(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProperty_HyperlinkBase(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProperty_HyperlinkBase(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProperty_ProductName(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProperty_ProductName(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}

	private bool SwigDirectorMethodgetProperty_ProductBuildVersion(IntPtr outStr)
	{
		OdSwigDirectorHelper.director_UnpackData(outStr, out var pOriginalObject, out var pFunction);
		string outStr2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = outStr2;
		try
		{
			return getProperty_ProductBuildVersion(ref outStr2);
		}
		finally
		{
			if (outStr2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(outStr2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(outStr);
		}
	}
}

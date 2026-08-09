using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class RxSystemServicesImpl : OdRxSystemServices
{
	public delegate IntPtr SwigDelegateRxSystemServicesImpl_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateRxSystemServicesImpl_1();

	public delegate void SwigDelegateRxSystemServicesImpl_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateRxSystemServicesImpl_3([MarshalAs(UnmanagedType.LPWStr)] string filename, int accessMode, int shareMode, int creationDisposition);

	public delegate IntPtr SwigDelegateRxSystemServicesImpl_4([MarshalAs(UnmanagedType.LPWStr)] string filename, int accessMode, int shareMode);

	public delegate IntPtr SwigDelegateRxSystemServicesImpl_5([MarshalAs(UnmanagedType.LPWStr)] string filename, int accessMode);

	public delegate IntPtr SwigDelegateRxSystemServicesImpl_6([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate bool SwigDelegateRxSystemServicesImpl_7([MarshalAs(UnmanagedType.LPWStr)] string filename, int accessMode);

	public delegate long SwigDelegateRxSystemServicesImpl_8([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate long SwigDelegateRxSystemServicesImpl_9([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate long SwigDelegateRxSystemServicesImpl_10([MarshalAs(UnmanagedType.LPWStr)] string filename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateRxSystemServicesImpl_11();

	public delegate IntPtr SwigDelegateRxSystemServicesImpl_12();

	public delegate IntPtr SwigDelegateRxSystemServicesImpl_13([MarshalAs(UnmanagedType.LPWStr)] string moduleFileName, bool silent);

	public delegate void SwigDelegateRxSystemServicesImpl_14(IntPtr pModuleObj);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateRxSystemServicesImpl_15([MarshalAs(UnmanagedType.LPWStr)] string applicationName);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateRxSystemServicesImpl_16([MarshalAs(UnmanagedType.LPWStr)] string applicationName, int loadReason);

	public delegate void SwigDelegateRxSystemServicesImpl_17([MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate void SwigDelegateRxSystemServicesImpl_18(string warnVisGroup, [MarshalAs(UnmanagedType.LPWStr)] string message);

	public delegate int SwigDelegateRxSystemServicesImpl_19(IntPtr pDict);

	public delegate int SwigDelegateRxSystemServicesImpl_20(IntPtr pDict);

	public delegate int SwigDelegateRxSystemServicesImpl_21([MarshalAs(UnmanagedType.LPWStr)] string varName, IntPtr value);

	public delegate int SwigDelegateRxSystemServicesImpl_22([MarshalAs(UnmanagedType.LPWStr)] string varName, [MarshalAs(UnmanagedType.LPWStr)] string newValue);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateRxSystemServicesImpl_23();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateRxSystemServicesImpl_24(int unFormat);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateRxSystemServicesImpl_25();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateRxSystemServicesImpl_26();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateRxSystemServicesImpl_0 swigDelegate0;

	private SwigDelegateRxSystemServicesImpl_1 swigDelegate1;

	private SwigDelegateRxSystemServicesImpl_2 swigDelegate2;

	private SwigDelegateRxSystemServicesImpl_3 swigDelegate3;

	private SwigDelegateRxSystemServicesImpl_4 swigDelegate4;

	private SwigDelegateRxSystemServicesImpl_5 swigDelegate5;

	private SwigDelegateRxSystemServicesImpl_6 swigDelegate6;

	private SwigDelegateRxSystemServicesImpl_7 swigDelegate7;

	private SwigDelegateRxSystemServicesImpl_8 swigDelegate8;

	private SwigDelegateRxSystemServicesImpl_9 swigDelegate9;

	private SwigDelegateRxSystemServicesImpl_10 swigDelegate10;

	private SwigDelegateRxSystemServicesImpl_11 swigDelegate11;

	private SwigDelegateRxSystemServicesImpl_12 swigDelegate12;

	private SwigDelegateRxSystemServicesImpl_13 swigDelegate13;

	private SwigDelegateRxSystemServicesImpl_14 swigDelegate14;

	private SwigDelegateRxSystemServicesImpl_15 swigDelegate15;

	private SwigDelegateRxSystemServicesImpl_16 swigDelegate16;

	private SwigDelegateRxSystemServicesImpl_17 swigDelegate17;

	private SwigDelegateRxSystemServicesImpl_18 swigDelegate18;

	private SwigDelegateRxSystemServicesImpl_19 swigDelegate19;

	private SwigDelegateRxSystemServicesImpl_20 swigDelegate20;

	private SwigDelegateRxSystemServicesImpl_21 swigDelegate21;

	private SwigDelegateRxSystemServicesImpl_22 swigDelegate22;

	private SwigDelegateRxSystemServicesImpl_23 swigDelegate23;

	private SwigDelegateRxSystemServicesImpl_24 swigDelegate24;

	private SwigDelegateRxSystemServicesImpl_25 swigDelegate25;

	private SwigDelegateRxSystemServicesImpl_26 swigDelegate26;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(string),
		typeof(Oda_FileAccessMode),
		typeof(Oda_FileShareMode),
		typeof(Oda_FileCreationDisposition)
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(string),
		typeof(Oda_FileAccessMode),
		typeof(Oda_FileShareMode)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(string),
		typeof(Oda_FileAccessMode)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdRxModule) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes16 = new Type[2]
	{
		typeof(string),
		typeof(OdaApp_LoadReasons)
	};

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes18 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdRxDictionary) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdRxDictionary) };

	private static Type[] swigMethodTypes21 = new Type[2]
	{
		typeof(string),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes22 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(Oda_UserNameFormat) };

	private static Type[] swigMethodTypes25 = new Type[0];

	private static Type[] swigMethodTypes26 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public RxSystemServicesImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(RxSystemServicesImpl obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_RxSystemServicesImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public RxSystemServicesImpl()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_RxSystemServicesImpl(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new virtual OdStreamBuf createFile(string filename, Oda_FileAccessMode accessMode, Oda_FileShareMode shareMode, Oda_FileCreationDisposition creationDisposition)
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(SwigDerivedClassHasMethod("createFile", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_createFileSwigExplicitRxSystemServicesImpl__SWIG_0(swigCPtr, filename, (int)accessMode, (int)shareMode, (int)creationDisposition) : TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_createFile__SWIG_0(swigCPtr, filename, (int)accessMode, (int)shareMode, (int)creationDisposition), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdStreamBuf createFile(string filename, Oda_FileAccessMode accessMode, Oda_FileShareMode shareMode)
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(SwigDerivedClassHasMethod("createFile", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_createFileSwigExplicitRxSystemServicesImpl__SWIG_1(swigCPtr, filename, (int)accessMode, (int)shareMode) : TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_createFile__SWIG_1(swigCPtr, filename, (int)accessMode, (int)shareMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdStreamBuf createFile(string filename, Oda_FileAccessMode accessMode)
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(SwigDerivedClassHasMethod("createFile", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_createFileSwigExplicitRxSystemServicesImpl__SWIG_2(swigCPtr, filename, (int)accessMode) : TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_createFile__SWIG_2(swigCPtr, filename, (int)accessMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdStreamBuf createFile(string filename)
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(SwigDerivedClassHasMethod("createFile", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_createFileSwigExplicitRxSystemServicesImpl__SWIG_3(swigCPtr, filename) : TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_createFile__SWIG_3(swigCPtr, filename), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual bool accessFile(string filename, int accessMode)
	{
		bool result = (SwigDerivedClassHasMethod("accessFile", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_accessFileSwigExplicitRxSystemServicesImpl(swigCPtr, filename, accessMode) : TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_accessFile(swigCPtr, filename, accessMode));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual long getFileCTime(string filename)
	{
		long result = (SwigDerivedClassHasMethod("getFileCTime", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_getFileCTimeSwigExplicitRxSystemServicesImpl(swigCPtr, filename) : TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_getFileCTime(swigCPtr, filename));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual long getFileMTime(string filename)
	{
		long result = (SwigDerivedClassHasMethod("getFileMTime", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_getFileMTimeSwigExplicitRxSystemServicesImpl(swigCPtr, filename) : TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_getFileMTime(swigCPtr, filename));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual long getFileSize(string filename)
	{
		long result = (SwigDerivedClassHasMethod("getFileSize", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_getFileSizeSwigExplicitRxSystemServicesImpl(swigCPtr, filename) : TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_getFileSize(swigCPtr, filename));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSystemCodePage(OdCodePageId id)
	{
		TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_setSystemCodePage(swigCPtr, (int)id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdResult getEnvVar(string varName, ref string value)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(value);
		IntPtr intPtr = jarg;
		try
		{
			int result = (SwigDerivedClassHasMethod("getEnvVar", swigMethodTypes21) ? TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_getEnvVarSwigExplicitRxSystemServicesImpl(swigCPtr, varName, ref jarg) : TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_getEnvVar(swigCPtr, varName, ref jarg));
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

	public new virtual OdResult setEnvVar(string varName, string newValue)
	{
		int result = (SwigDerivedClassHasMethod("setEnvVar", swigMethodTypes22) ? TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_setEnvVarSwigExplicitRxSystemServicesImpl(swigCPtr, varName, newValue) : TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_setEnvVar(swigCPtr, varName, newValue));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("createFile", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcreateFile__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createFile", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcreateFile__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createFile", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcreateFile__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("createFile", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcreateFile__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("accessFile", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodaccessFile;
		}
		if (SwigDerivedClassHasMethod("getFileCTime", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetFileCTime;
		}
		if (SwigDerivedClassHasMethod("getFileMTime", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetFileMTime;
		}
		if (SwigDerivedClassHasMethod("getFileSize", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetFileSize;
		}
		if (SwigDerivedClassHasMethod("createGuid", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcreateGuid;
		}
		if (SwigDerivedClassHasMethod("createOdGUID", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodcreateOdGUID;
		}
		if (SwigDerivedClassHasMethod("loadModule", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodloadModule;
		}
		if (SwigDerivedClassHasMethod("unloadModule", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodunloadModule;
		}
		if (SwigDerivedClassHasMethod("findModule", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodfindModule__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("findModule", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodfindModule__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodwarning__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("warning", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodwarning__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("initModelerLibrary", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodinitModelerLibrary;
		}
		if (SwigDerivedClassHasMethod("uninitModelerLibrary", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethoduninitModelerLibrary;
		}
		if (SwigDerivedClassHasMethod("getEnvVar", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodgetEnvVar;
		}
		if (SwigDerivedClassHasMethod("setEnvVar", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodsetEnvVar;
		}
		if (SwigDerivedClassHasMethod("getTemporaryPath", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodgetTemporaryPath;
		}
		if (SwigDerivedClassHasMethod("getUserName", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodgetUserName__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getUserName", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodgetUserName__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getTempFileName", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodgetTempFileName;
		}
		TD_RootIntegrated_GlobalsPINVOKE.RxSystemServicesImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(RxSystemServicesImpl));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodcreateFile__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string filename, int accessMode, int shareMode, int creationDisposition)
	{
		return OdStreamBuf.getCPtr(createFile(filename, (Oda_FileAccessMode)accessMode, (Oda_FileShareMode)shareMode, (Oda_FileCreationDisposition)creationDisposition)).Handle;
	}

	private IntPtr SwigDirectorMethodcreateFile__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string filename, int accessMode, int shareMode)
	{
		return OdStreamBuf.getCPtr(createFile(filename, (Oda_FileAccessMode)accessMode, (Oda_FileShareMode)shareMode)).Handle;
	}

	private IntPtr SwigDirectorMethodcreateFile__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string filename, int accessMode)
	{
		return OdStreamBuf.getCPtr(createFile(filename, (Oda_FileAccessMode)accessMode)).Handle;
	}

	private IntPtr SwigDirectorMethodcreateFile__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		return OdStreamBuf.getCPtr(createFile(filename)).Handle;
	}

	private bool SwigDirectorMethodaccessFile([MarshalAs(UnmanagedType.LPWStr)] string filename, int accessMode)
	{
		return accessFile(filename, accessMode);
	}

	private long SwigDirectorMethodgetFileCTime([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		return getFileCTime(filename);
	}

	private long SwigDirectorMethodgetFileMTime([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		return getFileMTime(filename);
	}

	private long SwigDirectorMethodgetFileSize([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		return getFileSize(filename);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodcreateGuid()
	{
		return createGuid();
	}

	private IntPtr SwigDirectorMethodcreateOdGUID()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGUID.getCPtr(createOdGUID()).Handle;
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

	private IntPtr SwigDirectorMethodloadModule([MarshalAs(UnmanagedType.LPWStr)] string moduleFileName, bool silent)
	{
		return OdRxModule.getCPtr(loadModule(moduleFileName, silent)).Handle;
	}

	private void SwigDirectorMethodunloadModule(IntPtr pModuleObj)
	{
		try
		{
			unloadModule(Helpers.GetRXObject<OdRxModule>(pModuleObj, bOwn: false, bTryAddToTransaction: false));
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
	private string SwigDirectorMethodfindModule__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string applicationName)
	{
		return findModule(applicationName);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfindModule__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string applicationName, int loadReason)
	{
		return findModule(applicationName, (OdaApp_LoadReasons)loadReason);
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

	private int SwigDirectorMethodinitModelerLibrary(IntPtr pDict)
	{
		return (int)initModelerLibrary(Helpers.GetRXObject<OdRxDictionary>(pDict, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethoduninitModelerLibrary(IntPtr pDict)
	{
		return (int)uninitModelerLibrary(Helpers.GetRXObject<OdRxDictionary>(pDict, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodgetEnvVar([MarshalAs(UnmanagedType.LPWStr)] string varName, IntPtr value)
	{
		OdSwigDirectorHelper.director_UnpackData(value, out var pOriginalObject, out var pFunction);
		string value2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = value2;
		try
		{
			return (int)getEnvVar(varName, ref value2);
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

	private int SwigDirectorMethodsetEnvVar([MarshalAs(UnmanagedType.LPWStr)] string varName, [MarshalAs(UnmanagedType.LPWStr)] string newValue)
	{
		return (int)setEnvVar(varName, newValue);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetTemporaryPath()
	{
		return getTemporaryPath();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetUserName__SWIG_0(int unFormat)
	{
		return getUserName((Oda_UserNameFormat)unFormat);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetUserName__SWIG_1()
	{
		return getUserName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetTempFileName()
	{
		return getTempFileName();
	}
}

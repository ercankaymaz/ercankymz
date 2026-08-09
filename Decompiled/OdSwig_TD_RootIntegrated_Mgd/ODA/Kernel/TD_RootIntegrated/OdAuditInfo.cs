using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdAuditInfo : IDisposable
{
	public class MsgInfo : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public string strName
		{
			get
			{
				string result = TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_MsgInfo_strName_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_MsgInfo_strName_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public string strValue
		{
			get
			{
				string result = TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_MsgInfo_strValue_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_MsgInfo_strValue_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public string strValidation
		{
			get
			{
				string result = TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_MsgInfo_strValidation_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_MsgInfo_strValidation_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public string strDefaultValue
		{
			get
			{
				string result = TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_MsgInfo_strDefaultValue_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_MsgInfo_strDefaultValue_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public bool bIsError
		{
			get
			{
				bool result = TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_MsgInfo_bIsError_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_MsgInfo_bIsError_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MsgInfo(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(MsgInfo obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~MsgInfo()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdAuditInfo_MsgInfo(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public MsgInfo()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdAuditInfo_MsgInfo(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate void SwigDelegateOdAuditInfo_0([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation, [MarshalAs(UnmanagedType.LPWStr)] string defaultValue);

	public delegate void SwigDelegateOdAuditInfo_1([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation);

	public delegate void SwigDelegateOdAuditInfo_2([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate void SwigDelegateOdAuditInfo_3(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation, [MarshalAs(UnmanagedType.LPWStr)] string defaultValue);

	public delegate void SwigDelegateOdAuditInfo_4(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation);

	public delegate void SwigDelegateOdAuditInfo_5(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string value);

	public delegate void SwigDelegateOdAuditInfo_6([MarshalAs(UnmanagedType.LPWStr)] string logInfo);

	public delegate IntPtr SwigDelegateOdAuditInfo_7();

	public delegate void SwigDelegateOdAuditInfo_8(IntPtr lastInfo);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdAuditInfo_0 swigDelegate0;

	private SwigDelegateOdAuditInfo_1 swigDelegate1;

	private SwigDelegateOdAuditInfo_2 swigDelegate2;

	private SwigDelegateOdAuditInfo_3 swigDelegate3;

	private SwigDelegateOdAuditInfo_4 swigDelegate4;

	private SwigDelegateOdAuditInfo_5 swigDelegate5;

	private SwigDelegateOdAuditInfo_6 swigDelegate6;

	private SwigDelegateOdAuditInfo_7 swigDelegate7;

	private SwigDelegateOdAuditInfo_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[4]
	{
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes1 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes2 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(OdRxObject),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(MsgInfo) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdAuditInfo(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdAuditInfo obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdAuditInfo()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdAuditInfo(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdAuditInfo()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdAuditInfo(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdAuditInfo) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public bool fixErrors()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_fixErrors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFixErrors(bool fixErrors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_setFixErrors(swigCPtr, fixErrors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numErrors()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_numErrors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numFixes()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_numFixes(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void errorsFound(int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_errorsFound(swigCPtr, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void errorsFixed(int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_errorsFixed(swigCPtr, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void errorsSkip(int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_errorsSkip(swigCPtr, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void printError(string name, string value, string validation, string defaultValue)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes0))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printErrorSwigExplicitOdAuditInfo__SWIG_0(swigCPtr, name, value, validation, defaultValue);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printError__SWIG_0(swigCPtr, name, value, validation, defaultValue);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void printError(string name, string value, string validation)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes1))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printErrorSwigExplicitOdAuditInfo__SWIG_1(swigCPtr, name, value, validation);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printError__SWIG_1(swigCPtr, name, value, validation);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void printError(string name, string value)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printErrorSwigExplicitOdAuditInfo__SWIG_2(swigCPtr, name, value);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printError__SWIG_2(swigCPtr, name, value);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void printError(OdRxObject pObject, string value, string validation, string defaultValue)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printErrorSwigExplicitOdAuditInfo__SWIG_3(swigCPtr, OdRxObject.getCPtr(pObject), value, validation, defaultValue);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printError__SWIG_3(swigCPtr, OdRxObject.getCPtr(pObject), value, validation, defaultValue);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void printError(OdRxObject pObject, string value, string validation)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printErrorSwigExplicitOdAuditInfo__SWIG_4(swigCPtr, OdRxObject.getCPtr(pObject), value, validation);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printError__SWIG_4(swigCPtr, OdRxObject.getCPtr(pObject), value, validation);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void printError(OdRxObject pObject, string value)
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printErrorSwigExplicitOdAuditInfo__SWIG_5(swigCPtr, OdRxObject.getCPtr(pObject), value);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printError__SWIG_5(swigCPtr, OdRxObject.getCPtr(pObject), value);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void printInfo(string logInfo)
	{
		if (SwigDerivedClassHasMethod("printInfo", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printInfoSwigExplicitOdAuditInfo(swigCPtr, logInfo);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_printInfo(swigCPtr, logInfo);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void requestRegen()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_requestRegen(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetNumEntities()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_resetNumEntities(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void incNumEntities()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_incNumEntities(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numEntities()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_numEntities(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual MsgInfo getLastInfo()
	{
		MsgInfo result = new MsgInfo(SwigDerivedClassHasMethod("getLastInfo", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_getLastInfoSwigExplicitOdAuditInfo(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_getLastInfo(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLastInfo(MsgInfo lastInfo)
	{
		if (SwigDerivedClassHasMethod("setLastInfo", swigMethodTypes8))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_setLastInfoSwigExplicitOdAuditInfo(swigCPtr, MsgInfo.getCPtr(lastInfo));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_setLastInfo(swigCPtr, MsgInfo.getCPtr(lastInfo));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPrintDest(OdAuditInfo_PrintDest printDest)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_setPrintDest(swigCPtr, (int)printDest);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdAuditInfo_PrintDest getPrintDest()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_getPrintDest(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdAuditInfo_PrintDest)result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodprintError__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodprintError__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodprintError__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodprintError__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodprintError__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("printError", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodprintError__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("printInfo", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodprintInfo;
		}
		if (SwigDerivedClassHasMethod("getLastInfo", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetLastInfo;
		}
		if (SwigDerivedClassHasMethod("setLastInfo", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetLastInfo;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdAuditInfo_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdAuditInfo));
	}

	private void SwigDirectorMethodprintError__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation, [MarshalAs(UnmanagedType.LPWStr)] string defaultValue)
	{
		try
		{
			printError(name, value, validation, defaultValue);
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

	private void SwigDirectorMethodprintError__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation)
	{
		try
		{
			printError(name, value, validation);
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

	private void SwigDirectorMethodprintError__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string value)
	{
		try
		{
			printError(name, value);
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

	private void SwigDirectorMethodprintError__SWIG_3(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation, [MarshalAs(UnmanagedType.LPWStr)] string defaultValue)
	{
		try
		{
			printError(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), value, validation, defaultValue);
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

	private void SwigDirectorMethodprintError__SWIG_4(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPWStr)] string validation)
	{
		try
		{
			printError(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), value, validation);
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

	private void SwigDirectorMethodprintError__SWIG_5(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string value)
	{
		try
		{
			printError(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), value);
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

	private void SwigDirectorMethodprintInfo([MarshalAs(UnmanagedType.LPWStr)] string logInfo)
	{
		try
		{
			printInfo(logInfo);
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

	private IntPtr SwigDirectorMethodgetLastInfo()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return MsgInfo.getCPtr(getLastInfo()).Handle;
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

	private void SwigDirectorMethodsetLastInfo(IntPtr lastInfo)
	{
		try
		{
			setLastInfo(new MsgInfo(lastInfo, cMemoryOwn: false));
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

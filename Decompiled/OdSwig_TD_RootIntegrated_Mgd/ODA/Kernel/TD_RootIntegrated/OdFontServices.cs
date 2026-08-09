using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdFontServices : OdRxObject
{
	public delegate IntPtr SwigDelegateOdFontServices_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdFontServices_1();

	public delegate void SwigDelegateOdFontServices_2(IntPtr pSource);

	public delegate void SwigDelegateOdFontServices_3(IntPtr textStyle, IntPtr pDb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdFontServices_4(IntPtr textStyle, IntPtr pDb);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdFontServices_5(IntPtr textStyle, IntPtr pDb);

	public delegate IntPtr SwigDelegateOdFontServices_6();

	public delegate bool SwigDelegateOdFontServices_7([MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr descr);

	public delegate bool SwigDelegateOdFontServices_8(IntPtr descr, IntPtr fileName, IntPtr pHost);

	public delegate bool SwigDelegateOdFontServices_9(IntPtr aDirs, IntPtr pHost);

	public delegate void SwigDelegateOdFontServices_10(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath, [MarshalAs(UnmanagedType.LPWStr)] string sFilter);

	public delegate void SwigDelegateOdFontServices_11(IntPtr res, [MarshalAs(UnmanagedType.LPWStr)] string sPath);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdFontServices_12([MarshalAs(UnmanagedType.LPWStr)] string arg0, IntPtr arg1);

	public delegate bool SwigDelegateOdFontServices_13([MarshalAs(UnmanagedType.LPWStr)] string arg0);

	public delegate bool SwigDelegateOdFontServices_14(bool arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdFontServices_0 swigDelegate0;

	private SwigDelegateOdFontServices_1 swigDelegate1;

	private SwigDelegateOdFontServices_2 swigDelegate2;

	private SwigDelegateOdFontServices_3 swigDelegate3;

	private SwigDelegateOdFontServices_4 swigDelegate4;

	private SwigDelegateOdFontServices_5 swigDelegate5;

	private SwigDelegateOdFontServices_6 swigDelegate6;

	private SwigDelegateOdFontServices_7 swigDelegate7;

	private SwigDelegateOdFontServices_8 swigDelegate8;

	private SwigDelegateOdFontServices_9 swigDelegate9;

	private SwigDelegateOdFontServices_10 swigDelegate10;

	private SwigDelegateOdFontServices_11 swigDelegate11;

	private SwigDelegateOdFontServices_12 swigDelegate12;

	private SwigDelegateOdFontServices_13 swigDelegate13;

	private SwigDelegateOdFontServices_14 swigDelegate14;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdGiTextStyle),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGiTextStyle),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdGiTextStyle),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(string),
		typeof(OdTtfDescriptor)
	};

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(OdTtfDescriptor),
		typeof(string).MakeByRefType(),
		typeof(OdDbBaseHostAppServices)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdStringArray),
		typeof(OdDbBaseHostAppServices)
	};

	private static Type[] swigMethodTypes10 = new Type[3]
	{
		typeof(OdStringArray),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(OdStringArray),
		typeof(string)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(string),
		typeof(OdDbBaseHostAppServices)
	};

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(bool) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdFontServices(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdFontServices obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdFontServices(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdFontServices cast(OdRxObject pObj)
	{
		OdFontServices rXObject = Helpers.GetRXObject<OdFontServices>(TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_isASwigExplicitOdFontServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_queryXSwigExplicitOdFontServices(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdFontServices createObject()
	{
		OdFontServices rXObject = Helpers.GetRXObject<OdFontServices>(TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void loadStyleRec(OdGiTextStyle textStyle, OdRxObject pDb)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_loadStyleRec(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getFontFilePath(OdGiTextStyle textStyle, OdRxObject pDb)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_getFontFilePath(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getBigFontFilePath(OdGiTextStyle textStyle, OdRxObject pDb)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_getBigFontFilePath(swigCPtr, OdGiTextStyle.getCPtr(textStyle).Handle, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdFont defaultFont()
	{
		OdFont rXObject = Helpers.GetRXObject<OdFont>(TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_defaultFont(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool getTTFParamFromFile(string fileName, OdTtfDescriptor descr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_getTTFParamFromFile(swigCPtr, fileName, OdTtfDescriptor.getCPtr(descr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool ttfFileNameByDescriptor(OdTtfDescriptor descr, ref string fileName, OdDbBaseHostAppServices pHost)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(fileName);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_ttfFileNameByDescriptor(swigCPtr, OdTtfDescriptor.getCPtr(descr), ref jarg, OdDbBaseHostAppServices.getCPtr(pHost));
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
				fileName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getSystemFontFolders(OdStringArray aDirs, OdDbBaseHostAppServices pHost)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_getSystemFontFolders(swigCPtr, OdStringArray.getCPtr(aDirs), OdDbBaseHostAppServices.getCPtr(pHost));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void collectFilePathsInDirectory(OdStringArray res, string sPath, string sFilter)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_collectFilePathsInDirectory__SWIG_0(swigCPtr, OdStringArray.getCPtr(res), sPath, sFilter);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void collectFilePathsInDirectory(OdStringArray res, string sPath)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_collectFilePathsInDirectory__SWIG_1(swigCPtr, OdStringArray.getCPtr(res), sPath);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string iFindFile(string arg0, OdDbBaseHostAppServices arg1)
	{
		string result = (SwigDerivedClassHasMethod("iFindFile", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_iFindFileSwigExplicitOdFontServices(swigCPtr, arg0, OdDbBaseHostAppServices.getCPtr(arg1)) : TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_iFindFile(swigCPtr, arg0, OdDbBaseHostAppServices.getCPtr(arg1)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool addFontResource(string arg0)
	{
		bool result = (SwigDerivedClassHasMethod("addFontResource", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_addFontResourceSwigExplicitOdFontServices(swigCPtr, arg0) : TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_addFontResource(swigCPtr, arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setUseNotInstalledWindowsFont(bool arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_setUseNotInstalledWindowsFont(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdFontServices()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdFontServices(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdFontServices) != GetType();
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
		if (SwigDerivedClassHasMethod("loadStyleRec", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodloadStyleRec;
		}
		if (SwigDerivedClassHasMethod("getFontFilePath", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetFontFilePath;
		}
		if (SwigDerivedClassHasMethod("getBigFontFilePath", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetBigFontFilePath;
		}
		if (SwigDerivedClassHasMethod("defaultFont", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoddefaultFont;
		}
		if (SwigDerivedClassHasMethod("getTTFParamFromFile", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetTTFParamFromFile;
		}
		if (SwigDerivedClassHasMethod("ttfFileNameByDescriptor", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodttfFileNameByDescriptor;
		}
		if (SwigDerivedClassHasMethod("getSystemFontFolders", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetSystemFontFolders;
		}
		if (SwigDerivedClassHasMethod("collectFilePathsInDirectory", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcollectFilePathsInDirectory__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("collectFilePathsInDirectory", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcollectFilePathsInDirectory__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("iFindFile", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodiFindFile;
		}
		if (SwigDerivedClassHasMethod("addFontResource", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodaddFontResource;
		}
		if (SwigDerivedClassHasMethod("setUseNotInstalledWindowsFont", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetUseNotInstalledWindowsFont;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdFontServices_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdFontServices));
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

	private void SwigDirectorMethodloadStyleRec(IntPtr textStyle, IntPtr pDb)
	{
		try
		{
			loadStyleRec(new OdGiTextStyle(textStyle, cMemoryOwn: true), Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
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
	private string SwigDirectorMethodgetFontFilePath(IntPtr textStyle, IntPtr pDb)
	{
		return getFontFilePath(new OdGiTextStyle(textStyle, cMemoryOwn: true), Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetBigFontFilePath(IntPtr textStyle, IntPtr pDb)
	{
		return getBigFontFilePath(new OdGiTextStyle(textStyle, cMemoryOwn: true), Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethoddefaultFont()
	{
		return OdFont.getCPtr(defaultFont()).Handle;
	}

	private bool SwigDirectorMethodgetTTFParamFromFile([MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr descr)
	{
		return getTTFParamFromFile(fileName, new OdTtfDescriptor(descr, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodttfFileNameByDescriptor(IntPtr descr, IntPtr fileName, IntPtr pHost)
	{
		OdSwigDirectorHelper.director_UnpackData(fileName, out var pOriginalObject, out var pFunction);
		string fileName2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = fileName2;
		try
		{
			return ttfFileNameByDescriptor(new OdTtfDescriptor(descr, cMemoryOwn: false), ref fileName2, Helpers.GetRXObject<OdDbBaseHostAppServices>(pHost, bOwn: false, bTryAddToTransaction: false));
		}
		finally
		{
			if (fileName2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(fileName2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(fileName);
		}
	}

	private bool SwigDirectorMethodgetSystemFontFolders(IntPtr aDirs, IntPtr pHost)
	{
		return getSystemFontFolders(new OdStringArray(aDirs, cMemoryOwn: false), Helpers.GetRXObject<OdDbBaseHostAppServices>(pHost, bOwn: false, bTryAddToTransaction: false));
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
	private string SwigDirectorMethodiFindFile([MarshalAs(UnmanagedType.LPWStr)] string arg0, IntPtr arg1)
	{
		return iFindFile(arg0, Helpers.GetRXObject<OdDbBaseHostAppServices>(arg1, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodaddFontResource([MarshalAs(UnmanagedType.LPWStr)] string arg0)
	{
		return addFontResource(arg0);
	}

	private bool SwigDirectorMethodsetUseNotInstalledWindowsFont(bool arg0)
	{
		return setUseNotInstalledWindowsFont(arg0);
	}
}

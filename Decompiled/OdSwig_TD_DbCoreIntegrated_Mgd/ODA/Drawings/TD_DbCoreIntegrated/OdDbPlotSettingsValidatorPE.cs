using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbPlotSettingsValidatorPE : OdRxObject
{
	public class psvPaperInfo : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public string canonicalName
		{
			get
			{
				string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_canonicalName_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_canonicalName_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public string localeName
		{
			get
			{
				string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_localeName_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_localeName_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double w
		{
			get
			{
				double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_w_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_w_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double h
		{
			get
			{
				double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_h_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_h_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double left
		{
			get
			{
				double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_left_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_left_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double top
		{
			get
			{
				double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_top_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_top_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double right
		{
			get
			{
				double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_right_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_right_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double bottom
		{
			get
			{
				double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_bottom_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_bottom_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdDbPlotSettings_PlotPaperUnits units
		{
			get
			{
				int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_units_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return (OdDbPlotSettings_PlotPaperUnits)result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_units_set(swigCPtr, (int)value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public psvPaperInfo(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(psvPaperInfo obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~psvPaperInfo()
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
						TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbPlotSettingsValidatorPE_psvPaperInfo(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public psvPaperInfo()
			: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbPlotSettingsValidatorPE_psvPaperInfo(), cMemoryOwn: true)
		{
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool IsEqual(psvPaperInfo p)
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_psvPaperInfo_IsEqual(swigCPtr, getCPtr(p));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public delegate IntPtr SwigDelegateOdDbPlotSettingsValidatorPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbPlotSettingsValidatorPE_1();

	public delegate void SwigDelegateOdDbPlotSettingsValidatorPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbPlotSettingsValidatorPE_3(IntPtr pDeviceList);

	public delegate int SwigDelegateOdDbPlotSettingsValidatorPE_4([MarshalAs(UnmanagedType.LPWStr)] string deviceName, IntPtr pMediaList, bool bUpdateMediaMargins);

	public delegate int SwigDelegateOdDbPlotSettingsValidatorPE_5([MarshalAs(UnmanagedType.LPWStr)] string deviceName, IntPtr defaultMedia);

	public delegate int SwigDelegateOdDbPlotSettingsValidatorPE_6([MarshalAs(UnmanagedType.LPWStr)] string deviceName, IntPtr pMediaInfo);

	public delegate int SwigDelegateOdDbPlotSettingsValidatorPE_7(IntPtr pPlotStyleSheetList, IntPtr pHostApp);

	public delegate int SwigDelegateOdDbPlotSettingsValidatorPE_8(IntPtr pPlotStyleSheetList, IntPtr pDb);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbPlotSettingsValidatorPE_0 swigDelegate0;

	private SwigDelegateOdDbPlotSettingsValidatorPE_1 swigDelegate1;

	private SwigDelegateOdDbPlotSettingsValidatorPE_2 swigDelegate2;

	private SwigDelegateOdDbPlotSettingsValidatorPE_3 swigDelegate3;

	private SwigDelegateOdDbPlotSettingsValidatorPE_4 swigDelegate4;

	private SwigDelegateOdDbPlotSettingsValidatorPE_5 swigDelegate5;

	private SwigDelegateOdDbPlotSettingsValidatorPE_6 swigDelegate6;

	private SwigDelegateOdDbPlotSettingsValidatorPE_7 swigDelegate7;

	private SwigDelegateOdDbPlotSettingsValidatorPE_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdStringArray) };

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(string),
		typeof(OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator),
		typeof(bool)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(string),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(string),
		typeof(psvPaperInfo)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdStringArray),
		typeof(OdDbBaseHostAppServices)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdStringArray),
		typeof(OdRxObject)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbPlotSettingsValidatorPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbPlotSettingsValidatorPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbPlotSettingsValidatorPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbPlotSettingsValidatorPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbPlotSettingsValidatorPE(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbPlotSettingsValidatorPE cast(OdRxObject pObj)
	{
		OdDbPlotSettingsValidatorPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettingsValidatorPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_isASwigExplicitOdDbPlotSettingsValidatorPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_queryXSwigExplicitOdDbPlotSettingsValidatorPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbPlotSettingsValidatorPE createObject()
	{
		OdDbPlotSettingsValidatorPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettingsValidatorPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getDeviceList(OdStringArray pDeviceList)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_getDeviceList(swigCPtr, OdStringArray.getCPtr(pDeviceList).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getMediaList(string deviceName, OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator pMediaList, bool bUpdateMediaMargins)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_getMediaList(swigCPtr, deviceName, OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator.getCPtr(pMediaList), bUpdateMediaMargins);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getDefaultMedia(string deviceName, ref string defaultMedia)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(defaultMedia);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_getDefaultMedia(swigCPtr, deviceName, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				defaultMedia = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult getMediaMargins(string deviceName, psvPaperInfo pMediaInfo)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_getMediaMargins(swigCPtr, deviceName, psvPaperInfo.getCPtr(pMediaInfo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getPlotStyleSheetList(OdStringArray pPlotStyleSheetList, OdDbBaseHostAppServices pHostApp)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_getPlotStyleSheetList__SWIG_0(swigCPtr, OdStringArray.getCPtr(pPlotStyleSheetList).Handle, OdDbBaseHostAppServices.getCPtr(pHostApp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getPlotStyleSheetList(OdStringArray pPlotStyleSheetList, OdRxObject pDb)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_getPlotStyleSheetList__SWIG_1(swigCPtr, OdStringArray.getCPtr(pPlotStyleSheetList).Handle, OdRxObject.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getDeviceList", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetDeviceList;
		}
		if (SwigDerivedClassHasMethod("getMediaList", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetMediaList;
		}
		if (SwigDerivedClassHasMethod("getDefaultMedia", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetDefaultMedia;
		}
		if (SwigDerivedClassHasMethod("getMediaMargins", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetMediaMargins;
		}
		if (SwigDerivedClassHasMethod("getPlotStyleSheetList", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetPlotStyleSheetList__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getPlotStyleSheetList", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetPlotStyleSheetList__SWIG_1;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidatorPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbPlotSettingsValidatorPE));
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

	private int SwigDirectorMethodgetDeviceList(IntPtr pDeviceList)
	{
		return (int)getDeviceList(new OdStringArray(pDeviceList, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetMediaList([MarshalAs(UnmanagedType.LPWStr)] string deviceName, IntPtr pMediaList, bool bUpdateMediaMargins)
	{
		return (int)getMediaList(deviceName, new OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator(pMediaList, cMemoryOwn: false), bUpdateMediaMargins);
	}

	private int SwigDirectorMethodgetDefaultMedia([MarshalAs(UnmanagedType.LPWStr)] string deviceName, IntPtr defaultMedia)
	{
		OdSwigDirectorHelper.director_UnpackData(defaultMedia, out var pOriginalObject, out var pFunction);
		string defaultMedia2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = defaultMedia2;
		try
		{
			return (int)getDefaultMedia(deviceName, ref defaultMedia2);
		}
		finally
		{
			if (defaultMedia2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(defaultMedia2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(defaultMedia);
		}
	}

	private int SwigDirectorMethodgetMediaMargins([MarshalAs(UnmanagedType.LPWStr)] string deviceName, IntPtr pMediaInfo)
	{
		return (int)getMediaMargins(deviceName, new psvPaperInfo(pMediaInfo, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetPlotStyleSheetList__SWIG_0(IntPtr pPlotStyleSheetList, IntPtr pHostApp)
	{
		return (int)getPlotStyleSheetList(new OdStringArray(pPlotStyleSheetList, cMemoryOwn: true), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBaseHostAppServices>(pHostApp, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodgetPlotStyleSheetList__SWIG_1(IntPtr pPlotStyleSheetList, IntPtr pDb)
	{
		return (int)getPlotStyleSheetList(new OdStringArray(pPlotStyleSheetList, cMemoryOwn: true), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
	}
}

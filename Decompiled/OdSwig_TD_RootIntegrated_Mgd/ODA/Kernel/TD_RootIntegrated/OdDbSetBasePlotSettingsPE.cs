using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbSetBasePlotSettingsPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbSetBasePlotSettingsPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbSetBasePlotSettingsPE_1();

	public delegate void SwigDelegateOdDbSetBasePlotSettingsPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_3(IntPtr pPlotSetObj, [MarshalAs(UnmanagedType.LPWStr)] string plotCfgName);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_4(IntPtr pPlotSetObj, short flags);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_5(IntPtr pPlotSetObj, double left, double Bottom, double right, double top);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_6(IntPtr pPlotSetObj, double paperWidth, double paperHeight);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_7(IntPtr pPlotSetObj, [MarshalAs(UnmanagedType.LPWStr)] string mediaName);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_8(IntPtr pPlotSetObj, IntPtr origin);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_9(IntPtr pPlotSetObj, int units);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_10(IntPtr pPlotSetObj, int plotRotation);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_11(IntPtr pPlotSetObj, int plotType);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_12(IntPtr pPlotSetObj, double xmin, double ymin, double xmax, double ymax);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_13(IntPtr pPlotSetObj, IntPtr plotViewId);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_14(IntPtr pPlotSetObj, double numerator, double denominator);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_15(IntPtr pPlotSetObj, [MarshalAs(UnmanagedType.LPWStr)] string styleSheet);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_16(IntPtr pPlotSetObj, int scaleType);

	public delegate int SwigDelegateOdDbSetBasePlotSettingsPE_17(IntPtr pPlotSetObj, double dScaleFactor);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbSetBasePlotSettingsPE_0 swigDelegate0;

	private SwigDelegateOdDbSetBasePlotSettingsPE_1 swigDelegate1;

	private SwigDelegateOdDbSetBasePlotSettingsPE_2 swigDelegate2;

	private SwigDelegateOdDbSetBasePlotSettingsPE_3 swigDelegate3;

	private SwigDelegateOdDbSetBasePlotSettingsPE_4 swigDelegate4;

	private SwigDelegateOdDbSetBasePlotSettingsPE_5 swigDelegate5;

	private SwigDelegateOdDbSetBasePlotSettingsPE_6 swigDelegate6;

	private SwigDelegateOdDbSetBasePlotSettingsPE_7 swigDelegate7;

	private SwigDelegateOdDbSetBasePlotSettingsPE_8 swigDelegate8;

	private SwigDelegateOdDbSetBasePlotSettingsPE_9 swigDelegate9;

	private SwigDelegateOdDbSetBasePlotSettingsPE_10 swigDelegate10;

	private SwigDelegateOdDbSetBasePlotSettingsPE_11 swigDelegate11;

	private SwigDelegateOdDbSetBasePlotSettingsPE_12 swigDelegate12;

	private SwigDelegateOdDbSetBasePlotSettingsPE_13 swigDelegate13;

	private SwigDelegateOdDbSetBasePlotSettingsPE_14 swigDelegate14;

	private SwigDelegateOdDbSetBasePlotSettingsPE_15 swigDelegate15;

	private SwigDelegateOdDbSetBasePlotSettingsPE_16 swigDelegate16;

	private SwigDelegateOdDbSetBasePlotSettingsPE_17 swigDelegate17;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(short)
	};

	private static Type[] swigMethodTypes5 = new Type[5]
	{
		typeof(OdRxObject),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbBaseLayoutPE_PlotPaperUnits)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbBaseLayoutPE_PlotRotation)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbBaseLayoutPE_PlotType)
	};

	private static Type[] swigMethodTypes12 = new Type[5]
	{
		typeof(OdRxObject),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes14 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes16 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbBaseLayoutPE_StdScaleType)
	};

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(double)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSetBasePlotSettingsPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSetBasePlotSettingsPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbSetBasePlotSettingsPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbSetBasePlotSettingsPE cast(OdRxObject pObj)
	{
		OdDbSetBasePlotSettingsPE rXObject = Helpers.GetRXObject<OdDbSetBasePlotSettingsPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_isASwigExplicitOdDbSetBasePlotSettingsPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_queryXSwigExplicitOdDbSetBasePlotSettingsPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbSetBasePlotSettingsPE createObject()
	{
		OdDbSetBasePlotSettingsPE rXObject = Helpers.GetRXObject<OdDbSetBasePlotSettingsPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult setPlotCfgName(OdRxObject pPlotSetObj, string plotCfgName)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setPlotCfgName(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), plotCfgName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotLayoutFlags(OdRxObject pPlotSetObj, short flags)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setPlotLayoutFlags(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setMargins(OdRxObject pPlotSetObj, double left, double Bottom, double right, double top)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setMargins(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), left, Bottom, right, top);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotPaperSize(OdRxObject pPlotSetObj, double paperWidth, double paperHeight)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setPlotPaperSize(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), paperWidth, paperHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setMediaName(OdRxObject pPlotSetObj, string mediaName)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setMediaName(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), mediaName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setOrigin(OdRxObject pPlotSetObj, OdGePoint2d origin)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setOrigin(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), OdGePoint2d.getCPtr(origin));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotPaperUnits(OdRxObject pPlotSetObj, OdDbBaseLayoutPE_PlotPaperUnits units)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setPlotPaperUnits(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), (int)units);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotRotation(OdRxObject pPlotSetObj, OdDbBaseLayoutPE_PlotRotation plotRotation)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setPlotRotation(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), (int)plotRotation);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotType(OdRxObject pPlotSetObj, OdDbBaseLayoutPE_PlotType plotType)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setPlotType(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), (int)plotType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotWindowArea(OdRxObject pPlotSetObj, double xmin, double ymin, double xmax, double ymax)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setPlotWindowArea(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), xmin, ymin, xmax, ymax);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotView(OdRxObject pPlotSetObj, OdDbStub plotViewId)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setPlotView(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), OdDbStub.getCPtr(plotViewId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPrintScale(OdRxObject pPlotSetObj, double numerator, double denominator)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setPrintScale(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), numerator, denominator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setStyleSheet(OdRxObject pPlotSetObj, string styleSheet)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setStyleSheet(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), styleSheet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setStdScaleType(OdRxObject pPlotSetObj, OdDbBaseLayoutPE_StdScaleType scaleType)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setStdScaleType(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), (int)scaleType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setScaleFactor(OdRxObject pPlotSetObj, double dScaleFactor)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_setScaleFactor(swigCPtr, OdRxObject.getCPtr(pPlotSetObj), dScaleFactor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbSetBasePlotSettingsPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbSetBasePlotSettingsPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbSetBasePlotSettingsPE) != GetType();
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
		if (SwigDerivedClassHasMethod("setPlotCfgName", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetPlotCfgName;
		}
		if (SwigDerivedClassHasMethod("setPlotLayoutFlags", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetPlotLayoutFlags;
		}
		if (SwigDerivedClassHasMethod("setMargins", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetMargins;
		}
		if (SwigDerivedClassHasMethod("setPlotPaperSize", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetPlotPaperSize;
		}
		if (SwigDerivedClassHasMethod("setMediaName", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetMediaName;
		}
		if (SwigDerivedClassHasMethod("setOrigin", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetOrigin;
		}
		if (SwigDerivedClassHasMethod("setPlotPaperUnits", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetPlotPaperUnits;
		}
		if (SwigDerivedClassHasMethod("setPlotRotation", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetPlotRotation;
		}
		if (SwigDerivedClassHasMethod("setPlotType", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetPlotType;
		}
		if (SwigDerivedClassHasMethod("setPlotWindowArea", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetPlotWindowArea;
		}
		if (SwigDerivedClassHasMethod("setPlotView", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetPlotView;
		}
		if (SwigDerivedClassHasMethod("setPrintScale", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetPrintScale;
		}
		if (SwigDerivedClassHasMethod("setStyleSheet", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetStyleSheet;
		}
		if (SwigDerivedClassHasMethod("setStdScaleType", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetStdScaleType;
		}
		if (SwigDerivedClassHasMethod("setScaleFactor", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetScaleFactor;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbSetBasePlotSettingsPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbSetBasePlotSettingsPE));
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

	private int SwigDirectorMethodsetPlotCfgName(IntPtr pPlotSetObj, [MarshalAs(UnmanagedType.LPWStr)] string plotCfgName)
	{
		return (int)setPlotCfgName(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), plotCfgName);
	}

	private int SwigDirectorMethodsetPlotLayoutFlags(IntPtr pPlotSetObj, short flags)
	{
		return (int)setPlotLayoutFlags(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), flags);
	}

	private int SwigDirectorMethodsetMargins(IntPtr pPlotSetObj, double left, double Bottom, double right, double top)
	{
		return (int)setMargins(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), left, Bottom, right, top);
	}

	private int SwigDirectorMethodsetPlotPaperSize(IntPtr pPlotSetObj, double paperWidth, double paperHeight)
	{
		return (int)setPlotPaperSize(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), paperWidth, paperHeight);
	}

	private int SwigDirectorMethodsetMediaName(IntPtr pPlotSetObj, [MarshalAs(UnmanagedType.LPWStr)] string mediaName)
	{
		return (int)setMediaName(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), mediaName);
	}

	private int SwigDirectorMethodsetOrigin(IntPtr pPlotSetObj, IntPtr origin)
	{
		return (int)setOrigin(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), new OdGePoint2d(origin, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsetPlotPaperUnits(IntPtr pPlotSetObj, int units)
	{
		return (int)setPlotPaperUnits(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), (OdDbBaseLayoutPE_PlotPaperUnits)units);
	}

	private int SwigDirectorMethodsetPlotRotation(IntPtr pPlotSetObj, int plotRotation)
	{
		return (int)setPlotRotation(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), (OdDbBaseLayoutPE_PlotRotation)plotRotation);
	}

	private int SwigDirectorMethodsetPlotType(IntPtr pPlotSetObj, int plotType)
	{
		return (int)setPlotType(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), (OdDbBaseLayoutPE_PlotType)plotType);
	}

	private int SwigDirectorMethodsetPlotWindowArea(IntPtr pPlotSetObj, double xmin, double ymin, double xmax, double ymax)
	{
		return (int)setPlotWindowArea(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), xmin, ymin, xmax, ymax);
	}

	private int SwigDirectorMethodsetPlotView(IntPtr pPlotSetObj, IntPtr plotViewId)
	{
		return (int)setPlotView(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), (plotViewId == IntPtr.Zero) ? null : new OdDbStub(plotViewId, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsetPrintScale(IntPtr pPlotSetObj, double numerator, double denominator)
	{
		return (int)setPrintScale(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), numerator, denominator);
	}

	private int SwigDirectorMethodsetStyleSheet(IntPtr pPlotSetObj, [MarshalAs(UnmanagedType.LPWStr)] string styleSheet)
	{
		return (int)setStyleSheet(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), styleSheet);
	}

	private int SwigDirectorMethodsetStdScaleType(IntPtr pPlotSetObj, int scaleType)
	{
		return (int)setStdScaleType(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), (OdDbBaseLayoutPE_StdScaleType)scaleType);
	}

	private int SwigDirectorMethodsetScaleFactor(IntPtr pPlotSetObj, double dScaleFactor)
	{
		return (int)setScaleFactor(Helpers.GetRXObject<OdRxObject>(pPlotSetObj, bOwn: false, bTryAddToTransaction: false), dScaleFactor);
	}
}

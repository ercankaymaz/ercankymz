using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbSetPlotSettingsPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbSetPlotSettingsPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbSetPlotSettingsPE_1();

	public delegate void SwigDelegateOdDbSetPlotSettingsPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_3(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string plotCfgName);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_4(IntPtr pPlotSettings, short flags);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_5(IntPtr pPlotSettings, double left, double Bottom, double right, double top);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_6(IntPtr pPlotSettings, double paperWidth, double paperHeight);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_7(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string mediaName);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_8(IntPtr pPlotSettings, IntPtr origin);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_9(IntPtr pPlotSettings, int units);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_10(IntPtr pPlotSettings, int plotRotation);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_11(IntPtr pPlotSettings, int plotType);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_12(IntPtr pPlotSettings, double xmin, double ymin, double xmax, double ymax);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_13(IntPtr pPlotSettings, IntPtr plotViewId);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_14(IntPtr pPlotSettings, double numerator, double denominator);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_15(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string styleSheet);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_16(IntPtr pPlotSettings, int scaleType);

	public delegate int SwigDelegateOdDbSetPlotSettingsPE_17(IntPtr pPlotSettings, double dScaleFactor);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbSetPlotSettingsPE_0 swigDelegate0;

	private SwigDelegateOdDbSetPlotSettingsPE_1 swigDelegate1;

	private SwigDelegateOdDbSetPlotSettingsPE_2 swigDelegate2;

	private SwigDelegateOdDbSetPlotSettingsPE_3 swigDelegate3;

	private SwigDelegateOdDbSetPlotSettingsPE_4 swigDelegate4;

	private SwigDelegateOdDbSetPlotSettingsPE_5 swigDelegate5;

	private SwigDelegateOdDbSetPlotSettingsPE_6 swigDelegate6;

	private SwigDelegateOdDbSetPlotSettingsPE_7 swigDelegate7;

	private SwigDelegateOdDbSetPlotSettingsPE_8 swigDelegate8;

	private SwigDelegateOdDbSetPlotSettingsPE_9 swigDelegate9;

	private SwigDelegateOdDbSetPlotSettingsPE_10 swigDelegate10;

	private SwigDelegateOdDbSetPlotSettingsPE_11 swigDelegate11;

	private SwigDelegateOdDbSetPlotSettingsPE_12 swigDelegate12;

	private SwigDelegateOdDbSetPlotSettingsPE_13 swigDelegate13;

	private SwigDelegateOdDbSetPlotSettingsPE_14 swigDelegate14;

	private SwigDelegateOdDbSetPlotSettingsPE_15 swigDelegate15;

	private SwigDelegateOdDbSetPlotSettingsPE_16 swigDelegate16;

	private SwigDelegateOdDbSetPlotSettingsPE_17 swigDelegate17;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(short)
	};

	private static Type[] swigMethodTypes5 = new Type[5]
	{
		typeof(OdDbPlotSettings),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdDbPlotSettings),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(string)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(OdDbPlotSettings_PlotPaperUnits)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(OdDbPlotSettings_PlotRotation)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(OdDbPlotSettings_PlotType)
	};

	private static Type[] swigMethodTypes12 = new Type[5]
	{
		typeof(OdDbPlotSettings),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes14 = new Type[3]
	{
		typeof(OdDbPlotSettings),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(string)
	};

	private static Type[] swigMethodTypes16 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(OdDbPlotSettings_StdScaleType)
	};

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(double)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSetPlotSettingsPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSetPlotSettingsPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbSetPlotSettingsPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbSetPlotSettingsPE cast(OdRxObject pObj)
	{
		OdDbSetPlotSettingsPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSetPlotSettingsPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_isASwigExplicitOdDbSetPlotSettingsPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_queryXSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult setPlotCfgName(OdDbPlotSettings pPlotSettings, string plotCfgName)
	{
		int result = (SwigDerivedClassHasMethod("setPlotCfgName", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotCfgNameSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), plotCfgName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotCfgName(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), plotCfgName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotLayoutFlags(OdDbPlotSettings pPlotSettings, short flags)
	{
		int result = (SwigDerivedClassHasMethod("setPlotLayoutFlags", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotLayoutFlagsSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), flags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotLayoutFlags(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), flags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setMargins(OdDbPlotSettings pPlotSettings, double left, double Bottom, double right, double top)
	{
		int result = (SwigDerivedClassHasMethod("setMargins", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setMarginsSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), left, Bottom, right, top) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setMargins(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), left, Bottom, right, top));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotPaperSize(OdDbPlotSettings pPlotSettings, double paperWidth, double paperHeight)
	{
		int result = (SwigDerivedClassHasMethod("setPlotPaperSize", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotPaperSizeSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), paperWidth, paperHeight) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotPaperSize(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), paperWidth, paperHeight));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setMediaName(OdDbPlotSettings pPlotSettings, string mediaName)
	{
		int result = (SwigDerivedClassHasMethod("setMediaName", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setMediaNameSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), mediaName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setMediaName(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), mediaName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setOrigin(OdDbPlotSettings pPlotSettings, OdGePoint2d origin)
	{
		int result = (SwigDerivedClassHasMethod("setOrigin", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setOriginSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), OdGePoint2d.getCPtr(origin)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setOrigin(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), OdGePoint2d.getCPtr(origin)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotPaperUnits(OdDbPlotSettings pPlotSettings, OdDbPlotSettings_PlotPaperUnits units)
	{
		int result = (SwigDerivedClassHasMethod("setPlotPaperUnits", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotPaperUnitsSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), (int)units) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotPaperUnits(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), (int)units));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotRotation(OdDbPlotSettings pPlotSettings, OdDbPlotSettings_PlotRotation plotRotation)
	{
		int result = (SwigDerivedClassHasMethod("setPlotRotation", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotRotationSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), (int)plotRotation) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotRotation(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), (int)plotRotation));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotType(OdDbPlotSettings pPlotSettings, OdDbPlotSettings_PlotType plotType)
	{
		int result = (SwigDerivedClassHasMethod("setPlotType", swigMethodTypes11) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotTypeSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), (int)plotType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotType(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), (int)plotType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotWindowArea(OdDbPlotSettings pPlotSettings, double xmin, double ymin, double xmax, double ymax)
	{
		int result = (SwigDerivedClassHasMethod("setPlotWindowArea", swigMethodTypes12) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotWindowAreaSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), xmin, ymin, xmax, ymax) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotWindowArea(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), xmin, ymin, xmax, ymax));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotView(OdDbPlotSettings pPlotSettings, OdDbObjectId plotViewId)
	{
		int result = (SwigDerivedClassHasMethod("setPlotView", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotViewSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), OdDbObjectId.getCPtr(plotViewId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPlotView(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), OdDbObjectId.getCPtr(plotViewId)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPrintScale(OdDbPlotSettings pPlotSettings, double numerator, double denominator)
	{
		int result = (SwigDerivedClassHasMethod("setPrintScale", swigMethodTypes14) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPrintScaleSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), numerator, denominator) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setPrintScale(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), numerator, denominator));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setStyleSheet(OdDbPlotSettings pPlotSettings, string styleSheet)
	{
		int result = (SwigDerivedClassHasMethod("setStyleSheet", swigMethodTypes15) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setStyleSheetSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), styleSheet) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setStyleSheet(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), styleSheet));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setScaleType(OdDbPlotSettings pPlotSettings, OdDbPlotSettings_StdScaleType scaleType)
	{
		int result = (SwigDerivedClassHasMethod("setScaleType", swigMethodTypes16) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setScaleTypeSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), (int)scaleType) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setScaleType(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), (int)scaleType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setScaleFactor(OdDbPlotSettings pPlotSettings, double dScaleFactor)
	{
		int result = (SwigDerivedClassHasMethod("setScaleFactor", swigMethodTypes17) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setScaleFactorSwigExplicitOdDbSetPlotSettingsPE(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), dScaleFactor) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_setScaleFactor(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), dScaleFactor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbSetPlotSettingsPE createObject()
	{
		OdDbSetPlotSettingsPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSetPlotSettingsPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbSetPlotSettingsPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbSetPlotSettingsPE(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbSetPlotSettingsPE) != GetType();
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
		if (SwigDerivedClassHasMethod("setScaleType", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetScaleType;
		}
		if (SwigDerivedClassHasMethod("setScaleFactor", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetScaleFactor;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSetPlotSettingsPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbSetPlotSettingsPE));
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

	private int SwigDirectorMethodsetPlotCfgName(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string plotCfgName)
	{
		return (int)setPlotCfgName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), plotCfgName);
	}

	private int SwigDirectorMethodsetPlotLayoutFlags(IntPtr pPlotSettings, short flags)
	{
		return (int)setPlotLayoutFlags(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), flags);
	}

	private int SwigDirectorMethodsetMargins(IntPtr pPlotSettings, double left, double Bottom, double right, double top)
	{
		return (int)setMargins(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), left, Bottom, right, top);
	}

	private int SwigDirectorMethodsetPlotPaperSize(IntPtr pPlotSettings, double paperWidth, double paperHeight)
	{
		return (int)setPlotPaperSize(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), paperWidth, paperHeight);
	}

	private int SwigDirectorMethodsetMediaName(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string mediaName)
	{
		return (int)setMediaName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), mediaName);
	}

	private int SwigDirectorMethodsetOrigin(IntPtr pPlotSettings, IntPtr origin)
	{
		return (int)setOrigin(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), new OdGePoint2d(origin, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsetPlotPaperUnits(IntPtr pPlotSettings, int units)
	{
		return (int)setPlotPaperUnits(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), (OdDbPlotSettings_PlotPaperUnits)units);
	}

	private int SwigDirectorMethodsetPlotRotation(IntPtr pPlotSettings, int plotRotation)
	{
		return (int)setPlotRotation(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), (OdDbPlotSettings_PlotRotation)plotRotation);
	}

	private int SwigDirectorMethodsetPlotType(IntPtr pPlotSettings, int plotType)
	{
		return (int)setPlotType(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), (OdDbPlotSettings_PlotType)plotType);
	}

	private int SwigDirectorMethodsetPlotWindowArea(IntPtr pPlotSettings, double xmin, double ymin, double xmax, double ymax)
	{
		return (int)setPlotWindowArea(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), xmin, ymin, xmax, ymax);
	}

	private int SwigDirectorMethodsetPlotView(IntPtr pPlotSettings, IntPtr plotViewId)
	{
		return (int)setPlotView(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), new OdDbObjectId(plotViewId, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsetPrintScale(IntPtr pPlotSettings, double numerator, double denominator)
	{
		return (int)setPrintScale(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), numerator, denominator);
	}

	private int SwigDirectorMethodsetStyleSheet(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string styleSheet)
	{
		return (int)setStyleSheet(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), styleSheet);
	}

	private int SwigDirectorMethodsetScaleType(IntPtr pPlotSettings, int scaleType)
	{
		return (int)setScaleType(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), (OdDbPlotSettings_StdScaleType)scaleType);
	}

	private int SwigDirectorMethodsetScaleFactor(IntPtr pPlotSettings, double dScaleFactor)
	{
		return (int)setScaleFactor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), dScaleFactor);
	}
}

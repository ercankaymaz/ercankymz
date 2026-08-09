using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbPlotSettingsValidator : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbPlotSettingsValidator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbPlotSettingsValidator_1();

	public delegate void SwigDelegateOdDbPlotSettingsValidator_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_3(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string plotDeviceName, [MarshalAs(UnmanagedType.LPWStr)] string mediaName);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_4(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string plotDeviceName);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_5(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string mediaName);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_6(IntPtr pPlotSettings, double xCoordinate, double yCoordinate);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_7(IntPtr pPlotSettings, int plotPaperUnits);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_8(IntPtr pPlotSettings, int plotRotation);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_9(IntPtr pPlotSettings, bool plotCentered);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_10(IntPtr pPlotSettings, int plotType);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_11(IntPtr pPlotSettings, double xMin, double yMin, double xMax, double yMax);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_12(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string plotViewName);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_13(IntPtr pPlotSettings, bool useStandardScale);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_14(IntPtr pPlotSettings, double numerator, double denominator);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_15(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string currentStyleSheet);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_16(IntPtr pPlotSettings, int stdScaleType);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_17(IntPtr pPlotSettings, double standardScale);

	public delegate void SwigDelegateOdDbPlotSettingsValidator_18(IntPtr deviceList);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_19(IntPtr pPlotSettings, IntPtr mediaList);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbPlotSettingsValidator_20(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string canonicalName);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbPlotSettingsValidator_21(IntPtr pPlotSettings, int mediaIndex);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_22(IntPtr pPlotSettings, double paperWidth, double paperHeight, int plotPaperUnits, bool matchPrintableArea);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_23(IntPtr styleList);

	public delegate void SwigDelegateOdDbPlotSettingsValidator_24(IntPtr pPlotSettings);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_25(IntPtr pPlotSettings, bool zoomToPaperOnUpdate);

	public delegate int SwigDelegateOdDbPlotSettingsValidator_26(IntPtr pPlotSettings);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbPlotSettingsValidator_0 swigDelegate0;

	private SwigDelegateOdDbPlotSettingsValidator_1 swigDelegate1;

	private SwigDelegateOdDbPlotSettingsValidator_2 swigDelegate2;

	private SwigDelegateOdDbPlotSettingsValidator_3 swigDelegate3;

	private SwigDelegateOdDbPlotSettingsValidator_4 swigDelegate4;

	private SwigDelegateOdDbPlotSettingsValidator_5 swigDelegate5;

	private SwigDelegateOdDbPlotSettingsValidator_6 swigDelegate6;

	private SwigDelegateOdDbPlotSettingsValidator_7 swigDelegate7;

	private SwigDelegateOdDbPlotSettingsValidator_8 swigDelegate8;

	private SwigDelegateOdDbPlotSettingsValidator_9 swigDelegate9;

	private SwigDelegateOdDbPlotSettingsValidator_10 swigDelegate10;

	private SwigDelegateOdDbPlotSettingsValidator_11 swigDelegate11;

	private SwigDelegateOdDbPlotSettingsValidator_12 swigDelegate12;

	private SwigDelegateOdDbPlotSettingsValidator_13 swigDelegate13;

	private SwigDelegateOdDbPlotSettingsValidator_14 swigDelegate14;

	private SwigDelegateOdDbPlotSettingsValidator_15 swigDelegate15;

	private SwigDelegateOdDbPlotSettingsValidator_16 swigDelegate16;

	private SwigDelegateOdDbPlotSettingsValidator_17 swigDelegate17;

	private SwigDelegateOdDbPlotSettingsValidator_18 swigDelegate18;

	private SwigDelegateOdDbPlotSettingsValidator_19 swigDelegate19;

	private SwigDelegateOdDbPlotSettingsValidator_20 swigDelegate20;

	private SwigDelegateOdDbPlotSettingsValidator_21 swigDelegate21;

	private SwigDelegateOdDbPlotSettingsValidator_22 swigDelegate22;

	private SwigDelegateOdDbPlotSettingsValidator_23 swigDelegate23;

	private SwigDelegateOdDbPlotSettingsValidator_24 swigDelegate24;

	private SwigDelegateOdDbPlotSettingsValidator_25 swigDelegate25;

	private SwigDelegateOdDbPlotSettingsValidator_26 swigDelegate26;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdDbPlotSettings),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(string)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(string)
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
		typeof(OdDbPlotSettings_PlotPaperUnits)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(OdDbPlotSettings_PlotRotation)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(bool)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(OdDbPlotSettings_PlotType)
	};

	private static Type[] swigMethodTypes11 = new Type[5]
	{
		typeof(OdDbPlotSettings),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(string)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(bool)
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

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdStringArray) };

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(OdStringArray)
	};

	private static Type[] swigMethodTypes20 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(string)
	};

	private static Type[] swigMethodTypes21 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(int)
	};

	private static Type[] swigMethodTypes22 = new Type[5]
	{
		typeof(OdDbPlotSettings),
		typeof(double),
		typeof(double),
		typeof(OdDbPlotSettings_PlotPaperUnits),
		typeof(bool)
	};

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(OdStringArray) };

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdDbPlotSettings) };

	private static Type[] swigMethodTypes25 = new Type[2]
	{
		typeof(OdDbPlotSettings),
		typeof(bool)
	};

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdDbPlotSettings) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbPlotSettingsValidator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbPlotSettingsValidator obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbPlotSettingsValidator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbPlotSettingsValidator()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbPlotSettingsValidator(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbPlotSettingsValidator cast(OdRxObject pObj)
	{
		OdDbPlotSettingsValidator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettingsValidator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_isASwigExplicitOdDbPlotSettingsValidator(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_queryXSwigExplicitOdDbPlotSettingsValidator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbPlotSettingsValidator createObject()
	{
		OdDbPlotSettingsValidator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettingsValidator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult setPlotCfgName(OdDbPlotSettings pPlotSettings, string plotDeviceName, string mediaName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setPlotCfgName__SWIG_0(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), plotDeviceName, mediaName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotCfgName(OdDbPlotSettings pPlotSettings, string plotDeviceName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setPlotCfgName__SWIG_1(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), plotDeviceName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setCanonicalMediaName(OdDbPlotSettings pPlotSettings, string mediaName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setCanonicalMediaName(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), mediaName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotOrigin(OdDbPlotSettings pPlotSettings, double xCoordinate, double yCoordinate)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setPlotOrigin(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), xCoordinate, yCoordinate);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotPaperUnits(OdDbPlotSettings pPlotSettings, OdDbPlotSettings_PlotPaperUnits plotPaperUnits)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setPlotPaperUnits(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), (int)plotPaperUnits);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotRotation(OdDbPlotSettings pPlotSettings, OdDbPlotSettings_PlotRotation plotRotation)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setPlotRotation(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), (int)plotRotation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotCentered(OdDbPlotSettings pPlotSettings, bool plotCentered)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setPlotCentered(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), plotCentered);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotType(OdDbPlotSettings pPlotSettings, OdDbPlotSettings_PlotType plotType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setPlotType(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), (int)plotType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotWindowArea(OdDbPlotSettings pPlotSettings, double xMin, double yMin, double xMax, double yMax)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setPlotWindowArea(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), xMin, yMin, xMax, yMax);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPlotViewName(OdDbPlotSettings pPlotSettings, string plotViewName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setPlotViewName(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), plotViewName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setUseStandardScale(OdDbPlotSettings pPlotSettings, bool useStandardScale)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setUseStandardScale(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), useStandardScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setCustomPrintScale(OdDbPlotSettings pPlotSettings, double numerator, double denominator)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setCustomPrintScale(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), numerator, denominator);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setCurrentStyleSheet(OdDbPlotSettings pPlotSettings, string currentStyleSheet)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setCurrentStyleSheet(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), currentStyleSheet);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setStdScaleType(OdDbPlotSettings pPlotSettings, OdDbPlotSettings_StdScaleType stdScaleType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setStdScaleType(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), (int)stdScaleType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setStdScale(OdDbPlotSettings pPlotSettings, double standardScale)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setStdScale(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), standardScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void plotDeviceList(OdStringArray deviceList)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_plotDeviceList(swigCPtr, OdStringArray.getCPtr(deviceList).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult canonicalMediaNameList(OdDbPlotSettings pPlotSettings, OdStringArray mediaList)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_canonicalMediaNameList(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), OdStringArray.getCPtr(mediaList).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual string getLocaleMediaName(OdDbPlotSettings pPlotSettings, string canonicalName)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_getLocaleMediaName__SWIG_0(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), canonicalName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getLocaleMediaName(OdDbPlotSettings pPlotSettings, int mediaIndex)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_getLocaleMediaName__SWIG_1(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), mediaIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setClosestMediaName(OdDbPlotSettings pPlotSettings, double paperWidth, double paperHeight, OdDbPlotSettings_PlotPaperUnits plotPaperUnits, bool matchPrintableArea)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setClosestMediaName(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), paperWidth, paperHeight, (int)plotPaperUnits, matchPrintableArea);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult plotStyleSheetList(OdStringArray styleList)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_plotStyleSheetList(swigCPtr, OdStringArray.getCPtr(styleList).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void refreshLists(OdDbPlotSettings pPlotSettings)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_refreshLists(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult setZoomToPaperOnUpdate(OdDbPlotSettings pPlotSettings, bool zoomToPaperOnUpdate)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setZoomToPaperOnUpdate(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings), zoomToPaperOnUpdate);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setDefaultPlotConfig(OdDbPlotSettings pPlotSettings)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_setDefaultPlotConfig(swigCPtr, OdDbPlotSettings.getCPtr(pPlotSettings));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("setPlotCfgName", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetPlotCfgName__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setPlotCfgName", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetPlotCfgName__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setCanonicalMediaName", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetCanonicalMediaName;
		}
		if (SwigDerivedClassHasMethod("setPlotOrigin", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetPlotOrigin;
		}
		if (SwigDerivedClassHasMethod("setPlotPaperUnits", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetPlotPaperUnits;
		}
		if (SwigDerivedClassHasMethod("setPlotRotation", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetPlotRotation;
		}
		if (SwigDerivedClassHasMethod("setPlotCentered", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetPlotCentered;
		}
		if (SwigDerivedClassHasMethod("setPlotType", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetPlotType;
		}
		if (SwigDerivedClassHasMethod("setPlotWindowArea", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetPlotWindowArea;
		}
		if (SwigDerivedClassHasMethod("setPlotViewName", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetPlotViewName;
		}
		if (SwigDerivedClassHasMethod("setUseStandardScale", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetUseStandardScale;
		}
		if (SwigDerivedClassHasMethod("setCustomPrintScale", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetCustomPrintScale;
		}
		if (SwigDerivedClassHasMethod("setCurrentStyleSheet", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetCurrentStyleSheet;
		}
		if (SwigDerivedClassHasMethod("setStdScaleType", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetStdScaleType;
		}
		if (SwigDerivedClassHasMethod("setStdScale", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetStdScale;
		}
		if (SwigDerivedClassHasMethod("plotDeviceList", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodplotDeviceList;
		}
		if (SwigDerivedClassHasMethod("canonicalMediaNameList", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodcanonicalMediaNameList;
		}
		if (SwigDerivedClassHasMethod("getLocaleMediaName", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetLocaleMediaName__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getLocaleMediaName", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodgetLocaleMediaName__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setClosestMediaName", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodsetClosestMediaName;
		}
		if (SwigDerivedClassHasMethod("plotStyleSheetList", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodplotStyleSheetList;
		}
		if (SwigDerivedClassHasMethod("refreshLists", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodrefreshLists;
		}
		if (SwigDerivedClassHasMethod("setZoomToPaperOnUpdate", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetZoomToPaperOnUpdate;
		}
		if (SwigDerivedClassHasMethod("setDefaultPlotConfig", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodsetDefaultPlotConfig;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPlotSettingsValidator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbPlotSettingsValidator));
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

	private int SwigDirectorMethodsetPlotCfgName__SWIG_0(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string plotDeviceName, [MarshalAs(UnmanagedType.LPWStr)] string mediaName)
	{
		return (int)setPlotCfgName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), plotDeviceName, mediaName);
	}

	private int SwigDirectorMethodsetPlotCfgName__SWIG_1(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string plotDeviceName)
	{
		return (int)setPlotCfgName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), plotDeviceName);
	}

	private int SwigDirectorMethodsetCanonicalMediaName(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string mediaName)
	{
		return (int)setCanonicalMediaName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), mediaName);
	}

	private int SwigDirectorMethodsetPlotOrigin(IntPtr pPlotSettings, double xCoordinate, double yCoordinate)
	{
		return (int)setPlotOrigin(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), xCoordinate, yCoordinate);
	}

	private int SwigDirectorMethodsetPlotPaperUnits(IntPtr pPlotSettings, int plotPaperUnits)
	{
		return (int)setPlotPaperUnits(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), (OdDbPlotSettings_PlotPaperUnits)plotPaperUnits);
	}

	private int SwigDirectorMethodsetPlotRotation(IntPtr pPlotSettings, int plotRotation)
	{
		return (int)setPlotRotation(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), (OdDbPlotSettings_PlotRotation)plotRotation);
	}

	private int SwigDirectorMethodsetPlotCentered(IntPtr pPlotSettings, bool plotCentered)
	{
		return (int)setPlotCentered(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), plotCentered);
	}

	private int SwigDirectorMethodsetPlotType(IntPtr pPlotSettings, int plotType)
	{
		return (int)setPlotType(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), (OdDbPlotSettings_PlotType)plotType);
	}

	private int SwigDirectorMethodsetPlotWindowArea(IntPtr pPlotSettings, double xMin, double yMin, double xMax, double yMax)
	{
		return (int)setPlotWindowArea(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), xMin, yMin, xMax, yMax);
	}

	private int SwigDirectorMethodsetPlotViewName(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string plotViewName)
	{
		return (int)setPlotViewName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), plotViewName);
	}

	private int SwigDirectorMethodsetUseStandardScale(IntPtr pPlotSettings, bool useStandardScale)
	{
		return (int)setUseStandardScale(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), useStandardScale);
	}

	private int SwigDirectorMethodsetCustomPrintScale(IntPtr pPlotSettings, double numerator, double denominator)
	{
		return (int)setCustomPrintScale(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), numerator, denominator);
	}

	private int SwigDirectorMethodsetCurrentStyleSheet(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string currentStyleSheet)
	{
		return (int)setCurrentStyleSheet(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), currentStyleSheet);
	}

	private int SwigDirectorMethodsetStdScaleType(IntPtr pPlotSettings, int stdScaleType)
	{
		return (int)setStdScaleType(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), (OdDbPlotSettings_StdScaleType)stdScaleType);
	}

	private int SwigDirectorMethodsetStdScale(IntPtr pPlotSettings, double standardScale)
	{
		return (int)setStdScale(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), standardScale);
	}

	private void SwigDirectorMethodplotDeviceList(IntPtr deviceList)
	{
		try
		{
			plotDeviceList(new OdStringArray(deviceList, cMemoryOwn: false));
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

	private int SwigDirectorMethodcanonicalMediaNameList(IntPtr pPlotSettings, IntPtr mediaList)
	{
		return (int)canonicalMediaNameList(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), new OdStringArray(mediaList, cMemoryOwn: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetLocaleMediaName__SWIG_0(IntPtr pPlotSettings, [MarshalAs(UnmanagedType.LPWStr)] string canonicalName)
	{
		return getLocaleMediaName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), canonicalName);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetLocaleMediaName__SWIG_1(IntPtr pPlotSettings, int mediaIndex)
	{
		return getLocaleMediaName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), mediaIndex);
	}

	private int SwigDirectorMethodsetClosestMediaName(IntPtr pPlotSettings, double paperWidth, double paperHeight, int plotPaperUnits, bool matchPrintableArea)
	{
		return (int)setClosestMediaName(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), paperWidth, paperHeight, (OdDbPlotSettings_PlotPaperUnits)plotPaperUnits, matchPrintableArea);
	}

	private int SwigDirectorMethodplotStyleSheetList(IntPtr styleList)
	{
		return (int)plotStyleSheetList(new OdStringArray(styleList, cMemoryOwn: false));
	}

	private void SwigDirectorMethodrefreshLists(IntPtr pPlotSettings)
	{
		try
		{
			refreshLists(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodsetZoomToPaperOnUpdate(IntPtr pPlotSettings, bool zoomToPaperOnUpdate)
	{
		return (int)setZoomToPaperOnUpdate(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false), zoomToPaperOnUpdate);
	}

	private int SwigDirectorMethodsetDefaultPlotConfig(IntPtr pPlotSettings)
	{
		return (int)setDefaultPlotConfig(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettings>(pPlotSettings, bOwn: false, bTryAddToTransaction: false));
	}
}

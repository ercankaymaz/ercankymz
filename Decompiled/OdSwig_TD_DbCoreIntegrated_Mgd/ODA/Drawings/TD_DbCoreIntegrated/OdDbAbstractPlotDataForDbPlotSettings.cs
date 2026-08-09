using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbAbstractPlotDataForDbPlotSettings : OdDbAbstractPlotData
{
	public delegate IntPtr SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_1();

	public delegate void SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_3(IntPtr pDstPlotObj, IntPtr pSrcPlotObj);

	public delegate bool SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_4(IntPtr pPlotObj);

	public delegate double SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_5(IntPtr pPlotObj);

	public delegate void SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_6(IntPtr pPlotObj, double customScale);

	public delegate int SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_7(IntPtr pPlotObj);

	public delegate void SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_8(IntPtr pPlotObj, int standardScale);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_9(IntPtr pPlotObj);

	public delegate void SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_10(IntPtr pPlotObj, [MarshalAs(UnmanagedType.LPWStr)] string styleSheetName);

	public delegate int SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_11(IntPtr pPlotObj);

	public delegate void SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_12(IntPtr pPlotObj, int shadePlotSet);

	public delegate IntPtr SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_13(IntPtr pPlotObj);

	public delegate void SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_14(IntPtr pPlotObj, int type, IntPtr shadePlotId);

	public delegate bool SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_15(IntPtr pPlotObj);

	public delegate void SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_16(IntPtr pPlotObj, bool plotHidden);

	public delegate bool SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_17(IntPtr pPlotObj);

	public delegate bool SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_18(IntPtr pPlotObj);

	public delegate bool SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_19(IntPtr pPlotObj);

	public delegate void SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_20(IntPtr pPlotObj, bool bEnable);

	public delegate bool SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_21(IntPtr pPlotObj);

	public delegate void SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_22(IntPtr pPlotObj, bool bEnable);

	public delegate bool SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_23(IntPtr pPlotObj);

	public delegate void SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_24(IntPtr pPlotObj, bool modelTypeSet);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_0 swigDelegate0;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_1 swigDelegate1;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_2 swigDelegate2;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_3 swigDelegate3;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_4 swigDelegate4;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_5 swigDelegate5;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_6 swigDelegate6;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_7 swigDelegate7;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_8 swigDelegate8;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_9 swigDelegate9;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_10 swigDelegate10;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_11 swigDelegate11;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_12 swigDelegate12;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_13 swigDelegate13;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_14 swigDelegate14;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_15 swigDelegate15;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_16 swigDelegate16;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_17 swigDelegate17;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_18 swigDelegate18;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_19 swigDelegate19;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_20 swigDelegate20;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_21 swigDelegate21;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_22 swigDelegate22;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_23 swigDelegate23;

	private SwigDelegateOdDbAbstractPlotDataForDbPlotSettings_24 swigDelegate24;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(double)
	};

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbPlotSettings_StdScaleType)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbPlotSettings_ShadePlotType)
	};

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes14 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdDbPlotSettings_ShadePlotType),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes16 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes20 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes22 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes24 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbAbstractPlotDataForDbPlotSettings(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbAbstractPlotDataForDbPlotSettings obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbAbstractPlotDataForDbPlotSettings(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbAbstractPlotDataForDbPlotSettings cast(OdRxObject pObj)
	{
		OdDbAbstractPlotDataForDbPlotSettings rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAbstractPlotDataForDbPlotSettings>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_isASwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_queryXSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override bool useStandardScale(OdRxObject pPlotObj)
	{
		bool result = (SwigDerivedClassHasMethod("useStandardScale", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_useStandardScaleSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_useStandardScale(swigCPtr, OdRxObject.getCPtr(pPlotObj)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double customScale(OdRxObject pPlotObj)
	{
		double result = (SwigDerivedClassHasMethod("customScale", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_customScaleSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_customScale(swigCPtr, OdRxObject.getCPtr(pPlotObj)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setCustomScale(OdRxObject pPlotObj, double customScale)
	{
		if (SwigDerivedClassHasMethod("setCustomScale", swigMethodTypes6))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setCustomScaleSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj), customScale);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setCustomScale(swigCPtr, OdRxObject.getCPtr(pPlotObj), customScale);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbPlotSettings_StdScaleType standardScale(OdRxObject pPlotObj)
	{
		int result = (SwigDerivedClassHasMethod("standardScale", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_standardScaleSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_standardScale(swigCPtr, OdRxObject.getCPtr(pPlotObj)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbPlotSettings_StdScaleType)result;
	}

	public override void setStandardScale(OdRxObject pPlotObj, OdDbPlotSettings_StdScaleType standardScale)
	{
		if (SwigDerivedClassHasMethod("setStandardScale", swigMethodTypes8))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setStandardScaleSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj), (int)standardScale);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setStandardScale(swigCPtr, OdRxObject.getCPtr(pPlotObj), (int)standardScale);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override string styleSheet(OdRxObject pPlotObj)
	{
		string result = (SwigDerivedClassHasMethod("styleSheet", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_styleSheetSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_styleSheet(swigCPtr, OdRxObject.getCPtr(pPlotObj)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setStyleSheet(OdRxObject pPlotObj, string styleSheetName)
	{
		if (SwigDerivedClassHasMethod("setStyleSheet", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setStyleSheetSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj), styleSheetName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setStyleSheet(swigCPtr, OdRxObject.getCPtr(pPlotObj), styleSheetName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbPlotSettings_ShadePlotType shadePlot(OdRxObject pPlotObj)
	{
		int result = (SwigDerivedClassHasMethod("shadePlot", swigMethodTypes11) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_shadePlotSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_shadePlot(swigCPtr, OdRxObject.getCPtr(pPlotObj)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbPlotSettings_ShadePlotType)result;
	}

	public override void setShadePlot(OdRxObject pPlotObj, OdDbPlotSettings_ShadePlotType shadePlotSet)
	{
		if (SwigDerivedClassHasMethod("setShadePlot", swigMethodTypes12))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setShadePlotSwigExplicitOdDbAbstractPlotDataForDbPlotSettings__SWIG_0(swigCPtr, OdRxObject.getCPtr(pPlotObj), (int)shadePlotSet);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setShadePlot__SWIG_0(swigCPtr, OdRxObject.getCPtr(pPlotObj), (int)shadePlotSet);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbObjectId shadePlotId(OdRxObject pPlotObj)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("shadePlotId", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_shadePlotIdSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_shadePlotId(swigCPtr, OdRxObject.getCPtr(pPlotObj)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setShadePlot(OdRxObject pPlotObj, OdDbPlotSettings_ShadePlotType type, OdDbObjectId shadePlotId)
	{
		if (SwigDerivedClassHasMethod("setShadePlot", swigMethodTypes14))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setShadePlotSwigExplicitOdDbAbstractPlotDataForDbPlotSettings__SWIG_1(swigCPtr, OdRxObject.getCPtr(pPlotObj), (int)type, OdDbObjectId.getCPtr(shadePlotId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setShadePlot__SWIG_1(swigCPtr, OdRxObject.getCPtr(pPlotObj), (int)type, OdDbObjectId.getCPtr(shadePlotId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool plotHiddenLines(OdRxObject pPlotObj)
	{
		bool result = (SwigDerivedClassHasMethod("plotHiddenLines", swigMethodTypes15) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_plotHiddenLinesSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_plotHiddenLines(swigCPtr, OdRxObject.getCPtr(pPlotObj)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setPlotHiddenLines(OdRxObject pPlotObj, bool plotHidden)
	{
		if (SwigDerivedClassHasMethod("setPlotHiddenLines", swigMethodTypes16))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setPlotHiddenLinesSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj), plotHidden);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setPlotHiddenLines(swigCPtr, OdRxObject.getCPtr(pPlotObj), plotHidden);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool plotWireframe(OdRxObject pPlotObj)
	{
		bool result = (SwigDerivedClassHasMethod("plotWireframe", swigMethodTypes17) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_plotWireframeSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_plotWireframe(swigCPtr, OdRxObject.getCPtr(pPlotObj)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool plotAsRaster(OdRxObject pPlotObj)
	{
		bool result = (SwigDerivedClassHasMethod("plotAsRaster", swigMethodTypes18) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_plotAsRasterSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_plotAsRaster(swigCPtr, OdRxObject.getCPtr(pPlotObj)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool plotTransparency(OdRxObject pPlotObj)
	{
		bool result = (SwigDerivedClassHasMethod("plotTransparency", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_plotTransparencySwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_plotTransparency(swigCPtr, OdRxObject.getCPtr(pPlotObj)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setPlotTransparency(OdRxObject pPlotObj, bool bEnable)
	{
		if (SwigDerivedClassHasMethod("setPlotTransparency", swigMethodTypes20))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setPlotTransparencySwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj), bEnable);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setPlotTransparency(swigCPtr, OdRxObject.getCPtr(pPlotObj), bEnable);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool plotLineweights(OdRxObject pPlotObj)
	{
		bool result = (SwigDerivedClassHasMethod("plotLineweights", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_plotLineweightsSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_plotLineweights(swigCPtr, OdRxObject.getCPtr(pPlotObj)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setPlotLineweights(OdRxObject pPlotObj, bool bEnable)
	{
		if (SwigDerivedClassHasMethod("setPlotLineweights", swigMethodTypes22))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setPlotLineweightsSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj), bEnable);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setPlotLineweights(swigCPtr, OdRxObject.getCPtr(pPlotObj), bEnable);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool modelType(OdRxObject pPlotObj)
	{
		bool result = (SwigDerivedClassHasMethod("modelType", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_modelTypeSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_modelType(swigCPtr, OdRxObject.getCPtr(pPlotObj)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setModelType(OdRxObject pPlotObj, bool modelTypeSet)
	{
		if (SwigDerivedClassHasMethod("setModelType", swigMethodTypes24))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setModelTypeSwigExplicitOdDbAbstractPlotDataForDbPlotSettings(swigCPtr, OdRxObject.getCPtr(pPlotObj), modelTypeSet);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_setModelType(swigCPtr, OdRxObject.getCPtr(pPlotObj), modelTypeSet);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbAbstractPlotDataForDbPlotSettings createObject()
	{
		OdDbAbstractPlotDataForDbPlotSettings rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAbstractPlotDataForDbPlotSettings>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("setProps", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetProps;
		}
		if (SwigDerivedClassHasMethod("useStandardScale", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoduseStandardScale;
		}
		if (SwigDerivedClassHasMethod("customScale", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcustomScale;
		}
		if (SwigDerivedClassHasMethod("setCustomScale", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetCustomScale;
		}
		if (SwigDerivedClassHasMethod("standardScale", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodstandardScale;
		}
		if (SwigDerivedClassHasMethod("setStandardScale", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetStandardScale;
		}
		if (SwigDerivedClassHasMethod("styleSheet", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodstyleSheet;
		}
		if (SwigDerivedClassHasMethod("setStyleSheet", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetStyleSheet;
		}
		if (SwigDerivedClassHasMethod("shadePlot", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodshadePlot;
		}
		if (SwigDerivedClassHasMethod("setShadePlot", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetShadePlot__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("shadePlotId", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodshadePlotId;
		}
		if (SwigDerivedClassHasMethod("setShadePlot", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetShadePlot__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("plotHiddenLines", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodplotHiddenLines;
		}
		if (SwigDerivedClassHasMethod("setPlotHiddenLines", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetPlotHiddenLines;
		}
		if (SwigDerivedClassHasMethod("plotWireframe", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodplotWireframe;
		}
		if (SwigDerivedClassHasMethod("plotAsRaster", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodplotAsRaster;
		}
		if (SwigDerivedClassHasMethod("plotTransparency", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodplotTransparency;
		}
		if (SwigDerivedClassHasMethod("setPlotTransparency", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsetPlotTransparency;
		}
		if (SwigDerivedClassHasMethod("plotLineweights", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodplotLineweights;
		}
		if (SwigDerivedClassHasMethod("setPlotLineweights", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodsetPlotLineweights;
		}
		if (SwigDerivedClassHasMethod("modelType", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodmodelType;
		}
		if (SwigDerivedClassHasMethod("setModelType", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsetModelType;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbPlotSettings_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbAbstractPlotDataForDbPlotSettings));
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

	private void SwigDirectorMethodsetProps(IntPtr pDstPlotObj, IntPtr pSrcPlotObj)
	{
		try
		{
			setProps(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pDstPlotObj, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSrcPlotObj, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethoduseStandardScale(IntPtr pPlotObj)
	{
		return useStandardScale(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodcustomScale(IntPtr pPlotObj)
	{
		return customScale(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetCustomScale(IntPtr pPlotObj, double customScale)
	{
		try
		{
			setCustomScale(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false), customScale);
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

	private int SwigDirectorMethodstandardScale(IntPtr pPlotObj)
	{
		return (int)standardScale(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetStandardScale(IntPtr pPlotObj, int standardScale)
	{
		try
		{
			setStandardScale(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false), (OdDbPlotSettings_StdScaleType)standardScale);
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
	private string SwigDirectorMethodstyleSheet(IntPtr pPlotObj)
	{
		return styleSheet(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetStyleSheet(IntPtr pPlotObj, [MarshalAs(UnmanagedType.LPWStr)] string styleSheetName)
	{
		try
		{
			setStyleSheet(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false), styleSheetName);
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

	private int SwigDirectorMethodshadePlot(IntPtr pPlotObj)
	{
		return (int)shadePlot(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetShadePlot__SWIG_0(IntPtr pPlotObj, int shadePlotSet)
	{
		try
		{
			setShadePlot(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false), (OdDbPlotSettings_ShadePlotType)shadePlotSet);
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

	private IntPtr SwigDirectorMethodshadePlotId(IntPtr pPlotObj)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(shadePlotId(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private void SwigDirectorMethodsetShadePlot__SWIG_1(IntPtr pPlotObj, int type, IntPtr shadePlotId)
	{
		try
		{
			setShadePlot(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false), (OdDbPlotSettings_ShadePlotType)type, new OdDbObjectId(shadePlotId, cMemoryOwn: true));
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

	private bool SwigDirectorMethodplotHiddenLines(IntPtr pPlotObj)
	{
		return plotHiddenLines(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetPlotHiddenLines(IntPtr pPlotObj, bool plotHidden)
	{
		try
		{
			setPlotHiddenLines(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false), plotHidden);
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

	private bool SwigDirectorMethodplotWireframe(IntPtr pPlotObj)
	{
		return plotWireframe(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodplotAsRaster(IntPtr pPlotObj)
	{
		return plotAsRaster(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodplotTransparency(IntPtr pPlotObj)
	{
		return plotTransparency(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetPlotTransparency(IntPtr pPlotObj, bool bEnable)
	{
		try
		{
			setPlotTransparency(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false), bEnable);
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

	private bool SwigDirectorMethodplotLineweights(IntPtr pPlotObj)
	{
		return plotLineweights(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetPlotLineweights(IntPtr pPlotObj, bool bEnable)
	{
		try
		{
			setPlotLineweights(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false), bEnable);
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

	private bool SwigDirectorMethodmodelType(IntPtr pPlotObj)
	{
		return modelType(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetModelType(IntPtr pPlotObj, bool modelTypeSet)
	{
		try
		{
			setModelType(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pPlotObj, bOwn: false, bTryAddToTransaction: false), modelTypeSet);
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
